using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Tests.Helpers;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AzAgroPOS.Tests.LogicTests
{
    public class MehsulManagerTests : IDisposable
    {
        private readonly AzAgroPOSDbContext _dbContext;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly MehsulManager _mehsulManager;

        public MehsulManagerTests()
        {
            _dbContext = DbContextHelper.GetInMemoryDbContext();

            _unitOfWorkMock = new Mock<IUnitOfWork>();

            // Setup UnitOfWork mock
            _unitOfWorkMock.Setup(u => u.Mehsullar).Returns(new Mock<IMehsulRepozitori>().Object);
            _unitOfWorkMock.Setup(u => u.EmeliyyatiTesdiqleAsync()).Returns(Task.FromResult(1));

            _mehsulManager = new MehsulManager(_unitOfWorkMock.Object);
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        [Fact]
        public async Task MehsulYaratAsync_UgurluMehsulYaratma()
        {
            // Arrange
            var mehsulDto = new MehsulDto
            {
                Ad = "Yeni Test Məhsulu",
                StokKodu = "SK999",
                Barkod = "999999999999",
                PerakendeSatisQiymeti = 15.50m,
                AlisQiymeti = 12.00m,
                MovcudSay = 100,
                OlcuVahidi = OlcuVahidi.Ədəd
            };

            var mockMehsulRepo = new Mock<IMehsulRepozitori>();
            mockMehsulRepo.Setup(r => r.ElaveEtAsync(It.IsAny<Mehsul>()))
                .Returns(Task.CompletedTask);

            _unitOfWorkMock.Setup(u => u.Mehsullar).Returns(mockMehsulRepo.Object);

            // Act
            var netice = await _mehsulManager.MehsulYaratAsync(mehsulDto);

            // Assert
            Assert.True(netice.UgurluDur);
            mockMehsulRepo.Verify(r => r.ElaveEtAsync(It.IsAny<Mehsul>()), Times.Once);
            _unitOfWorkMock.Verify(u => u.EmeliyyatiTesdiqleAsync(), Times.Once);
        }

        [Fact]
        public async Task MehsulYenileAsync_MovcudMehsulunAnbarMiqdariniYenile()
        {
            // Arrange
            var movcudMehsul = new Mehsul
            {
                Id = 1,
                Ad = "Mövcud Məhsul",
                StokKodu = "SK001",
                Barkod = "869000000001",
                PerakendeSatisQiymeti = 10.00m,
                AlisQiymeti = 8.00m,
                MovcudSay = 50,
                OlcuVahidi = OlcuVahidi.Ədəd
            };

            var mehsulDto = new MehsulDto
            {
                Id = 1,
                Ad = "Mövcud Məhsul",
                StokKodu = "SK001",
                Barkod = "869000000001",
                PerakendeSatisQiymeti = 10.00m,
                AlisQiymeti = 8.00m,
                MovcudSay = 75, // Yenilənmiş miqdar
                OlcuVahidi = OlcuVahidi.Ədəd
            };

            var mockMehsulRepo = new Mock<IMehsulRepozitori>();
            mockMehsulRepo.Setup(r => r.GetirAsync(1))
                .ReturnsAsync(movcudMehsul);
            mockMehsulRepo.Setup(r => r.Yenile(It.IsAny<Mehsul>()))
                .Callback<Mehsul>(m => movcudMehsul.MovcudSay = m.MovcudSay);

            _unitOfWorkMock.Setup(u => u.Mehsullar).Returns(mockMehsulRepo.Object);

            // Act
            var netice = await _mehsulManager.MehsulYenileAsync(mehsulDto);

            // Assert
            Assert.True(netice.UgurluDur);
            Assert.Equal(75, movcudMehsul.MovcudSay);
            mockMehsulRepo.Verify(r => r.GetirAsync(1), Times.Once);
            mockMehsulRepo.Verify(r => r.Yenile(It.IsAny<Mehsul>()), Times.Once);
            _unitOfWorkMock.Verify(u => u.EmeliyyatiTesdiqleAsync(), Times.Once);
        }

        [Fact]
        public async Task MehsulYenileAsync_MehsulTapilmadi_Ugursuz()
        {
            // Arrange
            var mehsulDto = new MehsulDto
            {
                Id = 999, // Mövcud olmayan ID
                Ad = "Yenilənmiş Məhsul",
                StokKodu = "SK999",
                Barkod = "999999999999",
                PerakendeSatisQiymeti = 15.50m,
                AlisQiymeti = 12.00m,
                MovcudSay = 100,
                OlcuVahidi = OlcuVahidi.Ədəd
            };

            var mockMehsulRepo = new Mock<IMehsulRepozitori>();
            mockMehsulRepo.Setup(r => r.GetirAsync(999))
                .ReturnsAsync((Mehsul)null); // Mövcud olmayan məhsul

            _unitOfWorkMock.Setup(u => u.Mehsullar).Returns(mockMehsulRepo.Object);

            // Act
            var netice = await _mehsulManager.MehsulYenileAsync(mehsulDto);

            // Assert
            Assert.False(netice.UgurluDur);
            Assert.Contains("Məhsul tapılmadı", netice.Mesaj);
            mockMehsulRepo.Verify(r => r.GetirAsync(999), Times.Once);
            mockMehsulRepo.Verify(r => r.Yenile(It.IsAny<Mehsul>()), Times.Never);
            _unitOfWorkMock.Verify(u => u.EmeliyyatiTesdiqleAsync(), Times.Never);
        }

        [Fact]
        public async Task MehsulSilAsync_MovcudMehsulSilinir()
        {
            // Arrange
            int mehsulId = 1;
            var movcudMehsul = new Mehsul
            {
                Id = mehsulId,
                Ad = "Silinəcək Məhsul",
                StokKodu = "SK001",
                Barkod = "869000000001",
                PerakendeSatisQiymeti = 10.00m,
                AlisQiymeti = 8.00m,
                MovcudSay = 50,
                OlcuVahidi = OlcuVahidi.Ədəd
            };

            var mockMehsulRepo = new Mock<IMehsulRepozitori>();
            mockMehsulRepo.Setup(r => r.GetirAsync(mehsulId))
                .ReturnsAsync(movcudMehsul);
            mockMehsulRepo.Setup(r => r.Sil(It.IsAny<Mehsul>()));

            _unitOfWorkMock.Setup(u => u.Mehsullar).Returns(mockMehsulRepo.Object);

            // Act
            var netice = await _mehsulManager.MehsulSilAsync(mehsulId);

            // Assert
            Assert.True(netice.UgurluDur);
            mockMehsulRepo.Verify(r => r.GetirAsync(mehsulId), Times.Once);
            mockMehsulRepo.Verify(r => r.Sil(It.IsAny<Mehsul>()), Times.Once);
            _unitOfWorkMock.Verify(u => u.EmeliyyatiTesdiqleAsync(), Times.Once);
        }

        [Fact]
        public async Task MehsulSilAsync_MehsulTapilmadi_Ugursuz()
        {
            // Arrange
            int mehsulId = 999; // Mövcud olmayan ID

            var mockMehsulRepo = new Mock<IMehsulRepozitori>();
            mockMehsulRepo.Setup(r => r.GetirAsync(mehsulId))
                .ReturnsAsync((Mehsul)null); // Mövcud olmayan məhsul

            _unitOfWorkMock.Setup(u => u.Mehsullar).Returns(mockMehsulRepo.Object);

            // Act
            var netice = await _mehsulManager.MehsulSilAsync(mehsulId);

            // Assert
            Assert.False(netice.UgurluDur);
            Assert.Contains("Məhsul tapılmadı", netice.Mesaj);
            mockMehsulRepo.Verify(r => r.GetirAsync(mehsulId), Times.Once);
            mockMehsulRepo.Verify(r => r.Sil(It.IsAny<Mehsul>()), Times.Never);
            _unitOfWorkMock.Verify(u => u.EmeliyyatiTesdiqleAsync(), Times.Never);
        }
    }
}