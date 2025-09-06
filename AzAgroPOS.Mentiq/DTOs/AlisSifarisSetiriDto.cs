// Fayl: AzAgroPOS.Mentiq/DTOs/AlisSifarisSetiriDto.cs
namespace AzAgroPOS.Mentiq.DTOs;
/// <summary>
/// Alış sifarişi sətiri məlumatlarını təqdimat qatına ötürmək üçün istifadə olunan DTO.
/// </summary>
public class AlisSifarisSetiriDto
{
    /// <summary>
    /// Alış sifarişi sətrinin unikal identifikatoru.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Alış sifarişi ID-si.
    /// </summary>
    public int AlisSifarisId { get; set; }

    /// <summary>
    /// Məhsul ID-si.
    /// </summary>
    public int MehsulId { get; set; }

    /// <summary>
    /// Məhsulun adı.
    /// </summary>
    public string MehsulAdi { get; set; } = string.Empty;

    /// <summary>
    /// Sifariş edilən miqdar.
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
    /// Təhvil alınan miqdar.
    /// </summary>
    public decimal TehvilAlinanMiqdar { get; set; } = 0;

    /// <summary>
    /// Qalan miqdar (Sifariş edilən miqdar - Təhvil alınan miqdar).
    /// </summary>
    public decimal QalanMiqdar { get; set; }
}