// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/BarkodCapiPresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Servisler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class BarkodCapiPresenter
{
    private readonly IBarkodCapiView _view;
    private readonly BarkodCapiManager _barkodCapiManager;
    private readonly MehsulManager _mehsulManager;
    private readonly BarkodCapiManager _manager;
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
        var netice = await _manager.MehsullariAxtarAsync(_view.AxtarisMetni);
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
        var siyahı = _view.CapSiyahisi;
        if (siyahı == null || !siyahı.Any())
        {
            _view.MesajGoster("Çap etmək üçün siyahı boşdur.", "Xəbərdarlıq");
            return;
        }

        try
        {
            BarkodCapServisi capServisi = new BarkodCapServisi();
            capServisi.EtiketleriCapaGonder(siyahı);
        }
        catch (System.Exception ex)
        {
            _view.MesajGoster($"Çap zamanı xəta baş verdi: {ex.Message}", "Xəta");
        }
    }
}