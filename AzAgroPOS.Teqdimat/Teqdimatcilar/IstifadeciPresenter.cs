// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/IstifadeciPresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;
using System.Linq;
using System.Threading.Tasks;

public class IstifadeciPresenter
{
    private readonly IIstifadeciView _view;
    private readonly IstifadeciManager _istifadeciManager;

    public IstifadeciPresenter(IIstifadeciView view, IstifadeciManager istifadeciManager)
    {
        _view = view;
        _istifadeciManager = istifadeciManager;

        // Hadisələrə (Events) abunə oluruq
        _view.FormYuklendi += async (s, e) => await FormuYukle();
        _view.IstifadeciYarat_Istek += async (s, e) => await IstifadeciYarat();
        _view.IstifadeciYenile_Istek += async (s, e) => await IstifadeciYenile();
        _view.IstifadeciSil_Istek += async (s, e) => await IstifadeciSil();
        _view.FormuTemizle_Istek += (s, e) => _view.FormuTemizle();
    }



    private async Task FormuYukle()
    {
        // Load roles first
        var rollar = await _istifadeciManager.ButunRollarGetirAsync();
        _view.RollariGoster(rollar);
        
        var netice = await _istifadeciManager.IstifadecileriGetirAsync();
        if (netice.UgurluDur)
        {
            _view.IstifadecileriGoster(netice.Data.OrderBy(i => i.IstifadeciAdi).ToList());
        }
        else
        {
            _view.IstifadecileriGoster(new List<IstifadeciDto>());
            _view.MesajGoster(netice.Mesaj);
        }
    }

    private async Task IstifadecileriYenile()
    {
        var netice = await _istifadeciManager.IstifadecileriGetirAsync();
        if (netice.UgurluDur)
        {
            _view.IstifadecileriGoster(netice.Data);
        }
        else
        {
            // Əgər heç bir istifadəçi yoxdursa, boş siyahı göndərərək cədvəli təmizləyirik
            _view.IstifadecileriGoster(new System.Collections.Generic.List<IstifadeciDto>());
            _view.MesajGoster(netice.Mesaj);
        }
    }

    private async Task IstifadeciYarat()
    {
        var dto = new IstifadeciDto
        {
            IstifadeciAdi = _view.IstifadeciAdi,
            TamAd = _view.TamAd,
            RolId = _view.SecilmisRolId
        };

        var netice = await _istifadeciManager.IstifadeciYaratAsync(dto, _view.Parol);

        if (netice.UgurluDur)
        {
            _view.MesajGoster("İstifadəçi uğurla yaradıldı.");
            await IstifadecileriYenile();
            _view.FormuTemizle();
        }
        else
        {
            _view.MesajGoster(netice.Mesaj, true);
        }
    }

    private async Task IstifadeciYenile()
    {
        if (!int.TryParse(_view.IstifadeciId, out int id))
        {
            _view.MesajGoster("Yeniləmək üçün cədvəldən bir istifadəçi seçməlisiniz.", true);
            return;
        }

        var dto = new IstifadeciDto
        {
            Id = id,
            IstifadeciAdi = _view.IstifadeciAdi, // İstifadəçi adı dəyişdirilmir
            TamAd = _view.TamAd,
            RolId = _view.SecilmisRolId
        };

        var netice = await _istifadeciManager.IstifadeciYenileAsync(dto, _view.Parol);

        if (netice.UgurluDur)
        {
            _view.MesajGoster("İstifadəçi məlumatları uğurla yeniləndi.");
            await IstifadecileriYenile();
            _view.FormuTemizle();
        }
        else
        {
            _view.MesajGoster(netice.Mesaj, true);
        }
    }

    private async Task IstifadeciSil()
    {
        if (int.TryParse(_view.IstifadeciId, out int id))
        {
            var netice = await _istifadeciManager.IstifadeciSilAsync(id);
            if (netice.UgurluDur)
            {
                _view.MesajGoster("İstifadəçi silindi.");
                await IstifadecileriYenile();
                _view.FormuTemizle();
            }
            else
            {
                _view.MesajGoster(netice.Mesaj, true);
            }
        }
        else
        {
            _view.MesajGoster("Silmək üçün cədvəldən istifadəçi seçin.", true);
        }
    }
}