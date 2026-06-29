// Fayl: AzAgroPOS.Mentiq/Idareciler/KateqoriyaMeneceri.cs

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Mentiq.Yardimcilar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;

namespace AzAgroPOS.Mentiq.Idareciler;
/// <summary>
/// Kateqoriya əməliyyatlarını idarə edən menecer.
/// Bu menecer kateqoriya yaratma, yeniləmə, silmə və axtarış əməliyyatlarını həyata keçirir.
/// </summary>
public class KateqoriyaMeneceri
{
    private readonly IUnitOfWork _unitOfWork;

    public KateqoriyaMeneceri(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Bütün kateqoriyaları DTO formatında gətirir.
    /// </summary>
    public async Task<EmeliyyatNeticesi<List<KateqoriyaDto>>> ButunKateqoriyalariGetirAsync()
    {
        Logger.MelumatYaz("ButunKateqoriyalariGetirAsync metodu çağırıldı.");
        Logger.MelumatYaz("Bütün kateqoriyaları gətiririk.");
        try
        {
            IEnumerable<Kateqoriya> kateqoriyalar = await _unitOfWork.Kateqoriyalar.ButununuGetirAsync();
            List<KateqoriyaDto> dtolar = kateqoriyalar.Select(k => new KateqoriyaDto
            {
                Id = k.Id,
                Ad = k.Ad,
                Tesvir = k.Tesvir,
                Aktivdir = k.Aktivdir
            }).ToList();

            return EmeliyyatNeticesi<List<KateqoriyaDto>>.Ugurlu(dtolar);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Kateqoriyaları gətirmək alınmadı: ");
            return EmeliyyatNeticesi<List<KateqoriyaDto>>.Ugursuz($"Kateqoriyaları gətirmək alınmadı: {ex.Message} + {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Verilmiş ID-yə görə kateqoriya məlumatlarını gətirir.
    /// </summary>
    public async Task<EmeliyyatNeticesi<KateqoriyaDto>> KateqoriyaGetirAsync(int id)
    {
        Logger.MelumatYaz($"KateqoriyaGetirAsync metodu çağırıldı. ID: {id}");
        try
        {
            Kateqoriya kateqoriya = await _unitOfWork.Kateqoriyalar.GetirAsync(id);
            if (kateqoriya == null)
            {
                return EmeliyyatNeticesi<KateqoriyaDto>.Ugursuz("Kateqoriya tapılmadı.");
            }

            KateqoriyaDto dto = new()
            {
                Id = kateqoriya.Id,
                Ad = kateqoriya.Ad,
                Tesvir = kateqoriya.Tesvir,
                Aktivdir = kateqoriya.Aktivdir
            };

            return EmeliyyatNeticesi<KateqoriyaDto>.Ugurlu(dto);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Kateqoriya məlumatlarını gətirmək alınmadı: ");
            return EmeliyyatNeticesi<KateqoriyaDto>.Ugursuz($"Kateqoriya məlumatlarını gətirmək alınmadı: {ex.Message} + {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Yeni kateqoriya yaradır.
    /// </summary>
    public async Task<EmeliyyatNeticesi<int>> KateqoriyaYaratAsync(KateqoriyaDto dto)
    {
        Logger.MelumatYaz("KateqoriyaYaratAsync metodu çağırıldı.");
        Logger.MelumatYaz(dto.ToString());
        try
        {
            // Validasiya
            if (string.IsNullOrWhiteSpace(dto.Ad))
            {
                return EmeliyyatNeticesi<int>.Ugursuz("Kateqoriya adı boş ola bilməz.");
            }

            // Yeni kateqoriya obyekti yaradırıq
            Kateqoriya yeniKateqoriya = new()
            {
                Ad = dto.Ad,
                Tesvir = dto.Tesvir,
                Aktivdir = dto.Aktivdir
            };

            await _unitOfWork.Kateqoriyalar.ElaveEtAsync(yeniKateqoriya);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi<int>.Ugurlu(yeniKateqoriya.Id);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Kateqoriya yaratmaq alınmadı: ");
            return EmeliyyatNeticesi<int>.Ugursuz($"Kateqoriya yaratmaq alınmadı: {ex.Message} + {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Mövcud kateqoriyanın məlumatlarını yeniləyir.
    /// </summary>
    public async Task<EmeliyyatNeticesi> KateqoriyaYenileAsync(KateqoriyaDto dto)
    {
        Logger.MelumatYaz(dto.ToString());
        try
        {
            Kateqoriya movcudKateqoriya = await _unitOfWork.Kateqoriyalar.GetirAsync(dto.Id);
            if (movcudKateqoriya == null)
            {
                return EmeliyyatNeticesi.Ugursuz("Yenilənmək üçün kateqoriya tapılmadı.");
            }

            // Validasiya
            if (string.IsNullOrWhiteSpace(dto.Ad))
            {
                return EmeliyyatNeticesi.Ugursuz("Kateqoriya adı boş ola bilməz.");
            }

            // Məlumatları yeniləyirik
            movcudKateqoriya.Ad = dto.Ad;
            movcudKateqoriya.Tesvir = dto.Tesvir;
            movcudKateqoriya.Aktivdir = dto.Aktivdir;

            _unitOfWork.Kateqoriyalar.Yenile(movcudKateqoriya);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Kateqoriya məlumatlarını yeniləmək alınmadı: ");
            return EmeliyyatNeticesi.Ugursuz($"Kateqoriya məlumatlarını yeniləmək alınmadı: {ex.Message} + {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Kateqoriya silir.
    /// </summary>
    public async Task<EmeliyyatNeticesi> KateqoriyaSilAsync(int id)
    {
        Logger.MelumatYaz($"KateqoriyaSilAsync metodu çağırıldı. ID: {id}");
        try
        {
            Kateqoriya kateqoriya = await _unitOfWork.Kateqoriyalar.GetirAsync(id);
            if (kateqoriya == null)
            {
                return EmeliyyatNeticesi.Ugursuz("Silinəcək kateqoriya tapılmadı.");
            }

            _unitOfWork.Kateqoriyalar.Sil(kateqoriya);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Kateqoriya silmək alınmadı: ");
            return EmeliyyatNeticesi.Ugursuz($"Kateqoriya silmək alınmadı: {ex.Message} + {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Səhifələnmiş kateqoriya siyahısını əldə edir.
    /// Diqqət: Bu metod böyük məlumat bazaları üçün əlverişlidir.
    /// </summary>
    /// <param name="parametrler">Səhifələmə parametrləri</param>
    /// <returns>Səhifələnmiş kateqoriya məlumatları</returns>
    public async Task<EmeliyyatNeticesi<SehifelenmisMelumat<KateqoriyaDto>>> KateqoriyalariSehifelenmisGetirAsync(SehifeParametrleri parametrler)
    {
        Logger.MelumatYaz($"Səhifələnmiş kateqoriyalar əldə edilir - Səhifə: {parametrler.SehifeNomresi}, Ölçü: {parametrler.SehifeOlcusu}");
        try
        {
            (IEnumerable<Kateqoriya>? kateqoriyalar, int umumiSay) = await _unitOfWork.Kateqoriyalar.SehifelenmisGetirAsync(
                parametrler.SehifeNomresi,
                parametrler.SehifeOlcusu,
                k => k.Aktivdir);

            List<KateqoriyaDto> dtolar = kateqoriyalar.Select(k => new KateqoriyaDto
            {
                Id = k.Id,
                Ad = k.Ad,
                Tesvir = k.Tesvir,
                Aktivdir = k.Aktivdir
            }).ToList();

            SehifelenmisMelumat<KateqoriyaDto> sehifelenmis = new(
                dtolar, umumiSay, parametrler.SehifeNomresi, parametrler.SehifeOlcusu);

            Logger.MelumatYaz($"Səhifələnmiş kateqoriyalar uğurla əldə edildi - {dtolar.Count}/{umumiSay}");
            return EmeliyyatNeticesi<SehifelenmisMelumat<KateqoriyaDto>>.Ugurlu(sehifelenmis);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Səhifələnmiş kateqoriyalar əldə edilərkən istisna baş verdi");
            return EmeliyyatNeticesi<SehifelenmisMelumat<KateqoriyaDto>>.Ugursuz($"Səhifələnmiş kateqoriyalar əldə edilərkən xəta: {ex.Message} + {ex.StackTrace}");
        }
    }
}