// AzAgroPOS.Verilenler/Realizasialar/KonfiqurasiyaRepozitori.cs
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using Microsoft.EntityFrameworkCore;

namespace AzAgroPOS.Verilenler.Realizasialar;

public class KonfiqurasiyaRepozitori : Repozitori<Konfiqurasiya>, IKonfiqurasiyaRepozitori
{
    public KonfiqurasiyaRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst)
    {
    }

    /// <summary>
    /// Açar adı ilə konfiqurasiya parametrini götürür
    /// </summary>
    /// <param name="acar">Konfiqurasiya açarı</param>
    /// <returns>Konfiqurasiya obyekti</returns>
    public async Task<Konfiqurasiya?> AcarlaGetirAsync(string acar)
    {
        return await _dbSet.FirstOrDefaultAsync(k => k.Acar == acar && !k.Silinib);
    }

    /// <summary>
    /// Qrupa görə konfiqurasiya parametrlərini götürür
    /// </summary>
    /// <param name="qrup">Konfiqurasiya qrupu</param>
    /// <returns>Konfiqurasiya parametrlərinin siyahısı</returns>
    public async Task<IEnumerable<Konfiqurasiya>> QruplaGetirAsync(string qrup)
    {
        return await _dbSet.Where(k => k.Qrup == qrup && !k.Silinib).ToListAsync();
    }
}