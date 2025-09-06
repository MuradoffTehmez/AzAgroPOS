// Fayl: AzAgroPOS.Mentiq/Yardimcilar/Logger.cs
namespace AzAgroPOS.Mentiq.Yardimcilar;

using Serilog;
using System;

/// <summary>
/// Tətbiqat səviyyəli loqger konfiqurasiyası.
/// </summary>
public static class Logger
{
    private static ILogger? _logger;

    /// <summary>
    /// Loqgeri konfiqurasiya edir və işə salır.
    /// </summary>
    public static void KonfiqurasiyaEt()
    {
        _logger = new LoggerConfiguration()
            .WriteTo.File("logs/loqlar-.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
    }

    /// <summary>
    /// Xəta loqlar.
    /// </summary>
    /// <param name="exception">Xəta obyekti</param>
    /// <param name="mesaj">Əlavə məlumat</param>
    public static void XetaLoqla(Exception exception, string mesaj = "")
    {
        _logger?.Error(exception, mesaj);
    }

    /// <summary>
    /// Ümumi məlumat loqlar.
    /// </summary>
    /// <param name="mesaj">Loq mesajı</param>
    public static void MelumatLoqla(string mesaj)
    {
        _logger?.Information(mesaj);
    }
}