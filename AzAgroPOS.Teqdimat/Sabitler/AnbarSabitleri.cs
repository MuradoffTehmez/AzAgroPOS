using System.Text.RegularExpressions;

namespace AzAgroPOS.Teqdimat.Sabitler
{
    /// <summary>
    /// Anbar (Warehouse) formu üçün sabitlər və konfiqurasiya dəyərləri
    /// </summary>
    public static class AnbarSabitleri
    {
        #region Əməliyyat Növləri

        /// <summary>
        /// Stok əməliyyat növləri
        /// </summary>
        public static class EmeliyyatNovu
        {
            public const string StokArtirma = "ARTIRMA";
            public const string StokAzaltma = "AZALTMA";
            public const string StokKocurme = "KOCURME";
            public const string StokDuzelis = "DUZELIS";
            public const string StokSayim = "SAYIM";
        }

        #endregion

        #region Validasiya

        /// <summary>
        /// Validasiya qaydaları
        /// </summary>
        public static class Validasiya
        {
            /// <summary>
            /// Minimum əlavə edilə biləcək say
            /// </summary>
            public const decimal MinimumSay = 0.01m;

            /// <summary>
            /// Maksimum əlavə edilə biləcək say
            /// </summary>
            public const decimal MaksimumSay = 999999.99m;

            /// <summary>
            /// Minimum qeyd uzunluğu
            /// </summary>
            public const int MinimumQeydUzunlugu = 3;

            /// <summary>
            /// Maksimum qeyd uzunluğu
            /// </summary>
            public const int MaksimumQeydUzunlugu = 500;

            /// <summary>
            /// Rəqəm pattern (müsbət onluq rəqəmlər)
            /// </summary>
            public static readonly Regex ReqemPattern = new(@"^\d+(\.\d{1,2})?$", RegexOptions.Compiled);

