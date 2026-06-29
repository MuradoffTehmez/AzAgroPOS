// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/AnbarQaliqHesabatPresenter.cs

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Teqdimat.Interfeysler;

namespace AzAgroPOS.Teqdimat.Teqdimatcilar;

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

        EmeliyyatNeticesi<List<AnbarQaliqDetayDto>> netice = await _hesabatManager.AnbarQaliqHesabatiGetirAsync(limit);

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