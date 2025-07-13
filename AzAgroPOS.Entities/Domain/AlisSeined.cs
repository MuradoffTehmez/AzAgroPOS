using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AzAgroPOS.Entities.Domain
{
    [Table("AlisSenedleri")]
    public class AlisSeined
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string SenedNomresi { get; set; }

        public DateTime SenedTarixi { get; set; } = DateTime.Now;

        public int TedarukcuId { get; set; }
        [ForeignKey("TedarukcuId")]
        public virtual Tedarukcu Tedarukcu { get; set; }

        public int? AlisOrderId { get; set; }
        [ForeignKey("AlisOrderId")]
        public virtual AlisOrder AlisOrder { get; set; }

        public int AnbarId { get; set; }
        [ForeignKey("AnbarId")]
        public virtual Anbar Anbar { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UmumiMebleg { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal EndirimMeblegi { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal VergiMeblegi { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal NetMebleg { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal OdenenMebleg { get; set; } = 0;

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Gözləyir"; // Gözləyir, Qəbul Edilmiş, İptal Edilmiş

        [Required]
        [StringLength(20)]
        public string OdemeStatus { get; set; } = "Ödənilməmiş"; // Ödənilməmiş, Qismən Ödənilmiş, Tam Ödənilmiş

        [StringLength(20)]
        public string OdemeSerti { get; set; } = "Nağd";

        [StringLength(50)]
        public string FakturaNomresi { get; set; }

        public DateTime? FakturaTarixi { get; set; }

        [StringLength(1000)]
        public string Qeydler { get; set; }

        public int YaradanIstifadeciId { get; set; }
        [ForeignKey("YaradanIstifadeciId")]
        public virtual Istifadeci YaradanIstifadeci { get; set; }

        public int? QebulEdenIstifadeciId { get; set; }
        [ForeignKey("QebulEdenIstifadeciId")]
        public virtual Istifadeci QebulEdenIstifadeci { get; set; }

        public DateTime? QebulTarixi { get; set; }

        public DateTime YaradilmaTarixi { get; set; } = DateTime.Now;
        public DateTime? YenilenmeTarixi { get; set; }

        // Navigation Properties
        public virtual ICollection<AlisSenedDetali> SenedDetallari { get; set; }
        public virtual ICollection<TedarukcuOdeme> Odemeler { get; set; }

        // Computed Properties
        [NotMapped]
        public string SenedNomresiFormatli => $"AL-{SenedNomresi}";

        [NotMapped]
        public int MehsulSayi => SenedDetallari?.Count ?? 0;

        [NotMapped]
        public decimal UmumiMiqdar => SenedDetallari?.Sum(d => d.Miqdar) ?? 0;

        [NotMapped]
        public decimal QalanBorc => NetMebleg - OdenenMebleg;

        [NotMapped]
        public bool TamOdenilmisdir => OdenenMebleg >= NetMebleg;

        [NotMapped]
        public bool QebulEdilmisdir => Status == "Qəbul Edilmiş";

        [NotMapped]
        public string StatusAzerbaycan
        {
            get
            {
                return Status switch
                {
                    "Gözləyir" => "Gözləyir",
                    "Qəbul Edilmiş" => "Qəbul Edilmiş",
                    "İptal Edilmiş" => "İptal Edilmiş",
                    _ => Status
                };
            }
        }

        [NotMapped]
        public string OdemeStatusAzerbaycan
        {
            get
            {
                return OdemeStatus switch
                {
                    "Ödənilməmiş" => "Ödənilməmiş",
                    "Qismən Ödənilmiş" => "Qismən Ödənilmiş", 
                    "Tam Ödənilmiş" => "Tam Ödənilmiş",
                    _ => OdemeStatus
                };
            }
        }

        [NotMapped]
        public string OdemeDurumu => $"{OdenenMebleg:F2} / {NetMebleg:F2} ₼";

        [NotMapped]
        public bool QebulEdileibilir => Status == "Gözləyir" && MehsulSayi > 0;

        [NotMapped]
        public bool IptalEdileibilir => Status == "Gözləyir";
    }
}