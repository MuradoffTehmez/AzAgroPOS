// Fayl: AzAgroPOS.Verilenler/Kontekst/AzAgroPOSDbContext.cs
namespace AzAgroPOS.Verilenler.Kontekst;

using AzAgroPOS.Varliglar;
using Microsoft.EntityFrameworkCore;

public class AzAgroPOSDbContext : DbContext
{
    public AzAgroPOSDbContext(DbContextOptions<AzAgroPOSDbContext> options) : base(options)
    {
       //Database.EnsureCreated(); // Verilənlər bazasının yaradılmasını təmin edir
    }

    public DbSet<Mehsul> Mehsullar { get; set; }
    public DbSet<Musteri> Musteriler { get; set; }
    public DbSet<Satis> Satislar { get; set; }
    public DbSet<SatisDetali> SatisDetallari { get; set; }
    public DbSet<Istifadeci> Istifadeciler { get; set; }
    public DbSet<Rol> Rollar { get; set; }
    public DbSet<NisyeHereketi> NisyeHereketleri { get; set; }
    public DbSet<Temir> TemirSifarisleri { get; set; }
    public DbSet<Novbe> Novbeler { get; set; }
    public DbSet<Isci> Isciler { get; set; }
    public DbSet<IsciPerformans> IsciPerformanslari { get; set; }
    public DbSet<IsciIzni> IsciIznleri { get; set; }
    public DbSet<Tedarukcu> Tedarukculer { get; set; }
    public DbSet<AlisSifaris> AlisSifarisleri { get; set; }
    public DbSet<AlisSifarisSetiri> AlisSifarisSetirleri { get; set; }
    public DbSet<AlisSened> AlisSenetleri { get; set; }
    public DbSet<AlisSenedSetiri> AlisSenedSetirleri { get; set; }
    public DbSet<TedarukcuOdeme> TedarukcuOdemeleri { get; set; }
    public DbSet<Kateqoriya> Kateqoriyalar { get; set; } // Əlavə edildi
    public DbSet<Brend> Brendler { get; set; } // Əlavə edildi

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Mehsul>().Property(m => m.PerakendeSatisQiymeti).HasColumnType("decimal(18, 2)");
        modelBuilder.Entity<Mehsul>().Property(m => m.TopdanSatisQiymeti).HasColumnType("decimal(18, 2)");
        modelBuilder.Entity<Mehsul>().Property(m => m.TekEdedSatisQiymeti).HasColumnType("decimal(18, 2)");
        modelBuilder.Entity<Mehsul>().Property(m => m.AlisQiymeti).HasColumnType("decimal(18, 2)");
        modelBuilder.Entity<Satis>().Property(s => s.UmumiMebleg).HasColumnType("decimal(18, 2)");
        modelBuilder.Entity<SatisDetali>().Property(sd => sd.Qiymet).HasColumnType("decimal(18, 2)");
        modelBuilder.Entity<Musteri>().Property(m => m.UmumiBorc).HasColumnType("decimal(18, 2)");
        modelBuilder.Entity<Temir>().Property(t => t.TemirXerci).HasColumnType("decimal(18, 2)");
        modelBuilder.Entity<Temir>().Property(t => t.YekunMebleg).HasColumnType("decimal(18, 2)");
        modelBuilder.Entity<NisyeHereketi>().Property(n => n.Mebleg).HasColumnType("decimal(18, 2)");
        modelBuilder.Entity<Novbe>().Property(n => n.BaslangicMebleg).HasColumnType("decimal(18, 2)");
        modelBuilder.Entity<Novbe>().Property(n => n.GozlenilenMebleg).HasColumnType("decimal(18, 2)");
        modelBuilder.Entity<Novbe>().Property(n => n.FaktikiMebleg).HasColumnType("decimal(18, 2)");
        modelBuilder.Entity<Isci>().Property(i => i.Maas).HasColumnType("decimal(18, 2)");
        modelBuilder.Entity<AlisSifaris>().Property(a => a.UmumiMebleg).HasColumnType("decimal(18, 2)");
        modelBuilder.Entity<AlisSifarisSetiri>().Property(a => a.BirVahidQiymet).HasColumnType("decimal(18, 2)");
        modelBuilder.Entity<AlisSifarisSetiri>().Property(a => a.CemiMebleg).HasColumnType("decimal(18, 2)");
        modelBuilder.Entity<AlisSened>().Property(a => a.UmumiMebleg).HasColumnType("decimal(18, 2)");
        modelBuilder.Entity<AlisSenedSetiri>().Property(a => a.BirVahidQiymet).HasColumnType("decimal(18, 2)");
        modelBuilder.Entity<AlisSenedSetiri>().Property(a => a.CemiMebleg).HasColumnType("decimal(18, 2)");
        modelBuilder.Entity<TedarukcuOdeme>().Property(t => t.Mebleg).HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<Istifadeci>()
            .HasOne(i => i.Rol)
            .WithMany(r => r.Istifadeciler)
            .HasForeignKey(i => i.RolId);

