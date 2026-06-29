// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/EmekHaqqiPresenter.cs

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Mentiq.Yardimcilar;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Yardimcilar;
using AzAgroPOS.Varliglar;

namespace AzAgroPOS.Teqdimat.Teqdimatcilar;
/// <summary>
/// Əmək haqqı idarəetmə forması üçün presenter.
/// İşçilərin əmək haqqını hesablamaq, ödəmək və tarixçəyə baxmaq əməliyyatlarını idarə edir.
/// </summary>
public class EmekHaqqiPresenter
{
    private readonly IEmekHaqqiView _view;
    private readonly EmekHaqqiManager _emekHaqqiManager;
    private readonly IsciManager _isciManager;
    private readonly SemaphoreSlim _kilit = new(1, 1);

    public EmekHaqqiPresenter(IEmekHaqqiView view, EmekHaqqiManager emekHaqqiManager, IsciManager isciManager)
    {
        _view = view ?? throw new ArgumentNullException(nameof(view));
        _emekHaqqiManager = emekHaqqiManager ?? throw new ArgumentNullException(nameof(emekHaqqiManager));
        _isciManager = isciManager ?? throw new ArgumentNullException(nameof(isciManager));

        // Hadisələrə abunə oluruq
        _view.FormYuklendi += async (s, e) => await FormuYukle();
        _view.IsciSecildi += async (s, e) => await IsciSecildi();
        _view.Hesabla_Istek += async (s, e) => await EmekHaqqiHesabla();
        _view.Ode_Istek += async (s, e) => await EmekHaqqiOde();
        _view.LegvEt_Istek += async (s, e) => await EmekHaqqiLegvEt();
        _view.Yenile_Istek += async (s, e) => await EmekHaqqiTarixcesiniYukle();
    }

    /// <summary>
    /// Formu yükləyir - işçi siyahısını və əmək haqqı tarixçəsini göstərir
    /// </summary>
    private async Task FormuYukle()
    {
        try
        {
            await IscileriYukle();
            await EmekHaqqiTarixcesiniYukle();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Əmək haqqı formu yüklənərkən xəta");
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
    /// Əmək haqqı tarixçəsini yükləyir
    /// </summary>
    private async Task EmekHaqqiTarixcesiniYukle()
    {
        try
        {
            EmeliyyatNeticesi<List<EmekHaqqiDto>> netice = await _emekHaqqiManager.EmekHaqqilariGetirAsync();
            if (netice.UgurluDur && netice.Data != null)
            {
                _view.EmekHaqqilariGoster(netice.Data.ToList());
            }
            else
            {
                _view.MesajGoster($"Əmək haqqı tarixçəsi yüklənərkən xəta: {netice.Mesaj}", true);
            }
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Əmək haqqı tarixçəsi yüklənərkən xəta");
            _view.MesajGoster($"Əmək haqqı tarixçəsi yüklənərkən xəta: {ex.Message}", true);
        }
    }

    /// <summary>
    /// İşçi seçildikdə onun son əmək haqqı məlumatlarını göstərir
    /// </summary>
    private async Task IsciSecildi()
    {
        if (!await _kilit.WaitAsync(0))
        {
            return;
        }

        try
        {
            if (!_view.SecilenIsciId.HasValue)
            {
                _view.SonMaasGoster("Son Maaş: ---");
                return;
            }

            EmeliyyatNeticesi<List<EmekHaqqiDto>> netice = await _emekHaqqiManager.EmekHaqqilariGetirAsync();
            if (netice.UgurluDur && netice.Data != null)
            {
                List<EmekHaqqiDto> isciEmekHaqqlari = netice.Data.Where(eh => eh.IsciId == _view.SecilenIsciId.Value).ToList();
                if (isciEmekHaqqlari.Any())
                {
                    EmekHaqqiDto sonEmekHaqqi = isciEmekHaqqlari.OrderByDescending(eh => eh.HesablanmaTarixi).First();
                    _view.SonMaasGoster($"Son Maaş: {sonEmekHaqqi.YekunEmekHaqqi:N2} AZN ({sonEmekHaqqi.Dovr})");
                }
                else
                {
                    _view.SonMaasGoster("Son Maaş: ---");
                }
            }
            else
            {
                _view.SonMaasGoster("Son Maaş: ---");
            }
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "İşçi məlumatları göstərilərkən xəta");
            _view.SonMaasGoster("Son Maaş: ---");
        }
        finally
        {
            _kilit.Release();
        }
    }

    /// <summary>
    /// Əmək haqqını hesablayır
    /// </summary>
    private async Task EmekHaqqiHesabla()
    {
        try
        {
            if (!_view.SecilenIsciId.HasValue)
            {
                _view.MesajGoster("Zəhmət olmasa işçi seçin!", true);
                return;
            }

            string dovr = _view.Dovr.ToString("yyyy MMMM");
            EmeliyyatNeticesi<int> netice = await _emekHaqqiManager.EmekHaqqiHesablaAsync(
                _view.SecilenIsciId.Value,
                dovr,
                _view.ElaveOdenisler,
                _view.DigerTutulmalar,
                _view.Qeyd,
                AktivSessiya.AktivIstifadeci?.Id);

            if (netice.UgurluDur)
            {
                _view.MesajGoster("Əmək haqqı uğurla hesablandı!");
                await EmekHaqqiTarixcesiniYukle();
                _view.FormuTemizle();
            }
            else
            {
                _view.MesajGoster($"Xəta: {netice.Mesaj}", true);
            }
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Əmək haqqı hesablanarkən xəta");
            _view.MesajGoster($"Hesablama xətası: {ex.Message}", true);
        }
    }

    /// <summary>
    /// Əmək haqqını ödəyir
    /// </summary>
    private async Task EmekHaqqiOde()
    {
        try
        {
            if (!_view.SecilenEmekHaqqiId.HasValue)
            {
                _view.MesajGoster("Zəhmət olmasa ödəniləcək əmək haqqını seçin!", true);
                return;
            }

            EmeliyyatNeticesi netice = await _emekHaqqiManager.EmekHaqqiOdeAsync(
                _view.SecilenEmekHaqqiId.Value,
                AktivSessiya.AktivIstifadeci?.Id);

            if (netice.UgurluDur)
            {
                _view.MesajGoster("Əmək haqqı uğurla ödənildi!");
                await EmekHaqqiTarixcesiniYukle();
            }
            else
            {
                _view.MesajGoster($"Xəta: {netice.Mesaj}", true);
            }
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Əmək haqqı ödənilərkən xəta");
            _view.MesajGoster($"Ödəniş xətası: {ex.Message}", true);
        }
    }

    /// <summary>
    /// Əmək haqqını ləğv edir
    /// </summary>
    private async Task EmekHaqqiLegvEt()
    {
        try
        {
            if (!_view.SecilenEmekHaqqiId.HasValue)
            {
                _view.MesajGoster("Zəhmət olmasa ləğv ediləcək əmək haqqını seçin!", true);
                return;
            }

            EmeliyyatNeticesi netice = await _emekHaqqiManager.EmekHaqqiLegvEtAsync(_view.SecilenEmekHaqqiId.Value);

            if (netice.UgurluDur)
            {
                _view.MesajGoster("Əmək haqqı ləğv edildi!");
                await EmekHaqqiTarixcesiniYukle();
            }
            else
            {
                _view.MesajGoster($"Xəta: {netice.Mesaj}", true);
            }
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Əmək haqqı ləğv edilərkən xəta");
            _view.MesajGoster($"Ləğv xətası: {ex.Message}", true);
        }
    }
}
