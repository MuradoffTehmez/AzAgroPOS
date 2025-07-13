using AzAgroPOS.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.DAL.Repositories
{
    public class MehsulRepository
    {
        public async Task<List<Mehsul>> GetAllAsync()
        {
            using (var context = new AzAgroDbContext())
            {
                return await context.Mehsullar
                    .Include(m => m.Kateqoriya)
                    .Include(m => m.Vahid)
                    .OrderBy(m => m.Ad)
                    .ToListAsync();
            }
        }

        public async Task<List<Mehsul>> GetAllActiveAsync()
        {
            using (var context = new AzAgroDbContext())
            {
                return await context.Mehsullar
                    .Include(m => m.Kateqoriya)
                    .Include(m => m.Vahid)
                    .Where(m => m.Status == "Aktiv")
                    .OrderBy(m => m.Ad)
                    .ToListAsync();
            }
        }

        public async Task<Mehsul> GetByIdAsync(int id)
        {
            using (var context = new AzAgroDbContext())
            {
                return await context.Mehsullar
                    .Include(m => m.Kateqoriya)
                    .Include(m => m.Vahid)
                    .FirstOrDefaultAsync(m => m.Id == id);
            }
        }

        public async Task<Mehsul> GetByBarkodAsync(string barkod)
        {
            using (var context = new AzAgroDbContext())
            {
                return await context.Mehsullar
                    .Include(m => m.Kateqoriya)
                    .Include(m => m.Vahid)
                    .FirstOrDefaultAsync(m => m.Barkod == barkod);
            }
        }

        public async Task<Mehsul> GetBySKUAsync(string sku)
        {
            using (var context = new AzAgroDbContext())
            {
                return await context.Mehsullar
                    .Include(m => m.Kateqoriya)
                    .Include(m => m.Vahid)
                    .FirstOrDefaultAsync(m => m.SKU == sku);
            }
        }

        public async Task<List<Mehsul>> GetByKateqoriyaAsync(int kateqoriyaId)
        {
            using (var context = new AzAgroDbContext())
            {
                return await context.Mehsullar
                    .Include(m => m.Kateqoriya)
                    .Include(m => m.Vahid)
                    .Where(m => m.KateqoriyaId == kateqoriyaId && m.Status == "Aktiv")
                    .OrderBy(m => m.Ad)
                    .ToListAsync();
            }
        }

        public async Task<List<Mehsul>> SearchAsync(string searchTerm)
        {
            using (var context = new AzAgroDbContext())
            {
                var term = searchTerm.ToLower();
                return await context.Mehsullar
                    .Include(m => m.Kateqoriya)
                    .Include(m => m.Vahid)
                    .Where(m => m.Ad.ToLower().Contains(term) ||
                               m.Barkod.ToLower().Contains(term) ||
                               m.SKU.ToLower().Contains(term) ||
                               m.Tesvir.ToLower().Contains(term))
                    .OrderBy(m => m.Ad)
                    .ToListAsync();
            }
        }

        public async Task<List<Mehsul>> GetStoktanKenardaAsync()
        {
            using (var context = new AzAgroDbContext())
            {
                return await context.Mehsullar
                    .Include(m => m.Kateqoriya)
                    .Include(m => m.Vahid)
                    .Where(m => m.Status == "Aktiv" && m.MovcudMiqdar <= m.MinimumMiqdar)
                    .OrderBy(m => m.Ad)
                    .ToListAsync();
            }
        }

        public async Task<bool> BarkodMevcudAsync(string barkod, int? excludeId = null)
        {
            using (var context = new AzAgroDbContext())
            {
                var query = context.Mehsullar.Where(m => m.Barkod == barkod);
                if (excludeId.HasValue)
                {
                    query = query.Where(m => m.Id != excludeId.Value);
                }
                return await query.AnyAsync();
            }
        }

        public async Task<bool> SKUMevcudAsync(string sku, int? excludeId = null)
        {
            using (var context = new AzAgroDbContext())
            {
                var query = context.Mehsullar.Where(m => m.SKU == sku);
                if (excludeId.HasValue)
                {
                    query = query.Where(m => m.Id != excludeId.Value);
                }
                return await query.AnyAsync();
            }
        }

        public async Task<int> AddAsync(Mehsul mehsul)
        {
            using (var context = new AzAgroDbContext())
            {
                mehsul.YaradilmaTarixi = DateTime.Now;
                context.Mehsullar.Add(mehsul);
                await context.SaveChangesAsync();
                return mehsul.Id;
            }
        }

        public async Task UpdateAsync(Mehsul mehsul)
        {
            using (var context = new AzAgroDbContext())
            {
                mehsul.YenilenmeTarixi = DateTime.Now;
                context.Mehsullar.Update(mehsul);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var context = new AzAgroDbContext())
            {
                var mehsul = await context.Mehsullar.FindAsync(id);
                if (mehsul != null)
                {
                    context.Mehsullar.Remove(mehsul);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<bool> CanDeleteAsync(int id)
        {
            using (var context = new AzAgroDbContext())
            {
                // Burada satış, alış və digər əlaqələr yoxlanılacaq
                // Hələlik sadəcə mövcudluq yoxlayırıq
                return await context.Mehsullar.AnyAsync(m => m.Id == id);
            }
        }

        public async Task UpdateMiqdarAsync(int mehsulId, decimal yeniMiqdar)
        {
            using (var context = new AzAgroDbContext())
            {
                var mehsul = await context.Mehsullar.FindAsync(mehsulId);
                if (mehsul != null)
                {
                    mehsul.MovcudMiqdar = yeniMiqdar;
                    mehsul.YenilenmeTarixi = DateTime.Now;
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<Dictionary<string, object>> GetStatistikalarAsync()
        {
            using (var context = new AzAgroDbContext())
            {
                var statistikalar = new Dictionary<string, object>();

                statistikalar["UmumiMehsulSayi"] = await context.Mehsullar.CountAsync();
                statistikalar["AktivMehsulSayi"] = await context.Mehsullar.CountAsync(m => m.Status == "Aktiv");
                statistikalar["StoktanKenardaMehsulSayi"] = await context.Mehsullar.CountAsync(m => m.Status == "Aktiv" && m.MovcudMiqdar <= m.MinimumMiqdar);
                statistikalar["UmumiDeger"] = await context.Mehsullar.Where(m => m.Status == "Aktiv").SumAsync(m => m.MovcudMiqdar * m.SatisQiymeti);

                return statistikalar;
            }
        }
    }
}