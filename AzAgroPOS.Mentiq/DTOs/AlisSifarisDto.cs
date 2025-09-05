// Fayl: AzAgroPOS.Mentiq/DTOs/AlisSifarisDto.cs
namespace AzAgroPOS.Mentiq.DTOs;

using AzAgroPOS.Varliglar;
using System;
using System.Collections.Generic;

/// <summary>
/// Alış sifarişi məlumatlarını təqdimat qatına ötürmək üçün istifadə olunan DTO.
/// </summary>
public class AlisSifarisDto
{
    /// <summary>
    /// Alış sifarişinin unikal identifikatoru.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Alış sifarişinin nömrəsi.
    /// </summary>
    public string SifarisNomresi { get; set; } = string.Empty;

    /// <summary>
    /// Sifarişin yaradıldığı tarix.
    /// </summary>
    public DateTime YaradilmaTarixi { get; set; } = DateTime.Now;

    /// <summary>
    /// Sifarişin təsdiq edildiyi tarix.
    /// </summary>
    public DateTime? TesdiqTarixi { get; set; }

    /// <summary>
    /// Sifarişin gözlənilən təhvil tarixi.
    /// </summary>
    public DateTime? GozlenilenTehvilTarixi { get; set; }

    /// <summary>
    /// Sifarişin faktiki təhvil alındığı tarix.
    /// </summary>
    public DateTime? FaktikiTehvilTarixi { get; set; }

    /// <summary>
    /// Tədarükçü ID-si.
    /// </summary>
    public int TedarukcuId { get; set; }

    /// <summary>
    /// Tədarükçünün adı.
    /// </summary>
    public string TedarukcuAdi { get; set; } = string.Empty;

    /// <summary>
    /// Sifarişin ümumi məbləği.
    /// </summary>
    public decimal UmumiMebleg { get; set; }

    /// <summary>
    /// Sifarişin statusu (Yaradıldı, Təsdiqləndi, Təhvil Alındı, Ləğv Edildi).
    /// </summary>
    public AlisSifarisStatusu Status { get; set; } = AlisSifarisStatusu.Yaradildi;

    /// <summary>
    /// Qeydlər və şərhlər.
    /// </summary>
    public string? Qeydler { get; set; }

    /// <summary>
    /// Bu sifarişə aid sətirlər.
    /// </summary>
    public List<AlisSifarisSetiriDto> SifarisSetirleri { get; set; } = new List<AlisSifarisSetiriDto>();
}