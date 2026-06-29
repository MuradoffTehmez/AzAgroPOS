// Fayl: AzAgroPOS.Verilenler/Interfeysler/IAlisSifarisSetiriRepozitori.cs

using AzAgroPOS.Varliglar;

namespace AzAgroPOS.Verilenler.Interfeysler;
/// <summary>
/// Bütün alış sifarişi sətiri verilənlər bazası əməliyyatları üçün interfeys.
/// </summary>
public interface IAlisSifarisSetiriRepozitori : IRepozitori<AlisSifarisSetiri>
{
    // Burada alış sifarişi sətiri ilə əlaqəli xüsusi əməliyyatlar əlavə edilə bilər
}