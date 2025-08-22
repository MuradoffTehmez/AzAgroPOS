// Fayl: AzAgroPOS.Varliglar/Musteri.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Nisyə və ya digər əməliyyatlar üçün qeydiyyata alınan müştəriləri təmsil edir.
/// 
/// 
/// </summary>
public class Musteri : BazaVarligi
{
    /// <summary>
    /// Müştərinin tam adı (Ad, Soyad, Ata adı).
    /// </summary>
    public string TamAd { get; set; } = string.Empty;

    /// <summary>
    /// Müştərinin telefon nömrəsi.
    /// 
    /// </summary>
    public string TelefonNomresi { get; set; } = string.Empty;

    /// <summary>
    /// Müştərinin ünvanı.
    /// </summary>
    public string? Unvan { get; set; }

    /// <summary>
    /// Müştərinin ümumi nisyə borcu.
    /// </summary>
    public decimal UmumiBorc { get; set; }
}