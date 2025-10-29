// Fayl: AzAgroPOS.Varliglar/SenedNovu.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Stok hərəkətinə səbəb olan sənədin növünü təyin edir.
/// diqqət: Bu enum, hər bir stok hərəkətinin hansı əməliyyatla bağlı olduğunu göstərir.
/// qeyd: Sənəd növü, stok hərəkətinin mənbəyini izləməyə kömək edir.
/// </summary>
public enum SenedNovu
{
    /// <summary>
    /// Alış sənədi - Tədarükçüdən məhsul alışı
    /// diqqət: Bu sənəd növü, tədarükçüdən məhsul alındığını və anbara daxil olduğunu göstərir.
    /// qeyd: Alış sənədi, AlısSenedi cədvəlinə istinad edir.
    /// </summary>
    Alis = 1,

    /// <summary>
    /// Satış sənədi - Müştəriyə məhsul satışı
    /// diqqət: Bu sənəd növü, müştəriyə məhsul satıldığını və anbardan çıxdığını göstərir.
    /// qeyd: Satış sənədi, Satis cədvəlinə istinad edir.
    /// </summary>
    Satis = 2,

    /// <summary>
    /// Qaytarma sənədi - Müştəridən məhsul qaytarması və ya tədarükçüyə məhsul qaytarılması
    /// diqqət: Bu sənəd növü, məhsulun geri qaytarıldığını göstərir.
    /// qeyd: Qaytarma sənədi, Qaytarma cədvəlinə istinad edir.
    /// </summary>
    Qaytarma = 3,

    /// <summary>
    /// İnventarizasiya - Anbar sayımı nəticəsində düzəliş
    /// diqqət: Bu sənəd növü, fiziki sayım nəticəsində stokun düzəldildiyini göstərir.
    /// qeyd: İnventarizasiya, real stok ilə sistem stoku arasındakı fərqi aradan qaldırır.
    /// </summary>
    Inventarizasiya = 4,

    /// <summary>
    /// Düzəliş (Artırma) - Manuel stok artırımı
    /// diqqət: Bu sənəd növü, xüsusi hallarda stokun əl ilə artırıldığını göstərir.
    /// qeyd: Məsələn, uçot xətası düzəlişi və ya hədiyyə məhsul daxil olması.
    /// </summary>
    DuzeltmeArtirim = 5,

    /// <summary>
    /// Düzəliş (Azalma) - Manuel stok azalması
    /// diqqət: Bu sənəd növü, xüsusi hallarda stokun əl ilə azaldıldığını göstərir.
    /// qeyd: Məsələn, məhsul xarab olması, oğurluq, uçot xətası düzəlişi.
    /// </summary>
    DuzeltmeAzalma = 6
}
