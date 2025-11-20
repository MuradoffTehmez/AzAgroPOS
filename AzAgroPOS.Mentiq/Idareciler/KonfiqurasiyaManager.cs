// AzAgroPOS.Mentiq/Idareciler/KonfiqurasiyaManager.cs
using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Mentiq.Yardimcilar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;

namespace AzAgroPOS.Mentiq.Idareciler;

/// <summary>
/// Tətbiqat konfiqurasiya parametrlərini idarə edən menecer
/// </summary>
public class KonfiqurasiyaManager
{
    private readonly IUnitOfWork _unitOfWork;

    public KonfiqurasiyaManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Açar adı ilə konfiqurasiya parametrini götürür
    /// </summary>
    /// <param name="acar">Konfiqurasiya açarı</param>
    /// <returns>Konfiqurasiya DTO obyekti</returns>
    public async Task<EmeliyyatNeticesi<KonfiqurasiyaDto>> AcarlaGetirAsync(string acar)
    {

        Logger.MelumatYaz(acar);
        try
        {
            var konfiqurasiya = await _unitOfWork.Konfiqurasiyalar.AcarlaGetirAsync(acar);

            if (konfiqurasiya == null)
            {
                return EmeliyyatNeticesi<KonfiqurasiyaDto>.Ugursuz("Konfiqurasiya parametri tapılmadı");
            }

            var dto = new KonfiqurasiyaDto
            {
                Id = konfiqurasiya.Id,
                Acar = konfiqurasiya.Acar,
                Deyer = konfiqurasiya.Deyer,
                Tesvir = konfiqurasiya.Tesvir,
                Qrup = konfiqurasiya.Qrup
            };

            return EmeliyyatNeticesi<KonfiqurasiyaDto>.Ugurlu(dto);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Konfiqurasiya parametri götürülərkən xəta baş verdi: ");
            return EmeliyyatNeticesi<KonfiqurasiyaDto>.Ugursuz($"Konfiqurasiya parametri götürülərkən xəta baş verdi: {ex.Message}+ {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Qrupa görə konfiqurasiya parametrlərini götürür
    /// </summary>
    /// <param name="qrup">Konfiqurasiya qrupu</param>
    /// <returns>Konfiqurasiya DTO obyektlərinin siyahısı</returns>
    public async Task<EmeliyyatNeticesi<IEnumerable<KonfiqurasiyaDto>>> QruplaGetirAsync(string qrup)
    {
        Logger.MelumatYaz(qrup);
        try
        {
            var konfiqurasiyalar = await _unitOfWork.Konfiqurasiyalar.QruplaGetirAsync(qrup);

            var dtos = konfiqurasiyalar.Select(k => new KonfiqurasiyaDto
            {
                Id = k.Id,
                Acar = k.Acar,
                Deyer = k.Deyer,
                Tesvir = k.Tesvir,
                Qrup = k.Qrup
            });

            return EmeliyyatNeticesi<IEnumerable<KonfiqurasiyaDto>>.Ugurlu(dtos);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Konfiqurasiya parametrləri götürülərkən xəta baş verdi: ");
            return EmeliyyatNeticesi<IEnumerable<KonfiqurasiyaDto>>.Ugursuz($"Konfiqurasiya parametrləri götürülərkən xəta baş verdi: {ex.Message} + {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Konfiqurasiya parametrini yaradır və ya yeniləyir
    /// </summary>
    /// <param name="dto">Konfiqurasiya DTO obyekti</param>
    /// <returns>Əməliyyat nəticəsi</returns>
    public async Task<EmeliyyatNeticesi<bool>> KonfiqurasiyaElaveEtVəYaYenileAsync(KonfiqurasiyaDto dto)
    {

        try
        {
            var movcudKonfiqurasiya = await _unitOfWork.Konfiqurasiyalar.AcarlaGetirAsync(dto.Acar);

            if (movcudKonfiqurasiya == null)
            {
                // Yeni konfiqurasiya yaradırıq
                var yeniKonfiqurasiya = new Konfiqurasiya
                {
                    Acar = dto.Acar,
                    Deyer = dto.Deyer,
                    Tesvir = dto.Tesvir,
                    Qrup = dto.Qrup
                };

                await _unitOfWork.Konfiqurasiyalar.ElaveEtAsync(yeniKonfiqurasiya);
            }
            else
            {
                // Mövcud konfiqurasiyanı yeniləyirik
                movcudKonfiqurasiya.Deyer = dto.Deyer;
                movcudKonfiqurasiya.Tesvir = dto.Tesvir;
                movcudKonfiqurasiya.Qrup = dto.Qrup;

                _unitOfWork.Konfiqurasiyalar.Yenile(movcudKonfiqurasiya);
            }

            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi<bool>.Ugurlu(true);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Konfiqurasiya parametri saxlanılarkən xəta baş verdi: ");
            return EmeliyyatNeticesi<bool>.Ugursuz($"Konfiqurasiya parametri saxlanılarkən xəta baş verdi: {ex.Message} + {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Bütün konfiqurasiya parametrlərini götürür
    /// </summary>
    /// <returns>Bütün konfiqurasiya DTO obyektlərinin siyahısı</returns>
    public async Task<EmeliyyatNeticesi<IEnumerable<KonfiqurasiyaDto>>> ButununuGetirAsync()
    {
        try
        {
            var konfiqurasiyalar = await _unitOfWork.Konfiqurasiyalar.ButununuGetirAsync();

            var dtos = konfiqurasiyalar.Select(k => new KonfiqurasiyaDto
            {
                Id = k.Id,
                Acar = k.Acar,
                Deyer = k.Deyer,
                Tesvir = k.Tesvir,
                Qrup = k.Qrup
            });

            return EmeliyyatNeticesi<IEnumerable<KonfiqurasiyaDto>>.Ugurlu(dtos);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Konfiqurasiya parametrləri götürülərkən xəta baş verdi: ");
            return EmeliyyatNeticesi<IEnumerable<KonfiqurasiyaDto>>.Ugursuz($"Konfiqurasiya parametrləri götürülərkən xəta baş verdi: {ex.Message} + {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Konfiqurasiya dəyərini götürür, tapılmazsa varsayılan dəyəri qaytarır
    /// </summary>
    /// <param name="acar">Konfiqurasiya açarı</param>
    /// <param name="varsayilan">Varsayılan dəyər</param>
    /// <returns>Konfiqurasiya dəyəri və ya varsayılan dəyər</returns>
    public async Task<string> GetirAsync(string acar, string varsayilan = "")
    {
        try
        {
            var netice = await AcarlaGetirAsync(acar);
            return netice.UgurluDur && netice.Data != null ? netice.Data.Deyer : varsayilan;
        }
        catch (Exception)
        {
            return varsayilan;
        }
    }

    /// <summary>
    /// Konfiqurasiya dəyərini təyin edir
    /// </summary>
    /// <param name="acar">Konfiqurasiya açarı</param>
    /// <param name="deyer">Konfiqurasiya dəyəri</param>
    /// <param name="tesvir">Konfiqurasiya təsviri (opsional)</param>
    /// <param name="qrup">Konfiqurasiya qrupu (opsional)</param>
    /// <returns>Əməliyyat nəticəsi</returns>
    public async Task<EmeliyyatNeticesi<bool>> SetAsync(string acar, string deyer, string tesvir = "", string qrup = "")
    {
        var dto = new KonfiqurasiyaDto
        {
            Acar = acar,
            Deyer = deyer,
            Tesvir = tesvir,
            Qrup = qrup
        };

        return await KonfiqurasiyaElaveEtVəYaYenileAsync(dto);
    }

    /// <summary>
    /// Çoxlu konfiqurasiya parametrlərini bir əməliyyatda saxlayır (batch operation)
    /// </summary>
    /// <param name="parametrler">Saxlanılacaq parametrlər (açar-dəyər cütləri)</param>
    /// <returns>Əməliyyat nəticəsi</returns>
    public async Task<EmeliyyatNeticesi<bool>> TopluSaxlaAsync(Dictionary<string, string> parametrler)
    {
        try
        {
            foreach (var parametr in parametrler)
            {
                var movcudKonfiqurasiya = await _unitOfWork.Konfiqurasiyalar.AcarlaGetirAsync(parametr.Key);

                if (movcudKonfiqurasiya == null)
                {
                    // Yeni konfiqurasiya yaradırıq
                    var yeniKonfiqurasiya = new Konfiqurasiya
                    {
                        Acar = parametr.Key,
                        Deyer = parametr.Value,
                        Tesvir = "",
                        Qrup = ""
                    };

                    await _unitOfWork.Konfiqurasiyalar.ElaveEtAsync(yeniKonfiqurasiya);
                }
                else
                {
                    // Mövcud konfiqurasiyanı yeniləyirik
                    movcudKonfiqurasiya.Deyer = parametr.Value;
                    _unitOfWork.Konfiqurasiyalar.Yenile(movcudKonfiqurasiya);
                }
            }

            // Bütün dəyişiklikləri bir əməliyyatda tətbiq edirik
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi<bool>.Ugurlu(true);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Konfiqurasiya parametrləri toplu saxlanılarkən xəta baş verdi: ");
            return EmeliyyatNeticesi<bool>.Ugursuz($"Konfiqurasiya parametrləri saxlanılarkən xəta baş verdi: {ex.Message}");
        }
    }
}