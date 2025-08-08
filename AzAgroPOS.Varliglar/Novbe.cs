// Fayl: AzAgroPOS.Varliglar/Novbe.cs
namespace AzAgroPOS.Varliglar;

using System;
using System.Collections.Generic;

/// <summary>
/// Kassirin iş növbəsini təmsil edir.
/// </summary>
public class Novbe : BazaVarligi
{
    public int IsciId { get; set; }
    public Istifadeci? Isci { get; set; }

    public DateTime AcilmaTarixi { get; set; }
    public DateTime? BaglanmaTarixi { get; set; }

    /// <summary>
    /// Növbə başlayarkən kassada olan nağd pul.
    /// </summary>
    public decimal BaslangicMebleg { get; set; }

    /// <summary>
    /// Növbə bağlanarkən kassada olmalı olan hesablanmış nağd pul.
    /// </summary>
    public decimal GozlenilenMebleg { get; set; }

    /// <summary>
    /// Növbə bağlanarkən kassada sayılan faktiki nağd pul.
    /// </summary>
    public decimal FaktikiMebleg { get; set; }

    public NovbeStatusu Status { get; set; }

    public ICollection<Satis> Satislar { get; set; } = new List<Satis>();
}