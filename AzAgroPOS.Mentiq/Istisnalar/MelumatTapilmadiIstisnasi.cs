// Fayl: AzAgroPOS.Mentiq/Istisnalar/MelumatTapilmadiIstisnasi.cs

namespace AzAgroPOS.Mentiq.Istisnalar;

/// <summary>
/// Axtarılan məlumat verilənlər bazasında tapılmadıqda atılan istisna.
/// Məsələn: istifadəçi tapılmadı, məhsul tapılmadı və s.
/// </summary>
public class MelumatTapilmadiIstisnasi : AzAgroPOSIstisnasi
{
    /// <summary>
    /// Axtarılan entity növü (məsələn: "İstifadəçi", "Məhsul")
    /// </summary>
    public string? EntityNovu { get; }

    /// <summary>
    /// Axtarılan identifikator (məsələn: ID, barkod, istifadəçi adı)
    /// </summary>
    public object? Identifikator { get; }

    public MelumatTapilmadiIstisnasi(string istifadeciMesaji, string? entityNovu = null, object? identifikator = null, string? texnikiDetallar = null)
        : base(istifadeciMesaji, texnikiDetallar)
    {
        EntityNovu = entityNovu;
        Identifikator = identifikator;
    }
}
