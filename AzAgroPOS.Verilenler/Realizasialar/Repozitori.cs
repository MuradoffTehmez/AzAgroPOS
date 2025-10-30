using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AzAgroPOS.Verilenler.Realizasialar
{
    public class Repozitori<T> : IRepozitori<T> where T : BazaVarligi
    {
        protected readonly AzAgroPOSDbContext _kontekst;
        protected readonly DbSet<T> _dbSet;

        public Repozitori(AzAgroPOSDbContext kontekst)
        {
            _kontekst = kontekst;
            _dbSet = _kontekst.Set<T>();
        }

        public async Task<IEnumerable<T>> AxtarAsync(Expression<Func<T, bool>>? filter = null, string[]? includeProperties = null)
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

            return await query.ToListAsync();
        }

        public async Task<T> GetirAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(e => e.Id == id && !e.Silinib);
        }

        public async Task<IEnumerable<T>> ButununuGetirAsync()
        {
            return await _dbSet.Where(e => !e.Silinib).ToListAsync();
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

            return await query.ToListAsync();
        }

        /// <summary>
        /// Bütün varlıqları göstərir (silinmişlər də daxil olmaqla)
        /// </summary>
        /// <param name="filter">Əlavə filtr</param>
        /// <param name="includeProperties">Əlaqəli xüsusiyyətlər</param>
        /// <returns>Bütün varlıqların siyahısı</returns>
        public async Task<IEnumerable<T>> ButununuVeSilinmisleriGetirAsync(Expression<Func<T, bool>>? filter = null, string[]? includeProperties = null)
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
                .ToListAsync();

            return (melumatlar, umumiSay);
        }
    }
}