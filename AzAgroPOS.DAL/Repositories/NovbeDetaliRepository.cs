using AzAgroPOS.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.DAL.Repositories
{
    public class NovbeDetaliRepository : IDisposable
    {
        private readonly AzAgroDbContext _context;

        public NovbeDetaliRepository(AzAgroDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<NovbeDetali>> GetAllAsync()
        {
            return await _context.NovbeDetallari
                .Include(nd => nd.Isci)
                .Include(nd => nd.NovbeCedveli)
                .OrderByDescending(nd => nd.NovbeTarixi)
                .ToListAsync();
        }

        public async Task<NovbeDetali> GetByIdAsync(int id)
        {
            return await _context.NovbeDetallari
                .Include(nd => nd.Isci)
                .Include(nd => nd.NovbeCedveli)
                .FirstOrDefaultAsync(nd => nd.Id == id);
        }

        public async Task<IEnumerable<NovbeDetali>> GetByScheduleIdAsync(int scheduleId)
        {
            return await _context.NovbeDetallari
                .Include(nd => nd.Isci)
                .Where(nd => nd.NovbeCedveliId == scheduleId)
                .OrderBy(nd => nd.NovbeTarixi)
                .ThenBy(nd => nd.BaslangicSaati)
                .ToListAsync();
        }

        public async Task<IEnumerable<NovbeDetali>> GetByEmployeeIdAsync(int employeeId)
        {
            return await _context.NovbeDetallari
                .Include(nd => nd.NovbeCedveli)
                .Where(nd => nd.IsciId == employeeId)
                .OrderByDescending(nd => nd.NovbeTarixi)
                .ToListAsync();
        }

        public async Task<IEnumerable<NovbeDetali>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.NovbeDetallari
                .Include(nd => nd.Isci)
                .Include(nd => nd.NovbeCedveli)
                .Where(nd => nd.NovbeTarixi >= startDate && nd.NovbeTarixi <= endDate)
                .OrderBy(nd => nd.NovbeTarixi)
                .ThenBy(nd => nd.BaslangicSaati)
                .ToListAsync();
        }

        public async Task<IEnumerable<NovbeDetali>> GetTodayShiftsAsync()
        {
            var today = DateTime.Today;
            return await _context.NovbeDetallari
                .Include(nd => nd.Isci)
                .Include(nd => nd.NovbeCedveli)
                .Where(nd => nd.NovbeTarixi.Date == today)
                .OrderBy(nd => nd.BaslangicSaati)
                .ToListAsync();
        }

        public async Task<IEnumerable<NovbeDetali>> GetActiveShiftsAsync()
        {
            var now = DateTime.Now;
            var today = now.Date;
            var currentTime = now.TimeOfDay;

            return await _context.NovbeDetallari
                .Include(nd => nd.Isci)
                .Include(nd => nd.NovbeCedveli)
                .Where(nd => nd.NovbeTarixi.Date == today &&
                           nd.BaslangicSaati <= currentTime &&
                           nd.BitisSaati >= currentTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<NovbeDetali>> GetPendingApprovalsAsync()
        {
            return await _context.NovbeDetallari
                .Include(nd => nd.Isci)
                .Include(nd => nd.NovbeCedveli)
                .Where(nd => !nd.TesdiqEdildi)
                .OrderBy(nd => nd.NovbeTarixi)
                .ToListAsync();
        }

        public async Task<bool> HasConflictingShiftAsync(int employeeId, DateTime shiftDate, TimeSpan startTime, TimeSpan endTime, int? excludeShiftId = null)
        {
            var query = _context.NovbeDetallari
                .Where(nd => nd.IsciId == employeeId &&
                           nd.NovbeTarixi.Date == shiftDate.Date &&
                           ((nd.BaslangicSaati <= startTime && nd.BitisSaati > startTime) ||
                            (nd.BaslangicSaati < endTime && nd.BitisSaati >= endTime) ||
                            (nd.BaslangicSaati >= startTime && nd.BitisSaati <= endTime)));

            if (excludeShiftId.HasValue)
            {
                query = query.Where(nd => nd.Id != excludeShiftId.Value);
            }

            return await query.AnyAsync();
        }

        public async Task<NovbeDetali> AddAsync(NovbeDetali entity)
        {
            entity.YaranmaTarixi = DateTime.Now;
            entity.YenilenmeTarixi = DateTime.Now;
            
            _context.NovbeDetallari.Add(entity);
            return entity;
        }

        public async Task<NovbeDetali> UpdateAsync(NovbeDetali entity)
        {
            entity.YenilenmeTarixi = DateTime.Now;
            
            _context.NovbeDetallari.Update(entity);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.NovbeDetallari.Remove(entity);
                }
        }

        public async Task<bool> ApproveShiftAsync(int shiftId, string approverName)
        {
            var shift = await GetByIdAsync(shiftId);
            if (shift != null)
            {
                shift.TesdiqEdildi = true;
                shift.TesdiqEden = approverName;
                shift.TesdiqTarixi = DateTime.Now;
                await UpdateAsync(shift);
                return true;
            }
            return false;
        }

        public async Task<bool> ApproveMultipleShiftsAsync(List<int> shiftIds, string approverName)
        {
            var shifts = await _context.NovbeDetallari
                .Where(nd => shiftIds.Contains(nd.Id))
                .ToListAsync();

            foreach (var shift in shifts)
            {
                shift.TesdiqEdildi = true;
                shift.TesdiqEden = approverName;
                shift.TesdiqTarixi = DateTime.Now;
                shift.YenilenmeTarixi = DateTime.Now;
            }

            return true;
        }

        public async Task<decimal> GetTotalWorkingHoursAsync(int employeeId, DateTime startDate, DateTime endDate)
        {
            return await _context.NovbeDetallari
                .Where(nd => nd.IsciId == employeeId &&
                           nd.NovbeTarixi >= startDate &&
                           nd.NovbeTarixi <= endDate &&
                           nd.TesdiqEdildi)
                .SumAsync(nd => nd.SaatlikMebleg);
        }

        public async Task<Dictionary<int, decimal>> GetEmployeeWorkingHoursReportAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.NovbeDetallari
                .Include(nd => nd.Isci)
                .Where(nd => nd.NovbeTarixi >= startDate &&
                           nd.NovbeTarixi <= endDate &&
                           nd.TesdiqEdildi)
                .GroupBy(nd => nd.IsciId)
                .ToDictionaryAsync(g => g.Key, g => g.Sum(nd => nd.SaatlikMebleg));
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}