using AzAgroPOS.DAL;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.Entities.Constants;
using AzAgroPOS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.BLL.Services
{
    public class BorcService : IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuditLogService _auditLogService;
        private bool _disposed = false;

        public BorcService(IUnitOfWork unitOfWork, IAuditLogService auditLogService)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _auditLogService = auditLogService ?? throw new ArgumentNullException(nameof(auditLogService));
        }

        public IEnumerable<MusteriBorc> GetAllDebts()
        {
            return ExecuteWithExceptionHandling(
                () => _unitOfWork.MusteriBorclari.GetAll().ToList(),
                "Borc məlumatları alınarkən xəta");
        }

        public MusteriBorc GetDebtById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Yanlış borc ID-si", nameof(id));

            return ExecuteWithExceptionHandling(
                () => _unitOfWork.MusteriBorclari.GetById(id),
                $"Borc məlumatı alınarkən xəta (ID: {id})");
        }

        public IEnumerable<MusteriBorc> GetDebtsByCustomer(int musteriId)
        {
            return ExecuteWithExceptionHandling(
                () => _unitOfWork.MusteriBorclari.GetByMusteriId(musteriId),
                $"Müştərinin borcları alınarkən xəta (Müştəri ID: {musteriId})");
        }

        public IEnumerable<MusteriBorc> GetActiveDebts()
        {
            return ExecuteWithExceptionHandling(
                () => _unitOfWork.MusteriBorclari.GetActiveDebts(),
                "Aktiv borclar alınarkən xəta");
        }

        public IEnumerable<MusteriBorc> GetOverdueDebts()
        {
            return ExecuteWithExceptionHandling(
                () => _unitOfWork.MusteriBorclari.GetOverdueDebts(),
                "Gecikmiş borclar alınarkən xəta");
        }

        public IEnumerable<MusteriBorc> GetDebtsRequiringAttention()
        {
            return ExecuteWithExceptionHandling(
                () => _unitOfWork.MusteriBorclari.GetDebtsRequiringAttention(),
                "Diqqət tələb edən borclar alınarkən xəta");
        }

        public decimal GetTotalDebtByCustomer(int musteriId)
        {
            return ExecuteWithExceptionHandling(
                () => _unitOfWork.MusteriBorclari.GetTotalDebtByMusteriId(musteriId),
                $"Müştərinin ümumi borcu hesablanarkən xəta (Müştəri ID: {musteriId})");
        }

        public decimal GetTotalOverdueDebt()
        {
            return ExecuteWithExceptionHandling(
                () => _unitOfWork.MusteriBorclari.GetTotalOverdueDebt(),
                "Ümumi gecikmiş borc hesablanarkən xəta");
        }

        public int CreateDebt(MusteriBorc musteriBorc)
        {
            return ExecuteWithExceptionHandling(() =>
            {
                musteriBorc.BorcNomresi = _unitOfWork.MusteriBorclari.GenerateBorcNomresi();
                musteriBorc.YaradilmaTarixi = DateTime.Now;

                var id = _unitOfWork.MusteriBorclari.Add(musteriBorc);
                _unitOfWork.Complete();

                _auditLogService.LogAction(
                    "MusteriBorc",
                    "CREATE",
                    id,
                    $"Yeni borc yaradıldı: {musteriBorc.BorcNomresi}",
                    musteriBorc.YaradanIstifadeciId
                );

                return id;
            }, "Borc yaradılarkən xəta");
        }

        public void UpdateDebt(MusteriBorc musteriBorc)
        {
            ExecuteWithExceptionHandling(() =>
            {
                var originalDebt = _unitOfWork.MusteriBorclari.GetById(musteriBorc.Id);
                if (originalDebt == null)
                    throw new ArgumentException("Borc tapılmadı");

                _unitOfWork.MusteriBorclari.Update(musteriBorc);
                _unitOfWork.Complete();

                _auditLogService.LogAction(
                    "MusteriBorc",
                    "UPDATE",
                    musteriBorc.Id,
                    $"Borc yeniləndi: {musteriBorc.BorcNomresi}",
                    musteriBorc.YaradanIstifadeciId
                );
            }, "Borc yenilənərkən xəta");
        }

        public void DeleteDebt(int id, int istifadeciId)
        {
            ExecuteWithExceptionHandling(() =>
            {
                var debt = _unitOfWork.MusteriBorclari.GetById(id);
                if (debt == null)
                    throw new ArgumentException("Borc tapılmadı");

                if (debt.BorcOdenisleri?.Any() == true)
                    throw new InvalidOperationException("Ödənişi olan borc silinə bilməz");

                _unitOfWork.MusteriBorclari.Delete(id);
                _unitOfWork.Complete();

                _auditLogService.LogAction(
                    "MusteriBorc",
                    "DELETE",
                    id,
                    $"Borc silindi: {debt.BorcNomresi}",
                    istifadeciId
                );
            }, "Borc silinərkən xəta");
        }

        public int AddPayment(BorcOdenis borcOdenis)
        {
            return ExecuteWithExceptionHandling(() =>
            {
                var debt = _unitOfWork.MusteriBorclari.GetById(borcOdenis.MusteriBorcId);
                if (debt == null)
                    throw new ArgumentException("Borc tapılmadı");

                if (borcOdenis.OdenisMeblegi > debt.QalanBorc)
                    throw new ArgumentException("Ödəniş məbləği qalan borcu aşa bilməz");

                borcOdenis.OdenisNomresi = _unitOfWork.BorcOdenisleri.GenerateOdenisNomresi();
                borcOdenis.YaradilmaTarixi = DateTime.Now;

                var id = _unitOfWork.BorcOdenisleri.Add(borcOdenis);
                _unitOfWork.Complete();

                UpdateDebtBalance(debt.Id);

                _auditLogService.LogAction(
                    "BorcOdenis",
                    "CREATE",
                    id,
                    $"Yeni ödəniş: {borcOdenis.OdenisNomresi} - {borcOdenis.OdenisMeblegi:C}",
                    borcOdenis.QebulEdenIstifadeciId
                );

                return id;
            }, "Ödəniş əlavə edilərkən xəta");
        }

        public void ConfirmPayment(int paymentId, int confirmingUserId)
        {
            ExecuteWithExceptionHandling(() =>
            {
                _unitOfWork.BorcOdenisleri.ConfirmPayment(paymentId, confirmingUserId);
                _unitOfWork.Complete();

                var payment = _unitOfWork.BorcOdenisleri.GetById(paymentId);
                UpdateDebtBalance(payment.MusteriBorcId);

                _auditLogService.LogAction(
                    "BorcOdenis",
                    "CONFIRM",
                    paymentId,
                    $"Ödəniş təsdiqləndi: {payment.OdenisNomresi}",
                    confirmingUserId
                );
            }, "Ödəniş təsdiqləyərkən xəta");
        }

        public void CancelPayment(int paymentId, int cancelingUserId)
        {
            ExecuteWithExceptionHandling(() =>
            {
                var payment = _unitOfWork.BorcOdenisleri.GetById(paymentId);
                if (payment == null)
                    throw new ArgumentException("Ödəniş tapılmadı");

                _unitOfWork.BorcOdenisleri.CancelPayment(paymentId);
                _unitOfWork.Complete();
                
                UpdateDebtBalance(payment.MusteriBorcId);

                _auditLogService.LogAction(
                    "BorcOdenis",
                    "CANCEL",
                    paymentId,
                    $"Ödəniş ləğv edildi: {payment.OdenisNomresi}",
                    cancelingUserId
                );
            }, "Ödəniş ləğv edilərkən xəta");
        }

        public IEnumerable<BorcOdenis> GetPaymentsByDebt(int musteriBorcId)
        {
            return ExecuteWithExceptionHandling(
                () => _unitOfWork.BorcOdenisleri.GetByMusteriBorcId(musteriBorcId),
                $"Borcun ödənişləri alınarkən xəta (Borc ID: {musteriBorcId})");
        }

        public IEnumerable<BorcOdenis> GetPaymentHistory(int debtId)
        {
            return ExecuteWithExceptionHandling(
                () => _unitOfWork.BorcOdenisleri.GetByMusteriBorcId(debtId),
                $"Ödəniş tarixçəsi alınarkən xəta (Borc ID: {debtId})");
        }

        public IEnumerable<BorcOdenis> GetPaymentsByCustomer(int musteriId)
        {
            return ExecuteWithExceptionHandling(
                () => _unitOfWork.BorcOdenisleri.GetByMusteriId(musteriId),
                $"Müştərinin ödənişləri alınarkən xəta (Müştəri ID: {musteriId})");
        }

        public IEnumerable<BorcOdenis> GetPendingPayments()
        {
            return ExecuteWithExceptionHandling(
                () => _unitOfWork.BorcOdenisleri.GetPendingPayments(),
                "Gözləyən ödənişlər alınarkən xəta");
        }

        public decimal CalculateInterest(int debtId)
        {
            return ExecuteWithExceptionHandling(() =>
            {
                var debt = _unitOfWork.MusteriBorclari.GetById(debtId);
                return debt?.FaizMeblegi ?? 0;
            }, $"Faiz hesablanarkən xəta (Borc ID: {debtId})");
        }

        public Dictionary<string, decimal> GetDebtSummary()
        {
            return ExecuteWithExceptionHandling(() =>
            {
                var debts = _unitOfWork.MusteriBorclari.GetActiveDebts().ToList();

                return new Dictionary<string, decimal>
                {
                    ["UmumiBorc"] = debts.Sum(d => d.QalanBorc),
                    ["GecikmisBorc"] = debts.Where(d => d.Gecikmiş).Sum(d => d.QalanBorc),
                    ["UmumiFaiz"] = debts.Sum(d => d.FaizMeblegi),
                    ["MusteriSayi"] = debts.Select(d => d.MusteriId).Distinct().Count()
                };
            }, "Borc xülasəsi hesablanarkən xəta");
        }

        private void UpdateDebtBalance(int debtId)
        {
            ExecuteWithExceptionHandling(() =>
            {
                var debt = _unitOfWork.MusteriBorclari.GetById(debtId);
                if (debt == null) return;

                var confirmedPayments = _unitOfWork.BorcOdenisleri.GetByMusteriBorcId(debtId)
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

                _unitOfWork.MusteriBorclari.Update(debt);
                _unitOfWork.Complete();
            }, $"Borc balansı yenilənərkən xəta (Borc ID: {debtId})");
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

        ~BorcService()
        {
            Dispose(false);
        }

        #endregion
    }
}