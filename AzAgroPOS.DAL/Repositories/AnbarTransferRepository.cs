using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AzAgroPOS.Entities.Domain;

namespace AzAgroPOS.DAL.Repositories
{
    public class AnbarTransferRepository
    {
        private readonly AzAgroDbContext _context;

        public AnbarTransferRepository()
        {
            _context = new AzAgroDbContext();
        }

        public int Add(AnbarTransfer transfer)
        {
            _context.AnbarTransferleri.Add(transfer);
            _context.SaveChanges();
            return transfer.Id;
        }

        public void Update(AnbarTransfer transfer)
        {
            transfer.YenilenmeTarixi = DateTime.Now;
            _context.AnbarTransferleri.Update(transfer);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var transfer = _context.AnbarTransferleri.Find(id);
            if (transfer != null)
            {
                _context.AnbarTransferleri.Remove(transfer);
                _context.SaveChanges();
            }
        }

        public AnbarTransfer GetById(int id)
        {
            return _context.AnbarTransferleri
                .Include(t => t.MenbAnbar)
                .Include(t => t.HedefAnbar)
                .Include(t => t.YaradanIstifadeci)
                .Include(t => t.GonderenIstifadeci)
                .Include(t => t.QebulEdenIstifadeci)
                .FirstOrDefault(t => t.Id == id);
        }

        public AnbarTransfer GetByIdWithDetails(int id)
        {
            return _context.AnbarTransferleri
                .Include(t => t.MenbAnbar)
                .Include(t => t.HedefAnbar)
                .Include(t => t.TransferDetallari)
                    .ThenInclude(d => d.Mehsul)
                .Include(t => t.YaradanIstifadeci)
                .Include(t => t.GonderenIstifadeci)
                .Include(t => t.QebulEdenIstifadeci)
                .FirstOrDefault(t => t.Id == id);
        }

        public List<AnbarTransfer> GetAll()
        {
            return _context.AnbarTransferleri
                .Include(t => t.MenbAnbar)
                .Include(t => t.HedefAnbar)
                .Include(t => t.YaradanIstifadeci)
                .OrderByDescending(t => t.TransferTarixi)
                .ToList();
        }

        public List<AnbarTransfer> GetByMenbAnbar(int anbarId)
        {
            return _context.AnbarTransferleri
                .Include(t => t.MenbAnbar)
                .Include(t => t.HedefAnbar)
                .Include(t => t.YaradanIstifadeci)
                .Where(t => t.MenbAnbarId == anbarId)
                .OrderByDescending(t => t.TransferTarixi)
                .ToList();
        }

        public List<AnbarTransfer> GetByHedefAnbar(int anbarId)
        {
            return _context.AnbarTransferleri
                .Include(t => t.MenbAnbar)
                .Include(t => t.HedefAnbar)
                .Include(t => t.YaradanIstifadeci)
                .Where(t => t.HedefAnbarId == anbarId)
                .OrderByDescending(t => t.TransferTarixi)
                .ToList();
        }

        public List<AnbarTransfer> GetByStatus(string status)
        {
            return _context.AnbarTransferleri
                .Include(t => t.MenbAnbar)
                .Include(t => t.HedefAnbar)
                .Include(t => t.YaradanIstifadeci)
                .Where(t => t.Status == status)
                .OrderByDescending(t => t.TransferTarixi)
                .ToList();
        }

        public List<AnbarTransfer> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            return _context.AnbarTransferleri
                .Include(t => t.MenbAnbar)
                .Include(t => t.HedefAnbar)
                .Include(t => t.YaradanIstifadeci)
                .Where(t => t.TransferTarixi >= startDate && t.TransferTarixi <= endDate)
                .OrderByDescending(t => t.TransferTarixi)
                .ToList();
        }

        public List<AnbarTransfer> GetPendingTransfers()
        {
            return _context.AnbarTransferleri
                .Include(t => t.MenbAnbar)
                .Include(t => t.HedefAnbar)
                .Where(t => t.Status == "Göndərilmiş")
                .OrderBy(t => t.GondermeTarixi)
                .ToList();
        }

        public bool TransferNomresiMevcudMu(string transferNomresi, int? excludeId = null)
        {
            var query = _context.AnbarTransferleri.Where(t => t.TransferNomresi == transferNomresi);
            if (excludeId.HasValue)
            {
                query = query.Where(t => t.Id != excludeId.Value);
            }
            return query.Any();
        }

