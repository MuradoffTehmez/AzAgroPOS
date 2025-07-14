using AzAgroPOS.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.DAL.Repositories
{
    public class SatisDetaliRepository
    {
        private readonly AzAgroDbContext _context;

        public SatisDetaliRepository()
        {
            _context = new AzAgroDbContext();
        }

        public async Task AddAsync(SatisDetali satisDetali)
        {
            _context.SatisDetallari.Add(satisDetali);
            await _context.SaveChangesAsync();
        }

        public void Update(SatisDetali satisDetali)
        {
            satisDetali.YenilenmeTarixi = DateTime.Now;
            _context.SatisDetallari.Update(satisDetali);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var satisDetali = _context.SatisDetallari.Find(id);
            if (satisDetali != null)
            {
                _context.SatisDetallari.Remove(satisDetali);
                _context.SaveChanges();
            }
        }

        public SatisDetali GetById(int id)
        {
            return _context.SatisDetallari
                .Include(sd => sd.Mehsul)
                .Include(sd => sd.Satis)
                .FirstOrDefault(sd => sd.Id == id);
        }

        public List<SatisDetali> GetBySatisId(int satisId)
        {
            return _context.SatisDetallari
                .Include(sd => sd.Mehsul)
                    .ThenInclude(m => m.Kateqoriya)
                .Include(sd => sd.Mehsul)
                    .ThenInclude(m => m.Vahid)
                .Where(sd => sd.SatisId == satisId)
                .OrderBy(sd => sd.Id)
                .ToList();
        }

        public List<SatisDetali> GetByMehsulId(int mehsulId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.SatisDetallari
                .Include(sd => sd.Satis)
                .Include(sd => sd.Mehsul)
                .Where(sd => sd.MehsulId == mehsulId);

            if (startDate.HasValue)
                query = query.Where(sd => sd.Satis.SatisTarixi >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(sd => sd.Satis.SatisTarixi <= endDate.Value);

            return query.OrderByDescending(sd => sd.Satis.SatisTarixi).ToList();
        }

        public List<SatisDetali> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            return _context.SatisDetallari
                .Include(sd => sd.Satis)
                .Include(sd => sd.Mehsul)
                .Where(sd => sd.Satis.SatisTarixi >= startDate && 
                            sd.Satis.SatisTarixi <= endDate &&
                            sd.Satis.Status != "İptal Edilmiş")
                .OrderByDescending(sd => sd.Satis.SatisTarixi)
                .ToList();
        }

        public decimal GetTotalQuantitySoldByMehsul(int mehsulId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.SatisDetallari
                .Include(sd => sd.Satis)
                .Where(sd => sd.MehsulId == mehsulId && sd.Satis.Status != "İptal Edilmiş");

            if (startDate.HasValue)
                query = query.Where(sd => sd.Satis.SatisTarixi >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(sd => sd.Satis.SatisTarixi <= endDate.Value);

            return query.Sum(sd => sd.Miqdar);
        }

        public decimal GetTotalRevenueByMehsul(int mehsulId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.SatisDetallari
                .Include(sd => sd.Satis)
                .Where(sd => sd.MehsulId == mehsulId && sd.Satis.Status != "İptal Edilmiş");

            if (startDate.HasValue)
                query = query.Where(sd => sd.Satis.SatisTarixi >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(sd => sd.Satis.SatisTarixi <= endDate.Value);

            return query.Sum(sd => sd.UmumiQiymet);
        }

        public List<SatisDetali> GetTopSellingProducts(DateTime startDate, DateTime endDate, int topCount = 10)
        {
            return _context.SatisDetallari
                .Include(sd => sd.Satis)
                .Include(sd => sd.Mehsul)
                .Where(sd => sd.Satis.SatisTarixi >= startDate && 
                            sd.Satis.SatisTarixi <= endDate &&
                            sd.Satis.Status != "İptal Edilmiş")
                .GroupBy(sd => sd.MehsulId)
                .Select(g => new
                {
                    MehsulId = g.Key,
                    ToplamMiqdar = g.Sum(sd => sd.Miqdar),
                    ToplamMebleg = g.Sum(sd => sd.UmumiQiymet),
                    SatisDetali = g.First()
                })
                .OrderByDescending(x => x.ToplamMiqdar)
                .Take(topCount)
                .Select(x => x.SatisDetali)
                .ToList();
        }

        public List<object> GetSalesAnalyticsByProduct(DateTime startDate, DateTime endDate)
        {
            return _context.SatisDetallari
                .Include(sd => sd.Satis)
                .Include(sd => sd.Mehsul)
                .Where(sd => sd.Satis.SatisTarixi >= startDate && 
                            sd.Satis.SatisTarixi <= endDate &&
                            sd.Satis.Status != "İptal Edilmiş")
                .GroupBy(sd => new { sd.MehsulId, sd.Mehsul.Ad })
                .Select(g => new
                {
                    MehsulId = g.Key.MehsulId,
                    MehsulAdi = g.Key.Ad,
                    ToplamMiqdar = g.Sum(sd => sd.Miqdar),
                    ToplamMebleg = g.Sum(sd => sd.UmumiQiymet),
                    SatisSayi = g.Count(),
                    OrtalamaMiqdar = g.Average(sd => sd.Miqdar),
                    OrtalamaQiymet = g.Average(sd => sd.VahidQiymeti)
                })
                .OrderByDescending(x => x.ToplamMebleg)
                .Cast<object>()
                .ToList();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}