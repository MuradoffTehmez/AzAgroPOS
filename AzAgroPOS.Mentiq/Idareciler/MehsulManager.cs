// Fayl: AzAgroPOS.Mentiq/Idareciler/MehsulManager.cs
namespace AzAgroPOS.Mentiq.Idareciler;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using System.Text.RegularExpressions;

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
    /// diqqət: Bu metod məhsulun ID, adı, stok kodu, barkodu, satış qiyməti və mövcud sayını gətirir.
    /// task : Asinxron olaraq işləyir və məhsul məlumatlarını gətirir.
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
            AlisQiymeti = m.AlisQiymeti,
            MovcudSay = m.MovcudSay
        });

        return EmeliyyatNeticesi<IEnumerable<MehsulDto>>.Ugurlu(mehsulDtolar);
    }

    /// <summary>
    /// Mövcud olmayan yeni bir məhsul yaradır.
    /// Validasiya və unikal stok kodu yoxlamaları ilə birlikdə.
    /// 
    /// Diqqət: Alış qiyməti sıfır olaraq təyin edilir, çünki bu modul üçün təyin ediləcək.
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
            AlisQiymeti = yeniMehsulDto.AlisQiymeti
        };

        await _unitOfWork.Mehsullar.ElaveEtAsync(yeniMehsul);
        await _unitOfWork.EmeliyyatiTesdiqleAsync();

        return EmeliyyatNeticesi<int>.Ugurlu(yeniMehsul.Id);
    }

    /// <summary>
    /// Bu metod mövcud məhsulun məlumatlarını yeniləmək üçün istifadə olunur.
    /// diqqət: Məhsulun ID-si ilə mövcud məhsul tapılır və onun məlumatları yenilənir.
    /// Stok kodunun unikal olmasını yoxlayır.
    /// yoxlayır ki, məhsulun adı və stok kodu boş olmasın.
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
        movcudMehsul.AlisQiymeti = mehsulDto.AlisQiymeti;
        movcudMehsul.MovcudSay = mehsulDto.MovcudSay;


        _unitOfWork.Mehsullar.Yenile(movcudMehsul);
        await _unitOfWork.EmeliyyatiTesdiqleAsync();

        return EmeliyyatNeticesi.Ugurlu();
    }

    /// <summary>
    /// Mövcud məhsulu silir.
    /// silinəcək məhsulun mövcud olub-olmadığını yoxlayır.
    /// diqqət: Məhsul silindikdən sonra onun bütün satış və alış tarixçələri silinmir, yalnız məhsulun özü silinir.
    /// Əgər məhsul satış və ya alış tarixçələrində istifadə olunubsa, bu əməliyyat uğursuz olacaq.
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
    /// <summary>
    /// Verilmiş məhsul adına əsasən unikal Stok Kodu (SKU) yaradır.
    /// Məsələn: "Süd 1L" -> "SUD-12345"
    /// </summary>
    /// <param name="mehsulAdi">Stok kodu yaradılacaq məhsulun adı.</param>
    public async Task<EmeliyyatNeticesi<string>> StokKoduGeneralasiyaEtAsync(string mehsulAdi)
    {
        if (string.IsNullOrWhiteSpace(mehsulAdi))
            return EmeliyyatNeticesi<string>.Ugursuz("Stok Kodu yaratmaq üçün məhsul adı daxil edilməlidir.");

        string yeniStokKodu;
        Random random = new Random();

        // Məhsul adından prefiks yarat (ilk sözün ilk 3 hərfi)
        var hisseler = mehsulAdi.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string prefix = hisseler.Length > 0 ? new string(hisseler[0].Take(3).ToArray()).ToUpper() : "SKU";

        // Yalnız hərflərdən ibarət olduğundan əmin ol
        prefix = Regex.Replace(prefix, @"[^A-Z]", "");
        if (prefix.Length == 0) prefix = "SKU";

        do
        {
            yeniStokKodu = $"{prefix}-{random.Next(10000, 99999)}";
        } while ((await _unitOfWork.Mehsullar.AxtarAsync(m => m.StokKodu == yeniStokKodu)).Any());

        return EmeliyyatNeticesi<string>.Ugurlu(yeniStokKodu);
    }

    /// <summary>
    /// Daxili istifadə üçün unikal Barkod yaradır.
    /// </summary>
    public async Task<EmeliyyatNeticesi<string>> BarkodGeneralasiyaEtAsync()
    {
        string yeniBarkod;
        Random random = new Random();

        do
        {
            yeniBarkod = "2" + random.NextInt64(100_000_000_000, 999_999_999_999).ToString();
        } while ((await _unitOfWork.Mehsullar.AxtarAsync(m => m.Barkod == yeniBarkod)).Any());

        return EmeliyyatNeticesi<string>.Ugurlu(yeniBarkod);
    }

    /*
    /// <summary>
    /// Məhsul üçün unikal Stok Kodu və Barkod yaradır.
    /// </summary>
    /// <returns>Yaradılmış unikal kodları olan DTO.</returns>
    public async Task<EmeliyyatNeticesi<GeneratedCodesDto>> KodlariGeneralasiyaEtAsync()
    {
        string yeniStokKodu;
        string yeniBarkod;
        Random random = new Random();

        // Unikal Stok Kodu yarat
        do
        {
            // Zaman damğası əsasında unikal bir kod yaradırıq (məsələn: SKU1661800000123)
            yeniStokKodu = "SKU" + DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();
        } while ((await _unitOfWork.Mehsullar.AxtarAsync(m => m.StokKodu == yeniStokKodu)).Any());

        // Unikal Barkod yarat
        do
        {
            // Daxili istifadə üçün 12 rəqəmli təsadüfi bir kod yaradırıq.
            // "2" prefiksi adətən daxili, mağaza tərəfindən yaradılan barkodlar üçün istifadə olunur.
            yeniBarkod = "2" + random.NextInt64(100_000_000_000, 999_999_999_999).ToString();
        } while ((await _unitOfWork.Mehsullar.AxtarAsync(m => m.Barkod == yeniBarkod)).Any());

        var generatedCodes = new GeneratedCodesDto
        {
            StokKodu = yeniStokKodu,
            Barkod = yeniBarkod
        };

        return EmeliyyatNeticesi<GeneratedCodesDto>.Ugurlu(generatedCodes);
    }
    */
}