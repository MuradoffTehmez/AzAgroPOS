using AzAgroPOS.DAL;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.Entities.DTO;
using AzAgroPOS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AzAgroPOS.BLL.Services
{
    public class EmployeePerformanceService : IDisposable
    {
        private readonly IstifadeciRepository _employeeRepository;
        private readonly SatisRepository _salesRepository;
        private readonly TamirIsiRepository _repairRepository;
        private bool _disposed = false;

        public EmployeePerformanceService()
        {
            var context = new AzAgroDbContext();
            _employeeRepository = new IstifadeciRepository(context);
            _salesRepository = new SatisRepository(context);
            _repairRepository = new TamirIsiRepository(context);
        }

        #region Employee Performance Analytics

        /// <summary>
        /// Get detailed performance analytics for a specific employee
        /// </summary>
        public EmployeePerformanceDto GetEmployeePerformance(int employeeId, DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                var employee = _employeeRepository.GetById(employeeId);
                if (employee == null)
                    return null;

                startDate = startDate ?? DateTime.Now.AddDays(-30);
                endDate = endDate ?? DateTime.Now;

                // Get employee sales
                var employeeSales = _salesRepository.GetByKassir(employeeId, startDate, endDate).ToList();
                
                // Get employee repairs (if technician)
                var employeeRepairs = _repairRepository.GetByTechnician(employeeId, startDate, endDate).ToList();

                // Calculate sales metrics
                var totalSales = employeeSales.Count;
                var totalSalesAmount = employeeSales.Sum(s => s.UmumiMebleg);
                var averageSaleAmount = totalSales > 0 ? totalSalesAmount / totalSales : 0;

                // Calculate repair metrics
                var totalRepairs = employeeRepairs.Count;
                var completedRepairs = employeeRepairs.Count(r => r.Status == "Hazır");
                var pendingRepairs = employeeRepairs.Count(r => r.Status != "Hazır");
                var totalRepairRevenue = employeeRepairs.Sum(r => r.SonQiymet);
                var averageRepairTime = CalculateAverageRepairTime(employeeRepairs);
                var repairSuccessRate = totalRepairs > 0 ? (decimal)completedRepairs / totalRepairs * 100 : 0;

                // Calculate working metrics
                var workingDays = CalculateWorkingDays(employeeId, startDate.Value, endDate.Value);
                var totalWorkingHours = workingDays * 8; // Assuming 8 hours per day
                var averageHoursPerDay = workingDays > 0 ? totalWorkingHours / workingDays : 0;

                // Calculate performance score
                var performanceScore = CalculatePerformanceScore(employee, employeeSales, employeeRepairs);

                var performance = new EmployeePerformanceDto
                {
                    EmployeeId = employee.Id,
                    EmployeeName = employee.TamAd,
                    Role = employee.Rol?.Ad ?? "İşçi",
                    HireDate = employee.YaradilmaTarixi,
                    Status = employee.Status,

                    // Sales Performance
                    TotalSales = totalSales,
                    TotalSalesAmount = totalSalesAmount,
                    AverageSaleAmount = averageSaleAmount,
                    LastSaleDate = employeeSales.OrderByDescending(s => s.SatisTarixi).FirstOrDefault()?.SatisTarixi,

                    // Repair Performance
                    TotalRepairs = totalRepairs,
                    CompletedRepairs = completedRepairs,
                    PendingRepairs = pendingRepairs,
                    TotalRepairRevenue = totalRepairRevenue,
                    AverageRepairTime = averageRepairTime,
                    RepairSuccessRate = repairSuccessRate,

                    // Working Hours
                    TotalWorkingDays = workingDays,
                    TotalWorkingHours = totalWorkingHours,
                    AverageHoursPerDay = averageHoursPerDay,
                    ShiftCount = workingDays, // Simplified

                    // Performance Metrics
                    PerformanceScore = performanceScore,
                    PerformanceGrade = GetPerformanceGrade(performanceScore),
                    ProductivityIndex = CalculateProductivityIndex(totalSalesAmount, totalRepairRevenue, totalWorkingHours),

                    // Detailed data
                    RecentActivities = GetEmployeeActivities(employeeId, startDate.Value, endDate.Value),
                    RecentShifts = GetEmployeeShifts(employeeId, startDate.Value, endDate.Value),
                    MonthlyMetrics = GetMonthlyMetrics(employeeId),

                    // Targets (simplified)
                    MonthlySalesTarget = 10000, // This could be configured
                    MonthlyRepairTarget = 20,
                    TargetAchievementRate = CalculateTargetAchievement(totalSalesAmount, totalRepairs),

                    ReportDate = DateTime.Now
                };

                return performance;
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "İşçi performans analitikası alınarkən xəta baş verdi.");
                return null;
            }
        }

        /// <summary>
        /// Get employee performance summary
        /// </summary>
        public EmployeeSummaryDto GetEmployeeSummary()
        {
            try
            {
                var allEmployees = _employeeRepository.GetAllActive().ToList();
                var activeEmployees = allEmployees.Where(e => e.Status == "Aktiv").ToList();
                var newEmployees = allEmployees.Where(e => e.YaradilmaTarixi >= DateTime.Now.AddDays(-30)).ToList();

                var summary = new EmployeeSummaryDto
                {
                    TotalEmployees = allEmployees.Count,
                    ActiveEmployees = activeEmployees.Count,
                    InactiveEmployees = allEmployees.Count - activeEmployees.Count,
                    NewEmployeesThisMonth = newEmployees.Count,
                    TopSalesPerformers = GetTopSalesPerformers(),
                    TopRepairPerformers = GetTopRepairPerformers(),
                    UnderPerformers = GetUnderPerformers(),
                    GeneratedDate = DateTime.Now
                };

                // Calculate totals
                var lastMonth = DateTime.Now.AddDays(-30);
                foreach (var employee in activeEmployees)
                {
                    var sales = _salesRepository.GetByKassir(employee.Id, lastMonth, DateTime.Now);
                    var repairs = _repairRepository.GetByTechnician(employee.Id, lastMonth, DateTime.Now);
                    
                    summary.TotalSalesGenerated += sales.Sum(s => s.UmumiMebleg);
                    summary.TotalRepairRevenue += repairs.Sum(r => r.SonQiymet);
                }

                summary.AveragePerformanceScore = activeEmployees.Count > 0 ? 
                    activeEmployees.Average(e => CalculatePerformanceScore(e, 
                        _salesRepository.GetByKassir(e.Id, lastMonth, DateTime.Now).ToList(),
                        _repairRepository.GetByTechnician(e.Id, lastMonth, DateTime.Now).ToList())) : 0;

                return summary;
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "İşçi xülasəsi alınarkən xəta baş verdi.");
                return null;
            }
        }

        #endregion

        #region Helper Methods

        private decimal CalculateAverageRepairTime(List<TamirIsi> repairs)
        {
            if (!repairs.Any()) return 0;

            var completedRepairs = repairs.Where(r => r.TehvilTarixi.HasValue).ToList();
            if (!completedRepairs.Any()) return 0;

            var totalDays = completedRepairs.Sum(r => (r.TehvilTarixi.Value - r.QebulTarixi).Days);
            return (decimal)totalDays / completedRepairs.Count;
        }

        private int CalculateWorkingDays(int employeeId, DateTime startDate, DateTime endDate)
        {
            // Simplified calculation - assumes employee works every weekday
            var totalDays = (endDate - startDate).Days;
            var workingDays = 0;

            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                {
                    workingDays++;
                }
            }

            return workingDays;
        }

        private decimal CalculatePerformanceScore(Istifadeci employee, List<Satis> sales, List<TamirIsi> repairs)
        {
            var score = 0m;

            // Sales performance (40% weight)
            var salesScore = 0m;
            if (sales.Any())
            {
                var totalSales = sales.Sum(s => s.UmumiMebleg);
                var salesCount = sales.Count;
                
                // Base score on sales volume and frequency
                salesScore = Math.Min(40, (totalSales / 1000) + (salesCount * 2));
            }

            // Repair performance (40% weight)
            var repairScore = 0m;
            if (repairs.Any())
            {
                var completedRepairs = repairs.Count(r => r.Status == "Hazır");
                var totalRepairs = repairs.Count;
                var successRate = totalRepairs > 0 ? (decimal)completedRepairs / totalRepairs : 0;
                
                repairScore = Math.Min(40, (completedRepairs * 3) + (successRate * 20));
            }

            // Experience and reliability (20% weight)
            var experienceScore = 0m;
            var daysSinceHire = (DateTime.Now - employee.YaradilmaTarixi).Days;
            if (daysSinceHire > 365) experienceScore += 10; // 1+ years
            if (daysSinceHire > 730) experienceScore += 5;  // 2+ years
            if (employee.Status == "Aktiv") experienceScore += 5; // Active status

            score = salesScore + repairScore + experienceScore;
            return Math.Min(100, score);
        }

        private string GetPerformanceGrade(decimal score)
        {
            if (score >= 90) return "A";
            if (score >= 80) return "B";
            if (score >= 70) return "C";
            if (score >= 60) return "D";
            return "F";
        }

        private decimal CalculateProductivityIndex(decimal salesAmount, decimal repairRevenue, decimal workingHours)
        {
            if (workingHours == 0) return 0;
            return (salesAmount + repairRevenue) / workingHours;
        }

        private decimal CalculateTargetAchievement(decimal actualSales, int actualRepairs)
        {
            var salesTarget = 10000m; // Monthly target
            var repairTarget = 20; // Monthly target
            
            var salesAchievement = salesTarget > 0 ? (actualSales / salesTarget) * 100 : 0;
            var repairAchievement = repairTarget > 0 ? ((decimal)actualRepairs / repairTarget) * 100 : 0;
            
            return (salesAchievement + repairAchievement) / 2;
        }

        private List<EmployeeActivityDto> GetEmployeeActivities(int employeeId, DateTime startDate, DateTime endDate)
        {
            var activities = new List<EmployeeActivityDto>();

            // Add sales activities
            var sales = _salesRepository.GetByKassir(employeeId, startDate, endDate).Take(10);
            foreach (var sale in sales)
            {
                activities.Add(new EmployeeActivityDto
                {
                    ActivityDate = sale.SatisTarixi,
                    ActivityType = "Satış",
                    Description = $"Satış #{sale.SatisNomresi}",
                    Value = sale.UmumiMebleg,
                    Status = sale.Status,
                    Details = $"Ödəniş: {sale.OdemeNovu}"
                });
            }

            // Add repair activities
            var repairs = _repairRepository.GetByTechnician(employeeId, startDate, endDate).Take(10);
            foreach (var repair in repairs)
            {
                activities.Add(new EmployeeActivityDto
                {
                    ActivityDate = repair.QebulTarixi,
                    ActivityType = "Təmir",
                    Description = repair.MehsulAdi,
                    Value = repair.SonQiymet,
                    Status = repair.Status,
                    Details = repair.ProblemTasviri
                });
            }

            return activities.OrderByDescending(a => a.ActivityDate).Take(20).ToList();
        }

        private List<ShiftDto> GetEmployeeShifts(int employeeId, DateTime startDate, DateTime endDate)
        {
            var shifts = new List<ShiftDto>();

            // Simplified shift calculation based on working days
            for (var date = startDate; date <= endDate && date <= DateTime.Now; date = date.AddDays(1))
            {
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                {
                    var daySales = _salesRepository.GetByKassir(employeeId, date, date.AddDays(1));
                    var dayRepairs = _repairRepository.GetByTechnician(employeeId, date, date.AddDays(1));

                    shifts.Add(new ShiftDto
                    {
                        ShiftDate = date,
                        StartTime = date.AddHours(9), // 9 AM start
                        EndTime = date.AddHours(18), // 6 PM end
                        WorkedHours = 8,
                        BreakMinutes = 60,
                        SalesCount = daySales.Count(),
                        SalesAmount = daySales.Sum(s => s.UmumiMebleg),
                        RepairsHandled = dayRepairs.Count(),
                        Notes = daySales.Any() || dayRepairs.Any() ? "Aktiv" : "Az aktivlik"
                    });
                }
            }

            return shifts.OrderByDescending(s => s.ShiftDate).Take(10).ToList();
        }

        private List<PerformanceMetricDto> GetMonthlyMetrics(int employeeId)
        {
            var metrics = new List<PerformanceMetricDto>();
            
            for (int i = 5; i >= 0; i--)
            {
                var monthStart = DateTime.Now.AddMonths(-i).AddDays(-DateTime.Now.Day + 1);
                var monthEnd = monthStart.AddMonths(1).AddDays(-1);
                
                var sales = _salesRepository.GetByKassir(employeeId, monthStart, monthEnd);
                var repairs = _repairRepository.GetByTechnician(employeeId, monthStart, monthEnd);
                
                metrics.Add(new PerformanceMetricDto
                {
                    Year = monthStart.Year,
                    Month = monthStart.Month,
                    MonthName = monthStart.ToString("MMMM"),
                    SalesCount = sales.Count(),
                    SalesAmount = sales.Sum(s => s.UmumiMebleg),
                    RepairsCount = repairs.Count(),
                    RepairRevenue = repairs.Sum(r => r.SonQiymet),
                    WorkedHours = CalculateWorkingDays(employeeId, monthStart, monthEnd) * 8,
                    PerformanceScore = CalculatePerformanceScore(
                        _employeeRepository.GetById(employeeId), 
                        sales.ToList(), 
                        repairs.ToList()),
                    TargetAchievement = CalculateTargetAchievement(sales.Sum(s => s.UmumiMebleg), repairs.Count())
                });
            }
            
            return metrics;
        }

        private List<TopPerformerDto> GetTopSalesPerformers()
        {
            var performers = new List<TopPerformerDto>();
            var employees = _employeeRepository.GetAllActive().Take(10);
            var lastMonth = DateTime.Now.AddDays(-30);

            foreach (var employee in employees)
            {
                var sales = _salesRepository.GetByKassir(employee.Id, lastMonth, DateTime.Now);
                var totalSales = sales.Sum(s => s.UmumiMebleg);
                
                if (totalSales > 0)
                {
                    performers.Add(new TopPerformerDto
                    {
                        EmployeeId = employee.Id,
                        EmployeeName = employee.TamAd,
                        Role = employee.Rol?.Ad ?? "İşçi",
                        Value = totalSales,
                        PerformanceScore = CalculatePerformanceScore(employee, sales.ToList(), new List<TamirIsi>()),
                        Achievement = $"{totalSales:C} satış"
                    });
                }
            }

            return performers.OrderByDescending(p => p.Value).Take(5).ToList();
        }

        private List<TopPerformerDto> GetTopRepairPerformers()
        {
            var performers = new List<TopPerformerDto>();
            var employees = _employeeRepository.GetAllActive().Take(10);
            var lastMonth = DateTime.Now.AddDays(-30);

            foreach (var employee in employees)
            {
                var repairs = _repairRepository.GetByTechnician(employee.Id, lastMonth, DateTime.Now);
                var completedRepairs = repairs.Count(r => r.Status == "Hazır");
                
                if (completedRepairs > 0)
                {
                    performers.Add(new TopPerformerDto
                    {
                        EmployeeId = employee.Id,
                        EmployeeName = employee.TamAd,
                        Role = employee.Rol?.Ad ?? "İşçi",
                        Value = completedRepairs,
                        PerformanceScore = CalculatePerformanceScore(employee, new List<Satis>(), repairs.ToList()),
                        Achievement = $"{completedRepairs} təmir"
                    });
                }
            }

            return performers.OrderByDescending(p => p.Value).Take(5).ToList();
        }

        private List<EmployeePerformanceDto> GetUnderPerformers()
        {
            var underPerformers = new List<EmployeePerformanceDto>();
            var employees = _employeeRepository.GetAllActive().Take(20);
            var lastMonth = DateTime.Now.AddDays(-30);

            foreach (var employee in employees)
            {
                var performance = GetEmployeePerformance(employee.Id, lastMonth, DateTime.Now);
                if (performance != null && performance.PerformanceScore < 50)
                {
                    underPerformers.Add(performance);
                }
            }

            return underPerformers.OrderBy(p => p.PerformanceScore).Take(5).ToList();
        }

        #endregion

        #region IDisposable

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _employeeRepository?.Dispose();
                    _salesRepository?.Dispose();
                    _repairRepository?.Dispose();
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