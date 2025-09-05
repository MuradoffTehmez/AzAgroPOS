// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/MehsulSatisHesabatPresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar;

using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;
using System.Threading.Tasks;

/// <summary>
/// Məhsul üzrə satış hesabatı formu ilə biznes məntiqi arasında əlaqəni qurur.
/// </summary>
public class MehsulSatisHesabatPresenter
{
    private readonly IMehsulSatisHesabatView _view;
    private readonly HesabatManager _hesabatManager;

    public MehsulSatisHesabatPresenter(IMehsulSatisHesabatView view, HesabatManager hesabatManager)
    {
        _view = view;
        _hesabatManager = hesabatManager;
        //_hesabatManager = new HesabatManager(unitOfWork);

        _view.HesabatiGosterIstek += async (s, e) => await MehsulSatisHesabatiniGoster();
    }

    private async Task MehsulSatisHesabatiniGoster()
    {
        var netice = await _hesabatManager.MehsulUzreSatisHesabatiGetirAsync(_view.BaslangicTarix, _view.BitisTarix);

        if (netice.UgurluDur)
        {
            _view.HesabatiGoster(netice.Data);
        }
        else
        {
            _view.MesajGoster(netice.Mesaj);
        }
    }
}