// Fayl: AzAgroPOS.Mentiq/Idareciler/IsciIzniManager.cs
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
/// İşçi izni idarəetmə meneceri
/// diqqət: Bu sinif işçilərin məzuniyyət, xəstəlik icazəsi və digər izinlərini idarə edir.
/// qeyd: Bütün izin əməliyyatları təsdiq prosesi ilə birlikdə həyata keçirilir.
/// rol: İşçi izinləri və məzuniyyət idarəetməsi üçün mərkəzi mənbədir.
/// </summary>
public class IsciIzniManager
{
    private readonly IUnitOfWork _unitOfWork;

    public IsciIzniManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Yeni işçi izni qeydiyyatı yaradır
    /// diqqət: İzin ilkin olaraq "Gözləmədə" statusu ilə yaradılır
    /// </summary>
    public async Task<EmeliyyatNeticesi<int>> IzinYaratAsync(
        int isciId,
        IzinNovu izinNovu,
        DateTime baslamaTarixi,
        DateTime bitmeTarixi,
        string sebeb,
        string? qeydler = null)
    {
        Logger.MelumatYaz($"İşçi izni yaradılır: İşçi={isciId}, Növ={izinNovu}");

        try
        {
            // Validasiya
            if (baslamaTarixi >= bitmeTarixi)
            {
                Logger.XəbərdarlıqYaz("Başlama tarixi bitmə tarixindən kiçik olmalıdır");
                return EmeliyyatNeticesi<int>.Ugursuz("Başlama tarixi bitmə tarixindən kiçik olmalıdır.");
            }

            if (string.IsNullOrWhiteSpace(sebeb))
            {
                Logger.XəbərdarlıqYaz("İzin səbəbi boş ola bilməz");
                return EmeliyyatNeticesi<int>.Ugursuz("İzin səbəbi boş ola bilməz.");
            }

            // İşçinin mövcudluğunu yoxla
            var isci = await _unitOfWork.Isciler.GetirAsync(isciId);
            if (isci == null)
            {
                Logger.XəbərdarlıqYaz("İşçi tapılmadı");
                return EmeliyyatNeticesi<int>.Ugursuz("İşçi tapılmadı.");
            }

            // İzin günlərini hesabla
            var izinGunu = (bitmeTarixi.Date - baslamaTarixi.Date).Days + 1;

            // Yeni izin yarat
            var izin = new IsciIzni
            {
                IsciId = isciId,
                IzinNovu = izinNovu,
                BaslamaTarixi = baslamaTarixi,
                BitmeTarixi = bitmeTarixi,
                IzinGunu = izinGunu,
                Sebeb = sebeb,
                Status = IzinStatusu.Gozlemede,
                Qeydler = qeydler ?? string.Empty
            };

            await _unitOfWork.IsciIznleri.ElaveEtAsync(izin);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            Logger.MelumatYaz($"İşçi izni uğurla yaradıldı: ID={izin.Id}");
            return EmeliyyatNeticesi<int>.Ugurlu(izin.Id);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "İşçi izni yaradılması zamanı xəta baş verdi");
            return EmeliyyatNeticesi<int>.Ugursuz($"İşçi izni yaradılması zamanı xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// İşçi iznini yeniləyir
    /// diqqət: Yalnız "Gözləmədə" statusundakı izinlər yenilənə bilər
    /// </summary>
    public async Task<EmeliyyatNeticesi> IzinYenileAsync(
        int izinId,
        IzinNovu izinNovu,
        DateTime baslamaTarixi,
        DateTime bitmeTarixi,
        string sebeb,
        string? qeydler = null)
    {
        Logger.MelumatYaz($"İşçi izni yenilənir: ID={izinId}");

        try
        {
            // Validasiya
            if (baslamaTarixi >= bitmeTarixi)
            {
                Logger.XəbərdarlıqYaz("Başlama tarixi bitmə tarixindən kiçik olmalıdır");
                return EmeliyyatNeticesi.Ugursuz("Başlama tarixi bitmə tarixindən kiçik olmalıdır.");
            }

            if (string.IsNullOrWhiteSpace(sebeb))
            {
                Logger.XəbərdarlıqYaz("İzin səbəbi boş ola bilməz");
                return EmeliyyatNeticesi.Ugursuz("İzin səbəbi boş ola bilməz.");
            }

            // Mövcud izni tap
            var movcudIzin = await _unitOfWork.IsciIznleri.GetirAsync(izinId);
            if (movcudIzin == null)
            {
                Logger.XəbərdarlıqYaz("İzin tapılmadı");
                return EmeliyyatNeticesi.Ugursuz("İzin tapılmadı.");
            }

            // Yalnız "Gözləmədə" statusundakı izinlər yenilənə bilər
            if (movcudIzin.Status != IzinStatusu.Gozlemede)
            {
                Logger.XəbərdarlıqYaz("Yalnız gözləmədə olan izinlər yenilənə bilər");
                return EmeliyyatNeticesi.Ugursuz("Yalnız gözləmədə olan izinlər yenilənə bilər.");
            }

            // İzin günlərini yenidən hesabla
            var izinGunu = (bitmeTarixi.Date - baslamaTarixi.Date).Days + 1;

            // İzni yenilə
            movcudIzin.IzinNovu = izinNovu;
            movcudIzin.BaslamaTarixi = baslamaTarixi;
            movcudIzin.BitmeTarixi = bitmeTarixi;
            movcudIzin.IzinGunu = izinGunu;
            movcudIzin.Sebeb = sebeb;
            movcudIzin.Qeydler = qeydler ?? string.Empty;

            _unitOfWork.IsciIznleri.Yenile(movcudIzin);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            Logger.MelumatYaz($"İşçi izni uğurla yeniləndi: ID={izinId}");
            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "İşçi izni yeniləməsi zamanı xəta baş verdi");
            return EmeliyyatNeticesi.Ugursuz($"İşçi izni yeniləməsi zamanı xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// İşçi iznini silir
    /// diqqət: Yalnız "Gözləmədə" statusundakı izinlər silinə bilər
    /// </summary>
    public async Task<EmeliyyatNeticesi> IzinSilAsync(int izinId)
    {
        Logger.MelumatYaz($"İşçi izni silinir: ID={izinId}");

        try
        {
            // Mövcud izni tap
            var izin = await _unitOfWork.IsciIznleri.GetirAsync(izinId);
            if (izin == null)
            {
                Logger.XəbərdarlıqYaz("İzin tapılmadı");
                return EmeliyyatNeticesi.Ugursuz("İzin tapılmadı.");
            }

            // Yalnız "Gözləmədə" statusundakı izinlər silinə bilər
            if (izin.Status != IzinStatusu.Gozlemede)
            {
                Logger.XəbərdarlıqYaz("Yalnız gözləmədə olan izinlər silinə bilər");
                return EmeliyyatNeticesi.Ugursuz("Yalnız gözləmədə olan izinlər silinə bilər.");
            }

            // İzni sil
            _unitOfWork.IsciIznleri.Sil(izin);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            Logger.MelumatYaz($"İşçi izni uğurla silindi: ID={izinId}");
            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "İşçi izni silinməsi zamanı xəta baş verdi");
            return EmeliyyatNeticesi.Ugursuz($"İşçi izni silinməsi zamanı xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// İşçi iznini təsdiqləyir
    /// </summary>
    public async Task<EmeliyyatNeticesi> IzinTesdiqleAsync(int izinId, int tesdiqEdenIsciId)
    {
        Logger.MelumatYaz($"İşçi izni təsdiqlənir: ID={izinId}, Təsdiqləyən={tesdiqEdenIsciId}");

        try
        {
            // Mövcud izni tap
            var izin = await _unitOfWork.IsciIznleri.GetirAsync(izinId);
            if (izin == null)
            {
                Logger.XəbərdarlıqYaz("İzin tapılmadı");
                return EmeliyyatNeticesi.Ugursuz("İzin tapılmadı.");
            }

            // Yalnız "Gözləmədə" statusundakı izinlər təsdiqlənə bilər
            if (izin.Status != IzinStatusu.Gozlemede)
            {
                Logger.XəbərdarlıqYaz("Yalnız gözləmədə olan izinlər təsdiqlənə bilər");
                return EmeliyyatNeticesi.Ugursuz("Yalnız gözləmədə olan izinlər təsdiqlənə bilər.");
            }

            // İzni təsdiqlə
            izin.Status = IzinStatusu.Tesdiqlenib;
            izin.TesdiqEdenIsciId = tesdiqEdenIsciId;
            izin.TesdiqTarixi = DateTime.Now;

            _unitOfWork.IsciIznleri.Yenile(izin);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            Logger.MelumatYaz($"İşçi izni uğurla təsdiqləndi: ID={izinId}");
            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "İşçi izni təsdiqləməsi zamanı xəta baş verdi");
            return EmeliyyatNeticesi.Ugursuz($"İşçi izni təsdiqləməsi zamanı xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// İşçi iznini rədd edir
    /// </summary>
    public async Task<EmeliyyatNeticesi> IzinReddEtAsync(int izinId, int reddEdenIsciId, string reddSebebi)
    {
        Logger.MelumatYaz($"İşçi izni rədd edilir: ID={izinId}, Rədd edən={reddEdenIsciId}");

        try
        {
            if (string.IsNullOrWhiteSpace(reddSebebi))
            {
                Logger.XəbərdarlıqYaz("Rədd səbəbi boş ola bilməz");
                return EmeliyyatNeticesi.Ugursuz("Rədd səbəbi boş ola bilməz.");
            }

            // Mövcud izni tap
            var izin = await _unitOfWork.IsciIznleri.GetirAsync(izinId);
            if (izin == null)
            {
                Logger.XəbərdarlıqYaz("İzin tapılmadı");
                return EmeliyyatNeticesi.Ugursuz("İzin tapılmadı.");
            }

            // Yalnız "Gözləmədə" statusundakı izinlər rədd edilə bilər
            if (izin.Status != IzinStatusu.Gozlemede)
            {
                Logger.XəbərdarlıqYaz("Yalnız gözləmədə olan izinlər rədd edilə bilər");
                return EmeliyyatNeticesi.Ugursuz("Yalnız gözləmədə olan izinlər rədd edilə bilər.");
            }

            // İzni rədd et
            izin.Status = IzinStatusu.Reddedilib;
            izin.TesdiqEdenIsciId = reddEdenIsciId;
            izin.TesdiqTarixi = DateTime.Now;
            izin.Qeydler += $"\nRədd səbəbi: {reddSebebi}";

            _unitOfWork.IsciIznleri.Yenile(izin);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            Logger.MelumatYaz($"İşçi izni uğurla rədd edildi: ID={izinId}");
            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "İşçi izni rədd edilməsi zamanı xəta baş verdi");
            return EmeliyyatNeticesi.Ugursuz($"İşçi izni rədd edilməsi zamanı xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// İşçi iznini ləğv edir
    /// diqqət: Təsdiqlənmiş izinlər ləğv edilə bilər
    /// </summary>
    public async Task<EmeliyyatNeticesi> IzinLegvEtAsync(int izinId)
    {
        Logger.MelumatYaz($"İşçi izni ləğv edilir: ID={izinId}");

        try
        {
            // Mövcud izni tap
            var izin = await _unitOfWork.IsciIznleri.GetirAsync(izinId);
            if (izin == null)
            {
                Logger.XəbərdarlıqYaz("İzin tapılmadı");
                return EmeliyyatNeticesi.Ugursuz("İzin tapılmadı.");
            }

            // İzni ləğv et
            izin.Status = IzinStatusu.LegvEdilib;

            _unitOfWork.IsciIznleri.Yenile(izin);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();

            Logger.MelumatYaz($"İşçi izni uğurla ləğv edildi: ID={izinId}");
            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "İşçi izni ləğv edilməsi zamanı xəta baş verdi");
            return EmeliyyatNeticesi.Ugursuz($"İşçi izni ləğv edilməsi zamanı xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// Bütün işçi izinlərini gətirir
    /// </summary>
    public async Task<EmeliyyatNeticesi<List<IsciIzni>>> ButunIzinleriGetirAsync()
    {
        Logger.MelumatYaz("Bütün işçi izinləri əldə edilir");

        try
        {
            var izinler = (await _unitOfWork.IsciIznleri.ButununuGetirAsync())
                .OrderByDescending(i => i.BaslamaTarixi)
                .ToList();

            Logger.MelumatYaz($"İşçi izinləri əldə edildi: Say={izinler.Count}");
            return EmeliyyatNeticesi<List<IsciIzni>>.Ugurlu(izinler);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "İşçi izinləri əldə edilərkən xəta baş verdi");
            return EmeliyyatNeticesi<List<IsciIzni>>.Ugursuz($"İşçi izinləri əldə edilərkən xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// Bütün işçi izinlərini DTO formatında gətirir
    /// </summary>
    public async Task<EmeliyyatNeticesi<List<IsciIzniDto>>> ButunIzinleriDtoFormatindaGetirAsync()
    {
        Logger.MelumatYaz("İşçi izinləri DTO formatında əldə edilir");

        try
        {
            var izinler = (await _unitOfWork.IsciIznleri.ButununuGetirAsync())
                .OrderByDescending(i => i.BaslamaTarixi)
                .ToList();

            var dtolar = new List<IsciIzniDto>();
            foreach (var izin in izinler)
            {
                // İşçi məlumatlarını yüklə
                var isci = await _unitOfWork.Isciler.GetirAsync(izin.IsciId);
                var tesdiqEdenIsci = izin.TesdiqEdenIsciId.HasValue
                    ? await _unitOfWork.Isciler.GetirAsync(izin.TesdiqEdenIsciId.Value)
                    : null;

                var dto = new IsciIzniDto
                {
                    Id = izin.Id,
                    IsciId = izin.IsciId,
                    IsciAdi = isci?.TamAd ?? "Naməlum",
                    IzinNovu = izin.IzinNovu,
                    BaslamaTarixi = izin.BaslamaTarixi,
                    BitmeTarixi = izin.BitmeTarixi,
                    IzinGunu = izin.IzinGunu,
                    Sebeb = izin.Sebeb,
                    Status = izin.Status,
                    TesdiqEdenIsciId = izin.TesdiqEdenIsciId,
                    TesdiqEdenIsciAdi = tesdiqEdenIsci?.TamAd ?? string.Empty,
                    TesdiqTarixi = izin.TesdiqTarixi,
                    Qeydler = izin.Qeydler
                };
                dtolar.Add(dto);
            }

            Logger.MelumatYaz($"İşçi izinləri DTO formatında əldə edildi: Say={dtolar.Count}");
            return EmeliyyatNeticesi<List<IsciIzniDto>>.Ugurlu(dtolar);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "İşçi izinləri DTO formatında əldə edilərkən xəta baş verdi");
            return EmeliyyatNeticesi<List<IsciIzniDto>>.Ugursuz($"İşçi izinləri DTO formatında əldə edilərkən xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// Müəyyən işçi üçün izinləri gətirir
    /// </summary>
    public async Task<EmeliyyatNeticesi<List<IsciIzniDto>>> IsciUcunIzinleriGetirAsync(int isciId)
    {
        Logger.MelumatYaz($"İşçi üçün izinlər əldə edilir: İşçi={isciId}");

        try
        {
            var izinler = (await _unitOfWork.IsciIznleri.ButununuGetirAsync())
                .Where(i => i.IsciId == isciId)
                .OrderByDescending(i => i.BaslamaTarixi)
                .ToList();

            var dtolar = new List<IsciIzniDto>();
            foreach (var izin in izinler)
            {
                var isci = await _unitOfWork.Isciler.GetirAsync(izin.IsciId);
                var tesdiqEdenIsci = izin.TesdiqEdenIsciId.HasValue
                    ? await _unitOfWork.Isciler.GetirAsync(izin.TesdiqEdenIsciId.Value)
                    : null;

                var dto = new IsciIzniDto
                {
                    Id = izin.Id,
                    IsciId = izin.IsciId,
                    IsciAdi = isci?.TamAd ?? "Naməlum",
                    IzinNovu = izin.IzinNovu,
                    BaslamaTarixi = izin.BaslamaTarixi,
                    BitmeTarixi = izin.BitmeTarixi,
                    IzinGunu = izin.IzinGunu,
                    Sebeb = izin.Sebeb,
                    Status = izin.Status,
                    TesdiqEdenIsciId = izin.TesdiqEdenIsciId,
                    TesdiqEdenIsciAdi = tesdiqEdenIsci?.TamAd ?? string.Empty,
                    TesdiqTarixi = izin.TesdiqTarixi,
                    Qeydler = izin.Qeydler
                };
                dtolar.Add(dto);
            }

            Logger.MelumatYaz($"İşçi üçün izinlər əldə edildi: Say={dtolar.Count}");
            return EmeliyyatNeticesi<List<IsciIzniDto>>.Ugurlu(dtolar);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "İşçi üçün izinlər əldə edilərkən xəta baş verdi");
            return EmeliyyatNeticesi<List<IsciIzniDto>>.Ugursuz($"İşçi üçün izinlər əldə edilərkən xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// Statusuna görə izinləri gətirir
    /// </summary>
    public async Task<EmeliyyatNeticesi<List<IsciIzniDto>>> StatusaGoreGetirAsync(IzinStatusu status)
    {
        Logger.MelumatYaz($"Statusuna görə izinlər əldə edilir: Status={status}");

        try
        {
            var izinler = (await _unitOfWork.IsciIznleri.ButununuGetirAsync())
                .Where(i => i.Status == status)
                .OrderByDescending(i => i.BaslamaTarixi)
                .ToList();

            var dtolar = new List<IsciIzniDto>();
            foreach (var izin in izinler)
            {
                var isci = await _unitOfWork.Isciler.GetirAsync(izin.IsciId);
                var tesdiqEdenIsci = izin.TesdiqEdenIsciId.HasValue
                    ? await _unitOfWork.Isciler.GetirAsync(izin.TesdiqEdenIsciId.Value)
                    : null;

                var dto = new IsciIzniDto
                {
                    Id = izin.Id,
                    IsciId = izin.IsciId,
                    IsciAdi = isci?.TamAd ?? "Naməlum",
                    IzinNovu = izin.IzinNovu,
                    BaslamaTarixi = izin.BaslamaTarixi,
                    BitmeTarixi = izin.BitmeTarixi,
                    IzinGunu = izin.IzinGunu,
                    Sebeb = izin.Sebeb,
                    Status = izin.Status,
                    TesdiqEdenIsciId = izin.TesdiqEdenIsciId,
                    TesdiqEdenIsciAdi = tesdiqEdenIsci?.TamAd ?? string.Empty,
                    TesdiqTarixi = izin.TesdiqTarixi,
                    Qeydler = izin.Qeydler
                };
                dtolar.Add(dto);
            }

            Logger.MelumatYaz($"Statusuna görə izinlər əldə edildi: Say={dtolar.Count}");
            return EmeliyyatNeticesi<List<IsciIzniDto>>.Ugurlu(dtolar);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Statusuna görə izinlər əldə edilərkən xəta baş verdi");
            return EmeliyyatNeticesi<List<IsciIzniDto>>.Ugursuz($"Statusuna görə izinlər əldə edilərkən xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// Səhifələnmiş işçi izni siyahısını əldə edir.
    /// Diqqət: Bu metod böyük məlumat bazaları üçün əlverişlidir.
    /// </summary>
    /// <param name="parametrler">Səhifələmə parametrləri</param>
    /// <returns>Səhifələnmiş işçi izni məlumatları</returns>
    public async Task<EmeliyyatNeticesi<SehifelenmisMelumat<IsciIzniDto>>> IzinleriSehifelenmisGetirAsync(SehifeParametrleri parametrler)
    {
        Logger.MelumatYaz($"Səhifələnmiş işçi izinləri əldə edilir - Səhifə: {parametrler.SehifeNomresi}, Ölçü: {parametrler.SehifeOlcusu}");
        try
        {
            var (izinler, umumiSay) = await _unitOfWork.IsciIznleri.SehifelenmisGetirAsync(
                parametrler.SehifeNomresi,
                parametrler.SehifeOlcusu,
                i => !i.Silinib);

            var dtolar = new List<IsciIzniDto>();
            foreach (var izin in izinler)
            {
                var isci = await _unitOfWork.Isciler.GetirAsync(izin.IsciId);
                var tesdiqEdenIsci = izin.TesdiqEdenIsciId.HasValue
                    ? await _unitOfWork.Isciler.GetirAsync(izin.TesdiqEdenIsciId.Value)
                    : null;

                dtolar.Add(new IsciIzniDto
                {
                    Id = izin.Id,
                    IsciId = izin.IsciId,
                    IsciAdi = isci?.TamAd ?? "Naməlum",
                    IzinNovu = izin.IzinNovu,
                    BaslamaTarixi = izin.BaslamaTarixi,
                    BitmeTarixi = izin.BitmeTarixi,
                    IzinGunu = izin.IzinGunu,
                    Sebeb = izin.Sebeb,
                    Status = izin.Status,
                    TesdiqEdenIsciId = izin.TesdiqEdenIsciId,
                    TesdiqEdenIsciAdi = tesdiqEdenIsci?.TamAd ?? string.Empty,
                    TesdiqTarixi = izin.TesdiqTarixi,
                    Qeydler = izin.Qeydler
                });
            }

            var sehifelenmis = new SehifelenmisMelumat<IsciIzniDto>(
                dtolar,
                umumiSay,
                parametrler.SehifeNomresi,
                parametrler.SehifeOlcusu);

            Logger.MelumatYaz($"Səhifələnmiş işçi izinləri uğurla əldə edildi - {dtolar.Count}/{umumiSay}");
            return EmeliyyatNeticesi<SehifelenmisMelumat<IsciIzniDto>>.Ugurlu(sehifelenmis);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Səhifələnmiş işçi izinləri əldə edilərkən istisna baş verdi");
            return EmeliyyatNeticesi<SehifelenmisMelumat<IsciIzniDto>>.Ugursuz($"Səhifələnmiş işçi izinləri əldə edilərkən xəta: {ex.Message}");
        }
    }
}
