// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/BonusIdareetmePresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar;

using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Mentiq.Yardimcilar;
using AzAgroPOS.Teqdimat.Interfeysler;
using System;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Bonus idarəetmə forması üçün presenter.
/// Müştəri bonus sistemini idarə edir - bal əlavə etmə, istifadə və ləğv.
/// </summary>
public class BonusIdareetmePresenter
{
    private readonly IBonusIdareetmeView _view;
    private readonly MusteriManager _musteriManager;

    public BonusIdareetmePresenter(IBonusIdareetmeView view, MusteriManager musteriManager)
    {
        _view = view ?? throw new ArgumentNullException(nameof(view));
        _musteriManager = musteriManager ?? throw new ArgumentNullException(nameof(musteriManager));

        // Hadisələrə abunə oluruq
        _view.FormYuklendi += async (s, e) => await FormuYukle();
        _view.MusteriSecildi += async (s, e) => await MusteriSecildi();
        _view.BalElaveEt_Istek += async (s, e) => await BalElaveEt();
        _view.BalIstifadeEt_Istek += async (s, e) => await BalIstifadeEt();
        _view.BalLegvEt_Istek += async (s, e) => await BalLegvEt();
        _view.ManualBalElaveEt_Istek += async (s, e) => await ManualBalElaveEt();
        _view.Yenile_Istek += async (s, e) => await Yenile();
    }

