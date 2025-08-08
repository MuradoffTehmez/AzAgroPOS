// Fayl: AzAgroPOS.Verilenler/Kontekst/AzAgroPOSDbContext.cs
namespace AzAgroPOS.Verilenler.Kontekst;

using AzAgroPOS.Varliglar;
using Microsoft.EntityFrameworkCore;

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


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Verilənlər bazasına qoşulma sətrini (connection string) burada təyin edirik.
        // **DİQQƏT:** Bu sətri öz SQL Server konfiqurasiyanıza uyğun dəyişin!
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=MURADOV-TAHMAZ\\TAHMAZ_MURADOV;Database=AzAgroPOS_DB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Model konfiqurasiyaları (pul vahidləri üçün dəqiqlik)
        modelBuilder.Entity<Mehsul>()
            .Property(m => m.SatisQiymeti)
            .HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<Mehsul>()
            .Property(m => m.AlisQiymeti)
            .HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<Satis>()
            .Property(s => s.UmumiMebleg)
            .HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<SatisDetali>()
            .Property(sd => sd.Qiymet)
            .HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<Musteri>()
            .Property(m => m.UmumiBorc)
            .HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<Temir>()
            .Property(t => t.TemirXerci)
            .HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<Temir>()
            .Property(t => t.YekunMebleg)
            .HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<NisyeHereketi>()
            .Property(n => n.Mebleg)
            .HasColumnType("decimal(18, 2)");

        // 1. Rol və Istifadeci arasındakı əlaqə:
        modelBuilder.Entity<Istifadeci>()
            .HasOne(i => i.Rol)               // Hər Istifadeci-nin bir Rol-u var.
            .WithMany(r => r.Istifadeciler)   // Hər Rol-un isə çox Istifadeci-si var (Rol sinfindəki kolleksiya).
            .HasForeignKey(i => i.RolId);     // Xarici açar Istifadeci.RolId-dir.

        // 2. Temir və Istifadeci arasındakı əlaqə:
        modelBuilder.Entity<Temir>()
            .HasOne(t => t.Isci)              // Hər Təmirin bir İşçisi var.
            .WithMany(i => i.TemirSifarisleri) // Bu işçinin "TemirSifarisleri" kolleksiyasına aiddir.
            .HasForeignKey(t => t.IsciId)     // Xarici açar Temir.IsciId-dir.
            .OnDelete(DeleteBehavior.Restrict); // Vacib: Bir işçini silsək, ona bağlı təmir sifarişləri silinməsin.


        // İlkin məlumatların (Seed Data) əlavə edilməsi
        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        // 1. Rolları yarat
        var adminRolu = new Rol { Id = 1, Ad = "Admin" };
        var kassirRolu = new Rol { Id = 2, Ad = "Kassir" };
        modelBuilder.Entity<Rol>().HasData(adminRolu, kassirRolu);

        // 2. Admin istifadəçisini yarat
        // DİQQƏT: Əsl tətbiqdə parol mütləq BCrypt kimi alqoritmlə hash-lənməlidir!
        // Bu nümunədə sadəlik üçün "12345" parolu hash-lənmiş kimi saxlanılır.
        var adminIstifadeci = new Istifadeci
        {
            Id = 1,
            IstifadeciAdi = "admin",
            ParolHash = "admin_parolu_hash_formatinda_olmalidir", //TODO: Hashing implementasiyası
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