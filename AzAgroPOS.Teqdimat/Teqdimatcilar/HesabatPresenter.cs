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
    /// <summary>
    /// hesabatPresenter konstruktoru, HesabatView və HesabatManager nümunələrini qəbul edir və hadisə abunəliyini təyin edir.
    /// </summary>
    /// <param name="view"></param>
    public HesabatPresenter(IHesabatView view, HesabatManager hesabatManager)
    {
        _view = view;
        _hesabatManager = hesabatManager;
        //_hesabatManager = new HesabatManager(unitOfWork);

        _view.HesabatiGosterIstek += async (s, e) => await GunlukHesabatiGoster();
    }
    /// <summary>
    /// Günlük satış hesabatını göstərir.
    /// </summary>
    /// <returns></returns>
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