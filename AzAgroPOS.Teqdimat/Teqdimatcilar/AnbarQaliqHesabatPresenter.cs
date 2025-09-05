// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/AnbarQaliqHesabatPresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar;

using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;
using System.Threading.Tasks;

public class AnbarQaliqHesabatPresenter
{
    private readonly IAnbarQaliqHesabatView _view;
    private readonly HesabatManager _hesabatManager;

    public AnbarQaliqHesabatPresenter(IAnbarQaliqHesabatView view, HesabatManager hesabatManager)
    {
        _view = view;
        _hesabatManager = hesabatManager;
        //_hesabatManager = new HesabatManager(unitOfWork);

        _view.HesabatiGosterIstek += async (s, e) => await AnbarQaliqHesabatiniGoster();
    }

    private async Task AnbarQaliqHesabatiniGoster()
    {
        if (!int.TryParse(_view.LimitSay, out int limit))
        {
            _view.MesajGoster("Zəhmət olmasa, limit üçün düzgün bir rəqəm daxil edin.");
            return;
        }

        var netice = await _hesabatManager.AnbarQaliqHesabatiGetirAsync(limit);

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