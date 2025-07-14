using AzAgroPOS.Entities.Domain;
using AzAgroPOS.Entities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AzAgroPOS.DAL.Repositories
{
    public class MusteriRepository : IDisposable
    {
        private readonly AzAgroDbContext _context;

        public MusteriRepository(AzAgroDbContext context = null)
        {
            _context = context ?? new AzAgroDbContext();
        }

        public IQueryable<Musteri> GetAll()
        {
            return _context.Musteriler
                .Include(m => m.MusteriQrupu)
                .Include(m => m.YaradanIstifadeci);
        }

        public IQueryable<Musteri> GetActive()
        {
            return GetAll().Where(m => m.Status == SystemConstants.Status.Active);
        }

        public Musteri GetById(int id)
        {
            return GetAll().FirstOrDefault(m => m.Id == id);
        }

        public Musteri GetByCode(string musteriKodu)
        {
            return GetAll().FirstOrDefault(m => m.MusteriKodu == musteriKodu);
        }

        public IQueryable<Musteri> GetByGroup(int qrupId)
        {
            return GetActive().Where(m => m.MusteriQrupuId == qrupId);
        }

        public IQueryable<Musteri> GetVIPCustomers()
        {
            return GetActive().Where(m => m.UmumiAlis > 10000);
        }

        public IQueryable<Musteri> GetNewCustomers(int days = 30)
        {
            var date = DateTime.Now.AddDays(-days);
            return GetActive().Where(m => m.YaradilmaTarixi >= date);
        }

        public IQueryable<Musteri> GetInactiveCustomers(int days = 90)
        {
            var date = DateTime.Now.AddDays(-days);
            return GetActive().Where(m => !m.SonZiyaretTarixi.HasValue || m.SonZiyaretTarixi < date);
        }

        public IQueryable<Musteri> GetCustomersWithDebt()
        {
            return GetActive().Where(m => m.CariBorc > 0);
        }

        public IQueryable<Musteri> GetCustomersOverCreditLimit()
        {
            return GetActive().Where(m => m.CariBorc > m.KreditLimiti && m.KreditLimiti > 0);
        }

        public IQueryable<Musteri> SearchCustomers(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
                return GetActive();

            searchTerm = searchTerm.ToLower();
            return GetActive().Where(m => 
                m.Ad.ToLower().Contains(searchTerm) ||
                m.Soyad.ToLower().Contains(searchTerm) ||
                m.SirketAdi.ToLower().Contains(searchTerm) ||
                m.MusteriKodu.ToLower().Contains(searchTerm) ||
                m.Telefon.Contains(searchTerm) ||
                m.MobilTelefon.Contains(searchTerm) ||
                m.Email.ToLower().Contains(searchTerm));
        }

        public Musteri Add(Musteri musteri)
        {
            if (string.IsNullOrEmpty(musteri.MusteriKodu))
            {
                musteri.MusteriKodu = GenerateCustomerCode();
            }

            _context.Musteriler.Add(musteri);
            _context.SaveChanges();
            return musteri;
        }

        public Musteri Update(Musteri musteri)
        {
            musteri.YenilenmeTarixi = DateTime.Now;
            _context.Entry(musteri).State = EntityState.Modified;
            _context.SaveChanges();
            return musteri;
        }

        public void Delete(int id)
        {
            var musteri = GetById(id);
            if (musteri != null)
            {
                musteri.Status = SystemConstants.Status.Deleted;
                musteri.YenilenmeTarixi = DateTime.Now;
                Update(musteri);
            }
        }

        public void HardDelete(int id)
        {
            var musteri = _context.Musteriler.Find(id);
            if (musteri != null)
            {
                _context.Musteriler.Remove(musteri);
                _context.SaveChanges();
            }
        }

        public bool IsCodeExists(string musteriKodu, int? excludeId = null)
        {
            var query = _context.Musteriler.Where(m => m.MusteriKodu == musteriKodu);
            if (excludeId.HasValue)
                query = query.Where(m => m.Id != excludeId.Value);
            return query.Any();
        }

        public bool IsEmailExists(string email, int? excludeId = null)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            var query = _context.Musteriler.Where(m => m.Email == email);
            if (excludeId.HasValue)
                query = query.Where(m => m.Id != excludeId.Value);
            return query.Any();
        }

        public void UpdateDebtAmount(int musteriId, decimal yeniBorc)
        {
            var musteri = GetById(musteriId);
            if (musteri != null)
            {
                musteri.CariBorc = yeniBorc;
                musteri.YenilenmeTarixi = DateTime.Now;
                Update(musteri);
            }
        }

        public void UpdatePurchaseAmount(int musteriId, decimal alistutar)
        {
            var musteri = GetById(musteriId);
            if (musteri != null)
            {
                musteri.UmumiAlis += alistutar;
                musteri.ZiyaretSayi += 1;
                musteri.SonZiyaretTarixi = DateTime.Now;
                musteri.YenilenmeTarixi = DateTime.Now;
                Update(musteri);
            }
        }

        public List<object> GetCustomerStatistics()
        {
            return _context.Musteriler
                .Where(m => m.Status == SystemConstants.Status.Active)
                .GroupBy(m => m.MusteriTipi)
                .Select(g => new 
                {
                    MusteriTipi = g.Key,
                    Sayi = g.Count(),
                    UmumiAlis = g.Sum(m => m.UmumiAlis),
                    OrtalamAlis = g.Average(m => m.UmumiAlis),
                    UmumiBorc = g.Sum(m => m.CariBorc)
                })
                .Cast<object>()
                .ToList();
        }

        public List<object> GetTopCustomers(int count = 10)
        {
            return _context.Musteriler
                .Where(m => m.Status == SystemConstants.Status.Active)
                .OrderByDescending(m => m.UmumiAlis)
                .Take(count)
                .Select(m => new 
                {
                    m.Id,
                    m.MusteriKodu,
                    TamAd = m.Ad + " " + m.Soyad,
                    m.SirketAdi,
                    m.UmumiAlis,
                    m.CariBorc,
                    m.ZiyaretSayi,
                    m.SonZiyaretTarixi
                })
                .Cast<object>()
                .ToList();
        }

        private string GenerateCustomerCode()
        {
            var lastCode = _context.Musteriler
                .Where(m => m.MusteriKodu.StartsWith("MST"))
                .OrderByDescending(m => m.MusteriKodu)
                .Select(m => m.MusteriKodu)
                .FirstOrDefault();

            if (string.IsNullOrEmpty(lastCode))
                return "MST001";

            var numPart = lastCode.Substring(3);
            if (int.TryParse(numPart, out int num))
            {
                return $"MST{(num + 1):D3}";
            }
            return "MST001";
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}