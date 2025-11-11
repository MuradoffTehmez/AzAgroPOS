// Fayl: AzAgroPOS.Tests/Unit/Managers/MehsulManagerTests.cs

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Tests.TestHelpers;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using FluentAssertions;
using Moq;

namespace AzAgroPOS.Tests.Unit.Managers;

/// <summary>
/// MehsulManager üçün unit test-lər
/// </summary>
public class MehsulManagerTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<IMehsulRepozitori> _mockMehsulRepo;
    private readonly MehsulManager _mehsulManager;

    public MehsulManagerTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockMehsulRepo = new Mock<IMehsulRepozitori>();
        _mockUnitOfWork.Setup(x => x.Mehsullar).Returns(_mockMehsulRepo.Object);
        _mehsulManager = new MehsulManager(_mockUnitOfWork.Object);
    }

    [Fact]
    public async Task MehsulYaratAsync_ValidMehsul_ReturnsSuccess()
    {
        // Arrange
        var dto = MehsulMockFactory.CreateValidDto();
        _mockMehsulRepo.Setup(x => x.AxtarAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Mehsul, bool>>>(), null))
            .ReturnsAsync(new List<Mehsul>());
        _mockMehsulRepo.Setup(x => x.ElaveEtAsync(It.IsAny<Mehsul>()))
            .Callback<Mehsul>(m => m.Id = 1)  // EF would set the ID after insert
            .Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(x => x.EmeliyyatiTesdiqleAsync())
            .ReturnsAsync(1);

        // Act
        var result = await _mehsulManager.MehsulYaratAsync(dto);

        // Assert
        result.UgurluDur.Should().BeTrue();
        result.Data.Should().BeGreaterThan(0);
        _mockMehsulRepo.Verify(x => x.ElaveEtAsync(It.IsAny<Mehsul>()), Times.Once);
        _mockUnitOfWork.Verify(x => x.EmeliyyatiTesdiqleAsync(), Times.Once);
    }

    [Fact]
    public async Task MehsulYaratAsync_EmptyAd_ReturnsFailure()
    {
        // Arrange
        var dto = MehsulMockFactory.CreateValidDto();
        dto.Ad = "";

        // Act
        var result = await _mehsulManager.MehsulYaratAsync(dto);

        // Assert
        result.UgurluDur.Should().BeFalse();
        result.Mesaj.Should().Contain("Məhsul adı boş ola bilməz");
        _mockMehsulRepo.Verify(x => x.ElaveEtAsync(It.IsAny<Mehsul>()), Times.Never);
    }

    [Fact]
    public async Task MehsulYaratAsync_DuplicateStokKodu_ReturnsFailure()
    {
        // Arrange
        var dto = MehsulMockFactory.CreateValidDto();
        var existingMehsul = MehsulMockFactory.CreateValid();
        _mockMehsulRepo.Setup(x => x.AxtarAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Mehsul, bool>>>(), null))
            .ReturnsAsync(new List<Mehsul> { existingMehsul });

        // Act
        var result = await _mehsulManager.MehsulYaratAsync(dto);

        // Assert
        result.UgurluDur.Should().BeFalse();
        result.Mesaj.Should().Contain("stok kodlu məhsul artıq mövcuddur");
        _mockMehsulRepo.Verify(x => x.ElaveEtAsync(It.IsAny<Mehsul>()), Times.Never);
    }

    [Fact]
    public async Task ButunMehsullariGetirAsync_ReturnsAllMehsullar()
    {
        // Arrange
        var mehsullar = MehsulMockFactory.CreateList(5);
        _mockMehsulRepo.Setup(x => x.ButununuGetirAsync())
            .ReturnsAsync(mehsullar);

        // Act
        var result = await _mehsulManager.ButunMehsullariGetirAsync();

        // Assert
        result.UgurluDur.Should().BeTrue();
        result.Data.Should().HaveCount(5);
        _mockMehsulRepo.Verify(x => x.ButununuGetirAsync(), Times.Once);
    }

    [Fact]
    public async Task MehsulSilAsync_ValidId_SoftDeletesSuccessfully()
    {
        // Arrange
        var mehsul = MehsulMockFactory.CreateValid(1);
        _mockMehsulRepo.Setup(x => x.GetirAsync(1))
            .ReturnsAsync(mehsul);
        _mockMehsulRepo.Setup(x => x.Sil(It.IsAny<Mehsul>()))
            .Callback<Mehsul>(m => m.Silinib = true);  // Sil() sets Silinib = true
        _mockUnitOfWork.Setup(x => x.EmeliyyatiTesdiqleAsync())
            .ReturnsAsync(1);

        // Act
        var result = await _mehsulManager.MehsulSilAsync(1);

        // Assert
        result.UgurluDur.Should().BeTrue();
        mehsul.Silinib.Should().BeTrue();
        _mockMehsulRepo.Verify(x => x.Sil(mehsul), Times.Once);
        _mockUnitOfWork.Verify(x => x.EmeliyyatiTesdiqleAsync(), Times.Once);
    }
}
