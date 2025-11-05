using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using System.Diagnostics;

namespace AzAgroPOS.Mentiq.Yardimcilar
{
    /// <summary>
    /// Strukturlaşdırılmış logging sistemi
    /// Features: JSON format, enrichers, separate error log, performance tracking, fallback mechanism
    /// </summary>
    public static class Logger
    {
        private static ILogger? _logger;
        private static ILogger? _fallbackLogger;
        private static readonly object _lockObject = new();

        /// <summary>
        /// Logger-i konfiqurasiya edir (JSON format, enrichers, separate logs)
        /// </summary>
        public static void KonfiqurasiyaEt()
        {
            lock (_lockObject)
            {
                try
                {
                    // Ensure logs directory exists
                    string logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "logs");
                    if (!Directory.Exists(logDirectory))
                    {
                        Directory.CreateDirectory(logDirectory);
                    }

                    // Main logger with JSON format and enrichers
                    _logger = new LoggerConfiguration()
                        .MinimumLevel.Debug()
                        .Enrich.FromLogContext()
                        .Enrich.WithMachineName()
                        .Enrich.WithThreadId()
                        .Enrich.WithProperty("Application", "AzAgroPOS")
                        .Enrich.WithProperty("Environment", GetEnvironment())
                        // All logs in JSON format
                        .WriteTo.File(
                            formatter: new CompactJsonFormatter(),
                            path: Path.Combine(logDirectory, "app-.json"),
                            rollingInterval: RollingInterval.Day,
                            shared: true,
                            rollOnFileSizeLimit: true,
                            fileSizeLimitBytes: 10_485_760) // 10 MB
                        // Separate error log
                        .WriteTo.File(
                            formatter: new CompactJsonFormatter(),
                            path: Path.Combine(logDirectory, "error-.json"),
                            restrictedToMinimumLevel: LogEventLevel.Error,
                            rollingInterval: RollingInterval.Day,
                            shared: true,
                            rollOnFileSizeLimit: true,
                            fileSizeLimitBytes: 10_485_760)
                        // Human-readable text log for debugging
                        .WriteTo.File(
                            path: Path.Combine(logDirectory, "debug-.txt"),
                            rollingInterval: RollingInterval.Day,
                            shared: true,
                            outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] [{ThreadId}] {Message:lj}{NewLine}{Exception}")
                        .CreateLogger();

                    // Fallback logger (console only, no file I/O)
                    _fallbackLogger = new LoggerConfiguration()
                        .MinimumLevel.Warning()
                        .WriteTo.Console(
                            outputTemplate: "{Timestamp:HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                        .CreateLogger();

                    MelumatYaz("Logger uğurla konfiqurasiya edildi");
                }
                catch (Exception ex)
                {
                    // Fallback to console-only logging
                    _fallbackLogger = new LoggerConfiguration()
                        .MinimumLevel.Information()
                        .WriteTo.Console()
                        .CreateLogger();

                    _fallbackLogger?.Error(ex, "Logging konfiqurasiya edilərkən xəta baş verdi");
                    _logger = null;
                }
            }
        }

        /// <summary>
        /// Məlumat səviyyəsində log yazır
        /// </summary>
        public static void MelumatYaz(string mesaj)
        {
            try
            {
                _logger?.Information(mesaj);
            }
            catch (Exception ex)
            {
                // Fallback to console
                try
                {
                    _fallbackLogger?.Information(mesaj);
                    _fallbackLogger?.Warning(ex, "Log yazılarkən xəta baş verdi");
                }
                catch
                {
                    System.Console.WriteLine($"[INFO] {DateTime.Now:yyyy-MM-dd HH:mm:ss}: {mesaj}");
                }
            }
        }

        /// <summary>
        /// Xəta səviyyəsində log yazır
        /// </summary>
        public static void XetaYaz(Exception ex, string? mesaj = null)
        {
            try
            {
                if (mesaj != null)
                {
                    _logger?.Error(ex, mesaj);
                }
                else
                {
                    _logger?.Error(ex, "İstisna baş verdi");
                }
            }
            catch (Exception logEx)
            {
                // Fallback to console
                try
                {
                    _fallbackLogger?.Error(ex, mesaj ?? "İstisna baş verdi");
                    _fallbackLogger?.Warning(logEx, "Log yazılarkən xəta baş verdi");
                }
                catch
                {
                    System.Console.WriteLine($"[ERROR] {DateTime.Now:yyyy-MM-dd HH:mm:ss}: {mesaj} - {ex.Message}");
                    System.Console.WriteLine($"StackTrace: {ex.StackTrace}");
                }
            }
        }

