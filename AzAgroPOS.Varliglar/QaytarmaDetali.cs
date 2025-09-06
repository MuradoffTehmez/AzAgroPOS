// Fayl: AzAgroPOS.Varliglar/QaytarmaDetali.cs
namespace AzAgroPOS.Varliglar;
/// <summary>
/// Qaytarma əməliyyatının detallarını təmsil edir.
/// </summary>
public class QaytarmaDetali : BazaVarligi
{
    /// <summary>
    /// Qaytarma ID-si.
    /// </summary>
    public int QaytarmaId { get; set; }

    /// <summary>
    /// Naviqasiya xüsusiyyəti: Qaytarma.
    /// </summary>
    public Qaytarma? Qaytarma { get; set; }

    /// <summary>
    /// Qaytarılan məhsulun ID-si.
    /// </summary>
    public int MehsulId { get; set; }

    /// <summary>
    /// Naviqasiya xüsusiyyəti: Qaytarılan məhsul.
    /// </summary>
    public Mehsul? Mehsul { get; set; }

    /// <summary>
    /// Qaytarılan miqdar.
    /// </summary>
    public decimal Miqdar { get; set; }

    /// <summary>
    /// Qaytarılan məhsulun vahid qiyməti.
    /// </summary>
    public decimal Qiymet { get; set; }

    /// <summary>
    /// Qaytarılan məbləğ (Miqdar * Qiymet).
    /// </summary>
    public decimal UmumiMebleg { get; set; }
}