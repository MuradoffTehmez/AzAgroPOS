// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/IsciIzniPresenter.cs

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Mentiq.Yardimcilar;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Yardimcilar;
using AzAgroPOS.Varliglar;

namespace AzAgroPOS.Teqdimat.Teqdimatcilar;
/// <summary>
/// İşçi izni idarəetmə forması üçün presenter.
/// İşçilərin məzuniyyət, xəstəlik icazəsi və digər izinlərini idarə edir.
/// </summary>
public class IsciIzniPresenter
{
    private readonly IIsciIzniView _view;
    private readonly IsciIzniManager _izniManager;
    private readonly IsciManager _isciManager;
    private readonly SemaphoreSlim _kilit = new SemaphoreSlim(1, 1);

    public IsciIzniPresenter(IIsciIzniView view, IsciIzniManager izniManager, IsciManager isciManager)
    {
        _view = view ?? throw new ArgumentNullException(nameof(view));
        _izniManager = izniManager ?? throw new ArgumentNullException(nameof(izniManager));
        _isciManager = isciManager ?? throw new ArgumentNullException(nameof(isciManager));

        // Hadisələrə abunə oluruq
        _view.FormYuklendi += async (s, e) => await FormuYukle();
        _view.IsciSecildi += async (s, e) => await IsciSecildi();
        _view.Yarat_Istek += async (s, e) => await IzinYarat();
        _view.Yenile_Istek += async (s, e) => await IzinYenile();
        _view.Sil_Istek += async (s, e) => await IzinSil();
        _view.Tesdiqle_Istek += async (s, e) => await IzinTesdiqle();
        _view.ReddEt_Istek += async (s, e) => await IzinReddEt();
        _view.LegvEt_Istek += async (s, e) => await IzinLegvEt();
        _view.StatusFiltre_Deyisdi += async (s, e) => await IzinleriFiltrele();
        _view.YenileHamisi_Istek += async (s, e) => await IzinleriYukle();
    }

