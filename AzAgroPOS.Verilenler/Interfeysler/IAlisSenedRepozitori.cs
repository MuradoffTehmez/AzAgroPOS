// Fayl: AzAgroPOS.Verilenler/Interfeysler/IAlisSenedRepozitori.cs
namespace AzAgroPOS.Verilenler.Interfeysler;

using AzAgroPOS.Varliglar;

/// <summary>
/// Bütün alış sənədi verilənlər bazası əməliyyatları üçün interfeys.
/// </summary>
public interface IAlisSenedRepozitori : IRepozitori<AlisSened>
{
    // Burada alış sənədi ilə əlaqəli xüsusi əməliyyatlar əlavə edilə bilər
}