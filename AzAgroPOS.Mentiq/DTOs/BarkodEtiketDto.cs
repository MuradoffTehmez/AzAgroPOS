// Fayl: AzAgroPOS.Mentiq/DTOs/BarkodEtiketDto.cs
namespace AzAgroPOS.Mentiq.DTOs;

/// <summary>
/// Barkod etiketi çapı üçün lazım olan məlumatları saxlayır.
/// </summary>
public class BarkodEtiketDto
{
    /// <summary>
    /// Məhsulun unikal ID-si.
    /// </summary>
    public int MehsulId { get; set; }

    /// <summary>
    /// Məhsulun adı.
    /// </summary>
    public string MehsulAdi { get; set; } = string.Empty;

    /// <summary>
    /// Məhsulun pərakəndə satış qiyməti.
    /// </summary>
    public decimal Qiymet { get; set; }

    /// <summary>
    /// Məhsulun barkodu.
    /// </summary>
    public string Barkod { get; set; } = string.Empty;

    /// <summary>
    /// Bu məhsuldan neçə ədəd etiket çap olunacağı.
    /// </summary>
    public int CapEdilecekSay { get; set; } = 1;

    /// <summary>
    /// Qiymətin formatlanmış versiyası.
    /// </summary>
    public string QiymetStr => $"{Qiymet:N2} AZN";
}