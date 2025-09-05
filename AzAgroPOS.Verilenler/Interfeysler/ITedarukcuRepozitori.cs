// Fayl: AzAgroPOS.Verilenler/Interfeysler/ITedarukcuRepozitori.cs
namespace AzAgroPOS.Verilenler.Interfeysler;

using AzAgroPOS.Varliglar;

/// <summary>
/// Bütün tədarükçü verilənlər bazası əməliyyatları üçün interfeys.
/// </summary>
public interface ITedarukcuRepozitori : IRepozitori<Tedarukcu>
{
    // Burada tədarükçü ilə əlaqəli xüsusi əməliyyatlar əlavə edilə bilər
}