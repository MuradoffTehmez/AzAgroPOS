// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/SatisPresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar;

// Gərəkli using-lər
using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;
using AzAgroPOS.Varliglar;

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

        // Səbətdə eyni məhsul varsa, sayını artır
        var sebettekiElement = _sebet.FirstOrDefault(e => e.MehsulId == tapilanMehsul.Id);
        if (sebettekiElement != null)
        {
            sebettekiElement.Miqdar++;
        }
        else // Yoxdursa, səbətə yeni əlavə et
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
        var netice = await _satisManager.SatisiTesdiqleAsync(_sebet, OdenisMetodu.Nağd); // Hələlik Nağd
        if (netice.UgurluDur)
        {
            _view.MesajGoster("Satış uğurla tamamlandı!", "Uğurlu Əməliyyat", MessageBoxButtons.OK, MessageBoxIcon.Information);
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