// Fayl: AzAgroPOS.Varliglar/IstifadeciSessiyasi.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// İstifadəçi sessiyalarını izləmək üçün entity
/// </summary>
public class IstifadeciSessiyasi : BazaVarligi
{
    /// <summary>
    /// İstifadəçi ID (Foreign Key)
    /// </summary>
    public int IstifadeciId { get; set; }

    /// <summary>
    /// Sessiya başlama tarixi
    /// </summary>
    public DateTime BaslamaTarixi { get; set; }

    /// <summary>
    /// Son aktivlik tarixi
    /// </summary>
    public DateTime SonAktivlikTarixi { get; set; }

    /// <summary>
    /// Sessiya bitmə tarixi (timeout)
    /// </summary>
    public DateTime? BitməTarixi { get; set; }

    /// <summary>
    /// Sessiya aktiv statusu
    /// </summary>
    public bool Aktivdir { get; set; } = true;

    /// <summary>
    /// IP ünvanı
    /// </summary>
    public string? IpUnvani { get; set; }

    /// <summary>
    /// Kompüter adı
    /// </summary>
    public string? KomputerAdi { get; set; }

    /// <summary>
    /// Navigation property: İstifadəçi
    /// </summary>
    public Istifadeci? Istifadeci { get; set; }
}
