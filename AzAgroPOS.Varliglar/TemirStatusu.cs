// Fayl: AzAgroPOS.Varliglar/TemirStatusu.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Təmir sifarişinin hazırkı vəziyyətini göstərir.
/// </summary>
public enum TemirStatusu
{
    Gözləmədə = 1,
    Təmirdə = 2,
    Hazırdır = 3,
    TəhvilVerildi = 4
}