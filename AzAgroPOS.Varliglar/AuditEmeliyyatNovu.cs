// AzAgroPOS.Varliglar/AuditEmeliyyatNovu.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Audit jurnalında saxlanılan əməliyyatların növləri
/// </summary>
public enum AuditEmeliyyatNovu
{
    /// <summary>
    /// Yeni obyektin yaradılması
    /// </summary>
    Elave = 1,
    
    /// <summary>
    /// Mövcud obyektin yenilənməsi
    /// </summary>
    Yenileme = 2,
    
    /// <summary>
    /// Obyektin silinməsi (soft delete)
    /// </summary>
    Silme = 3
}