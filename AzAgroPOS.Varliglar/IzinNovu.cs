// Fayl: AzAgroPOS.Varliglar/IzinNovu.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// İznin növünü təmsil edən enumerasiya.
/// </summary>
public enum IzinNovu
{
    /// <summary>
    /// Əsas məzuniyyət (yıllıq).
    /// </summary>
    Mezuniyyet = 1,

    /// <summary>
    /// Xəstəlik icazəsi.
    /// </summary>
    Xestelik = 2,

    /// <summary>
    /// Məzuniyyətsiz icazə (uşaq üçün).
    /// </summary>
    Mezuniyyetsiz = 3,

    /// <summary>
    /// Digər səbəblər üzrə icazə.
    /// </summary>
    Diger = 4,

    /// <summary>
    /// Məcburi iş günü.
    /// </summary>
    McburiIsGunu = 5,

    /// <summary>
    /// Təhsil icazəsi.
    /// </summary>
    Tehsil = 6
}