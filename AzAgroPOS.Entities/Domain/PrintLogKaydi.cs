using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzAgroPOS.Entities.Domain
{
    [Table("PrintLogKayitlari")]
    public class PrintLogKaydi : BaseEntity
    {
        [Required]
        public int PrinterKonfiqurasiId { get; set; }
        [ForeignKey("PrinterKonfiqurasiId")]
        public virtual PrinterKonfiqurasiyasi PrinterKonfiqurasiya { get; set; }

        public int? PrintSablonuId { get; set; }
        [ForeignKey("PrintSablonuId")]
        public virtual PrintSablonu PrintSablonu { get; set; }

        [Required]
        public int IstifadeciId { get; set; }
        [ForeignKey("IstifadeciId")]
        public virtual Istifadeci Istifadeci { get; set; }

        [Required]
        public DateTime PrintTarixi { get; set; } = DateTime.Now;

        [Required]
        [StringLength(20)]
        public string PrintStatusu { get; set; } = PrintStatuslari.Ugurlu;

        [StringLength(1000)]
        public string PrintMezmunu { get; set; } // Print edilən məzmun

        [StringLength(500)]
        public string XetaMesaji { get; set; }

        public int SuretiSayi { get; set; } = 1;

        [Column(TypeName = "decimal(8,3)")]
        public decimal PrintMuddeti { get; set; } // millisaniyə ilə

        [StringLength(100)]
        public string PrintKomandasi { get; set; } // ZPL/EPL komandasının qısa versiyası

        [StringLength(50)]
        public string PrintTipi { get; set; } = PrintTipleri.Etiket;

        public int? MehsulId { get; set; }
        [ForeignKey("MehsulId")]
        public virtual Mehsul Mehsul { get; set; }

        public int? SatisId { get; set; }
        [ForeignKey("SatisId")]
        public virtual Satis Satis { get; set; }

        [StringLength(100)]
        public string ReferansNomre { get; set; } // Hansı əməliyyatla bağlı (SATxx, ANBxx və s.)

        [StringLength(50)]
        public string MenbeModul { get; set; } = PrintMenbeLeri.Manual;

        [Column(TypeName = "decimal(10,2)")]
        public decimal KagizIstifadeOlcusu { get; set; } // İstifadə olunan kağız miqdarı (mm²)

        public bool PrinterOnlineIdi { get; set; } = true;

        [StringLength(100)]
        public string PrinterModeli { get; set; }

        [StringLength(50)]
        public string PrinterSerialNumber { get; set; }

        public int PrintQueuePosition { get; set; } = 1; // Print növbəsindəki mövqe

        public bool YenidenPrint { get; set; } = false; // Təkrar print olunub

        public int? OriginalPrintId { get; set; } // Əgər təkrar printdirsə orijinal print ID

        [StringLength(1000)]
        public string ElaveMelumatlar { get; set; } // JSON formatında əlavə məlumatlar

        // Static Constants
        public static class PrintStatuslari
        {
            public const string Ugurlu = "Uğurlu";
            public const string Ugursuz = "Uğursuz";
            public const string Gozleyir = "Gözləyir";
            public const string Legv = "Ləğv edildi";
            public const string Timeout = "Timeout";
            public const string PrinterOffline = "Printer Offline";
            public const string KagizBitmis = "Kağız Bitmiş";
            public const string PrinterXetasi = "Printer Xətası";
        }

        public static class PrintTipleri
        {
            public const string Etiket = "Etiket";
            public const string Qebz = "Qəbz";
            public const string Hesabat = "Hesabat";
            public const string Test = "Test";
            public const string Barkod = "Barkod";
        }

        public static class PrintMenbeLeri
        {
            public const string Manual = "Manual";
            public const string Satis = "Satış";
            public const string Anbar = "Anbar";
            public const string Mehsul = "Məhsul";
            public const string Sistem = "Sistem";
            public const string API = "API";
            public const string Avtomatik = "Avtomatik";
        }

        // Computed Properties
        [NotMapped]
        public bool PrintUgurlu => PrintStatusu == PrintStatuslari.Ugurlu;

        [NotMapped]
        public string PrintMuddetiText
        {
            get
            {
                if (PrintMuddeti < 1000)
                    return $"{PrintMuddeti:F0} ms";
                else
                    return $"{PrintMuddeti / 1000:F2} s";
            }
        }

        [NotMapped]
        public string StatusRengi
        {
            get
            {
                return PrintStatusu switch
                {
                    PrintStatuslari.Ugurlu => "#27ae60", // Green
                    PrintStatuslari.Ugursuz => "#e74c3c", // Red
                    PrintStatuslari.Gozleyir => "#f39c12", // Orange
                    PrintStatuslari.Legv => "#95a5a6", // Gray
                    PrintStatuslari.Timeout => "#e67e22", // Dark Orange
                    PrintStatuslari.PrinterOffline => "#9b59b6", // Purple
                    PrintStatuslari.KagizBitmis => "#f1c40f", // Yellow
                    PrintStatuslari.PrinterXetasi => "#c0392b", // Dark Red
                    _ => "#34495e" // Dark Gray
                };
            }
        }

        [NotMapped]
        public string PrintAciqlamasi
        {
            get
            {
                var aciqlamalar = new System.Collections.Generic.List<string>();
                
                if (!string.IsNullOrEmpty(MenbeModul))
                    aciqlamalar.Add($"Mənbə: {MenbeModul}");
                
                if (SuretiSayi > 1)
                    aciqlamalar.Add($"{SuretiSayi} nüsxə");
                
                if (YenidenPrint)
                    aciqlamalar.Add("Təkrar print");
                
                if (!string.IsNullOrEmpty(ReferansNomre))
                    aciqlamalar.Add($"Ref: {ReferansNomre}");

                return string.Join(" | ", aciqlamalar);
            }
        }

        [NotMapped]
        public bool YaxinZamandaPrint => (DateTime.Now - PrintTarixi).TotalMinutes <= 30;

        [NotMapped]
        public string ZamanFerqi
        {
            get
            {
                var timeSpan = DateTime.Now - PrintTarixi;
                if (timeSpan.TotalMinutes < 1)
                    return "İndi";
                else if (timeSpan.TotalHours < 1)
                    return $"{(int)timeSpan.TotalMinutes} dəq əvvəl";
                else if (timeSpan.TotalDays < 1)
                    return $"{(int)timeSpan.TotalHours} saat əvvəl";
                else if (timeSpan.TotalDays < 7)
                    return $"{(int)timeSpan.TotalDays} gün əvvəl";
                else
                    return PrintTarixi.ToString("dd.MM.yyyy");
            }
        }

        [NotMapped]
        public decimal KagizIstifadeOlcusuCM2 => KagizIstifadeOlcusu / 100; // cm² ilə

        [NotMapped]
        public bool PrinterBilgileriMevcut => !string.IsNullOrEmpty(PrinterModeli) || !string.IsNullOrEmpty(PrinterSerialNumber);

        [NotMapped]
        public string PrinterBilgileri
        {
            get
            {
                var bilgiler = new System.Collections.Generic.List<string>();
                
                if (!string.IsNullOrEmpty(PrinterModeli))
                    bilgiler.Add(PrinterModeli);
                
                if (!string.IsNullOrEmpty(PrinterSerialNumber))
                    bilgiler.Add($"S/N: {PrinterSerialNumber}");
                
                return string.Join(" | ", bilgiler);
            }
        }

        [NotMapped]
        public bool XetaVarMi => !string.IsNullOrEmpty(XetaMesaji) || !PrintUgurlu;

        [NotMapped]
        public string XetaQisaAciqlamasi
        {
            get
            {
                if (string.IsNullOrEmpty(XetaMesaji))
                    return PrintStatusu == PrintStatuslari.Ugurlu ? "" : PrintStatusu;
                
                return XetaMesaji.Length > 50 ? XetaMesaji.Substring(0, 47) + "..." : XetaMesaji;
            }
        }
    }
}