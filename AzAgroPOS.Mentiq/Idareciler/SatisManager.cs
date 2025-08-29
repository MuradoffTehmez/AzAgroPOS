// Fayl: AzAgroPOS.Mentiq/Idareciler/SatisManager.cs
namespace AzAgroPOS.Mentiq.Idareciler;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
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
            satis.SatisDetallari.Add(new SatisDetali { MehsulId = element.MehsulId, Miqdar = element.Miqdar, Qiymet = element.VahidinQiymeti });
            var mehsul = await _unitOfWork.Mehsullar.GetirAsync(element.MehsulId);
            if (mehsul != null)
            {
                mehsul.MovcudSay -= element.Miqdar;
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

        // Bütün əməliyyatları təsdiqlə
        await _unitOfWork.EmeliyyatiTesdiqleAsync();

        return EmeliyyatNeticesi<Satis>.Ugurlu(satis);
    }
}