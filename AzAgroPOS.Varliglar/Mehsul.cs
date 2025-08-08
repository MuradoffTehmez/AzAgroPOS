// Fayl: AzAgroPOS.Varliglar/Mehsul.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Sistemdə satılan və ya anbara daxil edilən hər bir məhsulu təmsil edir.
/// </summary>
public class Mehsul : BazaVarligi
{
    /// <summary>
    /// Məhsulun adı (məsələn, "Alma").
    /// </summary>
    public string Ad { get; set; } = string.Empty;

    /// <summary>
    /// Məhsulun unikal Stok Kodu (SKU - Stock Keeping Unit).
    /// </summary>
    public string StokKodu { get; set; } = string.Empty;

    /// <summary>
    /// Məhsulun barkodu. Skanerlə oxunmaq üçün istifadə olunur.
    /// </summary>
    public string Barkod { get; set; } = string.Empty;

    /// <summary>
    /// Məhsulun bir ədədinin pərakəndə satış qiyməti.
    /// </summary>
    public decimal SatisQiymeti { get; set; }

    /// <summary>
    /// Məhsulun alış qiyməti (maya dəyəri).
    /// </summary>
    public decimal AlisQiymeti { get; set; }

    /// <summary>
    /// Anbarda mövcud olan məhsul sayı.
    /// </summary>
    public int MovcudSay { get; set; }
}