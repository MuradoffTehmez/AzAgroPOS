// AzAgroPOS.Varliglar/Konfiqurasiya.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Tətbiqat konfiqurasiya parametrlərini saxlayan varlıq
/// </summary>
public class Konfiqurasiya : BazaVarligi
{
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