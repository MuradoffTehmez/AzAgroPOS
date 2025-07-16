using AzAgroPOS.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.DAL.Repositories
{
    public class IsciIzniRepository : IDisposable
    {
        private readonly AzAgroDbContext _context;

        public IsciIzniRepository(AzAgroDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<IsciIzni>> GetAllAsync()
        {
            return await _context.IsciIzinleri
                .Include(ii => ii.Isci)
                .OrderByDescending(ii => ii.BaslangicTarixi)
                .ToListAsync();
        }

        public async Task<IsciIzni> GetByIdAsync(int id)
        {
            return await _context.IsciIzinleri
                .Include(ii => ii.Isci)
                .FirstOrDefaultAsync(ii => ii.Id == id);
        }

        public async Task<IEnumerable<IsciIzni>> GetByEmployeeIdAsync(int employeeId)
        {
            return await _context.IsciIzinleri
                .Where(ii => ii.IsciId == employeeId)
                .OrderByDescending(ii => ii.BaslangicTarixi)
                .ToListAsync();
        }

        public async Task<IEnumerable<IsciIzni>> GetByStatusAsync(string status)
        {
            return await _context.IsciIzinleri
                .Include(ii => ii.Isci)
                .Where(ii => ii.Statusu == status)
                .OrderBy(ii => ii.BaslangicTarixi)
                .ToListAsync();
        }

        public async Task<IEnumerable<IsciIzni>> GetPendingLeavesAsync()
        {
            return await _context.IsciIzinleri
                .Include(ii => ii.Isci)
                .Where(ii => ii.Statusu == IsciIzni.IzinStatuslari.Gozleyir)
                .OrderBy(ii => ii.YaranmaTarixi)
                .ToListAsync();
        }

        public async Task<IEnumerable<IsciIzni>> GetActiveLeavesAsync()
        {
            var today = DateTime.Today;
            return await _context.IsciIzinleri
                .Include(ii => ii.Isci)
                .Where(ii => ii.Statusu == IsciIzni.IzinStatuslari.TesdiqEdildi &&
                           ii.BaslangicTarixi <= today &&
                           ii.BitisTarixi >= today)
                .OrderBy(ii => ii.BaslangicTarixi)
                .ToListAsync();
        }

        public async Task<IEnumerable<IsciIzni>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.IsciIzinleri
                .Include(ii => ii.Isci)
                .Where(ii => (ii.BaslangicTarixi >= startDate && ii.BaslangicTarixi <= endDate) ||
                           (ii.BitisTarixi >= startDate && ii.BitisTarixi <= endDate) ||
                           (ii.BaslangicTarixi <= startDate && ii.BitisTarixi >= endDate))
                .OrderBy(ii => ii.BaslangicTarixi)
                .ToListAsync();
        }

        public async Task<IEnumerable<IsciIzni>> GetByLeaveTypeAsync(string leaveType)
        {
            return await _context.IsciIzinleri
                .Include(ii => ii.Isci)
                .Where(ii => ii.IzinTipi == leaveType)
                .OrderByDescending(ii => ii.BaslangicTarixi)
                .ToListAsync();
        }

        public async Task<bool> HasOverlappingLeaveAsync(int employeeId, DateTime startDate, DateTime endDate, int? excludeLeaveId = null)
        {
            var query = _context.IsciIzinleri
                .Where(ii => ii.IsciId == employeeId &&
                           ii.Statusu == IsciIzni.IzinStatuslari.TesdiqEdildi &&
                           ((ii.BaslangicTarixi >= startDate && ii.BaslangicTarixi <= endDate) ||
                            (ii.BitisTarixi >= startDate && ii.BitisTarixi <= endDate) ||
                            (ii.BaslangicTarixi <= startDate && ii.BitisTarixi >= endDate)));

            if (excludeLeaveId.HasValue)
            {
                query = query.Where(ii => ii.Id != excludeLeaveId.Value);
            }

            return await query.AnyAsync();
        }

        public async Task<int> GetTotalLeaveDaysAsync(int employeeId, string leaveType, int year)
        {
            var yearStart = new DateTime(year, 1, 1);
            var yearEnd = new DateTime(year, 12, 31);

            return await _context.IsciIzinleri
                .Where(ii => ii.IsciId == employeeId &&
                           ii.IzinTipi == leaveType &&
                           ii.Statusu == IsciIzni.IzinStatuslari.TesdiqEdildi &&
                           ii.BaslangicTarixi >= yearStart &&
                           ii.BitisTarixi <= yearEnd)
                .SumAsync(ii => ii.IzinGunSayi);
        }

        public async Task<Dictionary<string, int>> GetLeaveStatisticsAsync(int employeeId, int year)
        {
            var yearStart = new DateTime(year, 1, 1);
            var yearEnd = new DateTime(year, 12, 31);

            return await _context.IsciIzinleri
                .Where(ii => ii.IsciId == employeeId &&
                           ii.Statusu == IsciIzni.IzinStatuslari.TesdiqEdildi &&
                           ii.BaslangicTarixi >= yearStart &&
                           ii.BitisTarixi <= yearEnd)
                .GroupBy(ii => ii.IzinTipi)
                .ToDictionaryAsync(g => g.Key, g => g.Sum(ii => ii.IzinGunSayi));
        }

        public async Task<IsciIzni> AddAsync(IsciIzni entity)
        {
            entity.YaranmaTarixi = DateTime.Now;
            entity.YenilenmeTarixi = DateTime.Now;
            
            _context.IsciIzinleri.Add(entity);
            return entity;
        }

        public async Task<IsciIzni> UpdateAsync(IsciIzni entity)
        {
            entity.YenilenmeTarixi = DateTime.Now;
            
            _context.IsciIzinleri.Update(entity);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.IsciIzinleri.Remove(entity);
                }
        }

        public async Task<bool> ApproveLeaveAsync(int leaveId, string approverName, string approvalNote = null)
        {
            var leave = await GetByIdAsync(leaveId);
            if (leave != null)
            {
                leave.Statusu = IsciIzni.IzinStatuslari.TesdiqEdildi;
                leave.TesdiqEden = approverName;
                leave.TesdiqTarixi = DateTime.Now;
                if (!string.IsNullOrEmpty(approvalNote))
                    leave.TesdiqQeydi = approvalNote;
                await UpdateAsync(leave);
                return true;
            }
            return false;
        }

        public async Task<bool> RejectLeaveAsync(int leaveId, string rejectorName, string rejectionReason)
        {
            var leave = await GetByIdAsync(leaveId);
            if (leave != null)
            {
                leave.Statusu = IsciIzni.IzinStatuslari.RedEdildi;
                leave.TesdiqEden = rejectorName;
                leave.RedTarixi = DateTime.Now;
                leave.RedSebebi = rejectionReason;
                await UpdateAsync(leave);
                return true;
            }
            return false;
        }

        public async Task<bool> CancelLeaveAsync(int leaveId)
        {
            var leave = await GetByIdAsync(leaveId);
            if (leave != null)
            {
                leave.Statusu = IsciIzni.IzinStatuslari.Legv;
                await UpdateAsync(leave);
                return true;
            }
            return false;
        }

        public async Task<bool> ApproveMultipleLeavesAsync(List<int> leaveIds, string approverName)
        {
            var leaves = await _context.IsciIzinleri
                .Where(ii => leaveIds.Contains(ii.Id))
                .ToListAsync();

            foreach (var leave in leaves)
            {
                leave.Statusu = IsciIzni.IzinStatuslari.TesdiqEdildi;
                leave.TesdiqEden = approverName;
                leave.TesdiqTarixi = DateTime.Now;
                leave.YenilenmeTarixi = DateTime.Now;
            }

            return true;
        }

        public async Task<IEnumerable<IsciIzni>> SearchAsync(string searchTerm)
        {
            return await _context.IsciIzinleri
                .Include(ii => ii.Isci)
                .Where(ii => ii.Isci.Ad.Contains(searchTerm) ||
                           ii.Isci.Soyad.Contains(searchTerm) ||
                           ii.IzinTipi.Contains(searchTerm) ||
                           ii.SebebOzuru.Contains(searchTerm))
                .OrderByDescending(ii => ii.BaslangicTarixi)
                .ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}