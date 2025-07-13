using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzAgroPOS.Entities.Domain
{
    [Table("TedarukcuOdemeleri")]
    public class TedarukcuOdeme
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string OdemeNomresi { get; set; }

        public DateTime OdemeTarixi { get; set; } = DateTime.Now;

        public int TedarukcuId { get; set; }
        [ForeignKey("TedarukcuId")]
        public virtual Tedarukcu Tedarukcu { get; set; }

        public int? AlisSenedId { get; set; }
        [ForeignKey("AlisSenedId")]
        public virtual AlisSeined AlisSeined { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Ödəmə məbləği sıfırdan böyük olmalıdır")]
        public decimal OdemeMeblegi { get; set; }

        [Required]
        [StringLength(20)]
        public string OdemeNovu { get; set; } = "Nağd"; // Nağd, Bank Köçürməsi, Çek, Sənəd

        [StringLength(100)]
        public string OdemeDetali { get; set; }

        [StringLength(50)]
        public string ReferansNomresi { get; set; }

        [StringLength(50)]
        public string BankHesabi { get; set; }

        [StringLength(20)]
        public string CekNomresi { get; set; }

        public DateTime? CekTarixi { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Tamamlandı"; // Tamamlandı, Gözləyir, İptal Edilmiş, Qaytarıldı

        [StringLength(1000)]
        public string Aciklama { get; set; }

        public int YaradanIstifadeciId { get; set; }
        [ForeignKey("YaradanIstifadeciId")]
        public virtual Istifadeci YaradanIstifadeci { get; set; }

        public int? TesdiqleyenIstifadeciId { get; set; }
        [ForeignKey("TesdiqleyenIstifadeciId")]
        public virtual Istifadeci TesdiqleyenIstifadeci { get; set; }

        public DateTime? TesdiqTarixi { get; set; }

        public DateTime YaradilmaTarixi { get; set; } = DateTime.Now;
        public DateTime? YenilenmeTarixi { get; set; }

        // Computed Properties
        [NotMapped]
        public string OdemeNomresiFormatli => $"OD-{OdemeNomresi}";

        [NotMapped]
        public bool Tamamlanmisdir => Status == "Tamamlandı";

        [NotMapped]
        public bool Gozleyir => Status == "Gözləyir";

        [NotMapped]
        public bool IptalEdilmisdir => Status == "İptal Edilmiş";

        [NotMapped]
        public string StatusAzerbaycan
        {
            get
            {
                switch (Status)
                {
                    case "Tamamlandı": return "Tamamlandı";
                    case "Gözləyir": return "Gözləyir";
                    case "İptal Edilmiş": return "İptal Edilmiş";
                    case "Qaytarıldı": return "Qaytarıldı";
                    default: return Status;
                }
            }
        }

        [NotMapped]
        public string OdemeNovuAzerbaycan
        {
            get
            {
                switch (OdemeNovu)
                {
                    case "Nağd": return "Nağd";
                    case "Bank Köçürməsi": return "Bank Köçürməsi";
                    case "Çek": return "Çek";
                    case "Sənəd": return "Sənəd";
                    default: return OdemeNovu;
                }
            }
        }

        [NotMapped]
        public string OdemeDetaylari
        {
            get
            {
                if (!string.IsNullOrEmpty(OdemeDetali)) return OdemeDetali;
                if (!string.IsNullOrEmpty(ReferansNomresi)) return $"Ref: {ReferansNomresi}";
                if (!string.IsNullOrEmpty(CekNomresi)) return $"Çek: {CekNomresi}";
                return "Ətraflı məlumat yoxdur";
            }
        }

        [NotMapped]
        public bool TesdiqEdileibilir => Status == "Gözləyir";

        [NotMapped]
        public bool IptalEdileibilir => Status == "Gözləyir" || Status == "Tamamlandı";
    }
}