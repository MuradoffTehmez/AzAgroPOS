using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzAgroPOS.Entities.Domain
{
    [Table("AlisSenedDetallari")]
    public class AlisSenedDetali
    {
        [Key]
        public int Id { get; set; }

        public int AlisSenedId { get; set; }
        [ForeignKey("AlisSenedId")]
        public virtual AlisSeined AlisSeined { get; set; }

        public int MehsulId { get; set; }
        [ForeignKey("MehsulId")]
        public virtual Mehsul Mehsul { get; set; }

        [Required]
        [StringLength(200)]
        public string MehsulAdi { get; set; }

        [StringLength(50)]
        public string MehsulSKU { get; set; }

        [StringLength(50)]
        public string MehsulBarkod { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        [Range(0.001, double.MaxValue, ErrorMessage = "Miqdar sıfırdan böyük olmalıdır")]
        public decimal Miqdar { get; set; }

        [Required]
        [StringLength(20)]
        public string VahidAdi { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        [Range(0, double.MaxValue, ErrorMessage = "Alış qiyməti mənfi ola bilməz")]
        public decimal AlisQiymeti { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 100, ErrorMessage = "Endirim faizi 0-100 arasında olmalıdır")]
        public decimal EndirimFaizi { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal EndirimMeblegi { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal UmumiQiymet { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal NetQiymet { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal SonSatisQiymeti { get; set; } = 0; // To update product selling price

        public DateTime SonİstifadeTarixi { get; set; } = DateTime.Now.AddYears(1);

        [StringLength(50)]
        public string Lot { get; set; }

        [StringLength(50)]
        public string SeriyaNomresi { get; set; }

        [StringLength(500)]
        public string Qeydler { get; set; }

        public DateTime YaradilmaTarixi { get; set; } = DateTime.Now;
        public DateTime? YenilenmeTarixi { get; set; }

        // Computed Properties
        [NotMapped]
        public string MehsulDetali => $"{MehsulAdi} ({MehsulSKU})";

        [NotMapped]
        public string MiqdarVeVahid => $"{Miqdar:F3} {VahidAdi}";

        [NotMapped]
        public decimal VahidEndirimliQiymet => AlisQiymeti - (AlisQiymeti * EndirimFaizi / 100);

        [NotMapped]
        public string QiymetBilgisi => EndirimFaizi > 0 
            ? $"{AlisQiymeti:F4} ₼ (-%{EndirimFaizi:F1}) = {VahidEndirimliQiymet:F4} ₼"
            : $"{AlisQiymeti:F4} ₼";

        [NotMapped]
        public bool SonİstifadeTarixiYaxin => (SonİstifadeTarixi - DateTime.Now).Days <= 30;

        [NotMapped]
        public bool SonİstifadeTarixiKecmis => SonİstifadeTarixi <= DateTime.Now;

        [NotMapped]
        public string LotVeSeriya => !string.IsNullOrEmpty(Lot) || !string.IsNullOrEmpty(SeriyaNomresi)
            ? $"Lot: {Lot} / S/N: {SeriyaNomresi}"
            : "Məlumat yoxdur";
    }
}