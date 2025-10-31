// AzAgroPOS.Mentiq/Idareciler/IcazeManager.cs
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
/// İstifadəçilərin ayrı-ayrı icazələrini idarə edən menecer
/// </summary>
public class IcazeManager
{
    private readonly IUnitOfWork _unitOfWork;

    public IcazeManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// İstifadəçinin müəyyən bir icazəyə sahib olub-olmadığını yoxlayır
    /// </summary>
    /// <param name="istifadeciId">İstifadəçinin ID-si</param>
    /// <param name="icaeAdi">Yoxlanılacaq icazənin adı</param>
    /// <returns>İstifadəçinin icazəyə sahib olub-olmaması</returns>
    public async Task<EmeliyyatNeticesi<bool>> IstifadecininIcazesiVarAsync(int istifadeciId, string icaeAdi)
    {
        Logger.MelumatYaz($"İstifadəçi ID-si: {istifadeciId}, İcazə adı: {icaeAdi} üçün icazə yoxlanılır.");
        try
        {
            // İstifadəçini götürürük
            var istifadeci = await _unitOfWork.Istifadeciler.GetirAsync(istifadeciId);
            if (istifadeci == null)
            {
                return EmeliyyatNeticesi<bool>.Ugursuz("İstifadəçi tapılmadı");
            }

            // Admin istifadəçisinin bütün icazələri var
            if (istifadeci.RolId == 1) // 1 - Admin rolu
            {
                return EmeliyyatNeticesi<bool>.Ugurlu(true);
            }

            // İstifadəçinin roluna aid icazələri yoxlayırıq
            var rolIcazeleri = await _unitOfWork.RolIcazeleri.AxtarAsync(ri => ri.RolId == istifadeci.RolId);
            var icazeIdleri = rolIcazeleri.Select(ri => ri.IcazeId).ToList();

            if (!icazeIdleri.Any())
            {
                return EmeliyyatNeticesi<bool>.Ugurlu(false);
            }

            // İcazələri götürüb axtarırıq
            var icazeler = await _unitOfWork.Icazeler.AxtarAsync(i => icazeIdleri.Contains(i.Id) && i.Ad == icaeAdi);
            var icazeVar = icazeler.Any();

            return EmeliyyatNeticesi<bool>.Ugurlu(icazeVar);
        }
        catch (System.Exception ex)
        {
            Logger.XetaYaz(ex, "İcazə yoxlanılması zamanı xəta baş verdi: ");
            return EmeliyyatNeticesi<bool>.Ugursuz($"İcazə yoxlanılması zamanı xəta baş verdi: {ex.Message}+ {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Bütün mövcud icazələri götürür
    /// </summary>
    /// <returns>Bütün icazələrin siyahısı</returns>
    public async Task<EmeliyyatNeticesi<IEnumerable<IcazeDto>>> ButunIcazeleriGetirAsync()
    {
        Logger.MelumatYaz("Bütün icazələr götürülür.");
        try
        {
            var icazeler = await _unitOfWork.Icazeler.ButununuGetirAsync();
            var icazeDtos = icazeler.Select(i => new IcazeDto
            {
                Id = i.Id,
                Ad = i.Ad,
                Tesvir = i.Tesvir
            });

            return EmeliyyatNeticesi<IEnumerable<IcazeDto>>.Ugurlu(icazeDtos);
        }
        catch (System.Exception ex)
        {
            Logger.XetaYaz(ex, "İcazələr götürülərkən xəta baş verdi: ");
            return EmeliyyatNeticesi<IEnumerable<IcazeDto>>.Ugursuz($"İcazələr götürülərkən xəta baş verdi: {ex.Message}+ {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Bir rol üçün icazələri təyin edir
    /// </summary>
    /// <param name="rolId">Rolun ID-si</param>
    /// <param name="icazeIdleri">Təyin ediləcək icazələrin ID-ləri</param>
    /// <returns>Əməliyyat nəticəsi</returns>
    public async Task<EmeliyyatNeticesi> RolIcazeleriniTeyinEtAsync(int rolId, IEnumerable<int> icazeIdleri)
    {
        Logger.MelumatYaz($"Rol ID-si: {rolId} üçün icazələr təyin edilir.");
        try
        {
            // Mövcud rol icazələrini silirik
            var movcudRolIcazeleri = await _unitOfWork.RolIcazeleri.AxtarAsync(ri => ri.RolId == rolId);
            foreach (var rolIcazesi in movcudRolIcazeleri)
            {
                _unitOfWork.RolIcazeleri.Sil(rolIcazesi);
            }

            // Yeni rol icazələrini əlavə edirik
            foreach (var icazeId in icazeIdleri)
            {
                var yeniRolIcazesi = new RolIcazesi
                {
                    RolId = rolId,
                    IcazeId = icazeId
                };
                await _unitOfWork.RolIcazeleri.ElaveEtAsync(yeniRolIcazesi);
            }

            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (System.Exception ex)
        {
            Logger.XetaYaz(ex, "Rol icazələri təyin edilərkən xəta baş verdi: ");
            return EmeliyyatNeticesi.Ugursuz($"Rol icazələri təyin edilərkən xəta baş verdi: {ex.Message}+ {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Bir rol üçün təyin edilmiş icazələri götürür
    /// </summary>
    /// <param name="rolId">Rolun ID-si</param>
    /// <returns>Rol üçün təyin edilmiş icazələrin siyahısı</returns>
    public async Task<EmeliyyatNeticesi<IEnumerable<IcazeDto>>> RolIcazeleriniGetirAsync(int rolId)
    {
        Logger.MelumatYaz($"Rol ID-si: {rolId} üçün icazələr götürülür.");
        try
        {
            var rolIcazeleri = await _unitOfWork.RolIcazeleri.AxtarAsync(ri => ri.RolId == rolId);
            var icazeIdleri = rolIcazeleri.Select(ri => ri.IcazeId).ToList();

            if (!icazeIdleri.Any())
            {
                return EmeliyyatNeticesi<IEnumerable<IcazeDto>>.Ugurlu(new List<IcazeDto>());
            }

            var icazeler = await _unitOfWork.Icazeler.AxtarAsync(i => icazeIdleri.Contains(i.Id));
            var icazeDtos = icazeler.Select(i => new IcazeDto
            {
                Id = i.Id,
                Ad = i.Ad,
                Tesvir = i.Tesvir
            });

            return EmeliyyatNeticesi<IEnumerable<IcazeDto>>.Ugurlu(icazeDtos);
        }
        catch (System.Exception ex)
        {
            Logger.XetaYaz(ex, "Rol icazələri götürülərkən xəta baş verdi: ");
            return EmeliyyatNeticesi<IEnumerable<IcazeDto>>.Ugursuz($"Rol icazələri götürülərkən xəta baş verdi: {ex.Message}+ {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Səhifələnmiş icazə siyahısını əldə edir.
    /// Diqqət: Bu metod böyük məlumat bazaları üçün əlverişlidir.
    /// </summary>
    /// <param name="parametrler">Səhifələmə parametrləri</param>
    /// <returns>Səhifələnmiş icazə məlumatları</returns>
    public async Task<EmeliyyatNeticesi<SehifelenmisMelumat<IcazeDto>>> IcazeleriSehifelenmisGetirAsync(SehifeParametrleri parametrler)
    {
        Logger.MelumatYaz($"Səhifələnmiş icazələr əldə edilir - Səhifə: {parametrler.SehifeNomresi}, Ölçü: {parametrler.SehifeOlcusu}");
        try
        {
            var (icazeler, umumiSay) = await _unitOfWork.Icazeler.SehifelenmisGetirAsync(
                parametrler.SehifeNomresi,
                parametrler.SehifeOlcusu,
                i => true);

            var dtolar = icazeler.Select(i => new IcazeDto
            {
                Id = i.Id,
                Ad = i.Ad,
                Tesvir = i.Tesvir
            }).ToList();

            var sehifelenmis = new SehifelenmisMelumat<IcazeDto>(
                dtolar, umumiSay, parametrler.SehifeNomresi, parametrler.SehifeOlcusu);

            Logger.MelumatYaz($"Səhifələnmiş icazələr uğurla əldə edildi - {dtolar.Count}/{umumiSay}");
            return EmeliyyatNeticesi<SehifelenmisMelumat<IcazeDto>>.Ugurlu(sehifelenmis);
        }
        catch (System.Exception ex)
        {
            Logger.XetaYaz(ex, "Səhifələnmiş icazələr əldə edilərkən istisna baş verdi");
            return EmeliyyatNeticesi<SehifelenmisMelumat<IcazeDto>>.Ugursuz($"Səhifələnmiş icazələr əldə edilərkən xəta: {ex.Message}+ {ex.StackTrace}");
        }
    }
}