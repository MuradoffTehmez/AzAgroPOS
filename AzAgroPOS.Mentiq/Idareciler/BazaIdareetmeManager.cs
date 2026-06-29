// Fayl: AzAgroPOS.Mentiq/Idareciler/BazaIdareetmeManager.cs

using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Mentiq.Yardimcilar;
using Microsoft.Data.SqlClient;

namespace AzAgroPOS.Mentiq.Idareciler;
/// <summary>
/// Verilənlər bazası backup və restore əməliyyatlarını idarə edir.
/// Diqqət: Bu sinif yalnız Admin icazəsi olan istifadəçilər tərəfindən istifadə edilməlidir.
/// Qeyd: Backup və restore əməliyyatları uzun çəkə bilər, ona görə asinxron həyata keçirilir.
/// </summary>
public class BazaIdareetmeManager
{
    private readonly string _connectionString;

    /// <summary>
    /// BazaIdareetmeManager konstruktoru.
    /// </summary>
    /// <param name="connectionString">Verilənlər bazası bağlantı sətri</param>
    public BazaIdareetmeManager(string connectionString)
    {
        _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    }

    /// <summary>
    /// SQL Server identifikatorunu (database, table, column adı) təhlükəsiz şəkildə quote edir.
    /// SQL Injection hücumlarından qorunmaq üçün istifadə olunur.
    /// </summary>
    /// <param name="identifier">Identifikator adı</param>
    /// <returns>Quote edilmiş identifikator (məsələn: [DatabaseName])</returns>
    private static string QuoteName(string identifier)
    {
        if (string.IsNullOrWhiteSpace(identifier))
        {
            throw new ArgumentException("Identifikator boş ola bilməz", nameof(identifier));
        }

        // SQL Server QUOTENAME funksiyasının davranışını təqlid edirik:
        // ] simvolunu ]] ilə əvəz edirik və [..] arasında qaytarırıq
        return "[" + identifier.Replace("]", "]]") + "]";
    }

    /// <summary>
    /// Verilənlər bazasının ehtiyat nüsxəsini (backup) yaradır.
    /// </summary>
    /// <param name="backupPath">Backup faylının saxlanacağı tam yol (məsələn: C:\Backups\AzAgroPOS_2025-01-30.bak)</param>
    /// <returns>Əməliyyatın nəticəsi</returns>
    public async Task<EmeliyyatNeticesi> BackupYaratAsync(string backupPath)
    {
        try
        {
            Logger.MelumatYaz($"Backup əməliyyatı başladı: {backupPath}");

            // Əgər fayl artıq mövcuddursa, xəbərdarlıq ver
            if (File.Exists(backupPath))
            {
                return EmeliyyatNeticesi.Ugursuz($"Bu adda backup faylı artıq mövcuddur: {backupPath}");
            }

            // Backup qovluğunun mövcud olduğunu yoxlayırıq
            string? backupDirectory = Path.GetDirectoryName(backupPath);
            if (!Directory.Exists(backupDirectory))
            {
                Directory.CreateDirectory(backupDirectory!);
            }

            // Connection string-dən verilənlər bazası adını çıxarırıq
            SqlConnectionStringBuilder builder = new(_connectionString);
            string databaseName = builder.InitialCatalog;

            if (string.IsNullOrEmpty(databaseName))
            {
                return EmeliyyatNeticesi.Ugursuz("Verilənlər bazası adı connection string-də tapılmadı.");
            }

            // Backup SQL komandası
            // Use QUOTENAME to safely escape database name
            string backupSql = $@"
                BACKUP DATABASE {QuoteName(databaseName)}
                TO DISK = @BackupPath
                WITH FORMAT,
                     MEDIANAME = 'AzAgroPOSBackup',
                     NAME = 'Full Backup of ' + @DatabaseName;";

            await using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            await using SqlCommand command = new(backupSql, connection);
            command.CommandTimeout = 600; // 10 dəqiqə timeout (böyük verilənlər bazaları üçün)
            command.Parameters.AddWithValue("@BackupPath", backupPath);
            command.Parameters.AddWithValue("@DatabaseName", databaseName);

            await command.ExecuteNonQueryAsync();

            Logger.MelumatYaz($"Backup uğurla tamamlandı: {backupPath}");
            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Backup yaradılması zamanı xəta baş verdi");
            return EmeliyyatNeticesi.Ugursuz($"Backup yaradılması uğursuz oldu: {ex.Message}");
        }
    }

