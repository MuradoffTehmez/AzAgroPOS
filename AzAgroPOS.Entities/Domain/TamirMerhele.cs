using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzAgroPOS.Entities.Domain
{
    [Table("TamirMerheleri")]
    public class TamirMerhele
    {
        [Key]
        public int Id { get; set; }

        public int TamirIsiId { get; set; }
        [ForeignKey("TamirIsiId")]
        public virtual TamirIsi TamirIsi { get; set; }

        [Required]
        [StringLength(200)]
        public string MerheleAdi { get; set; }

        [StringLength(1000)]
        public string Aciklama { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Gözləyir"; // Gözləyir, İşlənir, Bitdi, İptal

        public int Sira { get; set; }

        public DateTime? BaslangicTarixi { get; set; }

        public DateTime? BitirilmisTarix { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "İş saatı mənfi ola bilməz")]
        public decimal IsSaati { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Saatlik ücret mənfi ola bilməz")]
        public decimal SaatlikUcret { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Parça dəyəri mənfi ola bilməz")]
        public decimal ParcaDeyeri { get; set; } = 0;

        public int? TeyinEdilenIstifadeciId { get; set; }
        [ForeignKey("TeyinEdilenIstifadeciId")]
        public virtual Istifadeci TeyinEdilenIstifadeci { get; set; }

        [StringLength(1000)]
        public string TamirciQeydleri { get; set; }

        [StringLength(500)]
        public string IstifadeOlunmusParcalar { get; set; }

        public DateTime YaradilmaTarixi { get; set; } = DateTime.Now;
        public DateTime? YenilenmeTarixi { get; set; }

        // Computed Properties
        [NotMapped]
        public string StatusAzerbaycan
        {
            get
            {
                switch (Status)
                {
                    case "Gözləyir": return "Gözləyir";
                    case "İşlənir": return "İşlənir";
                    case "Bitdi": return "Bitdi";
                    case "İptal": return "İptal";
                    default: return Status;
                }
            }
        }

        [NotMapped]
        public bool Baslamisdir => BaslangicTarixi.HasValue;

        [NotMapped]
        public bool Bitmisdir => BitirilmisTarix.HasValue;

        [NotMapped]
        public decimal UmumiDeger => (IsSaati * SaatlikUcret) + ParcaDeyeri;

        [NotMapped]
        public string IsUcreti => IsSaati > 0 && SaatlikUcret > 0 ? 
                                 $"{IsSaati:F2} saat × {SaatlikUcret:C} = {(IsSaati * SaatlikUcret):C}" : "Məlumat yoxdur";

        [NotMapped]
        public string ParcaUcreti => ParcaDeyeri > 0 ? $"{ParcaDeyeri:C}" : "Məlumat yoxdur";

        [NotMapped]
        public int IslenmeVaxti => Baslamisdir && Bitmisdir ? 
                                  (BitirilmisTarix.Value - BaslangicTarixi.Value).Days : 0;

        [NotMapped]
        public bool BaslayaABilir => Status == "Gözləyir" && TeyinEdilenIstifadeciId.HasValue;

        [NotMapped]
        public bool BitireABilir => Status == "İşlənir";

        [NotMapped]
        public bool IptalEdileABilir => Status != "Bitdi";

        [NotMapped]
        public string TeyinEdilenIsciBilgisi => TeyinEdilenIstifadeci?.Ad ?? "Təyin edilməyib";

        [NotMapped]
        public string ParcalarBilgisi => !string.IsNullOrEmpty(IstifadeOlunmusParcalar) ? 
                                        IstifadeOlunmusParcalar : "İstifadə olunan parça yoxdur";
    }
}