// Fayl: AzAgroPOS.Varliglar/MusteriBonus.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Müştəri bonus/loyallıq proqramı üçün qeydlər.
/// Diqqət: Hər satış əməliyyatından sonra müştəri bal qazanır.
/// Qeyd: Ballar daha sonra endirimlərə çevrilə bilər.
/// </summary>
public class MusteriBonus : BazaVarligi
{
    /// <summary>
    /// Müştəri ID-si
    /// </summary>
    public int MusteriId { get; set; }

    /// <summary>
    /// Əlaqəli müştəri
    /// </summary>
    public Musteri Musteri { get; set; } = null!;

    /// <summary>
    /// Toplam qazanılmış bal
    /// </summary>
    public decimal ToplamBal { get; set; }

    /// <summary>
    /// İstifadə edilmiş bal
    /// </summary>
    public decimal IstifadeEdilmisBal { get; set; }

    /// <summary>
    /// Mövcud bal (Toplam - İstifadə edilmiş)
    /// </summary>
    public decimal MovcudBal => ToplamBal - IstifadeEdilmisBal;

    /// <summary>
    /// Son bal qazanma tarixi
    /// </summary>
    public DateTime? SonBalQazanmaTarixi { get; set; }

    /// <summary>
    /// Son bal istifadə tarixi
    /// </summary>
    public DateTime? SonBalIstifadeTarixi { get; set; }

    /// <summary>
    /// Müştəri səviyyəsi (Əsas, Gümüş, Qızıl, Platinum)
    /// </summary>
    public MusteriSeviyyesi Seviyye { get; set; } = MusteriSeviyyesi.Esas;

    /// <summary>
    /// Bonus qeydləri (tarixçə)
    /// </summary>
    public ICollection<BonusQeydi> BonusQeydleri { get; set; } = new List<BonusQeydi>();
}

/// <summary>
/// Müştəri səviyyəsi enum
/// </summary>
public enum MusteriSeviyyesi
{
    /// <summary>
    /// Əsas səviyyə (0-1000 bal)
    /// </summary>
    Esas = 1,

    /// <summary>
    /// Gümüş səviyyə (1000-5000 bal)
    /// </summary>
    Gumus = 2,

    /// <summary>
    /// Qızıl səviyyə (5000-10000 bal)
    /// </summary>
    Qizil = 3,

    /// <summary>
    /// Platinum səviyyə (10000+ bal)
    /// </summary>
    Platinum = 4
}
