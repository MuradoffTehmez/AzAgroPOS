// Fayl: AzAgroPOS.Varliglar/AlisSifarisStatusu.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Alış sifarişinin statusunu təmsil edən enumerasiya.
/// </summary>
public enum AlisSifarisStatusu
{
    /// <summary>
    /// Sifariş yaradıldı, lakin hələ təsdiq edilməyib.
    /// </summary>
    Yaradildi = 1,

    /// <summary>
    /// Sifariş təsdiq edilib.
    /// </summary>
    Tesdiqlendi = 2,

    /// <summary>
    /// Sifarişin bir hissəsi təhvil alınmışdır.
    /// </summary>
    QismenTehvilAlindi = 3,

    /// <summary>
    /// Sifarişin tamamı təhvil alınmışdır.
    /// </summary>
    TamTehvilAlindi = 4,

    /// <summary>
    /// Sifariş ləğv edilib.
    /// </summary>
    LegvEdildi = 5
}