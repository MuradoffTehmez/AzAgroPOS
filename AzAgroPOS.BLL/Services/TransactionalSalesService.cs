using AzAgroPOS.BLL.Interfaces;
using AzAgroPOS.DAL.Interfaces;
using AzAgroPOS.Entities.Constants;
using AzAgroPOS.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.BLL.Services
{
    /// <summary>
    /// Tranzaksiya bütövlüyünü təmin edən satış servisi
    /// CİDDİ MƏNTİQ XƏTASI: Tranzaksiya Bütövlüyünün Pozulması problemini həll edir
    /// </summary>
    public class TransactionalSalesService : BaseDisposableService
    {
        private readonly IAuditLogService _auditLogService;

        public TransactionalSalesService(IUnitOfWork unitOfWork, ILoggerService logger = null, IAuditLogService auditLogService = null)
            : base(unitOfWork, logger)
        {
            _auditLogService = auditLogService;
        }

        /// <summary>
        /// Kompleks satış əməliyyatını vahid tranzaksiya ilə icra edir
        /// Bütün əməliyyatlar uğurlu olmalıdır, əks halda heç biri yazılmır
        /// </summary>
        /// <param name="satis">Satış məlumatları</param>
        /// <param name="satisDetallari">Satış detalları</param>
        /// <param name="istifadeciId">İstifadəçi ID</param>
        /// <returns>Satış nəticəsi</returns>
        public async Task<SalesTransactionResult> CreateComplexSaleAsync(
            Satis satis, 
            List<SatisDetali> satisDetallari, 
            int istifadeciId)
        {
            ThrowIfDisposed();
            
            if (satis == null)
                throw new ArgumentNullException(nameof(satis));
            
            if (satisDetallari == null || !satisDetallari.Any())
                throw new ArgumentException("Satış detalları boş ola bilməz");

            var result = new SalesTransactionResult();
            
            try
            {
                // Audit log başlanğıcı
                _auditLogService?.LogAction(
                    SystemConstants.EntityNames.Satis,
                    SystemConstants.DatabaseOperations.Create,
                    null,
                    $"Satış əməliyyatı başladı - {satisDetallari.Count} məhsul",
                    istifadeciId);

                // 1. Ön yoxlamalar - verilənlər bazasına yazmazdan əvvəl
                var preValidationResult = await PreValidateTransactionAsync(satis, satisDetallari);
                if (!preValidationResult.IsValid)
                {
                    result.IsSuccess = false;
                    result.ErrorMessage = preValidationResult.ErrorMessage;
                    return result;
                }

                // 2. Satış əməliyyatını yaradırıq (hələ bazaya yazılmır)
                satis.SatisTarixi = DateTime.Now;
                satis.KassirId = istifadeciId;
                satis.Status = SystemConstants.Status.Active;
                
                await _unitOfWork.Satislar.AddAsync(satis);
                _logger?.LogInfo($"Satış əməliyyatı kontekstə əlavə edildi: Müştəri ID {satis.MusteriId}");

                // 3. Satış detallarını və anbar qalıqlarını yenilə
                decimal totalAmount = 0;
                var processedProducts = new List<ProductStockChange>();
                
                foreach (var detal in satisDetallari)
                {
                    var stockChangeResult = await ProcessSaleDetailAsync(detal, satis.Id);
                    if (!stockChangeResult.IsSuccess)
                    {
                        result.IsSuccess = false;
                        result.ErrorMessage = stockChangeResult.ErrorMessage;
                        return result;
                    }
                    
                    totalAmount += detal.Miqdar * detal.VahidQiymeti;
                    processedProducts.Add(stockChangeResult);
                }

                // 4. Satış məbləğini yenilə
                satis.UmumiMebleg = totalAmount;
                await _unitOfWork.Satislar.UpdateAsync(satis);

                // 5. Müştəri borcunu yenilə (əgər nağd olmayan satışdırsa)
                if (satis.OdemeNovu != "Nağd")
                {
                    await UpdateCustomerDebtAsync(satis.MusteriId, totalAmount);
                }

                // 6. Bütün dəyişiklikləri vahid tranzaksiya ilə bazaya yaz
                await _unitOfWork.CompleteAsync();

                // 7. Uğur audit log-u
                _auditLogService?.LogAction(
                    SystemConstants.EntityNames.Satis,
                    SystemConstants.DatabaseOperations.Create,
                    satis.Id,
                    $"Satış uğurla tamamlandı - Məbləğ: {totalAmount:C}",
                    istifadeciId);

                result.IsSuccess = true;
                result.SalesId = satis.Id;
                result.TotalAmount = totalAmount;
                result.ProcessedProducts = processedProducts;
                result.Message = "Satış uğurla tamamlandı";

                _logger?.LogInfo($"Kompleks satış əməliyyatı uğurla tamamlandı: ID {satis.Id}, Məbləğ: {totalAmount:C}");
                
                return result;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Optimistic Concurrency Exception - race condition detected
                _auditLogService?.LogError("Race condition detected in sales transaction", ex);
                
                result.IsSuccess = false;
                result.ErrorMessage = "Başqa istifadəçi eyni məhsulda dəyişiklik edib. Yenidən cəhd edin.";
                result.Exception = ex;
                
                _logger?.LogError(new Exception("Race condition in sales transaction", ex));
                
                return result;
            }
            catch (Exception ex)
            {
                // Xəta zamanı audit log
                _auditLogService?.LogError("Satış əməliyyatı xətası", ex);
                
                result.IsSuccess = false;
                result.ErrorMessage = $"Satış əməliyyatı zamanı xəta: {ex.Message}";
                result.Exception = ex;
                
                _logger?.LogError(new Exception("Kompleks satış əməliyyatı xətası", ex));
                
                // UnitOfWork Complete() çağırılmadığı üçün
                // bütün dəyişikliklər avtomatik geri qaytarılır
                return result;
            }
        }

        /// <summary>
        /// Satış əməliyyatından əvvəl ön yoxlamalar
        /// </summary>
        private async Task<ValidationResult> PreValidateTransactionAsync(Satis satis, List<SatisDetali> satisDetallari)
        {
            var result = new ValidationResult { IsValid = true };
            
            // Müştəri yoxlaması
            if (satis.MusteriId.HasValue)
            {
                var musteri = _unitOfWork.Musteriler.GetById(satis.MusteriId.Value);
                if (musteri == null)
                {
                    result.IsValid = false;
                    result.ErrorMessage = "Müştəri tapılmadı";
                    return result;
                }
                
                if (musteri.Status != SystemConstants.Status.Active)
                {
                    result.IsValid = false;
                    result.ErrorMessage = $"Müştəri aktiv deyil: {musteri.Status}";
                    return result;
                }
            }

            // Məhsul və anbar yoxlaması
            foreach (var detal in satisDetallari)
            {
                var mehsul = await _unitOfWork.Mehsullar.GetByIdAsync(detal.MehsulId);
                if (mehsul == null)
                {
                    result.IsValid = false;
                    result.ErrorMessage = $"Məhsul tapılmadı: ID {detal.MehsulId}";
                    return result;
                }

                // Anbar qalığı yoxlaması
                var anbarQaliq = _unitOfWork.AnbarQaliqlari.GetByAnbarVeMehsul(1, detal.MehsulId);
                if (anbarQaliq == null || anbarQaliq.MovcudMiqdar < detal.Miqdar)
                {
                    result.IsValid = false;
                    result.ErrorMessage = $"Kifayət qədər stok yoxdur: {mehsul.Ad}. Mövcud: {anbarQaliq?.MovcudMiqdar ?? 0}, Tələb: {detal.Miqdar}";
                    return result;
                }

                // Qiymət yoxlaması
                if (detal.VahidQiymeti <= 0)
                {
                    result.IsValid = false;
                    result.ErrorMessage = $"Satış qiyməti düzgün deyil: {detal.VahidQiymeti}";
                    return result;
                }
            }

            return result;
        }

        /// <summary>
        /// Satış detalını prosess edir və anbar qalığını azaldır
        /// </summary>
        private async Task<ProductStockChange> ProcessSaleDetailAsync(SatisDetali detal, int satisId)
        {
            var result = new ProductStockChange { IsSuccess = true };
            
            try
            {
                // Satış detalını əlavə et
                detal.SatisId = satisId;
                await _unitOfWork.SatisDetallari.AddAsync(detal);

                // Məhsul məlumatını al
                var mehsul = await _unitOfWork.Mehsullar.GetByIdAsync(detal.MehsulId);
                result.ProductId = detal.MehsulId;
                result.ProductName = mehsul.Ad;
                result.QuantitySold = detal.Miqdar;
                result.OldStock = mehsul.MovcudMiqdar;

                // Anbar qalığını azalt
                var anbarQaliq = _unitOfWork.AnbarQaliqlari.GetByAnbarVeMehsul(1, detal.MehsulId);
                anbarQaliq.MovcudMiqdar -= detal.Miqdar;
                anbarQaliq.YenilenmeTarixi = DateTime.Now;
                
                _unitOfWork.AnbarQaliqlari.Update(anbarQaliq);

                // Məhsul stok qalığını da yenilə
                mehsul.MovcudMiqdar -= detal.Miqdar;
                await _unitOfWork.Mehsullar.UpdateAsync(mehsul);

                result.NewStock = mehsul.MovcudMiqdar;
                
                // Anbar hərəkətini qeyd et
                var anbarHereketi = new AnbarHereketi
                {
                    AnbarId = 1,
                    MehsulId = detal.MehsulId,
                    HereketTipi = "Cixis",
                    SenedNomresi = $"SAT-{satisId}",
                    SenedTipi = "Satis",
                    SenedId = satisId,
                    Miqdar = detal.Miqdar,
                    VahidQiymeti = detal.VahidQiymeti,
                    UmumiMebleg = detal.Miqdar * detal.VahidQiymeti,
                    HereketTarixi = DateTime.Now,
                    Aciklama = $"Satış ID: {satisId}",
                    IstifadeciId = 1 // Default user ID
                };
                
                _unitOfWork.AnbarHereketleri.Add(anbarHereketi);
                
                return result;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = $"Məhsul prosess xətası: {ex.Message}";
                return result;
            }
        }

        /// <summary>
        /// Müştəri borcunu yenilə
        /// </summary>
        private async Task UpdateCustomerDebtAsync(int? musteriId, decimal mebleg)
        {
            if (!musteriId.HasValue)
                return;

            var musteriBorc = new MusteriBorc
            {
                MusteriId = musteriId.Value,
                BorcNomresi = DateTime.Now.ToString("yyyyMMddHHmmss"),
                BorcTipi = "Satis",
                BorcMeblegi = mebleg,
                BorcTarixi = DateTime.Now,
                SonOdemeTarixi = DateTime.Now.AddDays(30),
                Status = SystemConstants.DebtStatus.Open,
                Aciklama = "Satış əməliyyatından yaranan borc",
                YaradanIstifadeciId = 1 // Default user ID
            };

            _unitOfWork.MusteriBorclari.Add(musteriBorc);
        }

        /// <summary>
        /// Satış əməliyyatını ləğv edir (storno)
        /// </summary>
        public async Task<SalesTransactionResult> CancelSaleAsync(int satisId, int istifadeciId, string reason)
        {
            ThrowIfDisposed();
            
            var result = new SalesTransactionResult();
            
            try
            {
                // Satış məlumatını al
                var satis = _unitOfWork.Satislar.GetById(satisId);
                if (satis == null)
                {
                    result.IsSuccess = false;
                    result.ErrorMessage = "Satış tapılmadı";
                    return result;
                }

                if (satis.Status == SystemConstants.Status.Deleted)
                {
                    result.IsSuccess = false;
                    result.ErrorMessage = "Satış artıq ləğv edilib";
                    return result;
                }

                // Satış detallarını al
                var satisDetallari = _unitOfWork.SatisDetallari.GetBySatisId(satisId);
                
                // Anbar qalıqlarını geri qaytar
                foreach (var detal in satisDetallari)
                {
                    var mehsul = await _unitOfWork.Mehsullar.GetByIdAsync(detal.MehsulId);
                    mehsul.MovcudMiqdar += detal.Miqdar;
                    await _unitOfWork.Mehsullar.UpdateAsync(mehsul);

                    var anbarQaliq = _unitOfWork.AnbarQaliqlari.GetByAnbarVeMehsul(1, detal.MehsulId);
                    anbarQaliq.MovcudMiqdar += detal.Miqdar;
                    _unitOfWork.AnbarQaliqlari.Update(anbarQaliq);

                    // Storno anbar hərəkəti
                    var anbarHereketi = new AnbarHereketi
                    {
                        AnbarId = 1,
                        MehsulId = detal.MehsulId,
                        HereketTipi = "Giris",
                        SenedNomresi = $"STORNO-{satisId}",
                        SenedTipi = "Storno",
                        SenedId = satisId,
                        Miqdar = detal.Miqdar, // Müsbət, çünki geri qayıdır
                        VahidQiymeti = detal.VahidQiymeti,
                        UmumiMebleg = detal.Miqdar * detal.VahidQiymeti,
                        HereketTarixi = DateTime.Now,
                        Aciklama = $"Satış ləğvi: {reason}",
                        IstifadeciId = istifadeciId
                    };
                    
                    _unitOfWork.AnbarHereketleri.Add(anbarHereketi);
                }

                // Satışı ləğv et
                satis.Status = SystemConstants.Status.Deleted;
                await _unitOfWork.Satislar.UpdateAsync(satis);

                // Müştəri borcunu düzəlt
                if (satis.MusteriId.HasValue && satis.OdemeNovu != "Nağd")
                {
                    var musteriBorc = new MusteriBorc
                    {
                        MusteriId = satis.MusteriId.Value,
                        BorcNomresi = DateTime.Now.ToString("yyyyMMddHHmmss"),
                        BorcTipi = "Storno",
                        BorcMeblegi = -satis.UmumiMebleg, // Mənfi, çünki borc azalır
                        BorcTarixi = DateTime.Now,
                        SonOdemeTarixi = DateTime.Now.AddDays(30),
                        Status = SystemConstants.DebtStatus.Open,
                        Aciklama = $"Satış ləğvi: {reason}",
                        YaradanIstifadeciId = istifadeciId
                    };
                    
                    _unitOfWork.MusteriBorclari.Add(musteriBorc);
                }

                await _unitOfWork.CompleteAsync();

                // Audit log
                _auditLogService?.LogAction(
                    SystemConstants.EntityNames.Satis,
                    SystemConstants.DatabaseOperations.Delete,
                    satisId,
                    $"Satış ləğv edildi: {reason}",
                    istifadeciId);

                result.IsSuccess = true;
                result.Message = "Satış uğurla ləğv edildi";
                
                return result;
            }
            catch (Exception ex)
            {
                _auditLogService?.LogError("Satış ləğvi xətası", ex);
                
                result.IsSuccess = false;
                result.ErrorMessage = $"Satış ləğvi xətası: {ex.Message}";
                result.Exception = ex;
                
                return result;
            }
        }
    }

    /// <summary>
    /// Satış tranzaksiyasının nəticəsi
    /// </summary>
    public class SalesTransactionResult
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
        public int? SalesId { get; set; }
        public decimal TotalAmount { get; set; }
        public List<ProductStockChange> ProcessedProducts { get; set; } = new List<ProductStockChange>();
    }

    /// <summary>
    /// Məhsul stok dəyişikliyi məlumatları
    /// </summary>
    public class ProductStockChange
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal QuantitySold { get; set; }
        public decimal OldStock { get; set; }
        public decimal NewStock { get; set; }
    }

    /// <summary>
    /// Validasiya nəticəsi
    /// </summary>
    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }
    }
}