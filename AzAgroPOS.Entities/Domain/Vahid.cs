using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzAgroPOS.Entities.Domain
{
    [Table("Vahidler")]
    public class Vahid
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Vahid adı mütləqdir")]
        [StringLength(50, ErrorMessage = "Vahid adı 50 simvoldan çox ola bilməz")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Qısa ad mütləqdir")]
        [StringLength(10, ErrorMessage = "Qısa ad 10 simvoldan çox ola bilməz")]
        public string QisaAd { get; set; }

        [StringLength(200, ErrorMessage = "Təsvir 200 simvoldan çox ola bilməz")]
        public string Tesvir { get; set; }

        [Required]
        [StringLength(20)]
        public string Tipi { get; set; } = "Ümumi"; // Ümumi, Uzunluq, Çəki, Həcm, Saya

        [Column(TypeName = "decimal(18,6)")]
        [Range(0.000001, double.MaxValue, ErrorMessage = "Çevirmə əmsalı sıfırdan böyük olmalıdır")]
        public decimal CevirmeEmsali { get; set; } = 1; // Ana vahidə çevirmə əmsalı

        public int? AnaVahidId { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Aktiv"; // Aktiv, Deaktiv

        public DateTime YaradilmaTarixi { get; set; } = DateTime.Now;

        public DateTime? YenilenmeTarixi { get; set; }

        [StringLength(500)]
        public string Qeydler { get; set; }

        // Navigation Properties
        [ForeignKey("AnaVahidId")]
        public virtual Vahid AnaVahid { get; set; }

        public virtual ICollection<Vahid> AltVahidler { get; set; }

        public virtual ICollection<Mehsul> Mehsullar { get; set; }

        public Vahid()
        {
            AltVahidler = new HashSet<Vahid>();
            Mehsullar = new HashSet<Mehsul>();
        }

        // Computed Properties
        [NotMapped]
        public string TamAd => $"{Ad} ({QisaAd})";

        [NotMapped]
        public bool AnaVahiddir => AnaVahidId == null;

        [NotMapped]
        public string FormatliFaizi
        {
            get
            {
                if (AnaVahid != null && CevirmeEmsali != 1)
                    return $"1 {QisaAd} = {CevirmeEmsali} {AnaVahid.QisaAd}";
                return QisaAd;
            }
        }
    }
}