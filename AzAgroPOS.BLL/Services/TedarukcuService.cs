using AzAgroPOS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.Entities.Constants;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.DAL;
using AzAgroPOS.DAL.Interfaces;
using System.Threading.Tasks;

namespace AzAgroPOS.BLL.Services
{
    public class TedarukcuService : IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuditLogService _auditLogService;
        private bool _disposed = false;

        public TedarukcuService(IUnitOfWork unitOfWork, IAuditLogService auditLogService)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _auditLogService = auditLogService ?? throw new ArgumentNullException(nameof(auditLogService));
        }

        public List<Tedarukcu> GetAllActive()
        {
            return ExecuteWithExceptionHandling(
                () => _unitOfWork.Tedarukciler.GetAllActive(),
                "Aktiv tədarükçülər alınarkən xəta");
        }

        public List<Tedarukcu> GetActiveCustomers()
        {
            return ExecuteWithExceptionHandling(
                () => _unitOfWork.Tedarukciler.GetAll().Cast<Tedarukcu>().Where(t => t.Status == SystemConstants.Status.Active).ToList(),
                "Aktiv tədarükçülər alınarkən xəta");
        }

        public List<Tedarukcu> GetAll()
        {
            return ExecuteWithExceptionHandling(
                () => _unitOfWork.Tedarukciler.GetAll(),
                "Tədarükçülər alınarkən xəta");
        }

        public Tedarukcu GetById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Yanlış tədarükçü ID-si", nameof(id));

            return ExecuteWithExceptionHandling(
                () => _unitOfWork.Tedarukciler.GetById(id),
                $"Tədarükçü məlumatı alınarkən xəta (ID: {id})");
        }

        public List<Tedarukcu> SearchTedarukcu(string searchTerm)
        {
            return ExecuteWithExceptionHandling(
                () => _unitOfWork.Tedarukciler.Search(searchTerm),
                $"Tədarükçü axtarışında xəta (Axtarış: {searchTerm})");
        }

        public int AddTedarukcu(Tedarukcu tedarukcu)
        {
            return ExecuteWithExceptionHandling(() =>
            {
                // Generate unique code if not provided
                if (string.IsNullOrEmpty(tedarukcu.Kod))
                {
                    tedarukcu.Kod = GenerateTedarukcuKod();
                }

                // Validate unique fields
                if (_unitOfWork.Tedarukciler.KodMevcudMu(tedarukcu.Kod, tedarukcu.Id))
                    throw new InvalidOperationException("Bu kod artıq mövcuddur");

                if (!string.IsNullOrEmpty(tedarukcu.VOEN) &&
                    _unitOfWork.Tedarukciler.VOENMevcudMu(tedarukcu.VOEN, tedarukcu.Id))
                    throw new InvalidOperationException("Bu VOEN artıq mövcuddur");

                tedarukcu.YaradilmaTarixi = DateTime.Now;
                tedarukcu.Status = SystemConstants.Status.Active;

                var id = _unitOfWork.Tedarukciler.Add(tedarukcu);
                _unitOfWork.Complete();

                _auditLogService.LogAction(
                    "Tedarukcu",
                    "CREATE",
                    id,
                    $"Yeni tədarükçü yaradıldı: {tedarukcu.Ad}",
                    0 // Assuming no user context here
                );

                return id;
            }, "Tədarükçü əlavə edilərkən xəta");
        }

        public void UpdateTedarukcu(Tedarukcu tedarukcu)
        {
            ExecuteWithExceptionHandling(() =>
            {
                // Validate unique fields
                if (_unitOfWork.Tedarukciler.KodMevcudMu(tedarukcu.Kod, tedarukcu.Id))
                    throw new InvalidOperationException("Bu kod artıq mövcuddur");

                if (!string.IsNullOrEmpty(tedarukcu.VOEN) &&
                    _unitOfWork.Tedarukciler.VOENMevcudMu(tedarukcu.VOEN, tedarukcu.Id))
                    throw new InvalidOperationException("Bu VOEN artıq mövcuddur");

                tedarukcu.YenilenmeTarixi = DateTime.Now;
                _unitOfWork.Tedarukciler.Update(tedarukcu);
                _unitOfWork.Complete();

                _auditLogService.LogAction(
                    "Tedarukcu",
                    "UPDATE",
                    tedarukcu.Id,
                    $"Tədarükçü yeniləndi: {tedarukcu.Ad}",
                    0 // Assuming no user context here
                );
            }, "Tədarükçü yenilənərkən xəta");
        }

        public void DeleteTedarukcu(int id)
        {
            ExecuteWithExceptionHandling(() =>
            {
                var tedarukcu = _unitOfWork.Tedarukciler.GetById(id);
                if (tedarukcu == null)
                    throw new ArgumentException("Tədarükçü tapılmadı");

                // Check if supplier has any related records
                if (!CanDeleteTedarukcu(id))
                    throw new InvalidOperationException("Bu tədarükçü silinə bilməz - əlaqəli qeydlər mövcuddur");

                _unitOfWork.Tedarukciler.Delete(id);
                _unitOfWork.Complete();

                _auditLogService.LogAction(
                    "Tedarukcu",
                    "DELETE",
                    id,
                    $"Tədarükçü silindi: {tedarukcu.Ad}",
                    0 // Assuming no user context here
                );
            }, "Tədarükçü silinərkən xəta");
        }

        public bool CanDeleteTedarukcu(int id)
        {
            return ExecuteWithExceptionHandling(
                () => _unitOfWork.Tedarukciler.CanDelete(id),
                $"Tədarükçü silinmə yoxlanışında xəta (ID: {id})");
        }

        public void UpdateCariBorc(int tedarukcuId, decimal yeniBorc)
        {
            ExecuteWithExceptionHandling(() =>
            {
                var tedarukcu = _unitOfWork.Tedarukciler.GetById(tedarukcuId);
                if (tedarukcu != null)
                {
                    tedarukcu.CariBorc = yeniBorc;
                    tedarukcu.YenilenmeTarixi = DateTime.Now;
                    _unitOfWork.Tedarukciler.Update(tedarukcu);
                    _unitOfWork.Complete();

                    _auditLogService.LogAction(
                        "Tedarukcu",
                        "DEBT_UPDATE",
                        tedarukcuId,
                        $"Cari borc yeniləndi: {yeniBorc:C}",
                        0 // Assuming no user context here
                    );
                }
            }, $"Tədarükçü cari borc yenilənərkən xəta (ID: {tedarukcuId})");
        }

        public void ArtirCariBorc(int tedarukcuId, decimal mebleg)
        {
            ExecuteWithExceptionHandling(() =>
            {
                var tedarukcu = _unitOfWork.Tedarukciler.GetById(tedarukcuId);
                if (tedarukcu != null)
                {
                    tedarukcu.CariBorc += mebleg;
                    tedarukcu.YenilenmeTarixi = DateTime.Now;
                    _unitOfWork.Tedarukciler.Update(tedarukcu);
                    _unitOfWork.Complete();

                    _auditLogService.LogAction(
                        "Tedarukcu",
                        "DEBT_INCREASE",
                        tedarukcuId,
                        $"Cari borc artırıldı: +{mebleg:C} (Yeni borc: {tedarukcu.CariBorc:C})",
                        0 // Assuming no user context here
                    );
                }
            }, $"Tədarükçü cari borc artırılarkən xəta (ID: {tedarukcuId})");
        }

        public void AzaltCariBorc(int tedarukcuId, decimal mebleg)
        {
            ExecuteWithExceptionHandling(() =>
            {
                var tedarukcu = _unitOfWork.Tedarukciler.GetById(tedarukcuId);
                if (tedarukcu != null)
                {
                    var eskiBorc = tedarukcu.CariBorc;
                    tedarukcu.CariBorc = Math.Max(0, tedarukcu.CariBorc - mebleg);
                    tedarukcu.YenilenmeTarixi = DateTime.Now;
                    _unitOfWork.Tedarukciler.Update(tedarukcu);
                    _unitOfWork.Complete();

                    _auditLogService.LogAction(
                        "Tedarukcu",
                        "DEBT_DECREASE",
                        tedarukcuId,
                        $"Cari borc azaldıldı: -{mebleg:C} (Yeni borc: {tedarukcu.CariBorc:C})",
                        0 // Assuming no user context here
                    );
                }
            }, $"Tədarükçü cari borc azaldılarkən xəta (ID: {tedarukcuId})");
        }

        public List<Tedarukcu> GetKreditLimitiAsilanlar()
        {
            return ExecuteWithExceptionHandling(
                () => _unitOfWork.Tedarukciler.GetKreditLimitiAsilanlar(),
                "Kredit limiti aşılan tədarükçülər alınarkən xəta");
        }

        public List<Tedarukcu> GetBorcluTedarukciler()
        {
            return ExecuteWithExceptionHandling(
                () => _unitOfWork.Tedarukciler.GetBorcluTedarukciler(),
                "Borclu tədarükçülər alınarkən xəta");
        }

        public TedarukcuStatistikleri GetTedarukcuStatistikleri(int tedarukcuId, DateTime? startDate = null, DateTime? endDate = null)
        {
            return ExecuteWithExceptionHandling(() =>
            {
                var statistikalar = new TedarukcuStatistikleri();

                var tedarukcu = _unitOfWork.Tedarukciler.GetById(tedarukcuId);
                if (tedarukcu == null) return statistikalar;

                // Purchase orders statistics
                var orders = _unitOfWork.AlisOrderleri.GetByTedarukcu(tedarukcuId, startDate, endDate);
                statistikalar.UmumiOrderSayi = orders.Count;
                statistikalar.TesdiqlenmisgOrderSayi = orders.Count(o => o.Status == "Təsdiqlənmiş");
                statistikalar.TeslimEdilmişOrderSayi = orders.Count(o => o.Status == "Teslim Edilmiş");
                statistikalar.UmumiOrderMeblegi = orders.Sum(o => o.NetMebleg);

                // Purchase documents statistics
                var senedler = _unitOfWork.AlisSenedleri.GetByTedarukcu(tedarukcuId, startDate, endDate);
                statistikalar.UmumiSenedSayi = senedler.Count;
                statistikalar.QebulEdilmişSenedSayi = senedler.Count(s => s.Status == "Qəbul Edilmiş");
                statistikalar.UmumiSenedMeblegi = senedler.Sum(s => s.NetMebleg);

                // Payment statistics
                var odemeler = _unitOfWork.TedarukcuOdemeleri.GetByTedarukcu(tedarukcuId, startDate, endDate);
                statistikalar.UmumiOdemeSayi = odemeler.Count;
                statistikalar.UmumiOdemeMeblegi = odemeler.Where(o => o.Status == "Tamamlandı").Sum(o => o.OdemeMeblegi);

                // Current balances
                statistikalar.CariBorc = tedarukcu.CariBorc;
                statistikalar.KreditLimiti = tedarukcu.KreditLimiti;
                statistikalar.QalanKreditLimiti = tedarukcu.QalanKreditLimiti;

                return statistikalar;
            }, $"Tədarükçü statistikaları hesablanarkən xəta (ID: {tedarukcuId})");
        }

        private string GenerateTedarukcuKod()
        {
            return ExecuteWithExceptionHandling(() =>
            {
                var lastKod = _unitOfWork.Tedarukciler.GetLastKod();
                if (string.IsNullOrEmpty(lastKod))
                    return "TED001";

                var numPart = lastKod.Substring(3);
                if (int.TryParse(numPart, out int num))
                {
                    return $"TED{(num + 1):D3}";
                }
                return "TED001";
            }, "Tədarükçü kodu yaradılarkən xəta");
        }

        public List<object> GetTedarukcuPerformansRaporu(DateTime startDate, DateTime endDate)
        {
            return ExecuteWithExceptionHandling(
                () => _unitOfWork.Tedarukciler.GetPerformansRaporu(startDate, endDate),
                $"Tədarükçü performans raporu alınarkən xəta ({startDate:yyyy-MM-dd} - {endDate:yyyy-MM-dd})");
        }

        public List<AlisOrder> GetAllAlisOrders()
        {
            return ExecuteWithExceptionHandling(
                () => _unitOfWork.AlisOrderleri.GetAll(),
                "Alış orderləri alınarkən xəta");
        }

        public List<AlisSeined> GetAllAlisSenedleri()
        {
            return ExecuteWithExceptionHandling(
                () => _unitOfWork.AlisSenedleri.GetAll(),
                "Alış sənədləri alınarkən xəta");
        }

        #region Helper Methods

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

        private void ExecuteWithExceptionHandling(Action action, string errorMessage)
        {
            try
            {
                action();
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

        ~TedarukcuService()
        {
            Dispose(false);
        }

        #endregion
    }

    public class TedarukcuStatistikleri
    {
        public int UmumiOrderSayi { get; set; }
        public int TesdiqlenmisgOrderSayi { get; set; }
        public int TeslimEdilmişOrderSayi { get; set; }
        public decimal UmumiOrderMeblegi { get; set; }

        public int UmumiSenedSayi { get; set; }
        public int QebulEdilmişSenedSayi { get; set; }
        public decimal UmumiSenedMeblegi { get; set; }

        public int UmumiOdemeSayi { get; set; }
        public decimal UmumiOdemeMeblegi { get; set; }

        public decimal CariBorc { get; set; }
        public decimal KreditLimiti { get; set; }
        public decimal QalanKreditLimiti { get; set; }
    }
}