            /// <summary>
            /// Barkod/Stok kodu pattern (rəqəm və hərflər)
            /// </summary>
            public static readonly Regex BarkodPattern = new(@"^[A-Z0-9\-]+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }

        #endregion

        #region Xəta Mesajları

        /// <summary>
        /// Xəta mesajları
        /// </summary>
        public static class XetaMesajlari
        {
            // Axtarış xətaları
            public const string AxtarisMetniTelebelidir = "Barkod və ya Stok Kodu daxil edin";
            public const string MehsulTapilmadi = "Məhsul tapılmadı";
            public const string BarkodFormatXetasi = "Barkod/Stok kodu yalnız hərf, rəqəm və tire (-) simvollarından ibarət ola bilər";

            // Say xətaları
            public const string SayTelebelidir = "Say daxil edin";
            public const string SayReqemOlmalidir = "Say rəqəm olmalıdır";
            public const string SayMusbetOlmalidir = "Say müsbət olmalıdır";
            public const string SayCoxKicikdir = "Say minimum {0} olmalıdır";
            public const string SayCoxBoyukdur = "Say maksimum {0} olmalıdır";
            public const string SayFormatXetasi = "Say düzgün formatda deyil (məs: 10 və ya 10.50)";

            // Azaltma xətaları
            public const string MovcudStokKifayetDeyil = "Mövcud stok kifayət deyil. Mövcud: {0}, Azaltmaq istədiyiniz: {1}";
            public const string StokMenfiOlaBilmez = "Stok mənfi ola bilməz";

            // Qeyd xətaları
            public const string QeydTelebelidir = "Qeyd/Səbəb daxil edin";
            public const string QeydCoxQisadir = "Qeyd ən azı {0} simvoldan ibarət olmalıdır";
            public const string QeydCoxUzundur = "Qeyd maksimum {0} simvoldan ibarət ola bilər";

            // Ümumi xətalar
            public const string MehsulSecilmeyib = "Əvvəlcə məhsul axtarın və seçin";
            public const string EmeliyyatUgursuz = "Əməliyyat uğursuz oldu";
            public const string MelumatYuklenmeXetasi = "Məlumat yüklənərkən xəta baş verdi";
        }

        #endregion

        #region Uğur Mesajları

        /// <summary>
        /// Uğur mesajları
        /// </summary>
        public static class UgurMesajlari
        {
            public const string StokArtirilib = "Stok uğurla artırıldı. Yeni stok: {0}";
            public const string StokAzaldilib = "Stok uğurla azaldıldı. Yeni stok: {0}";
            public const string StokKocurulub = "Stok uğurla köçürüldü";
            public const string StokDuzelisEdildi = "Stok düzəliş edildi. Yeni stok: {0}";
            public const string EmeliyyatUgurlu = "Əməliyyat uğurla tamamlandı";
        }

        #endregion

        #region Məlumat Mesajları

        /// <summary>
        /// Məlumat mesajları
        /// </summary>
        public static class MelumatMesajlari
        {
            public const string MehsulTapildi = "Məhsul tapıldı";
            public const string MovcudStok = "Mövcud stok: {0} {1}";
            public const string YeniStok = "Yeni stok: {0} {1}";
            public const string MinimumStokXeberdarligi = "DİQQƏT: Məhsul minimum stok səviyyəsindədir!";
            public const string StokBitdi = "DİQQƏT: Məhsulun stoku bitib!";
        }

        #endregion

        #region Xəbərdarlıq Mesajları

        /// <summary>
        /// Xəbərdarlıq mesajları
        /// </summary>
        public static class XeberdarlikMesajlari
        {
            public const string StokSifirOlacaq = "Bu əməliyyatdan sonra stok 0 olacaq. Davam etmək istəyirsiniz?";
            public const string BoyukMiqdarAzaltma = "Çox böyük miqdar azaltmaq istəyirsiniz ({0}). Davam etmək istəyirsiniz?";
            public const string FormTemizlenecek = "Form təmizlənəcək. Davam etmək istəyirsiniz?";
            public const string EmeliyyatTesdiq = "Əməliyyatı təsdiq edirsiniz?";
        }

        #endregion

        #region Təsdiq Soruları

        /// <summary>
        /// Təsdiq soruları
        /// </summary>
        public static class TesdiqSorulari
        {
            public const string StokArtirmaTesdiqi = "{0} ədəd əlavə etmək istədiyinizə əminsiniz?";
            public const string StokAzaltmaTesdiqi = "{0} ədəd azaltmaq istədiyinizə əminsiniz?";
            public const string StokDuzelisTesdiqi = "Stoku {0} olaraq düzəltmək istədiyinizə əminsiniz?";
        }

        #endregion

        #region UI Mətnləri

        /// <summary>
        /// İstifadəçi interfeysi mətnləri
        /// </summary>
        public static class UIMetinler
        {
            // Form başlıqları
            public const string FormBasligi = "Anbar İdarəetməsi";
            public const string MehsulMelumatBasligi = "Məhsul Məlumatı";
            public const string EmeliyyatMelumatBasligi = "Əməliyyat Məlumatı";
            public const string TarixceBasligi = "Son Əməliyyatlar";

            // Label-lar
            public const string AxtarisLabel = "Barkod/Stok Kodu:";
            public const string SayLabel = "Say:";
            public const string QeydLabel = "Qeyd/Səbəb:";
            public const string MehsulAdiLabel = "Məhsul:";
            public const string MovcudStokLabel = "Mövcud Stok:";
            public const string EmeliyyatNovuLabel = "Əməliyyat:";

            // Düymələr
            public const string AxtarDuymesi = "Axtar";
            public const string TesdiqDuymesi = "Təsdiq Et";
            public const string LegvEtDuymesi = "Ləğv Et";
            public const string TemizleDuymesi = "Təmizlə";
            public const string StokArtirDuymesi = "Stok Artır";
            public const string StokAzaltDuymesi = "Stok Azalt";
            public const string TarixceGosterDuymesi = "Tarixçə";

            // Hints
            public const string AxtarisHint = "Məhsulun barkod və ya stok kodunu daxil edin...";
            public const string SayHint = "Əlavə ediləcək və ya azaldılacaq sayı daxil edin...";
            public const string QeydHint = "Əməliyyat üçün qeyd və ya səbəb (məs: inventarizasiya, satış iadəsi...)";

            // Status mesajları
            public const string Hazirdir = "Hazırdır";
            public const string YukleniR = "Yüklənir...";
            public const string Saxlanir = "Saxlanılır...";
            public const string Axtarilir = "Axtarılır...";
        }

        #endregion

        #region Varsayılan Dəyərlər

        /// <summary>
        /// Varsayılan dəyərlər
        /// </summary>
        public static class VarsayilanDeyerler
        {
            public const string VarsayilanOlcuVahidi = "ədəd";
            public const int TarixceSiraSayi = 10;
            public const decimal VarsayilanSay = 1m;
            public const string VarsayilanQeyd = "";
        }

        #endregion

        #region Klaviatura Qısayolları

        /// <summary>
        /// Klaviatura qısayolları
        /// </summary>
        public static class KlaviaturaQisayollari
        {
            public const string AxtarQisayol = "F3";
            public const string TesdiqQisayol = "F9";
            public const string LegvEtQisayol = "Esc";
            public const string TemizleQisayol = "F5";
            public const string TarixceQisayol = "F12";
        }

        #endregion

        #region İcazələr

        /// <summary>
        /// İcazə adları
        /// </summary>
        public static class Icazeler
        {
            public const string AnbarOxumaq = "Anbar.Oxumaq";
            public const string AnbarStokArtirma = "Anbar.StokArtirma";
            public const string AnbarStokAzaltma = "Anbar.StokAzaltma";
            public const string AnbarStokDuzelis = "Anbar.StokDuzelis";
            public const string AnbarTarixce = "Anbar.Tarixce";
            public const string AnbarHesabat = "Anbar.Hesabat";
        }

        #endregion

        #region DataGrid Sütunları

        /// <summary>
        /// DataGrid sütun adları
        /// </summary>
        public static class DataGridSutunlari
        {
            public const string Tarix = "Tarix";
            public const string Istifadeci = "İstifadəçi";
            public const string EmeliyyatNovu = "Əməliyyat";
            public const string KohneStok = "Köhnə Stok";
            public const string DeyisiklikMiqdari = "Dəyişiklik";
            public const string YeniStok = "Yeni Stok";
            public const string Qeyd = "Qeyd";
        }

        #endregion
    }
}
