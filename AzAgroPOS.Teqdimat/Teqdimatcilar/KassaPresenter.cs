// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/KassaPresenter.cs

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Mentiq.Yardimcilar;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Yardimcilar;
using AzAgroPOS.Varliglar;

namespace AzAgroPOS.Teqdimat.Teqdimatcilar;
/// <summary>
/// Kassa və maliyyə idarəetmə forması üçün presenter.
/// Xərcləri, kassa hərəkətlərini və maliyyə hesabatlarını idarə edir.
/// </summary>
public class KassaPresenter
{
    private readonly IKassaView _view;
    private readonly MaliyyeManager _maliyyeManager;

    public KassaPresenter(IKassaView view, MaliyyeManager maliyyeManager)
    {
        _view = view ?? throw new ArgumentNullException(nameof(view));
        _maliyyeManager = maliyyeManager ?? throw new ArgumentNullException(nameof(maliyyeManager));

        // Hadisələrə abunə oluruq
        _view.FormYuklendi += async (s, e) => await FormuYukle();
        _view.XercYarat_Istek += async (s, e) => await XercYarat();
        _view.XercYenile_Istek += async (s, e) => await XercYenile();
        _view.XercSil_Istek += async (s, e) => await XercSil();
        _view.XercTemizle_Istek += (s, e) => _view.XercFormuTemizle();
        _view.KassaFiltrele_Istek += async (s, e) => await KassaHareketleriniYukle();
        _view.HesabatGoster_Istek += async (s, e) => await MaliyyeXulasesiniYukle();
        _view.Yenile_Istek += async (s, e) => await YenileHamisi();
    }

    /// <summary>
    /// Formu yükləyir - xərcləri, kassa hərəkətlərini və maliyyə xülasəsini göstərir
    /// </summary>
    private async Task FormuYukle()
    {
        try
        {
            await XercleriYukle();
            await KassaHareketleriniYukle();
            await MaliyyeXulasesiniYukle();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Kassa formu yüklənərkən xəta");
            _view.MesajGoster($"Forma yüklənərkən xəta: {ex.Message}", true);
        }
    }

    /// <summary>
    /// Xərcləri yükləyir
    /// </summary>
    private async Task XercleriYukle()
    {
        try
        {
            EmeliyyatNeticesi<List<XercDto>> netice = await _maliyyeManager.ButunXercleriDtoFormatindaGetirAsync();
            if (netice.UgurluDur && netice.Data != null)
            {
                _view.XercleriGoster(netice.Data.ToList());
            }
            else
            {
                _view.MesajGoster($"Xərclər yüklənərkən xəta: {netice.Mesaj}", true);
            }
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Xərclər yüklənərkən xəta");
            _view.MesajGoster($"Xərclər yüklənərkən xəta: {ex.Message}", true);
        }
    }

    /// <summary>
    /// Kassa hərəkətlərini yükləyir
    /// </summary>
    private async Task KassaHareketleriniYukle()
    {
        try
        {
            EmeliyyatNeticesi<List<KassaHareketi>> netice = await _maliyyeManager.KassaHareketleriniGetirAsync(
                _view.BaslangicTarixi.Date,
                _view.BitisTarixi.Date);

            if (netice.UgurluDur && netice.Data != null)
            {
                _view.KassaHareketleriniGoster(netice.Data.ToList());
            }
            else
            {
                _view.MesajGoster($"Kassa hərəkətləri yüklənərkən xəta: {netice.Mesaj}", true);
            }
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Kassa hərəkətləri yüklənərkən xəta");
            _view.MesajGoster($"Kassa hərəkətləri yüklənərkən xəta: {ex.Message}", true);
        }
    }

    /// <summary>
    /// Maliyyə xülasəsini hesablayır və göstərir
    /// </summary>
    private async Task MaliyyeXulasesiniYukle()
    {
        try
        {
            DateTime baslangic = _view.XesabatBaslangicTarixi.Date;
            DateTime bitis = _view.XesabatBitisTarixi.Date;

            // Gəlirləri hesabla
            EmeliyyatNeticesi<List<KassaHareketi>> kassaHareketleriNetice = await _maliyyeManager.KassaHareketleriniGetirAsync(baslangic, bitis);
            decimal gelirler = 0;
            if (kassaHareketleriNetice.UgurluDur && kassaHareketleriNetice.Data != null)
            {
                gelirler = kassaHareketleriNetice.Data
                    .Where(k => k.HareketNovu == KassaHareketiNovu.Daxilolma)
                    .Sum(k => k.Mebleg);
            }

            // Xərcləri hesabla
            EmeliyyatNeticesi<decimal> xercCemiNetice = await _maliyyeManager.XercCeminiHesablaAsync(baslangic, bitis);
            decimal xercler = xercCemiNetice.UgurluDur ? xercCemiNetice.Data : 0;

            // Mənfəət/Zərəri hesabla
            EmeliyyatNeticesi<decimal> menfeetNetice = await _maliyyeManager.MenfeetZerereHesablaAsync(baslangic, bitis);
            decimal menfeetZerere = menfeetNetice.UgurluDur ? menfeetNetice.Data : 0;

            // Cari kassa balansını hesabla (bütün tarixlər üçün)
            EmeliyyatNeticesi<List<KassaHareketi>> butunHareketlerNetice = await _maliyyeManager.KassaHareketleriniGetirAsync();
            decimal balans = 0;
            if (butunHareketlerNetice.UgurluDur && butunHareketlerNetice.Data != null)
            {
                decimal gelirlerCem = butunHareketlerNetice.Data
                    .Where(k => k.HareketNovu == KassaHareketiNovu.Daxilolma)
                    .Sum(k => k.Mebleg);

                decimal xerclerCem = butunHareketlerNetice.Data
                    .Where(k => k.HareketNovu == KassaHareketiNovu.Cixis)
                    .Sum(k => k.Mebleg);

                balans = gelirlerCem - xerclerCem;
            }

            _view.MaliyyeXulasesiniGoster(gelirler, xercler, menfeetZerere, balans);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Maliyyə xülasəsi hesablanarkən xəta");
            _view.MesajGoster($"Maliyyə xülasəsi hesablanarkən xəta: {ex.Message}", true);
        }
    }

