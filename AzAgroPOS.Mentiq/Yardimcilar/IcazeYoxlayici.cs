// Fayl: AzAgroPOS.Mentiq/Yardimcilar/IcazeYoxlayici.cs
namespace AzAgroPOS.Mentiq.Yardimcilar;

using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Varliglar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Mərkəzləşdirilmiş icazə yoxlama sistemi
/// diqqət: Bu sinif singleton pattern ilə işləyir və bütün tətbiqat boyu istifadəçi icazələrini idarə edir
/// qeyd: Login zamanı AktivIstifadeciniTeyinEt çağırılmalıdır
/// rol: Bütün formalarda və əməliyyatlarda icazə yoxlamasını asanlaşdırır
/// </summary>
public sealed class IcazeYoxlayici
{
    private static IcazeYoxlayici? _instance;
    private static readonly object _lock = new object();

    private Istifadeci? _aktivIstifadeci;
    private IcazeManager? _icazeManager;
    private HashSet<string> _istifadeciIcazeleri;

    /// <summary>
    /// Hazırda aktiv olan istifadəçi
    /// </summary>
    public Istifadeci? AktivIstifadeci => _aktivIstifadeci;

    /// <summary>
    /// İstifadəçinin rol adı
    /// </summary>
    public string? IstifadeciRolu => _aktivIstifadeci?.Rol?.Ad;

    private IcazeYoxlayici()
    {
        _istifadeciIcazeleri = new HashSet<string>();
    }

