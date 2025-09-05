// Fayl: AzAgroPOS.Verilenler/Interfeysler/ITedarukcuOdemeRepozitori.cs
namespace AzAgroPOS.Verilenler.Interfeysler;

using AzAgroPOS.Varliglar;

/// <summary>
/// Bütün tədarükçü ödənişi verilənlər bazası əməliyyatları üçün interfeys.
/// </summary>
public interface ITedarukcuOdemeRepozitori : IRepozitori<TedarukcuOdeme>
{
    // Burada tədarükçü ödənişi ilə əlaqəli xüsusi əməliyyatlar əlavə edilə bilər
}