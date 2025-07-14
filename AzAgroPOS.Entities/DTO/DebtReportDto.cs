using System;
using System.Collections.Generic;

namespace AzAgroPOS.Entities.DTO
{
    public class DebtReportDto
    {
        public decimal TotalDebt { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal RemainingDebt { get; set; }
        public int CustomersWithDebt { get; set; }
        public DateTime GeneratedDate { get; set; }
        
        public List<CustomerDebtDto> CustomerDebts { get; set; } = new List<CustomerDebtDto>();
        
        public decimal CollectionRate => TotalDebt > 0 ? (TotalPaid / TotalDebt) * 100 : 0;
        public decimal AverageDebtPerCustomer => CustomersWithDebt > 0 ? RemainingDebt / CustomersWithDebt : 0;
    }

    public class CustomerDebtDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public decimal TotalDebt { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal RemainingDebt { get; set; }
        public DateTime? LastPaymentDate { get; set; }
        public int DebtCount { get; set; }
        public int DaysOverdue { get; set; }
        public string RiskLevel { get; set; }
    }
}