using Serilog;

namespace AzAgroPOS.Mentiq.Yardimcilar
{
    public static class Logger
    {
        private static ILogger? _logger;

        public static void KonfiqurasiyaEt()
        {
            try
            {
                // Ensure logs directory exists
                string logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "logs");
                if (!Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                }

                _logger = new LoggerConfiguration()
                    .WriteTo.File(Path.Combine(logDirectory, "log-.txt"),
                                 rollingInterval: RollingInterval.Day,
                                 shared: true,
                                 rollOnFileSizeLimit: true)
                    .CreateLogger();
            }
            catch (Exception ex)
            {
                // If we can't create the logger, we'll continue without logging
                // but we'll try to write to console as fallback
                System.Console.WriteLine($"Logging konfiqurasiya edilərkən xəta baş verdi: {ex.Message}");

                // Continue without logger - don't throw exception to avoid crashing the app
                _logger = null;
            }
        }

        public static void MelumatYaz(string mesaj)
        {
            try
            {
                _logger?.Information(mesaj);
            }
            catch
            {
                // Silent fail - don't let logging errors crash the application
                System.Console.WriteLine($"INFO: {mesaj}");
            }
        }

        public static void XetaYaz(Exception ex, string? mesaj = null)
        {
            try
            {
                _logger?.Error(ex, mesaj);
            }
            catch
            {
                // Silent fail - don't let logging errors crash the application
                System.Console.WriteLine($"ERROR: {mesaj} - {ex.Message}");
            }
        }

        public static void XəbərdarlıqYaz(string mesaj)
        {
            try
            {
                _logger?.Warning(mesaj);
            }
            catch
            {
                // Silent fail - don't let logging errors crash the application
                System.Console.WriteLine($"WARNING: {mesaj}");
            }
        }
    }
}