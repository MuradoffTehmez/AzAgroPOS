using System;
using System.Collections.Generic;
using System.Linq;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.DAL.Repositories;

namespace AzAgroPOS.BLL.Services
{
    public class SatisService
    {
        private readonly SatisRepository _satisRepository;
        private readonly SatisDetaliRepository _satisDetaliRepository;
        private readonly SatisOdemesiRepository _satisOdemesiRepository;
        private readonly MehsulRepository _mehsulRepository;

        public SatisService()
        {
            _satisRepository = new SatisRepository();
            _satisDetaliRepository = new SatisDetaliRepository();
            _satisOdemesiRepository = new SatisOdemesiRepository();
            _mehsulRepository = new MehsulRepository();
        }

        public int CreateSatis(Satis satis)
        {
            try
            {
                // Validate sales data
                if (satis.SatisDetallari == null || !satis.SatisDetallari.Any())
                    throw new ArgumentException("Satış detayları boş olamaz");

                // Check stock availability for all products
                foreach (var detay in satis.SatisDetallari)
                {
                    var mehsul = _mehsulRepository.GetById(detay.MehsulId);
                    if (mehsul == null)
                        throw new ArgumentException($"Məhsul tapılmadı: {detay.MehsulId}");

                    if (mehsul.MovcudMiqdar < detay.Miqdar)
                        throw new InvalidOperationException($"Kifayət qədər stok yoxdur: {mehsul.Ad}. Mövcud: {mehsul.MovcudMiqdar}");
                }

                // Create sales record
                int satisId = _satisRepository.Add(satis);

                // Create sales details
                foreach (var detay in satis.SatisDetallari)
                {
                    detay.SatisId = satisId;
                    _satisDetaliRepository.Add(detay);

                    // Update product stock
                    var mehsul = _mehsulRepository.GetById(detay.MehsulId);
                    mehsul.MovcudMiqdar -= detay.Miqdar;
                    mehsul.YenilenmeTarixi = DateTime.Now;
                    _mehsulRepository.Update(mehsul);
                }

                // Create payment record
                var odemesi = new SatisOdemesi
                {
                    SatisId = satisId,
                    OdemeMeblegi = satis.NetMebleg,
                    OdemeNovu = satis.OdemeNovu,
                    OdemeDetali = satis.OdemeDetali,
                    OdemeTarixi = DateTime.Now,
                    Status = "Tamamlandı"
                };
                _satisOdemesiRepository.Add(odemesi);

                return satisId;
            }
            catch (Exception)
            {
                // Rollback logic should be implemented here in a real scenario
                throw;
            }
        }

        public List<Satis> GetSatisByDate(DateTime startDate, DateTime endDate)
        {
            return _satisRepository.GetByDateRange(startDate, endDate);
        }

        public List<Satis> GetSatisByKassir(int kassirId, DateTime? startDate = null, DateTime? endDate = null)
        {
            return _satisRepository.GetByKassir(kassirId, startDate, endDate);
        }

        public Satis GetSatisById(int id)
        {
            return _satisRepository.GetByIdWithDetails(id);
        }

        public List<SatisDetali> GetSatisDetallari(int satisId)
        {
            return _satisDetaliRepository.GetBySatisId(satisId);
        }

        public List<SatisOdemesi> GetSatisOdemeleri(int satisId)
        {
            return _satisOdemesiRepository.GetBySatisId(satisId);
        }

