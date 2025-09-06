// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/AlisSifarisPresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Alış sifarişi idarəetmə forması üçün presenter.
/// </summary>
public class AlisSifarisPresenter
{
    private readonly IAlisSifarisView _view;
    private readonly AlisManager _alisManager;
    private readonly MehsulManager _mehsulManager; // Əlavə edildi

    public AlisSifarisPresenter(IAlisSifarisView view, AlisManager alisManager, MehsulManager mehsulManager)
    {
        _view = view;
        _alisManager = alisManager;
        _mehsulManager = mehsulManager; // Əlavə edildi

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
        var mehsulNetice = await _mehsulManager.ButunMehsullariGetirAsync(); // Əlavə edildi
        if (mehsulNetice.UgurluDur)
        {
            _view.MehsullariGoster(mehsulNetice.Data.OrderBy(m => m.Ad).ToList()); // Əlavə edildi
        }
        else
        {
            _view.MehsullariGoster(new System.Collections.Generic.List<MehsulDto>()); // Əlavə edildi
        }

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

        // Sifarişi yeniləmək üçün tətbiqat
        var dto = new AlisSifarisDto
        {
            Id = _view.SifarisId,
            SifarisNomresi = _view.SifarisNomresi,
            YaradilmaTarixi = _view.YaradilmaTarixi,
            TesdiqTarixi = _view.TesdiqTarixi,
            GozlenilenTehvilTarixi = _view.GozlenilenTehvilTarixi,
            TedarukcuId = _view.TedarukcuId,
            UmumiMebleg = _view.UmumiMebleg,
            Qeydler = _view.Qeydler
        };

        var netice = await _alisManager.AlisSifarisYenileAsync(dto);

        if (netice.UgurluDur)
        {
            _view.MesajGoster("Alış sifarişi uğurla yeniləndi.");
            await FormuYukle();
            _view.FormuTemizle();
        }
        else
        {
            _view.MesajGoster(netice.Mesaj, true);
        }
    }

    private async Task SifarisSil()
    {
        if (_view.SifarisId <= 0)
        {
            _view.MesajGoster("Silmək üçün cədvəldən sifariş seçin.", true);
            return;
        }

        // Sifarişi silmək üçün tətbiqat
        var netice = await _alisManager.AlisSifarisSilAsync(_view.SifarisId);

        if (netice.UgurluDur)
        {
            _view.MesajGoster("Alış sifarişi uğurla silindi.");
            await FormuYukle();
            _view.FormuTemizle();
        }
        else
        {
            _view.MesajGoster(netice.Mesaj, true);
        }
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