// Fayl: AzAgroPOS.Verilenler/Kontekst/AzAgroPOSDbContext.cs
namespace AzAgroPOS.Verilenler.Kontekst;

using AzAgroPOS.Varliglar;
using AzAgroPOS.Varliglar.Interfeysler;
using Microsoft.EntityFrameworkCore;

public class AzAgroPOSDbContext : DbContext
{
    private int? _currentUserId;

    public AzAgroPOSDbContext(DbContextOptions<AzAgroPOSDbContext> options) : base(options)
    {
        //Database.EnsureCreated(); // Verilənlər bazasının yaradılmasını təmin edir
    }

    /// <summary>
    /// Cari istifadəçinin ID-sini təyin edir (audit üçün)
    /// Bu metod, UnitOfWork tərəfindən çağırılır
    /// </summary>
    public void SetCurrentUser(int? userId)
    {
        _currentUserId = userId;
    }

    public override int SaveChanges()
    {
        UpdateAuditFields();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateAuditFields();
        return base.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Audit sahələrini avtomatik doldurur
    /// </summary>
    private void UpdateAuditFields()
    {
        var entries = ChangeTracker.Entries<IAuditableEntity>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.YaradilmaTarixi = DateTime.Now;
                entry.Entity.YaradanIstifadeciId = _currentUserId;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.DeyisdirilmeTarixi = DateTime.Now;
                entry.Entity.DeyisdirenIstifadeciId = _currentUserId;
            }
        }
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
    public DbSet<Qaytarma> Qaytarmalar { get; set; } // Əlavə edildi
    public DbSet<QaytarmaDetali> QaytarmaDetallari { get; set; } // Əlavə edildi
    public DbSet<EmeliyyatJurnali> EmeliyyatJurnallari { get; set; } // Əlavə edildi
    public DbSet<Konfiqurasiya> Konfiqurasiyalar { get; set; } // Əlavə edildi
    public DbSet<Icaze> Icazeler { get; set; } // Əlavə edildi
    public DbSet<RolIcazesi> RolIcazeleri { get; set; } // Əlavə edildi
    public DbSet<StokHareketi> StokHareketleri { get; set; } // Əlavə edildi - Anbar stok hərəkətləri
    public DbSet<Xerc> Xercler { get; set; } // Əlavə edildi - Xərc qeydləri
    public DbSet<KassaHareketi> KassaHareketleri { get; set; } // Əlavə edildi - Kassa hərəkətləri
    public DbSet<EmekHaqqi> EmekHaqqilari { get; set; } // Əlavə edildi - Əmək haqqı qeydləri
    public DbSet<MusteriBonus> MusteriBonuslari { get; set; } // Əlavə edildi - Müştəri bonus/loyallıq proqramı
    public DbSet<BonusQeydi> BonusQeydleri { get; set; } // Əlavə edildi - Bonus tarixçəsi
    public DbSet<IstifadeciSessiyasi> IstifadeciSessiyalari { get; set; } // Əlavə edildi - İstifadəçi sessiyaları
    public DbSet<GirisLoquKaydi> GirisLoquKaydlari { get; set; } // Əlavə edildi - Giriş audit loqu

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Mehsul>().Property(m => m.PerakendeSatisQiymeti).HasColumnType("decimal(18, 2)");
        modelBuilder.Entity<Mehsul>().Property(m => m.TopdanSatisQiymeti).HasColumnType("decimal(18, 2)");
        modelBuilder.Entity<Mehsul>().Property(m => m.TekEdedSatisQiymeti).HasColumnType("decimal(18, 2)");
        modelBuilder.Entity<Mehsul>().Property(m => m.AlisQiymeti).HasColumnType("decimal(18, 2)");
        modelBuilder.Entity<Satis>().Property(s => s.UmumiMebleg).HasColumnType("decimal(18, 2)");
        modelBuilder.Entity<SatisDetali>().Property(sd => sd.Qiymet).HasColumnType("decimal(18, 2)");
        modelBuilder.Entity<SatisDetali>().Property(sd => sd.Miqdar).HasColumnType("decimal(18, 3)");
        modelBuilder.Entity<SatisDetali>().Property(sd => sd.UmumiMebleg).HasColumnType("decimal(18, 2)");
        modelBuilder.Entity<Musteri>().Property(m => m.UmumiBorc).HasColumnType("decimal(18, 2)");
        modelBuilder.Entity<Musteri>().Property(m => m.KreditLimiti).HasColumnType("decimal(18, 2)");
        modelBuilder.Entity<Temir>().Property(t => t.TemirXerci).HasColumnType("decimal(18, 2)");
        modelBuilder.Entity<Temir>().Property(t => t.YekunMebleg).HasColumnType("decimal(18, 2)");
        modelBuilder.Entity<Temir>().Property(t => t.ServisHaqqi).HasColumnType("decimal(18, 2)");
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
        modelBuilder.Entity<AlisSenedSetiri>().Property(a => a.Miqdar).HasColumnType("decimal(18, 3)");
        modelBuilder.Entity<TedarukcuOdeme>().Property(t => t.Mebleg).HasColumnType("decimal(18, 2)");

