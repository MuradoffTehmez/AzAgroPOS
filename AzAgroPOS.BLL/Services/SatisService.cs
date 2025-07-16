using AzAgroPOS.BLL.Interfaces;
using AzAgroPOS.DAL;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Constants;
using AzAgroPOS.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.BLL.Services
{
    public class SatisService : IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;

        public SatisService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<int> CreateSatisAsync(Satis satis)
        {
            try
            {
                if (satis.SatisDetallari == null || !satis.SatisDetallari.Any())
                    throw new ArgumentException("Satış detalları boş ola bilməz");

                // Satış əlavə et
                int satisId = await _unitOfWork.Satislar.AddAsync(satis);

                // Anbar qalığını yenilə və satış detallarını əlavə et
                foreach (var detay in satis.SatisDetallari)
                {
                    // Məhsul məlumatını yoxla
                    var mehsul = _unitOfWork.Mehsullar.GetById(detay.MehsulId);
                    if (mehsul == null)
                        throw new ArgumentException($"Məhsul tapılmadı: {detay.MehsulId}");
                    
                    // Anbar qalığını yoxla
                    var anbarQaliq = _unitOfWork.AnbarQaliqlari
                        .GetByAnbarVeMehsul(1, detay.MehsulId); // Default anbar ID = 1
                    
                    if (anbarQaliq == null || anbarQaliq.MovcudMiqdar < detay.Miqdar)
                        throw new InvalidOperationException($"Kifayət qədər stok yoxdur: {mehsul.Ad}. Mövcud: {anbarQaliq?.MovcudMiqdar ?? 0}");

                    // Satış detalını əlavə et
                    detay.SatisId = satisId;
                    await _unitOfWork.SatisDetallari.AddAsync(detay);

                    // Anbar qalığını yenilə
                    anbarQaliq.MovcudMiqdar -= detay.Miqdar;
                    anbarQaliq.SonSatısTarixi = DateTime.Now;
                    _unitOfWork.AnbarQaliqlari.Update(anbarQaliq);
                }

                // Ödəmə məlumatını əlavə et
                var odemesi = new SatisOdemesi
                {
                    SatisId = satisId,
                    OdemeMeblegi = satis.NetMebleg,
                    OdemeNovu = satis.OdemeNovu,
                    OdemeDetali = satis.OdemeDetali,
                    OdemeTarixi = DateTime.Now,
                    Status = SystemConstants.Status.Active
                };
                await _unitOfWork.SatisOdemeleri.AddAsync(odemesi);

                // Bütün dəyişiklikləri bir dəfəyə təsdiqlə
                await _unitOfWork.CompleteAsync();
                return satisId;
            }
            catch (Exception)
            {
                // Xəta baş verdiyi üçün heç bir dəyişiklik yadda saxlanılmayacaq
                throw;
            }
        }

        public List<Satis> GetSatisByDate(DateTime startDate, DateTime endDate)
        {
            return _unitOfWork.Satislar.GetByDateRange(startDate, endDate);
        }

        public List<Satis> GetSatisByKassir(int kassirId, DateTime? startDate = null, DateTime? endDate = null)
        {
            return _unitOfWork.Satislar.GetByKassir(kassirId, startDate, endDate);
        }

        public Satis GetSatisById(int id)
        {
            return _unitOfWork.Satislar.GetByIdWithDetails(id);
        }

        public List<SatisDetali> GetSatisDetallari(int satisId)
        {
            return _unitOfWork.SatisDetallari.GetBySatisId(satisId);
        }

        public List<SatisOdemesi> GetSatisOdemeleri(int satisId)
        {
            return _unitOfWork.SatisOdemeleri.GetBySatisId(satisId);
        }

        public bool CancelSatis(int satisId, string reason)
        {
            try
            {
                var satis = _unitOfWork.Satislar.GetByIdWithDetails(satisId);
                if (satis == null)
                    throw new ArgumentException("Satış tapılmadı");

                if (satis.Status == "İptal Edilmiş")
                    throw new InvalidOperationException("Satış artıq iptal edilmişdir");

                // Anbar qalığını bərpa et
                var detaylar = _unitOfWork.SatisDetallari.GetBySatisId(satisId);
                
                foreach (var detay in detaylar)
                {
                    var anbarQaliq = _unitOfWork.AnbarQaliqlari
                        .GetByAnbarVeMehsul(1, detay.MehsulId); // Default anbar ID = 1
                    
                    if (anbarQaliq != null)
                    {
                        anbarQaliq.MovcudMiqdar += detay.Miqdar;
                        anbarQaliq.YenilenmeTarixi = DateTime.Now;
                        _unitOfWork.AnbarQaliqlari.Update(anbarQaliq);
                    }
                }

                // Satış statusunu yenilə
                satis.Status = "İptal Edilmiş";
                satis.Qeydler = $"İptal səbəbi: {reason}. İptal tarixi: {DateTime.Now:dd.MM.yyyy HH:mm}";
                satis.YenilenmeTarixi = DateTime.Now;
                _unitOfWork.Satislar.Update(satis);

                // Ödəmə statusunu yenilə
                var odemeler = _unitOfWork.SatisOdemeleri.GetBySatisId(satisId);
                foreach (var odeme in odemeler)
                {
                    odeme.Status = "İptal Edilmiş";
                    odeme.Qeydler = reason;
                    odeme.YenilenmeTarixi = DateTime.Now;
                    _unitOfWork.SatisOdemeleri.Update(odeme);
                }

                // Bütün dəyişiklikləri təsdiqlə
                _unitOfWork.Complete();
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
            var satisDetallari = _unitOfWork.SatisDetallari.GetByDateRange(startDate, endDate);

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
                var mehsul = _unitOfWork.Mehsullar.GetById(item.MehsulId);
                if (mehsul != null)
                {
                    mehsullar.Add(mehsul);
                }
            }

            return mehsullar;
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
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