using AzAgroPOS.BLL.Helpers;
using AzAgroPOS.DAL;
using AzAgroPOS.Entities;
using System.Collections.Generic;

namespace AzAgroPOS.BLL
{
    /// <summary>
    /// Satışa aid məhsullarla bağlı biznes məntiqini həyata keçirən sinif.
    /// </summary>
    public class SatisMehsullariBLL
    {
        private readonly SatisMehsullariDAL _dal = new SatisMehsullariDAL();
        private readonly MehsulBLL _mehsulBLL = new MehsulBLL();

        /// <summary>
        /// Müəyyən satışa aid olan bütün məhsulları qaytarır.
        /// </summary>
        /// <param name="satisId">Satış ID-si.</param>
        /// <returns>Satış məhsulları siyahısı.</returns>
        public List<SatisMehsulu> GetBySatisId(int satisId) => _dal.GetBySatisId(satisId);

        /// <summary>
        /// Satışa yeni məhsul əlavə edir və əməliyyatı jurnala yazır.
        /// </summary>
        /// <param name="satisMehsulu">Əlavə ediləcək satış məhsulu obyekti.</param>
        /// <param name="emeliyyatiEden">Əməliyyatı icra edən istifadəçi.</param>
        /// <param name="message">Nəticə mesajı.</param>
        /// <returns>Əməliyyatın uğurlu olub-olmadığı.</returns>
        public bool Add(SatisMehsulu satisMehsulu, Istifadeci emeliyyatiEden, out string message)
        {
            if (satisMehsulu.SatisId <= 0)
            {
                message = "Keçərli satış seçilməyib.";
                return false;
            }

            if (satisMehsulu.MehsulId <= 0)
            {
                message = "Keçərli məhsul seçilməyib.";
                return false;
            }

            if (satisMehsulu.Miqdar <= 0)
            {
                message = "Miqdar sıfırdan böyük olmalıdır.";
                return false;
            }

            // Məhsulun qiymətini və digər məlumatlarını gətiririk
            var mehsul = _mehsulBLL.GetById(satisMehsulu.MehsulId);
            if (mehsul == null)
            {
                message = "Məhsul tapılmadı.";
                return false;
            }

            // Qiymət və ümumi məbləğ hesablanması
            satisMehsulu.QiymetBirEdede = mehsul.SatisQiymeti;
            //satisMehsulu.YekunMebleg = satisMehsulu.Miqdar * satisMehsulu.QiymetBirEdede;

            if (_dal.Add(satisMehsulu))
            {
                message = "Məhsul satışa uğurla əlavə edildi.";
                AuditLogger.Log(emeliyyatiEden.Id, "Satışa Məhsul Əlavə Etdi",
                    $"Satış ID: {satisMehsulu.SatisId}, Məhsul ID: {satisMehsulu.MehsulId}, " +
                    $"Miqdar: {satisMehsulu.Miqdar}, Ümumi: {satisMehsulu.YekunMebleg} AZN");
                return true;
            }

            message = "Məhsul satışa əlavə edilərkən xəta baş verdi.";
            return false;
        }

        /// <summary>
        /// Satışdan məhsulu silir və əməliyyatı jurnala yazır.
        /// </summary>
        /// <param name="satisMehsulId">Silinəcək satış məhsulunun ID-si.</param>
        /// <param name="emeliyyatiEden">Əməliyyatı icra edən istifadəçi.</param>
        /// <param name="message">Nəticə mesajı.</param>
        /// <returns>Əməliyyatın uğurlu olub-olmadığı.</returns>
        public bool Remove(int satisMehsulId, Istifadeci emeliyyatiEden, out string message)
        {
            if (satisMehsulId <= 0)
            {
                message = "Silmək üçün məhsul seçilməyib.";
                return false;
            }

            // Əvvəlcə məhsul məlumatlarını alırıq ki, jurnalda istifadə edək
            var satisMehsulu = _dal.GetById(satisMehsulId);
            if (satisMehsulu == null)
            {
                message = "Satış məhsulu tapılmadı.";
                return false;
            }

            if (_dal.Remove(satisMehsulId))
            {
                message = "Məhsul satışdan uğurla silindi.";
                AuditLogger.Log(emeliyyatiEden.Id, "Satışdan Məhsul Silindi",
                    $"Satış ID: {satisMehsulu.SatisId}, Məhsul ID: {satisMehsulu.MehsulId}, " +
                    $"Silinən məbləğ: {satisMehsulu.YekunMebleg} AZN");
                return true;
            }

            message = "Məhsul satışdan silinərkən xəta baş verdi.";
            return false;
        }
    }
}