// Fayl: AzAgroPOS.Mentiq/DTOs/IsciPerformansDto.cs
namespace AzAgroPOS.Mentiq.DTOs;

using System;

/// <summary>
/// İşçi performans məlumatlarını təqdimat qatına ötürmək üçün istifadə olunan DTO.
/// </summary>
public class IsciPerformansDto
{
    /// <summary>
    /// Performans qeydinin unikal identifikatoru.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Performans qeydinin aid olduğu işçinin ID-si.
    /// </summary>
    public int IsciId { get; set; }

    /// <summary>
    /// Performans qeydinin aid olduğu işçinin adı.
    /// </summary>
    public string IsciAdi { get; set; } = string.Empty;

    /// <summary>
    /// Performans qeydinin tarixi.
    /// </summary>
    public DateTime Tarix { get; set; }

    /// <summary>
    /// Performans qiymətləndirmə dövrü.
    /// </summary>
    public string QeydDovru { get; set; } = string.Empty;

    /// <summary>
    /// Performansın qiyməti (1-10 arası).
    /// </summary>
    public int Qiymet { get; set; }

    /// <summary>
    /// Performansla bağlı əlavə qeydlər və şərhlər.
    /// </summary>
    public string Qeydler { get; set; } = string.Empty;

    /// <summary>
    /// Performans əmsalları.
    /// </summary>
    public string Emsallar { get; set; } = string.Empty;

    /// <summary>
    /// Performansla bağlı təkliflər.
    /// </summary>
    public string Teklifler { get; set; } = string.Empty;
}