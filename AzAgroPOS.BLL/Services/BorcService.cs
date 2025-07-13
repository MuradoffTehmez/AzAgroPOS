using AzAgroPOS.DAL;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AzAgroPOS.BLL.Services
{
    public class BorcService
    {
        private readonly MusteriBorcRepository _musteriBorcRepository;
        private readonly BorcOdenisRepository _borcOdenisRepository;
        private readonly AuditLogService _auditLogService;

        public BorcService(AzAgroDbContext context, AuditLogService auditLogService)
        {
            _musteriBorcRepository = new MusteriBorcRepository(context);
            _borcOdenisRepository = new BorcOdenisRepository(context);
            _auditLogService = auditLogService;
        }

        public IEnumerable<MusteriBorc> GetAllDebts()
        {
            return _musteriBorcRepository.GetAll().ToList();
        }

        public MusteriBorc GetDebtById(int id)
        {
            return _musteriBorcRepository.GetById(id);
        }

        public IEnumerable<MusteriBorc> GetDebtsByCustomer(int musteriId)
        {
            return _musteriBorcRepository.GetByMusteriId(musteriId);
        }

        public IEnumerable<MusteriBorc> GetActiveDebts()
        {
            return _musteriBorcRepository.GetActiveDebts();
        }

        public IEnumerable<MusteriBorc> GetOverdueDebts()
        {
            return _musteriBorcRepository.GetOverdueDebts();
        }

        public IEnumerable<MusteriBorc> GetDebtsRequiringAttention()
        {
            return _musteriBorcRepository.GetDebtsRequiringAttention();
        }

        public decimal GetTotalDebtByCustomer(int musteriId)
        {
            return _musteriBorcRepository.GetTotalDebtByMusteriId(musteriId);
        }

        public decimal GetTotalOverdueDebt()
        {
            return _musteriBorcRepository.GetTotalOverdueDebt();
        }

        public int CreateDebt(MusteriBorc musteriBorc)
        {
            musteriBorc.BorcNomresi = _musteriBorcRepository.GenerateBorcNomresi();
            musteriBorc.YaradilmaTarixi = DateTime.Now;
            
            var id = _musteriBorcRepository.Add(musteriBorc);
            
            _auditLogService.Log(
                "MusteriBorc", 
                id, 
                "Yaradıldı", 
                $"Yeni borc yaradıldı: {musteriBorc.BorcNomresi}", 
                musteriBorc.YaradanIstifadeciId
            );
            
            return id;
        }

        public void UpdateDebt(MusteriBorc musteriBorc)
        {
            var originalDebt = _musteriBorcRepository.GetById(musteriBorc.Id);
            if (originalDebt == null)
                throw new ArgumentException("Borc tapılmadı");

            _musteriBorcRepository.Update(musteriBorc);
            
            _auditLogService.Log(
                "MusteriBorc", 
                musteriBorc.Id, 
                "Yeniləndi", 
                $"Borc yeniləndi: {musteriBorc.BorcNomresi}", 
                musteriBorc.YaradanIstifadeciId
            );
        }

        public void DeleteDebt(int id, int istifadeciId)
        {
            var debt = _musteriBorcRepository.GetById(id);
            if (debt == null)
                throw new ArgumentException("Borc tapılmadı");

            if (debt.BorcOdenisleri?.Any() == true)
                throw new InvalidOperationException("Ödənişi olan borc silinə bilməz");

            _musteriBorcRepository.Delete(id);
            
            _auditLogService.Log(
                "MusteriBorc", 
                id, 
                "Silindi", 
                $"Borc silindi: {debt.BorcNomresi}", 
                istifadeciId
            );
        }

        public int AddPayment(BorcOdenis borcOdenis)
        {
            var debt = _musteriBorcRepository.GetById(borcOdenis.MusteriBorcId);
            if (debt == null)
                throw new ArgumentException("Borc tapılmadı");

            if (borcOdenis.OdenisMeblegi > debt.QalanBorc)
                throw new ArgumentException("Ödəniş məbləği qalan borcu aşa bilməz");

            borcOdenis.OdenisNomresi = _borcOdenisRepository.GenerateOdenisNomresi();
            borcOdenis.YaradilmaTarixi = DateTime.Now;
            
            var id = _borcOdenisRepository.Add(borcOdenis);
            
            UpdateDebtBalance(debt.Id);
            
            _auditLogService.Log(
                "BorcOdenis", 
                id, 
                "Yaradıldı", 
                $"Yeni ödəniş: {borcOdenis.OdenisNomresi} - {borcOdenis.OdenisMeblegi:C}", 
                borcOdenis.QebulEdenIstifadeciId
            );
            
            return id;
        }

        public void ConfirmPayment(int paymentId, int confirmingUserId)
        {
            _borcOdenisRepository.ConfirmPayment(paymentId, confirmingUserId);
            
            var payment = _borcOdenisRepository.GetById(paymentId);
            UpdateDebtBalance(payment.MusteriBorcId);
            
            _auditLogService.Log(
                "BorcOdenis", 
                paymentId, 
                "Təsdiqləndi", 
                $"Ödəniş təsdiqləndi: {payment.OdenisNomresi}", 
                confirmingUserId
            );
        }

        public void CancelPayment(int paymentId, int cancelingUserId)
        {
            var payment = _borcOdenisRepository.GetById(paymentId);
            if (payment == null)
                throw new ArgumentException("Ödəniş tapılmadı");

            _borcOdenisRepository.CancelPayment(paymentId);
            UpdateDebtBalance(payment.MusteriBorcId);
            
            _auditLogService.Log(
                "BorcOdenis", 
                paymentId, 
                "Ləğv edildi", 
                $"Ödəniş ləğv edildi: {payment.OdenisNomresi}", 
                cancelingUserId
            );
        }

        public IEnumerable<BorcOdenis> GetPaymentsByDebt(int musteriBorcId)
        {
            return _borcOdenisRepository.GetByMusteriBorcId(musteriBorcId);
        }

        public IEnumerable<BorcOdenis> GetPaymentsByCustomer(int musteriId)
        {
            return _borcOdenisRepository.GetByMusteriId(musteriId);
        }

        public IEnumerable<BorcOdenis> GetPendingPayments()
        {
            return _borcOdenisRepository.GetPendingPayments();
        }

        public decimal CalculateInterest(int debtId)
        {
            var debt = _musteriBorcRepository.GetById(debtId);
            return debt?.FaizMeblegi ?? 0;
        }

        public Dictionary<string, decimal> GetDebtSummary()
        {
            var debts = _musteriBorcRepository.GetActiveDebts().ToList();
            
            return new Dictionary<string, decimal>
            {
                ["UmumiBorc"] = debts.Sum(d => d.QalanBorc),
                ["GecikmisBorc"] = debts.Where(d => d.Gecikmiş).Sum(d => d.QalanBorc),
                ["UmumiFaiz"] = debts.Sum(d => d.FaizMeblegi),
                ["MusteriSayi"] = debts.Select(d => d.MusteriId).Distinct().Count()
            };
        }

        private void UpdateDebtBalance(int debtId)
        {
            var debt = _musteriBorcRepository.GetById(debtId);
            if (debt == null) return;

            var confirmedPayments = _borcOdenisRepository.GetByMusteriBorcId(debtId)
                .Where(p => p.Status == "Təsdiqlənmiş")
                .Sum(p => p.OdenisMeblegi);

            debt.OdenilmisMebleg = confirmedPayments;
            
            if (debt.QalanBorc <= 0)
            {
                debt.Status = "Tam Ödənilmiş";
            }
            else if (debt.OdenilmisMebleg > 0)
            {
                debt.Status = "Qismən Ödənilmiş";
            }
            else
            {
                debt.Status = "Açıq";
            }

            _musteriBorcRepository.Update(debt);
        }
    }
}