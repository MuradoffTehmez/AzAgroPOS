// Fayl: AzAgroPOS.Varliglar/IzinStatusu.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// İznin statusunu təmsil edən enumerasiya.
/// </summary>
public enum IzinStatusu
{
    /// <summary>
    /// İzin təqdim edilib, lakin hələ təsdiq olunmayıb.
    /// </summary>
    Gozlemede = 1,

    /// <summary>
    /// İzin təsdiqlənib.
    /// </summary>
    Tesdiqlenib = 2,

    /// <summary>
    /// İzin rədd edilib.
    /// </summary>
    Reddedilib = 3,

    /// <summary>
    /// İzin ləğv edilib.
    /// </summary>
    LegvEdilib = 4
}