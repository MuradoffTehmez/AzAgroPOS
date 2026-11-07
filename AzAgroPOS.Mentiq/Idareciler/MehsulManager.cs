// Fayl: AzAgroPOS.Mentiq/Idareciler/MehsulManager.cs

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Mentiq.Yardimcilar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using System.Text.RegularExpressions;

namespace AzAgroPOS.Mentiq.Idareciler;
/// <summary>
/// Məhsullarla bağlı biznes məntiqini, validasiyaları və əməliyyatları idarə edir.
/// </summary>
public class MehsulManager
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IStokHareketiRepozitori? _stokHareketleri;

    public MehsulManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public MehsulManager(IUnitOfWork unitOfWork, IStokHareketiRepozitori stokHareketleri)
        : this(unitOfWork)
    {
        _stokHareketleri = stokHareketleri;
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
            IEnumerable<Mehsul> mehsullar = await _unitOfWork.Mehsullar.ButununuGetirAsync();

            IEnumerable<MehsulDto> mehsulDtolar = mehsullar.Select(m => new MehsulDto
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
                OlcuVahidi = m.OlcuVahidi,
                Aktivdir = m.Aktivdir,
                MinimumStok = m.MinimumStok,
                KateqoriyaId = m.KateqoriyaId,
                BrendId = m.BrendId,
                TedarukcuId = m.TedarukcuId,
                SekilYolu = m.SekilYolu
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
    /// Alış və satış qiymətləri məhsulun ilk qeydindən saxlanır.
    /// </summary>
    public async Task<EmeliyyatNeticesi<int>> MehsulYaratAsync(MehsulDto yeniMehsulDto)
    {
        if (!IcazeYoxlayici.Instance.IcazeVarmi(SistemIcazeleri.MehsulElaveEt))
            return EmeliyyatNeticesi<int>.Ugursuz("Məhsul əlavə etməyə icazəniz yoxdur.");
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

            string? qiymetXetasi = MehsulMelumatlariniYoxla(yeniMehsulDto);
            if (qiymetXetasi != null)
                return EmeliyyatNeticesi<int>.Ugursuz(qiymetXetasi);
            if (yeniMehsulDto.MovcudSay < 0)
                return EmeliyyatNeticesi<int>.Ugursuz("Yeni məhsulun başlanğıc sayı mənfi ola bilməz.");

            // Stok kodunun unikal olmasını yoxlayaq
            Mehsul? movcudMehsul = (await _unitOfWork.Mehsullar.AxtarAsync(m => m.StokKodu == yeniMehsulDto.StokKodu)).FirstOrDefault();
            if (movcudMehsul != null)
            {
                Logger.XəbərdarlıqYaz($"'{yeniMehsulDto.StokKodu}' stok kodlu məhsul artıq mövcuddur");
                return EmeliyyatNeticesi<int>.Ugursuz($"'{yeniMehsulDto.StokKodu}' stok kodlu məhsul artıq mövcuddur.");
            }

            if (!string.IsNullOrWhiteSpace(yeniMehsulDto.Barkod) &&
                (await _unitOfWork.Mehsullar.AxtarAsync(m => m.Barkod == yeniMehsulDto.Barkod)).Any())
                return EmeliyyatNeticesi<int>.Ugursuz("Bu barkod artıq başqa məhsulda istifadə olunur.");

            // --- Əməliyyat Hissəsi ---
            Mehsul yeniMehsul = new()
            {
                Ad = yeniMehsulDto.Ad.Trim(),
                StokKodu = yeniMehsulDto.StokKodu.Trim(),
                Barkod = yeniMehsulDto.Barkod?.Trim() ?? string.Empty,
                PerakendeSatisQiymeti = yeniMehsulDto.PerakendeSatisQiymeti,
                TopdanSatisQiymeti = yeniMehsulDto.TopdanSatisQiymeti,
                TekEdedSatisQiymeti = yeniMehsulDto.TekEdedSatisQiymeti,
                MovcudSay = yeniMehsulDto.MovcudSay,
                AlisQiymeti = yeniMehsulDto.AlisQiymeti,
                OlcuVahidi = yeniMehsulDto.OlcuVahidi,
                MinimumStok = yeniMehsulDto.MinimumStok,
                KateqoriyaId = yeniMehsulDto.KateqoriyaId,
                BrendId = yeniMehsulDto.BrendId,
                TedarukcuId = yeniMehsulDto.TedarukcuId
            };

            await _unitOfWork.Mehsullar.ElaveEtAsync(yeniMehsul);
            if (yeniMehsulDto.MovcudSay > 0 && _stokHareketleri != null)
            {
                await _stokHareketleri.ElaveEtAsync(new StokHareketi
                {
                    Mehsul = yeniMehsul,
                    HareketTipi = StokHareketTipi.Daxilolma,
                    SenedNovu = SenedNovu.DuzeltmeArtirim,
                    Miqdar = yeniMehsulDto.MovcudSay,
                    AlisQiymeti = yeniMehsulDto.AlisQiymeti,
                    SatisQiymeti = yeniMehsulDto.PerakendeSatisQiymeti,
                    Tarix = DateTime.Now,
                    Qeyd = "Yeni məhsulun başlanğıc qalığı",
                    IstifadeciId = _unitOfWork.AktivIstifadeciId > 0 ? _unitOfWork.AktivIstifadeciId : null
                });
            }
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
        if (!IcazeYoxlayici.Instance.IcazeVarmi(SistemIcazeleri.MehsulDeyis))
            return EmeliyyatNeticesi.Ugursuz("Məhsul dəyişməyə icazəniz yoxdur.");
        Logger.MelumatYaz($"Məhsul yeniləmə əməliyyatı başlayır. ID: {mehsulDto.Id}");
        try
        {
            if (string.IsNullOrWhiteSpace(mehsulDto.Ad) || string.IsNullOrWhiteSpace(mehsulDto.StokKodu))
                return EmeliyyatNeticesi.Ugursuz("Məhsul adı və stok kodu boş ola bilməz.");
            string? qiymetXetasi = MehsulMelumatlariniYoxla(mehsulDto);
            if (qiymetXetasi != null)
                return EmeliyyatNeticesi.Ugursuz(qiymetXetasi);
            Mehsul movcudMehsul = await _unitOfWork.Mehsullar.GetirAsync(mehsulDto.Id);
            if (movcudMehsul == null)
            {
                Logger.XəbərdarlıqYaz("Məhsul tapılmadı");
                return EmeliyyatNeticesi.Ugursuz("Məhsul tapılmadı.");
            }

            // Stok kodunun başqa məhsulda istifadə olunmadığını yoxlayaq
            Mehsul? eyniKodluBasqaMehsul = (await _unitOfWork.Mehsullar.AxtarAsync(m => m.StokKodu == mehsulDto.StokKodu && m.Id != mehsulDto.Id)).FirstOrDefault();
            if (eyniKodluBasqaMehsul != null)
            {
                Logger.XəbərdarlıqYaz($"'{mehsulDto.StokKodu}' stok kodu başqa məhsulda istifadə olunur");
                return EmeliyyatNeticesi.Ugursuz($"'{mehsulDto.StokKodu}' stok kodu başqa məhsulda istifadə olunur.");
            }

            if (!string.IsNullOrWhiteSpace(mehsulDto.Barkod) &&
                (await _unitOfWork.Mehsullar.AxtarAsync(m => m.Barkod == mehsulDto.Barkod && m.Id != mehsulDto.Id)).Any())
                return EmeliyyatNeticesi.Ugursuz("Bu barkod artıq başqa məhsulda istifadə olunur.");

            movcudMehsul.Ad = mehsulDto.Ad.Trim();
            movcudMehsul.StokKodu = mehsulDto.StokKodu.Trim();
            movcudMehsul.Barkod = mehsulDto.Barkod?.Trim() ?? string.Empty;
            movcudMehsul.PerakendeSatisQiymeti = mehsulDto.PerakendeSatisQiymeti;
            movcudMehsul.TopdanSatisQiymeti = mehsulDto.TopdanSatisQiymeti;
            movcudMehsul.TekEdedSatisQiymeti = mehsulDto.TekEdedSatisQiymeti;
            movcudMehsul.AlisQiymeti = mehsulDto.AlisQiymeti;
            movcudMehsul.OlcuVahidi = mehsulDto.OlcuVahidi;
            movcudMehsul.MinimumStok = mehsulDto.MinimumStok;
            movcudMehsul.KateqoriyaId = mehsulDto.KateqoriyaId;
            movcudMehsul.BrendId = mehsulDto.BrendId;
            movcudMehsul.TedarukcuId = mehsulDto.TedarukcuId;


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

    private static string? MehsulMelumatlariniYoxla(MehsulDto mehsul)
    {
        if (mehsul.AlisQiymeti < 0 || mehsul.PerakendeSatisQiymeti < 0 ||
            mehsul.TopdanSatisQiymeti < 0 || mehsul.TekEdedSatisQiymeti < 0)
            return "Qiymətlər mənfi ola bilməz.";
        if (mehsul.MinimumStok < 0)
            return "Minimum stok mənfi ola bilməz.";
        if (mehsul.MinimumStok != decimal.Round(mehsul.MinimumStok, 3) ||
            mehsul.MovcudSay != decimal.Round(mehsul.MovcudSay, 3))
            return "Stok miqdarı ən çox üç onluq dəqiqlikdə olmalıdır.";
        if ((mehsul.OlcuVahidi == OlcuVahidi.Ədəd || mehsul.OlcuVahidi == OlcuVahidi.Paket) &&
            (mehsul.MinimumStok != decimal.Truncate(mehsul.MinimumStok) ||
             mehsul.MovcudSay != decimal.Truncate(mehsul.MovcudSay)))
            return "Ədəd və paket məhsulunun miqdarı tam ədəd olmalıdır.";
        return null;
    }

    /// <summary>
    /// Mövcud məhsulu silir.
    /// silinəcək məhsulun mövcud olub-olmadığını yoxlayır.
    /// diqqət: Məhsul silindikdən sonra onun bütün satış və alış tarixçələri silinmir, yalnız məhsulun özü silinir.
    /// Əgər məhsul satış və ya alış tarixçələrində istifadə olunubsa, bu əməliyyat uğursuz olacaq.
    /// </summary>
    public async Task<EmeliyyatNeticesi> MehsulSilAsync(int id)
    {
        if (!IcazeYoxlayici.Instance.IcazeVarmi(SistemIcazeleri.MehsulSil))
            return EmeliyyatNeticesi.Ugursuz("Məhsul silməyə icazəniz yoxdur.");
        Logger.MelumatYaz($"Məhsul silmə əməliyyatı başlayır. ID: {id}");
        try
        {
            Mehsul mehsul = await _unitOfWork.Mehsullar.GetirAsync(id);
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
            Random random = new();

            // Məhsul adından prefiks yarat (ilk sözün ilk 3 hərfi)
            string[] hisseler = mehsulAdi.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string prefix = hisseler.Length > 0 ? new string(hisseler[0].Take(3).ToArray()).ToUpper() : "SKU";

            // Yalnız hərflərdən ibarət olduğundan əmin ol
            prefix = Regex.Replace(prefix, @"[^A-Z]", "");
            if (prefix.Length == 0)
            {
                prefix = "SKU";
            }

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
            Random random = new();

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
            IEnumerable<Mehsul> butunMehsullar = await _unitOfWork.Mehsullar.AxtarAsync(m => m.Aktivdir);

            if (!string.IsNullOrWhiteSpace(axtarisMetni))
            {
                axtarisMetni = axtarisMetni.ToLower();
                butunMehsullar = butunMehsullar.Where(m =>
                    m.Ad.ToLower().Contains(axtarisMetni) ||
                    (m.StokKodu != null && m.StokKodu.ToLower().Contains(axtarisMetni)) ||
                    (m.Barkod != null && m.Barkod.Contains(axtarisMetni))
                );
            }

            List<MehsulDto> dtolar = butunMehsullar.Take(sayLimit).Select(m => new MehsulDto
            {
                Id = m.Id,
                Ad = m.Ad,
                Barkod = m.Barkod,
                StokKodu = m.StokKodu,
                AlisQiymeti = m.AlisQiymeti,
                PerakendeSatisQiymeti = m.PerakendeSatisQiymeti,
                TopdanSatisQiymeti = m.TopdanSatisQiymeti,
                TekEdedSatisQiymeti = m.TekEdedSatisQiymeti,
                MovcudSay = m.MovcudSay,
                AnbarMiqdari = m.MovcudSay,
                Aktivdir = m.Aktivdir,
                OlcuVahidi = m.OlcuVahidi,
                OlcuVahidiAdi = m.OlcuVahidi.ToString(),
                MinimumStok = m.MinimumStok,
                KateqoriyaId = m.KateqoriyaId,
                BrendId = m.BrendId,
                TedarukcuId = m.TedarukcuId,
                SekilYolu = m.SekilYolu
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
    public async Task<EmeliyyatNeticesi<SehifelenmisMelumat<MehsulDto>>> MehsullariSehifelenmisGetirAsync(SehifeParametrleri parametrler, string? axtarisMetni = null)
    {
        Logger.MelumatYaz($"Səhifələnmiş məhsullar əldə edilir - Səhifə: {parametrler.SehifeNomresi}, Ölçü: {parametrler.SehifeOlcusu}");
        try
        {
            string axtaris = axtarisMetni?.Trim() ?? string.Empty;
            (IEnumerable<Mehsul>? mehsullar, int umumiSay) = await _unitOfWork.Mehsullar.SehifelenmisGetirAsync(
                parametrler.SehifeNomresi,
                parametrler.SehifeOlcusu,
                m => m.Aktivdir && (axtaris == string.Empty ||
                    m.Ad.Contains(axtaris) ||
                    (m.StokKodu != null && m.StokKodu.Contains(axtaris)) ||
                    (m.Barkod != null && m.Barkod.Contains(axtaris))));

            List<MehsulDto> mehsulDtolar = mehsullar.Select(m => new MehsulDto
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
                OlcuVahidi = m.OlcuVahidi,
                Aktivdir = m.Aktivdir,
                MinimumStok = m.MinimumStok,
                KateqoriyaId = m.KateqoriyaId,
                BrendId = m.BrendId,
                TedarukcuId = m.TedarukcuId,
                SekilYolu = m.SekilYolu
            }).ToList();

            SehifelenmisMelumat<MehsulDto> sehifelenmis = new(
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
