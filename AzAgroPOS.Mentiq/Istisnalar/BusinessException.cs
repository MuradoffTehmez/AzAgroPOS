// Fayl: AzAgroPOS.Mentiq/Istisnalar/BusinessException.cs
namespace AzAgroPOS.Mentiq.Istisnalar;

using System;

/// <summary>
/// Biznes məntiqi xətaları üçün istisna sinifi.
/// diqqət: Bu xəta istifadəçiyə göstərilə bilən, oxunaqlı mesajlar daşıyır.
/// qeyd: Texniki xətalardan (məsələn, SqlException) fərqli olaraq, bu xəta istifadəçi səviyyəsində izah edilir.
/// </summary>
public class BusinessException : Exception
{
    /// <summary>
    /// Xətanın növü (Xəbərdarlıq, Səhv və s.)
    /// </summary>
    public XetaTipi XetaTipi { get; set; }

    /// <summary>
    /// Xətanın baş verdiyi modul və ya səhifə
    /// </summary>
    public string? Modul { get; set; }

    /// <summary>
    /// İstifadəçi üçün əlavə tövsiyyə və ya izahat
    /// </summary>
    public string? Tovsiyye { get; set; }

    /// <summary>
    /// BusinessException yaradır.
    /// </summary>
    /// <param name="mesaj">İstifadəçiyə göstəriləcək mesaj</param>
    /// <param name="xetaTipi">Xətanın növü (standart: Səhv)</param>
    /// <param name="modul">Xətanın baş verdiyi modul</param>
    /// <param name="tovsiyye">İstifadəçi üçün əlavə tövsiyyə</param>
    public BusinessException(string mesaj, XetaTipi xetaTipi = XetaTipi.Xeta, string? modul = null, string? tovsiyye = null)
        : base(mesaj)
    {
        XetaTipi = xetaTipi;
        Modul = modul;
        Tovsiyye = tovsiyye;
    }

    /// <summary>
    /// BusinessException yaradır (inner exception ilə).
    /// </summary>
    /// <param name="mesaj">İstifadəçiyə göstəriləcək mesaj</param>
    /// <param name="innerException">Daxili texniki xəta</param>
    /// <param name="xetaTipi">Xətanın növü (standart: Səhv)</param>
    /// <param name="modul">Xətanın baş verdiyi modul</param>
    /// <param name="tovsiyye">İstifadəçi üçün əlavə tövsiyyə</param>
    public BusinessException(string mesaj, Exception innerException, XetaTipi xetaTipi = XetaTipi.Xeta, string? modul = null, string? tovsiyye = null)
        : base(mesaj, innerException)
    {
        XetaTipi = xetaTipi;
        Modul = modul;
        Tovsiyye = tovsiyye;
    }
}

/// <summary>
/// Xətanın növü
/// </summary>
public enum XetaTipi
{
    /// <summary>
    /// Məlumat xəbəri (mavi ikona)
    /// </summary>
    Melumat = 1,

    /// <summary>
    /// Xəbərdarlıq (sarı ikona)
    /// </summary>
    Xeberdarliq = 2,

    /// <summary>
    /// Səhv (qırmızı ikona)
    /// </summary>
    Xeta = 3
}
