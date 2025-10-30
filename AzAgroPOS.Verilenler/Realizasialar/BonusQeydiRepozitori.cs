// Fayl: AzAgroPOS.Verilenler/Realizasialar/BonusQeydiRepozitori.cs
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using Microsoft.EntityFrameworkCore;

namespace AzAgroPOS.Verilenler.Realizasialar;

public class BonusQeydiRepozitori : Repozitori<BonusQeydi>, IBonusQeydiRepozitori
{
    public BonusQeydiRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst)
    {
    }

    public async Task<IEnumerable<BonusQeydi>> MusteriTarixcesiniGetirAsync(int musteriBonusId)
    {
        return await _dbSet
            .Where(bq => bq.MusteriBonusId == musteriBonusId && !bq.Silinib)
            .OrderByDescending(bq => bq.EmeliyyatTarixi)
            .ToListAsync();
    }
}
