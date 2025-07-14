using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzAgroPOS.Entities.Domain
{
    [Table("Mehsullar")]
    public class Mehsul
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Məhsul adı mütləqdir")]
        [StringLength(100, ErrorMessage = "Məhsul adı 100 simvoldan çox ola bilməz")]
        public string Ad { get; set; }

        [StringLength(500, ErrorMessage = "Təsvir 500 simvoldan çox ola bilməz")]
        public string Tesvir { get; set; }

        [Required(ErrorMessage = "Barkod mütləqdir")]
        [StringLength(50, ErrorMessage = "Barkod 50 simvoldan çox ola bilməz")]
        public string Barkod { get; set; }

        [Required(ErrorMessage = "SKU mütləqdir")]
        [StringLength(50, ErrorMessage = "SKU 50 simvoldan çox ola bilməz")]
        public string SKU { get; set; }

        [Required(ErrorMessage = "Kateqoriya seçilməlidir")]
        public int KateqoriyaId { get; set; }

        [Required(ErrorMessage = "Ölçü vahidi seçilməlidir")]
        public int VahidId { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        [Range(0, double.MaxValue, ErrorMessage = "Alış qiyməti mənfi ola bilməz")]
        public decimal AlisQiymeti { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        [Range(0, double.MaxValue, ErrorMessage = "Satış qiyməti mənfi ola bilməz")]
        public decimal SatisQiymeti { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        [Range(0, double.MaxValue, ErrorMessage = "Mövcud miqdar mənfi ola bilməz")]
        public decimal MovcudMiqdar { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        [Range(0, double.MaxValue, ErrorMessage = "Minimum miqdar mənfi ola bilməz")]
        public decimal MinimumMiqdar { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Aktiv"; // Aktiv, Deaktiv

        public DateTime YaradilmaTarixi { get; set; } = DateTime.Now;

        public DateTime? YenilenmeTarixi { get; set; }

        [StringLength(500)]
        public string Qeydler { get; set; }

        [StringLength(100)]
        public string Model { get; set; }

        // Navigation Properties
        [ForeignKey("KateqoriyaId")]
        public virtual MehsulKateqoriyasi Kateqoriya { get; set; }

        [ForeignKey("VahidId")]
        public virtual Vahid Vahid { get; set; }

        // Computed Properties
        [NotMapped]
        public decimal Menfeet => SatisQiymeti - AlisQiymeti;

        [NotMapped]
        public decimal MenfeeetFaizi => AlisQiymeti > 0 ? ((SatisQiymeti - AlisQiymeti) / AlisQiymeti) * 100 : 0;

        [NotMapped]
        public bool StoktanKenarda => MovcudMiqdar <= MinimumMiqdar;

        [NotMapped]
        public string TamAd => $"{Ad} ({SKU})";
    }
}