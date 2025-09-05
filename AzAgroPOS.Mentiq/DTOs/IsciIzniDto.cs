// Fayl: AzAgroPOS.Mentiq/DTOs/IsciIzniDto.cs
namespace AzAgroPOS.Mentiq.DTOs;

using AzAgroPOS.Varliglar;
using System;

/// <summary>
/// İşçinin məzuniyyət/icazə məlumatlarını təqdimat qatına ötürmək üçün istifadə olunan DTO.
/// </summary>
public class IsciIzniDto
{
    /// <summary>
    /// Məzuniyyət/icazə qeydinin unikal identifikatoru.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Məzuniyyət/icazə qeydinin aid olduğu işçinin ID-si.
    /// </summary>
    public int IsciId { get; set; }

    /// <summary>
    /// Məzuniyyət/icazə qeydinin aid olduğu işçinin adı.
    /// </summary>
    public string IsciAdi { get; set; } = string.Empty;

    /// <summary>
    /// Məzuniyyət/icazənin növü (Məzuniyyət, Xəstəlik, Məzuniyyətsiz, və s.).
    /// </summary>
    public IzinNovu IzinNovu { get; set; } = IzinNovu.Mezuniyyet;

    /// <summary>
    /// Məzuniyyət/icazənin başlama tarixi.
    /// </summary>
    public DateTime BaslamaTarixi { get; set; } = DateTime.Now;

    /// <summary>
    /// Məzuniyyət/icazənin bitmə tarixi.
    /// </summary>
    public DateTime BitmeTarixi { get; set; } = DateTime.Now.AddDays(1);

    /// <summary>
    /// Məzuniyyət/icazənin ümumi günü.
    /// </summary>
    public int IzinGunu { get; set; } = 1;

    /// <summary>
    /// Məzuniyyət/icazənin səbəbi.
    /// </summary>
    public string Sebeb { get; set; } = string.Empty;

    /// <summary>
    /// Məzuniyyət/icazənin statusu (Təsdiqlənib, Gözləmədə, Rədd edilib və s.).
    /// </summary>
    public IzinStatusu Status { get; set; } = IzinStatusu.Gozlemede;

    /// <summary>
    /// Məzuniyyət/icazəni təsdiq edən işçinin ID-si.
    /// </summary>
    public int? TesdiqEdenIsciId { get; set; }

    /// <summary>
    /// Məzuniyyət/icazəni təsdiq edən işçinin adı.
    /// </summary>
    public string TesdiqEdenIsciAdi { get; set; } = string.Empty;

    /// <summary>
    /// Məzuniyyət/icazənin təsdiq tarixi.
    /// </summary>
    public DateTime? TesdiqTarixi { get; set; }

    /// <summary>
    /// Məzuniyyət/icazə ilə bağlı əlavə qeydlər.
    /// </summary>
    public string Qeydler { get; set; } = string.Empty;
}