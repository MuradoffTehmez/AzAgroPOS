// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/AnbarPresenter.cs
using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Sabitler;
using AzAgroPOS.Teqdimat.Yardimcilar;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.Teqdimat.Teqdimatcilar
{
    /// <summary>
    /// Anbar formu ilə biznes məntiqi (AnbarManager) arasında əlaqəni qurur.
    /// MVP pattern-in Presenter hissəsi.
    /// </summary>
    public class AnbarPresenter
    {
        private readonly IAnbarView _view;
        private readonly AnbarManager _anbarManager;
        private readonly StokHareketiManager _stokHareketiManager;

        public AnbarPresenter(
            IAnbarView view,
            AnbarManager anbarManager,
            StokHareketiManager stokHareketiManager)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _anbarManager = anbarManager ?? throw new ArgumentNullException(nameof(anbarManager));
            _stokHareketiManager = stokHareketiManager ?? throw new ArgumentNullException(nameof(stokHareketiManager));

            SubscribeToViewEvents();
        }

        #region Event Subscription

        private void SubscribeToViewEvents()
        {
            _view.AxtarIstek += async (s, e) => await MehsulAxtarAsync();
            _view.StokArtirIstek += async (s, e) => await StokArtirAsync();
            _view.StokAzaltIstek += async (s, e) => await StokAzaltAsync();
            _view.StokDuzelisIstek += async (s, e) => await StokDuzelisAsync();
            _view.TemizleIstek += (s, e) => FormuTemizle();
            _view.TarixceGosterIstek += async (s, e) => await TarixceGosterAsync();
            _view.FormYuklendi += async (s, e) => await FormYuklendiAsync();
            _view.MehsulSecildi += async (s, mehsulId) => await MehsulSecildiAsync(mehsulId);
        }

        #endregion

        #region Form Yüklənmə

        /// <summary>
        /// Form yüklənərkən ilk tənzimləmələr
        /// </summary>
        private async Task FormYuklendiAsync()
        {
            try
            {
                _view.YuklemeGoster(AnbarSabitleri.UIMetinler.YukleniR);

                // İlkin vəziyyət
                _view.MehsulPaneliniGoster(false);
                _view.EmeliyyatDuymeleriniAktivet(false);

                // Bütün məhsulları yüklə
                await ButunMehsullariYukleAsync();

                // Son əməliyyatları yüklə
                await TarixceGridiniYenileAsync();

                _view.YuklemeGizle();
                _view.AxtarisFocus();
            }
            catch (Exception ex)
            {
                _view.YuklemeGizle();
                _view.XetaMesajiGoster($"{AnbarSabitleri.XetaMesajlari.MelumatYuklenmeXetasi}: {ex.Message}");
            }
        }

        /// <summary>
        /// Bütün məhsulları yükləyib göstərir
        /// </summary>
        private async Task ButunMehsullariYukleAsync()
        {
            try
            {
                var netice = await _anbarManager.ButunMehsullariGetirAsync();

                if (netice.UgurluDur && netice.Data != null)
                {
                    _view.ButunMehsullariGoster(netice.Data);
                }
            }
            catch (Exception ex)
            {
                _view.XetaMesajiGoster($"Məhsullar yüklənərkən xəta: {ex.Message}");
            }
        }

        /// <summary>
        /// Məhsullar grid-indən məhsul seçildikdə işə düşür
        /// </summary>
        private async Task MehsulSecildiAsync(int mehsulId)
        {
            try
            {
                _view.YuklemeGoster("Məhsul məlumatları yüklənir...");

                // Məhsul məlumatlarını əldə et
                var mehsullar = await _anbarManager.ButunMehsullariGetirAsync();
                if (mehsullar.UgurluDur && mehsullar.Data != null)
                {
                    var mehsul = mehsullar.Data.Find(m => m.Id == mehsulId);
                    if (mehsul != null)
                    {
                        // Məhsul məlumatlarını göstər
                        _view.MehsulMelumatlariniGoster(mehsul);
                        _view.MehsulPaneliniGoster(true);
                        _view.EmeliyyatDuymeleriniAktivet(true);

                        // Məhsulun tarixçəsini yüklə
                        await TarixceGridiniYenileAsync(mehsulId);

                        // Minimum stok xəbərdarlığı
                        if (mehsul.MovcudSay <= mehsul.MinimumStok && mehsul.MinimumStok > 0)
                        {
                            _view.XeberdarlikMesajiGoster(AnbarSabitleri.MelumatMesajlari.MinimumStokXeberdarligi);
                        }
                        else if (mehsul.MovcudSay == 0)
                        {
                            _view.XeberdarlikMesajiGoster(AnbarSabitleri.MelumatMesajlari.StokBitdi);
                        }
                    }
                }

                _view.YuklemeGizle();
            }
            catch (Exception ex)
            {
                _view.YuklemeGizle();
                _view.XetaMesajiGoster($"Məhsul seçilmərkən xəta: {ex.Message}");
            }
        }

        #endregion

        #region Məhsul Axtarma

        /// <summary>
        /// Məhsulu axtarır (barkod və ya stok kodu ilə)
        /// </summary>
        private async Task MehsulAxtarAsync()
        {
            try
            {
                // Validasiya
                _view.ButunXetalariTemizle();
                var validasiyaNetice = AnbarValidasiyasi.AxtarisMetniValidet(_view.AxtarisMetni);

                if (!validasiyaNetice.UgurludurMu)
                {
                    _view.ValidasiyaXetalariGoster(validasiyaNetice.XetalariGoster());
                    return;
                }

                _view.YuklemeGoster(AnbarSabitleri.UIMetinler.Axtarilir);
                _view.AxtarDuymesiniAktivet(false);

                // Məhsulu tap
                var netice = await _anbarManager.MehsulTapAsync(_view.AxtarisMetni.Trim());

                _view.YuklemeGizle();
                _view.AxtarDuymesiniAktivet(true);

                if (netice.UgurluDur && netice.Data != null)
                {
                    // Məhsul tapıldı
                    _view.MehsulMelumatlariniGoster(netice.Data);
                    _view.MehsulPaneliniGoster(true);
                    _view.EmeliyyatDuymeleriniAktivet(true);
                    _view.SayFocus();

                    // Minimum stok xəbərdarlığı
                    if (netice.Data.MovcudSay <= netice.Data.MinimumStok && netice.Data.MinimumStok > 0)
                    {
                        _view.XeberdarlikMesajiGoster(AnbarSabitleri.MelumatMesajlari.MinimumStokXeberdarligi);
                    }
                    else if (netice.Data.MovcudSay == 0)
                    {
                        _view.XeberdarlikMesajiGoster(AnbarSabitleri.MelumatMesajlari.StokBitdi);
                    }
                }
                else
                {
                    // Məhsul tapılmadı
                    _view.XetaMesajiGoster(AnbarSabitleri.XetaMesajlari.MehsulTapilmadi);
                    _view.FormuTemizle(axtarisQutusuQalsin: true);
                    _view.AxtarisFocus();
                }
            }
            catch (Exception ex)
            {
                _view.YuklemeGizle();
                _view.AxtarDuymesiniAktivet(true);
                _view.XetaMesajiGoster($"{AnbarSabitleri.XetaMesajlari.EmeliyyatUgursuz}: {ex.Message}");
            }
        }

        #endregion

        #region Stok Artırma

        /// <summary>
        /// Stok artırma əməliyyatı
        /// </summary>
        private async Task StokArtirAsync()
        {
            try
            {
                _view.ButunXetalariTemizle();

                // Məhsul seçilmişmi?
                var mehsulValidasiya = AnbarValidasiyasi.MehsulSecilmisValidet(_view.SecilmisMehsulId);
                if (!mehsulValidasiya.UgurludurMu)
                {
                    _view.XetaMesajiGoster(mehsulValidasiya.XetalariGoster());
                    return;
                }

                // Say validasiyası
                var sayValidasiya = AnbarValidasiyasi.SayValidet(_view.ElaveOlunanSay);
                if (!sayValidasiya.UgurludurMu)
                {
                    _view.ValidasiyaXetalariGoster(sayValidasiya.XetalariGoster());
                    return;
                }

                decimal say = decimal.Parse(_view.ElaveOlunanSay.Trim());

                // Təsdiq soruşu
                var mesaj = string.Format(AnbarSabitleri.TesdiqSorulari.StokArtirmaTesdiqi, say);
                if (!_view.TesdiqSorusu(mesaj))
                {
                    return;
                }

                _view.YuklemeGoster(AnbarSabitleri.UIMetinler.Saxlanir);
                _view.EmeliyyatDuymeleriniAktivet(false);

                // Stoku artır
                var netice = await _anbarManager.AnbardakiStokuArtirAsync(
                    _view.SecilmisMehsulId.Value,
                    (int)Math.Round(say));

                _view.YuklemeGizle();
                _view.EmeliyyatDuymeleriniAktivet(true);

                if (netice.UgurluDur)
                {
                    var ugurMesaj = string.Format(AnbarSabitleri.UgurMesajlari.StokArtirilib, netice.Data);
                    _view.UgurMesajiGoster(ugurMesaj);

                    // Tarixçəni yenilə
                    await TarixceGridiniYenileAsync();

                    // Formu təmizlə
                    _view.FormuTemizle();
                    _view.AxtarisFocus();
                }
                else
                {
                    _view.XetaMesajiGoster(netice.Mesaj);
                }
            }
            catch (Exception ex)
            {
                _view.YuklemeGizle();
                _view.EmeliyyatDuymeleriniAktivet(true);
                _view.XetaMesajiGoster($"{AnbarSabitleri.XetaMesajlari.EmeliyyatUgursuz}: {ex.Message}");
            }
        }

        #endregion

        #region Stok Azaltma

        /// <summary>
        /// Stok azaltma əməliyyatı
        /// </summary>
        private async Task StokAzaltAsync()
        {
            try
            {
                _view.ButunXetalariTemizle();

                // Məhsul seçilmişmi?
                var mehsulValidasiya = AnbarValidasiyasi.MehsulSecilmisValidet(_view.SecilmisMehsulId);
                if (!mehsulValidasiya.UgurludurMu)
                {
                    _view.XetaMesajiGoster(mehsulValidasiya.XetalariGoster());
                    return;
                }

                // Say validasiyası
                var sayValidasiya = AnbarValidasiyasi.SayValidet(_view.ElaveOlunanSay);
                if (!sayValidasiya.UgurludurMu)
                {
                    _view.ValidasiyaXetalariGoster(sayValidasiya.XetalariGoster());
                    return;
                }

                decimal say = decimal.Parse(_view.ElaveOlunanSay.Trim());

                // Mövcud stoku yoxla
                var mehsulNetice = await _anbarManager.MehsulTapAsync(_view.AxtarisMetni.Trim());
                if (!mehsulNetice.UgurluDur || mehsulNetice.Data == null)
                {
                    _view.XetaMesajiGoster(AnbarSabitleri.XetaMesajlari.MehsulTapilmadi);
                    return;
                }

                decimal movcudStok = mehsulNetice.Data.MovcudSay;

                // Azaltma validasiyası
                var azaltmaValidasiya = AnbarValidasiyasi.StokAzaltmaValidet(movcudStok, say);
                if (!azaltmaValidasiya.UgurludurMu)
                {
                    _view.XetaMesajiGoster(azaltmaValidasiya.XetalariGoster());
                    return;
                }

                // Xəbərdarlıqlar
                if (AnbarValidasiyasi.StokSifirOlacaqmi(movcudStok, say))
                {
                    if (!_view.TesdiqSorusu(AnbarSabitleri.XeberdarlikMesajlari.StokSifirOlacaq))
                    {
                        return;
                    }
                }
                else if (AnbarValidasiyasi.BoyukMiqdarAzaltmami(movcudStok, say))
                {
                    var xeberdarlik = string.Format(
                        AnbarSabitleri.XeberdarlikMesajlari.BoyukMiqdarAzaltma,
                        say);
                    if (!_view.TesdiqSorusu(xeberdarlik))
                    {
                        return;
                    }
                }

                // Təsdiq soruşu
                var mesaj = string.Format(AnbarSabitleri.TesdiqSorulari.StokAzaltmaTesdiqi, say);
                if (!_view.TesdiqSorusu(mesaj))
                {
                    return;
                }

                _view.YuklemeGoster(AnbarSabitleri.UIMetinler.Saxlanir);
                _view.EmeliyyatDuymeleriniAktivet(false);

                // Stoku azalt (mənfi say göndəririk)
                var netice = await _anbarManager.AnbardakiStokuArtirAsync(
                    _view.SecilmisMehsulId.Value,
                    -(int)Math.Round(say));

                _view.YuklemeGizle();
                _view.EmeliyyatDuymeleriniAktivet(true);

                if (netice.UgurluDur)
                {
                    var ugurMesaj = string.Format(AnbarSabitleri.UgurMesajlari.StokAzaldilib, netice.Data);
                    _view.UgurMesajiGoster(ugurMesaj);

                    // Tarixçəni yenilə
                    await TarixceGridiniYenileAsync();

                    // Formu təmizlə
                    _view.FormuTemizle();
                    _view.AxtarisFocus();
                }
                else
                {
                    _view.XetaMesajiGoster(netice.Mesaj);
                }
            }
            catch (Exception ex)
            {
                _view.YuklemeGizle();
                _view.EmeliyyatDuymeleriniAktivet(true);
                _view.XetaMesajiGoster($"{AnbarSabitleri.XetaMesajlari.EmeliyyatUgursuz}: {ex.Message}");
            }
        }

        #endregion

        #region Stok Düzəliş

        /// <summary>
        /// Stok düzəliş əməliyyatı (manuel düzəltmə)
        /// </summary>
        private async Task StokDuzelisAsync()
        {
            try
            {
                _view.ButunXetalariTemizle();

                // Məhsul seçilmişmi?
                var mehsulValidasiya = AnbarValidasiyasi.MehsulSecilmisValidet(_view.SecilmisMehsulId);
                if (!mehsulValidasiya.UgurludurMu)
                {
                    _view.XetaMesajiGoster(mehsulValidasiya.XetalariGoster());
                    return;
                }

                // Yeni stok sayı validasiyası
                var sayValidasiya = AnbarValidasiyasi.SayValidet(_view.ElaveOlunanSay);
                if (!sayValidasiya.UgurludurMu)
                {
                    _view.ValidasiyaXetalariGoster(sayValidasiya.XetalariGoster());
                    return;
                }

                decimal yeniStok = decimal.Parse(_view.ElaveOlunanSay.Trim());

                // Qeyd mütləqdir düzəliş üçün
                var qeydValidasiya = AnbarValidasiyasi.QeydValidet(_view.Qeyd, telebe: true);
                if (!qeydValidasiya.UgurludurMu)
                {
                    _view.ValidasiyaXetalariGoster(qeydValidasiya.XetalariGoster());
                    return;
                }

                // Düzəliş validasiyası
                var duzelisValidasiya = AnbarValidasiyasi.StokDuzelisValidet(yeniStok, _view.Qeyd);
                if (!duzelisValidasiya.UgurludurMu)
                {
                    _view.XetaMesajiGoster(duzelisValidasiya.XetalariGoster());
                    return;
                }

                // Təsdiq soruşu
                var mesaj = string.Format(AnbarSabitleri.TesdiqSorulari.StokDuzelisTesdiqi, yeniStok);
                if (!_view.TesdiqSorusu(mesaj))
                {
                    return;
                }

                _view.YuklemeGoster(AnbarSabitleri.UIMetinler.Saxlanir);
                _view.EmeliyyatDuymeleriniAktivet(false);

                // Mövcud stoku əldə et
                var mehsulNetice = await _anbarManager.MehsulTapAsync(_view.AxtarisMetni.Trim());
                if (!mehsulNetice.UgurluDur || mehsulNetice.Data == null)
                {
                    _view.YuklemeGizle();
                    _view.EmeliyyatDuymeleriniAktivet(true);
                    _view.XetaMesajiGoster(AnbarSabitleri.XetaMesajlari.MehsulTapilmadi);
                    return;
                }

                decimal movcudStok = mehsulNetice.Data.MovcudSay;
                decimal ferq = yeniStok - movcudStok;

                // Stoku düzəlt
                var netice = await _anbarManager.AnbardakiStokuArtirAsync(
                    _view.SecilmisMehsulId.Value,
                    (int)Math.Round(ferq));

                _view.YuklemeGizle();
                _view.EmeliyyatDuymeleriniAktivet(true);

                if (netice.UgurluDur)
                {
                    var ugurMesaj = string.Format(AnbarSabitleri.UgurMesajlari.StokDuzelisEdildi, netice.Data);
                    _view.UgurMesajiGoster(ugurMesaj);

                    // Tarixçəni yenilə
                    await TarixceGridiniYenileAsync();

                    // Formu təmizlə
                    _view.FormuTemizle();
                    _view.AxtarisFocus();
                }
                else
                {
                    _view.XetaMesajiGoster(netice.Mesaj);
                }
            }
            catch (Exception ex)
            {
                _view.YuklemeGizle();
                _view.EmeliyyatDuymeleriniAktivet(true);
                _view.XetaMesajiGoster($"{AnbarSabitleri.XetaMesajlari.EmeliyyatUgursuz}: {ex.Message}");
            }
        }

        #endregion

        #region Tarixçə

        /// <summary>
        /// Son stok hərəkətlərini göstərir
        /// </summary>
        private async Task TarixceGosterAsync()
        {
            try
            {
                if (!_view.SecilmisMehsulId.HasValue)
                {
                    _view.XetaMesajiGoster(AnbarSabitleri.XetaMesajlari.MehsulSecilmeyib);
                    return;
                }

                await TarixceGridiniYenileAsync(_view.SecilmisMehsulId.Value);
            }
            catch (Exception ex)
            {
                _view.XetaMesajiGoster($"{AnbarSabitleri.XetaMesajlari.EmeliyyatUgursuz}: {ex.Message}");
            }
        }

        /// <summary>
        /// Tarixçə grid-ini yeniləyir
        /// </summary>
        private async Task TarixceGridiniYenileAsync(int? mehsulId = null)
        {
            try
            {
                _view.YuklemeGoster(AnbarSabitleri.UIMetinler.YukleniR);

                // Stok hərəkətlərini əldə et
                var netice = await _stokHareketiManager.StokHereketleriniDtoFormatindaGetirAsync(
                    mehsulId: mehsulId,
                    limit: 50);

                if (netice.UgurluDur && netice.Data != null)
                {
                    _view.StokTarixcesiniGoster(netice.Data);
                }
                else
                {
                    // Xəta olarsa boş siyahı göstər
                    _view.StokTarixcesiniGoster(new List<StokHareketiDto>());
                }

                _view.YuklemeGizle();
            }
            catch (Exception)
            {
                _view.YuklemeGizle();
                // Tarixçə yüklənməsə də kritik deyil, səssiz keçək
                _view.StokTarixcesiniGoster(new List<StokHareketiDto>());
            }
        }

        #endregion

        #region Form Təmizləmə

        /// <summary>
        /// Formu təmizləyir
        /// </summary>
        private void FormuTemizle()
        {
            try
            {
                _view.FormuTemizle(axtarisQutusuQalsin: false);
                _view.MehsulPaneliniGoster(false);
                _view.EmeliyyatDuymeleriniAktivet(false);
                _view.ButunXetalariTemizle();
                _view.AxtarisFocus();
            }
            catch (Exception ex)
            {
                _view.XetaMesajiGoster($"Form təmizlənərkən xəta: {ex.Message}");
            }
        }

        #endregion
    }
}
