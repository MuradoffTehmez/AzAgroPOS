using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzAgroPOS.Entities.Domain
{
    [Table("PrintSablonlari")]
    public class PrintSablonu : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string SablonAdi { get; set; }

        [Required]
        [StringLength(50)]
        public string SablonTipi { get; set; } = SablonTipleri.Mehsul;

        [StringLength(500)]
        public string Aciqlama { get; set; }

        [Required]
        [StringLength(20)]
        public string PrinterTipi { get; set; } = PrinterKonfiqurasiyasi.PrinterTipleri.ZPL;

        [Column(TypeName = "decimal(5,2)")]
        public decimal SablonGenisligi { get; set; } = 58; // mm

        [Column(TypeName = "decimal(5,2)")]
        public decimal SablonUzunlugu { get; set; } = 40; // mm

        [Required]
        [StringLength(10000)]
        public string SablonKodu { get; set; } // ZPL/EPL code

        [StringLength(5000)]
        public string SablonParametrleri { get; set; } // JSON formatında parametrlər

        public bool Aktiv { get; set; } = true;

        public bool StandartSablon { get; set; } = false;

        [StringLength(50)]
        public string BarkodTipi { get; set; } = PrinterKonfiqurasiyasi.BarkodTipleri.Code128;

        public int BarkodX { get; set; } = 10; // X pozisiyası (pixel)

        public int BarkodY { get; set; } = 10; // Y pozisiyası (pixel)

        public int BarkodGenisligi { get; set; } = 2; // Çubuq genişliyi

        public int BarkodUzunlugu { get; set; } = 30; // Yüksəklik (pixel)

        public bool BarkodYazisiGoster { get; set; } = true;

        [StringLength(50)]
        public string BarkodFontu { get; set; } = "Arial";

        public int BarkodFontOlcusu { get; set; } = 8;

        // Məhsul adı ayarları
        public bool MehsulAdiGoster { get; set; } = true;

        public int MehsulAdiX { get; set; } = 10;

        public int MehsulAdiY { get; set; } = 50;

        [StringLength(50)]
        public string MehsulAdiFontu { get; set; } = "Arial";

        public int MehsulAdiFontOlcusu { get; set; } = 10;

        public int MehsulAdiMaksimumUzunlugu { get; set; } = 25;

        // Qiymət ayarları
        public bool QiymetGoster { get; set; } = true;

        public int QiymetX { get; set; } = 10;

        public int QiymetY { get; set; } = 70;

        [StringLength(50)]
        public string QiymetFontu { get; set; } = "Arial";

        public int QiymetFontOlcusu { get; set; } = 12;

        [StringLength(20)]
        public string QiymetFormati { get; set; } = "₼ #,##0.00";

        // Tarix ayarları
        public bool TarixGoster { get; set; } = true;

        public int TarixX { get; set; } = 10;

        public int TarixY { get; set; } = 90;

        [StringLength(50)]
        public string TarixFontu { get; set; } = "Arial";

        public int TarixFontOlcusu { get; set; } = 8;

        [StringLength(20)]
        public string TarixFormati { get; set; } = "dd.MM.yyyy";

        // Şirkət məlumatları
        public bool SirketAdiGoster { get; set; } = false;

        public int SirketAdiX { get; set; } = 10;

        public int SirketAdiY { get; set; } = 5;

        [StringLength(50)]
        public string SirketAdiFontu { get; set; } = "Arial";

        public int SirketAdiFontOlcusu { get; set; } = 8;

        // Logo ayarları
        public bool LogoGoster { get; set; } = false;

        public int LogoX { get; set; } = 100;

        public int LogoY { get; set; } = 5;

        public int LogoGenisligi { get; set; } = 40;

        public int LogoUzunlugu { get; set; } = 40;

        // Xüsusi mətn ayarları
        public bool XususiMetinGoster { get; set; } = false;

        public int XususiMetinX { get; set; } = 10;

        public int XususiMetinY { get; set; } = 110;

        [StringLength(50)]
        public string XususiMetinFontu { get; set; } = "Arial";

        public int XususiMetinFontOlcusu { get; set; } = 8;

        [StringLength(100)]
        public string XususiMetinMesaj { get; set; }

        public DateTime SonIstifadeTarixi { get; set; }

        public int IstifadeSayisi { get; set; } = 0;

        // Static Constants
        public static class SablonTipleri
        {
            public const string Mehsul = "Məhsul Etiketi";
            public const string Qiymet = "Qiymət Etiketi";
            public const string Anbar = "Anbar Etiketi";
            public const string Gonderim = "Göndərim Etiketi";
            public const string Xususi = "Xüsusi Etiket";
        }

        public static class SablonParametrleriAcarlari
        {
            public const string MehsulAdi = "{MEHSUL_ADI}";
            public const string Barkod = "{BARKOD}";
            public const string Qiymet = "{QIYMET}";
            public const string Tarix = "{TARIX}";
            public const string SirketAdi = "{SIRKET_ADI}";
            public const string SKU = "{SKU}";
            public const string Kateqoriya = "{KATEQORIYA}";
            public const string Vahid = "{VAHID}";
            public const string Miqdar = "{MIQDAR}";
            public const string XususiMetin = "{XUSUSI_METIN}";
        }

        // Computed Properties
        [NotMapped]
        public string SablonOlculeri => $"{SablonGenisligi}x{SablonUzunlugu} mm";

        [NotMapped]
        public bool SonIstifadeYaxin => (DateTime.Now - SonIstifadeTarixi).TotalDays <= 7;

        [NotMapped]
        public string IstifadeStatistikasi
        {
            get
            {
                if (IstifadeSayisi == 0) return "Heç istifadə edilməyib";
                if (SonIstifadeYaxin) return $"{IstifadeSayisi} dəfə istifadə - Son: {SonIstifadeTarixi:dd.MM.yyyy}";
                return $"{IstifadeSayisi} dəfə istifadə - Köhnə istifadə";
            }
        }

        [NotMapped]
        public string SablonOzeti
        {
            get
            {
                var ozet = $"{SablonTipi} | {PrinterTipi} | {SablonOlculeri}";
                if (BarkodYazisiGoster) ozet += " | Barkod";
                if (QiymetGoster) ozet += " | Qiymət";
                if (LogoGoster) ozet += " | Logo";
                return ozet;
            }
        }

        [NotMapped]
        public bool SablonTamamdir
        {
            get
            {
                if (string.IsNullOrEmpty(SablonKodu)) return false;
                if (!MehsulAdiGoster && !QiymetGoster && !BarkodYazisiGoster) return false;
                return true;
            }
        }

        [NotMapped]
        public int ElementSayisi
        {
            get
            {
                int count = 0;
                if (BarkodYazisiGoster) count++;
                if (MehsulAdiGoster) count++;
                if (QiymetGoster) count++;
                if (TarixGoster) count++;
                if (SirketAdiGoster) count++;
                if (LogoGoster) count++;
                if (XususiMetinGoster) count++;
                return count;
            }
        }

        public string ParametrleriEvedEt(string mehsulAdi, string barkod, decimal qiymet, DateTime tarix, 
            string sirketAdi = "", string sku = "", string kateqoriya = "", string vahid = "", 
            decimal miqdar = 0, string xususiMetin = "")
        {
            var sablon = SablonKodu;
            
            sablon = sablon.Replace(SablonParametrleriAcarlari.MehsulAdi, mehsulAdi ?? "");
            sablon = sablon.Replace(SablonParametrleriAcarlari.Barkod, barkod ?? "");
            sablon = sablon.Replace(SablonParametrleriAcarlari.Qiymet, qiymet.ToString(QiymetFormati));
            sablon = sablon.Replace(SablonParametrleriAcarlari.Tarix, tarix.ToString(TarixFormati));
            sablon = sablon.Replace(SablonParametrleriAcarlari.SirketAdi, sirketAdi ?? "");
            sablon = sablon.Replace(SablonParametrleriAcarlari.SKU, sku ?? "");
            sablon = sablon.Replace(SablonParametrleriAcarlari.Kateqoriya, kateqoriya ?? "");
            sablon = sablon.Replace(SablonParametrleriAcarlari.Vahid, vahid ?? "");
            sablon = sablon.Replace(SablonParametrleriAcarlari.Miqdar, miqdar.ToString("N2"));
            sablon = sablon.Replace(SablonParametrleriAcarlari.XususiMetin, xususiMetin ?? XususiMetinMesaj ?? "");

            return sablon;
        }

        public void IstifadeSayisiniArtir()
        {
            IstifadeSayisi++;
            SonIstifadeTarixi = DateTime.Now;
        }
    }
}