        // Configure Silinib property for all entities
        modelBuilder.Entity<Mehsul>().Property(m => m.Silinib).HasDefaultValue(false);
        modelBuilder.Entity<Musteri>().Property(m => m.Silinib).HasDefaultValue(false);
        modelBuilder.Entity<Satis>().Property(s => s.Silinib).HasDefaultValue(false);
        modelBuilder.Entity<SatisDetali>().Property(sd => sd.Silinib).HasDefaultValue(false);
        modelBuilder.Entity<Istifadeci>().Property(i => i.Silinib).HasDefaultValue(false);
        modelBuilder.Entity<Rol>().Property(r => r.Silinib).HasDefaultValue(false);
        modelBuilder.Entity<NisyeHereketi>().Property(nh => nh.Silinib).HasDefaultValue(false);
        modelBuilder.Entity<Temir>().Property(t => t.Silinib).HasDefaultValue(false);
        modelBuilder.Entity<Novbe>().Property(n => n.Silinib).HasDefaultValue(false);
        modelBuilder.Entity<Isci>().Property(i => i.Silinib).HasDefaultValue(false);
        modelBuilder.Entity<IsciPerformans>().Property(ip => ip.Silinib).HasDefaultValue(false);
        modelBuilder.Entity<IsciIzni>().Property(ii => ii.Silinib).HasDefaultValue(false);
        modelBuilder.Entity<Tedarukcu>().Property(t => t.Silinib).HasDefaultValue(false);
        modelBuilder.Entity<AlisSifaris>().Property(asif => asif.Silinib).HasDefaultValue(false);
        modelBuilder.Entity<AlisSifarisSetiri>().Property(ass => ass.Silinib).HasDefaultValue(false);
        modelBuilder.Entity<AlisSifarisSetiri>().Property(ass => ass.Miqdar).HasColumnType("decimal(18, 3)");
        modelBuilder.Entity<AlisSifarisSetiri>().Property(ass => ass.TehvilAlinanMiqdar).HasColumnType("decimal(18, 3)");
        modelBuilder.Entity<AlisSened>().Property(asen => asen.Silinib).HasDefaultValue(false);
        modelBuilder.Entity<AlisSenedSetiri>().Property(assen => assen.Silinib).HasDefaultValue(false);
        modelBuilder.Entity<AlisSenedSetiri>().Property(assen => assen.Miqdar).HasColumnType("decimal(18, 3)");
        modelBuilder.Entity<TedarukcuOdeme>().Property(to => to.Silinib).HasDefaultValue(false);
        modelBuilder.Entity<Kateqoriya>().Property(k => k.Silinib).HasDefaultValue(false);
        modelBuilder.Entity<Brend>().Property(b => b.Silinib).HasDefaultValue(false);
        modelBuilder.Entity<Qaytarma>().Property(q => q.Silinib).HasDefaultValue(false);
        modelBuilder.Entity<Qaytarma>().Property(q => q.UmumiMebleg).HasColumnType("decimal(18, 2)");
        modelBuilder.Entity<QaytarmaDetali>().Property(qd => qd.Silinib).HasDefaultValue(false);
        modelBuilder.Entity<QaytarmaDetali>().Property(qd => qd.Miqdar).HasColumnType("decimal(18, 3)");
        modelBuilder.Entity<QaytarmaDetali>().Property(qd => qd.Qiymet).HasColumnType("decimal(18, 2)");
        modelBuilder.Entity<QaytarmaDetali>().Property(qd => qd.UmumiMebleg).HasColumnType("decimal(18, 2)");
        modelBuilder.Entity<EmeliyyatJurnali>().Property(ej => ej.Silinib).HasDefaultValue(false);
        modelBuilder.Entity<Konfiqurasiya>().Property(k => k.Silinib).HasDefaultValue(false);
        modelBuilder.Entity<Icaze>().Property(i => i.Silinib).HasDefaultValue(false);
        modelBuilder.Entity<RolIcazesi>().Property(ri => ri.Silinib).HasDefaultValue(false);
        modelBuilder.Entity<StokHareketi>().Property(sh => sh.Silinib).HasDefaultValue(false);

