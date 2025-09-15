// Fayl: AzAgroPOS.Mentiq/Idareciler/BarkodCapiManager.cs
namespace AzAgroPOS.Mentiq.Idareciler;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Mentiq.Yardimcilar;
using AzAgroPOS.Verilenler.Interfeysler;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Barkod çapı ilə bağlı axtarış və məlumat hazırlama əməliyyatlarını idarə edir.
/// </summary>
public class BarkodCapiManager
{
    private readonly IUnitOfWork _unitOfWork;

    public BarkodCapiManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Verilmiş axtarış mətninə görə məhsulları tapır.
    /// </summary>
    /// <param name="axtarisMetni">Məhsul adı, stok kodu və ya barkoda görə axtarış.</param>
    /// <returns>Tapılmış məhsulların siyahısı.</returns>
    public async Task<EmeliyyatNeticesi<List<MehsulDto>>> MehsullariAxtarAsync(string axtarisMetni)
    {
        Logger.MelumatYaz($"Məhsullar axtarılır: {axtarisMetni}");
        try
        {
            if (string.IsNullOrWhiteSpace(axtarisMetni))
            {
                return EmeliyyatNeticesi<List<MehsulDto>>.Ugursuz("Axtarış üçün mətn daxil edin.");
            }

            var axtarisKicikHerfle = axtarisMetni.ToLower();

            var mehsullar = await _unitOfWork.Mehsullar.AxtarAsync(m =>
                m.Ad.ToLower().Contains(axtarisKicikHerfle) ||
                m.StokKodu.ToLower().Contains(axtarisKicikHerfle) ||
                m.Barkod.Contains(axtarisKicikHerfle)
            );

            if (!mehsullar.Any())
            {
                return EmeliyyatNeticesi<List<MehsulDto>>.Ugursuz("Axtarışa uyğun məhsul tapılmadı.");
            }

            var dtolar = mehsullar.Select(m => new MehsulDto
            {
                Id = m.Id,
                Ad = m.Ad,
                StokKodu = m.StokKodu,
                Barkod = m.Barkod,
                PerakendeSatisQiymeti = m.PerakendeSatisQiymeti,
                // Xətaların qarşısını almaq üçün bütün DTO sahələrini doldururuq
                TopdanSatisQiymeti = m.TopdanSatisQiymeti,
                TekEdedSatisQiymeti = m.TekEdedSatisQiymeti,
                AlisQiymeti = m.AlisQiymeti,
                MovcudSay = m.MovcudSay,
                OlcuVahidi = m.OlcuVahidi
            }).ToList();

            return EmeliyyatNeticesi<List<MehsulDto>>.Ugurlu(dtolar);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Məhsullar axtarılarkən xəta baş verdi: ");
            return EmeliyyatNeticesi<List<MehsulDto>>.Ugursuz($"Məhsullar axtarılarkən xəta baş verdi: {ex.Message} + {ex.StackTrace}");
        }

    }
}