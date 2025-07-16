using AzAgroPOS.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.DAL.Repositories
{
    public class BackupKaydiRepository : IDisposable
    {
        private readonly AzAgroDbContext _context;

        public BackupKaydiRepository(AzAgroDbContext context = null)
        {
            _context = context ?? new AzAgroDbContext();
        }

        public async Task<IEnumerable<BackupKaydi>> GetAllAsync()
        {
            return await _context.BackupKayitlari
                .Include(bk => bk.Istifadeci)
                .OrderByDescending(bk => bk.BackupTarixi)
                .ToListAsync();
        }

        public async Task<BackupKaydi> GetByIdAsync(int id)
        {
            return await _context.BackupKayitlari
                .Include(bk => bk.Istifadeci)
                .FirstOrDefaultAsync(bk => bk.Id == id);
        }

        public async Task<IEnumerable<BackupKaydi>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.BackupKayitlari
                .Include(bk => bk.Istifadeci)
                .Where(bk => bk.BackupTarixi >= startDate && bk.BackupTarixi <= endDate)
                .OrderByDescending(bk => bk.BackupTarixi)
                .ToListAsync();
        }

        public async Task<IEnumerable<BackupKaydi>> GetByStatusAsync(string status)
        {
            return await _context.BackupKayitlari
                .Include(bk => bk.Istifadeci)
                .Where(bk => bk.Statusu == status)
                .OrderByDescending(bk => bk.BackupTarixi)
                .ToListAsync();
        }

        public async Task<IEnumerable<BackupKaydi>> GetByBackupTypeAsync(string backupType)
        {
            return await _context.BackupKayitlari
                .Include(bk => bk.Istifadeci)
                .Where(bk => bk.BackupTipi == backupType)
                .OrderByDescending(bk => bk.BackupTarixi)
                .ToListAsync();
        }

        public async Task<IEnumerable<BackupKaydi>> GetSuccessfulBackupsAsync()
        {
            return await _context.BackupKayitlari
                .Include(bk => bk.Istifadeci)
                .Where(bk => bk.Statusu == BackupKaydi.BackupStatuslari.Ugurlu)
                .OrderByDescending(bk => bk.BackupTarixi)
                .ToListAsync();
        }

        public async Task<IEnumerable<BackupKaydi>> GetFailedBackupsAsync()
        {
            return await _context.BackupKayitlari
                .Include(bk => bk.Istifadeci)
                .Where(bk => bk.Statusu == BackupKaydi.BackupStatuslari.Ugursuz)
                .OrderByDescending(bk => bk.BackupTarixi)
                .ToListAsync();
        }

        public async Task<BackupKaydi> GetLatestBackupAsync()
        {
            return await _context.BackupKayitlari
                .Include(bk => bk.Istifadeci)
                .Where(bk => bk.Statusu == BackupKaydi.BackupStatuslari.Ugurlu)
                .OrderByDescending(bk => bk.BackupTarixi)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<BackupKaydi>> GetBackupsByUserAsync(int userId)
        {
            return await _context.BackupKayitlari
                .Include(bk => bk.Istifadeci)
                .Where(bk => bk.IstifadeciId == userId)
                .OrderByDescending(bk => bk.BackupTarixi)
                .ToListAsync();
        }

        public async Task<IEnumerable<BackupKaydi>> GetOldBackupsAsync(int daysOld)
        {
            var cutoffDate = DateTime.Now.AddDays(-daysOld);
            return await _context.BackupKayitlari
                .Include(bk => bk.Istifadeci)
                .Where(bk => bk.BackupTarixi < cutoffDate)
                .OrderBy(bk => bk.BackupTarixi)
                .ToListAsync();
        }

        public async Task<decimal> GetTotalBackupSizeAsync()
        {
            return await _context.BackupKayitlari
                .Where(bk => bk.Statusu == BackupKaydi.BackupStatuslari.Ugurlu)
                .SumAsync(bk => bk.FaylOlcusu);
        }

        public async Task<Dictionary<string, int>> GetBackupStatisticsByTypeAsync()
        {
            return await _context.BackupKayitlari
                .GroupBy(bk => bk.BackupTipi)
                .ToDictionaryAsync(g => g.Key, g => g.Count());
        }

        public async Task<Dictionary<string, int>> GetBackupStatisticsByStatusAsync()
        {
            return await _context.BackupKayitlari
                .GroupBy(bk => bk.Statusu)
                .ToDictionaryAsync(g => g.Key, g => g.Count());
        }

        public async Task<Dictionary<DateTime, int>> GetDailyBackupCountAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.BackupKayitlari
                .Where(bk => bk.BackupTarixi >= startDate && bk.BackupTarixi <= endDate)
                .GroupBy(bk => bk.BackupTarixi.Date)
                .ToDictionaryAsync(g => g.Key, g => g.Count());
        }

        public async Task<BackupKaydi> AddAsync(BackupKaydi entity)
        {
            entity.YaranmaTarixi = DateTime.Now;
            entity.YenilenmeTarixi = DateTime.Now;
            
            _context.BackupKayitlari.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<BackupKaydi> UpdateAsync(BackupKaydi entity)
        {
            entity.YenilenmeTarixi = DateTime.Now;
            
            _context.BackupKayitlari.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.BackupKayitlari.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteOldBackupsAsync(int daysOld)
        {
            var cutoffDate = DateTime.Now.AddDays(-daysOld);
            var oldBackups = await _context.BackupKayitlari
                .Where(bk => bk.BackupTarixi < cutoffDate)
                .ToListAsync();

            if (oldBackups.Any())
            {
                _context.BackupKayitlari.RemoveRange(oldBackups);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> VerifyBackupIntegrityAsync(int backupId)
        {
            var backup = await GetByIdAsync(backupId);
            if (backup == null || !backup.FaylMovcuddur)
                return false;

            try
            {
                if (!string.IsNullOrEmpty(backup.MD5Hash))
                {
                    var currentHash = CalculateFileMD5Hash(backup.BackupYolu);
                    return backup.MD5Hash.Equals(currentHash, StringComparison.OrdinalIgnoreCase);
                }
                return System.IO.File.Exists(backup.BackupYolu);
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<BackupKaydi>> SearchAsync(string searchTerm)
        {
            return await _context.BackupKayitlari
                .Include(bk => bk.Istifadeci)
                .Where(bk => bk.BackupAdi.Contains(searchTerm) ||
                           bk.Aciqlama.Contains(searchTerm) ||
                           bk.Istifadeci.Ad.Contains(searchTerm) ||
                           bk.Istifadeci.Soyad.Contains(searchTerm))
                .OrderByDescending(bk => bk.BackupTarixi)
                .ToListAsync();
        }

        private string CalculateFileMD5Hash(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
                return string.Empty;

            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                using (var stream = System.IO.File.OpenRead(filePath))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}