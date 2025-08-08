// Fayl: AzAgroPOS.Mentiq/DTOs/SatisSebetiElementiDto.cs
namespace AzAgroPOS.Mentiq.DTOs;

public class SatisSebetiElementiDto
{
    public int MehsulId { get; set; }
    public string MehsulAdi { get; set; } = string.Empty;
    public int Miqdar { get; set; }
    public decimal VahidinQiymeti { get; set; }
    public decimal UmumiMebleg => Miqdar * VahidinQiymeti;
}