using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AzAgroPOS.Varliglar; 

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
    }
}