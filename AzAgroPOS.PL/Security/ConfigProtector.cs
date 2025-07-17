using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Security
{
    /// <summary>
    /// App.config faylında connection string-ləri DPAPI istifadə edərək şifrələyir
    /// Windows-un daxili təhlükəsizlik mexanizmindən istifadə edir
    /// Kritik Məsələ №2: Bağlantı Sətrinin Qorunması
    /// </summary>
    public static class ConfigProtector
    {
        private const string CONNECTION_STRINGS_SECTION = "connectionStrings";
        private const string MACHINE_KEY_SECTION = "system.web/machineKey";
        private const string PROVIDER_NAME = "DataProtectionConfigurationProvider";

        /// <summary>
        /// App.config-də connection string şifrələnməsini aktivləşdirir
        /// Proqram ilk dəfə işə salındıqda avtomatik olaraq şifrələyir
        /// </summary>
        public static void ProtectConnectionStrings()
        {
            try
            {
                // Configuration faylını yüklə
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                
                if (config == null)
                {
                    LogWarning("Configuration fayl tapılmadı");
                    return;
                }

                // ConnectionStrings bölməsini əldə et
                ConfigurationSection connectionStringsSection = config.GetSection(CONNECTION_STRINGS_SECTION);
                
                if (connectionStringsSection == null)
                {
                    LogInfo("ConnectionStrings bölməsi tapılmadı");
                    return;
                }

                // Əgər artıq şifrələnibsə, heç nə etmə
                if (connectionStringsSection.SectionInformation.IsProtected)
                {
                    LogInfo("Connection strings artıq şifrələnib");
                    return;
                }

                // DPAPI istifadə edərək şifrələ
                connectionStringsSection.SectionInformation.ProtectSection(PROVIDER_NAME);
                
                // Dəyişiklikləri saxla
                config.Save(ConfigurationSaveMode.Modified);
                
                // Configuration cache-ini yenilə
                ConfigurationManager.RefreshSection(CONNECTION_STRINGS_SECTION);

                LogInfo("Connection strings uğurla şifrələndi və qorundu");
            }
            catch (Exception ex)
            {
                LogError($"Connection string şifrələnməsi zamanı xəta: {ex.Message}");
                
                // Kritik xəta deyil, proqram davam edə bilər
                // Sadəcə məlumat verib keçirik
                MessageBox.Show(
                    "Bağlantı məlumatlarının şifrələnməsi zamanı xəta baş verdi.\n" +
                    "Proqram normal işləyəcək, amma təhlükəsizlik səviyyəsi azaldılıb.\n\n" +
                    $"Texniki detal: {ex.Message}",
                    "Şifrələmə Xəbərdarlığı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        /// <summary>
        /// Şifrələnmiş connection string-ləri açır (testing məqsədilə)
        /// İstehsal mühitində adətən istifadə olunmur
        /// </summary>
        public static void UnprotectConnectionStrings()
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                ConfigurationSection connectionStringsSection = config.GetSection(CONNECTION_STRINGS_SECTION);

                if (connectionStringsSection != null && connectionStringsSection.SectionInformation.IsProtected)
                {
                    connectionStringsSection.SectionInformation.UnprotectSection();
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection(CONNECTION_STRINGS_SECTION);
                    
                    LogInfo("Connection strings şifrələmə açıldı");
                }
            }
            catch (Exception ex)
            {
                LogError($"Connection string şifrələmə açılması zamanı xəta: {ex.Message}");
            }
        }

        /// <summary>
        /// Connection string-lərin şifrələnmə vəziyyətini yoxlayır
        /// </summary>
        /// <returns>True əgər şifrələnibsə</returns>
        public static bool IsConnectionStringProtected()
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                ConfigurationSection connectionStringsSection = config.GetSection(CONNECTION_STRINGS_SECTION);
                
                return connectionStringsSection?.SectionInformation.IsProtected ?? false;
            }
            catch (Exception ex)
            {
                LogError($"Şifrələmə vəziyyəti yoxlanılarkən xəta: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Configuration faylının backup-ını yaradır (şifrələmədən əvvəl)
        /// </summary>
        public static void CreateConfigBackup()
        {
            try
            {
                string configPath = System.Reflection.Assembly.GetExecutingAssembly().Location + ".config";
                string backupPath = configPath + ".backup." + DateTime.Now.ToString("yyyyMMdd_HHmmss");
                
                File.Copy(configPath, backupPath, true);
                LogInfo($"Config backup yaradıldı: {backupPath}");
            }
            catch (Exception ex)
            {
                LogError($"Config backup yaradılarkən xəta: {ex.Message}");
            }
        }

        /// <summary>
        /// Bütün protection prosesini həyata keçirir
        /// Program.cs-dən çağrılır
        /// </summary>
        public static void Protect()
        {
            LogInfo("=== ConfigProtector başladı ===");
            
            // Əvvəlcə backup yarat
            CreateConfigBackup();
            
            // Sonra şifrələ
            ProtectConnectionStrings();
            
            // Status-u yoxla və log et
            bool isProtected = IsConnectionStringProtected();
            LogInfo($"Son durum: Connection strings qorunur = {isProtected}");
            
            LogInfo("=== ConfigProtector tamamlandı ===");
        }

        #region Logging Helper Methods

        private static void LogInfo(string message)
        {
            try
            {
                // Console və ya file log-a yaz
                Console.WriteLine($"[ConfigProtector INFO] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
                
                // Əgər logger service varsa, oraya da yaz
                WriteToFile("INFO", message);
            }
            catch
            {
                // Log xətası proqramı dayandırmamalıdır
            }
        }

        private static void LogWarning(string message)
        {
            try
            {
                Console.WriteLine($"[ConfigProtector WARNING] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
                WriteToFile("WARNING", message);
            }
            catch
            {
                // Log xətası proqramı dayandırmamalıdır
            }
        }

        private static void LogError(string message)
        {
            try
            {
                Console.WriteLine($"[ConfigProtector ERROR] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
                WriteToFile("ERROR", message);
            }
            catch
            {
                // Log xətası proqramı dayandırmamalıdır
            }
        }

        private static void WriteToFile(string level, string message)
        {
            try
            {
                string logDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
                if (!Directory.Exists(logDir))
                {
                    Directory.CreateDirectory(logDir);
                }

                string logFile = Path.Combine(logDir, $"config_protection_{DateTime.Now:yyyy-MM-dd}.txt");
                string logEntry = $"[{level}] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}{Environment.NewLine}";
                
                File.AppendAllText(logFile, logEntry);
            }
            catch
            {
                // Heç nə etmə - log xətası əsas proqramı pozmamalı
            }
        }

        #endregion
    }
}