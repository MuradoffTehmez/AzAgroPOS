using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// satis üçün CRUD əməliyyatlarını həyata keçirən repozitoriya.
/// diqqət: Bu sinif, CRUD əməliyyatlarını (Yarat, Oxu, Yenilə, Sil) ümumi şəkildə həyata keçirir.
/// q
/// </summary>
public class SatisRepozitori : Repozitori<AzAgroPOS.Varliglar.Satis>, ISatisRepozitori
{
    public SatisRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst)
    {
    }

    /// <summary>
    /// Satışı SatisDetallari + Mehsul nested-include ilə gətirir.
    /// Include(s => s.SatisDetallari).ThenInclude(d => d.Mehsul) EF Core zənciri istifadə edir.
    /// </summary>
    public async Task<Satis?> SatisDetallariIleBirlikdeGetirAsync(int satisId)
    {
        return await _kontekst.Set<Satis>()
            .AsNoTracking()
            .Include(s => s.SatisDetallari)
                .ThenInclude(d => d.Mehsul)
            .FirstOrDefaultAsync(s => s.Id == satisId);
    }
}