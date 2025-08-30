// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/BarkodCapiPresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Servisler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class BarkodCapiPresenter
{
    private readonly IBarkodCapiView _view;
    private readonly BarkodCapiManager _manager;

    public BarkodCapiPresenter(IBarkodCapiView view)
    {
        _view = view;
        var unitOfWork = new UnitOfWork(new AzAgroPOSDbContext());
        _manager = new BarkodCapiManager(unitOfWork);

        _view.AxtarisIstek += async (s, e) => await MehsulAxtar();
        _view.SiyahiniCapaGonderIstek += (s, e) => SiyahiniCapaGonder();
    }

    private async Task MehsulAxtar()
    {
        var netice = await _manager.MehsullariAxtarAsync(_view.AxtarisMetni);
        if (netice.UgurluDur)
        {
            _view.AxtarisNeticeleriniGoster(netice.Data);
        }
        else
        {
            _view.AxtarisXetasiGoster(netice.Mesaj);
        }
    }

    private void SiyahiniCapaGonder()
    {
        var siyahı = _view.CapSiyahisi;
        if (siyahı == null || !siyahı.Any())
        {
            _view.MesajGoster("Çap etmək üçün siyahı boşdur.", "Xəbərdarlıq");
            return;
        }

        // Burada CapServisi-nə bənzər yeni bir BarkodCapServisi yaradılmalıdır.
        // Hələlik sadəlik üçün birbaşa mesaj çıxarırıq.
        // Gələcəkdə bu hissə həqiqi çap məntiqi ilə əvəz olunacaq.
        _view.MesajGoster($"{siyahı.Sum(x => x.CapEdilecekSay)} ədəd etiket çapa göndərildi (simulyasiya).", "Uğurlu");
    }
}