using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Yardimcilar;
using AzAgroPOS.Verilenler.Interfeysler;
using Microsoft.Extensions.DependencyInjection;

namespace AzAgroPOS.Teqdimat.Teqdimatcilar;

public class LoginPresenter : IDisposable
{
    private readonly ILoginView _view;
    private readonly TehlukesizlikManager _tehlukesizlikManager;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IcazeManager _icazeManager;
    private readonly IServiceProvider _serviceProvider;
    private readonly SemaphoreSlim _loginSemaphore = new(1, 1);
    private bool _disposed;

    public LoginPresenter(ILoginView view, TehlukesizlikManager tehlukesizlikManager, IUnitOfWork unitOfWork, IcazeManager icazeManager, IServiceProvider serviceProvider)
    {
        _view = view;
        _tehlukesizlikManager = tehlukesizlikManager;
        _unitOfWork = unitOfWork;
        _icazeManager = icazeManager;
        _serviceProvider = serviceProvider;
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

            // İstifadəçinin açıq növbəsini yoxla və yüklə
            await AciqNovbeniYukle(netice.Data.Id);

            _view.UgurluDaxilOlundu = true;
            _view.FormuBagla();
        }
        else
        {
            _view.MesajGoster(netice.Mesaj);
        }
    }

    /// <summary>
    /// İstifadəçinin açıq növbəsini yoxlayır və AktivSessiya-ya yükləyir
    /// Threading problemini həll etmək üçün ayrı scope yaradır
    /// </summary>
    private async Task AciqNovbeniYukle(int istifadeciId)
    {
        try
        {
            // Threading problemini həll etmək üçün yeni scope yaradırıq
            // Bu DbContext-in eyni vaxtda müxtəlif thread-lər tərəfindən istifadəsini önləyir
            using (var scope = _serviceProvider.CreateScope())
            {
                var novbeManager = scope.ServiceProvider.GetRequiredService<NovbeManager>();

                // İstifadəçinin açıq növbəsini tap
                var aciqNovbe = await novbeManager.AktivNovbeniGetirAsync(istifadeciId);

                if (aciqNovbe != null)
                {
                    // Aktiv növbə ID-sini təyin et
                    AktivSessiya.AktivNovbeId = aciqNovbe.Id;
                    System.Diagnostics.Debug.WriteLine($"[LoginPresenter] Açıq növbə tapıldı və yükləndi: ID={aciqNovbe.Id}");
                }
                else
                {
                    // Açıq növbə yoxdursa, null təyin et
                    AktivSessiya.AktivNovbeId = null;
                    System.Diagnostics.Debug.WriteLine("[LoginPresenter] Açıq növbə tapılmadı");
                }
            }
        }
        catch (Exception ex)
        {
            // Xəta baş versə də növbə məlumatını yükləyə bilmərik
            // Amma giriş prosesini dayandırma
            AktivSessiya.AktivNovbeId = null;
            System.Diagnostics.Debug.WriteLine($"[LoginPresenter] Növbə yüklənərkən xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// Resurları azad edir (Dispose pattern)
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Resurları azad edir (protected virtual method)
    /// </summary>
    /// <param name="disposing">Managed resurları azad etmək üçün true</param>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                // Managed resurları azad et
                _loginSemaphore?.Dispose();
            }
            _disposed = true;
        }
    }
}
