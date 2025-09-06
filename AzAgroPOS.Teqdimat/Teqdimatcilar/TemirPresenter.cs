// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/TemirPresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar;
// using-lər
using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
///  temir presenter class. 
///  bu presenter, temir sifarişlərinin idarə olunması üçün istifadə olunur.
/// </summary>
public class TemirPresenter
{
    private readonly ITemirView _view;
    private readonly TemirManager _temirManager;
    private readonly MusteriManager _musteriManager;
    private readonly IstifadeciManager _istifadeciManager;
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    ///  bu presenter, temir view interfeysini alır və temir manager ilə əlaqələndirir.
    /// </summary>
    /// <param name="view"></param>
    public TemirPresenter(ITemirView view, TemirManager temirManager, MusteriManager musteriManager, IstifadeciManager istifadeciManager, IServiceProvider serviceProvider)
    {
        _view = view;
        _temirManager = temirManager;
        _musteriManager = musteriManager;
        _istifadeciManager = istifadeciManager;
        _serviceProvider = serviceProvider;

        _view.FormYuklendi += async (s, e) => await FormuYukle();
        _view.YeniSifarisYarat_Istek += async (s, e) => await YeniSifarisYarat();
        _view.SifarisYenile_Istek += async (s, e) => await SifarisYenile();
        _view.SifarisSil_Istek += async (s, e) => await SifarisSil();
        _view.FormuTemizle_Istek += (s, e) => _view.FormuTemizle();
        _view.EhtiyatHissəsiElaveEt_Istek += (s, e) => EhtiyatHissəsiElaveEt();
        _view.ÖdənişiTamamla_Istek += (s, e) => ÖdənişiTamamla();
    }
    
    /// <summary>
    /// bu metod, form yükləndikdə bütün sifarişləri yükləyir və göstərir.
    /// </summary>
    /// <returns></returns>
    private async Task FormuYukle()
    {
        // Sifarişləri yükləyirik
        var netice = await _temirManager.ButunSifarisleriGetirAsync();
        if (netice.UgurluDur)
            _view.SifarisleriGoster(netice.Data);
        
        // Usta siyahısını yükləyirik
        var ustalarNetice = await _istifadeciManager.ButunTexnikleriGetirAsync();
        if (ustalarNetice.UgurluDur)
            _view.UstaSiyahisiniGoster(ustalarNetice.Data);
    }

    /// <summary>
    /// bu metod, yeni təmir sifarişi yaratmaq üçün istifadə olunur.
    /// </summary>
    /// <returns></returns>
    private async Task YeniSifarisYarat()
    {
        var yeniSifarisDto = new TemirDto
        {
            MusteriAdi = _view.MusteriAdi,
            MusteriTelefonu = _view.MusteriTelefonu,
            CihazAdi = _view.CihazAdi,
            SeriyaNomresi = _view.SeriyaNomresi,
            ProblemTesviri = _view.ProblemTesviri,
            TemirXerci = _view.TemirXerci,
            ServisHaqqi = _view.ServisHaqqi,
            YekunMebleg = _view.YekunMebleg,
            IsciId = _view.UstaId
        };

        var netice = await _temirManager.YeniSifarisYaratAsync(yeniSifarisDto);
        if (netice.UgurluDur)
        {
            _view.MesajGoster("Yeni təmir sifarişi uğurla yaradıldı.", "Uğurlu Əməliyyat");
            _view.FormuTemizle();
            await FormuYukle();
        }
        else
        {
            _view.MesajGoster(netice.Mesaj, "Xəta");
        }
    }

    /// <summary>
    /// bu metod, mövcud təmir sifarişini yeniləmək üçün istifadə olunur.
    /// </summary>
    /// <returns></returns>
    private async Task SifarisYenile()
    {
        var secilmisSifarisId = _view.SecilmisSifarisId;
        if (secilmisSifarisId <= 0)
        {
            _view.MesajGoster("Zəhmət olmasa, yeniləmək üçün bir sifariş seçin.", "Xəbərdarlıq");
            return;
        }

        var sifarisDto = new TemirDto
        {
            Id = secilmisSifarisId,
            MusteriAdi = _view.MusteriAdi,
            MusteriTelefonu = _view.MusteriTelefonu,
            CihazAdi = _view.CihazAdi,
            SeriyaNomresi = _view.SeriyaNomresi,
            ProblemTesviri = _view.ProblemTesviri,
            TemirXerci = _view.TemirXerci,
            ServisHaqqi = _view.ServisHaqqi,
            YekunMebleg = _view.YekunMebleg,
            IsciId = _view.UstaId
        };

        var netice = await _temirManager.SifarisYenileAsync(sifarisDto);
        if (netice.UgurluDur)
        {
            _view.MesajGoster("Təmir sifarişi uğurla yeniləndi.", "Uğurlu Əməliyyat");
            await FormuYukle();
        }
        else
        {
            _view.MesajGoster(netice.Mesaj, "Xəta");
        }
    }

