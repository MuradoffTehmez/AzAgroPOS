// Fayl: AzAgroPOS.Mentiq/DTOs/TemirDto.cs
namespace AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Varliglar;

/// <summary>
/// Tamir əməliyyatlarını təmsil edən DTO (Data Transfer Object) sinifi.
/// </summary>
public class TemirDto
{
    /// <summary>
    /// İstifadəçinin unikal identifikatoru.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Müştərinin adı (istifadəçi interfeysində göstəriləcək).
    /// </summary>
    public string MusteriAdi { get; set; } = string.Empty;
    /// <summary>
    /// Müştərinin telefon nömrəsi (istifadəçi interfeysində göstəriləcək).
    /// </summary>
    public string MusteriTelefonu { get; set; } = string.Empty;
    /// <summary>
    /// Cihazın adı (istifadəçi interfeysində göstəriləcək).
    /// </summary>
    public string CihazAdi { get; set; } = string.Empty;
    /// <summary>
    /// Problem təsviri (istifadəçi interfeysində göstəriləcək).
    /// </summary>
    public string ProblemTesviri { get; set; } = string.Empty;
    /// <summary>
    /// Qəbul tarixi (istifadəçi interfeysində göstəriləcək).
    /// </summary>
    public DateTime QebulTarixi { get; set; }
    /// <summary>
    /// Status (istifadəçi interfeysində göstəriləcək).
    /// </summary>
    public TemirStatusu Status { get; set; }
    /// <summary>
    /// Yekun məbləğ (istifadəçi interfeysində göstəriləcək).
    /// </summary>
    public decimal YekunMebleg { get; set; }
}