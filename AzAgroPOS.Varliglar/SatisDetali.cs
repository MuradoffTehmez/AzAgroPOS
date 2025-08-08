// Fayl: AzAgroPOS.Varliglar/SatisDetali.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Bir satış əməliyyatı daxilində hər bir məhsulun detalını təmsil edir.
/// Məsələn, "2 ədəd Alma 1.50 AZN-dən".
/// </summary>
public class SatisDetali : BazaVarligi
{
    /// <summary>
    /// Aid olduğu satış əməliyyatının ID-si.
    /// </summary>
    public int SatisId { get; set; }

    /// <summary>
    /// Naviqasiya xüsusiyyəti: Aid olduğu satış.
    /// </summary>
    public Satis? Satis { get; set; }

    /// <summary>
    /// Satılan məhsulun ID-si.
    /// </summary>
    public int MehsulId { get; set; }

    /// <summary>
    /// Naviqasiya xüsusiyyəti: Satılan məhsul.
    /// </summary>
    public Mehsul? Mehsul { get; set; }

    /// <summary>
    /// Satılan məhsulun miqdarı (ədəd, kq və s.).
    /// </summary>
    public int Miqdar { get; set; }

    /// <summary>
    /// Satış anında məhsulun bir vahidinin qiyməti.
    /// Qiymətlər dəyişə biləcəyi üçün bu məlumat burada saxlanılır.
    /// </summary>
    public decimal Qiymet { get; set; }
}