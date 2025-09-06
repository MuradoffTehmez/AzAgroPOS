// AzAgroPOS.Mentiq/DTOs/IcazeDto.cs
namespace AzAgroPOS.Mentiq.DTOs;

/// <summary>
/// İcazə məlumatlarını saxlayan verilənlər obyekti
/// </summary>
public class IcazeDto
{
    /// <summary>
    /// İcazənin ID-si
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// İcazənin adı
    /// </summary>
    public string Ad { get; set; } = string.Empty;
    
    /// <summary>
    /// İcazənin təsviri
    /// </summary>
    public string Tesvir { get; set; } = string.Empty;
}