// Fayl: AzAgroPOS.Verilenler/Realizasialar/KassaHareketiRepozitori.cs

using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;

namespace AzAgroPOS.Verilenler.Realisasialar;
/// <summary>
/// Kassa hərəkəti repozitorisinin Entity Framework tətbiqi
/// diqqət: Bu sinif kassa hərəkətləri əməliyyatları üçün verilənlər bazası əməliyyatlarını həyata keçirir.
/// qeyd: IRepozitori<KassaHareketi> interfeysini tətbiq edir.
/// </summary>
public class KassaHareketiRepozitori : Repozitori<KassaHareketi>, IKassaHareketiRepozitori
{
    public KassaHareketiRepozitori(AzAgroPOSDbContext context) : base(context)
    {
    }
}