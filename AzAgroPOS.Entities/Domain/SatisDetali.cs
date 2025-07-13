using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzAgroPOS.Entities.Domain
{
    [Table("SatisDetallari")]
    public class SatisDetali
    {
        [Key]
        public int Id { get; set; }
        
        // Foreign Keys
        public int SatisId { get; set; }
        [ForeignKey("SatisId")]
        public virtual Satis Satis { get; set; }
        
        public int MehsulId { get; set; }
        [ForeignKey("MehsulId")]
        public virtual Mehsul Mehsul { get; set; }
        
        // Product details at time of sale (to preserve historical data)
        [Required]
        [StringLength(200)]
        public string MehsulAdi { get; set; }
        
        [StringLength(50)]
        public string MehsulSKU { get; set; }
        
        [StringLength(50)]
        public string MehsulBarkod { get; set; }
        
        // Quantity and pricing
        [Column(TypeName = "decimal(18,3)")]
        public decimal Miqdar { get; set; }
        
        [Required]
        [StringLength(20)]
        public string VahidAdi { get; set; } // Unit name at time of sale
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal VahidQiymeti { get; set; } // Unit price at time of sale
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal EndirimFaizi { get; set; } = 0; // Discount percentage
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal EndirimMeblegi { get; set; } = 0; // Discount amount
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal UmumiQiymet { get; set; } // Total price before discount
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal NetQiymet { get; set; } // Net price after discount
        
        [StringLength(200)]
        public string Qeydler { get; set; }
        
        public DateTime YaradilmaTarixi { get; set; } = DateTime.Now;
        public DateTime? YenilenmeTarixi { get; set; }
        
        // Computed Properties
        [NotMapped]
        public decimal EndirimliQiymet => UmumiQiymet - EndirimMeblegi;
        
        [NotMapped]
        public string MehsulDetali => $"{MehsulAdi} ({MehsulSKU})";
        
        [NotMapped]
        public string MiqdarVeVahid => $"{Miqdar} {VahidAdi}";
    }
}