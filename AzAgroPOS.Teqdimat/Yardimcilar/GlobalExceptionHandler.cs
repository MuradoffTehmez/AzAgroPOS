// Fayl: AzAgroPOS.Teqdimat/Yardimcilar/GlobalExceptionHandler.cs

using AzAgroPOS.Mentiq.Istisnalar;
using AzAgroPOS.Mentiq.Yardimcilar;
using Microsoft.Data.SqlClient;

namespace AzAgroPOS.Teqdimat.Yardimcilar;

/// <summary>
/// Qlobal exception handler - bütün tutulmamış exception-ları idarə edir
/// </summary>
public static class GlobalExceptionHandler
{
    /// <summary>
    /// Exception-ı analiz edib müvafiq mesajı qaytarır və log edir
    /// </summary>
    /// <param name="exception">Baş verən exception</param>
    /// <param name="source">Exception mənbəyi (məsələn: "UI Thread", "Background Thread")</param>
    /// <param name="isTerminating">Tətbiq bağlanır?</param>
    /// <returns>İstifadəçiyə göstəriləcək mesaj</returns>
    public static string Handle(Exception exception, string source, bool isTerminating = false)
    {
        string userMessage;

        try
        {
            // AzAgroPOS custom exception-larını idarə et
            if (exception is AzAgroPOSIstisnasi azagroException)
            {
                userMessage = HandleAzAgroPOSException(azagroException);
            }
            // SQL Server exception-larını idarə et
            else if (exception is SqlException sqlException)
            {
                userMessage = HandleSqlException(sqlException);
            }
            // InvalidOperationException
            else if (exception is InvalidOperationException)
            {
                userMessage = $"Əməliyyat xətası baş verdi.\n\nDetallar: {exception.Message}";
                Logger.XetaYaz(exception, $"{source} - InvalidOperationException");
            }
            // ArgumentException
            else if (exception is ArgumentException or ArgumentNullException)
            {
                userMessage = $"Yanlış parametr dəyəri.\n\nDetallar: {exception.Message}";
                Logger.XetaYaz(exception, $"{source} - ArgumentException");
            }
            // Generic exception
            else
            {
                userMessage = isTerminating
                    ? $"Tətbiqdə kritik xəta baş verdi və tətbiq bağlanacaq.\n\nXəta: {exception.Message}\n\nTəfərrüatlar log faylına yazıldı."
                    : $"Tətbiqdə gözlənilməyən xəta baş verdi.\n\nXəta: {exception.Message}\n\nTəfərrüatlar log faylına yazıldı.";

                Logger.XetaYaz(exception, $"{source} - Tutulmamış istisna");
            }
        }
        catch
        {
            // Əgər exception handling özü uğursuz olarsa
            userMessage = $"Kritik xəta baş verdi.\n\n{exception.GetType().Name}: {exception.Message}";
        }

        return userMessage;
    }

    /// <summary>
    /// AzAgroPOS custom exception-larını idarə edir
    /// </summary>
    private static string HandleAzAgroPOSException(AzAgroPOSIstisnasi exception)
    {
        string userMessage = exception.IstifadeciMesaji;

        switch (exception)
        {
            case TesdiqIstisnasi tesdiq:
                Logger.XəbərdarlıqYaz($"Təsdiq xətası: {tesdiq.IstifadeciMesaji} (Sahə: {tesdiq.SaheAdi})");
                if (!string.IsNullOrEmpty(tesdiq.SaheAdi))
                {
                    userMessage = $"Təsdiq xətası ({tesdiq.SaheAdi}):\n\n{tesdiq.IstifadeciMesaji}";
                }
                break;

            case BiznesQaydasiIstisnasi biznes:
                Logger.XəbərdarlıqYaz($"Biznes qaydası pozuldu: {biznes.IstifadeciMesaji} (Qayda: {biznes.QaydaKodu})");
                break;

            case MelumatTapilmadiIstisnasi melumat:
                Logger.XəbərdarlıqYaz($"Məlumat tapılmadı: {melumat.EntityNovu} (ID: {melumat.Identifikator})");
                break;

            case VerilenlerBazasiIstisnasi database:
                Logger.XetaYaz(database, $"Verilənlər bazası xətası (SQL Kod: {database.SqlXetaKodu})");
                break;

            case TehlukesizlikIstisnasi tehlukesizlik:
                Logger.XəbərdarlıqYaz($"Təhlükəsizlik xətası: {tehlukesizlik.XetaNovu} - {tehlukesizlik.IstifadeciMesaji}");
                break;

            default:
                Logger.XetaYaz(exception, $"AzAgroPOS exception: {exception.GetType().Name}");
                break;
        }

        return userMessage;
    }

    /// <summary>
    /// SQL Server exception-larını idarə edir
    /// </summary>
    private static string HandleSqlException(SqlException sqlException)
    {
        string userMessage;

        // SQL Server error kodlarına görə xüsusi mesajlar
        switch (sqlException.Number)
        {
            case -1: // Connection timeout
            case -2: // Timeout expired
                userMessage = "Verilənlər bazasına qoşulma timeout baş verdi.\n\nServer əlçatan olmaya bilər.";
                Logger.XetaYaz(sqlException, "SQL Timeout");
                break;

            case 2: // Network error
            case 53: // Could not open connection
                userMessage = "Verilənlər bazası serverinə qoşulmaq mümkün olmadı.\n\nŞəbəkə əlaqəsini yoxlayın.";
                Logger.XetaYaz(sqlException, "SQL Connection Error");
                break;

            case 547: // Foreign key violation
                userMessage = "Bu məlumatı silmək mümkün deyil.\n\nDaxilində əlaqəli qeydlər mövcuddur.";
                Logger.XəbərdarlıqYaz($"Foreign key constraint violation: {sqlException.Message}");
                break;

            case 2601: // Duplicate key - unique index
            case 2627: // Duplicate key - primary key
                userMessage = "Bu məlumat artıq mövcuddur.\n\nDuplikat qeyd yaratmaq mümkün deyil.";
                Logger.XəbərdarlıqYaz($"Duplicate key violation: {sqlException.Message}");
                break;

            case 18456: // Login failed
                userMessage = "Verilənlər bazasına giriş uğursuz oldu.\n\nİstifadəçi adı və ya parol yanlışdır.";
                Logger.XetaYaz(sqlException, "SQL Login Failed");
                break;

            default:
                userMessage = $"Verilənlər bazası xətası baş verdi.\n\nXəta kodu: {sqlException.Number}\nMesaj: {sqlException.Message}";
                Logger.XetaYaz(sqlException, $"SQL Error {sqlException.Number}");
                break;
        }

        return userMessage;
    }
}
