using AzAgroPOS.Entities.Domain;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AzAgroPOS.DAL.Repositories
{
    public class TamirIsiRepository : IDisposable
    {
        private readonly AzAgroDbContext _context;

        public TamirIsiRepository(AzAgroDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IQueryable<TamirIsi> GetAll()
        {
            return _context.TamirIsleri
                .Include(t => t.Musteri)
                .Include(t => t.QebulEdenIstifadeci)
                .Include(t => t.TeyinEdilenIstifadeci)
                .Include(t => t.TehvilEdenIstifadeci)
                .Include(t => t.TamirMerheleri)
                .Include(t => t.TamirMerheleri.Select(m => m.TeyinEdilenIstifadeci));
        }

        public TamirIsi GetById(int id)
        {
            return GetAll().FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<TamirIsi> GetByStatus(string status)
        {
            return GetAll().Where(t => t.Status == status).ToList();
        }

        public IEnumerable<TamirIsi> GetByMusteriId(int musteriId)
        {
            return GetAll().Where(t => t.MusteriId == musteriId).ToList();
        }

        public IEnumerable<TamirIsi> GetByTeyinEdilenIstifadeci(int istifadeciId)
        {
            return GetAll().Where(t => t.TeyinEdilenIstifadeciId == istifadeciId).ToList();
        }

        public IEnumerable<TamirIsi> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            return GetAll().Where(t => t.QebulTarixi >= startDate && t.QebulTarixi <= endDate).ToList();
        }

        public IEnumerable<TamirIsi> GetOverdueRepairs()
        {
            var today = DateTime.Now.Date;
            return GetAll()
                .Where(t => t.TaxminiBitirmeTarixi.HasValue && 
                           t.TaxminiBitirmeTarixi.Value < today && 
                           t.Status != "Təhvil Verildi" && t.Status != "İptal")
                .ToList();
        }

        public IEnumerable<TamirIsi> GetReadyForDelivery()
        {
            return GetAll().Where(t => t.Status == "Hazır").ToList();
        }

        public IEnumerable<TamirIsi> GetActiveRepairs()
        {
            return GetAll()
                .Where(t => t.Status != "Təhvil Verildi" && t.Status != "İptal")
                .ToList();
        }

        public IEnumerable<TamirIsi> GetByPrioritet(string prioritet)
        {
            return GetAll().Where(t => t.Prioritet == prioritet).ToList();
        }

        public IEnumerable<TamirIsi> GetCompletedRepairs()
        {
            return GetAll().Where(t => t.Status == "Təhvil Verildi").ToList();
        }

        public int GetCountByStatus(string status)
        {
            return _context.TamirIsleri.Count(t => t.Status == status);
        }

        public decimal GetTotalRevenue(DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.TamirIsleri.Where(t => t.Status == "Təhvil Verildi");
            
            if (startDate.HasValue)
                query = query.Where(t => t.TehvilTarixi >= startDate.Value);
            
            if (endDate.HasValue)
                query = query.Where(t => t.TehvilTarixi <= endDate.Value);
            
            return query.Sum(t => t.SonQiymet);
        }

        public int Add(TamirIsi tamirIsi)
        {
            _context.TamirIsleri.Add(tamirIsi);
            _context.SaveChanges();
            return tamirIsi.Id;
        }

        public void Update(TamirIsi tamirIsi)
        {
            tamirIsi.YenilenmeTarixi = DateTime.Now;
            _context.Entry(tamirIsi).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var tamirIsi = _context.TamirIsleri.Find(id);
            if (tamirIsi != null)
            {
                _context.TamirIsleri.Remove(tamirIsi);
                _context.SaveChanges();
            }
        }

        public void UpdateStatus(int id, string newStatus, int istifadeciId)
        {
            var tamirIsi = GetById(id);
            if (tamirIsi != null)
            {
                tamirIsi.Status = newStatus;
                tamirIsi.YenilenmeTarixi = DateTime.Now;
                
                if (newStatus == "Təhvil Verildi")
                {
                    tamirIsi.TehvilTarixi = DateTime.Now;
                    tamirIsi.TehvilEdenIstifadeciId = istifadeciId;
                }
                
                Update(tamirIsi);
            }
        }

        public void AssignToUser(int tamirId, int istifadeciId)
        {
            var tamirIsi = GetById(tamirId);
            if (tamirIsi != null)
            {
                tamirIsi.TeyinEdilenIstifadeciId = istifadeciId;
                Update(tamirIsi);
            }
        }

        public string GenerateTamirNomresi()
        {
            var today = DateTime.Now;
            var prefix = $"T{today:yyyyMM}";
            
            var lastNumber = _context.TamirIsleri
                .Where(t => t.TamirNomresi.StartsWith(prefix))
                .Select(t => t.TamirNomresi)
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
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}