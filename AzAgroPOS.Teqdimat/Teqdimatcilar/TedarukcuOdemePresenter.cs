// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/TedarukcuOdemePresenter.cs

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Teqdimat.Interfeysler;

namespace AzAgroPOS.Teqdimat.Teqdimatcilar;
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
        EmeliyyatNeticesi<List<TedarukcuDto>> tedarukcuNetice = await _alisManager.ButunTedarukculeriGetirAsync();
        if (tedarukcuNetice.UgurluDur)
        {
            _view.TedarukculeriGoster(tedarukcuNetice.Data.OrderBy(t => t.Ad).ToList());
        }
        else
        {
            _view.TedarukculeriGoster(new System.Collections.Generic.List<TedarukcuDto>());
        }

        // Alış sənədlərini yükləyirik
        EmeliyyatNeticesi<List<AlisSenedDto>> senedNetice = await _alisManager.ButunAlisSenetleriniGetirAsync();
        if (senedNetice.UgurluDur)
        {
            _view.SenetleriGoster(senedNetice.Data.OrderBy(s => s.YaradilmaTarixi).ToList());
        }
        else
        {
            _view.SenetleriGoster(new System.Collections.Generic.List<AlisSenedDto>());
        }

        // Ödənişləri yükləyirik
        EmeliyyatNeticesi<List<TedarukcuOdemeDto>> odemeNetice = await _alisManager.ButunTedarukcuOdemeleriniGetirAsync();
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
        TedarukcuOdemeDto dto = new()
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

        EmeliyyatNeticesi<int> netice = await _alisManager.TedarukcuOdemeYaratAsync(dto);

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

        // Ödənişi yeniləmək üçün tətbiqat
        TedarukcuOdemeDto dto = new()
        {
            Id = _view.OdemeId,
            OdemeNomresi = _view.OdemeNomresi,
            YaradilmaTarixi = _view.YaradilmaTarixi,
            TedarukcuId = _view.TedarukcuId,
            AlisSenedId = _view.AlisSenedId,
            OdemeTarixi = _view.OdemeTarixi,
            Mebleg = _view.Mebleg,
            Qeydler = _view.Qeydler,
            BankMelumatlari = _view.BankMelumatlari
        };

        EmeliyyatNeticesi netice = await _alisManager.TedarukcuOdemeYenileAsync(dto);

        if (netice.UgurluDur)
        {
            _view.MesajGoster("Tədarükçü ödənişi uğurla yeniləndi.");
            await FormuYukle();
            _view.FormuTemizle();
        }
        else
        {
            _view.MesajGoster(netice.Mesaj, true);
        }
    }

    private async Task OdemeSil()
    {
        if (_view.OdemeId <= 0)
        {
            _view.MesajGoster("Silmək üçün cədvəldən ödəniş seçin.", true);
            return;
        }

        // Ödənişi silmək üçün tətbiqat
        EmeliyyatNeticesi netice = await _alisManager.TedarukcuOdemeSilAsync(_view.OdemeId);

        if (netice.UgurluDur)
        {
            _view.MesajGoster("Tədarükçü ödənişi uğurla silindi.");
            await FormuYukle();
            _view.FormuTemizle();
        }
        else
        {
            _view.MesajGoster(netice.Mesaj, true);
        }
    }
}