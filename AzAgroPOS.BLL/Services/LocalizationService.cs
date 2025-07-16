using System;
using System.Collections.Generic;
using System.Globalization;

namespace AzAgroPOS.BLL.Services
{
    public class LocalizationService
    {
        private readonly SistemAyarlariService _sistemAyarlariService;
        private static Dictionary<string, Dictionary<string, string>> _translations;
        private static string _currentLanguage = "az";

        public LocalizationService(SistemAyarlariService sistemAyarlariService)
        {
            _sistemAyarlariService = sistemAyarlariService;
            InitializeTranslations();
        }

        private void InitializeTranslations()
        {
            _translations = new Dictionary<string, Dictionary<string, string>>
            {
                ["az"] = new Dictionary<string, string>
                {
                    // Main Menu
                    ["menu_dashboard"] = "🏠 Ana Səhifə",
                    ["menu_sales"] = "🛒 Satış",
                    ["menu_products"] = "📦 Məhsullar",
                    ["menu_customers"] = "👥 Müştərilər",
                    ["menu_suppliers"] = "🏭 Tədarükçülər", 
                    ["menu_inventory"] = "📊 Anbar",
                    ["menu_repairs"] = "🔧 Təmirlər",
                    ["menu_expenses"] = "💰 Gidərlər",
                    ["menu_debts"] = "💳 Borclar",
                    ["menu_reports"] = "📈 Hesabatlar",
                    ["menu_users"] = "👤 İstifadəçilər",
                    ["menu_settings"] = "⚙️ Parametrlər",

                    // Common Buttons
                    ["btn_add"] = "Əlavə Et",
                    ["btn_edit"] = "Redaktə Et",
                    ["btn_delete"] = "Sil",
                    ["btn_save"] = "Saxla",
                    ["btn_cancel"] = "Ləğv Et",
                    ["btn_close"] = "Bağla",
                    ["btn_search"] = "Axtar",
                    ["btn_refresh"] = "Yenilə",
                    ["btn_print"] = "Çap Et",
                    ["btn_export"] = "İxrac Et",
                    ["btn_import"] = "İdxal Et",

                    // Common Labels
                    ["label_name"] = "Ad",
                    ["label_description"] = "Açıqlama", 
                    ["label_date"] = "Tarix",
                    ["label_amount"] = "Məbləğ",
                    ["label_quantity"] = "Miqdar",
                    ["label_price"] = "Qiymət",
                    ["label_total"] = "Cəmi",
                    ["label_status"] = "Status",
                    ["label_phone"] = "Telefon",
                    ["label_email"] = "Email",
                    ["label_address"] = "Ünvan",

                    // Messages
                    ["msg_success"] = "Uğur",
                    ["msg_error"] = "Xəta",
                    ["msg_warning"] = "Xəbərdarlıq",
                    ["msg_info"] = "Məlumat",
                    ["msg_confirm"] = "Təsdiq",
                    ["msg_saved_successfully"] = "Məlumat uğurla saxlanıldı",
                    ["msg_deleted_successfully"] = "Məlumat uğurla silindi",
                    ["msg_updated_successfully"] = "Məlumat uğurla yeniləndi",
                    ["msg_operation_failed"] = "Əməliyyat uğursuz oldu",

                    // Settings
                    ["settings_regional"] = "Regional Ayarlar",
                    ["settings_appearance"] = "Görünüş",
                    ["settings_pos"] = "POS Ayarları",
                    ["settings_business"] = "Biznes Ayarları",
                    ["settings_security"] = "Təhlükəsizlik",
                    ["settings_notifications"] = "Bildirişlər"
                },

                ["en"] = new Dictionary<string, string>
                {
                    // Main Menu  
                    ["menu_dashboard"] = "🏠 Dashboard",
                    ["menu_sales"] = "🛒 Sales",
                    ["menu_products"] = "📦 Products",
                    ["menu_customers"] = "👥 Customers", 
                    ["menu_suppliers"] = "🏭 Suppliers",
                    ["menu_inventory"] = "📊 Inventory",
                    ["menu_repairs"] = "🔧 Repairs",
                    ["menu_expenses"] = "💰 Expenses",
                    ["menu_debts"] = "💳 Debts",
                    ["menu_reports"] = "📈 Reports",
                    ["menu_users"] = "👤 Users",
                    ["menu_settings"] = "⚙️ Settings",

                    // Common Buttons
                    ["btn_add"] = "Add",
                    ["btn_edit"] = "Edit", 
                    ["btn_delete"] = "Delete",
                    ["btn_save"] = "Save",
                    ["btn_cancel"] = "Cancel",
                    ["btn_close"] = "Close",
                    ["btn_search"] = "Search",
                    ["btn_refresh"] = "Refresh",
                    ["btn_print"] = "Print",
                    ["btn_export"] = "Export",
                    ["btn_import"] = "Import",

                    // Common Labels
                    ["label_name"] = "Name",
                    ["label_description"] = "Description",
                    ["label_date"] = "Date",
                    ["label_amount"] = "Amount",
                    ["label_quantity"] = "Quantity",
                    ["label_price"] = "Price",
                    ["label_total"] = "Total",
                    ["label_status"] = "Status",
                    ["label_phone"] = "Phone",
                    ["label_email"] = "Email",
                    ["label_address"] = "Address",

                    // Messages
                    ["msg_success"] = "Success",
                    ["msg_error"] = "Error", 
                    ["msg_warning"] = "Warning",
                    ["msg_info"] = "Information",
                    ["msg_confirm"] = "Confirm",
                    ["msg_saved_successfully"] = "Data saved successfully",
                    ["msg_deleted_successfully"] = "Data deleted successfully",
                    ["msg_updated_successfully"] = "Data updated successfully",
                    ["msg_operation_failed"] = "Operation failed",

                    // Settings
                    ["settings_regional"] = "Regional Settings",
                    ["settings_appearance"] = "Appearance",
                    ["settings_pos"] = "POS Settings",
                    ["settings_business"] = "Business Settings", 
                    ["settings_security"] = "Security",
                    ["settings_notifications"] = "Notifications"
                }
            };
        }

