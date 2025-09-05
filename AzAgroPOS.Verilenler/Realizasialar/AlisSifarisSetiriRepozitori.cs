// Fayl: AzAgroPOS.Verilenler/Realizasialar/AlisSifarisSetiriRepozitori.cs
namespace AzAgroPOS.Verilenler.Realizasialar;

using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;

/// <summary>
/// AlisSifarisSetiri varlığı üçün repozitoriya realizasiyası.
/// </summary>
public class AlisSifarisSetiriRepozitori : Repozitori<AlisSifarisSetiri>, IAlisSifarisSetiriRepozitori
{
    /// <summary>
    /// AlisSifarisSetiriRepozitoriyasını yaratmaq üçün konstruktor.
    /// </summary>
    /// <param name="kontekst">Verilənlər bazası konteksti.</param>
    public AlisSifarisSetiriRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst)
    {
        // Burada AlisSifarisSetiri varlığına xas xüsusi konfiqurasiyalar və ya əməliyyatlar həyata keçirilə bilər.
    }
}