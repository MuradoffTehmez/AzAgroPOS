// Fayl: AzAgroPOS.Tests/Unit/Managers/MehsulManagerTests.cs

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Tests.TestHelpers;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;

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
        MehsulDto dto = MehsulMockFactory.CreateValidDto();
        _mockMehsulRepo.Setup(x => x.AxtarAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Mehsul, bool>>>(), null))
            .ReturnsAsync(new List<Mehsul>());
        _mockMehsulRepo.Setup(x => x.ElaveEtAsync(It.IsAny<Mehsul>()))
            .Callback<Mehsul>(m => m.Id = 1)  // EF would set the ID after insert
            .Returns(Task.CompletedTask);
        _mockUnitOfWork.Setup(x => x.EmeliyyatiTesdiqleAsync())
            .ReturnsAsync(1);

        // Act
        EmeliyyatNeticesi<int> result = await _mehsulManager.MehsulYaratAsync(dto);

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
        MehsulDto dto = MehsulMockFactory.CreateValidDto();
        dto.Ad = "";

        // Act
        EmeliyyatNeticesi<int> result = await _mehsulManager.MehsulYaratAsync(dto);

        // Assert
        result.UgurluDur.Should().BeFalse();
        result.Mesaj.Should().Contain("Məhsul adı boş ola bilməz");
        _mockMehsulRepo.Verify(x => x.ElaveEtAsync(It.IsAny<Mehsul>()), Times.Never);
    }

    [Fact]
    public async Task MehsulYaratAsync_DuplicateStokKodu_ReturnsFailure()
    {
        // Arrange
        MehsulDto dto = MehsulMockFactory.CreateValidDto();
        Mehsul existingMehsul = MehsulMockFactory.CreateValid();
        _mockMehsulRepo.Setup(x => x.AxtarAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Mehsul, bool>>>(), null))
            .ReturnsAsync(new List<Mehsul> { existingMehsul });

        // Act
        EmeliyyatNeticesi<int> result = await _mehsulManager.MehsulYaratAsync(dto);

        // Assert
        result.UgurluDur.Should().BeFalse();
        result.Mesaj.Should().Contain("stok kodlu məhsul artıq mövcuddur");
        _mockMehsulRepo.Verify(x => x.ElaveEtAsync(It.IsAny<Mehsul>()), Times.Never);
    }

    [Fact]
    public async Task ButunMehsullariGetirAsync_ReturnsAllMehsullar()
    {
        // Arrange
        List<Mehsul> mehsullar = MehsulMockFactory.CreateList(5);
        _mockMehsulRepo.Setup(x => x.ButununuGetirAsync())
            .ReturnsAsync(mehsullar);

        // Act
        EmeliyyatNeticesi<IEnumerable<MehsulDto>> result = await _mehsulManager.ButunMehsullariGetirAsync();

        // Assert
        result.UgurluDur.Should().BeTrue();
        result.Data.Should().HaveCount(5);
        _mockMehsulRepo.Verify(x => x.ButununuGetirAsync(), Times.Once);
    }

    [Fact]
    public async Task MehsulSilAsync_ValidId_SoftDeletesSuccessfully()
    {
        // Arrange
        Mehsul mehsul = MehsulMockFactory.CreateValid(1);
        _mockMehsulRepo.Setup(x => x.GetirAsync(1))
            .ReturnsAsync(mehsul);
        _mockMehsulRepo.Setup(x => x.Sil(It.IsAny<Mehsul>()))
            .Callback<Mehsul>(m => m.Silinib = true);  // Sil() sets Silinib = true
        _mockUnitOfWork.Setup(x => x.EmeliyyatiTesdiqleAsync())
            .ReturnsAsync(1);

        // Act
        EmeliyyatNeticesi result = await _mehsulManager.MehsulSilAsync(1);

        // Assert
        result.UgurluDur.Should().BeTrue();
        mehsul.Silinib.Should().BeTrue();
        _mockMehsulRepo.Verify(x => x.Sil(mehsul), Times.Once);
        _mockUnitOfWork.Verify(x => x.EmeliyyatiTesdiqleAsync(), Times.Once);
    }
}
