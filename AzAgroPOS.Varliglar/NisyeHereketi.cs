// Fayl: AzAgroPOS.Varliglar/NisyeHereketi.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Müştərinin hər bir nisyə əməliyyatını (alış və ya ödəniş) təmsil edir.
/// </summary>
public class NisyeHereketi : BazaVarligi
{
    public int MusteriId { get; set; }
    public Musteri? Musteri { get; set; }

    public DateTime Tarix { get; set; }

    public EmeliyyatNovu EmeliyyatNovu { get; set; }

    /// <summary>
    /// Əməliyyatın məbləği.
    /// </summary>
    public decimal Mebleg { get; set; }

    /// <summary>
    /// Əgər əməliyyat satışdan yaranıbsa, əlaqəli satışın ID-si.
    /// </summary>
    public int? SatisId { get; set; }
    public Satis? Satis { get; set; }

    /// <summary>
    /// Əməliyyat haqqında əlavə qeyd.
    /// </summary>
    public string? Qeyd { get; set; }
}