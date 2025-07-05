using AzAgroPOS.BLL.Helpers;
using AzAgroPOS.DAL;
using AzAgroPOS.Entities;
using System.Collections.Generic;

namespace AzAgroPOS.BLL
{
    /// <summary>
    /// Təmirə aid edilən ehtiyat hissələri ilə bağlı biznes məntiqini həyata keçirən sinif.
    /// </summary>
    public class TemirHisseleriBLL
    {
        private readonly TemirHisseleriDAL _dal = new TemirHisseleriDAL();

        /// <summary>
        /// Müəyyən təmir sifarişinə aid edilən bütün ehtiyat hissələrini qaytarır.
        /// </summary>
        /// <param name="temirId">Təmir sifarişinin ID-si.</param>
        /// <returns>Ehtiyat hissələri siyahısı.</returns>
        public List<TemirHissesi> GetByTemirId(int temirId) => _dal.GetByTemirId(temirId);

        /// <summary>
        /// Təmirə yeni ehtiyat hissəsi əlavə edir və əməliyyatı jurnala yazır.
        /// </summary>
        /// <param name="hisse">Əlavə ediləcək ehtiyat hissəsi obyekti.</param>
        /// <param name="emeliyyatiEden">Əməliyyatı icra edən istifadəçi.</param>
        /// <param name="message">Nəticə mesajı.</param>
        /// <returns>Əməliyyatın uğurlu olub-olmadığı.</returns>
        public bool Add(TemirHissesi hisse, Istifadeci emeliyyatiEden, out string message)
        {
            if (hisse.TemirId <= 0)
            {
                message = "Keçərli təmir sifarişi seçilməyib.";
                return false;
            }

            if (hisse.MehsulId <= 0)
            {
                message = "Keçərli məhsul seçilməyib.";
                return false;
            }

            if (hisse.Miqdar <= 0)
            {
                message = "Miqdar sıfırdan böyük olmalıdır.";
                return false;
            }

            // TODO: Anbar qalığını yoxlamaq üçün əlavə məntiq yazıla bilər

            if (_dal.Add(hisse))
            {
                message = "Ehtiyat hissəsi uğurla əlavə edildi.";
                AuditLogger.Log(emeliyyatiEden.Id, "Təmirə Hissə Əlavə Etdi",
                    $"Təmir ID: {hisse.TemirId}, Məhsul ID: {hisse.MehsulId}, " +
                    $"Miqdar: {hisse.Miqdar}, Qiymət: {hisse.QiymetBirEdede}");
                return true;
            }

            message = "Ehtiyat hissəsi əlavə edilərkən xəta baş verdi.";
            return false;
        }

        /// <summary>
        /// Təmirdən ehtiyat hissəsini silir və əməliyyatı jurnala yazır.
        /// </summary>
        /// <param name="hisseId">Silinəcək ehtiyat hissəsinin ID-si.</param>
        /// <param name="emeliyyatiEden">Əməliyyatı icra edən istifadəçi.</param>
        /// <param name="message">Nəticə mesajı.</param>
        /// <returns>Əməliyyatın uğurlu olub-olmadığı.</returns>
        public bool Remove(int hisseId, Istifadeci emeliyyatiEden, out string message)
        {
            if (hisseId <= 0)
            {
                message = "Keçərli hissə seçilməyib.";
                return false;
            }

            // Əvvəlcə hissə məlumatlarını alırıq ki, jurnalda istifadə edək
            var hisse = _dal.GetById(hisseId);
            if (hisse == null)
            {
                message = "Hissə tapılmadı.";
                return false;
            }

            if (_dal.Remove(hisseId))
            {
                message = "Ehtiyat hissəsi uğurla silindi.";
                AuditLogger.Log(emeliyyatiEden.Id, "Təmirdən Hissə Silindi",
                    $"Təmir ID: {hisse.TemirId}, Məhsul ID: {hisse.MehsulId}, " +
                    $"Silinən hissə ID: {hisseId}");
                return true;
            }

            message = "Ehtiyat hissəsi silinərkən xəta baş verdi.";
            return false;
        }
    }
}