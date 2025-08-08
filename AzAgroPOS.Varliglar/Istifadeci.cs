// Fayl: AzAgroPOS.Varliglar/Istifadeci.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Sistemə daxil ola bilən istifadəçiləri (personalı) təmsil edir.
/// </summary>
public class Istifadeci : BazaVarligi
{
    /// <summary>
    /// İstifadəçinin sistemə daxil olmaq üçün istifadə etdiyi ad.
    /// </summary>
    public string IstifadeciAdi { get; set; } = string.Empty;

    /// <summary>
    /// İstifadəçinin parolu. Təhlükəsizlik üçün hash formatında saxlanmalıdır.
    /// </summary>
    public string ParolHash { get; set; } = string.Empty;

    /// <summary>
    /// İşçinin tam adı.
    /// </summary>
    public string TamAd { get; set; } = string.Empty;

    /// <summary>
    /// İstifadəçinin aid olduğu rolun ID-si.
    /// </summary>
    public int RolId { get; set; }

    /// <summary>
    /// Naviqasiya xüsusiyyəti: İstifadəçinin rolu.
    /// </summary>
    public Rol? Rol { get; set; }

    /// <summary>
    /// Bu işçiyə təyin edilmiş təmir sifarişlərinin siyahısı.
    /// </summary>
    public ICollection<Temir> TemirSifarisleri { get; set; } = new List<Temir>();
}