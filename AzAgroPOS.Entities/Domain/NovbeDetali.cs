using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzAgroPOS.Entities.Domain
{
    [Table("NovbeDetallari")]
    public class NovbeDetali : BaseEntity
    {
        [Required]
        public int NovbeCedveliId { get; set; }
        [ForeignKey("NovbeCedveliId")]
        public virtual NovbeCedveli NovbeCedveli { get; set; }

        [Required]
        public int IsciId { get; set; }
        [ForeignKey("IsciId")]
        public virtual Isci Isci { get; set; }

        [Required]
        public DateTime NovbeTarixi { get; set; }

        [Required]
        public TimeSpan BaslangicSaati { get; set; }

        [Required]
        public TimeSpan BitisSaati { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal MolaVaxti { get; set; } = 1; // Saat ilə

        [StringLength(50)]
        public string NovbeAdi { get; set; } // "Səhər", "Axşam", "Gecə"

        [StringLength(500)]
        public string Qeydler { get; set; }

        public bool TesdiqEdildi { get; set; } = false;

        [StringLength(100)]
        public string TesdiqEden { get; set; }

        public DateTime? TesdiqTarixi { get; set; }

        // Computed Properties
        [NotMapped]
        public TimeSpan ToplamIsSaati
        {
            get
            {
                var toplam = BitisSaati - BaslangicSaati;
                if (toplam.TotalDays < 0) // Gecə növbəsi üçün
                    toplam = toplam.Add(TimeSpan.FromDays(1));
                return toplam.Subtract(TimeSpan.FromHours((double)MolaVaxti));
            }
        }

        [NotMapped]
        public decimal SaatlikMebleg => (decimal)ToplamIsSaati.TotalHours;

        [NotMapped]
        public string NovbeVaxti => $"{BaslangicSaati:hh\\:mm} - {BitisSaati:hh\\:mm}";

        [NotMapped]
        public string TesdiqStatusu => TesdiqEdildi ? "Təsdiqləndi" : "Gözləyir";

        [NotMapped]
        public bool BugunNovbesi => NovbeTarixi.Date == DateTime.Today;

        [NotMapped]
        public bool GecmisNovbe => NovbeTarixi.Date < DateTime.Today;

        [NotMapped]
        public bool GelecekNovbe => NovbeTarixi.Date > DateTime.Today;

        // Static Constants
        public static class NovbeAdlari
        {
            public const string Seher = "Səhər";
            public const string Gun = "Gün";
            public const string Axsam = "Axşam";
            public const string Gece = "Gecə";
        }
    }
}