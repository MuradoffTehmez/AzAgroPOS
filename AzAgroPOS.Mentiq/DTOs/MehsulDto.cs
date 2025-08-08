// Fayl: AzAgroPOS.Mentiq/DTOs/MehsulDto.cs
namespace AzAgroPOS.Mentiq.DTOs;

/// <summary>
/// Məhsul məlumatlarını Təqdimat (UI) qatına ötürmək üçün istifadə olunan obyekt.
/// </summary>
public class MehsulDto
{
    public int Id { get; set; }
    public string Ad { get; set; } = string.Empty;
    public string StokKodu { get; set; } = string.Empty;
    public string Barkod { get; set; } = string.Empty;
    public decimal SatisQiymeti { get; set; }
    public int MovcudSay { get; set; }

    // Məsələn, cədvəldə göstərmək üçün formatlanmış qiymət
    public string SatisQiymetiStr => $"{SatisQiymeti:N2} AZN";
}