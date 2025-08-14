// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/NisyePresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar;

// using-lər
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;

public class NisyePresenter
{
    private readonly INisyeView _view;
    private readonly NisyeManager _nisyeManager;

    public NisyePresenter(INisyeView view)
    {
        _view = view;
        var unitOfWork = new UnitOfWork(new AzAgroPOSDbContext());
        _nisyeManager = new NisyeManager(unitOfWork);

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

    private async Task MusteriHereketleriniYukle()
    {
        if (_view.SecilmisMusteriId.HasValue)
        {
            var netice = await _nisyeManager.MusteriHereketleriniGetirAsync(_view.SecilmisMusteriId.Value);
            if (netice.UgurluDur)
                _view.MusteriHereketleriniGoster(netice.Data);
        }
    }

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