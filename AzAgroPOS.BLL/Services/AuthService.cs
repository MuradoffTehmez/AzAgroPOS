using AzAgroPOS.DAL.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace AzAgroPOS.BLL.Services
{
    public class AuthService
    {
        private readonly IstifadeciRepository _istifadeciRepository;

        public AuthService()
        {
            _istifadeciRepository = new IstifadeciRepository();
        }

        // Parolu hash-ləmək üçün köməkçi metod
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
            // 1. Biznes Qaydası: Boş girişlərin yoxlanılması
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                return "Email və ya şifrə boş ola bilməz.";
            }

            // 2. İstifadəçini DAL vasitəsilə bazadan almaq
            var istifadeci = _istifadeciRepository.GetByEmail(email);

            // 3. Biznes Qaydası: İstifadəçinin mövcudluğunun yoxlanılması
            if (istifadeci == null)
            {
                return "İstifadəçi tapılmadı və ya şifrə yanlışdır.";
            }

            // 4. Girilən şifrəni hash-ləyib bazadakı ilə müqayisə etmək
            string girilenParolHash = ComputeSha256Hash(password);

            if (istifadeci.ParolHash != girilenParolHash)
            {
                return "İstifadəçi tapılmadı və ya şifrə yanlışdır.";
            }

            // 5. Biznes Qaydası: İstifadəçi statusunun yoxlanılması
            if (istifadeci.Status != "Aktiv")
            {
                return $"İstifadəçi aktiv deyil. Status: {istifadeci.Status}";
            }

            // Hər şey qaydasındadırsa
            return $"Uğurlu giriş! Xoş gəldiniz, {istifadeci.Ad}.";
        }
    }
}