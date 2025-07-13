using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzAgroPOS.Entities.Domain
{
    [Table("AnbarTransferDetallari")]
    public class AnbarTransferDetali
    {
        [Key]
        public int Id { get; set; }

        public int AnbarTransferId { get; set; }
        [ForeignKey("AnbarTransferId")]
        public virtual AnbarTransfer AnbarTransfer { get; set; }

        public int MehsulId { get; set; }
        [ForeignKey("MehsulId")]
        public virtual Mehsul Mehsul { get; set; }

        [Required]
        [StringLength(200)]
        public string MehsulAdi { get; set; }

        [StringLength(50)]
        public string MehsulSKU { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        [Range(0.001, double.MaxValue, ErrorMessage = "Miqdar sıfırdan böyük olmalıdır")]
        public decimal Miqdar { get; set; }

        [Column(TypeName = "decimal(18,3)")]
        public decimal QebulEdilenMiqdar { get; set; } = 0;

        [Required]
        [StringLength(20)]
        public string VahidAdi { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal VahidQiymeti { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal UmumiMebleg { get; set; } = 0;

        [StringLength(500)]
        public string Qeydler { get; set; }

        public DateTime YaradilmaTarixi { get; set; } = DateTime.Now;
        public DateTime? YenilenmeTarixi { get; set; }

        // Computed Properties
        [NotMapped]
        public decimal QalanMiqdar => Miqdar - QebulEdilenMiqdar;

        [NotMapped]
        public bool TamQebulEdilmisdir => QebulEdilenMiqdar >= Miqdar;

        [NotMapped]
        public decimal QebulFaizi => Miqdar > 0 ? (QebulEdilenMiqdar / Miqdar) * 100 : 0;

        [NotMapped]
        public string MehsulDetali => $"{MehsulAdi} ({MehsulSKU})";

        [NotMapped]
        public string MiqdarVeVahid => $"{Miqdar:F3} {VahidAdi}";

        [NotMapped]
        public string QebulDurumu => TamQebulEdilmisdir ? "Tam" : QalanMiqdar > 0 ? "Qismən" : "Gözləyir";

        [NotMapped]
        public string QebulMelumati => $"{QebulEdilenMiqdar:F3} / {Miqdar:F3} ({QebulFaizi:F1}%)";
    }
}