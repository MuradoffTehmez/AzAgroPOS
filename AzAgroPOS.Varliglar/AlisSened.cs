// Fayl: AzAgroPOS.Varliglar/AlisSened.cs
namespace AzAgroPOS.Varliglar;

using System;
using System.Collections.Generic;

/// <summary>
/// Alış sənədlərini saxlayan varlıq sinifi.
/// </summary>
public class AlisSened : BazaVarligi
{
    /// <summary>
    /// Alış sənədin nömrəsi.
    /// </summary>
    public string SenedNomresi { get; set; } = string.Empty;

    /// <summary>
    /// Tədarükçü ID-si.
    /// </summary>
    public int TedarukcuId { get; set; }

    /// <summary>
    /// Tədarükçü məlumatı.
    /// </summary>
    public Tedarukcu? Tedarukcu { get; set; }

    /// <summary>
    /// Malın təhvil alındığı tarix.
    /// </summary>
    public DateTime TehvilTarixi { get; set; } = DateTime.Now;

    /// <summary>
    /// Sənədin ümumi məbləği.
    /// </summary>
    public decimal UmumiMebleg { get; set; }

    /// <summary>
    /// Sənədin statusu (Yaradıldı, Təsdiqləndi, Ləğv Edildi).
    /// </summary>
    public AlisSenedStatusu Status { get; set; } = AlisSenedStatusu.Yaradildi;

    /// <summary>
    /// Qeydlər və şərhlər.
    /// </summary>
    public string? Qeydler { get; set; }

    /// <summary>
    /// Bu sənədə aid sətirlər.
    /// </summary>
    public ICollection<AlisSenedSetiri> SenedSetirleri { get; set; } = new List<AlisSenedSetiri>();

    /// <summary>
    /// Bu sənədə aid ödənişlər.
    /// </summary>
    public ICollection<TedarukcuOdeme> Odemeler { get; set; } = new List<TedarukcuOdeme>();
}