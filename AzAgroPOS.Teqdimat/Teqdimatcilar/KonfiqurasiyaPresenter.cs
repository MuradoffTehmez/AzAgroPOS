// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/KonfiqurasiyaPresenter.cs
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Mentiq.Yardimcilar;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Sabitler;
using AzAgroPOS.Teqdimat.Yardimcilar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.Teqdimat.Teqdimatcilar
{
    /// <summary>
    /// Konfiqurasiya forması üçün presenter.
    /// MVP pattern-in Presenter hissəsi - business logic və data management.
    /// </summary>
    public class KonfiqurasiyaPresenter
    {
        private readonly IKonfiqurasiyaView _view;
        private readonly KonfiqurasiyaManager _konfiqurasiyaManager;

        /// <summary>
        /// Constructor - View və Manager-i inject edir
        /// </summary>
        public KonfiqurasiyaPresenter(IKonfiqurasiyaView view, KonfiqurasiyaManager konfiqurasiyaManager)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _konfiqurasiyaManager = konfiqurasiyaManager ?? throw new ArgumentNullException(nameof(konfiqurasiyaManager));

            // Event-lərə subscribe ol
            SubscribeToViewEvents();
        }

        /// <summary>
        /// View event-lərinə subscribe olur
        /// </summary>
        private void SubscribeToViewEvents()
        {
            _view.YaddaSaxlaClick += async (s, e) => await SaxlaKonfiqurasiyaParametrleriniAsync();
            _view.LegvEtClick += (s, e) => LegvEt();
            _view.QebzPrinterSecClick += (s, e) => QebzPrinterSec();
            _view.BarkodPrinterSecClick += (s, e) => BarkodPrinterSec();
            _view.LogoSecClick += (s, e) => LogoSec();
            _view.DeyerDeyisdi += (s, e) => DeyerDeyisdi();
            _view.FormYuklendi += async (s, e) => await FormYuklendi();
        }

        #region Form Lifecycle Methods

        /// <summary>
        /// Form yükləndikdə işə düşür - məlumatları yükləyir və UI-ı hazırlayır
        /// </summary>
        private async Task FormYuklendi()
        {
            try
            {
                _view.YuklemeGoster("Konfiqurasiya parametrləri yüklənir...");

                // Combo box-ları doldur
                ComboBoxlariDoldur();

                // Konfiqurasiya parametrlərini yüklə
                await YukleKonfiqurasiyaParametrleriniAsync();

                _view.YuklemeGizle();
            }
            catch (Exception ex)
            {
                _view.YuklemeGizle();
                Logger.XetaYaz(ex, "Form yüklənərkən xəta");
                _view.XetaMesajiGoster($"Form yüklənərkən xəta: {ex.Message}");
            }
        }

        /// <summary>
        /// Combo box-ları doldurur
        /// </summary>
        private void ComboBoxlariDoldur()
        {
            // Dillər
            var diller = new Dictionary<string, string>
            {
                { KonfiqurasiyaSabitleri.Diller.Azerbaycan, "Azərbaycan" },
                { KonfiqurasiyaSabitleri.Diller.English, "English" },
                { KonfiqurasiyaSabitleri.Diller.Russian, "Русский" },
                { KonfiqurasiyaSabitleri.Diller.Turkish, "Türkçe" }
            };
            _view.DilComboBoxDoldur(diller, _view.SistemDil);

            // Valyutalar
            var valyutalar = new List<string>
            {
                KonfiqurasiyaSabitleri.Valyutalar.AZN,
                KonfiqurasiyaSabitleri.Valyutalar.USD,
                KonfiqurasiyaSabitleri.Valyutalar.EUR,
                KonfiqurasiyaSabitleri.Valyutalar.TRY,
                KonfiqurasiyaSabitleri.Valyutalar.RUB
            };
            _view.ValyutaComboBoxDoldur(valyutalar, _view.SistemValyuta);

            // Kağız ölçüləri
            var olculer = new List<string>
            {
                KonfiqurasiyaSabitleri.KagizOlculeri.A4,
                KonfiqurasiyaSabitleri.KagizOlculeri.A5,
                KonfiqurasiyaSabitleri.KagizOlculeri.Letter,
                KonfiqurasiyaSabitleri.KagizOlculeri.Thermal80mm,
                KonfiqurasiyaSabitleri.KagizOlculeri.Thermal58mm
            };
            _view.KagizOlcusuComboBoxDoldur(olculer, _view.PrinterKagizOlcusu);

            // Temalar
            var temalar = new List<string>
            {
                KonfiqurasiyaSabitleri.Temalar.Light,
                KonfiqurasiyaSabitleri.Temalar.Dark
            };
            _view.TemaComboBoxDoldur(temalar, _view.SistemTema);
        }

        /// <summary>
        /// Ləğv et düyməsinə basıldıqda işə düşür
        /// </summary>
        private void LegvEt()
        {
            if (_view.IsDirty)
            {
                var netice = _view.TesdiqSorusu("Yadda saxlanmamış dəyişikliklər var. Formu bağlamaq istədiyinizə əminsiniz?");
                if (!netice)
                    return;
            }

            _view.FormuYenile();
            _view.IsDirty = false;
        }

        /// <summary>
        /// Dəyər dəyişdikdə işə düşür
        /// </summary>
        private void DeyerDeyisdi()
        {
            _view.IsDirty = true;
            _view.YaddaSaxlaDuymesiniBiraktir(true);
            _view.LegvEtDuymesiniBiraktir(true);
        }

        #endregion

        #region Data Loading

        /// <summary>
        /// Konfiqurasiya parametrlərini yükləyir
        /// </summary>
        public async Task YukleKonfiqurasiyaParametrleriniAsync()
        {
            try
            {
                // Şirkət məlumatları
                _view.SirketAdi = await _konfiqurasiyaManager.GetirAsync(
                    KonfiqurasiyaSabitleri.Acarlar.SirketAdi,
                    KonfiqurasiyaSabitleri.VarsayilanDeyerler.SirketAdi);

                _view.SirketUnvani = await _konfiqurasiyaManager.GetirAsync(
                    KonfiqurasiyaSabitleri.Acarlar.SirketUnvani,
                    KonfiqurasiyaSabitleri.VarsayilanDeyerler.SirketUnvani);

                _view.SirketVoen = await _konfiqurasiyaManager.GetirAsync(
                    KonfiqurasiyaSabitleri.Acarlar.SirketVoen,
                    KonfiqurasiyaSabitleri.VarsayilanDeyerler.SirketVoen);

                _view.SirketTelefon = await _konfiqurasiyaManager.GetirAsync(
                    KonfiqurasiyaSabitleri.Acarlar.SirketTelefon,
                    KonfiqurasiyaSabitleri.VarsayilanDeyerler.SirketTelefon);

                _view.SirketEmail = await _konfiqurasiyaManager.GetirAsync(
                    KonfiqurasiyaSabitleri.Acarlar.SirketEmail,
                    KonfiqurasiyaSabitleri.VarsayilanDeyerler.SirketEmail);

                _view.SirketVebSayt = await _konfiqurasiyaManager.GetirAsync(
                    KonfiqurasiyaSabitleri.Acarlar.SirketVebSayt,
                    KonfiqurasiyaSabitleri.VarsayilanDeyerler.SirketVebSayt);

                var logoYolu = await _konfiqurasiyaManager.GetirAsync(
                    KonfiqurasiyaSabitleri.Acarlar.SirketLogo,
                    KonfiqurasiyaSabitleri.VarsayilanDeyerler.SirketLogo);
                _view.SirketLogo = logoYolu;
                if (!string.IsNullOrWhiteSpace(logoYolu))
                {
                    _view.LogoGoster(logoYolu);
                }

                // Vergi parametrləri
                var edvStr = await _konfiqurasiyaManager.GetirAsync(
                    KonfiqurasiyaSabitleri.Acarlar.VergiEdvDerecesi,
                    KonfiqurasiyaSabitleri.VarsayilanDeyerler.VergiEdvDerecesi);
                _view.EdvDerecesi = decimal.TryParse(edvStr, out var edv) ? edv : 18;

                // Printer tənzimləmələri
                _view.QebzPrinteri = await _konfiqurasiyaManager.GetirAsync(
                    KonfiqurasiyaSabitleri.Acarlar.PrinterQebz,
                    KonfiqurasiyaSabitleri.VarsayilanDeyerler.PrinterQebz);

                _view.BarkodPrinteri = await _konfiqurasiyaManager.GetirAsync(
                    KonfiqurasiyaSabitleri.Acarlar.PrinterBarkod,
                    KonfiqurasiyaSabitleri.VarsayilanDeyerler.PrinterBarkod);

                _view.PrinterKagizOlcusu = await _konfiqurasiyaManager.GetirAsync(
                    KonfiqurasiyaSabitleri.Acarlar.PrinterKagizOlcusu,
                    KonfiqurasiyaSabitleri.VarsayilanDeyerler.PrinterKagizOlcusu);

                // Proqram davranışı
                var qebzCapStr = await _konfiqurasiyaManager.GetirAsync(
                    KonfiqurasiyaSabitleri.Acarlar.DavranisQebzCap,
                    KonfiqurasiyaSabitleri.VarsayilanDeyerler.DavranisQebzCap);
                _view.QebzAvtoCap = bool.TryParse(qebzCapStr, out var qebzCap) && qebzCap;

                var avtoYedeklemeStr = await _konfiqurasiyaManager.GetirAsync(
                    KonfiqurasiyaSabitleri.Acarlar.DavranisAvtoYedekleme,
                    KonfiqurasiyaSabitleri.VarsayilanDeyerler.DavranisAvtoYedekleme);
                _view.AvtomatikYedekleme = bool.TryParse(avtoYedeklemeStr, out var avtoYedekleme) && avtoYedekleme;

                _view.YedeklemeSaati = await _konfiqurasiyaManager.GetirAsync(
                    KonfiqurasiyaSabitleri.Acarlar.DavranisYedeklemeSaati,
                    KonfiqurasiyaSabitleri.VarsayilanDeyerler.DavranisYedeklemeSaati);

                // Sistem parametrləri
                _view.SistemDil = await _konfiqurasiyaManager.GetirAsync(
                    KonfiqurasiyaSabitleri.Acarlar.SistemDil,
                    KonfiqurasiyaSabitleri.VarsayilanDeyerler.SistemDil);

                _view.SistemValyuta = await _konfiqurasiyaManager.GetirAsync(
                    KonfiqurasiyaSabitleri.Acarlar.SistemValyuta,
                    KonfiqurasiyaSabitleri.VarsayilanDeyerler.SistemValyuta);

                _view.SistemTarixFormati = await _konfiqurasiyaManager.GetirAsync(
                    KonfiqurasiyaSabitleri.Acarlar.SistemTarixFormati,
                    KonfiqurasiyaSabitleri.VarsayilanDeyerler.SistemTarixFormati);

                _view.SistemReqemFormati = await _konfiqurasiyaManager.GetirAsync(
                    KonfiqurasiyaSabitleri.Acarlar.SistemReqemFormati,
                    KonfiqurasiyaSabitleri.VarsayilanDeyerler.SistemReqemFormati);

                _view.SistemTema = await _konfiqurasiyaManager.GetirAsync(
                    KonfiqurasiyaSabitleri.Acarlar.SistemTema,
                    KonfiqurasiyaSabitleri.VarsayilanDeyerler.SistemTema);

                var sessiyaStr = await _konfiqurasiyaManager.GetirAsync(
                    KonfiqurasiyaSabitleri.Acarlar.SistemSessiyaTimeout,
                    KonfiqurasiyaSabitleri.VarsayilanDeyerler.SistemSessiyaTimeout);
                _view.SistemSessiyaTimeout = int.TryParse(sessiyaStr, out var sessiya) ? sessiya : 30;

                // IsDirty bayrağını sıfırla
                _view.IsDirty = false;
                _view.YaddaSaxlaDuymesiniBiraktir(false);
                _view.LegvEtDuymesiniBiraktir(false);

                Logger.XetaYaz(null, "Konfiqurasiya parametrləri yükləndi");
            }
            catch (Exception ex)
            {
                Logger.XetaYaz(ex, "Konfiqurasiya parametrləri yüklənərkən xəta");
                _view.XetaMesajiGoster($"Konfiqurasiya parametrləri yüklənərkən xəta: {ex.Message}");
            }
        }

        #endregion

        #region Data Saving

        /// <summary>
        /// Konfiqurasiya parametrlərini saxlayır
        /// </summary>
        public async Task SaxlaKonfiqurasiyaParametrleriniAsync()
        {
            try
            {
                // Validasiya
                var validasiyaNeticesi = KonfiqurasiyaValidasiyasi.ButunParametrleriValidet(
                    _view.SirketAdi,
                    _view.SirketUnvani,
                    _view.SirketVoen,
                    _view.SirketTelefon,
                    _view.SirketEmail,
                    _view.SirketVebSayt,
                    _view.EdvDerecesi,
                    _view.QebzPrinteri,
                    _view.BarkodPrinteri,
                    _view.YedeklemeSaati,
                    _view.SistemSessiyaTimeout);

                if (!validasiyaNeticesi.UgurludurMu)
                {
                    _view.ValidasiyaXetalariGoster(validasiyaNeticesi.XetalariGoster());
                    return;
                }

                _view.YuklemeGoster("Konfiqurasiya parametrləri saxlanılır...");

                // Bütün parametrləri bir dictionary-də topla
                var parametrler = new Dictionary<string, string>
                {
                    // Şirkət məlumatları
                    { KonfiqurasiyaSabitleri.Acarlar.SirketAdi, _view.SirketAdi },
                    { KonfiqurasiyaSabitleri.Acarlar.SirketUnvani, _view.SirketUnvani },
                    { KonfiqurasiyaSabitleri.Acarlar.SirketVoen, _view.SirketVoen ?? "" },
                    { KonfiqurasiyaSabitleri.Acarlar.SirketTelefon, _view.SirketTelefon ?? "" },
                    { KonfiqurasiyaSabitleri.Acarlar.SirketEmail, _view.SirketEmail ?? "" },
                    { KonfiqurasiyaSabitleri.Acarlar.SirketVebSayt, _view.SirketVebSayt ?? "" },
                    { KonfiqurasiyaSabitleri.Acarlar.SirketLogo, _view.SirketLogo ?? "" },

                    // Vergi parametrləri
                    { KonfiqurasiyaSabitleri.Acarlar.VergiEdvDerecesi, _view.EdvDerecesi.ToString() },

                    // Printer tənzimləmələri
                    { KonfiqurasiyaSabitleri.Acarlar.PrinterQebz, _view.QebzPrinteri ?? "" },
                    { KonfiqurasiyaSabitleri.Acarlar.PrinterBarkod, _view.BarkodPrinteri ?? "" },
                    { KonfiqurasiyaSabitleri.Acarlar.PrinterKagizOlcusu, _view.PrinterKagizOlcusu },

                    // Proqram davranışı
                    { KonfiqurasiyaSabitleri.Acarlar.DavranisQebzCap, _view.QebzAvtoCap.ToString().ToLower() },
                    { KonfiqurasiyaSabitleri.Acarlar.DavranisAvtoYedekleme, _view.AvtomatikYedekleme.ToString().ToLower() },
                    { KonfiqurasiyaSabitleri.Acarlar.DavranisYedeklemeSaati, _view.YedeklemeSaati ?? "02:00" },

                    // Sistem parametrləri
                    { KonfiqurasiyaSabitleri.Acarlar.SistemDil, _view.SistemDil },
                    { KonfiqurasiyaSabitleri.Acarlar.SistemValyuta, _view.SistemValyuta },
                    { KonfiqurasiyaSabitleri.Acarlar.SistemTarixFormati, _view.SistemTarixFormati },
                    { KonfiqurasiyaSabitleri.Acarlar.SistemReqemFormati, _view.SistemReqemFormati },
                    { KonfiqurasiyaSabitleri.Acarlar.SistemTema, _view.SistemTema },
                    { KonfiqurasiyaSabitleri.Acarlar.SistemSessiyaTimeout, _view.SistemSessiyaTimeout.ToString() }
                };

                // Batch əməliyyatı ilə saxla
                var netice = await _konfiqurasiyaManager.TopluSaxlaAsync(parametrler);

                _view.YuklemeGizle();

                if (!netice.UgurluDur)
                {
                    _view.XetaMesajiGoster(netice.Mesaj);
                    return;
                }

                // IsDirty bayrağını sıfırla
                _view.IsDirty = false;
                _view.YaddaSaxlaDuymesiniBiraktir(false);
                _view.LegvEtDuymesiniBiraktir(false);

                Logger.XetaYaz(null, "Konfiqurasiya parametrləri saxlanıldı");
                _view.UgurMesajiGoster("Konfiqurasiya parametrləri uğurla saxlanıldı.");
            }
            catch (Exception ex)
            {
                _view.YuklemeGizle();
                Logger.XetaYaz(ex, "Konfiqurasiya parametrləri saxlanılarkən xəta");
                _view.XetaMesajiGoster($"Konfiqurasiya parametrləri saxlanılarkən xəta: {ex.Message}");
            }
        }

        #endregion

        #region Printer Operations

        /// <summary>
        /// Qəbz printer seçmə dialoqu göstərir
        /// </summary>
        private void QebzPrinterSec()
        {
            var secilmisPrinter = _view.PrinterSecDialoquGoster(_view.QebzPrinteri);
            if (!string.IsNullOrEmpty(secilmisPrinter))
            {
                _view.QebzPrinteri = secilmisPrinter;
                _view.IsDirty = true;
            }
        }

        /// <summary>
        /// Barkod printer seçmə dialoqu göstərir
        /// </summary>
        private void BarkodPrinterSec()
        {
            var secilmisPrinter = _view.PrinterSecDialoquGoster(_view.BarkodPrinteri);
            if (!string.IsNullOrEmpty(secilmisPrinter))
            {
                _view.BarkodPrinteri = secilmisPrinter;
                _view.IsDirty = true;
            }
        }

        #endregion

        #region Logo Operations

        /// <summary>
        /// Logo seçmə dialoqu göstərir
        /// </summary>
        private void LogoSec()
        {
            var logoYolu = _view.LogoSecDialoquGoster();
            if (!string.IsNullOrEmpty(logoYolu))
            {
                _view.SirketLogo = logoYolu;
                _view.LogoGoster(logoYolu);
                _view.IsDirty = true;
            }
        }

        #endregion
    }
}
