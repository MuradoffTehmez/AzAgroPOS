using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzAgroPOS.Entities.Domain
{
    [Table("Tedarukciler")]
    public class Tedarukcu
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tədarükçü adı mütləqdir")]
        [StringLength(200, ErrorMessage = "Tədarükçü adı 200 simvoldan çox ola bilməz")]
        public string Ad { get; set; }

        [StringLength(50, ErrorMessage = "Tədarükçü kodu 50 simvoldan çox ola bilməz")]
        public string Kod { get; set; }

        [StringLength(500, ErrorMessage = "Ünvan 500 simvoldan çox ola bilməz")]
        public string Unvan { get; set; }

        [StringLength(20, ErrorMessage = "Telefon nömrəsi 20 simvoldan çox ola bilməz")]
        public string Telefon { get; set; }

        [StringLength(20, ErrorMessage = "Telefon2 nömrəsi 20 simvoldan çox ola bilməz")]
        public string Telefon2 { get; set; }

        [StringLength(100, ErrorMessage = "Email 100 simvoldan çox ola bilməz")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "Website 100 simvoldan çox ola bilməz")]
        public string Website { get; set; }

        [StringLength(50, ErrorMessage = "VOEN 50 simvoldan çox ola bilməz")]
        public string VOEN { get; set; }

        [StringLength(100, ErrorMessage = "Əlaqədar şəxs 100 simvoldan çox ola bilməz")]
        public string ElaqedarSexs { get; set; }

        [StringLength(20, ErrorMessage = "Əlaqədar telefon 20 simvoldan çox ola bilməz")]
        public string ElaqedarTelefon { get; set; }

        [StringLength(100, ErrorMessage = "Əlaqədar email 100 simvoldan çox ola bilməz")]
        public string ElaqedarEmail { get; set; }

        [StringLength(50, ErrorMessage = "Bank adı 50 simvoldan çox ola bilməz")]
        public string BankAdi { get; set; }

        [StringLength(50, ErrorMessage = "Hesab nömrəsi 50 simvoldan çox ola bilməz")]
        public string HesabNomresi { get; set; }

        [StringLength(20, ErrorMessage = "SWIFT kodu 20 simvoldan çox ola bilməz")]
        public string SwiftKod { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Kredit limiti mənfi ola bilməz")]
        public decimal KreditLimiti { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal CariBorc { get; set; } = 0;

        [StringLength(20)]
        public string OdemeSerti { get; set; } = "Nağd"; // Nağd, 30 gün, 60 gün, 90 gün

        [Range(0, 100, ErrorMessage = "Endirim faizi 0-100 arasında olmalıdır")]
        public decimal EndirimFaizi { get; set; } = 0;

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Aktiv"; // Aktiv, Deaktiv, Bloklanmış

        [StringLength(1000)]
        public string Qeydler { get; set; }

        public DateTime YaradilmaTarixi { get; set; } = DateTime.Now;
        public DateTime? YenilenmeTarixi { get; set; }

        // Navigation Properties
        public virtual ICollection<AlisOrder> AlisOrderleri { get; set; }
        public virtual ICollection<AlisSeined> AlisSenedleri { get; set; }
        public virtual ICollection<TedarukcuOdeme> Odemeler { get; set; }

        // Computed Properties
        [NotMapped]
        public string TamBilgi => $"{Ad} ({Kod})";

        [NotMapped]
        public bool KreditLimitiAsildimi => CariBorc >= KreditLimiti;

        [NotMapped]
        public decimal QalanKreditLimiti => KreditLimiti - CariBorc;

        [NotMapped]
        public string ElaqeBilgileri => !string.IsNullOrEmpty(ElaqedarSexs) 
            ? $"{ElaqedarSexs} - {ElaqedarTelefon}" 
            : Telefon;
    }
}