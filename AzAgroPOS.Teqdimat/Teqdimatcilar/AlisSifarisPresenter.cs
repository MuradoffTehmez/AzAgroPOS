// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/AlisSifarisPresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Verilenler.Interfeysler;
using System;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Alış sifarişi idarəetmə forması üçün presenter.
/// </summary>
public class AlisSifarisPresenter
{
    private readonly IAlisSifarisView _view;
    private readonly AlisManager _alisManager;

    public AlisSifarisPresenter(IAlisSifarisView view, AlisManager alisManager)
    {
        _view = view;
        _alisManager = alisManager;

        // Hadisələrə abunə oluruq
        _view.FormYuklendi += async (s, e) => await FormuYukle();
        _view.SifarisYarat_Istek += async (s, e) => await SifarisYarat();
        _view.SifarisYenile_Istek += async (s, e) => await SifarisYenile();
        _view.SifarisSil_Istek += async (s, e) => await SifarisSil();
        _view.SifarisTesdiqle_Istek += async (s, e) => await SifarisTesdiqle();
        _view.FormuTemizle_Istek += (s, e) => _view.FormuTemizle();
    }

    private async Task FormuYukle()
    {
        // Tədarükçüləri yükləyirik
        var tedarukcuNetice = await _alisManager.ButunTedarukculeriGetirAsync();
        if (tedarukcuNetice.UgurluDur)
        {
            _view.TedarukculeriGoster(tedarukcuNetice.Data.OrderBy(t => t.Ad).ToList());
        }
        else
        {
            _view.TedarukculeriGoster(new System.Collections.Generic.List<TedarukcuDto>());
        }

        // Məhsulları yükləyirik
        var mehsulManager = new MehsulManager(_alisManager /* Bu düzgün deyil, amma sadəlik üçün */);
        // TODO: Məhsulları yükləmək üçün uyğun meneceri əlavə edin

        // Sifarişləri yükləyirik
        var sifarisNetice = await _alisManager.ButunAlisSifarisleriniGetirAsync();
        if (sifarisNetice.UgurluDur)
        {
            _view.SifarisleriGoster(sifarisNetice.Data.OrderBy(s => s.YaradilmaTarixi).ToList());
        }
        else
        {
            _view.SifarisleriGoster(new System.Collections.Generic.List<AlisSifarisDto>());
            _view.MesajGoster(sifarisNetice.Mesaj, true);
        }
    }

    private async Task SifarisYarat()
    {
        var dto = new AlisSifarisDto
        {
            SifarisNomresi = _view.SifarisNomresi,
            YaradilmaTarixi = _view.YaradilmaTarixi,
            TesdiqTarixi = _view.TesdiqTarixi,
            GozlenilenTehvilTarixi = _view.GozlenilenTehvilTarixi,
            TedarukcuId = _view.TedarukcuId,
            UmumiMebleg = _view.UmumiMebleg,
            Qeydler = _view.Qeydler
        };

        var netice = await _alisManager.AlisSifarisYaratAsync(dto);

        if (netice.UgurluDur)
        {
            _view.MesajGoster("Alış sifarişi uğurla yaradıldı.");
            await FormuYukle();
            _view.FormuTemizle();
        }
        else
        {
            _view.MesajGoster(netice.Mesaj, true);
        }
    }

    private async Task SifarisYenile()
    {
        if (_view.SifarisId <= 0)
        {
            _view.MesajGoster("Yeniləmək üçün cədvəldən bir sifariş seçməlisiniz.", true);
            return;
        }

        // TODO: Sifarişi yeniləmək üçün tətbiqat

        _view.MesajGoster("Bu funksiya hələ tətbiq edilməyib.");
    }

    private async Task SifarisSil()
    {
        if (_view.SifarisId <= 0)
        {
            _view.MesajGoster("Silmək üçün cədvəldən sifariş seçin.", true);
            return;
        }

        // TODO: Sifarişi silmək üçün tətbiqat

        _view.MesajGoster("Bu funksiya hələ tətbiq edilməyib.");
    }

    private async Task SifarisTesdiqle()
    {
        if (_view.SifarisId <= 0)
        {
            _view.MesajGoster("Təsdiqləmək üçün cədvəldən sifariş seçin.", true);
            return;
        }

        var netice = await _alisManager.AlisSifarisiniTesdiqleAsync(_view.SifarisId);
        if (netice.UgurluDur)
        {
            _view.MesajGoster("Alış sifarişi uğurla təsdiqləndi.");
            await FormuYukle();
        }
        else
        {
            _view.MesajGoster(netice.Mesaj, true);
        }
    }
}