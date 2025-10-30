// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/XercPresenter.cs

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Mentiq.Yardimcilar;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Yardimcilar;
using IcazeYoxlayici = AzAgroPOS.Mentiq.Yardimcilar.IcazeYoxlayici;

namespace AzAgroPOS.Teqdimat.Teqdimatcilar;
/// <summary>
/// Xərc idarəetməsi üçün presenter
/// diqqət: Bu sinif xərc əməliyyatlarını idarə edir.
/// qeyd: Xərc əlavə etmə, yeniləmə, silmə və axtarış əməliyyatlarını həyata keçirir.
/// rol: Xərc məlumatlarının UI və biznes məntiqi arasında köprü rolunu oynayır.
/// </summary>
public class XercPresenter
{
    private readonly IXercView _view;
    private readonly MaliyyeManager _maliyyeManager;
    private readonly IcazeYoxlayici _icazeYoxlayici;

    public XercPresenter(IXercView view, MaliyyeManager maliyyeManager)
    {
        _view = view;
        _maliyyeManager = maliyyeManager;
        _icazeYoxlayici = IcazeYoxlayici.Instance;

        AbuneOl();
    }

    private void AbuneOl()
    {
        _view.FormYuklendiIstek += async (s, e) => await FormYuklendi();
        _view.XercElaveEtIstek += async (s, e) => await XercElaveEt();
        _view.XercYenileIstek += async (s, e) => await XercYenile();
        _view.XercSilIstek += async (s, e) => await XercSil();
        _view.XercAxtarIstek += async (s, e) => await XercleriAxtar();
    }

        private async Task FormYuklendi()
        {
            await XercleriAxtar();
        }

        private async Task XercleriAxtar()
        {
            try
            {
                // Bütün xərcləri əldə edin
                var netice = await _maliyyeManager.ButunXercleriGetirAsync();
                if (netice.UgurluDur)
                {
                    var dtolar = netice.Data.Select(x => new XercDto
                    {
                        Id = x.Id,
                        Novu = x.Novu,
                        Ad = x.Ad,
                        Mebleg = x.Mebleg,
                        Tarix = x.Tarix,
                        SenedNomresi = x.SenedNomresi,
                        Qeyd = x.Qeyd,
                        IstifadeciId = x.IstifadeciId,
                        IstifadeciAdi = x.Istifadeci?.TamAd
                    }).ToList();

                    _view.XercleriGoster(dtolar);
                }
                else
                {
                    _view.MesajGoster($"Xərclər əldə edilərkən xəta baş verdi: {netice.Mesaj}", 
                        "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Logger.XetaYaz(ex, "Xərclər yüklənərkən istisna baş verdi");
                _view.MesajGoster($"Xərclər yüklənərkən istisna baş verdi: {ex.Message}", 
                    "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task XercElaveEt()
        {
            // İcazəni yoxlayın
            if (!_icazeYoxlayici.IcazeVarmi("CanManageExpenses"))
            {
                _view.MesajGoster("Sizin xərc idarə etmək icazəniz yoxdur.", 
                    "İcazə Yoxdur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Validasiya
                if (string.IsNullOrWhiteSpace(_view.XercAdi))
                {
                    _view.MesajGoster("Xərc adı boş ola bilməz.", 
                        "Validasiya Xətası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_view.XercMeblegi <= 0)
                {
                    _view.MesajGoster("Xərc məbləği sıfırdan böyük olmalıdır.", 
                        "Validasiya Xətası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Xərc yaradın
                var netice = await _maliyyeManager.XercYaratAsync(
                    _view.SecilmisXercNovu,
                    _view.XercAdi,
                    _view.XercMeblegi,
                    _view.XercTarixi,
                    _view.XercSenedNomresi,
                    _view.XercQeydi,
                    AktivSessiya.AktivIstifadeci?.Id);

                if (netice.UgurluDur)
                {
                    _view.MesajGoster("Xərc uğurla əlavə edildi.", 
                        "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _view.XercFormunuSifirla();
                    await XercleriAxtar(); // Siyahını yeniləyin
                }
                else
                {
                    _view.MesajGoster($"Xərc əlavə edilərkən xəta baş verdi: {netice.Mesaj}", 
                        "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Logger.XetaYaz(ex, "Xərc əlavə edilərkən istisna baş verdi");
                _view.MesajGoster($"Xərc əlavə edilərkən istisna baş verdi: {ex.Message}", 
                    "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task XercYenile()
        {
            // İcazəni yoxlayın
            if (!_icazeYoxlayici.IcazeVarmi("CanManageExpenses"))
            {
                _view.MesajGoster("Sizin xərc idarə etmək icazəniz yoxdur.", 
                    "İcazə Yoxdur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var xercId = _view.SecilmisXercId;
                if (!xercId.HasValue)
                {
                    _view.MesajGoster("Yeniləmək üçün xərc seçilməlidir.", 
                        "Validasiya Xətası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validasiya
                if (string.IsNullOrWhiteSpace(_view.XercAdi))
                {
                    _view.MesajGoster("Xərc adı boş ola bilməz.", 
                        "Validasiya Xətası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_view.XercMeblegi <= 0)
                {
                    _view.MesajGoster("Xərc məbləği sıfırdan böyük olmalıdır.", 
                        "Validasiya Xətası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Xərci yeniləyin
                var netice = await _maliyyeManager.XercYenileAsync(
                    xercId.Value,
                    _view.SecilmisXercNovu,
                    _view.XercAdi,
                    _view.XercMeblegi,
                    _view.XercTarixi,
                    _view.XercSenedNomresi,
                    _view.XercQeydi,
                    AktivSessiya.AktivIstifadeci?.Id);

                if (netice.UgurluDur)
                {
                    _view.MesajGoster("Xərc uğurla yeniləndi.", 
                        "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _view.XercFormunuSifirla();
                    await XercleriAxtar(); // Siyahını yeniləyin
                }
                else
                {
                    _view.MesajGoster($"Xərc yenilənərkən xəta baş verdi: {netice.Mesaj}", 
                        "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Logger.XetaYaz(ex, "Xərc yenilənərkən istisna baş verdi");
                _view.MesajGoster($"Xərc yenilənərkən istisna baş verdi: {ex.Message}", 
                    "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task XercSil()
        {
            // İcazəni yoxlayın
            if (!_icazeYoxlayici.IcazeVarmi("CanManageExpenses"))
            {
                _view.MesajGoster("Sizin xərc silmək icazəniz yoxdur.", 
                    "İcazə Yoxdur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var xercId = _view.SecilmisXercId;
                if (!xercId.HasValue)
                {
                    _view.MesajGoster("Silmək üçün xərc seçilməlidir.", 
                        "Validasiya Xətası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Təsdiqləmə
                var cavab = _view.MesajGoster("Bu xərc qeydiyyatını silmək istədiyinizə əminsiniz?", 
                    "Təsdiqləmə", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (cavab != DialogResult.Yes)
                    return;

                // Xərci silin
                var netice = await _maliyyeManager.XercSilAsync(xercId.Value);

                if (netice.UgurluDur)
                {
                    _view.MesajGoster("Xərc uğurla silindi.", 
                        "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _view.XercFormunuSifirla();
                    await XercleriAxtar(); // Siyahını yeniləyin
                }
                else
                {
                    _view.MesajGoster($"Xərc silinərkən xəta baş verdi: {netice.Mesaj}", 
                        "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Logger.XetaYaz(ex, "Xərc silinərkən istisna baş verdi");
                _view.MesajGoster($"Xərc silinərkən istisna baş verdi: {ex.Message}", 
                    "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
