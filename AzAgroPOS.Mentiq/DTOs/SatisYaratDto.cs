// Fayl: AzAgroPOS.Mentiq/DTOs/SatisYaratDto.cs
namespace AzAgroPOS.Mentiq.DTOs;

using AzAgroPOS.Varliglar;
using System.Collections.Generic;

/// <summary>
/// Yeni bir satış yaratmaq üçün Təqdimat qatından Məntiq qatına ötürülən məlumatları saxlayır.
/// </summary>
public class SatisYaratDto
{
    /// <summary>
    /// Satış səbətindəki məhsulların siyahısı.
    /// </summary>
    public List<SatisSebetiElementiDto> SebetElementleri { get; set; } = new();

    /// <summary>
    /// Həyata keçirilən ödənişin metodu (Nağd, Kart, Nisyə).
    /// </summary>
    public OdenisMetodu OdenisMetodu { get; set; }

    /// <summary>
    /// Satışın aid olduğu növbənin ID-si.
    /// </summary>
    public int NovbeId { get; set; }

    /// <summary>
    /// Əgər satış nisyədirsə, aid olduğu müştərinin ID-si.
    /// </summary>
    public int? MusteriId { get; set; }
}