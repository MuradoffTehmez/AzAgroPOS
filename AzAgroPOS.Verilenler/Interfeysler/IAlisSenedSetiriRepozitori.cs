// Fayl: AzAgroPOS.Verilenler/Interfeysler/IAlisSenedSetiriRepozitori.cs

using AzAgroPOS.Varliglar;

namespace AzAgroPOS.Verilenler.Interfeysler;
/// <summary>
/// Bütün alış sənədi sətiri verilənlər bazası əməliyyatları üçün interfeys.
/// </summary>
public interface IAlisSenedSetiriRepozitori : IRepozitori<AlisSenedSetiri>
{
    // Burada alış sənədi sətiri ilə əlaqəli xüsusi əməliyyatlar əlavə edilə bilər
}