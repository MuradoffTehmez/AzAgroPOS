// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/TedarukcuPresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Tədarükçü idarəetmə forması üçün presenter.
/// </summary>
public class TedarukcuPresenter
{
    private readonly ITedarukcuView _view;
    private readonly AlisManager _alisManager;

    public TedarukcuPresenter(ITedarukcuView view, AlisManager alisManager)
    {
        _view = view;
        _alisManager = alisManager;

        // Hadisələrə abunə oluruq
        _view.FormYuklendi += async (s, e) => await FormuYukle();
        _view.TedarukcuYarat_Istek += async (s, e) => await TedarukcuYarat();
        _view.TedarukcuYenile_Istek += async (s, e) => await TedarukcuYenile();
        _view.TedarukcuSil_Istek += async (s, e) => await TedarukcuSil();
        _view.FormuTemizle_Istek += (s, e) => _view.FormuTemizle();
    }

    private async Task FormuYukle()
    {
        var netice = await _alisManager.ButunTedarukculeriGetirAsync();
        if (netice.UgurluDur)
        {
            _view.TedarukculeriGoster(netice.Data.OrderBy(t => t.Ad).ToList());
        }
        else
        {
            _view.TedarukculeriGoster(new System.Collections.Generic.List<TedarukcuDto>());
            _view.MesajGoster(netice.Mesaj, true);
        }
    }

    private async Task TedarukcuYarat()
    {
        var dto = new TedarukcuDto
        {
            Ad = _view.Ad,
            Voen = _view.Voen,
            Unvan = _view.Unvan,
            Telefon = _view.Telefon,
            Email = _view.Email,
            BankHesabi = _view.BankHesabi,
            Aktivdir = _view.Aktivdir
        };

        var netice = await _alisManager.TedarukcuYaratAsync(dto);

        if (netice.UgurluDur)
        {
            _view.MesajGoster("Tədarükçü uğurla yaradıldı.");
            await FormuYukle();
            _view.FormuTemizle();
        }
        else
        {
            _view.MesajGoster(netice.Mesaj, true);
        }
    }

    private async Task TedarukcuYenile()
    {
        if (_view.TedarukcuId <= 0)
        {
            _view.MesajGoster("Yeniləmək üçün cədvəldən bir tədarükçü seçməlisiniz.", true);
            return;
        }

        var dto = new TedarukcuDto
        {
            Id = _view.TedarukcuId,
            Ad = _view.Ad,
            Voen = _view.Voen,
            Unvan = _view.Unvan,
            Telefon = _view.Telefon,
            Email = _view.Email,
            BankHesabi = _view.BankHesabi,
            Aktivdir = _view.Aktivdir
        };

        var netice = await _alisManager.TedarukcuYenileAsync(dto);

        if (netice.UgurluDur)
        {
            _view.MesajGoster("Tədarükçü məlumatları uğurla yeniləndi.");
            await FormuYukle();
            _view.FormuTemizle();
        }
        else
        {
            _view.MesajGoster(netice.Mesaj, true);
        }
    }

    private async Task TedarukcuSil()
    {
        if (_view.TedarukcuId <= 0)
        {
            _view.MesajGoster("Silmək üçün cədvəldən tədarükçü seçin.", true);
            return;
        }

        var netice = await _alisManager.TedarukcuSilAsync(_view.TedarukcuId);
        if (netice.UgurluDur)
        {
            _view.MesajGoster("Tədarükçü silindi.");
            await FormuYukle();
            _view.FormuTemizle();
        }
        else
        {
            _view.MesajGoster(netice.Mesaj, true);
        }
    }
}