using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;
using AzAgroPOS.Varliglar;

/// <summary>
/// BU REPOZITORIYA DIQQƏT: Bu sinif, CRUD əməliyyatlarını (Yarat, Oxu, Yenilə, Sil) ümumi şəkildə həyata keçirir.
/// QEYD: Bu sinif, konkret varlıq repozitoriyaları üçün təməl sinif kimi istifadə olunur.
/// </summary>
public class MusteriRepozitori : Repozitori<AzAgroPOS.Varliglar.Musteri>, IMusteriRepozitori
{
    /// <summary>
    /// DIQQƏT: Bu konstruktor, verilənlər bazası kontekstini bazaya ötürür.
    /// QEYD: Bu konstruktor, konkret varlıq repozitoriyaları üçün istifadə olunur.
    /// </summary>
    /// <param name="kontekst"></param>
    public MusteriRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst) 
    {
        // burda əlavə konfiqurasiya və ya başlanğıc əməliyyatları həyata keçirilə bilər
    }
}