// Fayl: AzAgroPOS.Varliglar/OdemeUsulu.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Ödəniş üsulunu təmsil edən enumerasiya.
/// </summary>
public enum OdemeUsulu
{
    /// <summary>
    /// Nağd ödəniş.
    /// </summary>
    Naqd = 1,

    /// <summary>
    /// Bank köçürməsi ilə ödəniş.
    /// </summary>
    BankKocurmesi = 2,

    /// <summary>
    /// Kredit kartı ilə ödəniş.
    /// </summary>
    KreditKarti = 3,

    /// <summary>
    /// Digər ödəniş üsulları.
    /// </summary>
    Diger = 4
}