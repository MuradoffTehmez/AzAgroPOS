// Fayl: AzAgroPOS.Mentiq/Exceptions/ValidationException.cs

namespace AzAgroPOS.Mentiq.Exceptions;

/// <summary>
/// Validation xətası baş verdikdə atılan exception.
/// Məsələn: Required field-lər boşdur, Format düzgün deyil, və s.
/// </summary>
public class ValidationException : Exception
{
    /// <summary>
    /// Validation xətaları (field name => error message)
    /// </summary>
    public Dictionary<string, string> Errors { get; set; }

    public ValidationException() : base("Validation xətası")
    {
        Errors = new Dictionary<string, string>();
    }

    public ValidationException(string message) : base(message)
    {
        Errors = new Dictionary<string, string>();
    }

    public ValidationException(Dictionary<string, string> errors)
        : base("Bir və ya bir neçə validation xətası baş verdi")
    {
        Errors = errors ?? new Dictionary<string, string>();
    }

    public ValidationException(string message, Dictionary<string, string> errors)
        : base(message)
    {
        Errors = errors ?? new Dictionary<string, string>();
    }

    public ValidationException(string message, Exception innerException)
        : base(message, innerException)
    {
        Errors = new Dictionary<string, string>();
    }

    /// <summary>
    /// Tək bir validation xətası üçün convenience constructor
    /// </summary>
    /// <param name="fieldName">Field adı</param>
    /// <param name="errorMessage">Xəta mesajı</param>
    public ValidationException(string fieldName, string errorMessage)
        : base($"{fieldName}: {errorMessage}")
    {
        Errors = new Dictionary<string, string>
        {
            { fieldName, errorMessage }
        };
    }
}
