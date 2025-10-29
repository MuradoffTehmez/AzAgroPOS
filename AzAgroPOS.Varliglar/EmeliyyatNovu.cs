// Fayl: AzAgroPOS.Varliglar/EmeliyyatNovu.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Nisyə hərəkətinin növünü təyin edir (borcun artması və ya azalması).
/// </summary>
public enum EmeliyyatNovu
{
    /// <summary>
    /// satis - Nisyə satış (borcu artırır).
    /// diqqət: Bu əməliyyat, müştərinin məhsulu nisyə ilə almasını və borcunun artmasını təmsil edir.
    /// qeyd: Nisyə satış, müştərinin məhsulu alıb, amma ödənişi gələcəkdə etməsini göstərir, məsələn, "300.00" AZN nisyə ilə satış.
    /// referans: Bu əməliyyat, müştərinin məhsulu nisyə ilə alması və borcunun artması ilə əlaqəlidir.
    /// rol: Bu əməliyyat, müştərinin nisyə ilə məhsul alması və borcunun artması üçün istifadə olunur..
    /// </summary>
    Satis = 1,  // Nisyə satış (borcu artırır)
    /// <summary>
    /// odenis - Nisyə ödənişi (borcu azaldır).
    /// diqqət: Bu əməliyyat, müştərinin nisyə borcunu ödəməsini və borcun azalmasını təmsil edir.
    /// qeyd: Nisyə ödənişi, müştərinin nisyə borcunu ödəməsi və borcun azalması ilə əlaqəlidir, məsələn, "150.00" AZN nisyə ödənişi.
    /// referans: Bu əməliyyat, müştərinin nisyə borcunu ödəməsi və borcun azalması ilə əlaqəlidir.
    /// rol: Bu əməliyyat, müştərinin nisyə borcunu ödəməsi və borcun azalması üçün istifadə olunur.
    /// </summary>
    Odenis = 2, // Borc ödənişi (borcu azaldır)

    /// <summary>
    /// qaytarma - Satış qaytarma (borcu azaldır).
    /// diqqət: Bu əməliyyat, müştərinin əvvəlki alışını qaytarmasını və borcun azalmasını təmsil edir.
    /// qeyd: Satış qaytarma, müştərinin əvvəlki nisyə alışını qaytarması və borcun azalması ilə əlaqəlidir.
    /// referans: Bu əməliyyat, müştərinin əvvəlki alışını qaytarması və borcun azalması ilə əlaqəlidir.
    /// rol: Bu əməliyyat, müştərinin əvvəlki alışını qaytarması və borcun azalması üçün istifadə olunur.
    /// </summary>
    Qaytarma = 3, // Satış qaytarma (borcu azaldır)
    Xerc = 4,
    Gelir = 5
}