// Fayl: AzAgroPOS.Mentiq/Exceptions/DatabaseException.cs

using Microsoft.EntityFrameworkCore;

namespace AzAgroPOS.Mentiq.Exceptions;

/// <summary>
/// Database əməliyyatları zamanı baş verən xətalar üçün exception.
/// DbUpdateException, SqlException və s. wrap edir.
/// </summary>
public class DatabaseException : Exception
{
    /// <summary>
    /// Database əməliyyatının tipi (Insert, Update, Delete, Query)
    /// </summary>
    public string? OperationType { get; set; }

    /// <summary>
    /// Təsir edilmiş table adı
    /// </summary>
    public string? TableName { get; set; }

    public DatabaseException()
        : base("Verilənlər bazası xətası")
    {
    }

    public DatabaseException(string message) : base(message)
    {
    }

    public DatabaseException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public DatabaseException(string message, string operationType, Exception innerException)
        : base(message, innerException)
    {
        OperationType = operationType;
    }

    /// <summary>
    /// DbUpdateException-dan DatabaseException yaradır
    /// </summary>
    public static DatabaseException FromDbUpdateException(DbUpdateException ex)
    {
        var message = "Verilənlər bazasına məlumat yazarkən xəta baş verdi";

        // Check for specific SQL errors
        if (ex.InnerException?.Message.Contains("UNIQUE constraint") == true)
        {
            message = "Bu məlumat artıq mövcuddur (dublikat qeyd)";
        }
        else if (ex.InnerException?.Message.Contains("FOREIGN KEY constraint") == true)
        {
            message = "Əlaqəli məlumat mövcud deyil və ya silinə bilməz";
        }
        else if (ex.InnerException?.Message.Contains("cannot insert NULL") == true)
        {
            message = "Mütləq doldurulmalı sahə boş buraxılıb";
        }

        return new DatabaseException(message, ex);
    }
}
