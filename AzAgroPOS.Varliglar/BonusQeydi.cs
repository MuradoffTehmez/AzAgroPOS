// Fayl: AzAgroPOS.Varliglar/BonusQeydi.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Müştəri bonus qazanma və istifadə tarixçəsi.
/// Diqqət: Hər bal dəyişikliyi bu cədvəldə qeyd edilir.
/// </summary>
public class BonusQeydi : BazaVarligi
{
    /// <summary>
    /// Müştəri bonus ID-si
    /// </summary>
    public int MusteriBonusId { get; set; }

    /// <summary>
    /// Əlaqəli müştəri bonus qeydi
    /// </summary>
    public MusteriBonus MusteriBonus { get; set; } = null!;

    /// <summary>
    /// Əməliyyat tipi (Qazanma, İstifadə, Ləğv)
    /// </summary>
    public BonusEmeliyyatNovu EmeliyyatNovu { get; set; }

    /// <summary>
    /// Bal miqdarı (+ qazanma, - istifadə)
    /// </summary>
    public decimal BalMiqdari { get; set; }

    /// <summary>
    /// Əməliyyat tarixi
    /// </summary>
    public DateTime EmeliyyatTarixi { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Əməliyyat açıqlaması
    /// </summary>
    public string? Aciklama { get; set; }

    /// <summary>
    /// Əlaqəli satış ID-si (varsa)
    /// </summary>
    public int? SatisId { get; set; }

    /// <summary>
    /// Əlaqəli satış
    /// </summary>
    public Satis? Satis { get; set; }
}

/// <summary>
/// Bonus əməliyyat növü
/// </summary>
public enum BonusEmeliyyatNovu
{
    /// <summary>
    /// Bal qazanma (satış əməliyyatından)
    /// </summary>
    Qazanma = 1,

    /// <summary>
    /// Bal istifadə (endirim əldə etmə)
    /// </summary>
    Istifade = 2,

    /// <summary>
    /// Bal ləğvi (admin tərəfindən)
    /// </summary>
    Legv = 3,

    /// <summary>
    /// Manual bal əlavəsi (admin tərəfindən)
    /// </summary>
    ManualElave = 4
}
