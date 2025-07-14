using AzAgroPOS.DAL;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.Entities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace AzAgroPOS.BLL.Services
{
    public class MusteriService : IDisposable
    {
        private readonly AzAgroDbContext _context;
        private readonly MusteriRepository _musteriRepository;
        private readonly MusteriQrupuRepository _musteriQrupuRepository;
        private readonly IAuditLogService _auditLogService;
        private bool _disposed = false;

        public MusteriService(AzAgroDbContext context = null, IAuditLogService auditLogService = null)
        {
            _context = context ?? new AzAgroDbContext();
            _musteriRepository = new MusteriRepository(_context);
            _musteriQrupuRepository = new MusteriQrupuRepository(_context);
            _auditLogService = auditLogService ?? new AuditLogService(_context);
        }

        #region Müştəri CRUD Operations

        public IEnumerable<Musteri> GetAllCustomers()
        {
            return ExecuteWithExceptionHandling(
                () => _musteriRepository.GetAll().ToList(),
                "Müştəri məlumatları alınarkən xəta");
        }

        public IEnumerable<Musteri> GetActiveCustomers()
        {
            return ExecuteWithExceptionHandling(
                () => _musteriRepository.GetActive().ToList(),
                "Aktiv müştəri məlumatları alınarkən xəta");
        }

        public Musteri GetCustomerById(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Yanlış müştəri ID-si", nameof(id));

            return ExecuteWithExceptionHandling(
                () => _musteriRepository.GetById(id),
                $"Müştəri məlumatı alınarkən xəta (ID: {id})");
        }

        public Musteri GetCustomerByCode(string musteriKodu)
        {
            if (string.IsNullOrEmpty(musteriKodu))
                throw new ArgumentException("Müştəri kodu boş ola bilməz", nameof(musteriKodu));

            return ExecuteWithExceptionHandling(
                () => _musteriRepository.GetByCode(musteriKodu),
                $"Müştəri məlumatı alınarkən xəta (Kod: {musteriKodu})");
        }

        public (bool Success, string Message, Musteri Customer) CreateCustomer(Musteri musteri, int yaradanIstifadeciId)
        {
            return ExecuteWithTransaction(() =>
            {
                // Validation
                var validationResult = ValidateCustomer(musteri);
                if (!validationResult.IsValid)
                    return (false, validationResult.ErrorMessage, null);

                // Check if code exists
                if (!string.IsNullOrEmpty(musteri.MusteriKodu) &&
                    _musteriRepository.IsCodeExists(musteri.MusteriKodu))
                {
                    return (false, "Bu müştəri kodu artıq mövcuddur.", null);
                }

                // Check if email exists
                if (!string.IsNullOrEmpty(musteri.Email) &&
                    _musteriRepository.IsEmailExists(musteri.Email))
                {
                    return (false, "Bu email ünvanı artıq istifadə olunur.", null);
                }

                musteri.YaradanIstifadeciId = yaradanIstifadeciId;
                musteri.YaradilmaTarixi = DateTime.Now;
                musteri.Status = SystemConstants.Status.Active;

                var createdCustomer = _musteriRepository.Add(musteri);

                // Log audit
                _auditLogService.LogAction("Musteri", "CREATE", createdCustomer.Id,
                    $"Yeni müştəri yaradıldı: {createdCustomer.TamAd}", yaradanIstifadeciId);

                return (true, "Müştəri uğurla yaradıldı.", createdCustomer);
            }, "Müştəri yaradılarkən xəta");
        }

        public (bool Success, string Message) UpdateCustomer(Musteri musteri, int yenileyenIstifadeciId)
        {
            return ExecuteWithTransaction(() =>
            {
                // Validation
                var validationResult = ValidateCustomer(musteri, musteri.Id);
                if (!validationResult.IsValid)
                    return (false, validationResult.ErrorMessage);

                // Check if code exists
                if (!string.IsNullOrEmpty(musteri.MusteriKodu) &&
                    _musteriRepository.IsCodeExists(musteri.MusteriKodu, musteri.Id))
                {
                    return (false, "Bu müştəri kodu artıq mövcuddur.");
                }

                // Check if email exists
                if (!string.IsNullOrEmpty(musteri.Email) &&
                    _musteriRepository.IsEmailExists(musteri.Email, musteri.Id))
                {
                    return (false, "Bu email ünvanı artıq istifadə olunur.");
                }

                _musteriRepository.Update(musteri);

                // Log audit
                _auditLogService.LogAction("Musteri", "UPDATE", musteri.Id,
                    $"Müştəri yeniləndi: {musteri.TamAd}", yenileyenIstifadeciId);

                return (true, "Müştəri məlumatları uğurla yeniləndi.");
            }, "Müştəri yenilənərkən xəta");
        }

        public (bool Success, string Message) DeleteCustomer(int id, int silenIstifadeciId)
        {
            return ExecuteWithExceptionHandling(() =>
            {
                var musteri = GetCustomerById(id);
                if (musteri == null)
                    return (false, "Müştəri tapılmadı.");

                // Check if customer can be deleted
                if (musteri.CariBorc > 0)
                    return (false, "Borcu olan müştəri silinə bilməz.");

                _musteriRepository.Delete(id);

                // Log audit
                _auditLogService.LogAction("Musteri", "DELETE", id,
                    $"Müştəri silindi: {musteri.TamAd}", silenIstifadeciId);

                return (true, "Müştəri uğurla silindi.");
            }, "Müştəri silinərkən xəta");
        }

        #endregion

        #region Customer Groups

        public IEnumerable<MusteriQrupu> GetAllCustomerGroups()
        {
            return ExecuteWithExceptionHandling(
                () => _musteriQrupuRepository.GetActive().ToList(),
                "Müştəri qrupları alınarkən xəta");
        }

        public (bool Success, string Message, MusteriQrupu Group) CreateCustomerGroup(MusteriQrupu qrup, int yaradanIstifadeciId)
        {
            return ExecuteWithExceptionHandling(() =>
            {
                // Validation
                if (string.IsNullOrEmpty(qrup.Ad))
                    return (false, "Qrup adı mütləqdir.", null);

                if (_musteriQrupuRepository.IsNameExists(qrup.Ad))
                    return (false, "Bu qrup adı artıq mövcuddur.", null);

                qrup.YaradanIstifadeciId = yaradanIstifadeciId;
                qrup.YaradilmaTarixi = DateTime.Now;
                qrup.Status = SystemConstants.Status.Active;

                var createdGroup = _musteriQrupuRepository.Add(qrup);

                // Log audit
                _auditLogService.LogAction("MusteriQrupu", "CREATE", createdGroup.Id,
                    $"Yeni müştəri qrupu yaradıldı: {createdGroup.Ad}", yaradanIstifadeciId);

                return (true, "Müştəri qrupu uğurla yaradıldı.", createdGroup);
            }, "Müştəri qrupu yaradılarkən xəta");
        }

        #endregion

        #region Search and Filter

        public IEnumerable<Musteri> SearchCustomers(string searchTerm)
        {
            return ExecuteWithExceptionHandling(
                () => _musteriRepository.SearchCustomers(searchTerm).ToList(),
                "Müştəri axtarışında xəta");
        }

        public IEnumerable<Musteri> GetCustomersByGroup(int qrupId)
        {
            return ExecuteWithExceptionHandling(
                () => _musteriRepository.GetByGroup(qrupId).ToList(),
                $"Qrup üzrə müştərilər alınarkən xəta (Qrup ID: {qrupId})");
        }

        public IEnumerable<Musteri> GetVIPCustomers()
        {
            return ExecuteWithExceptionHandling(
                () => _musteriRepository.GetVIPCustomers().ToList(),
                "VIP müştərilər alınarkən xəta");
        }

        public IEnumerable<Musteri> GetNewCustomers(int days = 30)
        {
            return ExecuteWithExceptionHandling(
                () => _musteriRepository.GetNewCustomers(days).ToList(),
                "Yeni müştərilər alınarkən xəta");
        }

        public IEnumerable<Musteri> GetInactiveCustomers(int days = 90)
        {
            return ExecuteWithExceptionHandling(
                () => _musteriRepository.GetInactiveCustomers(days).ToList(),
                "Passiv müştərilər alınarkən xəta");
        }

        #endregion

        #region Statistics and Reports

        public List<object> GetCustomerStatistics()
        {
            return ExecuteWithExceptionHandling(
                _musteriRepository.GetCustomerStatistics,
                "Müştəri statistikaları alınarkən xəta");
        }

        public List<object> GetTopCustomers(int count = 10)
        {
            return ExecuteWithExceptionHandling(
                () => _musteriRepository.GetTopCustomers(count),
                "Top müştərilər alınarkən xəta");
        }

        public List<object> GetGroupStatistics()
        {
            return ExecuteWithExceptionHandling(
                _musteriQrupuRepository.GetGroupStatistics,
                "Qrup statistikaları alınarkən xəta");
        }

        #endregion

        #region Business Logic

        public void UpdateCustomerDebt(int musteriId, decimal yeniBorc)
        {
            ExecuteWithExceptionHandling(
                () => _musteriRepository.UpdateDebtAmount(musteriId, yeniBorc),
                $"Müştəri borc məlumatı yenilənərkən xəta (Müştəri ID: {musteriId})");
        }

        public void UpdateCustomerPurchase(int musteriId, decimal alistutar)
        {
            ExecuteWithExceptionHandling(
                () => _musteriRepository.UpdatePurchaseAmount(musteriId, alistutar),
                $"Müştəri alış məlumatı yenilənərkən xəta (Müştəri ID: {musteriId})");
        }

        #endregion

        #region Helper Methods

        private (bool IsValid, string ErrorMessage) ValidateCustomer(Musteri musteri, int? excludeId = null)
        {
            if (string.IsNullOrEmpty(musteri.Ad))
                return (false, "Ad mütləqdir.");

            if (string.IsNullOrEmpty(musteri.Soyad))
                return (false, "Soyad mütləqdir.");

            if (!string.IsNullOrEmpty(musteri.Email) && !IsValidEmail(musteri.Email))
                return (false, "Email formatı düzgün deyil.");

            if (musteri.KreditLimiti < 0)
                return (false, "Kredit limiti mənfi ola bilməz.");

            if (musteri.DogumTarixi.HasValue && musteri.DogumTarixi.Value > DateTime.Now)
                return (false, "Doğum tarixi gələcəkdə ola bilməz.");

            return (true, "");
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
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

        private T ExecuteWithTransaction<T>(Func<T> action, string errorMessage)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var result = action();
                    transaction.Commit();
                    return result;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new ApplicationException($"{errorMessage}: {ex.Message}", ex);
                }
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
                    _context?.Dispose();
                    _musteriRepository?.Dispose();
                    _musteriQrupuRepository?.Dispose();
                    _auditLogService?.Dispose();
                }
                _disposed = true;
            }
        }

        ~MusteriService()
        {
            Dispose(false);
        }

        #endregion
    }
}