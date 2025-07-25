using AzAgroPOS.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AzAgroPOS.DAL.Repositories
{
    public class MusteriBorcRepository : IDisposable
    {
        private readonly AzAgroDbContext _context;

        public MusteriBorcRepository(AzAgroDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IQueryable<MusteriBorc> GetAll()
        {
            return _context.MusteriBorcları
                .Include(b => b.Musteri)
                .Include(b => b.Satis)
                .Include(b => b.BorcOdenisleri)
                .Include(b => b.YaradanIstifadeci);
        }

        public MusteriBorc GetById(int id)
        {
            return GetAll().FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<MusteriBorc> GetByMusteriId(int musteriId)
        {
            return GetAll().Where(b => b.MusteriId == musteriId).ToList();
        }

        public IEnumerable<MusteriBorc> GetActiveDebts()
        {
            return GetAll().Where(b => b.QalanBorc > 0).ToList();
        }

        public IEnumerable<MusteriBorc> GetOverdueDebts()
        {
            var today = DateTime.Now.Date;
            return GetAll().Where(b => b.QalanBorc > 0 && b.SonOdemeTarixi < today).ToList();
        }

        public IEnumerable<MusteriBorc> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            return GetAll().Where(b => b.BorcTarixi >= startDate && b.BorcTarixi <= endDate).ToList();
        }

        public decimal GetTotalDebtByMusteriId(int musteriId)
        {
            return GetAll()
                .Where(b => b.MusteriId == musteriId && b.QalanBorc > 0)
                .Sum(b => b.QalanBorc);
        }

        public decimal GetTotalOverdueDebt()
        {
            var today = DateTime.Now.Date;
            return GetAll()
                .Where(b => b.QalanBorc > 0 && b.SonOdemeTarixi < today)
                .Sum(b => b.QalanBorc);
        }

        public IEnumerable<MusteriBorc> GetDebtsRequiringAttention()
        {
            var today = DateTime.Now.Date;
            var warningDate = today.AddDays(7);
            
            return GetAll()
                .Where(b => b.QalanBorc > 0 && 
                           (b.SonOdemeTarixi < today || b.SonOdemeTarixi <= warningDate))
                .OrderBy(b => b.SonOdemeTarixi)
                .ToList();
        }

        public int Add(MusteriBorc musteriBorc)
        {
            _context.MusteriBorcları.Add(musteriBorc);
            _context.SaveChanges();
            return musteriBorc.Id;
        }

        public void Update(MusteriBorc musteriBorc)
        {
            musteriBorc.YenilenmeTarixi = DateTime.Now;
            _context.Entry(musteriBorc).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var musteriBorc = _context.MusteriBorcları.Find(id);
            if (musteriBorc != null)
            {
                _context.MusteriBorcları.Remove(musteriBorc);
                _context.SaveChanges();
            }
        }

        public string GenerateBorcNomresi()
        {
            var today = DateTime.Now;
            var prefix = $"B{today:yyyyMM}";
            
            var lastNumber = _context.MusteriBorcları
                .Where(b => b.BorcNomresi.StartsWith(prefix))
                .Select(b => b.BorcNomresi)
                .ToList()
                .Select(n => 
                {
                    if (int.TryParse(n.Substring(prefix.Length), out int num))
                        return num;
                    return 0;
                })
                .DefaultIfEmpty(0)
                .Max();

            return $"{prefix}{(lastNumber + 1):D4}";
        }

        public List<MusteriBorc> GetAllActiveDebts()
        {
            return _context.MusteriBorcları
                .Include(b => b.Musteri)
                .Include(b => b.Satis)
                .Include(b => b.BorcOdenisleri)
                .Where(b => b.Status == "Aktiv")
                .OrderByDescending(b => b.YaradilmaTarixi)
                .ToList();
        }

        public IEnumerable<MusteriBorc> GetByCustomer(int customerId)
        {
            return _context.MusteriBorcları
                .Include(b => b.Musteri)
                .Include(b => b.Satis)
                .Include(b => b.BorcOdenisleri)
                .Where(b => b.MusteriId == customerId)
                .OrderByDescending(b => b.YaradilmaTarixi);
        }

        public async Task<List<MusteriBorc>> GetFilteredDebtsAsync(string customerSearch, string status, DateTime? startDate, DateTime? endDate, int pageSize = 100, int pageNumber = 1)
        {
            using (var context = new AzAgroDbContext())
            {
                var query = context.MusteriBorcları
                    .Include(b => b.Musteri)
                    .Include(b => b.Satis)
                    .Include(b => b.BorcOdenisleri)
                    .AsQueryable();

                if (!string.IsNullOrEmpty(customerSearch))
                {
                    query = query.Where(b => 
                        b.Musteri.Ad.Contains(customerSearch) || 
                        b.Musteri.Soyad.Contains(customerSearch));
                }

                if (!string.IsNullOrEmpty(status))
                {
                    query = query.Where(b => b.Status == status);
                }

                if (startDate.HasValue)
                {
                    query = query.Where(b => b.YaradilmaTarixi >= startDate.Value);
                }

                if (endDate.HasValue)
                {
                    query = query.Where(b => b.YaradilmaTarixi <= endDate.Value);
                }

                return await query
                    .OrderByDescending(b => b.YaradilmaTarixi)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
            }
        }

        public async Task<int> GetFilteredDebtsCountAsync(string customerSearch, string status, DateTime? startDate, DateTime? endDate)
        {
            using (var context = new AzAgroDbContext())
            {
                var query = context.MusteriBorcları.AsQueryable();

                if (!string.IsNullOrEmpty(customerSearch))
                {
                    query = query.Where(b => 
                        b.Musteri.Ad.Contains(customerSearch) || 
                        b.Musteri.Soyad.Contains(customerSearch));
                }

                if (!string.IsNullOrEmpty(status))
                {
                    query = query.Where(b => b.Status == status);
                }

                if (startDate.HasValue)
                {
                    query = query.Where(b => b.YaradilmaTarixi >= startDate.Value);
                }

                if (endDate.HasValue)
                {
                    query = query.Where(b => b.YaradilmaTarixi <= endDate.Value);
                }

                return await query.CountAsync();
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}