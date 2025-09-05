// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/TemirPresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar;
// using-lər
using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;

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

    /// <summary>
    ///  bu presenter, temir view interfeysini alır və temir manager ilə əlaqələndirir.
    /// </summary>
    /// <param name="view"></param>
    public TemirPresenter(ITemirView view, TemirManager temirManager, MusteriManager musteriManager, IstifadeciManager istifadeciManager)
    {
        _view = view;
        _temirManager = temirManager;
        _musteriManager = musteriManager;
        _istifadeciManager = istifadeciManager;

        _view.FormYuklendi += async (s, e) => await FormuYukle();
        _view.YeniSifarisYarat_Istek += async (s, e) => await YeniSifarisYarat();
    }
    /// <summary>
    /// bu metod, form yükləndikdə bütün sifarişləri yükləyir və göstərir.
    /// </summary>
    /// <returns></returns>
    private async Task FormuYukle()
    {
        var netice = await _temirManager.ButunSifarisleriGetirAsync();
        if (netice.UgurluDur)
            _view.SifarisleriGoster(netice.Data);
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
            ProblemTesviri = _view.ProblemTesviri,
            YekunMebleg = _view.YekunMebleg
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
}