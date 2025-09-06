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
        //Task<T> IdyeGoreGetirAsync(int id, string includeProperties = null);
        //Task<IEnumerable<T>> HamisiniGetirAsync(Expression<Func<T, bool>> filter = null, string includeProperties = null);
        //Task ElaveEtAsync(T varliq);
    }
}