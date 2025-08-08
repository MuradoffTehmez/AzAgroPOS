// Fayl: AzAgroPOS.Varliglar/Satis.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Bir satış əməliyyatının başlığını təmsil edir.
/// Ümumi məbləğ, tarix və müştəri kimi məlumatları saxlayır.
/// </summary>
public class Satis : BazaVarligi
{
    /// <summary>
    /// Satışın həyata keçirildiyi tarix və vaxt.
    /// </summary>
    public DateTime Tarix { get; set; }

    /// <summary>
    /// Satışın ümumi məbləği.
    /// </summary>
    public decimal UmumiMebleg { get; set; }

    /// <summary>
    /// Tətbiq olunan ödəniş metodu.
    /// </summary>
    public OdenisMetodu OdenisMetodu { get; set; }

    /// <summary>
    /// Satış nisyə edilibsə, əlaqəli müştərinin ID-si.
    /// </summary>
    public int? MusteriId { get; set; }

    /// <summary>
    /// Naviqasiya xüsusiyyəti: Əlaqəli müştəri.
    /// </summary>
    public Musteri? Musteri { get; set; }

    /// <summary>
    /// Bu satışa aid olan məhsulların siyahısı (satış detalları).
    /// </summary>
    public ICollection<SatisDetali> SatisDetallari { get; set; } = new List<SatisDetali>();
}