    /// <summary>
    /// Formu yükləyir - müştəri və bonus siyahılarını göstərir
    /// </summary>
    private async Task FormuYukle()
    {
        try
        {
            await MusterileriYukle();
            await ButunBonuslariYukle();
            _view.TablolariDuzenle();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Bonus formu yüklənərkən xəta");
            _view.MesajGoster($"Forma yüklənərkən xəta: {ex.Message}", "Xəta",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Müştəriləri yükləyir
    /// </summary>
    private async Task MusterileriYukle()
    {
        try
        {
            var netice = await _musteriManager.ButunMusterileriGetirAsync();
            if (netice.UgurluDur && netice.Data != null)
            {
                var musteriler = netice.Data.OrderBy(m => m.TamAd).ToList();
                _view.MusterileriGoster(musteriler);
            }
            else
            {
                _view.MesajGoster(netice.Mesaj ?? "Müştərilər yüklənə bilmədi", "Xəta",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Müştərilər yüklənərkən xəta");
            _view.MesajGoster($"Müştərilər yüklənərkən xəta: {ex.Message}", "Xəta",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Bütün bonusları yükləyir
    /// </summary>
    private async Task ButunBonuslariYukle()
    {
        try
        {
            var netice = await _musteriManager.ButunBonuslariGetirAsync();
            if (netice.UgurluDur && netice.Data != null)
            {
                _view.ButunBonuslariGoster(netice.Data.ToList());
            }
            else
            {
                _view.MesajGoster(netice.Mesaj ?? "Bonuslar yüklənə bilmədi", "Xəta",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Bonuslar yüklənərkən xəta");
            _view.MesajGoster($"Bonuslar yüklənərkən xəta: {ex.Message}", "Xəta",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Müştəri seçildikdə onun bonus məlumatlarını göstərir
    /// </summary>
    private async Task MusteriSecildi()
    {
        try
        {
            if (_view.SecilenMusteriId == 0)
            {
                _view.BonusMelumatlariniTemizle();
                _view.DuymeleriBloklama();
                return;
            }

            await MusteriBonusMelumatlariniYukle();
            await BonusTarixcesiniYukle();
            _view.DuymeleriBloklama();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Müştəri məlumatları göstərilərkən xəta");
            _view.MesajGoster($"Müştəri məlumatları yüklənərkən xəta: {ex.Message}", "Xəta",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Müştəri bonus məlumatlarını yükləyir
    /// </summary>
    private async Task MusteriBonusMelumatlariniYukle()
    {
        try
        {
            var netice = await _musteriManager.MusteriBonusunuGetirAsync(_view.SecilenMusteriId);
            if (netice.UgurluDur)
            {
                _view.MusteriBonusMelumatlariniGoster(netice.Data);
            }
            else
            {
                _view.MesajGoster(netice.Mesaj ?? "Bonus məlumatı yüklənə bilmədi", "Xəta",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                _view.BonusMelumatlariniTemizle();
            }
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Müştəri bonus məlumatları yüklənərkən xəta");
            _view.BonusMelumatlariniTemizle();
        }
    }

    /// <summary>
    /// Bonus tarixçəsini yükləyir
    /// </summary>
    private async Task BonusTarixcesiniYukle()
    {
        try
        {
            var netice = await _musteriManager.BonusQeydleriniGetirAsync(_view.SecilenMusteriId);
            if (netice.UgurluDur && netice.Data != null)
            {
                var qeydler = netice.Data.OrderByDescending(bq => bq.EmeliyyatTarixi).ToList();
                _view.BonusTarixcesiniGoster(qeydler);
            }
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Bonus tarixçəsi yüklənərkən xəta");
        }
    }

    /// <summary>
    /// Müştəriyə bal əlavə edir
    /// </summary>
    private async Task BalElaveEt()
    {
        try
        {
            if (_view.SecilenMusteriId == 0)
            {
                _view.MesajGoster("Zəhmət olmasa müştəri seçin", "Xəbərdarlıq",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

            if (_view.BalMiqdari <= 0)
            {
                _view.MesajGoster("Bal miqdarı 0-dan böyük olmalıdır", "Xəbərdarlıq",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(_view.Aciklama))
            {
                _view.MesajGoster("Zəhmət olmasa açıqlama daxil edin", "Xəbərdarlıq",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

            var netice = await _musteriManager.BalElaveEtAsync(
                _view.SecilenMusteriId,
                _view.BalMiqdari,
                _view.Aciklama);

            if (netice.UgurluDur)
            {
                _view.MesajGoster("Bal uğurla əlavə edildi", "Uğur",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                await MusteriBonusMelumatlariniYukle();
                await BonusTarixcesiniYukle();
                await ButunBonuslariYukle();
                _view.EmeliyyatSaheleriniTemizle();
            }
            else
            {
                _view.MesajGoster(netice.Mesaj ?? "Bal əlavə edilə bilmədi", "Xəta",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Bal əlavə edilərkən xəta");
            _view.MesajGoster($"Bal əlavə edilərkən xəta: {ex.Message}", "Xəta",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Müştəri balını istifadə edir
    /// </summary>
    private async Task BalIstifadeEt()
    {
        try
        {
            if (_view.SecilenMusteriId == 0)
            {
                _view.MesajGoster("Zəhmət olmasa müştəri seçin", "Xəbərdarlıq",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

            if (_view.BalMiqdari <= 0)
            {
                _view.MesajGoster("Bal miqdarı 0-dan böyük olmalıdır", "Xəbərdarlıq",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

            if (_view.SecilenMusteriBonus == null || _view.SecilenMusteriBonus.MovcudBal < _view.BalMiqdari)
            {
                _view.MesajGoster($"Kifayət qədər bal yoxdur. Mövcud bal: {_view.SecilenMusteriBonus?.MovcudBal ?? 0:N2}", "Xəbərdarlıq",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(_view.Aciklama))
            {
                _view.MesajGoster("Zəhmət olmasa açıqlama daxil edin", "Xəbərdarlıq",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

            var netice = await _musteriManager.BalIstifadeEtAsync(
                _view.SecilenMusteriId,
                _view.BalMiqdari,
                _view.Aciklama);

            if (netice.UgurluDur)
            {
                _view.MesajGoster("Bal uğurla istifadə edildi", "Uğur",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                await MusteriBonusMelumatlariniYukle();
                await BonusTarixcesiniYukle();
                await ButunBonuslariYukle();
                _view.EmeliyyatSaheleriniTemizle();
            }
            else
            {
                _view.MesajGoster(netice.Mesaj ?? "Bal istifadə edilə bilmədi", "Xəta",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Bal istifadə edilərkən xəta");
            _view.MesajGoster($"Bal istifadə edilərkən xəta: {ex.Message}", "Xəta",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Müştəri balını ləğv edir
    /// </summary>
    private async Task BalLegvEt()
    {
        try
        {
            if (_view.SecilenMusteriId == 0)
            {
                _view.MesajGoster("Zəhmət olmasa müştəri seçin", "Xəbərdarlıq",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

            if (_view.BalMiqdari <= 0)
            {
                _view.MesajGoster("Bal miqdarı 0-dan böyük olmalıdır", "Xəbərdarlıq",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(_view.Aciklama))
            {
                _view.MesajGoster("Zəhmət olmasa açıqlama daxil edin", "Xəbərdarlıq",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

            var netice = await _musteriManager.BalLegvEtAsync(
                _view.SecilenMusteriId,
                _view.BalMiqdari,
                _view.Aciklama);

            if (netice.UgurluDur)
            {
                _view.MesajGoster("Bal uğurla ləğv edildi", "Uğur",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                await MusteriBonusMelumatlariniYukle();
                await BonusTarixcesiniYukle();
                await ButunBonuslariYukle();
                _view.EmeliyyatSaheleriniTemizle();
            }
            else
            {
                _view.MesajGoster(netice.Mesaj ?? "Bal ləğv edilə bilmədi", "Xəta",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Bal ləğv edilərkən xəta");
            _view.MesajGoster($"Bal ləğv edilərkən xəta: {ex.Message}", "Xəta",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Manual bal əlavə edir
    /// </summary>
    private async Task ManualBalElaveEt()
    {
        try
        {
            if (_view.SecilenMusteriId == 0)
            {
                _view.MesajGoster("Zəhmət olmasa müştəri seçin", "Xəbərdarlıq",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

            if (_view.BalMiqdari == 0)
            {
                _view.MesajGoster("Bal miqdarı 0 ola bilməz", "Xəbərdarlıq",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(_view.Aciklama))
            {
                _view.MesajGoster("Zəhmət olmasa açıqlama daxil edin", "Xəbərdarlıq",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

            var netice = await _musteriManager.ManualBalElaveEtAsync(
                _view.SecilenMusteriId,
                _view.BalMiqdari,
                _view.Aciklama);

            if (netice.UgurluDur)
            {
                _view.MesajGoster("Bal uğurla manual əlavə edildi", "Uğur",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                await MusteriBonusMelumatlariniYukle();
                await BonusTarixcesiniYukle();
                await ButunBonuslariYukle();
                _view.EmeliyyatSaheleriniTemizle();
            }
            else
            {
                _view.MesajGoster(netice.Mesaj ?? "Bal manual əlavə edilə bilmədi", "Xəta",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Bal manual əlavə edilərkən xəta");
            _view.MesajGoster($"Bal manual əlavə edilərkən xəta: {ex.Message}", "Xəta",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Məlumatları yeniləyir
    /// </summary>
    private async Task Yenile()
    {
        try
        {
            await MusterileriYukle();
            await ButunBonuslariYukle();

            if (_view.SecilenMusteriId > 0)
            {
                await MusteriBonusMelumatlariniYukle();
                await BonusTarixcesiniYukle();
            }

            _view.MesajGoster("Məlumatlar yeniləndi", "Uğur",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Məlumatlar yenilənərkən xəta");
            _view.MesajGoster($"Məlumatlar yenilənərkən xəta: {ex.Message}", "Xəta",
                System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
    }
}
