using AzAgroPOS.DAL;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AzAgroPOS.BLL.Services
{
    public class CustomerAnalyticsService : IDisposable
    {
        private readonly MusteriRepository _musteriRepository;
        private readonly SatisRepository _satisRepository;
        private readonly MusteriBorcRepository _borcRepository;
        private readonly TamirIsiRepository _tamirRepository;
        private readonly MehsulRepository _mehsulRepository;
        private bool _disposed = false;

        public CustomerAnalyticsService()
        {
            var context = new AzAgroDbContext();
            _musteriRepository = new MusteriRepository(context);
            _satisRepository = new SatisRepository(context);
            _borcRepository = new MusteriBorcRepository(context);
            _tamirRepository = new TamirIsiRepository(context);
            _mehsulRepository = new MehsulRepository(context);
        }

        #region Customer Analytics

        /// <summary>
        /// Get detailed analytics for a specific customer
        /// </summary>
        public CustomerAnalyticsDto GetCustomerAnalytics(int customerId)
        {
            try
            {
                var customer = _musteriRepository.GetById(customerId);
                if (customer == null)
                    return null;

                // Get customer purchase history
                var customerSales = GetCustomerSales(customerId);
                var customerDebts = GetCustomerDebts(customerId);
                var customerRepairs = GetCustomerRepairs(customerId);

                // Calculate metrics
                var totalSpent = customerSales.Sum(s => s.UmumiMebleg);
                var totalOrders = customerSales.Count();
                var averageOrderValue = totalOrders > 0 ? totalSpent / totalOrders : 0;
                var lastPurchase = customerSales.OrderByDescending(s => s.SatisTarixi).FirstOrDefault()?.SatisTarixi;

                var totalDebt = customerDebts.Sum(d => d.BorcMeblegi);
                var paidAmount = customerDebts.Sum(d => d.OdenilmisMebleg);
                var remainingDebt = totalDebt - paidAmount;

                var totalRepairs = customerRepairs.Count();
                var totalRepairCost = customerRepairs.Sum(r => r.SonQiymet);
                var completedRepairs = customerRepairs.Count(r => r.Status == "Hazır");
                var pendingRepairs = customerRepairs.Count(r => r.Status != "Hazır");

                var analytics = new CustomerAnalyticsDto
                {
                    CustomerId = customer.Id,
                    CustomerName = $"{customer.Ad} {customer.Soyad}",
                    CustomerPhone = customer.Telefon,
                    CustomerEmail = customer.Email,
                    CustomerGroup = customer.MusteriQrupu?.Ad ?? "Ümumi",
                    RegistrationDate = customer.YaradilmaTarixi,

                    // Purchase Statistics
                    TotalOrders = totalOrders,
                    TotalSpent = totalSpent,
                    AverageOrderValue = averageOrderValue,
                    LastPurchaseDate = lastPurchase,
                    DaysSinceLastPurchase = lastPurchase.HasValue ? (DateTime.Now - lastPurchase.Value).Days : 365,

                    // Debt Information
                    TotalDebt = totalDebt,
                    PaidAmount = paidAmount,
                    RemainingDebt = remainingDebt,
                    LastPaymentDate = customerDebts.OrderByDescending(d => d.SonOdemeTarixi).FirstOrDefault()?.SonOdemeTarixi,

                    // Repair History
                    TotalRepairs = totalRepairs,
                    TotalRepairCost = totalRepairCost,
                    CompletedRepairs = completedRepairs,
                    PendingRepairs = pendingRepairs,

                    // Calculate derived metrics
                    CustomerLifetimeValue = totalSpent + totalRepairCost,
                    LoyaltyScore = CalculateLoyaltyScore(customer, customerSales, customerRepairs),
                    CustomerSegment = DetermineCustomerSegment(totalSpent, totalOrders, customer.YaradilmaTarixi),
                    RiskLevel = DetermineRiskLevel(remainingDebt, lastPurchase),

                    // Get detailed data
                    RecentActivities = GetCustomerActivities(customerId),
                    TopPurchasedProducts = GetTopPurchasedProducts(customerId),
                    ServiceHistory = GetServiceHistory(customerId),

                    // Behavioral insights
                    PreferredPurchaseDay = GetPreferredPurchaseDay(customerSales),
                    PreferredPurchaseTime = GetPreferredPurchaseTime(customerSales),
                    MonthlyAverageSpending = CalculateMonthlyAverageSpending(customerSales),
                    SeasonalTrends = AnalyzeSeasonalTrends(customerSales)
                };

                return analytics;
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "Müştəri analitikası alınarkən xəta baş verdi.");
                return null;
            }
        }

        /// <summary>
        /// Get customer summary analytics
        /// </summary>
        public CustomerSummaryDto GetCustomerSummary()
        {
            try
            {
                var allCustomers = _musteriRepository.GetAllActive().ToList();
                var allSales = _satisRepository.GetByDateRange(DateTime.Now.AddYears(-1), DateTime.Now).ToList();
                var allDebts = _borcRepository.GetAllActiveDebts();

                var activeCustomers = GetActiveCustomers(allCustomers, allSales);
                var newCustomersThisMonth = allCustomers.Count(c => c.YaradilmaTarixi >= DateTime.Now.AddDays(-30));
                var inactiveCustomers = allCustomers.Count - activeCustomers.Count;

                var totalCustomerValue = allSales.Sum(s => s.UmumiMebleg);
                var averageCustomerValue = allCustomers.Count > 0 ? totalCustomerValue / allCustomers.Count : 0;
                var totalOutstandingDebt = allDebts.Sum(d => d.BorcMeblegi - (d.OdenenMebleg ?? 0));

                var summary = new CustomerSummaryDto
                {
                    TotalCustomers = allCustomers.Count,
                    ActiveCustomers = activeCustomers.Count,
                    NewCustomersThisMonth = newCustomersThisMonth,
                    InactiveCustomers = inactiveCustomers,
                    TotalCustomerValue = totalCustomerValue,
                    AverageCustomerValue = averageCustomerValue,
                    TotalOutstandingDebt = totalOutstandingDebt,
                    CustomerSegments = GetCustomerSegments(allCustomers, allSales),
                    TopCustomers = GetTopCustomers(allCustomers, allSales),
                    RiskCustomers = GetRiskCustomers(allCustomers, allDebts),
                    GeneratedDate = DateTime.Now
                };

                return summary;
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "Müştəri xülasəsi alınarkən xəta baş verdi.");
                return null;
            }
        }

        #endregion

        #region Helper Methods

        private List<Satis> GetCustomerSales(int customerId)
        {
            return _satisRepository.GetByCustomer(customerId).ToList();
        }

        private List<MusteriBorc> GetCustomerDebts(int customerId)
        {
            return _borcRepository.GetByCustomer(customerId).ToList();
        }

        private List<TamirIsi> GetCustomerRepairs(int customerId)
        {
            return _tamirRepository.GetByCustomer(customerId).ToList();
        }

        private int CalculateLoyaltyScore(Musteri customer, List<Satis> sales, List<TamirIsi> repairs)
        {
            var score = 0;

            // Registration duration (max 20 points)
            var daysSinceRegistration = (DateTime.Now - customer.YaradilmaTarixi).Days;
            score += Math.Min(20, daysSinceRegistration / 30);

            // Purchase frequency (max 30 points)
            if (sales.Any())
            {
                var monthsSinceFirstPurchase = Math.Max(1, (DateTime.Now - sales.Min(s => s.SatisTarixi)).Days / 30);
                var purchaseFrequency = sales.Count / (decimal)monthsSinceFirstPurchase;
                score += (int)Math.Min(30, purchaseFrequency * 10);
            }

            // Total spending (max 25 points)
            var totalSpent = sales.Sum(s => s.UmumiMebleg);
            if (totalSpent > 5000) score += 25;
            else if (totalSpent > 2000) score += 15;
            else if (totalSpent > 500) score += 10;
            else if (totalSpent > 100) score += 5;

            // Service usage (max 15 points)
            if (repairs.Count > 10) score += 15;
            else if (repairs.Count > 5) score += 10;
            else if (repairs.Count > 0) score += 5;

            // Recent activity (max 10 points)
            var daysSinceLastActivity = sales.Any() ? (DateTime.Now - sales.Max(s => s.SatisTarixi)).Days : 365;
            if (daysSinceLastActivity < 30) score += 10;
            else if (daysSinceLastActivity < 90) score += 5;

            return Math.Min(100, score);
        }

        private string DetermineCustomerSegment(decimal totalSpent, int totalOrders, DateTime registrationDate)
        {
            var daysSinceRegistration = (DateTime.Now - registrationDate).Days;

            if (totalSpent > 10000 && totalOrders > 20)
                return "VIP";
            else if (totalSpent > 2000 && totalOrders > 5)
                return "Daimi";
            else if (daysSinceRegistration < 30)
                return "Yeni";
            else if (totalOrders == 0 && daysSinceRegistration > 180)
                return "Passiv";
            else
                return "Adi";
        }

        private string DetermineRiskLevel(decimal remainingDebt, DateTime? lastPurchase)
        {
            var daysSinceLastPurchase = lastPurchase.HasValue ? (DateTime.Now - lastPurchase.Value).Days : 365;

            if (remainingDebt > 1000 && daysSinceLastPurchase > 90)
                return "Yüksək";
            else if (remainingDebt > 500 || daysSinceLastPurchase > 180)
                return "Orta";
            else if (remainingDebt > 0 || daysSinceLastPurchase > 90)
                return "Aşağı";
            else
                return "Normal";
        }

        private List<CustomerActivityDto> GetCustomerActivities(int customerId)
        {
            var activities = new List<CustomerActivityDto>();

            // Add sales activities
            var recentSales = _satisRepository.GetByCustomer(customerId).OrderByDescending(s => s.SatisTarixi).Take(10);
            foreach (var sale in recentSales)
            {
                activities.Add(new CustomerActivityDto
                {
                    ActivityDate = sale.SatisTarixi,
                    ActivityType = "Alış",
                    Description = $"Satış #{sale.SatisNomresi}",
                    Amount = sale.UmumiMebleg,
                    Status = sale.Status,
                    Details = $"{sale.SatisDetallari?.Count ?? 0} məhsul"
                });
            }

            // Add payment activities
            var recentPayments = _borcRepository.GetByCustomer(customerId).Where(d => d.SonOdemeTarixi.HasValue)
                .OrderByDescending(d => d.SonOdemeTarixi).Take(10);
            foreach (var payment in recentPayments)
            {
                if (payment.SonOdemeTarixi.HasValue)
                {
                    activities.Add(new CustomerActivityDto
                    {
                        ActivityDate = payment.SonOdemeTarixi.Value,
                        ActivityType = "Ödəniş",
                        Description = $"Borc ödənişi",
                        Amount = payment.OdenenMebleg ?? 0,
                        Status = payment.Status,
                        Details = $"Qalan: {payment.BorcMeblegi - (payment.OdenenMebleg ?? 0):C}"
                    });
                }
            }

            // Add repair activities
            var recentRepairs = _tamirRepository.GetByCustomer(customerId).OrderByDescending(r => r.QebulTarixi).Take(10);
            foreach (var repair in recentRepairs)
            {
                activities.Add(new CustomerActivityDto
                {
                    ActivityDate = repair.QebulTarixi,
                    ActivityType = "Təmir",
                    Description = repair.TamirNovu,
                    Amount = repair.TamirMebləgi ?? 0,
                    Status = repair.Veziyyeti,
                    Details = repair.ProblemTesviri
                });
            }

            return activities.OrderByDescending(a => a.ActivityDate).Take(20).ToList();
        }

        private List<ProductPurchaseDto> GetTopPurchasedProducts(int customerId)
        {
            var customerSales = _satisRepository.GetByCustomer(customerId);
            var productPurchases = new List<ProductPurchaseDto>();

            var groupedProducts = customerSales
                .SelectMany(s => s.SatisDetallari)
                .GroupBy(sd => sd.MehsulId)
                .ToList();

            foreach (var group in groupedProducts)
            {
                var product = _mehsulRepository.GetById(group.Key);
                if (product != null)
                {
                    var totalQuantity = group.Sum(sd => sd.Miqdar);
                    var totalAmount = group.Sum(sd => sd.Miqdar * sd.VahidQiymeti);
                    var purchaseCount = group.Count();

                    productPurchases.Add(new ProductPurchaseDto
                    {
                        ProductId = product.Id,
                        ProductName = product.Ad,
                        ProductCode = product.SKU,
                        PurchaseCount = purchaseCount,
                        TotalQuantity = totalQuantity,
                        TotalAmount = totalAmount,
                        LastPurchaseDate = group.Max(sd => sd.Satis.SatisTarixi),
                        AveragePrice = totalQuantity > 0 ? totalAmount / totalQuantity : 0
                    });
                }
            }

            return productPurchases.OrderByDescending(pp => pp.TotalAmount).Take(10).ToList();
        }

        private List<CustomerServiceDto> GetServiceHistory(int customerId)
        {
            var repairs = _tamirRepository.GetByCustomer(customerId).OrderByDescending(r => r.QebulTarixi);
            var serviceHistory = new List<CustomerServiceDto>();

            foreach (var repair in repairs)
            {
                var completionDays = repair.TehvilTarixi.HasValue ? 
                    (repair.TehvilTarixi.Value - repair.QebulTarixi).Days : 
                    (DateTime.Now - repair.QebulTarixi).Days;

                serviceHistory.Add(new CustomerServiceDto
                {
                    ServiceDate = repair.QebulTarixi,
                    ServiceType = repair.Status,
                    Description = repair.ProblemTasviri,
                    Status = repair.Status,
                    Cost = repair.SonQiymet,
                    Technician = repair.TeyinEdilenIstifadeci?.TamAd ?? "Təyin edilməyib",
                    CompletionDays = completionDays,
                    SatisfactionRating = "Qiymətləndirilməyib" // This could be expanded
                });
            }

            return serviceHistory.Take(20).ToList();
        }

        private string GetPreferredPurchaseDay(List<Satis> sales)
        {
            if (!sales.Any()) return "Məlumat yoxdur";

            var dayGroups = sales.GroupBy(s => s.SatisTarixi.DayOfWeek);
            var preferredDay = dayGroups.OrderByDescending(g => g.Count()).FirstOrDefault();
            
            return preferredDay?.Key.ToString() ?? "Məlumat yoxdur";
        }

        private string GetPreferredPurchaseTime(List<Satis> sales)
        {
            if (!sales.Any()) return "Məlumat yoxdur";

            var hourGroups = sales.GroupBy(s => s.SatisTarixi.Hour);
            var preferredHour = hourGroups.OrderByDescending(g => g.Count()).FirstOrDefault();
            
            if (preferredHour != null)
            {
                var hour = preferredHour.Key;
                if (hour < 12) return "Səhər";
                else if (hour < 17) return "Gündüz";
                else return "Axşam";
            }
            
            return "Məlumat yoxdur";
        }

        private decimal CalculateMonthlyAverageSpending(List<Satis> sales)
        {
            if (!sales.Any()) return 0;

            var totalSpent = sales.Sum(s => s.UmumiMebleg);
            var monthsSpan = Math.Max(1, (DateTime.Now - sales.Min(s => s.SatisTarixi)).Days / 30);
            
            return totalSpent / monthsSpan;
        }

        private string AnalyzeSeasonalTrends(List<Satis> sales)
        {
            if (!sales.Any()) return "Məlumat yoxdur";

            var seasonalSpending = sales.GroupBy(s => GetSeason(s.SatisTarixi))
                .ToDictionary(g => g.Key, g => g.Sum(s => s.UmumiMebleg));

            if (!seasonalSpending.Any()) return "Məlumat yoxdur";

            var topSeason = seasonalSpending.OrderByDescending(kvp => kvp.Value).First();
            return $"Ən aktiv: {topSeason.Key}";
        }

        private string GetSeason(DateTime date)
        {
            var month = date.Month;
            if (month >= 3 && month <= 5) return "Yaz";
            if (month >= 6 && month <= 8) return "Yay";
            if (month >= 9 && month <= 11) return "Payız";
            return "Qış";
        }

        private List<Musteri> GetActiveCustomers(List<Musteri> allCustomers, List<Satis> allSales)
        {
            var activeCustomerIds = allSales.Where(s => s.SatisTarixi >= DateTime.Now.AddDays(-90))
                .Select(s => s.MusteriId)
                .Distinct()
                .ToHashSet();

            return allCustomers.Where(c => activeCustomerIds.Contains(c.Id)).ToList();
        }

        private List<CustomerSegmentDto> GetCustomerSegments(List<Musteri> customers, List<Satis> sales)
        {
            var segments = new List<CustomerSegmentDto>();
            var totalCustomers = customers.Count;

            foreach (var customer in customers)
            {
                var customerSales = sales.Where(s => s.MusteriId == customer.Id).ToList();
                var totalSpent = customerSales.Sum(s => s.UmumiMebleg);
                var segment = DetermineCustomerSegment(totalSpent, customerSales.Count, customer.YaradilmaTarixi);

                var existingSegment = segments.FirstOrDefault(s => s.SegmentName == segment);
                if (existingSegment != null)
                {
                    existingSegment.CustomerCount++;
                    existingSegment.TotalValue += totalSpent;
                }
                else
                {
                    segments.Add(new CustomerSegmentDto
                    {
                        SegmentName = segment,
                        CustomerCount = 1,
                        TotalValue = totalSpent,
                        Description = GetSegmentDescription(segment)
                    });
                }
            }

            // Calculate averages and percentages
            foreach (var segment in segments)
            {
                segment.AverageValue = segment.CustomerCount > 0 ? segment.TotalValue / segment.CustomerCount : 0;
                segment.Percentage = totalCustomers > 0 ? (decimal)segment.CustomerCount / totalCustomers * 100 : 0;
            }

            return segments.OrderByDescending(s => s.CustomerCount).ToList();
        }

        private string GetSegmentDescription(string segment)
        {
            switch (segment)
            {
                case "VIP": return "Yüksək dəyərli müştərilər";
                case "Daimi": return "Müntəzəm alışveriş edən müştərilər";
                case "Yeni": return "Son 30 gündə qeydiyyatdan keçən müştərilər";
                case "Passiv": return "Uzun müddətdir alışveriş etməyən müştərilər";
                default: return "Adi müştərilər";
            }
        }

        private List<CustomerAnalyticsDto> GetTopCustomers(List<Musteri> customers, List<Satis> sales)
        {
            var topCustomers = new List<CustomerAnalyticsDto>();

            foreach (var customer in customers)
            {
                var customerSales = sales.Where(s => s.MusteriId == customer.Id).ToList();
                var totalSpent = customerSales.Sum(s => s.UmumiMebleg);

                if (totalSpent > 0)
                {
                    topCustomers.Add(new CustomerAnalyticsDto
                    {
                        CustomerId = customer.Id,
                        CustomerName = $"{customer.Ad} {customer.Soyad}",
                        TotalSpent = totalSpent,
                        TotalOrders = customerSales.Count,
                        AverageOrderValue = customerSales.Count > 0 ? totalSpent / customerSales.Count : 0,
                        LastPurchaseDate = customerSales.OrderByDescending(s => s.SatisTarixi).FirstOrDefault()?.SatisTarixi,
                        CustomerSegment = DetermineCustomerSegment(totalSpent, customerSales.Count, customer.YaradilmaTarixi)
                    });
                }
            }

            return topCustomers.OrderByDescending(c => c.TotalSpent).Take(10).ToList();
        }

        private List<CustomerAnalyticsDto> GetRiskCustomers(List<Musteri> customers, List<MusteriBorc> debts)
        {
            var riskCustomers = new List<CustomerAnalyticsDto>();

            var customerDebts = debts.GroupBy(d => d.MusteriId);

            foreach (var customerDebtGroup in customerDebts)
            {
                var customer = customers.FirstOrDefault(c => c.Id == customerDebtGroup.Key);
                if (customer != null)
                {
                    var totalDebt = customerDebtGroup.Sum(d => d.BorcMeblegi);
                    var paidAmount = customerDebtGroup.Sum(d => d.OdenilmisMebleg);
                    var remainingDebt = totalDebt - paidAmount;
                    var lastPayment = customerDebtGroup.Max(d => d.SonOdemeTarixi);

                    var riskLevel = DetermineRiskLevel(remainingDebt, lastPayment);

                    if (riskLevel == "Yüksək" || riskLevel == "Orta")
                    {
                        riskCustomers.Add(new CustomerAnalyticsDto
                        {
                            CustomerId = customer.Id,
                            CustomerName = $"{customer.Ad} {customer.Soyad}",
                            TotalDebt = totalDebt,
                            PaidAmount = paidAmount,
                            RemainingDebt = remainingDebt,
                            LastPaymentDate = lastPayment,
                            RiskLevel = riskLevel
                        });
                    }
                }
            }

            return riskCustomers.OrderByDescending(c => c.RemainingDebt).Take(10).ToList();
        }

        #endregion

        #region IDisposable

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _musteriRepository?.Dispose();
                    _satisRepository?.Dispose();
                    _borcRepository?.Dispose();
                    _tamirRepository?.Dispose();
                    _mehsulRepository?.Dispose();
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