    /// <summary>
    /// Formu yükləyir - işçi siyahısını və izin tarixçəsini göstərir
    /// </summary>
    private async Task FormuYukle()
    {
        try
        {
            await IscileriYukle();
            await IzinleriYukle();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "İşçi izni formu yüklənərkən xəta");
            _view.MesajGoster($"Forma yüklənərkən xəta: {ex.Message}", true);
        }
    }

    /// <summary>
    /// Aktiv işçiləri yükləyir
    /// </summary>
    private async Task IscileriYukle()
    {
        try
        {
            EmeliyyatNeticesi<List<IsciDto>> netice = await _isciManager.ButunIscileriGetirAsync();
            if (netice.UgurluDur && netice.Data != null)
            {
                List<IsciDto> aktivIsciler = netice.Data.Where(i => i.Status == IsciStatusu.Aktiv).ToList();
                _view.IscileriGoster(aktivIsciler);
            }
            else
            {
                _view.MesajGoster($"İşçi siyahısı yüklənərkən xəta: {netice.Mesaj}", true);
            }
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "İşçi siyahısı yüklənərkən xəta");
            _view.MesajGoster($"İşçi siyahısı yüklənərkən xəta: {ex.Message}", true);
        }
    }

    /// <summary>
    /// İzinləri yükləyir
    /// </summary>
    private async Task IzinleriYukle()
    {
        try
        {
            EmeliyyatNeticesi<List<IsciIzniDto>> netice = await _izniManager.ButunIzinleriDtoFormatindaGetirAsync();
            if (netice.UgurluDur && netice.Data != null)
            {
                _view.IzinleriGoster(netice.Data.ToList());
                _view.FormatlaGrid();
            }
            else
            {
                _view.MesajGoster($"İzinlər yüklənərkən xəta: {netice.Mesaj}", true);
            }
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "İzinlər yüklənərkən xəta");
            _view.MesajGoster($"İzinlər yüklənərkən xəta: {ex.Message}", true);
        }
    }

    /// <summary>
    /// İşçi seçildikdə onun izin məlumatlarını göstərir
    /// </summary>
    private async Task IsciSecildi()
    {
        if (!await _kilit.WaitAsync(0)) return;
        try
        {
            if (!_view.SecilenIsciId.HasValue)
            {
                _view.IsciIzinMelumatGoster("İzin məlumatı: ---");
                return;
            }

            EmeliyyatNeticesi<List<IsciIzniDto>> netice = await _izniManager.IsciUcunIzinleriGetirAsync(_view.SecilenIsciId.Value);
            if (netice.UgurluDur && netice.Data != null)
            {
                List<IsciIzniDto> tesdiqlenibIzinler = netice.Data.Where(i => i.Status == IzinStatusu.Tesdiqlenib).ToList();
                int cemiGun = tesdiqlenibIzinler.Sum(i => i.IzinGunu);
                _view.IsciIzinMelumatGoster($"Təsdiqlənmiş izin günləri: {cemiGun}");
            }
            else
            {
                _view.IsciIzinMelumatGoster("İzin məlumatı: ---");
            }
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "İşçi məlumatları göstərilərkən xəta");
            _view.IsciIzinMelumatGoster("İzin məlumatı: ---");
        }
        finally
        {
            _kilit.Release();
        }
    }

    /// <summary>
    /// İzin yaradır
    /// </summary>
    private async Task IzinYarat()
    {
        try
        {
            if (!_view.SecilenIsciId.HasValue)
            {
                _view.MesajGoster("Zəhmət olmasa işçi seçin!", true);
                return;
            }

            EmeliyyatNeticesi<int> netice = await _izniManager.IzinYaratAsync(
                _view.SecilenIsciId.Value,
                _view.IzinNovu,
                _view.BaslamaTarixi,
                _view.BitmeTarixi,
                _view.Sebeb,
                _view.Qeydler);

            if (netice.UgurluDur)
            {
                _view.MesajGoster("İzin uğurla yaradıldı!");
                await IzinleriYukle();
                _view.FormuTemizle();
            }
            else
            {
                _view.MesajGoster($"Xəta: {netice.Mesaj}", true);
            }
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "İzin yaradılarkən xəta");
            _view.MesajGoster($"İzin yaradılarkən xəta: {ex.Message}", true);
        }
    }

    /// <summary>
    /// İzini yeniləyir
    /// </summary>
    private async Task IzinYenile()
    {
        try
        {
            if (_view.SecilenIzinId == 0)
            {
                _view.MesajGoster("Zəhmət olmasa yeniləmək üçün izin seçin!", true);
                return;
            }

            EmeliyyatNeticesi netice = await _izniManager.IzinYenileAsync(
                _view.SecilenIzinId,
                _view.IzinNovu,
                _view.BaslamaTarixi,
                _view.BitmeTarixi,
                _view.Sebeb,
                _view.Qeydler);

            if (netice.UgurluDur)
            {
                _view.MesajGoster("İzin uğurla yeniləndi!");
                await IzinleriYukle();
                _view.FormuTemizle();
            }
            else
            {
                _view.MesajGoster($"Xəta: {netice.Mesaj}", true);
            }
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "İzin yenilənərkən xəta");
            _view.MesajGoster($"İzin yenilənərkən xəta: {ex.Message}", true);
        }
    }

    /// <summary>
    /// İzini silir
    /// </summary>
    private async Task IzinSil()
    {
        try
        {
            if (_view.SecilenIzinId == 0)
            {
                _view.MesajGoster("Zəhmət olmasa silmək üçün izin seçin!", true);
                return;
            }

            EmeliyyatNeticesi netice = await _izniManager.IzinSilAsync(_view.SecilenIzinId);

            if (netice.UgurluDur)
            {
                _view.MesajGoster("İzin uğurla silindi!");
                await IzinleriYukle();
                _view.FormuTemizle();
            }
            else
            {
                _view.MesajGoster($"Xəta: {netice.Mesaj}", true);
            }
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "İzin silinərkən xəta");
            _view.MesajGoster($"İzin silinərkən xəta: {ex.Message}", true);
        }
    }

    /// <summary>
    /// İzini təsdiqləyir
    /// </summary>
    private async Task IzinTesdiqle()
    {
        try
        {
            if (_view.SecilenIzinId == 0)
            {
                _view.MesajGoster("Zəhmət olmasa təsdiqləmək üçün izin seçin!", true);
                return;
            }

            EmeliyyatNeticesi netice = await _izniManager.IzinTesdiqleAsync(_view.SecilenIzinId, AktivSessiya.AktivIstifadeci?.Id ?? 0);

            if (netice.UgurluDur)
            {
                _view.MesajGoster("İzin uğurla təsdiqləndi!");
                await IzinleriYukle();
                _view.FormuTemizle();
            }
            else
            {
                _view.MesajGoster($"Xəta: {netice.Mesaj}", true);
            }
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "İzin təsdiqlənərkən xəta");
            _view.MesajGoster($"İzin təsdiqlənərkən xəta: {ex.Message}", true);
        }
    }

    /// <summary>
    /// İzini rədd edir
    /// </summary>
    private async Task IzinReddEt()
    {
        try
        {
            if (_view.SecilenIzinId == 0)
            {
                _view.MesajGoster("Zəhmət olmasa rədd etmək üçün izin seçin!", true);
                return;
            }

            // Rədd səbəbini view-dan alırıq (view-da implementasiya edilməlidir)
            string reddSebebi = Microsoft.VisualBasic.Interaction.InputBox(
                "Rədd səbəbini daxil edin:",
                "İzin Rəddi",
                "",
                -1,
                -1);

            if (string.IsNullOrWhiteSpace(reddSebebi))
            {
                _view.MesajGoster("Rədd səbəbi daxil edilməlidir!", true);
                return;
            }

            EmeliyyatNeticesi netice = await _izniManager.IzinReddEtAsync(_view.SecilenIzinId, AktivSessiya.AktivIstifadeci?.Id ?? 0, reddSebebi);

            if (netice.UgurluDur)
            {
                _view.MesajGoster("İzin rədd edildi!");
                await IzinleriYukle();
                _view.FormuTemizle();
            }
            else
            {
                _view.MesajGoster($"Xəta: {netice.Mesaj}", true);
            }
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "İzin rədd edilərkən xəta");
            _view.MesajGoster($"İzin rədd edilərkən xəta: {ex.Message}", true);
        }
    }

    /// <summary>
    /// İzini ləğv edir
    /// </summary>
    private async Task IzinLegvEt()
    {
        try
        {
            if (_view.SecilenIzinId == 0)
            {
                _view.MesajGoster("Zəhmət olmasa ləğv etmək üçün izin seçin!", true);
                return;
            }

            EmeliyyatNeticesi netice = await _izniManager.IzinLegvEtAsync(_view.SecilenIzinId);

            if (netice.UgurluDur)
            {
                _view.MesajGoster("İzin ləğv edildi!");
                await IzinleriYukle();
                _view.FormuTemizle();
            }
            else
            {
                _view.MesajGoster($"Xəta: {netice.Mesaj}", true);
            }
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "İzin ləğv edilərkən xəta");
            _view.MesajGoster($"İzin ləğv edilərkən xəta: {ex.Message}", true);
        }
    }

    /// <summary>
    /// İzinləri statusuna görə filtrələyir
    /// </summary>
    private async Task IzinleriFiltrele()
    {
        try
        {
            // Bu funksionallıq view-da implementasiya edilməlidir
            // Hazırda sadəcə hamısını yükləyirik
            await IzinleriYukle();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "İzinlər filtrlənərkən xəta");
            _view.MesajGoster($"Filtrələmə xətası: {ex.Message}", true);
        }
    }
}
