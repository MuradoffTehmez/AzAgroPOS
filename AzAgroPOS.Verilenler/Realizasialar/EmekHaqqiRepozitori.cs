// Fayl: AzAgroPOS.Verilenler/Realizasialar/EmekHaqqiRepozitori.cs

using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;

namespace AzAgroPOS.Verilenler.Realisasialar;
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
