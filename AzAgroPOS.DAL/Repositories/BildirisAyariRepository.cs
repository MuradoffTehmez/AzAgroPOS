using AzAgroPOS.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.DAL.Repositories
{
    public class BildirisAyariRepository : IDisposable
    {
        private readonly AzAgroDbContext _context;

        public BildirisAyariRepository(AzAgroDbContext context = null)
        {
            _context = context ?? new AzAgroDbContext();
        }

        public async Task<IEnumerable<BildirisAyari>> GetAllAsync()
        {
            return await _context.BildirisAyarlari
                .Include(ba => ba.Istifadeci)
                .OrderBy(ba => ba.IstifadeciId)
                .ThenBy(ba => ba.ModulAdi)
                .ToListAsync();
        }

        public async Task<BildirisAyari> GetByIdAsync(int id)
        {
            return await _context.BildirisAyarlari
                .Include(ba => ba.Istifadeci)
                .FirstOrDefaultAsync(ba => ba.Id == id);
        }

        public async Task<IEnumerable<BildirisAyari>> GetByUserIdAsync(int userId)
        {
            return await _context.BildirisAyarlari
                .Where(ba => ba.IstifadeciId == userId)
                .OrderBy(ba => ba.ModulAdi)
                .ThenBy(ba => ba.BildirisNovu)
                .ToListAsync();
        }

        public async Task<BildirisAyari> GetByUserAndModuleAsync(int userId, string moduleName, string notificationType)
        {
            return await _context.BildirisAyarlari
                .FirstOrDefaultAsync(ba => ba.IstifadeciId == userId && 
                                         ba.ModulAdi == moduleName && 
                                         ba.BildirisNovu == notificationType);
        }

        public async Task<IEnumerable<BildirisAyari>> GetByModuleAsync(string moduleName)
        {
            return await _context.BildirisAyarlari
                .Include(ba => ba.Istifadeci)
                .Where(ba => ba.ModulAdi == moduleName)
                .OrderBy(ba => ba.IstifadeciId)
                .ToListAsync();
        }

        public async Task<IEnumerable<BildirisAyari>> GetEmailEnabledAsync()
        {
            return await _context.BildirisAyarlari
                .Include(ba => ba.Istifadeci)
                .Where(ba => ba.EmailBildirimi)
                .ToListAsync();
        }

        public async Task<IEnumerable<BildirisAyari>> GetSoundEnabledAsync()
        {
            return await _context.BildirisAyarlari
                .Include(ba => ba.Istifadeci)
                .Where(ba => ba.SesliSiqnal)
                .ToListAsync();
        }

        public async Task<IEnumerable<BildirisAyari>> GetDesktopEnabledAsync()
        {
            return await _context.BildirisAyarlari
                .Include(ba => ba.Istifadeci)
                .Where(ba => ba.MasaustuBildirimi)
                .ToListAsync();
        }

        public async Task<IEnumerable<BildirisAyari>> GetActiveSettingsAsync()
        {
            return await _context.BildirisAyarlari
                .Include(ba => ba.Istifadeci)
                .Where(ba => ba.HazirdaAktiv)
                .ToListAsync();
        }

        public async Task<BildirisAyari> AddAsync(BildirisAyari entity)
        {
            entity.YaranmaTarixi = DateTime.Now;
            entity.YenilenmeTarixi = DateTime.Now;
            
            _context.BildirisAyarlari.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<BildirisAyari> UpdateAsync(BildirisAyari entity)
        {
            entity.YenilenmeTarixi = DateTime.Now;
            
            _context.BildirisAyarlari.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.BildirisAyarlari.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<BildirisAyari> CreateOrUpdateSettingAsync(int userId, string moduleName, string notificationType, BildirisAyari newSettings)
        {
            var existingSetting = await GetByUserAndModuleAsync(userId, moduleName, notificationType);
            
            if (existingSetting != null)
            {
                // Update existing
                existingSetting.EmailBildirimi = newSettings.EmailBildirimi;
                existingSetting.SistemBildirimi = newSettings.SistemBildirimi;
                existingSetting.SesliSiqnal = newSettings.SesliSiqnal;
                existingSetting.MasaustuBildirimi = newSettings.MasaustuBildirimi;
                existingSetting.SesliSiqnalFayli = newSettings.SesliSiqnalFayli;
                existingSetting.GeceSessiz = newSettings.GeceSessiz;
                existingSetting.SessizBaslangic = newSettings.SessizBaslangic;
                existingSetting.SessizBitis = newSettings.SessizBitis;
                existingSetting.Prioritet = newSettings.Prioritet;
                existingSetting.OtomatikSil = newSettings.OtomatikSil;
                existingSetting.OtomatikSilmeGunu = newSettings.OtomatikSilmeGunu;
                existingSetting.SadeceMuhimBildirisler = newSettings.SadeceMuhimBildirisler;
                existingSetting.AcarSozler = newSettings.AcarSozler;
                existingSetting.IstisnaAcarSozler = newSettings.IstisnaAcarSozler;
                existingSetting.AktivSaatlarDaxilinde = newSettings.AktivSaatlarDaxilinde;
                existingSetting.AktivBaslangic = newSettings.AktivBaslangic;
                existingSetting.AktivBitis = newSettings.AktivBitis;
                existingSetting.HefteSonuRezhimi = newSettings.HefteSonuRezhimi;
                
                return await UpdateAsync(existingSetting);
            }
            else
            {
                // Create new
                newSettings.IstifadeciId = userId;
                newSettings.ModulAdi = moduleName;
                newSettings.BildirisNovu = notificationType;
                return await AddAsync(newSettings);
            }
        }

        public async Task<bool> EnableNotificationsForUserAsync(int userId, string moduleName, string notificationType)
        {
            var setting = await GetByUserAndModuleAsync(userId, moduleName, notificationType);
            if (setting != null)
            {
                setting.SistemBildirimi = true;
                await UpdateAsync(setting);
                return true;
            }
            else
            {
                var newSetting = new BildirisAyari
                {
                    IstifadeciId = userId,
                    ModulAdi = moduleName,
                    BildirisNovu = notificationType,
                    SistemBildirimi = true,
                    EmailBildirimi = false,
                    SesliSiqnal = false,
                    MasaustuBildirimi = true
                };
                await AddAsync(newSetting);
                return true;
            }
        }

        public async Task<bool> DisableNotificationsForUserAsync(int userId, string moduleName, string notificationType)
        {
            var setting = await GetByUserAndModuleAsync(userId, moduleName, notificationType);
            if (setting != null)
            {
                setting.SistemBildirimi = false;
                setting.EmailBildirimi = false;
                setting.SesliSiqnal = false;
                setting.MasaustuBildirimi = false;
                await UpdateAsync(setting);
                return true;
            }
            return false;
        }

        public async Task<bool> SetDefaultsForUserAsync(int userId)
        {
            var modules = new[]
            {
                Bildiris.BildirisModulleri.Sistem,
                Bildiris.BildirisModulleri.Satis,
                Bildiris.BildirisModulleri.Anbar,
                Bildiris.BildirisModulleri.Novbe,
                Bildiris.BildirisModulleri.Backup,
                Bildiris.BildirisModulleri.Tamir,
                Bildiris.BildirisModulleri.Borc,
                Bildiris.BildirisModulleri.Gider
            };

            var notificationTypes = new[]
            {
                Bildiris.BildirisNovleri.Melumat,
                Bildiris.BildirisNovleri.Xeberdarliq,
                Bildiris.BildirisNovleri.Xeta,
                Bildiris.BildirisNovleri.Ugur,
                Bildiris.BildirisNovleri.Sistem
            };

            foreach (var module in modules)
            {
                foreach (var type in notificationTypes)
                {
                    var exists = await GetByUserAndModuleAsync(userId, module, type);
                    if (exists == null)
                    {
                        var defaultSetting = new BildirisAyari
                        {
                            IstifadeciId = userId,
                            ModulAdi = module,
                            BildirisNovu = type,
                            SistemBildirimi = true,
                            EmailBildirimi = false,
                            SesliSiqnal = type == Bildiris.BildirisNovleri.Xeta || type == Bildiris.BildirisNovleri.Xeberdarliq,
                            MasaustuBildirimi = true,
                            GeceSessiz = true,
                            SessizBaslangic = new TimeSpan(22, 0, 0),
                            SessizBitis = new TimeSpan(8, 0, 0),
                            Prioritet = Bildiris.BildirisPrioritetleri.Orta,
                            OtomatikSil = true,
                            OtomatikSilmeGunu = 30,
                            AktivSaatlarDaxilinde = false,
                            HefteSonuRezhimi = BildirisAyari.HefteSonuRejimi.Normal
                        };
                        await AddAsync(defaultSetting);
                    }
                }
            }

            return true;
        }

        public async Task<Dictionary<string, object>> GetUserNotificationPreferencesAsync(int userId)
        {
            var settings = await GetByUserIdAsync(userId);
            
            var emailEnabled = settings.Count(s => s.EmailBildirimi);
            var soundEnabled = settings.Count(s => s.SesliSiqnal);
            var desktopEnabled = settings.Count(s => s.MasaustuBildirimi);
            var systemEnabled = settings.Count(s => s.SistemBildirimi);

            var moduleStats = settings.GroupBy(s => s.ModulAdi)
                .ToDictionary(g => g.Key, g => new
                {
                    Total = g.Count(),
                    Enabled = g.Count(s => s.SistemBildirimi),
                    EmailEnabled = g.Count(s => s.EmailBildirimi),
                    SoundEnabled = g.Count(s => s.SesliSiqnal)
                });

            return new Dictionary<string, object>
            {
                { "TotalSettings", settings.Count() },
                { "EmailEnabled", emailEnabled },
                { "SoundEnabled", soundEnabled },
                { "DesktopEnabled", desktopEnabled },
                { "SystemEnabled", systemEnabled },
                { "ModuleStatistics", moduleStats }
            };
        }

        public async Task<IEnumerable<BildirisAyari>> GetSettingsForNotificationAsync(string moduleName, string notificationType)
        {
            return await _context.BildirisAyarlari
                .Include(ba => ba.Istifadeci)
                .Where(ba => ba.ModulAdi == moduleName && 
                           ba.BildirisNovu == notificationType &&
                           ba.SistemBildirimi)
                .ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}