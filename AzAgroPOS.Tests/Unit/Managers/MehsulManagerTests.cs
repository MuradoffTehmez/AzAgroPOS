// Fayl: AzAgroPOS.Tests/Unit/Managers/MehsulManagerTests.cs

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Tests.TestHelpers;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;

namespace AzAgroPOS.Tests.Unit.Managers;

public class MehsulManagerTests : IDisposable
{
    private readonly AzAgroPOSDbContext _context;
    private readonly IUnitOfWork _unitOfWork;
    private readonly MehsulManager _manager;

    public MehsulManagerTests()
    {
        _context = InMemoryDbContextFactory.Create();
        _unitOfWork = new UnitOfWork(_context);
        _manager = new MehsulManager(_unitOfWork);
    }

    public void Dispose()
    {
        _unitOfWork.Dispose();
        InMemoryDbContextFactory.Destroy(_context);
    }

    [Fact]
    public async Task ButunMehsullariGetirAsync_ReturnsAllProducts()
    {
        // Arrange
        var mehsullar = MockData.CreateMehsulList(3);
        foreach (var mehsul in mehsullar)
        {
            await _unitOfWork.Mehsullar.ElaveEtAsync(mehsul);
        }
        await _unitOfWork.TamamlaAsync();

        // Act
        var result = await _manager.ButunMehsullariGetirAsync();

        // Assert
        result.UgurluDur.Should().BeTrue();
        result.Data.Should().HaveCount(3);
    }

    [Fact]
    public async Task MehsulYaratAsync_ValidDto_CreatesProduct()
    {
        // Arrange
        var dto = new MehsulDto
        {
            Ad = "Yeni Məhsul",
            StokKodu = "NEW001",
            Barkod = "BAR001",
            PerakendeSatisQiymeti = 150m,
            TopdanSatisQiymeti = 120m,
            TekEdedSatisQiymeti = 140m,
            AlisQiymeti = 100m,
            MovcudSay = 10,
            OlcuVahidi = "Ədəd"
        };

        // Act
        var result = await _manager.MehsulYaratAsync(dto);

        // Assert
        result.UgurluDur.Should().BeTrue();
        result.Data.Should().BeGreaterThan(0);

        var created = await _unitOfWork.Mehsullar.GetirAsync(result.Data);
        created.Should().NotBeNull();
        created!.Ad.Should().Be("Yeni Məhsul");
    }

    [Fact]
    public async Task MehsulYaratAsync_EmptyAd_ReturnsError()
    {
        // Arrange
        var dto = new MehsulDto
        {
            Ad = "",
            StokKodu = "TEST001"
        };

        // Act
        var result = await _manager.MehsulYaratAsync(dto);

        // Assert
        result.UgurluDur.Should().BeFalse();
        result.XetaMesaji.Should().Contain("boş ola bilməz");
    }

    [Fact]
    public async Task MehsulYaratAsync_DuplicateStokKodu_ReturnsError()
    {
        // Arrange
        var existingMehsul = MockData.CreateMehsul(1, "Mövcud Məhsul", "DUP001");
        await _unitOfWork.Mehsullar.ElaveEtAsync(existingMehsul);
        await _unitOfWork.TamamlaAsync();

        var dto = new MehsulDto
        {
            Ad = "Yeni Məhsul",
            StokKodu = "DUP001" // Eyni stok kodu
        };

        // Act
        var result = await _manager.MehsulYaratAsync(dto);

        // Assert
        result.UgurluDur.Should().BeFalse();
        result.XetaMesaji.Should().Contain("mövcuddur");
    }

    [Fact]
    public async Task MehsulGuncelleAsync_ValidDto_UpdatesProduct()
    {
        // Arrange
        var mehsul = MockData.CreateMehsul();
        await _unitOfWork.Mehsullar.ElaveEtAsync(mehsul);
        await _unitOfWork.TamamlaAsync();

        var dto = new MehsulDto
        {
            Id = mehsul.Id,
            Ad = "Yenilənmiş Ad",
            StokKodu = mehsul.StokKodu,
            Barkod = mehsul.Barkod,
            PerakendeSatisQiymeti = 200m,
            TopdanSatisQiymeti = 150m,
            TekEdedSatisQiymeti = 180m,
            AlisQiymeti = 100m,
            MovcudSay = 30,
            OlcuVahidi = "Ədəd"
        };

        // Act
        var result = await _manager.MehsulGuncelleAsync(dto);

        // Assert
        result.UgurluDur.Should().BeTrue();

        var updated = await _unitOfWork.Mehsullar.GetirAsync(mehsul.Id);
        updated!.Ad.Should().Be("Yenilənmiş Ad");
        updated.PerakendeSatisQiymeti.Should().Be(200m);
    }

    [Fact]
    public async Task MehsulSilAsync_ExistingId_SoftDeletesProduct()
    {
        // Arrange
        var mehsul = MockData.CreateMehsul();
        await _unitOfWork.Mehsullar.ElaveEtAsync(mehsul);
        await _unitOfWork.TamamlaAsync();

        // Act
        var result = await _manager.MehsulSilAsync(mehsul.Id);

        // Assert
        result.UgurluDur.Should().BeTrue();

        var deleted = await _unitOfWork.Mehsullar.GetirAsync(mehsul.Id);
        deleted.Should().BeNull(); // Soft deleted
    }
}
