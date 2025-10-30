// Fayl: AzAgroPOS.Verilenler/Interfeysler/IUnitOfWork.cs
namespace AzAgroPOS.Verilenler.Interfeysler;

using System;

/// <summary>
/// Verilənlər bazası ilə bütün əməliyyatları vahid bir tranzaksiya altında idarə edir.
/// Repozitorilərə müraciəti təmin edir və dəyişiklikləri yaddaşa yazır.
/// </summary>
public interface IUnitOfWork : IAsyncDisposable
{
    /// <summary>
    /// Hazırda sistemdə aktiv olan istifadəçinin ID-si
    /// Audit jurnalı qeydləri üçün istifadə olunur
    /// </summary>
    int AktivIstifadeciId { get; set; }

    /// <summary>
    /// Aktiv istifadəçi ID-sini təyin edir
    /// </summary>
    /// <param name="istifadeciId">Aktiv istifadəçinin ID-si</param>
    void AktivIstifadeciniTeyinEt(int istifadeciId);
    /// <summary>
    /// Məhsul Repozitorisi - Məhsul əməliyyatlarını idarə edir.
    /// diqqət: Bu repozitoriya məhsul məlumatlarını, satış qiymətlərini və stok kodlarını idarə edir.
    /// qeyd: Məhsul yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirir.
    /// </summary>
    IMehsulRepozitori Mehsullar { get; }
    /// <summary>
    /// müştəri Repozitorisi - Müştəri əməliyyatlarını idarə edir.
    /// diqqət: Bu repozitoriya müştəri məlumatlarını, borc əməliyyatlarını və müştəri axtarışını idarə edir.
    /// qeyd: Müştəri yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirir.
    /// </summary>
    IMusteriRepozitori Musteriler { get; }
    /// <summary>
    /// Satis Repozitorisi - Satış əməliyyatlarını idarə edir.
    /// diqqət: Bu repozitoriya satış əməliyyatlarını, satış detalları və müştəri borc əməliyyatlarını idarə edir.
    /// qeyd: Satış yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirir.
    /// </summary>
    ISatisRepozitori Satislar { get; }
    /// <summary>
    /// İstifadəçi Repozitorisi - İstifadəçi əməliyyatlarını idarə edir.
    /// diqqət: Bu repozitoriya istifadəçi məlumatlarını, rollarını və parollarını idarə edir.
    /// qeyd: İstifadəçi yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirir.
    /// </summary>
    IIstifadeciRepozitori Istifadeciler { get; }
    /// <summary>
    /// Rol Repozitorisi - Rol əməliyyatlarını idarə edir.
    /// diqqət: Bu repozitoriya istifadəçi rollarını idarə edir və yeni rollar əlavə etməyə imkan verir.
    /// qeyd: Rol yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirir.
    /// </summary>
    IRolRepozitori Rollar { get; }
    /// <summary>
    /// Nisye Hərəkəti Repozitorisi - Nisye əməliyyatlarını idarə edir.
    /// diqqət: Bu repozitoriya müştəri borc və ödəniş əməliyyatlarını idarə edir.
    /// qeyd: Müştəri borc əməliyyatlarını yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirir.
    /// </summary>
    INisyeHereketiRepozitori NisyeHereketleri { get; }
    /// <summary>
    /// Təmir Sifarişləri Repozitorisi - Texniki xidmət və təmir sifarişlərini idarə edir.
    /// diqqət: Bu repozitoriya təmir sifarişlərinin yaradılması, axtarışı və silinməsi əməliyyatlarını idarə edir.
    /// qeyd: Təmir sifarişləri, təmir detalları və texniki xidmət tarixçəsini idarə edir.
    /// </summary>
    ITemirRepozitori TemirSifarisleri { get; }
    /// <summary>
    /// Novbə Repozitorisi - Novbə əməliyyatlarını idarə edir.
    /// diqqət: Bu repozitoriya növbə açma, bağlama və aktiv növbəni gətirmə əməliyyatlarını idarə edir.
    /// qeyd: Növbə açma, bağlama və aktiv növbəni axtarma əməliyyatlarını həyata keçirir.
    /// </summary>
    INovbeRepozitori Novbeler { get; }

    /// <summary>
    /// İşçi Repozitorisi - İşçi əməliyyatlarını idarə edir.
    /// diqqət: Bu repozitoriya işçilərin məlumatlarını, maaşlarını və işçi statusunu idarə edir.
    /// qeyd: İşçi yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirir.
    /// </summary>
    IIsciRepozitori Isciler { get; }

    /// <summary>
    /// İşçi Performans Repozitorisi - İşçi performans əməliyyatlarını idarə edir.
    /// diqqət: Bu repozitoriya işçilərin performans qeydlərini idarə edir və yeni performans qeydləri əlavə etməyə imkan verir.
    /// qeyd: Performans qeydi yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirir.
    /// </summary>
    IIsciPerformansRepozitori IsciPerformanslari { get; }

