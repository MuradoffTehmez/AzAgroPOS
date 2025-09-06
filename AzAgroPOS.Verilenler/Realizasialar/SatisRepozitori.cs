using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;

/// <summary>
/// satis üçün CRUD əməliyyatlarını həyata keçirən repozitoriya.
/// diqqət: Bu sinif, CRUD əməliyyatlarını (Yarat, Oxu, Yenilə, Sil) ümumi şəkildə həyata keçirir.
/// q
/// </summary>
public class SatisRepozitori : Repozitori<AzAgroPOS.Varliglar.Satis>, ISatisRepozitori
{
    /// <summary>
    /// satisRepozitoriyasını yaratmaq üçün konstruktor.
    /// qeyd: Bu konstruktor, konkret varlıq repozitoriyaları üçün istifadə olunur.
    /// </summary>
    /// <param name="kontekst"></param>
    public SatisRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst)
    {
        // Burada əlavə konfiqurasiyalar və ya metodlar əlavə edilə bilər
        // Məsələn, satışla əlaqəli xüsusi əməliyyatlar əlavə edilə bilər, məsələn: Müəyyən tarix aralığında satışları tapmaq, müəyyən məhsulun satışlarını filtrləmək və s.
        // ən çox satılan məhsulları tapmaq üçün xüsusi metodlar əlavə edilə bilər.
        // ən az satılan məhsulları tapmaq üçün xüsusi metodlar əlavə edilə bilər.
    }
}