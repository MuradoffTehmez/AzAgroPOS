// Fayl: AzAgroPOS.Varliglar/OdemeStatusu.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Ödənişin statusunu təmsil edən enumerasiya.
/// </summary>
public enum OdemeStatusu
{
    /// <summary>
    /// Ödəniş yaradıldı, lakin hələ təsdiq edilməyib.
    /// </summary>
    Yaradildi = 1,

    /// <summary>
    /// Ödəniş təsdiq edilib.
    /// </summary>
    Tesdiqlendi = 2,

    /// <summary>
    /// Ödəniş ləğv edilib.
    /// </summary>
    LegvEdildi = 3
}