    /// <summary>
    /// Ehtiyat nüsxəsindən (backup) verilənlər bazasını bərpa edir.
    /// DIQQƏT: Bu əməliyyat mövcud verilənləri SİLƏCƏK!
    /// </summary>
    /// <param name="backupPath">Bərpa ediləcək backup faylının tam yolu</param>
    /// <returns>Əməliyyatın nəticəsi</returns>
    public async Task<EmeliyyatNeticesi> RestoreEtAsync(string backupPath)
    {
        try
        {
            Logger.MelumatYaz($"Restore əməliyyatı başladı: {backupPath}");

            // Backup faylının mövcudluğunu yoxlayırıq
            if (!File.Exists(backupPath))
            {
                return EmeliyyatNeticesi.Ugursuz($"Backup faylı tapılmadı: {backupPath}");
            }

            // Connection string-dən verilənlər bazası adını çıxarırıq
            SqlConnectionStringBuilder builder = new(_connectionString);
            string databaseName = builder.InitialCatalog;

            if (string.IsNullOrEmpty(databaseName))
            {
                return EmeliyyatNeticesi.Ugursuz("Verilənlər bazası adı connection string-də tapılmadı.");
            }

            // Master bazasına qoşuluruq (çünki target bazasını restore edərkən ona qoşula bilmərik)
            builder.InitialCatalog = "master";
            string masterConnectionString = builder.ToString();

            await using SqlConnection connection = new(masterConnectionString);
            await connection.OpenAsync();

            // 1. Bütün aktiv bağlantıları bağlayırıq
            string killConnectionsSql = $@"
                ALTER DATABASE {QuoteName(databaseName)} SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";

            await using (SqlCommand killCommand = new(killConnectionsSql, connection))
            {
                killCommand.CommandTimeout = 60;
                await killCommand.ExecuteNonQueryAsync();
            }

            // 2. Restore əməliyyatını icra edirik
            string restoreSql = $@"
                RESTORE DATABASE {QuoteName(databaseName)}
                FROM DISK = @BackupPath
                WITH REPLACE;";

            await using (SqlCommand restoreCommand = new(restoreSql, connection))
            {
                restoreCommand.CommandTimeout = 600; // 10 dəqiqə timeout
                restoreCommand.Parameters.AddWithValue("@BackupPath", backupPath);
                await restoreCommand.ExecuteNonQueryAsync();
            }

            // 3. Verilənlər bazasını yenidən multi-user rejimə qaytarırıq
            string multiUserSql = $@"
                ALTER DATABASE {QuoteName(databaseName)} SET MULTI_USER;";

            await using (SqlCommand multiUserCommand = new(multiUserSql, connection))
            {
                multiUserCommand.CommandTimeout = 60;
                await multiUserCommand.ExecuteNonQueryAsync();
            }

            Logger.MelumatYaz($"Restore uğurla tamamlandı: {backupPath}");
            return EmeliyyatNeticesi.Ugurlu();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Restore əməliyyatı zamanı xəta baş verdi");
            return EmeliyyatNeticesi.Ugursuz($"Restore əməliyyatı uğursuz oldu: {ex.Message}");
        }
    }

    /// <summary>
    /// Backup faylı üçün standart fayl adı generasiya edir.
    /// </summary>
    /// <param name="backupDirectory">Backup qovluğu</param>
    /// <returns>Tam backup fayl yolu</returns>
    public static string StandartBackupAdiYarat(string backupDirectory)
    {
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HHmmss");
        string fileName = $"AzAgroPOS_Backup_{timestamp}.bak";
        return Path.Combine(backupDirectory, fileName);
    }

    /// <summary>
    /// Verilənlər bazasının ölçüsünü hesablayır (MB-da).
    /// </summary>
    /// <returns>Verilənlər bazası ölçüsü (MB)</returns>
    public async Task<EmeliyyatNeticesi<decimal>> BazaOlcusunuGetirAsync()
    {
        try
        {
            SqlConnectionStringBuilder builder = new(_connectionString);
            string databaseName = builder.InitialCatalog;

            string sizeSql = @"
                SELECT
                    SUM(size) * 8.0 / 1024 AS DatabaseSizeMB
                FROM sys.master_files
                WHERE database_id = DB_ID(@DatabaseName);";

            await using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            await using SqlCommand command = new(sizeSql, connection);
            command.Parameters.AddWithValue("@DatabaseName", databaseName);
            object? result = await command.ExecuteScalarAsync();

            if (result != null && result != DBNull.Value)
            {
                decimal sizeMB = Convert.ToDecimal(result);
                return EmeliyyatNeticesi<decimal>.Ugurlu(sizeMB);
            }

            return EmeliyyatNeticesi<decimal>.Ugursuz("Verilənlər bazası ölçüsü təyin edilə bilmədi.");
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Verilənlər bazası ölçüsünün hesablanması zamanı xəta");
            return EmeliyyatNeticesi<decimal>.Ugursuz($"Xəta: {ex.Message}");
        }
    }

    /// <summary>
    /// Son backup tarixini əldə edir.
    /// </summary>
    /// <returns>Son backup tarixi və ya null (əgər heç backup olmayıbsa)</returns>
    public async Task<EmeliyyatNeticesi<DateTime?>> SonBackupTarixiniGetirAsync()
    {
        try
        {
            SqlConnectionStringBuilder builder = new(_connectionString);
            string databaseName = builder.InitialCatalog;

            string lastBackupSql = @"
                SELECT TOP 1 backup_finish_date
                FROM msdb.dbo.backupset
                WHERE database_name = @DatabaseName
                  AND type = 'D' -- Full backup
                ORDER BY backup_finish_date DESC;";

            await using SqlConnection connection = new(_connectionString);
            await connection.OpenAsync();

            await using SqlCommand command = new(lastBackupSql, connection);
            command.Parameters.AddWithValue("@DatabaseName", databaseName);
            object? result = await command.ExecuteScalarAsync();

            if (result != null && result != DBNull.Value)
            {
                DateTime lastBackupDate = Convert.ToDateTime(result);
                return EmeliyyatNeticesi<DateTime?>.Ugurlu(lastBackupDate);
            }

            return EmeliyyatNeticesi<DateTime?>.Ugurlu(null);
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Son backup tarixinin əldə edilməsi zamanı xəta");
            return EmeliyyatNeticesi<DateTime?>.Ugursuz($"Xəta: {ex.Message}");
        }
    }
}
