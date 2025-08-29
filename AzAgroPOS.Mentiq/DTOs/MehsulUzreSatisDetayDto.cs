// Fayl: AzAgroPOS.Mentiq/DTOs/MehsulUzreSatisDetayDto.cs
namespace AzAgroPOS.Mentiq.DTOs;

/// <summary>
/// Məhsul üzrə satış hesabatında hər bir məhsulun yekun satış məlumatlarını saxlayır.
/// </summary>
public class MehsulUzreSatisDetayDto
{
    public string StokKodu { get; set; } = string.Empty;
    public string MehsulAdi { get; set; } = string.Empty;
    public int CemiSatilanMiqdar { get; set; }
    public decimal CemiMebleg { get; set; }

    // Cədvəldə daha səliqəli görünsün deyə formatlanmış xüsusiyyət
    public string CemiMeblegStr => $"{CemiMebleg:N2} AZN";
}