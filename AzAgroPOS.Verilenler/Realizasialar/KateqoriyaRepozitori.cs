// Fayl: AzAgroPOS.Verilenler/Realizasialar/KateqoriyaRepozitori.cs
namespace AzAgroPOS.Verilenler.Realizasialar;

using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;

/// <summary>
/// Kateqoriya varlığı üçün repozitoriya realizasiyası.
/// </summary>
public class KateqoriyaRepozitori : Repozitori<Kateqoriya>, IKateqoriyaRepozitori
{
    /// <summary>
    /// KateqoriyaRepozitoriyasını yaratmaq üçün konstruktor.
    /// </summary>
    /// <param name="kontekst">Verilənlər bazası konteksti.</param>
    public KateqoriyaRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst)
    {
        // Burada Kateqoriya varlığına xas xüsusi konfiqurasiyalar və ya əməliyyatlar həyata keçirilə bilər.
    }
}