// Fayl: AzAgroPOS.Mentiq/Idareciler/HesabatManager.cs
namespace AzAgroPOS.Mentiq.Idareciler;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Hesabatların hazırlanması ilə bağlı biznes məntiqini idarə edir.
/// </summary>
public class HesabatManager
{
    private readonly IUnitOfWork _unitOfWork;

    public HesabatManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Verilmiş tarix üçün günlük satış hesabatını hazırlayır.
    /// </summary>
    /// <param name="tarix">Hesabatın hazırlanacağı gün.</param>
    public async Task<EmeliyyatNeticesi<GunlukSatisHesabatDto>> GunlukSatisHesabatiGetirAsync(DateTime tarix)
    {
        try
        {
            var gununBasi = tarix.Date;
            var gununSonu = gununBasi.AddDays(1).AddTicks(-1);

            // Verilənlər bazasından həmin günə aid satışları müştəri məlumatları ilə birlikdə çəkirik.
            var satislar = await _unitOfWork.Satislar
                .AxtarAsync(s => s.Tarix >= gununBasi && s.Tarix <= gununSonu);

            // Müştəri məlumatlarını əlavə etmək üçün ayrıca sorğu
            var musteriIds = satislar.Where(s => s.MusteriId.HasValue).Select(s => s.MusteriId.Value).Distinct().ToList();
            var musteriler = (await _unitOfWork.Musteriler.AxtarAsync(m => musteriIds.Contains(m.Id)))
                             .ToDictionary(m => m.Id, m => m.TamAd);


            if (!satislar.Any())
            {
                return EmeliyyatNeticesi<GunlukSatisHesabatDto>.Ugursuz("Seçilmiş tarix üçün heç bir satış tapılmadı.");
            }

            var hesabat = new GunlukSatisHesabatDto
            {
                HesabatTarixi = gununBasi,
                UmumiDovriyye = satislar.Sum(s => s.UmumiMebleg),
                CemiSatisSayi = satislar.Count(),
                NagdSatisCemi = satislar.Where(s => s.OdenisMetodu == OdenisMetodu.Nağd).Sum(s => s.UmumiMebleg),
                KartSatisCemi = satislar.Where(s => s.OdenisMetodu == OdenisMetodu.Kart).Sum(s => s.UmumiMebleg),
                NisyeSatisCemi = satislar.Where(s => s.OdenisMetodu == OdenisMetodu.Nisyə).Sum(s => s.UmumiMebleg),
                SatislarinSiyahisi = satislar.Select(s => new GunlukSatisDetayDto
                {
                    SatisId = s.Id,
                    Tarix = s.Tarix,
                    UmumiMebleg = s.UmumiMebleg,
                    OdenisMetodu = s.OdenisMetodu.ToString(),
                    MusteriAdi = s.MusteriId.HasValue && musteriler.ContainsKey(s.MusteriId.Value)
                                 ? musteriler[s.MusteriId.Value]
                                 : "N/A"
                }).OrderBy(s => s.Tarix).ToList()
            };

            return EmeliyyatNeticesi<GunlukSatisHesabatDto>.Ugurlu(hesabat);
        }
        catch (Exception ex)
        {
            
            return EmeliyyatNeticesi<GunlukSatisHesabatDto>.Ugursuz($"Hesabat hazırlanarkən xəta baş verdi: {ex.Message}");
        }
    }
}