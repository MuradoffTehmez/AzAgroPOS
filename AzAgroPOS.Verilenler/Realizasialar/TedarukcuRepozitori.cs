// Fayl: AzAgroPOS.Verilenler/Realizasialar/TedarukcuRepozitori.cs

using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;

namespace AzAgroPOS.Verilenler.Realizasialar;
/// <summary>
/// Tedarukcu varlığı üçün repozitoriya realizasiyası.
/// </summary>
public class TedarukcuRepozitori : Repozitori<Tedarukcu>, ITedarukcuRepozitori
{
    /// <summary>
    /// TedarukcuRepozitoriyasını yaratmaq üçün konstruktor.
    /// </summary>
    /// <param name="kontekst">Verilənlər bazası konteksti.</param>
    public TedarukcuRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst)
    {
        // Burada Tedarukcu varlığına xas xüsusi konfiqurasiyalar və ya əməliyyatlar həyata keçirilə bilər.
    }
}