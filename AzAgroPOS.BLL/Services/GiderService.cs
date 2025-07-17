using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.BLL.Interfaces;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.BLL.Services
{
    public class GiderService
    {
        private readonly IGiderRepository _giderRepository;

        public GiderService(IGiderRepository giderRepository)
        {
            _giderRepository = giderRepository;
        }

        public async Task<IEnumerable<Gider>> GetAllExpensesAsync()
        {
            return await _giderRepository.GetAllAsync();
        }

        public async Task<Gider> GetExpenseByIdAsync(int id)
        {
            return await _giderRepository.GetByIdAsync(id);
        }

        public async Task<Gider> CreateExpenseAsync(Gider expense)
        {
            if (expense == null)
                throw new ArgumentNullException(nameof(expense));

            ValidateExpense(expense);

            // Set creation date
            expense.YaranmaTarixi = DateTime.Now;
            expense.Tarix = expense.Tarix.Date; // Ensure only date part

            return await _giderRepository.AddAsync(expense);
        }

        public async Task<Gider> UpdateExpenseAsync(Gider expense)
        {
            if (expense == null)
                throw new ArgumentNullException(nameof(expense));

            ValidateExpense(expense);

            var existingExpense = await _giderRepository.GetByIdAsync(expense.Id);
            if (existingExpense == null)
                throw new InvalidOperationException("Gidər tapılmadı");

            // Don't allow changes to approved expenses
            if (existingExpense.TesdiqEdildi)
                throw new InvalidOperationException("Təsdiqlənmiş gidər dəyişdirilə bilməz");

            expense.YenilenmeTarixi = DateTime.Now;
            return await _giderRepository.UpdateAsync(expense);
        }

        public async Task DeleteExpenseAsync(int id)
        {
            var expense = await _giderRepository.GetByIdAsync(id);
            if (expense == null)
                throw new InvalidOperationException("Gidər tapılmadı");

            if (expense.TesdiqEdildi)
                throw new InvalidOperationException("Təsdiqlənmiş gidər silinə bilməz");

            await _giderRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Gider>> GetExpensesByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
                throw new ArgumentException("Başlanğıc tarix bitmə tarixindən böyük ola bilməz");

            return await _giderRepository.GetByDateRangeAsync(startDate, endDate);
        }

        public async Task<IEnumerable<Gider>> GetExpensesByCategoryAsync(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
                throw new ArgumentException("Kateqoriya boş ola bilməz");

            return await _giderRepository.GetByCategoryAsync(category);
        }

        public async Task<IEnumerable<Gider>> GetPendingExpensesAsync()
        {
            return await _giderRepository.GetPendingApprovalAsync();
        }

        public async Task<IEnumerable<Gider>> GetUserExpensesAsync(int userId)
        {
            return await _giderRepository.GetByUserAsync(userId);
        }

        public async Task ApproveExpenseAsync(int expenseId, string approverName)
        {
            if (string.IsNullOrWhiteSpace(approverName))
                throw new ArgumentException("Təsdiqləyən ad daxil edilməlidir");

            await _giderRepository.ApproveExpenseAsync(expenseId, approverName);
        }

        public async Task<ExpenseSummaryDto> GetExpenseSummaryAsync(DateTime? startDate = null, DateTime? endDate = null)
        {
            var start = startDate ?? DateTime.Now.AddMonths(-1);
            var end = endDate ?? DateTime.Now;

            var expenses = await _giderRepository.GetByDateRangeAsync(start, end);
            var approvedExpenses = expenses.Where(e => e.TesdiqEdildi);

            return new ExpenseSummaryDto
            {
                TotalExpenses = approvedExpenses.Sum(e => e.Mebleg),
                PendingExpenses = expenses.Where(e => !e.TesdiqEdildi).Sum(e => e.Mebleg),
                ExpenseCount = expenses.Count(),
                PendingCount = expenses.Count(e => !e.TesdiqEdildi),
                CategoryBreakdown = await _giderRepository.GetExpensesByCategoryAsync(start, end),
                StartDate = start,
                EndDate = end
            };
        }

        public async Task<IEnumerable<Gider>> SearchExpensesAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return await GetAllExpensesAsync();

            return await _giderRepository.SearchAsync(searchTerm.Trim());
        }

        public async Task<decimal> GetMonthlyExpensesAsync(int year, int month)
        {
            return await _giderRepository.GetTotalExpensesByMonthAsync(year, month);
        }

        public async Task<Dictionary<string, decimal>> GetCategoryExpensesAsync(DateTime startDate, DateTime endDate)
        {
            return await _giderRepository.GetExpensesByCategoryAsync(startDate, endDate);
        }

        public List<string> GetExpenseCategories()
        {
            return new List<string>
            {
                GiderKateqoriyalari.OfisXercleri,
                GiderKateqoriyalari.PersonalMaasi,
                GiderKateqoriyalari.KommunalOdemeler,
                GiderKateqoriyalari.NaqliyyatXercleri,
                GiderKateqoriyalari.Reklamvemreketinq,
                GiderKateqoriyalari.TexnikiDəstək,
                GiderKateqoriyalari.AlqIcare,
                GiderKateqoriyalari.SahinkarligMateriallari,
                GiderKateqoriyalari.AvadanliqAlqi,
                GiderKateqoriyalari.Diger
            };
        }

        public List<string> GetPaymentMethods()
        {
            return new List<string>
            {
                OdemeUsullari.Negd,
                OdemeUsullari.BankKarti,
                OdemeUsullari.BankKocurmu,
                OdemeUsullari.Cek,
                OdemeUsullari.OnlineOdeme
            };
        }

        private void ValidateExpense(Gider expense)
        {
            if (string.IsNullOrWhiteSpace(expense.Ad))
                throw new ArgumentException("Gidər adı mütləqdir");

            if (expense.Mebleg <= 0)
                throw new ArgumentException("Məbləğ sıfırdan böyük olmalıdır");

            if (string.IsNullOrWhiteSpace(expense.Kateqoriya))
                throw new ArgumentException("Kateqoriya seçilməlidir");

            if (expense.Tarix > DateTime.Now.Date)
                throw new ArgumentException("Gidər tarixi bugündən sonra ola bilməz");

            if (expense.IstifadeciId <= 0)
                throw new ArgumentException("İstifadəçi təyin edilməlidir");
        }
    }
}

namespace AzAgroPOS.Entities.DTO
{
    public class ExpenseSummaryDto
    {
        public decimal TotalExpenses { get; set; }
        public decimal PendingExpenses { get; set; }
        public int ExpenseCount { get; set; }
        public int PendingCount { get; set; }
        public Dictionary<string, decimal> CategoryBreakdown { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        public string TotalExpensesFormatted => TotalExpenses.ToString("C");
        public string PendingExpensesFormatted => PendingExpenses.ToString("C");
    }
}