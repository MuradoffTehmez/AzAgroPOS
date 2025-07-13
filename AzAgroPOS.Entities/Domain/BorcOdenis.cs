using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzAgroPOS.Entities.Domain
{
    [Table("BorcOdenisleri")]
    public class BorcOdenis
    {
        [Key]
        public int Id { get; set; }

        public int MusteriBorcId { get; set; }
        [ForeignKey("MusteriBorcId")]
        public virtual MusteriBorc MusteriBorc { get; set; }

        [Required]
        [StringLength(50)]
        public string OdenisNomresi { get; set; }

        public DateTime OdenisTarixi { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Ödəniş məbləği mənfi ola bilməz")]
        public decimal OdenisMeblegi { get; set; }

        [Required]
        [StringLength(20)]
        public string OdenisTipi { get; set; } // Nəğd, Kart, Köçürmə, Çek

        [StringLength(100)]
        public string OdenisDetali { get; set; } // Kart nömrəsi, çek nömrəsi və s.

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Komissiya məbləği mənfi ola bilməz")]
        public decimal KomissiyaMeblegi { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal FaizOdenisi { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal EsasBorcOdenisi { get; set; }

        [StringLength(1000)]
        public string Aciklama { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = "Təsdiqlənmiş"; // Gözləyir, Təsdiqlənmiş, Ləğv Edilmiş

        public int QebulEdenIstifadeciId { get; set; }
        [ForeignKey("QebulEdenIstifadeciId")]
        public virtual Istifadeci QebulEdenIstifadeci { get; set; }

        public DateTime YaradilmaTarixi { get; set; } = DateTime.Now;
        public DateTime? YenilenmeTarixi { get; set; }

        // Computed Properties
        [NotMapped]
        public string OdenisTipiAzerbaycan
        {
            get
            {
                switch (OdenisTipi)
                {
                    case "Nəğd": return "Nəğd";
                    case "Kart": return "Kart";
                    case "Köçürmə": return "Bank Köçürməsi";
                    case "Çek": return "Çek";
                    default: return OdenisTipi;
                }
            }
        }

        [NotMapped]
        public string StatusAzerbaycan
        {
            get
            {
                switch (Status)
                {
                    case "Gözləyir": return "Gözləyir";
                    case "Təsdiqlənmiş": return "Təsdiqlənmiş";
                    case "Ləğv Edilmiş": return "Ləğv Edilmiş";
                    default: return Status;
                }
            }
        }

        [NotMapped]
        public decimal XalisSafiOdenis => OdenisMeblegi - KomissiyaMeblegi;

        [NotMapped]
        public string OdenisFormatli => $"{OdenisMeblegi:C} ({OdenisTipiAzerbaycan})";

        [NotMapped]
        public bool Legvedileibilir => Status == "Gözləyir" || Status == "Təsdiqlənmiş";

        [NotMapped]
        public string OdenisDetaliFormatli => !string.IsNullOrEmpty(OdenisDetali) ? OdenisDetali : "Əlavə məlumat yoxdur";
    }
}