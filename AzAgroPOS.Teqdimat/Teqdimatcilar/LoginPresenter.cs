using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Mentiq.Yardimcilar;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Yardimcilar;
using AzAgroPOS.Verilenler.Interfeysler;

namespace AzAgroPOS.Teqdimat.Teqdimatcilar;

public class LoginPresenter
{
    private readonly ILoginView _view;
    private readonly TehlukesizlikManager _tehlukesizlikManager;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IcazeManager _icazeManager;
    private readonly SemaphoreSlim _loginSemaphore = new(1, 1);

    public LoginPresenter(ILoginView view, TehlukesizlikManager tehlukesizlikManager, IUnitOfWork unitOfWork, IcazeManager icazeManager)
    {
        _view = view;
        _tehlukesizlikManager = tehlukesizlikManager;
        _unitOfWork = unitOfWork;
        _icazeManager = icazeManager;
        _view.DaxilOl_Istek += OnDaxilOl;

        // IcazeYoxlayici-ni initialize et
        AzAgroPOS.Mentiq.Yardimcilar.IcazeYoxlayici.Instance.IcazeManagerTeyinEt(_icazeManager);
    }

    private async void OnDaxilOl(object? sender, EventArgs e)
    {
        if (!await _loginSemaphore.WaitAsync(0))
        {
            _view.MesajGoster("Giriş prosesi artıq davam edir. Zəhmət olmasa tamamlanmasını gözləyin.");
            return;
        }

        try
        {
            await DaxilOlAsync();
        }
        catch (Exception ex)
        {
            _view.MesajGoster($"Giriş zamanı xəta baş verdi: {ex.Message}");
        }
        finally
        {
            _loginSemaphore.Release();
        }
    }

    private async Task DaxilOlAsync()
    {
        var netice = await _tehlukesizlikManager.DaxilOlAsync(_view.IstifadeciAdi, _view.Parol);

        if (netice.UgurluDur)
        {
            AktivSessiya.AktivIstifadeci = netice.Data;
            _unitOfWork.AktivIstifadeciniTeyinEt(netice.Data.Id);

            // İstifadəçi entity-ni verilənlər bazasından götür (icazələrlə birlikdə)
            var istifadeci = await _unitOfWork.Istifadeciler.GetirAsync(netice.Data.Id);
            if (istifadeci != null)
            {
                // İcazeYoxlayici-yə aktiv istifadəçini təyin et
                await AzAgroPOS.Mentiq.Yardimcilar.IcazeYoxlayici.Instance.AktivIstifadeciniTeyinEtAsync(istifadeci);
            }

            _view.UgurluDaxilOlundu = true;
            _view.FormuBagla();
        }
        else
        {
            _view.MesajGoster(netice.Mesaj);
        }
    }
}
