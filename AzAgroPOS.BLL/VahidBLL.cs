using AzAgroPOS.BLL.Helpers;
using AzAgroPOS.DAL;
using AzAgroPOS.Entities;
using System.Collections.Generic;

namespace AzAgroPOS.BLL
{
    /// <summary>
    /// Ölçü vahidləri ilə bağlı biznes məntiqini həyata keçirən sinif.
    /// </summary>
    public class VahidBLL
    {
        private readonly VahidDAL _dal = new VahidDAL();

        /// <summary>
        /// Sistemdəki bütün ölçü vahidlərini qaytarır.
        /// </summary>
        /// <returns>Ölçü vahidləri siyahısı.</returns>
        public List<Vahid> GetAll() => _dal.GetAll();

        /// <summary>
        /// Yeni ölçü vahidi əlavə edir və əməliyyatı jurnala yazır.
        /// </summary>
        /// <param name="vahid">Əlavə ediləcək vahid obyekti.</param>
        /// <param name="emeliyyatiEden">Əməliyyatı icra edən istifadəçi.</param>
        /// <param name="message">Nəticə mesajı.</param>
        /// <returns>Əməliyyatın uğurlu olub-olmadığı.</returns>
        public bool Add(Vahid vahid, Istifadeci emeliyyatiEden, out string message)
        {
            if (string.IsNullOrWhiteSpace(vahid.Ad))
            {
                message = "Vahid adı boş ola bilməz.";
                return false;
            }

            if (_dal.Exists(vahid.Ad))
            {
                message = "Bu adlı vahid artıq mövcuddur.";
                return false;
            }

            int newId = _dal.Add(vahid);
            if (newId > 0)
            {
                message = "Ölçü vahidi uğurla əlavə edildi.";
                AuditLogger.Log(emeliyyatiEden.Id, "Vahid Əlavə Etdi", $"Yeni vahid: {vahid.Ad} (ID: {newId})");
                return true;
            }

            message = "Vahid əlavə edilərkən xəta baş verdi.";
            return false;
        }

        /// <summary>
        /// Ölçü vahidinin məlumatlarını yeniləyir və əməliyyatı jurnala yazır.
        /// </summary>
        /// <param name="vahid">Yenilənəcək vahid obyekti.</param>
        /// <param name="emeliyyatiEden">Əməliyyatı icra edən istifadəçi.</param>
        /// <param name="message">Nəticə mesajı.</param>
        /// <returns>Əməliyyatın uğurlu olub-olmadığı.</returns>
        public bool Update(Vahid vahid, Istifadeci emeliyyatiEden, out string message)
        {
            if (vahid.Id <= 0)
            {
                message = "Yeniləmək üçün vahid seçilməyib.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(vahid.Ad))
            {
                message = "Vahid adı boş ola bilməz.";
                return false;
            }

            if (_dal.Update(vahid))
            {
                message = "Ölçü vahidi uğurla yeniləndi.";
                AuditLogger.Log(emeliyyatiEden.Id, "Vahid Yenilədi", $"Vahid: {vahid.Ad} (ID: {vahid.Id})");
                return true;
            }

            message = "Vahid yenilənərkən xəta baş verdi.";
            return false;
        }

        /// <summary>
        /// Ölçü vahidinin istifadə edilib-edilmədiyini yoxlayır.
        /// </summary>
        /// <param name="vahidId">Yoxlanılacaq vahid ID-si.</param>
        /// <returns>Vahidin istifadə edilib-edilməməsi.</returns>
        private bool IsVahidInUse(int vahidId)
        {
            return _dal.IsVahidUsedInProducts(vahidId);
        }

        /// <summary>
        /// Ölçü vahidini silir və əməliyyatı jurnala yazır.
        /// </summary>
        /// <param name="vahidId">Silinəcək vahidin ID-si.</param>
        /// <param name="emeliyyatiEden">Əməliyyatı icra edən istifadəçi.</param>
        /// <param name="message">Nəticə mesajı.</param>
        /// <returns>Əməliyyatın uğurlu olub-olmadığı.</returns>
        public bool Delete(int vahidId, Istifadeci emeliyyatiEden, out string message)
        {
            if (vahidId <= 0)
            {
                message = "Silmək üçün vahid seçilməyib.";
                return false;
            }

            var vahid = _dal.GetById(vahidId);
            if (vahid == null)
            {
                message = "Vahid tapılmadı.";
                return false;
            }

            if (IsVahidInUse(vahidId))
            {
                message = "Bu vahid məhsullarda istifadə olunub. Silmək üçün əvvəlcə məhsullardan çıxarın.";
                return false;
            }

            if (_dal.Delete(vahidId))
            {
                message = "Ölçü vahidi uğurla silindi.";
                AuditLogger.Log(emeliyyatiEden.Id, "Vahid Silindi", $"Vahid: {vahid.Ad} (ID: {vahidId})");
                return true;
            }

            message = "Vahid silinərkən xəta baş verdi.";
            return false;
        }
    }
}