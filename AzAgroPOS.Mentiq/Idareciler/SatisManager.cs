// Fayl: AzAgroPOS.Mentiq/Idareciler/SatisManager.cs
namespace AzAgroPOS.Mentiq.Idareciler;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Satışlarla bağlı əməliyyatları idarə edən menecer.
/// diqqət : Bu menecer satış təsdiqləmə, stok yoxlaması və satış detalları ilə bağlı əməliyyatları həyata keçirir.
/// qeyd: Satış təsdiqləmə əməliyyatı, satış səbəti elementlərini yoxlayır, stokda kifayət qədər məhsul olub olmadığını təsdiqləyir və satış əməliyyatını həyata keçirir.
/// </summary>
public class SatisManager
{
    private readonly IUnitOfWork _unitOfWork;
    public SatisManager(IUnitOfWork unitOfWork) { _unitOfWork = unitOfWork; }

    /// <summary>
    /// bu metod satış təsdiqləmə əməliyyatını həyata keçirir.
    /// diqqət: Satış təsdiqləmə zamanı satış səbəti elementləri, ödəniş metodu və növbə ID-si tələb olunur.
    /// səbət elementləri - satış üçün seçilmiş məhsul və miqdarları, ödəniş metodu - nağd, kart və s. ola bilər,
    /// task : Asinxron olaraq işləyir və satış əməliyyatını təsdiqləyir.
    /// qeyd: Əgər səbət boşdursa və ya stokda kifayət qədər məhsul yoxdursa, əməliyyat uğursuz olur və müvafiq mesaj qaytarılır.
    /// </summary>
    /// <param name="sebetElementleri"></param>
    /// <param name="odenisMetodu"></param>
    /// <param name="novbeId"></param>
    /// <returns></returns>
    public async Task<EmeliyyatNeticesi<Satis>> SatisiTesdiqleAsync(List<SatisSebetiElementiDto> sebetElementleri, OdenisMetodu odenisMetodu, int novbeId)
    {
        if (sebetElementleri == null || !sebetElementleri.Any())
            return EmeliyyatNeticesi<Satis>.Ugursuz("Satış üçün səbət boşdur.");

        // Stok yoxlaması
        foreach (var element in sebetElementleri)
        {
            var mehsul = await _unitOfWork.Mehsullar.GetirAsync(element.MehsulId);
            if (mehsul == null)
                return EmeliyyatNeticesi<Satis>.Ugursuz($"ID: {element.MehsulId} olan məhsul tapılmadı.");
            if (mehsul.MovcudSay < element.Miqdar)
                return EmeliyyatNeticesi<Satis>.Ugursuz($"'{mehsul.Ad}' üçün stokda kifayət qədər məhsul yoxdur. Mövcud say: {mehsul.MovcudSay}");
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
            if (mehsul != null)
            {
                mehsul.MovcudSay -= element.Miqdar;
                _unitOfWork.Mehsullar.Yenile(mehsul);
            }
        }
        await _unitOfWork.Satislar.ElaveEtAsync(satis);
        await _unitOfWork.EmeliyyatiTesdiqleAsync();

        return EmeliyyatNeticesi<Satis>.Ugurlu(satis);
    }
}