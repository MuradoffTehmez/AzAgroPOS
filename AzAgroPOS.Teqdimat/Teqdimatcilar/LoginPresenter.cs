// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/LoginPresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar;
// using-lər
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Yardimcilar;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;

public class LoginPresenter
{
    private readonly ILoginView _view;
    private readonly TehlukesizlikManager _manager;

    public LoginPresenter(ILoginView view)
    {
        _view = view;
        _manager = new TehlukesizlikManager(new UnitOfWork(new AzAgroPOSDbContext()));
        _view.DaxilOl_Istek += async (s, e) => await DaxilOl();
    }

    private async Task DaxilOl()
    {
        var netice = await _manager.DaxilOlAsync(_view.IstifadeciAdi, _view.Parol);

        if (netice.UgurluDur)
        {
            AktivSessiya.AktivIstifadeci = netice.Data;
            _view.UgurluDaxilOlundu = true;
            _view.FormuBagla();
        }
        else
        {
            _view.MesajGoster(netice.Mesaj);
        }
    }
}