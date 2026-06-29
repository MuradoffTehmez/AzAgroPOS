// Fayl: AzAgroPOS.Teqdimat/Yardimcilar/AktivSessiya.cs

using AzAgroPOS.Mentiq.DTOs;

namespace AzAgroPOS.Teqdimat.Yardimcilar;
/// <summary>
/// Proqram boyunca aktiv olan istifadəçi və növbə məlumatlarını saxlayan statik sinif.
/// </summary>
public static class AktivSessiya
{
    /// <summary>
    /// Sistemə daxil olmuş hazırkı istifadəçi.
    /// </summary>
    public static IstifadeciDto? AktivIstifadeci { get; set; }

    /// <summary>
    /// Kassirin açdığı hazırkı aktiv növbənin ID-si.
    /// </summary>
    public static int? AktivNovbeId { get; set; }
}