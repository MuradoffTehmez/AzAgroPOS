// Fayl: AzAgroPOS.Mentiq/Exceptions/BusinessRuleException.cs

namespace AzAgroPOS.Mentiq.Exceptions;

/// <summary>
/// Business rule pozulduqda atılan exception.
/// Məsələn: Stokda kifayət qədər məhsul yoxdur, Kredit limiti keçilir, və s.
/// </summary>
public class BusinessRuleException : Exception
{
    /// <summary>
    /// Business rule kodu (məsələn: "INSUFFICIENT_STOCK", "CREDIT_LIMIT_EXCEEDED")
    /// </summary>
    public string? RuleCode { get; set; }

    /// <summary>
    /// Əlavə məlumat (JSON formatında)
    /// </summary>
    public Dictionary<string, object>? AdditionalData { get; set; }

    public BusinessRuleException()
    {
    }

    public BusinessRuleException(string message) : base(message)
    {
    }

    public BusinessRuleException(string message, string ruleCode) : base(message)
    {
        RuleCode = ruleCode;
    }

    public BusinessRuleException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public BusinessRuleException(string message, string ruleCode, Dictionary<string, object> additionalData)
        : base(message)
    {
        RuleCode = ruleCode;
        AdditionalData = additionalData;
    }
}
