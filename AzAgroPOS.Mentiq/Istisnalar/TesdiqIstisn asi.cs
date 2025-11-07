// Fayl: AzAgroPOS.Mentiq/Istisnalar/TesdiqIstisnasi.cs

namespace AzAgroPOS.Mentiq.Istisnalar;

/// <summary>
/// Məlumat təsdiqi (validation) uğursuz olduqda atılan istisna.
/// Məsələn: boş sahələr, yanlış format, uyğun olmayan məlumatlar və s.
/// </summary>
public class TesdiqIstisnasi : AzAgroPOSIstisnasi
{
    /// <summary>
    /// Təsdiq uğursuz olan sahə adı (əgər varsa)
    /// </summary>
    public string? SaheAdi { get; }

    public TesdiqIstisnasi(string istifadeciMesaji, string? saheAdi = null, string? texnikiDetallar = null)
        : base(istifadeciMesaji, texnikiDetallar)
    {
        SaheAdi = saheAdi;
    }
}
