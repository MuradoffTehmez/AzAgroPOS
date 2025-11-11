// Fayl: AzAgroPOS.Tests/Unit/Managers/SatisManagerTests.cs

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Tests.TestHelpers;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using FluentAssertions;
using Moq;

namespace AzAgroPOS.Tests.Unit.Managers;

/// <summary>
/// SatisManager üçün unit test-lər
/// Qeyd: Sadə validasiya test-ləri - dependency test-ləri daha mürəkkəbdir
/// </summary>
public class SatisManagerTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<ISatisRepozitori> _mockSatisRepo;
    private readonly Mock<IMehsulRepozitori> _mockMehsulRepo;
    private readonly Mock<IStokHareketiRepozitori> _mockStokHareketiRepo;
    private readonly NisyeManager _nisyeManager;
    private readonly StokHareketiManager _stokManager;
    private readonly SatisManager _satisManager;

    public SatisManagerTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockSatisRepo = new Mock<ISatisRepozitori>();
        _mockMehsulRepo = new Mock<IMehsulRepozitori>();
        _mockStokHareketiRepo = new Mock<IStokHareketiRepozitori>();

        _mockUnitOfWork.Setup(x => x.Satislar).Returns(_mockSatisRepo.Object);
        _mockUnitOfWork.Setup(x => x.Mehsullar).Returns(_mockMehsulRepo.Object);
        _mockUnitOfWork.Setup(x => x.Musteriler).Returns(new Mock<IMusteriRepozitori>().Object);
        _mockUnitOfWork.Setup(x => x.NisyeHereketleri).Returns(new Mock<INisyeHereketiRepozitori>().Object);

        // Real instances üçün dependency-lər
        _nisyeManager = new NisyeManager(_mockUnitOfWork.Object);
        _stokManager = new StokHareketiManager(_mockUnitOfWork.Object, _mockStokHareketiRepo.Object);
        _satisManager = new SatisManager(_mockUnitOfWork.Object, _nisyeManager, _stokManager);
    }

    [Fact]
    public async Task SatisYaratAsync_EmptySebetElementleri_ReturnsFailure()
    {
        // Arrange
        var dto = SatisMockFactory.CreateValidYaratDto();
        dto.SebetElementleri = new List<SatisSebetiElementiDto>();

        // Act
        var result = await _satisManager.SatisYaratAsync(dto);

        // Assert
        result.UgurluDur.Should().BeFalse();
        result.Mesaj.Should().Contain("səbət boşdur");
        _mockSatisRepo.Verify(x => x.ElaveEtAsync(It.IsAny<Satis>()), Times.Never);
    }

    [Fact]
    public async Task SatisYaratAsync_NisyeWithoutMusteri_ReturnsFailure()
    {
        // Arrange
        var dto = SatisMockFactory.CreateValidYaratDto();
        dto.OdenisMetodu = OdenisMetodu.Nisyə;
        dto.MusteriId = null;

        // Act
        var result = await _satisManager.SatisYaratAsync(dto);

        // Assert
        result.UgurluDur.Should().BeFalse();
        result.Mesaj.Should().Contain("müştəri seçilməlidir");
        _mockSatisRepo.Verify(x => x.ElaveEtAsync(It.IsAny<Satis>()), Times.Never);
    }

    [Fact]
    public async Task SatisYaratAsync_InsufficientStock_ReturnsFailure()
    {
        // Arrange
        var dto = SatisMockFactory.CreateValidYaratDto();
        var mehsul = MehsulMockFactory.CreateValid(1);
        mehsul.MovcudSay = 1; // Səbətdə 2 ədəd var, amma stokda 1

        _mockMehsulRepo.Setup(x => x.GetirAsync(1))
            .ReturnsAsync(mehsul);

        // Act
        var result = await _satisManager.SatisYaratAsync(dto);

        // Assert
        result.UgurluDur.Should().BeFalse();
        result.Mesaj.Should().Contain("kifayət qədər məhsul yoxdur");
        _mockSatisRepo.Verify(x => x.ElaveEtAsync(It.IsAny<Satis>()), Times.Never);
    }

    [Fact]
    public async Task SatisYaratAsync_NullMehsul_ReturnsFailure()
    {
        // Arrange
        var dto = SatisMockFactory.CreateValidYaratDto();
        _mockMehsulRepo.Setup(x => x.GetirAsync(1))
            .ReturnsAsync((Mehsul?)null);

        // Act
        var result = await _satisManager.SatisYaratAsync(dto);

        // Assert
        result.UgurluDur.Should().BeFalse();
        result.Mesaj.Should().Contain("kifayət qədər məhsul yoxdur");
    }

    [Fact]
    public async Task SatisGetirAsync_InvalidSatisNomresi_ReturnsFailure()
    {
        // Arrange
        var invalidNomre = "ABC123"; // Non-numeric

        // Act
        var result = await _satisManager.SatisGetirAsync(invalidNomre);

        // Assert
        result.UgurluDur.Should().BeFalse();
        result.Mesaj.Should().Contain("Yanlış satış nömrəsi formatı");
    }

    [Fact]
    public async Task SatisGetirAsync_NonExistingSatis_ReturnsFailure()
    {
        // Arrange
        _mockSatisRepo.Setup(x => x.GetirAsync(999, It.IsAny<string[]>()))
            .ReturnsAsync((Satis?)null);

        // Act
        var result = await _satisManager.SatisGetirAsync("999");

        // Assert
        result.UgurluDur.Should().BeFalse();
        result.Mesaj.Should().Contain("Satış tapılmadı");
    }
}
