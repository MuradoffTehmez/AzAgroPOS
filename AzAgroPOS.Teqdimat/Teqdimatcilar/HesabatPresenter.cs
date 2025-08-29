// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/HesabatPresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar;

using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;
using System.Threading.Tasks;

/// <summary>
/// Hesabat formu ilə biznes məntiqi (HesabatManager) arasında əlaqəni qurur.
/// </summary>
public class HesabatPresenter
{
    private readonly IHesabatView _view;
    private readonly HesabatManager _hesabatManager;

    public HesabatPresenter(IHesabatView view)
    {
        _view = view;
        var unitOfWork = new UnitOfWork(new AzAgroPOSDbContext());
        _hesabatManager = new HesabatManager(unitOfWork);

        _view.HesabatiGosterIstek += async (s, e) => await GunlukHesabatiGoster();
    }

    private async Task GunlukHesabatiGoster()
    {
        _view.PanelləriSıfırla();
        var netice = await _hesabatManager.GunlukSatisHesabatiGetirAsync(_view.SecilmisTarix);

        if (netice.UgurluDur)
        {
            _view.HesabatiGoster(netice.Data);
        }
        else
        {
            _view.XetaMesajiGoster(netice.Mesaj);
        }
    }
}