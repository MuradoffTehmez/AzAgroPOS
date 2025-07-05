using AzAgroPOS.BLL.Helpers;
using AzAgroPOS.DAL;
using AzAgroPOS.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AzAgroPOS.BLL
{
    public class IstifadeciBLL
    {
        private readonly IstifadeciDAL _istifadeciDal = new IstifadeciDAL();

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

        public List<Istifadeci> GetAll() => _istifadeciDal.GetAll();

        public List<Istifadeci> GetAllByRole(string roleName) => _istifadeciDal.GetAllByRole(roleName);

        public bool Add(Istifadeci istifadeci, string plainTextPassword, out string message)
        {
            // Validasiya (Yoxlamalar)
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

            // Parolu hash-ləyirik
            var (hash, salt) = PasswordHelper.HashPassword(plainTextPassword);
            istifadeci.ParolHash = hash;
            istifadeci.ParolSalt = salt;

            // DAL vasitəsilə bazaya yazırıq
            int newId = _istifadeciDal.Add(istifadeci);
            if (newId > 0)
            {
                message = "Yeni istifadəçi uğurla yaradıldı.";
                return true;
            }

            message = "İstifadəçi yaradılarkən xəta baş verdi.";
            return false;
        }

        public bool Update(Istifadeci istifadeci, string newPlainTextPassword, out string message)
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

            // Əgər yeni parol daxil edilibsə, onu hash-ləyirik
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
                // Əgər yeni parol daxil edilməyibsə, bu sahələri boş saxlayırıq ki, DAL tərəfindən parol yenilənməsin
                istifadeci.ParolHash = null;
                istifadeci.ParolSalt = null;
            }

            if (_istifadeciDal.Update(istifadeci))
            {
                message = "İstifadəçi məlumatları uğurla yeniləndi.";
                return true;
            }

            message = "İstifadəçi məlumatları yenilənərkən xəta baş verdi.";
            return false;
        }

        public bool Delete(int istifadeciId, out string message)
        {
            if (istifadeciId <= 0)
            {
                message = "Silmək üçün istifadəçi seçilməyib.";
                return false;
            }
            // Sistemdə ən az bir Admin qalmalıdır.
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
                return true;
            }

            message = "İstifadəçi silinərkən xəta baş verdi.";
            return false;
        }
    }
}