    /// <summary>
    /// Yeni xərc yaradır
    /// </summary>
    private async Task XercYarat()
    {
        try
        {
            if (string.IsNullOrWhiteSpace(_view.XercAd))
            {
                _view.MesajGoster("Xərc adı daxil edin!", true);
                return;
            }

            if (_view.XercMebleg <= 0)
            {
                _view.MesajGoster("Xərc məbləği 0-dan böyük olmalıdır!", true);
                return;
            }

            EmeliyyatNeticesi<int> netice = await _maliyyeManager.XercYaratAsync(
                _view.XercNovu,
                _view.XercAd,
                _view.XercMebleg,
                _view.XercTarixi,
                _view.SenedNomresi,
                _view.XercQeyd,
                AktivSessiya.AktivIstifadeci?.Id);

            if (netice.UgurluDur)
            {
                _view.MesajGoster("Xərc uğurla yaradıldı!");
                await XercleriYukle();
                await KassaHareketleriniYukle();
                await MaliyyeXulasesiniYukle();
                _view.XercFormuTemizle();
            }
            else
            {
                _view.MesajGoster($"Xəta: {netice.Mesaj}", true);
            }
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Xərc yaradılarkən xəta");
            _view.MesajGoster($"Xərc yaratma xətası: {ex.Message}", true);
        }
    }

    /// <summary>
    /// Xərci yeniləyir
    /// </summary>
    private async Task XercYenile()
    {
        try
        {
            if (!_view.SecilenXercId.HasValue || _view.SecilenXercId.Value == 0)
            {
                _view.MesajGoster("Zəhmət olmasa yeniləmək üçün xərc seçin!", true);
                return;
            }

            if (string.IsNullOrWhiteSpace(_view.XercAd))
            {
                _view.MesajGoster("Xərc adı daxil edin!", true);
                return;
            }

            if (_view.XercMebleg <= 0)
            {
                _view.MesajGoster("Xərc məbləği 0-dan böyük olmalıdır!", true);
                return;
            }

            EmeliyyatNeticesi netice = await _maliyyeManager.XercYenileAsync(
                _view.SecilenXercId.Value,
                _view.XercNovu,
                _view.XercAd,
                _view.XercMebleg,
                _view.XercTarixi,
                _view.SenedNomresi,
                _view.XercQeyd,
                AktivSessiya.AktivIstifadeci?.Id);

            if (netice.UgurluDur)
            {
                _view.MesajGoster("Xərc uğurla yeniləndi!");
                await XercleriYukle();
                await KassaHareketleriniYukle();
                await MaliyyeXulasesiniYukle();
                _view.XercFormuTemizle();
            }
            else
            {
                _view.MesajGoster($"Xəta: {netice.Mesaj}", true);
            }
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Xərc yenilənərkən xəta");
            _view.MesajGoster($"Xərc yeniləmə xətası: {ex.Message}", true);
        }
    }

    /// <summary>
    /// Xərci silir
    /// </summary>
    private async Task XercSil()
    {
        try
        {
            if (!_view.SecilenXercId.HasValue || _view.SecilenXercId.Value == 0)
            {
                _view.MesajGoster("Zəhmət olmasa silmək üçün xərc seçin!", true);
                return;
            }

            EmeliyyatNeticesi netice = await _maliyyeManager.XercSilAsync(_view.SecilenXercId.Value);

            if (netice.UgurluDur)
            {
                _view.MesajGoster("Xərc uğurla silindi!");
                await XercleriYukle();
                await KassaHareketleriniYukle();
                await MaliyyeXulasesiniYukle();
                _view.XercFormuTemizle();
            }
            else
            {
                _view.MesajGoster($"Xəta: {netice.Mesaj}", true);
            }
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Xərc silinərkən xəta");
            _view.MesajGoster($"Xərc silmə xətası: {ex.Message}", true);
        }
    }

    /// <summary>
    /// Bütün məlumatları yeniləyir
    /// </summary>
    private async Task YenileHamisi()
    {
        try
        {
            await XercleriYukle();
            await KassaHareketleriniYukle();
            await MaliyyeXulasesiniYukle();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Məlumatlar yenilənərkən xəta");
            _view.MesajGoster($"Məlumatlar yenilənərkən xəta: {ex.Message}", true);
        }
    }
}
