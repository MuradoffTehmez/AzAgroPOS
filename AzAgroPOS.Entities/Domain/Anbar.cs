using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzAgroPOS.Entities.Domain
{
    [Table("Anbarlar")]
    public class Anbar
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Anbar adı mütləqdir")]
        [StringLength(100, ErrorMessage = "Anbar adı 100 simvoldan çox ola bilməz")]
        public string Ad { get; set; }

        [StringLength(20, ErrorMessage = "Anbar kodu 20 simvoldan çox ola bilməz")]
        public string Kod { get; set; }

        [StringLength(500, ErrorMessage = "Ünvan 500 simvoldan çox ola bilməz")]
        public string Unvan { get; set; }

        [StringLength(20, ErrorMessage = "Telefon 20 simvoldan çox ola bilməz")]
        public string Telefon { get; set; }

        [StringLength(100, ErrorMessage = "Məsul şəxs 100 simvoldan çox ola bilməz")]
        public string MesulSexs { get; set; }

        [StringLength(20, ErrorMessage = "Məsul telefon 20 simvoldan çox ola bilməz")]
        public string MesulTelefon { get; set; }

        [StringLength(20)]
        public string AnbarTipi { get; set; } = "Adi"; // Adi, Soyuducu, Xüsusi

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Sahə mənfi ola bilməz")]
        public decimal Sahe { get; set; } = 0; // m²

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Tutum mənfi ola bilməz")]
        public decimal Tutum { get; set; } = 0; // m³

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Aktiv"; // Aktiv, Deaktiv, Təmir

        [StringLength(1000)]
        public string Qeydler { get; set; }

        public DateTime YaradilmaTarixi { get; set; } = DateTime.Now;
        public DateTime? YenilenmeTarixi { get; set; }

        // Navigation Properties
        public virtual ICollection<AnbarQalik> AnbarQaliqları { get; set; }
        public virtual ICollection<AnbarHereketi> AnbarHereketleri { get; set; }
        public virtual ICollection<AnbarTransfer> GidenTransferler { get; set; }
        public virtual ICollection<AnbarTransfer> GelenTransferler { get; set; }

        // Computed Properties
        [NotMapped]
        public string TamAd => !string.IsNullOrEmpty(Kod) ? $"{Ad} ({Kod})" : Ad;

        [NotMapped]
        public int UmumiMehsulSayi => AnbarQaliqları?.Count ?? 0;

        [NotMapped]
        public string MesulBilgileri => !string.IsNullOrEmpty(MesulSexs) 
            ? $"{MesulSexs} - {MesulTelefon}" 
            : "Təyin edilməyib";

        [NotMapped]
        public string SaheVeTutum => Sahe > 0 || Tutum > 0 
            ? $"{Sahe:F1} m² / {Tutum:F1} m³" 
            : "Məlumat yoxdur";
    }
}