using Serilog;
using System;

namespace AzAgroPOS.Mentiq.Yardimcilar
{
    public static class Logger
    {
        private static ILogger? _logger;

        public static void KonfiqurasiyaEt()
        {
            _logger = new LoggerConfiguration()
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public static void MelumatYaz(string mesaj)
        {
            _logger?.Information(mesaj);
        }

        public static void XetaYaz(Exception ex, string? mesaj = null)
        {
            _logger?.Error(ex, mesaj);
        }

        public static void XəbərdarlıqYaz(string mesaj)
        {
            _logger?.Warning(mesaj);
        }
    }
}