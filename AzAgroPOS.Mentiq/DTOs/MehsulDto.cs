// Fayl: AzAgroPOS.Mentiq/DTOs/MehsulDto.cs
using AzAgroPOS.Varliglar;

namespace AzAgroPOS.Mentiq.DTOs;

/// <summary>
/// Məhsul məlumatlarını Təqdimat (UI) qatına ötürmək üçün istifadə olunan obyekt.
/// </summary>
public class MehsulDto
{
    
    public int Id { get; set; }
    
    public string Ad { get; set; } = string.Empty;
    
    public decimal AlisQiymeti { get; set; }
    
    public string StokKodu { get; set; } = string.Empty;
    
    public string Barkod { get; set; } = string.Empty;
    
    public decimal PerakendeSatisQiymeti { get; set; }
    
    public decimal TopdanSatisQiymeti { get; set; }

    public decimal TekEdedSatisQiymeti { get; set; }
    
    public int MovcudSay { get; set; }
    
    public OlcuVahidi OlcuVahidi { get; set; }
    
    public string PerakendeSatisQiymetiStr => $"{PerakendeSatisQiymeti:N2} AZN";
    
    public string OlcuVahidiStr => OlcuVahidi.ToString();
}