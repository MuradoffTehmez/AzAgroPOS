// Fayl: AzAgroPOS.Verilenler/Interfeysler/IQaytarmaRepozitori.cs

using AzAgroPOS.Varliglar;

namespace AzAgroPOS.Verilenler.Interfeysler;
/// <summary>
/// Qaytarma verilənlər bazası əməliyyatları üçün interfeys.
/// </summary>
public interface IQaytarmaRepozitori : IRepozitori<Qaytarma>
{
    Task QaytarmaDetaliElaveEtAsync(QaytarmaDetali detali);
}
