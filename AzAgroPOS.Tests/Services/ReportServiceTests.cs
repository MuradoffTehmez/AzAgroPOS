using AzAgroPOS.BLL.Services;
using AzAgroPOS.BLL.Interfaces;
using AzAgroPOS.DAL.Interfaces;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.Entities.DTOs;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AzAgroPOS.Tests.Services
{
    /// <summary>
    /// ReportService-in unit testləri
    /// Hesabat yaratma əməliyyatlarının düzgün işlədiyini test edir
    /// </summary>
    public class ReportServiceTests : IDisposable
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IAuditLogService> _mockAuditLogService;
        private readonly Mock<SatisRepository> _mockSatisRepository;
        private readonly Mock<MusteriRepository> _mockMusteriRepository;
        private readonly Mock<MehsulRepository> _mockMehsulRepository;
        private readonly Mock<TamirIsiRepository> _mockTamirRepository;
        private readonly ReportService _reportService;

        public ReportServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockAuditLogService = new Mock<IAuditLogService>();
            _mockSatisRepository = new Mock<SatisRepository>();
            _mockMusteriRepository = new Mock<MusteriRepository>();
            _mockMehsulRepository = new Mock<MehsulRepository>();
            _mockTamirRepository = new Mock<TamirIsiRepository>();

            _mockUnitOfWork.Setup(u => u.Satislar).Returns(_mockSatisRepository.Object);
            _mockUnitOfWork.Setup(u => u.Musteriler).Returns(_mockMusteriRepository.Object);
            _mockUnitOfWork.Setup(u => u.Mehsullar).Returns(_mockMehsulRepository.Object);
            _mockUnitOfWork.Setup(u => u.TamirIsleri).Returns(_mockTamirRepository.Object);

            _reportService = new ReportService(_mockUnitOfWork.Object, _mockAuditLogService.Object);
        }

        #region Sales Report Tests

        [Fact]
        public async Task GenerateSalesReport_ValidDateRange_ReturnsCorrectReport()
        {
            // Arrange
            var startDate = new DateTime(2024, 1, 1);
            var endDate = new DateTime(2024, 1, 31);

            var salesData = new List<Satis>
            {
                new Satis
                {
                    Id = 1,
                    SatisTarixi = new DateTime(2024, 1, 15),
                    UmumiMebleg = 100.00m,
                    EndirilenMebleg = 10.00m,
                    YekununMeblegi = 90.00m,
                    MusteriId = 1,
                    Musteri = new Musteri { Ad = "Əli", Soyad = "Vəliyev" },
                    SatisDetallari = new List<SatisDetali>
                    {
                        new SatisDetali
                        {
                            MehsulId = 1,
                            Mehsul = new Mehsul { Ad = "Buğda Toxumu" },
                            Miqdar = 10,
                            VahidQiymet = 10.00m,
                            UmumiQiymet = 100.00m
                        }
                    }
                },
                new Satis
                {
                    Id = 2,
                    SatisTarixi = new DateTime(2024, 1, 20),
                    UmumiMebleg = 200.00m,
                    EndirilenMebleg = 0.00m,
                    YekununMeblegi = 200.00m,
                    MusteriId = 2,
                    Musteri = new Musteri { Ad = "Fatma", Soyad = "İbrahimova" },
                    SatisDetallari = new List<SatisDetali>
                    {
                        new SatisDetali
                        {
                            MehsulId = 2,
                            Mehsul = new Mehsul { Ad = "Gübrə" },
                            Miqdar = 5,
                            VahidQiymet = 40.00m,
                            UmumiQiymet = 200.00m
                        }
                    }
                }
            };

            _mockSatisRepository.Setup(r => r.GetSalesByDateRange(startDate, endDate))
                .Returns(salesData.AsQueryable());

            // Act
            var result = await _reportService.GenerateSalesReportAsync(startDate, endDate);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Data.Should().NotBeNull();

            var reportData = result.Data as SalesReportDto;
            reportData.Should().NotBeNull();
            reportData.StartDate.Should().Be(startDate);
            reportData.EndDate.Should().Be(endDate);
            reportData.TotalSales.Should().Be(290.00m); // 90 + 200
            reportData.TotalDiscount.Should().Be(10.00m);
            reportData.TotalOrders.Should().Be(2);

            _mockAuditLogService.Verify(a => a.LogAsync(
                It.Is<string>(s => s.Contains("Satış hesabatı")),
                It.IsAny<string>(),
                It.IsAny<int>(),
                It.IsAny<string>()
            ), Times.Once);
        }

        [Fact]
        public async Task GenerateSalesReport_NoSalesInRange_ReturnsEmptyReport()
        {
            // Arrange
            var startDate = new DateTime(2024, 2, 1);
            var endDate = new DateTime(2024, 2, 28);

            _mockSatisRepository.Setup(r => r.GetSalesByDateRange(startDate, endDate))
                .Returns(new List<Satis>().AsQueryable());

            // Act
            var result = await _reportService.GenerateSalesReportAsync(startDate, endDate);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Data.Should().NotBeNull();

            var reportData = result.Data as SalesReportDto;
            reportData.TotalSales.Should().Be(0);
            reportData.TotalOrders.Should().Be(0);
            reportData.TotalDiscount.Should().Be(0);
        }

        [Fact]
        public async Task GenerateSalesReport_InvalidDateRange_ReturnsError()
        {
            // Arrange
            var startDate = new DateTime(2024, 2, 1);
            var endDate = new DateTime(2024, 1, 1); // End before start

            // Act
            var result = await _reportService.GenerateSalesReportAsync(startDate, endDate);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.Message.Should().Contain("Tarix aralığı yanlışdır");
        }

        [Fact]
        public async Task GenerateSalesReport_ExceptionThrown_ReturnsError()
        {
            // Arrange
            var startDate = new DateTime(2024, 1, 1);
            var endDate = new DateTime(2024, 1, 31);

            _mockSatisRepository.Setup(r => r.GetSalesByDateRange(startDate, endDate))
                .Throws(new Exception("Database connection failed"));

            // Act
            var result = await _reportService.GenerateSalesReportAsync(startDate, endDate);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.Message.Should().Contain("Database connection failed");
        }

        #endregion

        #region Customer Analytics Tests

        [Fact]
        public async Task GenerateCustomerAnalytics_ValidRequest_ReturnsAnalytics()
        {
            // Arrange
            var customers = new List<Musteri>
            {
                new Musteri
                {
                    Id = 1,
                    Ad = "Əli",
                    Soyad = "Vəliyev",
                    YaradilisTarixi = DateTime.Now.AddDays(-100),
                    SonAlisTarixi = DateTime.Now.AddDays(-5),
                    CariBorc = 50.00m,
                    UmumiAlis = 1000.00m
                },
                new Musteri
                {
                    Id = 2,
                    Ad = "Fatma",
                    Soyad = "İbrahimova",
                    YaradilisTarixi = DateTime.Now.AddDays(-200),
                    SonAlisTarixi = DateTime.Now.AddDays(-30),
                    CariBorc = 0.00m,
                    UmumiAlis = 2000.00m
                }
            };

            _mockMusteriRepository.Setup(r => r.GetAll())
                .Returns(customers.AsQueryable());

            // Act
            var result = await _reportService.GenerateCustomerAnalyticsAsync();

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Data.Should().NotBeNull();

            var analytics = result.Data as CustomerAnalyticsDto;
            analytics.Should().NotBeNull();
            analytics.TotalCustomers.Should().Be(2);
            analytics.TotalDebt.Should().Be(50.00m);
            analytics.TotalPurchases.Should().Be(3000.00m);
            analytics.ActiveCustomers.Should().Be(1); // Last purchase within 30 days
        }

        [Fact]
        public async Task GenerateCustomerAnalytics_EmptyDatabase_ReturnsZeroAnalytics()
        {
            // Arrange
            _mockMusteriRepository.Setup(r => r.GetAll())
                .Returns(new List<Musteri>().AsQueryable());

            // Act
            var result = await _reportService.GenerateCustomerAnalyticsAsync();

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();

            var analytics = result.Data as CustomerAnalyticsDto;
            analytics.TotalCustomers.Should().Be(0);
            analytics.TotalDebt.Should().Be(0);
            analytics.ActiveCustomers.Should().Be(0);
        }

        #endregion

        #region Repair Analytics Tests

        [Fact]
        public async Task GenerateRepairAnalytics_ValidRequest_ReturnsAnalytics()
        {
            // Arrange
            var startDate = new DateTime(2024, 1, 1);
            var endDate = new DateTime(2024, 1, 31);

            var repairJobs = new List<TamirIsi>
            {
                new TamirIsi
                {
                    Id = 1,
                    Tavsif = "Motor təmiri",
                    BaslangicTarixi = new DateTime(2024, 1, 10),
                    BitirmeTarixi = new DateTime(2024, 1, 15),
                    Status = TamirStatus.Tamamlandi,
                    TamirQiymeti = 100.00m,
                    MusteriId = 1,
                    Musteri = new Musteri { Ad = "Əli", Soyad = "Vəliyev" }
                },
                new TamirIsi
                {
                    Id = 2,
                    Tavsif = "Fren təmiri",
                    BaslangicTarixi = new DateTime(2024, 1, 20),
                    BitirmeTarixi = null,
                    Status = TamirStatus.DevamEdir,
                    TamirQiymeti = 75.00m,
                    MusteriId = 2,
                    Musteri = new Musteri { Ad = "Fatma", Soyad = "İbrahimova" }
                }
            };

            _mockTamirRepository.Setup(r => r.GetRepairsByDateRange(startDate, endDate))
                .Returns(repairJobs.AsQueryable());

            // Act
            var result = await _reportService.GenerateRepairAnalyticsAsync(startDate, endDate);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Data.Should().NotBeNull();

            var analytics = result.Data as RepairAnalyticsDto;
            analytics.Should().NotBeNull();
            analytics.TotalRepairs.Should().Be(2);
            analytics.CompletedRepairs.Should().Be(1);
            analytics.PendingRepairs.Should().Be(1);
            analytics.TotalRevenue.Should().Be(175.00m);
            analytics.AverageCompletionDays.Should().Be(5); // (5 + 0) / 1 completed
        }

        [Fact]
        public async Task GenerateRepairAnalytics_NoRepairs_ReturnsZeroAnalytics()
        {
            // Arrange
            var startDate = new DateTime(2024, 1, 1);
            var endDate = new DateTime(2024, 1, 31);

            _mockTamirRepository.Setup(r => r.GetRepairsByDateRange(startDate, endDate))
                .Returns(new List<TamirIsi>().AsQueryable());

            // Act
            var result = await _reportService.GenerateRepairAnalyticsAsync(startDate, endDate);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();

            var analytics = result.Data as RepairAnalyticsDto;
            analytics.TotalRepairs.Should().Be(0);
            analytics.CompletedRepairs.Should().Be(0);
            analytics.TotalRevenue.Should().Be(0);
        }

        #endregion

        #region Debt Report Tests

        [Fact]
        public async Task GenerateDebtReport_ValidRequest_ReturnsReport()
        {
            // Arrange
            var customersWithDebt = new List<Musteri>
            {
                new Musteri
                {
                    Id = 1,
                    Ad = "Əli",
                    Soyad = "Vəliyev",
                    CariBorc = 150.00m,
                    SonAlisTarixi = DateTime.Now.AddDays(-10),
                    Telefon = "0501234567"
                },
                new Musteri
                {
                    Id = 2,
                    Ad = "Fatma",
                    Soyad = "İbrahimova",
                    CariBorc = 200.00m,
                    SonAlisTarixi = DateTime.Now.AddDays(-20),
                    Telefon = "0507654321"
                }
            };

            _mockMusteriRepository.Setup(r => r.GetCustomersWithDebt())
                .Returns(customersWithDebt.AsQueryable());

            // Act
            var result = await _reportService.GenerateDebtReportAsync();

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Data.Should().NotBeNull();

            var debtReport = result.Data as DebtReportDto;
            debtReport.Should().NotBeNull();
            debtReport.TotalDebtors.Should().Be(2);
            debtReport.TotalDebtAmount.Should().Be(350.00m);
            debtReport.CustomerDebts.Should().HaveCount(2);

            var firstDebtor = debtReport.CustomerDebts.First();
            firstDebtor.CustomerName.Should().Be("Əli Vəliyev");
            firstDebtor.DebtAmount.Should().Be(150.00m);
        }

        [Fact]
        public async Task GenerateDebtReport_NoDebts_ReturnsEmptyReport()
        {
            // Arrange
            _mockMusteriRepository.Setup(r => r.GetCustomersWithDebt())
                .Returns(new List<Musteri>().AsQueryable());

            // Act
            var result = await _reportService.GenerateDebtReportAsync();

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();

            var debtReport = result.Data as DebtReportDto;
            debtReport.TotalDebtors.Should().Be(0);
            debtReport.TotalDebtAmount.Should().Be(0);
            debtReport.CustomerDebts.Should().BeEmpty();
        }

        #endregion

        #region Export Functionality Tests

        [Fact]
        public async Task ExportReportToPdf_ValidReport_ReturnsSuccess()
        {
            // Arrange
            var salesReport = new SalesReportDto
            {
                StartDate = new DateTime(2024, 1, 1),
                EndDate = new DateTime(2024, 1, 31),
                TotalSales = 1000.00m,
                TotalOrders = 10,
                TotalDiscount = 50.00m
            };

            var fileName = "sales_report_202401.pdf";

            // Act
            var result = await _reportService.ExportReportToPdfAsync(salesReport, fileName);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Message.Should().Contain("PDF faylı uğurla yaradıldı");

            _mockAuditLogService.Verify(a => a.LogAsync(
                It.Is<string>(s => s.Contains("PDF ixrac")),
                It.IsAny<string>(),
                It.IsAny<int>(),
                It.IsAny<string>()
            ), Times.Once);
        }

        [Fact]
        public async Task ExportReportToExcel_ValidReport_ReturnsSuccess()
        {
            // Arrange
            var customerAnalytics = new CustomerAnalyticsDto
            {
                TotalCustomers = 100,
                ActiveCustomers = 80,
                TotalDebt = 5000.00m,
                TotalPurchases = 50000.00m
            };

            var fileName = "customer_analytics_202401.xlsx";

            // Act
            var result = await _reportService.ExportReportToExcelAsync(customerAnalytics, fileName);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Message.Should().Contain("Excel faylı uğurla yaradıldı");
        }

        [Fact]
        public async Task ExportReportToPdf_InvalidFileName_ReturnsError()
        {
            // Arrange
            var salesReport = new SalesReportDto();
            var invalidFileName = ""; // Empty filename

            // Act
            var result = await _reportService.ExportReportToPdfAsync(salesReport, invalidFileName);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.Message.Should().Contain("Fayl adı boş ola bilməz");
        }

        #endregion

        #region Employee Performance Tests

        [Fact]
        public async Task GenerateEmployeePerformanceReport_ValidRequest_ReturnsReport()
        {
            // Arrange
            var startDate = new DateTime(2024, 1, 1);
            var endDate = new DateTime(2024, 1, 31);

            var employeeSales = new List<dynamic>
            {
                new { EmployeeId = 1, EmployeeName = "Əli Vəliyev", TotalSales = 10000.00m, OrderCount = 25 },
                new { EmployeeId = 2, EmployeeName = "Fatma İbrahimova", TotalSales = 8000.00m, OrderCount = 20 }
            };

            _mockSatisRepository.Setup(r => r.GetEmployeeSalesPerformance(startDate, endDate))
                .Returns(employeeSales);

            // Act
            var result = await _reportService.GenerateEmployeePerformanceReportAsync(startDate, endDate);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.Data.Should().NotBeNull();

            var performanceReport = result.Data as EmployeePerformanceDto;
            performanceReport.Should().NotBeNull();
            performanceReport.ReportPeriod.Should().Be($"{startDate:dd.MM.yyyy} - {endDate:dd.MM.yyyy}");
            performanceReport.EmployeePerformances.Should().HaveCount(2);

            var topPerformer = performanceReport.EmployeePerformances.First();
            topPerformer.EmployeeName.Should().Be("Əli Vəliyev");
            topPerformer.TotalSales.Should().Be(10000.00m);
            topPerformer.OrderCount.Should().Be(25);
        }

        #endregion

        #region Integration and Edge Case Tests

        [Fact]
        public async Task GenerateComprehensiveReport_AllDataTypes_ReturnsCompleteReport()
        {
            // Arrange
            var startDate = new DateTime(2024, 1, 1);
            var endDate = new DateTime(2024, 1, 31);

            // Setup all mock data
            SetupMockDataForIntegrationTest(startDate, endDate);

            // Act
            var salesResult = await _reportService.GenerateSalesReportAsync(startDate, endDate);
            var customerResult = await _reportService.GenerateCustomerAnalyticsAsync();
            var repairResult = await _reportService.GenerateRepairAnalyticsAsync(startDate, endDate);
            var debtResult = await _reportService.GenerateDebtReportAsync();

            // Assert
            salesResult.Success.Should().BeTrue();
            customerResult.Success.Should().BeTrue();
            repairResult.Success.Should().BeTrue();
            debtResult.Success.Should().BeTrue();

            // Verify audit logging was called for all reports
            _mockAuditLogService.Verify(a => a.LogAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<int>(),
                It.IsAny<string>()
            ), Times.AtLeast(4));
        }

        private void SetupMockDataForIntegrationTest(DateTime startDate, DateTime endDate)
        {
            // Sales data
            var salesData = new List<Satis>
            {
                new Satis
                {
                    Id = 1,
                    SatisTarixi = startDate.AddDays(5),
                    YekununMeblegi = 100.00m,
                    MusteriId = 1
                }
            };
            _mockSatisRepository.Setup(r => r.GetSalesByDateRange(startDate, endDate))
                .Returns(salesData.AsQueryable());

            // Customer data
            var customers = new List<Musteri>
            {
                new Musteri { Id = 1, Ad = "Test", CariBorc = 50.00m }
            };
            _mockMusteriRepository.Setup(r => r.GetAll())
                .Returns(customers.AsQueryable());
            _mockMusteriRepository.Setup(r => r.GetCustomersWithDebt())
                .Returns(customers.Where(c => c.CariBorc > 0).AsQueryable());

            // Repair data
            var repairs = new List<TamirIsi>
            {
                new TamirIsi
                {
                    Id = 1,
                    BaslangicTarixi = startDate.AddDays(3),
                    Status = TamirStatus.Tamamlandi,
                    TamirQiymeti = 75.00m
                }
            };
            _mockTamirRepository.Setup(r => r.GetRepairsByDateRange(startDate, endDate))
                .Returns(repairs.AsQueryable());
        }

        #endregion

        public void Dispose()
        {
            // Cleanup resources if needed
        }
    }

    // Test helper enums and classes
    public enum TamirStatus
    {
        Gozleyir,
        DevamEdir,
        Tamamlandi,
        LegvEdildi
    }
}