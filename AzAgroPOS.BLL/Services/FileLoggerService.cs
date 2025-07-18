using AzAgroPOS.BLL.Interfaces;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AzAgroPOS.BLL.Services
{
    /// <summary>
    /// Fayl əsaslı loglama servisi
    /// Bütün log məlumatlarını "logs" qovluğunda saxlayır
    /// </summary>
    public class FileLoggerService : ILoggerService
    {
        private readonly string _logDirectory;
        private readonly object _lockObject = new object();

        public FileLoggerService()
        {
            // Log fayllarını proqramın exe faylının yanında olan "logs" qovluğunda saxlayırıq
            _logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
            
            // Logs qovluğu yoxdursa yaradırıq
            if (!Directory.Exists(_logDirectory))
            {
                Directory.CreateDirectory(_logDirectory);
            }
        }

        public void LogError(Exception ex)
        {
            if (ex == null) return;

            try
            {
                lock (_lockObject) // Thread-safe etmək üçün
                {
                    string logFilePath = Path.Combine(_logDirectory, $"error_{DateTime.Now:yyyy-MM-dd}.txt");

                    var logMessage = new StringBuilder();
                    logMessage.AppendLine("==============================================================================");
                    logMessage.AppendLine($"XƏTA - {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                    logMessage.AppendLine($"Xəta Mesajı: {ex.Message}");
                    logMessage.AppendLine($"Xəta Tipi: {ex.GetType().FullName}");
                    logMessage.AppendLine("------------------------------------------------------------------------------");
                    logMessage.AppendLine("Stack Trace:");
                    logMessage.AppendLine(ex.StackTrace);

                    if (ex.InnerException != null)
                    {
                        logMessage.AppendLine("------------------------------------------------------------------------------");
                        logMessage.AppendLine("Daxili Exception:");
                        logMessage.AppendLine($"Mesaj: {ex.InnerException.Message}");
                        logMessage.AppendLine($"Stack Trace: {ex.InnerException.StackTrace}");
                    }
                    
                    logMessage.AppendLine("==============================================================================");
                    logMessage.AppendLine();

                    File.AppendAllText(logFilePath, logMessage.ToString(), Encoding.UTF8);
                }
            }
            catch (Exception loggingEx)
            {
                // Loglama zamanı belə xəta olarsa, onu konsola çıxarırıq
                Console.WriteLine($"Kritik loglama xətası: {loggingEx.Message}");
                
                // Son çarə olaraq Windows Event Log-a yazmağa cəhd edək
                try
                {
                    System.Diagnostics.EventLog.WriteEntry("AzAgroPOS", 
                        $"Loglama xətası: {loggingEx.Message}\nOrijinal xəta: {ex.Message}", 
                        System.Diagnostics.EventLogEntryType.Error);
                }
                catch
                {
                    // Heç bir şey etmir, çünkü artıq heç bir log məkanizmi işləmir
                }
            }
        }

        public void LogInfo(string message)
        {
            if (string.IsNullOrEmpty(message)) return;

            try
            {
                lock (_lockObject)
                {
                    string logFilePath = Path.Combine(_logDirectory, $"info_{DateTime.Now:yyyy-MM-dd}.txt");
                    
                    var logMessage = $"[INFO] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}{Environment.NewLine}";
                    File.AppendAllText(logFilePath, logMessage, Encoding.UTF8);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Info log xətası: {ex.Message}");
            }
        }

        public void LogWarning(string message)
        {
            if (string.IsNullOrEmpty(message)) return;

            try
            {
                lock (_lockObject)
                {
                    string logFilePath = Path.Combine(_logDirectory, $"warning_{DateTime.Now:yyyy-MM-dd}.txt");
                    
                    var logMessage = $"[XƏBƏRDARLIQ] {DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}{Environment.NewLine}";
                    File.AppendAllText(logFilePath, logMessage, Encoding.UTF8);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Warning log xətası: {ex.Message}");
            }
        }

        #region Async Methods

        public async Task LogErrorAsync(Exception ex, string message = "")
        {
            await Task.Run(() =>
            {
                if (!string.IsNullOrEmpty(message))
                {
                    // Create a combined exception message
                    var combinedException = new Exception($"{message}: {ex.Message}", ex);
                    LogError(combinedException);
                }
                else
                {
                    LogError(ex);
                }
            });
        }

        public async Task LogInfoAsync(string message)
        {
            await Task.Run(() => LogInfo(message));
        }

        public async Task LogWarningAsync(string message)
        {
            await Task.Run(() => LogWarning(message));
        }

        #endregion
    }
}