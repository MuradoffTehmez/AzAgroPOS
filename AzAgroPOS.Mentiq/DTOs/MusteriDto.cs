// Fayl: AzAgroPOS.Mentiq/DTOs/MusteriDto.cs
namespace AzAgroPOS.Mentiq.DTOs;

public class MusteriDto
{
    public int Id { get; set; }
    public string TamAd { get; set; } = string.Empty;
    public string TelefonNomresi { get; set; } = string.Empty;
    public string? Unvan { get; set; }
    public decimal UmumiBorc { get; set; }
}