// Fayl: AzAgroPOS.Mentiq/Uslublar/SehifelenmisMelumat.cs
namespace AzAgroPOS.Mentiq.Uslublar;

/// <summary>
/// Səhifələnmiş məlumat nəticəsi.
/// Diqqət: Bu sinif səhifələmə məlumatları ilə birlikdə məlumatları saxlayır.
/// </summary>
/// <typeparam name="T">Məlumat tipi</typeparam>
public class SehifelenmisMelumat<T>
{
    /// <summary>
    /// Cari səhifə nömrəsi
    /// </summary>
    public int CariSehife { get; set; }

    /// <summary>
    /// Ümumi səhifə sayı
    /// </summary>
    public int UmumiSehifeSayi { get; set; }

    /// <summary>
    /// Hər səhifədə göstərilən qeyd sayı
    /// </summary>
    public int SehifeOlcusu { get; set; }

    /// <summary>
    /// Ümumi qeyd sayı
    /// </summary>
    public int UmumiQeydSayi { get; set; }

    /// <summary>
    /// Cari səhifənin məlumatları
    /// </summary>
    public IEnumerable<T> Melumatlar { get; set; } = new List<T>();

    /// <summary>
    /// Əvvəlki səhifə mövcuddurmu?
    /// </summary>
    public bool EvvelkiSehifeVar => CariSehife > 1;

    /// <summary>
    /// Növbəti səhifə mövcuddurmu?
    /// </summary>
    public bool NovbetiSehifeVar => CariSehife < UmumiSehifeSayi;

    /// <summary>
    /// Səhifələnmiş məlumat yaradır
    /// </summary>
    /// <param name="melumatlat">Məlumatlar</param>
    /// <param name="say">Ümumi qeyd sayı</param>
    /// <param name="sehifeNomresi">Cari səhifə nömrəsi</param>
    /// <param name="sehifeOlcusu">Səhifə ölçüsü</param>
    public SehifelenmisMelumat(IEnumerable<T> melumatlar, int say, int sehifeNomresi, int sehifeOlcusu)
    {
        CariSehife = sehifeNomresi;
        UmumiQeydSayi = say;
        SehifeOlcusu = sehifeOlcusu;
        UmumiSehifeSayi = (int)Math.Ceiling(say / (double)sehifeOlcusu);
        Melumatlar = melumatlar;
    }

    /// <summary>
    /// Boş səhifələnmiş məlumat yaradır
    /// </summary>
    public static SehifelenmisMelumat<T> Bos(int sehifeOlcusu = 20)
    {
        return new SehifelenmisMelumat<T>(new List<T>(), 0, 1, sehifeOlcusu);
    }
}
