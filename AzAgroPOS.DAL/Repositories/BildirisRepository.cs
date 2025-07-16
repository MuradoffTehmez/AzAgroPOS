using AzAgroPOS.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.DAL.Repositories
{
    public class BildirisRepository : IDisposable
    {
        private readonly AzAgroDbContext _context;

        public BildirisRepository(AzAgroDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Bildiris>> GetAllAsync()
        {
            return await _context.Bildirisler
                .Include(b => b.HedefIstifadeci)
                .Include(b => b.GonderenIstifadeci)
                .Where(b => !b.Silindi)
                .OrderByDescending(b => b.GonderimeTarixi)
                .ToListAsync();
        }

        public async Task<Bildiris> GetByIdAsync(int id)
        {
            return await _context.Bildirisler
                .Include(b => b.HedefIstifadeci)
                .Include(b => b.GonderenIstifadeci)
                .FirstOrDefaultAsync(b => b.Id == id && !b.Silindi);
        }

        public async Task<IEnumerable<Bildiris>> GetByUserIdAsync(int userId)
        {
            return await _context.Bildirisler
                .Include(b => b.GonderenIstifadeci)
                .Where(b => (b.HedefIstifadeciId == userId || b.HedefIstifadeciId == null) 
                           && !b.Silindi && b.Gecerli)
                .OrderByDescending(b => b.GonderimeTarixi)
                .ToListAsync();
        }

        public async Task<IEnumerable<Bildiris>> GetUnreadByUserIdAsync(int userId)
        {
            return await _context.Bildirisler
                .Include(b => b.GonderenIstifadeci)
                .Where(b => (b.HedefIstifadeciId == userId || b.HedefIstifadeciId == null) 
                           && !b.Oxundu && !b.Silindi && b.Gecerli)
                .OrderByDescending(b => b.GonderimeTarixi)
                .ToListAsync();
        }

        public async Task<int> GetUnreadCountByUserIdAsync(int userId)
        {
            return await _context.Bildirisler
                .CountAsync(b => (b.HedefIstifadeciId == userId || b.HedefIstifadeciId == null) 
                                && !b.Oxundu && !b.Silindi && b.Gecerli);
        }

        public async Task<IEnumerable<Bildiris>> GetByTypeAsync(string notificationType)
        {
            return await _context.Bildirisler
                .Include(b => b.HedefIstifadeci)
                .Include(b => b.GonderenIstifadeci)
                .Where(b => b.BildirisNovu == notificationType && !b.Silindi && b.Gecerli)
                .OrderByDescending(b => b.GonderimeTarixi)
                .ToListAsync();
        }

        public async Task<IEnumerable<Bildiris>> GetByModuleAsync(string moduleName)
        {
            return await _context.Bildirisler
                .Include(b => b.HedefIstifadeci)
                .Include(b => b.GonderenIstifadeci)
                .Where(b => b.MenbeModulAdi == moduleName && !b.Silindi && b.Gecerli)
                .OrderByDescending(b => b.GonderimeTarixi)
                .ToListAsync();
        }

        public async Task<IEnumerable<Bildiris>> GetByPriorityAsync(string priority)
        {
            return await _context.Bildirisler
                .Include(b => b.HedefIstifadeci)
                .Include(b => b.GonderenIstifadeci)
                .Where(b => b.Prioritet == priority && !b.Silindi && b.Gecerli)
                .OrderByDescending(b => b.GonderimeTarixi)
                .ToListAsync();
        }

        public async Task<IEnumerable<Bildiris>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Bildirisler
                .Include(b => b.HedefIstifadeci)
                .Include(b => b.GonderenIstifadeci)
                .Where(b => b.GonderimeTarixi >= startDate && b.GonderimeTarixi <= endDate 
                           && !b.Silindi)
                .OrderByDescending(b => b.GonderimeTarixi)
                .ToListAsync();
        }

        public async Task<IEnumerable<Bildiris>> GetExpiredNotificationsAsync()
        {
            var now = DateTime.Now;
            return await _context.Bildirisler
                .Where(b => b.SonGecerlilikTarixi.HasValue && b.SonGecerlilikTarixi < now)
                .ToListAsync();
        }

        public async Task<IEnumerable<Bildiris>> GetAutoReadCandidatesAsync()
        {
            return await _context.Bildirisler
                .Where(b => b.OtomatikOxunsun && !b.Oxundu && b.OtomatikOxunmaVaxti)
                .ToListAsync();
        }

        public async Task<IEnumerable<Bildiris>> GetGlobalNotificationsAsync()
        {
            return await _context.Bildirisler
                .Include(b => b.GonderenIstifadeci)
                .Where(b => b.HedefIstifadeciId == null && !b.Silindi && b.Gecerli)
                .OrderByDescending(b => b.GonderimeTarixi)
                .ToListAsync();
        }

        public async Task<IEnumerable<Bildiris>> GetRecentNotificationsAsync(int userId, int takeCount = 10)
        {
            return await _context.Bildirisler
                .Include(b => b.GonderenIstifadeci)
                .Where(b => (b.HedefIstifadeciId == userId || b.HedefIstifadeciId == null) 
                           && !b.Silindi && b.Gecerli)
                .OrderByDescending(b => b.GonderimeTarixi)
                .Take(takeCount)
                .ToListAsync();
        }

        public async Task<Bildiris> AddAsync(Bildiris entity)
        {
            entity.YaranmaTarixi = DateTime.Now;
            entity.YenilenmeTarixi = DateTime.Now;
            
            _context.Bildirisler.Add(entity);
            return entity;
        }

        public async Task<Bildiris> UpdateAsync(Bildiris entity)
        {
            entity.YenilenmeTarixi = DateTime.Now;
            
            _context.Bildirisler.Update(entity);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                entity.Silindi = true;
                await UpdateAsync(entity);
            }
        }

        public async Task HardDeleteAsync(int id)
        {
            var entity = await _context.Bildirisler.FindAsync(id);
            if (entity != null)
            {
                _context.Bildirisler.Remove(entity);
                }
        }

        public async Task<bool> MarkAsReadAsync(int notificationId, int userId)
        {
            var notification = await _context.Bildirisler
                .FirstOrDefaultAsync(b => b.Id == notificationId && 
                                        (b.HedefIstifadeciId == userId || b.HedefIstifadeciId == null));
            
            if (notification != null && !notification.Oxundu)
            {
                notification.Oxundu = true;
                notification.OxunduTarixi = DateTime.Now;
                    return true;
            }
            return false;
        }

        public async Task<bool> MarkAsUnreadAsync(int notificationId, int userId)
        {
            var notification = await _context.Bildirisler
                .FirstOrDefaultAsync(b => b.Id == notificationId && 
                                        (b.HedefIstifadeciId == userId || b.HedefIstifadeciId == null));
            
            if (notification != null && notification.Oxundu)
            {
                notification.Oxundu = false;
                notification.OxunduTarixi = null;
                    return true;
            }
            return false;
        }

        public async Task<int> MarkAllAsReadAsync(int userId)
        {
            var unreadNotifications = await _context.Bildirisler
                .Where(b => (b.HedefIstifadeciId == userId || b.HedefIstifadeciId == null) 
                           && !b.Oxundu && !b.Silindi && b.Gecerli)
                .ToListAsync();

            var count = unreadNotifications.Count;
            foreach (var notification in unreadNotifications)
            {
                notification.Oxundu = true;
                notification.OxunduTarixi = DateTime.Now;
            }

            return count;
        }

        public async Task<int> DeleteOldNotificationsAsync(int daysOld)
        {
            var cutoffDate = DateTime.Now.AddDays(-daysOld);
            var oldNotifications = await _context.Bildirisler
                .Where(b => b.GonderimeTarixi < cutoffDate)
                .ToListAsync();

            var count = oldNotifications.Count;
            _context.Bildirisler.RemoveRange(oldNotifications);
            return count;
        }

        public async Task<int> ProcessAutoReadNotificationsAsync()
        {
            var autoReadCandidates = await GetAutoReadCandidatesAsync();
            var count = autoReadCandidates.Count();

            foreach (var notification in autoReadCandidates)
            {
                notification.Oxundu = true;
                notification.OxunduTarixi = DateTime.Now;
                _context.Bildirisler.Update(notification);
            }

            return count;
        }

        public async Task<Dictionary<string, int>> GetNotificationStatisticsByTypeAsync()
        {
            return await _context.Bildirisler
                .Where(b => !b.Silindi && b.Gecerli)
                .GroupBy(b => b.BildirisNovu)
                .ToDictionaryAsync(g => g.Key, g => g.Count());
        }

        public async Task<Dictionary<string, int>> GetNotificationStatisticsByModuleAsync()
        {
            return await _context.Bildirisler
                .Where(b => !b.Silindi && b.Gecerli)
                .GroupBy(b => b.MenbeModulAdi)
                .ToDictionaryAsync(g => g.Key, g => g.Count());
        }

        public async Task<Dictionary<string, int>> GetNotificationStatisticsByPriorityAsync()
        {
            return await _context.Bildirisler
                .Where(b => !b.Silindi && b.Gecerli)
                .GroupBy(b => b.Prioritet)
                .ToDictionaryAsync(g => g.Key, g => g.Count());
        }

        public async Task<IEnumerable<Bildiris>> SearchAsync(string searchTerm, int? userId = null)
        {
            var query = _context.Bildirisler
                .Include(b => b.HedefIstifadeci)
                .Include(b => b.GonderenIstifadeci)
                .Where(b => !b.Silindi && b.Gecerli &&
                           (b.Basliq.Contains(searchTerm) || 
                            b.Mesaj.Contains(searchTerm) ||
                            b.MenbeModulAdi.Contains(searchTerm)));

            if (userId.HasValue)
            {
                query = query.Where(b => b.HedefIstifadeciId == userId || b.HedefIstifadeciId == null);
            }

            return await query.OrderByDescending(b => b.GonderimeTarixi).ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}