// Fayl: AzAgroPOS.Verilenler/Realizasialar/NovbeRepozitori.cs
namespace AzAgroPOS.Verilenler.Realizasialar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;

/// <summary>
/// Novbe üçün CRUD əməliyyatlarını həyata keçirən repozitoriya.
/// diqqət: Bu sinif, CRUD əməliyyatlarını (Yarat, Oxu, Yenilə, Sil) ümumi şəkildə həyata keçirir.
/// qeyd: Bu sinif, konkret varlıq repozitoriyaları üçün təməl sinif kimi istifadə olunur.
/// azAgroPOSDbContext kontekst - verilənlər bazası kontekstini təmsil edən obyekt.
/// interfeys: INovbeRepozitori
/// </summary>
public class NovbeRepozitori : Repozitori<Novbe>, INovbeRepozitori
{
    /// <summary>
    /// novbeRepozitoriyasını yaradmaq üçün konstruktor.
    /// diqqət: Bu konstruktor, verilənlər bazası kontekstini bazaya ötürür.
    /// qeyd: Bu konstruktor, konkret varlıq repozitoriyaları üçün istifadə olunur.
    /// </summary>
    /// <param name="kontekst"></param>
    public NovbeRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst) 
    {
        // burda əlavə konfiqurasiya və ya başlanğıc əməliyyatları həyata keçirilə bilər
        // novbe ilə əlaqəli xüsusi əməliyyatlar əlavə edilə bilər, məsələn: Novbeye görə növbələri tapmaq, tarix aralığına görə növbələri filtrləmək və s.
        // növbədə hansi işçinin olduğunu tapmaq üçün xüsusi metodlar əlavə edilə bilər.
        // işçi növbədə nə qədər qalır, işlədiyi vaxtı hesablamaq üçün xüsusi metodlar əlavə edilə bilər.
    }
}