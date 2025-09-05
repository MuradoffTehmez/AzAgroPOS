// Fayl: AzAgroPOS.Mentiq/DTOs/AlisSenedDto.cs
namespace AzAgroPOS.Mentiq.DTOs;

using AzAgroPOS.Varliglar;
using System;
using System.Collections.Generic;

/// <summary>
/// Alış sənədi məlumatlarını təqdimat qatına ötürmək üçün istifadə olunan DTO.
/// </summary>
public class AlisSenedDto
{
    /// <summary>
    /// Alış sənədin unikal identifikatoru.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Alış sənədin nömrəsi.
    /// </summary>
    public string SenedNomresi { get; set; } = string.Empty;

    /// <summary>
    /// Sənədin yaradıldığı tarix.
    /// </summary>
    public DateTime YaradilmaTarixi { get; set; } = DateTime.Now;

    /// <summary>
    /// Tədarükçü ID-si.
    /// </summary>
    public int TedarukcuId { get; set; }

    /// <summary>
    /// Tədarükçünün adı.
    /// </summary>
    public string TedarukcuAdi { get; set; } = string.Empty;

    /// <summary>
    /// Malın təhvil alındığı tarix.
    /// </summary>
    public DateTime TehvilTarixi { get; set; } = DateTime.Now;

    /// <summary>
    /// Sənədin ümumi məbləği.
    /// </summary>
    public decimal UmumiMebleg { get; set; }

    /// <summary>
    /// Sənədin statusu (Yaradıldı, Təsdiqləndi, Ləğv Edildi).
    /// </summary>
    public AlisSenedStatusu Status { get; set; } = AlisSenedStatusu.Yaradildi;

    /// <summary>
    /// Qeydlər və şərhlər.
    /// </summary>
    public string? Qeydler { get; set; }

    /// <summary>
    /// Bu sənədə aid sətirlər.
    /// </summary>
    public List<AlisSenedSetiriDto> SenedSetirleri { get; set; } = new List<AlisSenedSetiriDto>();
}