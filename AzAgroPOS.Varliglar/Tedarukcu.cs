// Fayl: AzAgroPOS.Varliglar/Tedarukcu.cs
namespace AzAgroPOS.Varliglar;

using System;
using System.Collections.Generic;

/// <summary>
/// Tədarükçülərin məlumatlarını saxlayan varlıq sinifi.
/// </summary>
public class Tedarukcu : BazaVarligi
{
    /// <summary>
    /// Tədarükçünün adı.
    /// </summary>
    public string Ad { get; set; } = string.Empty;

    /// <summary>
    /// Tədarükçünün VÖEN nömrəsi.
    /// </summary>
    public string? Voen { get; set; }

    /// <summary>
    /// Tədarükçünün ünvanı.
    /// </summary>
    public string? Unvan { get; set; }

    /// <summary>
    /// Tədarükçünün telefon nömrəsi.
    /// </summary>
    public string? Telefon { get; set; }

    /// <summary>
    /// Tədarükçünün email ünvanı.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Tədarükçünün bank hesabı.
    /// </summary>
    public string? BankHesabi { get; set; }

    /// <summary>
    /// Tədarükçünün statusu (Aktiv, Passiv).
    /// </summary>
    public bool Aktivdir { get; set; } = true;

    /// <summary>
    /// Bu tədarükçünün alış sifarişləri.
    /// </summary>
    public ICollection<AlisSifaris> AlisSifarisleri { get; set; } = new List<AlisSifaris>();

    /// <summary>
    /// Bu tədarükçüyə aid alış sənədləri.
    /// </summary>
    public ICollection<AlisSened> AlisSenetleri { get; set; } = new List<AlisSened>();

    /// <summary>
    /// Bu tədarükçüyə ödənişlər.
    /// </summary>
    public ICollection<TedarukcuOdeme> Odemeler { get; set; } = new List<TedarukcuOdeme>();
}