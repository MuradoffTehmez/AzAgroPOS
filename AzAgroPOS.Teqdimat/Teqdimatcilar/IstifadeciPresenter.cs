// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/IstifadeciPresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar;
// Gərəkli using-lər...
using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;
using System.Threading.Tasks;
public class IstifadeciPresenter
{
    private readonly IIstifadeciView _view;
    private readonly IstifadeciManager _manager;
    private readonly UnitOfWork _unitOfWork;
    public IstifadeciPresenter(IIstifadeciView view)
    {
        _view = view;
        _unitOfWork = new UnitOfWork(new AzAgroPOSDbContext());
        _manager = new IstifadeciManager(_unitOfWork);
        _view.FormYuklendi += async (s, e) => await FormuYukle();
        _view.IstifadeciYarat_Istek += async (s, e) => await IstifadeciYarat();
        _view.IstifadeciSil_Istek += async (s, e) => await IstifadeciSil();
    }
    private async Task FormuYukle()
    {
        var rollar = await _unitOfWork.Rollar.ButununuGetirAsync();
        _view.RollarGoster(rollar.ToList());
        await IstifadecileriYenile();
    }
    private async Task IstifadecileriYenile()
    {
        var netice = await _manager.IstifadecileriGetirAsync();
        if (netice.UgurluDur) _view.IstifadecileriGoster(netice.Data);
    }
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