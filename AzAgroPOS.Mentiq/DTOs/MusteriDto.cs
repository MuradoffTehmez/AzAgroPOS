// Fayl: AzAgroPOS.Mentiq/DTOs/MusteriDto.cs
namespace AzAgroPOS.Mentiq.DTOs;
/// <summary>
/// Müştəri məlumatlarını Təqdimat (UI) qatına ötürmək üçün istifadə olunan obyekt.
/// </summary>
public class MusteriDto
{
    /// <summary>
    /// İstifadəçi interfeysində müştəri məlumatlarını təmsil edən unikal identifikator.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Tam adı (istifadəçi interfeysində göstəriləcək müştərinin tam adı).
    /// </summary>
    public string TamAd { get; set; } = string.Empty;
    /// <summary>
    /// Telefon nömrəsi (istifadəçi interfeysində göstəriləcək müştərinin telefon nömrəsi).
    /// </summary>
    public string TelefonNomresi { get; set; } = string.Empty;
    /// <summary>
    /// Unvan (istifadəçi interfeysində göstəriləcək müştərinin ünvanı).
    /// </summary>
    public string? Unvan { get; set; }
    /// <summary>
    /// Umumi borc (istifadəçi interfeysində göstəriləcək müştərinin ümumi borcu).
    /// </summary>
    public decimal UmumiBorc { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public decimal KreditLimiti { get; set; }
}