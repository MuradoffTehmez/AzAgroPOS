using AzAgroPOS.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.DAL.Repositories
{
    public class GiderRepository : Repository<Gider>, IGiderRepository
    {
        public GiderRepository(AzAgroDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Gider>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Giderler
                .Include(g => g.Istifadeci)
                .Where(g => g.Tarix >= startDate && g.Tarix <= endDate)
                .OrderByDescending(g => g.Tarix)
                .ToListAsync();
        }

        public async Task<IEnumerable<Gider>> GetByCategoryAsync(string category)
        {
            return await _context.Giderler
                .Include(g => g.Istifadeci)
                .Where(g => g.Kateqoriya == category)
                .OrderByDescending(g => g.Tarix)
                .ToListAsync();
        }

        public async Task<IEnumerable<Gider>> GetPendingApprovalAsync()
        {
            return await _context.Giderler
                .Include(g => g.Istifadeci)
                .Where(g => !g.TesdiqEdildi)
                .OrderBy(g => g.Tarix)
                .ToListAsync();
        }

        public async Task<decimal> GetTotalExpensesByMonthAsync(int year, int month)
        {
            return await _context.Giderler
                .Where(g => g.Tarix.Year == year && g.Tarix.Month == month && g.TesdiqEdildi)
                .SumAsync(g => g.Mebleg);
        }

        public async Task<decimal> GetTotalExpensesByCategoryAsync(string category, DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.Giderler.Where(g => g.Kateqoriya == category && g.TesdiqEdildi);

            if (startDate.HasValue)
                query = query.Where(g => g.Tarix >= startDate);

            if (endDate.HasValue)
                query = query.Where(g => g.Tarix <= endDate);

            return await query.SumAsync(g => g.Mebleg);
        }

        public async Task<Dictionary<string, decimal>> GetExpensesByCategoryAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Giderler
                .Where(g => g.Tarix >= startDate && g.Tarix <= endDate && g.TesdiqEdildi)
                .GroupBy(g => g.Kateqoriya)
                .Select(group => new
                {
                    Category = group.Key,
                    Total = group.Sum(g => g.Mebleg)
                })
                .ToDictionaryAsync(x => x.Category, x => x.Total);
        }

        public async Task<IEnumerable<Gider>> GetByUserAsync(int userId)
        {
            return await _context.Giderler
                .Include(g => g.Istifadeci)
                .Where(g => g.IstifadeciId == userId)
                .OrderByDescending(g => g.Tarix)
                .ToListAsync();
        }

        public async Task ApproveExpenseAsync(int expenseId, string approverName)
        {
            var expense = await GetByIdAsync(expenseId);
            if (expense != null)
            {
                expense.TesdiqEdildi = true;
                expense.TesdiqTarixi = DateTime.Now;
                expense.Tesdiqleyen = approverName;
                await UpdateAsync(expense);
            }
        }

        public async Task<IEnumerable<Gider>> SearchAsync(string searchTerm)
        {
            return await _context.Giderler
                .Include(g => g.Istifadeci)
                .Where(g => g.Ad.Contains(searchTerm) || 
                           g.Aciqlama.Contains(searchTerm) ||
                           g.Kateqoriya.Contains(searchTerm))
                .OrderByDescending(g => g.Tarix)
                .ToListAsync();
        }

        public override async Task<IEnumerable<Gider>> GetAllAsync()
        {
            return await _context.Giderler
                .Include(g => g.Istifadeci)
                .OrderByDescending(g => g.Tarix)
                .ToListAsync();
        }

        public override async Task<Gider> GetByIdAsync(int id)
        {
            return await _context.Giderler
                .Include(g => g.Istifadeci)
                .FirstOrDefaultAsync(g => g.Id == id);
        }
    }

    public interface IGiderRepository : IRepository<Gider>
    {
        Task<IEnumerable<Gider>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Gider>> GetByCategoryAsync(string category);
        Task<IEnumerable<Gider>> GetPendingApprovalAsync();
        Task<decimal> GetTotalExpensesByMonthAsync(int year, int month);
        Task<decimal> GetTotalExpensesByCategoryAsync(string category, DateTime? startDate = null, DateTime? endDate = null);
        Task<Dictionary<string, decimal>> GetExpensesByCategoryAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Gider>> GetByUserAsync(int userId);
        Task ApproveExpenseAsync(int expenseId, string approverName);
        Task<IEnumerable<Gider>> SearchAsync(string searchTerm);
    }
}