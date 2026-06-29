// Fayl: AzAgroPOS.Tests/Mentiq/Idareciler/TehlukesizlikManagerTests.cs

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;

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
        string istifadeciAdi = "";
        string parol = "test123";

        // Act
        EmeliyyatNeticesi<IstifadeciDto> netice = await _manager.DaxilOlAsync(istifadeciAdi, parol);

        // Assert
        netice.UgurluDur.Should().BeFalse();
        netice.Mesaj.Should().Contain("boş ola bilməz");
    }

    [Fact]
    public async Task DaxilOlAsync_BosParol_UgursuzNeticeQaytar()
    {
        // Arrange
        string istifadeciAdi = "admin";
        string parol = "";

        // Act
        EmeliyyatNeticesi<IstifadeciDto> netice = await _manager.DaxilOlAsync(istifadeciAdi, parol);

        // Assert
        netice.UgurluDur.Should().BeFalse();
        netice.Mesaj.Should().Contain("boş ola bilməz");
    }

    [Fact]
    public async Task DaxilOlAsync_IstifadeciTapilmadi_UgursuzNeticeQaytar()
    {
        // Arrange
        string istifadeciAdi = "neexistuser";
        string parol = "test123";

        _mockIstifadeciRepo
            .Setup(x => x.AxtarAsync(It.IsAny<System.Linq.Expressions.Expression<Func<Istifadeci, bool>>>(), null))
            .ReturnsAsync(new List<Istifadeci>());

        // Act
        EmeliyyatNeticesi<IstifadeciDto> netice = await _manager.DaxilOlAsync(istifadeciAdi, parol);

        // Assert
        netice.UgurluDur.Should().BeFalse();
        netice.Mesaj.Should().Contain("yanlışdır");
    }

    [Fact]
    public async Task DaxilOlAsync_HesabDeaktiv_UgursuzNeticeQaytar()
    {
        // Arrange
        string istifadeciAdi = "admin";
        string parol = "test123";
        string parolHash = BCrypt.Net.BCrypt.HashPassword(parol);

        Istifadeci istifadeci = new()
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
        EmeliyyatNeticesi<IstifadeciDto> netice = await _manager.DaxilOlAsync(istifadeciAdi, parol);

        // Assert
        netice.UgurluDur.Should().BeFalse();
        netice.Mesaj.Should().Contain("deaktiv");
    }

    [Fact]
    public async Task DaxilOlAsync_HesabKilidlenmis_UgursuzNeticeQaytar()
    {
        // Arrange
        string istifadeciAdi = "admin";
        string parol = "test123";
        string parolHash = BCrypt.Net.BCrypt.HashPassword(parol);

        Istifadeci istifadeci = new()
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
        EmeliyyatNeticesi<IstifadeciDto> netice = await _manager.DaxilOlAsync(istifadeciAdi, parol);

        // Assert
        netice.UgurluDur.Should().BeFalse();
        netice.Mesaj.Should().Contain("kilidlənib");
    }

    [Fact]
    public async Task DaxilOlAsync_YanlisParol_UgursuzNeticeQaytar()
    {
        // Arrange
        string istifadeciAdi = "admin";
        string dogruParol = "test123";
        string yanlisParol = "wrong123";
        string parolHash = BCrypt.Net.BCrypt.HashPassword(dogruParol);

        Istifadeci istifadeci = new()
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
        EmeliyyatNeticesi<IstifadeciDto> netice = await _manager.DaxilOlAsync(istifadeciAdi, yanlisParol);

        // Assert
        netice.UgurluDur.Should().BeFalse();
        netice.Mesaj.Should().Contain("yanlışdır");
        _mockIstifadeciRepo.Verify(x => x.Yenile(It.IsAny<Istifadeci>()), Times.Once);
    }

    [Fact]
    public async Task DaxilOlAsync_DogruMelumatlar_UgurluNeticeQaytar()
    {
        // Arrange
        string istifadeciAdi = "admin";
        string parol = "test123";
        string parolHash = BCrypt.Net.BCrypt.HashPassword(parol);

        Istifadeci istifadeci = new()
        {
            Id = 1,
            IstifadeciAdi = istifadeciAdi,
            TamAd = "Admin İstifadəçi",
            ParolHash = parolHash,
            HesabAktivdir = true,
            UgursuzGirisCehdi = 0,
            RolId = 1
        };

        Rol rol = new()
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
        EmeliyyatNeticesi<IstifadeciDto> netice = await _manager.DaxilOlAsync(istifadeciAdi, parol);

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
        int istifadeciId = 1;
        string kohneParol = "wrong";
        string yeniParol = "newpass123A@";
        string parolHash = BCrypt.Net.BCrypt.HashPassword("correctold");

        Istifadeci istifadeci = new()
        {
            Id = istifadeciId,
            ParolHash = parolHash
        };

        _mockIstifadeciRepo
            .Setup(x => x.GetirAsync(istifadeciId))
            .ReturnsAsync(istifadeci);

        // Act
        EmeliyyatNeticesi netice = await _manager.SifreDeyisAsync(istifadeciId, kohneParol, yeniParol);

        // Assert
        netice.UgurluDur.Should().BeFalse();
        netice.Mesaj.Should().Contain("Köhnə şifrə yanlışdır");
    }

    [Fact]
    public async Task SifreDeyisAsync_YeniParolZeif_UgursuzNeticeQaytar()
    {
        // Arrange
        int istifadeciId = 1;
        string kohneParol = "oldpass123";
        string yeniParol = "123"; // Çox qısa
        string parolHash = BCrypt.Net.BCrypt.HashPassword(kohneParol);

        Istifadeci istifadeci = new()
        {
            Id = istifadeciId,
            ParolHash = parolHash
        };

        _mockIstifadeciRepo
            .Setup(x => x.GetirAsync(istifadeciId))
            .ReturnsAsync(istifadeci);

        // Act
        EmeliyyatNeticesi netice = await _manager.SifreDeyisAsync(istifadeciId, kohneParol, yeniParol);

        // Assert
        netice.UgurluDur.Should().BeFalse();
        netice.Mesaj.Should().Contain("8 simvoldan");
    }

    public void Dispose()
    {
        // Cleanup if needed
    }
}
