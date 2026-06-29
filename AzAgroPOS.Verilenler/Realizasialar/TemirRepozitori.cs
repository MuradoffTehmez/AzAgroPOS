// Fayl: AzAgroPOS.Verilenler/Realizasialar/TemirRepozitori.cs

using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;

namespace AzAgroPOS.Verilenler.Realizasialar;
/// <summary>
/// temir üçün CRUD əməliyyatlarını həyata keçirən repozitoriya.
/// qeyd: Bu sinif, konkret varlıq repozitoriyaları üçün təməl sinif kimi istifadə olunur.
/// </summary>
public class TemirRepozitori : Repozitori<Temir>, ITemirRepozitori
{
    /// <summary>
    /// temirRepozitoriyasını yaratmaq üçün konstruktor.
    /// qeyd: Bu konstruktor, konkret varlıq repozitoriyaları üçün istifadə olunur.
    /// </summary>
    /// <param name="kontekst"></param>
    public TemirRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst)
    {
        // burda əlavə konfiqurasiya və ya başlanğıc əməliyyatları həyata keçirilə bilər
        // temir ilə əlaqəli xüsusi əməliyyatlar əlavə edilə bilər, məsələn: müəyyən tarix aralığında təmir işlərini tapmaq, müəyyən avadanlığın təmir işlərini filtrləmək və s.
        // təmir işlərinin ümumi xərclərini hesablamaq üçün xüsusi metodlar əlavə edilə bilər.
        // təmir işlərinin müddətini hesablamaq üçün xüsusi metodlar əlavə edilə bilər.
    }
}