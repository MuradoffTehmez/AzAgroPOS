// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/NisyePresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar;

// using-lər
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;

/// <summary>
///  bu presenter, müştəri nisye əməliyyatlarını idarə etmək üçün istifadə olunur.
/// </summary>
public class NisyePresenter
{
    private readonly INisyeView _view;
    private readonly NisyeManager _nisyeManager;
    private readonly MusteriManager _musteriManager;

    public NisyePresenter(INisyeView view, NisyeManager nisyeManager, MusteriManager musteriManager)
    {
        _view = view;
        _nisyeManager = nisyeManager;
        _musteriManager = musteriManager;

        _view.FormYuklendi += async (s, e) => await FormuYukle();
        _view.MusteriSecildi += async (s, e) => await MusteriHereketleriniYukle();
        _view.OdenisEdildi += async (s, e) => await OdenisEt();
    }

    private async Task FormuYukle()
    {
        var netice = await _nisyeManager.MusterileriGetirAsync();
        if (netice.UgurluDur)
            _view.MusterileriGoster(netice.Data);
    }

    /// <summary>
    /// bu metod, seçilmiş müştərinin hərəkətlərini yükləyir və göstərir.
    /// </summary>
    /// <returns></returns>
    private async Task MusteriHereketleriniYukle()
    {
        if (_view.SecilmisMusteriId.HasValue)
        {
            var netice = await _nisyeManager.MusteriHereketleriniGetirAsync(_view.SecilmisMusteriId.Value);
            if (netice.UgurluDur)
                _view.MusteriHereketleriniGoster(netice.Data);
        }
    }
    /// <summary>
    /// bu metod, seçilmiş müştəri üçün ödəniş əməliyyatını həyata keçirir.
    /// </summary>
    /// <returns></returns>
    private async Task OdenisEt()
    {
        try
        {
            // Validation: Müştəri seçimi
            if (!_view.SecilmisMusteriId.HasValue)
            {
                _view.MesajGoster("Zəhmət olmasa əvvəlcə müştəri seçin", "Xəbərdarlıq",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

            // Validation: Məbləğ
            var mebleg = _view.OdenisMeblegi;
            if (mebleg <= 0)
            {
                _view.MesajGoster("Ödəniş məbləği müsbət olmalıdır", "Validation Xətası",
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

            // Confirmation dialog
            var confirmResult = _view.MesajGoster(
                $"Ödəniş məlumatları:\n\n" +
                $"Ödəniləcək məbləğ: {mebleg:N2} AZN\n\n" +
                $"Ödənişi təsdiq edirsiniz?",
                "Ödəniş Təsdiqi",
                System.Windows.Forms.MessageBoxButtons.YesNo,
                System.Windows.Forms.MessageBoxIcon.Question);

            if (confirmResult != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }

            // Düyməni disable et (multiple click-in qarşısını al)
            _view.OdenisButtonAktivdir = false;

            // Ödəniş əməliyyatını icra et
            var netice = await _nisyeManager.BorcOdenisiEtAsync(_view.SecilmisMusteriId.Value, mebleg);

            // Düyməni enable et
            _view.OdenisButtonAktivdir = true;

            if (netice.UgurluDur)
            {
                _view.MesajGoster(
                    $"Ödəniş uğurla qeydə alındı!\n\nÖdənilən məbləğ: {mebleg:N2} AZN",
                    "Uğurlu Əməliyyat",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Information);

                // Formları yenilə
                await FormuYukle();
                await MusteriHereketleriniYukle();
                _view.FormuTemizle();
            }
            else
            {
                _view.MesajGoster(netice.Mesaj, "Xəta",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            // Düyməni enable et (xəta halında)
            _view.OdenisButtonAktivdir = true;

            System.Diagnostics.Debug.WriteLine($"Ödəniş zamanı xəta: {ex.Message}\n{ex.StackTrace}");
            _view.MesajGoster(
                $"Ödəniş zamanı gözlənilməz xəta baş verdi:\n{ex.Message}",
                "Sistem Xətası",
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Error);
        }
    }
}