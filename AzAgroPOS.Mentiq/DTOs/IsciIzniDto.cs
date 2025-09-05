// Fayl: AzAgroPOS.Mentiq/DTOs/IsciIzniDto.cs
namespace AzAgroPOS.Mentiq.DTOs;

using AzAgroPOS.Varliglar;
using System;

/// <summary>
/// İşçi məzuniyyət/icazə məlumatlarını təqdimat qatına ötürmək üçün istifadə olunan DTO.
/// </summary>
public class IsciIzniDto
{
    /// <summary>
    /// İznin unikal identifikatoru.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// İznin aid olduğu işçinin ID-si.
    /// </summary>
    public int IsciId { get; set; }

    /// <summary>
    /// İznin aid olduğu işçinin adı.
    /// </summary>
    public string IsciAdi { get; set; } = string.Empty;

    /// <summary>
    /// İznin növü.
    /// </summary>
    public IzinNovu IzinNovu { get; set; }

    /// <summary>
    /// İznin başlama tarixi.
    /// </summary>
    public DateTime BaslamaTarixi { get; set; }

    /// <summary>
    /// İznin bitmə tarixi.
    /// </summary>
    public DateTime BitmeTarixi { get; set; }

    /// <summary>
    /// İznin ümumi günü.
    /// </summary>
    public int IzinGunu { get; set; }

    /// <summary>
    /// İznin səbəbi.
    /// </summary>
    public string Sebeb { get; set; } = string.Empty;

    /// <summary>
    /// İznin statusu.
    /// </summary>
    public IzinStatusu Status { get; set; }

    /// <summary>
    /// İznin təsdiq edən şəxsin ID-si.
    /// </summary>
    public int? TesdiqEdenIsciId { get; set; }

    /// <summary>
    /// İznin təsdiq edən şəxsin adı.
    /// </summary>
    public string? TesdiqEdenIsciAdi { get; set; }

    /// <summary>
    /// İznin təsdiq tarixi.
    /// </summary>
    public DateTime? TesdiqTarixi { get; set; }

    /// <summary>
    /// İznin təsdiq edilməsi ilə bağlı əlavə qeydlər.
    /// </summary>
    public string Qeydler { get; set; } = string.Empty;
}