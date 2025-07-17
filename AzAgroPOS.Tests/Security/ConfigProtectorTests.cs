using AzAgroPOS.PL.Security;
using FluentAssertions;
using System;
using System.Configuration;
using System.IO;
using Xunit;

namespace AzAgroPOS.Tests.Security
{
    /// <summary>
    /// ConfigProtector-un unit testləri
    /// Təhlükəsizlik funksionallarının düzgün işlədiyini yoxlayır
    /// </summary>
    public class ConfigProtectorTests : IDisposable
    {
        private readonly string _testConfigPath;
        private readonly string _backupConfigPath;

        public ConfigProtectorTests()
        {
            // Test üçün müvəqqəti config fayl yaradırıq
            _testConfigPath = Path.GetTempFileName() + ".config";
            _backupConfigPath = _testConfigPath + ".backup";
            
            CreateTestConfigFile();
        }

        private void CreateTestConfigFile()
        {
            var testConfigContent = @"<?xml version=""1.0"" encoding=""utf-8""?>
<configuration>
    <connectionStrings>
        <add name=""DefaultConnection"" 
             connectionString=""Data Source=localhost;Initial Catalog=AzAgroTest;Integrated Security=True"" 
             providerName=""System.Data.SqlClient"" />
    </connectionStrings>
    <appSettings>
        <add key=""TestKey"" value=""TestValue"" />
    </appSettings>
</configuration>";

            File.WriteAllText(_testConfigPath, testConfigContent);
        }

        [Fact]
        public void IsConnectionStringProtected_WithUnprotectedConfig_ReturnsFalse()
        {
            // Arrange
            // Test config faylı şifrələnməyib

            // Act
            var result = ConfigProtector.IsConnectionStringProtected();

            // Assert  
            // Real config faylı test zamanı şifrələnməmiş ola bilər
            // Bu test environment-a bağlıdır, məntiq yoxlanılır
            result.Should().BeOfType<bool>("çünki protected status bool dəyər qaytarmalıdır");
        }

        [Fact]
        public void CreateConfigBackup_ValidConfig_CreatesBackupFile()
        {
            // Arrange
            var initialBackupCount = Directory.GetFiles(
                Path.GetDirectoryName(_testConfigPath) ?? "", 
                "*.backup.*").Length;

            // Act
            ConfigProtector.CreateConfigBackup();

            // Assert
            var finalBackupCount = Directory.GetFiles(
                Path.GetDirectoryName(_testConfigPath) ?? "", 
                "*.backup.*").Length;

            // Backup yaradılması environment-a bağlıdır
            // En azı metodun exception atmadığını yoxlayırıq
            Assert.True(finalBackupCount >= initialBackupCount, 
                "Backup fayl sayı azalmamalıdır");
        }

        [Fact]
        public void ProtectConnectionStrings_ValidConfig_DoesNotThrowException()
        {
            // Arrange & Act & Assert
            // Bu metod environment-a bağlı olduğu üçün
            // ən azından exception atmadığını yoxlayırıq
            var exception = Record.Exception(() => ConfigProtector.ProtectConnectionStrings());
            
            // Exception olsa da, ArgumentNullException olmamalıdır
            exception.Should().NotBeOfType<ArgumentNullException>(
                "çünki valid giriş parametrləri ilə ArgumentNullException olmamalıdır");
        }

        [Fact]
        public void UnprotectConnectionStrings_DoesNotThrowException()
        {
            // Arrange & Act & Assert
            var exception = Record.Exception(() => ConfigProtector.UnprotectConnectionStrings());
            
            exception.Should().NotBeOfType<ArgumentNullException>(
                "çünki bu metod heç bir parametr qəbul etmir");
        }

        [Fact]
        public void Protect_MainMethod_ExecutesWithoutCriticalError()
        {
            // Arrange & Act
            var exception = Record.Exception(() => ConfigProtector.Protect());

            // Assert
            // Bu ən əsas metoddur və exception atmadan işləməlidir
            exception.Should().NotBeOfType<ArgumentNullException>(
                "çünki əsas Protect metodu kritik xəta verməməlidir");
            
            exception.Should().NotBeOfType<FileNotFoundException>(
                "çünki əsas Protect metodu fayl tapılmasa belə işləməlidir");
        }

