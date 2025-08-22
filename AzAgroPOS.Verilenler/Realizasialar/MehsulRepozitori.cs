using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;
using AzAgroPOS.Varliglar;

/// <summary>
/// Baza repozitoriya sinifi, verilənlər bazası əməliyyatlarını ümumi şəkildə idarə edir.
/// REPOZITORIYA DIQQƏT: Bu sinif, CRUD əməliyyatlarını (Yarat, Oxu, Yenilə, Sil) ümumi şəkildə həyata keçirir.
/// QEYD: Bu sinif, konkret varlıq repozitoriyaları üçün təməl sinif kimi istifadə olunur.
/// </summary>
public class MehsulRepozitori : Repozitori<AzAgroPOS.Varliglar.Mehsul>, IMehsulRepozitori
{
    /// <summary>
    /// BU KONSTRUKTORA DIQQƏT: Bu konstruktor, verilənlər bazası kontekstini bazaya ötürür.
    /// QEYD: Bu konstruktor, konkret varlıq repozitoriyaları üçün istifadə olunur.
    /// </summary>
    /// <param name="kontekst"></param>
    public MehsulRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst) 
    {
        // Burda əlavə konfiqurasiyalar və ya başlanğıc əməliyyatları həyata keçirilə bilər.
    }
}