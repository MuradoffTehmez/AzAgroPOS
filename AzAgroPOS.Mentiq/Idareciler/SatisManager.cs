// Fayl: AzAgroPOS.Mentiq/Idareciler/SatisManager.cs
namespace AzAgroPOS.Mentiq.Idareciler;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;

public class SatisManager
{
    private readonly IUnitOfWork _unitOfWork;

    public SatisManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<EmeliyyatNeticesi> SatisiTesdiqleAsync(List<SatisSebetiElementiDto> sebetElementleri, OdenisMetodu odenisMetodu)
    {
        if (sebetElementleri == null || !sebetElementleri.Any())
            return EmeliyyatNeticesi.Ugursuz("Satış üçün səbət boşdur.");

        // 1. Stok yoxlaması
        foreach (var element in sebetElementleri)
        {
            var mehsul = await _unitOfWork.Mehsullar.GetirAsync(element.MehsulId);
            if (mehsul == null)
                return EmeliyyatNeticesi.Ugursuz($"ID: {element.MehsulId} olan məhsul tapılmadı.");

            if (mehsul.MovcudSay < element.Miqdar)
                return EmeliyyatNeticesi.Ugursuz($"'{mehsul.Ad}' üçün stokda kifayət qədər məhsul yoxdur. Mövcud say: {mehsul.MovcudSay}");
        }

        // 2. Satış və satış detallarını yarat
        var satis = new Satis
        {
            Tarix = DateTime.Now,
            OdenisMetodu = odenisMetodu,
            UmumiMebleg = sebetElementleri.Sum(e => e.UmumiMebleg)
        };

        foreach (var element in sebetElementleri)
        {
            satis.SatisDetallari.Add(new SatisDetali
            {
                MehsulId = element.MehsulId,
                Miqdar = element.Miqdar,
                Qiymet = element.VahidinQiymeti
            });

            // 3. Stokdan çıx
            var mehsul = await _unitOfWork.Mehsullar.GetirAsync(element.MehsulId);
            mehsul.MovcudSay -= element.Miqdar;
            _unitOfWork.Mehsullar.Yenile(mehsul);
        }

        await _unitOfWork.Satislar.ElaveEtAsync(satis);

        // 4. Bütün əməliyyatları vahid tranzaksiya kimi təsdiqlə
        await _unitOfWork.EmeliyyatiTesdiqleAsync();

        return EmeliyyatNeticesi.Ugurlu();
    }
}