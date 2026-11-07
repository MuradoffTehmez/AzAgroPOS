using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Kontekst;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Əvvəlki satış axınında yazılmamış sətirləri yalnız stok çıxışları satış
/// məbləğinə tam uyğun gələndə bərpa edir. Təxminlə sətir yaratmır.
/// </summary>
internal static class SaleDetailRepair
{
    public static async Task RunAsync(AzAgroPOSDbContext db)
    {
        await using var transaction = await db.Database.BeginTransactionAsync();
        var missing = await db.Satislar
            .Where(s => !db.SatisDetallari.Any(d => d.SatisId == s.Id))
            .ToListAsync();
        int repaired = 0;
        foreach (Satis sale in missing)
        {
            var movements = await db.StokHareketleri
                .Where(m => m.SenedNovu == SenedNovu.Satis && m.SenedId == sale.Id &&
                            m.HareketTipi == StokHareketTipi.Cixis && !m.Silinib)
                .ToListAsync();
            if (movements.Count == 0 || movements.Any(m => m.Miqdar == 0 || m.SatisQiymeti <= 0))
                continue;

            decimal gross = movements.Sum(m => Math.Abs(m.Miqdar) * m.SatisQiymeti);
            if (gross != sale.UmumiMebleg)
                continue;

            var productIds = movements.Select(m => m.MehsulId).Distinct().ToArray();
            int productCount = await db.Mehsullar.CountAsync(p => productIds.Contains(p.Id));
            if (productCount != productIds.Length)
                continue;

            foreach (var group in movements.GroupBy(m => new { m.MehsulId, m.SatisQiymeti, m.AlisQiymeti }))
            {
                decimal quantity = group.Sum(m => Math.Abs(m.Miqdar));
                db.SatisDetallari.Add(new SatisDetali
                {
                    SatisId = sale.Id,
                    MehsulId = group.Key.MehsulId,
                    Miqdar = quantity,
                    Qiymet = group.Key.SatisQiymeti,
                    AlisQiymeti = group.Key.AlisQiymeti,
                    UmumiMebleg = quantity * group.Key.SatisQiymeti
                });
            }
            repaired++;
        }
        await db.SaveChangesAsync();
        await transaction.CommitAsync();
        Console.WriteLine($"Detalları bərpa edilən satış: {repaired}; etibarlı stok uyğunluğu olmayan satış: {missing.Count - repaired}.");
    }
}
