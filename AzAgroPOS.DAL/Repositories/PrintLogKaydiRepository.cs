using AzAgroPOS.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.DAL.Repositories
{
    public class PrintLogKaydiRepository : IDisposable
    {
        private readonly AzAgroDbContext _context;

        public PrintLogKaydiRepository(AzAgroDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<PrintLogKaydi>> GetAllAsync()
        {
            return await _context.PrintLogKayitlari
                .Include(pl => pl.PrinterKonfiqurasiya)
                .Include(pl => pl.PrintSablonu)
                .Include(pl => pl.Istifadeci)
                .Include(pl => pl.Mehsul)
                .Include(pl => pl.Satis)
                .OrderByDescending(pl => pl.PrintTarixi)
                .ToListAsync();
        }

        public async Task<PrintLogKaydi> GetByIdAsync(int id)
        {
            return await _context.PrintLogKayitlari
                .Include(pl => pl.PrinterKonfiqurasiya)
                .Include(pl => pl.PrintSablonu)
                .Include(pl => pl.Istifadeci)
                .Include(pl => pl.Mehsul)
                .Include(pl => pl.Satis)
                .FirstOrDefaultAsync(pl => pl.Id == id);
        }

        public async Task<IEnumerable<PrintLogKaydi>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.PrintLogKayitlari
                .Include(pl => pl.PrinterKonfiqurasiya)
                .Include(pl => pl.PrintSablonu)
                .Include(pl => pl.Istifadeci)
                .Where(pl => pl.PrintTarixi >= startDate && pl.PrintTarixi <= endDate)
                .OrderByDescending(pl => pl.PrintTarixi)
                .ToListAsync();
        }

        public async Task<IEnumerable<PrintLogKaydi>> GetByPrinterAsync(int printerConfigurationId)
        {
            return await _context.PrintLogKayitlari
                .Include(pl => pl.PrintSablonu)
                .Include(pl => pl.Istifadeci)
                .Include(pl => pl.Mehsul)
                .Where(pl => pl.PrinterKonfiqurasiId == printerConfigurationId)
                .OrderByDescending(pl => pl.PrintTarixi)
                .ToListAsync();
        }

        public async Task<IEnumerable<PrintLogKaydi>> GetByUserAsync(int userId)
        {
            return await _context.PrintLogKayitlari
                .Include(pl => pl.PrinterKonfiqurasiya)
                .Include(pl => pl.PrintSablonu)
                .Include(pl => pl.Mehsul)
                .Where(pl => pl.IstifadeciId == userId)
                .OrderByDescending(pl => pl.PrintTarixi)
                .ToListAsync();
        }

        public async Task<IEnumerable<PrintLogKaydi>> GetByStatusAsync(string printStatus)
        {
            return await _context.PrintLogKayitlari
                .Include(pl => pl.PrinterKonfiqurasiya)
                .Include(pl => pl.PrintSablonu)
                .Include(pl => pl.Istifadeci)
                .Where(pl => pl.PrintStatusu == printStatus)
                .OrderByDescending(pl => pl.PrintTarixi)
                .ToListAsync();
        }

        public async Task<IEnumerable<PrintLogKaydi>> GetFailedPrintsAsync()
        {
            return await _context.PrintLogKayitlari
                .Include(pl => pl.PrinterKonfiqurasiya)
                .Include(pl => pl.PrintSablonu)
                .Include(pl => pl.Istifadeci)
                .Where(pl => pl.PrintStatusu != PrintLogKaydi.PrintStatuslari.Ugurlu)
                .OrderByDescending(pl => pl.PrintTarixi)
                .ToListAsync();
        }

        public async Task<IEnumerable<PrintLogKaydi>> GetSuccessfulPrintsAsync()
        {
            return await _context.PrintLogKayitlari
                .Include(pl => pl.PrinterKonfiqurasiya)
                .Include(pl => pl.PrintSablonu)
                .Include(pl => pl.Istifadeci)
                .Where(pl => pl.PrintStatusu == PrintLogKaydi.PrintStatuslari.Ugurlu)
                .OrderByDescending(pl => pl.PrintTarixi)
                .ToListAsync();
        }

        public async Task<IEnumerable<PrintLogKaydi>> GetRecentPrintsAsync(int count = 50)
        {
            return await _context.PrintLogKayitlari
                .Include(pl => pl.PrinterKonfiqurasiya)
                .Include(pl => pl.PrintSablonu)
                .Include(pl => pl.Istifadeci)
                .OrderByDescending(pl => pl.PrintTarixi)
                .Take(count)
                .ToListAsync();
        }

        public async Task<IEnumerable<PrintLogKaydi>> GetTodayPrintsAsync()
        {
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);
            
            return await _context.PrintLogKayitlari
                .Include(pl => pl.PrinterKonfiqurasiya)
                .Include(pl => pl.PrintSablonu)
                .Include(pl => pl.Istifadeci)
                .Where(pl => pl.PrintTarixi >= today && pl.PrintTarixi < tomorrow)
                .OrderByDescending(pl => pl.PrintTarixi)
                .ToListAsync();
        }

        public async Task<IEnumerable<PrintLogKaydi>> GetByPrintTypeAsync(string printType)
        {
            return await _context.PrintLogKayitlari
                .Include(pl => pl.PrinterKonfiqurasiya)
                .Include(pl => pl.PrintSablonu)
                .Include(pl => pl.Istifadeci)
                .Where(pl => pl.PrintTipi == printType)
                .OrderByDescending(pl => pl.PrintTarixi)
                .ToListAsync();
        }

        public async Task<IEnumerable<PrintLogKaydi>> GetBySourceModuleAsync(string sourceModule)
        {
            return await _context.PrintLogKayitlari
                .Include(pl => pl.PrinterKonfiqurasiya)
                .Include(pl => pl.PrintSablonu)
                .Include(pl => pl.Istifadeci)
                .Where(pl => pl.MenbeModul == sourceModule)
                .OrderByDescending(pl => pl.PrintTarixi)
                .ToListAsync();
        }

        public async Task<IEnumerable<PrintLogKaydi>> GetReprintLogsAsync()
        {
            return await _context.PrintLogKayitlari
                .Include(pl => pl.PrinterKonfiqurasiya)
                .Include(pl => pl.PrintSablonu)
                .Include(pl => pl.Istifadeci)
                .Where(pl => pl.YenidenPrint)
                .OrderByDescending(pl => pl.PrintTarixi)
                .ToListAsync();
        }

        public async Task<PrintLogKaydi> AddAsync(PrintLogKaydi entity)
        {
            entity.YaranmaTarixi = DateTime.Now;
            entity.YenilenmeTarixi = DateTime.Now;
            
            _context.PrintLogKayitlari.Add(entity);
            return entity;
        }

        public async Task<PrintLogKaydi> UpdateAsync(PrintLogKaydi entity)
        {
            entity.YenilenmeTarixi = DateTime.Now;
            
            _context.PrintLogKayitlari.Update(entity);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.PrintLogKayitlari.Remove(entity);
                }
        }

        public async Task<int> DeleteOldLogsAsync(int daysOld)
        {
            var cutoffDate = DateTime.Now.AddDays(-daysOld);
            var oldLogs = await _context.PrintLogKayitlari
                .Where(pl => pl.PrintTarixi < cutoffDate)
                .ToListAsync();

            var count = oldLogs.Count;
            if (count > 0)
            {
                _context.PrintLogKayitlari.RemoveRange(oldLogs);
                }

            return count;
        }

        public async Task<Dictionary<string, int>> GetPrintStatisticsByStatusAsync()
        {
            return await _context.PrintLogKayitlari
                .GroupBy(pl => pl.PrintStatusu)
                .ToDictionaryAsync(g => g.Key, g => g.Count());
        }

        public async Task<Dictionary<string, int>> GetPrintStatisticsByTypeAsync()
        {
            return await _context.PrintLogKayitlari
                .GroupBy(pl => pl.PrintTipi)
                .ToDictionaryAsync(g => g.Key, g => g.Count());
        }

        public async Task<Dictionary<string, int>> GetPrintStatisticsByModuleAsync()
        {
            return await _context.PrintLogKayitlari
                .GroupBy(pl => pl.MenbeModul)
                .ToDictionaryAsync(g => g.Key, g => g.Count());
        }

        public async Task<Dictionary<int, int>> GetPrintStatisticsByPrinterAsync()
        {
            return await _context.PrintLogKayitlari
                .Include(pl => pl.PrinterKonfiqurasiya)
                .GroupBy(pl => pl.PrinterKonfiqurasiId)
                .ToDictionaryAsync(g => g.Key, g => g.Count());
        }

        public async Task<Dictionary<DateTime, int>> GetDailyPrintCountAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.PrintLogKayitlari
                .Where(pl => pl.PrintTarixi >= startDate && pl.PrintTarixi <= endDate)
                .GroupBy(pl => pl.PrintTarixi.Date)
                .ToDictionaryAsync(g => g.Key, g => g.Count());
        }

        public async Task<Dictionary<int, int>> GetHourlyPrintCountAsync(DateTime date)
        {
            var startDate = date.Date;
            var endDate = startDate.AddDays(1);

            return await _context.PrintLogKayitlari
                .Where(pl => pl.PrintTarixi >= startDate && pl.PrintTarixi < endDate)
                .GroupBy(pl => pl.PrintTarixi.Hour)
                .ToDictionaryAsync(g => g.Key, g => g.Count());
        }

        public async Task<decimal> GetAveragePrintDurationAsync()
        {
            var successfulPrints = await _context.PrintLogKayitlari
                .Where(pl => pl.PrintStatusu == PrintLogKaydi.PrintStatuslari.Ugurlu && pl.PrintMuddeti > 0)
                .ToListAsync();

            return successfulPrints.Any() ? successfulPrints.Average(pl => pl.PrintMuddeti) : 0;
        }

        public async Task<decimal> GetTotalPaperUsageAsync(DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.PrintLogKayitlari
                .Where(pl => pl.PrintStatusu == PrintLogKaydi.PrintStatuslari.Ugurlu);

            if (startDate.HasValue)
                query = query.Where(pl => pl.PrintTarixi >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(pl => pl.PrintTarixi <= endDate.Value);

            return await query.SumAsync(pl => pl.KagizIstifadeOlcusu);
        }

        public async Task<int> GetTotalCopiesPrintedAsync(DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.PrintLogKayitlari
                .Where(pl => pl.PrintStatusu == PrintLogKaydi.PrintStatuslari.Ugurlu);

            if (startDate.HasValue)
                query = query.Where(pl => pl.PrintTarixi >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(pl => pl.PrintTarixi <= endDate.Value);

            return await query.SumAsync(pl => pl.SuretiSayi);
        }

        public async Task<double> GetPrintSuccessRateAsync(DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.PrintLogKayitlari.AsQueryable();

            if (startDate.HasValue)
                query = query.Where(pl => pl.PrintTarixi >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(pl => pl.PrintTarixi <= endDate.Value);

            var totalPrints = await query.CountAsync();
            var successfulPrints = await query.CountAsync(pl => pl.PrintStatusu == PrintLogKaydi.PrintStatuslari.Ugurlu);

            return totalPrints > 0 ? (double)successfulPrints / totalPrints * 100 : 0;
        }

        public async Task<Dictionary<string, object>> GetDetailedPrintStatisticsAsync(DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.PrintLogKayitlari.AsQueryable();

            if (startDate.HasValue)
                query = query.Where(pl => pl.PrintTarixi >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(pl => pl.PrintTarixi <= endDate.Value);

            var logs = await query.ToListAsync();

            var totalPrints = logs.Count;
            var successfulPrints = logs.Count(pl => pl.PrintUgurlu);
            var failedPrints = totalPrints - successfulPrints;
            var totalCopies = logs.Where(pl => pl.PrintUgurlu).Sum(pl => pl.SuretiSayi);
            var totalPaperUsage = logs.Where(pl => pl.PrintUgurlu).Sum(pl => pl.KagizIstifadeOlcusu);
            var avgDuration = logs.Where(pl => pl.PrintUgurlu && pl.PrintMuddeti > 0).Average(pl => (double?)pl.PrintMuddeti) ?? 0;

            var statusStats = logs.GroupBy(pl => pl.PrintStatusu)
                .ToDictionary(g => g.Key, g => g.Count());

            var typeStats = logs.GroupBy(pl => pl.PrintTipi)
                .ToDictionary(g => g.Key, g => g.Count());

            var moduleStats = logs.GroupBy(pl => pl.MenbeModul)
                .ToDictionary(g => g.Key, g => g.Count());

            return new Dictionary<string, object>
            {
                { "TotalPrints", totalPrints },
                { "SuccessfulPrints", successfulPrints },
                { "FailedPrints", failedPrints },
                { "SuccessRate", totalPrints > 0 ? (double)successfulPrints / totalPrints * 100 : 0 },
                { "TotalCopies", totalCopies },
                { "TotalPaperUsage", totalPaperUsage },
                { "AverageDuration", avgDuration },
                { "StatusStatistics", statusStats },
                { "TypeStatistics", typeStats },
                { "ModuleStatistics", moduleStats }
            };
        }

        public async Task<IEnumerable<PrintLogKaydi>> SearchAsync(string searchTerm)
        {
            return await _context.PrintLogKayitlari
                .Include(pl => pl.PrinterKonfiqurasiya)
                .Include(pl => pl.PrintSablonu)
                .Include(pl => pl.Istifadeci)
                .Include(pl => pl.Mehsul)
                .Where(pl => pl.PrinterKonfiqurasiya.PrinterAdi.Contains(searchTerm) ||
                           pl.PrintSablonu.SablonAdi.Contains(searchTerm) ||
                           pl.Istifadeci.Ad.Contains(searchTerm) ||
                           pl.Istifadeci.Soyad.Contains(searchTerm) ||
                           pl.Mehsul.Ad.Contains(searchTerm) ||
                           pl.ReferansNomre.Contains(searchTerm) ||
                           pl.PrintStatusu.Contains(searchTerm) ||
                           pl.PrintTipi.Contains(searchTerm))
                .OrderByDescending(pl => pl.PrintTarixi)
                .ToListAsync();
        }

        public async Task<IEnumerable<PrintLogKaydi>> GetPrinterUsageReportAsync(int printerConfigurationId, DateTime startDate, DateTime endDate)
        {
            return await _context.PrintLogKayitlari
                .Include(pl => pl.PrintSablonu)
                .Include(pl => pl.Istifadeci)
                .Where(pl => pl.PrinterKonfiqurasiId == printerConfigurationId &&
                           pl.PrintTarixi >= startDate &&
                           pl.PrintTarixi <= endDate)
                .OrderByDescending(pl => pl.PrintTarixi)
                .ToListAsync();
        }

        public async Task<IEnumerable<PrintLogKaydi>> GetUserPrintHistoryAsync(int userId, DateTime startDate, DateTime endDate)
        {
            return await _context.PrintLogKayitlari
                .Include(pl => pl.PrinterKonfiqurasiya)
                .Include(pl => pl.PrintSablonu)
                .Include(pl => pl.Mehsul)
                .Where(pl => pl.IstifadeciId == userId &&
                           pl.PrintTarixi >= startDate &&
                           pl.PrintTarixi <= endDate)
                .OrderByDescending(pl => pl.PrintTarixi)
                .ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}