// Fayl: AzAgroPOS.Verilenler/Kontekst/AzAgroPOSDbContext.cs
namespace AzAgroPOS.Verilenler.Kontekst;

using AzAgroPOS.Varliglar;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

/// <summary>
/// AzAgroPOS tətbiqinin verilənlər bazası kontekstini təmsil edir.
/// bu sinif Entity Framework Core istifadə edərək verilənlər bazası əməliyyatlarını idarə edir.
/// Diqqət: Bu kontekst, verilənlər bazası cədvəlləri ilə əlaqəli varlıqları və onların konfiqurasiyalarını ehtiva edir.
/// Qeyd: Verilənlər bazası bağlantı sətri (connection string) və digər konfiqurasiyalar burada təyin olunur.
/// </summary>
public class AzAgroPOSDbContext : DbContext
{
    // Hər bir varlıq üçün DbSet təyin edirik. Bunlar verilənlər bazasındakı cədvəlləri təmsil edəcək.
    /// <summary>
    /// Məhsul cədvəli - Məhsul varlıqlarını təmsil edir.
    /// Diqqət: Məhsul məlumatlarını, satış qiymətlərini və stok kodlarını ehtiva edir.
    /// Qeyd: Məhsul yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirmək üçün istifadə olunur.
    /// </summary>
    public DbSet<Mehsul> Mehsullar { get; set; }
    /// <summary>
    /// Müştəri cədvəli - Müştəri varlıqlarını təmsil edir.
    /// Diqqət: Müştəri məlumatlarını, borc əməliyyatlarını və müştəri axtarışını ehtiva edir.
    /// Qeyd: Müştəri yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirmək üçün istifadə olunur.
    /// </summary>
    public DbSet<Musteri> Musteriler { get; set; }
    /// <summary>
    /// Satış cədvəli - Satış varlıqlarını təmsil edir.
    /// Diqqət: Satış əməliyyatlarını, satış detalları və müştəri borc əməliyyatlarını ehtiva edir.
    /// Qeyd: Satış yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirmək üçün istifadə olunur.
    /// </summary>
    public DbSet<Satis> Satislar { get; set; }
    /// <summary>
    /// Satış Detalları cədvəli - Satış detalları varlıqlarını təmsil edir.
    /// Diqqət: Hər bir satış əməliyyatının detallı məlumatlarını ehtiva edir.
    /// Qeyd: Satış detalları yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirmək üçün istifadə olunur.
    /// </summary>
    public DbSet<SatisDetali> SatisDetallari { get; set; }
    /// <summary>
    /// İstifadəçi cədvəli - İstifadəçi varlıqlarını təmsil edir.
    /// Diqqət: İstifadəçi məlumatlarını, rollarını və parollarını ehtiva edir.
    /// Qeyd: İstifadəçi yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirmək üçün istifadə olunur.
    /// </summary>
    public DbSet<Istifadeci> Istifadeciler { get; set; }
    /// <summary>
    /// Rol cədvəli - Rol varlıqlarını təmsil edir.
    /// Diqqət: İstifadəçi rollarını ehtiva edir və yeni rollar əlavə etməyə imkan verir.
    /// Qeyd: Rol yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirmək üçün istifadə olunur.
    /// </summary>
    public DbSet<Rol> Rollar { get; set; }
    /// <summary>
    /// Nisyə Hərəkəti cədvəli - Müştəri borc əməliyyatlarını təmsil edir.
    /// Diqqət: Müştəri borc və ödəniş əməliyyatlarını ehtiva edir.
    /// Qeyd: Müştəri borc əməliyyatlarını yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirmək üçün istifadə olunur.
    /// </summary>
    public DbSet<NisyeHereketi> NisyeHereketleri { get; set; }
    /// <summary>
    /// Təmir Sifarişləri cədvəli - Texniki xidmət və təmir sifarişlərini təmsil edir.
    /// Diqqət: Təmir sifarişlərinin yaradılması, axtarılması və silinməsi əməliyyatlarını ehtiva edir.
    /// </summary>
    public DbSet<Temir> TemirSifarisleri { get; set; }
    /// <summary>
    /// Növbə cədvəli - Növbə əməliyyatlarını təmsil edir.
    /// Diqqət: Növbə açma, bağlama və aktiv növbəni gətirmə əməliyyatlarını ehtiva edir.
    /// Qeyd: Növbə açma, bağlama və aktiv növbəni axtarma əməliyyatlarını həyata keçirmək üçün istifadə olunur.
    /// </summary>
    public DbSet<Novbe> Novbeler { get; set; }

