using AzAgroPOS.DAL;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AzAgroPOS.BLL.Services
{
    public class TamirService
    {
        private readonly TamirIsiRepository _tamirIsiRepository;
        private readonly TamirMerheleRepository _tamirMerheleRepository;
        private readonly AuditLogService _auditLogService;

        public TamirService(AzAgroDbContext context, AuditLogService auditLogService)
        {
            _tamirIsiRepository = new TamirIsiRepository(context);
            _tamirMerheleRepository = new TamirMerheleRepository(context);
            _auditLogService = auditLogService;
        }

        #region Tamir İşi Yönetimi

        public IEnumerable<TamirIsi> GetAllRepairs()
        {
            return _tamirIsiRepository.GetAll().ToList();
        }

        public TamirIsi GetRepairById(int id)
        {
            return _tamirIsiRepository.GetById(id);
        }

        public IEnumerable<TamirIsi> GetRepairsByStatus(string status)
        {
            return _tamirIsiRepository.GetByStatus(status);
        }

        public IEnumerable<TamirIsi> GetRepairsByCustomer(int musteriId)
        {
            return _tamirIsiRepository.GetByMusteriId(musteriId);
        }

        public IEnumerable<TamirIsi> GetOverdueRepairs()
        {
            return _tamirIsiRepository.GetOverdueRepairs();
        }

        public IEnumerable<TamirIsi> GetReadyForDelivery()
        {
            return _tamirIsiRepository.GetReadyForDelivery();
        }

        public IEnumerable<TamirIsi> GetActiveRepairs()
        {
            return _tamirIsiRepository.GetActiveRepairs();
        }

        public int CreateRepair(TamirIsi tamirIsi)
        {
            tamirIsi.TamirNomresi = _tamirIsiRepository.GenerateTamirNomresi();
            tamirIsi.YaradilmaTarixi = DateTime.Now;
            tamirIsi.Status = "Qəbul Edildi";
            
            var id = _tamirIsiRepository.Add(tamirIsi);
            
            _auditLogService.Log(
                "TamirIsi", 
                id, 
                "Yaradıldı", 
                $"Yeni təmir işi qəbul edildi: {tamirIsi.TamirNomresiFormatli}", 
                tamirIsi.QebulEdenIstifadeciId
            );
            
            return id;
        }

        public void UpdateRepair(TamirIsi tamirIsi, int istifadeciId)
        {
            var originalRepair = _tamirIsiRepository.GetById(tamirIsi.Id);
            if (originalRepair == null)
                throw new ArgumentException("Təmir işi tapılmadı");

            _tamirIsiRepository.Update(tamirIsi);
            
            _auditLogService.Log(
                "TamirIsi", 
                tamirIsi.Id, 
                "Yeniləndi", 
                $"Təmir işi yeniləndi: {tamirIsi.TamirNomresiFormatli}", 
                istifadeciId
            );
        }

        public void UpdateRepairStatus(int repairId, string newStatus, int istifadeciId)
        {
            var repair = _tamirIsiRepository.GetById(repairId);
            if (repair == null)
                throw new ArgumentException("Təmir işi tapılmadı");

            var oldStatus = repair.Status;
            _tamirIsiRepository.UpdateStatus(repairId, newStatus, istifadeciId);
            
            _auditLogService.Log(
                "TamirIsi", 
                repairId, 
                "Status Dəyişdi", 
                $"Status dəyişdirildi: {oldStatus} → {newStatus}", 
                istifadeciId
            );
        }

        public void AssignRepairToUser(int repairId, int istifadeciId, int assigningUserId)
        {
            _tamirIsiRepository.AssignToUser(repairId, istifadeciId);
            
            _auditLogService.Log(
                "TamirIsi", 
                repairId, 
                "Təyin Edildi", 
                $"İşçiyə təyin edildi: İstifadəçi {istifadeciId}", 
                assigningUserId
            );
        }

        public void DeliverRepair(int repairId, int deliveringUserId)
        {
            var repair = _tamirIsiRepository.GetById(repairId);
            if (repair == null)
                throw new ArgumentException("Təmir işi tapılmadı");

            if (repair.Status != "Hazır")
                throw new InvalidOperationException("Təmir işi hazır statusunda deyil");

            if (!repair.TesdiqlerTamdir)
                throw new InvalidOperationException("Təsdiq prosesi tamamlanmamış");

            _tamirIsiRepository.UpdateStatus(repairId, "Təhvil Verildi", deliveringUserId);
            
            _auditLogService.Log(
                "TamirIsi", 
                repairId, 
                "Təhvil Verildi", 
                $"Təmir işi müştəriyə təhvil verildi", 
                deliveringUserId
            );
        }

        #endregion

        #region Tamir Mərhələsi Yönetimi

        public IEnumerable<TamirMerhele> GetStepsByRepairId(int tamirIsiId)
        {
            return _tamirMerheleRepository.GetByTamirIsiId(tamirIsiId);
        }

        public TamirMerhele GetStepById(int id)
        {
            return _tamirMerheleRepository.GetById(id);
        }

        public IEnumerable<TamirMerhele> GetStepsByUser(int istifadeciId)
        {
            return _tamirMerheleRepository.GetByTeyinEdilenIstifadeci(istifadeciId);
        }

        public IEnumerable<TamirMerhele> GetActiveSteps()
        {
            return _tamirMerheleRepository.GetActiveSteps();
        }

        public int AddStep(TamirMerhele tamirMerhele)
        {
            tamirMerhele.YaradilmaTarixi = DateTime.Now;
            
            var id = _tamirMerheleRepository.Add(tamirMerhele);
            
            _auditLogService.Log(
                "TamirMerhele", 
                id, 
                "Yaradıldı", 
                $"Yeni mərhələ əlavə edildi: {tamirMerhele.MerheleAdi}", 
                tamirMerhele.TeyinEdilenIstifadeciId ?? 0
            );
            
            return id;
        }

        public void UpdateStep(TamirMerhele tamirMerhele, int istifadeciId)
        {
            _tamirMerheleRepository.Update(tamirMerhele);
            
            _auditLogService.Log(
                "TamirMerhele", 
                tamirMerhele.Id, 
                "Yeniləndi", 
                $"Mərhələ yeniləndi: {tamirMerhele.MerheleAdi}", 
                istifadeciId
            );
        }

        public void StartStep(int stepId, int istifadeciId)
        {
            var step = _tamirMerheleRepository.GetById(stepId);
            if (step == null)
                throw new ArgumentException("Mərhələ tapılmadı");

            if (step.Status != "Gözləyir")
                throw new InvalidOperationException("Mərhələ başladıla bilməz");

            _tamirMerheleRepository.StartStep(stepId, istifadeciId);
            
            _auditLogService.Log(
                "TamirMerhele", 
                stepId, 
                "Başladıldı", 
                $"Mərhələ başladıldı: {step.MerheleAdi}", 
                istifadeciId
            );
        }

        public void CompleteStep(int stepId, decimal isSaati, decimal parcaDeyeri, string tamirciQeydleri, string istifadeOlunmusParcalar, int istifadeciId)
        {
            var step = _tamirMerheleRepository.GetById(stepId);
            if (step == null)
                throw new ArgumentException("Mərhələ tapılmadı");

            if (step.Status != "İşlənir")
                throw new InvalidOperationException("Mərhələ tamamlana bilməz");

            _tamirMerheleRepository.CompleteStep(stepId, isSaati, parcaDeyeri, tamirciQeydleri, istifadeOlunmusParcalar);
            
            // Update the repair status if all steps are completed
            UpdateRepairStatusBasedOnSteps(step.TamirIsiId);
            
            _auditLogService.Log(
                "TamirMerhele", 
                stepId, 
                "Tamamlandı", 
                $"Mərhələ tamamlandı: {step.MerheleAdi}", 
                istifadeciId
            );
        }

        public void CancelStep(int stepId, int istifadeciId)
        {
            var step = _tamirMerheleRepository.GetById(stepId);
            if (step == null)
                throw new ArgumentException("Mərhələ tapılmadı");

            if (step.Status == "Bitdi")
                throw new InvalidOperationException("Bitmiş mərhələ ləğv edilə bilməz");

            _tamirMerheleRepository.CancelStep(stepId);
            
            _auditLogService.Log(
                "TamirMerhele", 
                stepId, 
                "Ləğv Edildi", 
                $"Mərhələ ləğv edildi: {step.MerheleAdi}", 
                istifadeciId
            );
        }

        public void AssignStepToUser(int stepId, int istifadeciId, int assigningUserId)
        {
            _tamirMerheleRepository.AssignToUser(stepId, istifadeciId);
            
            _auditLogService.Log(
                "TamirMerhele", 
                stepId, 
                "Təyin Edildi", 
                $"Mərhələ işçiyə təyin edildi: İstifadəçi {istifadeciId}", 
                assigningUserId
            );
        }

        #endregion

        #region Hesabatlar və Statistikalar

        public Dictionary<string, int> GetRepairStatusSummary()
        {
            var statuses = new[] { "Qəbul Edildi", "Təşxis", "İşlənir", "Gözləyir", "Hazır", "Təhvil Verildi", "İptal" };
            var summary = new Dictionary<string, int>();
            
            foreach (var status in statuses)
            {
                summary[status] = _tamirIsiRepository.GetCountByStatus(status);
            }
            
            return summary;
        }

        public decimal GetTotalRevenue(DateTime? startDate = null, DateTime? endDate = null)
        {
            return _tamirIsiRepository.GetTotalRevenue(startDate, endDate);
        }

        public decimal GetTotalWorkingHoursByUser(int istifadeciId, DateTime? startDate = null, DateTime? endDate = null)
        {
            return _tamirMerheleRepository.GetTotalWorkingHoursByUser(istifadeciId, startDate, endDate);
        }

        public IEnumerable<TamirIsi> GetRepairsByDateRange(DateTime startDate, DateTime endDate)
        {
            return _tamirIsiRepository.GetByDateRange(startDate, endDate);
        }

        #endregion

        #region Yardımcı Metodlar

        private void UpdateRepairStatusBasedOnSteps(int tamirIsiId)
        {
            var repair = _tamirIsiRepository.GetById(tamirIsiId);
            var steps = _tamirMerheleRepository.GetByTamirIsiId(tamirIsiId).ToList();
            
            if (steps.All(s => s.Status == "Bitdi" || s.Status == "İptal"))
            {
                if (steps.Any(s => s.Status == "Bitdi"))
                {
                    repair.Status = "Hazır";
                    repair.EmeliBitirmeTarixi = DateTime.Now;
                    repair.SonQiymet = _tamirMerheleRepository.GetTotalCostByTamirId(tamirIsiId);
                    _tamirIsiRepository.Update(repair);
                }
            }
            else if (steps.Any(s => s.Status == "İşlənir"))
            {
                if (repair.Status != "İşlənir")
                {
                    repair.Status = "İşlənir";
                    _tamirIsiRepository.Update(repair);
                }
            }
        }

        #endregion
    }
}