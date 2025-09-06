// Fayl: AzAgroPOS.Mentiq/DTOs/AlisSenedSetiriDto.cs
namespace AzAgroPOS.Mentiq.DTOs;
/// <summary>
/// Alış sənədi sətiri məlumatlarını təqdimat qatına ötürmək üçün istifadə olunan DTO.
/// </summary>
public class AlisSenedSetiriDto
{
    /// <summary>
    /// Alış sənədi sətrinin unikal identifikatoru.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Alış sənədi ID-si.
    /// </summary>
    public int AlisSenedId { get; set; }

    /// <summary>
    /// Məhsul ID-si.
    /// </summary>
    public int MehsulId { get; set; }

    /// <summary>
    /// Məhsulun adı.
    /// </summary>
    public string MehsulAdi { get; set; } = string.Empty;

    /// <summary>
    /// Təhvil alınan miqdar.
    /// </summary>
    public decimal Miqdar { get; set; }

    /// <summary>
    /// Vahidin alış qiyməti.
    /// </summary>
    public decimal BirVahidQiymet { get; set; }

    /// <summary>
    /// Cəmi məbləğ (Miqdar * BirVahidQiymet).
    /// </summary>
    public decimal CemiMebleg { get; set; }

    /// <summary>
    /// Alış sifarişi sətri ID-si (əgər sifariş əsasında yaradılıbsa).
    /// </summary>
    public int? AlisSifarisSetiriId { get; set; }

    /// <summary>
    /// Alış sifarişi sətrinin nömrəsi (əgər sifariş əsasında yaradılıbsa).
    /// </summary>
    public string? AlisSifarisSetiriNomresi { get; set; }
}