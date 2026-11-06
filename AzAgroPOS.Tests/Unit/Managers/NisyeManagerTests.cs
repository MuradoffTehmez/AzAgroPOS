using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;

namespace AzAgroPOS.Tests.Unit.Managers;

public class NisyeManagerTests
{
    [Fact]
    public async Task EvvelkiBorcElaveEtAsync_BalansiVeHereketiBirlikdeYazir()
    {
        Mock<IUnitOfWork> unitOfWork = new();
        Mock<IMusteriRepozitori> musteriler = new();
        Mock<INisyeHereketiRepozitori> hereketler = new();
        Mock<IIstifadeciRepozitori> istifadeciler = new();
        Musteri musteri = new() { Id = 7, TamAd = "Test", UmumiBorc = 25m };
        NisyeHereketi? yazilanHereket = null;
        unitOfWork.Setup(x => x.Musteriler).Returns(musteriler.Object);
        unitOfWork.Setup(x => x.NisyeHereketleri).Returns(hereketler.Object);
        unitOfWork.Setup(x => x.Istifadeciler).Returns(istifadeciler.Object);
        istifadeciler.Setup(x => x.GetirAsync(1)).ReturnsAsync(new Istifadeci { Id = 1, RolId = 1 });
        musteriler.Setup(x => x.GetirAsync(7)).ReturnsAsync(musteri);
        hereketler.Setup(x => x.ElaveEtAsync(It.IsAny<NisyeHereketi>()))
            .Callback<NisyeHereketi>(h => yazilanHereket = h)
            .Returns(Task.CompletedTask);
        unitOfWork.Setup(x => x.EmeliyyatiTesdiqleAsync()).ReturnsAsync(1);

        var netice = await new NisyeManager(unitOfWork.Object).EvvelkiBorcElaveEtAsync(7, 10.50m, "köhnə qeyd", 1, DateTime.Today.AddMonths(-1));

        netice.UgurluDur.Should().BeTrue();
        musteri.UmumiBorc.Should().Be(35.50m);
        yazilanHereket.Should().NotBeNull();
        yazilanHereket!.EmeliyyatNovu.Should().Be(EmeliyyatNovu.IlkinBorc);
        yazilanHereket.Mebleg.Should().Be(10.50m);
        yazilanHereket.Qeyd.Should().Contain("köhnə qeyd");
        unitOfWork.Verify(x => x.EmeliyyatiTesdiqleAsync(), Times.Once);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-5)]
    [InlineData(1.001)]
    public async Task EvvelkiBorcElaveEtAsync_YanlisMeblegiQebulEtmir(decimal mebleg)
    {
        Mock<IUnitOfWork> unitOfWork = new();

        var netice = await new NisyeManager(unitOfWork.Object).EvvelkiBorcElaveEtAsync(7, mebleg, null, 1, DateTime.Today);

        netice.UgurluDur.Should().BeFalse();
        unitOfWork.Verify(x => x.EmeliyyatiTesdiqleAsync(), Times.Never);
    }
}
