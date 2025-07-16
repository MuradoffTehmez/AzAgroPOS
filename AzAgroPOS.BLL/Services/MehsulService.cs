using AzAgroPOS.DAL;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.BLL.Services
{
    public class MehsulService : IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuditLogService _auditLogService;
        private bool _disposed = false;

        public MehsulService(IUnitOfWork unitOfWork, IAuditLogService auditLogService)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _auditLogService = auditLogService ?? throw new ArgumentNullException(nameof(auditLogService));
        }

        #region CRUD Operations

        public async Task<(bool Success, string Message, int? MehsulId)> CreateMehsulAsync(Mehsul mehsul, int istifadeciId)
        {
            return await ExecuteWithTransactionAsync(async () =>
            {
                // Validation
                if (await _unitOfWork.Mehsullar.BarkodMevcudAsync(mehsul.Barkod))
                    return (false, "Bu barkod artıq mövcuddur.", (int?)null);

                if (await _unitOfWork.Mehsullar.SKUMevcudAsync(mehsul.SKU))
                    return (false, "Bu SKU artıq mövcuddur.", (int?)null);

                if (!await ValidateKateqoriyaAsync(mehsul.KateqoriyaId))
                    return (false, "Seçilən kateqoriya mövcud deyil və ya aktiv deyil.", (int?)null);

                if (!await ValidateVahidAsync(mehsul.VahidId))
                    return (false, "Seçilən vahid mövcud deyil və ya aktiv deyil.", (int?)null);

                if (mehsul.SatisQiymeti <= mehsul.AlisQiymeti)
                    return (false, "Satış qiyməti alış qiymətindən böyük olmalıdır.", (int?)null);

                // Create product
                var mehsulId = await _unitOfWork.Mehsullar.AddAsync(mehsul);

                // Log audit
                await LogAuditAsync(istifadeciId, "Məhsul İdarəetməsi", "Məhsul Əlavə Etmə",
                    $"Yeni məhsul yaradıldı: {mehsul.Ad} ({mehsul.SKU})");

                return (true, "Məhsul uğurla yaradıldı.", mehsulId);
            }, "Məhsul yaradılarkən xəta");
        }

        public async Task<(bool Success, string Message)> UpdateMehsulAsync(Mehsul mehsul, int istifadeciId)
        {
            return await ExecuteWithTransactionAsync(async () =>
            {
                var existingMehsul = await _unitOfWork.Mehsullar.GetByIdAsync(mehsul.Id);
                if (existingMehsul == null)
                    return (false, "Məhsul tapılmadı.");

                if (await _unitOfWork.Mehsullar.BarkodMevcudAsync(mehsul.Barkod, mehsul.Id))
                    return (false, "Bu barkod başqa məhsulda mövcuddur.");

                if (await _unitOfWork.Mehsullar.SKUMevcudAsync(mehsul.SKU, mehsul.Id))
                    return (false, "Bu SKU başqa məhsulda mövcuddur.");

                if (!await ValidateKateqoriyaAsync(mehsul.KateqoriyaId))
                    return (false, "Seçilən kateqoriya mövcud deyil və ya aktiv deyil.");

                if (!await ValidateVahidAsync(mehsul.VahidId))
                    return (false, "Seçilən vahid mövcud deyil və ya aktiv deyil.");

                if (mehsul.SatisQiymeti <= mehsul.AlisQiymeti)
                    return (false, "Satış qiyməti alış qiymətindən böyük olmalıdır.");

                // Update product
                mehsul.YaradilmaTarixi = existingMehsul.YaradilmaTarixi;
                await _unitOfWork.Mehsullar.UpdateAsync(mehsul);

                // Log audit
                await LogAuditAsync(istifadeciId, "Məhsul İdarəetməsi", "Məhsul Yeniləmə",
                    $"Məhsul yeniləndi: {mehsul.Ad} ({mehsul.SKU})");

                return (true, "Məhsul uğurla yeniləndi.");
            }, "Məhsul yenilənərkən xəta");
        }

        public async Task<(bool Success, string Message)> DeleteMehsulAsync(int mehsulId, int istifadeciId)
        {
            return await ExecuteWithTransactionAsync(async () =>
            {
                var mehsul = await _unitOfWork.Mehsullar.GetByIdAsync(mehsulId);
                if (mehsul == null)
                    return (false, "Məhsul tapılmadı.");

                if (!await _unitOfWork.Mehsullar.CanDeleteAsync(mehsulId))
                    return (false, "Bu məhsul silinə bilməz çünki digər əməliyyatlarda istifadə olunur.");

                await _unitOfWork.Mehsullar.DeleteAsync(mehsulId);

                // Log audit
                await LogAuditAsync(istifadeciId, "Məhsul İdarəetməsi", "Məhsul Silmə",
                    $"Məhsul silindi: {mehsul.Ad} ({mehsul.SKU})");

                return (true, "Məhsul uğurla silindi.");
            }, "Məhsul silinərkən xəta");
        }

        #endregion

        #region Status Management

        public async Task<(bool Success, string Message)> UpdateMehsulStatusAsync(int mehsulId, string status, int istifadeciId)
        {
            return await ExecuteWithTransactionAsync(async () =>
            {
                var mehsul = await _unitOfWork.Mehsullar.GetByIdAsync(mehsulId);
                if (mehsul == null)
                    return (false, "Məhsul tapılmadı.");

                var oldStatus = mehsul.Status;
                mehsul.Status = status;
                await _unitOfWork.Mehsullar.UpdateAsync(mehsul);

                // Log audit
                await LogAuditAsync(istifadeciId, "Məhsul İdarəetməsi", "Status Dəyişikliyi",
                    $"Məhsul statusu dəyişdi: {mehsul.Ad} ({oldStatus} → {status})");

                return (true, $"Məhsul statusu {status} olaraq dəyişdirildi.");
            }, "Məhsul statusu yenilənərkən xəta");
        }

        #endregion

        #region Stock Management

        public async Task<(bool Success, string Message)> UpdateStokMiqdarAsync(int mehsulId, decimal yeniMiqdar, int istifadeciId, string sebet = null)
        {
            return await ExecuteWithTransactionAsync(async () =>
            {
                var mehsul = await _unitOfWork.Mehsullar.GetByIdAsync(mehsulId);
                if (mehsul == null)
                    return (false, "Məhsul tapılmadı.");

                if (yeniMiqdar < 0)
                    return (false, "Stok miqdarı mənfi ola bilməz.");

                var kohMiqdar = mehsul.MovcudMiqdar;
                await _unitOfWork.Mehsullar.UpdateMiqdarAsync(mehsulId, yeniMiqdar);

                var detal = sebet ?? $"Stok miqdarı dəyişdi: {kohMiqdar} → {yeniMiqdar}";
                await LogAuditAsync(istifadeciId, "Məhsul İdarəetməsi", "Stok Yeniləmə",
                    $"{mehsul.Ad}: {detal}");

                return (true, "Stok miqdarı uğurla yeniləndi.");
            }, "Stok miqdarı yenilənərkən xəta");
        }

        public async Task<List<Mehsul>> GetStoktanKenardaMehsullarAsync()
        {
            return await ExecuteWithExceptionHandlingAsync(
                () => _unitOfWork.Mehsullar.GetStoktanKenardaAsync(),
                "Stokdan kənar məhsullar alınarkən xəta");
        }

        public async Task<decimal> HesablaUmumiStokDegeriAsync()
        {
            return await ExecuteWithExceptionHandlingAsync(async () =>
            {
                var mehsullar = await _unitOfWork.Mehsullar.GetAllActiveAsync();
                return mehsullar.Sum(m => m.MovcudMiqdar * m.SatisQiymeti);
            }, "Ümumi stok dəyəri hesablanarkən xəta");
        }

        #endregion

        #region Code Generation

        public async Task<string> GenerateBarkodAsync()
        {
            return await ExecuteWithExceptionHandlingAsync(async () =>
            {
                var random = new Random();
                string barkod;

                do
                {
                    barkod = "299" + random.Next(1000000000).ToString("D10");
                }
                while (await _unitOfWork.Mehsullar.BarkodMevcudAsync(barkod));

                return barkod;
            }, "Barkod yaradılarkən xəta");
        }

        public async Task<string> GenerateSKUAsync(string mehsulAdi, string kateqoriyaKodu)
        {
            return await ExecuteWithExceptionHandlingAsync(async () =>
            {
                var mehsulPrefix = "";
                var words = mehsulAdi.Split(' ');
                foreach (var word in words)
                {
                    if (word.Length > 0)
                    {
                        mehsulPrefix += word[0];
                        if (mehsulPrefix.Length >= 3) break;
                    }
                }
                mehsulPrefix = mehsulPrefix.PadRight(3, 'X').ToUpper();

                var katPrefix = !string.IsNullOrEmpty(kateqoriyaKodu) ? kateqoriyaKodu : "GEN";

                string sku;
                int counter = 1;

                do
                {
                    sku = $"{katPrefix}-{mehsulPrefix}-{counter:D4}";
                    counter++;
                }
                while (await _unitOfWork.Mehsullar.SKUMevcudAsync(sku));

                return sku;
            }, "SKU yaradılarkən xəta");
        }

        #endregion

        #region Reporting

        public async Task<Dictionary<string, object>> GetMehsulStatistikalarAsync()
        {
            return await ExecuteWithExceptionHandlingAsync(
                () => _unitOfWork.Mehsullar.GetStatistikalarAsync(),
                "Məhsul statistikaları alınarkən xəta");
        }

        #endregion

        #region Query Methods

        public async Task<List<Mehsul>> GetMehsullarByFiltersAsync(string searchTerm = null, int? kateqoriyaId = null, string status = null)
        {
            return await ExecuteWithExceptionHandlingAsync(async () =>
            {
                var mehsullar = await _unitOfWork.Mehsullar.GetAllAsync();

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    var term = searchTerm.ToLower();
                    mehsullar = mehsullar.Where(m =>
                        m.Ad.ToLower().Contains(term) ||
                        m.Barkod.ToLower().Contains(term) ||
                        m.SKU.ToLower().Contains(term) ||
                        (m.Tesvir != null && m.Tesvir.ToLower().Contains(term))).ToList();
                }

                if (kateqoriyaId.HasValue)
                {
                    mehsullar = mehsullar.Where(m => m.KateqoriyaId == kateqoriyaId.Value).ToList();
                }

                if (!string.IsNullOrEmpty(status))
                {
                    mehsullar = mehsullar.Where(m => m.Status == status).ToList();
                }

                return mehsullar;
            }, "Məhsullar filtr edilərkən xəta");
        }

        public List<Mehsul> GetAllActive()
        {
            return ExecuteWithExceptionHandling(
                () => _unitOfWork.Mehsullar.GetAllActive(),
                "Aktiv məhsullar alınarkən xəta");
        }

        #endregion

        #region Helper Methods

        private async Task<bool> ValidateKateqoriyaAsync(int kateqoriyaId)
        {
            var kateqoriya = await _unitOfWork.MehsulKateqoriyalari.GetByIdAsync(kateqoriyaId);
            return kateqoriya != null && kateqoriya.Status == "Aktiv";
        }

        private async Task<bool> ValidateVahidAsync(int vahidId)
        {
            var vahid = await _unitOfWork.Vahidler.GetByIdAsync(vahidId);
            return vahid != null && vahid.Status == "Aktiv";
        }

        private async Task LogAuditAsync(int userId, string category, string action, string details)
        {
            await _auditLogService.LogAsync(category, null, action, details, userId);
        }

        private async Task<T> ExecuteWithTransactionAsync<T>(Func<Task<T>> action, string errorMessage)
        {
            try
            {
                var result = await action();
                await _unitOfWork.CompleteAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"{errorMessage}: {ex.Message}", ex);
            }
        }

        private async Task<T> ExecuteWithExceptionHandlingAsync<T>(Func<Task<T>> action, string errorMessage)
        {
            try
            {
                return await action();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"{errorMessage}: {ex.Message}", ex);
            }
        }

        private T ExecuteWithExceptionHandling<T>(Func<T> action, string errorMessage)
        {
            try
            {
                return action();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"{errorMessage}: {ex.Message}", ex);
            }
        }

        #endregion

        #region IDisposable Implementation

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _unitOfWork?.Dispose();
                    _auditLogService?.Dispose();
                }
                _disposed = true;
            }
        }

        ~MehsulService()
        {
            Dispose(false);
        }

        #endregion
    }
}