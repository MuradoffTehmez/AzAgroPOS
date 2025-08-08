// Fayl: AzAgroPOS.Verilenler/Realizasialar/Repozitori.cs
namespace AzAgroPOS.Verilenler.Realizasialar;

using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using Microsoft.EntityFrameworkCore;

public class Repozitori<T> : IRepozitori<T> where T : BazaVarligi
{
    protected readonly AzAgroPOSDbContext _kontekst;

    public Repozitori(AzAgroPOSDbContext kontekst)
    {
        _kontekst = kontekst;
    }

    public async Task<T?> GetirAsync(int id)
    {
        return await _kontekst.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> ButununuGetirAsync()
    {
        return await _kontekst.Set<T>().ToListAsync();
    }

    public async Task<IEnumerable<T>> AxtarAsync(Expression<Func<T, bool>> predicate)
    {
        return await _kontekst.Set<T>().Where(predicate).ToListAsync();
    }

    public async Task ElaveEtAsync(T varliq)
    {
        await _kontekst.Set<T>().AddAsync(varliq);
    }

    public void Yenile(T varliq)
    {
        _kontekst.Set<T>().Update(varliq);
    }

    public void Sil(T varliq)
    {
        _kontekst.Set<T>().Remove(varliq);
    }
}