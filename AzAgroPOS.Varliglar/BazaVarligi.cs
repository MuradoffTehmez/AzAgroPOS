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
    /// diqqət: Bu ID, hər bir varlığın unikal olmasını təmin edir və verilənlər bazasında axtarış və əlaqələndirmə əməliyyatlarında istifadə olunur.
    /// qeyd: ID, sistemdəki hər bir varlığın unikal identifikatorudur və verilənlər bazasında avtomatik olaraq artırılır, məsələn, "1", "2", "3" və s. kimi dəyərlər alır.
    /// rol: Bu sinif, bütün varlıqların ID sahəsini ehtiva edir və hər bir varlığın unikal identifikatorunu təmsil edir.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Varlığın silinib-silinmədiyini göstərir. True olduqda varlıq silinmiş sayılır.
    /// </summary>
    public bool Silinib { get; set; } = false;
}