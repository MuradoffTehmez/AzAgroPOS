// Fayl: AzAgroPOS.Verilenler/Kontekst/AzAgroPOSDbContext.cs
namespace AzAgroPOS.Verilenler.Kontekst;

using AzAgroPOS.Varliglar;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

public class AzAgroPOSDbContext : DbContext
{
    // Hər bir varlıq üçün DbSet təyin edirik. Bunlar verilənlər bazasındakı cədvəlləri təmsil edəcək.
    public DbSet<Mehsul> Mehsullar { get; set; }
    public DbSet<Musteri> Musteriler { get; set; }
    public DbSet<Satis> Satislar { get; set; }
    public DbSet<SatisDetali> SatisDetallari { get; set; }
    public DbSet<Istifadeci> Istifadeciler { get; set; }
    public DbSet<Rol> Rollar { get; set; }
    public DbSet<NisyeHereketi> NisyeHereketleri { get; set; }
    public DbSet<Temir> TemirSifarisleri { get; set; }
    public DbSet<Novbe> Novbeler { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Verilənlər bazasına qoşulma sətrini (connection string) burada təyin edirik.
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=MURADOV-TAHMAZ\\TAHMAZ_MURADOV;Database=AzAgroPOS_DB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Bütün decimal property-lər üçün konfiqurasiyalar
        modelBuilder.Entity<Mehsul>().Property(m => m.SatisQiymeti).HasColumnType("decimal(18, 2)");
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

        
        modelBuilder.Entity<Istifadeci>().HasOne(i => i.Rol).WithMany(r => r.Istifadeciler).HasForeignKey(i => i.RolId);
        modelBuilder.Entity<Temir>().HasOne(t => t.Isci).WithMany(i => i.TemirSifarisleri).HasForeignKey(t => t.IsciId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Satis>().HasOne(s => s.Novbe).WithMany(n => n.Satislar).HasForeignKey(s => s.NovbeId).OnDelete(DeleteBehavior.Restrict);

        
        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        // 1. Rolları yarat
        var adminRolu = new Rol { Id = 1, Ad = "Admin" };
        var kassirRolu = new Rol { Id = 2, Ad = "Kassir" };
        modelBuilder.Entity<Rol>().HasData(adminRolu, kassirRolu);

        // 2. Admin istifadəçisini yarat
        var adminIstifadeci = new Istifadeci
        {
            Id = 1,
            IstifadeciAdi = "admin",
            // DİQQƏT: Dinamik funksiya yerinə, statik hash-i birbaşa yazırıq
            ParolHash = "$2a$11$wvv2PHlk9LWlv4vuz3eEBl.ynUDwxFQSIHWle5nHfS3sL7hTkTQPG",
            TamAd = "Sistem Administratoru",
            RolId = adminRolu.Id
        };
        modelBuilder.Entity<Istifadeci>().HasData(adminIstifadeci);
        
        // 3. Bir neçə nümunə məhsul yarat
        modelBuilder.Entity<Mehsul>().HasData(
            new Mehsul { Id = 1, Ad = "Çörək", StokKodu = "SK001", Barkod = "869000000001", SatisQiymeti = 0.70m, AlisQiymeti = 0.50m, MovcudSay = 100 },
            new Mehsul { Id = 2, Ad = "Süd 1L", StokKodu = "SK002", Barkod = "869000000002", SatisQiymeti = 2.50m, AlisQiymeti = 2.00m, MovcudSay = 50 },
            new Mehsul { Id = 3, Ad = "Yumurta (10 ədəd)", StokKodu = "SK003", Barkod = "869000000003", SatisQiymeti = 3.20m, AlisQiymeti = 2.80m, MovcudSay = 200 }
        );
    }
}