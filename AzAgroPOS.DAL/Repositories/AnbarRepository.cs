using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AzAgroPOS.Entities.Domain;

namespace AzAgroPOS.DAL.Repositories
{
    public class AnbarRepository
    {
        private readonly AzAgroDbContext _context;

        public AnbarRepository()
        {
            _context = new AzAgroDbContext();
        }

        public int Add(Anbar anbar)
        {
            _context.Anbarlar.Add(anbar);
            _context.SaveChanges();
            return anbar.Id;
        }

        public void Update(Anbar anbar)
        {
            anbar.YenilenmeTarixi = DateTime.Now;
            _context.Anbarlar.Update(anbar);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var anbar = _context.Anbarlar.Find(id);
            if (anbar != null)
            {
                _context.Anbarlar.Remove(anbar);
                _context.SaveChanges();
            }
        }

        public Anbar GetById(int id)
        {
            return _context.Anbarlar.Find(id);
        }

        public List<Anbar> GetAll()
        {
            return _context.Anbarlar
                .OrderBy(a => a.Ad)
                .ToList();
        }

        public List<Anbar> GetAllActive()
        {
            return _context.Anbarlar
                .Where(a => a.Status == "Aktiv")
                .OrderBy(a => a.Ad)
                .ToList();
        }

        public bool KodMevcudMu(string kod, int? excludeId = null)
        {
            var query = _context.Anbarlar.Where(a => a.Kod == kod);
            if (excludeId.HasValue)
            {
                query = query.Where(a => a.Id != excludeId.Value);
            }
            return query.Any();
        }

        public bool CanDelete(int id)
        {
            // Check if warehouse has any stock
            var hasStock = _context.AnbarQaliqları.Any(q => q.AnbarId == id && q.MovcudMiqdar > 0);
            var hasMovements = _context.AnbarHereketleri.Any(h => h.AnbarId == id);
            var hasTransfers = _context.AnbarTransferleri.Any(t => t.MenbAnbarId == id || t.HedefAnbarId == id);
            
            return !hasStock && !hasMovements && !hasTransfers;
        }

        public string GetLastKod()
        {
            return _context.Anbarlar
                .Where(a => a.Kod.StartsWith("ANB"))
                .OrderByDescending(a => a.Kod)
                .Select(a => a.Kod)
                .FirstOrDefault();
        }

        public AnbarStatistikleri GetStatistikalar(int anbarId)
        {
            var anbar = _context.Anbarlar
                .Include(a => a.AnbarQaliqları)
                    .ThenInclude(q => q.Mehsul)
                .Include(a => a.AnbarHereketleri)
                .FirstOrDefault(a => a.Id == anbarId);

            if (anbar == null)
                return new AnbarStatistikleri();

            var qaliqlar = anbar.AnbarQaliqları.Where(q => q.MovcudMiqdar > 0).ToList();

            return new AnbarStatistikleri
            {
                UmumiMehsulSayi = qaliqlar.Count,
                UmumiMehsulMiqdari = qaliqlar.Sum(q => q.MovcudMiqdar),
                UmumiDeger = qaliqlar.Sum(q => q.UmumiDeger),
                MinimumSeviyyeAltindaMehsulSayi = qaliqlar.Count(q => q.MinimumSeviyyedenAsagi),
                MaksimumSeviyyeUstundeMehsulSayi = qaliqlar.Count(q => q.MaksimumSeviyyedenYuxari),
                StoktanKenardaMehsulSayi = qaliqlar.Count(q => q.MovcudMiqdar == 0),
                SonHereketTarixi = anbar.AnbarHereketleri.OrderByDescending(h => h.HereketTarixi).FirstOrDefault()?.HereketTarixi
            };
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}