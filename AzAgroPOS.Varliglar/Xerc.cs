// Fayl: AzAgroPOS.Varliglar/Xerc.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Xərc növü və ya kateqoriyasını təyin edir
/// diqqət: Bu enum sistemə daxil olan bütün xərc növlərini təyin edir.
/// qeyd: Xərc növü, maliyyə hesabatlarında analiz üçün vacibdir.
/// </summary>
public enum XercNovu
{
    /// <summary>
    /// Əmək haqqı xərci
    /// </summary>
    EmekHaqqi = 1,
    
    /// <summary>
    /// Kommunal xərclər
    /// </summary>
    Kommunal = 2,
    
    /// <summary>
    /// Kirayə haqqı
    /// </summary>
    Kira = 3,
    
    /// <summary>
    /// Marketinq və reklam xərcləri
    /// </summary>
    Marketinq = 4,
    
    /// <summary>
    /// Təmir və saxlanma xərcləri
    /// </summary>
    TemirSaxlanma = 5,
    
    /// <summary>
    /// Ofis avadanlıqları xərci
    /// </summary>
    OfisAvadanliqi = 6,
    
    /// <summary>
    /// Nəqliyyat xərcləri
    /// </summary>
    Nenqliyyat = 7,
    
    /// <summary>
    /// Digər xərclər
    /// </summary>
    Diger = 99
}

/// <summary>
/// Xərc qeydlərini təmsil edən varlıq
/// diqqət: Bu varlıq, şirkətin həyata keçirdiyi xərc qeydlərini saxlayır.
/// qeyd: Bütün əsas və əlavə xərclər bu cədvəldə qeyd olunur.
/// rol: Maliyyə hesabatları və mənfəət/zərər analizləri üçün mühüm məlumat mənbəyidir.
/// </summary>
public class Xerc : BazaVarligi
{
    /// <summary>
    /// Xərcin növü (kategoriya)
    /// diqqət: Bu sahə, xərcin hansı kateqoriyaya aid olduğunu göstərir.
    /// qeyd: XercNovu enumundan bir dəyər alır.
    /// </summary>
    public XercNovu Novu { get; set; }

    /// <summary>
    /// Xərcin adı/təsviri
    /// diqqət: Bu sahə, xərcin məqsədini və ya nəyə aid olduğunu təsvir edir.
    /// qeyd: Məsələn, "Elektrik", "İşçilərə əmək haqqı", "Ofis kirayəsi" və s.
    /// </summary>
    public string? Ad { get; set; }

    /// <summary>
    /// Xərcin məbləği
    /// diqqət: Bu sahə, xərcin məbləğini saxlayır.
    /// qeyd: Məbləğ həmişə müsbət olmalıdır.
    /// </summary>
    public decimal Mebleg { get; set; }

    /// <summary>
    /// Xərcin baş verdiyi tarix
    /// diqqət: Bu sahə, xərcin həyata keçdiyi tarixi saxlayır.
    /// qeyd: Maliyyə hesabatları üçün vacibdir.
    /// </summary>
    public DateTime Tarix { get; set; }

    /// <summary>
    /// Xərcə aid sənəd nömrəsi (istəyə görə)
    /// diqqət: Bu sahə, xərc qeydiyyatı ilə əlaqəli sənəd nömrəsini saxlayır.
    /// qeyd: Məsələn, çeki nömrəsi, qəbzdəki nömrə və s.
    /// </summary>
    public string? SenedNomresi { get; set; }

    /// <summary>
    /// Xərcə aid qeyd
    /// diqqət: Bu sahə, xərc qeydiyyatı ilə bağlı əlavə məlumatları saxlayır.
    /// qeyd: Məsələn, əlavə izahatlar, ödəniş üsulu və s.
    /// </summary>
    public string? Qeyd { get; set; }

    /// <summary>
    /// Əməliyyatı həyata keçirən istifadəçinin ID-si
    /// diqqət: Bu sahə, hansı istifadəçinin bu xərc qeydiyyatını etdiyini göstərir.
    /// qeyd: İstifadeçi cədvəlinə foreign key.
    /// </summary>
    public int? IstifadeciId { get; set; }

    /// <summary>
    /// İstifadəçi navigasiya xassəsi
    /// diqqət: Bu navigasiya xassəsi, istifadəçi məlumatlarına asanlıqla çatmağa imkan verir.
    /// </summary>
    public Istifadeci? Istifadeci { get; set; }
}