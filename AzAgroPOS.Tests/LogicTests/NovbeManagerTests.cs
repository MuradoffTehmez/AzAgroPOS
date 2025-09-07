// AzAgroPOS.Tests/LogicTests/NovbeManagerTests.cs

using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Tests.Helpers;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace AzAgroPOS.Tests.LogicTests
{
    public class NovbeManagerTests : IDisposable
    {
        private readonly AzAgroPOSDbContext _dbContext;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly NovbeManager _novbeManager;

        public NovbeManagerTests()
        {
            _dbContext = DbContextHelper.GetInMemoryDbContext();

            _unitOfWorkMock = new Mock<IUnitOfWork>();

            // Setup UnitOfWork mock
            _unitOfWorkMock.Setup(u => u.Novbeler).Returns(new Mock<INovbeRepozitori>().Object);
            _unitOfWorkMock.Setup(u => u.Istifadeciler).Returns(new Mock<IIstifadeciRepozitori>().Object);
            _unitOfWorkMock.Setup(u => u.Satislar).Returns(new Mock<ISatisRepozitori>().Object);
            _unitOfWorkMock.Setup(u => u.EmeliyyatiTesdiqleAsync()).Returns(Task.FromResult(1));

            _novbeManager = new NovbeManager(_unitOfWorkMock.Object);
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        [Fact]
        public async Task NovbeAcAsync_UgurluNovbeAcma()
        {
            // Arrange
            int isciId = 1;
            decimal baslangicMebleg = 100.00m;

            var isci = new Istifadeci
            {
                Id = isciId,
                TamAd = "Test Kassir"
            };

            var mockIsciRepo = new Mock<IIstifadeciRepozitori>();
            mockIsciRepo.Setup(r => r.GetirAsync(isciId))
                .ReturnsAsync(isci);

            var mockNovbeRepo = new Mock<INovbeRepozitori>();
            mockNovbeRepo.Setup(r => r.ElaveEtAsync(It.IsAny<Novbe>()))
                .Returns(Task.CompletedTask);

            _unitOfWorkMock.Setup(u => u.Istifadeciler).Returns(mockIsciRepo.Object);
            _unitOfWorkMock.Setup(u => u.Novbeler).Returns(mockNovbeRepo.Object);

            // Act
            var netice = await _novbeManager.NovbeAcAsync(isciId, baslangicMebleg);

            // Assert
            Assert.True(netice.UgurluDur);
            Assert.NotNull(netice.Data);
            Assert.Equal(isciId, netice.Data.IsciId);
            Assert.Equal(baslangicMebleg, netice.Data.BaslangicMebleg);
            Assert.Equal(baslangicMebleg, netice.Data.GozlenilenMebleg);
            Assert.Equal(0.00m, netice.Data.FaktikiMebleg);
            Assert.Equal(NovbeStatusu.Aciq, netice.Data.Status);
            mockNovbeRepo.Verify(r => r.ElaveEtAsync(It.IsAny<Novbe>()), Times.Once);
            _unitOfWorkMock.Verify(u => u.EmeliyyatiTesdiqleAsync(), Times.Once);
        }

        [Fact]
        public async Task NovbeAcAsync_IsciTapilmadi_Ugursuz()
        {
            // Arrange
            int isciId = 999; // Mövcud olmayan ID
            decimal baslangicMebleg = 100.00m;

            var mockIsciRepo = new Mock<IIstifadeciRepozitori>();
            mockIsciRepo.Setup(r => r.GetirAsync(isciId))
                .ReturnsAsync((Istifadeci)null); // Mövcud olmayan işçi

            _unitOfWorkMock.Setup(u => u.Istifadeciler).Returns(mockIsciRepo.Object);

            // Act
            var netice = await _novbeManager.NovbeAcAsync(isciId, baslangicMebleg);

            // Assert
            Assert.False(netice.UgurluDur);
            Assert.Contains("İşçi tapılmadı", netice.Mesaj);
            mockIsciRepo.Verify(r => r.GetirAsync(isciId), Times.Once);
            _unitOfWorkMock.Verify(u => u.Novbeler.ElaveEtAsync(It.IsAny<Novbe>()), Times.Never);
            _unitOfWorkMock.Verify(u => u.EmeliyyatiTesdiqleAsync(), Times.Never);
        }

        [Fact]
        public async Task NovbeBaglaAsync_UgurluNovbeBaglama()
        {
            // Arrange
            int novbeId = 1;
            decimal faktikiMebleg = 1250.75m;

            var movcudNovbe = new Novbe
            {
                Id = novbeId,
                IsciId = 1,
                AcilmaTarixi = DateTime.Now.AddHours(-8),
                BaslangicMebleg = 100.00m,
                GozlenilenMebleg = 1350.00m,
                FaktikiMebleg = 0.00m, // Hələ doldurulmayıb
                Status = NovbeStatusu.Aciq
            };

            var satislar = new List<Satis>
            {
                new Satis { Id = 1, UmumiMebleg = 500.00m, OdenisMetodu = OdenisMetodu.Nağd },
                new Satis { Id = 2, UmumiMebleg = 750.00m, OdenisMetodu = OdenisMetodu.Kart },
                new Satis { Id = 3, UmumiMebleg = 100.00m, OdenisMetodu = OdenisMetodu.Nisyə }
            };

            var mockNovbeRepo = new Mock<INovbeRepozitori>();
            mockNovbeRepo.Setup(r => r.GetirAsync(novbeId))
                .ReturnsAsync(movcudNovbe);
            mockNovbeRepo.Setup(r => r.Yenile(It.IsAny<Novbe>()))
                .Callback<Novbe>(n =>
                {
                    movcudNovbe.FaktikiMebleg = n.FaktikiMebleg;
                    movcudNovbe.Status = n.Status;
                    movcudNovbe.BaglanmaTarixi = n.BaglanmaTarixi;
                });

            var mockSatisRepo = new Mock<ISatisRepozitori>();
            mockSatisRepo.Setup(r => r.AxtarAsync(It.IsAny<Expression<Func<Satis, bool>>>(), null))
                .ReturnsAsync(satislar);

            _unitOfWorkMock.Setup(u => u.Novbeler).Returns(mockNovbeRepo.Object);
            _unitOfWorkMock.Setup(u => u.Satislar).Returns(mockSatisRepo.Object);

            // Act
            var netice = await _novbeManager.NovbeBaglaAsync(novbeId, faktikiMebleg);

            // Assert
            Assert.True(netice.UgurluDur);
            Assert.Equal(faktikiMebleg, movcudNovbe.FaktikiMebleg);
            Assert.Equal(NovbeStatusu.Bagli, movcudNovbe.Status);
            Assert.NotNull(movcudNovbe.BaglanmaTarixi);
            mockNovbeRepo.Verify(r => r.GetirAsync(novbeId), Times.Once);
            mockNovbeRepo.Verify(r => r.Yenile(It.IsAny<Novbe>()), Times.Once);
            _unitOfWorkMock.Verify(u => u.EmeliyyatiTesdiqleAsync(), Times.Once);
        }

        [Fact]
        public async Task NovbeBaglaAsync_NovbeTapilmadi_Ugursuz()
        {
            // Arrange
            int novbeId = 999; // Mövcud olmayan ID
            decimal faktikiMebleg = 1250.75m;

            var mockNovbeRepo = new Mock<INovbeRepozitori>();
            mockNovbeRepo.Setup(r => r.GetirAsync(novbeId))
                .ReturnsAsync((Novbe)null); // Mövcud olmayan növbə

            _unitOfWorkMock.Setup(u => u.Novbeler).Returns(mockNovbeRepo.Object);

            // Act
            var netice = await _novbeManager.NovbeBaglaAsync(novbeId, faktikiMebleg);

            // Assert
            Assert.False(netice.UgurluDur);
            Assert.Contains("Növbə tapılmadı", netice.Mesaj);
            mockNovbeRepo.Verify(r => r.GetirAsync(novbeId), Times.Once);
            mockNovbeRepo.Verify(r => r.Yenile(It.IsAny<Novbe>()), Times.Never);
            _unitOfWorkMock.Verify(u => u.EmeliyyatiTesdiqleAsync(), Times.Never);
        }

        [Fact]
        public async Task NovbeBaglaAsync_NovbeArtiqBaglidir_Ugursuz()
        {
            // Arrange
            int novbeId = 1;
            decimal faktikiMebleg = 1250.75m;

            var movcudNovbe = new Novbe
            {
                Id = novbeId,
                IsciId = 1,
                AcilmaTarixi = DateTime.Now.AddHours(-8),
                BaslangicMebleg = 100.00m,
                GozlenilenMebleg = 1350.00m,
                FaktikiMebleg = 1250.75m,
                Status = NovbeStatusu.Bagli, // Artıq bağlı
                BaglanmaTarixi = DateTime.Now
            };

            var mockNovbeRepo = new Mock<INovbeRepozitori>();
            mockNovbeRepo.Setup(r => r.GetirAsync(novbeId))
                .ReturnsAsync(movcudNovbe);

            _unitOfWorkMock.Setup(u => u.Novbeler).Returns(mockNovbeRepo.Object);

            // Act
            var netice = await _novbeManager.NovbeBaglaAsync(novbeId, faktikiMebleg);

            // Assert
            Assert.False(netice.UgurluDur);
            Assert.Contains("Növbə artıq bağlıdır", netice.Mesaj);
            mockNovbeRepo.Verify(r => r.GetirAsync(novbeId), Times.Once);
            mockNovbeRepo.Verify(r => r.Yenile(It.IsAny<Novbe>()), Times.Never);
            _unitOfWorkMock.Verify(u => u.EmeliyyatiTesdiqleAsync(), Times.Never);
        }

        [Fact]
        public async Task AktivNovbeniGetirAsync_AktivNovbeTapildi()
        {
            // Arrange
            int isciId = 1;

            var aktivNovbe = new Novbe
            {
                Id = 1,
                IsciId = isciId,
                AcilmaTarixi = DateTime.Now.AddHours(-2),
                BaslangicMebleg = 100.00m,
                GozlenilenMebleg = 500.00m,
                FaktikiMebleg = 250.00m,
                Status = NovbeStatusu.Aciq
            };

            var novbeler = new List<Novbe> { aktivNovbe };

            var mockNovbeRepo = new Mock<INovbeRepozitori>();
            mockNovbeRepo.Setup(r => r.AxtarAsync(It.IsAny<Expression<Func<Novbe, bool>>>(), null))
                .ReturnsAsync(novbeler);

            _unitOfWorkMock.Setup(u => u.Novbeler).Returns(mockNovbeRepo.Object);

            // Act
            var netice = await _novbeManager.AktivNovbeniGetirAsync(isciId);

            // Assert
            Assert.True(netice.UgurluDur);
            Assert.NotNull(netice.Data);
            Assert.Equal(aktivNovbe.Id, netice.Data.Id);
            Assert.Equal(NovbeStatusu.Aciq, netice.Data.Status);
            mockNovbeRepo.Verify(r => r.AxtarAsync(It.IsAny<Expression<Func<Novbe, bool>>>(), null), Times.Once);
        }

        [Fact]
        public async Task AktivNovbeniGetirAsync_AktivNovbeYoxdur_Ugursuz()
        {
            // Arrange
            int isciId = 1;

            var bosNovbeler = new List<Novbe>();

            var mockNovbeRepo = new Mock<INovbeRepozitori>();
            mockNovbeRepo.Setup(r => r.AxtarAsync(It.IsAny<Expression<Func<Novbe, bool>>>(), null))
                .ReturnsAsync(bosNovbeler);

            _unitOfWorkMock.Setup(u => u.Novbeler).Returns(mockNovbeRepo.Object);

            // Act
            var netice = await _novbeManager.AktivNovbeniGetirAsync(isciId);

            // Assert
            Assert.False(netice.UgurluDur);
            Assert.Contains("Aktiv növbə tapılmadı", netice.Mesaj);
            mockNovbeRepo.Verify(r => r.AxtarAsync(It.IsAny<Expression<Func<Novbe, bool>>>(), null), Times.Once);
        }
    }
}