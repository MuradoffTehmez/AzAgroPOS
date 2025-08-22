// Fayl: AzAgroPOS.Mentiq/DTOs/IstifadeciDto.cs
namespace AzAgroPOS.Mentiq.DTOs;
/// <summary>
/// bu DTO, istifadəçi məlumatlarını saxlamaq üçün istifadə olunur.
/// </summary>
public class IstifadeciDto
{
    /// <summary>
    /// İstifadəçinin unikal identifikatoru.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// İstifadəçi adı (login).
    /// </summary>
    public string IstifadeciAdi { get; set; } = string.Empty;
    /// <summary>
    /// Tam adı (ad və soyad).
    /// </summary>
    public string TamAd { get; set; } = string.Empty;
    /// <summary>
    /// Rol adı (istifadəçinin rolu).
    /// </summary>
    public string RolAdi { get; set; } = string.Empty;
    /// <summary>
    /// Rol ID-si (istifadəçinin rolu ilə əlaqəli identifikator).
    /// </summary>
    public int RolId { get; set; }
}