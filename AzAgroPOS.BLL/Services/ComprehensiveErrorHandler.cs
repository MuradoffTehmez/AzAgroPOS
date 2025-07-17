using AzAgroPOS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.BLL.Services
{
    /// <summary>
    /// Hərtərəfli xəta idarəetmə və loglama servisi
    /// YÜKSƏK PRİORİTET: Xətaların tam loglanması və düzgün idarəsi
    /// </summary>
    public class ComprehensiveErrorHandler : IDisposable
    {
        private readonly ILoggerService _logger;
        private readonly string _applicationName;
        private readonly string _applicationVersion;
        private readonly object _lockObject = new object();
        private bool _disposed = false;

        public ComprehensiveErrorHandler(ILoggerService logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _applicationName = Assembly.GetEntryAssembly()?.GetName().Name ?? "AzAgroPOS";
            _applicationVersion = Assembly.GetEntryAssembly()?.GetName().Version?.ToString() ?? "Unknown";
        }

        /// <summary>
        /// Xətanı hərtərəfli loglayır və istifadəçiyə uyğun mesaj göstərir
        /// </summary>
        /// <param name="exception">Baş verən xəta</param>
        /// <param name="context">Xətanın baş verdiyi kontekst</param>
        /// <param name="userFriendlyMessage">İstifadəçiyə göstəriləcək mesaj</param>
        /// <param name="showToUser">İstifadəçiyə mesaj göstərilsin</param>
        /// <returns>Xəta ID-si</returns>
        public string HandleError(Exception exception, string context = null, 
            string userFriendlyMessage = null, bool showToUser = true)
        {
            if (_disposed) return null;

            var errorId = Guid.NewGuid().ToString("N")[..8].ToUpper();
            
            try
            {
                // Detallı xəta məlumatlarını topla
                var errorDetails = CollectErrorDetails(exception, context, errorId);
                
                // Xətanı loglayırıq
                LogError(errorDetails);
                
                // Kritik xətalar üçün xüsusi işlənmə
                if (IsCriticalError(exception))
                {
                    HandleCriticalError(exception, errorDetails);
                }
                
                // İstifadəçiyə mesaj göstər
                if (showToUser)
                {
                    ShowUserFriendlyError(userFriendlyMessage, errorId, exception);
                }
                
                return errorId;
            }
            catch (Exception loggingException)
            {
                // Loglama xətası əsas xətanı gizlətməməlidir
                HandleLoggingError(loggingException, exception);
                return errorId;
            }
        }

        /// <summary>
        /// Async xətaları idarə edir
        /// </summary>
        /// <param name="exception">Baş verən xəta</param>
        /// <param name="context">Xətanın baş verdiyi kontekst</param>
        /// <param name="userFriendlyMessage">İstifadəçiyə göstəriləcək mesaj</param>
        /// <param name="showToUser">İstifadəçiyə mesaj göstərilsin</param>
        /// <returns>Xəta ID-si</returns>
        public async Task<string> HandleErrorAsync(Exception exception, string context = null,
            string userFriendlyMessage = null, bool showToUser = true)
        {
            return await Task.Run(() => HandleError(exception, context, userFriendlyMessage, showToUser));
        }

        /// <summary>
        /// Xəta məlumatlarını toplamaq
        /// </summary>
        /// <param name="exception">Xəta</param>
        /// <param name="context">Kontekst</param>
        /// <param name="errorId">Xəta ID-si</param>
        /// <returns>Detallı xəta məlumatları</returns>
        private ErrorDetails CollectErrorDetails(Exception exception, string context, string errorId)
        {
            var details = new ErrorDetails
            {
                ErrorId = errorId,
                Timestamp = DateTime.Now,
                ApplicationName = _applicationName,
                ApplicationVersion = _applicationVersion,
                Context = context,
                Exception = exception,
                MachineName = Environment.MachineName,
                UserName = Environment.UserName,
                OSVersion = Environment.OSVersion.ToString(),
                CLRVersion = Environment.Version.ToString(),
                WorkingDirectory = Environment.CurrentDirectory,
                CommandLine = Environment.CommandLine
            };

            // Stack trace əlavə et
            if (exception != null)
            {
                details.ExceptionType = exception.GetType().FullName;
                details.Message = exception.Message;
                details.StackTrace = exception.StackTrace;
                details.Source = exception.Source;
                
                // Inner exception-ları topla
                var innerExceptions = new List<string>();
                var currentException = exception.InnerException;
                while (currentException != null)
                {
                    innerExceptions.Add($"{currentException.GetType().FullName}: {currentException.Message}");
                    currentException = currentException.InnerException;
                }
                details.InnerExceptions = innerExceptions;
            }

            // Sistem məlumatları
            details.AvailableMemory = GetAvailableMemory();
            details.ProcessorCount = Environment.ProcessorCount;
            details.SystemUptime = TimeSpan.FromMilliseconds(Environment.TickCount);

            // Aktiv thread-lər
            details.ThreadCount = Process.GetCurrentProcess().Threads.Count;
            details.ThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;

            return details;
        }

        /// <summary>
        /// Xətanı loglayır
        /// </summary>
        /// <param name="details">Xəta detalları</param>
        private void LogError(ErrorDetails details)
        {
            lock (_lockObject)
            {
                try
                {
                    var logMessage = BuildLogMessage(details);
                    _logger.LogError(new Exception(logMessage, details.Exception));
                    
                    // Xüsusi xəta log faylı
                    WriteToErrorLogFile(details, logMessage);
                }
                catch (Exception ex)
                {
                    // Son çarə - Windows Event Log
                    WriteToEventLog($"Error logging failed: {ex.Message}", EventLogEntryType.Error);
                }
            }
        }

        /// <summary>
        /// Log mesajını qurur
        /// </summary>
        /// <param name="details">Xəta detalları</param>
        /// <returns>Log mesajı</returns>
        private string BuildLogMessage(ErrorDetails details)
        {
            var sb = new StringBuilder();
            
            sb.AppendLine($"=== ERROR REPORT [{details.ErrorId}] ===");
            sb.AppendLine($"Timestamp: {details.Timestamp:yyyy-MM-dd HH:mm:ss.fff}");
            sb.AppendLine($"Application: {details.ApplicationName} v{details.ApplicationVersion}");
            sb.AppendLine($"Context: {details.Context ?? "Unknown"}");
            sb.AppendLine($"Machine: {details.MachineName}");
            sb.AppendLine($"User: {details.UserName}");
            sb.AppendLine($"OS: {details.OSVersion}");
            sb.AppendLine($"CLR: {details.CLRVersion}");
            sb.AppendLine($"Memory: {details.AvailableMemory:N0} bytes available");
            sb.AppendLine($"Threads: {details.ThreadCount} (Current: {details.ThreadId})");
            sb.AppendLine($"Uptime: {details.SystemUptime}");
            sb.AppendLine();
            
            if (details.Exception != null)
            {
                sb.AppendLine($"Exception Type: {details.ExceptionType}");
                sb.AppendLine($"Message: {details.Message}");
                sb.AppendLine($"Source: {details.Source}");
                sb.AppendLine();
                
                if (details.InnerExceptions.Count > 0)
                {
                    sb.AppendLine("Inner Exceptions:");
                    for (int i = 0; i < details.InnerExceptions.Count; i++)
                    {
                        sb.AppendLine($"  {i + 1}. {details.InnerExceptions[i]}");
                    }
                    sb.AppendLine();
                }
                
                sb.AppendLine("Stack Trace:");
                sb.AppendLine(details.StackTrace);
            }
            
            sb.AppendLine("=== END ERROR REPORT ===");
            
            return sb.ToString();
        }

        /// <summary>
        /// Xüsusi xəta log faylına yazır
        /// </summary>
        /// <param name="details">Xəta detalları</param>
        /// <param name="logMessage">Log mesajı</param>
        private void WriteToErrorLogFile(ErrorDetails details, string logMessage)
        {
            try
            {
                string logDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs", "errors");
                if (!Directory.Exists(logDir))
                {
                    Directory.CreateDirectory(logDir);
                }

                string logFile = Path.Combine(logDir, $"error_{DateTime.Now:yyyy-MM-dd}.txt");
                File.AppendAllText(logFile, logMessage + Environment.NewLine);
            }
            catch
            {
                // Xəta log faylı yazıla bilmirsə, heç nə etmə
            }
        }

        /// <summary>
        /// Kritik xəta olub-olmadığını yoxlayır
        /// </summary>
        /// <param name="exception">Xəta</param>
        /// <returns>Kritik xəta olub-olmadığı</returns>
        private bool IsCriticalError(Exception exception)
        {
            return exception is OutOfMemoryException ||
                   exception is StackOverflowException ||
                   exception is System.Threading.ThreadAbortException ||
                   exception is AccessViolationException ||
                   exception is System.Security.SecurityException;
        }

        /// <summary>
        /// Kritik xətaları idarə edir
        /// </summary>
        /// <param name="exception">Kritik xəta</param>
        /// <param name="details">Xəta detalları</param>
        private void HandleCriticalError(Exception exception, ErrorDetails details)
        {
            try
            {
                // Kritik xəta log-u
                WriteToEventLog($"CRITICAL ERROR [{details.ErrorId}]: {exception.Message}", EventLogEntryType.Error);
                
                // Emergency backup (əgər mümkündürsə)
                // CreateEmergencyBackup();
                
                // Sistem administratoruna bildiriş
                // NotifySystemAdministrator(details);
            }
            catch
            {
                // Kritik xəta idarəsi zamanı xəta baş versə də, proqramı çökdürmə
            }
        }

        /// <summary>
        /// İstifadəçiyə anlaşıqlı xəta mesajı göstərir
        /// </summary>
        /// <param name="userFriendlyMessage">İstifadəçi dostu mesaj</param>
        /// <param name="errorId">Xəta ID-si</param>
        /// <param name="exception">Xəta</param>
        private void ShowUserFriendlyError(string userFriendlyMessage, string errorId, Exception exception)
        {
            try
            {
                string message = userFriendlyMessage ?? GetDefaultUserMessage(exception);
                string title = "Sistem Xətası";
                
                string fullMessage = $"{message}\n\nXəta ID: {errorId}\n\n" +
                                   "Bu xəta avtomatik olaraq qeydə alınıb. " +
                                   "Problemin davam etməsi halında sistem administratoru ilə əlaqə saxlayın.";
                
                MessageBox.Show(fullMessage, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                // MessageBox göstərə bilmirsə, heç nə etmə
            }
        }

        /// <summary>
        /// Xəta növünə əsasən default user mesajı qaytarır
        /// </summary>
        /// <param name="exception">Xəta</param>
        /// <returns>Default mesaj</returns>
        private string GetDefaultUserMessage(Exception exception)
        {
            return exception switch
            {
                UnauthorizedAccessException => "Bu əməliyyat üçün icazəniz yoxdur.",
                FileNotFoundException => "Tələb olunan fayl tapılmadı.",
                System.Data.SqlClient.SqlException => "Verilənlər bazası ilə əlaqə problemi yarandı.",
                System.Net.NetworkInformation.NetworkInformationException => "Şəbəkə bağlantısı problemi yarandı.",
                OutOfMemoryException => "Sistem yaddaşı kifayət etmir.",
                _ => "Gözlənilməz bir xəta baş verdi."
            };
        }

        /// <summary>
        /// Loglama xətasını idarə edir
        /// </summary>
        /// <param name="loggingException">Loglama xətası</param>
        /// <param name="originalException">Orijinal xəta</param>
        private void HandleLoggingError(Exception loggingException, Exception originalException)
        {
            try
            {
                // Windows Event Log-a yaz
                string message = $"Logging error: {loggingException.Message}\n\n" +
                               $"Original error: {originalException?.Message ?? "Unknown"}";
                WriteToEventLog(message, EventLogEntryType.Error);
            }
            catch
            {
                // Son çarə - heç nə etmə
            }
        }

        /// <summary>
        /// Windows Event Log-a yazır
        /// </summary>
        /// <param name="message">Mesaj</param>
        /// <param name="entryType">Log tipi</param>
        private void WriteToEventLog(string message, EventLogEntryType entryType)
        {
            try
            {
                using var eventLog = new EventLog("Application");
                eventLog.Source = _applicationName;
                eventLog.WriteEntry(message, entryType);
            }
            catch
            {
                // Event log da yazıla bilmirsə, heç nə etmə
            }
        }

        /// <summary>
        /// Mövcud yaddaş miqdarını qaytarır
        /// </summary>
        /// <returns>Mövcud yaddaş (byte)</returns>
        private long GetAvailableMemory()
        {
            try
            {
                return GC.GetTotalMemory(false);
            }
            catch
            {
                return -1;
            }
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
            }
        }
    }

    /// <summary>
    /// Xəta detalları
    /// </summary>
    public class ErrorDetails
    {
        public string ErrorId { get; set; }
        public DateTime Timestamp { get; set; }
        public string ApplicationName { get; set; }
        public string ApplicationVersion { get; set; }
        public string Context { get; set; }
        public Exception Exception { get; set; }
        public string ExceptionType { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string Source { get; set; }
        public List<string> InnerExceptions { get; set; } = new List<string>();
        public string MachineName { get; set; }
        public string UserName { get; set; }
        public string OSVersion { get; set; }
        public string CLRVersion { get; set; }
        public string WorkingDirectory { get; set; }
        public string CommandLine { get; set; }
        public long AvailableMemory { get; set; }
        public int ProcessorCount { get; set; }
        public TimeSpan SystemUptime { get; set; }
        public int ThreadCount { get; set; }
        public int ThreadId { get; set; }
    }
}