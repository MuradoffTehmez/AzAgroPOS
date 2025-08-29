// Fayl: AzAgroPOS.Varliglar/Mehsul.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Sistemdə satılan və ya anbara daxil edilən hər bir məhsulu təmsil edir.
/// diqqət: Bu sinif, məhsul məlumatlarını və onların anbar vəziyyətini saxlayır.
/// qeyd: Məhsul, sistemdə satılan və ya anbara daxil edilən hər bir məhsulu təmsil edir. Hər bir məhsulun adı, unikal stok kodu, barkodu, satış qiyməti, alış qiyməti və anbarda mövcud olan sayı kimi məlumatları vardır.
/// </summary>
public class Mehsul : BazaVarligi
{
    /// <summary>
    /// Məhsulun adı (məsələn, "Alma").
    /// diqqət: Məhsulun adı, istifadəçilər tərəfindən tanınan və axtarılan məhsulun adını təmsil edir.
    /// qeyd: Məhsulun adı, məhsulun növünü və ya markasını əks etdirə bilər, məsələn, "Qırmızı Alma", "Yaşıl Alma" və s. Bu ad, məhsulun tanınması və axtarılması üçün istifadə olunur.
    /// </summary>
    public string Ad { get; set; } = string.Empty;

    /// <summary>
    /// Məhsulun unikal Stok Kodu (SKU - Stock Keeping Unit).
    /// diqqət: Stok kodu, məhsulun sistemdə unikal olaraq tanınmasını təmin edir və məhsulun axtarılması və idarə edilməsi üçün istifadə olunur.
    /// qeyd: Stok kodu, məhsulun unikal identifikatorudur və hər bir məhsul üçün fərqlidir. Məsələn, "ALM-12345" və ya "ALM-67890" kimi dəyərlər alır. Bu kod, məhsulun sistemdə tanınması və axtarılması üçün istifadə olunur.
    /// </summary>
    public string StokKodu { get; set; } = string.Empty;

    /// <summary>
    /// Məhsulun ölçü vahidi (ədəd, kq, litr və s.).
    /// </summary>
    public OlcuVahidi OlcuVahidi { get; set; }

    /// <summary>
    /// Məhsulun barkodu. Skanerlə oxunmaq üçün istifadə olunur.
    /// diqqət: Barkod, məhsulun sürətli və asan tanınması üçün istifadə olunur və məhsulun satış və anbar əməliyyatlarında skanerlə oxunmasını təmin edir.
    /// qeyd: Barkod, məhsulun unikal identifikatorudur və məhsulun sürətli və asan tanınması üçün istifadə olunur. Məsələn, "1234567890123" və ya "9876543210987" kimi dəyərlər alır. Bu barkod, məhsulun satış və anbar əməliyyatlarında skanerlə oxunmasını təmin edir.
    /// </summary>
    public string Barkod { get; set; } = string.Empty;

    /// <summary>
    /// Məhsulun bir ədədinin pərakəndə satış qiyməti.
    /// diqqət: Satış qiyməti, məhsulun müştərilərə satılarkən təyin olunan qiymətidir və məhsulun dəyərini göstərir.
    /// qeyd: Satış qiyməti, məhsulun müştərilərə satılarkən təyin olunan qiymətidir və məhsulun dəyərini göstərir. Məsələn, "1.50" AZN və ya "2.99" AZN kimi dəyərlər alır. Bu qiymət, məhsulun satış zamanı müştərilərə təqdim olunan qiymətidir.
    /// </summary>
    public decimal SatisQiymeti { get; set; }

    /// <summary>
    /// Məhsulun alış qiyməti (maya dəyəri).
    /// diqqət: Alış qiyməti, məhsulun anbara daxil edildiyi zaman ödənilən qiymətdir və məhsulun maliyyətini göstərir.
    /// qeyd: Alış qiyməti, məhsulun anbara daxil edildiyi zaman ödənilən qiymətdir və məhsulun maliyyətini göstərir. Məsələn, "1.20" AZN və ya "2.50" AZN kimi dəyərlər alır. Bu qiymət, məhsulun anbara daxil edilməsi zamanı ödənilən qiymətdir və məhsulun maliyyətini təmsil edir.
    /// </summary>
    public decimal AlisQiymeti { get; set; }

    /// <summary>
    /// Anbarda mövcud olan məhsul sayı.
    /// diqqət: Bu sahə, məhsulun anbar vəziyyətini göstərir və anbarın nə qədər məhsul saxladığını təmsil edir.
    /// qeyd: Anbarda mövcud olan məhsul sayı, məhsulun anbar vəziyyətini göstərir və anbarın nə qədər məhsul saxladığını təmsil edir. Məsələn, "100" və ya "50" kimi dəyərlər alır. Bu sahə, məhsulun anbar vəziyyətini izləmək və idarə etmək üçün istifadə olunur.
    /// </summary>
    public int MovcudSay { get; set; }
}