    //public DbSet<TemirMerhelesi> TemirMerheleleri { get; set; }


    /// <summary>
    /// OnConfiguring metodu, verilənlər bazası bağlantı sətrini və digər konfiqurasiyaları təyin etmək üçün istifadə olunur.
    /// Diqqət: Bu metod, DbContext-in necə konfiqurasiya olunacağını müəyyən edir.
    /// Qeyd: Bağlantı sətri (connection string) burada təyin olunur, lakin təhlükəsizlik səbəbi ilə onu birbaşa kodda saxlamaq tövsiyə edilmir. Əvəzinə, konfiqurasiya faylında və ya mühit dəyişənlərində saxlamaq daha yaxşıdır.
    /// </summary>
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Verilənlər bazasına qoşulma sətrini (connection string) burada təyin edirik.
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=MURADOV-TAHMAZ\\TAHMAZ_MURADOV;Database=AzAgroPOS_DB;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }

    /// <summary>
    /// OnModelCreating metodu, verilənlər bazası modellərinin konfiqurasiyasını təyin etmək üçün istifadə olunur.
    /// Diqqət: Bu metod, varlıqların cədvəl strukturlarını, əlaqələrini və digər konfiqurasiyalarını müəyyən edir.
    /// Qeyd: Burada, məsələn, decimal tipli sahələrin dəqiqliyini təyin etmək, əlaqələri qurmaq və başlanğıc məlumatları əlavə etmək kimi əməliyyatlar həyata keçirilir.
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Bütün decimal property-lər üçün konfiqurasiyalar
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

        
        modelBuilder.Entity<Istifadeci>().HasOne(i => i.Rol).WithMany(r => r.Istifadeciler).HasForeignKey(i => i.RolId);
        modelBuilder.Entity<Temir>().HasOne(t => t.Isci).WithMany(i => i.TemirSifarisleri).HasForeignKey(t => t.IsciId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Satis>().HasOne(s => s.Novbe).WithMany(n => n.Satislar).HasForeignKey(s => s.NovbeId).OnDelete(DeleteBehavior.Restrict);

        
        SeedData(modelBuilder);
    }
    /// <summary>
    /// SeedData metodu, verilənlər bazasına başlanğıc (initial) məlumatları əlavə etmək üçün istifadə olunur.
    /// Diqqət: Bu metod, tətbiq ilk dəfə işə salındıqda və ya verilənlər bazası yaradıldıqda lazım olan ilkin məlumatları təmin edir.
    /// Qeyd: Burada, məsələn, admin istifadəçisi, rollar və nümunə məhsullar kimi məlumatlar əlavə olunur.
    /// ADMIN istifadəçi üçün parol "admin123" olaraq təyin olunub və BCrypt ilə hash-lənib.
    /// </summary>
    /// <param name="modelBuilder"></param>
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
            ParolHash = "$2a$11$wvv2PHlk9LWlv4vuz3eEBl.ynUDwxFQSIHWle5nHfS3sL7hTkTQPG",
            TamAd = "Sistem Administratoru",
            RolId = adminRolu.Id
        };
        modelBuilder.Entity<Istifadeci>().HasData(adminIstifadeci);
        
        // 3. Bir neçə nümunə məhsul yarat
        modelBuilder.Entity<Mehsul>().HasData(
            new Mehsul { Id = 1, Ad = "Çörək", StokKodu = "SK001", Barkod = "869000000001", PerakendeSatisQiymeti = 0.70m, AlisQiymeti = 0.50m, MovcudSay = 100, OlcuVahidi = OlcuVahidi.Ədəd },
            new Mehsul { Id = 2, Ad = "Süd 1L", StokKodu = "SK002", Barkod = "869000000002", PerakendeSatisQiymeti = 2.50m, AlisQiymeti = 2.00m, MovcudSay = 50, OlcuVahidi = OlcuVahidi.Litr },
            new Mehsul { Id = 3, Ad = "Yumurta (10 ədəd)", StokKodu = "SK003", Barkod = "869000000003", PerakendeSatisQiymeti = 3.20m, AlisQiymeti = 2.80m, MovcudSay = 200, OlcuVahidi = OlcuVahidi.Paket }
         );
    }
}