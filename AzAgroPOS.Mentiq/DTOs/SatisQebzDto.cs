// Fayl: AzAgroPOS.Mentiq/DTOs/SatisQebzDto.cs
namespace AzAgroPOS.Mentiq.DTOs;

using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Satış qəbzini çap etmək üçün lazım olan bütün məlumatları saxlayır.
/// </summary>
public class SatisQebzDto
{
    /// <summary>
    /// satışın unikal identifikatoru.
    /// </summary>
    public int SatisId { get; set; }
    /// <summary>
    /// tarix və saat (satışın baş verdiyi tarix və saat).
    /// </summary>
    public DateTime Tarix { get; set; }
    /// <summary>
    /// Kassir adı (satışı həyata keçirən kassirin adı).
    /// </summary>
    public string KassirAdi { get; set; } = string.Empty;
    /// <summary>
    /// Satılan məhsulların siyahısı (satış zamanı satılan məhsul elementləri).
    /// </summary>
    public List<SatisSebetiElementiDto> SatilanMehsullar { get; set; } = new();
    /// <summary>
    /// Cəmi məbləğ (satılan məhsulların ümumi məbləği).
    /// </summary>
    public decimal CemiMebleg => SatilanMehsullar.Sum(m => m.UmumiMebleg);
}