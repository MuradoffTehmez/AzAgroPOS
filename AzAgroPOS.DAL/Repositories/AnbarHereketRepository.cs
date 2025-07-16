using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AzAgroPOS.Entities.Domain;

namespace AzAgroPOS.DAL.Repositories
{
    public class AnbarHereketRepository : IDisposable
    {
        private readonly AzAgroDbContext _context;

        public AnbarHereketRepository(AzAgroDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public int Add(AnbarHereketi hareket)
        {
            _context.AnbarHereketleri.Add(hareket);
            return hareket.Id;
        }

        public void Update(AnbarHereketi hareket)
        {
            _context.AnbarHereketleri.Update(hareket);
        }

        public void Delete(int id)
        {
            var hareket = _context.AnbarHereketleri.Find(id);
            if (hareket != null)
            {
                _context.AnbarHereketleri.Remove(hareket);
                }
        }

        public AnbarHereketi GetById(int id)
        {
            return _context.AnbarHereketleri
                .Include(h => h.Anbar)
                .Include(h => h.Mehsul)
                    .ThenInclude(m => m.Kateqoriya)
                .Include(h => h.Mehsul)
                    .ThenInclude(m => m.Vahid)
                .Include(h => h.Istifadeci)
                .FirstOrDefault(h => h.Id == id);
        }

        public List<AnbarHereketi> GetByAnbar(int anbarId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.AnbarHereketleri
                .Include(h => h.Mehsul)
                    .ThenInclude(m => m.Kateqoriya)
                .Include(h => h.Mehsul)
                    .ThenInclude(m => m.Vahid)
                .Include(h => h.Istifadeci)
                .Where(h => h.AnbarId == anbarId);

            if (startDate.HasValue)
                query = query.Where(h => h.HereketTarixi >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(h => h.HereketTarixi <= endDate.Value);

            return query.OrderByDescending(h => h.HereketTarixi).ToList();
        }

        public List<AnbarHereketi> GetByMehsul(int mehsulId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.AnbarHereketleri
                .Include(h => h.Anbar)
                .Include(h => h.Mehsul)
                .Include(h => h.Istifadeci)
                .Where(h => h.MehsulId == mehsulId);

            if (startDate.HasValue)
                query = query.Where(h => h.HereketTarixi >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(h => h.HereketTarixi <= endDate.Value);

            return query.OrderByDescending(h => h.HereketTarixi).ToList();
        }

        public List<AnbarHereketi> GetAll(DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.AnbarHereketleri
                .Include(h => h.Anbar)
                .Include(h => h.Mehsul)
                    .ThenInclude(m => m.Kateqoriya)
                .Include(h => h.Istifadeci)
                .AsQueryable();

            if (startDate.HasValue)
                query = query.Where(h => h.HereketTarixi >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(h => h.HereketTarixi <= endDate.Value);

            return query.OrderByDescending(h => h.HereketTarixi).ToList();
        }

        public List<AnbarHereketi> GetByHereketTipi(string hereketTipi, DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.AnbarHereketleri
                .Include(h => h.Anbar)
                .Include(h => h.Mehsul)
                .Include(h => h.Istifadeci)
                .Where(h => h.HereketTipi == hereketTipi);

            if (startDate.HasValue)
                query = query.Where(h => h.HereketTarixi >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(h => h.HereketTarixi <= endDate.Value);

            return query.OrderByDescending(h => h.HereketTarixi).ToList();
        }

        public List<AnbarHereketi> GetBySenedNomresi(string senedNomresi)
        {
            return _context.AnbarHereketleri
                .Include(h => h.Anbar)
                .Include(h => h.Mehsul)
                .Include(h => h.Istifadeci)
                .Where(h => h.SenedNomresi == senedNomresi)
                .OrderBy(h => h.HereketTarixi)
                .ToList();
        }

        public List<AnbarHereketi> GetByIstifadeci(int istifadeciId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.AnbarHereketleri
                .Include(h => h.Anbar)
                .Include(h => h.Mehsul)
                .Include(h => h.Istifadeci)
                .Where(h => h.IstifadeciId == istifadeciId);

            if (startDate.HasValue)
                query = query.Where(h => h.HereketTarixi >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(h => h.HereketTarixi <= endDate.Value);

            return query.OrderByDescending(h => h.HereketTarixi).ToList();
        }

        public List<object> GetHereketRaporu(DateTime startDate, DateTime endDate, int? anbarId = null)
        {
            var query = _context.AnbarHereketleri
                .Include(h => h.Anbar)
                .Include(h => h.Mehsul)
                .Where(h => h.HereketTarixi >= startDate && h.HereketTarixi <= endDate);

            if (anbarId.HasValue)
                query = query.Where(h => h.AnbarId == anbarId.Value);

            return query
                .GroupBy(h => new { h.HereketTarixi.Date, h.HereketTipi })
                .Select(g => new
                {
                    Tarix = g.Key.Date,
                    HereketTipi = g.Key.HereketTipi,
                    HereketSayi = g.Count(),
                    ToplamMiqdar = g.Sum(h => h.Miqdar),
                    ToplamMebleg = g.Sum(h => h.UmumiMebleg),
                    OrtalamaMiqdar = g.Average(h => h.Miqdar)
                })
                .OrderByDescending(x => x.Tarix)
                .ThenBy(x => x.HereketTipi)
                .Cast<object>()
                .ToList();
        }

        public List<object> GetMehsulHereketAnalizi(int mehsulId, DateTime startDate, DateTime endDate)
        {
            return _context.AnbarHereketleri
                .Include(h => h.Anbar)
                .Where(h => h.MehsulId == mehsulId && 
                           h.HereketTarixi >= startDate && 
                           h.HereketTarixi <= endDate)
                .GroupBy(h => new { h.AnbarId, h.Anbar.Ad })
                .Select(g => new
                {
                    AnbarId = g.Key.AnbarId,
                    AnbarAdi = g.Key.Ad,
                    GirisMiqdari = g.Where(h => h.GirisHereketi).Sum(h => h.Miqdar),
                    CixisMiqdari = g.Where(h => h.CixisHereketi).Sum(h => h.Miqdar),
                    NetMiqdar = g.Where(h => h.GirisHereketi).Sum(h => h.Miqdar) - 
                               g.Where(h => h.CixisHereketi).Sum(h => h.Miqdar),
                    HereketSayi = g.Count(),
                    ToplamMebleg = g.Sum(h => h.UmumiMebleg)
                })
                .OrderByDescending(x => x.HereketSayi)
                .Cast<object>()
                .ToList();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}