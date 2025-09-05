// Fayl: AzAgroPOS.Verilenler/Interfeysler/IAlisSifarisSetiriRepozitori.cs
namespace AzAgroPOS.Verilenler.Interfeysler;

using AzAgroPOS.Varliglar;

/// <summary>
/// Bütün alış sifarişi sətiri verilənlər bazası əməliyyatları üçün interfeys.
/// </summary>
public interface IAlisSifarisSetiriRepozitori : IRepozitori<AlisSifarisSetiri>
{
    // Burada alış sifarişi sətiri ilə əlaqəli xüsusi əməliyyatlar əlavə edilə bilər
}