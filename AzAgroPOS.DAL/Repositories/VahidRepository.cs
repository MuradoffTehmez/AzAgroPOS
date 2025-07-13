using AzAgroPOS.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.DAL.Repositories
{
    public class VahidRepository
    {
        public async Task<List<Vahid>> GetAllAsync()
        {
            using (var context = new AzAgroDbContext())
            {
                return await context.Vahidler
                    .Include(v => v.AnaVahid)
                    .Include(v => v.AltVahidler)
                    .OrderBy(v => v.Ad)
                    .ToListAsync();
            }
        }

        public async Task<List<Vahid>> GetAllActiveAsync()
        {
            using (var context = new AzAgroDbContext())
            {
                return await context.Vahidler
                    .Include(v => v.AnaVahid)
                    .Include(v => v.AltVahidler)
                    .Where(v => v.Status == "Aktiv")
                    .OrderBy(v => v.Ad)
                    .ToListAsync();
            }
        }

        public async Task<Vahid> GetByIdAsync(int id)
        {
            using (var context = new AzAgroDbContext())
            {
                return await context.Vahidler
                    .Include(v => v.AnaVahid)
                    .Include(v => v.AltVahidler)
                    .FirstOrDefaultAsync(v => v.Id == id);
            }
        }

        public async Task<List<Vahid>> GetByTipiAsync(string tipi)
        {
            using (var context = new AzAgroDbContext())
            {
                return await context.Vahidler
                    .Include(v => v.AnaVahid)
                    .Where(v => v.Tipi == tipi && v.Status == "Aktiv")
                    .OrderBy(v => v.Ad)
                    .ToListAsync();
            }
        }

        public async Task<List<Vahid>> GetAnaVahidlerAsync()
        {
            using (var context = new AzAgroDbContext())
            {
                return await context.Vahidler
                    .Include(v => v.AltVahidler)
                    .Where(v => v.AnaVahidId == null && v.Status == "Aktiv")
                    .OrderBy(v => v.Ad)
                    .ToListAsync();
            }
        }

        public async Task<List<Vahid>> GetAltVahidlerAsync(int anaVahidId)
        {
            using (var context = new AzAgroDbContext())
            {
                return await context.Vahidler
                    .Include(v => v.AnaVahid)
                    .Where(v => v.AnaVahidId == anaVahidId && v.Status == "Aktiv")
                    .OrderBy(v => v.Ad)
                    .ToListAsync();
            }
        }

        public async Task<List<Vahid>> SearchAsync(string searchTerm)
        {
            using (var context = new AzAgroDbContext())
            {
                var term = searchTerm.ToLower();
                return await context.Vahidler
                    .Include(v => v.AnaVahid)
                    .Where(v => v.Ad.ToLower().Contains(term) ||
                               v.QisaAd.ToLower().Contains(term) ||
                               v.Tesvir.ToLower().Contains(term) ||
                               v.Tipi.ToLower().Contains(term))
                    .OrderBy(v => v.Ad)
                    .ToListAsync();
            }
        }

        public async Task<bool> QisaAdMevcudAsync(string qisaAd, int? excludeId = null)
        {
            using (var context = new AzAgroDbContext())
            {
                var query = context.Vahidler.Where(v => v.QisaAd == qisaAd);
                if (excludeId.HasValue)
                {
                    query = query.Where(v => v.Id != excludeId.Value);
                }
                return await query.AnyAsync();
            }
        }

        public async Task<bool> AdMevcudAsync(string ad, int? excludeId = null)
        {
            using (var context = new AzAgroDbContext())
            {
                var query = context.Vahidler.Where(v => v.Ad == ad);
                if (excludeId.HasValue)
                {
                    query = query.Where(v => v.Id != excludeId.Value);
                }
                return await query.AnyAsync();
            }
        }

        public async Task<int> AddAsync(Vahid vahid)
        {
            using (var context = new AzAgroDbContext())
            {
                vahid.YaradilmaTarixi = DateTime.Now;
                context.Vahidler.Add(vahid);
                await context.SaveChangesAsync();
                return vahid.Id;
            }
        }

        public async Task UpdateAsync(Vahid vahid)
        {
            using (var context = new AzAgroDbContext())
            {
                vahid.YenilenmeTarixi = DateTime.Now;
                context.Vahidler.Update(vahid);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var context = new AzAgroDbContext())
            {
                var vahid = await context.Vahidler.FindAsync(id);
                if (vahid != null)
                {
                    context.Vahidler.Remove(vahid);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<bool> CanDeleteAsync(int id)
        {
            using (var context = new AzAgroDbContext())
            {
                // Alt vahidlər var mı?
                var altVahidVar = await context.Vahidler.AnyAsync(v => v.AnaVahidId == id);
                if (altVahidVar)
                    return false;

                // Bu vahiddə məhsullar var mı?
                var mehsulVar = await context.Mehsullar.AnyAsync(m => m.VahidId == id);
                if (mehsulVar)
                    return false;

                return true;
            }
        }

        public async Task<decimal> CevirmeHesablaAsync(int fromVahidId, int toVahidId, decimal miqdar)
        {
            using (var context = new AzAgroDbContext())
            {
                var fromVahid = await context.Vahidler.FindAsync(fromVahidId);
                var toVahid = await context.Vahidler.FindAsync(toVahidId);

                if (fromVahid == null || toVahid == null)
                    throw new ArgumentException("Vahidlər tapılmadı");

                // Eyni vahiddirsə
                if (fromVahidId == toVahidId)
                    return miqdar;

                // Hər ikisi eyni ana vahidə aiddirsə
                if (fromVahid.AnaVahidId == toVahid.AnaVahidId && fromVahid.AnaVahidId.HasValue)
                {
                    // Ana vahidə çevir, sonra hədəf vahidə
                    var anaVahidMiqdar = miqdar * fromVahid.CevirmeEmsali;
                    return anaVahidMiqdar / toVahid.CevirmeEmsali;
                }

                // Çevirmə mümkün deyil
                throw new InvalidOperationException("Bu vahidlər arasında çevirmə mümkün deyil");
            }
        }

        public async Task<List<string>> GetVahidTipleriAsync()
        {
            using (var context = new AzAgroDbContext())
            {
                return await context.Vahidler
                    .Where(v => v.Status == "Aktiv")
                    .Select(v => v.Tipi)
                    .Distinct()
                    .OrderBy(t => t)
                    .ToListAsync();
            }
        }

        public async Task<Dictionary<string, object>> GetStatistikalarAsync()
        {
            using (var context = new AzAgroDbContext())
            {
                var statistikalar = new Dictionary<string, object>();

                statistikalar["UmumiVahidSayi"] = await context.Vahidler.CountAsync();
                statistikalar["AktivVahidSayi"] = await context.Vahidler.CountAsync(v => v.Status == "Aktiv");
                statistikalar["AnaVahidSayi"] = await context.Vahidler.CountAsync(v => v.AnaVahidId == null && v.Status == "Aktiv");

                var tiplerSayi = await context.Vahidler
                    .Where(v => v.Status == "Aktiv")
                    .GroupBy(v => v.Tipi)
                    .Select(g => new { Tipi = g.Key, Sayi = g.Count() })
                    .ToDictionaryAsync(x => x.Tipi, x => x.Sayi);

                statistikalar["TiplerSayi"] = tiplerSayi;

                return statistikalar;
            }
        }
    }
}