using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzAgroPOS.Entities.Domain
{
    [Table("NovbeKayitlari")]
    public class NovbeKaydi
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IsciId { get; set; }
        [ForeignKey("IsciId")]
        public virtual Isci Isci { get; set; }

        [Required]
        public DateTime GirisTarixi { get; set; }

        public DateTime? CixisTarixi { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal IslemeSaati { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal MolaVaxti { get; set; }

        [StringLength(500)]
        public string Qeydler { get; set; }

        [Required]
        public DateTime YaradilmaTarixi { get; set; } = DateTime.Now;

        // Computed Properties
        [NotMapped]
        public bool AktivNovbedir => !CixisTarixi.HasValue;

        [NotMapped]
        public TimeSpan ToplamIsSaati => CixisTarixi.HasValue ? 
            CixisTarixi.Value - GirisTarixi : 
            DateTime.Now - GirisTarixi;

        [NotMapped]
        public decimal SaatlikHesab => (decimal)ToplamIsSaati.TotalHours;

        [NotMapped]
        public string NovbeStatusu => AktivNovbedir ? "Davam edir" : "Bitib";
    }
}