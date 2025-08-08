// Fayl: AzAgroPOS.Mentiq/DTOs/NisyeHereketiDto.cs
namespace AzAgroPOS.Mentiq.DTOs;

using AzAgroPOS.Varliglar;

public class NisyeHereketiDto
{
    public DateTime Tarix { get; set; }
    public string EmeliyyatNovu { get; set; } = string.Empty;
    public decimal Mebleg { get; set; }
    public string Qeyd { get; set; } = string.Empty;
}