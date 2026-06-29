// Fayl: AzAgroPOS.Verilenler/Realizasialar/AlisSenedSetiriRepozitori.cs

using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;

namespace AzAgroPOS.Verilenler.Realizasialar;
/// <summary>
/// AlisSenedSetiri varlığı üçün repozitoriya realizasiyası.
/// </summary>
public class AlisSenedSetiriRepozitori : Repozitori<AlisSenedSetiri>, IAlisSenedSetiriRepozitori
{
    /// <summary>
    /// AlisSenedSetiriRepozitoriyasını yaratmaq üçün konstruktor.
    /// </summary>
    /// <param name="kontekst">Verilənlər bazası konteksti.</param>
    public AlisSenedSetiriRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst)
    {
        // Burada AlisSenedSetiri varlığına xas xüsusi konfiqurasiyalar və ya əməliyyatlar həyata keçirilə bilər.
    }
}