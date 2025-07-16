using AzAgroPOS.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.DAL.Repositories
{
    public class BackupTenzimlemeRepository : IDisposable
    {
        private readonly AzAgroDbContext _context;

        public BackupTenzimlemeRepository(AzAgroDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<BackupTenzimleme>> GetAllAsync()
        {
            return await _context.BackupTenzimlemeleri
                .OrderBy(bt => bt.TenzimlemeAdi)
                .ToListAsync();
        }

        public async Task<BackupTenzimleme> GetByIdAsync(int id)
        {
            return await _context.BackupTenzimlemeleri
                .FirstOrDefaultAsync(bt => bt.Id == id);
        }

        public async Task<IEnumerable<BackupTenzimleme>> GetActiveConfigurationsAsync()
        {
            return await _context.BackupTenzimlemeleri
                .Where(bt => bt.Aktiv)
                .OrderBy(bt => bt.SonrakiBackupTarixi)
                .ToListAsync();
        }

        public async Task<IEnumerable<BackupTenzimleme>> GetConfigurationsByTypeAsync(string backupType)
        {
            return await _context.BackupTenzimlemeleri
                .Where(bt => bt.BackupTipi == backupType)
                .OrderBy(bt => bt.TenzimlemeAdi)
                .ToListAsync();
        }

        public async Task<IEnumerable<BackupTenzimleme>> GetDueBackupsAsync()
        {
            var now = DateTime.Now;
            return await _context.BackupTenzimlemeleri
                .Where(bt => bt.Aktiv && 
                           bt.OtomatikBackup && 
                           bt.SonrakiBackupTarixi <= now)
                .OrderBy(bt => bt.SonrakiBackupTarixi)
                .ToListAsync();
        }

        public async Task<IEnumerable<BackupTenzimleme>> GetConfigurationsWithEmailNotificationAsync()
        {
            return await _context.BackupTenzimlemeleri
                .Where(bt => bt.Aktiv && bt.EmailBildirim && !string.IsNullOrEmpty(bt.EmailUnvanlari))
                .ToListAsync();
        }

        public async Task<BackupTenzimleme> GetDefaultConfigurationAsync()
        {
            return await _context.BackupTenzimlemeleri
                .Where(bt => bt.Aktiv && bt.TenzimlemeAdi.Contains("Default"))
                .FirstOrDefaultAsync() ?? 
                await _context.BackupTenzimlemeleri
                .Where(bt => bt.Aktiv)
                .FirstOrDefaultAsync();
        }

        public async Task<BackupTenzimleme> AddAsync(BackupTenzimleme entity)
        {
            entity.YaranmaTarixi = DateTime.Now;
            entity.YenilenmeTarixi = DateTime.Now;
            
            // Calculate next backup time
            entity.HesablaNextBackupTime();
            
            _context.BackupTenzimlemeleri.Add(entity);
            return entity;
        }

        public async Task<BackupTenzimleme> UpdateAsync(BackupTenzimleme entity)
        {
            entity.YenilenmeTarixi = DateTime.Now;
            
            // Recalculate next backup time
            entity.HesablaNextBackupTime();
            
            _context.BackupTenzimlemeleri.Update(entity);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.BackupTenzimlemeleri.Remove(entity);
            }
        }

        public async Task<bool> ActivateConfigurationAsync(int id)
        {
            var configuration = await GetByIdAsync(id);
            if (configuration != null)
            {
                configuration.Aktiv = true;
                configuration.HesablaNextBackupTime();
                await UpdateAsync(configuration);
                return true;
            }
            return false;
        }

        public async Task<bool> DeactivateConfigurationAsync(int id)
        {
            var configuration = await GetByIdAsync(id);
            if (configuration != null)
            {
                configuration.Aktiv = false;
                await UpdateAsync(configuration);
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateLastBackupTimeAsync(int id, DateTime backupTime)
        {
            var configuration = await GetByIdAsync(id);
            if (configuration != null)
            {
                configuration.SonBackupTarixi = backupTime;
                configuration.HesablaNextBackupTime();
                await UpdateAsync(configuration);
                return true;
            }
            return false;
        }

        public async Task UpdateNextBackupTimesAsync()
        {
            var configurations = await GetActiveConfigurationsAsync();
            foreach (var config in configurations)
            {
                config.HesablaNextBackupTime();
                _context.BackupTenzimlemeleri.Update(config);
            }
        }

        public async Task<IEnumerable<BackupTenzimleme>> GetConfigurationsNeedingCleanupAsync()
        {
            return await _context.BackupTenzimlemeleri
                .Where(bt => bt.Aktiv && bt.KohneBackuplarVar)
                .ToListAsync();
        }

        public async Task<Dictionary<string, object>> GetBackupConfigurationStatisticsAsync()
        {
            var totalConfigurations = await _context.BackupTenzimlemeleri.CountAsync();
            var activeConfigurations = await _context.BackupTenzimlemeleri.CountAsync(bt => bt.Aktiv);
            var automaticConfigurations = await _context.BackupTenzimlemeleri.CountAsync(bt => bt.OtomatikBackup);
            var encryptedConfigurations = await _context.BackupTenzimlemeleri.CountAsync(bt => bt.Sifreleme);

            var typeStatistics = await _context.BackupTenzimlemeleri
                .GroupBy(bt => bt.BackupTipi)
                .ToDictionaryAsync(g => g.Key, g => g.Count());

            return new Dictionary<string, object>
            {
                { "TotalConfigurations", totalConfigurations },
                { "ActiveConfigurations", activeConfigurations },
                { "AutomaticConfigurations", automaticConfigurations },
                { "EncryptedConfigurations", encryptedConfigurations },
                { "TypeStatistics", typeStatistics }
            };
        }

        public async Task<IEnumerable<BackupTenzimleme>> SearchAsync(string searchTerm)
        {
            return await _context.BackupTenzimlemeleri
                .Where(bt => bt.TenzimlemeAdi.Contains(searchTerm) ||
                           bt.BackupYolu.Contains(searchTerm) ||
                           bt.Qeydler.Contains(searchTerm))
                .OrderBy(bt => bt.TenzimlemeAdi)
                .ToListAsync();
        }

        public async Task<bool> IsConfigurationNameUniqueAsync(string name, int? excludeId = null)
        {
            var query = _context.BackupTenzimlemeleri.Where(bt => bt.TenzimlemeAdi == name);
            
            if (excludeId.HasValue)
                query = query.Where(bt => bt.Id != excludeId.Value);

            return !await query.AnyAsync();
        }

        public async Task<BackupTenzimleme> CloneConfigurationAsync(int sourceId, string newName)
        {
            var source = await GetByIdAsync(sourceId);
            if (source == null)
                return null;

            var clone = new BackupTenzimleme
            {
                TenzimlemeAdi = newName,
                BackupYolu = source.BackupYolu,
                BackupTipi = source.BackupTipi,
                OtomatikBackup = source.OtomatikBackup,
                BackupSaati = source.BackupSaati,
                GunleriBitmesi = source.GunleriBitmesi,
                SaxlanmaGunSayi = source.SaxlanmaGunSayi,
                Sifreleme = source.Sifreleme,
                SifrelemeSifre = source.SifrelemeSifre,
                Siqisdir = source.Siqisdir,
                SiqisdirmaSeviyesi = source.SiqisdirmaSeviyesi,
                EmailBildirim = source.EmailBildirim,
                EmailUnvanlari = source.EmailUnvanlari,
                Aktiv = false, // Clone starts as inactive
                DaxilEdilenCedveller = source.DaxilEdilenCedveller,
                IstisnaEdilenCedveller = source.IstisnaEdilenCedveller,
                BackupMelumatlarDaxil = source.BackupMelumatlarDaxil,
                BackupStrukturDaxil = source.BackupStrukturDaxil,
                Qeydler = $"Klonlandı: {source.TenzimlemeAdi}"
            };

            return await AddAsync(clone);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}