// Fayl: AzAgroPOS.Verilenler/Interfeysler/IRepozitori.cs
namespace AzAgroPOS.Verilenler.Interfeysler;

using System.Linq.Expressions;
using AzAgroPOS.Varliglar;

/// <summary>
/// Ümumi (generic) repozitori interfeysi.
/// Bütün varlıqlar üçün standart CRUD (Yarat, Oxu, Yenilə, Sil) əməliyyatlarını təyin edir.
/// </summary>
/// <typeparam name="T">BazaVarligi sinifindən törəyən hər hansı bir varlıq növü.</typeparam>
public interface IRepozitori<T> where T : BazaVarligi
{
    /// <summary>
    /// Göstərilən id-yə malik varlığı asinxron olaraq gətirir.
    /// diqqət: Bu metod yalnız mövcud olan varlıqları gətirir, əgər id ilə uyğun varlıq tapılmazsa, null qaytarır.
    /// qeyd: Bu metod asinxron işləyir və Task T? tipində nəticə qaytarır.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<T?> GetirAsync(int id);
    /// <summary>
    /// Bütün varlıqları asinxron olaraq gətirir.
    /// diqqət: Bu metod bütün varlıqları gətirir, əgər heç bir varlıq tapılmazsa, boş kolleksiya qaytarır.
    /// qeyd: Bu metod asinxron işləyir və Task  tipində nəticə qaytarır.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<T>> ButununuGetirAsync();
    /// <summary>
    /// Axtarış əməliyyatı üçün asinxron metod.
    /// diqqət: Bu metod göstərilən şərtə uyğun olan bütün varlıqları gətirir.
    /// qeyd: Bu metod asinxron işləyir və Task  tipində nəticə qaytarır.
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    Task<IEnumerable<T>> AxtarAsync(Expression<Func<T, bool>> predicate);
    /// <summary>
    /// Elavə etmə əməliyyatını asinxron olaraq həyata keçirir.
    /// diqqət: Bu metod yeni bir varlıq əlavə edir və verilənlər bazasına yazır.
    /// qeyd: Bu metod asinxron işləyir və Task tipində nəticə qaytarır.
    /// </summary>
    /// <param name="varliq"></param>
    /// <returns></returns>
    Task ElaveEtAsync(T varliq);
    /// <summary>
    /// yeniləmə əməliyyatını asinxron olaraq həyata keçirir.
    /// diqqət: Bu metod mövcud varlığı yeniləyir və verilənlər bazasına yazır.
    /// qeyd: Bu metod asinxron işləyir və Task tipində nəticə qaytarır.
    /// </summary>
    /// <param name="varliq"></param>
    void Yenile(T varliq); // EF Core-da Update sinxron işləyir
    /// <summary>
    /// Silmə əməliyyatını asinxron olaraq həyata keçirir.
    /// diqqət: Bu metod göstərilən varlığı silir və verilənlər bazasından çıxarır.
    /// qeyd: Bu metod asinxron işləyir və Task tipində nəticə qaytarır.
    /// </summary>
    /// <param name="varliq"></param>
    void Sil(T varliq);   // EF Core-da Sil sinxron işləyir
}