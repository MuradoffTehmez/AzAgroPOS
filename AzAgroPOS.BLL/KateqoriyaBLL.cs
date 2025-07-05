using AzAgroPOS.BLL.Helpers;
using AzAgroPOS.DAL;
using AzAgroPOS.Entities;
using System.Collections.Generic;

namespace AzAgroPOS.BLL
{
    /// <summary>
    /// Məhsul kateqoriyaları ilə bağlı biznes məntiqini həyata keçirən sinif.
    /// </summary>
    public class KateqoriyaBLL
    {
        private readonly KateqoriyaDAL _dal = new KateqoriyaDAL();

        /// <summary>
        /// Sistemdəki bütün məhsul kateqoriyalarını qaytarır.
        /// </summary>
        /// <returns>Kateqoriyalar siyahısı.</returns>
        public List<Kateqoriya> GetAll() => _dal.GetAll();

        /// <summary>
        /// Yeni kateqoriya əlavə edir və əməliyyatı jurnala yazır.
        /// </summary>
        /// <param name="kateqoriya">Əlavə ediləcək kateqoriya obyekti.</param>
        /// <param name="emeliyyatiEden">Əməliyyatı icra edən istifadəçi.</param>
        /// <param name="message">Nəticə mesajı.</param>
        /// <returns>Əməliyyatın uğurlu olub-olmadığı.</returns>
        public bool Add(Kateqoriya kateqoriya, Istifadeci emeliyyatiEden, out string message)
        {
            if (string.IsNullOrWhiteSpace(kateqoriya.Ad))
            {
                message = "Kateqoriya adı boş ola bilməz.";
                return false;
            }

            if (_dal.Exists(kateqoriya.Ad))
            {
                message = "Bu adlı kateqoriya artıq mövcuddur.";
                return false;
            }

            int newId = _dal.Add(kateqoriya);
            if (newId > 0)
            {
                message = "Kateqoriya uğurla əlavə edildi.";
                AuditLogger.Log(emeliyyatiEden.Id, "Kateqoriya Əlavə Etdi",
                    $"Yeni kateqoriya: {kateqoriya.Ad} (ID: {newId})");
                return true;
            }

            message = "Kateqoriya əlavə edilərkən xəta baş verdi.";
            return false;
        }

        /// <summary>
        /// Kateqoriya məlumatlarını yeniləyir və əməliyyatı jurnala yazır.
        /// </summary>
        /// <param name="kateqoriya">Yenilənəcək kateqoriya obyekti.</param>
        /// <param name="emeliyyatiEden">Əməliyyatı icra edən istifadəçi.</param>
        /// <param name="message">Nəticə mesajı.</param>
        /// <returns>Əməliyyatın uğurlu olub-olmadığı.</returns>
        public bool Update(Kateqoriya kateqoriya, Istifadeci emeliyyatiEden, out string message)
        {
            if (kateqoriya.Id <= 0)
            {
                message = "Yeniləmək üçün kateqoriya seçilməyib.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(kateqoriya.Ad))
            {
                message = "Kateqoriya adı boş ola bilməz.";
                return false;
            }

            if (_dal.Update(kateqoriya))
            {
                message = "Kateqoriya məlumatları uğurla yeniləndi.";
                AuditLogger.Log(emeliyyatiEden.Id, "Kateqoriya Yenilədi",
                    $"Kateqoriya: {kateqoriya.Ad} (ID: {kateqoriya.Id})");
                return true;
            }

            message = "Kateqoriya yenilənərkən xəta baş verdi.";
            return false;
        }

        /// <summary>
        /// Kateqoriyanın istifadə edilib-edilmədiyini yoxlayır.
        /// </summary>
        /// <param name="kateqoriyaId">Yoxlanılacaq kateqoriya ID-si.</param>
        /// <returns>Kateqoriyanın istifadə edilib-edilməməsi.</returns>
        private bool IsKateqoriyaInUse(int kateqoriyaId)
        {
            return _dal.IsKateqoriyaUsedInProducts(kateqoriyaId);
        }

        /// <summary>
        /// Kateqoriyanı silir və əməliyyatı jurnala yazır.
        /// </summary>
        /// <param name="kateqoriyaId">Silinəcək kateqoriyanın ID-si.</param>
        /// <param name="emeliyyatiEden">Əməliyyatı icra edən istifadəçi.</param>
        /// <param name="message">Nəticə mesajı.</param>
        /// <returns>Əməliyyatın uğurlu olub-olmadığı.</returns>
        public bool Delete(int kateqoriyaId, Istifadeci emeliyyatiEden, out string message)
        {
            if (kateqoriyaId <= 0)
            {
                message = "Silmək üçün kateqoriya seçilməyib.";
                return false;
            }

            var kateqoriya = _dal.GetById(kateqoriyaId);
            if (kateqoriya == null)
            {
                message = "Kateqoriya tapılmadı.";
                return false;
            }

            if (IsKateqoriyaInUse(kateqoriyaId))
            {
                message = "Bu kateqoriya məhsullarda istifadə olunub. Silmək üçün əvvəlcə məhsullardan çıxarın.";
                return false;
            }

            if (_dal.Delete(kateqoriyaId))
            {
                message = "Kateqoriya uğurla silindi.";
                AuditLogger.Log(emeliyyatiEden.Id, "Kateqoriya Silindi",
                    $"Kateqoriya: {kateqoriya.Ad} (ID: {kateqoriyaId})");
                return true;
            }

            message = "Kateqoriya silinərkən xəta baş verdi.";
            return false;
        }
    }
}