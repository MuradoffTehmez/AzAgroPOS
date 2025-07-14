using AzAgroPOS.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.DAL.Repositories
{
    public class SatisRepository : IDisposable
    {
        private readonly AzAgroDbContext _context;

        public SatisRepository(AzAgroDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> AddAsync(Satis satis)
        {
            _context.Satislar.Add(satis);
            await _context.SaveChangesAsync();
            return satis.Id;
        }

        public void Update(Satis satis)
        {
            satis.YenilenmeTarixi = DateTime.Now;
            _context.Satislar.Update(satis);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var satis = _context.Satislar.Find(id);
            if (satis != null)
            {
                _context.Satislar.Remove(satis);
                _context.SaveChanges();
            }
        }

        public Satis GetById(int id)
        {
            return _context.Satislar.Find(id);
        }

        public Satis GetByIdWithDetails(int id)
        {
            return _context.Satislar
                .Include(s => s.SatisDetallari)
                    .ThenInclude(sd => sd.Mehsul)
                .Include(s => s.SatisOdemeleri)
                .Include(s => s.Kassir)
                .FirstOrDefault(s => s.Id == id);
        }

        public List<Satis> GetAll()
        {
            return _context.Satislar
                .Include(s => s.Kassir)
                .OrderByDescending(s => s.SatisTarixi)
                .ToList();
        }

        public List<Satis> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            return _context.Satislar
                .Include(s => s.Kassir)
                .Where(s => s.SatisTarixi >= startDate && s.SatisTarixi <= endDate)
                .OrderByDescending(s => s.SatisTarixi)
                .ToList();
        }

        public List<Satis> GetByKassir(int kassirId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.Satislar
                .Include(s => s.Kassir)
                .Where(s => s.KassirId == kassirId);

            if (startDate.HasValue)
                query = query.Where(s => s.SatisTarixi >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(s => s.SatisTarixi <= endDate.Value);

            return query.OrderByDescending(s => s.SatisTarixi).ToList();
        }

        public List<Satis> GetBySatisNomresi(string satisNomresi)
        {
            return _context.Satislar
                .Include(s => s.Kassir)
                .Where(s => s.SatisNomresi.Contains(satisNomresi))
                .OrderByDescending(s => s.SatisTarixi)
                .ToList();
        }

        public List<Satis> GetByStatus(string status)
        {
            return _context.Satislar
                .Include(s => s.Kassir)
                .Where(s => s.Status == status)
                .OrderByDescending(s => s.SatisTarixi)
                .ToList();
        }

        public List<Satis> GetByOdemeNovu(string odemeNovu, DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.Satislar
                .Include(s => s.Kassir)
                .Where(s => s.OdemeNovu == odemeNovu);

            if (startDate.HasValue)
                query = query.Where(s => s.SatisTarixi >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(s => s.SatisTarixi <= endDate.Value);

            return query.OrderByDescending(s => s.SatisTarixi).ToList();
        }

        public decimal GetTotalSalesByDate(DateTime date)
        {
            return _context.Satislar
                .Where(s => s.SatisTarixi.Date == date.Date && s.Status != "İptal Edilmiş")
                .Sum(s => s.NetMebleg);
        }

        public int GetSalesCountByDate(DateTime date)
        {
            return _context.Satislar
                .Count(s => s.SatisTarixi.Date == date.Date && s.Status != "İptal Edilmiş");
        }

        public List<Satis> GetTodaysSales()
        {
            DateTime today = DateTime.Today;
            return GetByDateRange(today, today.AddDays(1).AddSeconds(-1));
        }

        public IEnumerable<Satis> GetByCustomer(int customerId)
        {
            return _context.Satislar
                .Include(s => s.Kassir)
                .Include(s => s.SatisDetallari)
                .ThenInclude(sd => sd.Mehsul)
                .Where(s => s.MusteriId == customerId)
                .OrderByDescending(s => s.SatisTarixi);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}