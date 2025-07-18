using AzAgroPOS.BLL.Services;
using AzAgroPOS.DAL.Interfaces;
using AzAgroPOS.BLL.Interfaces;
using AzAgroPOS.Entities.Domain;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AzAgroPOS.Tests.Services
{
    public class BorcServiceAdvancedTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IAuditLogService> _mockAuditLogService;
        private readonly Mock<IMusteriBorcRepository> _mockBorcRepository;
        private readonly Mock<IBorcOdenisRepository> _mockOdenisRepository;
        private readonly BorcService _borcService;

        public BorcServiceAdvancedTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockAuditLogService = new Mock<IAuditLogService>();
            _mockBorcRepository = new Mock<IMusteriBorcRepository>();
            _mockOdenisRepository = new Mock<IBorcOdenisRepository>();

            _mockUnitOfWork.Setup(x => x.MusteriBorclari).Returns(_mockBorcRepository.Object);
            _mockUnitOfWork.Setup(x => x.BorcOdenisleri).Returns(_mockOdenisRepository.Object);

            _borcService = new BorcService(_mockUnitOfWork.Object, _mockAuditLogService.Object);
        }

        [Fact]
        public void AddPayment_WhenPaymentExceedsRemainingDebt_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var debt = new MusteriBorc 
            { 
                Id = 1, 
                QalanBorc = 100m, 
                UmumiMebleg = 200m 
            };
            
            var payment = new BorcOdenis 
            { 
                MusteriBorcId = 1, 
                OdenisMeblegi = 150m,
                QebulEdenIstifadeciId = 1
            };

            _mockBorcRepository.Setup(x => x.GetById(1)).Returns(debt);

            // Act & Assert
            var exception = Assert.Throws<ApplicationException>(() => _borcService.AddPayment(payment));
            exception.InnerException.Should().BeOfType<InvalidOperationException>();
            exception.Message.Should().Contain("Ödəniş məbləği qalan borcu aşa bilməz");
        }

        [Fact]
        public void AddPayment_WhenPaymentIsZero_ShouldThrowArgumentException()
        {
            // Arrange
            var debt = new MusteriBorc 
            { 
                Id = 1, 
                QalanBorc = 100m, 
                UmumiMebleg = 200m 
            };
            
            var payment = new BorcOdenis 
            { 
                MusteriBorcId = 1, 
                OdenisMeblegi = 0m,
                QebulEdenIstifadeciId = 1
            };

            _mockBorcRepository.Setup(x => x.GetById(1)).Returns(debt);

            // Act & Assert
            var exception = Assert.Throws<ApplicationException>(() => _borcService.AddPayment(payment));
            exception.InnerException.Should().BeOfType<ArgumentException>();
            exception.Message.Should().Contain("Ödəniş məbləği müsbət olmalıdır");
        }

        [Fact]
        public void AddPayment_WhenPaymentIsNegative_ShouldThrowArgumentException()
        {
            // Arrange
            var debt = new MusteriBorc 
            { 
                Id = 1, 
                QalanBorc = 100m, 
                UmumiMebleg = 200m 
            };
            
            var payment = new BorcOdenis 
            { 
                MusteriBorcId = 1, 
                OdenisMeblegi = -50m,
                QebulEdenIstifadeciId = 1
            };

            _mockBorcRepository.Setup(x => x.GetById(1)).Returns(debt);

            // Act & Assert
            var exception = Assert.Throws<ApplicationException>(() => _borcService.AddPayment(payment));
            exception.InnerException.Should().BeOfType<ArgumentException>();
            exception.Message.Should().Contain("Ödəniş məbləği müsbət olmalıdır");
        }

        [Fact]
        public void AddPayment_WhenLargePaymentMade_ShouldLogWarning()
        {
            // Arrange
            var debt = new MusteriBorc 
            { 
                Id = 1, 
                QalanBorc = 150m, 
                UmumiMebleg = 200m 
            };
            
            var payment = new BorcOdenis 
            { 
                MusteriBorcId = 1, 
                OdenisMeblegi = 120m, // > 50% of total debt (200 * 0.5 = 100)
                QebulEdenIstifadeciId = 1
            };

            _mockBorcRepository.Setup(x => x.GetById(1)).Returns(debt);
            _mockOdenisRepository.Setup(x => x.GenerateOdenisNomresi()).Returns("PAY-001");
            _mockOdenisRepository.Setup(x => x.Add(It.IsAny<BorcOdenis>())).Returns(1);

            // Act
            _borcService.AddPayment(payment);

            // Assert
            _mockAuditLogService.Verify(x => x.LogAction(
                "BorcOdenis",
                "LARGE_PAYMENT_WARNING",
                1,
                It.Is<string>(s => s.Contains("Böyük ödəniş cəhdi")),
                1
            ), Times.Once);
        }

        [Fact]
        public void AddPayment_WhenValidPayment_ShouldSucceed()
        {
            // Arrange
            var debt = new MusteriBorc 
            { 
                Id = 1, 
                QalanBorc = 100m, 
                UmumiMebleg = 200m 
            };
            
            var payment = new BorcOdenis 
            { 
                MusteriBorcId = 1, 
                OdenisMeblegi = 50m,
                QebulEdenIstifadeciId = 1
            };

            _mockBorcRepository.Setup(x => x.GetById(1)).Returns(debt);
            _mockOdenisRepository.Setup(x => x.GenerateOdenisNomresi()).Returns("PAY-001");
            _mockOdenisRepository.Setup(x => x.Add(It.IsAny<BorcOdenis>())).Returns(1);

            // Act
            var result = _borcService.AddPayment(payment);

            // Assert
            result.Should().Be(1);
            _mockOdenisRepository.Verify(x => x.Add(It.IsAny<BorcOdenis>()), Times.Once);
            _mockUnitOfWork.Verify(x => x.Complete(), Times.AtLeastOnce);
        }

        [Fact]
        public void AddPayment_WhenDebtNotFound_ShouldThrowArgumentException()
        {
            // Arrange
            var payment = new BorcOdenis 
            { 
                MusteriBorcId = 999, 
                OdenisMeblegi = 50m,
                QebulEdenIstifadeciId = 1
            };

            _mockBorcRepository.Setup(x => x.GetById(999)).Returns((MusteriBorc)null);

            // Act & Assert
            var exception = Assert.Throws<ApplicationException>(() => _borcService.AddPayment(payment));
            exception.InnerException.Should().BeOfType<ArgumentException>();
            exception.Message.Should().Contain("Borc tapılmadı");
        }

        [Fact]
        public void AddPayment_ShouldSetCorrectTimestamp()
        {
            // Arrange
            var debt = new MusteriBorc 
            { 
                Id = 1, 
                QalanBorc = 100m, 
                UmumiMebleg = 200m 
            };
            
            var payment = new BorcOdenis 
            { 
                MusteriBorcId = 1, 
                OdenisMeblegi = 50m,
                QebulEdenIstifadeciId = 1
            };

            var beforeTime = DateTime.Now.AddSeconds(-1);
            var afterTime = DateTime.Now.AddSeconds(1);

            _mockBorcRepository.Setup(x => x.GetById(1)).Returns(debt);
            _mockOdenisRepository.Setup(x => x.GenerateOdenisNomresi()).Returns("PAY-001");
            _mockOdenisRepository.Setup(x => x.Add(It.IsAny<BorcOdenis>())).Returns(1);

            // Act
            _borcService.AddPayment(payment);

            // Assert
            payment.YaradilmaTarixi.Should().BeAfter(beforeTime);
            payment.YaradilmaTarixi.Should().BeBefore(afterTime);
        }

        [Theory]
        [InlineData(100.01)]
        [InlineData(150.50)]
        [InlineData(200.00)]
        public void AddPayment_WhenPaymentExceedsDebt_ShouldThrowForVariousAmounts(decimal paymentAmount)
        {
            // Arrange
            var debt = new MusteriBorc 
            { 
                Id = 1, 
                QalanBorc = 100m, 
                UmumiMebleg = 200m 
            };
            
            var payment = new BorcOdenis 
            { 
                MusteriBorcId = 1, 
                OdenisMeblegi = paymentAmount,
                QebulEdenIstifadeciId = 1
            };

            _mockBorcRepository.Setup(x => x.GetById(1)).Returns(debt);

            // Act & Assert
            var exception = Assert.Throws<ApplicationException>(() => _borcService.AddPayment(payment));
            exception.InnerException.Should().BeOfType<InvalidOperationException>();
        }

        [Theory]
        [InlineData(99.99, false)]
        [InlineData(100.00, false)]
        [InlineData(100.01, true)]
        [InlineData(150.00, true)]
        public void AddPayment_LargePaymentWarning_ShouldTriggerCorrectly(decimal paymentAmount, bool shouldWarn)
        {
            // Arrange - Total debt 200, so 50% = 100
            var debt = new MusteriBorc 
            { 
                Id = 1, 
                QalanBorc = 150m, 
                UmumiMebleg = 200m 
            };
            
            var payment = new BorcOdenis 
            { 
                MusteriBorcId = 1, 
                OdenisMeblegi = paymentAmount,
                QebulEdenIstifadeciId = 1
            };

            _mockBorcRepository.Setup(x => x.GetById(1)).Returns(debt);
            _mockOdenisRepository.Setup(x => x.GenerateOdenisNomresi()).Returns("PAY-001");
            _mockOdenisRepository.Setup(x => x.Add(It.IsAny<BorcOdenis>())).Returns(1);

            // Act
            _borcService.AddPayment(payment);

            // Assert
            var expectedTimes = shouldWarn ? Times.Once() : Times.Never();
            _mockAuditLogService.Verify(x => x.LogAction(
                "BorcOdenis",
                "LARGE_PAYMENT_WARNING",
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<int>()
            ), expectedTimes);
        }

        [Fact]
        public void AddPayment_ShouldGenerateUniquePaymentNumber()
        {
            // Arrange
            var debt = new MusteriBorc 
            { 
                Id = 1, 
                QalanBorc = 100m, 
                UmumiMebleg = 200m 
            };
            
            var payment = new BorcOdenis 
            { 
                MusteriBorcId = 1, 
                OdenisMeblegi = 50m,
                QebulEdenIstifadeciId = 1
            };

            _mockBorcRepository.Setup(x => x.GetById(1)).Returns(debt);
            _mockOdenisRepository.Setup(x => x.GenerateOdenisNomresi()).Returns("PAY-001-2024");
            _mockOdenisRepository.Setup(x => x.Add(It.IsAny<BorcOdenis>())).Returns(1);

            // Act
            _borcService.AddPayment(payment);

            // Assert
            payment.OdenisNomresi.Should().Be("PAY-001-2024");
            _mockOdenisRepository.Verify(x => x.GenerateOdenisNomresi(), Times.Once);
        }
    }
}