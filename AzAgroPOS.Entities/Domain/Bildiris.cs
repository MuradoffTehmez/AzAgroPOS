using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzAgroPOS.Entities.Domain
{
    [Table("Bildirisler")]
    public class Bildiris : BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string Basliq { get; set; }

        [Required]
        [StringLength(1000)]
        public string Mesaj { get; set; }

        [Required]
        [StringLength(50)]
        public string BildirisNovu { get; set; } = BildirisNovleri.Melumat;

        [Required]
        [StringLength(20)]
        public string Prioritet { get; set; } = BildirisPrioritetleri.Orta;

        [Required]
        public int MenbeModulId { get; set; } // Hansı moduldan gəlir

        [StringLength(100)]
        public string MenbeModulAdi { get; set; } // Modul adı

        public int? HedefIstifadeciId { get; set; } // Null olarsa bütün istifadəçilər üçün
        [ForeignKey("HedefIstifadeciId")]
        public virtual Istifadeci HedefIstifadeci { get; set; }

        public int? GonderenIstifadeciId { get; set; }
        [ForeignKey("GonderenIstifadeciId")]
        public virtual Istifadeci GonderenIstifadeci { get; set; }

        [Required]
        public DateTime GonderimeTarixi { get; set; } = DateTime.Now;

        public DateTime? OxunduTarixi { get; set; }

        public bool Oxundu { get; set; } = false;

        public bool Silindi { get; set; } = false;

        [StringLength(500)]
        public string Emeliyyat { get; set; } // Klik edildikdə açılacaq form

        [StringLength(200)]
        public string EmeliyyatParametrleri { get; set; } // JSON formatında parametrlər

        public DateTime? SonGecerlilikTarixi { get; set; }

        [StringLength(100)]
        public string Ikon { get; set; } // Bildiriş ikonu

        [StringLength(50)]
        public string Renk { get; set; } = "#3498db"; // Bildiriş rəngi

        public bool OtomatikOxunsun { get; set; } = false; // Müəyyən müddətdən sonra otomatik oxunmuş say

        public int OtomatikOxunmaGunu { get; set; } = 7; // Neçə gündən sonra

        [StringLength(1000)]
        public string ElaveMelumat { get; set; } // JSON formatında əlavə məlumatlar

        // Static Constants
        public static class BildirisNovleri
        {
            public const string Melumat = "Məlumat";
            public const string Xeberdarliq = "Xəbərdarlıq";
            public const string Xeta = "Xəta";
            public const string Ugur = "Uğur";
            public const string Sistem = "Sistem";
            public const string Emr = "Əmr";
            public const string Sosial = "Sosial";
        }

        public static class BildirisPrioritetleri
        {
            public const string Asagi = "Aşağı";
            public const string Orta = "Orta";
            public const string Yuksek = "Yüksək";
            public const string Kritik = "Kritik";
        }

        public static class BildirisModulleri
        {
            public const string Satis = "Satış";
            public const string Anbar = "Anbar";
            public const string Novbe = "Növbə";
            public const string Backup = "Backup";
            public const string Sistem = "Sistem";
            public const string Istifadeci = "İstifadəçi";
            public const string Hesabat = "Hesabat";
            public const string Tamir = "Təmir";
            public const string Borc = "Borc";
            public const string Gider = "Gidər";
        }

        // Computed Properties
        [NotMapped]
        public bool Gecerli => SonGecerlilikTarixi == null || SonGecerlilikTarixi >= DateTime.Now;

        [NotMapped]
        public bool Yeni => !Oxundu && (DateTime.Now - GonderimeTarixi).TotalHours <= 24;

        [NotMapped]
        public string ZamanFerqi
        {
            get
            {
                var timeSpan = DateTime.Now - GonderimeTarixi;
                if (timeSpan.TotalMinutes < 1)
                    return "İndi";
                else if (timeSpan.TotalHours < 1)
                    return $"{(int)timeSpan.TotalMinutes} dəq əvvəl";
                else if (timeSpan.TotalDays < 1)
                    return $"{(int)timeSpan.TotalHours} saat əvvəl";
                else if (timeSpan.TotalDays < 7)
                    return $"{(int)timeSpan.TotalDays} gün əvvəl";
                else
                    return GonderimeTarixi.ToString("dd.MM.yyyy");
            }
        }

        [NotMapped]
        public string PrioritetRengi
        {
            get
            {
                return Prioritet switch
                {
                    BildirisPrioritetleri.Asagi => "#95a5a6", // Gray
                    BildirisPrioritetleri.Orta => "#3498db", // Blue
                    BildirisPrioritetleri.Yuksek => "#f39c12", // Orange
                    BildirisPrioritetleri.Kritik => "#e74c3c", // Red
                    _ => "#34495e" // Dark Gray
                };
            }
        }

        [NotMapped]
        public string BildirisRengi
        {
            get
            {
                return BildirisNovu switch
                {
                    BildirisNovleri.Melumat => "#3498db", // Blue
                    BildirisNovleri.Xeberdarliq => "#f39c12", // Orange
                    BildirisNovleri.Xeta => "#e74c3c", // Red
                    BildirisNovleri.Ugur => "#27ae60", // Green
                    BildirisNovleri.Sistem => "#9b59b6", // Purple
                    BildirisNovleri.Emr => "#34495e", // Dark Gray
                    BildirisNovleri.Sosial => "#1abc9c", // Turquoise
                    _ => Renk
                };
            }
        }

        [NotMapped]
        public string BildirisIkonu
        {
            get
            {
                if (!string.IsNullOrEmpty(Ikon))
                    return Ikon;

                return BildirisNovu switch
                {
                    BildirisNovleri.Melumat => "ℹ️",
                    BildirisNovleri.Xeberdarliq => "⚠️",
                    BildirisNovleri.Xeta => "❌",
                    BildirisNovleri.Ugur => "✅",
                    BildirisNovleri.Sistem => "⚙️",
                    BildirisNovleri.Emr => "📋",
                    BildirisNovleri.Sosial => "👥",
                    _ => "📢"
                };
            }
        }

        [NotMapped]
        public bool OtomatikOxunmaVaxti => OtomatikOxunsun && (DateTime.Now - GonderimeTarixi).TotalDays >= OtomatikOxunmaGunu;

        [NotMapped]
        public string QisaBasliq => Basliq.Length > 50 ? Basliq.Substring(0, 47) + "..." : Basliq;

        [NotMapped]
        public string QisaMesaj => Mesaj.Length > 100 ? Mesaj.Substring(0, 97) + "..." : Mesaj;
    }
}