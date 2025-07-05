using AzAgroPOS.BLL.Helpers;
using AzAgroPOS.DAL;
using AzAgroPOS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AzAgroPOS.BLL
{
    /// <summary>
    /// Satış əməliyyatları ilə bağlı biznes məntiqini həyata keçirən sinif.
    /// </summary>
    public class SatisBLL
    {
        private readonly SatisDAL _dal = new SatisDAL();

        /// <summary>
        /// Yeni satış əməliyyatını sistemə əlavə edir və əməliyyatı jurnala yazır.
        /// </summary>
        /// <param name="satis">Əlavə ediləcək satış obyekti.</param>
        /// <param name="emeliyyatiEden">Əməliyyatı icra edən istifadəçi.</param>
        /// <param name="message">Nəticə mesajı.</param>
        /// <returns>Əməliyyatın uğurlu olub-olmadığı.</returns>
        public bool Add(Satis satis, Istifadeci emeliyyatiEden, out string message)
        {
            if (satis.SatisMehsullari == null || satis.SatisMehsullari.Count == 0)
            {
                message = "Satış üçün səbət boşdur.";
                return false;
            }

            if (satis.MusteriId <= 0)
            {
                message = "Müştəri seçilməyib.";
                return false;
            }

            // Ümumi məbləğin hesablanması
            satis.YekunMebleg = satis.SatisMehsullari.Sum(m => m.YekunMebleg);
            satis.SatisTarixi = DateTime.Now;

            int yeniId = _dal.Add(satis);
            if (yeniId > 0)
            {
                message = $"Satış uğurla tamamlandı. Qəbz Nömrəsi: {yeniId}";

                // Jurnal qeydi üçün detallar
                string satisDetallari = $"Müştəri ID: {satis.MusteriId}, Ümumi məbləğ: {satis.YekunMebleg} AZN, " +
                    $"Məhsul sayı: {satis.SatisMehsullari.Count}";

                AuditLogger.Log(emeliyyatiEden.Id, "Yeni Satış",
                    $"Qəbz №{yeniId}. {satisDetallari}");

                return true;
            }

            message = "Satış zamanı xəta baş verdi.";
            return false;
        }

        /// <summary>
        /// Müəyyən tarix aralığındakı satışları qaytarır.
        /// </summary>
        /// <param name="startDate">Başlanğıc tarix.</param>
        /// <param name="endDate">Bitmə tarixi.</param>
        /// <returns>Satışlar siyahısı.</returns>
        public List<Satis> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            return _dal.GetByDateRange(startDate, endDate);
        }

        /// <summary>
        /// Müəyyən satışın detallarını qaytarır.
        /// </summary>
        /// <param name="satisId">Satış ID-si.</param>
        /// <returns>Satış detalları.</returns>
        public Satis GetById(int satisId)
        {
            if (satisId <= 0) return null;
            return _dal.GetById(satisId);
        }

        /// <summary>
        /// Satışı ləğv edir və əməliyyatı jurnala yazır.
        /// </summary>
        /// <param name="satisId">Ləğv ediləcək satış ID-si.</param>
        /// <param name="emeliyyatiEden">Əməliyyatı icra edən istifadəçi.</param>
        /// <param name="message">Nəticə mesajı.</param>
        /// <returns>Əməliyyatın uğurlu olub-olmadığı.</returns>
        public bool Cancel(int satisId, Istifadeci emeliyyatiEden, out string message)
        {
            if (satisId <= 0)
            {
                message = "Ləğv etmək üçün satış seçilməyib.";
                return false;
            }

            var satis = _dal.GetById(satisId);
            if (satis == null)
            {
                message = "Satış tapılmadı.";
                return false;
            }

            if (_dal.Cancel(satisId))
            {
                message = $"Satış uğurla ləğv edildi. Qəbz Nömrəsi: {satisId}";

                AuditLogger.Log(emeliyyatiEden.Id, "Satış Ləğv Edildi",
                    $"Qəbz №{satisId}, Müştəri ID: {satis.MusteriId}, " +
                    $"Ləğv edilən məbləğ: {satis.YekunMebleg} AZN");

                return true;
            }

            message = "Satış ləğv edilərkən xəta baş verdi.";
            return false;
        }
    }
}