using AzAgroPOS.BLL.Services;
using AzAgroPOS.DAL.Interfaces;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Domain;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AzAgroPOS.Tests.Services
{
    /// <summary>
    /// SatisService-in unit testləri
    /// Mock obyektlərdən istifadə edərək təcrid olunmuş testlər
    /// </summary>
    public class SatisServiceTests : IDisposable
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<SatisRepository> _mockSatisRepository;
        private readonly Mock<SatisDetaliRepository> _mockSatisDetaliRepository;
        private readonly Mock<MehsulRepository> _mockMehsulRepository;
        private readonly Mock<AnbarQalikRepository> _mockAnbarQalikRepository;
        private readonly SatisService _satisService;

        public SatisServiceTests()
        {
            // Mock obyektləri yaradırıq
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockSatisRepository = new Mock<SatisRepository>();
            _mockSatisDetaliRepository = new Mock<SatisDetaliRepository>();
            _mockMehsulRepository = new Mock<MehsulRepository>();
            _mockAnbarQalikRepository = new Mock<AnbarQalikRepository>();

            // UnitOfWork mock-unu konfiqurasiya edirik
            _mockUnitOfWork.Setup(x => x.Satislar).Returns(_mockSatisRepository.Object);
            _mockUnitOfWork.Setup(x => x.SatisDetallari).Returns(_mockSatisDetaliRepository.Object);
            _mockUnitOfWork.Setup(x => x.Mehsullar).Returns(_mockMehsulRepository.Object);
            _mockUnitOfWork.Setup(x => x.AnbarQaliqlari).Returns(_mockAnbarQalikRepository.Object);

            // Test ediləcək servisi yaradırıq
            _satisService = new SatisService(_mockUnitOfWork.Object);
        }

        [Fact]
        public async Task CreateSatisAsync_ValidSatis_ReturnsSuccessfullyCreatedSatisId()
        {
            // Arrange (Hazırlıq)
            var testSatis = new Satis
            {
                MusteriId = 1,
                UmumiMebleg = 100.00m,
                SatisDetallari = new List<SatisDetali>
                {
                    new SatisDetali
                    {
                        MehsulId = 1,
                        Miqdar = 5,
                        VahidQiymet = 20.00m,
                        UmumiQiymet = 100.00m
                    }
                }
            };

            var testMehsul = new Mehsul
            {
                Id = 1,
                Ad = "Test Məhsul",
                SatisQiymeti = 20.00m
            };

            var testAnbarQaliq = new AnbarQalik
            {
                Id = 1,
                AnbarId = 1,
                MehsulId = 1,
                MovcudMiqdar = 100 // Kifayət qədər stok
            };

            // Mock davranışlarını təyin edirik
            _mockSatisRepository.Setup(x => x.AddAsync(It.IsAny<Satis>()))
                .ReturnsAsync(123); // Saxta ID qaytarır

            _mockMehsulRepository.Setup(x => x.GetById(1))
                .Returns(testMehsul);

            _mockAnbarQalikRepository.Setup(x => x.GetByAnbarVeMehsul(1, 1))
                .Returns(testAnbarQaliq);

            _mockSatisDetaliRepository.Setup(x => x.AddAsync(It.IsAny<SatisDetali>()))
                .ReturnsAsync(1);

            _mockUnitOfWork.Setup(x => x.CompleteAsync())
                .ReturnsAsync(1);

            // Act (İcra)
            var result = await _satisService.CreateSatisAsync(testSatis);

            // Assert (Yoxlama)
            result.Should().Be(123, "çünki mock repository 123 ID-ni qaytarmalıdır");

            // Mock-ların düzgün çağrıldığını yoxlayırıq
            _mockSatisRepository.Verify(x => x.AddAsync(It.IsAny<Satis>()), Times.Once,
                "Satış repository-də AddAsync bir dəfə çağrılmalıdır");

            _mockMehsulRepository.Verify(x => x.GetById(1), Times.Once,
                "Məhsul məlumatı bir dəfə yoxlanmalıdır");

            _mockAnbarQalikRepository.Verify(x => x.GetByAnbarVeMehsul(1, 1), Times.Once,
                "Anbar qalığı bir dəfə yoxlanmalıdır");

            _mockUnitOfWork.Verify(x => x.CompleteAsync(), Times.Once,
                "Transaction commit edilməlidir");
        }

        [Fact]
        public async Task CreateSatisAsync_EmptySatisDetallari_ThrowsArgumentException()
        {
            // Arrange
            var invalidSatis = new Satis
            {
                MusteriId = 1,
                UmumiMebleg = 0,
                SatisDetallari = new List<SatisDetali>() // Boş list
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(
                () => _satisService.CreateSatisAsync(invalidSatis));

            exception.Message.Should().Contain("Satış detalları boş ola bilməz",
                "çünki boş detallar üçün məna dolu xəta mesajı olmalıdır");
        }

        [Fact]
        public async Task CreateSatisAsync_NullSatisDetallari_ThrowsArgumentException()
        {
            // Arrange
            var invalidSatis = new Satis
            {
                MusteriId = 1,
                UmumiMebleg = 0,
                SatisDetallari = null // Null
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(
                () => _satisService.CreateSatisAsync(invalidSatis));

            exception.Message.Should().Contain("Satış detalları boş ola bilməz");
        }

        [Fact]
        public async Task CreateSatisAsync_NonExistentMehsul_ThrowsArgumentException()
        {
            // Arrange
            var satisWithInvalidMehsul = new Satis
            {
                MusteriId = 1,
                UmumiMebleg = 100,
                SatisDetallari = new List<SatisDetali>
                {
                    new SatisDetali
                    {
                        MehsulId = 999, // Mövcud olmayan məhsul
                        Miqdar = 1,
                        VahidQiymet = 100,
                        UmumiQiymet = 100
                    }
                }
            };

            _mockSatisRepository.Setup(x => x.AddAsync(It.IsAny<Satis>()))
                .ReturnsAsync(1);

            _mockMehsulRepository.Setup(x => x.GetById(999))
                .Returns((Mehsul)null); // Məhsul tapılmır

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(
                () => _satisService.CreateSatisAsync(satisWithInvalidMehsul));

            exception.Message.Should().Contain("Məhsul tapılmadı: 999");
        }

        [Fact]
        public async Task CreateSatisAsync_InsufficientStock_ThrowsInvalidOperationException()
        {
            // Arrange
            var satisWithHighQuantity = new Satis
            {
                MusteriId = 1,
                UmumiMebleg = 200,
                SatisDetallari = new List<SatisDetali>
                {
                    new SatisDetali
                    {
                        MehsulId = 1,
                        Miqdar = 150, // Mövcuddan çox
                        VahidQiymet = 1,
                        UmumiQiymet = 150
                    }
                }
            };

            var mehsul = new Mehsul { Id = 1, Ad = "Test Məhsul" };
            var anbarQaliq = new AnbarQalik 
            { 
                AnbarId = 1, 
                MehsulId = 1, 
                MovcudMiqdar = 100 // Kifayət etmir
            };

            _mockSatisRepository.Setup(x => x.AddAsync(It.IsAny<Satis>()))
                .ReturnsAsync(1);

            _mockMehsulRepository.Setup(x => x.GetById(1))
                .Returns(mehsul);

            _mockAnbarQalikRepository.Setup(x => x.GetByAnbarVeMehsul(1, 1))
                .Returns(anbarQaliq);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(
                () => _satisService.CreateSatisAsync(satisWithHighQuantity));

            exception.Message.Should().Contain("Kifayət qədər stok yoxdur");
            exception.Message.Should().Contain("Test Məhsul");
            exception.Message.Should().Contain("Mövcud: 100");
        }

        [Fact]
        public void Constructor_NullUnitOfWork_ThrowsArgumentNullException()
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(
                () => new SatisService(null));

            exception.ParamName.Should().Be("unitOfWork");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-10)]
        public async Task CreateSatisAsync_InvalidQuantity_ThrowsAppropriateException(int invalidQuantity)
        {
            // Arrange
            var satisWithInvalidQuantity = new Satis
            {
                MusteriId = 1,
                UmumiMebleg = 100,
                SatisDetallari = new List<SatisDetali>
                {
                    new SatisDetali
                    {
                        MehsulId = 1,
                        Miqdar = invalidQuantity, // Səhv miqdar
                        VahidQiymet = 100,
                        UmumiQiymet = 100
                    }
                }
            };

            var mehsul = new Mehsul { Id = 1, Ad = "Test Məhsul" };
            var anbarQaliq = new AnbarQalik { MovcudMiqdar = 100 };

            _mockSatisRepository.Setup(x => x.AddAsync(It.IsAny<Satis>()))
                .ReturnsAsync(1);

            _mockMehsulRepository.Setup(x => x.GetById(1))
                .Returns(mehsul);

            _mockAnbarQalikRepository.Setup(x => x.GetByAnbarVeMehsul(1, 1))
                .Returns(anbarQaliq);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(
                () => _satisService.CreateSatisAsync(satisWithInvalidQuantity));
        }

        public void Dispose()
        {
            _satisService?.Dispose();
        }
    }
}