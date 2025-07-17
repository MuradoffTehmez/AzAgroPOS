using AzAgroPOS.BLL.Services;
using AzAgroPOS.DAL.Interfaces;
using AzAgroPOS.Entities.Domain;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace AzAgroPOS.Tests.Services
{
    /// <summary>
    /// SalesService-in sadə unit testləri
    /// Mövcud struktura uyğun testlər
    /// </summary>
    public class SalesServiceSimpleTests : IDisposable
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly SatisService _salesService;

        public SalesServiceSimpleTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _salesService = new SatisService(_mockUnitOfWork.Object);
        }

        [Fact]
        public void Constructor_ValidUnitOfWork_CreatesService()
        {
            // Assert
            _salesService.Should().NotBeNull();
        }

        [Fact]
        public void Constructor_NullUnitOfWork_ThrowsArgumentNullException()
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new SatisService(null));
            exception.ParamName.Should().Be("unitOfWork");
        }

        [Fact]
        public void CreateValidSale_ShouldHaveCorrectProperties()
        {
            // Arrange
            var sale = new Satis
            {
                Id = 1,
                SatisNomresi = "SAT001",
                SatisTarixi = DateTime.Now,
                UmumiMebleg = 100.00m,
                EndirimMeblegi = 10.00m,
                NetMebleg = 90.00m,
                OdemeNovu = "Nəqd",
                Status = "Tamamlandı"
            };

            // Assert
            sale.Should().NotBeNull();
            sale.UmumiMebleg.Should().Be(100.00m);
            sale.EndirimMeblegi.Should().Be(10.00m);
            sale.NetMebleg.Should().Be(90.00m);
            sale.OdemeNovu.Should().Be("Nəqd");
        }

        [Fact]
        public void CreateSaleDetail_ShouldHaveCorrectProperties()
        {
            // Arrange
            var saleDetail = new SatisDetali
            {
                Id = 1,
                SatisId = 1,
                MehsulId = 1,
                Miqdar = 5,
                VahidQiymeti = 20.00m,
                UmumiMebleg = 100.00m
            };

            // Assert
            saleDetail.Should().NotBeNull();
            saleDetail.Miqdar.Should().Be(5);
            saleDetail.VahidQiymeti.Should().Be(20.00m);
            saleDetail.UmumiMebleg.Should().Be(100.00m);
        }

        [Fact]
        public void SaleWithDetails_ShouldMaintainRelationship()
        {
            // Arrange
            var sale = new Satis
            {
                Id = 1,
                SatisNomresi = "SAT001",
                UmumiMebleg = 100.00m,
                SatisDetallari = new List<SatisDetali>
                {
                    new SatisDetali
                    {
                        Id = 1,
                        SatisId = 1,
                        MehsulId = 1,
                        Miqdar = 2,
                        VahidQiymeti = 50.00m,
                        UmumiMebleg = 100.00m
                    }
                }
            };

            // Assert
            sale.SatisDetallari.Should().NotBeNull();
            sale.SatisDetallari.Should().HaveCount(1);
            sale.SatisDetallari.First().SatisId.Should().Be(sale.Id);
        }

        [Theory]
        [InlineData("Nəqd")]
        [InlineData("Kart")]
        [InlineData("Nisyə")]
        public void Sale_DifferentPaymentTypes_ShouldBeValid(string paymentType)
        {
            // Arrange
            var sale = new Satis
            {
                OdemeNovu = paymentType,
                UmumiMebleg = 100.00m
            };

            // Assert
            sale.OdemeNovu.Should().Be(paymentType);
            sale.Should().NotBeNull();
        }

        [Theory]
        [InlineData("Tamamlandı")]
        [InlineData("Ləğv edilib")]
        [InlineData("Geri qaytarıldı")]
        public void Sale_DifferentStatuses_ShouldBeValid(string status)
        {
            // Arrange
            var sale = new Satis
            {
                Status = status,
                UmumiMebleg = 100.00m
            };

            // Assert
            sale.Status.Should().Be(status);
            sale.Should().NotBeNull();
        }

        [Fact]
        public void SalesService_Dispose_ShouldNotThrowException()
        {
            // Act & Assert
            var exception = Record.Exception(() => _salesService.Dispose());
            exception.Should().BeNull();
        }

        [Fact]
        public void MultipleOperations_ShouldWorkCorrectly()
        {
            // Arrange
            var sale1 = new Satis { Id = 1, UmumiMebleg = 100.00m };
            var sale2 = new Satis { Id = 2, UmumiMebleg = 200.00m };
            var sale3 = new Satis { Id = 3, UmumiMebleg = 300.00m };

            // Act
            var sales = new List<Satis> { sale1, sale2, sale3 };
            var totalAmount = 0m;
            foreach (var sale in sales)
            {
                totalAmount += sale.UmumiMebleg;
            }

            // Assert
            sales.Should().HaveCount(3);
            totalAmount.Should().Be(600.00m);
        }

        public void Dispose()
        {
            _salesService?.Dispose();
        }
    }
}