        /// <summary>
        /// Xəbərdarlıq səviyyəsində log yazır
        /// </summary>
        public static void XəbərdarlıqYaz(string mesaj)
        {
            try
            {
                _logger?.Warning(mesaj);
            }
            catch (Exception ex)
            {
                // Fallback to console
                try
                {
                    _fallbackLogger?.Warning(mesaj);
                    _fallbackLogger?.Warning(ex, "Log yazılarkən xəta baş verdi");
                }
                catch
                {
                    System.Console.WriteLine($"[WARNING] {DateTime.Now:yyyy-MM-dd HH:mm:ss}: {mesaj}");
                }
            }
        }

        /// <summary>
        /// Debug səviyyəsində log yazır
        /// </summary>
        public static void DebugYaz(string mesaj)
        {
            try
            {
                _logger?.Debug(mesaj);
            }
            catch (Exception ex)
            {
                // Fallback to console
                try
                {
                    _fallbackLogger?.Debug(mesaj);
                    _fallbackLogger?.Warning(ex, "Log yazılarkən xəta baş verdi");
                }
                catch
                {
                    System.Console.WriteLine($"[DEBUG] {DateTime.Now:yyyy-MM-dd HH:mm:ss}: {mesaj}");
                }
            }
        }

        /// <summary>
        /// Strukturlaşdırılmış log yazır (əlavə properties ilə)
        /// </summary>
        public static void StrukturluMelumatYaz(string mesaj, params (string Key, object Value)[] properties)
        {
            try
            {
                var logProperties = properties.ToDictionary(p => p.Key, p => p.Value);
                _logger?.Information(mesaj + " {@Properties}", logProperties);
            }
            catch (Exception ex)
            {
                // Fallback
                try
                {
                    _fallbackLogger?.Information(mesaj);
                    _fallbackLogger?.Warning(ex, "Log yazılarkən xəta baş verdi");
                }
                catch
                {
                    System.Console.WriteLine($"[INFO] {DateTime.Now:yyyy-MM-dd HH:mm:ss}: {mesaj}");
                }
            }
        }

        /// <summary>
        /// Performance tracking - Əməliyyatın icra müddətini ölçür
        /// </summary>
        /// <param name="emeliyyatAdi">Əməliyyatın adı</param>
        /// <returns>Performance tracker (IDisposable)</returns>
        public static IDisposable PerformansOlc(string emeliyyatAdi)
        {
            return new PerformansTracker(emeliyyatAdi);
        }

        /// <summary>
        /// Environment tipini müəyyən edir
        /// </summary>
        private static string GetEnvironment()
        {
            return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                   ?? Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")
                   ?? "Production";
        }

        /// <summary>
        /// Performance tracking helper class
        /// </summary>
        private class PerformansTracker : IDisposable
        {
            private readonly string _emeliyyatAdi;
            private readonly Stopwatch _stopwatch;

            public PerformansTracker(string emeliyyatAdi)
            {
                _emeliyyatAdi = emeliyyatAdi;
                _stopwatch = Stopwatch.StartNew();
                MelumatYaz($"Əməliyyat başladı: {_emeliyyatAdi}");
            }

            public void Dispose()
            {
                _stopwatch.Stop();
                var elapsedMs = _stopwatch.ElapsedMilliseconds;

                StrukturluMelumatYaz(
                    $"Əməliyyat tamamlandı: {_emeliyyatAdi}",
                    ("OperationName", _emeliyyatAdi),
                    ("DurationMs", elapsedMs),
                    ("DurationSeconds", _stopwatch.Elapsed.TotalSeconds)
                );

                // Performance warning if operation takes too long
                if (elapsedMs > 5000) // 5 seconds
                {
                    XəbərdarlıqYaz($"PERFORMANS XƏBƏRDARLIĞI: {_emeliyyatAdi} əməliyyatı {elapsedMs}ms çəkdi");
                }
            }
        }
    }
}