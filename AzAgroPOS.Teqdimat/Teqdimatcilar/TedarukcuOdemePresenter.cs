// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/TedarukcuOdemePresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using System;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Tədarükçü ödənişi idarəetmə forması üçün presenter.
/// </summary>
public class TedarukcuOdemePresenter
{
    private readonly ITedarukcuOdemeView _view;
    private readonly AlisManager _alisManager;

    public TedarukcuOdemePresenter(ITedarukcuOdemeView view, AlisManager alisManager)
    {
        _view = view;
        _alisManager = alisManager;

        // Hadisələrə abunə oluruq
        _view.FormYuklendi += async (s, e) => await FormuYukle();
        _view.OdemeYarat_Istek += async (s, e) => await OdemeYarat();
        _view.OdemeYenile_Istek += async (s, e) => await OdemeYenile();
        _view.OdemeSil_Istek += async (s, e) => await OdemeSil();
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

        // Alış sənədlərini yükləyirik
        var senedNetice = await _alisManager.ButunAlisSenetleriniGetirAsync();
        if (senedNetice.UgurluDur)
        {
            _view.SenetleriGoster(senedNetice.Data.OrderBy(s => s.YaradilmaTarixi).ToList());
        }
        else
        {
            _view.SenetleriGoster(new System.Collections.Generic.List<AlisSenedDto>());
        }

        // Ödənişləri yükləyirik
        var odemeNetice = await _alisManager.ButunTedarukcuOdemeleriniGetirAsync();
        if (odemeNetice.UgurluDur)
        {
            _view.OdemeleriGoster(odemeNetice.Data.OrderBy(o => o.YaradilmaTarixi).ToList());
        }
        else
        {
            _view.OdemeleriGoster(new System.Collections.Generic.List<TedarukcuOdemeDto>());
            _view.MesajGoster(odemeNetice.Mesaj, true);
        }
    }

    private async Task OdemeYarat()
    {
        var dto = new TedarukcuOdemeDto
        {
            OdemeNomresi = _view.OdemeNomresi,
            YaradilmaTarixi = _view.YaradilmaTarixi,
            TedarukcuId = _view.TedarukcuId,
            AlisSenedId = _view.AlisSenedId,
            OdemeTarixi = _view.OdemeTarixi,
            Mebleg = _view.Mebleg,
            Qeydler = _view.Qeydler,
            BankMelumatlari = _view.BankMelumatlari
        };

        var netice = await _alisManager.TedarukcuOdemeYaratAsync(dto);

        if (netice.UgurluDur)
        {
            _view.MesajGoster("Tədarükçü ödənişi uğurla yaradıldı.");
            await FormuYukle();
            _view.FormuTemizle();
        }
        else
        {
            _view.MesajGoster(netice.Mesaj, true);
        }
    }

    private async Task OdemeYenile()
    {
        if (_view.OdemeId <= 0)
        {
            _view.MesajGoster("Yeniləmək üçün cədvəldən bir ödəniş seçməlisiniz.", true);
            return;
        }

        // TODO: Ödənişi yeniləmək üçün tətbiqat

        _view.MesajGoster("Bu funksiya hələ tətbiq edilməyib.");
    }

    private async Task OdemeSil()
    {
        if (_view.OdemeId <= 0)
        {
            _view.MesajGoster("Silmək üçün cədvəldən ödəniş seçin.", true);
            return;
        }

        // TODO: Ödənişi silmək üçün tətbiqat

        _view.MesajGoster("Bu funksiya hələ tətbiq edilməyib.");
    }
}