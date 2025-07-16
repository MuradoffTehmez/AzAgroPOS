using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AzAgroPOS.Entities.Domain;

namespace AzAgroPOS.DAL.Repositories
{
    public class AlisOrderRepository : IDisposable
    {
        private readonly AzAgroDbContext _context;

        public AlisOrderRepository(AzAgroDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public int Add(AlisOrder order)
        {
            _context.AlisOrderleri.Add(order);
            return order.Id;
        }

        public void Update(AlisOrder order)
        {
            order.YenilenmeTarixi = DateTime.Now;
            _context.AlisOrderleri.Update(order);
        }

        public void Delete(int id)
        {
            var order = _context.AlisOrderleri.Find(id);
            if (order != null)
            {
                _context.AlisOrderleri.Remove(order);
                }
        }

        public AlisOrder GetById(int id)
        {
            return _context.AlisOrderleri
                .Include(o => o.Tedarukcu)
                .Include(o => o.YaradanIstifadeci)
                .Include(o => o.TesdiqleyenIstifadeci)
                .FirstOrDefault(o => o.Id == id);
        }

        public AlisOrder GetByIdWithDetails(int id)
        {
            return _context.AlisOrderleri
                .Include(o => o.Tedarukcu)
                .Include(o => o.OrderDetallari)
                    .ThenInclude(d => d.Mehsul)
                .Include(o => o.YaradanIstifadeci)
                .Include(o => o.TesdiqleyenIstifadeci)
                .FirstOrDefault(o => o.Id == id);
        }

        public List<AlisOrder> GetAll()
        {
            return _context.AlisOrderleri
                .Include(o => o.Tedarukcu)
                .Include(o => o.YaradanIstifadeci)
                .OrderByDescending(o => o.OrderTarixi)
                .ToList();
        }

        public List<AlisOrder> GetByTedarukcu(int tedarukcuId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.AlisOrderleri
                .Include(o => o.Tedarukcu)
                .Include(o => o.YaradanIstifadeci)
                .Where(o => o.TedarukcuId == tedarukcuId);

            if (startDate.HasValue)
                query = query.Where(o => o.OrderTarixi >= startDate.Value);

            if (endDate.HasValue)
                query = query.Where(o => o.OrderTarixi <= endDate.Value);

            return query.OrderByDescending(o => o.OrderTarixi).ToList();
        }

        public List<AlisOrder> GetByStatus(string status)
        {
            return _context.AlisOrderleri
                .Include(o => o.Tedarukcu)
                .Include(o => o.YaradanIstifadeci)
                .Where(o => o.Status == status)
                .OrderByDescending(o => o.OrderTarixi)
                .ToList();
        }

        public List<AlisOrder> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            return _context.AlisOrderleri
                .Include(o => o.Tedarukcu)
                .Include(o => o.YaradanIstifadeci)
                .Where(o => o.OrderTarixi >= startDate && o.OrderTarixi <= endDate)
                .OrderByDescending(o => o.OrderTarixi)
                .ToList();
        }

        public List<AlisOrder> GetOverdueOrders()
        {
            var today = DateTime.Today;
            return _context.AlisOrderleri
                .Include(o => o.Tedarukcu)
                .Where(o => o.TeslimTarixi.HasValue &&
                           o.TeslimTarixi.Value.Date < today &&
                           o.Status != "Teslim Edilmiş" &&
                           o.Status != "İptal Edilmiş")
                .OrderBy(o => o.TeslimTarixi)
                .ToList();
        }

        public bool OrderNomresiMevcudMu(string orderNomresi, int? excludeId = null)
        {
            var query = _context.AlisOrderleri.Where(o => o.OrderNomresi == orderNomresi);
            if (excludeId.HasValue)
            {
                query = query.Where(o => o.Id != excludeId.Value);
            }
            return query.Any();
        }

        public void AddDetali(AlisOrderDetali detali)
        {
            _context.AlisOrderDetallari.Add(detali);
        }

        public void UpdateDetali(AlisOrderDetali detali)
        {
            detali.YenilenmeTarixi = DateTime.Now;
            _context.AlisOrderDetallari.Update(detali);
        }

        public void DeleteDetali(int id)
        {
            var detali = _context.AlisOrderDetallari.Find(id);
            if (detali != null)
            {
                _context.AlisOrderDetallari.Remove(detali);
                }
        }

        public List<AlisOrderDetali> GetDetallari(int orderId)
        {
            return _context.AlisOrderDetallari
                .Include(d => d.Mehsul)
                    .ThenInclude(m => m.Kateqoriya)
                .Include(d => d.Mehsul)
                    .ThenInclude(m => m.Vahid)
                .Where(d => d.AlisOrderId == orderId)
                .OrderBy(d => d.Id)
                .ToList();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}