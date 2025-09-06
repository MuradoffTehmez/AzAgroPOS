// Fayl: AzAgroPOS.Mentiq/DTOs/IsciIzniDto.cs
namespace AzAgroPOS.Mentiq.DTOs;

using AzAgroPOS.Varliglar;
using System;

/// <summary>
/// İşçinin məzuniyyət və digər icazələrini təqdimat qatına ötürmək üçün istifadə olunan DTO.
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
    /// İznin növü (Məzuniyyət, Xəstəlik, Məzuniyyətsiz, və s.).
    /// </summary>
    public IzinNovu IzinNovu { get; set; } = IzinNovu.Mezuniyyet;

    /// <summary>
    /// İznin başlama tarixi.
    /// </summary>
    public DateTime BaslamaTarixi { get; set; } = DateTime.Now;

    /// <summary>
    /// İznin bitmə tarixi.
    /// </summary>
    public DateTime BitmeTarixi { get; set; } = DateTime.Now.AddDays(1);

    /// <summary>
    /// İznin ümumi günü.
    /// </summary>
    public int IzinGunu { get; set; } = 1;

    /// <summary>
    /// İznin səbəbi.
    /// </summary>
    public string Sebeb { get; set; } = string.Empty;

    /// <summary>
    /// İznin statusu (Təsdiqlənib, Gözləmədə, Rədd edilib və s.).
    /// </summary>
    public IzinStatusu Status { get; set; } = IzinStatusu.Gozlemede;

    /// <summary>
    /// İznin təsdiq edən işçinin ID-si.
    /// </summary>
    public int? TesdiqEdenIsciId { get; set; }

    /// <summary>
    /// İznin təsdiq edən işçinin adı.
    /// </summary>
    public string TesdiqEdenIsciAdi { get; set; } = string.Empty;

    /// <summary>
    /// İznin təsdiq tarixi.
    /// </summary>
    public DateTime? TesdiqTarixi { get; set; }

    /// <summary>
    /// İznin təsdiq edilməsi ilə bağlı əlavə qeydlər.
    /// </summary>
    public string Qeydler { get; set; } = string.Empty;
}