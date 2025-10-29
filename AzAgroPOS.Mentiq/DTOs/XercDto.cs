// Fayl: AzAgroPOS.Mentiq/DTOs/XercDto.cs
namespace AzAgroPOS.Mentiq.DTOs;

using AzAgroPOS.Varliglar;
using System;

/// <summary>
/// Xərc məlumatlarını daşıyan DTO (Data Transfer Object)
/// diqqət: Bu sinif xərc əməliyyatları üçün məlumat transferi üçündür.
/// qeyd: UI və biznes məntiqi arasında məlumat ötürmək üçün istifadə olunur.
/// </summary>
public class XercDto
{
    /// <summary>
    /// Xərcin ID-si (yeni yaradılan xərclər üçün 0 olur)
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Xərcin növü (kategoriya)
    /// </summary>
    public XercNovu Novu { get; set; }

    /// <summary>
    /// Xərcin adı/təsviri
    /// </summary>
    public string? Ad { get; set; }

    /// <summary>
    /// Xərcin məbləği
    /// </summary>
    public decimal Mebleg { get; set; }

    /// <summary>
    /// Xərcin baş verdiyi tarix
    /// </summary>
    public DateTime Tarix { get; set; }

    /// <summary>
    /// Xərcə aid sənəd nömrəsi (istəyə görə)
    /// </summary>
    public string? SenedNomresi { get; set; }

    /// <summary>
    /// Xərcə aid qeyd
    /// </summary>
    public string? Qeyd { get; set; }

    /// <summary>
    /// Xərci qeydə alan istifadəçinin adı
    /// </summary>
    public string? IstifadeciAdi { get; set; }
}