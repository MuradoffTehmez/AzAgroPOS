using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzAgroPOS.Entities.Domain
{
    public class SatisOdemesi
    {
        public int Id { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal OdemeMeblegi { get; set; } // Payment amount
        
        [Required]
        [StringLength(20)]
        public string OdemeNovu { get; set; } // Payment type: Nağd, Kart, Bank Transfer
        
        [StringLength(100)]
        public string OdemeDetali { get; set; } // Payment details
        
        [StringLength(50)]
        public string ReferansNomresi { get; set; } // Reference number for electronic payments
        
        public DateTime OdemeTarixi { get; set; } = DateTime.Now;
        
        [StringLength(20)]
        public string Status { get; set; } = "Tamamlandı"; // Completed, Failed, Pending
        
        [StringLength(500)]
        public string Qeydler { get; set; }
        
        // Foreign Key
        public int SatisId { get; set; }
        [ForeignKey("SatisId")]
        public virtual Satis Satis { get; set; }
        
        // Audit fields
        public DateTime YaradilmaTarixi { get; set; } = DateTime.Now;
        public DateTime? YenilenmeTarixi { get; set; }
    }
}