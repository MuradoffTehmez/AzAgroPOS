
using AzAgroPOS.Varliglar;

namespace AzAgroPOS.Mentiq.DTOs;
/// <summary>
/// Satışların listələnməsi və təqdimat üçün istifadə olunan DTO.
/// SatisManager içində səhifələnmiş satış nəticələri üçün tələb olunur.
/// </summary>
public class SatisDto
{
    public int Id { get; set; }
    public DateTime Tarix { get; set; }
    public OdenisMetodu OdenisMetodu { get; set; }
    public decimal UmumiMebleg { get; set; }
    public int NovbeId { get; set; }
    public int? MusteriId { get; set; }

}