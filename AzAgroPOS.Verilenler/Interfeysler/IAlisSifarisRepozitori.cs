// Fayl: AzAgroPOS.Verilenler/Interfeysler/IAlisSifarisRepozitori.cs
namespace AzAgroPOS.Verilenler.Interfeysler;

using AzAgroPOS.Varliglar;

/// <summary>
/// Bütün alış sifarişi verilənlər bazası əməliyyatları üçün interfeys.
/// </summary>
public interface IAlisSifarisRepozitori : IRepozitori<AlisSifaris>
{
    // Burada alış sifarişi ilə əlaqəli xüsusi əməliyyatlar əlavə edilə bilər
}