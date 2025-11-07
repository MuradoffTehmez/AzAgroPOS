// Fayl: AzAgroPOS.Mentiq/Istisnalar/TehlukesizlikIstisnasi.cs

namespace AzAgroPOS.Mentiq.Istisnalar;

/// <summary>
/// Təhlükəsizlik əməliyyatları zamanı baş verən istisna.
/// Məsələn: autentifikasiya uğursuz oldu, icazə yoxdur, sessiya bitib və s.
/// </summary>
public class TehlukesizlikIstisnasi : AzAgroPOSIstisnasi
{
    /// <summary>
    /// Təhlükəsizlik xətasının növü
    /// </summary>
    public TehlukesizlikXetasiNovu XetaNovu { get; }

    public TehlukesizlikIstisnasi(string istifadeciMesaji, TehlukesizlikXetasiNovu xetaNovu, string? texnikiDetallar = null)
        : base(istifadeciMesaji, texnikiDetallar)
    {
        XetaNovu = xetaNovu;
    }
}

/// <summary>
/// Təhlükəsizlik xətalarının növləri
/// </summary>
public enum TehlukesizlikXetasiNovu
{
    /// <summary>
    /// İstifadəçi adı və ya parol yanlışdır
    /// </summary>
    YanlisIstifadeciVeyaParol,

    /// <summary>
    /// Hesab kilidlənib
    /// </summary>
    HesabKilidlenmə,

    /// <summary>
    /// Hesab deaktiv edilib
    /// </summary>
    HesabDeaktiv,

    /// <summary>
    /// İcazə yoxdur (Authorization)
    /// </summary>
    IcazeYoxdur,

    /// <summary>
    /// Sessiya bitib və ya mövcud deyil
    /// </summary>
    SessiyaBitib
}
