// Fayl: AzAgroPOS.BLL/IstifadeciBLL.cs
using AzAgroPOS.BLL.Helpers;
using AzAgroPOS.DAL;
using AzAgroPOS.Entities;

namespace AzAgroPOS.BLL
{
    public class IstifadeciBLL
    {
        private readonly IstifadeciDAL _istifadeciDal;

        public IstifadeciBLL()
        {
            _istifadeciDal = new IstifadeciDAL();
        }

        /// <summary>
        /// İstifadəçi adı və parolu yoxlayaraq sistemə girişi təmin edir.
        /// </summary>
        /// <param name="istifadeciAdi">Daxil edilmiş istifadəçi adı.</param>
        /// <param name="parol">Daxil edilmiş parol.</param>
        /// <returns>Giriş uğurlu olarsa Istifadeci obyektini, uğursuz olarsa null qaytarır.</returns>
        public Istifadeci Login(string istifadeciAdi, string parol)
        {
            // 1. İstifadəçini DAL vasitəsilə bazadan al
            var istifadeci = _istifadeciDal.GetByUsername(istifadeciAdi);

            // 2. Biznes Məntiqi Yoxlamaları

            // İstifadəçi tapılmadı?
            if (istifadeci == null)
            {
                return null;
            }

            // İstifadəçi aktiv deyil?
            if (!istifadeci.Aktivdir)
            {
                return null; // Və ya xüsusi bir mesaj üçün fərqli bir nəticə qaytara bilərik
            }

            // Parol yoxlaması (PasswordHelper istifadə edərək)
            bool isPasswordCorrect = PasswordHelper.VerifyPassword(parol, istifadeci.ParolHash, istifadeci.ParolSalt);

            if (isPasswordCorrect)
            {
                // Giriş uğurludur, istifadəçi obyektini qaytar
                return istifadeci;
            }
            else
            {
                // Parol səhvdir
                return null;
            }
        }

        // Digər biznes məntiqləri (məsələn, yeni istifadəçi yaradarkən yoxlamalar) bura əlavə olunacaq
    }
}