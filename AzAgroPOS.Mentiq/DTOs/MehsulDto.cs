// Fayl: AzAgroPOS.Mentiq/DTOs/MehsulDto.cs
using AzAgroPOS.Varliglar;

namespace AzAgroPOS.Mentiq.DTOs;

/// <summary>
/// Məhsul məlumatlarını Təqdimat (UI) qatına ötürmək üçün istifadə olunan obyekt.
/// </summary>
public class MehsulDto
{
    /// <summary>
    /// İstifadəçi interfeysində göstəriləcək məhsulun unikal identifikatoru.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Ad (istifadəçi interfeysində göstəriləcək məhsulun adı).
    /// </summary>
    public string Ad { get; set; } = string.Empty;
    /// <summary>
    /// Alış qiyməti (müəyyən məhsulun alış qiyməti).
    /// </summary>
    public decimal AlisQiymeti { get; set; }
    /// <summary>
    /// Stok kodu (müəyyən məhsulu tanımaq üçün istifadə olunan unikal kod).
    /// </summary>
    public string StokKodu { get; set; } = string.Empty;
    /// <summary>
    /// Barkod (müəyyən məhsulu tanımaq üçün istifadə olunan barkod).
    /// </summary>
    public string Barkod { get; set; } = string.Empty;
    /// <summary>
    /// Satış qiyməti (müəyyən məhsulun satış qiyməti).
    /// </summary>
    public decimal SatisQiymeti { get; set; }
    /// <summary>
    /// Mövcud say (müəyyən məhsulun anbarında mövcud olan miqdarı).
    /// </summary>
    public int MovcudSay { get; set; }
    /// <summary>
    /// olcu vahidi (müəyyən məhsulun ölçü vahidi, məsələn, ədəd, kiloqram, litr və s.).
    /// </summary>
    public OlcuVahidi OlcuVahidi { get; set; }
    /// <summary>
    /// Satış qiymətinin formatlanmış versiyası (istifadəçi interfeysində göstəriləcək).
    /// </summary>
    public string SatisQiymetiStr => $"{SatisQiymeti:N2} AZN";
    /// <summary>
    /// olcu vahidinin formatlanmış versiyası (istifadəçi interfeysində göstəriləcək).
    /// </summary>
    public string OlcuVahidiStr => OlcuVahidi.ToString();
}