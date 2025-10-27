using System.Windows.Forms;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Yardimcilar;
using AzAgroPOS.Verilenler.Interfeysler;

namespace AzAgroPOS.Teqdimat.Teqdimatcilar
{
    public class LoginPresenter
    {
        private readonly ILoginView _view;
        private readonly TehlukesizlikManager _tehlukesizlikManager;
        private readonly IUnitOfWork _unitOfWork;

        public LoginPresenter(ILoginView view, TehlukesizlikManager tehlukesizlikManager, IUnitOfWork unitOfWork)
        {
            _view = view;
            _tehlukesizlikManager = tehlukesizlikManager;
            _unitOfWork = unitOfWork;
            _view.DaxilOl_Istek += OnDaxilOl;
        }

        private void OnDaxilOl(object sender, EventArgs e)
        {
            // Use Task.Run to execute the async operation on a background thread
            // This avoids blocking the UI thread and prevents concurrent access issues
            Task.Run(async () => 
            {
                try
                {
                    await DaxilOl();
                }
                catch (Exception ex)
                {
                    // Marshal the exception back to the UI thread
                    if (_view is Control control && control.InvokeRequired)
                    {
                        control.Invoke((MethodInvoker)delegate {
                            _view.MesajGoster($"Giriş zamanı xəta baş verdi: {ex.Message}");
                        });
                    }
                    else
                    {
                        _view.MesajGoster($"Giriş zamanı xəta baş verdi: {ex.Message}");
                    }
                }
            });
        }

        private async Task DaxilOl()
        {
            var netice = await _tehlukesizlikManager.DaxilOlAsync(_view.IstifadeciAdi, _view.Parol);

            if (netice.UgurluDur)
            {
                AktivSessiya.AktivIstifadeci = netice.Data;
                _unitOfWork.AktivIstifadeciniTeyinEt(netice.Data.Id);
                _view.UgurluDaxilOlundu = true;
                _view.FormuBagla();
            }
            else
            {
                _view.MesajGoster(netice.Mesaj);
            }
        }
    }
}