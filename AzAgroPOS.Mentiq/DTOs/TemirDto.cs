// Fayl: AzAgroPOS.Mentiq/DTOs/TemirDto.cs
namespace AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Varliglar;

public class TemirDto
{
    public int Id { get; set; }
    public string MusteriAdi { get; set; } = string.Empty;
    public string MusteriTelefonu { get; set; } = string.Empty;
    public string CihazAdi { get; set; } = string.Empty;
    public string ProblemTesviri { get; set; } = string.Empty;
    public DateTime QebulTarixi { get; set; }
    public TemirStatusu Status { get; set; }
    public decimal YekunMebleg { get; set; }
}