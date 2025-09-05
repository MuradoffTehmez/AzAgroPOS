// Fayl: AzAgroPOS.Varliglar/TedarukcuOdeme.cs
namespace AzAgroPOS.Varliglar;

using System;

/// <summary>
/// Tədarükçü ödənişlərini saxlayan varlıq sinifi.
/// </summary>
public class TedarukcuOdeme : BazaVarligi
{
    /// <summary>
    /// Ödənişin nömrəsi.
    /// </summary>
    public string OdemeNomresi { get; set; } = string.Empty;

    /// <summary>
    /// Ödənişin yaradıldığı tarix.
    /// </summary>
    public DateTime YaradilmaTarixi { get; set; } = DateTime.Now;

    /// <summary>
    /// Tədarükçü ID-si.
    /// </summary>
    public int TedarukcuId { get; set; }

    /// <summary>
    /// Tədarükçü məlumatı.
    /// </summary>
    public Tedarukcu? Tedarukcu { get; set; }

    /// <summary>
    /// Əlaqəli alış sənədi ID-si (əgər ödəniş müəyyən sənəd üçündirsə).
    /// </summary>
    public int? AlisSenedId { get; set; }

    /// <summary>
    /// Əlaqəli alış sənədi məlumatı.
    /// </summary>
    public AlisSened? AlisSened { get; set; }

    /// <summary>
    /// Ödəniş tarixi.
    /// </summary>
    public DateTime OdemeTarixi { get; set; } = DateTime.Now;

    /// <summary>
    /// Ödəniş məbləği.
    /// </summary>
    public decimal Mebleg { get; set; }

    /// <summary>
    /// Ödəniş üsulu (Nağd, Bank Köçürməsi, və s.).
    /// </summary>
    public OdemeUsulu OdemeUsulu { get; set; } = OdemeUsulu.Naqd;

    /// <summary>
    /// Ödənişin statusu (Yaradıldı, Təsdiqləndi, Ləğv Edildi).
    /// </summary>
    public OdemeStatusu Status { get; set; } = OdemeStatusu.Yaradildi;

    /// <summary>
    /// Qeydlər və şərhlər.
    /// </summary>
    public string? Qeydler { get; set; }

    /// <summary>
    /// Bank məlumatları (əgər bank köçürməsi ilə ödənişdirsə).
    /// </summary>
    public string? BankMelumatlari { get; set; }
}