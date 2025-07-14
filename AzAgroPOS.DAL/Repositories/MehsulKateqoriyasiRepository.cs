using AzAgroPOS.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.DAL.Repositories
{
    public class MehsulKateqoriyasiRepository : IDisposable
    {
        private readonly AzAgroDbContext _context;

        public MehsulKateqoriyasiRepository(AzAgroDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<MehsulKateqoriyasi>> GetAllAsync()
        {
            return await _context.MehsulKateqoriyalari
                .Include(k => k.UstKateqoriya)
                .Include(k => k.AltKateqoriyalar)
                .OrderBy(k => k.Ad)
                .ToListAsync();
        }

        public async Task<List<MehsulKateqoriyasi>> GetAllActiveAsync()
        {
            using (var context = new AzAgroDbContext())
            {
                return await context.MehsulKateqoriyalari
                    .Include(k => k.UstKateqoriya)
                    .Include(k => k.AltKateqoriyalar)
                    .Where(k => k.Status == "Aktiv")
                    .OrderBy(k => k.Ad)
                    .ToListAsync();
            }
        }

        public async Task<MehsulKateqoriyasi> GetByIdAsync(int id)
        {
            using (var context = new AzAgroDbContext())
            {
                return await context.MehsulKateqoriyalari
                    .Include(k => k.UstKateqoriya)
                    .Include(k => k.AltKateqoriyalar)
                    .FirstOrDefaultAsync(k => k.Id == id);
            }
        }

        public async Task<List<MehsulKateqoriyasi>> GetAnaKateqoriyalarAsync()
        {
            using (var context = new AzAgroDbContext())
            {
                return await context.MehsulKateqoriyalari
                    .Include(k => k.AltKateqoriyalar)
                    .Where(k => k.UstKateqoriyaId == null && k.Status == "Aktiv")
                    .OrderBy(k => k.Ad)
                    .ToListAsync();
            }
        }

        public async Task<List<MehsulKateqoriyasi>> GetAltKateqoriyalarAsync(int ustKateqoriyaId)
        {
            using (var context = new AzAgroDbContext())
            {
                return await context.MehsulKateqoriyalari
                    .Include(k => k.UstKateqoriya)
                    .Where(k => k.UstKateqoriyaId == ustKateqoriyaId && k.Status == "Aktiv")
                    .OrderBy(k => k.Ad)
                    .ToListAsync();
            }
        }

        public async Task<List<MehsulKateqoriyasi>> SearchAsync(string searchTerm)
        {
            using (var context = new AzAgroDbContext())
            {
                var term = searchTerm.ToLower();
                return await context.MehsulKateqoriyalari
                    .Include(k => k.UstKateqoriya)
                    .Where(k => k.Ad.ToLower().Contains(term) ||
                               k.Kod.ToLower().Contains(term) ||
                               k.Tesvir.ToLower().Contains(term))
                    .OrderBy(k => k.Ad)
                    .ToListAsync();
            }
        }

        public async Task<bool> KodMevcudAsync(string kod, int? excludeId = null)
        {
            using (var context = new AzAgroDbContext())
            {
                var query = context.MehsulKateqoriyalari.Where(k => k.Kod == kod);
                if (excludeId.HasValue)
                {
                    query = query.Where(k => k.Id != excludeId.Value);
                }
                return await query.AnyAsync();
            }
        }

        public async Task<bool> AdMevcudAsync(string ad, int? ustKateqoriyaId, int? excludeId = null)
        {
            using (var context = new AzAgroDbContext())
            {
                var query = context.MehsulKateqoriyalari.Where(k => k.Ad == ad && k.UstKateqoriyaId == ustKateqoriyaId);
                if (excludeId.HasValue)
                {
                    query = query.Where(k => k.Id != excludeId.Value);
                }
                return await query.AnyAsync();
            }
        }

        public async Task<int> AddAsync(MehsulKateqoriyasi kateqoriya)
        {
            using (var context = new AzAgroDbContext())
            {
                kateqoriya.YaradilmaTarixi = DateTime.Now;
                
                // Kod avtomatik yaradılsın əgər verilməyibsə
                if (string.IsNullOrEmpty(kateqoriya.Kod))
                {
                    kateqoriya.Kod = await GenerateKodAsync(context, kateqoriya.UstKateqoriyaId);
                }

                context.MehsulKateqoriyalari.Add(kateqoriya);
                await context.SaveChangesAsync();
                return kateqoriya.Id;
            }
        }

        public async Task UpdateAsync(MehsulKateqoriyasi kateqoriya)
        {
            using (var context = new AzAgroDbContext())
            {
                kateqoriya.YenilenmeTarixi = DateTime.Now;
                context.MehsulKateqoriyalari.Update(kateqoriya);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var context = new AzAgroDbContext())
            {
                var kateqoriya = await context.MehsulKateqoriyalari.FindAsync(id);
                if (kateqoriya != null)
                {
                    context.MehsulKateqoriyalari.Remove(kateqoriya);
                    await context.SaveChangesAsync();
                }
            }
        }

        public async Task<bool> CanDeleteAsync(int id)
        {
            using (var context = new AzAgroDbContext())
            {
                // Alt kateqoriyalar var mı?
                var altKateqoriyaVar = await context.MehsulKateqoriyalari.AnyAsync(k => k.UstKateqoriyaId == id);
                if (altKateqoriyaVar)
                    return false;

                // Bu kateqoriyada məhsullar var mı?
                var mehsulVar = await context.Mehsullar.AnyAsync(m => m.KateqoriyaId == id);
                if (mehsulVar)
                    return false;

                return true;
            }
        }

        public async Task<string> GenerateKodAsync(AzAgroDbContext context, int? ustKateqoriyaId)
        {
            string prefix = "K";
            
            if (ustKateqoriyaId.HasValue)
            {
                var ustKateqoriya = await context.MehsulKateqoriyalari.FindAsync(ustKateqoriyaId.Value);
                if (ustKateqoriya != null && !string.IsNullOrEmpty(ustKateqoriya.Kod))
                {
                    prefix = ustKateqoriya.Kod;
                }
            }

            var existingCodes = await context.MehsulKateqoriyalari
                .Where(k => k.Kod.StartsWith(prefix))
                .Select(k => k.Kod)
                .ToListAsync();

            int maxNumber = 0;
            foreach (var code in existingCodes)
            {
                if (code.Length > prefix.Length)
                {
                    var numberPart = code.Substring(prefix.Length);
                    if (int.TryParse(numberPart, out int number))
                    {
                        maxNumber = Math.Max(maxNumber, number);
                    }
                }
            }

            return $"{prefix}{(maxNumber + 1):D3}";
        }

        public async Task<Dictionary<string, object>> GetStatistikalarAsync()
        {
            using (var context = new AzAgroDbContext())
            {
                var statistikalar = new Dictionary<string, object>();

                statistikalar["UmumiKateqoriyaSayi"] = await context.MehsulKateqoriyalari.CountAsync();
                statistikalar["AktivKateqoriyaSayi"] = await context.MehsulKateqoriyalari.CountAsync(k => k.Status == "Aktiv");
                statistikalar["AnaKateqoriyaSayi"] = await context.MehsulKateqoriyalari.CountAsync(k => k.UstKateqoriyaId == null && k.Status == "Aktiv");

                return statistikalar;
            }
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}