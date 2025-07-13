using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzAgroPOS.Entities.Domain
{
    [Table("MehsulKateqoriyalari")]
    public class MehsulKateqoriyasi
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Kateqoriya adı mütləqdir")]
        [StringLength(100, ErrorMessage = "Kateqoriya adı 100 simvoldan çox ola bilməz")]
        public string Ad { get; set; }

        [StringLength(500, ErrorMessage = "Təsvir 500 simvoldan çox ola bilməz")]
        public string Tesvir { get; set; }

        public int? UstKateqoriyaId { get; set; }

        [StringLength(20, ErrorMessage = "Kod 20 simvoldan çox ola bilməz")]
        public string Kod { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Aktiv"; // Aktiv, Deaktiv

        public DateTime YaradilmaTarixi { get; set; } = DateTime.Now;

        public DateTime? YenilenmeTarixi { get; set; }

        [StringLength(500)]
        public string Qeydler { get; set; }

        // Navigation Properties
        [ForeignKey("UstKateqoriyaId")]
        public virtual MehsulKateqoriyasi UstKateqoriya { get; set; }

        public virtual ICollection<MehsulKateqoriyasi> AltKateqoriyalar { get; set; }

        public virtual ICollection<Mehsul> Mehsullar { get; set; }

        public MehsulKateqoriyasi()
        {
            AltKateqoriyalar = new HashSet<MehsulKateqoriyasi>();
            Mehsullar = new HashSet<Mehsul>();
        }

        // Computed Properties
        [NotMapped]
        public string SeviyeliAd
        {
            get
            {
                if (UstKateqoriya != null)
                    return $"{UstKateqoriya.SeviyeliAd} > {Ad}";
                return Ad;
            }
        }

        [NotMapped]
        public int Seviye
        {
            get
            {
                int seviye = 0;
                var ust = UstKateqoriya;
                while (ust != null)
                {
                    seviye++;
                    ust = ust.UstKateqoriya;
                }
                return seviye;
            }
        }

        [NotMapped]
        public bool AltKateqoriyaVar => AltKateqoriyalar?.Count > 0;
    }
}