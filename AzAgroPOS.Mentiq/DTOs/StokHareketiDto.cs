// Fayl: AzAgroPOS.Mentiq/DTOs/StokHareketiDto.cs
namespace AzAgroPOS.Mentiq.DTOs;

using System;

/// <summary>
/// Stok hərəkəti məlumatları üçün DTO
/// </summary>
public class StokHareketiDto
{
    /// <summary>
    /// Stok hərəkəti ID-si
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Hərəkət tarixi
    /// </summary>
    public DateTime Tarix { get; set; }

    /// <summary>
    /// İstifadəçi adı
    /// </summary>
    public string? IstifadeciAdi { get; set; }

    /// <summary>
    /// Əməliyyat növü (ARTIRMA, AZALTMA, DUZELIS və s.)
    /// </summary>
    public string? EmeliyyatNovu { get; set; }

    /// <summary>
    /// Köhnə stok miqdarı (əməliyyatdan əvvəl)
    /// </summary>
    public decimal KohneStok { get; set; }

    /// <summary>
    /// Dəyişiklik miqdarı (+/-)
    /// </summary>
    public decimal DeyisiklikMiqdari { get; set; }

    /// <summary>
    /// Yeni stok miqdarı (əməliyyatdan sonra)
    /// </summary>
    public decimal YeniStok { get; set; }

    /// <summary>
    /// Qeyd/səbəb
    /// </summary>
    public string? Qeyd { get; set; }

    /// <summary>
    /// Məhsul ID-si
    /// </summary>
    public int MehsulId { get; set; }

    /// <summary>
    /// Məhsul adı
    /// </summary>
    public string? MehsulAdi { get; set; }
}