    /// <summary>
    /// İşçi İzn Repozitorisi - İşçi məzuniyyət/icazə əməliyyatlarını idarə edir.
    /// Diqqət: Bu repozitoriya işçilərin məzuniyyət/icazə qeydlərini idarə edir və yeni məzuniyyət/icazə qeydləri əlavə etməyə imkan verir.
    /// Qeyd: Məzuniyyət/icazə qeydi yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirir.
    /// </summary>
    IIsciIzniRepozitori IsciIznleri { get; }

    /// <summary>
    /// Tədarükçü Repozitorisi - Tədarükçü əməliyyatlarını idarə edir.
    /// Diqqət: Bu repozitoriya tədarükçülərin məlumatlarını idarə edir.
    /// Qeyd: Tədarükçü yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirir.
    /// </summary>
    ITedarukcuRepozitori Tedarukculer { get; }

    /// <summary>
    /// Alış Sifarişi Repozitorisi - Alış sifarişi əməliyyatlarını idarə edir.
    /// Diqqət: Bu repozitoriya alış sifarişlərinin məlumatlarını idarə edir.
    /// Qeyd: Alış sifarişi yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirir.
    /// </summary>
    IAlisSifarisRepozitori AlisSifarisleri { get; }

    /// <summary>
    /// Alış Sifarişi Sətiri Repozitorisi - Alış sifarişi sətirləri əməliyyatlarını idarə edir.
    /// Diqqət: Bu repozitoriya alış sifarişi sətirlərinin məlumatlarını idarə edir.
    /// Qeyd: Alış sifarişi sətiri yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirir.
    /// </summary>
    IAlisSifarisSetiriRepozitori AlisSifarisSetirleri { get; }

    /// <summary>
    /// Alış Sənədi Repozitorisi - Alış sənədi əməliyyatlarını idarə edir.
    /// Diqqət: Bu repozitoriya alış sənədlərinin məlumatlarını idarə edir.
    /// Qeyd: Alış sənədi yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirir.
    /// </summary>
    IAlisSenedRepozitori AlisSenetleri { get; }

    /// <summary>
    /// Alış Sənədi Sətiri Repozitorisi - Alış sənədi sətirləri əməliyyatlarını idarə edir.
    /// Diqqət: Bu repozitoriya alış sənədi sətirlərinin yaradılması, axtarış, yeniləmə və silinmə əməliyyatlarını idarə edir.
    /// Qeyd: Alış sənədi sətiri yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirir.
    /// </summary>
    IAlisSenedSetiriRepozitori AlisSenedSetirleri { get; }

    /// <summary>
    /// Tədarükçü Ödənişi Repozitorisi - Tədarükçü ödəniş əməliyyatlarını idarə edir.
    /// Diqqət: Bu repozitoriya tədarükçü ödənişlərinin yaradılması, axtarış, yeniləmə və silinmə əməliyyatlarını idarə edir.
    /// Qeyd: Tədarükçü ödənişi yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirir.
    /// </summary>
    ITedarukcuOdemeRepozitori TedarukcuOdemeleri { get; }

    /// <summary>
    /// Kateqoriya Repozitorisi - Kateqoriya əməliyyatlarını idarə edir.
    /// Diqqət: Bu repozitoriya məhsul kateqoriyalarını idarə edir.
    /// Qeyd: Kateqoriya yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirir.
    /// </summary>
    IKateqoriyaRepozitori Kateqoriyalar { get; }

    /// <summary>
    /// Brend Repozitorisi - Brend əməliyyatlarını idarə edir.
    /// Diqqət: Bu repozitoriya məhsul brendlərini idarə edir.
    /// Qeyd: Brend yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirir.
    /// </summary>
    IBrendRepozitori Brendler { get; }

    /// <summary>
    /// Qaytarma Repozitorisi - Qaytarma əməliyyatlarını idarə edir.
    /// Diqqət: Bu repozitoriya qaytarma məlumatlarını idarə edir.
    /// Qeyd: Qaytarma yaratma, axtarış, yeniləmə və silmə əməliyyatlarını həyata keçirir.
    /// </summary>
    IQaytarmaRepozitori Qaytarmalar { get; }

    /// <summary>
    /// Əməliyyat Jurnalı Repozitorisi - Audit jurnalı əməliyyatlarını idarə edir.
    /// Diqqət: Bu repozitoriya verilənlər bazasında edilən əməliyyatların jurnalını saxlayır.
    /// Qeyd: Audit jurnalı qeydlərinin yaradılması, axtarışı və silinməsi əməliyyatlarını həyata keçirir.
    /// </summary>
    IEmeliyyatJurnaliRepozitori EmeliyyatJurnallari { get; }