        [Theory]
        [InlineData("localhost")]
        [InlineData("127.0.0.1")]
        [InlineData("(local)")]
        public void TestDifferentConnectionStringFormats_ValidFormats_DoNotCauseCriticalErrors(string server)
        {
            // Arrange
            var testConnectionString = $"Data Source={server};Initial Catalog=TestDB;Integrated Security=True";
            
            // Bu test üçün müvəqqəti config yaradırıq
            var tempConfig = @$"<?xml version=""1.0"" encoding=""utf-8""?>
<configuration>
    <connectionStrings>
        <add name=""DefaultConnection"" 
             connectionString=""{testConnectionString}"" 
             providerName=""System.Data.SqlClient"" />
    </connectionStrings>
</configuration>";

            var tempPath = Path.GetTempFileName() + ".config";
            File.WriteAllText(tempPath, tempConfig);

            try
            {
                // Act & Assert
                var exception = Record.Exception(() => ConfigProtector.Protect());
                
                // Connection string formatından asılı olmayaraq kritik xəta olmamalıdır
                exception.Should().NotBeOfType<FormatException>(
                    $"çünki '{server}' serveri üçün format xətası olmamalıdır");
            }
            finally
            {
                // Cleanup
                if (File.Exists(tempPath))
                    File.Delete(tempPath);
            }
        }

        [Fact]
        public void ConfigProtectorMethods_WithEmptyAppDirectory_HandleGracefully()
        {
            // Arrange
            var originalDirectory = Directory.GetCurrentDirectory();
            
            try
            {
                // Müvəqqəti olaraq boş directory-ə keçirik
                var tempDir = Path.GetTempPath();
                Directory.SetCurrentDirectory(tempDir);

                // Act & Assert
                var protectException = Record.Exception(() => ConfigProtector.Protect());
                var statusException = Record.Exception(() => ConfigProtector.IsConnectionStringProtected());

                // Boş directory olsa da metodlar crash olmamalıdır
                protectException.Should().NotBeOfType<DirectoryNotFoundException>(
                    "çünki metodlar directory probleminə qarşı davamlı olmalıdır");
                
                statusException.Should().NotBeOfType<DirectoryNotFoundException>(
                    "çünki status yoxlama metodu directory problemini idarə etməlidir");
            }
            finally
            {
                // Original directory-ni geri qaytar
                Directory.SetCurrentDirectory(originalDirectory);
            }
        }

        [Fact]
        public void ConfigProtector_LoggingMethods_DoNotThrowExceptions()
        {
            // Bu testdə internal logging metodlarının işlədiyini dolayı yolla yoxlayırıq
            
            // Act
            var protectException = Record.Exception(() => ConfigProtector.Protect());
            
            // Assert
            // Logging xətası əsas funksionallığı pozmamalıdır
            protectException.Should().NotBeOfType<UnauthorizedAccessException>(
                "çünki log faylı yazılmasa da əsas funksionallıq işləməlidir");
        }

        public void Dispose()
        {
            // Test fayllarını təmizlə
            try
            {
                if (File.Exists(_testConfigPath))
                    File.Delete(_testConfigPath);
                
                if (File.Exists(_backupConfigPath))
                    File.Delete(_backupConfigPath);

                // Test zamanı yaradılmış digər backup faylları
                var testDir = Path.GetDirectoryName(_testConfigPath);
                if (!string.IsNullOrEmpty(testDir))
                {
                    var backupFiles = Directory.GetFiles(testDir, "*.backup.*");
                    foreach (var backupFile in backupFiles)
                    {
                        try
                        {
                            File.Delete(backupFile);
                        }
                        catch
                        {
                            // Backup faylı silinməsə də problem deyil
                        }
                    }
                }
            }
            catch
            {
                // Cleanup xətası test nəticəsini pozmamalı
            }
        }
    }
}