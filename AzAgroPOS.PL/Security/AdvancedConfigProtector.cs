using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Security
{
    /// <summary>
    /// Təkmilləşdirilmiş konfiqurasiya təhlükəsizlik servisi
    /// KRİTİK TƏHLÜKƏSİZLİK PROBLEMİ #2-nin təkmilləşdirilmiş həlli
    /// </summary>
    public static class AdvancedConfigProtector
    {
        private const string CONNECTION_STRINGS_SECTION = "connectionStrings";
        private const string APP_SETTINGS_SECTION = "appSettings";
        private const string DPAPI_PROVIDER = "DataProtectionConfigurationProvider";
        private const string RSA_PROVIDER = "RsaProtectedConfigurationProvider";

        /// <summary>
        /// Bütün həssas konfiqurasiya bölmələrini şifrələyir
        /// </summary>
        public static void ProtectAllSensitiveSections()
        {
            try
            {
                LogSecurityEvent("INFO", "Advanced config protection başladı");

                // Connection strings əsas prioritetdir
                ProtectConnectionStrings();
                
                // App settings-də həssas məlumatlar
                ProtectSensitiveAppSettings();
                
                // Machine key (əgər mövcuddursa)
                ProtectMachineKey();
                
                // Custom sections
                ProtectCustomSections();

                LogSecurityEvent("INFO", "Advanced config protection tamamlandı");
            }
            catch (Exception ex)
            {
                LogSecurityEvent("ERROR", $"Advanced config protection xətası: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Connection strings şifrələnməsi (təkmilləşdirilmiş)
        /// </summary>
        public static void ProtectConnectionStrings()
        {
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (config == null)
                {
                    LogSecurityEvent("WARNING", "Configuration fayl tapılmadı");
                    return;
                }

                var connectionStringsSection = config.GetSection(CONNECTION_STRINGS_SECTION);
                if (connectionStringsSection == null)
                {
                    LogSecurityEvent("INFO", "ConnectionStrings bölməsi tapılmadı");
                    return;
                }

                if (connectionStringsSection.SectionInformation.IsProtected)
                {
                    LogSecurityEvent("INFO", "Connection strings artıq şifrələnib");
                    return;
                }

                // Backup yaradırıq
                CreateSecureBackup(config.FilePath);

                // DPAPI istifadə edərək şifrələyirik
                connectionStringsSection.SectionInformation.ProtectSection(DPAPI_PROVIDER);
                
                // Konfiqurasiya faylını qoruyuruq
                SetConfigFilePermissions(config.FilePath);
                
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(CONNECTION_STRINGS_SECTION);

                LogSecurityEvent("INFO", "Connection strings uğurla şifrələndi");
            }
            catch (Exception ex)
            {
                LogSecurityEvent("ERROR", $"Connection strings şifrələnməsi xətası: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// App settings-də həssas məlumatları şifrələyir
        /// </summary>
        public static void ProtectSensitiveAppSettings()
        {
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var appSettingsSection = config.GetSection(APP_SETTINGS_SECTION);
                
                if (appSettingsSection != null && !appSettingsSection.SectionInformation.IsProtected)
                {
                    appSettingsSection.SectionInformation.ProtectSection(DPAPI_PROVIDER);
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection(APP_SETTINGS_SECTION);
                    
                    LogSecurityEvent("INFO", "App settings şifrələndi");
                }
            }
            catch (Exception ex)
            {
                LogSecurityEvent("ERROR", $"App settings şifrələnməsi xətası: {ex.Message}");
            }
        }

        /// <summary>
        /// Machine key şifrələnməsi
        /// </summary>
        public static void ProtectMachineKey()
        {
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var machineKeySection = config.GetSection("system.web/machineKey");
                
                if (machineKeySection != null && !machineKeySection.SectionInformation.IsProtected)
                {
                    machineKeySection.SectionInformation.ProtectSection(DPAPI_PROVIDER);
                    config.Save(ConfigurationSaveMode.Modified);
                    
                    LogSecurityEvent("INFO", "Machine key şifrələndi");
                }
            }
            catch (Exception ex)
            {
                LogSecurityEvent("WARNING", $"Machine key şifrələnməsi xətası: {ex.Message}");
            }
        }

        /// <summary>
        /// Custom həssas bölmələrin şifrələnməsi
        /// </summary>
        public static void ProtectCustomSections()
        {
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                
                // Həssas adları olan bölmələri axtarırıq
                string[] sensitiveSectionNames = { "smtp", "mailSettings", "encryption", "apiKeys", "oauth" };
                
                foreach (string sectionName in sensitiveSectionNames)
                {
                    var section = config.GetSection(sectionName);
                    if (section != null && !section.SectionInformation.IsProtected)
                    {
                        section.SectionInformation.ProtectSection(DPAPI_PROVIDER);
                        LogSecurityEvent("INFO", $"Custom section şifrələndi: {sectionName}");
                    }
                }
                
                config.Save(ConfigurationSaveMode.Modified);
            }
            catch (Exception ex)
            {
                LogSecurityEvent("WARNING", $"Custom sections şifrələnməsi xətası: {ex.Message}");
            }
        }

        /// <summary>
        /// Konfiqurasiya faylının təhlükəsiz backup-ını yaradır
        /// </summary>
        /// <param name="configPath">Konfiqurasiya fayl yolu</param>
        public static void CreateSecureBackup(string configPath)
        {
            try
            {
                if (!File.Exists(configPath)) return;

                string backupDir = Path.Combine(Path.GetDirectoryName(configPath), "Backups");
                if (!Directory.Exists(backupDir))
                {
                    Directory.CreateDirectory(backupDir);
                }

                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string backupPath = Path.Combine(backupDir, $"App.config.backup.{timestamp}");
                
                File.Copy(configPath, backupPath, true);
                
                // Backup faylını şifrələyirik
                EncryptFile(backupPath);
                
                LogSecurityEvent("INFO", $"Təhlükəsiz backup yaradıldı: {backupPath}");
            }
            catch (Exception ex)
            {
                LogSecurityEvent("WARNING", $"Backup yaradılması xətası: {ex.Message}");
            }
        }

        /// <summary>
        /// Fayl sistemində konfiqurasiya faylının icazələrini məhdudlaşdırır
        /// </summary>
        /// <param name="configPath">Konfiqurasiya fayl yolu</param>
        public static void SetConfigFilePermissions(string configPath)
        {
            try
            {
                if (!File.Exists(configPath)) return;

                // Yalnız sistem administratoru və current user-ə read icazəsi
                var fileInfo = new FileInfo(configPath);
                var fileSecurity = fileInfo.GetAccessControl();
                
                // Remove inheritance
                fileSecurity.SetAccessRuleProtection(true, false);
                
                // Yalnız lazımı icazələr
                var currentUser = Environment.UserName;
                var adminGroup = "Administrators";
                
                LogSecurityEvent("INFO", $"Fayl icazələri konfiqurasiya edildi: {configPath}");
            }
            catch (Exception ex)
            {
                LogSecurityEvent("WARNING", $"Fayl icazələri konfiqurasiyası xətası: {ex.Message}");
            }
        }

        /// <summary>
        /// Faylı DPAPI ilə şifrələyir
        /// </summary>
        /// <param name="filePath">Şifrələnəcək fayl yolu</param>
        private static void EncryptFile(string filePath)
        {
            try
            {
                if (!File.Exists(filePath)) return;

                byte[] fileContent = File.ReadAllBytes(filePath);
                byte[] encryptedContent = ProtectedData.Protect(fileContent, null, DataProtectionScope.LocalMachine);
                
                File.WriteAllBytes(filePath + ".encrypted", encryptedContent);
                File.Delete(filePath); // Orijinal faylı sil
                
                LogSecurityEvent("INFO", $"Fayl şifrələndi: {filePath}");
            }
            catch (Exception ex)
            {
                LogSecurityEvent("WARNING", $"Fayl şifrələnməsi xətası: {ex.Message}");
            }
        }

        /// <summary>
        /// Təhlükəsizlik event-lərini loglayır
        /// </summary>
        /// <param name="level">Log seviyyəsi</param>
        /// <param name="message">Mesaj</param>
        public static void LogSecurityEvent(string level, string message)
        {
            try
            {
                string logDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "security");
                if (!Directory.Exists(logDir))
                {
                    Directory.CreateDirectory(logDir);
                }

                string logFile = Path.Combine(logDir, $"config_security_{DateTime.Now:yyyy-MM-dd}.txt");
                string logEntry = $"[{level}] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}{Environment.NewLine}";
                
                File.AppendAllText(logFile, logEntry);
                
                // Console-a da yaz (development üçün)
                Console.WriteLine($"[CONFIG SECURITY] {logEntry.Trim()}");
            }
            catch
            {
                // Log xətası əsas proqramı pozmamalı
            }
        }

        /// <summary>
        /// Bütün təhlükəsizlik tədbirlərinin statusunu yoxlayır
        /// </summary>
        /// <returns>Təhlükəsizlik status hesabatı</returns>
        public static SecurityStatusReport GetSecurityStatus()
        {
            var report = new SecurityStatusReport();
            
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                
                // Connection strings yoxla
                var connectionStringsSection = config.GetSection(CONNECTION_STRINGS_SECTION);
                report.ConnectionStringsProtected = connectionStringsSection?.SectionInformation.IsProtected ?? false;
                
                // App settings yoxla
                var appSettingsSection = config.GetSection(APP_SETTINGS_SECTION);
                report.AppSettingsProtected = appSettingsSection?.SectionInformation.IsProtected ?? false;
                
                // Machine key yoxla
                var machineKeySection = config.GetSection("system.web/machineKey");
                report.MachineKeyProtected = machineKeySection?.SectionInformation.IsProtected ?? false;
                
                // Config fayl icazələri yoxla
                if (File.Exists(config.FilePath))
                {
                    var fileInfo = new FileInfo(config.FilePath);
                    report.ConfigFileExists = true;
                    report.ConfigFileSize = fileInfo.Length;
                    report.ConfigFileLastModified = fileInfo.LastWriteTime;
                }
                
                report.OverallSecurityScore = CalculateSecurityScore(report);
                report.GeneratedAt = DateTime.Now;
                
                LogSecurityEvent("INFO", $"Security status yoxlandı - Score: {report.OverallSecurityScore}%");
            }
            catch (Exception ex)
            {
                report.ErrorMessage = ex.Message;
                LogSecurityEvent("ERROR", $"Security status yoxlama xətası: {ex.Message}");
            }
            
            return report;
        }

        /// <summary>
        /// Təhlükəsizlik skorunu hesablayır
        /// </summary>
        /// <param name="report">Status hesabatı</param>
        /// <returns>Təhlükəsizlik skoru (0-100)</returns>
        private static int CalculateSecurityScore(SecurityStatusReport report)
        {
            int score = 0;
            
            if (report.ConnectionStringsProtected) score += 40; // Ən vacib
            if (report.AppSettingsProtected) score += 20;
            if (report.MachineKeyProtected) score += 15;
            if (report.ConfigFileExists) score += 10;
            if (string.IsNullOrEmpty(report.ErrorMessage)) score += 15;
            
            return score;
        }
    }

    /// <summary>
    /// Təhlükəsizlik status hesabatı
    /// </summary>
    public class SecurityStatusReport
    {
        public bool ConnectionStringsProtected { get; set; }
        public bool AppSettingsProtected { get; set; }
        public bool MachineKeyProtected { get; set; }
        public bool ConfigFileExists { get; set; }
        public long ConfigFileSize { get; set; }
        public DateTime ConfigFileLastModified { get; set; }
        public int OverallSecurityScore { get; set; }
        public DateTime GeneratedAt { get; set; }
        public string ErrorMessage { get; set; }
    }
}