        public bool CancelSatis(int satisId, string reason)
        {
            try
            {
                var satis = _satisRepository.GetByIdWithDetails(satisId);
                if (satis == null)
                    throw new ArgumentException("Satış tapılmadı");

                if (satis.Status == "İptal Edilmiş")
                    throw new InvalidOperationException("Satış artıq iptal edilmişdir");

                // Restore product stock
                var detaylar = _satisDetaliRepository.GetBySatisId(satisId);
                foreach (var detay in detaylar)
                {
                    var mehsul = _mehsulRepository.GetById(detay.MehsulId);
                    if (mehsul != null)
                    {
                        mehsul.MovcudMiqdar += detay.Miqdar;
                        mehsul.YenilenmeTarixi = DateTime.Now;
                        _mehsulRepository.Update(mehsul);
                    }
                }

                // Update sales status
                satis.Status = "İptal Edilmiş";
                satis.Qeydler = $"İptal səbəbi: {reason}. İptal tarixi: {DateTime.Now:dd.MM.yyyy HH:mm}";
                satis.YenilenmeTarixi = DateTime.Now;
                _satisRepository.Update(satis);

                // Update payment status
                var odemeler = _satisOdemesiRepository.GetBySatisId(satisId);
                foreach (var odeme in odemeler)
                {
                    odeme.Status = "İptal Edilmiş";
                    odeme.Qeydler = reason;
                    odeme.YenilenmeTarixi = DateTime.Now;
                    _satisOdemesiRepository.Update(odeme);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public SatisReportData GetSatisRaporu(DateTime startDate, DateTime endDate, int? kassirId = null)
        {
            var satislar = kassirId.HasValue 
                ? GetSatisByKassir(kassirId.Value, startDate, endDate)
                : GetSatisByDate(startDate, endDate);

            var activeSatislar = satislar.Where(s => s.Status != "İptal Edilmiş").ToList();

            return new SatisReportData
            {
                BaslangicTarixi = startDate,
                BitisTarixi = endDate,
                UmumiSatisSayi = activeSatislar.Count,
                UmumiSatisMeblegi = activeSatislar.Sum(s => s.NetMebleg),
                UmumiEndirimMeblegi = activeSatislar.Sum(s => s.EndirimMeblegi),
                UmumiVergiMeblegi = activeSatislar.Sum(s => s.VergiMeblegi),
                NagdSatisSayi = activeSatislar.Count(s => s.OdemeNovu == "Nağd"),
                NagdSatisMeblegi = activeSatislar.Where(s => s.OdemeNovu == "Nağd").Sum(s => s.NetMebleg),
                KartSatisSayi = activeSatislar.Count(s => s.OdemeNovu == "Kart"),
                KartSatisMeblegi = activeSatislar.Where(s => s.OdemeNovu == "Kart").Sum(s => s.NetMebleg),
                NisyeSatisSayi = activeSatislar.Count(s => s.OdemeNovu == "Nisyə"),
                NisyeSatisMeblegi = activeSatislar.Where(s => s.OdemeNovu == "Nisyə").Sum(s => s.NetMebleg),
                IptalEdilenSatisSayi = satislar.Count(s => s.Status == "İptal Edilmiş"),
                Satislar = activeSatislar
            };
        }

        public List<Mehsul> GetEnCoxSatılanMehsullar(DateTime startDate, DateTime endDate, int topCount = 10)
        {
            var satisDetallari = _satisDetaliRepository.GetByDateRange(startDate, endDate);
            
            var mehsulSatislari = satisDetallari
                .GroupBy(d => d.MehsulId)
                .Select(g => new
                {
                    MehsulId = g.Key,
                    ToplamMiqdar = g.Sum(d => d.Miqdar),
                    ToplamMebleg = g.Sum(d => d.UmumiQiymet)
                })
                .OrderByDescending(x => x.ToplamMiqdar)
                .Take(topCount)
                .ToList();

            var mehsullar = new List<Mehsul>();
            foreach (var item in mehsulSatislari)
            {
                var mehsul = _mehsulRepository.GetById(item.MehsulId);
                if (mehsul != null)
                {
                    mehsullar.Add(mehsul);
                }
            }

            return mehsullar;
        }
    }

    public class SatisReportData
    {
        public DateTime BaslangicTarixi { get; set; }
        public DateTime BitisTarixi { get; set; }
        public int UmumiSatisSayi { get; set; }
        public decimal UmumiSatisMeblegi { get; set; }
        public decimal UmumiEndirimMeblegi { get; set; }
        public decimal UmumiVergiMeblegi { get; set; }
        public int NagdSatisSayi { get; set; }
        public decimal NagdSatisMeblegi { get; set; }
        public int KartSatisSayi { get; set; }
        public decimal KartSatisMeblegi { get; set; }
        public int NisyeSatisSayi { get; set; }
        public decimal NisyeSatisMeblegi { get; set; }
        public int IptalEdilenSatisSayi { get; set; }
        public List<Satis> Satislar { get; set; }
    }
}