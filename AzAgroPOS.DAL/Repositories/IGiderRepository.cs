using AzAgroPOS.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzAgroPOS.DAL.Repositories
{
    public interface IGiderRepository : IDisposable
    {
        Task<IEnumerable<Gider>> GetAllAsync();
        Task<Gider> GetByIdAsync(int id);
        Task<int> AddAsync(Gider entity);
        Task UpdateAsync(Gider entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<Gider>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Gider>> GetByCategoryAsync(string category);
        Task<IEnumerable<Gider>> GetPendingApprovalAsync();
        Task<decimal> GetTotalExpenseAsync();
        Task<decimal> GetTotalExpenseByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<decimal> GetTotalExpensesByMonthAsync(int year, int month);
        Task<decimal> GetTotalExpensesByCategoryAsync(string category, DateTime? startDate = null, DateTime? endDate = null);
        Task<Dictionary<string, decimal>> GetExpensesByCategoryAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Gider>> GetByUserAsync(int userId);
        Task ApproveExpenseAsync(int expenseId, string approverName);
        Task<IEnumerable<Gider>> SearchAsync(string searchTerm);
    }
}