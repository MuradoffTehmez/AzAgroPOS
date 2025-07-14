using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzAgroPOS.Entities.Domain
{
    [Table("IsciPerformans")]
    public class IsciPerformans
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IsciId { get; set; }
        [ForeignKey("IsciId")]
        public virtual Isci Isci { get; set; }

        [Required]
        public DateTime TarixAraligi { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SatisSayi { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal SatisMeblegi { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal MusteriMemnuniyeti { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal IslemeSaati { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal GecikmeSaati { get; set; }

        [StringLength(1000)]
        public string Qeydler { get; set; }

        [Required]
        public DateTime YaradilmaTarixi { get; set; } = DateTime.Now;

        // Computed Properties
        [NotMapped]
        public decimal SaatlikSatis => IslemeSaati > 0 ? SatisMeblegi / IslemeSaati : 0;

        [NotMapped]
        public string PerformansReytingi => SaatlikSatis switch
        {
            > 1000 => "Əla",
            > 500 => "Yaxşı",
            > 200 => "Orta",
            _ => "Zəif"
        };

        [NotMapped]
        public decimal VerimlilikyIndeksi => (SatisSayi * MusteriMemnuniyeti) / (IslemeSaati + GecikmeSaati);
    }
}