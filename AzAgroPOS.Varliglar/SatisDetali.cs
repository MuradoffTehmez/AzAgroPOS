// Fayl: AzAgroPOS.Varliglar/SatisDetali.cs
namespace AzAgroPOS.Varliglar;

/// <summary>
/// Bir satış əməliyyatı daxilində hər bir məhsulun detalını təmsil edir.
/// Məsələn, "2 ədəd Alma 1.50 AZN-dən".
/// Diqqət: Bu sinif, satış əməliyyatının hər bir məhsulunu və onun miqdarını, eləcə də satış anındakı qiymətini təmsil edir.
/// Qeyd: Satış detalları, satışın ümumi məbləğini hesablamaq və inventar idarəetməsi üçün vacibdir.
/// </summary>
public class SatisDetali : BazaVarligi
{
    /// <summary>
    /// Aid olduğu satış əməliyyatının ID-si.
    /// Diqqət: Bu ID, satış əməliyyatının unikal identifikatorudur və hər bir satış üçün fərqlidir.
    /// Qeyd: SatisId, satış detalları ilə əlaqəli satış əməliyyatını müəyyən etmək üçün istifadə olunur.
    /// </summary>
    public int SatisId { get; set; }

    /// <summary>
    /// Naviqasiya xüsusiyyəti: Aid olduğu satış.
    /// Diqqət: Bu xüsusiyyət, satış detalının aid olduğu satış əməliyyatını təmsil edir.
    /// Q
    /// </summary>
    public Satis? Satis { get; set; }

    /// <summary>
    /// Satılan məhsulun ID-si.
    /// Diqqət: Bu ID, məhsulun unikal identifikatorudur və hər bir məhsul üçün fərqlidir.
    /// Qeyd: MehsulId, satış detalının hansı məhsula aid olduğunu müəyyən etmək üçün istifadə olunur.
    /// </summary>
    public int MehsulId { get; set; }

    /// <summary>
    /// Naviqasiya xüsusiyyəti: Satılan məhsul.
    /// Diqqət: Bu xüsusiyyət, satış detalının aid olduğu məhsulu təmsil edir.
    /// Qeyd: Mehsul, məhsulun adını, təsvirini və digər əlaqəli məlumatları ehtiva edə bilər.
    /// </summary>
    public Mehsul? Mehsul { get; set; }

    /// <summary>
    /// Satılan məhsulun miqdarı (ədəd, kq və s.).
    /// Diqqət: Bu miqdar, satış əməliyyatında satılan məhsulun miqdarını təmsil edir və müsbət bir dəyər olmalıdır.
    /// Qeyd: Miqdar, inventar idarəetməsi və satışın ümumi məbləğini hesablamaq üçün vacibdir.
    /// </summary>
    public int Miqdar { get; set; }

    /// <summary>
    /// Satış anında məhsulun bir vahidinin qiyməti.
    /// Qiymətlər dəyişə biləcəyi üçün bu məlumat burada saxlanılır.
    /// Diqqət: Bu qiymət, satış əməliyyatında məhsulun bir vahidinin qiymətini təmsil edir və müsbət bir dəyər olmalıdır.
    /// Qeyd: Qiymet, satışın ümumi məbləğini hesablamaq və gəlir analizləri üçün vacibdir.
    /// </summary>
    public decimal Qiymet { get; set; }
}