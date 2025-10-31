// Fayl: AzAgroPOS.Mentiq/Idareciler/IsciManager.cs
namespace AzAgroPOS.Mentiq.Idareciler;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Mentiq.Yardimcilar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// İşçilərlə bağlı biznes məntiqini idarə edən menecer.
/// </summary>
public class IsciManager
{
    private readonly IUnitOfWork _unitOfWork;

    public IsciManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Bütün işçiləri DTO formatında gətirir.
    /// </summary>
    public async Task<EmeliyyatNeticesi<List<IsciDto>>> ButunIscileriGetirAsync()
    {
        Logger.MelumatYaz("ButunIscileriGetirAsync metodu çağırıldı.");
        Logger.MelumatYaz("Bütün işçilər gətirilir.");
        try
        {
            var isciler = await _unitOfWork.Isciler.ButununuGetirAsync();
            var dtolar = isciler.Select(i => new IsciDto
            {
                Id = i.Id,
                TamAd = i.TamAd,
                DogumTarixi = i.DogumTarixi,
                TelefonNomresi = i.TelefonNomresi,
                Unvan = i.Unvan,
                Email = i.Email,
                IseBaslamaTarixi = i.IseBaslamaTarixi,
                Maas = i.Maas,
                Vezife = i.Vezife,
                Departament = i.Departament,
                Status = i.Status,
                SvsNo = i.SvsNo,
                QeydiyyatUnvani = i.QeydiyyatUnvani,
                BankMəlumatları = i.BankMəlumatları,
                SistemIstifadeciAdi = i.SistemIstifadecisi?.IstifadeciAdi
            }).ToList();

            return EmeliyyatNeticesi<List<IsciDto>>.Ugurlu(dtolar);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "İşçiləri gətirmək alınmadı: ");
            return EmeliyyatNeticesi<List<IsciDto>>.Ugursuz($"İşçiləri gətirmək alınmadı: {ex.Message} + {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Verilmiş ID-yə görə işçi məlumatlarını gətirir.
    /// </summary>
    public async Task<EmeliyyatNeticesi<IsciDto>> IsciGetirAsync(int id)
    {
        Logger.MelumatYaz($"IsciGetirAsync metodu çağırıldı. İD: {id}");
        Logger.MelumatYaz($"Axtarılan işçi ID-si: {id}");
        try
        {
            var isci = await _unitOfWork.Isciler.GetirAsync(id);
            if (isci == null)
                return EmeliyyatNeticesi<IsciDto>.Ugursuz("İşçi tapılmadı.");

            var dto = new IsciDto
            {
                Id = isci.Id,
                TamAd = isci.TamAd,
                DogumTarixi = isci.DogumTarixi,
                TelefonNomresi = isci.TelefonNomresi,
                Unvan = isci.Unvan,
                Email = isci.Email,
                IseBaslamaTarixi = isci.IseBaslamaTarixi,
                Maas = isci.Maas,
                Vezife = isci.Vezife,
                Departament = isci.Departament,
                Status = isci.Status,
                SvsNo = isci.SvsNo,
                QeydiyyatUnvani = isci.QeydiyyatUnvani,
                BankMəlumatları = isci.BankMəlumatları,
                SistemIstifadeciAdi = isci.SistemIstifadecisi?.IstifadeciAdi
            };

            return EmeliyyatNeticesi<IsciDto>.Ugurlu(dto);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "İşçi məlumatlarını gətirmək alınmadı: ");
            return EmeliyyatNeticesi<IsciDto>.Ugursuz($"İşçi məlumatlarını gətirmək alınmadı: {ex.Message} + {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Yeni işçi yaradır.
    /// </summary>
    public async Task<EmeliyyatNeticesi<int>> IsciYaratAsync(IsciDto dto)
    {
        Logger.MelumatYaz("IsciYaratAsync metodu çağırıldı.");
        Logger.MelumatYaz($"Yaradılacaq işçi adı: {dto.TamAd}");
        try
        {
            // Validasiya
            if (string.IsNullOrWhiteSpace(dto.TamAd))
                return EmeliyyatNeticesi<int>.Ugursuz("İşçinin tam adı boş ola bilməz.");

            if (dto.Maas < 0)
                return EmeliyyatNeticesi<int>.Ugursuz("Maaş mənfi ola bilməz.");

            // Yeni işçi obyekti yaradırıq
            var yeniIsci = new Isci
            {
                TamAd = dto.TamAd,
                DogumTarixi = dto.DogumTarixi,
                TelefonNomresi = dto.TelefonNomresi,
                Unvan = dto.Unvan,
                Email = dto.Email,
                IseBaslamaTarixi = dto.IseBaslamaTarixi,
                Maas = dto.Maas,
                Vezife = dto.Vezife,
                Departament = dto.Departament,
                Status = dto.Status,
                SvsNo = dto.SvsNo,
                QeydiyyatUnvani = dto.QeydiyyatUnvani,
                BankMəlumatları = dto.BankMəlumatları
            };

            await _unitOfWork.Isciler.ElaveEtAsync(yeniIsci);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi<int>.Ugurlu(yeniIsci.Id);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "İşçi yaratmaq alınmadı: ");
            return EmeliyyatNeticesi<int>.Ugursuz($"İşçi yaratmaq alınmadı: {ex.Message} + {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Mövcud işçinin məlumatlarını yeniləyir.
    /// </summary>
    public async Task<EmeliyyatNeticesi> IsciYenileAsync(IsciDto dto)
    {
        Logger.MelumatYaz("IsciYenileAsync metodu çağırıldı.");
        Logger.MelumatYaz($"Yenilənəcək işçi ID-si: {dto.Id}");
        try
        {
            var movcudIsci = await _unitOfWork.Isciler.GetirAsync(dto.Id);
            if (movcudIsci == null)
                return EmeliyyatNeticesi.Ugursuz("Yenilənmək üçün işçi tapılmadı.");

            // Validasiya
            if (string.IsNullOrWhiteSpace(dto.TamAd))
                return EmeliyyatNeticesi.Ugursuz("İşçinin tam adı boş ola bilməz.");

            if (dto.Maas < 0)
                return EmeliyyatNeticesi.Ugursuz("Maaş mənfi ola bilməz.");

            // Məlumatları yeniləyirik
            movcudIsci.TamAd = dto.TamAd;
            movcudIsci.DogumTarixi = dto.DogumTarixi;
            movcudIsci.TelefonNomresi = dto.TelefonNomresi;
            movcudIsci.Unvan = dto.Unvan;
            movcudIsci.Email = dto.Email;
            movcudIsci.IseBaslamaTarixi = dto.IseBaslamaTarixi;
            movcudIsci.Maas = dto.Maas;
            movcudIsci.Vezife = dto.Vezife;
            movcudIsci.Departament = dto.Departament;
            movcudIsci.Status = dto.Status;
            movcudIsci.SvsNo = dto.SvsNo;
            movcudIsci.QeydiyyatUnvani = dto.QeydiyyatUnvani;
            movcudIsci.BankMəlumatları = dto.BankMəlumatları;

            _unitOfWork.Isciler.Yenile(movcudIsci);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "İşçi məlumatlarını yeniləmək alınmadı: ");
            return EmeliyyatNeticesi.Ugursuz($"İşçi məlumatlarını yeniləmək alınmadı: {ex.Message}+ {ex.StackTrace}");
        }
    }

    /// <summary>
    /// İşçi silir.
    /// </summary>
    public async Task<EmeliyyatNeticesi> IsciSilAsync(int id)
    {
        Logger.MelumatYaz("IsciSilAsync metodu çağırıldı.");
        Logger.MelumatYaz($"Silinəcək işçi ID-si: {id}");
        try
        {
            var isci = await _unitOfWork.Isciler.GetirAsync(id);
            if (isci == null)
                return EmeliyyatNeticesi.Ugursuz("Silinəcək işçi tapılmadı.");

            _unitOfWork.Isciler.Sil(isci);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "İşçi silmək alınmadı: ");
            return EmeliyyatNeticesi.Ugursuz($"İşçi silmək alınmadı: {ex.Message}+ {ex.StackTrace}");
        }
    }

    /// <summary>
    /// İşçinin performans qeydlərini gətirir.
    /// </summary>
    public async Task<EmeliyyatNeticesi<List<IsciPerformansDto>>> IscininPerformansQeydleriniGetirAsync(int isciId)
    {
        Logger.MelumatYaz("IscininPerformansQeydleriniGetirAsync metodu çağırıldı.");
        Logger.MelumatYaz($"Performans qeydləri gətiriləcək işçi ID-si: {isciId}");
        try
        {
            var performansQeydleri = await _unitOfWork.IsciPerformanslari.AxtarAsync(p => p.IsciId == isciId);
            var dtolar = performansQeydleri.Select(p => new IsciPerformansDto
            {
                Id = p.Id,
                IsciId = p.IsciId,
                IsciAdi = p.Isci?.TamAd ?? "Naməlum",
                Tarix = p.Tarix,
                QeydDovru = p.QeydDovru,
                Qiymet = p.Qiymet,
                Qeydler = p.Qeydler,
                Emsallar = p.Emsallar,
                Teklifler = p.Teklifler
            }).ToList();

            return EmeliyyatNeticesi<List<IsciPerformansDto>>.Ugurlu(dtolar);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "İşçinin performans qeydlərini gətirmək alınmadı: ");
            return EmeliyyatNeticesi<List<IsciPerformansDto>>.Ugursuz($"İşçinin performans qeydlərini gətirmək alınmadı: {ex.Message}+ {ex.StackTrace}");
        }
    }

    /// <summary>
    /// İşçinin məzuniyyət/icazə qeydlərini gətirir.
    /// </summary>
    public async Task<EmeliyyatNeticesi<List<IsciIzniDto>>> IscininIzinQeydleriniGetirAsync(int isciId)
    {
        Logger.MelumatYaz("IscininİzinQeydleriniGetirAsync metodu çağırıldı.");
        Logger.MelumatYaz($"Məzuniyyət/icazə qeydləri gətiriləcək işçi ID-si: {isciId}");
        try
        {
            var izinQeydleri = await _unitOfWork.IsciIznleri.AxtarAsync(i => i.IsciId == isciId);
            var dtolar = izinQeydleri.Select(i => new IsciIzniDto
            {
                Id = i.Id,
                IsciId = i.IsciId,
                IsciAdi = i.Isci?.TamAd ?? "Naməlum",
                IzinNovu = i.IzinNovu,
                BaslamaTarixi = i.BaslamaTarixi,
                BitmeTarixi = i.BitmeTarixi,
                IzinGunu = i.IzinGunu,
                Sebeb = i.Sebeb,
                Status = i.Status,
                TesdiqEdenIsciId = i.TesdiqEdenIsciId,
                TesdiqEdenIsciAdi = i.TesdiqEdenIsci?.TamAd ?? "Naməlum",
                TesdiqTarixi = i.TesdiqTarixi,
                Qeydler = i.Qeydler
            }).ToList();

            return EmeliyyatNeticesi<List<IsciIzniDto>>.Ugurlu(dtolar);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "İşçinin məzuniyyət/icazə qeydlərini gətirmək alınmadı: ");
            return EmeliyyatNeticesi<List<IsciIzniDto>>.Ugursuz($"İşçinin məzuniyyət/icazə qeydlərini gətirmək alınmadı: {ex.Message}+ {ex.StackTrace}");
        }
    }

    /// <summary>
    /// Səhifələnmiş işçi siyahısını əldə edir.
    /// Diqqət: Bu metod böyük məlumat bazaları üçün əlverişlidir.
    /// </summary>
    /// <param name="parametrler">Səhifələmə parametrləri</param>
    /// <returns>Səhifələnmiş işçi məlumatları</returns>
    public async Task<EmeliyyatNeticesi<SehifelenmisMelumat<IsciDto>>> IscileriSehifelenmisGetirAsync(SehifeParametrleri parametrler)
    {
        Logger.MelumatYaz($"Səhifələnmiş işçilər əldə edilir - Səhifə: {parametrler.SehifeNomresi}, Ölçü: {parametrler.SehifeOlcusu}");
        try
        {
            var (isciler, umumiSay) = await _unitOfWork.Isciler.SehifelenmisGetirAsync(
                parametrler.SehifeNomresi,
                parametrler.SehifeOlcusu,
                i => !i.Silinib);

            var dtolar = isciler.Select(i => new IsciDto
            {
                Id = i.Id,
                TamAd = i.TamAd,
                DogumTarixi = i.DogumTarixi,
                TelefonNomresi = i.TelefonNomresi,
                Unvan = i.Unvan,
                Email = i.Email,
                IseBaslamaTarixi = i.IseBaslamaTarixi,
                Maas = i.Maas,
                Vezife = i.Vezife,
                Departament = i.Departament,
                Status = i.Status,
                SvsNo = i.SvsNo,
                QeydiyyatUnvani = i.QeydiyyatUnvani,
                BankMəlumatları = i.BankMəlumatları,
                SistemIstifadeciAdi = i.SistemIstifadecisi?.IstifadeciAdi
            }).ToList();

            var sehifelenmis = new SehifelenmisMelumat<IsciDto>(
                dtolar,
                umumiSay,
                parametrler.SehifeNomresi,
                parametrler.SehifeOlcusu);

            Logger.MelumatYaz($"Səhifələnmiş işçilər uğurla əldə edildi - {dtolar.Count}/{umumiSay}");
            return EmeliyyatNeticesi<SehifelenmisMelumat<IsciDto>>.Ugurlu(sehifelenmis);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Səhifələnmiş işçilər əldə edilərkən istisna baş verdi");
            return EmeliyyatNeticesi<SehifelenmisMelumat<IsciDto>>.Ugursuz($"Səhifələnmiş işçilər əldə edilərkən xəta: {ex.Message}");
        }
    }
}