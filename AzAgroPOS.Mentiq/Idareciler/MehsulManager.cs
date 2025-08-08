// Fayl: AzAgroPOS.Mentiq/Idareciler/MehsulManager.cs
namespace AzAgroPOS.Mentiq.Idareciler;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;

/// <summary>
/// Məhsullarla bağlı biznes məntiqini, validasiyaları və əməliyyatları idarə edir.
/// </summary>
public class MehsulManager
{
    private readonly IUnitOfWork _unitOfWork;

    public MehsulManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Bütün məhsulları DTO formatında gətirir.
    /// </summary>
    public async Task<EmeliyyatNeticesi<IEnumerable<MehsulDto>>> ButunMehsullariGetirAsync()
    {
        var mehsullar = await _unitOfWork.Mehsullar.ButununuGetirAsync();

        var mehsulDtolar = mehsullar.Select(m => new MehsulDto
        {
            Id = m.Id,
            Ad = m.Ad,
            StokKodu = m.StokKodu,
            Barkod = m.Barkod,
            SatisQiymeti = m.SatisQiymeti,
            MovcudSay = m.MovcudSay
        });

        return EmeliyyatNeticesi<IEnumerable<MehsulDto>>.Ugurlu(mehsulDtolar);
    }

    /// <summary>
    /// Yeni bir məhsul yaradır.
    /// </summary>
    public async Task<EmeliyyatNeticesi<int>> MehsulYaratAsync(MehsulDto yeniMehsulDto)
    {
        // --- Validasiya Hissəsi ---
        if (string.IsNullOrWhiteSpace(yeniMehsulDto.Ad))
            return EmeliyyatNeticesi<int>.Ugursuz("Məhsul adı boş ola bilməz.");

        if (string.IsNullOrWhiteSpace(yeniMehsulDto.StokKodu))
            return EmeliyyatNeticesi<int>.Ugursuz("Stok kodu boş ola bilməz.");

        // Stok kodunun unikal olmasını yoxlayaq
        var movcudMehsul = (await _unitOfWork.Mehsullar.AxtarAsync(m => m.StokKodu == yeniMehsulDto.StokKodu)).FirstOrDefault();
        if (movcudMehsul != null)
            return EmeliyyatNeticesi<int>.Ugursuz($"'{yeniMehsulDto.StokKodu}' stok kodlu məhsul artıq mövcuddur.");

        // --- Əməliyyat Hissəsi ---
        var yeniMehsul = new Mehsul
        {
            Ad = yeniMehsulDto.Ad,
            StokKodu = yeniMehsulDto.StokKodu,
            Barkod = yeniMehsulDto.Barkod,
            SatisQiymeti = yeniMehsulDto.SatisQiymeti,
            MovcudSay = yeniMehsulDto.MovcudSay,
            AlisQiymeti = 0 // Alış modulu üçün bu dəyər təyin ediləcək
        };

        await _unitOfWork.Mehsullar.ElaveEtAsync(yeniMehsul);
        await _unitOfWork.EmeliyyatiTesdiqleAsync();

        return EmeliyyatNeticesi<int>.Ugurlu(yeniMehsul.Id);
    }

    /// <summary>
    /// Mövcud məhsulu yeniləyir.
    /// </summary>
    public async Task<EmeliyyatNeticesi> MehsulYenileAsync(MehsulDto mehsulDto)
    {
        var movcudMehsul = await _unitOfWork.Mehsullar.GetirAsync(mehsulDto.Id);
        if (movcudMehsul == null)
            return EmeliyyatNeticesi.Ugursuz("Məhsul tapılmadı.");

        // Stok kodunun başqa məhsulda istifadə olunmadığını yoxlayaq
        var eyniKodluBasqaMehsul = (await _unitOfWork.Mehsullar.AxtarAsync(m => m.StokKodu == mehsulDto.StokKodu && m.Id != mehsulDto.Id)).FirstOrDefault();
        if (eyniKodluBasqaMehsul != null)
            return EmeliyyatNeticesi.Ugursuz($"'{mehsulDto.StokKodu}' stok kodu başqa məhsulda istifadə olunur.");

        movcudMehsul.Ad = mehsulDto.Ad;
        movcudMehsul.StokKodu = mehsulDto.StokKodu;
        movcudMehsul.Barkod = mehsulDto.Barkod;
        movcudMehsul.SatisQiymeti = mehsulDto.SatisQiymeti;
        movcudMehsul.MovcudSay = mehsulDto.MovcudSay;

        _unitOfWork.Mehsullar.Yenile(movcudMehsul);
        await _unitOfWork.EmeliyyatiTesdiqleAsync();

        return EmeliyyatNeticesi.Ugurlu();
    }

    /// <summary>
    /// Məhsulu ID-sinə görə silir.
    /// </summary>
    public async Task<EmeliyyatNeticesi> MehsulSilAsync(int id)
    {
        var mehsul = await _unitOfWork.Mehsullar.GetirAsync(id);
        if (mehsul == null)
            return EmeliyyatNeticesi.Ugursuz("Silinəcək məhsul tapılmadı.");

        _unitOfWork.Mehsullar.Sil(mehsul);
        await _unitOfWork.EmeliyyatiTesdiqleAsync();

        return EmeliyyatNeticesi.Ugurlu();
    }
}