        public async System.Threading.Tasks.Task InitializeAsync()
        {
            try
            {
                _currentLanguage = await _sistemAyarlariService.GetCurrentLanguageAsync();
                SetCulture(_currentLanguage);
            }
            catch (Exception)
            {
                _currentLanguage = "az"; // Default to Azerbaijani
            }
        }

        public string GetString(string key)
        {
            try
            {
                if (_translations.ContainsKey(_currentLanguage) && 
                    _translations[_currentLanguage].ContainsKey(key))
                {
                    return _translations[_currentLanguage][key];
                }

                // Fallback to Azerbaijani if key not found in current language
                if (_translations.ContainsKey("az") && _translations["az"].ContainsKey(key))
                {
                    return _translations["az"][key];
                }

                // Return key itself if no translation found
                return key;
            }
            catch (Exception)
            {
                return key;
            }
        }

        public async System.Threading.Tasks.Task SetLanguageAsync(string languageCode)
        {
            try
            {
                _currentLanguage = languageCode;
                await _sistemAyarlariService.SetSettingAsync("sistem.dil", languageCode);
                SetCulture(languageCode);
            }
            catch (Exception)
            {
                // Handle error silently
            }
        }

        public string GetCurrentLanguage()
        {
            return _currentLanguage;
        }

        public List<LanguageOption> GetAvailableLanguages()
        {
            return new List<LanguageOption>
            {
                new LanguageOption { Code = "az", Name = "Azərbaycan", DisplayName = "Azərbaycan dili" },
                new LanguageOption { Code = "en", Name = "English", DisplayName = "English" }
            };
        }

        private void SetCulture(string languageCode)
        {
            try
            {
                CultureInfo culture;
                switch (languageCode.ToLower())
                {
                    case "en":
                        culture = new CultureInfo("en-US");
                        break;
                    case "az":
                    default:
                        culture = new CultureInfo("az-Latn-AZ");
                        break;
                }

                CultureInfo.DefaultThreadCurrentCulture = culture;
                CultureInfo.DefaultThreadCurrentUICulture = culture;
                System.Threading.Thread.CurrentThread.CurrentCulture = culture;
                System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
            }
            catch (Exception)
            {
                // Handle culture setting errors silently
            }
        }

        // Currency formatting
        public async System.Threading.Tasks.Task<string> FormatCurrencyAsync(decimal amount)
        {
            try
            {
                var currencySymbol = await _sistemAyarlariService.GetCurrentCurrencyAsync();
                var decimalPlaces = await _sistemAyarlariService.GetDecimalPlacesAsync();
                
                return $"{amount.ToString($"N{decimalPlaces}")} {currencySymbol}";
            }
            catch (Exception)
            {
                return amount.ToString("C");
            }
        }

        // Date formatting
        public async System.Threading.Tasks.Task<string> FormatDateAsync(DateTime date)
        {
            try
            {
                var dateFormat = await _sistemAyarlariService.GetDateFormatAsync();
                return date.ToString(dateFormat);
            }
            catch (Exception)
            {
                return date.ToString("dd.MM.yyyy");
            }
        }

        // Number formatting
        public async System.Threading.Tasks.Task<string> FormatNumberAsync(decimal number)
        {
            try
            {
                var decimalPlaces = await _sistemAyarlariService.GetDecimalPlacesAsync();
                return number.ToString($"N{decimalPlaces}");
            }
            catch (Exception)
            {
                return number.ToString("N2");
            }
        }

        // Sync versions for backward compatibility
        public string FormatCurrency(decimal amount)
        {
            return FormatCurrencyAsync(amount).Result;
        }

        public string FormatDate(DateTime date)
        {
            return FormatDateAsync(date).Result;
        }

        public string FormatNumber(decimal number)
        {
            return FormatNumberAsync(number).Result;
        }
    }

    public class LanguageOption
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
    }
}