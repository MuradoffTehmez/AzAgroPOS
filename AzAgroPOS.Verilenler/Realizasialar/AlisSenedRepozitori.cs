// Fayl: AzAgroPOS.Verilenler/Realizasialar/AlisSenedRepozitori.cs
namespace AzAgroPOS.Verilenler.Realizasialar;

using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;

/// <summary>
/// AlisSened varlığı üçün repozitoriya realizasiyası.
/// </summary>
public class AlisSenedRepozitori : Repozitori<AlisSened>, IAlisSenedRepozitori
{
    /// <summary>
    /// AlisSenedRepozitoriyasını yaratmaq üçün konstruktor.
    /// </summary>
    /// <param name="kontekst">Verilənlər bazası konteksti.</param>
    public AlisSenedRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst)
    {
        // Burada AlisSened varlığına xas xüsusi konfiqurasiyalar və ya əməliyyatlar həyata keçirilə bilər.
    }
}