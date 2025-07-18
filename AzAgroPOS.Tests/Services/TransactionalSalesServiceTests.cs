using AzAgroPOS.BLL.Services;
using AzAgroPOS.BLL.Interfaces;
using AzAgroPOS.DAL.Interfaces;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.Entities.Constants;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AzAgroPOS.Tests.Services
{
    public class TransactionalSalesServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<ILoggerService> _mockLogger;
        private readonly Mock<IAuditLogService> _mockAuditLogService;
        private readonly Mock<ISatisRepository> _mockSatisRepository;
        private readonly Mock<ISatisDetaliRepository> _mockSatisDetaliRepository;
        private readonly Mock<IMehsulRepository> _mockMehsulRepository;
        private readonly Mock<IAnbarQaliqRepository> _mockAnbarQaliqRepository;
        private readonly Mock<IMusteriRepository> _mockMusteriRepository;
        private readonly TransactionalSalesService _salesService;

        public TransactionalSalesServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILoggerService>();
            _mockAuditLogService = new Mock<IAuditLogService>();
            _mockSatisRepository = new Mock<ISatisRepository>();
            _mockSatisDetaliRepository = new Mock<ISatisDetaliRepository>();
            _mockMehsulRepository = new Mock<IMehsulRepository>();
            _mockAnbarQaliqRepository = new Mock<IAnbarQaliqRepository>();
            _mockMusteriRepository = new Mock<IMusteriRepository>();

            _mockUnitOfWork.Setup(x => x.Satislar).Returns(_mockSatisRepository.Object);
            _mockUnitOfWork.Setup(x => x.SatisDetallari).Returns(_mockSatisDetaliRepository.Object);
            _mockUnitOfWork.Setup(x => x.Mehsullar).Returns(_mockMehsulRepository.Object);
            _mockUnitOfWork.Setup(x => x.AnbarQaliqlari).Returns(_mockAnbarQaliqRepository.Object);
            _mockUnitOfWork.Setup(x => x.Musteriler).Returns(_mockMusteriRepository.Object);

            _salesService = new TransactionalSalesService(_mockUnitOfWork.Object, _mockLogger.Object, _mockAuditLogService.Object);
        }

        [Fact]
        public async Task CreateComplexSaleAsync_WhenDbConcurrencyExceptionOccurs_ShouldReturnSpecificError()
        {
            // Arrange
            var satis = new Satis { MusteriId = 1, OdemeNovu = "Nağd" };
            var satisDetallari = new List<SatisDetali>
            {
                new SatisDetali { MehsulId = 1, Miqdar = 2, VahidQiymeti = 10m }
            };

            var musteri = new Musteri { Id = 1, Status = SystemConstants.Status.Active };
            var mehsul = new Mehsul { Id = 1, Ad = "Test Məhsul", MovcudMiqdar = 10 };
            var anbarQaliq = new AnbarQalik { AnbarId = 1, MehsulId = 1, MovcudMiqdar = 10 };

            _mockMusteriRepository.Setup(x => x.GetById(1)).Returns(musteri);
            _mockMehsulRepository.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(mehsul);
            _mockAnbarQaliqRepository.Setup(x => x.GetByAnbarVeMehsul(1, 1)).Returns(anbarQaliq);

            // Simulate DbUpdateConcurrencyException when CompleteAsync is called
            _mockUnitOfWork.Setup(x => x.CompleteAsync())
                .ThrowsAsync(new DbUpdateConcurrencyException("Concurrency conflict"));

            // Act
            var result = await _salesService.CreateComplexSaleAsync(satis, satisDetallari, 1);

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.ErrorMessage.Should().Be("Başqa istifadəçi eyni məhsulda dəyişiklik edib. Yenidən cəhd edin.");
            result.Exception.Should().BeOfType<DbUpdateConcurrencyException>();

            _mockAuditLogService.Verify(x => x.LogError("Race condition detected in sales transaction", It.IsAny<DbUpdateConcurrencyException>()), Times.Once);
        }

        [Fact]
        public async Task CreateComplexSaleAsync_WhenInsufficientStock_ShouldReturnError()
        {
            // Arrange
            var satis = new Satis { MusteriId = 1, OdemeNovu = "Nağd" };
            var satisDetallari = new List<SatisDetali>
            {
                new SatisDetali { MehsulId = 1, Miqdar = 15, VahidQiymeti = 10m } // Requesting more than available
            };

            var musteri = new Musteri { Id = 1, Status = SystemConstants.Status.Active };
            var mehsul = new Mehsul { Id = 1, Ad = "Test Məhsul", MovcudMiqdar = 10 };
            var anbarQaliq = new AnbarQalik { AnbarId = 1, MehsulId = 1, MovcudMiqdar = 10 }; // Only 10 available

            _mockMusteriRepository.Setup(x => x.GetById(1)).Returns(musteri);
            _mockMehsulRepository.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(mehsul);
            _mockAnbarQaliqRepository.Setup(x => x.GetByAnbarVeMehsul(1, 1)).Returns(anbarQaliq);

            // Act
            var result = await _salesService.CreateComplexSaleAsync(satis, satisDetallari, 1);

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.ErrorMessage.Should().Contain("Kifayət qədər stok yoxdur");
            result.ErrorMessage.Should().Contain("Test Məhsul");
            result.ErrorMessage.Should().Contain("Mövcud: 10");
            result.ErrorMessage.Should().Contain("Tələb: 15");
        }

        [Fact]
        public async Task CreateComplexSaleAsync_WhenInactiveCustomer_ShouldReturnError()
        {
            // Arrange
            var satis = new Satis { MusteriId = 1, OdemeNovu = "Nağd" };
            var satisDetallari = new List<SatisDetali>
            {
                new SatisDetali { MehsulId = 1, Miqdar = 2, VahidQiymeti = 10m }
            };

            var musteri = new Musteri { Id = 1, Status = "Deaktiv" }; // Inactive customer

            _mockMusteriRepository.Setup(x => x.GetById(1)).Returns(musteri);

            // Act
            var result = await _salesService.CreateComplexSaleAsync(satis, satisDetallari, 1);

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.ErrorMessage.Should().Contain("Müştəri aktiv deyil");
        }

        [Fact]
        public async Task CreateComplexSaleAsync_WhenProductNotFound_ShouldReturnError()
        {
            // Arrange
            var satis = new Satis { MusteriId = 1, OdemeNovu = "Nağd" };
            var satisDetallari = new List<SatisDetali>
            {
                new SatisDetali { MehsulId = 999, Miqdar = 2, VahidQiymeti = 10m } // Non-existent product
            };

            var musteri = new Musteri { Id = 1, Status = SystemConstants.Status.Active };

            _mockMusteriRepository.Setup(x => x.GetById(1)).Returns(musteri);
            _mockMehsulRepository.Setup(x => x.GetByIdAsync(999)).ReturnsAsync((Mehsul)null);

            // Act
            var result = await _salesService.CreateComplexSaleAsync(satis, satisDetallari, 1);

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.ErrorMessage.Should().Contain("Məhsul tapılmadı: ID 999");
        }

        [Fact]
        public async Task CreateComplexSaleAsync_WhenInvalidPrice_ShouldReturnError()
        {
            // Arrange
            var satis = new Satis { MusteriId = 1, OdemeNovu = "Nağd" };
            var satisDetallari = new List<SatisDetali>
            {
                new SatisDetali { MehsulId = 1, Miqdar = 2, VahidQiymeti = -5m } // Negative price
            };

            var musteri = new Musteri { Id = 1, Status = SystemConstants.Status.Active };
            var mehsul = new Mehsul { Id = 1, Ad = "Test Məhsul", MovcudMiqdar = 10 };

            _mockMusteriRepository.Setup(x => x.GetById(1)).Returns(musteri);
            _mockMehsulRepository.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(mehsul);

            // Act
            var result = await _salesService.CreateComplexSaleAsync(satis, satisDetallari, 1);

            // Assert
            result.IsSuccess.Should().BeFalse();
            result.ErrorMessage.Should().Contain("Satış qiyməti düzgün deyil");
        }

        [Fact]
        public async Task CreateComplexSaleAsync_WhenValidSale_ShouldSucceed()
        {
            // Arrange
            var satis = new Satis { MusteriId = 1, OdemeNovu = "Nağd" };
            var satisDetallari = new List<SatisDetali>
            {
                new SatisDetali { MehsulId = 1, Miqdar = 2, VahidQiymeti = 10m },
                new SatisDetali { MehsulId = 2, Miqdar = 1, VahidQiymeti = 15m }
            };

            var musteri = new Musteri { Id = 1, Status = SystemConstants.Status.Active };
            var mehsul1 = new Mehsul { Id = 1, Ad = "Məhsul 1", MovcudMiqdar = 10 };
            var mehsul2 = new Mehsul { Id = 2, Ad = "Məhsul 2", MovcudMiqdar = 5 };
            var anbarQaliq1 = new AnbarQalik { AnbarId = 1, MehsulId = 1, MovcudMiqdar = 10 };
            var anbarQaliq2 = new AnbarQalik { AnbarId = 1, MehsulId = 2, MovcudMiqdar = 5 };

            _mockMusteriRepository.Setup(x => x.GetById(1)).Returns(musteri);
            _mockMehsulRepository.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(mehsul1);
            _mockMehsulRepository.Setup(x => x.GetByIdAsync(2)).ReturnsAsync(mehsul2);
            _mockAnbarQaliqRepository.Setup(x => x.GetByAnbarVeMehsul(1, 1)).Returns(anbarQaliq1);
            _mockAnbarQaliqRepository.Setup(x => x.GetByAnbarVeMehsul(1, 2)).Returns(anbarQaliq2);

            // Act
            var result = await _salesService.CreateComplexSaleAsync(satis, satisDetallari, 1);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.TotalAmount.Should().Be(35m); // (2 * 10) + (1 * 15) = 35
            result.ProcessedProducts.Should().HaveCount(2);
            result.Message.Should().Be("Satış uğurla tamamlandı");

            // Verify stock reduction
            mehsul1.MovcudMiqdar.Should().Be(8); // 10 - 2 = 8
            mehsul2.MovcudMiqdar.Should().Be(4); // 5 - 1 = 4
            anbarQaliq1.MovcudMiqdar.Should().Be(8);
            anbarQaliq2.MovcudMiqdar.Should().Be(4);

            // Verify database operations
            _mockUnitOfWork.Verify(x => x.CompleteAsync(), Times.Once);
            _mockAuditLogService.Verify(x => x.LogAction(
                SystemConstants.EntityNames.Satis,
                SystemConstants.DatabaseOperations.Create,
                It.IsAny<int>(),
                It.Is<string>(s => s.Contains("Satış uğurla tamamlandı")),
                1
            ), Times.Once);
        }

        [Fact]
        public async Task CreateComplexSaleAsync_WhenNullSatis_ShouldThrowArgumentNullException()
        {
            // Arrange
            var satisDetallari = new List<SatisDetali>
            {
                new SatisDetali { MehsulId = 1, Miqdar = 2, VahidQiymeti = 10m }
            };

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() =>
                _salesService.CreateComplexSaleAsync(null, satisDetallari, 1));
        }

        [Fact]
        public async Task CreateComplexSaleAsync_WhenEmptyDetails_ShouldThrowArgumentException()
        {
            // Arrange
            var satis = new Satis { MusteriId = 1, OdemeNovu = "Nağd" };
            var satisDetallari = new List<SatisDetali>();

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() =>
                _salesService.CreateComplexSaleAsync(satis, satisDetallari, 1));
            
            exception.Message.Should().Contain("Satış detalları boş ola bilməz");
        }

        [Fact]
        public async Task CreateComplexSaleAsync_ShouldSetCorrectTimestampsAndStatus()
        {
            // Arrange
            var satis = new Satis { MusteriId = 1, OdemeNovu = "Nağd" };
            var satisDetallari = new List<SatisDetali>
            {
                new SatisDetali { MehsulId = 1, Miqdar = 2, VahidQiymeti = 10m }
            };

            var musteri = new Musteri { Id = 1, Status = SystemConstants.Status.Active };
            var mehsul = new Mehsul { Id = 1, Ad = "Test Məhsul", MovcudMiqdar = 10 };
            var anbarQaliq = new AnbarQalik { AnbarId = 1, MehsulId = 1, MovcudMiqdar = 10 };

            _mockMusteriRepository.Setup(x => x.GetById(1)).Returns(musteri);
            _mockMehsulRepository.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(mehsul);
            _mockAnbarQaliqRepository.Setup(x => x.GetByAnbarVeMehsul(1, 1)).Returns(anbarQaliq);

            var beforeTime = DateTime.Now.AddSeconds(-1);

            // Act
            var result = await _salesService.CreateComplexSaleAsync(satis, satisDetallari, 1);

            var afterTime = DateTime.Now.AddSeconds(1);

            // Assert
            result.IsSuccess.Should().BeTrue();
            satis.SatisTarixi.Should().BeAfter(beforeTime);
            satis.SatisTarixi.Should().BeBefore(afterTime);
            satis.KassirId.Should().Be(1);
            satis.Status.Should().Be(SystemConstants.Status.Active);
            satis.UmumiMebleg.Should().Be(20m);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10)]
        public async Task CreateComplexSaleAsync_WhenInvalidQuantity_ShouldPassValidation(decimal invalidQuantity)
        {
            // Arrange
            var satis = new Satis { MusteriId = 1, OdemeNovu = "Nağd" };
            var satisDetallari = new List<SatisDetali>
            {
                new SatisDetali { MehsulId = 1, Miqdar = invalidQuantity, VahidQiymeti = 10m }
            };

            var musteri = new Musteri { Id = 1, Status = SystemConstants.Status.Active };
            var mehsul = new Mehsul { Id = 1, Ad = "Test Məhsul", MovcudMiqdar = 10 };
            var anbarQaliq = new AnbarQalik { AnbarId = 1, MehsulId = 1, MovcudMiqdar = 10 };

            _mockMusteriRepository.Setup(x => x.GetById(1)).Returns(musteri);
            _mockMehsulRepository.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(mehsul);
            _mockAnbarQaliqRepository.Setup(x => x.GetByAnbarVeMehsul(1, 1)).Returns(anbarQaliq);

            // Act
            var result = await _salesService.CreateComplexSaleAsync(satis, satisDetallari, 1);

            // Assert - Invalid quantities should fail stock validation
            result.IsSuccess.Should().BeFalse();
            result.ErrorMessage.Should().Contain("Kifayət qədər stok yoxdur");
        }
    }
}