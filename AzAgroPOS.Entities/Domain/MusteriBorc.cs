using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AzAgroPOS.Entities.Domain
{
    [Table("MusteriBorcları")]
    public class MusteriBorc
    {
        [Key]
        public int Id { get; set; }

        public int MusteriId { get; set; }
        [ForeignKey("MusteriId")]
        public virtual Musteri Musteri { get; set; }

        [Required]
        [StringLength(50)]
        public string BorcNomresi { get; set; }

        [Required]
        [StringLength(20)]
        public string BorcTipi { get; set; } // Satis, Nisye, Faiz, Cərimə

        public int? SatisId { get; set; }
        [ForeignKey("SatisId")]
        public virtual Satis Satis { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Borc məbləği mənfi ola bilməz")]
        public decimal BorcMeblegi { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Ödənilmiş məbləğ mənfi ola bilməz")]
        public decimal OdenilmisMebleg { get; set; } = 0;

        public DateTime BorcTarixi { get; set; } = DateTime.Now;

        public DateTime SonOdemeTarixi { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        [Range(0, 100, ErrorMessage = "Faiz dərəcəsi 0-100 arasında olmalıdır")]
        public decimal FaizDerecesi { get; set; } = 0;

        [StringLength(20)]
        public string Status { get; set; } = "Açıq"; // Açıq, Qismən Ödənilmiş, Tam Ödənilmiş, Məhkəməlik

        [StringLength(1000)]
        public string Aciklama { get; set; }

        public int YaradanIstifadeciId { get; set; }
        [ForeignKey("YaradanIstifadeciId")]
        public virtual Istifadeci YaradanIstifadeci { get; set; }

        public DateTime YaradilmaTarixi { get; set; } = DateTime.Now;
        public DateTime? YenilenmeTarixi { get; set; }

        // Navigation Properties
        public virtual ICollection<BorcOdenis> BorcOdenisleri { get; set; }

        // Computed Properties
        [NotMapped]
        public string BorcNomresiFormatli => $"B-{BorcNomresi}";

        [NotMapped]
        public decimal QalanBorc => BorcMeblegi - OdenilmisMebleg;

        [NotMapped]
        public bool TamOdenilmis => QalanBorc <= 0;

        [NotMapped]
        public int GecikenGunSayi => SonOdemeTarixi < DateTime.Now ? (DateTime.Now - SonOdemeTarixi).Days : 0;

        [NotMapped]
        public bool Gecikmiş => GecikenGunSayi > 0 && !TamOdenilmis;

        [NotMapped]
        public decimal FaizMeblegi
        {
            get
            {
                if (FaizDerecesi <= 0 || GecikenGunSayi <= 0) return 0;
                return QalanBorc * (FaizDerecesi / 100) * (GecikenGunSayi / 365m);
            }
        }

        [NotMapped]
        public decimal UmumiBorc => QalanBorc + FaizMeblegi;

        [NotMapped]
        public string StatusAzerbaycan
        {
            get
            {
                switch (Status)
                {
                    case "Açıq": return "Açıq";
                    case "Qismən Ödənilmiş": return "Qismən Ödənilmiş";
                    case "Tam Ödənilmiş": return "Tam Ödənilmiş";
                    case "Məhkəməlik": return "Məhkəməlik";
                    default: return Status;
                }
            }
        }

        [NotMapped]
        public string OdemeStatusu
        {
            get
            {
                if (TamOdenilmis) return "Tam Ödənilmiş";
                if (OdenilmisMebleg > 0) return "Qismən Ödənilmiş";
                return "Ödənilməmiş";
            }
        }

        [NotMapped]
        public decimal OdemeYuzdesi => BorcMeblegi > 0 ? (OdenilmisMebleg / BorcMeblegi) * 100 : 0;

        [NotMapped]
        public string GecikmeDurumu
        {
            get
            {
                if (TamOdenilmis) return "Ödənilmiş";
                if (Gecikmiş) return $"{GecikenGunSayi} gün gecikmiş";
                return "Vaxtında";
            }
        }
    }
}