    /// <summary>
    /// Singleton instance-ı əldə edir
    /// </summary>
    public static IcazeYoxlayici Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new IcazeYoxlayici();
                    }
                }
            }
            return _instance;
        }
    }

    /// <summary>
    /// IcazeManager-i təyin edir (DI vasitəsilə)
    /// diqqət: Bu metod tətbiqatın başlanğıcında çağırılmalıdır
    /// </summary>
    public void IcazeManagerTeyinEt(IcazeManager icazeManager)
    {
        _icazeManager = icazeManager ?? throw new ArgumentNullException(nameof(icazeManager));
        Logger.MelumatYaz("IcazeManager təyin edildi");
    }

    /// <summary>
    /// Aktiv istifadəçini təyin edir və icazələrini yükləyir
    /// diqqət: Login uğurlu olduqdan sonra bu metod çağırılmalıdır
    /// qeyd: İstifadəçinin icazələri cache-ə alınır performans üçün
    /// </summary>
    public async Task AktivIstifadeciniTeyinEtAsync(Istifadeci istifadeci)
    {
        if (istifadeci == null)
            throw new ArgumentNullException(nameof(istifadeci));

        _aktivIstifadeci = istifadeci;
        await IcazeleriYukleAsync();

        Logger.MelumatYaz($"Aktiv istifadəçi təyin edildi: {istifadeci.IstifadeciAdi} (Rol: {IstifadeciRolu})");
    }

    /// <summary>
    /// İstifadəçinin icazələrini verilənlər bazasından yükləyir
    /// </summary>
    private async Task IcazeleriYukleAsync()
    {
        _istifadeciIcazeleri.Clear();

        if (_aktivIstifadeci == null || _icazeManager == null)
            return;

        // Admin istifadəçiləri bütün icazələrə sahibdir
        if (_aktivIstifadeci.RolId == 1) // 1 - Admin rolu
        {
            var butunIcazeler = await _icazeManager.ButunIcazeleriGetirAsync();
            if (butunIcazeler.UgurluDur && butunIcazeler.Data != null)
            {
                foreach (var icaze in butunIcazeler.Data)
                {
                    _istifadeciIcazeleri.Add(icaze.Ad);
                }
            }
            Logger.MelumatYaz($"Admin istifadəçisi üçün {_istifadeciIcazeleri.Count} icazə yükləndi");
        }
        else
        {
            var rolIcazeleri = await _icazeManager.RolIcazeleriniGetirAsync(_aktivIstifadeci.RolId);
            if (rolIcazeleri.UgurluDur && rolIcazeleri.Data != null)
            {
                foreach (var icaze in rolIcazeleri.Data)
                {
                    _istifadeciIcazeleri.Add(icaze.Ad);
                }
            }
            Logger.MelumatYaz($"İstifadəçi üçün {_istifadeciIcazeleri.Count} icazə yükləndi");
        }
    }

    /// <summary>
    /// İstifadəçinin müəyyən icazəyə sahib olub-olmadığını yoxlayır
    /// diqqət: Bu metod cache-dən yoxlayır, çox sürətlidir
    /// qeyd: İcazə adı case-sensitive deyil
    /// </summary>
    /// <param name="icazeAdi">Yoxlanılacaq icazənin adı</param>
    /// <returns>İcazə varsa true, yoxsa false</returns>
    public bool IcazeVarmi(string icazeAdi)
    {
        if (string.IsNullOrWhiteSpace(icazeAdi))
            return false;

        if (_aktivIstifadeci == null)
        {
            Logger.XəbərdarlıqYaz("Aktiv istifadəçi təyin edilməyib");
            return false;
        }

        return _istifadeciIcazeleri.Contains(icazeAdi, StringComparer.OrdinalIgnoreCase);
    }

    /// <summary>
    /// İstifadəçinin müəyyən icazəyə sahib olub-olmadığını yoxlayır və mesaj qaytarır
    /// diqqət: İcazə yoxdursa istifadəçiyə göstərilə biləcək mesaj qaytarır
    /// </summary>
    /// <param name="icazeAdi">Yoxlanılacaq icazənin adı</param>
    /// <param name="mesaj">İcazə yoxdursa göstəriləcək mesaj</param>
    /// <returns>İcazə varsa true, yoxsa false</returns>
    public bool IcazeVarmiMesajla(string icazeAdi, out string mesaj)
    {
        bool icazeVar = IcazeVarmi(icazeAdi);

        if (icazeVar)
        {
            mesaj = string.Empty;
            return true;
        }
        else
        {
            mesaj = $"Bu əməliyyat üçün '{icazeAdi}' icazəsi tələb olunur.";
            Logger.XəbərdarlıqYaz($"İcazə yoxdur: {icazeAdi} (İstifadəçi: {_aktivIstifadeci?.IstifadeciAdi})");
            return false;
        }
    }

    /// <summary>
    /// İstifadəçinin Admin olub-olmadığını yoxlayır
    /// </summary>
    public bool AdminDirmi()
    {
        return _aktivIstifadeci?.RolId == 1;
    }

    /// <summary>
    /// İstifadəçinin Manager olub-olmadığını yoxlayır
    /// </summary>
    public bool ManagerDirmi()
    {
        return _aktivIstifadeci?.RolId == 2; // 2 - Manager rolu
    }

    /// <summary>
    /// İstifadəçinin Kassir olub-olmadığını yoxlayır
    /// </summary>
    public bool KassirDirmi()
    {
        return _aktivIstifadeci?.RolId == 3; // 3 - Kassir rolu
    }

    /// <summary>
    /// İstifadəçinin birdən çox icazəyə sahib olub-olmadığını yoxlayır (VƏ şərti)
    /// </summary>
    /// <param name="icazeAdlari">Yoxlanılacaq icazələrin adları</param>
    /// <returns>Bütün icazələr varsa true, əks halda false</returns>
    public bool CoxluIcazeVarmiVE(params string[] icazeAdlari)
    {
        if (icazeAdlari == null || icazeAdlari.Length == 0)
            return false;

        return icazeAdlari.All(IcazeVarmi);
    }

    /// <summary>
    /// İstifadəçinin ən azı bir icazəyə sahib olub-olmadığını yoxlayır (VƏ YA şərti)
    /// </summary>
    /// <param name="icazeAdlari">Yoxlanılacaq icazələrin adları</param>
    /// <returns>Ən azı bir icazə varsa true, əks halda false</returns>
    public bool CoxluIcazeVarmiVEYA(params string[] icazeAdlari)
    {
        if (icazeAdlari == null || icazeAdlari.Length == 0)
            return false;

        return icazeAdlari.Any(IcazeVarmi);
    }

    /// <summary>
    /// Aktiv sessiya məlumatlarını təmizləyir (Logout zamanı)
    /// </summary>
    public void TəmizleTəmizlə()
    {
        _aktivIstifadeci = null;
        _istifadeciIcazeleri.Clear();
        Logger.MelumatYaz("İstifadəçi sessiyası təmizləndi");
    }

    /// <summary>
    /// İstifadəçinin bütün icazələrini qaytarır
    /// </summary>
    public IReadOnlySet<string> ButunIcazeler()
    {
        return _istifadeciIcazeleri;
    }
}

