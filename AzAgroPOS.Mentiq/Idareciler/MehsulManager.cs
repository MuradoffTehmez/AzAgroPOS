// Fayl: AzAgroPOS.Mentiq/Idareciler/MehsulManager.cs
namespace AzAgroPOS.Mentiq.Idareciler;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Mentiq.Yardimcilar;
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
        Logger.MelumatYaz("Bütün məhsullar əldə edilir");
        try
        {
            var mehsullar = await _unitOfWork.Mehsullar.ButununuGetirAsync();

            var mehsulDtolar = mehsullar.Select(m => new MehsulDto
            {
                Id = m.Id,
                Ad = m.Ad,
                StokKodu = m.StokKodu,
                Barkod = m.Barkod,
                PerakendeSatisQiymeti = m.PerakendeSatisQiymeti,
                TopdanSatisQiymeti = m.TopdanSatisQiymeti,
                TekEdedSatisQiymeti = m.TekEdedSatisQiymeti,
                AlisQiymeti = m.AlisQiymeti,
                MovcudSay = m.MovcudSay,
                OlcuVahidi = m.OlcuVahidi
            });

            Logger.MelumatYaz("Bütün məhsullar uğurla əldə edildi");
            return EmeliyyatNeticesi<IEnumerable<MehsulDto>>.Ugurlu(mehsulDtolar);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Bütün məhsullar əldə edilərkən istisna baş verdi");
            return EmeliyyatNeticesi<IEnumerable<MehsulDto>>.Ugursuz("Bütün məhsullar əldə edilərkən istisna baş verdi: " + ex.Message);
        }
    }

    /// <summary>
    /// Mövcud olmayan yeni bir məhsul yaradır.
    /// Validasiya və unikal stok kodu yoxlamaları ilə birlikdə.
    /// 
    /// Diqqət: Alış qiyməti sıfır olaraq təyin edilir, çünki bu modul üçün təyin ediləcək.
    /// </summary>
    public async Task<EmeliyyatNeticesi<int>> MehsulYaratAsync(MehsulDto yeniMehsulDto)
    {
        Logger.MelumatYaz("Yeni məhsul yaratma əməliyyatı başlayır");
        try
        {
            // --- Validasiya Hissəsi ---
            if (string.IsNullOrWhiteSpace(yeniMehsulDto.Ad))
            {
                Logger.XəbərdarlıqYaz("Məhsul adı boş ola bilməz");
                return EmeliyyatNeticesi<int>.Ugursuz("Məhsul adı boş ola bilməz.");
            }

            if (string.IsNullOrWhiteSpace(yeniMehsulDto.StokKodu))
            {
                Logger.XəbərdarlıqYaz("Stok kodu boş ola bilməz");
                return EmeliyyatNeticesi<int>.Ugursuz("Stok kodu boş ola bilməz.");
            }

            // Stok kodunun unikal olmasını yoxlayaq
            var movcudMehsul = (await _unitOfWork.Mehsullar.AxtarAsync(m => m.StokKodu == yeniMehsulDto.StokKodu)).FirstOrDefault();
            if (movcudMehsul != null)
            {
                Logger.XəbərdarlıqYaz($"'{yeniMehsulDto.StokKodu}' stok kodlu məhsul artıq mövcuddur");
                return EmeliyyatNeticesi<int>.Ugursuz($"'{yeniMehsulDto.StokKodu}' stok kodlu məhsul artıq mövcuddur.");
            }

            // --- Əməliyyat Hissəsi ---
            var yeniMehsul = new Mehsul
            {
                Ad = yeniMehsulDto.Ad,
                StokKodu = yeniMehsulDto.StokKodu,
                Barkod = yeniMehsulDto.Barkod,
                PerakendeSatisQiymeti = yeniMehsulDto.PerakendeSatisQiymeti,
                TopdanSatisQiymeti = yeniMehsulDto.TopdanSatisQiymeti,
                TekEdedSatisQiymeti = yeniMehsulDto.TekEdedSatisQiymeti,
                MovcudSay = yeniMehsulDto.MovcudSay,
                AlisQiymeti = yeniMehsulDto.AlisQiymeti,
                OlcuVahidi = yeniMehsulDto.OlcuVahidi
            };

            await _unitOfWork.Mehsullar.ElaveEtAsync(yeniMehsul);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            Logger.MelumatYaz($"Yeni məhsul uğurla yaradıldı. ID: {yeniMehsul.Id}");
            return EmeliyyatNeticesi<int>.Ugurlu(yeniMehsul.Id);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Yeni məhsul yaratma əməliyyatı zamanı istisna baş verdi");
            return EmeliyyatNeticesi<int>.Ugursuz("Yeni məhsul yaratma əməliyyatı zamanı istisna baş verdi: " + ex.Message);
        }
    }

    /// <summary>
    /// Bu metod mövcud məhsulun məlumatlarını yeniləmək üçün istifadə olunur.
    /// diqqət: Məhsulun ID-si ilə mövcud məhsul tapılır və onun məlumatları yenilənir.
    /// Stok kodunun unikal olmasını yoxlayır.
    /// yoxlayır ki, məhsulun adı və stok kodu boş olmasın.
    /// </summary>
    public async Task<EmeliyyatNeticesi> MehsulYenileAsync(MehsulDto mehsulDto)
    {
        Logger.MelumatYaz($"Məhsul yeniləmə əməliyyatı başlayır. ID: {mehsulDto.Id}");
        try
        {
            var movcudMehsul = await _unitOfWork.Mehsullar.GetirAsync(mehsulDto.Id);
            if (movcudMehsul == null)
            {
                Logger.XəbərdarlıqYaz("Məhsul tapılmadı");
                return EmeliyyatNeticesi.Ugursuz("Məhsul tapılmadı.");
            }

            // Stok kodunun başqa məhsulda istifadə olunmadığını yoxlayaq
            var eyniKodluBasqaMehsul = (await _unitOfWork.Mehsullar.AxtarAsync(m => m.StokKodu == mehsulDto.StokKodu && m.Id != mehsulDto.Id)).FirstOrDefault();
            if (eyniKodluBasqaMehsul != null)
            {
                Logger.XəbərdarlıqYaz($"'{mehsulDto.StokKodu}' stok kodu başqa məhsulda istifadə olunur");
                return EmeliyyatNeticesi.Ugursuz($"'{mehsulDto.StokKodu}' stok kodu başqa məhsulda istifadə olunur.");
            }

            movcudMehsul.Ad = mehsulDto.Ad;
            movcudMehsul.StokKodu = mehsulDto.StokKodu;
            movcudMehsul.Barkod = mehsulDto.Barkod;
            movcudMehsul.PerakendeSatisQiymeti = mehsulDto.PerakendeSatisQiymeti;
            movcudMehsul.TopdanSatisQiymeti = mehsulDto.TopdanSatisQiymeti;
            movcudMehsul.TekEdedSatisQiymeti = mehsulDto.TekEdedSatisQiymeti;
            movcudMehsul.AlisQiymeti = mehsulDto.AlisQiymeti;
            movcudMehsul.MovcudSay = mehsulDto.MovcudSay;
            movcudMehsul.OlcuVahidi = mehsulDto.OlcuVahidi;


            _unitOfWork.Mehsullar.Yenile(movcudMehsul);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            Logger.MelumatYaz($"Məhsul uğurla yeniləndi. ID: {mehsulDto.Id}");
            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Məhsul yeniləmə əməliyyatı zamanı istisna baş verdi");
            return EmeliyyatNeticesi.Ugursuz("Məhsul yeniləmə əməliyyatı zamanı istisna baş verdi: " + ex.Message);
        }
    }

    /// <summary>
    /// Mövcud məhsulu silir.
    /// silinəcək məhsulun mövcud olub-olmadığını yoxlayır.
    /// diqqət: Məhsul silindikdən sonra onun bütün satış və alış tarixçələri silinmir, yalnız məhsulun özü silinir.
    /// Əgər məhsul satış və ya alış tarixçələrində istifadə olunubsa, bu əməliyyat uğursuz olacaq.
    /// </summary>
    public async Task<EmeliyyatNeticesi> MehsulSilAsync(int id)
    {
        Logger.MelumatYaz($"Məhsul silmə əməliyyatı başlayır. ID: {id}");
        try
        {
            var mehsul = await _unitOfWork.Mehsullar.GetirAsync(id);
            if (mehsul == null)
            {
                Logger.XəbərdarlıqYaz("Silinəcək məhsul tapılmadı");
                return EmeliyyatNeticesi.Ugursuz("Silinəcək məhsul tapılmadı.");
            }

            _unitOfWork.Mehsullar.Sil(mehsul);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            Logger.MelumatYaz($"Məhsul uğurla silindi. ID: {id}");
            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Məhsul silmə əməliyyatı zamanı istisna baş verdi");
            return EmeliyyatNeticesi.Ugursuz("Məhsul silmə əməliyyatı zamanı istisna baş verdi: " + ex.Message);
        }
    }


    /// <summary>
    /// Verilmiş məhsul adına əsasən unikal Stok Kodu (SKU) yaradır.
    /// Məsələn: "Süd 1L" -> "SUD-12345"
    /// </summary>
    /// <param name="mehsulAdi">Stok kodu yaradılacaq məhsulun adı.</param>
    public async Task<EmeliyyatNeticesi<string>> StokKoduGeneralasiyaEtAsync(string mehsulAdi)
    {
        Logger.MelumatYaz("Stok kodu yaratma əməliyyatı başlayır");
        try
        {
            if (string.IsNullOrWhiteSpace(mehsulAdi))
            {
                Logger.XəbərdarlıqYaz("Stok Kodu yaratmaq üçün məhsul adı daxil edilməlidir");
                return EmeliyyatNeticesi<string>.Ugursuz("Stok Kodu yaratmaq üçün məhsul adı daxil edilməlidir.");
            }

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

            Logger.MelumatYaz($"Stok kodu uğurla yaradıldı: {yeniStokKodu}");
            return EmeliyyatNeticesi<string>.Ugurlu(yeniStokKodu);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Stok kodu yaratma əməliyyatı zamanı istisna baş verdi");
            return EmeliyyatNeticesi<string>.Ugursuz("Stok kodu yaratma əməliyyatı zamanı istisna baş verdi: " + ex.Message);
        }
    }

    /// <summary>
    /// Daxili istifadə üçün unikal Barkod yaradır.
    /// </summary>
    public async Task<EmeliyyatNeticesi<string>> BarkodGeneralasiyaEtAsync()
    {
        Logger.MelumatYaz("Barkod yaratma əməliyyatı başlayır");
        try
        {
            string yeniBarkod;
            Random random = new Random();

            do
            {
                yeniBarkod = "2" + random.NextInt64(100_000_000_000, 999_999_999_999).ToString();
            } while ((await _unitOfWork.Mehsullar.AxtarAsync(m => m.Barkod == yeniBarkod)).Any());

            Logger.MelumatYaz($"Barkod uğurla yaradıldı: {yeniBarkod}");
            return EmeliyyatNeticesi<string>.Ugurlu(yeniBarkod);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Barkod yaratma əməliyyatı zamanı istisna baş verdi");
            return EmeliyyatNeticesi<string>.Ugursuz("Barkod yaratma əməliyyatı zamanı istisna baş verdi: " + ex.Message);
        }
    }

    public async Task<EmeliyyatNeticesi<List<MehsulDto>>> AxtarAsync(string axtarisMetni, int sayLimit = 100)
    {
        Logger.MelumatYaz($"Məhsul axtarışı başlayır. Axtarış mətni: {axtarisMetni}");
        try
        {
            var butunMehsullar = await _unitOfWork.Mehsullar.AxtarAsync(m => m.Aktivdir);

            if (!string.IsNullOrWhiteSpace(axtarisMetni))
            {
                axtarisMetni = axtarisMetni.ToLower();
                butunMehsullar = butunMehsullar.Where(m =>
                    m.Ad.ToLower().Contains(axtarisMetni) ||
                    (m.StokKodu != null && m.StokKodu.ToLower().Contains(axtarisMetni)) ||
                    (m.Barkod != null && m.Barkod.Contains(axtarisMetni))
                );
            }

            var dtolar = butunMehsullar.Take(sayLimit).Select(m => new MehsulDto
            {
                Id = m.Id,
                Ad = m.Ad,
                Barkod = m.Barkod,
                StokKodu = m.StokKodu,
                PerakendeSatisQiymeti = m.PerakendeSatisQiymeti,
                AnbarMiqdari = m.MovcudSay,
                Aktivdir = m.Aktivdir,
                OlcuVahidi = m.OlcuVahidi,
                OlcuVahidiAdi = m.OlcuVahidi.ToString()
            }).ToList();

            Logger.MelumatYaz($"Məhsul axtarışı tamamlandı. Tapılan nəticə sayı: {dtolar.Count}");
            return EmeliyyatNeticesi<List<MehsulDto>>.Ugurlu(dtolar);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Məhsul axtarışı zamanı istisna baş verdi");
            return EmeliyyatNeticesi<List<MehsulDto>>.Ugursuz("Məhsul axtarışı zamanı istisna baş verdi: " + ex.Message);
        }
    }

    /// <summary>
    /// Səhifələnmiş məhsul siyahısını əldə edir.
    /// Diqqət: Bu metod böyük məlumat bazaları üçün əlverişlidir.
    /// </summary>
    /// <param name="parametrler">Səhifələmə parametrləri</param>
    /// <returns>Səhifələnmiş məhsul məlumatları</returns>
    public async Task<EmeliyyatNeticesi<SehifelenmisMelumat<MehsulDto>>> MehsullariSehifelenmisGetirAsync(SehifeParametrleri parametrler)
    {
        Logger.MelumatYaz($"Səhifələnmiş məhsullar əldə edilir - Səhifə: {parametrler.SehifeNomresi}, Ölçü: {parametrler.SehifeOlcusu}");
        try
        {
            var (mehsullar, umumiSay) = await _unitOfWork.Mehsullar.SehifelenmisGetirAsync(
                parametrler.SehifeNomresi,
                parametrler.SehifeOlcusu,
                m => m.Aktivdir);

            var mehsulDtolar = mehsullar.Select(m => new MehsulDto
            {
                Id = m.Id,
                Ad = m.Ad,
                StokKodu = m.StokKodu,
                Barkod = m.Barkod,
                PerakendeSatisQiymeti = m.PerakendeSatisQiymeti,
                TopdanSatisQiymeti = m.TopdanSatisQiymeti,
                TekEdedSatisQiymeti = m.TekEdedSatisQiymeti,
                AlisQiymeti = m.AlisQiymeti,
                MovcudSay = m.MovcudSay,
                OlcuVahidi = m.OlcuVahidi
            }).ToList();

            var sehifelenmis = new SehifelenmisMelumat<MehsulDto>(
                mehsulDtolar,
                umumiSay,
                parametrler.SehifeNomresi,
                parametrler.SehifeOlcusu);

            Logger.MelumatYaz($"Səhifələnmiş məhsullar uğurla əldə edildi - {mehsulDtolar.Count}/{umumiSay}");
            return EmeliyyatNeticesi<SehifelenmisMelumat<MehsulDto>>.Ugurlu(sehifelenmis);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Səhifələnmiş məhsullar əldə edilərkən istisna baş verdi");
            return EmeliyyatNeticesi<SehifelenmisMelumat<MehsulDto>>.Ugursuz($"Səhifələnmiş məhsullar əldə edilərkən xəta: {ex.Message}");
        }
    }
}