        modelBuilder.Entity<Temir>()
            .HasOne(t => t.Isci)
            .WithMany(i => i.TemirSifarisleri)
            .HasForeignKey(t => t.IsciId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Satis>()
            .HasOne(s => s.Novbe)
            .WithMany(n => n.Satislar)
            .HasForeignKey(s => s.NovbeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Novbe>()
            .HasOne(n => n.Isci) 
            .WithMany(i => i.Novbeler) 
            .HasForeignKey(n => n.IsciId) 
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<IsciPerformans>()
            .HasOne(ip => ip.Isci)
            .WithMany(i => i.PerformansQeydleri)
            .HasForeignKey(ip => ip.IsciId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<IsciIzni>()
            .HasOne(ii => ii.Isci)
            .WithMany(i => i.IzinQeydleri)
            .HasForeignKey(ii => ii.IsciId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<IsciIzni>()
            .HasOne(ii => ii.TesdiqEdenIsci)
            .WithMany()
            .HasForeignKey(ii => ii.TesdiqEdenIsciId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<AlisSifaris>()
            .HasOne(a => a.Tedarukcu)
            .WithMany(t => t.AlisSifarisleri)
            .HasForeignKey(a => a.TedarukcuId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Tedarukcu>()
            .HasMany(t => t.AlisSenetleri)
            .WithOne(a => a.Tedarukcu)
            .HasForeignKey(a => a.TedarukcuId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Tedarukcu>()
            .HasMany(t => t.Odemeler)
            .WithOne(o => o.Tedarukcu)
            .HasForeignKey(o => o.TedarukcuId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AlisSifaris>()
            .HasMany(a => a.SifarisSetirleri)
            .WithOne(s => s.AlisSifaris)
            .HasForeignKey(s => s.AlisSifarisId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AlisSifarisSetiri>()
            .HasOne(a => a.AlisSifaris)
            .WithMany(s => s.SifarisSetirleri)
            .HasForeignKey(a => a.AlisSifarisId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AlisSifarisSetiri>()
            .HasOne(a => a.Mehsul)
            .WithMany()
            .HasForeignKey(a => a.MehsulId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<AlisSened>()
            .HasMany(a => a.SenedSetirleri)
            .WithOne(s => s.AlisSened)
            .HasForeignKey(s => s.AlisSenedId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AlisSened>()
            .HasOne(a => a.Tedarukcu)
            .WithMany(t => t.AlisSenetleri)
            .HasForeignKey(a => a.TedarukcuId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<AlisSenedSetiri>()
            .HasOne(a => a.AlisSened)
            .WithMany(s => s.SenedSetirleri)
            .HasForeignKey(a => a.AlisSenedId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AlisSenedSetiri>()
            .HasOne(a => a.Mehsul)
            .WithMany()
            .HasForeignKey(a => a.MehsulId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<AlisSenedSetiri>()
            .HasOne(a => a.AlisSifarisSetiri)
            .WithMany()
            .HasForeignKey(a => a.AlisSifarisSetiriId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TedarukcuOdeme>()
            .HasOne(t => t.Tedarukcu)
            .WithMany(t => t.Odemeler)
            .HasForeignKey(t => t.TedarukcuId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TedarukcuOdeme>()
            .HasOne(t => t.AlisSened)
            .WithMany(a => a.Odemeler)
            .HasForeignKey(t => t.AlisSenedId)
            .OnDelete(DeleteBehavior.SetNull);

        // Mehsul ile Kateqoriya arasinda elaqe
        modelBuilder.Entity<Mehsul>()
            .HasOne(m => m.Kateqoriya)
            .WithMany(k => k.Mehsullar)
            .HasForeignKey(m => m.KateqoriyaId)
            .OnDelete(DeleteBehavior.SetNull);

        // Mehsul ile Brend arasinda elaqe
        modelBuilder.Entity<Mehsul>()
            .HasOne(m => m.Brend)
            .WithMany(b => b.Mehsullar)
            .HasForeignKey(m => m.BrendId)
            .OnDelete(DeleteBehavior.SetNull);

        // Mehsul ile Tedarukcu arasinda elaqe
        modelBuilder.Entity<Mehsul>()
            .HasOne(m => m.Tedarukcu)
            .WithMany()
            .HasForeignKey(m => m.TedarukcuId)
            .OnDelete(DeleteBehavior.SetNull);

        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        var adminRolu = new Rol { Id = 1, Ad = "Admin" };
        var kassirRolu = new Rol { Id = 2, Ad = "Kassir" };
        modelBuilder.Entity<Rol>().HasData(adminRolu, kassirRolu);

        var adminIstifadeci = new Istifadeci
        {
            Id = 1,
            IstifadeciAdi = "admin",
            ParolHash = "$2a$11$wvv2PHlk9LWlv4vuz3eEBl.ynUDwxFQSIHWle5nHfS3sL7hTkTQPG", 
            TamAd = "Sistem Administratoru",
            RolId = adminRolu.Id
        };
        modelBuilder.Entity<Istifadeci>().HasData(adminIstifadeci);

        modelBuilder.Entity<Mehsul>().HasData(
            new Mehsul { Id = 1, Ad = "Çörək", StokKodu = "SK001", Barkod = "869000000001", PerakendeSatisQiymeti = 0.70m, AlisQiymeti = 0.50m, MovcudSay = 100, OlcuVahidi = OlcuVahidi.Ədəd },
            new Mehsul { Id = 2, Ad = "Süd 1L", StokKodu = "SK002", Barkod = "869000000002", PerakendeSatisQiymeti = 2.50m, AlisQiymeti = 2.00m, MovcudSay = 50, OlcuVahidi = OlcuVahidi.Litr },
            new Mehsul { Id = 3, Ad = "Yumurta (10 ədəd)", StokKodu = "SK003", Barkod = "869000000003", PerakendeSatisQiymeti = 3.20m, AlisQiymeti = 2.80m, MovcudSay = 200, OlcuVahidi = OlcuVahidi.Paket }
           );

        // Sample employee data
        modelBuilder.Entity<Isci>().HasData(
            new Isci 
            { 
                Id = 1, 
                TamAd = "Əli Məmmədov", 
                DogumTarixi = new DateTime(1990, 5, 15),
                TelefonNomresi = "+994501234567",
                Unvan = "Bakı şəh., Nərimanov r-nu, Sədərək m/s",
                Email = "ali.mammadov@example.com",
                IseBaslamaTarixi = new DateTime(2020, 1, 15),
                Maas = 1200.00m,
                Vezife = "Kassir",
                Departament = "Satış",
                Status = IsciStatusu.Aktiv,
                SvsNo = "AZE12345678",
                QeydiyyatUnvani = "Bakı şəh., Nərimanov r-nu",
                BankMəlumatları = "IBAN: AZ12NABZ0000000012345678"
            },
            new Isci 
            { 
                Id = 2, 
                TamAd = "Nərgiz Quliyeva", 
                DogumTarixi = new DateTime(1992, 8, 22),
                TelefonNomresi = "+994552345678",
                Unvan = "Bakı şəh., Xətai r-nu, Mərdəkan m/s",
                Email = "nargiz.quliyeva@example.com",
                IseBaslamaTarixi = new DateTime(2019, 3, 10),
                Maas = 1500.00m,
                Vezife = "Menecer",
                Departament = "İdarəetmə",
                Status = IsciStatusu.Aktiv,
                SvsNo = "AZE87654321",
                QeydiyyatUnvani = "Bakı şəh., Xətai r-nu",
                BankMəlumatları = "IBAN: AZ87NABZ0000000087654321"
            }
        );

        // Sample supplier data
        modelBuilder.Entity<Tedarukcu>().HasData(
            new Tedarukcu 
            { 
                Id = 1, 
                Ad = "Ənənəvi Bakery", 
                Voen = "1234567890",
                Unvan = "Bakı şəh., Nəsimi r-nu, Cavid prospekti 45",
                Telefon = "+994123456789",
                Email = "info@enanavi-bakery.az",
                BankHesabi = "IBAN: AZ12NABZ0000000012345678",
                Aktivdir = true
            },
            new Tedarukcu 
            { 
                Id = 2, 
                Ad = "Fresh Dairy Products", 
                Voen = "0987654321",
                Unvan = "Sumqayıt şəh., Sənaye rayonu, Zavod küçəsi 12",
                Telefon = "+994181234567",
                Email = "orders@fresh-dairy.az",
                BankHesabi = "IBAN: AZ87NABZ0000000087654321",
                Aktivdir = true
            }
        );

        // Kateqoriya və Brend nümunə məlumatları
        modelBuilder.Entity<Kateqoriya>().HasData(
            new Kateqoriya { Id = 1, Ad = "Qida Məhsulları", Tesvir = "Yemək və içki məhsulları", Aktivdir = true },
            new Kateqoriya { Id = 2, Ad = "Təmizlik Vasitələri", Tesvir = "Ev təmizliyi üçün vasitələr", Aktivdir = true },
            new Kateqoriya { Id = 3, Ad = "Şəxsi Gigiyena", Tesvir = "Şəxsi gigiyena məhsulları", Aktivdir = true }
        );

        modelBuilder.Entity<Brend>().HasData(
            new Brend { Id = 1, Ad = "Ənənəvi", Olke = "Azərbaycan", Vebsayt = "www.enanevi.az", Tesvir = "Yerli brend", Aktivdir = true },
            new Brend { Id = 2, Ad = "Fresh", Olke = "Azərbaycan", Vebsayt = "www.fresh.az", Tesvir = "Təzə məhsullar", Aktivdir = true },
            new Brend { Id = 3, Ad = "CleanHome", Olke = "Almaniya", Vebsayt = "www.cleanhome.de", Tesvir = "Təmizlik vasitələri", Aktivdir = true }
        );
    }
}