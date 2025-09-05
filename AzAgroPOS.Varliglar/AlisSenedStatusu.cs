// Fayl: AzAgroPOS.Varliglar/AlisSenedStatusu.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Alış sənədinin statusunu təmsil edən enumerasiya.
/// </summary>
public enum AlisSenedStatusu
{
    /// <summary>
    /// Sənəd yaradıldı, lakin hələ təsdiq edilməyib.
    /// </summary>
    Yaradildi = 1,

    /// <summary>
    /// Sənəd təsdiq edilib və anbarda qeyd edilib.
    /// </summary>
    Tesdiqlendi = 2,

    /// <summary>
    /// Sənəd ləğv edilib.
    /// </summary>
    LegvEdildi = 3
}