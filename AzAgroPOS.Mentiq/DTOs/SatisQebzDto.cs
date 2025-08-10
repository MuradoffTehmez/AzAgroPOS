// Fayl: AzAgroPOS.Mentiq/DTOs/SatisQebzDto.cs
namespace AzAgroPOS.Mentiq.DTOs;

using System;
using System.Collections.Generic;

/// <summary>
/// Satış qəbzini çap etmək üçün lazım olan bütün məlumatları saxlayır.
/// </summary>
public class SatisQebzDto
{
    public int SatisId { get; set; }
    public DateTime Tarix { get; set; }
    public string KassirAdi { get; set; } = string.Empty;
    public List<SatisSebetiElementiDto> SatilanMehsullar { get; set; } = new();
    public decimal CemiMebleg => SatilanMehsullar.Sum(m => m.UmumiMebleg);
}