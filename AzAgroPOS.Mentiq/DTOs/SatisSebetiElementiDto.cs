// Fayl: AzAgroPOS.Mentiq/DTOs/SatisSebetiElementiDto.cs
namespace AzAgroPOS.Mentiq.DTOs;

/// <summary>
/// Satis sebeti elementi DTO (Data Transfer Object).
/// </summary>
public class SatisSebetiElementiDto
{
    public int MehsulId { get; set; }
    public string MehsulAdi { get; set; } = string.Empty;
    public int Miqdar { get; set; }

    /// <summary>
    /// Satış zamanı tətbiq edilən konkret vahid qiyməti.
    /// </summary>
    public decimal VahidinQiymeti { get; set; }

    /// <summary>
    /// Hansı qiymət növünün (Pərakəndə, Topdan və s.) tətbiq edildiyini göstərir.
    /// Qəbzdə və hesabatlarda göstərmək üçün faydalıdır.
    /// </summary>
    public string QiymetNövü { get; set; } = "Pərakəndə";

    /// <summary>
    /// Umumi məbləğ (satılan məhsulun miqdarı ilə vahidin qiymətinin hasilidir).
    /// </summary>
    public decimal UmumiMebleg => Miqdar * VahidinQiymeti;
}