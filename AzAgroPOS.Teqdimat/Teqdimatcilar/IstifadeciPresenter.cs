// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/IstifadeciPresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;
using System.Threading.Tasks;

/// <summary>
/// bu presenter, istifadəçi əməliyyatlarını idarə etmək üçün istifadə olunur.
/// daxil olma, istifadəçi yaratma və silmə əməliyyatlarını həyata keçirir.
/// </summary>
public class IstifadeciPresenter
{
    private readonly IIstifadeciView _view;
    private readonly IstifadeciManager _manager;
    private readonly UnitOfWork _unitOfWork;
    /// <summary>
    /// İstifadeciPresenter, IIstifadeciView interfeysini alır və IstifadeciManager ilə əlaqələndirir.
    /// daxil olma, istifadəçi yaratma və silmə əməliyyatlarını idarə etmək üçün istifadə olunur.
    /// </summary>
    /// <param name="view"></param>
    public IstifadeciPresenter(IIstifadeciView view)
    {
        _view = view;
        _unitOfWork = new UnitOfWork(new AzAgroPOSDbContext());
        _manager = new IstifadeciManager(_unitOfWork);
        _view.FormYuklendi += async (s, e) => await FormuYukle();
        _view.IstifadeciYarat_Istek += async (s, e) => await IstifadeciYarat();
        _view.IstifadeciSil_Istek += async (s, e) => await IstifadeciSil();
    }
    /// <summary>
    /// FormuYukle metodu, form yükləndikdə bütün rolları və istifadəçiləri yükləyir və göstərir.
    /// </summary>
    /// <returns> bu metod, asinxron olaraq bütün rolları və istifadəçiləri yükləyir və göstərir.
    /// </returns>
    private async Task FormuYukle()
    {
        var rollar = await _unitOfWork.Rollar.ButununuGetirAsync();
        _view.RollariGoster(rollar.ToList());
        await IstifadecileriYenile();
    }
    /// <summary>
    /// İstifadecileriYenile metodu, istifadəçi siyahısını yeniləyir və göstərir.
    /// </summary>
    /// <returns> Async bir şəkildə istifadəçi siyahısını yeniləyir və göstərir.
    /// </returns>
    private async Task IstifadecileriYenile()
    {
        var netice = await _manager.IstifadecileriGetirAsync();
        if (netice.UgurluDur) _view.IstifadecileriGoster(netice.Data);
    }
    /// <summary>
    /// İstifadeciYarat metodu daxil olan istifadəçi məlumatlarını alır və yeni istifadəçi yaradır.
    /// Asinxron olaraq işləyir və istifadəçi yaradıldıqda mesaj göstərir.
    /// </summary>
    /// <returns> Async bir şəkildə yeni istifadəçi yaradır və istifadəçiyə mesaj göstərir.
    /// </returns>
    private async Task IstifadeciYarat()
    {
        var dto = new IstifadeciDto { IstifadeciAdi = _view.IstifadeciAdi, TamAd = _view.TamAd, RolId = _view.SecilmisRolId };
        var netice = await _manager.IstifadeciYaratAsync(dto, _view.Parol);
        if (netice.UgurluDur)
        {
            _view.MesajGoster("İstifadəçi uğurla yaradıldı.");
            _view.FormuTemizle();
            await IstifadecileriYenile();
        }
        else _view.MesajGoster(netice.Mesaj, true);
    }
    /// <summary>
    /// İstifadeciSil metodu, istifadəçi silmək üçün istifadə olunur,
    /// metod daxil olan istifadəçi ID-sini alır və istifadəçini silir.
    /// </summary>
    /// <returns> Async bir şəkildə istifadəçi ID-sini alır və istifadəçini silir.
    /// </returns>
    private async Task IstifadeciSil()
    {
        if (int.TryParse(_view.IstifadeciId, out int id))
        {
            var netice = await _manager.IstifadeciSilAsync(id);
            if (netice.UgurluDur)
            {
                _view.MesajGoster("İstifadəçi silindi.");
                await IstifadecileriYenile();
            }
            else _view.MesajGoster(netice.Mesaj, true);
        }
        else _view.MesajGoster("Silmək üçün cədvəldən istifadəçi seçin.", true);
    }
}