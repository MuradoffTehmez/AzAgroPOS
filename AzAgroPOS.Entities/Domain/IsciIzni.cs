using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzAgroPOS.Entities.Domain
{
    [Table("IsciIzinleri")]
    public class IsciIzni : BaseEntity
    {
        [Required]
        public int IsciId { get; set; }
        [ForeignKey("IsciId")]
        public virtual Isci Isci { get; set; }

        [Required]
        [StringLength(50)]
        public string IzinTipi { get; set; }

        [Required]
        public DateTime BaslangicTarixi { get; set; }

        [Required]
        public DateTime BitisTarixi { get; set; }

        [Required]
        [StringLength(1000)]
        public string SebebOzuru { get; set; }

        [StringLength(1000)]
        public string TesdiqQeydi { get; set; }

        [Required]
        [StringLength(20)]
        public string Statusu { get; set; } = IzinStatuslari.Gozleyir;

        [StringLength(100)]
        public string TesdiqEden { get; set; }

        public DateTime? TesdiqTarixi { get; set; }

        public DateTime? RedTarixi { get; set; }

        [StringLength(500)]
        public string RedSebebi { get; set; }

        [StringLength(500)]
        public string ElaveMelumat { get; set; }

        // Static Constants
        public static class IzinTipleri
        {
            public const string Illik = "İllik İzin";
            public const string Xeresteliq = "Xəstəlik İzni";
            public const string Ana = "Ana İzni";
            public const string Ata = "Ata İzni";
            public const string Evlilik = "Evlilik İzni";
            public const string Vefat = "Vəfat İzni";
            public const string Tehsil = "Təhsil İzni";
            public const string Shexsi = "Şəxsi İzin";
            public const string Mezuriyetsiz = "Məzuriyyətsiz İzin";
        }

        public static class IzinStatuslari
        {
            public const string Gozleyir = "Gözləyir";
            public const string TesdiqEdildi = "Təsdiqləndi";
            public const string RedEdildi = "Rədd Edildi";
            public const string Legv = "Ləğv Edildi";
        }

        // Computed Properties
        [NotMapped]
        public int IzinGunSayi => (BitisTarixi - BaslangicTarixi).Days + 1;

        [NotMapped]
        public bool AktivIzin => Statusu == IzinStatuslari.TesdiqEdildi && 
                                BaslangicTarixi <= DateTime.Today && 
                                BitisTarixi >= DateTime.Today;

        [NotMapped]
        public string IzinMuddeti => $"{BaslangicTarixi:dd.MM.yyyy} - {BitisTarixi:dd.MM.yyyy}";

        [NotMapped]
        public string StatusRengi
        {
            get
            {
                return Statusu switch
                {
                    IzinStatuslari.Gozleyir => "#f39c12", // Orange
                    IzinStatuslari.TesdiqEdildi => "#27ae60", // Green
                    IzinStatuslari.RedEdildi => "#e74c3c", // Red
                    IzinStatuslari.Legv => "#95a5a6", // Gray
                    _ => "#3498db" // Blue
                };
            }
        }

        [NotMapped]
        public bool Gecmis => BitisTarixi < DateTime.Today;

        [NotMapped]
        public bool Gelecek => BaslangicTarixi > DateTime.Today;
    }
}