// Fayl: AzAgroPOS.Teqdimat/Yardimcilar/AktivSessiya.cs
namespace AzAgroPOS.Teqdimat.Yardimcilar;
using AzAgroPOS.Mentiq.DTOs;

/// <summary>
/// Proqram boyunca aktiv olan istifadəçi məlumatlarını saxlayan statik sinif.
/// </summary>
public static class AktivSessiya
{
    public static IstifadeciDto? AktivIstifadeci { get; set; }
}


