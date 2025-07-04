using AzAgroPOS.DAL;
using AzAgroPOS.Entities;
using System.Collections.Generic;

namespace AzAgroPOS.BLL
{
    public class MusteriBLL
    {
        private readonly MusteriDAL _dal = new MusteriDAL();

        public List<Musteri> GetAll() => _dal.GetAll();

        public List<Musteri> SearchByNameOrPhone(string searchTerm) => _dal.SearchByNameOrPhone(searchTerm);

        public bool Add(Musteri musteri, out string message)
        {
            if (string.IsNullOrWhiteSpace(musteri.Ad) || string.IsNullOrWhiteSpace(musteri.Soyad) || string.IsNullOrWhiteSpace(musteri.Telefon))
            {
                message = "Ad, Soyad və Telefon xanaları boş ola bilməz.";
                return false;
            }
            int newId = _dal.Add(musteri);
            message = newId > 0 ? "Müştəri uğurla əlavə edildi." : "Müştəri əlavə edilərkən xəta baş verdi.";
            return newId > 0;
        }

        public bool Update(Musteri musteri, out string message)
        {
            if (string.IsNullOrWhiteSpace(musteri.Ad) || string.IsNullOrWhiteSpace(musteri.Soyad) || string.IsNullOrWhiteSpace(musteri.Telefon))
            {
                message = "Ad, Soyad və Telefon xanaları boş ola bilməz.";
                return false;
            }
            bool result = _dal.Update(musteri);
            message = result ? "Müştəri məlumatları uğurla yeniləndi." : "Məlumatlar yenilənərkən xəta baş verdi.";
            return result;
        }

        public bool Delete(int musteriId, out string message)
        {
            bool result = _dal.Delete(musteriId);
            message = result ? "Müştəri uğurla silindi." : "Müştəri silinərkən xəta baş verdi.";
            return result;
        }
    }
}