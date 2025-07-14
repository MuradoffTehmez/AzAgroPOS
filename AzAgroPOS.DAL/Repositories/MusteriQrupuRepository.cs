using AzAgroPOS.Entities.Domain;
using AzAgroPOS.Entities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace AzAgroPOS.DAL.Repositories
{
    public class MusteriQrupuRepository : IDisposable
    {
        private readonly AzAgroDbContext _context;

        public MusteriQrupuRepository(AzAgroDbContext context = null)
        {
            _context = context ?? new AzAgroDbContext();
        }

        public IQueryable<MusteriQrupu> GetAll()
        {
            return _context.MusteriQruplari
                .Include(mq => mq.YaradanIstifadeci)
                .Include(mq => mq.Musteriler);
        }

        public IQueryable<MusteriQrupu> GetActive()
        {
            return GetAll().Where(mq => mq.Status == SystemConstants.Status.Active);
        }

        public MusteriQrupu GetById(int id)
        {
            return GetAll().FirstOrDefault(mq => mq.Id == id);
        }

        public MusteriQrupu GetByName(string ad)
        {
            return GetActive().FirstOrDefault(mq => mq.Ad == ad);
        }

        public MusteriQrupu Add(MusteriQrupu musteriQrupu)
        {
            _context.MusteriQruplari.Add(musteriQrupu);
            _context.SaveChanges();
            return musteriQrupu;
        }

        public MusteriQrupu Update(MusteriQrupu musteriQrupu)
        {
            musteriQrupu.YenilenmeTarixi = DateTime.Now;
            _context.Entry(musteriQrupu).State = EntityState.Modified;
            _context.SaveChanges();
            return musteriQrupu;
        }

        public void Delete(int id)
        {
            var qrup = GetById(id);
            if (qrup != null)
            {
                qrup.Status = SystemConstants.Status.Deleted;
                qrup.YenilenmeTarixi = DateTime.Now;
                Update(qrup);
            }
        }

        public void HardDelete(int id)
        {
            var qrup = _context.MusteriQruplari.Find(id);
            if (qrup != null)
            {
                _context.MusteriQruplari.Remove(qrup);
                _context.SaveChanges();
            }
        }

        public bool IsNameExists(string ad, int? excludeId = null)
        {
            var query = GetActive().Where(mq => mq.Ad == ad);
            if (excludeId.HasValue)
                query = query.Where(mq => mq.Id != excludeId.Value);
            return query.Any();
        }

        public bool CanDelete(int id)
        {
            var qrup = GetById(id);
            return qrup != null && qrup.SilineABilir;
        }

        public List<object> GetGroupStatistics()
        {
            return GetActive()
                .Select(mq => new 
                {
                    mq.Id,
                    mq.Ad,
                    MusteriSayi = mq.Musteriler.Count(m => m.Status == SystemConstants.Status.Active),
                    UmumiAlis = mq.Musteriler.Where(m => m.Status == SystemConstants.Status.Active).Sum(m => m.UmumiAlis),
                    OrtalamAlis = mq.Musteriler.Where(m => m.Status == SystemConstants.Status.Active).Any() ? 
                                 mq.Musteriler.Where(m => m.Status == SystemConstants.Status.Active).Average(m => m.UmumiAlis) : 0,
                    mq.EndirimbFaizi,
                    mq.KreditLimiti
                })
                .Cast<object>()
                .ToList();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}