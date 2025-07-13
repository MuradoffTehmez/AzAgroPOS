using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AzAgroPOS.Entities.Domain
{
    [Table("AnbarTransferleri")]
    public class AnbarTransfer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string TransferNomresi { get; set; }

        public DateTime TransferTarixi { get; set; } = DateTime.Now;

        public int MenbAnbarId { get; set; }
        [ForeignKey("MenbAnbarId")]
        public virtual Anbar MenbAnbar { get; set; }

        public int HedefAnbarId { get; set; }
        [ForeignKey("HedefAnbarId")]
        public virtual Anbar HedefAnbar { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Hazırlıq"; // Hazırlıq, Göndərilmiş, Qəbul Edilmiş, İptal Edilmiş

        [StringLength(1000)]
        public string Aciklama { get; set; }

        public int YaradanIstifadeciId { get; set; }
        [ForeignKey("YaradanIstifadeciId")]
        public virtual Istifadeci YaradanIstifadeci { get; set; }

        public int? GonderenIstifadeciId { get; set; }
        [ForeignKey("GonderenIstifadeciId")]
        public virtual Istifadeci GonderenIstifadeci { get; set; }

        public DateTime? GondermeTarixi { get; set; }

        public int? QebulEdenIstifadeciId { get; set; }
        [ForeignKey("QebulEdenIstifadeciId")]
        public virtual Istifadeci QebulEdenIstifadeci { get; set; }

        public DateTime? QebulTarixi { get; set; }

        public DateTime YaradilmaTarixi { get; set; } = DateTime.Now;
        public DateTime? YenilenmeTarixi { get; set; }

        // Navigation Properties
        public virtual ICollection<AnbarTransferDetali> TransferDetallari { get; set; }

        // Computed Properties
        [NotMapped]
        public string TransferNomresiFormatli => $"TRF-{TransferNomresi}";

        [NotMapped]
        public int MehsulSayi => TransferDetallari?.Count ?? 0;

        [NotMapped]
        public decimal UmumiMiqdar => TransferDetallari?.Sum(d => d.Miqdar) ?? 0;

        [NotMapped]
        public decimal QebulEdilenMiqdar => TransferDetallari?.Sum(d => d.QebulEdilenMiqdar) ?? 0;

        [NotMapped]
        public bool TamQebulEdilmisdir => Status == "Qəbul Edilmiş" && 
                                         TransferDetallari?.All(d => d.TamQebulEdilmisdir) == true;

        [NotMapped]
        public string StatusAzerbaycan
        {
            get
            {
                switch (Status)
                {
                    case "Hazırlıq": return "Hazırlıq";
                    case "Göndərilmiş": return "Göndərilmiş";
                    case "Qəbul Edilmiş": return "Qəbul Edilmiş";
                    case "İptal Edilmiş": return "İptal Edilmiş";
                    default: return Status;
                }
            }
        }

        [NotMapped]
        public string AnbarlarArasi => $"{MenbAnbar?.Ad} → {HedefAnbar?.Ad}";

        [NotMapped]
        public bool Gonderileibilir => Status == "Hazırlıq" && MehsulSayi > 0;

        [NotMapped]
        public bool QebulEdileibilir => Status == "Göndərilmiş";

        [NotMapped]
        public bool IptalEdileibilir => Status == "Hazırlıq" || Status == "Göndərilmiş";
    }
}