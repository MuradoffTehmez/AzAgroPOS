// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/NovbePresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar;
// Gərəkli using-lər
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Yardimcilar;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// Class NovbePresenter, INovbeView interfeysini alır və növbə əməliyyatlarını idarə etmək üçün NovbeManager ilə əlaqələndirir.
/// </summary>
public class NovbePresenter
{
    private readonly INovbeView _view;
    private readonly NovbeManager _novbeManager;
    private readonly IstifadeciManager _istifadeciManager;
    private AzAgroPOS.Varliglar.Novbe? _aktivNovbe;

    /// <summary>
    /// NovbePresenter, INovbeView interfeysini alır və NovbeManager ilə əlaqələndirir. 
    /// Novbemanager, növbə əməliyyatlarını idarə etmək üçün istifadə olunur.
    /// </summary>
    /// <param name="view"></param>
    public NovbePresenter(INovbeView view, NovbeManager novbeManager, IstifadeciManager istifadeciManager)
    {
        _view = view;
        _novbeManager = novbeManager;
        _istifadeciManager = istifadeciManager;
        _view.NovbeAc_Istek += async (s, e) => await NovbeAc();
        _view.NovbeBagla_Istek += async (s, e) => await NovbeBagla();
        Task.Run(async () => await FormuYukle());
    }


    /// <summary>
    /// FormuYukle metodu, form yükləndikdə aktiv növbəni yükləyir və göstərir. Dəyişikliklər varsa, istifadəçiyə aktiv növbənin açıq olduğunu və açılma tarixini göstərir.
    /// </summary>
    /// <returns></returns>
    private async Task FormuYukle()
    {
        if (AktivSessiya.AktivIstifadeci == null) return;

        _aktivNovbe = await _novbeManager.AktivNovbeniGetirAsync(AktivSessiya.AktivIstifadeci.Id);
        if (_aktivNovbe != null)
        {
            AktivSessiya.AktivNovbeId = _aktivNovbe.Id;
            _view.NovbeAciqdirGoster(AktivSessiya.AktivIstifadeci.TamAd, _aktivNovbe.AcilmaTarixi);
        }
        else
        {
            AktivSessiya.AktivNovbeId = null;
            _view.NovbeBaxlidirGoster();
        }
    }

    /// <summary>
    /// NovbeAc metodu, yeni bir növbə açmaq üçün istifadə olunur.
    /// </summary>
    /// <returns></returns>
    private async Task NovbeAc()
    {
        if (AktivSessiya.AktivIstifadeci == null) return;

        var netice = await _novbeManager.NovbeAcAsync(AktivSessiya.AktivIstifadeci.Id, _view.BaslangicMebleg);
        if (netice.UgurluDur)
        {
            _aktivNovbe = netice.Data;
            AktivSessiya.AktivNovbeId = _aktivNovbe.Id;
            _view.NovbeAciqdirGoster(AktivSessiya.AktivIstifadeci.TamAd, _aktivNovbe.AcilmaTarixi);
        }
    }
    /// <summary>
    ///  bu metod, aktiv növbəni bağlayır və hesabatı göstərir.
    ///  Z-hesabatı, kassir adı, açılış və bağlanma tarixləri, başlanğıc məbləği, nağd və kart satışları, gözlənilən və faktiki məbləğlər daxil olmaqla məlumatları ehtiva edir.
    ///  </summary>
    /// <returns>j</returns>
    private async Task NovbeBagla()
    {
        if (_aktivNovbe == null) return;

        var netice = await _novbeManager.NovbeBaglaAsync(_aktivNovbe.Id, _view.FaktikiMebleg);
        if (netice.UgurluDur)
        {
            AktivSessiya.AktivNovbeId = null;
            _view.NovbeBaxlidirGoster();
            var h = netice.Data;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("         Z-HESABATI");
            sb.AppendLine("---------------------------------");
            sb.AppendLine($"Kassir: {h.KassirAdi}");
            sb.AppendLine($"Açılış: {h.AcilmaTarixi:dd.MM.yyyy HH:mm}");
            sb.AppendLine($"Bağlanış: {h.BaglanmaTarixi:dd.MM.yyyy HH:mm}");
            sb.AppendLine("---------------------------------");
            sb.AppendLine($"Başlanğıc Məbləğ: {h.BaslangicMebleg:N2} AZN");
            sb.AppendLine($"Nağd Satışlar: {h.NagdSatislar:N2} AZN");
            sb.AppendLine($"Kart Satışları: {h.KartSatislar:N2} AZN");
            sb.AppendLine($"CƏMİ SATIŞ: {h.CemiSatislar:N2} AZN");
            sb.AppendLine("---------------------------------");
            sb.AppendLine($"Gözlənilən Məbləğ: {h.GozlenilenMebleg:N2} AZN");
            sb.AppendLine($"Faktiki Məbləğ: {h.FaktikiMebleg:N2} AZN");
            sb.AppendLine($"FƏRQ: {h.Ferq:N2} AZN");
            _view.HesabatGoster(sb.ToString());
        }
    }
}