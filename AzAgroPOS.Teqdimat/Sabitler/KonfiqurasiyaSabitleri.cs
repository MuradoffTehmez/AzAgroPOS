using System.Text.RegularExpressions;

namespace AzAgroPOS.Teqdimat.Sabitler
{
    /// <summary>
    /// Konfiqurasiya parametrləri üçün sabit dəyərlər
    /// </summary>
    public static class KonfiqurasiyaSabitleri
    {
        /// <summary>
        /// Konfiqurasiya açarları
        /// </summary>
        public static class Acarlar
        {
            // Şirkət məlumatları
            public const string SirketAdi = "Şirkət.Adı";
            public const string SirketUnvani = "Şirkət.Ünvanı";
            public const string SirketVoen = "Şirkət.VÖEN";
            public const string SirketTelefon = "Şirkət.Telefon";
            public const string SirketEmail = "Şirkət.Email";
            public const string SirketVebSayt = "Şirkət.VebSayt";
            public const string SirketLogo = "Şirkət.Logo";

            // Vergi parametrləri
            public const string VergiEdvDerecesi = "Vergi.ƏDV.Dərəcəsi";

            // Printer tənzimləmələri
            public const string PrinterQebz = "Printer.Qəbz";
            public const string PrinterBarkod = "Printer.Barkod";
            public const string PrinterKagizOlcusu = "Printer.KağızÖlçüsü";

            // Proqram davranışı
            public const string DavranisQebzCap = "Davranış.SatışdanSonraQəbziÇapEt";
            public const string DavranisAvtoYedekleme = "Davranış.AvtomatikYedekləmə";
            public const string DavranisYedeklemeSaati = "Davranış.YedekləməSaatı";

            // Sistem parametrləri
            public const string SistemDil = "Sistem.Dil";
            public const string SistemValyuta = "Sistem.Valyuta";
            public const string SistemTarixFormati = "Sistem.TarixFormatı";
            public const string SistemReqemFormati = "Sistem.RəqəmFormatı";
            public const string SistemTema = "Sistem.Tema";
            public const string SistemSessiyaTimeout = "Sistem.SessiyaTimeout";
        }

        /// <summary>
        /// Konfiqurasiya qrupları
        /// </summary>
        public static class Qruplar
        {
            public const string SirketMelumatlari = "Şirkət Məlumatları";
            public const string VergiParametrleri = "Vergi Parametrləri";
            public const string PrinterTenzimleri = "Printer Tənzimləmələri";
            public const string ProqramDavranisi = "Proqram Davranışı";
            public const string SistemParametrleri = "Sistem Parametrləri";
        }

        /// <summary>
        /// Varsayılan dəyərlər
        /// </summary>
        public static class VarsayilanDeyerler
        {
            // Şirkət
            public const string SirketAdi = "Şirkət Adı";
            public const string SirketUnvani = "";
            public const string SirketVoen = "";
            public const string SirketTelefon = "";
            public const string SirketEmail = "";
            public const string SirketVebSayt = "";
            public const string SirketLogo = "";

            // Vergi
            public const string VergiEdvDerecesi = "18";

            // Printer
            public const string PrinterQebz = "";
            public const string PrinterBarkod = "";
            public const string PrinterKagizOlcusu = "A4";

            // Davranış
            public const string DavranisQebzCap = "true";
            public const string DavranisAvtoYedekleme = "false";
            public const string DavranisYedeklemeSaati = "02:00";

            // Sistem
            public const string SistemDil = "az-AZ";
            public const string SistemValyuta = "AZN";
            public const string SistemTarixFormati = "dd.MM.yyyy";
            public const string SistemReqemFormati = "N2";
            public const string SistemTema = "Light";
            public const string SistemSessiyaTimeout = "30";
        }

        /// <summary>
        /// Konfiqurasiya təsvirləri
        /// </summary>
        public static class Tesvirler
        {
            // Şirkət
            public const string SirketAdi = "Şirkətin rəsmi adı";
            public const string SirketUnvani = "Şirkətin qeydiyyat ünvanı";
            public const string SirketVoen = "Vergi ödəyicisinin eyniləşdirmə nömrəsi (10 rəqəm)";
            public const string SirketTelefon = "Əlaqə telefon nömrəsi";
            public const string SirketEmail = "Email ünvanı";
            public const string SirketVebSayt = "Veb sayt ünvanı";
            public const string SirketLogo = "Şirkət loqosu (şəkil yolu)";

