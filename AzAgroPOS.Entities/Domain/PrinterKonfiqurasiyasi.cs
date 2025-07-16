using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzAgroPOS.Entities.Domain
{
    [Table("PrinterKonfiqurasiyas")]
    public class PrinterKonfiqurasiyasi : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string PrinterAdi { get; set; }

        [Required]
        [StringLength(50)]
        public string PrinterTipi { get; set; } = PrinterTipleri.ZPL;

        [StringLength(200)]
        public string PrinterIP { get; set; }

        public int PrinterPort { get; set; } = 9100;

        [StringLength(100)]
        public string PrinterUSB { get; set; } // USB Port məsələn: USB001

        [StringLength(100)]
        public string PrinterSerial { get; set; } // Serial Port məsələn: COM1

        [Required]
        [StringLength(20)]
        public string BaglantiTipi { get; set; } = BaglantiTipleri.IP;

        public int PrinterGenisligi { get; set; } = 203; // DPI

        public int PrinterUzunlugu { get; set; } = 203; // DPI

        [Column(TypeName = "decimal(5,2)")]
        public decimal KagizGenisligi { get; set; } = 58; // mm

        [Column(TypeName = "decimal(5,2)")]
        public decimal KagizUzunlugu { get; set; } = 40; // mm

        [StringLength(50)]
        public string FontAdi { get; set; } = "Arial";

        public int FontOlcusu { get; set; } = 8;

        public bool Aktiv { get; set; } = true;

        public bool StandartPrinter { get; set; } = false;

        [StringLength(20)]
        public string KagizOrientasiyasi { get; set; } = OrientasiyaTipleri.Portrait;

        public int PrintSureti { get; set; } = 1;

        [Column(TypeName = "decimal(3,1)")]
        public decimal PrintKeyfiyyeti { get; set; } = 8; // 1-15 arası

        [StringLength(50)]
        public string BarkodTipi { get; set; } = BarkodTipleri.Code128;

        public int BarkodUzunlugu { get; set; } = 40; // mm

        public int BarkodGenisligi { get; set; } = 2; // pixel

        public bool BarkodYazisiGoster { get; set; } = true;

        [StringLength(20)]
        public string TextAliglama { get; set; } = TextAliglamaTipleri.Left;

        [StringLength(500)]
        public string BaslikSablonu { get; set; } // JSON formatında şablon

        [StringLength(500)]
        public string AltBilgiSablonu { get; set; } // JSON formatında şablon

        public bool LogoGoster { get; set; } = false;

        [StringLength(200)]
        public string LogoYolu { get; set; }

        public int LogoGenisligi { get; set; } = 50; // pixel

        public int LogoUzunlugu { get; set; } = 50; // pixel

        [StringLength(20)]
        public string LogoPozisiyasi { get; set; } = PozisiyaTipleri.TopLeft;

        [StringLength(1000)]
        public string ElaveTenzimlemeler { get; set; } // JSON formatında əlavə ayarlar

        public DateTime SonTestTarixi { get; set; }

        public bool SonTestUgurlu { get; set; } = false;

        [StringLength(500)]
        public string SonTestNetice { get; set; }

        // Static Constants
        public static class PrinterTipleri
        {
            public const string ZPL = "ZPL"; // Zebra Programming Language
            public const string EPL = "EPL"; // Eltron Programming Language
            public const string ESCPOS = "ESC/POS"; // Epson Standard Code for POS printers
            public const string CPCL = "CPCL"; // Comtec Printer Control Language
        }

        public static class BaglantiTipleri
        {
            public const string IP = "IP";
            public const string USB = "USB";
            public const string Serial = "Serial";
            public const string Bluetooth = "Bluetooth";
        }

        public static class OrientasiyaTipleri
        {
            public const string Portrait = "Portrait";
            public const string Landscape = "Landscape";
        }

        public static class BarkodTipleri
        {
            public const string Code128 = "Code128";
            public const string Code39 = "Code39";
            public const string EAN13 = "EAN13";
            public const string EAN8 = "EAN8";
            public const string QRCode = "QRCode";
            public const string DataMatrix = "DataMatrix";
            public const string PDF417 = "PDF417";
        }

        public static class TextAliglamaTipleri
        {
            public const string Left = "Left";
            public const string Center = "Center";
            public const string Right = "Right";
        }

        public static class PozisiyaTipleri
        {
            public const string TopLeft = "TopLeft";
            public const string TopCenter = "TopCenter";
            public const string TopRight = "TopRight";
            public const string MiddleLeft = "MiddleLeft";
            public const string MiddleCenter = "MiddleCenter";
            public const string MiddleRight = "MiddleRight";
            public const string BottomLeft = "BottomLeft";
            public const string BottomCenter = "BottomCenter";
            public const string BottomRight = "BottomRight";
        }

        // Computed Properties
        [NotMapped]
        public string BaglantiAdresi
        {
            get
            {
                return BaglantiTipi switch
                {
                    BaglantiTipleri.IP => $"{PrinterIP}:{PrinterPort}",
                    BaglantiTipleri.USB => PrinterUSB,
                    BaglantiTipleri.Serial => PrinterSerial,
                    BaglantiTipleri.Bluetooth => "Bluetooth Device",
                    _ => "Bilinməyən"
                };
            }
        }

        [NotMapped]
        public string KagizOlculeri => $"{KagizGenisligi}x{KagizUzunlugu} mm";

        [NotMapped]
        public string PrinterCozunurlugu => $"{PrinterGenisligi}x{PrinterUzunlugu} DPI";

        [NotMapped]
        public bool BaglantiAktiv => Aktiv && (DateTime.Now - SonTestTarixi).TotalHours <= 24 && SonTestUgurlu;

        [NotMapped]
        public string Statusu
        {
            get
            {
                if (!Aktiv) return "Deaktiv";
                if (!SonTestUgurlu) return "Bağlantı problemi";
                if (BaglantiAktiv) return "Aktiv";
                return "Test edilməyib";
            }
        }

        [NotMapped]
        public string StatusRengi
        {
            get
            {
                return Statusu switch
                {
                    "Aktiv" => "#27ae60", // Green
                    "Bağlantı problemi" => "#e74c3c", // Red
                    "Deaktiv" => "#95a5a6", // Gray
                    "Test edilməyib" => "#f39c12", // Orange
                    _ => "#34495e" // Dark Gray
                };
            }
        }

        [NotMapped]
        public bool TestVaxtiCatib => (DateTime.Now - SonTestTarixi).TotalHours > 24;

        [NotMapped]
        public string PrinterAyarlariOzeti
        {
            get
            {
                return $"{PrinterTipi} | {BaglantiTipi} | {KagizOlculeri} | {BarkodTipi}";
            }
        }

        [NotMapped]
        public bool LogoMevcut => LogoGoster && !string.IsNullOrEmpty(LogoYolu) && System.IO.File.Exists(LogoYolu);
    }
}