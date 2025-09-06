// Fayl: AzAgroPOS.Mentiq/Idareciler/SatisManager.cs
namespace AzAgroPOS.Mentiq.Idareciler;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Mentiq.Yardimcilar;
// Removed direct reference to Teqdimat namespace
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using System;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Satışlarla bağlı əməliyyatları idarə edən menecer.
/// </summary>
public class SatisManager
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly NisyeManager _nisyeManager; 

    public SatisManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _nisyeManager = new NisyeManager(unitOfWork); 
    }

    /// <summary>
    /// Yeni bir satış yaradır, stokları azaldır və nisyədirsə borcu qeydə alır.
    /// </summary>
    public async Task<EmeliyyatNeticesi<Satis>> SatisYaratAsync(SatisYaratDto satisDto)
    {
        if (satisDto.SebetElementleri == null || !satisDto.SebetElementleri.Any())
            return EmeliyyatNeticesi<Satis>.Ugursuz("Satış üçün səbət boşdur.");

        if (satisDto.OdenisMetodu == OdenisMetodu.Nisyə && !satisDto.MusteriId.HasValue)
            return EmeliyyatNeticesi<Satis>.Ugursuz("Nisyə satış üçün müştəri seçilməlidir.");

        // Stok yoxlaması
        foreach (var element in satisDto.SebetElementleri)
        {
            var mehsul = await _unitOfWork.Mehsullar.GetirAsync(element.MehsulId);
            if (mehsul == null || mehsul.MovcudSay < element.Miqdar)
                return EmeliyyatNeticesi<Satis>.Ugursuz($"'{element.MehsulAdi}' üçün stokda kifayət qədər məhsul yoxdur.");
        }

        var satis = new Satis
        {
            Tarix = System.DateTime.Now,
            OdenisMetodu = satisDto.OdenisMetodu,
            UmumiMebleg = satisDto.SebetElementleri.Sum(e => e.UmumiMebleg),
            NovbeId = satisDto.NovbeId,
            MusteriId = satisDto.MusteriId
        };

        // Satış detallarını və stokları yenilə
        foreach (var element in satisDto.SebetElementleri)
        {
            satis.SatisDetallari.Add(new SatisDetali { MehsulId = element.MehsulId, Miqdar = element.Miqdar, Qiymet = element.VahidinQiymeti, UmumiMebleg = element.Miqdar * element.VahidinQiymeti });
            var mehsul = await _unitOfWork.Mehsullar.GetirAsync(element.MehsulId);
            if (mehsul != null)
            {
                mehsul.MovcudSay -= (int)element.Miqdar;
                _unitOfWork.Mehsullar.Yenile(mehsul);
            }
        }

        await _unitOfWork.Satislar.ElaveEtAsync(satis);
        // Vacib: Dəyişiklikləri yaddaşa veririk ki, satış ID alsın
        await _unitOfWork.EmeliyyatiTesdiqleAsync();

        // Əgər nisyədirsə, borcu qeydə al
        if (satis.OdenisMetodu == OdenisMetodu.Nisyə)
        {
            var nisyeNetice = await _nisyeManager.NisyeyeSatisElaveEtAsync(satis);
            if (!nisyeNetice.UgurluDur)
            {
                // Bu hal baş verərsə, tranzaksiyanı ləğv etmək üçün mürəkkəb mexanizm lazımdır.
                // Hələlik sadə xəta qaytarırıq.
                return EmeliyyatNeticesi<Satis>.Ugursuz($"Nisyə qeydiyatı zamanı xəta: {nisyeNetice.Mesaj}");
            }
        }

        return EmeliyyatNeticesi<Satis>.Ugurlu(satis);
    }

    /// <summary>
    /// Satış nömrəsinə görə satış məlumatlarını qaytarır.
    /// </summary>
    public async Task<EmeliyyatNeticesi<SatisQebzDto>> SatisGetirAsync(string satisNomresi)
    {
        // Satış nömrəsi formatı kontrolü
        if (!int.TryParse(satisNomresi, out int satisId))
            return EmeliyyatNeticesi<SatisQebzDto>.Ugursuz("Yanlış satış nömrəsi formatı.");

        var satis = await _unitOfWork.Satislar.GetirAsync(satisId);
        if (satis == null)
            return EmeliyyatNeticesi<SatisQebzDto>.Ugursuz("Satış tapılmadı.");

        // Satış detallarını və məhsul məlumatlarını yükləyin
        var sebetElementleri = new List<SatisSebetiElementiDto>();
        foreach (var detali in satis.SatisDetallari)
        {
            var mehsul = await _unitOfWork.Mehsullar.GetirAsync(detali.MehsulId);
            if (mehsul != null)
            {
                sebetElementleri.Add(new SatisSebetiElementiDto
                {
                    MehsulId = detali.MehsulId,
                    MehsulAdi = mehsul.Ad,
                    Miqdar = detali.Miqdar,
                    VahidinQiymeti = detali.Qiymet
                });
            }
        }

        var satisDto = new SatisQebzDto
        {
            SatisId = satis.Id,
            Tarix = satis.Tarix,
            SatilanMehsullar = sebetElementleri
        };

        return EmeliyyatNeticesi<SatisQebzDto>.Ugurlu(satisDto);
    }

    /// <summary>
    /// Qaytarma əməliyyatını həyata keçirir.
    /// </summary>
    public async Task<EmeliyyatNeticesi<bool>> QaytarmaEmeliyyatiAsync(List<SatisSebetiElementiDto> qaytarilanMehsullar, int satisId, string sebeb, int kassirId, int? aktivNovbeId)
    {
        // Əsas satışı tap
        var satis = await _unitOfWork.Satislar.GetirAsync(satisId);
        if (satis == null)
            return EmeliyyatNeticesi<bool>.Ugursuz("Satış tapılmadı.");

        // Qaytarma obyektini yarat
        var qaytarma = new Qaytarma
        {
            Tarix = DateTime.Now,
            SatisId = satisId,
            Sebeb = sebeb,
            KassirId = kassirId,
            UmumiMebleg = qaytarilanMehsullar.Sum(e => e.UmumiMebleg)
        };

        // Qaytarma detallarını və stokları yenilə
        foreach (var element in qaytarilanMehsullar)
        {
            // Qaytarma detallarını əlavə et
            qaytarma.QaytarmaDetallari.Add(new QaytarmaDetali
            {
                MehsulId = element.MehsulId,
                Miqdar = element.Miqdar,
                Qiymet = element.VahidinQiymeti,
                UmumiMebleg = element.UmumiMebleg
            });

            // Stokları artır
            var mehsul = await _unitOfWork.Mehsullar.GetirAsync(element.MehsulId);
            if (mehsul != null)
            {
                mehsul.MovcudSay += (int)element.Miqdar;
                _unitOfWork.Mehsullar.Yenile(mehsul);
            }
        }

        // Müştərinin borcunu azalt (əgər satış nisyə idisə)
        if (satis.OdenisMetodu == OdenisMetodu.Nisyə && satis.MusteriId.HasValue)
        {
            var musteri = await _unitOfWork.Musteriler.GetirAsync(satis.MusteriId.Value);
            if (musteri != null)
            {
                musteri.UmumiBorc -= qaytarma.UmumiMebleg;
                _unitOfWork.Musteriler.Yenile(musteri);

                // Nisyə hərəkəti yarat
                var nisyeHereketi = new NisyeHereketi
                {
                    MusteriId = satis.MusteriId.Value,
                    Mebleg = qaytarma.UmumiMebleg,
                    Tarix = DateTime.Now,
                    EmeliyyatNovu = EmeliyyatNovu.Qaytarma,
                    SatisId = 0 // Qaytarma ID-si əlavə edildikdən sonra təyin ediləcək
                };
                await _unitOfWork.NisyeHereketleri.ElaveEtAsync(nisyeHereketi);
            }
        }

        // Qaytarma qeydini əlavə et
        await _unitOfWork.Qaytarmalar.ElaveEtAsync(qaytarma);
        
        // Kassirin aktiv növbəsindəki nağd və ya kart məbləğini azalt
        if (aktivNovbeId.HasValue)
        {
            var novbe = await _unitOfWork.Novbeler.GetirAsync(aktivNovbeId.Value);
            if (novbe != null)
            {
                if (satis.OdenisMetodu == OdenisMetodu.Nağd)
                {
                    novbe.FaktikiMebleg -= qaytarma.UmumiMebleg;
                }
                else if (satis.OdenisMetodu == OdenisMetodu.Kart)
                {
                    // Kart ödənişləri üçün lazımi dəyişikliklər
                    // Bu implementasiya şirkətin daxili qaydalarına görə dəyişə bilər
                }
                _unitOfWork.Novbeler.Yenile(novbe);
            }
        }

        // Bütün əməliyyatları təsdiqlə
        await _unitOfWork.EmeliyyatiTesdiqleAsync();

        return EmeliyyatNeticesi<bool>.Ugurlu(true);
    }
}