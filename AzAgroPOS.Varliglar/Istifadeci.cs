// Fayl: AzAgroPOS.Varliglar/Istifadeci.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Sistemə daxil ola bilən istifadəçiləri (personalı) təmsil edir.
/// diqqət: Bu sinif, istifadəçi məlumatlarını və onların sistemdəki rolunu saxlayır.
/// qeyd: İstifadəçilər, sistemdəki fərqli rollara malik ola bilərlər, məsələn, kassir, menecer və s. Hər bir istifadəçi unikal bir istifadəçi adı və parol ilə sistemə daxil olur.
/// referans: Bu sinif, BazaVarligi sinifindən miras alır və hər bir istifadəçinin unikal identifikatorunu (ID) ehtiva edir.
/// </summary>
public class Istifadeci : BazaVarligi
{
    /// <summary>
    /// İstifadəçinin sistemə daxil olmaq üçün istifadə etdiyi ad.
    /// diqqət: Bu ad, istifadəçinin sistemdəki unikal identifikatorudur və giriş zamanı istifadə olunur.
    /// qeyd: İstifadəçi adı, sistemdəki hər bir istifadəçi üçün unikal olmalıdır, məsələn, "kassir123" və ya "menecer456". Bu ad, istifadəçinin sistemdəki fəaliyyətlərini izləmək və identifikasiya etmək üçün istifadə olunur.
    /// </summary>
    public string IstifadeciAdi { get; set; } = string.Empty;

    /// <summary>
    /// İstifadəçinin parolu. Təhlükəsizlik üçün hash formatında saxlanmalıdır.
    /// diqqət: Parol, istifadəçinin sistemə daxil olmaq üçün istifadə etdiyi gizli məlumatdır və təhlükəsizlik səbəbi ilə hash formatında saxlanmalıdır.
    /// qeyd: Parol, istifadəçinin sistemə girişini təmin edən və onun identifikasiyasını təsdiqləyən bir məlumatdır. Parolun təhlükəsizliyi üçün, onu hash formatında saxlamaq tövsiyə olunur, məsələn, "2b$12$KIX9Z5a1e8f3c4d5e6f7g8h9i0j1k2l3m4n5o6p7q8r9s0t1u2v3w4x5y6z" kimi. Bu, parolun açıq şəkildə saxlanılmasının qarşısını alır.
    /// </summary>
    public string ParolHash { get; set; } = string.Empty;

    /// <summary>
    /// İşçinin tam adı.
    /// diqqət: Bu, istifadəçinin sistemdəki tam adını təmsil edir və istifadəçi ilə əlaqəli məlumatları daha da dəqiqləşdirmək üçün istifadə olunur.
    /// qeyd: Tam ad, istifadəçinin adını və soyadını əhatə edir, məsələn, "Elvin Məmmədov". Bu məlumat, istifadəçinin sistemdəki fəaliyyətlərini daha da şəxsiyyətləşdirmək və identifikasiya etmək üçün istifadə olunur.
    /// </summary>
    public string TamAd { get; set; } = string.Empty;

    /// <summary>
    /// İstifadəçinin aid olduğu rolun ID-si.
    /// diqqət: Bu ID, istifadəçinin sistemdəki rolunu təyin edir və onun hansı hüquqlara malik olduğunu göstərir.
    /// qeyd: Rol ID-si, sistemdəki fərqli rolları təmsil edir, məsələn, kassir, menecer və s. Hər bir rol, istifadəçinin sistemdəki fəaliyyətlərini və hüquqlarını müəyyən edir. Məsələn, "1" - Kassir rolu, "2" - Menecer rolu və s. Bu ID, Rol sinifindəki unikal identifikator ilə əlaqələndirilir.
    /// </summary>
    public int RolId { get; set; }

    /// <summary>
    /// Naviqasiya xüsusiyyəti: İstifadəçinin rolu.
    /// diqqət: Bu, istifadəçinin sistemdəki rolunu təmsil edir və onun hüquqlarını və fəaliyyətlərini müəyyən edir.
    /// qeyd: Rol, istifadəçinin sistemdəki fəaliyyətlərini və hüquqlarını təyin edən bir obyekt ola bilər. Məsələn, "Kassir", "Menecer" və s. Hər bir rol, istifadəçinin sistemdəki fəaliyyətlərini və hüquqlarını müəyyən edir. Bu, Rol sinifindəki məlumatlarla əlaqələndirilir.
    /// </summary>
    public Rol? Rol { get; set; }

    /// <summary>
    /// Bu işçiyə təyin edilmiş təmir sifarişlərinin siyahısı.
    /// diqqət: Bu kolleksiya, istifadəçinin təmir sifarişləri ilə əlaqəli məlumatları saxlayır və istifadəçinin təmir prosesindəki rolunu göstərir.
    /// qeyd: İstifadəçi, təmir sifarişlərini idarə edə bilər və bu kolleksiya vasitəsilə ona təyin edilmiş bütün təmir sifarişlərini görə bilər. Məsələn, "Temir Sifarişi 1", "Temir Sifarişi 2" və s. Bu kolleksiya, Temir sinifindən olan obyektləri ehtiva edir və istifadəçinin təmir sifarişləri ilə əlaqəli məlumatları saxlayır.
    /// </summary>
    public ICollection<Temir> TemirSifarisleri { get; set; } = new List<Temir>();
}