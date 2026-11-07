// Fayl: AzAgroPOS.Mentiq/Idareciler/AnbarManager.cs

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Mentiq.Yardimcilar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;

namespace AzAgroPOS.Mentiq.Idareciler;
/// <summary>
/// Anbar əməliyyatları (stok artımı və s.) ilə bağlı biznes məntiqini idarə edir.
/// </summary>
public class AnbarManager
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStokHareketiRepozitori _stokHareketiRepo;

    public AnbarManager(IUnitOfWork unitOfWork, IStokHareketiRepozitori stokHareketiRepo)
    {
        _unitOfWork = unitOfWork;
        _stokHareketiRepo = stokHareketiRepo;
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
            {
                return EmeliyyatNeticesi<MehsulDto>.Ugursuz("Axtarış üçün dəyər daxil edin.");
            }

            Mehsul? mehsul = (await _unitOfWork.Mehsullar.AxtarAsync(m => m.Barkod == barkodVeyaStokKodu || m.StokKodu == barkodVeyaStokKodu)).FirstOrDefault();

            if (mehsul == null)
            {
                return EmeliyyatNeticesi<MehsulDto>.Ugursuz("Bu koda uyğun məhsul tapılmadı.");
            }

            MehsulDto mehsulDto = new()
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
    public async Task<EmeliyyatNeticesi<decimal>> AnbardakiStokuArtirAsync(
        int mehsulId, decimal elaveOlunanSay, string? qeyd = null, SenedNovu? senedNovu = null)
    {
        if (!IcazeYoxlayici.Instance.IcazeVarmi(SistemIcazeleri.MehsulDeyis))
            return EmeliyyatNeticesi<decimal>.Ugursuz("Anbar qalığını dəyişməyə icazəniz yoxdur.");
        Logger.MelumatYaz($"AnbardakiStokuArtirAsync çağırıldı. Məhsul ID: {mehsulId}, Əlavə olunan say: {elaveOlunanSay}");
        try
        {
            if (elaveOlunanSay == 0)
            {
                return EmeliyyatNeticesi<decimal>.Ugursuz("Dəyişiklik miqdarı sıfır ola bilməz.");
            }
            if (elaveOlunanSay != decimal.Round(elaveOlunanSay, 3))
                return EmeliyyatNeticesi<decimal>.Ugursuz("Stok miqdarı ən çox üç onluq dəqiqlikdə olmalıdır.");

            Mehsul mehsul = await _unitOfWork.Mehsullar.GetirAsync(mehsulId);
            if (mehsul == null)
            {
                return EmeliyyatNeticesi<decimal>.Ugursuz("Məhsul tapılmadı.");
            }
            if ((mehsul.OlcuVahidi == OlcuVahidi.Ədəd || mehsul.OlcuVahidi == OlcuVahidi.Paket) &&
                elaveOlunanSay != decimal.Truncate(elaveOlunanSay))
                return EmeliyyatNeticesi<decimal>.Ugursuz("Ədəd və paket məhsulunun stok dəyişməsi tam ədəd olmalıdır.");

            mehsul.MovcudSay += elaveOlunanSay;
            _unitOfWork.Mehsullar.Yenile(mehsul);
            await _stokHareketiRepo.ElaveEtAsync(new StokHareketi
            {
                MehsulId = mehsulId,
                HareketTipi = elaveOlunanSay > 0 ? StokHareketTipi.Daxilolma : StokHareketTipi.Cixis,
                SenedNovu = senedNovu ?? (elaveOlunanSay > 0 ? SenedNovu.DuzeltmeArtirim : SenedNovu.DuzeltmeAzalma),
                Miqdar = Math.Abs(elaveOlunanSay),
                AlisQiymeti = mehsul.AlisQiymeti,
                SatisQiymeti = mehsul.PerakendeSatisQiymeti,
                Tarix = DateTime.Now,
                Qeyd = qeyd
            });
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi<decimal>.Ugurlu(mehsul.MovcudSay);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Anbardakı stoku artırarkən xəta baş verdi: ");
            return EmeliyyatNeticesi<decimal>.Ugursuz($"Anbardakı stoku artırarkən xəta baş verdi: {ex.Message} + {ex.StackTrace}");
        }

    }

    /// <summary>
    /// Bütün məhsulların siyahısını DTO formatında qaytarır.
    /// </summary>
    /// <returns>Məhsul siyahısı.</returns>
    public async Task<EmeliyyatNeticesi<List<MehsulDto>>> ButunMehsullariGetirAsync()
    {
        Logger.MelumatYaz("ButunMehsullariGetirAsync çağırıldı");
        try
        {
            IEnumerable<Mehsul> mehsullar = await _unitOfWork.Mehsullar.ButununuGetirAsync();

            List<MehsulDto> mehsulDtolar = mehsullar.Select(m => new MehsulDto
            {
                Id = m.Id,
                Ad = m.Ad,
                StokKodu = m.StokKodu,
                Barkod = m.Barkod,
                MovcudSay = m.MovcudSay,
                AlisQiymeti = m.AlisQiymeti,
                PerakendeSatisQiymeti = m.PerakendeSatisQiymeti,
                MinimumStok = m.MinimumStok,
                OlcuVahidi = m.OlcuVahidi,
                OlcuVahidiAdi = m.OlcuVahidi.ToString()
            }).OrderBy(m => m.Ad).ToList();

            Logger.MelumatYaz($"Bütün məhsullar gətirildi. Say: {mehsulDtolar.Count}");
            return EmeliyyatNeticesi<List<MehsulDto>>.Ugurlu(mehsulDtolar);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Bütün məhsullar gətirilmərkən xəta baş verdi: ");
            return EmeliyyatNeticesi<List<MehsulDto>>.Ugursuz($"Məhsullar gətirilmərkən xəta: {ex.Message}");
        }
    }
}
