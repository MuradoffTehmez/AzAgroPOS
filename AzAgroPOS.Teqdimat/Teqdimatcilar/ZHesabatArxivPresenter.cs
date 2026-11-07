// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/ZHesabatArxivPresenter.cs

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Teqdimat.Interfeysler;
using System.Text;

namespace AzAgroPOS.Teqdimat.Teqdimatcilar;

public class ZHesabatArxivPresenter
{
    private readonly IZHesabatArxivView _view;
    private readonly HesabatManager _hesabatManager;
    private readonly NovbeManager _novbeManager;
    private List<BaglanmisNovbeDto> _butunNovbeler = new();

    public ZHesabatArxivPresenter(IZHesabatArxivView view, HesabatManager hesabatManager)
    {
        _view = view;
        _hesabatManager = hesabatManager;

        _view.FormYuklendi += async (s, e) => await FormuYukle();
        _view.HesabatGosterIstek += async (s, e) => await ZHesabatiGoster();
        _view.HesabatSecimDeyisdi += async (s, e) => await DetallariYukle();
        _view.TarixFiltrDeyisdi += (s, e) => Filtrle();
    }

    private async Task FormuYukle()
    {
        EmeliyyatNeticesi<List<BaglanmisNovbeDto>> netice = await _hesabatManager.BaglanmisNovbeleriGetirAsync();
        if (netice.UgurluDur)
        {
            _butunNovbeler = netice.Data;
            Filtrle();
        }
        else
        {
            _view.MesajGoster(netice.Mesaj);
        }
    }

    private void Filtrle()
    {
        List<BaglanmisNovbeDto> novbeler = _butunNovbeler
            .Where(n => n.BaglanmaTarixi >= _view.BaslangicTarixi && n.BaglanmaTarixi <= _view.BitisTarixi)
            .ToList();
        _view.NovbeleriGoster(novbeler);
        _view.XulaseGoster(novbeler.Count, novbeler.Sum(n => n.CemiSatis),
            novbeler.Sum(n => n.NagdSatis), novbeler.Sum(n => n.KartSatis));
    }

    private async Task DetallariYukle()
    {
        if (!_view.SecilmisNovbeId.HasValue) return;
        EmeliyyatNeticesi<ZHesabatDto> netice = await _hesabatManager.ZHesabatTekrarGetirAsync(_view.SecilmisNovbeId.Value);
        if (netice.UgurluDur)
            _view.HesabatDetallariGoster(netice.Data);
    }

    private async Task ZHesabatiGoster()
    {
        if (!_view.SecilmisNovbeId.HasValue)
        {
            _view.MesajGoster("Zəhmət olmasa, cədvəldən bir növbə seçin.");
            return;
        }

        EmeliyyatNeticesi<ZHesabatDto> netice = await _hesabatManager.ZHesabatTekrarGetirAsync(_view.SecilmisNovbeId.Value);

        if (netice.UgurluDur)
        {
            ZHesabatDto? h = netice.Data;
            StringBuilder sb = new();
            sb.AppendLine("         Z-HESABATI (Arxiv)");
            sb.AppendLine("---------------------------------");
            sb.AppendLine($"Kassir: {h.KassirAdi}");
            sb.AppendLine($"Açılış: {h.AcilmaTarixi:dd.MM.yyyy HH:mm}");
            sb.AppendLine($"Bağlanış: {h.BaglanmaTarixi:dd.MM.yyyy HH:mm}");
            sb.AppendLine("---------------------------------");
            sb.AppendLine($"Başlanğıc Məbləğ: {h.BaslangicMebleg:N2} AZN");
            sb.AppendLine($"Nağd Satışlar: {h.NagdSatislar:N2} AZN");
            sb.AppendLine($"Kart Satışları: {h.KartSatislar:N2} AZN");
            sb.AppendLine($"Nisyə satışları: {h.NisyeSatislar:N2} AZN");
            sb.AppendLine($"Nağd borc ödənişləri: {h.NagdBorcOdenisleri:N2} AZN");
            sb.AppendLine($"Kart borc ödənişləri: {h.KartBorcOdenisleri:N2} AZN");
            sb.AppendLine($"Nağd qaytarmalar: -{h.NagdQaytarmalar:N2} AZN");
            sb.AppendLine($"Kart qaytarmaları: -{h.KartQaytarmalar:N2} AZN");
            sb.AppendLine($"Kassa xərcləri: -{h.NagdXercler:N2} AZN");
            sb.AppendLine($"Tədarükçü ödənişləri: -{h.TedarukcuOdemeleri:N2} AZN");
            sb.AppendLine($"CƏMİ SATIŞ: {h.CemiSatislar:N2} AZN");
            sb.AppendLine("---------------------------------");
            sb.AppendLine($"Gözlənilən Məbləğ: {h.GozlenilenMebleg:N2} AZN");
            sb.AppendLine($"Faktiki Məbləğ: {h.FaktikiMebleg:N2} AZN");
            sb.AppendLine(h.SayimAparilib ? $"FƏRQ: {h.Ferq:N2} AZN" : "Faktiki məbləğ sayılmayıb");

            _view.HesabatiGoster(sb.ToString());
        }
        else
        {
            _view.MesajGoster(netice.Mesaj);
        }
    }
}