        public void AddDetali(AnbarTransferDetali detali)
        {
            _context.AnbarTransferDetallari.Add(detali);
            _context.SaveChanges();
        }

        public void UpdateDetali(AnbarTransferDetali detali)
        {
            detali.YenilenmeTarixi = DateTime.Now;
            _context.AnbarTransferDetallari.Update(detali);
            _context.SaveChanges();
        }

        public void DeleteDetali(int id)
        {
            var detali = _context.AnbarTransferDetallari.Find(id);
            if (detali != null)
            {
                _context.AnbarTransferDetallari.Remove(detali);
                _context.SaveChanges();
            }
        }

        public List<AnbarTransferDetali> GetDetallari(int transferId)
        {
            return _context.AnbarTransferDetallari
                .Include(d => d.Mehsul)
                    .ThenInclude(m => m.Kateqoriya)
                .Include(d => d.Mehsul)
                    .ThenInclude(m => m.Vahid)
                .Where(d => d.AnbarTransferId == transferId)
                .OrderBy(d => d.Id)
                .ToList();
        }

        public List<object> GetTransferRaporu(DateTime startDate, DateTime endDate, int? anbarId = null)
        {
            var query = _context.AnbarTransferleri
                .Include(t => t.MenbAnbar)
                .Include(t => t.HedefAnbar)
                .Where(t => t.TransferTarixi >= startDate && t.TransferTarixi <= endDate);

            if (anbarId.HasValue)
                query = query.Where(t => t.MenbAnbarId == anbarId.Value || t.HedefAnbarId == anbarId.Value);

            return query
                .GroupBy(t => new { t.TransferTarixi.Date, t.Status })
                .Select(g => new
                {
                    Tarix = g.Key.Date,
                    Status = g.Key.Status,
                    TransferSayi = g.Count(),
                    UmumiMehsulSayi = g.Sum(t => t.MehsulSayi),
                    UmumiMiqdar = g.Sum(t => t.UmumiMiqdar),
                    QebulEdilenMiqdar = g.Sum(t => t.QebulEdilenMiqdar)
                })
                .OrderByDescending(x => x.Tarix)
                .ThenBy(x => x.Status)
                .Cast<object>()
                .ToList();
        }

        public List<object> GetAnbarTransferAnalizi(int anbarId, DateTime startDate, DateTime endDate)
        {
            var gidenTransferler = _context.AnbarTransferleri
                .Include(t => t.HedefAnbar)
                .Include(t => t.TransferDetallari)
                .Where(t => t.MenbAnbarId == anbarId && 
                           t.TransferTarixi >= startDate && 
                           t.TransferTarixi <= endDate &&
                           t.Status == "Qəbul Edilmiş")
                .SelectMany(t => t.TransferDetallari, (t, d) => new
                {
                    TransferTipi = "Giden",
                    HedefAnbar = t.HedefAnbar.Ad,
                    MehsulId = d.MehsulId,
                    Miqdar = d.QebulEdilenMiqdar,
                    Mebleg = d.UmumiMebleg
                });

            var gelenTransferler = _context.AnbarTransferleri
                .Include(t => t.MenbAnbar)
                .Include(t => t.TransferDetallari)
                .Where(t => t.HedefAnbarId == anbarId && 
                           t.TransferTarixi >= startDate && 
                           t.TransferTarixi <= endDate &&
                           t.Status == "Qəbul Edilmiş")
                .SelectMany(t => t.TransferDetallari, (t, d) => new
                {
                    TransferTipi = "Gelen",
                    HedefAnbar = t.MenbAnbar.Ad,
                    MehsulId = d.MehsulId,
                    Miqdar = d.QebulEdilenMiqdar,
                    Mebleg = d.UmumiMebleg
                });

            return gidenTransferler.Union(gelenTransferler)
                .GroupBy(x => new { x.TransferTipi, x.HedefAnbar })
                .Select(g => new
                {
                    TransferTipi = g.Key.TransferTipi,
                    DigerAnbar = g.Key.HedefAnbar,
                    MehsulSayi = g.Select(x => x.MehsulId).Distinct().Count(),
                    ToplamMiqdar = g.Sum(x => x.Miqdar),
                    ToplamMebleg = g.Sum(x => x.Mebleg)
                })
                .OrderBy(x => x.TransferTipi)
                .ThenByDescending(x => x.ToplamMiqdar)
                .Cast<object>()
                .ToList();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}