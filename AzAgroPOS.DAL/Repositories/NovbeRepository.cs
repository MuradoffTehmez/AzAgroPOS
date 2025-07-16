using AzAgroPOS.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.DAL.Repositories
{
    public class NovbeRepository : IDisposable
    {
        private readonly AzAgroDbContext _context;

        public NovbeRepository(AzAgroDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<NovbeKaydi>> GetAllAsync()
        {
            return await _context.NovbeKayitlari
                .Include(n => n.Isci)
                .OrderByDescending(n => n.GirisTarixi)
                .ToListAsync();
        }

        public async Task<IEnumerable<NovbeKaydi>> GetByWorkerIdAsync(int isciId)
        {
            return await _context.NovbeKayitlari
                .Include(n => n.Isci)
                .Where(n => n.IsciId == isciId)
                .OrderByDescending(n => n.GirisTarixi)
                .ToListAsync();
        }

        public async Task<NovbeKaydi> GetActiveShiftByWorkerIdAsync(int isciId)
        {
            return await _context.NovbeKayitlari
                .Include(n => n.Isci)
                .FirstOrDefaultAsync(n => n.IsciId == isciId && !n.CixisTarixi.HasValue);
        }

        public async Task<IEnumerable<NovbeKaydi>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.NovbeKayitlari
                .Include(n => n.Isci)
                .Where(n => n.GirisTarixi >= startDate && n.GirisTarixi <= endDate)
                .OrderByDescending(n => n.GirisTarixi)
                .ToListAsync();
        }

        public async Task<IEnumerable<NovbeKaydi>> GetActiveShiftsAsync()
        {
            return await _context.NovbeKayitlari
                .Include(n => n.Isci)
                .Where(n => !n.CixisTarixi.HasValue)
                .OrderBy(n => n.GirisTarixi)
                .ToListAsync();
        }

        public async Task<int> AddAsync(NovbeKaydi novbeKaydi)
        {
            _context.NovbeKayitlari.Add(novbeKaydi);
            return novbeKaydi.Id;
        }

        public async Task UpdateAsync(NovbeKaydi novbeKaydi)
        {
            _context.Entry(novbeKaydi).State = EntityState.Modified;
        }

        public async Task<NovbeKaydi> GetByIdAsync(int id)
        {
            return await _context.NovbeKayitlari
                .Include(n => n.Isci)
                .FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<Dictionary<int, decimal>> GetTotalHoursAsync(DateTime startDate, DateTime endDate)
        {
            var shifts = await _context.NovbeKayitlari
                .Where(n => n.GirisTarixi >= startDate && 
                           n.GirisTarixi <= endDate &&
                           n.CixisTarixi.HasValue)
                .ToListAsync();

            return shifts.GroupBy(n => n.IsciId)
                .ToDictionary(g => g.Key, g => g.Sum(n => n.IslemeSaati));
        }

        public async Task<IEnumerable<NovbeKaydi>> GetLongShiftsAsync(decimal minimumHours)
        {
            return await _context.NovbeKayitlari
                .Include(n => n.Isci)
                .Where(n => n.IslemeSaati >= minimumHours)
                .OrderByDescending(n => n.IslemeSaati)
                .ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}