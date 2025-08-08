// Fayl: AzAgroPOS.Varliglar/BazaVarligi.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Bütün verilənlər bazası varlıqları üçün təməl sinif.
/// Hər bir varlığın unikal bir identifikatorunun olmasını təmin edir.
/// </summary>
public abstract class BazaVarligi
{
    /// <summary>
    /// Varlığın unikal identifikatoru. Verilənlər bazasında birincili açar (Primary Key).
    /// </summary>
    public int Id { get; set; }
}