using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AzAgroPOS.Entities.Domain
{
    [Table("AlisOrderleri")]
    public class AlisOrder
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string OrderNomresi { get; set; }

        public DateTime OrderTarixi { get; set; } = DateTime.Now;

        public DateTime? TeslimTarixi { get; set; }

        [Required]
        public int TedarukcuId { get; set; }
        [ForeignKey("TedarukcuId")]
        public virtual Tedarukcu Tedarukcu { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UmumiMebleg { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal EndirimMeblegi { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal VergiMeblegi { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal NetMebleg { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Yeni"; // Yeni, Təsdiqlənmiş, Sifarişdə, Teslim Edilmiş, İptal Edilmiş

        [StringLength(20)]
        public string OdemeSerti { get; set; } = "Nağd";

        [StringLength(1000)]
        public string Qeydler { get; set; }

        public int YaradanIstifadeciId { get; set; }
        [ForeignKey("YaradanIstifadeciId")]
        public virtual Istifadeci YaradanIstifadeci { get; set; }

        public int? TesdiqleyenIstifadeciId { get; set; }
        [ForeignKey("TesdiqleyenIstifadeciId")]
        public virtual Istifadeci TesdiqleyenIstifadeci { get; set; }

        public DateTime? TesdiqTarixi { get; set; }

        public DateTime YaradilmaTarixi { get; set; } = DateTime.Now;
        public DateTime? YenilenmeTarixi { get; set; }

        // Navigation Properties
        public virtual ICollection<AlisOrderDetali> OrderDetallari { get; set; }

        // Computed Properties
        [NotMapped]
        public string OrderNomresiFormatli => $"ORD-{OrderNomresi}";

        [NotMapped]
        public int MehsulSayi => OrderDetallari?.Count ?? 0;

        [NotMapped]
        public decimal UmumiMiqdar => OrderDetallari?.Sum(d => d.Miqdar) ?? 0;

        [NotMapped]
        public bool TesdiqlenmeGozleyir => Status == "Yeni";

        [NotMapped]
        public bool TeslimGunuKecmisdir => TeslimTarixi.HasValue && TeslimTarixi.Value.Date < DateTime.Today;

        [NotMapped]
        public string StatusAzerbaycan
        {
            get
            {
                switch (Status)
                {
                    case "Yeni": return "Yeni";
                    case "Təsdiqlənmiş": return "Təsdiqlənmiş";
                    case "Sifarişdə": return "Sifarişdə";
                    case "Teslim Edilmiş": return "Teslim Edilmiş";
                    case "İptal Edilmiş": return "İptal Edilmiş";
                    default: return Status;
                }
            }
        }
    }
}