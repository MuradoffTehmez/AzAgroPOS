using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzAgroPOS.Entities.Domain
{
    [Table("SatisHesabatlari")]
    public class SatisHesabati
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime TarixBaslangic { get; set; }

        [Required]
        public DateTime TarixBitis { get; set; }

        [Required]
        [StringLength(50)]
        public string HesabatTipi { get; set; } // Günlük, Həftəlik, Aylıq, Məhsul Üzrə, Müştəri Üzrə

        [Column(TypeName = "decimal(18,2)")]
        public decimal ToplamSatis { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ToplamMenfeet { get; set; }

        public int SatisSayi { get; set; }

        public int MusteriSayi { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal OrtalamaSatis { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal EnYuksekSatis { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal EnAsagiSatis { get; set; }

        [StringLength(100)]
        public string EnCoxSatilanMehsul { get; set; }

        [StringLength(100)]
        public string EnAzSatilanMehsul { get; set; }

        [StringLength(100)]
        public string EnAktivMusteri { get; set; }

        [StringLength(2000)]
        public string EkMalumatlar { get; set; }

        [Required]
        public DateTime YaradilmaTarixi { get; set; } = DateTime.Now;

        public int? YaradanIstifadeciId { get; set; }
        [ForeignKey("YaradanIstifadeciId")]
        public virtual Istifadeci YaradanIstifadeci { get; set; }

        // Computed Properties
        [NotMapped]
        public decimal MenfeelFaizi => ToplamSatis > 0 ? (ToplamMenfeet / ToplamSatis) * 100 : 0;

        [NotMapped]
        public decimal GunlukOrtalama => 
            TarixBitis.Subtract(TarixBaslangic).Days > 0 ? 
            ToplamSatis / TarixBitis.Subtract(TarixBaslangic).Days : ToplamSatis;

        [NotMapped]
        public string HesabatOzeti => 
            $"{HesabatTipi} hesabatı: {SatisSayi} satış, {ToplamSatis:C} cəmi";

        [NotMapped]
        public string PerformansReytingi => MenfeelFaizi switch
        {
            > 30 => "Əla",
            > 20 => "Yaxşı",
            > 10 => "Orta",
            _ => "Zəif"
        };
    }
}