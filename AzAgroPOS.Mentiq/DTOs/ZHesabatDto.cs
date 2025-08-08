// Fayl: AzAgroPOS.Mentiq/DTOs/ZHesabatDto.cs
namespace AzAgroPOS.Mentiq.DTOs;
using System;
public class ZHesabatDto
{
    public DateTime AcilmaTarixi { get; set; }
    public DateTime BaglanmaTarixi { get; set; }
    public string KassirAdi { get; set; } = string.Empty;
    public decimal BaslangicMebleg { get; set; }
    public int SatisSayi { get; set; }
    public decimal NagdSatislar { get; set; }
    public decimal KartSatislar { get; set; }
    public decimal CemiSatislar => NagdSatislar + KartSatislar;
    public decimal GozlenilenMebleg { get; set; }
    public decimal FaktikiMebleg { get; set; }
    public decimal Ferq => FaktikiMebleg - GozlenilenMebleg;
}