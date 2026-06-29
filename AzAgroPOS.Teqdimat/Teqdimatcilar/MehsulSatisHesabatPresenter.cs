// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/MehsulSatisHesabatPresenter.cs

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Teqdimat.Interfeysler;

namespace AzAgroPOS.Teqdimat.Teqdimatcilar;
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
        EmeliyyatNeticesi<List<MehsulUzreSatisDetayDto>> netice = await _hesabatManager.MehsulUzreSatisHesabatiGetirAsync(_view.BaslangicTarix, _view.BitisTarix);

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