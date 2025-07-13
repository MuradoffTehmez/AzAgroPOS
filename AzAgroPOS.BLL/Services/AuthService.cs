using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Domain;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AzAgroPOS.BLL.Services
{
    public class AuthService
    {
        private readonly IstifadeciRepository _istifadeciRepository;

        public AuthService()
        {
            _istifadeciRepository = new IstifadeciRepository();
        }

        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public string Login(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                return "Email və ya şifrə boş ola bilməz.";
            }

            var istifadeci = _istifadeciRepository.GetByEmail(email);

            if (istifadeci == null)
            {
                return "İstifadəçi tapılmadı və ya şifrə yanlışdır.";
            }

            string girilenParolHash = ComputeSha256Hash(password);

            if (istifadeci.ParolHash != girilenParolHash)
            {
                return "İstifadəçi tapılmadı və ya şifrə yanlışdır.";
            }

            if (istifadeci.Status != "Aktiv")
            {
                return $"İstifadəçi aktiv deyil. Status: {istifadeci.Status}";
            }

            return $"Uğurlu giriş! Xoş gəldiniz, {istifadeci.Ad}.";
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                return "Email və ya şifrə boş ola bilməz.";
            }

            var istifadeci = await _istifadeciRepository.GetByEmailAsync(email);

            if (istifadeci == null)
            {
                return "İstifadəçi tapılmadı və ya şifrə yanlışdır.";
            }

            string girilenParolHash = ComputeSha256Hash(password);

            if (istifadeci.ParolHash != girilenParolHash)
            {
                return "İstifadəçi tapılmadı və ya şifrə yanlışdır.";
            }

            if (istifadeci.Status != "Aktiv")
            {
                return $"İstifadəçi aktiv deyil. Status: {istifadeci.Status}";
            }

            return $"Uğurlu giriş! Xoş gəldiniz, {istifadeci.Ad}.";
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

                if (password.Length < 6)
                {
                    return (false, "Şifrə ən azı 6 simvoldan ibarət olmalıdır.", null);
                }

                var istifadeci = new Istifadeci
                {
                    Ad = ad,
                    Soyad = soyad,
                    Email = email,
                    ParolHash = ComputeSha256Hash(password),
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

                string oldPasswordHash = ComputeSha256Hash(oldPassword);
                if (istifadeci.ParolHash != oldPasswordHash)
                {
                    return (false, "Köhnə şifrə yanlışdır.");
                }

                if (newPassword.Length < 6)
                {
                    return (false, "Yeni şifrə ən azı 6 simvoldan ibarət olmalıdır.");
                }

                istifadeci.ParolHash = ComputeSha256Hash(newPassword);
                await _istifadeciRepository.UpdateAsync(istifadeci);

                return (true, "Şifrə uğurla dəyişdirildi.");
            }
            catch (Exception ex)
            {
                return (false, $"Xəta baş verdi: {ex.Message}");
            }
        }
    }
}