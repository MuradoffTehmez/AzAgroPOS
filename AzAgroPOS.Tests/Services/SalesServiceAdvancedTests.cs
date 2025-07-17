using AzAgroPOS.BLL.Services;
using AzAgroPOS.BLL.Interfaces;
using AzAgroPOS.DAL.Interfaces;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.Entities.DTO;
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
    /// SalesService-in əlavə və təkmil unit testləri
    /// Kompleks senariolar və edge case-ləri test edir
    /// </summary>
    public class SalesServiceAdvancedTests : IDisposable
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IAuditLogService> _mockAuditLogService;
        private readonly Mock<SatisRepository> _mockSatisRepository;
        private readonly Mock<SatisDetaliRepository> _mockSatisDetaliRepository;
        private readonly Mock<MusteriRepository> _mockMusteriRepository;
        private readonly Mock<MehsulRepository> _mockMehsulRepository;
        private readonly Mock<AnbarQalikRepository> _mockAnbarQalikRepository;
        private readonly Mock<SatisOdemesiRepository> _mockSatisOdemesiRepository;
        private readonly SatisService _salesService;

        public SalesServiceAdvancedTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockAuditLogService = new Mock<IAuditLogService>();
            _mockSatisRepository = new Mock<SatisRepository>();
            _mockSatisDetaliRepository = new Mock<SatisDetaliRepository>();
            _mockMusteriRepository = new Mock<MusteriRepository>();
            _mockMehsulRepository = new Mock<MehsulRepository>();
            _mockAnbarQalikRepository = new Mock<AnbarQalikRepository>();
            _mockSatisOdemesiRepository = new Mock<SatisOdemesiRepository>();

            // UnitOfWork mock setup
            _mockUnitOfWork.Setup(u => u.Satislar).Returns(_mockSatisRepository.Object);
            _mockUnitOfWork.Setup(u => u.SatisDetallari).Returns(_mockSatisDetaliRepository.Object);
            _mockUnitOfWork.Setup(u => u.Musteriler).Returns(_mockMusteriRepository.Object);
            _mockUnitOfWork.Setup(u => u.Mehsullar).Returns(_mockMehsulRepository.Object);
            _mockUnitOfWork.Setup(u => u.AnbarQaliqlari).Returns(_mockAnbarQalikRepository.Object);
            _mockUnitOfWork.Setup(u => u.SatisOdemeləri).Returns(_mockSatisOdemesiRepository.Object);

            _salesService = new SatisService(_mockUnitOfWork.Object, _mockAuditLogService.Object);
        }

        #region Complex Sales Creation Tests

        [Fact]
        public async Task CreateComplexSale_MultipleProductsWithDiscounts_ProcessesCorrectly()
        {
            // Arrange
            var sale = new Satis
            {
                MusteriId = 1,
                SatisTarixi = DateTime.Now,
                UmumiMebleg = 500.00m,
                EndirilenMebleg = 50.00m,
                YekununMeblegi = 450.00m,
                SatisDetallari = new List<SatisDetali>
                {
                    new SatisDetali { MehsulId = 1, Miqdar = 10, VahidQiymeti = 20.00m, UmumiQiymet = 200.00m, EndirilenMebleg = 20.00m },
                    new SatisDetali { MehsulId = 2, Miqdar = 5, VahidQiymeti = 60.00m, UmumiQiymet = 300.00m, EndirilenMebleg = 30.00m }
                }
            };

            var customer = new Musteri { Id = 1, Ad = "Test", CariBorc = 0.00m };
            var product1 = new Mehsul { Id = 1, Ad = "Gübrə", SatisQiymeti = 20.00m };
            var product2 = new Mehsul { Id = 2, Ad = "Toxum", SatisQiymeti = 60.00m };
            var stock1 = new AnbarQalik { MehsulId = 1, MovcudMiqdar = 100 };
            var stock2 = new AnbarQalik { MehsulId = 2, MovcudMiqdar = 50 };

            SetupMockReturns(customer, new[] { product1, product2 }, new[] { stock1, stock2 });

            // Act
            var result = await _salesService.CreateSaleWithPaymentAsync(sale, 200.00m, "Nəqd");

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();
            result.SaleId.Should().BeGreaterThan(0);

            // Verify discount calculations
            _mockSatisRepository.Verify(r => r.AddAsync(It.Is<Satis>(s => 
                s.UmumiMebleg == 500.00m && 
                s.EndirilenMebleg == 50.00m && 
                s.YekununMeblegi == 450.00m)), Times.Once);

            // Verify stock updates
            _mockAnbarQalikRepository.Verify(r => r.Update(It.Is<AnbarQalik>(q => 
                q.MehsulId == 1 && q.MovcudMiqdar == 90)), Times.Once);
            _mockAnbarQalikRepository.Verify(r => r.Update(It.Is<AnbarQalik>(q => 
                q.MehsulId == 2 && q.MovcudMiqdar == 45)), Times.Once);

            // Verify audit logging
            _mockAuditLogService.Verify(a => a.LogAsync(
                It.Is<string>(s => s.Contains("Kompleks satış")),
                It.IsAny<string>(),
                It.IsAny<int>(),
                It.IsAny<string>()
            ), Times.Once);
        }

        [Fact]
        public async Task CreateSaleOnCredit_UpdatesCustomerDebt_ReturnsSuccess()
        {
            // Arrange
            var creditSale = new Satis
            {
                MusteriId = 1,
                YekununMeblegi = 1000.00m,
                OdemeNovu = "Borc",
                SatisDetallari = new List<SatisDetali>
                {
                    new SatisDetali { MehsulId = 1, Miqdar = 10, VahidQiymeti = 100.00m, UmumiQiymet = 1000.00m }
                }
            };

            var customer = new Musteri { Id = 1, Ad = "Test Müştəri", CariBorc = 500.00m };
            var product = new Mehsul { Id = 1, Ad = "Traktor", SatisQiymeti = 100.00m };
            var stock = new AnbarQalik { MehsulId = 1, MovcudMiqdar = 20 };

            SetupMockReturns(customer, new[] { product }, new[] { stock });

            // Act
            var result = await _salesService.CreateCreditSaleAsync(creditSale);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();

            // Verify customer debt is updated
            _mockMusteriRepository.Verify(r => r.Update(It.Is<Musteri>(m => 
                m.Id == 1 && m.CariBorc == 1500.00m)), Times.Once);

            // Verify audit logging for credit sale
            _mockAuditLogService.Verify(a => a.LogAsync(
                It.Is<string>(s => s.Contains("Kredit satış")),
                It.IsAny<string>(),
                1,
                It.IsAny<string>()
            ), Times.Once);
        }

        #endregion

        #region Payment Processing Tests

        [Fact]
        public async Task ProcessPartialPayment_ValidAmount_UpdatesSaleAndCustomerDebt()
        {
            // Arrange
            var saleId = 1;
            var paymentAmount = 300.00m;
            var existingSale = new Satis
            {
                Id = saleId,
                MusteriId = 1,
                YekununMeblegi = 1000.00m,
                OdenenMebleg = 200.00m,
                QalanMebleg = 800.00m
            };

            var customer = new Musteri { Id = 1, CariBorc = 1500.00m };

            _mockSatisRepository.Setup(r => r.GetByIdAsync(saleId))
                .ReturnsAsync(existingSale);
            _mockMusteriRepository.Setup(r => r.GetById(1))
                .Returns(customer);
            _mockUnitOfWork.Setup(u => u.CompleteAsync()).ReturnsAsync(1);

            // Act
            var result = await _salesService.ProcessPartialPaymentAsync(saleId, paymentAmount, "Bank Kartı");

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();

            // Verify sale amounts are updated
            existingSale.OdenenMebleg.Should().Be(500.00m); // 200 + 300
            existingSale.QalanMebleg.Should().Be(500.00m); // 1000 - 500

            // Verify customer debt is reduced
            customer.CariBorc.Should().Be(1200.00m); // 1500 - 300

            // Verify payment record is created
            _mockSatisOdemesiRepository.Verify(r => r.AddAsync(It.Is<SatisOdemesi>(p =>
                p.SatisId == saleId &&
                p.OdenenMebleg == paymentAmount &&
                p.OdemeNovu == "Bank Kartı"
            )), Times.Once);
        }

        [Fact]
        public async Task ProcessFullPayment_CompletesPayment_UpdatesStatusToPaid()
        {
            // Arrange
            var saleId = 1;
            var finalPayment = 500.00m;
            var existingSale = new Satis
            {
                Id = saleId,
                MusteriId = 1,
                YekununMeblegi = 1000.00m,
                OdenenMebleg = 500.00m,
                QalanMebleg = 500.00m,
                OdemeStatusu = OdemeStatusu.QismOdenib
            };

            var customer = new Musteri { Id = 1, CariBorc = 500.00m };

            _mockSatisRepository.Setup(r => r.GetByIdAsync(saleId))
                .ReturnsAsync(existingSale);
            _mockMusteriRepository.Setup(r => r.GetById(1))
                .Returns(customer);
            _mockUnitOfWork.Setup(u => u.CompleteAsync()).ReturnsAsync(1);

            // Act
            var result = await _salesService.ProcessFullPaymentAsync(saleId, finalPayment, "Nəqd");

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();

            // Verify sale is fully paid
            existingSale.OdenenMebleg.Should().Be(1000.00m);
            existingSale.QalanMebleg.Should().Be(0.00m);
            existingSale.OdemeStatusu.Should().Be(OdemeStatusu.TamOdenib);

            // Verify customer debt is cleared for this sale
            customer.CariBorc.Should().Be(0.00m);
        }

        [Fact]
        public async Task ProcessPayment_ExcessiveAmount_ReturnsError()
        {
            // Arrange
            var saleId = 1;
            var excessivePayment = 1500.00m;
            var existingSale = new Satis
            {
                Id = saleId,
                MusteriId = 1,
                YekununMeblegi = 1000.00m,
                OdenenMebleg = 800.00m,
                QalanMebleg = 200.00m
            };

            _mockSatisRepository.Setup(r => r.GetByIdAsync(saleId))
                .ReturnsAsync(existingSale);

            // Act
            var result = await _salesService.ProcessPartialPaymentAsync(saleId, excessivePayment, "Nəqd");

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.Message.Should().Contain("Ödəmə məbləği qalan borcdan çox ola bilməz");

            // Verify no changes were made
            _mockSatisOdemesiRepository.Verify(r => r.AddAsync(It.IsAny<SatisOdemesi>()), Times.Never);
            _mockUnitOfWork.Verify(u => u.CompleteAsync(), Times.Never);
        }

        #endregion

        #region Sales Query and Reporting Tests

        [Fact]
        public async Task GetSalesByDateRange_ValidRange_ReturnsFilteredSales()
        {
            // Arrange
            var startDate = new DateTime(2024, 1, 1);
            var endDate = new DateTime(2024, 1, 31);

            var salesData = new List<Satis>
            {
                new Satis { Id = 1, SatisTarixi = new DateTime(2024, 1, 15), YekununMeblegi = 100.00m },
                new Satis { Id = 2, SatisTarixi = new DateTime(2024, 1, 25), YekununMeblegi = 200.00m },
                new Satis { Id = 3, SatisTarixi = new DateTime(2024, 2, 5), YekununMeblegi = 150.00m } // Outside range
            };

            _mockSatisRepository.Setup(r => r.GetSalesByDateRange(startDate, endDate))
                .Returns(salesData.Where(s => s.SatisTarixi >= startDate && s.SatisTarixi <= endDate).AsQueryable());

            // Act
            var result = await _salesService.GetSalesByDateRangeAsync(startDate, endDate);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result.Sum(s => s.YekununMeblegi).Should().Be(300.00m);
            result.All(s => s.SatisTarixi >= startDate && s.SatisTarixi <= endDate).Should().BeTrue();
        }

        [Fact]
        public async Task GetTopSellingProducts_ValidPeriod_ReturnsRankedProducts()
        {
            // Arrange
            var startDate = new DateTime(2024, 1, 1);
            var endDate = new DateTime(2024, 1, 31);

            var topProducts = new List<TopSellingProductDto>
            {
                new TopSellingProductDto { ProductId = 1, ProductName = "Gübrə", TotalQuantity = 100, TotalRevenue = 5000.00m },
                new TopSellingProductDto { ProductId = 2, ProductName = "Toxum", TotalQuantity = 75, TotalRevenue = 3750.00m },
                new TopSellingProductDto { ProductId = 3, ProductName = "Dərman", TotalQuantity = 50, TotalRevenue = 2500.00m }
            };

            _mockSatisRepository.Setup(r => r.GetTopSellingProducts(startDate, endDate, 5))
                .Returns(topProducts);

            // Act
            var result = await _salesService.GetTopSellingProductsAsync(startDate, endDate, 5);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(3);
            result.First().ProductName.Should().Be("Gübrə");
            result.First().TotalQuantity.Should().Be(100);
            result.Should().BeInDescendingOrder(p => p.TotalQuantity);
        }

        [Fact]
        public async Task GetCustomerSalesHistory_ValidCustomer_ReturnsHistory()
        {
            // Arrange
            var customerId = 1;
            var customerSales = new List<Satis>
            {
                new Satis
                {
                    Id = 1,
                    MusteriId = customerId,
                    SatisTarixi = DateTime.Now.AddDays(-10),
                    YekununMeblegi = 500.00m,
                    OdemeStatusu = OdemeStatusu.TamOdenib
                },
                new Satis
                {
                    Id = 2,
                    MusteriId = customerId,
                    SatisTarixi = DateTime.Now.AddDays(-5),
                    YekununMeblegi = 300.00m,
                    OdemeStatusu = OdemeStatusu.QismOdenib
                }
            };

            _mockSatisRepository.Setup(r => r.GetSalesByCustomer(customerId))
                .Returns(customerSales.AsQueryable());

            // Act
            var result = await _salesService.GetCustomerSalesHistoryAsync(customerId);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result.Sum(s => s.YekununMeblegi).Should().Be(800.00m);
            result.All(s => s.MusteriId == customerId).Should().BeTrue();
        }

        #endregion

        #region Sales Cancellation and Returns Tests

        [Fact]
        public async Task CancelSale_ValidSale_CancelsAndRestoresStock()
        {
            // Arrange
            var saleId = 1;
            var cancelReason = "Müştəri təkzibi";
            var existingSale = new Satis
            {
                Id = saleId,
                MusteriId = 1,
                YekununMeblegi = 1000.00m,
                SatisStatusu = SatisStatusu.Tamamlandi,
                SatisDetallari = new List<SatisDetali>
                {
                    new SatisDetali { MehsulId = 1, Miqdar = 10 },
                    new SatisDetali { MehsulId = 2, Miqdar = 5 }
                }
            };

            var stockItems = new List<AnbarQalik>
            {
                new AnbarQalik { MehsulId = 1, MovcudMiqdar = 90 },
                new AnbarQalik { MehsulId = 2, MovcudMiqdar = 45 }
            };

            _mockSatisRepository.Setup(r => r.GetByIdWithDetailsAsync(saleId))
                .ReturnsAsync(existingSale);
            _mockAnbarQalikRepository.Setup(r => r.GetByMehsul(1))
                .Returns(stockItems[0]);
            _mockAnbarQalikRepository.Setup(r => r.GetByMehsul(2))
                .Returns(stockItems[1]);
            _mockUnitOfWork.Setup(u => u.CompleteAsync()).ReturnsAsync(1);

            // Act
            var result = await _salesService.CancelSaleAsync(saleId, cancelReason, 1);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeTrue();

            // Verify sale status is updated
            existingSale.SatisStatusu.Should().Be(SatisStatusu.LegvEdildi);
            existingSale.LegvSebebi.Should().Be(cancelReason);

            // Verify stock is restored
            stockItems[0].MovcudMiqdar.Should().Be(100); // 90 + 10
            stockItems[1].MovcudMiqdar.Should().Be(50);  // 45 + 5

            // Verify audit logging
            _mockAuditLogService.Verify(a => a.LogAsync(
                It.Is<string>(s => s.Contains("Satış ləğv edildi")),
                It.IsAny<string>(),
                1,
                It.IsAny<string>()
            ), Times.Once);
        }

        [Fact]
        public async Task CancelSale_AlreadyCancelled_ReturnsError()
        {
            // Arrange
            var saleId = 1;
            var existingSale = new Satis
            {
                Id = saleId,
                SatisStatusu = SatisStatusu.LegvEdildi
            };

            _mockSatisRepository.Setup(r => r.GetByIdWithDetailsAsync(saleId))
                .ReturnsAsync(existingSale);

            // Act
            var result = await _salesService.CancelSaleAsync(saleId, "Test reason", 1);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.Message.Should().Contain("Bu satış artıq ləğv edilib");

            // Verify no changes were made
            _mockUnitOfWork.Verify(u => u.CompleteAsync(), Times.Never);
        }

        #endregion

        #region Performance and Edge Case Tests

        [Fact]
        public async Task CreateBulkSales_MultipleValidSales_ProcessesAllSuccessfully()
        {
            // Arrange
            var bulkSales = new List<Satis>();
            for (int i = 1; i <= 10; i++)
            {
                bulkSales.Add(new Satis
                {
                    MusteriId = i,
                    YekununMeblegi = 100.00m * i,
                    SatisDetallari = new List<SatisDetali>
                    {
                        new SatisDetali { MehsulId = 1, Miqdar = i, VahidQiymeti = 100.00m, UmumiQiymet = 100.00m * i }
                    }
                });
            }

            // Setup mocks for bulk operations
            SetupBulkMockData();

            // Act
            var results = new List<CreateSaleResult>();
            foreach (var sale in bulkSales)
            {
                var result = await _salesService.CreateSaleAsync(sale);
                results.Add(result);
            }

            // Assert
            results.Should().HaveCount(10);
            results.All(r => r.Success).Should().BeTrue();
            
            // Verify all sales were processed
            _mockSatisRepository.Verify(r => r.AddAsync(It.IsAny<Satis>()), Times.Exactly(10));
            _mockUnitOfWork.Verify(u => u.CompleteAsync(), Times.Exactly(10));
        }

        [Fact]
        public async Task CreateSale_DatabaseConcurrencyConflict_HandlesGracefully()
        {
            // Arrange
            var sale = CreateTestSale();
            var customer = new Musteri { Id = 1, Ad = "Test" };
            var product = new Mehsul { Id = 1, Ad = "Test Product" };
            var stock = new AnbarQalik { MehsulId = 1, MovcudMiqdar = 100 };

            SetupMockReturns(customer, new[] { product }, new[] { stock });

            // Simulate concurrency conflict
            _mockUnitOfWork.Setup(u => u.CompleteAsync())
                .ThrowsAsync(new InvalidOperationException("Concurrency conflict detected"));

            // Act
            var result = await _salesService.CreateSaleAsync(sale);

            // Assert
            result.Should().NotBeNull();
            result.Success.Should().BeFalse();
            result.Message.Should().Contain("Concurrency conflict detected");

            // Verify rollback behavior
            _mockSatisRepository.Verify(r => r.AddAsync(It.IsAny<Satis>()), Times.Once);
        }

        #endregion

        #region Helper Methods

        private void SetupMockReturns(Musteri customer, Mehsul[] products, AnbarQalik[] stockItems)
        {
            _mockMusteriRepository.Setup(r => r.GetById(customer.Id)).Returns(customer);
            
            foreach (var product in products)
            {
                _mockMehsulRepository.Setup(r => r.GetById(product.Id)).Returns(product);
            }

            foreach (var stock in stockItems)
            {
                _mockAnbarQalikRepository.Setup(r => r.GetByAnbarVeMehsul(It.IsAny<int>(), stock.MehsulId))
                    .Returns(stock);
            }

            _mockSatisRepository.Setup(r => r.AddAsync(It.IsAny<Satis>()))
                .ReturnsAsync((Satis s) => new Random().Next(1, 1000));
            _mockUnitOfWork.Setup(u => u.CompleteAsync()).ReturnsAsync(1);
        }

        private void SetupBulkMockData()
        {
            // Setup for bulk operations
            for (int i = 1; i <= 10; i++)
            {
                _mockMusteriRepository.Setup(r => r.GetById(i))
                    .Returns(new Musteri { Id = i, Ad = $"Customer {i}" });
            }

            _mockMehsulRepository.Setup(r => r.GetById(1))
                .Returns(new Mehsul { Id = 1, Ad = "Bulk Product" });

            _mockAnbarQalikRepository.Setup(r => r.GetByAnbarVeMehsul(It.IsAny<int>(), 1))
                .Returns(new AnbarQalik { MehsulId = 1, MovcudMiqdar = 1000 });

            _mockSatisRepository.Setup(r => r.AddAsync(It.IsAny<Satis>()))
                .ReturnsAsync((Satis s) => new Random().Next(1, 1000));
            _mockUnitOfWork.Setup(u => u.CompleteAsync()).ReturnsAsync(1);
        }

        private Satis CreateTestSale()
        {
            return new Satis
            {
                MusteriId = 1,
                YekununMeblegi = 100.00m,
                SatisDetallari = new List<SatisDetali>
                {
                    new SatisDetali { MehsulId = 1, Miqdar = 1, VahidQiymeti = 100.00m, UmumiQiymet = 100.00m }
                }
            };
        }

        #endregion

        public void Dispose()
        {
            _salesService?.Dispose();
        }
    }

    // Helper DTOs and Enums for testing
    public class CreateSaleResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int SaleId { get; set; }
    }

    public class TopSellingProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalRevenue { get; set; }
    }

    public enum OdemeStatusu
    {
        Odenmeyib,
        QismOdenib,
        TamOdenib,
        GeriQayitdi
    }

    public enum SatisStatusu
    {
        Gozleyir,
        Tamamlandi,
        LegvEdildi,
        QismIade
    }
}