// Fayl: AzAgroPOS.Verilenler/Realizasialar/QaytarmaRepozitori.cs
namespace AzAgroPOS.Verilenler.Realizasialar;

using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;

/// <summary>
/// Qaytarma verilənlər bazası əməliyyatları üçün realizasiya.
/// </summary>
public class QaytarmaRepozitori : Repozitori<Qaytarma>, IQaytarmaRepozitori
{
    public QaytarmaRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst)
    {
        // burda əlavə konfiqurasiyalar edilə bilər
    }
}