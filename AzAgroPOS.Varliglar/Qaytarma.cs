// Fayl: AzAgroPOS.Varliglar/Qaytarma.cs
namespace AzAgroPOS.Varliglar;

using System;
using System.Collections.Generic;

/// <summary>
/// Qaytarma əməliyyatlarını təmsil edir.
/// </summary>
public class Qaytarma : BazaVarligi
{
    /// <summary>
    /// Qaytarma tarixi.
    /// </summary>
    public DateTime Tarix { get; set; }

    /// <summary>
    /// Əsas satışın ID-si.
    /// </summary>
    public int SatisId { get; set; }

    /// <summary>
    /// Naviqasiya xüsusiyyəti: Əsas satış.
    /// </summary>
    public Satis? Satis { get; set; }

    /// <summary>
    /// Qaytarılan məbləğ.
    /// </summary>
    public decimal UmumiMebleg { get; set; }

    /// <summary>
    /// Qaytarma səbəbi.
    /// </summary>
    public string Sebeb { get; set; } = string.Empty;

    /// <summary>
    /// Qaytarma edən kassirin ID-si.
    /// </summary>
    public int KassirId { get; set; }

    /// <summary>
    /// Naviqasiya xüsusiyyəti: Qaytarma edən kassir.
    /// </summary>
    public Istifadeci? Kassir { get; set; }

    /// <summary>
    /// Qaytarma detallarının siyahısı.
    /// </summary>
    public ICollection<QaytarmaDetali> QaytarmaDetallari { get; set; } = new List<QaytarmaDetali>();
}