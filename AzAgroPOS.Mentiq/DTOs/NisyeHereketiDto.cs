// Fayl: AzAgroPOS.Mentiq/DTOs/NisyeHereketiDto.cs
namespace AzAgroPOS.Mentiq.DTOs;

using AzAgroPOS.Varliglar;
/// <summary>
/// bu class, nisye hərəkətlərini təmsil edir.
/// </summary>
public class NisyeHereketiDto
{
    /// <summary>
    /// Tarix, hərəkətin baş verdiyi tarixi saxlayır.
    /// </summary>
    public DateTime Tarix { get; set; }
    /// <summary>
    /// EmeliyyatNovu, hərəkətin növünü (məsələn, borc, ödəniş və s.) saxlayır.
    /// </summary>
    public string EmeliyyatNovu { get; set; } = string.Empty;
    /// <summary>
    /// Mebleg, hərəkət üçün ödənilən və ya alınan məbləği saxlayır.
    /// </summary>
    public decimal Mebleg { get; set; }
    /// <summary>
    /// qeyd, hərəkət haqqında əlavə məlumat və ya qeydləri saxlayır.
    /// </summary>
    public string Qeyd { get; set; } = string.Empty;
}