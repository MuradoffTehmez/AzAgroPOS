using AzAgroPOS.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.DAL.Repositories
{
    public class SatisHesabatiRepository : IDisposable
    {
        private readonly AzAgroDbContext _context;

        public SatisHesabatiRepository(AzAgroDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<SatisHesabati>> GetAllAsync()
        {
            return await _context.SatisHesabatlari
                .Include(sh => sh.YaradanIstifadeci)
                .OrderByDescending(sh => sh.YaradilmaTarixi)
                .ToListAsync();
        }

        public async Task<SatisHesabati> GetByIdAsync(int id)
        {
            return await _context.SatisHesabatlari
                .Include(sh => sh.YaradanIstifadeci)
                .FirstOrDefaultAsync(sh => sh.Id == id);
        }

        public async Task<IEnumerable<SatisHesabati>> GetByTypeAsync(string hesabatTipi)
        {
            return await _context.SatisHesabatlari
                .Include(sh => sh.YaradanIstifadeci)
                .Where(sh => sh.HesabatTipi == hesabatTipi)
                .OrderByDescending(sh => sh.YaradilmaTarixi)
                .ToListAsync();
        }

        public async Task<IEnumerable<SatisHesabati>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.SatisHesabatlari
                .Include(sh => sh.YaradanIstifadeci)
                .Where(sh => sh.TarixBaslangic >= startDate && sh.TarixBitis <= endDate)
                .OrderByDescending(sh => sh.YaradilmaTarixi)
                .ToListAsync();
        }

        public async Task<IEnumerable<SatisHesabati>> GetByUserAsync(int istifadeciId)
        {
            return await _context.SatisHesabatlari
                .Include(sh => sh.YaradanIstifadeci)
                .Where(sh => sh.YaradanIstifadeciId == istifadeciId)
                .OrderByDescending(sh => sh.YaradilmaTarixi)
                .ToListAsync();
        }

        public async Task<SatisHesabati> GetLatestByTypeAsync(string hesabatTipi)
        {
            return await _context.SatisHesabatlari
                .Include(sh => sh.YaradanIstifadeci)
                .Where(sh => sh.HesabatTipi == hesabatTipi)
                .OrderByDescending(sh => sh.YaradilmaTarixi)
                .FirstOrDefaultAsync();
        }

        public async Task<int> AddAsync(SatisHesabati hesabat)
        {
            _context.SatisHesabatlari.Add(hesabat);
            return hesabat.Id;
        }

        public async Task UpdateAsync(SatisHesabati hesabat)
        {
            _context.Entry(hesabat).State = EntityState.Modified;
        }

        public async Task DeleteAsync(int id)
        {
            var hesabat = await _context.SatisHesabatlari.FindAsync(id);
            if (hesabat != null)
            {
                _context.SatisHesabatlari.Remove(hesabat);
                }
        }

        public async Task<Dictionary<string, decimal>> GetSummaryAsync(DateTime startDate, DateTime endDate)
        {
            var reports = await _context.SatisHesabatlari
                .Where(sh => sh.TarixBaslangic >= startDate && sh.TarixBitis <= endDate)
                .ToListAsync();

            return new Dictionary<string, decimal>
            {
                ["Cəmi Satış"] = reports.Sum(r => r.ToplamSatis),
                ["Cəmi Mənfəət"] = reports.Sum(r => r.ToplamMenfeet),
                ["Cəmi Satış Sayı"] = reports.Sum(r => r.SatisSayi),
                ["Ortalama Satış"] = reports.Any() ? reports.Average(r => r.OrtalamaSatis) : 0,
                ["Mənfəət Faizi"] = reports.Sum(r => r.ToplamSatis) > 0 ? 
                    (reports.Sum(r => r.ToplamMenfeet) / reports.Sum(r => r.ToplamSatis)) * 100 : 0
            };
        }

        public async Task<IEnumerable<SatisHesabati>> GetTopPerformingReportsAsync(int count = 10)
        {
            return await _context.SatisHesabatlari
                .Include(sh => sh.YaradanIstifadeci)
                .OrderByDescending(sh => sh.ToplamSatis)
                .Take(count)
                .ToListAsync();
        }

        public async Task CleanOldReportsAsync(int daysToKeep = 365)
        {
            var cutoffDate = DateTime.Now.AddDays(-daysToKeep);
            
            var oldReports = await _context.SatisHesabatlari
                .Where(sh => sh.YaradilmaTarixi < cutoffDate)
                .ToListAsync();

            if (oldReports.Any())
            {
                _context.SatisHesabatlari.RemoveRange(oldReports);
                }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}