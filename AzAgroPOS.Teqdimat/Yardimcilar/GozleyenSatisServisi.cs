// Fayl: AzAgroPOS.Teqdimat/Yardimcilar/GozleyenSatisServisi.cs
using AzAgroPOS.Mentiq.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace AzAgroPOS.Teqdimat.Yardimcilar
{
    /*
    public class GozleyenSatis
    {
        public int Id { get; set; }
        public List<SatisSebetiElementiDto> Sebet { get; set; }
        public int MusteriId { get; set; }
        public string MusteriAdi { get; set; }
    }

    public static class GozleyenSatisServisi
    {
        private static List<GozleyenSatis> _gozleyenSatislar = new List<GozleyenSatis>();
        private static int _nextId = 1;

        public static void SatisSaxla(List<SatisSebetiElementiDto> sebet, int musteriId, string musteriAdi)
        {
            var sebetKopyasi = sebet.Select(s => s.Clone()).ToList();
            _gozleyenSatislar.Add(new GozleyenSatis
            {
                Id = _nextId++,
                Sebet = sebetKopyasi,
                MusteriId = musteriId,
                MusteriAdi = musteriAdi
            });
        }

        public static List<GozleyenSatis> GozleyenleriGetir()
        {
            return _gozleyenSatislar;
        }

        public static GozleyenSatis SatisiYukle(int id)
        {
            var satis = _gozleyenSatislar.FirstOrDefault(s => s.Id == id);
            if (satis != null)
            {
                _gozleyenSatislar.Remove(satis);
            }
            return satis;
        }
    
    }
    */
}