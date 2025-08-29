// Fayl: AzAgroPOS.Mentiq/DTOs/AnbarQaliqDetayDto.cs
namespace AzAgroPOS.Mentiq.DTOs;

/// <summary>
/// Anbar qalığı hesabatında hər bir məhsulun məlumatını saxlayır.
/// </summary>
public class AnbarQaliqDetayDto
{
    public string StokKodu { get; set; } = string.Empty;
    public string MehsulAdi { get; set; } = string.Empty;
    public int MovcudSay { get; set; }
}