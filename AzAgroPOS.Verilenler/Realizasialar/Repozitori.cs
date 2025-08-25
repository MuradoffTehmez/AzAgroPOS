// Fayl: AzAgroPOS.Verilenler/Realizasialar/Repozitori.cs
namespace AzAgroPOS.Verilenler.Realizasialar;

using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Repozitori sinifi, verilənlər bazası əməliyyatlarını ümumi şəkildə həyata keçirir.
/// Təqdim edilən T tipi, BazaVarligi sinifindən törədilmiş olmalıdır.
/// diqqət: Bu sinif, CRUD əməliyyatlarını (Yarat, Oxu, Yenilə, Sil) ümumi şəkildə həyata keçirir.
/// qeyd: Bu sinif, konkret varlıq repozitoriyaları üçün təməl sinif kimi istifadə olunur.
/// </summary>
/// <typeparam name="T"></typeparam>
public class Repozitori<T> : IRepozitori<T> where T : BazaVarligi
{
    /// <summary>
    /// _kontekst - verilənlər bazası kontekstini təmsil edən obyektdir.
    /// DIQQƏT: Bu sahə, verilənlər bazası əməliyyatlarını həyata keçirmək üçün istifadə olunur.
    /// QEYD: Bu sahə, konkret varlıq repozitoriyaları üçün istifadə olunur.
    /// </summary>
    protected readonly AzAgroPOSDbContext _kontekst;

    /// <summary>
    /// repozitoriyanı yaratmaq üçün konstruktor.
    /// BU KONSTRUKTOR, VERILƏNLƏR BAZASI KONTEKSTINI BAZAYA ÖTÜRÜR.
    /// DIQQƏT: BU KONSTRUKTOR, KONKRET VARLIQ REPOZITORIYALARI ÜÇÜN İSTİFADƏ OLUNUR.
    /// QEYD: AZAGROPOSDBCONTEXT KONTEKST - VERILƏNLƏR BAZASI KONTEKSTINI TƏMSIL EDƏN OBYEKT.
    /// ASYNC TAPILAN T? - VERILƏNLƏR BAZASINDAN TAPILAN OBYEKT (NULL OLA BILER).
    /// </summary>
    /// <param name="kontekst"></param>
    public Repozitori(AzAgroPOSDbContext kontekst)
    {
        _kontekst = kontekst;
    }

    /// <summary>
    /// GetirAsync metodu, verilənlər bazasından müəyyən bir ID-yə sahib varlığı asinxron şəkildə tapır.
    /// DIQQƏT: Bu metod, verilənlər bazasından varlığı tapmaq üçün istifadə olunur.
    /// qeyd: Bu metod, konkret varlıq repozitoriyaları üçün istifadə olunur.
    ///  T? - verilənlər bazasından tapılan obyekt (null ola bilər).
    ///  id - tapılacaq varlığın ID-si.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<T?> GetirAsync(int id)
    {
        return await _kontekst.Set<T>().FindAsync(id);
    }
    /// <summary>
    /// ButununuGetirAsync metodu, verilənlər bazasından bütün varlıqları asinxron şəkildə gətirir.
    /// diqqət: Bu metod, verilənlər bazasından bütün varlıqları gətirmək üçün istifadə olunur.
    /// qeyd: Bu metod, konkret varlıq repozitoriyaları üçün istifadə olunur.
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<T>> ButununuGetirAsync()
    {
        return await _kontekst.Set<T>().ToListAsync();
    }
    /// <summary>
    /// AxtarAsync metodu, verilənlər bazasından müəyyən bir şərtə uyğun varlıqları asinxron şəkildə tapır.
    /// diqqət - Bu metod, verilənlər bazasından şərtə uyğun varlıqları tapmaq üçün istifadə olunur.
    /// qeyd - Bu metod, konkret varlıq repozitoriyaları üçün istifadə olunur, _kontekst - verilənlər bazası kontekstini təmsil edən obyekt.
    /// predicate - varlıqları tapmaq üçün istifadə olunan şərt ifadəsi.
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public async Task<IEnumerable<T>> AxtarAsync(Expression<Func<T, bool>> predicate)
    {
        return await _kontekst.Set<T>().Where(predicate).ToListAsync();
    }
    /// <summary>
    /// ElaveEtAsync metodu, verilənlər bazasına yeni bir varlıq əlavə etmək üçün istifadə olunur.
    /// async - Bu metod asinxron işləyir və verilənlər bazasına əlavə etmə əməliyyatını həyata keçirir.
    /// qeyd - Bu metod, konkret varlıq repozitoriyaları üçün istifadə olunur, _kontekst - verilənlər bazası kontekstini təmsil edən obyekt.
    /// diqqət - Bu metod yeni bir varlıq əlavə edir və verilənlər bazasına yazır.
    /// </summary>
    /// <param name="varliq"></param>
    /// <returns></returns>
    public async Task ElaveEtAsync(T varliq)
    {
        await _kontekst.Set<T>().AddAsync(varliq);
    }
    /// <summary>
    /// Yenile metodu, verilənlər bazasındakı mövcud bir varlığı yeniləmək üçün istifadə olunur.
    /// T - verilənlər bazasındakı varlığı təmsil edən obyektdir və BazaVarligi sinifindən törədilmiş olmalıdır.
    /// qeyd - Bu metod, konkret varlıq repozitoriyaları üçün istifadə olunur, _kontekst - verilənlər bazası kontekstini təmsil edən obyekt.
    /// diqqət - Bu metod mövcud varlığı yeniləyir və verilənlər bazasına yazır.
    /// </summary>
    /// <param name="varliq"></param>
    public void Yenile(T varliq)
    {
        _kontekst.Set<T>().Update(varliq);
    }
    /// <summary>
    /// Sil metodu, verilənlər bazasından mövcud bir varlığı silmək üçün istifadə olunur.
    /// T - verilənlər bazasındakı varlığı təmsil edən obyektdir və BazaVarligi sinifindən törədilmiş olmalıdır.
    /// qeyd - Bu metod, konkret varlıq repozitoriyaları üçün istifadə olunur, _kontekst - verilənlər bazası kontekstini təmsil edən obyekt.
    /// </summary>
    /// <param name="varliq"></param>
    public void Sil(T varliq)
    {
        _kontekst.Set<T>().Remove(varliq);
    }
}