            // Vergi
            public const string VergiEdvDerecesi = "Əlavə dəyər vergisi dərəcəsi (%)";

            // Printer
            public const string PrinterQebz = "Qəbz çap edən printer";
            public const string PrinterBarkod = "Barkod çap edən printer";
            public const string PrinterKagizOlcusu = "Printer kağız ölçüsü";

            // Davranış
            public const string DavranisQebzCap = "Satışdan sonra qəbzi avtomatik çap et";
            public const string DavranisAvtoYedekleme = "Avtomatik yedekləmə aktivdir";
            public const string DavranisYedeklemeSaati = "Gündəlik yedekləmə saatı (HH:mm)";

            // Sistem
            public const string SistemDil = "Proqram interfeys dili";
            public const string SistemValyuta = "Əsas valyuta";
            public const string SistemTarixFormati = "Tarix göstərmə formatı";
            public const string SistemReqemFormati = "Rəqəm göstərmə formatı";
            public const string SistemTema = "İnterfeys teması (Light/Dark)";
            public const string SistemSessiyaTimeout = "Sessiya bitmə vaxtı (dəqiqə)";
        }

        /// <summary>
        /// Validasiya qaydaları
        /// </summary>
        public static class Validasiya
        {
            // VÖEN 10 rəqəm olmalıdır
            public static readonly Regex VoenPattern = new Regex(@"^\d{10}$", RegexOptions.Compiled);

            // Email validasiyası
            public static readonly Regex EmailPattern = new Regex(
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);

            // Telefon (müxtəlif formatlar)
            public static readonly Regex TelefonPattern = new Regex(
                @"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$",
                RegexOptions.Compiled);

            // URL validasiyası
            public static readonly Regex UrlPattern = new Regex(
                @"^(http|https)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$",
                RegexOptions.Compiled | RegexOptions.IgnoreCase);

            // ƏDV dərəcəsi
            public const decimal EdvMinimum = 0;
            public const decimal EdvMaksimum = 100;

            // Sessiya timeout
            public const int SessiyaTimeoutMinimum = 5;
            public const int SessiyaTimeoutMaksimum = 1440; // 24 saat

            // Saat formatı (HH:mm)
            public static readonly Regex SaatPattern = new Regex(
                @"^([01]?[0-9]|2[0-3]):[0-5][0-9]$",
                RegexOptions.Compiled);
        }

        /// <summary>
        /// Xəta mesajları
        /// </summary>
        public static class XetaMesajlari
        {
            public const string VoenFormatXetasi = "VÖEN 10 rəqəmdən ibarət olmalıdır";
            public const string EmailFormatXetasi = "Email ünvanı düzgün formatda deyil";
            public const string TelefonFormatXetasi = "Telefon nömrəsi düzgün formatda deyil";
            public const string UrlFormatXetasi = "URL düzgün formatda deyil";
            public const string EdvDerecesiXetasi = "ƏDV dərəcəsi 0 ilə 100 arasında olmalıdır";
            public const string SessiyaTimeoutXetasi = "Sessiya timeout 5 ilə 1440 dəqiqə arasında olmalıdır";
            public const string SaatFormatXetasi = "Saat formatı HH:mm şəklində olmalıdır (məs: 14:30)";
            public const string TelebeXetasi = "Bu sahə mütləq doldurulmalıdır";
            public const string PrinterTapilmadiXetasi = "Seçilmiş printer sistemdə tapılmadı";
        }

        /// <summary>
        /// Kağız ölçüləri
        /// </summary>
        public static class KagizOlculeri
        {
            public const string A4 = "A4";
            public const string A5 = "A5";
            public const string Letter = "Letter";
            public const string Thermal80mm = "Thermal 80mm";
            public const string Thermal58mm = "Thermal 58mm";
        }

        /// <summary>
        /// Dillər
        /// </summary>
        public static class Diller
        {
            public const string Azerbaycan = "az-AZ";
            public const string English = "en-US";
            public const string Russian = "ru-RU";
            public const string Turkish = "tr-TR";
        }

        /// <summary>
        /// Valyutalar
        /// </summary>
        public static class Valyutalar
        {
            public const string AZN = "AZN";
            public const string USD = "USD";
            public const string EUR = "EUR";
            public const string TRY = "TRY";
            public const string RUB = "RUB";
        }

        /// <summary>
        /// Temalar
        /// </summary>
        public static class Temalar
        {
            public const string Light = "Light";
            public const string Dark = "Dark";
        }
    }
}
