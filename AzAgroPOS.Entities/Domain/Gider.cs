using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzAgroPOS.Entities.Domain
{
    [Table("Giderler")]
    public class Gider : BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string Ad { get; set; }
        
        [StringLength(1000)]
        public string Aciqlama { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Mebleg { get; set; }
        
        [Required]
        public DateTime Tarix { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Kateqoriya { get; set; }
        
        [StringLength(50)]
        public string OdemeUsulu { get; set; }
        
        [StringLength(100)]
        public string Tesdiqleyen { get; set; }
        
        public bool TesdiqEdildi { get; set; }
        
        public DateTime? TesdiqTarixi { get; set; }
        
        [StringLength(500)]
        public string Qeyd { get; set; }
        
        // Foreign key
        public int IstifadeciId { get; set; }
        
        // Navigation property
        [ForeignKey("IstifadeciId")]
        public virtual Istifadeci Istifadeci { get; set; }
        
        // Computed properties
        [NotMapped]
        public string MeblegFormatli => Mebleg.ToString("C");
        
        [NotMapped]
        public string TarixFormatli => Tarix.ToString("dd.MM.yyyy");
        
        [NotMapped]
        public string StatusText => TesdiqEdildi ? "Təsdiqləndi" : "Gözləyir";
        
        [NotMapped]
        public string TamMelumat => $"{Ad} - {MeblegFormatli} ({TarixFormatli})";

        public DateTime YenilenmeTarixi { get; set; }
        public DateTime YaranmaTarixi { get; set; }
    }
    
    public static class GiderKateqoriyalari
    {
        public const string OfisXercleri = "Ofis Xərcləri";
        public const string PersonalMaasi = "Personal Maaşı";
        public const string KommunalOdemeler = "Kommunal Ödəmələr";
        public const string NaqliyyatXercleri = "Nəqliyyat Xərcləri";
        public const string Reklamvemreketinq = "Reklam və Marketinq";
        public const string TexnikiDəstək = "Texniki Dəstək";
        public const string AlqIcare = "Alqı/İcarə";
        public const string SahinkarligMateriallari = "Səhinkarlıq Materialları";
        public const string AvadanliqAlqi = "Avadanlıq Alqısı";
        public const string Diger = "Digər";
    }
    
    public static class OdemeUsullari
    {
        public const string Negd = "Nəğd";
        public const string BankKarti = "Bank Kartı";
        public const string BankKocurmu = "Bank Köçürməsi";
        public const string Cek = "Çek";
        public const string OnlineOdeme = "Online Ödəmə";
    }
}