    /// <summary>
    /// Konfiqurasiya Repozitorisi - Tətbiqat konfiqurasiya parametrlərini idarə edir.
    /// Diqqət: Bu repozitoriya tətbiqatın konfiqurasiya parametrlərini saxlayır və idarə edir.
    /// Qeyd: Konfiqurasiya parametrlərinin yaradılması, axtarışı, yenilənməsi və silinməsi əməliyyatlarını həyata keçirir.
    /// </summary>
    IKonfiqurasiyaRepozitori Konfiqurasiyalar { get; }

    /// <summary>
    /// İcazə Repozitorisi - İstifadəçilərin ayrı-ayrı icazələrini idarə edir.
    /// Diqqət: Bu repozitoriya sistemdə mövcud olan icazələri saxlayır və idarə edir.
    /// Qeyd: İcazələrin yaradılması, axtarışı, yenilənməsi və silinməsi əməliyyatlarını həyata keçirir.
    /// </summary>
    IIcazeRepozitori Icazeler { get; }

    /// <summary>
    /// Rol İcazəsi Repozitorisi - Rollar və icazələr arasında əlaqələri idarə edir.
    /// Diqqət: Bu repozitoriya rolların sahib olduğu icazələri saxlayır və idarə edir.
    /// Qeyd: Rol-icazə əlaqələrinin yaradılması, axtarışı, yenilənməsi və silinməsi əməliyyatlarını həyata keçirir.
    /// </summary>
    IRolIcazesiRepozitori RolIcazeleri { get; }

    /// <summary>
    /// Xərc Repozitorisi - Xərc əməliyyatlarını idarə edir.
    /// Diqqət: Bu repozitoriya şirkətin xərc qeydiyyatlarını saxlayır və idarə edir.
    /// Qeyd: Xərc qeydiyyatlarının yaradılması, axtarışı, yenilənməsi və silinməsi əməliyyatlarını həyata keçirir.
    /// </summary>
    IXercRepozitori Xercler { get; }

    /// <summary>
    /// Kassa Hərəkəti Repozitorisi - Kassa hərəkətlərini idarə edir.
    /// Diqqət: Bu repozitoriya kassadakı gəlir və xərc hərəkətlərini saxlayır və idarə edir.
    /// Qeyd: Kassa hərəkətlərinin yaradılması, axtarışı, yenilənməsi və silinməsi əməliyyatlarını həyata keçirir.
    /// </summary>
    IKassaHareketiRepozitori KassaHareketleri { get; }

    /// <summary>
    /// Əmək Haqqı Repozitorisi - Əmək haqqı əməliyyatlarını idarə edir.
    /// Diqqət: Bu repozitoriya işçilərin əmək haqqı qeydlərini saxlayır və idarə edir.
    /// Qeyd: Əmək haqqı qeydlərinin yaradılması, axtarışı, yenilənməsi və silinməsi əməliyyatlarını həyata keçirir.
    /// </summary>
    IEmekHaqqiRepozitori EmekHaqqilari { get; }

    /// <summary>
    /// Müştəri Bonus Repozitorisi - Müştəri bonus/loyallıq proqramını idarə edir.
    /// Diqqət: Bu repozitoriya müştərilərin toplam, istifadə edilmiş və mövcud ballarını saxlayır.
    /// Qeyd: Müştəri bonus qeydlərinin yaradılması, axtarışı, yenilənməsi və silinməsi əməliyyatlarını həyata keçirir.
    /// </summary>
    IMusteriBonusRepozitori MusteriBonuslari { get; }

    /// <summary>
    /// Bonus Qeydi Repozitorisi - Müştəri bonus tarixçəsini idarə edir.
    /// Diqqət: Bu repozitoriya müştərilərin bal qazanma və istifadə tarixçəsini saxlayır.
    /// Qeyd: Bonus qeydi əlavə etmə, axtarma və silmə əməliyyatlarını həyata keçirir.
    /// </summary>
    IBonusQeydiRepozitori BonusQeydleri { get; }

    /// <summary>
    /// Edilmiş bütün dəyişiklikləri vahid bir tranzaksiya kimi verilənlər bazasına tətbiq edir.
    /// dəyişikliklər uğurla tətbiq olunarsa, təsdiqlənir; əks halda, ləğv edilir.
    /// Bu metod asinxron olaraq işləyir və təsirlənən sətirlərin sayını qaytarır.
    /// diqqət: Əgər heç bir dəyişiklik edilməyibsə, 0 qaytarır.
    /// qeyd: Bu metod bütün repozitorilərdəki dəyişiklikləri birləşdirərək, verilənlər bazasında atomik əməliyyatlar həyata keçirir.
    /// </summary>
    /// <returns>Təsirlənən sətirlərin sayı.</returns>
    Task<int> EmeliyyatiTesdiqleAsync();
}