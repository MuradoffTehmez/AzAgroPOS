// Fayl: AzAgroPOS.Varliglar/GirisLoquKaydi.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Giriş cəhdlərini audit etmək üçün loq kaydi
/// </summary>
public class GirisLoquKaydi : BazaVarligi
{
    /// <summary>
    /// İstifadəçi adı (giriş cəhdi edilən)
    /// </summary>
    public string IstifadeciAdi { get; set; } = string.Empty;

    /// <summary>
    /// Giriş cəhdi uğurlu olub-olmamağı
    /// </summary>
    public bool Ugurlu { get; set; }

    /// <summary>
    /// Giriş cəhdi tarixi
    /// </summary>
    public DateTime CehdTarixi { get; set; }

    /// <summary>
    /// IP ünvanı
    /// </summary>
    public string? IpUnvani { get; set; }

    /// <summary>
    /// Kompüter adı
    /// </summary>
    public string? KomputerAdi { get; set; }

    /// <summary>
    /// Uğursuz olarsa səbəbi
    /// </summary>
    public string? UgursuzluqSebebi { get; set; }
}
