// Fayl: AzAgroPOS.Varliglar/AlisSifaris.cs
namespace AzAgroPOS.Varliglar;

using System;
using System.Collections.Generic;

/// <summary>
/// Alış sifarişlərini saxlayan varlıq sinifi.
/// </summary>
public class AlisSifaris : BazaVarligi
{
    /// <summary>
    /// Alış sifarişinin nömrəsi.
    /// </summary>
    public string SifarisNomresi { get; set; } = string.Empty;

    /// <summary>
    /// Sifarişin yaradıldığı tarix.
    /// </summary>
    public DateTime YaradilmaTarixi { get; set; } = DateTime.Now;

    /// <summary>
    /// Sifarişin təsdiq edildiyi tarix.
    /// </summary>
    public DateTime? TesdiqTarixi { get; set; }

    /// <summary>
    /// Sifarişin gözlənilən təhvil tarixi.
    /// </summary>
    public DateTime? GozlenilenTehvilTarixi { get; set; }

    /// <summary>
    /// Sifarişin faktiki təhvil alındığı tarix.
    /// </summary>
    public DateTime? FaktikiTehvilTarixi { get; set; }

    /// <summary>
    /// Tədarükçü ID-si.
    /// </summary>
    public int TedarukcuId { get; set; }

    /// <summary>
    /// Tədarükçü məlumatı.
    /// </summary>
    public Tedarukcu? Tedarukcu { get; set; }

    /// <summary>
    /// Sifarişin ümumi məbləği.
    /// </summary>
    public decimal UmumiMebleg { get; set; }

    /// <summary>
    /// Sifarişin statusu (Yaradıldı, Təsdiqləndi, Təhvil Alındı, Ləğv Edildi).
    /// </summary>
    public AlisSifarisStatusu Status { get; set; } = AlisSifarisStatusu.Yaradildi;

    /// <summary>
    /// Qeydlər və şərhlər.
    /// </summary>
    public string? Qeydler { get; set; }

    /// <summary>
    /// Bu sifarişə aid sətirlər.
    /// </summary>
    public ICollection<AlisSifarisSetiri> SifarisSetirleri { get; set; } = new List<AlisSifarisSetiri>();
}