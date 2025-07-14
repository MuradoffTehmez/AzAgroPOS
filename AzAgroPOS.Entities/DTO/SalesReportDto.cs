using System;
using System.Collections.Generic;

namespace AzAgroPOS.Entities.DTO
{
    public class SalesReportDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalSales { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal NetAmount { get; set; }
        public string ReportType { get; set; }
        public DateTime GeneratedDate { get; set; }
        
        public List<ProductSalesDto> TopProducts { get; set; } = new List<ProductSalesDto>();
        public Dictionary<int, decimal> SalesByHour { get; set; } = new Dictionary<int, decimal>();
        public Dictionary<int, decimal> SalesByDay { get; set; } = new Dictionary<int, decimal>();
        
        public decimal AverageOrderValue => TotalSales > 0 ? NetAmount / TotalSales : 0;
        public decimal DiscountPercentage => TotalAmount > 0 ? (TotalDiscount / TotalAmount) * 100 : 0;
    }

    public class ProductSalesDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public decimal TotalQuantity { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AveragePrice { get; set; }
        public int SalesCount { get; set; }
        public decimal Percentage { get; set; }
    }
}