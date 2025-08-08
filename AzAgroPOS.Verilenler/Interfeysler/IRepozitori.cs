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
    Task<T?> GetirAsync(int id);
    Task<IEnumerable<T>> ButununuGetirAsync();
    Task<IEnumerable<T>> AxtarAsync(Expression<Func<T, bool>> predicate);
    Task ElaveEtAsync(T varliq);
    void Yenile(T varliq); // EF Core-da Update sinxron işləyir
    void Sil(T varliq);   // EF Core-da Sil sinxron işləyir
}