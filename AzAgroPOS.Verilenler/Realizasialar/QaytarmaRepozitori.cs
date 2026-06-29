// Fayl: AzAgroPOS.Verilenler/Realizasialar/QaytarmaRepozitori.cs

using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;

namespace AzAgroPOS.Verilenler.Realizasialar;
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