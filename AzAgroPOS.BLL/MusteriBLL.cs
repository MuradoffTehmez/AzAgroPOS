using AzAgroPOS.BLL.Helpers;
using AzAgroPOS.DAL;
using AzAgroPOS.Entities;
using System.Collections.Generic;

namespace AzAgroPOS.BLL
{
    /// <summary>
    /// Müştərilərlə bağlı biznes məntiqini həyata keçirən sinif.
    /// </summary>
    public class MusteriBLL
    {
        private readonly MusteriDAL _dal = new MusteriDAL();

        /// <summary>
        /// Bütün aktiv müştərilərin siyahısını qaytarır.
        /// </summary>
        /// <returns>Müştərilər siyahısı.</returns>
        public List<Musteri> GetAll() => _dal.GetAll();

        /// <summary>
        /// Ad və ya telefon nömrəsinə görə müştəri axtarışı edir.
        /// </summary>
        /// <param name="searchTerm">Axtarış termini.</param>
        /// <returns>Uyğun gələn müştərilər siyahısı.</returns>
        public List<Musteri> SearchByNameOrPhone(string searchTerm) => _dal.SearchByNameOrPhone(searchTerm);

        /// <summary>
        /// Yeni müştəri yaradır və əməliyyatı jurnala yazır.
        /// </summary>
        /// <param name="musteri">Əlavə ediləcək müştəri obyekti.</param>
        /// <param name="emeliyyatiEden">Əməliyyatı icra edən istifadəçi.</param>
        /// <param name="message">Nəticə mesajı.</param>
        /// <returns>Əməliyyatın uğurlu olub-olmadığı.</returns>
        public bool Add(Musteri musteri, Istifadeci emeliyyatiEden, out string message)
        {
            if (string.IsNullOrWhiteSpace(musteri.Ad) || string.IsNullOrWhiteSpace(musteri.Soyad) || string.IsNullOrWhiteSpace(musteri.Telefon))
            {
                message = "Ad, Soyad və Telefon xanaları boş ola bilməz.";
                return false;
            }

            int newId = _dal.Add(musteri);
            if (newId > 0)
            {
                message = "Müştəri uğurla əlavə edildi.";
                AuditLogger.Log(emeliyyatiEden.Id, "Müştəri Əlavə Etdi",
                    $"Yeni müştəri: {musteri.Ad} {musteri.Soyad} (ID: {newId}, Tel: {musteri.Telefon})");
                return true;
            }

            message = "Müştəri əlavə edilərkən xəta baş verdi.";
            return false;
        }

        /// <summary>
        /// Mövcud müştərinin məlumatlarını yeniləyir və əməliyyatı jurnala yazır.
        /// </summary>
        /// <param name="musteri">Yenilənəcək müştəri obyekti.</param>
        /// <param name="emeliyyatiEden">Əməliyyatı icra edən istifadəçi.</param>
        /// <param name="message">Nəticə mesajı.</param>
        /// <returns>Əməliyyatın uğurlu olub-olmadığı.</returns>
        public bool Update(Musteri musteri, Istifadeci emeliyyatiEden, out string message)
        {
            if (string.IsNullOrWhiteSpace(musteri.Ad) || string.IsNullOrWhiteSpace(musteri.Soyad) || string.IsNullOrWhiteSpace(musteri.Telefon))
            {
                message = "Ad, Soyad və Telefon xanaları boş ola bilməz.";
                return false;
            }

            bool result = _dal.Update(musteri);
            if (result)
            {
                message = "Müştəri məlumatları uğurla yeniləndi.";
                AuditLogger.Log(emeliyyatiEden.Id, "Müştəri Yenilədi",
                    $"Müştəri: {musteri.Ad} {musteri.Soyad} (ID: {musteri.Id}). " +
                    $"Yeni telefon: {musteri.Telefon}");
                return true;
            }

            message = "Məlumatlar yenilənərkən xəta baş verdi.";
            return false;
        }

        /// <summary>
        /// Müştərini sistemdən silir (deaktiv edir) və əməliyyatı jurnala yazır.
        /// </summary>
        /// <param name="musteriId">Silinəcək müştərinin ID-si.</param>
        /// <param name="emeliyyatiEden">Əməliyyatı icra edən istifadəçi.</param>
        /// <param name="message">Nəticə mesajı.</param>
        /// <returns>Əməliyyatın uğurlu olub-olmadığı.</returns>
        public bool Delete(int musteriId, Istifadeci emeliyyatiEden, out string message)
        {
            // Əvvəlcə müştəri məlumatlarını alırıq ki, jurnalda istifadə edək
            var musteri = _dal.GetById(musteriId);
            string musteriAdi = musteri != null ? $"{musteri.Ad} {musteri.Soyad}" : "Naməlum";

            bool result = _dal.Delete(musteriId);
            if (result)
            {
                message = "Müştəri uğurla silindi.";
                AuditLogger.Log(emeliyyatiEden.Id, "Müştəri Silindi",
                    $"Müştəri: {musteriAdi} (ID: {musteriId})");
                return true;
            }

            message = "Müştəri silinərkən xəta baş verdi.";
            return false;
        }

    }
}