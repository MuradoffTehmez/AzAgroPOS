using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzAgroPOS.Entities.Domain
{
    [Table("AnbarQaliqları")]
    public class AnbarQalik
    {
        [Key]
        public int Id { get; set; }

        public int AnbarId { get; set; }
        [ForeignKey("AnbarId")]
        public virtual Anbar Anbar { get; set; }

        public int MehsulId { get; set; }
        [ForeignKey("MehsulId")]
        public virtual Mehsul Mehsul { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        [Range(0, double.MaxValue, ErrorMessage = "Mövcud miqdar mənfi ola bilməz")]
        public decimal MovcudMiqdar { get; set; } = 0;

        [Column(TypeName = "decimal(18,3)")]
        [Range(0, double.MaxValue, ErrorMessage = "Minimum miqdar mənfi ola bilməz")]
        public decimal MinimumMiqdar { get; set; } = 0;

        [Column(TypeName = "decimal(18,3)")]
        [Range(0, double.MaxValue, ErrorMessage = "Maksimum miqdar mənfi ola bilməz")]
        public decimal MaksimumMiqdar { get; set; } = 0;

        [Column(TypeName = "decimal(18,3)")]
        [Range(0, double.MaxValue, ErrorMessage = "Rezerv olunmuş miqdar mənfi ola bilməz")]
        public decimal RezervMiqdar { get; set; } = 0;

        [Column(TypeName = "decimal(18,4)")]
        [Range(0, double.MaxValue, ErrorMessage = "Ortalama alış qiyməti mənfi ola bilməz")]
        public decimal OrtalamaAlisQiymeti { get; set; } = 0;

        [Column(TypeName = "decimal(18,4)")]
        [Range(0, double.MaxValue, ErrorMessage = "Son alış qiyməti mənfi ola bilməz")]
        public decimal SonAlisQiymeti { get; set; } = 0;

        public DateTime? SonAlısTarixi { get; set; }

        public DateTime? SonSatısTarixi { get; set; }

        [StringLength(50)]
        public string Yer { get; set; } // Raf, sıra, mövqe

        [StringLength(500)]
        public string Qeydler { get; set; }

        public DateTime YaradilmaTarixi { get; set; } = DateTime.Now;
        public DateTime? YenilenmeTarixi { get; set; }

        // Computed Properties
        [NotMapped]
        public decimal ElcatanMiqdar => MovcudMiqdar - RezervMiqdar;

        [NotMapped]
        public bool MinimumSeviyyedenAsagi => MovcudMiqdar <= MinimumMiqdar;

        [NotMapped]
        public bool MaksimumSeviyyedenYuxari => MaksimumMiqdar > 0 && MovcudMiqdar >= MaksimumMiqdar;

        [NotMapped]
        public string SeviyyeDurumu
        {
            get
            {
                if (MinimumSeviyyedenAsagi) return "Aşağı";
                if (MaksimumSeviyyedenYuxari) return "Yuxarı";
                return "Normal";
            }
        }

        [NotMapped]
        public decimal UmumiDeger => MovcudMiqdar * OrtalamaAlisQiymeti;

        [NotMapped]
        public string YerBilgisi => !string.IsNullOrEmpty(Yer) ? Yer : "Təyin edilməyib";

        [NotMapped]
        public int GundenBeriSatilmayib => SonSatısTarixi.HasValue 
            ? (DateTime.Now - SonSatısTarixi.Value).Days 
            : 0;

        [NotMapped]
        public int GundenBeriAlinmayib => SonAlısTarixi.HasValue 
            ? (DateTime.Now - SonAlısTarixi.Value).Days 
            : 0;
    }
}