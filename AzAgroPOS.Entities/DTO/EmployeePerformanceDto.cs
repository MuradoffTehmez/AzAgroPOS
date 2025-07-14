using System;
using System.Collections.Generic;

namespace AzAgroPOS.Entities.DTO
{
    public class EmployeePerformanceDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Role { get; set; }
        public DateTime HireDate { get; set; }
        public string Status { get; set; }
        
        // Sales Performance
        public int TotalSales { get; set; }
        public decimal TotalSalesAmount { get; set; }
        public decimal AverageSaleAmount { get; set; }
        public DateTime? LastSaleDate { get; set; }
        
        // Repair Performance (for technicians)
        public int TotalRepairs { get; set; }
        public int CompletedRepairs { get; set; }
        public int PendingRepairs { get; set; }
        public decimal TotalRepairRevenue { get; set; }
        public decimal AverageRepairTime { get; set; } // in days
        public decimal RepairSuccessRate { get; set; }
        
        // Working Hours and Shifts
        public int TotalWorkingDays { get; set; }
        public decimal TotalWorkingHours { get; set; }
        public decimal AverageHoursPerDay { get; set; }
        public int ShiftCount { get; set; }
        
        // Performance Metrics
        public decimal PerformanceScore { get; set; } // 0-100
        public string PerformanceGrade { get; set; } // A, B, C, D, F
        public decimal ProductivityIndex { get; set; }
        
        // Activity Details
        public List<EmployeeActivityDto> RecentActivities { get; set; } = new List<EmployeeActivityDto>();
        public List<ShiftDto> RecentShifts { get; set; } = new List<ShiftDto>();
        public List<PerformanceMetricDto> MonthlyMetrics { get; set; } = new List<PerformanceMetricDto>();
        
        // Goals and Targets
        public decimal MonthlySalesTarget { get; set; }
        public decimal MonthlyRepairTarget { get; set; }
        public decimal TargetAchievementRate { get; set; }
        
        public DateTime ReportDate { get; set; }
    }

    public class EmployeeActivityDto
    {
        public DateTime ActivityDate { get; set; }
        public string ActivityType { get; set; } // Sale, Repair, Login, Logout, Break
        public string Description { get; set; }
        public decimal Value { get; set; } // Amount or time
        public string Status { get; set; }
        public string Details { get; set; }
    }

    public class ShiftDto
    {
        public DateTime ShiftDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal WorkedHours { get; set; }
        public int BreakMinutes { get; set; }
        public int SalesCount { get; set; }
        public decimal SalesAmount { get; set; }
        public int RepairsHandled { get; set; }
        public string Notes { get; set; }
    }

    public class PerformanceMetricDto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public string MonthName { get; set; }
        public int SalesCount { get; set; }
        public decimal SalesAmount { get; set; }
        public int RepairsCount { get; set; }
        public decimal RepairRevenue { get; set; }
        public decimal WorkedHours { get; set; }
        public decimal PerformanceScore { get; set; }
        public decimal TargetAchievement { get; set; }
    }

    public class EmployeeSummaryDto
    {
        public int TotalEmployees { get; set; }
        public int ActiveEmployees { get; set; }
        public int InactiveEmployees { get; set; }
        public int NewEmployeesThisMonth { get; set; }
        
        public decimal TotalSalesGenerated { get; set; }
        public decimal TotalRepairRevenue { get; set; }
        public decimal AveragePerformanceScore { get; set; }
        
        public List<TopPerformerDto> TopSalesPerformers { get; set; } = new List<TopPerformerDto>();
        public List<TopPerformerDto> TopRepairPerformers { get; set; } = new List<TopPerformerDto>();
        public List<EmployeePerformanceDto> UnderPerformers { get; set; } = new List<EmployeePerformanceDto>();
        
        public DateTime GeneratedDate { get; set; }
    }

    public class TopPerformerDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Role { get; set; }
        public decimal Value { get; set; } // Sales amount or repair count
        public decimal PerformanceScore { get; set; }
        public string Achievement { get; set; }
    }

    public class ShiftScheduleDto
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime ShiftDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string ShiftType { get; set; } // Morning, Evening, Night
        public string Status { get; set; } // Scheduled, Started, Completed, Absent
        public string Notes { get; set; }
    }
}