using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AzAgroPOS.Entities.Domain;

namespace AzAgroPOS.DAL.Repositories
{
    public class TedarukcuOdemeRepository : IDisposable
    {
        private readonly AzAgroDbContext _context;

        public TedarukcuOdemeRepository(AzAgroDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public int Add(TedarukcuOdeme odeme)
        {
            _context.TedarukcuOdemeleri.Add(odeme);
            _context.SaveChanges();
            return odeme.Id;
        }

        public void Update(TedarukcuOdeme odeme)
        {
            odeme.YenilenmeTarixi = DateTime.Now;
            _context.TedarukcuOdemeleri.Update(odeme);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var odeme = _context.TedarukcuOdemeleri.Find(id);
            if (odeme != null)
            {
                _context.TedarukcuOdemeleri.Remove(odeme);
                _context.SaveChanges();
            }
        }

        public TedarukcuOdeme GetById(int id)
        {
            return _context.TedarukcuOdemeleri
                .Include(o => o.Tedarukcu)
                .Include(o => o.AlisSeined)
                .Include(o => o.YaradanIstifadeci)
                .Include(o => o.TesdiqleyenIstifadeci)
                .FirstOrDefault(o => o.Id == id);
        }

        public List<TedarukcuOdeme> GetAll()
        {
            return _context.TedarukcuOdemeleri
                .Include(o => o.Tedarukcu)
                .Include(o => o.AlisSeined)
                .Include(o => o.YaradanIstifadeci)
                .OrderByDescending(o => o.OdemeTarixi)
                .ToList();
        }

        public List<TedarukcuOdeme> GetByTedarukcu(int tedarukcuId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.TedarukcuOdemeleri
                .Include(o => o.Tedarukcu)
                .Include(o => o.AlisSeined)
                .Where(o => o.TedarukcuId == tedarukcuId);

            if (startDate.HasValue)
                query = query.Where(o => o.OdemeTarixi >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(o => o.OdemeTarixi <= endDate.Value);

            return query.OrderByDescending(o => o.OdemeTarixi).ToList();
        }

        public List<TedarukcuOdeme> GetByAlisSened(int alisSenedId)
        {
            return _context.TedarukcuOdemeleri
                .Include(o => o.Tedarukcu)
                .Include(o => o.YaradanIstifadeci)
                .Where(o => o.AlisSenedId == alisSenedId)
                .OrderBy(o => o.OdemeTarixi)
                .ToList();
        }

        public List<TedarukcuOdeme> GetByStatus(string status)
        {
            return _context.TedarukcuOdemeleri
                .Include(o => o.Tedarukcu)
                .Include(o => o.AlisSeined)
                .Where(o => o.Status == status)
                .OrderByDescending(o => o.OdemeTarixi)
                .ToList();
        }

        public List<TedarukcuOdeme> GetByOdemeNovu(string odemeNovu, DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.TedarukcuOdemeleri
                .Include(o => o.Tedarukcu)
                .Where(o => o.OdemeNovu == odemeNovu);

            if (startDate.HasValue)
                query = query.Where(o => o.OdemeTarixi >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(o => o.OdemeTarixi <= endDate.Value);

            return query.OrderByDescending(o => o.OdemeTarixi).ToList();
        }

        public List<TedarukcuOdeme> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            return _context.TedarukcuOdemeleri
                .Include(o => o.Tedarukcu)
                .Include(o => o.AlisSeined)
                .Where(o => o.OdemeTarixi >= startDate && o.OdemeTarixi <= endDate)
                .OrderByDescending(o => o.OdemeTarixi)
                .ToList();
        }

        public List<TedarukcuOdeme> GetPendingPayments()
        {
            return _context.TedarukcuOdemeleri
                .Include(o => o.Tedarukcu)
                .Include(o => o.AlisSeined)
                .Where(o => o.Status == "Gözləyir")
                .OrderBy(o => o.OdemeTarixi)
                .ToList();
        }

        public decimal GetTotalPaymentsByTedarukcu(int tedarukcuId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.TedarukcuOdemeleri
                .Where(o => o.TedarukcuId == tedarukcuId && o.Status == "Tamamlandı");

            if (startDate.HasValue)
                query = query.Where(o => o.OdemeTarixi >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(o => o.OdemeTarixi <= endDate.Value);

            return query.Sum(o => o.OdemeMeblegi);
        }

        public bool OdemeNomresiMevcudMu(string odemeNomresi, int? excludeId = null)
        {
            var query = _context.TedarukcuOdemeleri.Where(o => o.OdemeNomresi == odemeNomresi);
            if (excludeId.HasValue)
            {
                query = query.Where(o => o.Id != excludeId.Value);
            }
            return query.Any();
        }

        public List<object> GetPaymentSummaryByDate(DateTime startDate, DateTime endDate)
        {
            return _context.TedarukcuOdemeleri
                .Where(o => o.OdemeTarixi >= startDate && 
                           o.OdemeTarixi <= endDate && 
                           o.Status == "Tamamlandı")
                .GroupBy(o => o.OdemeTarixi.Date)
                .Select(g => new
                {
                    Tarix = g.Key,
                    ToplamMebleg = g.Sum(o => o.OdemeMeblegi),
                    OdemeSayi = g.Count(),
                    NagdMebleg = g.Where(o => o.OdemeNovu == "Nağd").Sum(o => o.OdemeMeblegi),
                    BankMebleg = g.Where(o => o.OdemeNovu == "Bank Köçürməsi").Sum(o => o.OdemeMeblegi),
                    CekMebleg = g.Where(o => o.OdemeNovu == "Çek").Sum(o => o.OdemeMeblegi)
                })
                .OrderByDescending(x => x.Tarix)
                .Cast<object>()
                .ToList();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}