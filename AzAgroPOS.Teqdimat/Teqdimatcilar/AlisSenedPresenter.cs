// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/AlisSenedPresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using System;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Alış sənədi idarəetmə forması üçün presenter.
/// </summary>
public class AlisSenedPresenter
{
    private readonly IAlisSenedView _view;
    private readonly AlisManager _alisManager;
    private readonly MehsulManager _mehsulManager;

    public AlisSenedPresenter(IAlisSenedView view, AlisManager alisManager, MehsulManager mehsulManager)
    {
        _view = view;
        _alisManager = alisManager;
        _mehsulManager = mehsulManager;

        // Hadisələrə abunə oluruq
        _view.FormYuklendi += async (s, e) => await FormuYukle();
        _view.SenedYarat_Istek += async (s, e) => await SenedYarat();
        _view.SenedYenile_Istek += async (s, e) => await SenedYenile();
        _view.SenedSil_Istek += async (s, e) => await SenedSil();
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
        var mehsulNetice = await _mehsulManager.ButunMehsullariGetirAsync();
        if (mehsulNetice.UgurluDur)
        {
            _view.MehsullariGoster(mehsulNetice.Data.OrderBy(m => m.Ad).ToList());
        }
        else
        {
            _view.MehsullariGoster(new System.Collections.Generic.List<MehsulDto>());
        }

        // Sənədləri yükləyirik
        var senedNetice = await _alisManager.ButunAlisSenetleriniGetirAsync();
        if (senedNetice.UgurluDur)
        {
            _view.SenetleriGoster(senedNetice.Data.OrderBy(s => s.YaradilmaTarixi).ToList());
        }
        else
        {
            _view.SenetleriGoster(new System.Collections.Generic.List<AlisSenedDto>());
            _view.MesajGoster(senedNetice.Mesaj, true);
        }
    }

    private async Task SenedYarat()
    {
        var dto = new AlisSenedDto
        {
            SenedNomresi = _view.SenedNomresi,
            YaradilmaTarixi = _view.YaradilmaTarixi,
            TedarukcuId = _view.TedarukcuId,
            TehvilTarixi = _view.TehvilTarixi,
            UmumiMebleg = _view.UmumiMebleg,
            Qeydler = _view.Qeydler
        };

        var netice = await _alisManager.AlisSenedYaratAsync(dto);

        if (netice.UgurluDur)
        {
            _view.MesajGoster("Alış sənədi uğurla yaradıldı.");
            await FormuYukle();
            _view.FormuTemizle();
        }
        else
        {
            _view.MesajGoster(netice.Mesaj, true);
        }
    }

    private async Task SenedYenile()
    {
        if (_view.SenedId <= 0)
        {
            _view.MesajGoster("Yeniləmək üçün cədvəldən bir sənəd seçməlisiniz.", true);
            return;
        }

        // Sənədi yeniləmək üçün tətbiqat
        var dto = new AlisSenedDto
        {
            Id = _view.SenedId,
            SenedNomresi = _view.SenedNomresi,
            YaradilmaTarixi = _view.YaradilmaTarixi,
            TedarukcuId = _view.TedarukcuId,
            TehvilTarixi = _view.TehvilTarixi,
            UmumiMebleg = _view.UmumiMebleg,
            Qeydler = _view.Qeydler
        };

        var netice = await _alisManager.AlisSenedYenileAsync(dto);

        if (netice.UgurluDur)
        {
            _view.MesajGoster("Alış sənədi uğurla yeniləndi.");
            await FormuYukle();
            _view.FormuTemizle();
        }
        else
        {
            _view.MesajGoster(netice.Mesaj, true);
        }
    }

    private async Task SenedSil()
    {
        if (_view.SenedId <= 0)
        {
            _view.MesajGoster("Silmək üçün cədvəldən sənəd seçin.", true);
            return;
        }

        // Sənədi silmək üçün tətbiqat
        var netice = await _alisManager.AlisSenedSilAsync(_view.SenedId);

        if (netice.UgurluDur)
        {
            _view.MesajGoster("Alış sənədi uğurla silindi.");
            await FormuYukle();
            _view.FormuTemizle();
        }
        else
        {
            _view.MesajGoster(netice.Mesaj, true);
        }
    }
}