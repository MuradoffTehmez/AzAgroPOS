using AzAgroPOS.DAL;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.Entities.Constants;
using AzAgroPOS.BLL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.BLL.Services
{
    public class HesabatService : IDisposable
    {
        private readonly AzAgroDbContext _context;
        private readonly IAuditLogService _auditLogService;
        private bool _disposed = false;

        public HesabatService(AzAgroDbContext context = null, IAuditLogService auditLogService = null)
        {
            _context = context ?? new AzAgroDbContext();
            _auditLogService = auditLogService ?? new AuditLogService(_context);
        }

        #region Satış Hesabatları

        public async Task<SatisHesabati> GenerateDailySalesReportAsync(DateTime date, int istifadeciId)
        {
            var startDate = date.Date;
            var endDate = startDate.AddDays(1);

            var salesData = await _context.Satislar
                .Include(s => s.Musteri)
                .Include(s => s.SatisDetallari)
                .ThenInclude(sd => sd.Mehsul)
                .Where(s => s.SatisTarixi >= startDate && s.SatisTarixi < endDate)
                .ToListAsync();

            var report = new SatisHesabati
            {
                TarixBaslangic = startDate,
                TarixBitis = endDate.AddMilliseconds(-1),
                HesabatTipi = "Günlük",
                SatisSayi = salesData.Count,
                ToplamSatis = salesData.Sum(s => s.ToplamMebleg),
                ToplamMenfeet = salesData.Sum(s => s.SatisDetallari.Sum(sd => 
                    (sd.SatisQiymeti - sd.Mehsul.AlisQiymeti) * sd.Miqdar)),
                MusteriSayi = salesData.Select(s => s.MusteriId).Distinct().Count(),
                OrtalamaSatis = salesData.Any() ? salesData.Average(s => s.ToplamMebleg) : 0,
                EnYuksekSatis = salesData.Any() ? salesData.Max(s => s.ToplamMebleg) : 0,
                EnAsagiSatis = salesData.Any() ? salesData.Min(s => s.ToplamMebleg) : 0,
                YaradanIstifadeciId = istifadeciId,
                YaradilmaTarixi = DateTime.Now
            };

            // En çox satılan məhsul
            var productSales = salesData.SelectMany(s => s.SatisDetallari)
                .GroupBy(sd => sd.Mehsul.Ad)
                .OrderByDescending(g => g.Sum(sd => sd.Miqdar))
                .FirstOrDefault();

            if (productSales != null)
                report.EnCoxSatilanMehsul = productSales.Key;

            // En aktiv müştəri
            var customerSales = salesData.GroupBy(s => s.Musteri.TamAd)
                .OrderByDescending(g => g.Sum(s => s.ToplamMebleg))
                .FirstOrDefault();

            if (customerSales != null)
                report.EnAktivMusteri = customerSales.Key;

            _context.SatisHesabatlari.Add(report);
            await _context.SaveChangesAsync();

            await _auditLogService.LogAsync("Hesabat Sistemi", report.Id, "Günlük Hesabat", 
                $"Günlük satış hesabatı yaradıldı: {date:dd.MM.yyyy}", istifadeciId);

            return report;
        }

        public async Task<SatisHesabati> GenerateMonthlySalesReportAsync(int year, int month, int istifadeciId)
        {
            var startDate = new DateTime(year, month, 1);
            var endDate = startDate.AddMonths(1);

            var salesData = await _context.Satislar
                .Include(s => s.Musteri)
                .Include(s => s.SatisDetallari)
                .ThenInclude(sd => sd.Mehsul)
                .Where(s => s.SatisTarixi >= startDate && s.SatisTarixi < endDate)
                .ToListAsync();

            var report = new SatisHesabati
            {
                TarixBaslangic = startDate,
                TarixBitis = endDate.AddMilliseconds(-1),
                HesabatTipi = "Aylıq",
                SatisSayi = salesData.Count,
                ToplamSatis = salesData.Sum(s => s.ToplamMebleg),
                ToplamMenfeet = salesData.Sum(s => s.SatisDetallari.Sum(sd => 
                    (sd.SatisQiymeti - sd.Mehsul.AlisQiymeti) * sd.Miqdar)),
                MusteriSayi = salesData.Select(s => s.MusteriId).Distinct().Count(),
                OrtalamaSatis = salesData.Any() ? salesData.Average(s => s.ToplamMebleg) : 0,
                EnYuksekSatis = salesData.Any() ? salesData.Max(s => s.ToplamMebleg) : 0,
                EnAsagiSatis = salesData.Any() ? salesData.Min(s => s.ToplamMebleg) : 0,
                YaradanIstifadeciId = istifadeciId,
                YaradilmaTarixi = DateTime.Now
            };

            _context.SatisHesabatlari.Add(report);
            await _context.SaveChangesAsync();

            await _auditLogService.LogAsync("Hesabat Sistemi", report.Id, "Aylıq Hesabat", 
                $"Aylıq satış hesabatı yaradıldı: {month:00}/{year}", istifadeciId);

            return report;
        }

        public async Task<SatisHesabati> GenerateProductSalesReportAsync(int mehsulId, DateTime startDate, DateTime endDate, int istifadeciId)
        {
            var salesData = await _context.SatisDetallari
                .Include(sd => sd.Satis)
                .Include(sd => sd.Mehsul)
                .Where(sd => sd.MehsulId == mehsulId && 
                           sd.Satis.SatisTarixi >= startDate && 
                           sd.Satis.SatisTarixi <= endDate)
                .ToListAsync();

            var product = await _context.Mehsullar.FindAsync(mehsulId);

            var report = new SatisHesabati
            {
                TarixBaslangic = startDate,
                TarixBitis = endDate,
                HesabatTipi = "Məhsul Üzrə",
                SatisSayi = salesData.Count,
                ToplamSatis = salesData.Sum(sd => sd.ToplamMebleg),
                ToplamMenfeet = salesData.Sum(sd => (sd.SatisQiymeti - product.AlisQiymeti) * sd.Miqdar),
                MusteriSayi = salesData.Select(sd => sd.Satis.MusteriId).Distinct().Count(),
                OrtalamaSatis = salesData.Any() ? salesData.Average(sd => sd.ToplamMebleg) : 0,
                EnYuksekSatis = salesData.Any() ? salesData.Max(sd => sd.ToplamMebleg) : 0,
                EnAsagiSatis = salesData.Any() ? salesData.Min(sd => sd.ToplamMebleg) : 0,
                EnCoxSatilanMehsul = product?.Ad,
                YaradanIstifadeciId = istifadeciId,
                YaradilmaTarixi = DateTime.Now
            };

            _context.SatisHesabatlari.Add(report);
            await _context.SaveChangesAsync();

            await _auditLogService.LogAsync("Hesabat Sistemi", report.Id, "Məhsul Hesabatı", 
                $"Məhsul satış hesabatı yaradıldı: {product?.Ad}", istifadeciId);

            return report;
        }

        public async Task<SatisHesabati> GenerateCustomerSalesReportAsync(int musteriId, DateTime startDate, DateTime endDate, int istifadeciId)
        {
            var salesData = await _context.Satislar
                .Include(s => s.Musteri)
                .Include(s => s.SatisDetallari)
                .ThenInclude(sd => sd.Mehsul)
                .Where(s => s.MusteriId == musteriId && 
                           s.SatisTarixi >= startDate && 
                           s.SatisTarixi <= endDate)
                .ToListAsync();

            var customer = await _context.Musteriler.FindAsync(musteriId);

            var report = new SatisHesabati
            {
                TarixBaslangic = startDate,
                TarixBitis = endDate,
                HesabatTipi = "Müştəri Üzrə",
                SatisSayi = salesData.Count,
                ToplamSatis = salesData.Sum(s => s.ToplamMebleg),
                ToplamMenfeet = salesData.Sum(s => s.SatisDetallari.Sum(sd => 
                    (sd.SatisQiymeti - sd.Mehsul.AlisQiymeti) * sd.Miqdar)),
                MusteriSayi = 1,
                OrtalamaSatis = salesData.Any() ? salesData.Average(s => s.ToplamMebleg) : 0,
                EnYuksekSatis = salesData.Any() ? salesData.Max(s => s.ToplamMebleg) : 0,
                EnAsagiSatis = salesData.Any() ? salesData.Min(s => s.ToplamMebleg) : 0,
                EnAktivMusteri = customer?.TamAd,
                YaradanIstifadeciId = istifadeciId,
                YaradilmaTarixi = DateTime.Now
            };

            _context.SatisHesabatlari.Add(report);
            await _context.SaveChangesAsync();

            await _auditLogService.LogAsync("Hesabat Sistemi", report.Id, "Müştəri Hesabatı", 
                $"Müştəri satış hesabatı yaradıldı: {customer?.TamAd}", istifadeciId);

            return report;
        }

        #endregion

        #region Borc Hesabatları

        public async Task<Dictionary<string, decimal>> GetDebtSummaryAsync()
        {
            var debtSummary = new Dictionary<string, decimal>();

            var totalDebt = await _context.MusteriBorclar
                .Where(mb => mb.Status == SystemConstants.Status.Active)
                .SumAsync(mb => mb.BorcMeblegi - mb.OdenenMebleg);

            var overdueDebt = await _context.MusteriBorclar
                .Where(mb => mb.Status == SystemConstants.Status.Active && 
                           mb.VadeTarixi < DateTime.Now)
                .SumAsync(mb => mb.BorcMeblegi - mb.OdenenMebleg);

            var currentDebt = totalDebt - overdueDebt;

            debtSummary.Add("Cəmi Borc", totalDebt);
            debtSummary.Add("Vaxtı Keçmiş Borc", overdueDebt);
            debtSummary.Add("Cari Borc", currentDebt);

            return debtSummary;
        }

        public async Task<IEnumerable<MusteriBorc>> GetOverdueDebtsAsync()
        {
            return await _context.MusteriBorclar
                .Include(mb => mb.Musteri)
                .Where(mb => mb.Status == SystemConstants.Status.Active && 
                           mb.VadeTarixi < DateTime.Now &&
                           mb.BorcMeblegi > mb.OdenenMebleg)
                .OrderBy(mb => mb.VadeTarixi)
                .ToListAsync();
        }

        #endregion

        #region İxrac Funksiyaları

        public string ExportToCSV<T>(IEnumerable<T> data, string fileName)
        {
            // Bu metod CSV ixracı üçün hazırlanacaq
            // CsvHelper kitabxanasından istifadə edərək
            return $"Data exported to {fileName}.csv";
        }

        public string ExportToPDF<T>(IEnumerable<T> data, string fileName)
        {
            // Bu metod PDF ixracı üçün hazırlanacaq
            // iTextSharp və ya digər PDF kitabxanasından istifadə edərək
            return $"Data exported to {fileName}.pdf";
        }

        public string ExportToExcel<T>(IEnumerable<T> data, string fileName)
        {
            // Bu metod Excel ixracı üçün hazırlanacaq
            // EPPlus və ya digər Excel kitabxanasından istifadə edərək
            return $"Data exported to {fileName}.xlsx";
        }

        #endregion

        public void Dispose()
        {
            if (!_disposed)
            {
                _context?.Dispose();
                _disposed = true;
            }
        }
    }
}