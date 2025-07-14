using System;
using System.Collections.Generic;

namespace AzAgroPOS.Entities.DTO
{
    public class CustomerAnalyticsDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerGroup { get; set; }
        public DateTime RegistrationDate { get; set; }
        
        // Purchase Statistics
        public int TotalOrders { get; set; }
        public decimal TotalSpent { get; set; }
        public decimal AverageOrderValue { get; set; }
        public DateTime? LastPurchaseDate { get; set; }
        public int DaysSinceLastPurchase { get; set; }
        
        // Debt Information
        public decimal TotalDebt { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal RemainingDebt { get; set; }
        public DateTime? LastPaymentDate { get; set; }
        
        // Repair History
        public int TotalRepairs { get; set; }
        public decimal TotalRepairCost { get; set; }
        public int CompletedRepairs { get; set; }
        public int PendingRepairs { get; set; }
        
        // Customer Value Metrics
        public string CustomerSegment { get; set; } // VIP, Regular, New, Inactive
        public decimal CustomerLifetimeValue { get; set; }
        public int LoyaltyScore { get; set; } // 0-100
        public string RiskLevel { get; set; } // Low, Medium, High
        
        // Activity Summary
        public List<CustomerActivityDto> RecentActivities { get; set; } = new List<CustomerActivityDto>();
        public List<ProductPurchaseDto> TopPurchasedProducts { get; set; } = new List<ProductPurchaseDto>();
        public List<CustomerServiceDto> ServiceHistory { get; set; } = new List<CustomerServiceDto>();
        
        // Behavioral Insights
        public string PreferredPurchaseDay { get; set; }
        public string PreferredPurchaseTime { get; set; }
        public decimal MonthlyAverageSpending { get; set; }
        public string SeasonalTrends { get; set; }
    }

    public class CustomerActivityDto
    {
        public DateTime ActivityDate { get; set; }
        public string ActivityType { get; set; } // Purchase, Payment, Repair, Contact
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public string Details { get; set; }
    }

    public class ProductPurchaseDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int PurchaseCount { get; set; }
        public decimal TotalQuantity { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime LastPurchaseDate { get; set; }
        public decimal AveragePrice { get; set; }
    }

    public class CustomerServiceDto
    {
        public DateTime ServiceDate { get; set; }
        public string ServiceType { get; set; } // Repair, Maintenance, Consultation
        public string Description { get; set; }
        public string Status { get; set; }
        public decimal Cost { get; set; }
        public string Technician { get; set; }
        public int CompletionDays { get; set; }
        public string SatisfactionRating { get; set; }
    }

    public class CustomerSummaryDto
    {
        public int TotalCustomers { get; set; }
        public int ActiveCustomers { get; set; }
        public int NewCustomersThisMonth { get; set; }
        public int InactiveCustomers { get; set; }
        
        public decimal TotalCustomerValue { get; set; }
        public decimal AverageCustomerValue { get; set; }
        public decimal TotalOutstandingDebt { get; set; }
        
        public List<CustomerSegmentDto> CustomerSegments { get; set; } = new List<CustomerSegmentDto>();
        public List<CustomerAnalyticsDto> TopCustomers { get; set; } = new List<CustomerAnalyticsDto>();
        public List<CustomerAnalyticsDto> RiskCustomers { get; set; } = new List<CustomerAnalyticsDto>();
        
        public DateTime GeneratedDate { get; set; }
    }

    public class CustomerSegmentDto
    {
        public string SegmentName { get; set; }
        public int CustomerCount { get; set; }
        public decimal TotalValue { get; set; }
        public decimal AverageValue { get; set; }
        public decimal Percentage { get; set; }
        public string Description { get; set; }
    }
}