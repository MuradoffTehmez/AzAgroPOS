// Fayl: AzAgroPOS.Varliglar/Kateqoriya.cs
namespace AzAgroPOS.Varliglar;

using System;
using System.Collections.Generic;

/// <summary>
/// Məhsul kateqoriyalarını təmsil edən varlıq sinifi.
/// </summary>
public class Kateqoriya : BazaVarligi
{
    /// <summary>
    /// Kateqoriyanın adı.
    /// </summary>
    public string Ad { get; set; } = string.Empty;

    /// <summary>
    /// Kateqoriyanın təsviri.
    /// </summary>
    public string? Tesvir { get; set; }

    /// <summary>
    /// Kateqoriyanın aktivlik statusu.
    /// </summary>
    public bool Aktivdir { get; set; } = true;

    /// <summary>
    /// Bu kateqoriyaya aid məhsullar.
    /// </summary>
    public ICollection<Mehsul> Mehsullar { get; set; } = new List<Mehsul>();
}