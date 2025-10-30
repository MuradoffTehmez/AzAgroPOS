// Fayl: AzAgroPOS.Verilenler/Realizasialar/MusteriBonusRepozitori.cs
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using Microsoft.EntityFrameworkCore;

namespace AzAgroPOS.Verilenler.Realizasialar;

public class MusteriBonusRepozitori : Repozitori<MusteriBonus>, IMusteriBonusRepozitori
{
    public MusteriBonusRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst)
    {
    }

    public async Task<MusteriBonus?> MusteriUzreGetirAsync(int musteriId)
    {
        return await _dbSet
            .Include(mb => mb.BonusQeydleri)
            .Include(mb => mb.Musteri)
            .FirstOrDefaultAsync(mb => mb.MusteriId == musteriId && !mb.Silinib);
    }
}
