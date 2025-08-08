// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/TemirPresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar;
// using-lər
using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;

public class TemirPresenter
{
    private readonly ITemirView _view;
    private readonly TemirManager _temirManager;

    public TemirPresenter(ITemirView view)
    {
        _view = view;
        var unitOfWork = new UnitOfWork(new AzAgroPOSDbContext());
        _temirManager = new TemirManager(unitOfWork);

        _view.FormYuklendi += async (s, e) => await FormuYukle();
        _view.YeniSifarisYarat_Istek += async (s, e) => await YeniSifarisYarat();
    }

    private async Task FormuYukle()
    {
        var netice = await _temirManager.ButunSifarisleriGetirAsync();
        if (netice.UgurluDur)
            _view.SifarisleriGoster(netice.Data);
    }

    private async Task YeniSifarisYarat()
    {
        var yeniSifarisDto = new TemirDto
        {
            MusteriAdi = _view.MusteriAdi,
            MusteriTelefonu = _view.MusteriTelefonu,
            CihazAdi = _view.CihazAdi,
            ProblemTesviri = _view.ProblemTesviri,
            YekunMebleg = _view.YekunMebleg
        };

        var netice = await _temirManager.YeniSifarisYaratAsync(yeniSifarisDto);
        if (netice.UgurluDur)
        {
            _view.MesajGoster("Yeni təmir sifarişi uğurla yaradıldı.", "Uğurlu Əməliyyat");
            _view.FormuTemizle();
            await FormuYukle();
        }
        else
        {
            _view.MesajGoster(netice.Mesaj, "Xəta");
        }
    }
}