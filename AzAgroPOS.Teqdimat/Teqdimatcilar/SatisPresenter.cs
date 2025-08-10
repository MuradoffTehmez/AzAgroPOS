// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/SatisPresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Yardimcilar;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Teqdimat.Servisler;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

public class SatisPresenter
{
    private readonly ISatisView _view;
    private readonly MehsulManager _mehsulManager;
    private readonly SatisManager _satisManager;
    private readonly List<SatisSebetiElementiDto> _sebet;

    public SatisPresenter(ISatisView view)
    {
        _view = view;
        var unitOfWork = new UnitOfWork(new AzAgroPOSDbContext());
        _mehsulManager = new MehsulManager(unitOfWork);
        _satisManager = new SatisManager(unitOfWork);
        _sebet = new List<SatisSebetiElementiDto>();

        _view.BarkodDaxilEdildi_Istek += async (s, e) => await BarkodlaMehsulTap();
        _view.SatisiTesdiqle_Istek += async (s, e) => await SatisiTesdiqle();
    }

    private async Task BarkodlaMehsulTap()
    {
        var barkod = _view.BarkodAxtaris;
        if (string.IsNullOrWhiteSpace(barkod)) return;

        var butunMehsullar = (await _mehsulManager.ButunMehsullariGetirAsync()).Data;
        var tapilanMehsul = butunMehsullar?.FirstOrDefault(m => m.Barkod == barkod || m.StokKodu == barkod);

        if (tapilanMehsul == null)
        {
            _view.MesajGoster("Bu barkodla məhsul tapılmadı.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var sebettekiElement = _sebet.FirstOrDefault(e => e.MehsulId == tapilanMehsul.Id);
        if (sebettekiElement != null)
        {
            sebettekiElement.Miqdar++;
        }
        else
        {
            _sebet.Add(new SatisSebetiElementiDto
            {
                MehsulId = tapilanMehsul.Id,
                MehsulAdi = tapilanMehsul.Ad,
                Miqdar = 1,
                VahidinQiymeti = tapilanMehsul.SatisQiymeti
            });
        }
        GosterisleriYenile();
    }

    private async Task SatisiTesdiqle()
    {
        if (!AktivSessiya.AktivNovbeId.HasValue)
        {
            _view.MesajGoster("Aktiv növbə yoxdur. Satış etmək mümkün deyil.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var netice = await _satisManager.SatisiTesdiqleAsync(_sebet, OdenisMetodu.Nağd, AktivSessiya.AktivNovbeId.Value);

        if (netice.UgurluDur)
        {
            _view.MesajGoster("Satış uğurla tamamlandı!", "Uğurlu Əməliyyat", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var cavab = _view.MesajGoster("Qəbz çap edilsinmi?", "Çap", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cavab == DialogResult.Yes)
            {
                var qebzDto = new SatisQebzDto
                {
                    SatisId = netice.Data.Id,
                    Tarix = netice.Data.Tarix,
                    KassirAdi = AktivSessiya.AktivIstifadeci?.TamAd ?? "Naməlum",
                    SatilanMehsullar = new List<SatisSebetiElementiDto>(_sebet)
                };

                CapServisi capServisi = new CapServisi();
                capServisi.SatisiCapEt(qebzDto);
            }

            _sebet.Clear();
            GosterisleriYenile();
            _view.FormuSifirla();
        }
        else
        {
            _view.MesajGoster(netice.Mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void GosterisleriYenile()
    {
        _view.SebeteMehsulGoster(_sebet);
        _view.UmumiMebligiGoster(_sebet.Sum(e => e.UmumiMebleg));
    }
}