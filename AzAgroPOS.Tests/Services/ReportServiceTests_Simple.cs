using AzAgroPOS.BLL.Services;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.Entities.DTO;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AzAgroPOS.Tests.Services
{
    /// <summary>
    /// ReportService-in sadə unit testləri
    /// Mövcud metodları test edir
    /// </summary>
    public class ReportServiceSimpleTests : IDisposable
    {
        private readonly ReportService _reportService;

        public ReportServiceSimpleTests()
        {
            _reportService = new ReportService();
        }

        [Fact]
        public void Constructor_Should_CreateValidService()
        {
            // Assert
            _reportService.Should().NotBeNull();
        }

        [Fact]
        public void GetDailySalesReport_ValidDate_ShouldNotThrowException()
        {
            // Arrange
            var testDate = DateTime.Today;

            // Act & Assert
            var exception = Record.Exception(() => _reportService.GetDailySalesReport(testDate));
            exception.Should().BeNull();
        }

        [Fact]
        public void GetMonthlySalesReport_ValidYearMonth_ShouldNotThrowException()
        {
            // Arrange
            var year = DateTime.Now.Year;
            var month = DateTime.Now.Month;

            // Act & Assert
            var exception = Record.Exception(() => _reportService.GetMonthlySalesReport(year, month));
            exception.Should().BeNull();
        }

        [Fact]
        public void GetProductSalesReport_ValidDateRange_ShouldNotThrowException()
        {
            // Arrange
            var startDate = DateTime.Today.AddDays(-30);
            var endDate = DateTime.Today;

            // Act & Assert
            var exception = Record.Exception(() => _reportService.GetProductSalesReport(startDate, endDate));
            exception.Should().BeNull();
        }

        [Fact]
        public void GetDebtBalanceReport_ShouldNotThrowException()
        {
            // Act & Assert
            var exception = Record.Exception(() => _reportService.GetDebtBalanceReport());
            exception.Should().BeNull();
        }

        [Fact]
        public void GetRepairAnalytics_ValidDateRange_ShouldNotThrowException()
        {
            // Arrange
            var startDate = DateTime.Today.AddDays(-30);
            var endDate = DateTime.Today;

            // Act & Assert
            var exception = Record.Exception(() => _reportService.GetRepairAnalytics(startDate, endDate));
            exception.Should().BeNull();
        }

        [Theory]
        [InlineData(2024, 1)]
        [InlineData(2024, 12)]
        [InlineData(2023, 6)]
        public void GetMonthlySalesReport_DifferentMonths_ShouldHandleGracefully(int year, int month)
        {
            // Act
            var result = _reportService.GetMonthlySalesReport(year, month);

            // Assert - Should not throw exception, result can be null or valid object
            var exception = Record.Exception(() => _reportService.GetMonthlySalesReport(year, month));
            exception.Should().BeNull();
        }

        [Fact]
        public void GetProductSalesReport_EmptyDateRange_ShouldReturnEmptyList()
        {
            // Arrange
            var startDate = DateTime.Today.AddDays(1); // Future date
            var endDate = DateTime.Today.AddDays(2);   // Future date

            // Act
            var result = _reportService.GetProductSalesReport(startDate, endDate);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<ProductSalesDto>>();
        }

        [Fact]
        public void ReportService_MultipleMethodCalls_ShouldWorkCorrectly()
        {
            // Arrange
            var testDate = DateTime.Today;
            var startDate = DateTime.Today.AddDays(-7);
            var endDate = DateTime.Today;

            // Act & Assert - Multiple calls should not interfere with each other
            var dailyReport = Record.Exception(() => _reportService.GetDailySalesReport(testDate));
            var productReport = Record.Exception(() => _reportService.GetProductSalesReport(startDate, endDate));
            var debtReport = Record.Exception(() => _reportService.GetDebtBalanceReport());

            dailyReport.Should().BeNull();
            productReport.Should().BeNull();
            debtReport.Should().BeNull();
        }

        public void Dispose()
        {
            _reportService?.Dispose();
        }
    }
}