        modelBuilder.Entity<RolIcazesi>()
            .HasOne(ri => ri.Rol)
            .WithMany(r => r.Icazeler)
            .HasForeignKey(ri => ri.RolId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<RolIcazesi>()
            .HasOne(ri => ri.Icaze)
            .WithMany(i => i.Rollar)
            .HasForeignKey(ri => ri.IcazeId)
            .OnDelete(DeleteBehavior.Cascade);

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

        // Qaytarma ile Satis arasinda elaqe
        modelBuilder.Entity<Qaytarma>()
            .HasOne(q => q.Satis)
            .WithMany(s => s.Qaytarmalar)
            .HasForeignKey(q => q.SatisId)
            .OnDelete(DeleteBehavior.Restrict);

        // Qaytarma ile Kassir (Istifadeci) arasinda elaqe
        modelBuilder.Entity<Qaytarma>()
            .HasOne(q => q.Kassir)
            .WithMany()
            .HasForeignKey(q => q.KassirId)
            .OnDelete(DeleteBehavior.Restrict);

        // QaytarmaDetali ile Qaytarma arasinda elaqe
        modelBuilder.Entity<QaytarmaDetali>()
            .HasOne(qd => qd.Qaytarma)
            .WithMany(q => q.QaytarmaDetallari)
            .HasForeignKey(qd => qd.QaytarmaId)
            .OnDelete(DeleteBehavior.Cascade);

        // QaytarmaDetali ile Mehsul arasinda elaqe
        modelBuilder.Entity<QaytarmaDetali>()
            .HasOne(qd => qd.Mehsul)
            .WithMany()
            .HasForeignKey(qd => qd.MehsulId)
            .OnDelete(DeleteBehavior.Restrict);

        // Rol və İcazə arasında çoxdan-çoxa əlaqə
        modelBuilder.Entity<RolIcazesi>()
            .HasOne(ri => ri.Rol)
            .WithMany(r => r.Icazeler)
            .HasForeignKey(ri => ri.RolId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<RolIcazesi>()
            .HasOne(ri => ri.Icaze)
            .WithMany(i => i.Rollar)
            .HasForeignKey(ri => ri.IcazeId)
            .OnDelete(DeleteBehavior.Cascade);

        // StokHareketi konfiqurasiyası
        modelBuilder.Entity<StokHareketi>()
            .HasOne(sh => sh.Mehsul)
            .WithMany()
            .HasForeignKey(sh => sh.MehsulId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<StokHareketi>()
            .HasOne(sh => sh.Istifadeci)
            .WithMany()
            .HasForeignKey(sh => sh.IstifadeciId)
            .OnDelete(DeleteBehavior.SetNull);

        // Decimal precision konfiqurasiyası
        modelBuilder.Entity<StokHareketi>()
            .Property(sh => sh.AlisQiymeti)
            .HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<StokHareketi>()
            .Property(sh => sh.SatisQiymeti)
            .HasColumnType("decimal(18, 2)");

        // StokHareketi üçün indexlər - performans üçün vacibdir
        modelBuilder.Entity<StokHareketi>()
            .HasIndex(sh => sh.MehsulId)
            .HasDatabaseName("IX_StokHareketi_MehsulId");

        modelBuilder.Entity<StokHareketi>()
            .HasIndex(sh => sh.Tarix)
            .HasDatabaseName("IX_StokHareketi_Tarix");

        modelBuilder.Entity<StokHareketi>()
            .HasIndex(sh => new { sh.SenedNovu, sh.SenedId })
            .HasDatabaseName("IX_StokHareketi_Sened");

        // Xerc konfiqurasiyası
        modelBuilder.Entity<Xerc>()
            .Property(x => x.Mebleg).HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<Xerc>()
            .HasOne(x => x.Istifadeci)
            .WithMany()
            .HasForeignKey(x => x.IstifadeciId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Xerc>()
            .Property(x => x.Silinib).HasDefaultValue(false);

        // KassaHareketi konfiqurasiyası
        modelBuilder.Entity<KassaHareketi>()
            .Property(kh => kh.Mebleg).HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<KassaHareketi>()
            .HasOne(kh => kh.Istifadeci)
            .WithMany()
            .HasForeignKey(kh => kh.IstifadeciId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<KassaHareketi>()
            .Property(kh => kh.Silinib).HasDefaultValue(false);

        // Xerc üçün indexlər
        modelBuilder.Entity<Xerc>()
            .HasIndex(x => x.Tarix)
            .HasDatabaseName("IX_Xerc_Tarix");

        modelBuilder.Entity<Xerc>()
            .HasIndex(x => x.Novu)
            .HasDatabaseName("IX_Xerc_Novu");

        // KassaHareketi üçün indexlər
        modelBuilder.Entity<KassaHareketi>()
            .HasIndex(kh => kh.Tarix)
            .HasDatabaseName("IX_KassaHareketi_Tarix");

        modelBuilder.Entity<KassaHareketi>()
            .HasIndex(kh => new { kh.EmeliyyatNovu, kh.EmeliyyatId })
            .HasDatabaseName("IX_KassaHareketi_Emeliyyat");

        // EmekHaqqi konfiqurasiyası
        modelBuilder.Entity<EmekHaqqi>()
            .Property(eh => eh.EsasMaas).HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<EmekHaqqi>()
            .Property(eh => eh.Bonuslar).HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<EmekHaqqi>()
            .Property(eh => eh.ElaveOdenisler).HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<EmekHaqqi>()
            .Property(eh => eh.IcazeTutulmasi).HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<EmekHaqqi>()
            .Property(eh => eh.DigerTutulmalar).HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<EmekHaqqi>()
            .HasOne(eh => eh.Isci)
            .WithMany(i => i.EmekHaqqiQeydleri)
            .HasForeignKey(eh => eh.IsciId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<EmekHaqqi>()
            .Property(eh => eh.Silinib).HasDefaultValue(false);

        // EmekHaqqi üçün indexlər
        modelBuilder.Entity<EmekHaqqi>()
            .HasIndex(eh => eh.IsciId)
            .HasDatabaseName("IX_EmekHaqqi_IsciId");

        modelBuilder.Entity<EmekHaqqi>()
            .HasIndex(eh => eh.Dovr)
            .HasDatabaseName("IX_EmekHaqqi_Dovr");

        modelBuilder.Entity<EmekHaqqi>()
            .HasIndex(eh => eh.Status)
            .HasDatabaseName("IX_EmekHaqqi_Status");

        // MusteriBonus konfiqurasiyası
        modelBuilder.Entity<MusteriBonus>()
            .Property(mb => mb.ToplamBal).HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<MusteriBonus>()
            .Property(mb => mb.IstifadeEdilmisBal).HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<MusteriBonus>()
            .HasOne(mb => mb.Musteri)
            .WithOne()
            .HasForeignKey<MusteriBonus>(mb => mb.MusteriId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<MusteriBonus>()
            .Property(mb => mb.Silinib).HasDefaultValue(false);

        modelBuilder.Entity<MusteriBonus>()
            .HasIndex(mb => mb.MusteriId)
            .HasDatabaseName("IX_MusteriBonus_MusteriId")
            .IsUnique();

        // BonusQeydi konfiqurasiyası
        modelBuilder.Entity<BonusQeydi>()
            .Property(bq => bq.BalMiqdari).HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<BonusQeydi>()
            .HasOne(bq => bq.MusteriBonus)
            .WithMany(mb => mb.BonusQeydleri)
            .HasForeignKey(bq => bq.MusteriBonusId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BonusQeydi>()
            .HasOne(bq => bq.Satis)
            .WithMany()
            .HasForeignKey(bq => bq.SatisId)
            .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<BonusQeydi>()
            .Property(bq => bq.Silinib).HasDefaultValue(false);

        modelBuilder.Entity<BonusQeydi>()
            .HasIndex(bq => bq.MusteriBonusId)
            .HasDatabaseName("IX_BonusQeydi_MusteriBonusId");

        modelBuilder.Entity<BonusQeydi>()
            .HasIndex(bq => bq.EmeliyyatTarixi)
            .HasDatabaseName("IX_BonusQeydi_EmeliyyatTarixi");

        // ================== PHASE 1: CRITICAL INDEXES ==================
        // Performance optimization indexes for frequently accessed fields
        // Added: 2025-11-06 - Task 11: Database Index Optimization

        // Musteri indexes - High-frequency customer searches
        modelBuilder.Entity<Musteri>()
            .HasIndex(m => m.TamAd)
            .HasDatabaseName("IX_Musteri_TamAd");

        modelBuilder.Entity<Musteri>()
            .HasIndex(m => m.TelefonNomresi)
            .HasDatabaseName("IX_Musteri_TelefonNomresi");

        modelBuilder.Entity<Musteri>()
            .HasIndex(m => m.UmumiBorc)
            .HasDatabaseName("IX_Musteri_UmumiBorc");

        // Mehsul indexes - Critical for product search and POS operations
        modelBuilder.Entity<Mehsul>()
            .HasIndex(m => m.Ad)
            .HasDatabaseName("IX_Mehsul_Ad");

        modelBuilder.Entity<Mehsul>()
            .HasIndex(m => m.Barkod)
            .HasDatabaseName("IX_Mehsul_Barkod");

        modelBuilder.Entity<Mehsul>()
            .HasIndex(m => m.StokKodu)
            .HasDatabaseName("IX_Mehsul_StokKodu");

        modelBuilder.Entity<Mehsul>()
            .HasIndex(m => m.Aktivdir)
            .HasDatabaseName("IX_Mehsul_Aktivdir");

        modelBuilder.Entity<Mehsul>()
            .HasIndex(m => m.KateqoriyaId)
            .HasDatabaseName("IX_Mehsul_KateqoriyaId");

        modelBuilder.Entity<Mehsul>()
            .HasIndex(m => m.BrendId)
            .HasDatabaseName("IX_Mehsul_BrendId");

        // Composite index for pagination + filtering (high-value optimization)
        modelBuilder.Entity<Mehsul>()
            .HasIndex(m => new { m.Aktivdir, m.Id })
            .HasDatabaseName("IX_Mehsul_Aktivdir_Id");

        // Istifadeci indexes - Authentication and user management
        modelBuilder.Entity<Istifadeci>()
            .HasIndex(i => i.IstifadeciAdi)
            .IsUnique()
            .HasDatabaseName("IX_Istifadeci_IstifadeciAdi");

        modelBuilder.Entity<Istifadeci>()
            .HasIndex(i => i.HesabAktivdir)
            .HasDatabaseName("IX_Istifadeci_HesabAktivdir");

        modelBuilder.Entity<Istifadeci>()
            .HasIndex(i => i.RolId)
            .HasDatabaseName("IX_Istifadeci_RolId");

        modelBuilder.Entity<Istifadeci>()
            .HasIndex(i => i.SonGirisTarixi)
            .HasDatabaseName("IX_Istifadeci_SonGirisTarixi");

        // Satis indexes - High-volume sales operations
        modelBuilder.Entity<Satis>()
            .HasIndex(s => s.Tarix)
            .HasDatabaseName("IX_Satis_Tarix");

        modelBuilder.Entity<Satis>()
            .HasIndex(s => s.NovbeId)
            .HasDatabaseName("IX_Satis_NovbeId");

        modelBuilder.Entity<Satis>()
            .HasIndex(s => s.MusteriId)
            .HasDatabaseName("IX_Satis_MusteriId");

        modelBuilder.Entity<Satis>()
            .HasIndex(s => s.OdenisMetodu)
            .HasDatabaseName("IX_Satis_OdenisMetodu");

        modelBuilder.Entity<Satis>()
            .HasIndex(s => s.Silinib)
            .HasDatabaseName("IX_Satis_Silinib");

        // Composite index for date range + filtering queries (covering index)
        modelBuilder.Entity<Satis>()
            .HasIndex(s => new { s.Silinib, s.Tarix, s.MusteriId })
            .HasDatabaseName("IX_Satis_Silinib_Tarix_MusteriId");

        // Novbe indexes - Shift management (critical for POS operations)
        modelBuilder.Entity<Novbe>()
            .HasIndex(n => new { n.IsciId, n.Status })
            .HasDatabaseName("IX_Novbe_IsciId_Status");

        modelBuilder.Entity<Novbe>()
            .HasIndex(n => n.Status)
            .HasDatabaseName("IX_Novbe_Status");

        // Isci indexes - Employee search and filtering
        modelBuilder.Entity<Isci>()
            .HasIndex(i => i.TamAd)
            .HasDatabaseName("IX_Isci_TamAd");

        modelBuilder.Entity<Isci>()
            .HasIndex(i => i.Status)
            .HasDatabaseName("IX_Isci_Status");

        // Composite index for search + filter operations
        modelBuilder.Entity<Isci>()
            .HasIndex(i => new { i.Silinib, i.Status, i.TamAd })
            .HasDatabaseName("IX_Isci_Silinib_Status_TamAd");

        // ================== PHASE 2: HIGH PRIORITY INDEXES ==================

        // SatisDetali indexes - Product lookup in sales
        modelBuilder.Entity<SatisDetali>()
            .HasIndex(sd => sd.MehsulId)
            .HasDatabaseName("IX_SatisDetali_MehsulId");

        modelBuilder.Entity<SatisDetali>()
            .HasIndex(sd => sd.Silinib)
            .HasDatabaseName("IX_SatisDetali_Silinib");

        // Tedarukcu indexes - Supplier search
        modelBuilder.Entity<Tedarukcu>()
            .HasIndex(t => t.Ad)
            .HasDatabaseName("IX_Tedarukcu_Ad");

        modelBuilder.Entity<Tedarukcu>()
            .HasIndex(t => t.Aktivdir)
            .HasDatabaseName("IX_Tedarukcu_Aktivdir");

        // AlisSifaris indexes - Purchase order management
        modelBuilder.Entity<AlisSifaris>()
            .HasIndex(a => a.TedarukcuId)
            .HasDatabaseName("IX_AlisSifaris_TedarukcuId");

        modelBuilder.Entity<AlisSifaris>()
            .HasIndex(a => a.YaradilmaTarixi)
            .HasDatabaseName("IX_AlisSifaris_YaradilmaTarixi");

        modelBuilder.Entity<AlisSifaris>()
            .HasIndex(a => a.Silinib)
            .HasDatabaseName("IX_AlisSifaris_Silinib");

        // AlisSened indexes
        modelBuilder.Entity<AlisSened>()
            .HasIndex(a => a.YaradilmaTarixi)
            .HasDatabaseName("IX_AlisSened_YaradilmaTarixi");

        // IsciPerformans & IsciIzni indexes
        modelBuilder.Entity<IsciPerformans>()
            .HasIndex(ip => ip.IsciId)
            .HasDatabaseName("IX_IsciPerformans_IsciId");

        modelBuilder.Entity<IsciIzni>()
            .HasIndex(ii => ii.IsciId)
            .HasDatabaseName("IX_IsciIzni_IsciId");

        modelBuilder.Entity<IsciIzni>()
            .HasIndex(ii => ii.BaslamaTarixi)
            .HasDatabaseName("IX_IsciIzni_BaslamaTarixi");

        // Qaytarma indexes - Return operations
        modelBuilder.Entity<Qaytarma>()
            .HasIndex(q => q.SatisId)
            .HasDatabaseName("IX_Qaytarma_SatisId");

        modelBuilder.Entity<Qaytarma>()
            .HasIndex(q => q.Tarix)
            .HasDatabaseName("IX_Qaytarma_Tarix");

        modelBuilder.Entity<Qaytarma>()
            .HasIndex(q => q.KassirId)
            .HasDatabaseName("IX_Qaytarma_KassirId");

        modelBuilder.Entity<QaytarmaDetali>()
            .HasIndex(qd => qd.MehsulId)
            .HasDatabaseName("IX_QaytarmaDetali_MehsulId");

        // ================== PHASE 3: MEDIUM PRIORITY INDEXES ==================

        // Xerc additional indexes
        modelBuilder.Entity<Xerc>()
            .HasIndex(x => x.IstifadeciId)
            .HasDatabaseName("IX_Xerc_IstifadeciId");

        // KassaHareketi additional indexes
        modelBuilder.Entity<KassaHareketi>()
            .HasIndex(kh => kh.IstifadeciId)
            .HasDatabaseName("IX_KassaHareketi_IstifadeciId");

        // NisyeHereketi indexes - Debt tracking
        modelBuilder.Entity<NisyeHereketi>()
            .HasIndex(nh => nh.MusteriId)
            .HasDatabaseName("IX_NisyeHereketi_MusteriId");

        modelBuilder.Entity<NisyeHereketi>()
            .HasIndex(nh => nh.Tarix)
            .HasDatabaseName("IX_NisyeHereketi_Tarix");

        // Kateqoriya & Brend indexes
        modelBuilder.Entity<Kateqoriya>()
            .HasIndex(k => k.Ad)
            .HasDatabaseName("IX_Kateqoriya_Ad");

        modelBuilder.Entity<Kateqoriya>()
            .HasIndex(k => k.Aktivdir)
            .HasDatabaseName("IX_Kateqoriya_Aktivdir");

        modelBuilder.Entity<Brend>()
            .HasIndex(b => b.Ad)
            .HasDatabaseName("IX_Brend_Ad");

        modelBuilder.Entity<Brend>()
            .HasIndex(b => b.Aktivdir)
            .HasDatabaseName("IX_Brend_Aktivdir");

        // GirisLoquKaydi indexes - Audit trail
        modelBuilder.Entity<GirisLoquKaydi>()
            .HasIndex(gl => gl.IstifadeciAdi)
            .HasDatabaseName("IX_GirisLoquKaydi_IstifadeciAdi");

        modelBuilder.Entity<GirisLoquKaydi>()
            .HasIndex(gl => gl.CehdTarixi)
            .HasDatabaseName("IX_GirisLoquKaydi_CehdTarixi");

        // IstifadeciSessiyasi indexes - Session management
        modelBuilder.Entity<IstifadeciSessiyasi>()
            .HasIndex(sess => sess.IstifadeciId)
            .HasDatabaseName("IX_IstifadeciSessiyasi_IstifadeciId");

        modelBuilder.Entity<IstifadeciSessiyasi>()
            .HasIndex(sess => sess.BaslamaTarixi)
            .HasDatabaseName("IX_IstifadeciSessiyasi_BaslamaTarixi");

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

        // Standart icazələr
        modelBuilder.Entity<Icaze>().HasData(
            new Icaze { Id = 1, Ad = "CanDeleteSale", Tesvir = "Satış silmək imkanı" },
            new Icaze { Id = 2, Ad = "CanGiveDiscount", Tesvir = "Endirim tətbiq etmək imkanı" },
            new Icaze { Id = 3, Ad = "CanViewReports", Tesvir = "Hesabatları görmək imkanı" },
            new Icaze { Id = 4, Ad = "CanManageProducts", Tesvir = "Məhsulları idarə etmək imkanı" },
            new Icaze { Id = 5, Ad = "CanManageUsers", Tesvir = "İstifadəçiləri idarə etmək imkanı" }
        );

        // Admin rolu üçün bütün icazələr
        modelBuilder.Entity<RolIcazesi>().HasData(
            new RolIcazesi { Id = 1, RolId = 1, IcazeId = 1 },
            new RolIcazesi { Id = 2, RolId = 1, IcazeId = 2 },
            new RolIcazesi { Id = 3, RolId = 1, IcazeId = 3 },
            new RolIcazesi { Id = 4, RolId = 1, IcazeId = 4 },
            new RolIcazesi { Id = 5, RolId = 1, IcazeId = 5 }
        );
    }
}