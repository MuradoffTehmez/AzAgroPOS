// Fayl: AzAgroPOS.Mentiq/Uslublar/SehifeParametrleri.cs
namespace AzAgroPOS.Mentiq.Uslublar;

/// <summary>
/// Səhifələmə (pagination) parametrləri.
/// Diqqət: Bu sinif səhifə nömrəsi və səhifə ölçüsünü saxlayır.
/// </summary>
public class SehifeParametrleri
{
    private const int MaksimumSehifeOlcusu = 100;
    private int _sehifeOlcusu = 20;

    /// <summary>
    /// Səhifə nömrəsi (1-dən başlayır)
    /// </summary>
    public int SehifeNomresi { get; set; } = 1;

    /// <summary>
    /// Hər səhifədə göstəriləcək qeyd sayı (maksimum 100)
    /// </summary>
    public int SehifeOlcusu
    {
        get => _sehifeOlcusu;
        set => _sehifeOlcusu = (value > MaksimumSehifeOlcusu) ? MaksimumSehifeOlcusu : value;
    }

    /// <summary>
    /// Nə qədər qeydi keçmək lazımdır (SKIP)
    /// </summary>
    public int Kec => (SehifeNomresi - 1) * SehifeOlcusu;
}
