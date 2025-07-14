using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzAgroPOS.Entities.Domain
{
    [Table("Satislar")]
    public class Satis
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string SatisNomresi { get; set; } // Unique sales number
        
        public DateTime SatisTarixi { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal UmumiMebleg { get; set; } // Total amount
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal EndirimMeblegi { get; set; } // Discount amount
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal VergiMeblegi { get; set; } // Tax amount
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal NetMebleg { get; set; } // Net amount after discounts and taxes
        
        [Required]
        [StringLength(20)]
        public string OdemeNovu { get; set; } // Payment type: Nağd, Kart, Nisyə
        
        [StringLength(50)]
        public string OdemeDetali { get; set; } // Payment details (card number last 4 digits, etc.)
        
        [StringLength(20)]
        public string Status { get; set; } = "Tamamlandı"; // Completed, Cancelled, Refunded
        
        [StringLength(500)]
        public string Qeydler { get; set; }
        
        // Customer information (optional - for future customer management)
        [StringLength(100)]
        public string MusteriAdi { get; set; }
        [StringLength(20)]
        public string MusteriTelefonu { get; set; }
        
        // Foreign Keys
        public int KassirId { get; set; } // Cashier user ID
        [ForeignKey("KassirId")]
        public virtual Istifadeci Kassir { get; set; }
        
        public int? MusteriId { get; set; } // Customer ID (optional)
        [ForeignKey("MusteriId")]
        public virtual Musteri Musteri { get; set; }
        
        // Navigation Properties
        public virtual ICollection<SatisDetali> SatisDetallari { get; set; }
        public virtual ICollection<SatisOdemesi> SatisOdemeleri { get; set; }
        
        public DateTime YaradilmaTarixi { get; set; } = DateTime.Now;
        public DateTime? YenilenmeTarixi { get; set; }
        
        // Computed Properties
        [NotMapped]
        public string TamMusteriAdi => !string.IsNullOrEmpty(MusteriAdi) ? MusteriAdi : "Adsız Müştəri";
        
        [NotMapped]
        public string SatisNomresiFormatli => $"SAT-{SatisNomresi}";
    }
}