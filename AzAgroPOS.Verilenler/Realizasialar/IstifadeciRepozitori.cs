// Fayl: AzAgroPOS.Verilenler/Realizasialar/IstifadeciRepozitori.cs
namespace AzAgroPOS.Verilenler.Realizasialar;

using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;


/// <summary>
/// Baza repozitoriya sinifi, verilənlər bazası əməliyyatlarını ümumi şəkildə idarə edir.
/// Diqqət: Bu sinif, CRUD əməliyyatlarını (Yarat, Oxu, Yenilə, Sil) ümumi şəkildə həyata keçirir.
/// Qeyd: Bu sinif, konkret varlıq repozitoriyaları üçün təməl sinif kimi istifadə olunur.
/// </summary>
public class IstifadeciRepozitori : Repozitori<Istifadeci>, IIstifadeciRepozitori
{
    /// <summary>
    /// Baza repozitoriya konstruktoru, verilənlər bazası kontekstini qəbul edir.
    /// KONSTRUKTORA DIQQƏT:Bu konstruktor, verilənlər bazası kontekstini bazaya ötürür.
    /// Qeyd: Bu konstruktor, konkret varlıq repozitoriyaları üçün istifadə olunur.
    /// </summary>
    /// <param name="kontekst"></param>
    public IstifadeciRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst) 
    {
        // Burda əlavə konfiqurasiyalar və ya başlanğıc əməliyyatları həyata keçirilə bilər.
        // buradakı əlavə əməliyyatlar, məsələn, başlanğıc məlumatları əlavə etmək və ya xüsusi konfiqurasiyalar təyin etmək kimi ola bilər.
        // İstifadəçi ilə əlaqəli xüsusi əməliyyatlar əlavə edilə bilər, məsələn: Rola görə istifadəçiləri tapmaq, istifadəçi adına görə istifadəçiləri filtrləmək və s.
        // İstifadəçi adına, emailinə və ya roluna görə istifadəçiləri axtarmaq üçün xüsusi metodlar əlavə edilə bilər.
    }
}