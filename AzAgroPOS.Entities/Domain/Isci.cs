using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AzAgroPOS.Entities.Constants;

namespace AzAgroPOS.Entities.Domain
{
    [Table("Isciler")]
    public class Isci
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "İşçi kodu mütləqdir")]
        [StringLength(20, ErrorMessage = "İşçi kodu maksimum 20 simbol ola bilər")]
        public string IsciKodu { get; set; }

        [Required(ErrorMessage = "Ad mütləqdir")]
        [StringLength(50, ErrorMessage = "Ad maksimum 50 simbol ola bilər")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyad mütləqdir")]
        [StringLength(50, ErrorMessage = "Soyad maksimum 50 simbol ola bilər")]
        public string Soyad { get; set; }

        [StringLength(20, ErrorMessage = "Telefon maksimum 20 simbol ola bilər")]
        public string Telefon { get; set; }

        [StringLength(100, ErrorMessage = "Email maksimum 100 simbol ola bilər")]
        [EmailAddress(ErrorMessage = "Email formatı düzgün deyil")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vəzifə mütləqdir")]
        [StringLength(50, ErrorMessage = "Vəzifə maksimum 50 simbol ola bilər")]
        public string Vezife { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Maas { get; set; }

        public DateTime? IseBaslamaTarixi { get; set; }

        public DateTime? IseQurtarmaTarixi { get; set; }

        [StringLength(500, ErrorMessage = "Qeydlər maksimum 500 simbol ola bilər")]
        public string Qeydler { get; set; }

        [Required(ErrorMessage = "Status mütləqdir")]
        [StringLength(20, ErrorMessage = "Status maksimum 20 simbol ola bilər")]
        public string Status { get; set; } = SystemConstants.Status.Active;

        public DateTime YaradilmaTarixi { get; set; } = DateTime.Now;
        public DateTime? YenilenmeTarixi { get; set; }

        public int? YaradanIstifadeciId { get; set; }
        [ForeignKey("YaradanIstifadeciId")]
        public virtual Istifadeci YaradanIstifadeci { get; set; }

        // Navigation Properties
        public virtual ICollection<NovbeKaydi> NovbeKayitlari { get; set; } = new List<NovbeKaydi>();
        public virtual ICollection<IsciPerformans> PerformansKayitlari { get; set; } = new List<IsciPerformans>();

        // Computed Properties
        [NotMapped]
        public string TamAd => $"{Ad} {Soyad}";

        [NotMapped]
        public string IsciKoduFormatli => $"ISC-{IsciKodu}";

        [NotMapped]
        public bool AktivIscidir => Status == SystemConstants.Status.Active;

        [NotMapped]
        public int IsGunleri => IseBaslamaTarixi.HasValue ? 
            (IseQurtarmaTarixi.HasValue ? 
                (int)(IseQurtarmaTarixi.Value - IseBaslamaTarixi.Value).TotalDays : 
                (int)(DateTime.Now - IseBaslamaTarixi.Value).TotalDays) : 0;

        [NotMapped]
        public string VezifeSeviyyesi
        {
            get
            {
                if (Vezife == "Müdür")
                    return "Yüksek";
                else if (Vezife == "Supervisor" || Vezife == "Kassir" || Vezife == "Anbar məsul")
                    return "Orta";
                else
                    return "Əsas";
            }
        }
    }
}