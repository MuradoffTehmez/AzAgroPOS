// Fayl: AzAgroPOS.Tests/Unit/Repositories/RepozitoriTests.cs

using AzAgroPOS.Tests.TestHelpers;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;

namespace AzAgroPOS.Tests.Unit.Repositories;

public class RepozitoriTests : IDisposable
{
    private readonly AzAgroPOSDbContext _context;
    private readonly Repozitori<Mehsul> _repository;

    public RepozitoriTests()
    {
        _context = InMemoryDbContextFactory.Create();
        _repository = new Repozitori<Mehsul>(_context);
    }

    public void Dispose()
    {
        _repository.Dispose();
        InMemoryDbContextFactory.Destroy(_context);
    }

    [Fact]
    public async Task ElaveEtAsync_ValidEntity_AddsToDatabase()
    {
        // Arrange
        var mehsul = MockData.CreateMehsul();

        // Act
        await _repository.ElaveEtAsync(mehsul);
        await _context.SaveChangesAsync();

        // Assert
        var result = await _repository.GetirAsync(mehsul.Id);
        result.Should().NotBeNull();
        result!.Ad.Should().Be("Test Məhsul");
    }

    [Fact]
    public async Task GetirAsync_ExistingId_ReturnsEntity()
    {
        // Arrange
        var mehsul = MockData.CreateMehsul();
        await _repository.ElaveEtAsync(mehsul);
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.GetirAsync(mehsul.Id);

        // Assert
        result.Should().NotBeNull();
        result!.Id.Should().Be(mehsul.Id);
        result.Ad.Should().Be(mehsul.Ad);
    }

    [Fact]
    public async Task GetirAsync_NonExistingId_ReturnsNull()
    {
        // Act
        var result = await _repository.GetirAsync(999);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task ButununuGetirAsync_ReturnsAllNonDeletedEntities()
    {
        // Arrange
        var mehsullar = MockData.CreateMehsulList(5);
        foreach (var mehsul in mehsullar)
        {
            await _repository.ElaveEtAsync(mehsul);
        }
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.ButununuGetirAsync();

        // Assert
        result.Should().HaveCount(5);
    }

    [Fact]
    public async Task Sil_SoftDeletesEntity()
    {
        // Arrange
        var mehsul = MockData.CreateMehsul();
        await _repository.ElaveEtAsync(mehsul);
        await _context.SaveChangesAsync();

        // Act
        _repository.Sil(mehsul);
        await _context.SaveChangesAsync();

        // Assert
        var result = await _repository.GetirAsync(mehsul.Id);
        result.Should().BeNull(); // Soft deleted, so should not be returned

        var deleted = (await _repository.SilinmisleriGetirAsync()).FirstOrDefault(m => m.Id == mehsul.Id);
        deleted.Should().NotBeNull();
        deleted!.Silinib.Should().BeTrue();
    }

    [Fact]
    public async Task AxtarAsync_WithFilter_ReturnsMatchingEntities()
    {
        // Arrange
        var mehsullar = MockData.CreateMehsulList(5);
        foreach (var mehsul in mehsullar)
        {
            await _repository.ElaveEtAsync(mehsul);
        }
        await _context.SaveChangesAsync();

        // Act
        var result = await _repository.AxtarAsync(m => m.Ad.Contains("Məhsul 2"));

        // Assert
        result.Should().HaveCount(1);
        result.First().Ad.Should().Be("Məhsul 2");
    }

    [Fact]
    public async Task SehifelenmisGetirAsync_ReturnsPaginatedResults()
    {
        // Arrange
        var mehsullar = MockData.CreateMehsulList(20);
        foreach (var mehsul in mehsullar)
        {
            await _repository.ElaveEtAsync(mehsul);
        }
        await _context.SaveChangesAsync();

        // Act
        var (melumatlar, umumiSay) = await _repository.SehifelenmisGetirAsync(
            sehifeNomresi: 2,
            sehifeOlcusu: 5);

        // Assert
        umumiSay.Should().Be(20);
        melumatlar.Should().HaveCount(5);
        melumatlar.First().Id.Should().Be(6); // Səhifə 2, ilk element ID 6
    }
}
