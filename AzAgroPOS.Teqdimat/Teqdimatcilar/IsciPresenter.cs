// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/IsciPresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Varliglar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// İşçi idarəetmə forması üçün presenter.
/// </summary>
public class IsciPresenter
{
    private readonly IIsciView _view;
    private readonly IsciManager _isciManager;

    public IsciPresenter(IIsciView view, IsciManager isciManager)
    {
        _view = view;
        _isciManager = isciManager;

        // Hadisələrə abunə oluruq
        _view.FormYuklendi += async (s, e) => await FormuYukle();
        _view.IsciYarat_Istek += async (s, e) => await IsciYarat();
        _view.IsciYenile_Istek += async (s, e) => await IsciYenile();
        _view.IsciSil_Istek += async (s, e) => await IsciSil();
        _view.FormuTemizle_Istek += (s, e) => _view.FormuTemizle();
    }

    private async Task FormuYukle()
    {
        var netice = await _isciManager.ButunIscileriGetirAsync();
        if (netice.UgurluDur)
        {
            _view.IscileriGoster(netice.Data.OrderBy(i => i.TamAd).ToList());
        }
        else
        {
            _view.IscileriGoster(new List<IsciDto>());
            _view.MesajGoster(netice.Mesaj, true);
        }
    }

    private async Task IsciYarat()
    {
        var dto = new IsciDto
        {
            TamAd = _view.TamAd,
            DogumTarixi = _view.DogumTarixi,
            TelefonNomresi = _view.TelefonNomresi,
            Unvan = _view.Unvan,
            Email = _view.Email,
            IseBaslamaTarixi = _view.IseBaslamaTarixi,
            Maas = _view.Maas,
            Vezife = _view.Vezife,
            Departament = _view.Departament,
            Status = _view.Status,
            SvsNo = _view.SvsNo,
            QeydiyyatUnvani = _view.QeydiyyatUnvani,
            BankMəlumatları = _view.BankMəlumatları
        };

        var netice = await _isciManager.IsciYaratAsync(dto);
        if (netice.UgurluDur)
        {
            _view.MesajGoster("İşçi uğurla yaradıldı.");
            await FormuYukle();
            _view.FormuTemizle();
        }
        else
        {
            _view.MesajGoster(netice.Mesaj, true);
        }
    }

    private async Task IsciYenile()
    {
        if (_view.IsciId <= 0)
        {
            _view.MesajGoster("Yeniləmək üçün cədvəldən bir işçi seçməlisiniz.", true);
            return;
        }

        var dto = new IsciDto
        {
            Id = _view.IsciId,
            TamAd = _view.TamAd,
            DogumTarixi = _view.DogumTarixi,
            TelefonNomresi = _view.TelefonNomresi,
            Unvan = _view.Unvan,
            Email = _view.Email,
            IseBaslamaTarixi = _view.IseBaslamaTarixi,
            Maas = _view.Maas,
            Vezife = _view.Vezife,
            Departament = _view.Departament,
            Status = _view.Status,
            SvsNo = _view.SvsNo,
            QeydiyyatUnvani = _view.QeydiyyatUnvani,
            BankMəlumatları = _view.BankMəlumatları
        };

        var netice = await _isciManager.IsciYenileAsync(dto);
        if (netice.UgurluDur)
        {
            _view.MesajGoster("İşçi məlumatları uğurla yeniləndi.");
            await FormuYukle();
            _view.FormuTemizle();
        }
        else
        {
            _view.MesajGoster(netice.Mesaj, true);
        }
    }

    private async Task IsciSil()
    {
        if (_view.IsciId <= 0)
        {
            _view.MesajGoster("Silmək üçün cədvəldən işçi seçin.", true);
            return;
        }

        var netice = await _isciManager.IsciSilAsync(_view.IsciId);
        if (netice.UgurluDur)
        {
            _view.MesajGoster("İşçi silindi.");
            await FormuYukle();
            _view.FormuTemizle();
        }
        else
        {
            _view.MesajGoster(netice.Mesaj, true);
        }
    }
}