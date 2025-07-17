using AzAgroPOS.DAL;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.BLL.Interfaces;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AzAgroPOS.BLL.Services
{
    public class ReportService : IDisposable
    {
        private readonly SatisRepository _satisRepository;
        private readonly MehsulRepository _mehsulRepository;
        private readonly MusteriRepository _musteriRepository;
        private readonly TamirIsiRepository _tamirRepository;
        private readonly MusteriBorcRepository _borcRepository;
        private bool _disposed = false;

        public ReportService()
        {
            var context = new AzAgroDbContext();
            _satisRepository = new SatisRepository(context);
            _mehsulRepository = new MehsulRepository(context);
            _musteriRepository = new MusteriRepository(context);
            _tamirRepository = new TamirIsiRepository(context);
            _borcRepository = new MusteriBorcRepository(context);
        }

        #region Sales Reports

        /// <summary>
        /// Günlük satış hesabatı
        /// </summary>
        public SalesReportDto GetDailySalesReport(DateTime date)
        {
            try
            {
                var startDate = date.Date;
                var endDate = startDate.AddDays(1);

                var sales = _satisRepository.GetByDateRange(startDate, endDate);
                
                return new SalesReportDto
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    TotalSales = sales.Count(),
                    TotalAmount = sales.Sum(s => s.UmumiMebleg),
                    TotalDiscount = sales.Sum(s => s.EndirimMeblegi),
                    NetAmount = sales.Sum(s => s.UmumiMebleg - s.EndirimMeblegi),
                    TopProducts = GetTopSellingProducts(sales),
                    SalesByHour = GetSalesByHour(sales),
                    ReportType = "Günlük",
                    GeneratedDate = DateTime.Now
                };
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "Günlük satış hesabatı alınarkən xəta baş verdi.");
                return null;
            }
        }

        /// <summary>
        /// Aylıq satış hesabatı
        /// </summary>
        public SalesReportDto GetMonthlySalesReport(int year, int month)
        {
            try
            {
                var startDate = new DateTime(year, month, 1);
                var endDate = startDate.AddMonths(1);

                var sales = _satisRepository.GetByDateRange(startDate, endDate);
                
                return new SalesReportDto
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    TotalSales = sales.Count(),
                    TotalAmount = sales.Sum(s => s.UmumiMebleg),
                    TotalDiscount = sales.Sum(s => s.EndirimMeblegi),
                    NetAmount = sales.Sum(s => s.UmumiMebleg - s.EndirimMeblegi),
                    TopProducts = GetTopSellingProducts(sales),
                    SalesByDay = GetSalesByDay(sales),
                    ReportType = "Aylıq",
                    GeneratedDate = DateTime.Now
                };
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "Aylıq satış hesabatı alınarkən xəta baş verdi.");
                return null;
            }
        }

        /// <summary>
        /// Məhsul üzrə satış hesabatı
        /// </summary>
        public List<ProductSalesDto> GetProductSalesReport(DateTime startDate, DateTime endDate)
        {
            try
            {
                var sales = _satisRepository.GetByDateRange(startDate, endDate);
                var productSales = new List<ProductSalesDto>();

                var groupedSales = sales
                    .SelectMany(s => s.SatisDetallari)
                    .GroupBy(sd => sd.MehsulId)
                    .ToList();

                // Get all product IDs and fetch products in a single batch query
                var productIds = groupedSales.Select(g => g.Key).ToList();
                var products = _mehsulRepository.GetByIds(productIds);
                var productLookup = products.ToDictionary(p => p.Id);

                foreach (var group in groupedSales)
                {
                    if (productLookup.TryGetValue(group.Key, out var mehsul))
                    {
                        var totalQuantity = group.Sum(sd => sd.Miqdar);
                        var totalAmount = group.Sum(sd => sd.Miqdar * sd.VahidQiymeti);

                        productSales.Add(new ProductSalesDto
                        {
                            ProductId = mehsul.Id,
                            ProductName = mehsul.Ad,
                            ProductCode = mehsul.SKU,
                            TotalQuantity = totalQuantity,
                            TotalAmount = totalAmount,
                            AveragePrice = totalAmount / totalQuantity,
                            SalesCount = group.Count()
                        });
                    }
                }

                return productSales.OrderByDescending(ps => ps.TotalAmount).ToList();
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "Məhsul satış hesabatı alınarkən xəta baş verdi.");
                return new List<ProductSalesDto>();
            }
        }

        #endregion

        #region Debt Reports

        /// <summary>
        /// Borc balansı hesabatı
        /// </summary>
        public DebtReportDto GetDebtBalanceReport()
        {
            try
            {
                var allDebts = _borcRepository.GetAllActiveDebts();
                var customers = _musteriRepository.GetAll();

                var totalDebt = allDebts.Sum(d => d.BorcMeblegi);
                var totalPaid = allDebts.Sum(d => d.OdenilmisMebleg);
                var remainingDebt = totalDebt - totalPaid;

                var customerDebts = allDebts
                    .GroupBy(d => d.MusteriId)
                    .Select(g => new CustomerDebtDto
                    {
                        CustomerId = g.Key,
                        CustomerName = customers.FirstOrDefault(c => c.Id == g.Key)?.Ad + " " + 
                                     customers.FirstOrDefault(c => c.Id == g.Key)?.Soyad,
                        TotalDebt = g.Sum(d => d.BorcMeblegi),
                        TotalPaid = g.Sum(d => d.OdenilmisMebleg),
                        RemainingDebt = g.Sum(d => d.BorcMeblegi) - g.Sum(d => d.OdenilmisMebleg),
                        LastPaymentDate = g.Max(d => d.SonOdemeTarixi),
                        DebtCount = g.Count()
                    })
                    .Where(cd => cd.RemainingDebt > 0)
                    .OrderByDescending(cd => cd.RemainingDebt)
                    .ToList();

                return new DebtReportDto
                {
                    TotalDebt = totalDebt,
                    TotalPaid = totalPaid,
                    RemainingDebt = remainingDebt,
                    CustomersWithDebt = customerDebts.Count,
                    CustomerDebts = customerDebts,
                    GeneratedDate = DateTime.Now
                };
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "Borc hesabatı alınarkən xəta baş verdi.");
                return null;
            }
        }

        #endregion

        #region Repair Reports

        /// <summary>
        /// Təmir analitika hesabatı
        /// </summary>
        public RepairAnalyticsDto GetRepairAnalytics(DateTime startDate, DateTime endDate)
        {
            try
            {
                var repairs = _tamirRepository.GetRepairsByDateRange(startDate, endDate);
                
                var totalRepairs = repairs.Count();
                var completedRepairs = repairs.Count(r => r.Status == "Hazır");
                var pendingRepairs = repairs.Count(r => r.Status == "Gözləyir");
                var inProgressRepairs = repairs.Count(r => r.Status == "İşlənir");

                var totalCost = repairs.Sum(r => r.SonQiymet);
                var averageCost = totalRepairs > 0 ? totalCost / totalRepairs : 0;

                var repairsByType = repairs
                    .GroupBy(r => r.Status)
                    .Select(g => new RepairTypeDto
                    {
                        RepairType = g.Key,
                        Count = g.Count(),
                        TotalCost = g.Sum(r => r.SonQiymet),
                        AverageCost = g.Average(r => r.SonQiymet)
                    })
                    .OrderByDescending(rt => rt.Count)
                    .ToList();

                return new RepairAnalyticsDto
                {
                    StartDate = startDate,
                    EndDate = endDate,
                    TotalRepairs = totalRepairs,
                    CompletedRepairs = completedRepairs,
                    PendingRepairs = pendingRepairs,
                    InProgressRepairs = inProgressRepairs,
                    TotalCost = totalCost,
                    AverageCost = averageCost,
                    RepairsByType = repairsByType,
                    GeneratedDate = DateTime.Now
                };
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "Təmir analitika hesabatı alınarkən xəta baş verdi.");
                return null;
            }
        }

        #endregion

        #region Helper Methods

        private List<ProductSalesDto> GetTopSellingProducts(IEnumerable<Satis> sales, int topCount = 10)
        {
            // Group sales first to get product IDs
            var groupedSales = sales
                .SelectMany(s => s.SatisDetallari)
                .GroupBy(sd => sd.MehsulId)
                .ToList();

            // Get all product IDs and fetch products in a single batch query
            var productIds = groupedSales.Select(g => g.Key).ToList();
            var products = _mehsulRepository.GetByIds(productIds);
            var productLookup = products.ToDictionary(p => p.Id);

            var productSales = groupedSales
                .Select(g => new ProductSalesDto
                {
                    ProductId = g.Key,
                    ProductName = productLookup.TryGetValue(g.Key, out var product) ? product.Ad : "Naməlum",
                    TotalQuantity = g.Sum(sd => sd.Miqdar),
                    TotalAmount = g.Sum(sd => sd.Miqdar * sd.VahidQiymeti),
                    SalesCount = g.Count()
                })
                .OrderByDescending(ps => ps.TotalQuantity)
                .Take(topCount)
                .ToList();

            return productSales;
        }

        private Dictionary<int, decimal> GetSalesByHour(IEnumerable<Satis> sales)
        {
            return sales
                .GroupBy(s => s.SatisTarixi.Hour)
                .ToDictionary(g => g.Key, g => g.Sum(s => s.UmumiMebleg));
        }

        private Dictionary<int, decimal> GetSalesByDay(IEnumerable<Satis> sales)
        {
            return sales
                .GroupBy(s => s.SatisTarixi.Day)
                .ToDictionary(g => g.Key, g => g.Sum(s => s.UmumiMebleg));
        }

        #endregion

        #region IDisposable

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _satisRepository?.Dispose();
                    _mehsulRepository?.Dispose();
                    _musteriRepository?.Dispose();
                    _tamirRepository?.Dispose();
                    _borcRepository?.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}