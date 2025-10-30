// Fayl: AzAgroPOS.Varliglar/Isci.cs
namespace AzAgroPOS.Varliglar;

using System;
using System.Collections.Generic;

/// <summary>
/// İşçilərin əsas məlumatlarını saxlayan varlıq sinifi.
/// Bu sinif, işçinin şəxsi məlumatları, iş yeri məlumatları və digər əlaqəli məlumatları ehtiva edir.
/// </summary>
public class Isci : BazaVarligi
{
    /// <summary>
    /// İşçinin tam adı.
    /// </summary>
    public string TamAd { get; set; } = string.Empty;

    /// <summary>
    /// İşçinin doğum tarixi.
    /// </summary>
    public DateTime DogumTarixi { get; set; }

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
    public DateTime IseBaslamaTarixi { get; set; }

    /// <summary>
    /// İşçinin maaşı.
    /// </summary>
    public decimal Maas { get; set; }

    /// <summary>
    /// İşçinin vəzifəsi.
    /// </summary>
    public string Vezife { get; set; } = string.Empty;

    /// <summary>
    /// İşçinin departamenti.
    /// </summary>
    public string Departament { get; set; } = string.Empty;

    /// <summary>
    /// İşçinin statusu (Aktiv, Çıxış edib, Məzuniyyətdə və s.).
    /// </summary>
    public IsciStatusu Status { get; set; }

    /// <summary>
    /// İşçinin şəxsiyyət vəsiqəsinin seriya nömrəsi.
    /// </summary>
    public string SvsNo { get; set; } = string.Empty;

    /// <summary>
    /// İşçinin qeydiyyat ünvanı.
    /// </summary>
    public string QeydiyyatUnvani { get; set; } = string.Empty;

    /// <summary>
    /// İşçinin bank məlumatları (hesab nömrəsi və s.).
    /// </summary>
    public string BankMəlumatları { get; set; } = string.Empty;

    /// <summary>
    /// Bu işçiyə aid performans qeydləri.
    /// </summary>
    public ICollection<IsciPerformans> PerformansQeydleri { get; set; } = new List<IsciPerformans>();

    /// <summary>
    /// Bu işçiyə aid məzuniyyət/icazə qeydləri.
    /// </summary>
    public ICollection<IsciIzni> IzinQeydleri { get; set; } = new List<IsciIzni>();

    /// <summary>
    /// Bu işçiyə aid əmək haqqı qeydləri.
    /// </summary>
    public ICollection<EmekHaqqi> EmekHaqqiQeydleri { get; set; } = new List<EmekHaqqi>();

    /// <summary>
    /// Bu işçiyə aid sistem giriş məlumatları (əgər varsa).
    /// </summary>
    public Istifadeci? SistemIstifadecisi { get; set; }
}