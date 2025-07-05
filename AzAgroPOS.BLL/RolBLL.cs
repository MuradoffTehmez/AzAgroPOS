using AzAgroPOS.BLL.Helpers;
using AzAgroPOS.DAL;
using AzAgroPOS.Entities;
using System.Collections.Generic;

namespace AzAgroPOS.BLL
{
    /// <summary>
    /// Rollarla bağlı biznes məntiqini həyata keçirən sinif.
    /// </summary>
    public class RolBLL
    {
        private readonly RolDAL _dal = new RolDAL();

        /// <summary>
        /// Sistemdəki bütün rolların siyahısını qaytarır.
        /// </summary>
        /// <returns>Rollar siyahısı.</returns>
        public List<Rol> GetAll() => _dal.GetAll();

        /// <summary>
        /// Yeni rol yaradır və əməliyyatı jurnala yazır.
        /// </summary>
        /// <param name="rol">Əlavə ediləcək rol obyekti.</param>
        /// <param name="emeliyyatiEden">Əməliyyatı icra edən istifadəçi.</param>
        /// <param name="message">Nəticə mesajı.</param>
        /// <returns>Əməliyyatın uğurlu olub-olmadığı.</returns>
        public bool Add(Rol rol, Istifadeci emeliyyatiEden, out string message)
        {
            if (string.IsNullOrWhiteSpace(rol.Ad))
            {
                message = "Rol adı boş ola bilməz.";
                return false;
            }

            if (_dal.Exists(rol.Ad))
            {
                message = "Bu adlı rol artıq mövcuddur.";
                return false;
            }

            int newId = _dal.Add(rol);
            if (newId > 0)
            {
                message = "Rol uğurla əlavə edildi.";
                AuditLogger.Log(emeliyyatiEden.Id, "Rol Əlavə Etdi", $"Yeni rol: {rol.Ad} (ID: {newId})");
                return true;
            }

            message = "Rol əlavə edilərkən xəta baş verdi.";
            return false;
        }

        /// <summary>
        /// Rolun məlumatlarını yeniləyir və əməliyyatı jurnala yazır.
        /// </summary>
        /// <param name="rol">Yenilənəcək rol obyekti.</param>
        /// <param name="emeliyyatiEden">Əməliyyatı icra edən istifadəçi.</param>
        /// <param name="message">Nəticə mesajı.</param>
        /// <returns>Əməliyyatın uğurlu olub-olmadığı.</returns>
        public bool Update(Rol rol, Istifadeci emeliyyatiEden, out string message)
        {
            if (rol.Id <= 0)
            {
                message = "Yeniləmək üçün rol seçilməyib.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(rol.Ad))
            {
                message = "Rol adı boş ola bilməz.";
                return false;
            }

            if (_dal.Update(rol))
            {
                message = "Rol məlumatları uğurla yeniləndi.";
                AuditLogger.Log(emeliyyatiEden.Id, "Rol Yenilədi", $"Rol: {rol.Ad} (ID: {rol.Id})");
                return true;
            }

            message = "Rol yenilənərkən xəta baş verdi.";
            return false;
        }

        /// <summary>
        /// Rolun istifadəçilərə təyin edilib-edilmədiyini yoxlayır.
        /// </summary>
        /// <param name="rolId">Yoxlanılacaq rol ID-si.</param>
        /// <returns>Rolun istifadə edilib-edilməməsi.</returns>
        private bool IsRoleInUse(int rolId)
        {
            // Burada RolDAL-dan istifadəçilərin bu roldan istifadə edib-etmədiyini yoxlamaq üçün metod çağırılmalıdır
            return _dal.IsRoleAssignedToUsers(rolId);
        }

        /// <summary>
        /// Rol u silir və əməliyyatı jurnala yazır.
        /// </summary>
        /// <param name="rolId">Silinəcək rolun ID-si.</param>
        /// <param name="emeliyyatiEden">Əməliyyatı icra edən istifadəçi.</param>
        /// <param name="message">Nəticə mesajı.</param>
        /// <returns>Əməliyyatın uğurlu olub-olmadığı.</returns>
        public bool Delete(int rolId, Istifadeci emeliyyatiEden, out string message)
        {
            if (rolId <= 0)
            {
                message = "Silmək üçün rol seçilməyib.";
                return false;
            }

            var rol = _dal.GetById(rolId);
            if (rol == null)
            {
                message = "Rol tapılmadı.";
                return false;
            }

            if (IsRoleInUse(rolId))
            {
                message = "Bu rol istifadəçilərə təyin edilib. Silmək üçün əvvəlcə istifadəçilərdən çıxarın.";
                return false;
            }

            if (_dal.Delete(rolId))
            {
                message = "Rol uğurla silindi.";
                AuditLogger.Log(emeliyyatiEden.Id, "Rol Silindi", $"Rol: {rol.Ad} (ID: {rolId})");
                return true;
            }

            message = "Rol silinərkən xəta baş verdi.";
            return false;
        }
    }
}