// Fayl: AzAgroPOS.Mentiq/Istisnalar/VerilenlerBazasiIstisnasi.cs

namespace AzAgroPOS.Mentiq.Istisnalar;

/// <summary>
/// Verilənlər bazası əməliyyatları zamanı baş verən istisna.
/// Məsələn: bağlantı kəsildi, constraint pozuldu, timeout baş verdi və s.
/// </summary>
public class VerilenlerBazasiIstisnasi : AzAgroPOSIstisnasi
{
    /// <summary>
    /// SQL xəta kodu (əgər SQL Server exception-dırsa)
    /// </summary>
    public int? SqlXetaKodu { get; }

    public VerilenlerBazasiIstisnasi(string istifadeciMesaji, int? sqlXetaKodu = null, string? texnikiDetallar = null, Exception? innerException = null)
        : base(istifadeciMesaji, texnikiDetallar, innerException)
    {
        SqlXetaKodu = sqlXetaKodu;
    }
}
