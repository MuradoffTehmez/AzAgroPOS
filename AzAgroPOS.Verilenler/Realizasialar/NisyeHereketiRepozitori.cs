// Fayl: AzAgroPOS.Verilenler/Realizasialar/NisyeHereketiRepozitori.cs
namespace AzAgroPOS.Verilenler.Realizasialar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Varliglar;

/// <summary>
/// NisyeHereketi üçün CRUD əməliyyatlarını həyata keçirən repozitoriya.
/// diqqət: Bu sinif, CRUD əməliyyatlarını (Yarat, Oxu, Yenilə, Sil) ümumi şəkildə həyata keçirir.
/// qeyd: Bu sinif, konkret varlıq repozitoriyaları üçün təməl sinif kimi istifadə olunur.
/// </summary>
public class NisyeHereketiRepozitori : Repozitori<NisyeHereketi>, INisyeHereketiRepozitori
{
    /// <summary>
    /// NisyeHereketiRepozitoriyasını yaradmaq üçün konstruktor.
    /// diqqət: Bu konstruktor, verilənlər bazası kontekstini bazaya ötürür.
    /// qeyd: Bu konstruktor, konkret varlıq repozitoriyaları üçün istifadə olunur.
    /// azAgroPOSDbContext kontekst - verilənlər bazası kontekstini təmsil edən obyekt.
    /// </summary>
    /// <param name="kontekst"></param>
    public NisyeHereketiRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst) 
    {
        // burda əlavə konfiqurasiya və ya başlanğıc əməliyyatları həyata keçirilə bilər
        // nisyeHereketi ilə əlaqəli xüsusi əməliyyatlar əlavə edilə bilər, məsələn: Müştəriyə görə nisyə hərəkətlərini tapmaq, tarix aralığına görə nisyə hərəkətlərini filtrləmək və s.
    }
}