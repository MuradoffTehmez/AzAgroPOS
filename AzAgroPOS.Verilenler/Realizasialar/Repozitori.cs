using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading;

namespace AzAgroPOS.Verilenler.Realizasialar
{
    public class Repozitori<T> : IRepozitori<T>, IDisposable where T : BazaVarligi
    {
        protected readonly AzAgroPOSDbContext _kontekst;
        protected readonly DbSet<T> _dbSet;
        private readonly SemaphoreSlim _semaphore = new(1, 1); // Only allow 1 operation at a time
        private bool _disposed = false;

        public Repozitori(AzAgroPOSDbContext kontekst)
        {
            _kontekst = kontekst;
            _dbSet = _kontekst.Set<T>();
        }

        /// <summary>
        /// Resurları azad edir (Dispose pattern)
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Resurları azad edir (protected virtual method)
        /// </summary>
        /// <param name="disposing">Managed resurları azad etmək üçün true</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Managed resurları azad et
                    _semaphore?.Dispose();
                }

                _disposed = true;
            }
        }

        public async Task<IEnumerable<T>> AxtarAsync(Expression<Func<T, bool>>? filter = null, string[]? includeProperties = null)
        {
            await _semaphore.WaitAsync();
            try
            {
                IQueryable<T> query = _dbSet;

                // Filter out deleted records by default
                query = query.Where(e => !e.Silinib);

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

                // Execute the query and return results - this should be thread-safe within the scope
                return await query.AsNoTracking().ToListAsync();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task<T> GetirAsync(int id)
        {
            await _semaphore.WaitAsync();
            try
            {
                return await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id && !e.Silinib);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task<IEnumerable<T>> ButununuGetirAsync()
        {
            await _semaphore.WaitAsync();
            try
            {
                return await _dbSet.Where(e => !e.Silinib).AsNoTracking().ToListAsync();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public async Task ElaveEtAsync(T varliq)
        {
            await _semaphore.WaitAsync();
            try
            {
                await _dbSet.AddAsync(varliq);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public void Yenile(T varliq)
        {
            _dbSet.Attach(varliq);
            _kontekst.Entry(varliq).State = EntityState.Modified;
        }

        public void Sil(T varliq)
        {
            // Soft delete - mark as deleted instead of physical removal
            varliq.Silinib = true;
            _dbSet.Attach(varliq);
            _kontekst.Entry(varliq).State = EntityState.Modified;
        }

        /// <summary>
        /// Fiziki olaraq silir (geri qaytarılmaz)
        /// </summary>
        /// <param name="varliq">Silinəcək varlıq</param>
        public void FizikiSil(T varliq)
        {
            // Hard delete - physically remove from database
            _dbSet.Remove(varliq);
        }

        /// <summary>
        /// Silinmiş varlıqları göstərir
        /// </summary>
        /// <param name="filter">Əlavə filtr</param>
        /// <param name="includeProperties">Əlaqəli xüsusiyyətlər</param>
        /// <returns>Silinmiş varlıqların siyahısı</returns>
        public async Task<IEnumerable<T>> SilinmisleriGetirAsync(Expression<Func<T, bool>>? filter = null, string[]? includeProperties = null)
        {
            await _semaphore.WaitAsync();
            try
            {
                IQueryable<T> query = _dbSet;

                // Only show deleted records
                query = query.Where(e => e.Silinib);

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

                return await query.AsNoTracking().ToListAsync();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        /// Bütün varlıqları göstərir (silinmişlər də daxil olmaqla)
        /// </summary>
        /// <param name="filter">Əlavə filtr</param>
        /// <param name="includeProperties">Əlaqəli xüsusiyyətlər</param>
        /// <returns>Bütün varlıqların siyahısı</returns>
        public async Task<IEnumerable<T>> ButununuVeSilinmisleriGetirAsync(Expression<Func<T, bool>>? filter = null, string[]? includeProperties = null)
        {
            await _semaphore.WaitAsync();
            try
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

                return await query.AsNoTracking().ToListAsync();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        /// Səhifələnmiş məlumat əldə edir
        /// </summary>
        /// <param name="sehifeNomresi">Səhifə nömrəsi (1-dən başlayır)</param>
        /// <param name="sehifeOlcusu">Hər səhifədə göstəriləcək qeyd sayı</param>
        /// <param name="filter">Filtr şərti</param>
        /// <param name="includeProperties">Əlaqəli xüsusiyyətlər</param>
        /// <returns>Səhifələnmiş məlumat və ümumi say</returns>
        public async Task<(IEnumerable<T> Melumatlar, int UmumiSay)> SehifelenmisGetirAsync(
            int sehifeNomresi,
            int sehifeOlcusu,
            Expression<Func<T, bool>>? filter = null,
            string[]? includeProperties = null)
        {
            await _semaphore.WaitAsync();
            try
            {
                IQueryable<T> query = _dbSet;

                // Silinmiş qeydləri filter et
                query = query.Where(e => !e.Silinib);

                // Əlavə filtr tətbiq et
                if (filter != null)
                {
                    query = query.Where(filter);
                }

                // Ümumi say
                var umumiSay = await query.CountAsync();

                // Include properties
                if (includeProperties != null)
                {
                    foreach (var includeProperty in includeProperties)
                    {
                        query = query.Include(includeProperty);
                    }
                }

                // Səhifələmə - SKIP və TAKE
                var kec = (sehifeNomresi - 1) * sehifeOlcusu;
                var melumatlar = await query
                    .Skip(kec)
                    .Take(sehifeOlcusu)
                    .AsNoTracking()
                    .ToListAsync();

                return (melumatlar, umumiSay);
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}