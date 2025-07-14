using AzAgroPOS.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.DAL.Repositories
{
    public class SatisOdemesiRepository : IDisposable
    {
        private readonly AzAgroDbContext _context;

        public SatisOdemesiRepository(AzAgroDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task AddAsync(SatisOdemesi satisOdemesi)
        {
            _context.SatisOdemeleri.Add(satisOdemesi);
            await _context.SaveChangesAsync();
        }

        public void Update(SatisOdemesi satisOdemesi)
        {
            satisOdemesi.YenilenmeTarixi = DateTime.Now;
            _context.SatisOdemeleri.Update(satisOdemesi);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var satisOdemesi = _context.SatisOdemeleri.Find(id);
            if (satisOdemesi != null)
            {
                _context.SatisOdemeleri.Remove(satisOdemesi);
                _context.SaveChanges();
            }
        }

        public SatisOdemesi GetById(int id)
        {
            return _context.SatisOdemeleri
                .Include(so => so.Satis)
                .FirstOrDefault(so => so.Id == id);
        }

        public List<SatisOdemesi> GetBySatisId(int satisId)
        {
            return _context.SatisOdemeleri
                .Include(so => so.Satis)
                .Where(so => so.SatisId == satisId)
                .OrderBy(so => so.OdemeTarixi)
                .ToList();
        }

        public List<SatisOdemesi> GetByOdemeNovu(string odemeNovu, DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.SatisOdemeleri
                .Include(so => so.Satis)
                .Where(so => so.OdemeNovu == odemeNovu);

            if (startDate.HasValue)
                query = query.Where(so => so.OdemeTarixi >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(so => so.OdemeTarixi <= endDate.Value);

            return query.OrderByDescending(so => so.OdemeTarixi).ToList();
        }

        public List<SatisOdemesi> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            return _context.SatisOdemeleri
                .Include(so => so.Satis)
                .Where(so => so.OdemeTarixi >= startDate && so.OdemeTarixi <= endDate)
                .OrderByDescending(so => so.OdemeTarixi)
                .ToList();
        }

        public List<SatisOdemesi> GetByStatus(string status)
        {
            return _context.SatisOdemeleri
                .Include(so => so.Satis)
                .Where(so => so.Status == status)
                .OrderByDescending(so => so.OdemeTarixi)
                .ToList();
        }

        public decimal GetTotalPaymentsByType(string odemeNovu, DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.SatisOdemeleri
                .Where(so => so.OdemeNovu == odemeNovu && so.Status == "Tamamlandı");

            if (startDate.HasValue)
                query = query.Where(so => so.OdemeTarixi >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(so => so.OdemeTarixi <= endDate.Value);

            return query.Sum(so => so.OdemeMeblegi);
        }

        public int GetPaymentCountByType(string odemeNovu, DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.SatisOdemeleri
                .Where(so => so.OdemeNovu == odemeNovu && so.Status == "Tamamlandı");

            if (startDate.HasValue)
                query = query.Where(so => so.OdemeTarixi >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(so => so.OdemeTarixi <= endDate.Value);

            return query.Count();
        }

        public List<object> GetPaymentSummaryByDate(DateTime startDate, DateTime endDate)
        {
            return _context.SatisOdemeleri
                .Include(so => so.Satis)
                .Where(so => so.OdemeTarixi >= startDate && 
                            so.OdemeTarixi <= endDate && 
                            so.Status == "Tamamlandı")
                .GroupBy(so => so.OdemeTarixi.Date)
                .Select(g => new
                {
                    Tarix = g.Key,
                    ToplamMebleg = g.Sum(so => so.OdemeMeblegi),
                    OdemeSayi = g.Count(),
                    NagdMebleg = g.Where(so => so.OdemeNovu == "Nağd").Sum(so => so.OdemeMeblegi),
                    KartMebleg = g.Where(so => so.OdemeNovu == "Kart").Sum(so => so.OdemeMeblegi),
                    NisyeMebleg = g.Where(so => so.OdemeNovu == "Nisyə").Sum(so => so.OdemeMeblegi)
                })
                .OrderByDescending(x => x.Tarix)
                .Cast<object>()
                .ToList();
        }

        public List<object> GetPaymentSummaryByType(DateTime startDate, DateTime endDate)
        {
            return _context.SatisOdemeleri
                .Where(so => so.OdemeTarixi >= startDate && 
                            so.OdemeTarixi <= endDate && 
                            so.Status == "Tamamlandı")
                .GroupBy(so => so.OdemeNovu)
                .Select(g => new
                {
                    OdemeNovu = g.Key,
                    ToplamMebleg = g.Sum(so => so.OdemeMeblegi),
                    OdemeSayi = g.Count(),
                    OrtalamaMebleg = g.Average(so => so.OdemeMeblegi)
                })
                .OrderByDescending(x => x.ToplamMebleg)
                .Cast<object>()
                .ToList();
        }

        public decimal GetTodaysPayments()
        {
            DateTime today = DateTime.Today;
            return GetTotalPaymentsByType("", today, today.AddDays(1).AddSeconds(-1));
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}