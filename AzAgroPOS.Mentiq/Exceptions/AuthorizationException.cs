// Fayl: AzAgroPOS.Mentiq/Exceptions/AuthorizationException.cs

namespace AzAgroPOS.Mentiq.Exceptions;

/// <summary>
/// İcazə problemi olduqda atılan exception.
/// Məsələn: İstifadəçi bu əməliyyatı etmək hüququna malik deyil
/// </summary>
public class AuthorizationException : Exception
{
    /// <summary>
    /// Tələb olunan rol
    /// </summary>
    public string? RequiredRole { get; set; }

    /// <summary>
    /// İstifadəçinin cari rolu
    /// </summary>
    public string? CurrentRole { get; set; }

    /// <summary>
    /// Əməliyyat adı
    /// </summary>
    public string? OperationName { get; set; }

    public AuthorizationException()
        : base("Bu əməliyyatı yerinə yetirmək üçün icazəniz yoxdur")
    {
    }

    public AuthorizationException(string message) : base(message)
    {
    }

    public AuthorizationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public AuthorizationException(string operationName, string requiredRole, string currentRole)
        : base($"'{operationName}' əməliyyatı üçün '{requiredRole}' rolu tələb olunur. Sizin rolunuz: '{currentRole}'")
    {
        OperationName = operationName;
        RequiredRole = requiredRole;
        CurrentRole = currentRole;
    }
}
