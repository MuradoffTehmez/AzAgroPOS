using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzAgroPOS.Entities.Domain
{
    [Table("AnbarHereketleri")]
    public class AnbarHereketi
    {
        [Key]
        public int Id { get; set; }

        public int AnbarId { get; set; }
        [ForeignKey("AnbarId")]
        public virtual Anbar Anbar { get; set; }

        public int MehsulId { get; set; }
        [ForeignKey("MehsulId")]
        public virtual Mehsul Mehsul { get; set; }

        [Required]
        [StringLength(20)]
        public string HereketTipi { get; set; } // Giris, Cixis, Transfer-Giris, Transfer-Cixis, Duzelish

        [Required]
        [StringLength(50)]
        public string SenedNomresi { get; set; }

        [StringLength(20)]
        public string SenedTipi { get; set; } // AlisSeined, Satis, Transfer, InventarizasyaDuzelishi

        public int? SenedId { get; set; } // Reference to related document

        public DateTime HereketTarixi { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(18,3)")]
        public decimal Miqdar { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        public decimal OncekiQalik { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        public decimal YeniQalik { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        [Range(0, double.MaxValue, ErrorMessage = "Vahid qiyməti mənfi ola bilməz")]
        public decimal VahidQiymeti { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal UmumiMebleg { get; set; } = 0;

        [StringLength(100)]
        public string Terefkarsi { get; set; } // Supplier, Customer, Transfer target warehouse

        [StringLength(1000)]
        public string Aciklama { get; set; }

        public int IstifadeciId { get; set; }
        [ForeignKey("IstifadeciId")]
        public virtual Istifadeci Istifadeci { get; set; }

        public DateTime YaradilmaTarixi { get; set; } = DateTime.Now;

        // Computed Properties
        [NotMapped]
        public string HereketTipiAzerbaycan
        {
            get
            {
                return HereketTipi switch
                {
                    "Giris" => "Giriş",
                    "Cixis" => "Çıxış",
                    "Transfer-Giris" => "Transfer Giriş",
                    "Transfer-Cixis" => "Transfer Çıxış",
                    "Duzelish" => "Düzəliş",
                    _ => HereketTipi
                };
            }
        }

        [NotMapped]
        public bool GirisHereketi => HereketTipi == "Giris" || HereketTipi == "Transfer-Giris";

        [NotMapped]
        public bool CixisHereketi => HereketTipi == "Cixis" || HereketTipi == "Transfer-Cixis";

        [NotMapped]
        public string MiqdarFormatli => $"{(GirisHereketi ? "+" : "-")}{Miqdar:F3}";

        [NotMapped]
        public string QalikDeyisikliyi => $"{OncekiQalik:F3} → {YeniQalik:F3}";

        [NotMapped]
        public string TerefkarsiBilgisi => !string.IsNullOrEmpty(Terefkarsi) ? Terefkarsi : "Məlumat yoxdur";
    }
}