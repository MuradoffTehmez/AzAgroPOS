using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzAgroPOS.Entities.Domain
{
    [Table("NovbeCedvelleri")]
    public class NovbeCedveli : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Ad { get; set; }

        [StringLength(500)]
        public string Aciqlama { get; set; }

        [Required]
        public DateTime BaslamaTarixi { get; set; }

        public DateTime? BitisTarixi { get; set; }

        public bool Aktiv { get; set; } = true;

        [Required]
        [StringLength(20)]
        public string NovbeTipi { get; set; } // "Gunluk", "Hefte", "Ayliq"

        [Column(TypeName = "decimal(5,2)")]
        public decimal GunlukIsSaati { get; set; } = 8; // Standart iş saatı

        [Column(TypeName = "decimal(5,2)")]
        public decimal HeftelikIsSaati { get; set; } = 40; // Standart həftəlik iş saatı

        // Navigation Properties
        public virtual ICollection<NovbeDetali> NovbeDetallari { get; set; } = new List<NovbeDetali>();

        // Static Constants
        public static class NovbeTipleri
        {
            public const string Gunluk = "Günlük";
            public const string Hefte = "Həftə";
            public const string Ayliq = "Aylıq";
        }

        // Computed Properties
        [NotMapped]
        public string StatusText => Aktiv ? "Aktiv" : "Deaktiv";

        [NotMapped] 
        public int ToplamIsciSayi => NovbeDetallari?.Count ?? 0;
    }
}