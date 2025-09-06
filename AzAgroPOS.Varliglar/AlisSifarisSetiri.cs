// Fayl: AzAgroPOS.Varliglar/AlisSifarisSetiri.cs
namespace AzAgroPOS.Varliglar;
/// <summary>
/// Alış sifarişi sətirlərini saxlayan varlıq sinifi.
/// </summary>
public class AlisSifarisSetiri : BazaVarligi
{
    /// <summary>
    /// Alış sifarişi ID-si.
    /// </summary>
    public int AlisSifarisId { get; set; }

    /// <summary>
    /// Alış sifarişi məlumatı.
    /// </summary>
    public AlisSifaris? AlisSifaris { get; set; }

    /// <summary>
    /// Məhsul ID-si.
    /// </summary>
    public int MehsulId { get; set; }

    /// <summary>
    /// Məhsul məlumatı.
    /// </summary>
    public Mehsul? Mehsul { get; set; }

    /// <summary>
    /// Sifariş edilən miqdar.
    /// </summary>
    public decimal Miqdar { get; set; }

    /// <summary>
    /// Vahidin alış qiyməti.
    /// </summary>
    public decimal BirVahidQiymet { get; set; }

    /// <summary>
    /// Cəmi məbləğ (Miqdar * BirVahidQiymet).
    /// </summary>
    public decimal CemiMebleg { get; set; }

    /// <summary>
    /// Təhvil alınan miqdar.
    /// </summary>
    public decimal TehvilAlinanMiqdar { get; set; } = 0;

    /// <summary>
    /// Qalan miqdar (Sifariş edilən miqdar - Təhvil alınan miqdar).
    /// </summary>
    public decimal QalanMiqdar => Miqdar - TehvilAlinanMiqdar;
}