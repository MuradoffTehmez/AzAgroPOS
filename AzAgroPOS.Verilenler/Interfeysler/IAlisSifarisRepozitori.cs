// Fayl: AzAgroPOS.Verilenler/Interfeysler/IAlisSifarisRepozitori.cs

using AzAgroPOS.Varliglar;

namespace AzAgroPOS.Verilenler.Interfeysler;
/// <summary>
/// Bütün alış sifarişi verilənlər bazası əməliyyatları üçün interfeys.
/// </summary>
public interface IAlisSifarisRepozitori : IRepozitori<AlisSifaris>
{
    // Burada alış sifarişi ilə əlaqəli xüsusi əməliyyatlar əlavə edilə bilər
}