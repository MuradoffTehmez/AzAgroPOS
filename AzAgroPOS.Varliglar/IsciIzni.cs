// Fayl: AzAgroPOS.Varliglar/IsciIzni.cs
namespace AzAgroPOS.Varliglar;

using System;

/// <summary>
/// İşçinin məzuniyyət və digər icazələrini izləmək üçün istifadə olunan varlıq sinifi.
/// Bu sinif, işçinin məzuniyyət, xəstəlik icazəsi və digər icazələrini qeyd etmək üçün istifadə olunur.
/// </summary>
public class IsciIzni : BazaVarligi
{
    /// <summary>
    /// İznin aid olduğu işçinin ID-si.
    /// </summary>
    public int IsciId { get; set; }

    /// <summary>
    /// İznin aid olduğu işçi.
    /// </summary>
    public Isci? Isci { get; set; }

    /// <summary>
    /// İznin növü (Məzuniyyət, Xəstəlik, Məzuniyyətsiz, və s.).
    /// </summary>
    public IzinNovu IzinNovu { get; set; }

    /// <summary>
    /// İznin başlama tarixi.
    /// </summary>
    public DateTime BaslamaTarixi { get; set; }

    /// <summary>
    /// İznin bitmə tarixi.
    /// </summary>
    public DateTime BitmeTarixi { get; set; }

    /// <summary>
    /// İznin ümumi günü.
    /// </summary>
    public int IzinGunu { get; set; }

    /// <summary>
    /// İznin səbəbi.
    /// </summary>
    public string Sebeb { get; set; } = string.Empty;

    /// <summary>
    /// İznin statusu (Təsdiqlənib, Gözləmədə, Rədd edilib və s.).
    /// </summary>
    public IzinStatusu Status { get; set; }

    /// <summary>
    /// İznin təsdiq edən şəxsin ID-si.
    /// </summary>
    public int? TesdiqEdenIsciId { get; set; }

    /// <summary>
    /// İznin təsdiq edən şəxs.
    /// </summary>
    public Isci? TesdiqEdenIsci { get; set; }

    /// <summary>
    /// İznin təsdiq tarixi.
    /// </summary>
    public DateTime? TesdiqTarixi { get; set; }

    /// <summary>
    /// İznin təsdiq edilməsi ilə bağlı əlavə qeydlər.
    /// </summary>
    public string Qeydler { get; set; } = string.Empty;
}