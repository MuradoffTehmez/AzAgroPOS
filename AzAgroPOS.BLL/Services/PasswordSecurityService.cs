using System;
using System.Security.Cryptography;
using System.Text;

namespace AzAgroPOS.BLL.Services
{
    /// <summary>
    /// Şifrələrin təhlükəsiz hash və salt ilə qorunması üçün servis
    /// KRİTİK TƏHLÜKƏSİZLİK PROBLEMİ #1-in həlli
    /// </summary>
    public class PasswordSecurityService
    {
        private const int SaltSize = 32; // 256 bit
        private const int HashSize = 32; // 256 bit
        private const int Iterations = 10000; // PBKDF2 iterasiya sayı

        /// <summary>
        /// Şifrə üçün təhlükəsiz hash və salt yaradır
        /// </summary>
        /// <param name="password">Orijinal şifrə</param>
        /// <param name="passwordHash">Çıxış: Hash dəyəri</param>
        /// <param name="passwordSalt">Çıxış: Salt dəyəri</param>
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("Şifrə boş ola bilməz", nameof(password));

            // Təsadüfi salt yaradırıq
            using (var rng = RandomNumberGenerator.Create())
            {
                passwordSalt = new byte[SaltSize];
                rng.GetBytes(passwordSalt);
            }

            // PBKDF2 istifadə edərək hash yaradırıq
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, passwordSalt, Iterations))
            {
                passwordHash = pbkdf2.GetBytes(HashSize);
            }
        }

        /// <summary>
        /// Şifrənin düzgünlüyünü yoxlayır
        /// </summary>
        /// <param name="password">Yoxlanılacaq şifrə</param>
        /// <param name="passwordHash">Saxlanılmış hash</param>
        /// <param name="passwordSalt">Saxlanılmış salt</param>
        /// <returns>Şifrə düzgündürsə true</returns>
        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("Şifrə boş ola bilməz", nameof(password));

            if (passwordHash == null || passwordHash.Length != HashSize)
                throw new ArgumentException("Hash dəyəri səhvdir", nameof(passwordHash));

            if (passwordSalt == null || passwordSalt.Length != SaltSize)
                throw new ArgumentException("Salt dəyəri səhvdir", nameof(passwordSalt));

            // Verilmiş şifrə üçün hash hesablayırıq
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, passwordSalt, Iterations))
            {
                var computedHash = pbkdf2.GetBytes(HashSize);

                // Constant-time comparison (timing attack-dan qorunmaq üçün)
                return SlowEquals(passwordHash, computedHash);
            }
        }

        /// <summary>
        /// Timing attack-dan qorunmaq üçün constant-time comparison
        /// </summary>
        /// <param name="a">Birinci array</param>
        /// <param name="b">İkinci array</param>
        /// <returns>Array-lər bərabərsə true</returns>
        private bool SlowEquals(byte[] a, byte[] b)
        {
            var diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
            {
                diff |= (uint)(a[i] ^ b[i]);
            }
            return diff == 0;
        }

        /// <summary>
        /// Şifrənin güclülüyünü yoxlayır
        /// </summary>
        /// <param name="password">Yoxlanılacaq şifrə</param>
        /// <returns>Şifrə güclülük nəticəsi</returns>
        public PasswordStrengthResult ValidatePasswordStrength(string password)
        {
            var result = new PasswordStrengthResult();

            if (string.IsNullOrEmpty(password))
            {
                result.IsValid = false;
                result.ErrorMessage = "Şifrə boş ola bilməz";
                return result;
            }

            // Minimum uzunluq
            if (password.Length < 8)
            {
                result.IsValid = false;
                result.ErrorMessage = "Şifrə ən azı 8 simbol olmalıdır";
                return result;
            }

            // Maksimum uzunluq
            if (password.Length > 128)
            {
                result.IsValid = false;
                result.ErrorMessage = "Şifrə maksimum 128 simbol ola bilər";
                return result;
            }

            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;
            bool hasSpecial = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpper = true;
                else if (char.IsLower(c)) hasLower = true;
                else if (char.IsDigit(c)) hasDigit = true;
                else if (!char.IsLetterOrDigit(c)) hasSpecial = true;
            }

            // Güclülük yoxlaması
            int score = 0;
            if (hasUpper) score++;
            if (hasLower) score++;
            if (hasDigit) score++;
            if (hasSpecial) score++;

            if (score < 3)
            {
                result.IsValid = false;
                result.ErrorMessage = "Şifrə böyük hərf, kiçik hərf, rəqəm və xüsusi simvollardan ən azı 3 növ ehtiva etməlidir";
                return result;
            }

            // Ümumi nümunələri yoxla
            var commonPatterns = new[] { "123456", "password", "qwerty", "admin", "azagro" };
            var lowerPassword = password.ToLower();
            
            foreach (var pattern in commonPatterns)
            {
                if (lowerPassword.Contains(pattern))
                {
                    result.IsValid = false;
                    result.ErrorMessage = "Şifrə çox sadədir və təxmin edilə bilər";
                    return result;
                }
            }

            result.IsValid = true;
            result.StrengthScore = score;
            result.ErrorMessage = "Şifrə güclüdür";
            return result;
        }
    }

    /// <summary>
    /// Şifrə güclülüyü yoxlama nəticəsi
    /// </summary>
    public class PasswordStrengthResult
    {
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }
        public int StrengthScore { get; set; } // 1-4 arası
        public string StrengthLevel => StrengthScore switch
        {
            1 => "Zəif",
            2 => "Orta",
            3 => "Güclü", 
            4 => "Çox Güclü",
            _ => "Naməlum"
        };
    }
}