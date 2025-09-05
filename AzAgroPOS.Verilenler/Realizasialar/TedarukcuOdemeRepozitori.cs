// Fayl: AzAgroPOS.Verilenler/Realizasialar/TedarukcuOdemeRepozitori.cs
namespace AzAgroPOS.Verilenler.Realizasialar;

using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;

/// <summary>
/// TedarukcuOdeme varlığı üçün repozitoriya realizasiyası.
/// </summary>
public class TedarukcuOdemeRepozitori : Repozitori<TedarukcuOdeme>, ITedarukcuOdemeRepozitori
{
    /// <summary>
    /// TedarukcuOdemeRepozitoriyasını yaratmaq üçün konstruktor.
    /// </summary>
    /// <param name="kontekst">Verilənlər bazası konteksti.</param>
    public TedarukcuOdemeRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst)
    {
        // Burada TedarukcuOdeme varlığına xas xüsusi konfiqurasiyalar və ya əməliyyatlar həyata keçirilə bilər.
    }
}