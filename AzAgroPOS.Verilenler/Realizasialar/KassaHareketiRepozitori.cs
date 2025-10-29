// Fayl: AzAgroPOS.Verilenler/Realizasialar/KassaHareketiRepozitori.cs
namespace AzAgroPOS.Verilenler.Realisasialar;

using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Varliglar;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using AzAgroPOS.Verilenler.Realizasialar;

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