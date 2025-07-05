using AzAgroPOS.BLL.Helpers;
using AzAgroPOS.DAL;
using AzAgroPOS.Entities;
using System.Collections.Generic;

namespace AzAgroPOS.BLL
{
    /// <summary>
    /// Təmir sifarişləri ilə bağlı biznes məntiqini həyata keçirən sinif.
    /// </summary>
    public class TemirBLL
    {
        private readonly TemirDAL _dal = new TemirDAL();

        /// <summary>
        /// Bütün aktiv təmir sifarişlərinin siyahısını qaytarır.
        /// </summary>
        /// <returns>Təmir sifarişləri siyahısı.</returns>
        public List<Temir> GetAll() => _dal.GetAll();

        /// <summary>
        /// Yeni təmir sifarişi yaradır və əməliyyatı jurnala yazır.
        /// </summary>
        /// <param name="temir">Əlavə ediləcək təmir sifarişi obyekti.</param>
        /// <param name="emeliyyatiEden">Əməliyyatı icra edən istifadəçi.</param>
        /// <param name="message">Nəticə mesajı.</param>
        /// <returns>Əməliyyatın uğurlu olub-olmadığı.</returns>
        public bool Add(Temir temir, Istifadeci emeliyyatiEden, out string message)
        {
            if (temir.MusteriId == 0) 
            { 
                message = "Müştəri seçilməlidir."; 
                return false; 
            }
            if (string.IsNullOrWhiteSpace(temir.CihazAdi)) 
            { 
                message = "Cihazın adı boş ola bilməz."; 
                return false; 
            }
            if (string.IsNullOrWhiteSpace(temir.ProblemTesviri)) 
            { 
                message = "Problem təsviri boş ola bilməz."; 
                return false; 
            }

            int newId = _dal.Add(temir);
            if (newId > 0)
            {
                message = $"Yeni təmir sifarişi uğurla yaradıldı. Qeydiyyat Nömrəsi: {newId}";
                AuditLogger.Log(emeliyyatiEden.Id, "Təmir Sifarişi Əlavə Etdi", 
                    $"Yeni təmir sifarişi: {temir.CihazAdi} (ID: {newId}, Müştəri ID: {temir.MusteriId})");
                return true;
            }

            message = "Sifariş yaradılarkən xəta baş verdi.";
            return false;
        }

        /// <summary>
        /// Mövcud təmir sifarişini yeniləyir və əməliyyatı jurnala yazır.
        /// </summary>
        /// <param name="temir">Yenilənəcək təmir sifarişi obyekti.</param>
        /// <param name="emeliyyatiEden">Əməliyyatı icra edən istifadəçi.</param>
        /// <param name="message">Nəticə mesajı.</param>
        /// <returns>Əməliyyatın uğurlu olub-olmadığı.</returns>
        public bool Update(Temir temir, Istifadeci emeliyyatiEden, out string message)
        {
            if (temir.Id == 0) 
            { 
                message = "Yeniləmək üçün sifariş seçilməyib."; 
                return false; 
            }
            if (temir.MusteriId == 0) 
            { 
                message = "Müştəri seçilməlidir."; 
                return false; 
            }
            if (string.IsNullOrWhiteSpace(temir.CihazAdi)) 
            { 
                message = "Cihazın adı boş ola bilməz."; 
                return false; 
            }

            bool result = _dal.Update(temir);
            if (result)
            {
                message = "Sifariş uğurla yeniləndi.";
                AuditLogger.Log(emeliyyatiEden.Id, "Təmir Sifarişi Yenilədi", 
                    $"Təmir sifarişi: {temir.CihazAdi} (ID: {temir.Id}). " +
                    $"Status: {temir.StatusAdi}, Problem: {temir.ProblemTesviri}");
                return true;
            }

            message = "Sifariş yenilənərkən xəta baş verdi.";
            return false;
        }

        /// <summary>
        /// Təmir sifarişini sistemdən silir və əməliyyatı jurnala yazır.
        /// </summary>
        /// <param name="temirId">Silinəcək təmir sifarişinin ID-si.</param>
        /// <param name="emeliyyatiEden">Əməliyyatı icra edən istifadəçi.</param>
        /// <param name="message">Nəticə mesajı.</param>
        /// <returns>Əməliyyatın uğurlu olub-olmadığı.</returns>
        public bool Delete(int temirId, Istifadeci emeliyyatiEden, out string message)
        {
            if (temirId == 0)
            {
                message = "Silmək üçün sifariş seçilməyib.";
                return false;
            }

            // Əvvəlcə təmir məlumatlarını alırıq ki, jurnalda istifadə edək
            var temir = _dal.GetById(temirId);
            string cihazAdi = temir?.CihazAdi ?? "Naməlum cihaz";

            bool result = _dal.Delete(temirId);
            if (result)
            {
                message = "Sifariş uğurla silindi.";
                AuditLogger.Log(emeliyyatiEden.Id, "Təmir Sifarişi Silindi", 
                    $"Təmir sifarişi: {cihazAdi} (ID: {temirId})");
                return true;
            }

            message = "Sifariş silinərkən xəta baş verdi.";
            return false;
        }

        /// <summary>
        /// Təmir sifarişini tamamlandı olaraq qeyd edir və əməliyyatı jurnala yazır.
        /// </summary>
        /// <param name="temirId">Tamamlanacaq təmir sifarişinin ID-si.</param>
        /// <param name="yekunXerc">Yekun xərci.</param>
        /// <param name="emeliyyatiEden">Əməliyyatı icra edən istifadəçi.</param>
        /// <param name="message">Nəticə mesajı.</param>
        /// <returns>Əməliyyatın uğurlu olub-olmadığı.</returns>
        public bool CompleteRepair(int temirId, decimal yekunXerc, Istifadeci emeliyyatiEden, out string message)
        {
            if (temirId == 0)
            {
                message = "Sifariş seçilməyib.";
                return false;
            }

            // Əvvəlcə təmir məlumatlarını alırıq ki, jurnalda istifadə edək
            var temir = _dal.GetById(temirId);
            string cihazAdi = temir?.CihazAdi ?? "Naməlum cihaz";

            if (_dal.CompleteRepair(temirId, yekunXerc))
            {
                message = "Təmir sifarişi uğurla tamamlandı.";
                AuditLogger.Log(emeliyyatiEden.Id, "Təmir Tamamlandı", 
                    $"Təmir sifarişi: {cihazAdi} (ID: {temirId}). " +
                    $"Yekun xərc: {yekunXerc} AZN");
                return true;
            }

            message = "Sifariş tamamlanarkən xəta baş verdi.";
            return false;
        }

        /// <summary>
        /// Verilmiş ID-yə görə tək bir təmiri və ona aid bütün hissələri gətirir.
        /// </summary>
        public Temir GetById(int temirId)
        {
            if (temirId <= 0) return null;

            var temir = _dal.GetById(temirId);
            if (temir != null)
            {
                // Təmir tapılıbsa, ona aid ehtiyat hissələrini də gətirib obyektə əlavə edirik
                var hisselerBll = new TemirHisseleriBLL();
                temir.Hisseler = hisselerBll.GetByTemirId(temirId);
            }
            return temir;
        }
    }
}