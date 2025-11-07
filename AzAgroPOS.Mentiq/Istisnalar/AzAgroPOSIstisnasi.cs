// Fayl: AzAgroPOS.Mentiq/Istisnalar/AzAgroPOSIstisnasi.cs

namespace AzAgroPOS.Mentiq.Istisnalar;

/// <summary>
/// AzAgroPOS tətbiqində istifadə olunan bütün custom exception-ların baza sinfi.
/// </summary>
public abstract class AzAgroPOSIstisnasi : Exception
{
    /// <summary>
    /// İstifadəçiyə göstəriləcək mesaj (user-friendly)
    /// </summary>
    public string IstifadeciMesaji { get; }

    /// <summary>
    /// Texniki detallar (log üçün)
    /// </summary>
    public string? TexnikiDetallar { get; }

    protected AzAgroPOSIstisnasi(string istifadeciMesaji, string? texnikiDetallar = null, Exception? innerException = null)
        : base(istifadeciMesaji, innerException)
    {
        IstifadeciMesaji = istifadeciMesaji;
        TexnikiDetallar = texnikiDetallar;
    }
}
