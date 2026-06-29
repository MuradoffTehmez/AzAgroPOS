// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/HesabatPresenter.cs

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Teqdimat.Interfeysler;

namespace AzAgroPOS.Teqdimat.Teqdimatcilar;
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
        EmeliyyatNeticesi<GunlukSatisHesabatDto> netice = await _hesabatManager.GunlukSatisHesabatiGetirAsync(_view.SecilmisTarix);

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