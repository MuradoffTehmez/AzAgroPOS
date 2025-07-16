using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Domain;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AzAgroPOS.BLL.Services
{
    public class BackupService : IDisposable
    {
        private readonly BackupKaydiRepository _backupRepository;
        private readonly BackupTenzimlemeRepository _configRepository;
        private readonly string _connectionString;

        public BackupService()
        {
            _backupRepository = new BackupKaydiRepository();
            _configRepository = new BackupTenzimlemeRepository();
            _connectionString = "Data Source=azagropos.db";
        }

        #region Backup Operations

        public async Task<BackupKaydi> CreateManualBackupAsync(int userId, string backupName = null, string description = null)
        {
            var backupRecord = new BackupKaydi
            {
                BackupAdi = backupName ?? $"Manuel Backup {DateTime.Now:yyyy-MM-dd HH-mm-ss}",
                BackupTipi = BackupKaydi.BackupTipleri.Manual,
                IstifadeciId = userId,
                Aciqlama = description,
                BackupTarixi = DateTime.Now,
                Statusu = BackupKaydi.BackupStatuslari.Davam
            };

            try
            {
                backupRecord = await _backupRepository.AddAsync(backupRecord);
                
                var stopwatch = Stopwatch.StartNew();
                var backupPath = await PerformBackupAsync(backupRecord);
                stopwatch.Stop();

                backupRecord.BackupYolu = backupPath;
                backupRecord.BackupMuddeti = stopwatch.Elapsed;
                backupRecord.FaylOlcusu = GetFileSizeInMB(backupPath);
                backupRecord.MD5Hash = CalculateFileMD5Hash(backupPath);
                backupRecord.Statusu = BackupKaydi.BackupStatuslari.Ugurlu;

                return await _backupRepository.UpdateAsync(backupRecord);
            }
            catch (Exception ex)
            {
                backupRecord.Statusu = BackupKaydi.BackupStatuslari.Ugursuz;
                backupRecord.XetaMesaji = ex.Message;
                await _backupRepository.UpdateAsync(backupRecord);
                throw;
            }
        }

        public async Task<BackupKaydi> CreateAutomaticBackupAsync(BackupTenzimleme configuration)
        {
            var backupRecord = new BackupKaydi
            {
                BackupAdi = $"{configuration.TenzimlemeAdi} - {DateTime.Now:yyyy-MM-dd HH-mm-ss}",
                BackupTipi = BackupKaydi.BackupTipleri.Avtomatik,
                IstifadeciId = 1, // System user
                Aciqlama = $"Avtomatik backup: {configuration.TenzimlemeAdi}",
                BackupTarixi = DateTime.Now,
                Statusu = BackupKaydi.BackupStatuslari.Davam,
                Sifrelendi = configuration.Sifreleme,
                Siqisdirildi = configuration.Siqisdir
            };

            try
            {
                backupRecord = await _backupRepository.AddAsync(backupRecord);
                
                var stopwatch = Stopwatch.StartNew();
                var backupPath = await PerformBackupAsync(backupRecord, configuration);
                stopwatch.Stop();

                backupRecord.BackupYolu = backupPath;
                backupRecord.BackupMuddeti = stopwatch.Elapsed;
                backupRecord.FaylOlcusu = GetFileSizeInMB(backupPath);
                backupRecord.MD5Hash = CalculateFileMD5Hash(backupPath);
                backupRecord.Statusu = BackupKaydi.BackupStatuslari.Ugurlu;

                await _configRepository.UpdateLastBackupTimeAsync(configuration.Id, DateTime.Now);
                return await _backupRepository.UpdateAsync(backupRecord);
            }
            catch (Exception ex)
            {
                backupRecord.Statusu = BackupKaydi.BackupStatuslari.Ugursuz;
                backupRecord.XetaMesaji = ex.Message;
                await _backupRepository.UpdateAsync(backupRecord);
                throw;
            }
        }

        private async Task<string> PerformBackupAsync(BackupKaydi backupRecord, BackupTenzimleme configuration = null)
        {
            var backupFileName = $"{backupRecord.BackupAdi}_{DateTime.Now:yyyyMMdd_HHmmss}.db";
            var backupDirectory = configuration?.BackupYolu ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "AzAgroPOS", "Backups");
            
            if (!Directory.Exists(backupDirectory))
                Directory.CreateDirectory(backupDirectory);

            var backupPath = Path.Combine(backupDirectory, backupFileName);

            // SQLite database backup
            using (var source = new SqliteConnection(_connectionString))
            using (var destination = new SqliteConnection($"Data Source={backupPath}"))
            {
                await source.OpenAsync();
                await destination.OpenAsync();
                source.BackupDatabase(destination);
            }

            // Apply compression if configured
            if (configuration?.Siqisdir == true || (configuration == null && backupRecord.Siqisdirildi))
            {
                backupPath = await CompressBackupFileAsync(backupPath, configuration?.SiqisdirmaSeviyesi ?? 6);
            }

            // Apply encryption if configured
            if (configuration?.Sifreleme == true && !string.IsNullOrEmpty(configuration.SifrelemeSifre))
            {
                backupPath = await EncryptBackupFileAsync(backupPath, configuration.SifrelemeSifre);
            }

            return backupPath;
        }

        private async Task<string> CompressBackupFileAsync(string filePath, decimal compressionLevel)
        {
            var compressedPath = Path.ChangeExtension(filePath, ".zip");
            
            using (var archive = ZipFile.Open(compressedPath, ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(filePath, Path.GetFileName(filePath), (CompressionLevel)(int)compressionLevel);
            }

            File.Delete(filePath);
            return compressedPath;
        }

        private async Task<string> EncryptBackupFileAsync(string filePath, string password)
        {
            var encryptedPath = Path.ChangeExtension(filePath, ".enc");
            var key = DeriveKeyFromPassword(password);
            
            using (var aes = Aes.Create())
            {
                aes.Key = key;
                aes.GenerateIV();

                using (var fileStream = new FileStream(encryptedPath, FileMode.Create))
                {
                    await fileStream.WriteAsync(aes.IV, 0, aes.IV.Length);
                    
                    using (var cryptoStream = new CryptoStream(fileStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    using (var inputStream = new FileStream(filePath, FileMode.Open))
                    {
                        await inputStream.CopyToAsync(cryptoStream);
                    }
                }
            }

            File.Delete(filePath);
            return encryptedPath;
        }

        #endregion

        #region Restore Operations

        public async Task<bool> RestoreBackupAsync(int backupId, string restorePath = null)
        {
            var backup = await _backupRepository.GetByIdAsync(backupId);
            if (backup == null || !backup.FaylMovcuddur)
                return false;

            try
            {
                var tempFilePath = backup.BackupYolu;

                // Decrypt if necessary
                if (backup.Sifrelendi)
                {
                    // Note: In a real implementation, you'd need to prompt for the password
                    throw new InvalidOperationException("Şifrəli backup-ları bərpa etmək üçün şifrə tələb olunur");
                }

                // Decompress if necessary
                if (backup.Siqisdirildi)
                {
                    tempFilePath = await DecompressBackupFileAsync(backup.BackupYolu);
                }

                var targetPath = restorePath ?? _connectionString.Replace("Data Source=", "");
                
                // Create backup of current database
                var currentBackupPath = $"{targetPath}.backup_{DateTime.Now:yyyyMMdd_HHmmss}";
                if (File.Exists(targetPath))
                {
                    File.Copy(targetPath, currentBackupPath);
                }

                // Restore the backup
                File.Copy(tempFilePath, targetPath, true);

                // Clean up temporary file if decompressed
                if (tempFilePath != backup.BackupYolu && File.Exists(tempFilePath))
                {
                    File.Delete(tempFilePath);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task<string> DecompressBackupFileAsync(string compressedPath)
        {
            var tempPath = Path.GetTempFileName();
            
            using (var archive = ZipFile.OpenRead(compressedPath))
            {
                var entry = archive.Entries.FirstOrDefault();
                if (entry != null)
                {
                    entry.ExtractToFile(tempPath, true);
                }
            }

            return tempPath;
        }

        #endregion

        #region Automatic Backup Management

        public async Task ProcessScheduledBackupsAsync()
        {
            var dueBackups = await _configRepository.GetDueBackupsAsync();
            
            foreach (var config in dueBackups)
            {
                try
                {
                    await CreateAutomaticBackupAsync(config);
                }
                catch (Exception ex)
                {
                    // Log error but continue with other backups
                    Console.WriteLine($"Scheduled backup failed for {config.TenzimlemeAdi}: {ex.Message}");
                }
            }
        }

        public async Task CleanupOldBackupsAsync()
        {
            var configurations = await _configRepository.GetConfigurationsNeedingCleanupAsync();
            
            foreach (var config in configurations)
            {
                var oldBackups = await _backupRepository.GetOldBackupsAsync(config.SaxlanmaGunSayi);
                
                foreach (var backup in oldBackups)
                {
                    try
                    {
                        if (File.Exists(backup.BackupYolu))
                        {
                            File.Delete(backup.BackupYolu);
                        }
                        await _backupRepository.DeleteAsync(backup.Id);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to delete old backup {backup.BackupAdi}: {ex.Message}");
                    }
                }
            }
        }

        #endregion

        #region Configuration Management

        public async Task<IEnumerable<BackupTenzimleme>> GetAllConfigurationsAsync()
        {
            return await _configRepository.GetAllAsync();
        }

        public async Task<BackupTenzimleme> GetConfigurationByIdAsync(int id)
        {
            return await _configRepository.GetByIdAsync(id);
        }

        public async Task<BackupTenzimleme> CreateConfigurationAsync(BackupTenzimleme configuration)
        {
            return await _configRepository.AddAsync(configuration);
        }

        public async Task<BackupTenzimleme> UpdateConfigurationAsync(BackupTenzimleme configuration)
        {
            return await _configRepository.UpdateAsync(configuration);
        }

        public async Task DeleteConfigurationAsync(int id)
        {
            await _configRepository.DeleteAsync(id);
        }

        #endregion

        #region Backup History

        public async Task<IEnumerable<BackupKaydi>> GetAllBackupsAsync()
        {
            return await _backupRepository.GetAllAsync();
        }

        public async Task<BackupKaydi> GetBackupByIdAsync(int id)
        {
            return await _backupRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<BackupKaydi>> GetBackupsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _backupRepository.GetByDateRangeAsync(startDate, endDate);
        }

        public async Task<BackupKaydi> GetLatestBackupAsync()
        {
            return await _backupRepository.GetLatestBackupAsync();
        }

        #endregion

        #region Utility Methods

        private decimal GetFileSizeInMB(string filePath)
        {
            if (!File.Exists(filePath))
                return 0;

            var fileInfo = new FileInfo(filePath);
            return (decimal)fileInfo.Length / (1024 * 1024);
        }

        private string CalculateFileMD5Hash(string filePath)
        {
            if (!File.Exists(filePath))
                return string.Empty;

            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        private byte[] DeriveKeyFromPassword(string password)
        {
            using (var derive = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes("AzAgroPosSalt"), 10000))
            {
                return derive.GetBytes(32); // 256-bit key
            }
        }

        public async Task<Dictionary<string, object>> GetBackupStatisticsAsync()
        {
            var totalBackups = (await _backupRepository.GetAllAsync()).Count();
            var successfulBackups = (await _backupRepository.GetSuccessfulBackupsAsync()).Count();
            var failedBackups = (await _backupRepository.GetFailedBackupsAsync()).Count();
            var totalSize = await _backupRepository.GetTotalBackupSizeAsync();
            var latestBackup = await _backupRepository.GetLatestBackupAsync();

            var typeStats = await _backupRepository.GetBackupStatisticsByTypeAsync();
            var statusStats = await _backupRepository.GetBackupStatisticsByStatusAsync();

            return new Dictionary<string, object>
            {
                { "TotalBackups", totalBackups },
                { "SuccessfulBackups", successfulBackups },
                { "FailedBackups", failedBackups },
                { "TotalSizeMB", totalSize },
                { "LatestBackup", latestBackup },
                { "TypeStatistics", typeStats },
                { "StatusStatistics", statusStats }
            };
        }

        public async Task<bool> VerifyBackupIntegrityAsync(int backupId)
        {
            return await _backupRepository.VerifyBackupIntegrityAsync(backupId);
        }

        #endregion

        public void Dispose()
        {
            _backupRepository?.Dispose();
            _configRepository?.Dispose();
        }
    }
}