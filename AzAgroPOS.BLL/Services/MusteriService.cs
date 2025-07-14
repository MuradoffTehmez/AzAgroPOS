using AzAgroPOS.DAL;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.Entities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AzAgroPOS.BLL.Services
{
    public class MusteriService : IDisposable
    {
        private readonly MusteriRepository _musteriRepository;
        private readonly MusteriQrupuRepository _musteriQrupuRepository;
        private readonly AuditLogService _auditLogService;
        private readonly AzAgroDbContext _context;

        public MusteriService(AzAgroDbContext context = null, AuditLogService auditLogService = null)
        {
            _context = context ?? new AzAgroDbContext();
            _musteriRepository = new MusteriRepository(_context);
            _musteriQrupuRepository = new MusteriQrupuRepository(_context);
            _auditLogService = auditLogService ?? new AuditLogService();
        }

        #region Müştəri CRUD Operations

        public IEnumerable<Musteri> GetAllCustomers()
        {
            try
            {
                return _musteriRepository.GetAll().ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Müştəri məlumatları alınarkən xəta: {ex.Message}", ex);
            }
        }

        public IEnumerable<Musteri> GetActiveCustomers()
        {
            try
            {
                return _musteriRepository.GetActive().ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Aktiv müştəri məlumatları alınarkən xəta: {ex.Message}", ex);
            }
        }

        public Musteri GetCustomerById(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("Yanlış müştəri ID-si", nameof(id));
                    
                return _musteriRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Müştəri məlumatı alınarkən xəta: {ex.Message}", ex);
            }
        }

        public Musteri GetCustomerByCode(string musteriKodu)
        {
            try
            {
                if (string.IsNullOrEmpty(musteriKodu))
                    throw new ArgumentException("Müştəri kodu boş ola bilməz", nameof(musteriKodu));
                    
                return _musteriRepository.GetByCode(musteriKodu);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Müştəri məlumatı alınarkən xəta: {ex.Message}", ex);
            }
        }

        public (bool Success, string Message, Musteri Customer) CreateCustomer(Musteri musteri, int yaradanIstifadeciId)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
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

                    transaction.Commit();
                    return (true, "Müştəri uğurla yaradıldı.", createdCustomer);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return (false, $"Müştəri yaradılarkən xəta: {ex.Message}", null);
                }
            }
        }

        public (bool Success, string Message) UpdateCustomer(Musteri musteri, int yenileyenIstifadeciId)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
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

                    var updatedCustomer = _musteriRepository.Update(musteri);

                    // Log audit
                    _auditLogService.LogAction("Musteri", "UPDATE", musteri.Id, 
                        $"Müştəri yeniləndi: {musteri.TamAd}", yenileyenIstifadeciId);

                    transaction.Commit();
                    return (true, "Müştəri məlumatları uğurla yeniləndi.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return (false, $"Müştəri yenilənərkən xəta: {ex.Message}");
                }
            }
        }

        public (bool Success, string Message) DeleteCustomer(int id, int silenIstifadeciId)
        {
            try
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
            }
            catch (Exception ex)
            {
                return (false, $"Müştəri silinərkən xəta: {ex.Message}");
            }
        }

        #endregion

        #region Customer Groups

        public IEnumerable<MusteriQrupu> GetAllCustomerGroups()
        {
            try
            {
                return _musteriQrupuRepository.GetActive().ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Müştəri qrupları alınarkən xəta: {ex.Message}", ex);
            }
        }

        public (bool Success, string Message, MusteriQrupu Group) CreateCustomerGroup(MusteriQrupu qrup, int yaradanIstifadeciId)
        {
            try
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
            }
            catch (Exception ex)
            {
                return (false, $"Müştəri qrupu yaradılarkən xəta: {ex.Message}", null);
            }
        }

        #endregion

        #region Search and Filter

        public IEnumerable<Musteri> SearchCustomers(string searchTerm)
        {
            try
            {
                return _musteriRepository.SearchCustomers(searchTerm).ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Müştəri axtarışında xəta: {ex.Message}", ex);
            }
        }

        public IEnumerable<Musteri> GetCustomersByGroup(int qrupId)
        {
            try
            {
                return _musteriRepository.GetByGroup(qrupId).ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Qrup üzrə müştərilər alınarkən xəta: {ex.Message}", ex);
            }
        }

        public IEnumerable<Musteri> GetVIPCustomers()
        {
            try
            {
                return _musteriRepository.GetVIPCustomers().ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"VIP müştərilər alınarkən xəta: {ex.Message}", ex);
            }
        }

        public IEnumerable<Musteri> GetNewCustomers(int days = 30)
        {
            try
            {
                return _musteriRepository.GetNewCustomers(days).ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Yeni müştərilər alınarkən xəta: {ex.Message}", ex);
            }
        }

        public IEnumerable<Musteri> GetInactiveCustomers(int days = 90)
        {
            try
            {
                return _musteriRepository.GetInactiveCustomers(days).ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Passiv müştərilər alınarkən xəta: {ex.Message}", ex);
            }
        }

        #endregion

        #region Statistics and Reports

        public List<object> GetCustomerStatistics()
        {
            try
            {
                return _musteriRepository.GetCustomerStatistics();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Müştəri statistikaları alınarkən xəta: {ex.Message}", ex);
            }
        }

        public List<object> GetTopCustomers(int count = 10)
        {
            try
            {
                return _musteriRepository.GetTopCustomers(count);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Top müştərilər alınarkən xəta: {ex.Message}", ex);
            }
        }

        public List<object> GetGroupStatistics()
        {
            try
            {
                return _musteriQrupuRepository.GetGroupStatistics();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Qrup statistikaları alınarkən xəta: {ex.Message}", ex);
            }
        }

        #endregion

        #region Business Logic

        public void UpdateCustomerDebt(int musteriId, decimal yeniBorc)
        {
            try
            {
                _musteriRepository.UpdateDebtAmount(musteriId, yeniBorc);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Müştəri borc məlumatı yenilənərkən xəta: {ex.Message}", ex);
            }
        }

        public void UpdateCustomerPurchase(int musteriId, decimal alistutar)
        {
            try
            {
                _musteriRepository.UpdatePurchaseAmount(musteriId, alistutar);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Müştəri alış məlumatı yenilənərkən xəta: {ex.Message}", ex);
            }
        }

        #endregion

        #region Validation

        private (bool IsValid, string ErrorMessage) ValidateCustomer(Musteri musteri, int? excludeId = null)
        {
            if (string.IsNullOrEmpty(musteri.Ad))
                return (false, "Ad mütləqdir.");

            if (string.IsNullOrEmpty(musteri.Soyad))
                return (false, "Soyad mütləqdir.");

            if (!string.IsNullOrEmpty(musteri.Email))
            {
                if (!IsValidEmail(musteri.Email))
                    return (false, "Email formatı düzgün deyil.");
            }

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
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        public void Dispose()
        {
            _musteriRepository?.Dispose();
            _musteriQrupuRepository?.Dispose();
            _auditLogService?.Dispose();
        }
    }
}