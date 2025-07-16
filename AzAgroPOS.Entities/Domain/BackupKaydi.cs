using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzAgroPOS.Entities.Domain
{
    [Table("BackupKayitlari")]
    public class BackupKaydi : BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string BackupAdi { get; set; }

        [Required]
        [StringLength(500)]
        public string BackupYolu { get; set; }

        [Required]
        public DateTime BackupTarixi { get; set; }

        [Required]
        [StringLength(20)]
        public string BackupTipi { get; set; } = BackupTipleri.Manual;

        [Column(TypeName = "decimal(10,2)")]
        public decimal FaylOlcusu { get; set; } // MB ilə

        [Required]
        [StringLength(20)]
        public string Statusu { get; set; } = BackupStatuslari.Ugurlu;

        [StringLength(1000)]
        public string XetaMesaji { get; set; }

        [Required]
        public int IstifadeciId { get; set; }
        [ForeignKey("IstifadeciId")]
        public virtual Istifadeci Istifadeci { get; set; }

        [StringLength(500)]
        public string Aciqlama { get; set; }

        public TimeSpan BackupMuddeti { get; set; } // Backup vaxtı

        [StringLength(64)]
        public string MD5Hash { get; set; } // Fayl bütövlüyü yoxlaması

        public bool Sifrelendi { get; set; } = false;

        public bool Siqisdirildi { get; set; } = true;

        // Static Constants
        public static class BackupTipleri
        {
            public const string Manual = "Manuel";
            public const string Avtomatik = "Avtomatik";
            public const string Planli = "Planlı";
            public const string Sistem = "Sistem";
        }

        public static class BackupStatuslari
        {
            public const string Ugurlu = "Uğurlu";
            public const string Ugursuz = "Uğursuz";
            public const string Davam = "Davam edir";
            public const string Legv = "Ləğv edildi";
        }

        // Computed Properties
        [NotMapped]
        public string FaylOlcusuText
        {
            get
            {
                if (FaylOlcusu < 1024)
                    return $"{FaylOlcusu:F2} MB";
                else if (FaylOlcusu < 1024 * 1024)
                    return $"{FaylOlcusu / 1024:F2} GB";
                else
                    return $"{FaylOlcusu / (1024 * 1024):F2} TB";
            }
        }

        [NotMapped]
        public string BackupMuddeteText => BackupMuddeti.ToString(@"hh\:mm\:ss");

        [NotMapped]
        public string StatusRengi
        {
            get
            {
                return Statusu switch
                {
                    BackupStatuslari.Ugurlu => "#27ae60", // Green
                    BackupStatuslari.Ugursuz => "#e74c3c", // Red
                    BackupStatuslari.Davam => "#3498db", // Blue
                    BackupStatuslari.Legv => "#95a5a6", // Gray
                    _ => "#34495e" // Dark Gray
                };
            }
        }

        [NotMapped]
        public bool FaylMovcuddur => !string.IsNullOrEmpty(BackupYolu) && System.IO.File.Exists(BackupYolu);

        [NotMapped]
        public DateTime SonrakiOtomatikBackup
        {
            get
            {
                if (BackupTipi == BackupTipleri.Avtomatik)
                    return BackupTarixi.AddDays(1);
                else if (BackupTipi == BackupTipleri.Planli)
                    return BackupTarixi.AddDays(7);
                else
                    return DateTime.MinValue;
            }
        }
    }
}