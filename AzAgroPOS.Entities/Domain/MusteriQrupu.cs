using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AzAgroPOS.Entities.Constants;

namespace AzAgroPOS.Entities.Domain
{
    [Table("MusteriQruplari")]
    public class MusteriQrupu
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Qrup adı mütləqdir")]
        [StringLength(100, ErrorMessage = "Qrup adı maksimum 100 simbol ola bilər")]
        public string Ad { get; set; }

        [StringLength(500, ErrorMessage = "Açıqlama maksimum 500 simbol ola bilər")]
        public string Aciklama { get; set; }

        [Required(ErrorMessage = "Endirim faizi mütləqdir")]
        [Column(TypeName = "decimal(5,2)")]
        [Range(0, 100, ErrorMessage = "Endirim faizi 0-100 arasında olmalıdır")]
        public decimal EndirimbFaizi { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Kredit limiti mənfi ola bilməz")]
        public decimal KreditLimiti { get; set; } = 0;

        [Required(ErrorMessage = "Status mütləqdir")]
        [StringLength(20, ErrorMessage = "Status maksimum 20 simbol ola bilər")]
        public string Status { get; set; } = SystemConstants.Status.Active;

        [StringLength(50)]
        public string Renk { get; set; } = "#3498db"; // Default blue color

        public DateTime YaradilmaTarixi { get; set; } = DateTime.Now;
        public DateTime? YenilenmeTarixi { get; set; }

        public int? YaradanIstifadeciId { get; set; }
        [ForeignKey("YaradanIstifadeciId")]
        public virtual Istifadeci YaradanIstifadeci { get; set; }

        // Navigation Properties
        public virtual ICollection<Musteri> Musteriler { get; set; } = new List<Musteri>();

        // Computed Properties
        [NotMapped]
        public int MusteriSayi => Musteriler?.Count ?? 0;

        [NotMapped]
        public bool SilineABilir => MusteriSayi == 0;

        [NotMapped]
        public string EndirimbFaiziFormatli => EndirimbFaizi > 0 ? $"%{EndirimbFaizi:F1}" : "Yoxdur";

        [NotMapped]
        public string KreditLimitiFormatli => KreditLimiti > 0 ? KreditLimiti.ToString("C") : "Məhdudiyyətsiz";
    }
}