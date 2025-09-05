// Fayl: AzAgroPOS.Verilenler/Realizasialar/AlisSifarisRepozitori.cs
namespace AzAgroPOS.Verilenler.Realizasialar;

using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;

/// <summary>
/// AlisSifaris varlığı üçün repozitoriya realizasiyası.
/// </summary>
public class AlisSifarisRepozitori : Repozitori<AlisSifaris>, IAlisSifarisRepozitori
{
    /// <summary>
    /// AlisSifarisRepozitoriyasını yaratmaq üçün konstruktor.
    /// </summary>
    /// <param name="kontekst">Verilənlər bazası konteksti.</param>
    public AlisSifarisRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst)
    {
        // Burada AlisSifaris varlığına xas xüsusi konfiqurasiyalar və ya əməliyyatlar həyata keçirilə bilər.
    }
}