// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/AnbarPresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar;

using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using System.Threading.Tasks;
using System.Windows.Forms;


/// <summary>
/// Anbar formu ilə biznes məntiqi (AnbarManager) arasında əlaqəni qurur.
/// </summary>
public class AnbarPresenter
{
    private readonly IAnbarView _view;
    private readonly AnbarManager _anbarManager;

    public AnbarPresenter(IAnbarView view, AnbarManager anbarManager)
    {
        _view = view;
        _anbarManager = anbarManager;
        //_anbarManager = new AnbarManager(unitOfWork);

        _view.AxtarIstek += async (s, e) => await MehsulAxtar();
        _view.StokArtirIstek += async (s, e) => await StokArtir();
    }

    private async Task MehsulAxtar()
    {
        var netice = await _anbarManager.MehsulTapAsync(_view.AxtarisMetni);
        if (netice.UgurluDur)
        {
            _view.MehsulMelumatlariniGoster(netice.Data);
        }
        else
        {
            _view.MesajGoster(netice.Mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            _view.FormuTemizle(true);
        }
    }

    private async Task StokArtir()
    {
        if (!_view.SecilmisMehsulId.HasValue)
        {
            _view.MesajGoster("Zəhmət olmasa, əvvəlcə məhsul axtarın.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!int.TryParse(_view.ElaveOlunanSay, out int say))
        {
            _view.MesajGoster("Əlavə olunacaq say düzgün formatda deyil.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var netice = await _anbarManager.AnbardakiStokuArtirAsync(_view.SecilmisMehsulId.Value, say);

        if (netice.UgurluDur)
        {
            _view.MesajGoster($"Məhsulun yeni sayı: {netice.Data}", "Uğurlu Əməliyyat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _view.FormuTemizle();
        }
        else
        {
            _view.MesajGoster(netice.Mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}