using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AzAgroPOS.Entities.Domain;

namespace AzAgroPOS.DAL.Repositories
{
    public class AnbarQalikRepository
    {
        private readonly AzAgroDbContext _context;

        public AnbarQalikRepository()
        {
            _context = new AzAgroDbContext();
        }

        public int Add(AnbarQalik qalik)
        {
            _context.AnbarQaliqları.Add(qalik);
            _context.SaveChanges();
            return qalik.Id;
        }

        public void Update(AnbarQalik qalik)
        {
            qalik.YenilenmeTarixi = DateTime.Now;
            _context.AnbarQaliqları.Update(qalik);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var qalik = _context.AnbarQaliqları.Find(id);
            if (qalik != null)
            {
                _context.AnbarQaliqları.Remove(qalik);
                _context.SaveChanges();
            }
        }

        public AnbarQalik GetById(int id)
        {
            return _context.AnbarQaliqları
                .Include(q => q.Anbar)
                .Include(q => q.Mehsul)
                    .ThenInclude(m => m.Kateqoriya)
                .Include(q => q.Mehsul)
                    .ThenInclude(m => m.Vahid)
                .FirstOrDefault(q => q.Id == id);
        }

        public AnbarQalik GetByAnbarVeMehsul(int anbarId, int mehsulId)
        {
            return _context.AnbarQaliqları
                .Include(q => q.Anbar)
                .Include(q => q.Mehsul)
                    .ThenInclude(m => m.Kateqoriya)
                .Include(q => q.Mehsul)
                    .ThenInclude(m => m.Vahid)
                .FirstOrDefault(q => q.AnbarId == anbarId && q.MehsulId == mehsulId);
        }

        public List<AnbarQalik> GetByAnbar(int anbarId)
        {
            return _context.AnbarQaliqları
                .Include(q => q.Mehsul)
                    .ThenInclude(m => m.Kateqoriya)
                .Include(q => q.Mehsul)
                    .ThenInclude(m => m.Vahid)
                .Where(q => q.AnbarId == anbarId)
                .OrderBy(q => q.Mehsul.Ad)
                .ToList();
        }

        public List<AnbarQalik> GetByMehsul(int mehsulId)
        {
            return _context.AnbarQaliqları
                .Include(q => q.Anbar)
                .Include(q => q.Mehsul)
                .Where(q => q.MehsulId == mehsulId)
                .OrderBy(q => q.Anbar.Ad)
                .ToList();
        }

        public List<AnbarQalik> GetAll()
        {
            return _context.AnbarQaliqları
                .Include(q => q.Anbar)
                .Include(q => q.Mehsul)
                    .ThenInclude(m => m.Kateqoriya)
                .OrderBy(q => q.Anbar.Ad)
                .ThenBy(q => q.Mehsul.Ad)
                .ToList();
        }

        public List<AnbarQalik> GetMinimumSeviyyedenAsagi()
        {
            // DÜZƏLİŞ: Sorğu client-side evaluation üçün yenidən yazıldı
            var allQaliqlar = _context.AnbarQaliqları
                .Include(q => q.Anbar)
                .Include(q => q.Mehsul)
                    .ThenInclude(m => m.Kateqoriya)
                .ToList();

            return allQaliqlar
                .Where(q => q.MovcudMiqdar <= q.MinimumMiqdar && q.MinimumMiqdar > 0)
                .OrderBy(q => q.MovcudMiqdar)
                .ToList();
        }

        public List<AnbarQalik> GetMaksimumSeviyyedenYuxari()
        {
            // DÜZƏLİŞ: Sorğu client-side evaluation üçün yenidən yazıldı
            var allQaliqlar = _context.AnbarQaliqları
                .Include(q => q.Anbar)
                .Include(q => q.Mehsul)
                    .ThenInclude(m => m.Kateqoriya)
                .ToList();

            return allQaliqlar
                .Where(q => q.MaksimumMiqdar > 0 && q.MovcudMiqdar >= q.MaksimumMiqdar)
                .OrderByDescending(q => q.MovcudMiqdar)
                .ToList();
        }

        public List<AnbarQalik> GetStoktanKenarda()
        {
            return _context.AnbarQaliqları
                .Include(q => q.Anbar)
                .Include(q => q.Mehsul)
                    .ThenInclude(m => m.Kateqoriya)
                .Where(q => q.MovcudMiqdar == 0)
                .OrderBy(q => q.Anbar.Ad)
                .ThenBy(q => q.Mehsul.Ad)
                .ToList();
        }

        public List<AnbarQalik> GetWithStock()
        {
            return _context.AnbarQaliqları
                .Include(q => q.Anbar)
                .Include(q => q.Mehsul)
                    .ThenInclude(m => m.Kateqoriya)
                .Where(q => q.MovcudMiqdar > 0)
                .OrderBy(q => q.Anbar.Ad)
                .ThenBy(q => q.Mehsul.Ad)
                .ToList();
        }

        public List<object> GetStokDurumRaporu(int? anbarId = null)
        {
            var query = _context.AnbarQaliqları
                .Include(q => q.Anbar)
                .Include(q => q.Mehsul)
                    .ThenInclude(m => m.Kateqoriya)
                .AsQueryable();

            if (anbarId.HasValue)
                query = query.Where(q => q.AnbarId == anbarId.Value);

            return query
                .GroupBy(q => new { AnbarAdi = q.Anbar.Ad, MehsulAdi = q.Mehsul.Ad, q.MehsulId })
                .Select(g => new
                {
                    AnbarAdi = g.Key.AnbarAdi,
                    MehsulAdi = g.Key.MehsulAdi,
                    MehsulId = g.Key.MehsulId,
                    MovcudMiqdar = g.Sum(q => q.MovcudMiqdar),
                    RezervMiqdar = g.Sum(q => q.RezervMiqdar),
                    ElcatanMiqdar = g.Sum(q => q.ElcatanMiqdar),
                    MinimumMiqdar = g.Max(q => q.MinimumMiqdar),
                    MaksimumMiqdar = g.Max(q => q.MaksimumMiqdar),
                    UmumiDeger = g.Sum(q => q.UmumiDeger),
                    OrtalamaQiymet = g.Average(q => q.OrtalamaAlisQiymeti),
                    SonAlısTarixi = g.Max(q => q.SonAlısTarixi),
                    SonSatısTarixi = g.Max(q => q.SonSatısTarixi),
                    SeviyyeDurumu = g.FirstOrDefault().SeviyyeDurumu
                })
                .OrderBy(x => x.AnbarAdi)
                .ThenBy(x => x.MehsulAdi)
                .Cast<object>()
                .ToList();
        }

        public decimal GetTotalStockValue(int? anbarId = null)
        {
            var query = _context.AnbarQaliqları.AsQueryable();

            if (anbarId.HasValue)
                query = query.Where(q => q.AnbarId == anbarId.Value);

            return query.Sum(q => q.UmumiDeger);
        }

        public int GetTotalProductCount(int? anbarId = null)
        {
            var query = _context.AnbarQaliqları.Where(q => q.MovcudMiqdar > 0);

            if (anbarId.HasValue)
                query = query.Where(q => q.AnbarId == anbarId.Value);

            return query.Count();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}