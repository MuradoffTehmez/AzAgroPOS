using AzAgroPOS.DAL;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.Entities.Constants;
using AzAgroPOS.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.BLL.Services
{
    public class TamirService : IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuditLogService _auditLogService;
        private bool _disposed = false;

        public TamirService(IUnitOfWork unitOfWork, IAuditLogService auditLogService)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _auditLogService = auditLogService ?? throw new ArgumentNullException(nameof(auditLogService));
        }

        #region Tamir İşi Yönetimi

        public IEnumerable<TamirIsi> GetAllRepairs()
        {
            return ExecuteWithExceptionHandling(
                () => _unitOfWork.TamirIsleri.GetAll().ToList(),
                "Təmir işləri alınarkən xəta");
        }

        public TamirIsi GetRepairById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Yanlış təmir işi ID-si", nameof(id));

            return ExecuteWithExceptionHandling(
                () => _unitOfWork.TamirIsleri.GetById(id),
                $"Təmir işi alınarkən xəta (ID: {id})");
        }

        public IEnumerable<TamirIsi> GetRepairsByStatus(string status)
        {
            return ExecuteWithExceptionHandling(
                () => _unitOfWork.TamirIsleri.GetByStatus(status),
                $"Status üzrə təmir işləri alınarkən xəta (Status: {status})");
        }

        public IEnumerable<TamirIsi> GetRepairsByCustomer(int musteriId)
        {
            return ExecuteWithExceptionHandling(
                () => _unitOfWork.TamirIsleri.GetByMusteriId(musteriId),
                $"Müştərinin təmir işləri alınarkən xəta (Müştəri ID: {musteriId})");
        }

        public IEnumerable<TamirIsi> GetOverdueRepairs()
        {
            return ExecuteWithExceptionHandling(
                () => _unitOfWork.TamirIsleri.GetOverdueRepairs(),
                "Gecikmiş təmir işləri alınarkən xəta");
        }

        public IEnumerable<TamirIsi> GetReadyForDelivery()
        {
            return ExecuteWithExceptionHandling(
                () => _unitOfWork.TamirIsleri.GetReadyForDelivery(),
                "Təhvilə hazır təmir işləri alınarkən xəta");
        }

        public IEnumerable<TamirIsi> GetActiveRepairs()
        {
            return ExecuteWithExceptionHandling(
                () => _unitOfWork.TamirIsleri.GetActiveRepairs(),
                "Aktiv təmir işləri alınarkən xəta");
        }

        public int CreateRepair(TamirIsi tamirIsi)
        {
            return ExecuteWithExceptionHandling(() =>
            {
                tamirIsi.TamirNomresi = _unitOfWork.TamirIsleri.GenerateTamirNomresi();
                tamirIsi.YaradilmaTarixi = DateTime.Now;
                tamirIsi.Status = "Qəbul Edildi";

                var id = _unitOfWork.TamirIsleri.Add(tamirIsi);
                _unitOfWork.Complete();

                _auditLogService.LogAction(
                    "TamirIsi",
                    "CREATE",
                    id,
                    $"Yeni təmir işi qəbul edildi: {tamirIsi.TamirNomresiFormatli}",
                    tamirIsi.QebulEdenIstifadeciId
                );

                return id;
            }, "Təmir işi yaradılarkən xəta");
        }

        public void UpdateRepair(TamirIsi tamirIsi, int istifadeciId)
        {
            ExecuteWithExceptionHandling(() =>
            {
                var originalRepair = _unitOfWork.TamirIsleri.GetById(tamirIsi.Id);
                if (originalRepair == null)
                    throw new ArgumentException("Təmir işi tapılmadı");

                _unitOfWork.TamirIsleri.Update(tamirIsi);
                _unitOfWork.Complete();

                _auditLogService.LogAction(
                    "TamirIsi",
                    "UPDATE",
                    tamirIsi.Id,
                    $"Təmir işi yeniləndi: {tamirIsi.TamirNomresiFormatli}",
                    istifadeciId
                );
            }, "Təmir işi yenilənərkən xəta");
        }

        public void UpdateRepairStatus(int repairId, string newStatus, int istifadeciId)
        {
            ExecuteWithExceptionHandling(() =>
            {
                var repair = _unitOfWork.TamirIsleri.GetById(repairId);
                if (repair == null)
                    throw new ArgumentException("Təmir işi tapılmadı");

                var oldStatus = repair.Status;
                _unitOfWork.TamirIsleri.UpdateStatus(repairId, newStatus, istifadeciId);
                _unitOfWork.Complete();

                _auditLogService.LogAction(
                    "TamirIsi",
                    "STATUS_CHANGE",
                    repairId,
                    $"Status dəyişdirildi: {oldStatus} → {newStatus}",
                    istifadeciId
                );
            }, "Təmir işi statusu dəyişdirilərkən xəta");
        }

        public void AssignRepairToUser(int repairId, int istifadeciId, int assigningUserId)
        {
            ExecuteWithExceptionHandling(() =>
            {
                _unitOfWork.TamirIsleri.AssignToUser(repairId, istifadeciId);
                _unitOfWork.Complete();

                _auditLogService.LogAction(
                    "TamirIsi",
                    "ASSIGN",
                    repairId,
                    $"İşçiyə təyin edildi: İstifadəçi {istifadeciId}",
                    assigningUserId
                );
            }, "Təmir işi təyin edilərkən xəta");
        }

        public void DeliverRepair(int repairId, int deliveringUserId)
        {
            ExecuteWithExceptionHandling(() =>
            {
                var repair = _unitOfWork.TamirIsleri.GetById(repairId);
                if (repair == null)
                    throw new ArgumentException("Təmir işi tapılmadı");

                if (repair.Status != "Hazır")
                    throw new InvalidOperationException("Təmir işi hazır statusunda deyil");

                if (!repair.TesdiqlerTamdir)
                    throw new InvalidOperationException("Təsdiq prosesi tamamlanmamış");

                _unitOfWork.TamirIsleri.UpdateStatus(repairId, "Təhvil Verildi", deliveringUserId);
                _unitOfWork.Complete();

                _auditLogService.LogAction(
                    "TamirIsi",
                    "DELIVER",
                    repairId,
                    $"Təmir işi müştəriyə təhvil verildi",
                    deliveringUserId
                );
            }, "Təmir işi təhvil verilərkən xəta");
        }

        #endregion

        #region Tamir Mərhələsi Yönetimi

        public IEnumerable<TamirMerhele> GetStepsByRepairId(int tamirIsiId)
        {
            return ExecuteWithExceptionHandling(
                () => _unitOfWork.TamirMerheleri.GetByTamirIsiId(tamirIsiId),
                $"Təmir işi mərhələləri alınarkən xəta (Təmir ID: {tamirIsiId})");
        }

        public TamirMerhele GetStepById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Yanlış mərhələ ID-si", nameof(id));

            return ExecuteWithExceptionHandling(
                () => _unitOfWork.TamirMerheleri.GetById(id),
                $"Mərhələ alınarkən xəta (ID: {id})");
        }

        public IEnumerable<TamirMerhele> GetStepsByUser(int istifadeciId)
        {
            return ExecuteWithExceptionHandling(
                () => _unitOfWork.TamirMerheleri.GetByTeyinEdilenIstifadeci(istifadeciId),
                $"İstifadəçi mərhələləri alınarkən xəta (İstifadəçi ID: {istifadeciId})");
        }

        public IEnumerable<TamirMerhele> GetActiveSteps()
        {
            return ExecuteWithExceptionHandling(
                () => _unitOfWork.TamirMerheleri.GetActiveSteps(),
                "Aktiv mərhələlər alınarkən xəta");
        }

        public int AddStep(TamirMerhele tamirMerhele)
        {
            return ExecuteWithExceptionHandling(() =>
            {
                tamirMerhele.YaradilmaTarixi = DateTime.Now;

                var id = _unitOfWork.TamirMerheleri.Add(tamirMerhele);
                _unitOfWork.Complete();

                _auditLogService.LogAction(
                    "TamirMerhele",
                    "CREATE",
                    id,
                    $"Yeni mərhələ əlavə edildi: {tamirMerhele.MerheleAdi}",
                    tamirMerhele.TeyinEdilenIstifadeciId ?? 0
                );

                return id;
            }, "Mərhələ əlavə edilərkən xəta");
        }

        public void UpdateStep(TamirMerhele tamirMerhele, int istifadeciId)
        {
            ExecuteWithExceptionHandling(() =>
            {
                _unitOfWork.TamirMerheleri.Update(tamirMerhele);
                _unitOfWork.Complete();

                _auditLogService.LogAction(
                    "TamirMerhele",
                    "UPDATE",
                    tamirMerhele.Id,
                    $"Mərhələ yeniləndi: {tamirMerhele.MerheleAdi}",
                    istifadeciId
                );
            }, "Mərhələ yenilənərkən xəta");
        }

        public void StartStep(int stepId, int istifadeciId)
        {
            ExecuteWithExceptionHandling(() =>
            {
                var step = _unitOfWork.TamirMerheleri.GetById(stepId);
                if (step == null)
                    throw new ArgumentException("Mərhələ tapılmadı");

                if (step.Status != "Gözləyir")
                    throw new InvalidOperationException("Mərhələ başladıla bilməz");

                _unitOfWork.TamirMerheleri.StartStep(stepId, istifadeciId);
                _unitOfWork.Complete();

                _auditLogService.LogAction(
                    "TamirMerhele",
                    "START",
                    stepId,
                    $"Mərhələ başladıldı: {step.MerheleAdi}",
                    istifadeciId
                );
            }, "Mərhələ başladılarkən xəta");
        }

        public void CompleteStep(int stepId, decimal isSaati, decimal parcaDeyeri, string tamirciQeydleri, string istifadeOlunmusParcalar, int istifadeciId)
        {
            ExecuteWithExceptionHandling(() =>
            {
                var step = _unitOfWork.TamirMerheleri.GetById(stepId);
                if (step == null)
                    throw new ArgumentException("Mərhələ tapılmadı");

                if (step.Status != "İşlənir")
                    throw new InvalidOperationException("Mərhələ tamamlana bilməz");

                _unitOfWork.TamirMerheleri.CompleteStep(stepId, isSaati, parcaDeyeri, tamirciQeydleri, istifadeOlunmusParcalar);
                _unitOfWork.Complete();

                // Update the repair status if all steps are completed
                UpdateRepairStatusBasedOnSteps(step.TamirIsiId);

                _auditLogService.LogAction(
                    "TamirMerhele",
                    "COMPLETE",
                    stepId,
                    $"Mərhələ tamamlandı: {step.MerheleAdi}",
                    istifadeciId
                );
            }, "Mərhələ tamamlanırkən xəta");
        }

        public void CancelStep(int stepId, int istifadeciId)
        {
            ExecuteWithExceptionHandling(() =>
            {
                var step = _unitOfWork.TamirMerheleri.GetById(stepId);
                if (step == null)
                    throw new ArgumentException("Mərhələ tapılmadı");

                if (step.Status == "Bitdi")
                    throw new InvalidOperationException("Bitmiş mərhələ ləğv edilə bilməz");

                _unitOfWork.TamirMerheleri.CancelStep(stepId);
                _unitOfWork.Complete();

                _auditLogService.LogAction(
                    "TamirMerhele",
                    "CANCEL",
                    stepId,
                    $"Mərhələ ləğv edildi: {step.MerheleAdi}",
                    istifadeciId
                );
            }, "Mərhələ ləğv edilərkən xəta");
        }

        public void AssignStepToUser(int stepId, int istifadeciId, int assigningUserId)
        {
            ExecuteWithExceptionHandling(() =>
            {
                _unitOfWork.TamirMerheleri.AssignToUser(stepId, istifadeciId);
                _unitOfWork.Complete();

                _auditLogService.LogAction(
                    "TamirMerhele",
                    "ASSIGN",
                    stepId,
                    $"Mərhələ işçiyə təyin edildi: İstifadəçi {istifadeciId}",
                    assigningUserId
                );
            }, "Mərhələ təyin edilərkən xəta");
        }

        #endregion

        #region Hesabatlar və Statistikalar

        public Dictionary<string, int> GetRepairStatusSummary()
        {
            return ExecuteWithExceptionHandling(() =>
            {
                var statuses = new[] { "Qəbul Edildi", "Təşxis", "İşlənir", "Gözləyir", "Hazır", "Təhvil Verildi", "İptal" };
                var summary = new Dictionary<string, int>();

                foreach (var status in statuses)
                {
                    summary[status] = _unitOfWork.TamirIsleri.GetCountByStatus(status);
                }

                return summary;
            }, "Təmir statusu xülasəsi hesablanarkən xəta");
        }

        public decimal GetTotalRevenue(DateTime? startDate = null, DateTime? endDate = null)
        {
            return ExecuteWithExceptionHandling(
                () => _unitOfWork.TamirIsleri.GetTotalRevenue(startDate, endDate),
                "Təmir gəliri hesablanarkən xəta");
        }

        public decimal GetTotalWorkingHoursByUser(int istifadeciId, DateTime? startDate = null, DateTime? endDate = null)
        {
            return ExecuteWithExceptionHandling(
                () => _unitOfWork.TamirMerheleri.GetTotalWorkingHoursByUser(istifadeciId, startDate, endDate),
                $"İstifadəçi iş saatları hesablanarkən xəta (İstifadəçi ID: {istifadeciId})");
        }

        public IEnumerable<TamirIsi> GetRepairsByDateRange(DateTime startDate, DateTime endDate)
        {
            return ExecuteWithExceptionHandling(
                () => _unitOfWork.TamirIsleri.GetByDateRange(startDate, endDate),
                $"Tarix aralığına görə təmir işləri alınarkən xəta ({startDate:yyyy-MM-dd} - {endDate:yyyy-MM-dd})");
        }

        #endregion

        #region Yardımcı Metodlar

        private void UpdateRepairStatusBasedOnSteps(int tamirIsiId)
        {
            ExecuteWithExceptionHandling(() =>
            {
                var repair = _unitOfWork.TamirIsleri.GetById(tamirIsiId);
                var steps = _unitOfWork.TamirMerheleri.GetByTamirIsiId(tamirIsiId).ToList();

                if (steps.All(s => s.Status == "Bitdi" || s.Status == "İptal"))
                {
                    if (steps.Any(s => s.Status == "Bitdi"))
                    {
                        repair.Status = "Hazır";
                        repair.EmeliBitirmeTarixi = DateTime.Now;
                        repair.SonQiymet = _unitOfWork.TamirMerheleri.GetTotalCostByTamirId(tamirIsiId);
                        _unitOfWork.TamirIsleri.Update(repair);
                        _unitOfWork.Complete();
                    }
                }
                else if (steps.Any(s => s.Status == "İşlənir"))
                {
                    if (repair.Status != "İşlənir")
                    {
                        repair.Status = "İşlənir";
                        _unitOfWork.TamirIsleri.Update(repair);
                        _unitOfWork.Complete();
                    }
                }
            }, $"Təmir statusu yenilənərkən xəta (Təmir ID: {tamirIsiId})");
        }

        #endregion

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

        ~TamirService()
        {
            Dispose(false);
        }

        #endregion
    }
}