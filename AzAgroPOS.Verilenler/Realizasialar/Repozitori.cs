using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Interfeysler;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AzAgroPOS.Verilenler.Realizasialar
{
    public class Repozitori<T> : IRepozitori<T> where T : class
    {
        protected readonly AzAgroPOSDbContext _kontekst;
        private readonly DbSet<T> _dbSet;

        public Repozitori(AzAgroPOSDbContext kontekst)
        {
            _kontekst = kontekst;
            _dbSet = _kontekst.Set<T>();
        }

        public async Task<IEnumerable<T>> AxtarAsync(Expression<Func<T, bool>>? filter = null, string[]? includeProperties = null)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetirAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> ButununuGetirAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task ElaveEtAsync(T varliq)
        {
            await _dbSet.AddAsync(varliq);
        }

        public void Yenile(T varliq)
        {
            _dbSet.Attach(varliq);
            _kontekst.Entry(varliq).State = EntityState.Modified;
        }

        public void Sil(T varliq)
        {
            _dbSet.Remove(varliq);
        }
    }
}