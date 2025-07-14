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
        private readonly IstifadeciRepository _istifadeciRepository;

        public AuthService()
        {
            _istifadeciRepository = new IstifadeciRepository();
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
                var istifadeci = _istifadeciRepository.GetByEmail(email);

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
                _istifadeciRepository.Update(istifadeci);

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
                var istifadeci = await _istifadeciRepository.GetByEmailAsync(email);

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
                await _istifadeciRepository.UpdateAsync(istifadeci);

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

                if (await _istifadeciRepository.EmailExistsAsync(email))
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

                var createdUser = await _istifadeciRepository.CreateAsync(istifadeci);
                return (true, "İstifadəçi uğurla yaradıldı.", createdUser);
            }
            catch (Exception ex)
            {
                return (false, $"Xəta baş verdi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message)> ChangePasswordAsync(string email, string oldPassword, string newPassword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(oldPassword) || string.IsNullOrWhiteSpace(newPassword))
                {
                    return (false, "Bütün sahələr doldurulmalıdır.");
                }

                var istifadeci = await _istifadeciRepository.GetByEmailAsync(email);
                if (istifadeci == null)
                {
                    return (false, "İstifadəçi tapılmadı.");
                }

                if (!VerifyPassword(oldPassword, istifadeci.ParolHash))
                {
                    return (false, "Köhnə şifrə yanlışdır.");
                }

                if (newPassword.Length < 8)
                {
                    return (false, "Yeni şifrə ən azı 8 simvoldan ibarət olmalıdır.");
                }

                // Check password complexity
                if (!IsPasswordComplex(newPassword))
                {
                    return (false, "Şifrə ən azı bir böyük hərf, bir kiçik hərf və bir rəqəm olmalıdır.");
                }

                istifadeci.ParolHash = HashPassword(newPassword);
                istifadeci.YenilenmeTarixi = DateTime.Now;
                await _istifadeciRepository.UpdateAsync(istifadeci);

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

            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpper = true;
                if (char.IsLower(c)) hasLower = true;
                if (char.IsDigit(c)) hasDigit = true;
            }

            return hasUpper && hasLower && hasDigit;
        }

        public List<Istifadeci> GetActiveWorkers()
        {
            return _istifadeciRepository.GetAll()
                .Where(i => i.Status == SystemConstants.Status.Active && 
                       (i.Rol.Ad == SystemConstants.Roles.Worker || 
                        i.Rol.Ad == SystemConstants.Roles.Manager || 
                        i.Rol.Ad == SystemConstants.Roles.Administrator))
                .ToList();
        }

        public void Dispose()
        {
            _istifadeciRepository?.Dispose();
        }
    }
}