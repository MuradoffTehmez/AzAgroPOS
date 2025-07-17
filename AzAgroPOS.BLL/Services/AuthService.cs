using AzAgroPOS.BLL.Interfaces;
using AzAgroPOS.DAL;
using AzAgroPOS.DAL.Interfaces;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.Entities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;

namespace AzAgroPOS.BLL.Services
{
    public class AuthService : IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuditLogService _auditLogService;
        private bool _disposed = false;

        public AuthService(IUnitOfWork unitOfWork, IAuditLogService auditLogService = null)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _auditLogService = auditLogService;
        }

        /// <summary>
        /// Hash password using BCrypt with salt
        /// </summary>
        /// <param name="password">Plain text password</param>
        /// <returns>Hashed password with salt</returns>
        public string HashPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password cannot be null or empty", nameof(password));

            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt(12));
        }

        public async Task<(bool Success, string Message)> ResetPasswordAsync(int userId, string newPassword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(newPassword))
                {
                    return (false, "Yeni şifrə boş ola bilməz.");
                }

                if (!IsPasswordComplex(newPassword))
                {
                    return (false, "Şifrə ən azı 8 simvoldan, bir böyük hərfdən, bir kiçik hərfdən və bir rəqəmdən ibarət olmalıdır.");
                }

                var istifadeci = await _unitOfWork.Istifadeciler.GetByIdAsync(userId);
                if (istifadeci == null)
                {
                    return (false, "İstifadəçi tapılmadı.");
                }

                istifadeci.ParolHash = HashPassword(newPassword);
                istifadeci.YenilenmeTarixi = DateTime.Now;
                await _unitOfWork.Istifadeciler.UpdateAsync(istifadeci);
                await _unitOfWork.CompleteAsync();

                return (true, "Şifrə uğurla sıfırlandı.");
            }
            catch (Exception ex)
            {
                return (false, $"Xəta baş verdi: {ex.Message}");
            }
        }

        /// <summary>
        /// Verify password against hash
        /// </summary>
        /// <param name="password">Plain text password</param>
        /// <param name="hash">Stored hash</param>
        /// <returns>True if password matches</returns>
        public bool VerifyPassword(string password, string hash)
        {
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(hash))
                return false;

            try
            {
                return BCrypt.Net.BCrypt.Verify(password, hash);
            }
            catch
            {
                return false;
            }
        }

        public string Login(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                return "Email və ya şifrə boş ola bilməz.";
            }

            try
            {
                var istifadeci = _unitOfWork.Istifadeciler.GetByEmail(email);

                // Always perform hash computation to prevent timing attacks
                string dummyHash = "$2a$12$dummyhashfortimingatnormalizedconstanttime";

                if (istifadeci == null)
                {
                    // Perform dummy verification to normalize timing
                    VerifyPassword(password, dummyHash);
                    return "İstifadəçi tapılmadı və ya şifrə yanlışdır.";
                }

                if (!VerifyPassword(password, istifadeci.ParolHash))
                {
                    return "İstifadəçi tapılmadı və ya şifrə yanlışdır.";
                }

                if (istifadeci.Status != "Aktiv")
                {
                    return $"İstifadəçi aktiv deyil. Status: {istifadeci.Status}";
                }

                // Update last login time
                istifadeci.SonGiris = DateTime.Now;
                _unitOfWork.Istifadeciler.Update(istifadeci);
                _unitOfWork.Complete();

                return $"Uğurlu giriş! Xoş gəldiniz, {istifadeci.Ad}.";
            }
            catch (Exception ex)
            {
                return $"Sistem xətası: {ex.Message}";
            }
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                return "Email və ya şifrə boş ola bilməz.";
            }

            try
            {
                var istifadeci = await _unitOfWork.Istifadeciler.GetByEmailAsync(email);

                // Always perform hash computation to prevent timing attacks
                string dummyHash = "$2a$12$dummyhashfortimingatnormalizedconstanttime";

                if (istifadeci == null)
                {
                    // Perform dummy verification to normalize timing
                    VerifyPassword(password, dummyHash);
                    return "İstifadəçi tapılmadı və ya şifrə yanlışdır.";
                }

                if (!VerifyPassword(password, istifadeci.ParolHash))
                {
                    return "İstifadəçi tapılmadı və ya şifrə yanlışdır.";
                }

                if (istifadeci.Status != "Aktiv")
                {
                    return $"İstifadəçi aktiv deyil. Status: {istifadeci.Status}";
                }

                // Update last login time
                istifadeci.SonGiris = DateTime.Now;
                await _unitOfWork.Istifadeciler.UpdateAsync(istifadeci);
                await _unitOfWork.CompleteAsync();

                return $"Uğurlu giriş! Xoş gəldiniz, {istifadeci.Ad}.";
            }
            catch (Exception ex)
            {
                return $"Sistem xətası: {ex.Message}";
            }
        }

        public async Task<(bool Success, string Message, Istifadeci User)> CreateUserAsync(string ad, string soyad, string email, string password, int? rolId = null, int? temaId = null)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(ad) || string.IsNullOrWhiteSpace(soyad) ||
                    string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                {
                    return (false, "Bütün sahələr doldurulmalıdır.", null);
                }

                if (await _unitOfWork.Istifadeciler.EmailExistsAsync(email))
                {
                    return (false, "Bu email ünvanı artıq istifadə olunur.", null);
                }

                if (password.Length < 8)
                {
                    return (false, "Şifrə ən azı 8 simvoldan ibarət olmalıdır.", null);
                }

                // Check password complexity
                if (!IsPasswordComplex(password))
                {
                    return (false, "Şifrə ən azı bir böyük hərf, bir kiçik hərf və bir rəqəm olmalıdır.", null);
                }

                var istifadeci = new Istifadeci
                {
                    Ad = ad,
                    Soyad = soyad,
                    Email = email,
                    ParolHash = HashPassword(password),
                    RolId = rolId ?? 2,
                    TemaId = temaId ?? 1,
                    Status = "Aktiv",
                    YaradilmaTarixi = DateTime.Now
                };

                var createdUser = await _unitOfWork.Istifadeciler.CreateAsync(istifadeci);
                await _unitOfWork.CompleteAsync();
                return (true, "İstifadəçi uğurla yaradıldı.", createdUser);
            }
            catch (Exception ex)
            {
                return (false, $"Xəta baş verdi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message)> ChangePasswordAsync(int userId, string oldPassword, string newPassword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(oldPassword) || string.IsNullOrWhiteSpace(newPassword))
                {
                    return (false, "Köhnə və yeni şifrə sahələri doldurulmalıdır.");
                }

                if (oldPassword == newPassword)
                {
                    return (false, "Yeni şifrə köhnə şifrə ilə eyni ola bilməz.");
                }

                var istifadeci = await _unitOfWork.Istifadeciler.GetByIdAsync(userId);
                if (istifadeci == null)
                {
                    return (false, "İstifadəçi tapılmadı.");
                }

                if (!VerifyPassword(oldPassword, istifadeci.ParolHash))
                {
                    return (false, "Köhnə şifrə yanlışdır.");
                }

                if (!IsPasswordComplex(newPassword))
                {
                    return (false, "Yeni şifrə ən azı 8 simvoldan, bir böyük hərfdən, bir kiçik hərfdən və bir rəqəmdən ibarət olmalıdır.");
                }

                istifadeci.ParolHash = HashPassword(newPassword);
                istifadeci.YenilenmeTarixi = DateTime.Now;
                await _unitOfWork.Istifadeciler.UpdateAsync(istifadeci);
                await _unitOfWork.CompleteAsync();

                return (true, "Şifrə uğurla dəyişdirildi.");
            }
            catch (Exception ex)
            {
                return (false, $"Xəta baş verdi: {ex.Message}");
            }
        }

        /// <summary>
        /// Check if password meets complexity requirements
        /// </summary>
        /// <param name="password">Password to check</param>
        /// <returns>True if password is complex enough</returns>
        private bool IsPasswordComplex(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
                return false;

            // Ən azı bir böyük hərf, bir kiçik hərf və bir rəqəm olmalıdır.
            return password.Any(char.IsUpper) && password.Any(char.IsLower) && password.Any(char.IsDigit);
        }

        public List<Istifadeci> GetActiveWorkers()
        {
            return _unitOfWork.Istifadeciler.GetAll()
                .Cast<Istifadeci>()
                .Where(i => i.Status == SystemConstants.Status.Active &&
                       (i.Rol?.Ad == SystemConstants.Roles.Worker ||
                        i.Rol?.Ad == SystemConstants.Roles.Manager ||
                        i.Rol?.Ad == SystemConstants.Roles.Administrator))
                .ToList();
        }

        public async Task<(bool Success, Istifadeci User)> LoginWithTokenAsync(string token)
        {
            return await ExecuteWithExceptionHandlingAsync(async () =>
            {
                var user = await _unitOfWork.Istifadeciler.GetByRememberMeTokenAsync(token);

                if (user != null && user.RememberMeTokenExpiry.HasValue && user.RememberMeTokenExpiry.Value > DateTime.Now)
                {
                    // Token düzgün və vaxtı keçməyibsə, son giriş tarixini yenilə
                    user.SonGiris = DateTime.Now;
                    await _unitOfWork.Istifadeciler.UpdateAsync(user);
                    await _unitOfWork.CompleteAsync();

                    _auditLogService?.LogAction(
                        "Istifadeci",
                        "TOKEN_LOGIN",
                        user.Id,
                        "Token ilə giriş",
                        user.Id
                    );

                    return (true, user);
                }

                // Token səhvdirsə və ya vaxtı keçibsə, təmizlə
                if (user != null)
                {
                    user.RememberMeToken = null;
                    user.RememberMeTokenExpiry = null;
                    await _unitOfWork.Istifadeciler.UpdateAsync(user);
                    await _unitOfWork.CompleteAsync();
                }

                return (false, null);
            }, "Token ilə giriş zamanı xəta");
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

        private async Task ExecuteWithExceptionHandlingAsync(Func<Task> action, string errorMessage)
        {
            try
            {
                await action();
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

        ~AuthService()
        {
            Dispose(false);
        }

        #endregion
    }
}