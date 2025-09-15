// Fayl: AzAgroPOS.Mentiq/Idareciler/AnbarManager.cs
namespace AzAgroPOS.Mentiq.Idareciler;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Mentiq.Yardimcilar;
using AzAgroPOS.Verilenler.Interfeysler;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Anbar əməliyyatları (stok artımı və s.) ilə bağlı biznes məntiqini idarə edir.
/// </summary>
public class AnbarManager
{
    private readonly IUnitOfWork _unitOfWork;

    public AnbarManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Barkod və ya Stok Koduna görə məhsulu tapıb məlumatlarını qaytarır.
    /// </summary>
    /// <param name="barkodVeyaStokKodu">Axtarılan məhsulun barkodu və ya stok kodu.</param>
    /// <returns>Məhsul tapılarsa MehsulDto, tapılmazsa null qaytarır.</returns>
    public async Task<EmeliyyatNeticesi<MehsulDto>> MehsulTapAsync(string barkodVeyaStokKodu)
    {
        Logger.MelumatYaz($"MehsulTapAsync çağırıldı. Axtarış dəyəri: {barkodVeyaStokKodu}");
        try
        {
            if (string.IsNullOrWhiteSpace(barkodVeyaStokKodu))
                return EmeliyyatNeticesi<MehsulDto>.Ugursuz("Axtarış üçün dəyər daxil edin.");

            var mehsul = (await _unitOfWork.Mehsullar.AxtarAsync(m => m.Barkod == barkodVeyaStokKodu || m.StokKodu == barkodVeyaStokKodu)).FirstOrDefault();

            if (mehsul == null)
                return EmeliyyatNeticesi<MehsulDto>.Ugursuz("Bu koda uyğun məhsul tapılmadı.");

            var mehsulDto = new MehsulDto
            {
                Id = mehsul.Id,
                Ad = mehsul.Ad,
                StokKodu = mehsul.StokKodu,
                Barkod = mehsul.Barkod,
                MovcudSay = mehsul.MovcudSay
            };

            return EmeliyyatNeticesi<MehsulDto>.Ugurlu(mehsulDto);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Məhsul tapılarkən xəta baş verdi: ");
            return EmeliyyatNeticesi<MehsulDto>.Ugursuz($"Məhsul tapılarkən xəta baş verdi: {ex.Message} + {ex.StackTrace}");
        }

    }


    /// <summary>
    /// Mövcud məhsulun anbardakı sayını artırır.
    /// </summary>
    /// <param name="mehsulId">Sayı artırılacaq məhsulun ID-si.</param>
    /// <param name="elaveOlunanSay">Anbara əlavə edilən yeni miqdar.</param>
    /// <returns>Əməliyyatın nəticəsi.</returns>
    public async Task<EmeliyyatNeticesi<int>> AnbardakiStokuArtirAsync(int mehsulId, int elaveOlunanSay)
    {
        Logger.MelumatYaz($"AnbardakiStokuArtirAsync çağırıldı. Məhsul ID: {mehsulId}, Əlavə olunan say: {elaveOlunanSay}");
        try
        {
            if (elaveOlunanSay <= 0)
                return EmeliyyatNeticesi<int>.Ugursuz("Əlavə edilən say 0-dan böyük olmalıdır.");

            var mehsul = await _unitOfWork.Mehsullar.GetirAsync(mehsulId);
            if (mehsul == null)
                return EmeliyyatNeticesi<int>.Ugursuz("Məhsul tapılmadı.");

            mehsul.MovcudSay += elaveOlunanSay;
            _unitOfWork.Mehsullar.Yenile(mehsul);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi<int>.Ugurlu(mehsul.MovcudSay);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Anbardakı stoku artırarkən xəta baş verdi: ");
            return EmeliyyatNeticesi<int>.Ugursuz($"Anbardakı stoku artırarkən xəta baş verdi: {ex.Message} + {ex.StackTrace}");
        }

    }
}