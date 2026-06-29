// Fayl: AzAgroPOS.Verilenler/Interfeysler/ITedarukcuOdemeRepozitori.cs

using AzAgroPOS.Varliglar;

namespace AzAgroPOS.Verilenler.Interfeysler;
/// <summary>
/// Bütün tədarükçü ödənişi verilənlər bazası əməliyyatları üçün interfeys.
/// </summary>
public interface ITedarukcuOdemeRepozitori : IRepozitori<TedarukcuOdeme>
{
    // Burada tədarükçü ödənişi ilə əlaqəli xüsusi əməliyyatlar əlavə edilə bilər
}