// Fayl: AzAgroPOS.Verilenler/Realizasialar/EmekHaqqiRepozitori.cs
namespace AzAgroPOS.Verilenler.Realisasialar;

using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;

/// <summary>
/// Əmək haqqı əməliyyatları üçün repozitori sinifi.
/// diqqət: Bu sinif əmək haqqı qeydlərinin verilənlər bazası əməliyyatlarını həyata keçirir.
/// qeyd: Repozitori<EmekHaqqi> sinfini miras alır və baza funksionallığı təmin edir.
/// </summary>
public class EmekHaqqiRepozitori : Repozitori<EmekHaqqi>, IEmekHaqqiRepozitori
{
    public EmekHaqqiRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst)
    {
    }
}
