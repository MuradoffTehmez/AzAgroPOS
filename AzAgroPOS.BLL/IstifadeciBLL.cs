using AzAgroPOS.BLL.Helpers;
using AzAgroPOS.DAL;
using AzAgroPOS.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AzAgroPOS.BLL
{
    /// <summary>
    /// İstifadəçilərlə bağlı biznes məntiqini həyata keçirən sinif.
    /// </summary>
    public class IstifadeciBLL
    {
        private readonly IstifadeciDAL _istifadeciDal = new IstifadeciDAL();

        /// <summary>
        /// İstifadəçinin daxil olmasını yoxlayır.
        /// </summary>
        /// <param name="istifadeciAdi">İstifadəçi adı.</param>
        /// <param name="parol">Açıq mətndə parol.</param>
        /// <returns>Uğurlu olduqda Istifadeci obyekti, əks halda null.</returns>
        public Istifadeci Login(string istifadeciAdi, string parol)
        {
            var istifadeci = _istifadeciDal.GetByUsername(istifadeciAdi);

            if (istifadeci == null || !istifadeci.Aktivdir)
            {
                return null;
            }

            bool isPasswordCorrect = PasswordHelper.VerifyPassword(parol, istifadeci.ParolHash, istifadeci.ParolSalt);

            return isPasswordCorrect ? istifadeci : null;
        }

        /// <summary>
        /// Bütün aktiv istifadəçilərin siyahısını qaytarır.
        /// </summary>
        /// <returns>İstifadəçilər siyahısı.</returns>
        public List<Istifadeci> GetAll() => _istifadeciDal.GetAll();

        /// <summary>
        /// Müəyyən rola malik istifadəçilərin siyahısını qaytarır.
        /// </summary>
        /// <param name="roleName">Rol adı.</param>
        /// <returns>İstifadəçilər siyahısı.</returns>
        public List<Istifadeci> GetAllByRole(string roleName) => _istifadeciDal.GetAllByRole(roleName);

        /// <summary>
        /// Yeni istifadəçi yaradır, parolunu hash-ləyir və əməliyyatı jurnala yazır.
        /// </summary>
        /// <param name="istifadeci">Əlavə ediləcək istifadəçi obyekti.</param>
        /// <param name="plainTextPassword">İstifadəçinin açıq mətndə parolu.</param>
        /// <param name="emeliyyatiEden">Əməliyyatı icra edən admin.</param>
        /// <param name="message">Nəticə mesajı.</param>
        /// <returns>Əməliyyatın uğurlu olub-olmadığı.</returns>
        public bool Add(Istifadeci istifadeci, string plainTextPassword, Istifadeci emeliyyatiEden, out string message)
        {
            if (string.IsNullOrWhiteSpace(istifadeci.Ad) || string.IsNullOrWhiteSpace(istifadeci.Soyad) || string.IsNullOrWhiteSpace(istifadeci.IstifadeciAdi))
            {
                message = "Ad, Soyad və İstifadəçi adı xanaları boş ola bilməz.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(plainTextPassword) || plainTextPassword.Length < 6)
            {
                message = "Parol boş ola bilməz və ən az 6 simvoldan ibarət olmalıdır.";
                return false;
            }
            if (_istifadeciDal.GetByUsername(istifadeci.IstifadeciAdi) != null)
            {
                message = "Bu istifadəçi adı artıq mövcuddur. Zəhmət olmasa, fərqli bir ad seçin.";
                return false;
            }

            var (hash, salt) = PasswordHelper.HashPassword(plainTextPassword);
            istifadeci.ParolHash = hash;
            istifadeci.ParolSalt = salt;

            int newId = _istifadeciDal.Add(istifadeci);
            if (newId > 0)
            {
                message = "Yeni istifadəçi uğurla yaradıldı.";
                AuditLogger.Log(emeliyyatiEden.Id, "İstifadəçi Əlavə Etdi", $"Yeni istifadəçi yaradıldı: {istifadeci.IstifadeciAdi} (ID: {newId})");
                return true;
            }
            message = "İstifadəçi yaradılarkən xəta baş verdi.";
            return false;
        }

        /// <summary>
        /// Mövcud istifadəçinin məlumatlarını yeniləyir və əməliyyatı jurnala yazır.
        /// </summary>
        /// <param name="istifadeci">Yenilənəcək istifadəçi obyekti.</param>
        /// <param name="newPlainTextPassword">Əgər dəyişdirilirsə, yeni parol. Boş olarsa, parol dəyişməz.</param>
        /// <param name="emeliyyatiEden">Əməliyyatı icra edən admin.</param>
        /// <param name="message">Nəticə mesajı.</param>
        /// <returns>Əməliyyatın uğurlu olub-olmadığı.</returns>
        public bool Update(Istifadeci istifadeci, string newPlainTextPassword, Istifadeci emeliyyatiEden, out string message)
        {
            if (istifadeci.Id <= 0)
            {
                message = "Yeniləmək üçün istifadəçi seçilməyib.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(istifadeci.Ad) || string.IsNullOrWhiteSpace(istifadeci.Soyad) || string.IsNullOrWhiteSpace(istifadeci.IstifadeciAdi))
            {
                message = "Ad, Soyad və İstifadəçi adı xanaları boş ola bilməz.";
                return false;
            }

            if (!string.IsNullOrWhiteSpace(newPlainTextPassword))
            {
                if (newPlainTextPassword.Length < 6)
                {
                    message = "Yeni parol ən az 6 simvoldan ibarət olmalıdır.";
                    return false;
                }
                var (hash, salt) = PasswordHelper.HashPassword(newPlainTextPassword);
                istifadeci.ParolHash = hash;
                istifadeci.ParolSalt = salt;
            }
            else
            {
                istifadeci.ParolHash = null;
                istifadeci.ParolSalt = null;
            }

            if (_istifadeciDal.Update(istifadeci))
            {
                message = "İstifadəçi məlumatları uğurla yeniləndi.";
                AuditLogger.Log(emeliyyatiEden.Id, "İstifadəçi Yenilədi", $"İstifadəçi məlumatları yeniləndi: {istifadeci.IstifadeciAdi} (ID: {istifadeci.Id})");
                return true;
            }
            message = "İstifadəçi məlumatları yenilənərkən xəta baş verdi.";
            return false;
        }

        /// <summary>
        /// İstifadəçini deaktiv edir (soft delete) və əməliyyatı jurnala yazır.
        /// </summary>
        /// <param name="istifadeciId">Silinəcək istifadəçinin ID-si.</param>
        /// <param name="emeliyyatiEden">Əməliyyatı icra edən admin.</param>
        /// <param name="message">Nəticə mesajı.</param>
        /// <returns>Əməliyyatın uğurlu olub-olmadığı.</returns>
        public bool Delete(int istifadeciId, Istifadeci emeliyyatiEden, out string message)
        {
            if (istifadeciId <= 0)
            {
                message = "Silmək üçün istifadəçi seçilməyib.";
                return false;
            }

            var allUsers = _istifadeciDal.GetAll();
            var userToDelete = allUsers.FirstOrDefault(u => u.Id == istifadeciId);
            if (userToDelete != null && userToDelete.RolAdi == "Admin")
            {
                int adminCount = allUsers.Count(u => u.RolAdi == "Admin" && u.Aktivdir);
                if (adminCount <= 1)
                {
                    message = "Sistemdəki sonuncu Admin istifadəçisini silmək olmaz!";
                    return false;
                }
            }

            if (_istifadeciDal.Delete(istifadeciId))
            {
                message = "İstifadəçi uğurla deaktiv edildi.";
                AuditLogger.Log(emeliyyatiEden.Id, "İstifadəçi Silindi", $"İstifadəçi deaktiv edildi (ID: {istifadeciId})");
                return true;
            }
            message = "İstifadəçi silinərkən xəta baş verdi.";
            return false;
        }
    }
}