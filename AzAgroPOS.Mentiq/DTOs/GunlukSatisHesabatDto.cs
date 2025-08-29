// Fayl: AzAgroPOS.Mentiq/DTOs/GunlukSatisHesabatDto.cs
namespace AzAgroPOS.Mentiq.DTOs;

using System;
using System.Collections.Generic;

/// <summary>
/// Günlük satış hesabatının yekun nəticələrini və detallarını özündə cəmləyir.
/// </summary>
public class GunlukSatisHesabatDto
{
    public DateTime HesabatTarixi { get; set; }
    public decimal UmumiDovriyye { get; set; }
    public int CemiSatisSayi { get; set; }
    public decimal NagdSatisCemi { get; set; }
    public decimal KartSatisCemi { get; set; }
    public decimal NisyeSatisCemi { get; set; }
    public List<GunlukSatisDetayDto> SatislarinSiyahisi { get; set; } = new();
}