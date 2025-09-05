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

        modelBuilder.Entity<Isci>()
            .HasOne(i => i.SistemIstifadecisi)
            .WithOne(si => si.Isci)
            .HasForeignKey<Istifadeci>(si => si.Id)
            .OnDelete(DeleteBehavior.Cascade);

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
    }
}