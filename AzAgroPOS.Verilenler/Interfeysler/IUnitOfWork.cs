// Fayl: AzAgroPOS.Verilenler/Interfeysler/IUnitOfWork.cs
namespace AzAgroPOS.Verilenler.Interfeysler;

/// <summary>
/// Verilənlər bazası ilə bütün əməliyyatları vahid bir tranzaksiya altında idarə edir.
/// Repozitorilərə müraciəti təmin edir və dəyişiklikləri yaddaşa yazır.
/// </summary>
public interface IUnitOfWork : IAsyncDisposable
{
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
    /// diqqət: Bu repozitoriya təmir sifarişlərinin yaradılması, axtarılması və silinməsi əməliyyatlarını idarə edir.
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
    /// Edilmiş bütün dəyişiklikləri vahid bir tranzaksiya kimi verilənlər bazasına tətbiq edir.
    /// dəyişikliklər uğurla tətbiq olunarsa, təsdiqlənir; əks halda, ləğv edilir.
    /// Bu metod asinxron olaraq işləyir və təsirlənən sətirlərin sayını qaytarır.
    /// diqqət: Əgər heç bir dəyişiklik edilməyibsə, 0 qaytarır.
    /// qeyd: Bu metod bütün repozitorilərdəki dəyişiklikləri birləşdirərək, verilənlər bazasında atomik əməliyyatlar həyata keçirir.
    /// </summary>
    /// <returns>Təsirlənən sətirlərin sayı.</returns>
    Task<int> EmeliyyatiTesdiqleAsync();
}