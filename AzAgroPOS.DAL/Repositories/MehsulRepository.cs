using AzAgroPOS.Entities.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.DAL.Repositories
{
    public class MehsulRepository : IDisposable
    {
        private readonly AzAgroDbContext _context;

        public MehsulRepository(AzAgroDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Mehsul>> GetAllAsync()
        {
            return await _context.Mehsullar
                .Include(m => m.Kateqoriya)
                .Include(m => m.Vahid)
                .OrderBy(m => m.Ad)
                .ToListAsync();
        }

        public async Task<List<Mehsul>> GetAllActiveAsync()
        {
            return await _context.Mehsullar
                .Include(m => m.Kateqoriya)
                .Include(m => m.Vahid)
                .Where(m => m.Status == "Aktiv")
                .OrderBy(m => m.Ad)
                .ToListAsync();
        }

        public List<Mehsul> GetAllActive()
        {
            return _context.Mehsullar
                .Include(m => m.Kateqoriya)
                .Include(m => m.Vahid)
                .Where(m => m.Status == "Aktiv")
                .OrderBy(m => m.Ad)
                .ToList();
        }

        public async Task<Mehsul> GetByIdAsync(int id)
        {
            return await _context.Mehsullar
                .Include(m => m.Kateqoriya)
                .Include(m => m.Vahid)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public Mehsul GetById(int id)
        {
            return _context.Mehsullar
                .Include(m => m.Kateqoriya)
                .Include(m => m.Vahid)
                .FirstOrDefault(m => m.Id == id);
        }

        public async Task<Mehsul> GetByBarkodAsync(string barkod)
        {
            return await _context.Mehsullar
                .Include(m => m.Kateqoriya)
                .Include(m => m.Vahid)
                .FirstOrDefaultAsync(m => m.Barkod == barkod);
        }

        public async Task<Mehsul> GetBySKUAsync(string sku)
        {
            return await _context.Mehsullar
                .Include(m => m.Kateqoriya)
                .Include(m => m.Vahid)
                .FirstOrDefaultAsync(m => m.SKU == sku);
        }

        public async Task<List<Mehsul>> GetByKateqoriyaAsync(int kateqoriyaId)
        {
            return await _context.Mehsullar
                .Include(m => m.Kateqoriya)
                .Include(m => m.Vahid)
                .Where(m => m.KateqoriyaId == kateqoriyaId && m.Status == "Aktiv")
                .OrderBy(m => m.Ad)
                .ToListAsync();
        }

        public async Task<List<Mehsul>> SearchAsync(string searchTerm)
        {
            var term = searchTerm.ToLower();
            return await _context.Mehsullar
                .Include(m => m.Kateqoriya)
                .Include(m => m.Vahid)
                .Where(m => m.Ad.ToLower().Contains(term) ||
                           m.Barkod.ToLower().Contains(term) ||
                           m.SKU.ToLower().Contains(term) ||
                           (m.Tesvir != null && m.Tesvir.ToLower().Contains(term)))
                .OrderBy(m => m.Ad)
                .ToListAsync();
        }

        public async Task<List<Mehsul>> GetStoktanKenardaAsync()
        {
            return await _context.Mehsullar
                .Include(m => m.Kateqoriya)
                .Include(m => m.Vahid)
                .Where(m => m.Status == "Aktiv" && m.MovcudMiqdar <= m.MinimumMiqdar)
                .OrderBy(m => m.Ad)
                .ToListAsync();
        }

        public async Task<bool> BarkodMevcudAsync(string barkod, int? excludeId = null)
        {
            var query = _context.Mehsullar.Where(m => m.Barkod == barkod);
            if (excludeId.HasValue)
            {
                query = query.Where(m => m.Id != excludeId.Value);
            }
            return await query.AnyAsync();
        }

        public async Task<bool> SKUMevcudAsync(string sku, int? excludeId = null)
        {
            var query = _context.Mehsullar.Where(m => m.SKU == sku);
            if (excludeId.HasValue)
            {
                query = query.Where(m => m.Id != excludeId.Value);
            }
            return await query.AnyAsync();
        }

        public async Task<int> AddAsync(Mehsul mehsul)
        {
            mehsul.YaradilmaTarixi = DateTime.Now;
            _context.Mehsullar.Add(mehsul);
            return mehsul.Id;
        }

        public async Task UpdateAsync(Mehsul mehsul)
        {
            mehsul.YenilenmeTarixi = DateTime.Now;
            _context.Mehsullar.Update(mehsul);
        }

        public void Update(Mehsul mehsul)
        {
            mehsul.YenilenmeTarixi = DateTime.Now;
            _context.Mehsullar.Update(mehsul);
        }

        public async Task DeleteAsync(int id)
        {
            var mehsul = await _context.Mehsullar.FindAsync(id);
            if (mehsul != null)
            {
                _context.Mehsullar.Remove(mehsul);
            }
        }

        public async Task<bool> CanDeleteAsync(int id)
        {
            // Məhsul satış detallarında istifadə edilibmi?
            bool isInSatis = await _context.SatisDetallari.AnyAsync(d => d.MehsulId == id);
            if (isInSatis) return false;

            // Məhsul anbar hərəkətlərində var mı?
            bool isInAnbar = await _context.AnbarHereketleri.AnyAsync(h => h.MehsulId == id);
            if (isInAnbar) return false;

            // Məhsul alış sənədlərində var mı?
            bool isInAlis = await _context.AlisSenedDetallari.AnyAsync(d => d.MehsulId == id);
            if (isInAlis) return false;

            // Əgər heç bir yerdə istifadə edilməyibsə, silinə bilər.
            return true;
        }

        public async Task UpdateMiqdarAsync(int mehsulId, decimal yeniMiqdar)
        {
            var mehsul = await _context.Mehsullar.FindAsync(mehsulId);
            if (mehsul != null)
            {
                mehsul.MovcudMiqdar = yeniMiqdar;
                mehsul.YenilenmeTarixi = DateTime.Now;
            }
        }

        public async Task<Dictionary<string, object>> GetStatistikalarAsync()
        {
            var statistikalar = new Dictionary<string, object>();

            // Bütün hesablamalar birbaşa bazada aparılır
            var umumiSay = await _context.Mehsullar.CountAsync();
            var aktivSay = await _context.Mehsullar.CountAsync(m => m.Status == "Aktiv");
            var azStokluSay = await _context.Mehsullar.CountAsync(m => m.Status == "Aktiv" && m.MovcudMiqdar <= m.MinimumMiqdar);

            // Sum əməliyyatı üçün ayrıca sorğu
            var umumiDeyer = await _context.Mehsullar
                .Where(m => m.Status == "Aktiv")
                .SumAsync(m => m.MovcudMiqdar * m.SatisQiymeti);

            statistikalar["UmumiMehsulSayi"] = umumiSay;
            statistikalar["AktivMehsulSayi"] = aktivSay;
            statistikalar["StoktanKenardaMehsulSayi"] = azStokluSay;
            statistikalar["UmumiDeger"] = umumiDeyer;

            return statistikalar;
        }

        public async Task<List<Mehsul>> GetByIdsAsync(List<int> ids)
        {
            return await _context.Mehsullar
                .Include(m => m.Kateqoriya)
                .Include(m => m.Vahid)
                .Where(m => ids.Contains(m.Id))
                .ToListAsync();
        }

        public List<Mehsul> GetByIds(List<int> ids)
        {
            return _context.Mehsullar
                .Include(m => m.Kateqoriya)
                .Include(m => m.Vahid)
                .Where(m => ids.Contains(m.Id))
                .ToList();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}