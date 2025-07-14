using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AzAgroPOS.Entities.Constants;
using Microsoft.EntityFrameworkCore;
using CsvHelper.Configuration.Attributes;

namespace AzAgroPOS.Entities.Domain
{
    [Table("Musteriler")]
    public class Musteri
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Müştəri kodu mütləqdir")]
        [StringLength(20, ErrorMessage = "Müştəri kodu maksimum 20 simbol ola bilər")]
        public string MusteriKodu { get; set; }

        [Required(ErrorMessage = "Ad mütləqdir")]
        [StringLength(50, ErrorMessage = "Ad maksimum 50 simbol ola bilər")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyad mütləqdir")]
        [StringLength(50, ErrorMessage = "Soyad maksimum 50 simbol ola bilər")]
        public string Soyad { get; set; }

        [StringLength(100, ErrorMessage = "Şirkət adı maksimum 100 simbol ola bilər")]
        public string SirketAdi { get; set; }

        [StringLength(20, ErrorMessage = "Telefon maksimum 20 simbol ola bilər")]
        public string Telefon { get; set; }

        [StringLength(20, ErrorMessage = "Mobil telefon maksimum 20 simbol ola bilər")]
        public string MobilTelefon { get; set; }

        [StringLength(100, ErrorMessage = "Email maksimum 100 simbol ola bilər")]
        [EmailAddress(ErrorMessage = "Email formatı düzgün deyil")]
        public string Email { get; set; }

        [StringLength(500, ErrorMessage = "Ünvan maksimum 500 simbol ola bilər")]
        public string Unvan { get; set; }

        [StringLength(50, ErrorMessage = "Şəhər maksimum 50 simbol ola bilər")]
        public string Seher { get; set; }

        [StringLength(20, ErrorMessage = "Poçt kodu maksimum 20 simbol ola bilər")]
        public string PostKodu { get; set; }

        [StringLength(20, ErrorMessage = "Vergi nömrəsi maksimum 20 simbol ola bilər")]
        public string VergiNomresi { get; set; }

        [StringLength(20, ErrorMessage = "VÖEN maksimum 20 simbol ola bilər")]
        public string VOEN { get; set; }

        public DateTime? DogumTarixi { get; set; }

        [StringLength(20, ErrorMessage = "Cinsi maksimum 20 simbol ola bilər")]
        public string Cinsi { get; set; } // Kişi, Qadın

        [StringLength(20, ErrorMessage = "Müştəri tipi maksimum 20 simbol ola bilər")]
        public string MusteriTipi { get; set; } = "Fərdi"; // Fərdi, Korporativ

        public int? MusteriQrupuId { get; set; }
        [ForeignKey("MusteriQrupuId")]
        public virtual MusteriQrupu MusteriQrupu { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Kredit limiti mənfi ola bilməz")]
        public decimal KreditLimiti { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal CariBorc { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal UmumiAlis { get; set; } = 0;

        public int ZiyaretSayi { get; set; } = 0;

        public DateTime? SonZiyaretTarixi { get; set; }

        [StringLength(1000, ErrorMessage = "Qeydlər maksimum 1000 simbol ola bilər")]
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
        public virtual ICollection<Satis> Satislar { get; set; } = new List<Satis>();
        public virtual ICollection<MusteriBorc> Borclar { get; set; } = new List<MusteriBorc>();
        public virtual ICollection<TamirIsi> TamirIsleri { get; set; } = new List<TamirIsi>();

        // Computed Properties
        [NotMapped]
        public string TamAd => $"{Ad} {Soyad}";

        [NotMapped]
        public string TamAdVeSirket => !string.IsNullOrEmpty(SirketAdi) ? $"{TamAd} ({SirketAdi})" : TamAd;

        [NotMapped]
        public string MusteriKoduFormatli => $"MST-{MusteriKodu}";

        [NotMapped]
        public string TelefonBilgisi => !string.IsNullOrEmpty(MobilTelefon) ? MobilTelefon : 
                                       !string.IsNullOrEmpty(Telefon) ? Telefon : "Məlumat yoxdur";

        [NotMapped]
        public decimal QalanKreditLimiti => KreditLimiti - CariBorc;

        [NotMapped]
        public bool KreditLimitiAsildi => CariBorc > KreditLimiti;

        [NotMapped]
        public string KreditVeziyyeti => KreditLimitiAsildi ? "Limit aşıldı" : 
                                        QalanKreditLimiti == 0 ? "Limit doldu" : "Normal";

        [NotMapped]
        public decimal EndirimbFaizi => MusteriQrupu?.EndirimbFaizi ?? 0;

        [NotMapped]
        public string MusteriQrupuAdi => MusteriQrupu?.Ad ?? "Qrup təyin edilməyib";

        [NotMapped]
        public int Yasi => DogumTarixi.HasValue ? DateTime.Now.Year - DogumTarixi.Value.Year : 0;

        [NotMapped]
        public bool YeniMusteridir => DateTime.Now.Subtract(YaradilmaTarixi).Days <= 30;

        [NotMapped]
        public bool VIPMusteridir => UmumiAlis > 10000; // 10,000+ alış yapan VIP

        [NotMapped]
        public string MusteriSeviyyesi => VIPMusteridir ? "VIP" : 
                                         UmumiAlis > 5000 ? "Premium" :
                                         UmumiAlis > 1000 ? "Standard" : "Yeni";

        [NotMapped]
        public int GecenZiyaretdenGunler => SonZiyaretTarixi.HasValue ? 
                                          DateTime.Now.Subtract(SonZiyaretTarixi.Value).Days : -1;

        [NotMapped]
        public bool UzunMuddeetPasivdir => GecenZiyaretdenGunler > 90;
    }
}