// Fayl: AzAgroPOS.Varliglar/XercNovu.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Xərc növü və ya kateqoriyasını təyin edir
/// diqqət: Bu enum sistemə daxil olan bütün xərc növlərini təyin edir.
/// qeyd: Xərc növü, maliyyə hesabatlarında analiz üçün vacibdir.
/// rol: Xərclərin kateqoriyalaşdırılması və analiz edilməsi üçün istifadə olunur.
/// </summary>
public enum XercNovu
{
    /// <summary>
    /// Əmək haqqı xərci
    /// diqqət: Bu növ işçilərə ödənilən əmək haqqını təyin edir.
    /// qeyd: Hər ay ödənilən maaşlar bu kateqoriyaya aiddir.
    /// </summary>
    EmekHaqqi = 1,

    /// <summary>
    /// Kommunal xərclər
    /// diqqət: Bu növ elektrik, su, qaz kimi kommunal xərcləri təyin edir.
    /// qeyd: Dükanda istifadə olunan enerji resurslarının ödənişləri.
    /// </summary>
    Kommunal = 2,

    /// <summary>
    /// Kirayə haqqı
    /// diqqət: Bu növ dükana görə ödənilən kirayə haqqını təyin edir.
    /// qeyd: Dükana görə hər ay ödənilən kirayə haqqı.
    /// </summary>
    Kira = 3,

    /// <summary>
    /// Marketinq və reklam xərcləri
    /// diqqət: Bu növ marketinq kampaniyaları və reklam xərclərini təyin edir.
    /// qeyd: Reklam materialları, kampaniyalar və digər marketinq xərcləri.
    /// </summary>
    Marketinq = 4,

    /// <summary>
    /// Təmir və saxlanma xərcləri
    /// diqqət: Bu növ dükanda və avadanlıqlarda görülmüş təmir və saxlanma işlərini təyin edir.
    /// qeyd: Təmir materialları, ustaya görə ödənişlər və digər saxlanma xərcləri.
    /// </summary>
    TemirSaxlanma = 5,

    /// <summary>
    /// Ofis avadanlıqları xərci
    /// diqqət: Bu növ ofis avadanlıqlarının alınması və saxlanılması xərclərini təyin edir.
    /// qeyd: Kompyuter, printer, ofis mebeli və digər avadanlıqlar.
    /// </summary>
    OfisAvadanliqi = 6,

    /// <summary>
    /// Nəqliyyat xərcləri
    /// diqqət: Bu növ nəqliyyat xidmətləri və avtomobil saxlanışı xərclərini təyin edir.
    /// qeyd: Daşınma xidmətləri, benzin, avtomobil təmiri və saxlanışı.
    /// </summary>
    Nenqliyyat = 7,

    /// <summary>
    /// Vergi ödənişləri
    /// diqqət: Bu növ vergi ödənişlərini təyin edir.
    /// qeyd: Gəlir vergisi, əmlak vergisi və digər vergi ödənişləri.
    /// </summary>
    Vergi = 8,

    /// <summary>
    /// Bank xidmətləri
    /// diqqət: Bu növ bank xidmətləri və komissiya xərclərini təyin edir.
    /// qeyd: Hesab açılışı, köçürmə komissiyası və digər bank xidmətləri.
    /// </summary>
    BankXidmeti = 9,

    /// <summary>
    /// Digər xərclər
    /// diqqət: Bu növ digər kateqoriyalaşdırılmamış xərcləri təyin edir.
    /// qeyd: Müxtəlif və qeyri-standart xərclər bu kateqoriyaya aiddir.
    /// </summary>
    Diger = 99
}