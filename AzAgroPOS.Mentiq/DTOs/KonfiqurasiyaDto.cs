// AzAgroPOS.Mentiq/DTOs/KonfiqurasiyaDto.cs
namespace AzAgroPOS.Mentiq.DTOs;

/// <summary>
/// Konfiqurasiya parametri üçün verilənlər obyekti
/// </summary>
public class KonfiqurasiyaDto
{
    /// <summary>
    /// Konfiqurasiya ID-si
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Konfiqurasiya açarı (məsələn: "Şirkət.Adı")
    /// </summary>
    public string Acar { get; set; } = string.Empty;
    
    /// <summary>
    /// Konfiqurasiya dəyəri (məsələn: "AzAgroPOS MMC")
    /// </summary>
    public string Deyer { get; set; } = string.Empty;
    
    /// <summary>
    /// Konfiqurasiya təsviri (məsələn: "Şirkətin rəsmi adı")
    /// </summary>
    public string Tesvir { get; set; } = string.Empty;
    
    /// <summary>
    /// Konfiqurasiya qrupu (məsələn: "Şirkət Məlumatları", "Printer Tənzimləmələri")
    /// </summary>
    public string Qrup { get; set; } = string.Empty;
}