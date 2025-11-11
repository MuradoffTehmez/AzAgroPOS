// Fayl: AzAgroPOS.Tests/Unit/Managers/MusteriManagerTests.cs

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Tests.TestHelpers;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using FluentAssertions;
using Moq;

namespace AzAgroPOS.Tests.Unit.Managers;

/// <summary>
/// MusteriManager üçün unit test-lər
/// </summary>
public class MusteriManagerTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<IMusteriRepozitori> _mockMusteriRepo;
    private readonly MusteriManager _musteriManager;

    public MusteriManagerTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockMusteriRepo = new Mock<IMusteriRepozitori>();
        _mockUnitOfWork.Setup(x => x.Musteriler).Returns(_mockMusteriRepo.Object);
        _musteriManager = new MusteriManager(_mockUnitOfWork.Object);
    }

    [Fact]
    public async Task MusteriYaratAsync_DuplicateTelefonNomresi_ReturnsFailure()
    {
        // Arrange
        var dto = MusteriMockFactory.CreateValidDto();
        var existingMusteri = MusteriMockFactory.CreateValid();
        _mockMusteriRepo.Setup(x => x.AxtarAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Musteri, bool>>>(), null))
            .ReturnsAsync(new List<Musteri> { existingMusteri });

        // Act
        var result = await _musteriManager.MusteriYaratAsync(dto);

        // Assert
        result.UgurluDur.Should().BeFalse();
        result.Mesaj.Should().Contain("telefon nömrəsi ilə müştəri artıq mövcuddur");
        _mockMusteriRepo.Verify(x => x.ElaveEtAsync(It.IsAny<Musteri>()), Times.Never);
    }

    [Fact]
    public async Task MusteriYaratAsync_ValidData_ReturnsSuccess()
    {
        // Arrange
        var dto = MusteriMockFactory.CreateValidDto();
        _mockMusteriRepo.Setup(x => x.AxtarAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Musteri, bool>>>(), null))
            .ReturnsAsync(new List<Musteri>());
        _mockMusteriRepo.Setup(x => x.ElaveEtAsync(It.IsAny<Musteri>()))
            .Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(x => x.EmeliyyatiTesdiqleAsync())
            .ReturnsAsync(1);

        // Act
        var result = await _musteriManager.MusteriYaratAsync(dto);

        // Assert
        result.UgurluDur.Should().BeTrue();
        _mockMusteriRepo.Verify(x => x.ElaveEtAsync(It.IsAny<Musteri>()), Times.Once);
        _mockUnitOfWork.Verify(x => x.EmeliyyatiTesdiqleAsync(), Times.Once);
    }

    [Fact]
    public async Task MusteriYenileAsync_NonExistingMusteri_ReturnsFailure()
    {
        // Arrange
        var dto = MusteriMockFactory.CreateValidDto(999);
        _mockMusteriRepo.Setup(x => x.GetirAsync(999))
            .ReturnsAsync((Musteri?)null);

        // Act
        var result = await _musteriManager.MusteriYenileAsync(dto);

        // Assert
        result.UgurluDur.Should().BeFalse();
        result.Mesaj.Should().Contain("Müştəri tapılmadı");
        _mockUnitOfWork.Verify(x => x.EmeliyyatiTesdiqleAsync(), Times.Never);
    }

    [Fact]
    public async Task MusteriYenileAsync_ValidData_ReturnsSuccess()
    {
        // Arrange
        var musteri = MusteriMockFactory.CreateValid(1);
        var dto = MusteriMockFactory.CreateValidDto(1);
        dto.TamAd = "Yenilənmiş Ad";

        _mockMusteriRepo.Setup(x => x.GetirAsync(1))
            .ReturnsAsync(musteri);
        _mockUnitOfWork.Setup(x => x.EmeliyyatiTesdiqleAsync())
            .ReturnsAsync(1);

        // Act
        var result = await _musteriManager.MusteriYenileAsync(dto);

        // Assert
        result.UgurluDur.Should().BeTrue();
        musteri.TamAd.Should().Be("Yenilənmiş Ad");
        _mockUnitOfWork.Verify(x => x.EmeliyyatiTesdiqleAsync(), Times.Once);
    }

    [Fact]
    public async Task MusteriSilAsync_MusteriWithDebt_ReturnsFailure()
    {
        // Arrange
        var musteri = MusteriMockFactory.CreateWithDebt(1, 500m);
        _mockMusteriRepo.Setup(x => x.GetirAsync(1))
            .ReturnsAsync(musteri);

        // Act
        var result = await _musteriManager.MusteriSilAsync(1);

        // Assert
        result.UgurluDur.Should().BeFalse();
        result.Mesaj.Should().Contain("Borcu olan müştərini silmək olmaz");
        _mockMusteriRepo.Verify(x => x.Sil(It.IsAny<Musteri>()), Times.Never);
    }

    [Fact]
    public async Task MusteriSilAsync_ValidMusteri_ReturnsSuccess()
    {
        // Arrange
        var musteri = MusteriMockFactory.CreateValid(1);
        musteri.UmumiBorc = 0; // Borcu yoxdur
        _mockMusteriRepo.Setup(x => x.GetirAsync(1))
            .ReturnsAsync(musteri);
        _mockMusteriRepo.Setup(x => x.Sil(It.IsAny<Musteri>()))
            .Callback<Musteri>(m => m.Silinib = true);
        _mockUnitOfWork.Setup(x => x.EmeliyyatiTesdiqleAsync())
            .ReturnsAsync(1);

        // Act
        var result = await _musteriManager.MusteriSilAsync(1);

        // Assert
        result.UgurluDur.Should().BeTrue();
        musteri.Silinib.Should().BeTrue();
        _mockMusteriRepo.Verify(x => x.Sil(musteri), Times.Once);
    }

    [Fact]
    public async Task ButunMusterileriGetirAsync_ReturnsAllMusteriler()
    {
        // Arrange
        var musteriler = MusteriMockFactory.CreateList(5);
        _mockMusteriRepo.Setup(x => x.ButununuGetirAsync())
            .ReturnsAsync(musteriler);

        // Act
        var result = await _musteriManager.ButunMusterileriGetirAsync();

        // Assert
        result.UgurluDur.Should().BeTrue();
        result.Data.Should().HaveCount(5);
        _mockMusteriRepo.Verify(x => x.ButununuGetirAsync(), Times.Once);
    }
}
