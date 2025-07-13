using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AzAgroPOS.Entities.Domain
{
    [Table("TamirIsleri")]
    public class TamirIsi
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string TamirNomresi { get; set; }

        public DateTime QebulTarixi { get; set; } = DateTime.Now;

        public int MusteriId { get; set; }
        [ForeignKey("MusteriId")]
        public virtual Tedarukcu Musteri { get; set; }

        [Required]
        [StringLength(100)]
        public string MehsulAdi { get; set; }

        [StringLength(50)]
        public string Marka { get; set; }

        [StringLength(50)]
        public string Model { get; set; }

        [StringLength(50)]
        public string SeriNomresi { get; set; }

        [Required]
        [StringLength(1000)]
        public string ProblemTasviri { get; set; }

        [StringLength(1000)]
        public string MusteriQeydleri { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Qəbul Edildi"; // Qəbul Edildi, Təşxis, İşlənir, Gözləyir, Hazır, Təhvil Verildi, İptal

        [Required]
        [StringLength(20)]
        public string Prioritet { get; set; } = "Orta"; // Yüksək, Orta, Aşağı

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Təxmin qiymət mənfi ola bilməz")]
        public decimal TaxminQiymet { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Son qiymət mənfi ola bilməz")]
        public decimal SonQiymet { get; set; } = 0;

        public DateTime? TaxminiBitirmeTarixi { get; set; }

        public DateTime? EmeliBitirmeTarixi { get; set; }

        public DateTime? TehvilTarixi { get; set; }

        public int QebulEdenIstifadeciId { get; set; }
        [ForeignKey("QebulEdenIstifadeciId")]
        public virtual Istifadeci QebulEdenIstifadeci { get; set; }

        public int? TeyinEdilenIstifadeciId { get; set; }
        [ForeignKey("TeyinEdilenIstifadeciId")]
        public virtual Istifadeci TeyinEdilenIstifadeci { get; set; }

        public int? TehvilEdenIstifadeciId { get; set; }
        [ForeignKey("TehvilEdenIstifadeciId")]
        public virtual Istifadeci TehvilEdenIstifadeci { get; set; }

        [StringLength(1000)]
        public string TamirciQeydleri { get; set; }

        [StringLength(1000)]
        public string IstifadeOlunmusParcalar { get; set; }

        public bool TamirciTesdiqiVarmi { get; set; } = false;

        public bool MusteriTesdiqiVarmi { get; set; } = false;

        public DateTime YaradilmaTarixi { get; set; } = DateTime.Now;
        public DateTime? YenilenmeTarixi { get; set; }

        // Navigation Properties
        public virtual ICollection<TamirMerhele> TamirMerheleri { get; set; }

        // Computed Properties
        [NotMapped]
        public string TamirNomresiFormatli => $"TMR-{TamirNomresi}";

        [NotMapped]
        public string StatusAzerbaycan
        {
            get
            {
                switch (Status)
                {
                    case "Qəbul Edildi": return "Qəbul Edildi";
                    case "Təşxis": return "Təşxis";
                    case "İşlənir": return "İşlənir";
                    case "Gözləyir": return "Gözləyir";
                    case "Hazır": return "Hazır";
                    case "Təhvil Verildi": return "Təhvil Verildi";
                    case "İptal": return "İptal";
                    default: return Status;
                }
            }
        }

        [NotMapped]
        public string PrioritetAzerbaycan
        {
            get
            {
                switch (Prioritet)
                {
                    case "Yüksək": return "Yüksək";
                    case "Orta": return "Orta";
                    case "Aşağı": return "Aşağı";
                    default: return Prioritet;
                }
            }
        }

        [NotMapped]
        public bool Gecikmisdir => TaxminiBitirmeTarixi.HasValue && 
                                  TaxminiBitirmeTarixi.Value < DateTime.Now && 
                                  Status != "Təhvil Verildi" && Status != "İptal";

        [NotMapped]
        public int QalanGunSayi => TaxminiBitirmeTarixi.HasValue ? 
                                  (TaxminiBitirmeTarixi.Value - DateTime.Now).Days : 0;

        [NotMapped]
        public int IslenmisGunSayi => (DateTime.Now - QebulTarixi).Days;

        [NotMapped]
        public string MehsulTamBilgisi
        {
            get
            {
                var parts = new List<string> { MehsulAdi };
                if (!string.IsNullOrEmpty(Marka)) parts.Add(Marka);
                if (!string.IsNullOrEmpty(Model)) parts.Add(Model);
                return string.Join(" - ", parts);
            }
        }

        [NotMapped]
        public bool TesdiqlerTamdir => TamirciTesdiqiVarmi && MusteriTesdiqiVarmi;

        [NotMapped]
        public bool TehvilVerileibilir => Status == "Hazır" && TesdiqlerTamdir;

        [NotMapped]
        public bool IslenirStatusundadir => Status == "İşlənir" || Status == "Təşxis";

        [NotMapped]
        public string SeriNomresiBilgisi => !string.IsNullOrEmpty(SeriNomresi) ? SeriNomresi : "Yoxdur";

        [NotMapped]
        public int TamamlananMerheleeleriSayi => TamirMerheleri?.Count(m => m.BitirilmisTarix.HasValue) ?? 0;

        [NotMapped]
        public int UmumiMerheleSayi => TamirMerheleri?.Count ?? 0;

        [NotMapped]
        public double TamamlanmaYuzdesi => UmumiMerheleSayi > 0 ? 
                                         (double)TamamlananMerheleeleriSayi / UmumiMerheleSayi * 100 : 0;
    }
}