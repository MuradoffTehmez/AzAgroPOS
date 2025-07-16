using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.BLL.Services
{
    public class SistemAyarlariService
    {
        private readonly SistemAyarlariRepository _repository;
        private static Dictionary<string, string> _cachedSettings = new Dictionary<string, string>();

        public SistemAyarlariService(SistemAyarlariRepository repository)
        {
            _repository = repository;
        }

        // Get all settings
        public async Task<IEnumerable<SistemAyarlari>> GetAllSettingsAsync()
        {
            return await _repository.GetAllAsync();
        }

        // Get settings by category
        public async Task<IEnumerable<SistemAyarlari>> GetSettingsByCategoryAsync(string category)
        {
            return await _repository.GetByCategoryAsync(category);
        }

        // Get user-editable settings
        public async Task<IEnumerable<SistemAyarlari>> GetUserEditableSettingsAsync()
        {
            return await _repository.GetUserEditableAsync();
        }

        // Get setting value with type conversion
        public async Task<T> GetSettingAsync<T>(string key, T defaultValue = default(T))
        {
            try
            {
                // First check cache
                if (_cachedSettings.ContainsKey(key))
                {
                    return ConvertValue<T>(_cachedSettings[key], defaultValue);
                }

                // Get from database
                var value = await _repository.GetSettingValueAsync(key);
                if (!string.IsNullOrEmpty(value))
                {
                    _cachedSettings[key] = value;
                    return ConvertValue<T>(value, defaultValue);
                }

                return defaultValue;
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }

        // Set setting value
        public async Task<bool> SetSettingAsync(string key, object value, string description = null, string category = null, string dataType = null)
        {
            try
            {
                var stringValue = value?.ToString() ?? "";
                var result = await _repository.SetSettingValueAsync(key, stringValue, description, category, dataType);
                
                if (result)
                {
                    // Update cache
                    _cachedSettings[key] = stringValue;
                }

                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Initialize default settings
        public async Task InitializeDefaultSettingsAsync()
        {
            await _repository.InitializeDefaultSettingsAsync();
            await RefreshCacheAsync();
        }

        // Refresh cache from database
        public async Task RefreshCacheAsync()
        {
            _cachedSettings.Clear();
            var allSettings = await _repository.GetAllAsync();
            foreach (var setting in allSettings)
            {
                _cachedSettings[setting.Acar] = setting.Deyer;
            }
        }

        // Regional Settings Methods
        public async Task<string> GetCurrentLanguageAsync()
        {
            return await GetSettingAsync(SistemAyarlari.Keys.Dil, "az");
        }

        public async Task<string> GetCurrentCurrencyAsync()
        {
            return await GetSettingAsync(SistemAyarlari.Keys.Valyuta, "₼");
        }

        public async Task<string> GetDateFormatAsync()
        {
            return await GetSettingAsync(SistemAyarlari.Keys.TarixFormati, "dd.MM.yyyy");
        }

        public async Task<int> GetDecimalPlacesAsync()
        {
            return await GetSettingAsync(SistemAyarlari.Keys.OndalikNoqte, 2);
        }

        // Appearance Settings Methods
        public async Task<string> GetCurrentThemeAsync()
        {
            return await GetSettingAsync(SistemAyarlari.Keys.Tema, "Modern");
        }

        public async Task<Color> GetPrimaryColorAsync()
        {
            var colorHex = await GetSettingAsync(SistemAyarlari.Keys.EsasReng, "#3498db");
            return ColorFromHex(colorHex);
        }

        public async Task<int> GetFontSizeAsync()
        {
            return await GetSettingAsync(SistemAyarlari.Keys.YaziOlcusu, 10);
        }

        public async Task<string> GetCompanyNameAsync()
        {
            return await GetSettingAsync(SistemAyarlari.Keys.SirketAdi, "AzAgroPOS");
        }

        public async Task<string> GetCompanyAddressAsync()
        {
            return await GetSettingAsync(SistemAyarlari.Keys.SirketUnvani, "");
        }

        public async Task<string> GetLogoPathAsync()
        {
            return await GetSettingAsync(SistemAyarlari.Keys.LogoYolu, "");
        }

        // POS Settings Methods
        public async Task<bool> GetReceiptPrintingEnabledAsync()
        {
            return await GetSettingAsync(SistemAyarlari.Keys.QebzCapi, true);
        }

        public async Task<string> GetPrinterNameAsync()
        {
            return await GetSettingAsync(SistemAyarlari.Keys.PrinterAdi, "");
        }

        public async Task<bool> GetAutomaticReceiptAsync()
        {
            return await GetSettingAsync(SistemAyarlari.Keys.AvtomatikQebz, true);
        }

        // Business Settings Methods
        public async Task<decimal> GetVATRateAsync()
        {
            return await GetSettingAsync(SistemAyarlari.Keys.EdvDerecesi, 18m);
        }

        public async Task<string> GetVATNumberAsync()
        {
            return await GetSettingAsync(SistemAyarlari.Keys.EdvNomresi, "");
        }

        public async Task<string> GetPhoneNumberAsync()
        {
            return await GetSettingAsync(SistemAyarlari.Keys.TelefonNomresi, "");
        }

        public async Task<string> GetEmailAddressAsync()
        {
            return await GetSettingAsync(SistemAyarlari.Keys.EmailAdresi, "");
        }

        // Security Settings Methods
        public async Task<int> GetMaxLoginAttemptsAsync()
        {
            return await GetSettingAsync(SistemAyarlari.Keys.GirisCehdSayi, 3);
        }

        public async Task<int> GetLockoutDurationAsync()
        {
            return await GetSettingAsync(SistemAyarlari.Keys.BloklananMuddet, 15);
        }

        // Notification Settings Methods
        public async Task<int> GetStockAlertLevelAsync()
        {
            return await GetSettingAsync(SistemAyarlari.Keys.MehsulQitligi, 5);
        }

        public async Task<bool> GetSMSNotificationsEnabledAsync()
        {
            return await GetSettingAsync(SistemAyarlari.Keys.SmsAktiv, false);
        }

        public async Task<bool> GetEmailNotificationsEnabledAsync()
        {
            return await GetSettingAsync(SistemAyarlari.Keys.EmailAktiv, false);
        }

        // File Management Methods
        public async Task<string> SaveLogoAsync(string sourcePath)
        {
            try
            {
                if (string.IsNullOrEmpty(sourcePath) || !File.Exists(sourcePath))
                    return "";

                var appDir = AppDomain.CurrentDomain.BaseDirectory;
                var logoDir = Path.Combine(appDir, "Resources", "Logos");
                
                if (!Directory.Exists(logoDir))
                    Directory.CreateDirectory(logoDir);

                var fileName = $"logo_{DateTime.Now:yyyyMMdd_HHmmss}{Path.GetExtension(sourcePath)}";
                var destinationPath = Path.Combine(logoDir, fileName);
                
                File.Copy(sourcePath, destinationPath, true);
                
                // Save logo path to settings
                var relativePath = Path.Combine("Resources", "Logos", fileName);
                await SetSettingAsync(SistemAyarlari.Keys.LogoYolu, relativePath);
                
                return relativePath;
            }
            catch (Exception)
            {
                return "";
            }
        }

        // Backup settings
        public async Task<bool> ExportSettingsAsync(string filePath)
        {
            try
            {
                var settings = await GetAllSettingsAsync();
                var lines = settings.Select(s => $"{s.Acar}={s.Deyer}");
                await File.WriteAllLinesAsync(filePath, lines);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> ImportSettingsAsync(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                    return false;

                var lines = await File.ReadAllLinesAsync(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split('=', 2);
                    if (parts.Length == 2)
                    {
                        await SetSettingAsync(parts[0], parts[1]);
                    }
                }

                await RefreshCacheAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Helper Methods
        private T ConvertValue<T>(string value, T defaultValue)
        {
            try
            {
                if (string.IsNullOrEmpty(value))
                    return defaultValue;

                if (typeof(T) == typeof(bool))
                {
                    return (T)(object)bool.Parse(value);
                }
                else if (typeof(T) == typeof(int))
                {
                    return (T)(object)int.Parse(value);
                }
                else if (typeof(T) == typeof(decimal))
                {
                    return (T)(object)decimal.Parse(value, CultureInfo.InvariantCulture);
                }
                else if (typeof(T) == typeof(double))
                {
                    return (T)(object)double.Parse(value, CultureInfo.InvariantCulture);
                }
                else if (typeof(T) == typeof(DateTime))
                {
                    return (T)(object)DateTime.Parse(value);
                }
                else
                {
                    return (T)(object)value;
                }
            }
            catch
            {
                return defaultValue;
            }
        }

        private Color ColorFromHex(string hex)
        {
            try
            {
                if (string.IsNullOrEmpty(hex))
                    return Color.FromArgb(52, 152, 219); // Default blue

                hex = hex.Replace("#", "");
                if (hex.Length == 6)
                {
                    var r = Convert.ToInt32(hex.Substring(0, 2), 16);
                    var g = Convert.ToInt32(hex.Substring(2, 2), 16);
                    var b = Convert.ToInt32(hex.Substring(4, 2), 16);
                    return Color.FromArgb(r, g, b);
                }
                
                return Color.FromArgb(52, 152, 219); // Default blue
            }
            catch
            {
                return Color.FromArgb(52, 152, 219); // Default blue
            }
        }

        public string ColorToHex(Color color)
        {
            return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
        }
    }
}