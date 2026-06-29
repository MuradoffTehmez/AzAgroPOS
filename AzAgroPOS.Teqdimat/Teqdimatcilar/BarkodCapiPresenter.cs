// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/BarkodCapiPresenter.cs

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Servisler;

namespace AzAgroPOS.Teqdimat.Teqdimatcilar;

public class BarkodCapiPresenter
{
    private readonly IBarkodCapiView _view;
    private readonly BarkodCapiManager _barkodCapiManager;
    private readonly MehsulManager _mehsulManager;
    public BarkodCapiPresenter(IBarkodCapiView view, BarkodCapiManager barkodCapiManager, MehsulManager mehsulManager)
    {
        _view = view;
        _barkodCapiManager = barkodCapiManager;
        _mehsulManager = mehsulManager;

        _view.AxtarisIstek += async (s, e) => await MehsulAxtar();
        _view.SiyahiniCapaGonderIstek += (s, e) => SiyahiniCapaGonder();
    }

    private async Task MehsulAxtar()
    {
        EmeliyyatNeticesi<List<MehsulDto>> netice = await _barkodCapiManager.MehsullariAxtarAsync(_view.AxtarisMetni);
        if (netice.UgurluDur)
        {
            _view.AxtarisNeticeleriniGoster(netice.Data);
        }
        else
        {
            _view.AxtarisXetasiGoster(netice.Mesaj);
        }
    }

    private void SiyahiniCapaGonder()
    {
        List<BarkodEtiketDto> siyahı = _view.CapSiyahisi;
        if (siyahı == null || !siyahı.Any())
        {
            _view.MesajGoster("Çap etmək üçün siyahı boşdur.", "Xəbərdarlıq");
            return;
        }

        try
        {
            BarkodCapServisi capServisi = new();
            capServisi.EtiketleriCapaGonder(siyahı);
        }
        catch (System.Exception ex)
        {
            _view.MesajGoster($"Çap zamanı xəta baş verdi: {ex.Message}", "Xəta");
        }
    }
}