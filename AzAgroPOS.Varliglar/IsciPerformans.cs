// Fayl: AzAgroPOS.Varliglar/IsciPerformans.cs
namespace AzAgroPOS.Varliglar;

using System;

/// <summary>
/// İşçinin performansını izləmək üçün istifadə olunan varlıq sinifi.
/// Bu sinif, işçinin aylıq/vəzifəli performansını qiymətləndirmək üçün istifadə olunur.
/// </summary>
public class IsciPerformans : BazaVarligi
{
    /// <summary>
    /// Performans qeydinin aid olduğu işçinin ID-si.
    /// </summary>
    public int IsciId { get; set; }

    /// <summary>
    /// Performans qeydinin aid olduğu işçi.
    /// </summary>
    public Isci? Isci { get; set; }

    /// <summary>
    /// Performans qeydinin tarixi.
    /// </summary>
    public DateTime Tarix { get; set; }

    /// <summary>
    /// Performans qiymətləndirmə dövrü (məsələn, "2023-cü il avqust ayı").
    /// </summary>
    public string QeydDovru { get; set; } = string.Empty;

    /// <summary>
    /// Performansın qiyməti (1-10 arası).
    /// </summary>
    public int Qiymet { get; set; }

    /// <summary>
    /// Performansla bağlı əlavə qeydlər və şərhlər.
    /// </summary>
    public string Qeydler { get; set; } = string.Empty;

    /// <summary>
    /// Performans əmsalı (ümumi iş saatı, tamamlanan tapşırıq sayı və s.).
    /// </summary>
    public string Emsallar { get; set; } = string.Empty;

    /// <summary>
    /// Performansla bağlı təkliflər (təkmilləşdirmə, təlim və s.).
    /// </summary>
    public string Teklifler { get; set; } = string.Empty;
}