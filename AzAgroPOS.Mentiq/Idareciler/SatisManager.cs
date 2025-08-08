// Fayl: AzAgroPOS.Mentiq/Idareciler/SatisManager.cs
namespace AzAgroPOS.Mentiq.Idareciler;
// Gərəkli using-lər...
using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public class SatisManager
{
    private readonly IUnitOfWork _unitOfWork;
    public SatisManager(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

    public async Task<EmeliyyatNeticesi> SatisiTesdiqleAsync(List<SatisSebetiElementiDto> sebetElementleri, OdenisMetodu odenisMetodu, int novbeId)
    {
        if (sebetElementleri == null || !sebetElementleri.Any())
            return EmeliyyatNeticesi.Ugursuz("Satış üçün səbət boşdur.");

        foreach (var element in sebetElementleri)
        {
            var mehsul = await _unitOfWork.Mehsullar.GetirAsync(element.MehsulId);
            if (mehsul == null) return EmeliyyatNeticesi.Ugursuz($"ID: {element.MehsulId} olan məhsul tapılmadı.");
            if (mehsul.MovcudSay < element.Miqdar) return EmeliyyatNeticesi.Ugursuz($"'{mehsul.Ad}' üçün stokda kifayət qədər məhsul yoxdur. Mövcud say: {mehsul.MovcudSay}");
        }

        var satis = new Satis
        {
            Tarix = System.DateTime.Now,
            OdenisMetodu = odenisMetodu,
            UmumiMebleg = sebetElementleri.Sum(e => e.UmumiMebleg),
            NovbeId = novbeId
        };

        foreach (var element in sebetElementleri)
        {
            satis.SatisDetallari.Add(new SatisDetali { MehsulId = element.MehsulId, Miqdar = element.Miqdar, Qiymet = element.VahidinQiymeti });
            var mehsul = await _unitOfWork.Mehsullar.GetirAsync(element.MehsulId);
            mehsul.MovcudSay -= element.Miqdar;
            _unitOfWork.Mehsullar.Yenile(mehsul);
        }
        await _unitOfWork.Satislar.ElaveEtAsync(satis);
        await _unitOfWork.EmeliyyatiTesdiqleAsync();
        return EmeliyyatNeticesi.Ugurlu();
    }
}