// Fayl: AzAgroPOS.Verilenler/Interfeysler/IAlisSenedSetiriRepozitori.cs
namespace AzAgroPOS.Verilenler.Interfeysler;

using AzAgroPOS.Varliglar;

/// <summary>
/// Bütün alış sənədi sətiri verilənlər bazası əməliyyatları üçün interfeys.
/// </summary>
public interface IAlisSenedSetiriRepozitori : IRepozitori<AlisSenedSetiri>
{
    // Burada alış sənədi sətiri ilə əlaqəli xüsusi əməliyyatlar əlavə edilə bilər
}