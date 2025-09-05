// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/ZHesabatArxivPresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar;

using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;
using System.Text;
using System.Threading.Tasks;

public class ZHesabatArxivPresenter
{
    private readonly IZHesabatArxivView _view;
    private readonly HesabatManager _hesabatManager;
    private readonly NovbeManager _novbeManager;

    public ZHesabatArxivPresenter(IZHesabatArxivView view, HesabatManager hesabatManager)
    {
        _view = view;
        _hesabatManager = hesabatManager;

        _view.FormYuklendi += async (s, e) => await FormuYukle();
        _view.HesabatGosterIstek += async (s, e) => await ZHesabatiGoster();
    }

    private async Task FormuYukle()
    {
        var netice = await _hesabatManager.BaglanmisNovbeleriGetirAsync();
        if (netice.UgurluDur)
        {
            _view.NovbeleriGoster(netice.Data);
        }
        else
        {
            _view.MesajGoster(netice.Mesaj);
        }
    }

    private async Task ZHesabatiGoster()
    {
        if (!_view.SecilmisNovbeId.HasValue)
        {
            _view.MesajGoster("Zəhmət olmasa, cədvəldən bir növbə seçin.");
            return;
        }

        var netice = await _hesabatManager.ZHesabatTekrarGetirAsync(_view.SecilmisNovbeId.Value);

        if (netice.UgurluDur)
        {
            var h = netice.Data;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("         Z-HESABATI (Arxiv)");
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

            _view.HesabatiGoster(sb.ToString());
        }
        else
        {
            _view.MesajGoster(netice.Mesaj);
        }
    }
}