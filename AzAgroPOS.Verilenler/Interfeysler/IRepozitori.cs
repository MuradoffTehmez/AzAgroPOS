using AzAgroPOS.Varliglar;
using System.Linq.Expressions;

namespace AzAgroPOS.Verilenler.Interfeysler
{
    public interface IRepozitori<T> where T : BazaVarligi
    {
        Task<T> GetirAsync(int id);
        Task<IEnumerable<T>> ButununuGetirAsync();
        Task<IEnumerable<T>> AxtarAsync(Expression<Func<T, bool>>? filter = null, string[]? includeProperties = null);
        Task ElaveEtAsync(T varliq);
        void Yenile(T varliq);
        void Sil(T varliq);
        // Fiziki silmə əməliyyatı (geri qaytarılmaz)
        void FizikiSil(T varliq);
        // Silinmiş varlıqları əldə etmək üçün metodlar
        Task<IEnumerable<T>> SilinmisleriGetirAsync(Expression<Func<T, bool>>? filter = null, string[]? includeProperties = null);
        Task<IEnumerable<T>> ButununuVeSilinmisleriGetirAsync(Expression<Func<T, bool>>? filter = null, string[]? includeProperties = null);
    }
}