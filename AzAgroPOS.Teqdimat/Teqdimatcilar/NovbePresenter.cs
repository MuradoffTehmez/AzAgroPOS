// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/NovbePresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar;
// Gərəkli using-lər...
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Yardimcilar;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;
using System;
using System.Text;
using System.Threading.Tasks;
public class NovbePresenter
{
    private readonly INovbeView _view;
    private readonly NovbeManager _manager;
    private AzAgroPOS.Varliglar.Novbe? _aktivNovbe;

    public NovbePresenter(INovbeView view)
    {
        _view = view;
        _manager = new NovbeManager(new UnitOfWork(new AzAgroPOSDbContext()));
        _view.NovbeAc_Istek += async (s, e) => await NovbeAc();
        _view.NovbeBagla_Istek += async (s, e) => await NovbeBagla();
        Task.Run(async () => await FormuYukle());
    }

    private async Task FormuYukle()
    {
        _aktivNovbe = await _manager.AktivNovbeniGetirAsync(AktivSessiya.AktivIstifadeci.Id);
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

    private async Task NovbeAc()
    {
        var netice = await _manager.NovbeAcAsync(AktivSessiya.AktivIstifadeci.Id, _view.BaslangicMebleg);
        if (netice.UgurluDur)
        {
            _aktivNovbe = netice.Data;
            AktivSessiya.AktivNovbeId = _aktivNovbe.Id;
            _view.NovbeAciqdirGoster(AktivSessiya.AktivIstifadeci.TamAd, _aktivNovbe.AcilmaTarixi);
        }
    }

    private async Task NovbeBagla()
    {
        var netice = await _manager.NovbeBaglaAsync(_aktivNovbe.Id, _view.FaktikiMebleg);
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