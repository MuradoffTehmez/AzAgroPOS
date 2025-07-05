using AzAgroPOS.BLL.Helpers;
using AzAgroPOS.DAL;
using AzAgroPOS.Entities;
using System.Collections.Generic;

namespace AzAgroPOS.BLL
{
    /// <summary>
    /// Təmir statusları ilə bağlı biznes məntiqini həyata keçirən sinif.
    /// </summary>
    public class TemirStatusuBLL
    {
        private readonly TemirStatusuDAL _dal = new TemirStatusuDAL();

        /// <summary>
        /// Sistemdəki bütün təmir statuslarını qaytarır.
        /// </summary>
        /// <returns>Təmir statusları siyahısı.</returns>
        public List<TemirStatusu> GetAll() => _dal.GetAll();

        /// <summary>
        /// Yeni təmir statusu əlavə edir və əməliyyatı jurnala yazır.
        /// </summary>
        /// <param name="status">Əlavə ediləcək status obyekti.</param>
        /// <param name="emeliyyatiEden">Əməliyyatı icra edən istifadəçi.</param>
        /// <param name="message">Nəticə mesajı.</param>
        /// <returns>Əməliyyatın uğurlu olub-olmadığı.</returns>
        public bool Add(TemirStatusu status, Istifadeci emeliyyatiEden, out string message)
        {
            if (string.IsNullOrWhiteSpace(status.Ad))
            {
                message = "Status adı boş ola bilməz.";
                return false;
            }

            if (_dal.Exists(status.Ad))
            {
                message = "Bu adlı status artıq mövcuddur.";
                return false;
            }

            int newId = _dal.Add(status);
            if (newId > 0)
            {
                message = "Təmir statusu uğurla əlavə edildi.";
                AuditLogger.Log(emeliyyatiEden.Id, "Təmir Statusu Əlavə Etdi",
                    $"Yeni status: {status.Ad} (ID: {newId})");
                return true;
            }

            message = "Təmir statusu əlavə edilərkən xəta baş verdi.";
            return false;
        }

        /// <summary>
        /// Təmir statusunun məlumatlarını yeniləyir və əməliyyatı jurnala yazır.
        /// </summary>
        /// <param name="status">Yenilənəcək status obyekti.</param>
        /// <param name="emeliyyatiEden">Əməliyyatı icra edən istifadəçi.</param>
        /// <param name="message">Nəticə mesajı.</param>
        /// <returns>Əməliyyatın uğurlu olub-olmadığı.</returns>
        public bool Update(TemirStatusu status, Istifadeci emeliyyatiEden, out string message)
        {
            if (status.Id <= 0)
            {
                message = "Yeniləmək üçün status seçilməyib.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(status.Ad))
            {
                message = "Status adı boş ola bilməz.";
                return false;
            }

            if (_dal.Update(status))
            {
                message = "Təmir statusu uğurla yeniləndi.";
                AuditLogger.Log(emeliyyatiEden.Id, "Təmir Statusu Yenilədi",
                    $"Status: {status.Ad} (ID: {status.Id})");
                return true;
            }

            message = "Təmir statusu yenilənərkən xəta baş verdi.";
            return false;
        }

        /// <summary>
        /// Təmir statusunun istifadə edilib-edilmədiyini yoxlayır.
        /// </summary>
        /// <param name="statusId">Yoxlanılacaq status ID-si.</param>
        /// <returns>Statusun istifadə edilib-edilməməsi.</returns>
        private bool IsStatusInUse(int statusId)
        {
            return _dal.IsStatusUsedInRepairs(statusId);
        }

        /// <summary>
        /// Təmir statusunu silir və əməliyyatı jurnala yazır.
        /// </summary>
        /// <param name="statusId">Silinəcək statusun ID-si.</param>
        /// <param name="emeliyyatiEden">Əməliyyatı icra edən istifadəçi.</param>
        /// <param name="message">Nəticə mesajı.</param>
        /// <returns>Əməliyyatın uğurlu olub-olmadığı.</returns>
        public bool Delete(int statusId, Istifadeci emeliyyatiEden, out string message)
        {
            if (statusId <= 0)
            {
                message = "Silmək üçün status seçilməyib.";
                return false;
            }

            var status = _dal.GetById(statusId);
            if (status == null)
            {
                message = "Status tapılmadı.";
                return false;
            }

            if (IsStatusInUse(statusId))
            {
                message = "Bu status təmir sifarişlərində istifadə olunub. Silmək üçün əvvəlcə sifarişlərdən çıxarın.";
                return false;
            }

            if (_dal.Delete(statusId))
            {
                message = "Təmir statusu uğurla silindi.";
                AuditLogger.Log(emeliyyatiEden.Id, "Təmir Statusu Silindi",
                    $"Status: {status.Ad} (ID: {statusId})");
                return true;
            }

            message = "Təmir statusu silinərkən xəta baş verdi.";
            return false;
        }
    }
}