using AzAgroPOS.BLL.Services;
using AzAgroPOS.BLL.Interfaces;
using AzAgroPOS.DAL.Interfaces;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Domain;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AzAgroPOS.Tests.Services
{
    /// <summary>
    /// MusteriService-in unit testləri
    /// Müştəri əməliyyatlarının düzgün işlədiyini yoxlayır
    /// </summary>
    public class MusteriServiceTests : IDisposable
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IAuditLogService> _mockAuditLogService;
        private readonly Mock<MusteriRepository> _mockMusteriRepository;
        private readonly Mock<MusteriQrupuRepository> _mockMusteriQrupuRepository;
        private readonly MusteriService _musteriService;

        public MusteriServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockAuditLogService = new Mock<IAuditLogService>();
            _mockMusteriRepository = new Mock<MusteriRepository>();
            _mockMusteriQrupuRepository = new Mock<MusteriQrupuRepository>();

            _mockUnitOfWork.Setup(x => x.Musteriler).Returns(_mockMusteriRepository.Object);
            _mockUnitOfWork.Setup(x => x.MusteriQruplari).Returns(_mockMusteriQrupuRepository.Object);

            _musteriService = new MusteriService(_mockUnitOfWork.Object, _mockAuditLogService.Object);
        }

        [Fact]
        public void CreateCustomer_ValidCustomer_ReturnsSuccess()
        {
            // Arrange
            var testMusteri = new Musteri
            {
                Ad = "Əli",
                Soyad = "Məmmədov",
                Email = "ali@example.com",
                Telefon = "0501234567",
                MusteriQrupuId = 1,
                MusteriKodu = "MST001"
            };

            var testQrup = new MusteriQrupu
            {
                Id = 1,
                Ad = "VIP Müştərilər",
                EndirimbFaizi = 10
            };

            var createdMusteri = new Musteri
            {
                Id = 100,
                Ad = testMusteri.Ad,
                Soyad = testMusteri.Soyad,
                Email = testMusteri.Email
            };

            _mockMusteriRepository.Setup(x => x.IsCodeExists(It.IsAny<string>(), It.IsAny<int?>()))
                .Returns(false);
            
            _mockMusteriRepository.Setup(x => x.IsEmailExists(It.IsAny<string>(), It.IsAny<int?>()))
                .Returns(false);

            _mockMusteriRepository.Setup(x => x.Add(It.IsAny<Musteri>()))
                .Returns(createdMusteri);

            _mockUnitOfWork.Setup(x => x.Complete())
                .Returns(1);

            // Act
            var result = _musteriService.CreateCustomer(testMusteri, 1);

            // Assert
            result.Success.Should().BeTrue("çünki valid müştəri yaradılmalıdır");
            result.Message.Should().Contain("uğurla yaradıldı");
            result.Customer.Should().NotBeNull();

            _mockMusteriRepository.Verify(x => x.Add(It.IsAny<Musteri>()), Times.Once);
            _mockUnitOfWork.Verify(x => x.Complete(), Times.Once);
            _mockAuditLogService.Verify(x => x.LogAction("Musteri", "CREATE", 100, It.IsAny<string>(), 1), Times.Once);
        }

        [Theory]
        [InlineData("", "Məmmədov", "ali@example.com")] // Boş ad
        [InlineData("Əli", "", "ali@example.com")]       // Boş soyad
        [InlineData("Əli", "Məmmədov", "")]              // Boş email
        [InlineData(null, "Məmmədov", "ali@example.com")] // Null ad
        [InlineData("Əli", null, "ali@example.com")]      // Null soyad
        [InlineData("Əli", "Məmmədov", null)]             // Null email
        public void CreateCustomer_InvalidData_ReturnsFailure(string ad, string soyad, string email)
        {
            // Arrange
            var invalidMusteri = new Musteri
            {
                Ad = ad,
                Soyad = soyad,
                Email = email,
                MusteriQrupuId = 1,
                MusteriKodu = "MST001"
            };

            // Act
            var result = _musteriService.CreateCustomer(invalidMusteri, 1);

            // Assert
            result.Success.Should().BeFalse("çünki invalid data ilə müştəri yaradılmamalıdır");
            result.Message.Should().NotBeEmpty();
            result.Customer.Should().BeNull();
        }

        [Fact]
        public void CreateCustomer_ExistingCode_ReturnsFailure()
        {
            // Arrange
            var musteriWithExistingCode = new Musteri
            {
                Ad = "Əli",
                Soyad = "Məmmədov",
                Email = "ali@example.com",
                MusteriKodu = "MST001" // Mövcud kod
            };

            _mockMusteriRepository.Setup(x => x.IsCodeExists(It.IsAny<string>(), It.IsAny<int?>()))
                .Returns(true);

            // Act
            var result = _musteriService.CreateCustomer(musteriWithExistingCode, 1);

            // Assert
            result.Success.Should().BeFalse();
            result.Message.Should().Contain("müştəri kodu artıq mövcuddur");
            result.Customer.Should().BeNull();
        }

        [Fact]
        public void CreateCustomer_ExistingEmail_ReturnsFailure()
        {
            // Arrange
            var musteriWithExistingEmail = new Musteri
            {
                Ad = "Əli",
                Soyad = "Məmmədov",
                Email = "existing@example.com", // Mövcud email
                MusteriKodu = "MST001"
            };

            _mockMusteriRepository.Setup(x => x.IsCodeExists(It.IsAny<string>(), It.IsAny<int?>()))
                .Returns(false);
            
            _mockMusteriRepository.Setup(x => x.IsEmailExists(It.IsAny<string>(), It.IsAny<int?>()))
                .Returns(true);

            // Act
            var result = _musteriService.CreateCustomer(musteriWithExistingEmail, 1);

            // Assert
            result.Success.Should().BeFalse();
            result.Message.Should().Contain("email ünvanı artıq istifadə olunur");
            result.Customer.Should().BeNull();
        }

        [Fact]
        public void GetAllCustomers_ReturnsAllCustomers()
        {
            // Arrange
            var testCustomers = new List<Musteri>
            {
                new Musteri { Id = 1, Ad = "Əli", Soyad = "Məmmədov" },
                new Musteri { Id = 2, Ad = "Fatma", Soyad = "İbrahimova" },
                new Musteri { Id = 3, Ad = "Orxan", Soyad = "Həsənov" }
            };

            _mockMusteriRepository.Setup(x => x.GetAll())
                .Returns(testCustomers.AsQueryable());

            // Act
            var result = _musteriService.GetAllCustomers();

            // Assert
            result.Should().HaveCount(3, "çünki 3 müştəri qaytarılmalıdır");
            result.Should().Contain(m => m.Ad == "Əli" && m.Soyad == "Məmmədov");
            result.Should().Contain(m => m.Ad == "Fatma" && m.Soyad == "İbrahimova");
            result.Should().Contain(m => m.Ad == "Orxan" && m.Soyad == "Həsənov");
        }

        [Fact]
        public void GetCustomerById_ExistingId_ReturnsCustomer()
        {
            // Arrange
            var testMusteri = new Musteri 
            { 
                Id = 1, 
                Ad = "Əli", 
                Soyad = "Məmmədov",
                Email = "ali@example.com"
            };

            _mockMusteriRepository.Setup(x => x.GetById(1))
                .Returns(testMusteri);

            // Act
            var result = _musteriService.GetCustomerById(1);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(1);
            result.Ad.Should().Be("Əli");
            result.Soyad.Should().Be("Məmmədov");
            result.Email.Should().Be("ali@example.com");
        }

        [Fact]
        public void GetCustomerById_NonExistingId_ReturnsNull()
        {
            // Arrange
            _mockMusteriRepository.Setup(x => x.GetById(999))
                .Returns((Musteri)null);

            // Act
            var result = _musteriService.GetCustomerById(999);

            // Assert
            result.Should().BeNull("çünki mövcud olmayan ID üçün null qaytarılmalıdır");
        }

        [Fact]
        public void GetCustomerById_InvalidId_ThrowsArgumentException()
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(
                () => _musteriService.GetCustomerById(0));

            exception.ParamName.Should().Be("id");
            exception.Message.Should().Contain("Yanlış müştəri ID-si");
        }

        [Fact]
        public void UpdateCustomer_ValidCustomer_ReturnsSuccess()
        {
            // Arrange
            var existingMusteri = new Musteri
            {
                Id = 1,
                Ad = "Əli",
                Soyad = "Məmmədov",
                Email = "ali@example.com",
                MusteriQrupuId = 1,
                MusteriKodu = "MST001"
            };

            _mockMusteriRepository.Setup(x => x.IsCodeExists(It.IsAny<string>(), It.IsAny<int>()))
                .Returns(false);
            
            _mockMusteriRepository.Setup(x => x.IsEmailExists(It.IsAny<string>(), It.IsAny<int>()))
                .Returns(false);

            _mockUnitOfWork.Setup(x => x.Complete())
                .Returns(1);

            // Act
            var result = _musteriService.UpdateCustomer(existingMusteri, 1);

            // Assert
            result.Success.Should().BeTrue("çünki valid məlumatlarla yeniləmə uğurlu olmalıdır");
            result.Message.Should().Contain("uğurla yeniləndi");

            _mockMusteriRepository.Verify(x => x.Update(It.IsAny<Musteri>()), Times.Once);
            _mockUnitOfWork.Verify(x => x.Complete(), Times.Once);
            _mockAuditLogService.Verify(x => x.LogAction("Musteri", "UPDATE", 1, It.IsAny<string>(), 1), Times.Once);
        }

        [Fact]
        public void DeleteCustomer_ExistingCustomer_ReturnsSuccess()
        {
            // Arrange
            var existingMusteri = new Musteri
            {
                Id = 1,
                Ad = "Əli",
                Soyad = "Məmmədov",
                CariBorc = 0 // Borcu yoxdur
            };

            _mockMusteriRepository.Setup(x => x.GetById(1))
                .Returns(existingMusteri);

            _mockUnitOfWork.Setup(x => x.Complete())
                .Returns(1);

            // Act
            var result = _musteriService.DeleteCustomer(1, 1);

            // Assert
            result.Success.Should().BeTrue("çünki borcu olmayan müştəri silinə bilər");

            _mockMusteriRepository.Verify(x => x.Delete(1), Times.Once);
            _mockUnitOfWork.Verify(x => x.Complete(), Times.Once);
        }

        [Fact]
        public void DeleteCustomer_CustomerWithDebt_ReturnsFailure()
        {
            // Arrange
            var musteriWithDebt = new Musteri
            {
                Id = 1,
                Ad = "Əli",
                Soyad = "Məmmədov",
                CariBorc = 100 // Borcu var
            };

            _mockMusteriRepository.Setup(x => x.GetById(1))
                .Returns(musteriWithDebt);

            // Act
            var result = _musteriService.DeleteCustomer(1, 1);

            // Assert
            result.Success.Should().BeFalse();
            result.Message.Should().Contain("Borcu olan müştəri silinə bilməz");

            _mockMusteriRepository.Verify(x => x.Delete(It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public void DeleteCustomer_NonExistingCustomer_ReturnsFailure()
        {
            // Arrange
            _mockMusteriRepository.Setup(x => x.GetById(999))
                .Returns((Musteri)null);

            // Act
            var result = _musteriService.DeleteCustomer(999, 1);

            // Assert
            result.Success.Should().BeFalse();
            result.Message.Should().Contain("Müştəri tapılmadı");
        }

        [Fact]
        public void GetCustomerByCode_ValidCode_ReturnsCustomer()
        {
            // Arrange
            var testMusteri = new Musteri
            {
                Id = 1,
                MusteriKodu = "MST001",
                Ad = "Əli",
                Soyad = "Məmmədov"
            };

            _mockMusteriRepository.Setup(x => x.GetByCode("MST001"))
                .Returns(testMusteri);

            // Act
            var result = _musteriService.GetCustomerByCode("MST001");

            // Assert
            result.Should().NotBeNull();
            result.MusteriKodu.Should().Be("MST001");
            result.Ad.Should().Be("Əli");
        }

        [Fact]
        public void GetCustomerByCode_EmptyCode_ThrowsArgumentException()
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(
                () => _musteriService.GetCustomerByCode(""));

            exception.ParamName.Should().Be("musteriKodu");
            exception.Message.Should().Contain("Müştəri kodu boş ola bilməz");
        }

        [Fact]
        public void Constructor_NullUnitOfWork_ThrowsArgumentNullException()
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(
                () => new MusteriService(null, _mockAuditLogService.Object));

            exception.ParamName.Should().Be("unitOfWork");
        }

        [Fact]
        public void Constructor_NullAuditLogService_ThrowsArgumentNullException()
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(
                () => new MusteriService(_mockUnitOfWork.Object, null));

            exception.ParamName.Should().Be("auditLogService");
        }

        public void Dispose()
        {
            _musteriService?.Dispose();
        }
    }
}