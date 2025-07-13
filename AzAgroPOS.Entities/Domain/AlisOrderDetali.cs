using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzAgroPOS.Entities.Domain
{
    [Table("AlisOrderDetallari")]
    public class AlisOrderDetali
    {
        [Key]
        public int Id { get; set; }

        public int AlisOrderId { get; set; }
        [ForeignKey("AlisOrderId")]
        public virtual AlisOrder AlisOrder { get; set; }

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
        [Range(0, double.MaxValue, ErrorMessage = "Vahid qiyməti mənfi ola bilməz")]
        public decimal VahidQiymeti { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 100, ErrorMessage = "Endirim faizi 0-100 arasında olmalıdır")]
        public decimal EndirimFaizi { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal EndirimMeblegi { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal UmumiQiymet { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal NetQiymet { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        public decimal TeslimEdilenMiqdar { get; set; } = 0;

        [StringLength(500)]
        public string Qeydler { get; set; }

        public DateTime YaradilmaTarixi { get; set; } = DateTime.Now;
        public DateTime? YenilenmeTarixi { get; set; }

        // Computed Properties
        [NotMapped]
        public decimal QalanMiqdar => Miqdar - TeslimEdilenMiqdar;

        [NotMapped]
        public bool TamTeslimEdilmisdir => TeslimEdilenMiqdar >= Miqdar;

        [NotMapped]
        public decimal TeslimFaizi => Miqdar > 0 ? (TeslimEdilenMiqdar / Miqdar) * 100 : 0;

        [NotMapped]
        public string MehsulDetali => $"{MehsulAdi} ({MehsulSKU})";

        [NotMapped]
        public string MiqdarVeVahid => $"{Miqdar:F2} {VahidAdi}";

        [NotMapped]
        public string TeslimDurumu => TamTeslimEdilmisdir ? "Tam" : QalanMiqdar > 0 ? "Qismən" : "Gözləyir";
    }
}