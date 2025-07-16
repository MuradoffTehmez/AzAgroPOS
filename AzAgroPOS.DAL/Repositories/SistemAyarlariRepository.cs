using AzAgroPOS.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.DAL.Repositories
{
    public class SistemAyarlariRepository : IDisposable
    {
        private readonly AzAgroDbContext _context;

        public SistemAyarlariRepository(AzAgroDbContext context = null)
        {
            _context = context ?? new AzAgroDbContext();
        }

        public async Task<IEnumerable<SistemAyarlari>> GetAllAsync()
        {
            return await _context.SistemAyarlari
                .OrderBy(s => s.Kateqoriya)
                .ThenBy(s => s.Acar)
                .ToListAsync();
        }

        public async Task<SistemAyarlari> GetByIdAsync(int id)
        {
            return await _context.SistemAyarlari
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<SistemAyarlari> GetByKeyAsync(string key)
        {
            return await _context.SistemAyarlari
                .FirstOrDefaultAsync(s => s.Acar == key);
        }

        public async Task<IEnumerable<SistemAyarlari>> GetByCategoryAsync(string category)
        {
            return await _context.SistemAyarlari
                .Where(s => s.Kateqoriya == category)
                .OrderBy(s => s.Acar)
                .ToListAsync();
        }

        public async Task<IEnumerable<SistemAyarlari>> GetUserEditableAsync()
        {
            return await _context.SistemAyarlari
                .Where(s => s.IstifadeciDeyise)
                .OrderBy(s => s.Kateqoriya)
                .ThenBy(s => s.Acar)
                .ToListAsync();
        }

        public async Task<string> GetSettingValueAsync(string key, string defaultValue = "")
        {
            var setting = await GetByKeyAsync(key);
            return setting?.Deyer ?? defaultValue;
        }

        public async Task<T> GetSettingValueAsync<T>(string key, T defaultValue = default(T))
        {
            var setting = await GetByKeyAsync(key);
            if (setting == null) return defaultValue;

            try
            {
                return (T)Convert.ChangeType(setting.Deyer, typeof(T));
            }
            catch
            {
                return defaultValue;
            }
        }

        public async Task<bool> SetSettingValueAsync(string key, string value, string description = null, string category = null, string dataType = null)
        {
            var setting = await GetByKeyAsync(key);
            
            if (setting == null)
            {
                // Create new setting
                setting = new SistemAyarlari
                {
                    Acar = key,
                    Deyer = value,
                    Aciqlama = description ?? "",
                    Kateqoriya = category ?? SistemAyarlari.Categories.Regional,
                    DataTipi = dataType ?? SistemAyarlari.DataTypes.String,
                    YaranmaTarixi = DateTime.Now,
                    YenilenmeTarixi = DateTime.Now
                };
                _context.SistemAyarlari.Add(setting);
            }
            else
            {
                // Update existing setting
                setting.Deyer = value;
                setting.YenilenmeTarixi = DateTime.Now;
                if (!string.IsNullOrEmpty(description))
                    setting.Aciqlama = description;
                if (!string.IsNullOrEmpty(category))
                    setting.Kateqoriya = category;
                if (!string.IsNullOrEmpty(dataType))
                    setting.DataTipi = dataType;
                
                _context.SistemAyarlari.Update(setting);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<SistemAyarlari> AddAsync(SistemAyarlari entity)
        {
            entity.YaranmaTarixi = DateTime.Now;
            entity.YenilenmeTarixi = DateTime.Now;
            
            _context.SistemAyarlari.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<SistemAyarlari> UpdateAsync(SistemAyarlari entity)
        {
            entity.YenilenmeTarixi = DateTime.Now;
            
            _context.SistemAyarlari.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.SistemAyarlari.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> DeleteByKeyAsync(string key)
        {
            var setting = await GetByKeyAsync(key);
            if (setting != null)
            {
                _context.SistemAyarlari.Remove(setting);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task InitializeDefaultSettingsAsync()
        {
            var existingSettings = await _context.SistemAyarlari.ToListAsync();
            var defaultSettings = GetDefaultSettings();

            foreach (var defaultSetting in defaultSettings)
            {
                if (!existingSettings.Any(s => s.Acar == defaultSetting.Acar))
                {
                    await AddAsync(defaultSetting);
                }
            }
        }

        private List<SistemAyarlari> GetDefaultSettings()
        {
            return new List<SistemAyarlari>
            {
                // Regional Settings
                new SistemAyarlari { Acar = SistemAyarlari.Keys.Dil, Deyer = "az", Aciqlama = "Sistem dili", Kateqoriya = SistemAyarlari.Categories.Regional, DataTipi = SistemAyarlari.DataTypes.String },
                new SistemAyarlari { Acar = SistemAyarlari.Keys.Valyuta, Deyer = "₼", Aciqlama = "Ana valyuta simvolu", Kateqoriya = SistemAyarlari.Categories.Regional, DataTipi = SistemAyarlari.DataTypes.String },
                new SistemAyarlari { Acar = SistemAyarlari.Keys.TarixFormati, Deyer = "dd.MM.yyyy", Aciqlama = "Tarix formatı", Kateqoriya = SistemAyarlari.Categories.Regional, DataTipi = SistemAyarlari.DataTypes.String },
                new SistemAyarlari { Acar = SistemAyarlari.Keys.OndalikNoqte, Deyer = "2", Aciqlama = "Ondalık nöqtədən sonrakı rəqəm sayı", Kateqoriya = SistemAyarlari.Categories.Regional, DataTipi = SistemAyarlari.DataTypes.Integer },

                // Appearance Settings
                new SistemAyarlari { Acar = SistemAyarlari.Keys.Tema, Deyer = "Modern", Aciqlama = "Sistem teması", Kateqoriya = SistemAyarlari.Categories.Gorunus, DataTipi = SistemAyarlari.DataTypes.String },
                new SistemAyarlari { Acar = SistemAyarlari.Keys.EsasReng, Deyer = "#3498db", Aciqlama = "Əsas rəng", Kateqoriya = SistemAyarlari.Categories.Gorunus, DataTipi = SistemAyarlari.DataTypes.Color },
                new SistemAyarlari { Acar = SistemAyarlari.Keys.YaziOlcusu, Deyer = "10", Aciqlama = "Yazı ölçüsü", Kateqoriya = SistemAyarlari.Categories.Gorunus, DataTipi = SistemAyarlari.DataTypes.Integer },
                new SistemAyarlari { Acar = SistemAyarlari.Keys.SirketAdi, Deyer = "AzAgroPOS", Aciqlama = "Şirkət adı", Kateqoriya = SistemAyarlari.Categories.Gorunus, DataTipi = SistemAyarlari.DataTypes.String },

                // POS Settings
                new SistemAyarlari { Acar = SistemAyarlari.Keys.QebzCapi, Deyer = "true", Aciqlama = "Qəbz çapını aktiv et", Kateqoriya = SistemAyarlari.Categories.POS, DataTipi = SistemAyarlari.DataTypes.Boolean },
                new SistemAyarlari { Acar = SistemAyarlari.Keys.AvtomatikQebz, Deyer = "true", Aciqlama = "Avtomatik qəbz çapı", Kateqoriya = SistemAyarlari.Categories.POS, DataTipi = SistemAyarlari.DataTypes.Boolean },

                // Business Settings
                new SistemAyarlari { Acar = SistemAyarlari.Keys.EdvDerecesi, Deyer = "18", Aciqlama = "ƏDV dərəcəsi (%)", Kateqoriya = SistemAyarlari.Categories.Biznes, DataTipi = SistemAyarlari.DataTypes.Decimal },

                // Database Settings
                new SistemAyarlari { Acar = SistemAyarlari.Keys.BackupMuddeti, Deyer = "7", Aciqlama = "Backup müddəti (gün)", Kateqoriya = SistemAyarlari.Categories.Database, DataTipi = SistemAyarlari.DataTypes.Integer },
                new SistemAyarlari { Acar = SistemAyarlari.Keys.LogSaxlamaMuddeti, Deyer = "30", Aciqlama = "Log saxlama müddəti (gün)", Kateqoriya = SistemAyarlari.Categories.Database, DataTipi = SistemAyarlari.DataTypes.Integer },

                // Security Settings
                new SistemAyarlari { Acar = SistemAyarlari.Keys.GirisCehdSayi, Deyer = "3", Aciqlama = "Maksimum giriş cəhdi sayı", Kateqoriya = SistemAyarlari.Categories.Tehlukesizlik, DataTipi = SistemAyarlari.DataTypes.Integer },
                new SistemAyarlari { Acar = SistemAyarlari.Keys.BloklananMuddet, Deyer = "15", Aciqlama = "Bloklanma müddəti (dəqiqə)", Kateqoriya = SistemAyarlari.Categories.Tehlukesizlik, DataTipi = SistemAyarlari.DataTypes.Integer },

                // Notification Settings
                new SistemAyarlari { Acar = SistemAyarlari.Keys.MehsulQitligi, Deyer = "5", Aciqlama = "Məhsul qıtlığı hədd", Kateqoriya = SistemAyarlari.Categories.Bildiriş, DataTipi = SistemAyarlari.DataTypes.Integer },
                new SistemAyarlari { Acar = SistemAyarlari.Keys.SmsAktiv, Deyer = "false", Aciqlama = "SMS bildirişləri aktiv", Kateqoriya = SistemAyarlari.Categories.Bildiriş, DataTipi = SistemAyarlari.DataTypes.Boolean },
                new SistemAyarlari { Acar = SistemAyarlari.Keys.EmailAktiv, Deyer = "false", Aciqlama = "Email bildirişləri aktiv", Kateqoriya = SistemAyarlari.Categories.Bildiriş, DataTipi = SistemAyarlari.DataTypes.Boolean }
            };
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}