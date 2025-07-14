using AzAgroPOS.Entities.Domain;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AzAgroPOS.DAL.Repositories
{
    public class TamirMerheleRepository : IDisposable
    {
        private readonly AzAgroDbContext _context;

        public TamirMerheleRepository(AzAgroDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IQueryable<TamirMerhele> GetAll()
        {
            return _context.TamirMerheleri
                .Include(m => m.TamirIsi)
                .Include(m => m.TamirIsi.Musteri)
                .Include(m => m.TeyinEdilenIstifadeci);
        }

        public TamirMerhele GetById(int id)
        {
            return GetAll().FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<TamirMerhele> GetByTamirIsiId(int tamirIsiId)
        {
            return GetAll()
                .Where(m => m.TamirIsiId == tamirIsiId)
                .OrderBy(m => m.Sira)
                .ToList();
        }

        public IEnumerable<TamirMerhele> GetByStatus(string status)
        {
            return GetAll().Where(m => m.Status == status).ToList();
        }

        public IEnumerable<TamirMerhele> GetByTeyinEdilenIstifadeci(int istifadeciId)
        {
            return GetAll().Where(m => m.TeyinEdilenIstifadeciId == istifadeciId).ToList();
        }

        public IEnumerable<TamirMerhele> GetActiveSteps()
        {
            return GetAll()
                .Where(m => m.Status == "İşlənir" || m.Status == "Gözləyir")
                .ToList();
        }

        public IEnumerable<TamirMerhele> GetCompletedSteps()
        {
            return GetAll().Where(m => m.Status == "Bitdi").ToList();
        }

        public IEnumerable<TamirMerhele> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            return GetAll()
                .Where(m => m.BaslangicTarixi >= startDate && m.BaslangicTarixi <= endDate)
                .ToList();
        }

        public int GetNextSiraNumber(int tamirIsiId)
        {
            var maxSira = _context.TamirMerheleri
                .Where(m => m.TamirIsiId == tamirIsiId)
                .Select(m => (int?)m.Sira)
                .Max();
            
            return (maxSira ?? 0) + 1;
        }

        public decimal GetTotalCostByTamirId(int tamirIsiId)
        {
            return _context.TamirMerheleri
                .Where(m => m.TamirIsiId == tamirIsiId && m.Status == "Bitdi")
                .Sum(m => m.UmumiDeger);
        }

        public decimal GetTotalWorkingHoursByUser(int istifadeciId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.TamirMerheleri
                .Where(m => m.TeyinEdilenIstifadeciId == istifadeciId && m.Status == "Bitdi");
            
            if (startDate.HasValue)
                query = query.Where(m => m.BitirilmisTarix >= startDate.Value);
            
            if (endDate.HasValue)
                query = query.Where(m => m.BitirilmisTarix <= endDate.Value);
            
            return query.Sum(m => m.IsSaati);
        }

        public int Add(TamirMerhele tamirMerhele)
        {
            if (tamirMerhele.Sira == 0)
            {
                tamirMerhele.Sira = GetNextSiraNumber(tamirMerhele.TamirIsiId);
            }
            
            _context.TamirMerheleri.Add(tamirMerhele);
            _context.SaveChanges();
            return tamirMerhele.Id;
        }

        public void Update(TamirMerhele tamirMerhele)
        {
            tamirMerhele.YenilenmeTarixi = DateTime.Now;
            _context.Entry(tamirMerhele).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var tamirMerhele = _context.TamirMerheleri.Find(id);
            if (tamirMerhele != null)
            {
                _context.TamirMerheleri.Remove(tamirMerhele);
                _context.SaveChanges();
            }
        }

        public void StartStep(int id, int istifadeciId)
        {
            var step = GetById(id);
            if (step != null && step.Status == "Gözləyir")
            {
                step.Status = "İşlənir";
                step.BaslangicTarixi = DateTime.Now;
                step.TeyinEdilenIstifadeciId = istifadeciId;
                Update(step);
            }
        }

        public void CompleteStep(int id, decimal isSaati, decimal parcaDeyeri, string tamirciQeydleri, string istifadeOlunmusParcalar)
        {
            var step = GetById(id);
            if (step != null && step.Status == "İşlənir")
            {
                step.Status = "Bitdi";
                step.BitirilmisTarix = DateTime.Now;
                step.IsSaati = isSaati;
                step.ParcaDeyeri = parcaDeyeri;
                step.TamirciQeydleri = tamirciQeydleri;
                step.IstifadeOlunmusParcalar = istifadeOlunmusParcalar;
                Update(step);
            }
        }

        public void CancelStep(int id)
        {
            var step = GetById(id);
            if (step != null && step.Status != "Bitdi")
            {
                step.Status = "İptal";
                Update(step);
            }
        }

        public void AssignToUser(int id, int istifadeciId)
        {
            var step = GetById(id);
            if (step != null)
            {
                step.TeyinEdilenIstifadeciId = istifadeciId;
                Update(step);
            }
        }

        public void ReorderSteps(int tamirIsiId, Dictionary<int, int> stepIdToSiraMapping)
        {
            var steps = GetByTamirIsiId(tamirIsiId).ToList();
            
            foreach (var step in steps)
            {
                if (stepIdToSiraMapping.ContainsKey(step.Id))
                {
                    step.Sira = stepIdToSiraMapping[step.Id];
                    Update(step);
                }
            }
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}