// Fayl: AzAgroPOS.Mentiq/DTOs/GunlukSatisDetayDto.cs
namespace AzAgroPOS.Mentiq.DTOs;

using System;

/// <summary>
/// Günlük satış hesabatında hər bir satış əməliyyatının detalını təmsil edir.
/// </summary>
public class GunlukSatisDetayDto
{
    public int SatisId { get; set; }
    public DateTime Tarix { get; set; }
    public decimal UmumiMebleg { get; set; }
    public string OdenisMetodu { get; set; } = string.Empty;
    public string MusteriAdi { get; set; } = "N/A";
}