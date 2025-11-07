// Fayl: AzAgroPOS.Tests/Mentiq/Idareciler/TehlukesizlikManagerTests.cs

using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Mentiq.Istisnalar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using Microsoft.EntityFrameworkCore;

namespace AzAgroPOS.Tests.Mentiq.Idareciler;

public class TehlukesizlikManagerTests : IDisposable
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<IIstifadeciRepozitori> _mockIstifadeciRepo;
    private readonly Mock<IRolRepozitori> _mockRolRepo;
    private readonly TehlukesizlikManager _manager;

    public TehlukesizlikManagerTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockIstifadeciRepo = new Mock<IIstifadeciRepozitori>();
        _mockRolRepo = new Mock<IRolRepozitori>();

        _mockUnitOfWork.Setup(x => x.Istifadeciler).Returns(_mockIstifadeciRepo.Object);
        _mockUnitOfWork.Setup(x => x.Rollar).Returns(_mockRolRepo.Object);

        _manager = new TehlukesizlikManager(_mockUnitOfWork.Object);
    }

    [Fact]
    public async Task DaxilOlAsync_BosIstifadeciAdi_UgursuzNeticeQaytar()
    {
        // Arrange
        var istifadeciAdi = "";
        var parol = "test123";

        // Act
        var netice = await _manager.DaxilOlAsync(istifadeciAdi, parol);

        // Assert
        netice.UgurluDur.Should().BeFalse();
        netice.Mesaj.Should().Contain("boş ola bilməz");
    }

    [Fact]
    public async Task DaxilOlAsync_BosParol_UgursuzNeticeQaytar()
    {
        // Arrange
        var istifadeciAdi = "admin";
        var parol = "";

        // Act
        var netice = await _manager.DaxilOlAsync(istifadeciAdi, parol);

        // Assert
        netice.UgurluDur.Should().BeFalse();
        netice.Mesaj.Should().Contain("boş ola bilməz");
    }

    [Fact]
    public async Task DaxilOlAsync_IstifadeciTapilmadi_UgursuzNeticeQaytar()
    {
        // Arrange
        var istifadeciAdi = "neexistuser";
        var parol = "test123";

        _mockIstifadeciRepo
            .Setup(x => x.AxtarAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Istifadeci, bool>>>(), null))
            .ReturnsAsync(new List<Istifadeci>());

        // Act
        var netice = await _manager.DaxilOlAsync(istifadeciAdi, parol);

        // Assert
        netice.UgurluDur.Should().BeFalse();
        netice.Mesaj.Should().Contain("yanlışdır");
    }

    [Fact]
    public async Task DaxilOlAsync_HesabDeaktiv_UgursuzNeticeQaytar()
    {
        // Arrange
        var istifadeciAdi = "admin";
        var parol = "test123";
        var parolHash = BCrypt.Net.BCrypt.HashPassword(parol);

        var istifadeci = new Istifadeci
        {
            Id = 1,
            IstifadeciAdi = istifadeciAdi,
            ParolHash = parolHash,
            HesabAktivdir = false, // Deaktiv
            RolId = 1
        };

        _mockIstifadeciRepo
            .Setup(x => x.AxtarAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Istifadeci, bool>>>(), null))
            .ReturnsAsync(new List<Istifadeci> { istifadeci });

        // Act
        var netice = await _manager.DaxilOlAsync(istifadeciAdi, parol);

        // Assert
        netice.UgurluDur.Should().BeFalse();
        netice.Mesaj.Should().Contain("deaktiv");
    }

    [Fact]
    public async Task DaxilOlAsync_HesabKilidlenmis_UgursuzNeticeQaytar()
    {
        // Arrange
        var istifadeciAdi = "admin";
        var parol = "test123";
        var parolHash = BCrypt.Net.BCrypt.HashPassword(parol);

        var istifadeci = new Istifadeci
        {
            Id = 1,
            IstifadeciAdi = istifadeciAdi,
            ParolHash = parolHash,
            HesabAktivdir = true,
            HesabKilidlenmeTarixi = DateTime.Now.AddMinutes(-10), // 10 dəqiqə əvvəl kilidlənib
            RolId = 1
        };

        _mockIstifadeciRepo
            .Setup(x => x.AxtarAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Istifadeci, bool>>>(), null))
            .ReturnsAsync(new List<Istifadeci> { istifadeci });

        // Act
        var netice = await _manager.DaxilOlAsync(istifadeciAdi, parol);

        // Assert
        netice.UgurluDur.Should().BeFalse();
        netice.Mesaj.Should().Contain("kilidlənib");
    }

    [Fact]
    public async Task DaxilOlAsync_YanlisParol_UgursuzNeticeQaytar()
    {
        // Arrange
        var istifadeciAdi = "admin";
        var dogruParol = "test123";
        var yanlisParol = "wrong123";
        var parolHash = BCrypt.Net.BCrypt.HashPassword(dogruParol);

        var istifadeci = new Istifadeci
        {
            Id = 1,
            IstifadeciAdi = istifadeciAdi,
            ParolHash = parolHash,
            HesabAktivdir = true,
            UgursuzGirisCehdi = 0,
            RolId = 1
        };

        _mockIstifadeciRepo
            .Setup(x => x.AxtarAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Istifadeci, bool>>>(), null))
            .ReturnsAsync(new List<Istifadeci> { istifadeci });

        // Act
        var netice = await _manager.DaxilOlAsync(istifadeciAdi, yanlisParol);

        // Assert
        netice.UgurluDur.Should().BeFalse();
        netice.Mesaj.Should().Contain("yanlışdır");
        _mockIstifadeciRepo.Verify(x => x.Yenile(It.IsAny<Istifadeci>()), Times.Once);
    }

    [Fact]
    public async Task DaxilOlAsync_DogruMelumatlar_UgurluNeticeQaytar()
    {
        // Arrange
        var istifadeciAdi = "admin";
        var parol = "test123";
        var parolHash = BCrypt.Net.BCrypt.HashPassword(parol);

        var istifadeci = new Istifadeci
        {
            Id = 1,
            IstifadeciAdi = istifadeciAdi,
            TamAd = "Admin İstifadəçi",
            ParolHash = parolHash,
            HesabAktivdir = true,
            UgursuzGirisCehdi = 0,
            RolId = 1
        };

        var rol = new Rol
        {
            Id = 1,
            Ad = "Administrator"
        };

        _mockIstifadeciRepo
            .Setup(x => x.AxtarAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Istifadeci, bool>>>(), null))
            .ReturnsAsync(new List<Istifadeci> { istifadeci });

        _mockRolRepo
            .Setup(x => x.GetirAsync(1))
            .ReturnsAsync(rol);

        // Act
        var netice = await _manager.DaxilOlAsync(istifadeciAdi, parol);

        // Assert
        netice.UgurluDur.Should().BeTrue();
        netice.Data.Should().NotBeNull();
        netice.Data.IstifadeciAdi.Should().Be(istifadeciAdi);
        netice.Data.RolAdi.Should().Be("Administrator");
        _mockIstifadeciRepo.Verify(x => x.Yenile(It.IsAny<Istifadeci>()), Times.Once);
        _mockUnitOfWork.Verify(x => x.EmeliyyatiTesdiqleAsync(), Times.Once);
    }

    [Fact]
    public async Task SifreDeyisAsync_KohneParolYanlis_UgursuzNeticeQaytar()
    {
        // Arrange
        var istifadeciId = 1;
        var kohneParol = "wrong";
        var yeniParol = "newpass123A@";
        var parolHash = BCrypt.Net.BCrypt.HashPassword("correctold");

        var istifadeci = new Istifadeci
        {
            Id = istifadeciId,
            ParolHash = parolHash
        };

        _mockIstifadeciRepo
            .Setup(x => x.GetirAsync(istifadeciId))
            .ReturnsAsync(istifadeci);

        // Act
        var netice = await _manager.SifreDeyisAsync(istifadeciId, kohneParol, yeniParol);

        // Assert
        netice.UgurluDur.Should().BeFalse();
        netice.Mesaj.Should().Contain("Köhnə şifrə yanlışdır");
    }

    [Fact]
    public async Task SifreDeyisAsync_YeniParolZeif_UgursuzNeticeQaytar()
    {
        // Arrange
        var istifadeciId = 1;
        var kohneParol = "oldpass123";
        var yeniParol = "123"; // Çox qısa
        var parolHash = BCrypt.Net.BCrypt.HashPassword(kohneParol);

        var istifadeci = new Istifadeci
        {
            Id = istifadeciId,
            ParolHash = parolHash
        };

        _mockIstifadeciRepo
            .Setup(x => x.GetirAsync(istifadeciId))
            .ReturnsAsync(istifadeci);

        // Act
        var netice = await _manager.SifreDeyisAsync(istifadeciId, kohneParol, yeniParol);

        // Assert
        netice.UgurluDur.Should().BeFalse();
        netice.Mesaj.Should().Contain("8 simvoldan");
    }

    public void Dispose()
    {
        // Cleanup if needed
    }
}
