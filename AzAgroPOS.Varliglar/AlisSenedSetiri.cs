// Fayl: AzAgroPOS.Varliglar/AlisSenedSetiri.cs
namespace AzAgroPOS.Varliglar;
/// <summary>
/// Alış sənədi sətirlərini saxlayan varlıq sinifi.
/// </summary>
public class AlisSenedSetiri : BazaVarligi
{
    /// <summary>
    /// Alış sənədi ID-si.
    /// </summary>
    public int AlisSenedId { get; set; }

    /// <summary>
    /// Alış sənədi məlumatı.
    /// </summary>
    public AlisSened? AlisSened { get; set; }

    /// <summary>
    /// Məhsul ID-si.
    /// </summary>
    public int MehsulId { get; set; }

    /// <summary>
    /// Məhsul məlumatı.
    /// </summary>
    public Mehsul? Mehsul { get; set; }

    /// <summary>
    /// Təhvil alınan miqdar.
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
    /// Alış sifarişi sətri ID-si (əgər sifariş əsasında yaradılıbsa).
    /// </summary>
    public int? AlisSifarisSetiriId { get; set; }

    /// <summary>
    /// Alış sifarişi sətri məlumatı.
    /// </summary>
    public AlisSifarisSetiri? AlisSifarisSetiri { get; set; }
}