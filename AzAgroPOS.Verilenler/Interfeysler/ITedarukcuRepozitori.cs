// Fayl: AzAgroPOS.Verilenler/Interfeysler/ITedarukcuRepozitori.cs

using AzAgroPOS.Varliglar;

namespace AzAgroPOS.Verilenler.Interfeysler;
/// <summary>
/// Bütün tədarükçü verilənlər bazası əməliyyatları üçün interfeys.
/// </summary>
public interface ITedarukcuRepozitori : IRepozitori<Tedarukcu>
{
    // Burada tədarükçü ilə əlaqəli xüsusi əməliyyatlar əlavə edilə bilər
}