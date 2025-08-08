// Fayl: AzAgroPOS.Varliglar/OdenisMetodu.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Satış zamanı istifadə oluna biləcək ödəniş metodlarını təyin edir.
/// </summary>
public enum OdenisMetodu
{
    Nağd = 1,
    Kart = 2,
    Köçürmə = 3,
    Nisyə = 4
}