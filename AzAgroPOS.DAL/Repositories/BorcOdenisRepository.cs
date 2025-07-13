using AzAgroPOS.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AzAgroPOS.DAL.Repositories
{
    public class BorcOdenisRepository
    {
        private readonly AzAgroDbContext _context;

        public BorcOdenisRepository(AzAgroDbContext context)
        {
            _context = context;
        }

        public IQueryable<BorcOdenis> GetAll()
        {
            return _context.BorcOdenisleri
                .Include(o => o.MusteriBorc)
                .Include(o => o.MusteriBorc.Musteri)
                .Include(o => o.QebulEdenIstifadeci);
        }

        public BorcOdenis GetById(int id)
        {
            return GetAll().FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<BorcOdenis> GetByMusteriBorcId(int musteriBorcId)
        {
            return GetAll().Where(o => o.MusteriBorcId == musteriBorcId).ToList();
        }

        public IEnumerable<BorcOdenis> GetByMusteriId(int musteriId)
        {
            return GetAll().Where(o => o.MusteriBorc.MusteriId == musteriId).ToList();
        }

        public IEnumerable<BorcOdenis> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            return GetAll().Where(o => o.OdenisTarixi >= startDate && o.OdenisTarixi <= endDate).ToList();
        }

        public IEnumerable<BorcOdenis> GetByOdenisTipi(string odenisTipi)
        {
            return GetAll().Where(o => o.OdenisTipi == odenisTipi).ToList();
        }

        public IEnumerable<BorcOdenis> GetPendingPayments()
        {
            return GetAll().Where(o => o.Status == "Gözləyir").ToList();
        }

        public decimal GetTotalPaymentsByMusteriId(int musteriId)
        {
            return GetAll()
                .Where(o => o.MusteriBorc.MusteriId == musteriId && o.Status == "Təsdiqlənmiş")
                .Sum(o => o.OdenisMeblegi);
        }

        public decimal GetTotalPaymentsByDateRange(DateTime startDate, DateTime endDate)
        {
            return GetAll()
                .Where(o => o.OdenisTarixi >= startDate && o.OdenisTarixi <= endDate && o.Status == "Təsdiqlənmiş")
                .Sum(o => o.OdenisMeblegi);
        }

        public IEnumerable<BorcOdenis> GetRecentPayments(int count = 10)
        {
            return GetAll()
                .Where(o => o.Status == "Təsdiqlənmiş")
                .OrderByDescending(o => o.OdenisTarixi)
                .Take(count)
                .ToList();
        }

        public int Add(BorcOdenis borcOdenis)
        {
            _context.BorcOdenisleri.Add(borcOdenis);
            _context.SaveChanges();
            return borcOdenis.Id;
        }

        public void Update(BorcOdenis borcOdenis)
        {
            borcOdenis.YenilenmeTarixi = DateTime.Now;
            _context.Entry(borcOdenis).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var borcOdenis = _context.BorcOdenisleri.Find(id);
            if (borcOdenis != null)
            {
                _context.BorcOdenisleri.Remove(borcOdenis);
                _context.SaveChanges();
            }
        }

        public void ConfirmPayment(int id, int confirmingUserId)
        {
            var payment = GetById(id);
            if (payment != null && payment.Status == "Gözləyir")
            {
                payment.Status = "Təsdiqlənmiş";
                payment.QebulEdenIstifadeciId = confirmingUserId;
                payment.YenilenmeTarixi = DateTime.Now;
                Update(payment);
            }
        }

        public void CancelPayment(int id)
        {
            var payment = GetById(id);
            if (payment != null && payment.Legvedileibilir)
            {
                payment.Status = "Ləğv Edilmiş";
                payment.YenilenmeTarixi = DateTime.Now;
                Update(payment);
            }
        }

        public string GenerateOdenisNomresi()
        {
            var today = DateTime.Now;
            var prefix = $"O{today:yyyyMM}";
            
            var lastNumber = _context.BorcOdenisleri
                .Where(o => o.OdenisNomresi.StartsWith(prefix))
                .Select(o => o.OdenisNomresi)
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
    }
}