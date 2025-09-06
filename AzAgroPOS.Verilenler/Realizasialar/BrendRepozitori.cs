// Fayl: AzAgroPOS.Verilenler/Realizasialar/BrendRepozitori.cs
namespace AzAgroPOS.Verilenler.Realizasialar;

using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Brend varlığı üçün repozitoriya realizasiyası.
/// </summary>
public class BrendRepozitori : Repozitori<Brend>, IBrendRepozitori
{
    /// <summary>
    /// BrendRepozitoriyasını yaratmaq üçün konstruktor.
    /// </summary>
    /// <param name="kontekst">Verilənlər bazası konteksti.</param>
    public BrendRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst)
    {
        // Burada Brend varlığına xas xüsusi konfiqurasiyalar və ya əməliyyatlar həyata keçirilə bilər.
    }
}