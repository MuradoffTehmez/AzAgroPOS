// Fayl: AzAgroPOS.Mentiq/DTOs/ZHesabatDto.cs
namespace AzAgroPOS.Mentiq.DTOs;
using System;

/// <summary>
/// ZHesabatDto, satış hesabatını saxlamaq üçün istifadə olunan məlumatları ehtiva edir.
/// Bu cür hesabatlar, kassir tərəfindən açılan və bağlanan satış hesablarını göstərmək üçün istifadə olunur.
/// </summary>
public class ZHesabatDto
{
    /// <summary>
    /// Açılış tarixi və saatı (hesabatın açıldığı tarix və saat).
    /// </summary>
    public DateTime AcilmaTarixi { get; set; }
    /// <summary>
    /// Bağlanma tarixi və saatı (hesabatın bağlandığı tarix və saat).
    /// </summary>
    public DateTime BaglanmaTarixi { get; set; }
    /// <summary>
    /// Kassir adı (hesabatı hazırlayan kassirin adı).
    /// </summary>
    public string KassirAdi { get; set; } = string.Empty;
    /// <summary>
    /// Başlanğıc məbləğ (hesabatın açıldığı zaman kassada olan başlanğıc məbləği).
    /// </summary>
    public decimal BaslangicMebleg { get; set; }
    /// <summary>
    /// Satış sayı (hesabat dövründə həyata keçirilən satışların sayı).
    /// </summary>
    public int SatisSayi { get; set; }
    /// <summary>
    /// nəğd satışlar (hesabat dövründə nağd şəkildə həyata keçirilən satışların məbləği).
    /// </summary>
    public decimal NagdSatislar { get; set; }
    /// <summary>
    /// Kart satışlar (hesabat dövründə kartla həyata keçirilən satışların məbləği).
    /// </summary>
    public decimal KartSatislar { get; set; }
    /// <summary>
    /// Cəmi satışlar (hesabat dövründə həyata keçirilən bütün satışların cəmi məbləği).
    /// </summary>
    public decimal CemiSatislar => NagdSatislar + KartSatislar;
    /// <summary>
    /// Gözlənilən məbləğ (hesabatın bağlanması zamanı kassada olması gözlənilən məbləğ).
    /// </summary>
    public decimal GozlenilenMebleg { get; set; }
    /// <summary>
    /// Faktiki məbləğ (hesabatın bağlanması zamanı kassada faktiki olaraq olan məbləğ).
    /// </summary>
    public decimal FaktikiMebleg { get; set; }
    /// <summary>
    /// Fərq (gözlənilən və faktiki məbləğ arasındakı fərq).
    /// </summary>
    public decimal Ferq => FaktikiMebleg - GozlenilenMebleg;
}