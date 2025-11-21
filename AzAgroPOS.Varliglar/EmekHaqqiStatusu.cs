// Fayl: AzAgroPOS.Varliglar/EmekHaqqiStatusu.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Əmək haqqı statusu.
/// </summary>
public enum EmekHaqqiStatusu
{
    /// <summary>
    /// Status təyin edilməyib (default dəyər).
    /// </summary>
    Namalum = 0,

    /// <summary>
    /// Əmək haqqı hesablanmışdır, amma hələ ödənilməmişdir.
    /// </summary>
    Hesablanmis = 1,

    /// <summary>
    /// Əmək haqqı ödənilmişdir.
    /// </summary>
    Odenilmis = 2,

    /// <summary>
    /// Əmək haqqı ləğv edilmişdir.
    /// </summary>
    Legv = 3
}