    /// <summary>
    /// bu metod, mövcud təmir sifarişini silmək üçün istifadə olunur.
    /// </summary>
    /// <returns></returns>
    private async Task SifarisSil()
    {
        var secilmisSifarisId = _view.SecilmisSifarisId;
        if (secilmisSifarisId <= 0)
        {
            _view.MesajGoster("Zəhmət olmasa, silmək üçün bir sifariş seçin.", "Xəbərdarlıq");
            return;
        }

        var tesdiq = MessageBox.Show(
            "Bu sifarişi silmək istədiyinizə əminsiniz?", 
            "Təsdiq", 
            MessageBoxButtons.YesNo, 
            MessageBoxIcon.Question);

        if (tesdiq == DialogResult.Yes)
        {
            var netice = await _temirManager.SifarisSilAsync(secilmisSifarisId);
            if (netice.UgurluDur)
            {
                _view.MesajGoster("Təmir sifarişi uğurla silindi.", "Uğurlu Əməliyyat");
                _view.FormuTemizle();
                await FormuYukle();
            }
            else
            {
                _view.MesajGoster(netice.Mesaj, "Xəta");
            }
        }
    }
    
    /// <summary>
    /// bu metod, ehtiyat hissəsi əlavə etmək üçün istifadə olunur.
    /// </summary>
    private void EhtiyatHissəsiElaveEt()
    {
        using (var form = _serviceProvider.GetRequiredService<EhtiyatHissəsiFormu>())
        {
            if (form.ShowDialog() == DialogResult.OK)
            {
                var ehtiyatHissələri = form.EhtiyatHissələri;
                decimal ümumiMəbləğ = ehtiyatHissələri.Sum(e => e.ÜmumiMəbləğ);
                
                // Təmir xərcini yeniləyirik
                var cariXerc = _view.TemirXerci;
                _view.TemirXerci = cariXerc + ümumiMəbləğ;
                
                // Yekun məbləği yeniləyirik
                var servisHaqqi = _view.ServisHaqqi;
                _view.YekunMebleg = _view.TemirXerci + servisHaqqi;
                
                _view.MesajGoster($"{ehtiyatHissələri.Count} ədəd ehtiyat hissəsi əlavə edildi. Ümumi məbləğ: {ümumiMəbləğ:N2} AZN", "Məlumat");
            }
        }
    }
    
    /// <summary>
    /// bu metod, təmirin ödənişini tamamlamaq üçün istifadə olunur.
    /// </summary>
    private async void ÖdənişiTamamla()
    {
        var secilmisSifarisId = _view.SecilmisSifarisId;
        if (secilmisSifarisId <= 0)
        {
            _view.MesajGoster("Zəhmət olmasa, ödənişi tamamlamaq üçün bir sifariş seçin.", "Xəbərdarlıq");
            return;
        }

        var tesdiq = MessageBox.Show(
            "Bu sifarişin ödənişini tamamlamaq istədiyinizə əminsiniz?", 
            "Təsdiq", 
            MessageBoxButtons.YesNo, 
            MessageBoxIcon.Question);

        if (tesdiq == DialogResult.Yes)
        {
            var netice = await _temirManager.StatusDeyisAsync(secilmisSifarisId, TemirStatusu.Hazırdır);
            if (netice.UgurluDur)
            {
                _view.MesajGoster("Təmir sifarişinin ödənişi uğurla tamamlandı.", "Uğurlu Əməliyyat");
                await FormuYukle();
            }
            else
            {
                _view.MesajGoster(netice.Mesaj, "Xəta");
            }
        }
    }
}