/// <summary>
/// Sistem icazələrinin sabitləri
/// diqqət: Buraya yeni icazələr əlavə edildikdə verilənlər bazasında da əlavə edilməlidir
/// qeyd: İcazə adları konstant olaraq saxlanılır, səhv yazmağın qarşısı alınır
/// </summary>
public static class SistemIcazeleri
{
    // Satış icazələri
    public const string SatisSil = "SatisSil";
    public const string SatisaEndirimVer = "SatisaEndirimVer";
    public const string SatisGoruntule = "SatisGoruntule";
    public const string SatisYarat = "SatisYarat";

    // Məhsul icazələri
    public const string MehsulElaveEt = "MehsulElaveEt";
    public const string MehsulDeyis = "MehsulDeyis";
    public const string MehsulSil = "MehsulSil";
    public const string MehsulGoruntule = "MehsulGoruntule";
    public const string MehsulQiymetDeyis = "MehsulQiymetDeyis";

    // Müştəri icazələri
    public const string MusteriElaveEt = "MusteriElaveEt";
    public const string MusteriDeyis = "MusteriDeyis";
    public const string MusteriSil = "MusteriSil";
    public const string MusteriGoruntule = "MusteriGoruntule";

    // Nisyə icazələri
    public const string NisyeVer = "NisyeVer";
    public const string NisyeOdemeQebulEt = "NisyeOdemeQebulEt";
    public const string NisyeHesabatlari = "NisyeHesabatlari";

    // Növbə icazələri
    public const string NovbeAc = "NovbeAc";
    public const string NovbeBagle = "NovbeBagle";
    public const string NovbeHesabatlari = "NovbeHesabatlari";

    // Qaytarma icazələri
    public const string QaytarmaYarat = "QaytarmaYarat";
    public const string QaytarmaGoruntule = "QaytarmaGoruntule";

    // Hesabat icazələri
    public const string HesabatGoruntule = "HesabatGoruntule";
    public const string MaliyyeHesabatlari = "MaliyyeHesabatlari";
    public const string StokHesabatlari = "StokHesabatlari";

    // İstifadəçi icazələri
    public const string IstifadeciElaveEt = "IstifadeciElaveEt";
    public const string IstifadeciDeyis = "IstifadeciDeyis";
    public const string IstifadeciSil = "IstifadeciSil";
    public const string IstifadeciGoruntule = "IstifadeciGoruntule";

    // Konfiqurasiya icazələri
    public const string KonfiqurasiyaGoruntule = "KonfiqurasiyaGoruntule";
    public const string KonfiqurasiyaDeyis = "KonfiqurasiyaDeyis";

    // Alış icazələri
    public const string AlisSenediYarat = "AlisSenediYarat";
    public const string AlisSenediGoruntule = "AlisSenediGoruntule";
    public const string AlisSenediDeyis = "AlisSenediDeyis";
    public const string AlisSenediSil = "AlisSenediSil";
}
