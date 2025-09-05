// Fayl: AzAgroPOS.Verilenler/Realizasialar/UnitOfWork.cs
namespace AzAgroPOS.Verilenler.Realizasialar;

using System.Threading.Tasks;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Varliglar;

/// <summary>
/// UnitOfWork sinifi, verilənlər bazası əməliyyatlarını idarə etmək üçün istifadə olunur.
/// İUnitOfWork nümunəsi yaradıldıqda, bütün repozitoriyalar üçün instansiyalar yaradılır və verilənlər bazası əməliyyatları üçün vahid nöqtə təmin edilir.
/// diqət: Bu sinif, verilənlər bazası əməliyyatlarını vahid bir tranzaksiya altında idarə etməyə imkan verir.
/// qeyd: Bu sinif, IDisposable interfeysini implementasiya edir və verilənlər bazası kontekstini düzgün şəkildə sərbəst buraxır.
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    /// <summary>
    /// AzAgroPOSDbContext nümunəsi, verilənlər bazası əməliyyatlarını həyata keçirmək üçün istifadə olunur.
    /// qeyd: Bu kontekst, verilənlər bazası bağlantısını və digər konfiqurasiyaları ehtiva edir.
    /// </summary>
    private readonly AzAgroPOSDbContext _kontekst;

    // Repozitorilərin instansiyaları
    /// <summary>
    /// Məhsul Repozitorisi - Məhsul əməliyyatlarını idarə edir.
    /// diqət: Bu repozitoriya məhsul məlumatlarını, satış qiymətlərini və stok kodlarını idarə edir.
    /// qeyd: Məhsul yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirir.
    /// </summary>
    public IMehsulRepozitori Mehsullar { get; private set; }
    /// <summary>
    /// Müştəri Repozitorisi - Müştəri əməliyyatlarını idarə edir.
    /// diqət: Bu repozitoriya müştəri məlumatlarını, borc əməliyyatlarını və müştəri axtarışını idarə edir.
    /// qeyd: Müştəri yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirir.
    /// </summary>
    public IMusteriRepozitori Musteriler { get; private set; }
    /// <summary>
    /// Satış Repozitorisi - Satış əməliyyatlarını idarə edir.
    /// diqət: Bu repozitoriya satış əməliyyatlarını, satış detalları və müştəri borc əməliyyatlarını idarə edir.
    /// qeyd: Satış yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirir.
    /// </summary>
    public ISatisRepozitori Satislar { get; private set; }
    /// <summary>
    /// İstifadəçi Repozitorisi - İstifadəçi əməliyyatlarını idarə edir.
    /// diqət: Bu repozitoriya istifadəçi məlumatlarını, rollarını və parollarını idarə edir.
    /// qeyd: İstifadəçi yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirir.
    /// </summary>
    public IIstifadeciRepozitori Istifadeciler { get; private set; }
    /// <summary>
    /// Rol Repozitorisi - Rol əməliyyatlarını idarə edir.
    /// diqət: Bu repozitoriya istifadəçi rollarını idarə edir və yeni rollar əlavə etməyə imkan verir.
    /// qeyd: Rol yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirir.
    /// </summary>
    public IRolRepozitori Rollar { get; private set; }
    /// <summary>
    /// Nisye Hərəkəti Repozitorisi - Nisye əməliyyatlarını idarə edir.
    /// Diqqət: Bu repozitoriya müştəri borc və ödəniş əməliyyatlarını idarə edir.
    /// Qeyd: Müştəri borc əməliyyatlarını yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirir.
    /// </summary>
    public INisyeHereketiRepozitori NisyeHereketleri { get; private set; }
    /// <summary>
    /// Təmir Sifarişləri Repozitorisi - Texniki xidmət və təmir sifarişlərini idarə edir.
    /// Diqət: Bu repozitoriya təmir sifarişlərinin yaradılması, axtarılması və silinməsi əməliyyatlarını idarə edir.
    /// Qeyd: Təmir sifarişləri, təmir detalları və texniki xidmət tarixçəsini idarə edir.
    /// </summary>
    public ITemirRepozitori TemirSifarisleri { get; private set; }
    /// <summary>
    /// Novbə Repozitorisi - Novbə əməliyyatlarını idarə edir.
    /// Diqət: Bu repozitoriya növbə açma, bağlama və aktiv növbəni gətirmə əməliyyatlarını idarə edir.
    /// Qeyd: Növbə açma, bağlama və aktiv növbəni axtarma əməliyyatlarını həyata keçirir.
    /// </summary>
    public INovbeRepozitori Novbeler { get; private set; }

    /// <summary>
    /// İşçi Repozitorisi - İşçi əməliyyatlarını idarə edir.
    /// Diqqət: Bu repozitoriya işçilərin məlumatlarını idarə edir.
    /// Qeyd: İşçi yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirir.
    /// </summary>
    public IIsciRepozitori Isciler { get; private set; }

    /// <summary>
    /// İşçi Performans Repozitorisi - İşçi performans əməliyyatlarını idarə edir.
    /// Diqqət: Bu repozitoriya işçilərin performans qeydlərini idarə edir.
    /// Qeyd: Performans qeydi yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirir.
    /// </summary>
    public IIsciPerformansRepozitori IsciPerformanslari { get; private set; }

    /// <summary>
    /// İşçi İzn Repozitorisi - İşçi məzuniyyət/icazə əməliyyatlarını idarə edir.
    /// Diqqət: Bu repozitoriya işçilərin məzuniyyət/icazə qeydlərini idarə edir.
    /// Qeyd: İzn qeydi yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirir.
    /// </summary>
    public IIsciIzniRepozitori IsciIznleri { get; private set; }

    /// <summary>
    /// Tədarükçü Repozitorisi - Tədarükçü əməliyyatlarını idarə edir.
    /// Diqqət: Bu repozitoriya tədarükçülərin məlumatlarını idarə edir.
    /// Qeyd: Tədarükçü yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirir.
    /// </summary>
    public ITedarukcuRepozitori Tedarukculer { get; private set; }

    /// <summary>
    /// Alış Sifarişi Repozitorisi - Alış sifarişi əməliyyatlarını idarə edir.
    /// Diqqət: Bu repozitoriya alış sifarişlərinin məlumatlarını idarə edir.
    /// Qeyd: Alış sifarişi yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirir.
    /// </summary>
    public IAlisSifarisRepozitori AlisSifarisleri { get; private set; }

    /// <summary>
    /// Alış Sifarişi Sətiri Repozitorisi - Alış sifarişi sətirləri əməliyyatlarını idarə edir.
    /// Diqqət: Bu repozitoriya alış sifarişi sətirlərinin məlumatlarını idarə edir.
    /// Qeyd: Alış sifarişi sətiri yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirir.
    /// </summary>
    public IAlisSifarisSetiriRepozitori AlisSifarisSetirleri { get; private set; }

    /// <summary>
    /// Alış Sənədi Repozitorisi - Alış sənədi əməliyyatlarını idarə edir.
    /// Diqqət: Bu repozitoriya alış sənədlərinin məlumatlarını idarə edir.
    /// Qeyd: Alış sənədi yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirir.
    /// </summary>
    public IAlisSenedRepozitori AlisSenetleri { get; private set; }

    /// <summary>
    /// Alış Sənədi Sətiri Repozitorisi - Alış sənədi sətirləri əməliyyatlarını idarə edir.
    /// Diqqət: Bu repozitoriya alış sənədi sətirlərinin məlumatlarını idarə edir.
    /// Qeyd: Alış sənədi sətiri yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirir.
    /// </summary>
    public IAlisSenedSetiriRepozitori AlisSenedSetirleri { get; private set; }

    /// <summary>
    /// Tədarükçü Ödənişi Repozitorisi - Tədarükçü ödəniş əməliyyatlarını idarə edir.
    /// Diqqət: Bu repozitoriya tədarükçü ödənişlərinin məlumatlarını idarə edir.
    /// Qeyd: Tədarükçü ödənişi yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirir.
    /// </summary>
    public ITedarukcuOdemeRepozitori TedarukcuOdemeleri { get; private set; }

    /// <summary>
    /// unitOfWork konstruktoru, verilənlər bazası kontekstini qəbul edir və repozitoriyaların instansiyalarını yaradır.
    /// Diqqət: Bu konstruktor, verilənlər bazası kontekstini bazaya ötürür.
    /// Qeyd: Bu konstruktor, konkret varlıq repozitoriyaları üçün istifadə olunur.
    /// </summary>
    /// <param name="kontekst"></param>
    public UnitOfWork(AzAgroPOSDbContext kontekst)
    {
        _kontekst = kontekst;

        // Repozitoriləri yaradırıq
        Mehsullar = new MehsulRepozitori(_kontekst);
        Musteriler = new MusteriRepozitori(_kontekst);
        Satislar = new SatisRepozitori(_kontekst);
        Istifadeciler = new IstifadeciRepozitori(_kontekst);
        Rollar = new RolRepozitori(_kontekst);
        NisyeHereketleri = new NisyeHereketiRepozitori(_kontekst);
        TemirSifarisleri = new TemirRepozitori(_kontekst);
        Novbeler = new NovbeRepozitori(_kontekst);
        Isciler = new IsciRepozitori(_kontekst);
        IsciPerformanslari = new IsciPerformansRepozitori(_kontekst);
        IsciIznleri = new IsciIzniRepozitori(_kontekst);
        Tedarukculer = new TedarukcuRepozitori(_kontekst);
        AlisSifarisleri = new AlisSifarisRepozitori(_kontekst);
        AlisSifarisSetirleri = new AlisSifarisSetiriRepozitori(_kontekst);
        AlisSenetleri = new AlisSenedRepozitori(_kontekst);
        AlisSenedSetirleri = new AlisSenedSetiriRepozitori(_kontekst);
        TedarukcuOdemeleri = new TedarukcuOdemeRepozitori(_kontekst);
    }
    /// <summary>
    /// EMELIYYATI TƏSDİQLƏ metod, edilmiş bütün dəyişiklikləri vahid bir tranzaksiya kimi verilənlər bazasına tətbiq edir.
    /// Dəyişikliklər uğurla tətbiq olunarsa, təsdiqlənir; əks halda, ləğv edilir.
    /// Qeyd: Bu metod asinxron olaraq işləyir və təsirlənən sətirlərin sayını qaytarır.
    /// </summary>
    /// <returns></returns>
    public async Task<int> EmeliyyatiTesdiqleAsync()
    {
        return await _kontekst.SaveChangesAsync();
    }

    /// <summary>
    /// DisposeAsync metodu, verilənlər bazası kontekstini asinxron şəkildə sərbəst buraxır.
    /// Diqqət: Bu metod, IDisposable interfeysinin implementasiyasıdır.
    /// Qeyd: Bu metod, verilənlər bazası kontekstinin düzgün şəkildə bağlanmasını təmin edir.
    /// </summary>
    /// <returns></returns>
    public async ValueTask DisposeAsync()
    {
        await _kontekst.DisposeAsync();
    }
}