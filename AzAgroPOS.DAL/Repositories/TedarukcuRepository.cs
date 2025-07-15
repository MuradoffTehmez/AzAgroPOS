using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AzAgroPOS.Entities.Domain;

namespace AzAgroPOS.DAL.Repositories
{
    public class TedarukcuRepository : IDisposable
    {
        private readonly AzAgroDbContext _context;

        public TedarukcuRepository(AzAgroDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public TedarukcuRepository()
        {

        }

        public int Add(Tedarukcu tedarukcu)
        {
            _context.Tedarukciler.Add(tedarukcu);
            _context.SaveChanges();
            return tedarukcu.Id;
        }

        public async Task<int> AddAsync(Tedarukcu tedarukcu)
        {
            using (var context = new AzAgroDbContext())
            {
                context.Tedarukciler.Add(tedarukcu);
                await context.SaveChangesAsync();
                return tedarukcu.Id;
            }
        }

        public void Update(Tedarukcu tedarukcu)
        {
            tedarukcu.YenilenmeTarixi = DateTime.Now;
            _context.Tedarukciler.Update(tedarukcu);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var tedarukcu = _context.Tedarukciler.Find(id);
            if (tedarukcu != null)
            {
                _context.Tedarukciler.Remove(tedarukcu);
                _context.SaveChanges();
            }
        }

        public Tedarukcu GetById(int id)
        {
            return _context.Tedarukciler.Find(id);
        }

        public List<Tedarukcu> GetAll()
        {
            return _context.Tedarukciler
                .OrderBy(t => t.Ad)
                .ToList();
        }

        public List<Tedarukcu> GetAllActive()
        {
            return _context.Tedarukciler
                .Where(t => t.Status == "Aktiv")
                .OrderBy(t => t.Ad)
                .ToList();
        }

        public List<Tedarukcu> Search(string searchTerm)
        {
            var term = searchTerm.ToLower();
            return _context.Tedarukciler
                .Where(t => t.Ad.ToLower().Contains(term) ||
                           t.Kod.ToLower().Contains(term) ||
                           t.VOEN.ToLower().Contains(term) ||
                           t.Email.ToLower().Contains(term))
                .OrderBy(t => t.Ad)
                .ToList();
        }

        public bool KodMevcudMu(string kod, int? excludeId = null)
        {
            var query = _context.Tedarukciler.Where(t => t.Kod == kod);
            if (excludeId.HasValue)
            {
                query = query.Where(t => t.Id != excludeId.Value);
            }
            return query.Any();
        }

        public bool VOENMevcudMu(string voen, int? excludeId = null)
        {
            var query = _context.Tedarukciler.Where(t => t.VOEN == voen);
            if (excludeId.HasValue)
            {
                query = query.Where(t => t.Id != excludeId.Value);
            }
            return query.Any();
        }

        public bool CanDelete(int id)
        {
            // Check if supplier has any related records
            var hasOrders = _context.AlisOrderleri.Any(o => o.TedarukcuId == id);
            var hasSenedler = _context.AlisSenedleri.Any(s => s.TedarukcuId == id);
            var hasOdemeler = _context.TedarukcuOdemeleri.Any(o => o.TedarukcuId == id);
            
            return !hasOrders && !hasSenedler && !hasOdemeler;
        }

        public List<Tedarukcu> GetKreditLimitiAsilanlar()
        {
            return _context.Tedarukciler
                .Where(t => t.Status == "Aktiv" && t.CariBorc >= t.KreditLimiti)
                .OrderByDescending(t => t.CariBorc)
                .ToList();
        }

        public List<Tedarukcu> GetBorcluTedarukciler()
        {
            return _context.Tedarukciler
                .Where(t => t.Status == "Aktiv" && t.CariBorc > 0)
                .OrderByDescending(t => t.CariBorc)
                .ToList();
        }

        public string GetLastKod()
        {
            return _context.Tedarukciler
                .Where(t => t.Kod.StartsWith("TED"))
                .OrderByDescending(t => t.Kod)
                .Select(t => t.Kod)
                .FirstOrDefault();
        }

        public List<object> GetPerformansRaporu(DateTime startDate, DateTime endDate)
        {
            return _context.Tedarukciler
                .Where(t => t.Status == "Aktiv")
                .Select(t => new
                {
                    TedarukcuId = t.Id,
                    TedarukcuAdi = t.Ad,
                    CariBorc = t.CariBorc,
                    KreditLimiti = t.KreditLimiti,
                    OrderSayi = t.AlisOrderleri.Count(o => o.OrderTarixi >= startDate && o.OrderTarixi <= endDate),
                    OrderMeblegi = t.AlisOrderleri
                        .Where(o => o.OrderTarixi >= startDate && o.OrderTarixi <= endDate)
                        .Sum(o => o.NetMebleg),
                    SenedSayi = t.AlisSenedleri.Count(s => s.SenedTarixi >= startDate && s.SenedTarixi <= endDate),
                    SenedMeblegi = t.AlisSenedleri
                        .Where(s => s.SenedTarixi >= startDate && s.SenedTarixi <= endDate)
                        .Sum(s => s.NetMebleg),
                    OdemeSayi = t.Odemeler.Count(o => o.OdemeTarixi >= startDate && o.OdemeTarixi <= endDate),
                    OdemeMeblegi = t.Odemeler
                        .Where(o => o.OdemeTarixi >= startDate && o.OdemeTarixi <= endDate && o.Status == "Tamamlandı")
                        .Sum(o => o.OdemeMeblegi)
                })
                .OrderByDescending(x => x.SenedMeblegi)
                .Cast<object>()
                .ToList();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}