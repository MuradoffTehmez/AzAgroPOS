using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using Microsoft.Extensions.DependencyInjection;

namespace AzAgroPOS.Tests.Unit.Managers;

public class AlisManagerScopeTests
{
    [Fact]
    public async Task ButunAlisSifarisleriniGetirAsync_AsyncOnlyScopeIleIsleyir()
    {
        Mock<IUnitOfWork> unitOfWork = new();
        Mock<IAlisSifarisRepozitori> sifarisler = new();
        Mock<ITedarukcuRepozitori> tedarukculer = new();
        sifarisler.Setup(x => x.ButununuGetirAsync()).ReturnsAsync(Array.Empty<AlisSifaris>());
        tedarukculer.Setup(x => x.ButununuGetirAsync()).ReturnsAsync(Array.Empty<Tedarukcu>());
        unitOfWork.Setup(x => x.AlisSifarisleri).Returns(sifarisler.Object);
        unitOfWork.Setup(x => x.Tedarukculer).Returns(tedarukculer.Object);
        ServiceCollection services = new();
        services.AddScoped<IUnitOfWork>(_ => unitOfWork.Object);
        await using ServiceProvider provider = services.BuildServiceProvider();
        StokHareketiManager stokManager = new(unitOfWork.Object, new Mock<IStokHareketiRepozitori>().Object);
        AlisManager manager = new(unitOfWork.Object, stokManager, provider);

        var netice = await manager.ButunAlisSifarisleriniGetirAsync();

        netice.UgurluDur.Should().BeTrue();
        netice.Data.Should().BeEmpty();
    }
}
