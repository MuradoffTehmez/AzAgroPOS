using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AzAgroPOS.Entities.Domain;

namespace AzAgroPOS.DAL.Repositories
{
    public class AlisSenedRepository : IDisposable
    {
        private readonly AzAgroDbContext _context;

        public AlisSenedRepository(AzAgroDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public int Add(AlisSeined seined)
        {
            _context.AlisSenedleri.Add(seined);
            return seined.Id;
        }

        public void Update(AlisSeined seined)
        {
            seined.YenilenmeTarixi = DateTime.Now;
            _context.AlisSenedleri.Update(seined);
        }

        public void Delete(int id)
        {
            var seined = _context.AlisSenedleri.Find(id);
            if (seined != null)
            {
                _context.AlisSenedleri.Remove(seined);
                }
        }

        public AlisSeined GetById(int id)
        {
            return _context.AlisSenedleri
                .Include(s => s.Tedarukcu)
                .Include(s => s.Anbar)
                .Include(s => s.AlisOrder)
                .Include(s => s.YaradanIstifadeci)
                .Include(s => s.QebulEdenIstifadeci)
                .FirstOrDefault(s => s.Id == id);
        }

        public AlisSeined GetByIdWithDetails(int id)
        {
            return _context.AlisSenedleri
                .Include(s => s.Tedarukcu)
                .Include(s => s.Anbar)
                .Include(s => s.AlisOrder)
                .Include(s => s.SenedDetallari)
                    .ThenInclude(d => d.Mehsul)
                .Include(s => s.Odemeler)
                .Include(s => s.YaradanIstifadeci)
                .Include(s => s.QebulEdenIstifadeci)
                .FirstOrDefault(s => s.Id == id);
        }

        public List<AlisSeined> GetAll()
        {
            return _context.AlisSenedleri
                .Include(s => s.Tedarukcu)
                .Include(s => s.Anbar)
                .Include(s => s.YaradanIstifadeci)
                .OrderByDescending(s => s.SenedTarixi)
                .ToList();
        }

        public List<AlisSeined> GetByTedarukcu(int tedarukcuId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.AlisSenedleri
                .Include(s => s.Tedarukcu)
                .Include(s => s.Anbar)
                .Where(s => s.TedarukcuId == tedarukcuId);

            if (startDate.HasValue)
                query = query.Where(s => s.SenedTarixi >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(s => s.SenedTarixi <= endDate.Value);

            return query.OrderByDescending(s => s.SenedTarixi).ToList();
        }

        public List<AlisSeined> GetByStatus(string status)
        {
            return _context.AlisSenedleri
                .Include(s => s.Tedarukcu)
                .Include(s => s.Anbar)
                .Where(s => s.Status == status)
                .OrderByDescending(s => s.SenedTarixi)
                .ToList();
        }

        public List<AlisSeined> GetByOdemeStatus(string odemeStatus)
        {
            return _context.AlisSenedleri
                .Include(s => s.Tedarukcu)
                .Include(s => s.Anbar)
                .Where(s => s.OdemeStatus == odemeStatus)
                .OrderByDescending(s => s.SenedTarixi)
                .ToList();
        }

        public List<AlisSeined> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            return _context.AlisSenedleri
                .Include(s => s.Tedarukcu)
                .Include(s => s.Anbar)
                .Where(s => s.SenedTarixi >= startDate && s.SenedTarixi <= endDate)
                .OrderByDescending(s => s.SenedTarixi)
                .ToList();
        }

        public List<AlisSeined> GetUnpaidDocuments()
        {
            return _context.AlisSenedleri
                .Include(s => s.Tedarukcu)
                .Where(s => s.Status == "Qəbul Edilmiş" &&
                           s.OdemeStatus != "Tam Ödənilmiş")
                .OrderBy(s => s.SenedTarixi)
                .ToList();
        }

        public bool SenedNomresiMevcudMu(string senedNomresi, int? excludeId = null)
        {
            var query = _context.AlisSenedleri.Where(s => s.SenedNomresi == senedNomresi);
            if (excludeId.HasValue)
            {
                query = query.Where(s => s.Id != excludeId.Value);
            }
            return query.Any();
        }

        public void AddDetali(AlisSenedDetali detali)
        {
            _context.AlisSenedDetallari.Add(detali);
        }

        public void UpdateDetali(AlisSenedDetali detali)
        {
            detali.YenilenmeTarixi = DateTime.Now;
            _context.AlisSenedDetallari.Update(detali);
        }

        public void DeleteDetali(int id)
        {
            var detali = _context.AlisSenedDetallari.Find(id);
            if (detali != null)
            {
                _context.AlisSenedDetallari.Remove(detali);
                }
        }

        public List<AlisSenedDetali> GetDetallari(int senedId)
        {
            return _context.AlisSenedDetallari
                .Include(d => d.Mehsul)
                    .ThenInclude(m => m.Kateqoriya)
                .Include(d => d.Mehsul)
                    .ThenInclude(m => m.Vahid)
                .Where(d => d.AlisSenedId == senedId)
                .OrderBy(d => d.Id)
                .ToList();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}