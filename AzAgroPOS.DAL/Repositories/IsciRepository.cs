using AzAgroPOS.Entities.Domain;
using AzAgroPOS.Entities.Constants;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.DAL.Repositories
{
    public class IsciRepository : IDisposable
    {
        private readonly AzAgroDbContext _context;

        public IsciRepository(AzAgroDbContext context = null)
        {
            _context = context ?? new AzAgroDbContext();
        }

        public async Task<IEnumerable<Isci>> GetAllAsync()
        {
            return await _context.Isciler
                .Include(i => i.YaradanIstifadeci)
                .Include(i => i.NovbeKayitlari)
                .Include(i => i.PerformansKayitlari)
                .ToListAsync();
        }

        public async Task<IEnumerable<Isci>> GetActiveAsync()
        {
            return await _context.Isciler
                .Include(i => i.YaradanIstifadeci)
                .Where(i => i.Status == SystemConstants.Status.Active)
                .ToListAsync();
        }

        public async Task<Isci> GetByIdAsync(int id)
        {
            return await _context.Isciler
                .Include(i => i.YaradanIstifadeci)
                .Include(i => i.NovbeKayitlari)
                .Include(i => i.PerformansKayitlari)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Isci> GetByCodeAsync(string isciKodu)
        {
            return await _context.Isciler
                .Include(i => i.YaradanIstifadeci)
                .FirstOrDefaultAsync(i => i.IsciKodu == isciKodu);
        }

        public async Task<IEnumerable<Isci>> GetByPositionAsync(string vezife)
        {
            return await _context.Isciler
                .Include(i => i.YaradanIstifadeci)
                .Where(i => i.Status == SystemConstants.Status.Active && i.Vezife == vezife)
                .ToListAsync();
        }

        public async Task<IEnumerable<Isci>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Isciler
                .Include(i => i.YaradanIstifadeci)
                .Where(i => i.IseBaslamaTarixi >= startDate && 
                           i.IseBaslamaTarixi <= endDate)
                .ToListAsync();
        }

        public async Task<int> AddAsync(Isci isci)
        {
            _context.Isciler.Add(isci);
            await _context.SaveChangesAsync();
            return isci.Id;
        }

        public async Task UpdateAsync(Isci isci)
        {
            _context.Entry(isci).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var isci = await _context.Isciler.FindAsync(id);
            if (isci != null)
            {
                isci.Status = SystemConstants.Status.Deleted;
                isci.YenilenmeTarixi = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> IsCodeExistsAsync(string isciKodu, int? excludeId = null)
        {
            return await _context.Isciler
                .AnyAsync(i => i.IsciKodu == isciKodu && 
                              (excludeId == null || i.Id != excludeId));
        }

        public async Task<bool> IsEmailExistsAsync(string email, int? excludeId = null)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            return await _context.Isciler
                .AnyAsync(i => i.Email == email && 
                              (excludeId == null || i.Id != excludeId));
        }

        public async Task<IEnumerable<Isci>> SearchAsync(string searchTerm)
        {
            return await _context.Isciler
                .Include(i => i.YaradanIstifadeci)
                .Where(i => i.Status == SystemConstants.Status.Active &&
                           (i.Ad.Contains(searchTerm) || 
                            i.Soyad.Contains(searchTerm) ||
                            i.IsciKodu.Contains(searchTerm) ||
                            i.Vezife.Contains(searchTerm)))
                .ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}