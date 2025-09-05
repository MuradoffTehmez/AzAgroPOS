// Fayl: AzAgroPOS.Mentiq/DTOs/IsciDto.cs
namespace AzAgroPOS.Mentiq.DTOs;

using AzAgroPOS.Varliglar;
using System;

/// <summary>
/// İşçi məlumatlarını təqdimat qatına ötürmək üçün istifadə olunan DTO.
/// </summary>
public class IsciDto
{
    /// <summary>
    /// İşçinin unikal identifikatoru.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// İşçinin tam adı.
    /// </summary>
    public string TamAd { get; set; } = string.Empty;

    /// <summary>
    /// İşçinin doğum tarixi.
    /// </summary>
    public DateTime DogumTarixi { get; set; } = DateTime.Now.AddYears(-25);

    /// <summary>
    /// İşçinin telefon nömrəsi.
    /// </summary>
    public string TelefonNomresi { get; set; } = string.Empty;

    /// <summary>
    /// İşçinin ünvanı.
    /// </summary>
    public string Unvan { get; set; } = string.Empty;

    /// <summary>
    /// İşçinin email ünvanı.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// İşçinin işə başlama tarixi.
    /// </summary>
    public DateTime IseBaslamaTarixi { get; set; } = DateTime.Now;

    /// <summary>
    /// İşçinin maaşı.
    /// </summary>
    public decimal Maas { get; set; } = 0;

    /// <summary>
    /// İşçinin vəzifəsi.
    /// </summary>
    public string Vezife { get; set; } = string.Empty;

    /// <summary>
    /// İşçinin departamenti.
    /// </summary>
    public string Departament { get; set; } = string.Empty;

    /// <summary>
    /// İşçinin statusu.
    /// </summary>
    public IsciStatusu Status { get; set; } = IsciStatusu.Aktiv;

    /// <summary>
    /// İşçinin şəxsiyyət vəsiqəsinin seriya nömrəsi.
    /// </summary>
    public string SvsNo { get; set; } = string.Empty;

    /// <summary>
    /// İşçinin qeydiyyat ünvanı.
    /// </summary>
    public string QeydiyyatUnvani { get; set; } = string.Empty;

    /// <summary>
    /// İşçinin bank məlumatları.
    /// </summary>
    public string BankMəlumatları { get; set; } = string.Empty;
}