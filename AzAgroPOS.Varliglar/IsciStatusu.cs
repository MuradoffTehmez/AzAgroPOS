// Fayl: AzAgroPOS.Varliglar/IsciStatusu.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// İşçinin statusunu təmsil edən enumerasiya.
/// </summary>
public enum IsciStatusu
{
    /// <summary>
    /// İşçinin işlədiyi aktiv status.
    /// </summary>
    Aktiv = 1,

    /// <summary>
    /// İşçinin işdən çıxdığı status.
    /// </summary>
    CixisEdb = 2,

    /// <summary>
    /// İşçinin məzuniyyətdə olduğu status.
    /// </summary>
    Mezuniyyetde = 3,

    /// <summary>
    /// İşçinin xəstəlik icazəsində olduğu status.
    /// </summary>
    Xestelikde = 4,

    /// <summary>
    /// İşçinin işə gəlmədiyi, lakin işdən çıxmamış status.
    /// </summary>
    Geletmir = 5
}