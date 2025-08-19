// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/NisyePresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar;

// using-lər
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;

/// <summary>
///  bu presenter, müştəri nisye əməliyyatlarını idarə etmək üçün istifadə olunur.
/// </summary>
public class NisyePresenter
{
    private readonly INisyeView _view;
    private readonly NisyeManager _nisyeManager;

    /// <summary>
    /// nisye presenter, müştəri nisye əməliyyatlarını idarə etmək üçün istifadə olunur.
    /// </summary>
    /// <param name="view"></param>
    public NisyePresenter(INisyeView view)
    {
        _view = view;
        var unitOfWork = new UnitOfWork(new AzAgroPOSDbContext());
        _nisyeManager = new NisyeManager(unitOfWork);

        _view.FormYuklendi += async (s, e) => await FormuYukle();
        _view.MusteriSecildi += async (s, e) => await MusteriHereketleriniYukle();
        _view.OdenisEdildi += async (s, e) => await OdenisEt();
    }
    /// <summary>
    /// bu metod, form yükləndikdə müştəri siyahısını yükləyir və göstərir.
    /// </summary>
    /// <returns></returns>
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
        if (!_view.SecilmisMusteriId.HasValue)
        {
            _view.MesajGoster("Zəhmət olmasa, əvvəlcə müştəri seçin.", "Xəbərdarlıq");
            return;
        }

        var mebleg = _view.OdenisMeblegi;
        var netice = await _nisyeManager.BorcOdenisiEtAsync(_view.SecilmisMusteriId.Value, mebleg);

        if (netice.UgurluDur)
        {
            _view.MesajGoster("Ödəniş uğurla qeydə alındı.", "Uğurlu Əməliyyat");
            // Formları yeniləmə
            await FormuYukle();
            await MusteriHereketleriniYukle();
            _view.FormuTemizle();
        }
        else
        {
            _view.MesajGoster(netice.Mesaj, "Xəta");
        }
    }
}