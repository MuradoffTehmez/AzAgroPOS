// Fayl: AzAgroPOS.Mentiq/DTOs/SatisSebetiElementiDto.cs
namespace AzAgroPOS.Mentiq.DTOs;

/// <summary>
/// Satis sebeti elementi DTO (Data Transfer Object).
/// </summary>
public class SatisSebetiElementiDto
{
    /// <summary>
    /// Məhsulun unikal identifikatoru.
    /// </summary>
    public int MehsulId { get; set; }
    /// <summary>
    /// məhsulun adı (istifadəçi interfeysində göstəriləcək).
    /// </summary>
    public string MehsulAdi { get; set; } = string.Empty;
    /// <summary>
    /// Miqdar (satılan məhsulun miqdarı).
    /// </summary>
    public int Miqdar { get; set; }
    /// <summary>
    /// Vahidin qiyməti (satılan məhsulun vahid qiyməti).
    /// </summary>
    public decimal VahidinQiymeti { get; set; }
    /// <summary>
    /// Umumi məbləğ (satılan məhsulun miqdarı ilə vahidin qiymətinin hasilidir).
    /// </summary>
    public decimal UmumiMebleg => Miqdar * VahidinQiymeti;
}