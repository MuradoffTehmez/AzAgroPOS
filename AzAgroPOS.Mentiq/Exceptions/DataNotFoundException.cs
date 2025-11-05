// Fayl: AzAgroPOS.Mentiq/Exceptions/DataNotFoundException.cs

namespace AzAgroPOS.Mentiq.Exceptions;

/// <summary>
/// Məlumat tapılmadıqda atılan exception.
/// Məsələn: ID-yə görə entity tapılmadı, axtarış nəticəsiz qaldı, və s.
/// </summary>
public class DataNotFoundException : Exception
{
    /// <summary>
    /// Entity adı (məsələn: "Mehsul", "Musteri")
    /// </summary>
    public string? EntityName { get; set; }

    /// <summary>
    /// Entity ID (əgər varsa)
    /// </summary>
    public object? EntityId { get; set; }

    public DataNotFoundException()
        : base("Məlumat tapılmadı")
    {
    }

    public DataNotFoundException(string message) : base(message)
    {
    }

    public DataNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    /// <summary>
    /// Entity adı və ID ilə DataNotFoundException yaradır
    /// </summary>
    /// <param name="entityName">Entity adı</param>
    /// <param name="entityId">Entity ID</param>
    public DataNotFoundException(string entityName, object entityId)
        : base($"{entityName} tapılmadı (ID: {entityId})")
    {
        EntityName = entityName;
        EntityId = entityId;
    }

    /// <summary>
    /// Entity adı, ID və inner exception ilə DataNotFoundException yaradır
    /// </summary>
    public DataNotFoundException(string entityName, object entityId, Exception innerException)
        : base($"{entityName} tapılmadı (ID: {entityId})", innerException)
    {
        EntityName = entityName;
        EntityId = entityId;
    }
}
