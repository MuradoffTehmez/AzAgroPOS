using System;
using System.Collections.Generic;

namespace AzAgroPOS.Entities.DTO
{
    public class RepairAnalyticsDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalRepairs { get; set; }
        public int CompletedRepairs { get; set; }
        public int PendingRepairs { get; set; }
        public int InProgressRepairs { get; set; }
        public decimal TotalCost { get; set; }
        public decimal AverageCost { get; set; }
        public DateTime GeneratedDate { get; set; }
        
        public List<RepairTypeDto> RepairsByType { get; set; } = new List<RepairTypeDto>();
        public List<RepairWorkerDto> WorkerPerformance { get; set; } = new List<RepairWorkerDto>();
        
        public decimal CompletionRate => TotalRepairs > 0 ? (decimal)CompletedRepairs / TotalRepairs * 100 : 0;
        public decimal AverageRepairTime { get; set; }
    }

    public class RepairTypeDto
    {
        public string RepairType { get; set; }
        public int Count { get; set; }
        public decimal TotalCost { get; set; }
        public decimal AverageCost { get; set; }
        public decimal Percentage { get; set; }
        public decimal AverageCompletionDays { get; set; }
    }

    public class RepairWorkerDto
    {
        public int WorkerId { get; set; }
        public string WorkerName { get; set; }
        public int CompletedRepairs { get; set; }
        public int PendingRepairs { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal AverageRepairTime { get; set; }
        public decimal SuccessRate { get; set; }
    }
}