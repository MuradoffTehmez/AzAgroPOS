// Fayl: AzAgroPOS.Verilenler/Realizasialar/XercRepozitori.cs
namespace AzAgroPOS.Verilenler.Realisasialar;

using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;

/// <summary>
/// Xərc repozitorisinin Entity Framework tətbiqi
/// diqqət: Bu sinif xərc əməliyyatları üçün verilənlər bazası əməliyyatlarını həyata keçirir.
/// qeyd: IRepozitori<Xerc> interfeysini tətbiq edir.
/// </summary>
public class XercRepozitori : Repozitori<Xerc>, IXercRepozitori
{
    public XercRepozitori(AzAgroPOSDbContext context) : base(context)
    {
    }
}