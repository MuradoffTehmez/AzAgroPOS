// Fayl: AzAgroPOS.Mentiq/Idareciler/IstifadeciManager.cs
namespace AzAgroPOS.Mentiq.Idareciler;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Mentiq.Yardimcilar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// İstifadəçilərlə bağlı əməliyyatları idarə edən menecer.
/// </summary>
public class IstifadeciManager
{
    private readonly IUnitOfWork _unitOfWork;
    public IstifadeciManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    ///  İstifadəçilərin siyahısını DTO formatında gətirir.
    ///  diqqət: Bu metod bütün istifadəçiləri gətirir, lakin əsas admini (id = 1) istisna edir.
    ///  burada istifadəçilərin rollarını da əlavə edirik ki, hansı istifadəçinin hansı rolda olduğunu görə bilək.
    /// </summary>
    /// <returns></returns>
    public async Task<EmeliyyatNeticesi<List<IstifadeciDto>>> IstifadecileriGetirAsync()
    {
        Logger.MelumatYaz("IstifadecileriGetirAsync metodu çağırıldı.");
        Logger.MelumatYaz("Əsas admini (id = 1) istisna edirik.");
        try
        {
            var istifadeciler = await _unitOfWork.Istifadeciler.ButununuGetirAsync();
            var rollar = await _unitOfWork.Rollar.ButununuGetirAsync();

            var dtolar = istifadeciler.Select(i => new IstifadeciDto
            {
                Id = i.Id,
                IstifadeciAdi = i.IstifadeciAdi,
                TamAd = i.TamAd,
                RolAdi = rollar.FirstOrDefault(r => r.Id == i.RolId)?.Ad ?? "Təyinatsız"
            }).ToList();

            return EmeliyyatNeticesi<List<IstifadeciDto>>.Ugurlu(dtolar);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Istifadəçiləri yaratmaq alınmadı: ");
            return EmeliyyatNeticesi<List<IstifadeciDto>>.Ugursuz($"Istifadəçiləri yaratmaq alınmadı: {ex.Message} + {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Bütün istifadəçiləri gətirir (əsas admin daxil olmaqla).
    /// </summary>
    /// <returns></returns>
    public async Task<List<Istifadeci>> ButunIstifadecileriGetirAsync()
    {
        return (await _unitOfWork.Istifadeciler.ButununuGetirAsync()).ToList();
    }

    /// <summary>
    /// Bütün rolları gətirir.
    /// </summary>
    /// <returns></returns>
    public async Task<List<Rol>> ButunRollarGetirAsync()
    {
        return (await _unitOfWork.Rollar.ButununuGetirAsync()).ToList();
    }

    /// <summary>
    /// İstifadəçi yaratmaq üçün metod. Asinxron olaraq işləyir və yeni istifadəçi məlumatlarını alır.
    /// diqqət: İstifadəçi adı və parol boş olmamalıdır, və istifadəçi adı unikal olmalıdır.
    /// Əsas admini (id = 1) yaratmaq mümkün deyil.
    /// Parol hash formatında saxlanılır.
    /// bcrypt kitabxanasından istifadə olunur.
    /// </summary>
    /// <param name="yeniIstifadeci"></param>
    /// <param name="parol"></param>
    /// <returns></returns>
    public async Task<EmeliyyatNeticesi> IstifadeciYaratAsync(IstifadeciDto yeniIstifadeci, string parol)
    {
        Logger.MelumatYaz("IstifadeciYaratAsync metodu çağırıldı.");
        Logger.MelumatYaz(yeniIstifadeci.ToString());
        Logger.MelumatYaz(parol.ToLower());

        try
        {
            if (string.IsNullOrWhiteSpace(yeniIstifadeci.IstifadeciAdi) || string.IsNullOrWhiteSpace(parol))
                return EmeliyyatNeticesi.Ugursuz("İstifadəçi adı və parol boş ola bilməz.");

            var movcudIstifadeci = (await _unitOfWork.Istifadeciler.AxtarAsync(i => i.IstifadeciAdi == yeniIstifadeci.IstifadeciAdi)).FirstOrDefault();
            if (movcudIstifadeci != null)
                return EmeliyyatNeticesi.Ugursuz("Bu istifadəçi adı artıq mövcuddur.");

            var istifadeci = new Istifadeci
            {
                IstifadeciAdi = yeniIstifadeci.IstifadeciAdi,
                TamAd = yeniIstifadeci.TamAd,
                RolId = yeniIstifadeci.RolId,
                ParolHash = BCrypt.Net.BCrypt.HashPassword(parol)
            };

            await _unitOfWork.Istifadeciler.ElaveEtAsync(istifadeci);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Istifadəçiləri yaratmaq alınmadı: ");
            return EmeliyyatNeticesi<List<IstifadeciDto>>.Ugursuz($"Istifadəçiləri yaratmaq alınmadı: {ex.Message} + {ex.StackTrace}");
        }
    }
    /// <summary>
    ///  İstifadəçi məlumatlarını yeniləmək üçün metod. Asinxron olaraq işləyir.
    ///  diqqət: İstifadəçi adı və parol boş olmamalıdır, və istifadəçi adı unikal olmalıdır.
    ///  əsas admini (id = 1) yeniləmək mümkün deyil.
    ///  dəqiq istifadəçi ID-si verilməlidir.
    ///  Administratoru yeniləmək üçün istifadəçi ID-si 1 olmamalıdır.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<EmeliyyatNeticesi> IstifadeciSilAsync(int id)
    {
        Logger.MelumatYaz("IstifadeciSilAsync metodu çağırıldı.");
        Logger.MelumatYaz(id.ToString());
        try
        {
            if (id == 1) // Əsas admini silməyin qarşısını alırıq
                return EmeliyyatNeticesi.Ugursuz("Əsas Administratoru silmək olmaz.");

            var istifadeci = await _unitOfWork.Istifadeciler.GetirAsync(id);
            if (istifadeci == null)
                return EmeliyyatNeticesi.Ugursuz("İstifadəçi tapılmadı.");

            _unitOfWork.Istifadeciler.Sil(istifadeci);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Istifadəçiləri silmək alınmadı: ");
            return EmeliyyatNeticesi<List<IstifadeciDto>>.Ugursuz($"Istifadəçiləri silmək alınmadı: {ex.Message} + {ex.StackTrace}");
        }
    }
    /// <summary>
    /// Mövcud istifadəçinin məlumatlarını (Tam Ad, Rol, Parol) yeniləyir.
    /// </summary>
    /// <param name="istifadeciDto">Yenilənəcək məlumatları daşıyan DTO.</param>
    /// <param name="yeniParol">Əgər dəyişdirilirsə, yeni parol. Boş olarsa, parol dəyişməz.</param>
    /// <returns>Əməliyyatın nəticəsi.</returns>
    public async Task<EmeliyyatNeticesi> IstifadeciYenileAsync(IstifadeciDto istifadeciDto, string? yeniParol)
    {
        Logger.MelumatYaz("IstifadeciYenileAsync metodu çağırıldı.");
        Logger.MelumatYaz(istifadeciDto.ToString());
        Logger.MelumatYaz(yeniParol?.ToLower() ?? "Yeni parol daxil edilməyib.");
        try
        {
            if (string.IsNullOrWhiteSpace(istifadeciDto.TamAd))
                return EmeliyyatNeticesi.Ugursuz("Tam ad boş ola bilməz.");

            var movcudIstifadeci = await _unitOfWork.Istifadeciler.GetirAsync(istifadeciDto.Id);
            if (movcudIstifadeci == null)
                return EmeliyyatNeticesi.Ugursuz("Yenilənmək üçün istifadəçi tapılmadı.");

            // Əsas adminin məlumatlarının dəyişdirilməsinin qarşısını alırıq
            if (movcudIstifadeci.Id == 1 && istifadeciDto.RolId != 1)
                return EmeliyyatNeticesi.Ugursuz("Əsas Administratorun rolu dəyişdirilə bilməz.");

            movcudIstifadeci.TamAd = istifadeciDto.TamAd;
            movcudIstifadeci.RolId = istifadeciDto.RolId;

            // Əgər yeni parol daxil edilibsə, onu hash-ləyib yeniləyirik
            if (!string.IsNullOrWhiteSpace(yeniParol))
            {
                movcudIstifadeci.ParolHash = BCrypt.Net.BCrypt.HashPassword(yeniParol);
            }

            _unitOfWork.Istifadeciler.Yenile(movcudIstifadeci);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Istifadəçiləri yeniləmək alınmadı: ");
            return EmeliyyatNeticesi<List<IstifadeciDto>>.Ugursuz($"Istifadəçiləri gətirmək alınmadı: {ex.Message} + {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Bütün texnikləri (usta) gətirir.
    /// </summary>
    /// <returns></returns>
    public async Task<EmeliyyatNeticesi<List<IstifadeciDto>>> ButunTexnikleriGetirAsync()
    {
        Logger.MelumatYaz("ButunTexnikleriGetirAsync metodu çağırıldı.");
        try
        {
            var istifadeciler = await _unitOfWork.Istifadeciler.ButununuGetirAsync();
            var rollar = await _unitOfWork.Rollar.ButununuGetirAsync();

            // "Texnik" və ya "Usta" rolu olan istifadəçiləri gətiririk
            var texnikler = istifadeciler.Where(i =>
                rollar.FirstOrDefault(r => r.Id == i.RolId)?.Ad == "Texnik" ||
                rollar.FirstOrDefault(r => r.Id == i.RolId)?.Ad == "Usta").ToList();

            var dtolar = texnikler.Select(i => new IstifadeciDto
            {
                Id = i.Id,
                IstifadeciAdi = i.IstifadeciAdi,
                TamAd = i.TamAd,
                RolAdi = rollar.FirstOrDefault(r => r.Id == i.RolId)?.Ad ?? "Təyinatsız"
            }).ToList();

            return EmeliyyatNeticesi<List<IstifadeciDto>>.Ugurlu(dtolar);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Texnikləri gətirmək alınmadı: ");
            return EmeliyyatNeticesi<List<IstifadeciDto>>.Ugursuz($"Texnikləri gətirmək alınmadı: {ex.Message} + {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Səhifələnmiş istifadəçi siyahısını əldə edir.
    /// Diqqət: Bu metod böyük məlumat bazaları üçün əlverişlidir.
    /// </summary>
    /// <param name="parametrler">Səhifələmə parametrləri</param>
    /// <returns>Səhifələnmiş istifadəçi məlumatları</returns>
    public async Task<EmeliyyatNeticesi<SehifelenmisMelumat<IstifadeciDto>>> IstifadecileriSehifelenmisGetirAsync(SehifeParametrleri parametrler)
    {
        Logger.MelumatYaz($"Səhifələnmiş istifadəçilər əldə edilir - Səhifə: {parametrler.SehifeNomresi}, Ölçü: {parametrler.SehifeOlcusu}");
        try
        {
            var (istifadeciler, umumiSay) = await _unitOfWork.Istifadeciler.SehifelenmisGetirAsync(
                parametrler.SehifeNomresi,
                parametrler.SehifeOlcusu,
                i => true);

            var rollar = await _unitOfWork.Rollar.ButununuGetirAsync();

            var dtolar = istifadeciler.Select(i => new IstifadeciDto
            {
                Id = i.Id,
                IstifadeciAdi = i.IstifadeciAdi,
                TamAd = i.TamAd,
                RolAdi = rollar.FirstOrDefault(r => r.Id == i.RolId)?.Ad ?? "Təyinatsız"
            }).ToList();

            var sehifelenmis = new SehifelenmisMelumat<IstifadeciDto>(
                dtolar, umumiSay, parametrler.SehifeNomresi, parametrler.SehifeOlcusu);

            Logger.MelumatYaz($"Səhifələnmiş istifadəçilər uğurla əldə edildi - {dtolar.Count}/{umumiSay}");
            return EmeliyyatNeticesi<SehifelenmisMelumat<IstifadeciDto>>.Ugurlu(sehifelenmis);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Səhifələnmiş istifadəçilər əldə edilərkən istisna baş verdi");
            return EmeliyyatNeticesi<SehifelenmisMelumat<IstifadeciDto>>.Ugursuz($"Səhifələnmiş istifadəçilər əldə edilərkən xəta: {ex.Message} + {ex.StackTrace}");
        }
    }
}