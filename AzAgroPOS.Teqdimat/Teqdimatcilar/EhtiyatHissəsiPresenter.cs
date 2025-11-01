// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/EhtiyatHissəsiPresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar;

using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Mentiq.Yardimcilar;
using AzAgroPOS.Teqdimat.Interfeysler;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Ehtiyat hissəsi forması üçün presenter.
/// Məhsul ehtiyat hissələrini seçmək və idarə etmək üçün istifadə olunur.
/// </summary>
public class EhtiyatHissəsiPresenter
{
    private readonly IEhtiyatHissəsiView _view;
    private readonly MehsulManager _mehsulManager;

    public EhtiyatHissəsiPresenter(IEhtiyatHissəsiView view, MehsulManager mehsulManager)
    {
        _view = view ?? throw new ArgumentNullException(nameof(view));
        _mehsulManager = mehsulManager ?? throw new ArgumentNullException(nameof(mehsulManager));

        // Hadisələrə abunə oluruq
        _view.AxtarIstek += async (s, e) => await MehsullariAxtar();
        _view.ElaveEtIstek += (s, e) => EhtiyatHissəsiElaveEt();
        _view.SilIstek += (s, e) => EhtiyatHissəsiSil();
        _view.TamamIstek += (s, e) => FormuTamamla();
        _view.İmtinaIstek += (s, e) => FormuImtinaEt();
    }

    /// <summary>
    /// Formu yükləyir - məhsul siyahısını göstərir
    /// </summary>
    public async Task FormuYukleAsync()
    {
        try
        {
            await MehsullariYukle();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Ehtiyat hissəsi formu yüklənərkən xəta");
            _view.MesajGoster($"Forma yüklənərkən xəta: {ex.Message}", "Xəta",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Məhsulları yükləyir
    /// </summary>
    private async Task MehsullariYukle()
    {
        try
        {
            var netice = await _mehsulManager.ButunMehsullariGetirAsync();
            if (netice.UgurluDur && netice.Data != null)
            {
                _view.MehsullariGoster(netice.Data.ToList());
            }
            else
            {
                _view.MesajGoster(netice.Mesaj ?? "Məhsullar yüklənə bilmədi", "Xəta",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Məhsullar yüklənərkən xəta");
            _view.MesajGoster($"Məhsullar yüklənərkən xəta: {ex.Message}", "Xəta",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Məhsulları axtarır
    /// </summary>
    private async Task MehsullariAxtar()
    {
        try
        {
            var netice = await _mehsulManager.ButunMehsullariGetirAsync();
            if (netice.UgurluDur && netice.Data != null)
            {
                var axtarisMetni = _view.AxtarisMetni?.ToLower() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(axtarisMetni))
                {
                    _view.MehsullariGoster(netice.Data.ToList());
                }
                else
                {
                    var filtrlenmisMehsullar = netice.Data
                        .Where(m => m.Ad.ToLower().Contains(axtarisMetni) ||
                                   m.StokKodu.ToLower().Contains(axtarisMetni))
                        .ToList();
                    _view.MehsullariGoster(filtrlenmisMehsullar);
                }
            }
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Məhsul axtarışı xətası");
            _view.MesajGoster($"Axtarış xətası: {ex.Message}", "Xəta",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Ehtiyat hissəsi əlavə edir
    /// </summary>
    private void EhtiyatHissəsiElaveEt()
    {
        try
        {
            if (_view.SecilmisMehsul == null)
            {
                _view.MesajGoster("Zəhmət olmasa məhsul seçin", "Xəbərdarlıq",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(_view.Miqdar, out decimal miqdar) || miqdar <= 0)
            {
                _view.MesajGoster("Zəhmət olmasa düzgün miqdar daxil edin", "Xəbərdarlıq",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ehtiyat hissəsinin əlavə edilməsi formada həyata keçirilir
            // çünki _ehtiyatHissələri siyahısı formada saxlanılır
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Ehtiyat hissəsi əlavə edilərkən xəta");
            _view.MesajGoster($"Əlavə etmə xətası: {ex.Message}", "Xəta",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Ehtiyat hissəsini silir
    /// </summary>
    private void EhtiyatHissəsiSil()
    {
        try
        {
            // Silinmə əməliyyatı formada həyata keçirilir
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Ehtiyat hissəsi silinərkən xəta");
            _view.MesajGoster($"Silmə xətası: {ex.Message}", "Xəta",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Formu tamamlayır
    /// </summary>
    private void FormuTamamla()
    {
        try
        {
            if (_view.EhtiyatHissələri == null || _view.EhtiyatHissələri.Count == 0)
            {
                _view.MesajGoster("Zəhmət olmasa ən azı bir məhsul əlavə edin", "Xəbərdarlıq",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Forma DialogResult.OK ilə bağlanır
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Forma tamamlanarkən xəta");
            _view.MesajGoster($"Tamamlama xətası: {ex.Message}", "Xəta",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Formadan imtina edir
    /// </summary>
    private void FormuImtinaEt()
    {
        try
        {
            // Forma DialogResult.Cancel ilə bağlanır
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Forma imtina edilərkən xəta");
        }
    }
}
