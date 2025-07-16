using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzAgroPOS.Entities.Domain
{
    [Table("BackupTenzimlemeleri")]
    public class BackupTenzimleme : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string TenzimlemeAdi { get; set; }

        [Required]
        [StringLength(500)]
        public string BackupYolu { get; set; }

        [Required]
        [StringLength(20)]
        public string BackupTipi { get; set; } = BackupTipleri.Haftaliq;

        public bool OtomatikBackup { get; set; } = true;

        public TimeSpan BackupSaati { get; set; } = new TimeSpan(2, 0, 0); // Gecə saat 02:00

        [StringLength(20)]
        public string GunleriBitmesi { get; set; } = "Pazartesi"; // Həftəlik backup üçün

        public int SaxlanmaGunSayi { get; set; } = 30; // Köhnə backupları silmək üçün

        public bool Sifreleme { get; set; } = false;

        [StringLength(100)]
        public string SifrelemeSifre { get; set; }

        public bool Siqisdir { get; set; } = true;

        [Column(TypeName = "decimal(3,1)")]
        public decimal SiqisdirmaSeviyesi { get; set; } = 6; // 1-9 arası

        public bool EmailBildirim { get; set; } = false;

        [StringLength(500)]
        public string EmailUnvanlari { get; set; }

        public bool Aktiv { get; set; } = true;

        public DateTime SonBackupTarixi { get; set; }

        public DateTime SonrakiBackupTarixi { get; set; }

        [StringLength(1000)]
        public string DaxilEdilenCedveller { get; set; } // JSON formatında

        [StringLength(1000)]
        public string IstisnaEdilenCedveller { get; set; } // JSON formatında

        public bool BackupMelumatlarDaxil { get; set; } = true; // Data

        public bool BackupStrukturDaxil { get; set; } = true; // Schema

        [StringLength(500)]
        public string Qeydler { get; set; }

        // Static Constants
        public static class BackupTipleri
        {
            public const string Gunluk = "Günlük";
            public const string Haftaliq = "Həftəlik";
            public const string Ayliq = "Aylıq";
            public const string Manuel = "Manuel";
        }

        public static class HefteGunleri
        {
            public const string Bazaertesi = "Bazar ertəsi";
            public const string Cersenbeaxsami = "Çərşənbə axşamı";
            public const string Cersenbe = "Çərşənbə";
            public const string Cumeaxsami = "Cümə axşamı";
            public const string Cume = "Cümə";
            public const string Senbeaxsami = "Şənbə axşamı";
            public const string Senbe = "Şənbə";
            public const string Bazar = "Bazar";
        }

        // Computed Properties
        [NotMapped]
        public bool BackupVaxtiCatdi => DateTime.Now >= SonrakiBackupTarixi && Aktiv;

        [NotMapped]
        public string BackupVaxtiText => $"{BackupSaati:hh\\:mm}";

        [NotMapped]
        public string SifreleninStatusu => Sifreleme ? "Bəli" : "Xeyr";

        [NotMapped]
        public string SiqisdirmaStatusu => Siqisdir ? $"Bəli (Səviyyə {SiqisdirmaSeviyesi})" : "Xeyr";

        [NotMapped]
        public TimeSpan SonrakiBackupMuddeti
        {
            get
            {
                if (SonrakiBackupTarixi > DateTime.Now)
                    return SonrakiBackupTarixi - DateTime.Now;
                else
                    return TimeSpan.Zero;
            }
        }

        [NotMapped]
        public string SonrakiBackupMuddeteText
        {
            get
            {
                var muddet = SonrakiBackupMuddeti;
                if (muddet.TotalDays >= 1)
                    return $"{(int)muddet.TotalDays} gün, {muddet.Hours} saat";
                else if (muddet.TotalHours >= 1)
                    return $"{(int)muddet.TotalHours} saat, {muddet.Minutes} dəqiqə";
                else
                    return $"{muddet.Minutes} dəqiqə";
            }
        }

        [NotMapped]
        public bool KohneBackuplarVar
        {
            get
            {
                var cutoffDate = DateTime.Now.AddDays(-SaxlanmaGunSayi);
                return SonBackupTarixi < cutoffDate;
            }
        }

        public void HesablaNextBackupTime()
        {
            var now = DateTime.Now;
            var nextBackup = now.Date.Add(BackupSaati);

            switch (BackupTipi)
            {
                case BackupTipleri.Gunluk:
                    if (nextBackup <= now)
                        nextBackup = nextBackup.AddDays(1);
                    break;

                case BackupTipleri.Haftaliq:
                    var targetDayOfWeek = GetDayOfWeekFromString(GunleriBitmesi);
                    var daysUntilTarget = ((int)targetDayOfWeek - (int)now.DayOfWeek + 7) % 7;
                    if (daysUntilTarget == 0 && nextBackup <= now)
                        daysUntilTarget = 7;
                    nextBackup = now.Date.AddDays(daysUntilTarget).Add(BackupSaati);
                    break;

                case BackupTipleri.Ayliq:
                    nextBackup = new DateTime(now.Year, now.Month, 1).Add(BackupSaati);
                    if (nextBackup <= now)
                        nextBackup = nextBackup.AddMonths(1);
                    break;

                default:
                    nextBackup = DateTime.MaxValue;
                    break;
            }

            SonrakiBackupTarixi = nextBackup;
        }

        private DayOfWeek GetDayOfWeekFromString(string dayName)
        {
            return dayName switch
            {
                HefteGunleri.Bazaertesi => DayOfWeek.Monday,
                HefteGunleri.Cersenbeaxsami => DayOfWeek.Tuesday,
                HefteGunleri.Cersenbe => DayOfWeek.Wednesday,
                HefteGunleri.Cumeaxsami => DayOfWeek.Thursday,
                HefteGunleri.Cume => DayOfWeek.Friday,
                HefteGunleri.Senbeaxsami => DayOfWeek.Saturday,
                HefteGunleri.Senbe => DayOfWeek.Saturday,
                HefteGunleri.Bazar => DayOfWeek.Sunday,
                _ => DayOfWeek.Monday
            };
        }
    }
}