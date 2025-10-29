// Fayl: AzAgroPOS.Varliglar/StokHareketTipi.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Stok hərəkətinin növünü təyin edir.
/// diqqət: Bu enum, anbar əməliyyatlarında məhsulun hansı istiqamətdə hərəkət etdiyini göstərir.
/// qeyd: Hər bir hərəkət tipi, məhsulun anbara daxil olması və ya anbardançıxması ilə bağlıdır.
/// </summary>
public enum StokHareketTipi
{
    /// <summary>
    /// Məhsulun anbara daxil olması (alış, qaytarma və s.)
    /// diqqət: Bu tip, məhsulun anbar stokuna əlavə edildiyini göstərir.
    /// qeyd: Məsələn, tədarükçüdən alış, müştəridən qaytarma, inventarizasiya zamanı artım.
    /// </summary>
    Daxilolma = 1,

    /// <summary>
    /// Məhsulun anbardan çıxması (satış, xarab olma və s.)
    /// diqqət: Bu tip, məhsulun anbar stokdən çıxdığını göstərir.
    /// qeyd: Məsələn, müştəriyə satış, xarab olmuş məhsulun silinməsi, inventarizasiya zamanı azalma.
    /// </summary>
    Cixis = 2
}
