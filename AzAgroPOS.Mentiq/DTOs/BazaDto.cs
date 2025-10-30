// Fayl: AzAgroPOS.Mentiq/DTOs/BazaDto.cs
namespace AzAgroPOS.Mentiq.DTOs;

/// <summary>
/// Bütün DTO-lar üçün əsas sinif
/// diqqət: Bu sinif digər DTO siniflərinin miras aldığı əsas sinifdir
/// qeyd: Bütün DTO-lar bu sinifdən miras ala bilər
/// </summary>
public abstract class BazaDto
{
    /// <summary>
    /// Unikal identifikator
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Yaradılış tarixi
    /// </summary>
    public DateTime YaradilmaTarixi { get; set; }
    
    /// <summary>
    /// Dəyişdirilmə tarixi
    /// </summary>
    public DateTime? DeyisdirilmeTarixi { get; set; }
}