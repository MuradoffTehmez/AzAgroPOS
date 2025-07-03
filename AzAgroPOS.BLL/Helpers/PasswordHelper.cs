// Fayl: AzAgroPOS.BLL/Helpers/PasswordHelper.cs
using System;
using System.Security.Cryptography;
using System.Text;

namespace AzAgroPOS.BLL.Helpers
{
    public static class PasswordHelper
    {
        private const int SaltSize = 16; // 128 bit
        private const int HashSize = 64; // 512 bit
        private const int Iterations = 10000;

        /// <summary>
        /// Verilmiş parolu təsadüfi yaradılmış salt ilə hash-ləyir.
        /// </summary>
        /// <param name="password">Hash-lənəcək parol.</param>
        /// <returns>Hash və Salt dəyərlərini saxlayan bir Tuple.</returns>
        public static (string hash, string salt) HashPassword(string password)
        {
            // 1. Salt yarat
            byte[] saltBytes = new byte[SaltSize];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            string salt = Convert.ToBase64String(saltBytes);

            // 2. Parolu salt ilə hash-lə (PBKDF2 alqoritmi)
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, Iterations))
            {
                byte[] hashBytes = pbkdf2.GetBytes(HashSize);
                string hash = Convert.ToBase64String(hashBytes);
                return (hash, salt);
            }
        }

        /// <summary>
        /// Verilmiş parolu, mövcud hash və salt ilə yoxlayır.
        /// </summary>
        /// <param name="password">Yoxlanılacaq parol.</param>
        /// <param name="storedHash">Verilənlər bazasındakı hash.</param>
        /// <param name="storedSalt">Verilənlər bazasındakı salt.</param>
        /// <returns>Parolların uyğun gəlib-gəlmədiyini bildirən boolean dəyər.</returns>
        public static bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            byte[] saltBytes = Convert.FromBase64String(storedSalt);
            byte[] storedHashBytes = Convert.FromBase64String(storedHash);

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, Iterations))
            {
                byte[] testHashBytes = pbkdf2.GetBytes(HashSize);

                // Hash-ləri müqayisə et
                for (int i = 0; i < HashSize; i++)
                {
                    if (testHashBytes[i] != storedHashBytes[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}