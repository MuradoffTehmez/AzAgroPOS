using AzAgroPOS.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.DAL.Repositories
{
    public class NovbeCedveliRepository : IDisposable
    {
        private readonly AzAgroDbContext _context;

        public NovbeCedveliRepository(AzAgroDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<NovbeCedveli>> GetAllAsync()
        {
            return await _context.NovbeCedvelleri
                .Include(n => n.NovbeDetallari)
                .ThenInclude(nd => nd.Isci)
                .OrderByDescending(n => n.YaranmaTarixi)
                .ToListAsync();
        }

        public async Task<NovbeCedveli> GetByIdAsync(int id)
        {
            return await _context.NovbeCedvelleri
                .Include(n => n.NovbeDetallari)
                .ThenInclude(nd => nd.Isci)
                .FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<IEnumerable<NovbeCedveli>> GetActiveSchedulesAsync()
        {
            return await _context.NovbeCedvelleri
                .Include(n => n.NovbeDetallari)
                .ThenInclude(nd => nd.Isci)
                .Where(n => n.Aktiv)
                .OrderBy(n => n.Ad)
                .ToListAsync();
        }

        public async Task<IEnumerable<NovbeCedveli>> GetSchedulesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.NovbeCedvelleri
                .Include(n => n.NovbeDetallari)
                .ThenInclude(nd => nd.Isci)
                .Where(n => n.BaslamaTarixi <= endDate && 
                           (n.BitisTarixi == null || n.BitisTarixi >= startDate))
                .OrderBy(n => n.BaslamaTarixi)
                .ToListAsync();
        }

        public async Task<NovbeCedveli> AddAsync(NovbeCedveli entity)
        {
            entity.YaranmaTarixi = DateTime.Now;
            entity.YenilenmeTarixi = DateTime.Now;
            
            _context.NovbeCedvelleri.Add(entity);
            return entity;
        }

        public async Task<NovbeCedveli> UpdateAsync(NovbeCedveli entity)
        {
            entity.YenilenmeTarixi = DateTime.Now;
            
            _context.NovbeCedvelleri.Update(entity);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.NovbeCedvelleri.Remove(entity);
                }
        }

        public async Task<bool> DeactivateScheduleAsync(int id)
        {
            var schedule = await GetByIdAsync(id);
            if (schedule != null)
            {
                schedule.Aktiv = false;
                schedule.BitisTarixi = DateTime.Now;
                await UpdateAsync(schedule);
                return true;
            }
            return false;
        }

        public async Task<bool> ActivateScheduleAsync(int id)
        {
            var schedule = await GetByIdAsync(id);
            if (schedule != null)
            {
                schedule.Aktiv = true;
                schedule.BitisTarixi = null;
                await UpdateAsync(schedule);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<NovbeCedveli>> SearchAsync(string searchTerm)
        {
            return await _context.NovbeCedvelleri
                .Include(n => n.NovbeDetallari)
                .ThenInclude(nd => nd.Isci)
                .Where(n => n.Ad.Contains(searchTerm) || 
                           n.Aciqlama.Contains(searchTerm))
                .OrderBy(n => n.Ad)
                .ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}