// Fayl: AzAgroPOS.Mentiq/Istisnalar/BiznesQaydasiIstisnasi.cs

namespace AzAgroPOS.Mentiq.Istisnalar;

/// <summary>
/// Biznes qaydaları pozulduqda atılan istisna.
/// Məsələn: stokda kifayət qədər məhsul yoxdur, hesab kilidlənib, icazə yoxdur və s.
/// </summary>
public class BiznesQaydasiIstisnasi : AzAgroPOSIstisnasi
{
    /// <summary>
    /// Pozulan biznes qaydası kodu (kategorizasiya üçün)
    /// </summary>
    public string? QaydaKodu { get; }

    public BiznesQaydasiIstisnasi(string istifadeciMesaji, string? qaydaKodu = null, string? texnikiDetallar = null)
        : base(istifadeciMesaji, texnikiDetallar)
    {
        QaydaKodu = qaydaKodu;
    }
}
