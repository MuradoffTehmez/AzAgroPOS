using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzAgroPOS.Entities.Domain
{
    [Table("BildirisAyarlari")]
    public class BildirisAyari : BaseEntity
    {
        [Required]
        public int IstifadeciId { get; set; }
        [ForeignKey("IstifadeciId")]
        public virtual Istifadeci Istifadeci { get; set; }

        [Required]
        [StringLength(100)]
        public string ModulAdi { get; set; }

        [Required]
        [StringLength(100)]
        public string BildirisNovu { get; set; }

        public bool EmailBildirimi { get; set; } = false;

        public bool SistemBildirimi { get; set; } = true;

        public bool SesliSiqnal { get; set; } = false;

        public bool MasaustuBildirimi { get; set; } = true;

        [StringLength(100)]
        public string SesliSiqnalFayli { get; set; }

        public bool GeceSessiz { get; set; } = true; // 22:00 - 08:00 arası sessiz

        public TimeSpan SessizBaslangic { get; set; } = new TimeSpan(22, 0, 0);

        public TimeSpan SessizBitis { get; set; } = new TimeSpan(8, 0, 0);

        [StringLength(50)]
        public string Prioritet { get; set; } = Bildiris.BildirisPrioritetleri.Orta;

        public bool OtomatikSil { get; set; } = true;

        public int OtomatikSilmeGunu { get; set; } = 30; // 30 gündən sonra sil

        public bool SadeceMuhimBildirisler { get; set; } = false;

        [StringLength(500)]
        public string AcarSozler { get; set; } // Filtr üçün açar sözlər

        [StringLength(500)]
        public string IstisnaAcarSozler { get; set; } // Bu açar sözlər varsa bildiriş göstərmə

        public bool AktivSaatlarDaxilinde { get; set; } = false; // Yalnız iş saatlarında

        public TimeSpan AktivBaslangic { get; set; } = new TimeSpan(9, 0, 0);

        public TimeSpan AktivBitis { get; set; } = new TimeSpan(18, 0, 0);

        [StringLength(20)]
        public string HefteSonuRezhimi { get; set; } = HefteSonuRejimi.Normal; // Həftə sonu bildiriş rejimi

        // Static Constants
        public static class HefteSonuRejimi
        {
            public const string Normal = "Normal";
            public const string SadeceCritik = "Sadəcə Kritik";
            public const string Hicsiri = "Heç biri";
        }

        // Computed Properties
        [NotMapped]
        public bool HazirdaAktiv
        {
            get
            {
                var now = DateTime.Now;
                var currentTime = now.TimeOfDay;
                var isWeekend = now.DayOfWeek == DayOfWeek.Saturday || now.DayOfWeek == DayOfWeek.Sunday;

                // Həftə sonu yoxlaması
                if (isWeekend && HefteSonuRezhimi == HefteSonuRejimi.Hicsiri)
                    return false;

                // Gecə sessiz rejimi
                if (GeceSessiz)
                {
                    if (SessizBaslangic > SessizBitis) // Gecə keçen interval (məs: 22:00 - 08:00)
                    {
                        if (currentTime >= SessizBaslangic || currentTime <= SessizBitis)
                            return false;
                    }
                    else // Gün içi interval
                    {
                        if (currentTime >= SessizBaslangic && currentTime <= SessizBitis)
                            return false;
                    }
                }

                // Aktiv saatlar yoxlaması
                if (AktivSaatlarDaxilinde)
                {
                    if (AktivBaslangic > AktivBitis) // Gecə keçen interval
                    {
                        if (!(currentTime >= AktivBaslangic || currentTime <= AktivBitis))
                            return false;
                    }
                    else // Gün içi interval
                    {
                        if (!(currentTime >= AktivBaslangic && currentTime <= AktivBitis))
                            return false;
                    }
                }

                return true;
            }
        }

        [NotMapped]
        public string AyarAdi => $"{ModulAdi} - {BildirisNovu}";

        [NotMapped]
        public string BildirisYollari
        {
            get
            {
                var yollar = new System.Collections.Generic.List<string>();
                if (SistemBildirimi) yollar.Add("Sistem");
                if (EmailBildirimi) yollar.Add("Email");
                if (MasaustuBildirimi) yollar.Add("Masaüstü");
                if (SesliSiqnal) yollar.Add("Sesli");
                return string.Join(", ", yollar);
            }
        }

        [NotMapped]
        public bool FiltrVarMi => !string.IsNullOrEmpty(AcarSozler) || !string.IsNullOrEmpty(IstisnaAcarSozler);

        public bool BildirisFiltrKecer(string mesaj, string prioritet)
        {
            // Prioritet yoxlaması
            if (SadeceMuhimBildirisler)
            {
                if (prioritet != Bildiris.BildirisPrioritetleri.Yuksek && 
                    prioritet != Bildiris.BildirisPrioritetleri.Kritik)
                    return false;
            }

            // Həftə sonu rejimi yoxlaması
            var isWeekend = DateTime.Now.DayOfWeek == DayOfWeek.Saturday || DateTime.Now.DayOfWeek == DayOfWeek.Sunday;
            if (isWeekend && HefteSonuRezhimi == HefteSonuRejimi.SadeceCritik)
            {
                if (prioritet != Bildiris.BildirisPrioritetleri.Kritik)
                    return false;
            }

            // Açar söz filtri
            if (!string.IsNullOrEmpty(AcarSozler))
            {
                var keywords = AcarSozler.Split(',', StringSplitOptions.RemoveEmptyEntries);
                bool hasKeyword = false;
                foreach (var keyword in keywords)
                {
                    if (mesaj.Contains(keyword.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        hasKeyword = true;
                        break;
                    }
                }
                if (!hasKeyword) return false;
            }

            // İstisna açar söz filtri
            if (!string.IsNullOrEmpty(IstisnaAcarSozler))
            {
                var excludeKeywords = IstisnaAcarSozler.Split(',', StringSplitOptions.RemoveEmptyEntries);
                foreach (var keyword in excludeKeywords)
                {
                    if (mesaj.Contains(keyword.Trim(), StringComparison.OrdinalIgnoreCase))
                        return false;
                }
            }

            return true;
        }
    }
}