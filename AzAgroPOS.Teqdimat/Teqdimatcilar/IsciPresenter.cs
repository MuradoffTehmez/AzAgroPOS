// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/IsciPresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Teqdimat.Interfeysler;
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
    private List<IsciDto> _isciCache;
    private readonly SehifeParametrleri _sehifeParametrleri = new SehifeParametrleri { SehifeOlcusu = 50 };
    private bool _paginationEnabled = true;

    public IsciPresenter(IIsciView view, IsciManager isciManager)
    {
        _view = view;
        _isciManager = isciManager;
        _isciCache = new List<IsciDto>();

        // Hadisələrə abunə oluruq
        _view.FormYuklendi += async (s, e) => await FormuYukle();
        _view.IsciYarat_Istek += async (s, e) => await IsciYarat();
        _view.IsciYenile_Istek += async (s, e) => await IsciYenile();
        _view.IsciSil_Istek += async (s, e) => await IsciSil();
        _view.FormuTemizle_Istek += (s, e) => _view.FormuTemizle();
        _view.AxtarIstek += async (s, e) => await Axtar();
        _view.NovbetiSehifeIstek += async (s, e) => await NovbetiSehife();
        _view.EvvelkiSehifeIstek += async (s, e) => await EvvelkiSehife();
    }

    private async Task FormuYukle()
    {
        await _view.EmeliyyatIcraEtAsync(async () =>
        {
            _sehifeParametrleri.SehifeNomresi = 1;
            await IscileriYukle();
            _view.FormuTemizle();
        }, "İşçilər yüklənir...");
    }

    private async Task IscileriYukle()
    {
        if (_paginationEnabled)
        {
            var netice = await _isciManager.IscileriSehifelenmisGetirAsync(_sehifeParametrleri);
            if (netice.UgurluDur && netice.Data != null)
            {
                var sehifelenmis = netice.Data;
                var axtarisMetni = _view.AxtarisMetni;

                IEnumerable<IsciDto> isciler = sehifelenmis.Melumatlar;
                if (!string.IsNullOrWhiteSpace(axtarisMetni))
                {
                    var axtarisLower = axtarisMetni.ToLower();
                    isciler = isciler.Where(i =>
                        i.TamAd.ToLower().Contains(axtarisLower) ||
                        i.TelefonNomresi.Contains(axtarisLower) ||
                        i.Vezife.ToLower().Contains(axtarisLower));
                }

                _view.IscileriGoster(isciler.ToList());
                _view.SehifeMelumatlariGoster(
                    sehifelenmis.CariSehife,
                    sehifelenmis.UmumiSehifeSayi,
                    sehifelenmis.UmumiQeydSayi,
                    sehifelenmis.EvvelkiSehifeVar,
                    sehifelenmis.NovbetiSehifeVar
                );
            }
        }
        else
        {
            var netice = await _isciManager.ButunIscileriGetirAsync();
            if (netice.UgurluDur)
            {
                _isciCache = netice.Data;
                _view.IscileriGoster(_isciCache);
            }
            else
            {
                _view.MesajGoster(netice.Mesaj, true);
            }
        }
    }

    private async Task Axtar()
    {
        _sehifeParametrleri.SehifeNomresi = 1;
        await IscileriYukle();
    }

    private async Task NovbetiSehife()
    {
        await _view.EmeliyyatIcraEtAsync(async () =>
        {
            _sehifeParametrleri.SehifeNomresi++;
            await IscileriYukle();
        }, "Səhifə yüklənir...");
    }

    private async Task EvvelkiSehife()
    {
        await _view.EmeliyyatIcraEtAsync(async () =>
        {
            if (_sehifeParametrleri.SehifeNomresi > 1)
            {
                _sehifeParametrleri.SehifeNomresi--;
                await IscileriYukle();
            }
        }, "Səhifə yüklənir...");
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
            BankMəlumatları = _view.BankMəlumatları,
            SistemIstifadeciAdi = _view.SistemIstifadeciAdi
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
            BankMəlumatları = _view.BankMəlumatları,
            SistemIstifadeciAdi = _view.SistemIstifadeciAdi
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

    private async Task IscininPerformansQeydleriniGoster()
    {
        if (_view.IsciId <= 0)
        {
            _view.MesajGoster("Performans qeydlərini göstərmək üçün cədvəldən işçi seçin.", true);
            return;
        }

        var netice = await _isciManager.IscininPerformansQeydleriniGetirAsync(_view.IsciId);
        if (netice.UgurluDur)
        {
            // Performans qeydlərini göstərmək üçün uyğun view metodu çağırılır
            _view.PerformansQeydleriniGoster(netice.Data);
        }
        else
        {
            _view.MesajGoster(netice.Mesaj, true);
        }
    }

    private async Task IscininIzinQeydleriniGoster()
    {
        if (_view.IsciId <= 0)
        {
            _view.MesajGoster("İzn qeydlərini göstərmək üçün cədvəldən işçi seçin.", true);
            return;
        }

        var netice = await _isciManager.IscininIzinQeydleriniGetirAsync(_view.IsciId);
        if (netice.UgurluDur)
        {
            // İzn qeydlərini göstərmək üçün uyğun view metodu çağırılır
            _view.IzinQeydleriniGoster(netice.Data);
        }
        else
        {
            _view.MesajGoster(netice.Mesaj, true);
        }
    }
}