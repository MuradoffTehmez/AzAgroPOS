using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Tests.Helpers;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AzAgroPOS.Tests.LogicTests
{
    public class SatisManagerTests : IDisposable
    {
        private readonly AzAgroPOSDbContext _dbContext;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<NisyeManager> _nisyeManagerMock;
        private readonly SatisManager _satisManager;

        public SatisManagerTests()
        {
            _dbContext = DbContextHelper.GetInMemoryDbContext();
            
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _nisyeManagerMock = new Mock<NisyeManager>(_unitOfWorkMock.Object);
            
            // Setup UnitOfWork mock to return our in-memory database context
            _unitOfWorkMock.Setup(u => u.Mehsullar).Returns(new Mock<IMehsulRepozitori>().Object);
            _unitOfWorkMock.Setup(u => u.Musteriler).Returns(new Mock<IMusteriRepozitori>().Object);
            _unitOfWorkMock.Setup(u => u.Satislar).Returns(new Mock<ISatisRepozitori>().Object);
            _unitOfWorkMock.Setup(u => u.Novbeler).Returns(new Mock<INovbeRepozitori>().Object);
            _unitOfWorkMock.Setup(u => u.EmeliyyatiTesdiqleAsync()).Returns(Task.FromResult(1));
            
            _satisManager = new SatisManager(_unitOfWorkMock.Object, _nisyeManagerMock.Object);
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        [Fact]
        public async Task SatisYaratAsync_Ugurlu_Satis()
        {
            // Arrange
            var mehsul = new Mehsul
            {
                Id = 1,
                Ad = "Test Məhsulu",
                MovcudSay = 10,
                PerakendeSatisQiymeti = 10.00m
            };

            // Add product to database
            _dbContext.Mehsullar.Add(mehsul);
            await _dbContext.SaveChangesAsync();

            // Setup mock to return product from database
            _unitOfWorkMock.Setup(u => u.Mehsullar.GetirAsync(1))
                .ReturnsAsync(await _dbContext.Mehsullar.FirstAsync(m => m.Id == 1));

            var sebetElementleri = new List<SatisSebetiElementiDto>
            {
                new SatisSebetiElementiDto
                {
                    MehsulId = 1,
                    MehsulAdi = "Test Məhsulu",
                    Miqdar = 2,
                    VahidinQiymeti = 10
                }
            };

            var satisDto = new SatisYaratDto
            {
                SebetElementleri = sebetElementleri,
                OdenisMetodu = OdenisMetodu.Nağd,
                NovbeId = 1,
                UmumiMebleg = 20,
                YekunMebleg = 20
            };

            _unitOfWorkMock.Setup(u => u.Satislar.ElaveEtAsync(It.IsAny<Satis>()))
                .Returns(Task.CompletedTask);

            // Act
            var netice = await _satisManager.SatisYaratAsync(satisDto);

            // Assert
            Assert.True(netice.UgurluDur);
            _unitOfWorkMock.Verify(u => u.Mehsullar.GetirAsync(1), Times.Exactly(2));
            _unitOfWorkMock.Verify(u => u.Satislar.ElaveEtAsync(It.IsAny<Satis>()), Times.Once);
            _unitOfWorkMock.Verify(u => u.EmeliyyatiTesdiqleAsync(), Times.Once);
        }

        [Fact]
        public async Task SatisYaratAsync_StokdaMehsulYoxdur()
        {
            // Arrange
            var mehsul = new Mehsul
            {
                Id = 1,
                Ad = "Test Məhsulu",
                MovcudSay = 5,
                PerakendeSatisQiymeti = 10.00m
            };

            // Add product to database
            _dbContext.Mehsullar.Add(mehsul);
            await _dbContext.SaveChangesAsync();

            // Setup mock to return product from database
            _unitOfWorkMock.Setup(u => u.Mehsullar.GetirAsync(1))
                .ReturnsAsync(await _dbContext.Mehsullar.FirstAsync(m => m.Id == 1));

            var sebetElementleri = new List<SatisSebetiElementiDto>
            {
                new SatisSebetiElementiDto
                {
                    MehsulId = 1,
                    MehsulAdi = "Test Məhsulu",
                    Miqdar = 10, // More than available stock
                    VahidinQiymeti = 10
                }
            };

            var satisDto = new SatisYaratDto
            {
                SebetElementleri = sebetElementleri,
                OdenisMetodu = OdenisMetodu.Nağd,
                NovbeId = 1,
                UmumiMebleg = 100,
                YekunMebleg = 100
            };

            // Act
            var netice = await _satisManager.SatisYaratAsync(satisDto);

            // Assert
            Assert.False(netice.UgurluDur);
            Assert.Contains("stokda kifayət qədər məhsul yoxdur", netice.Mesaj);
            _unitOfWorkMock.Verify(u => u.Mehsullar.GetirAsync(1), Times.Once);
            _unitOfWorkMock.Verify(u => u.Satislar.ElaveEtAsync(It.IsAny<Satis>()), Times.Never);
            _unitOfWorkMock.Verify(u => u.EmeliyyatiTesdiqleAsync(), Times.Never);
        }

        [Fact]
        public async Task SatisYaratAsync_NisyedeMusteriSecilmeyib()
        {
            // Arrange
            var sebetElementleri = new List<SatisSebetiElementiDto>
            {
                new SatisSebetiElementiDto
                {
                    MehsulId = 1,
                    MehsulAdi = "Test Məhsulu",
                    Miqdar = 2,
                    VahidinQiymeti = 10
                }
            };

            var satisDto = new SatisYaratDto
            {
                SebetElementleri = sebetElementleri,
                OdenisMetodu = OdenisMetodu.Nisyə,
                NovbeId = 1,
                UmumiMebleg = 20,
                YekunMebleg = 20
                // MusteriId is not provided for nisyə sale
            };

            // Act
            var netice = await _satisManager.SatisYaratAsync(satisDto);

            // Assert
            Assert.False(netice.UgurluDur);
            Assert.Contains("Nisyə satış üçün müştəri seçilməlidir", netice.Mesaj);
            _unitOfWorkMock.Verify(u => u.Mehsullar.GetirAsync(1), Times.Never);
            _unitOfWorkMock.Verify(u => u.Satislar.ElaveEtAsync(It.IsAny<Satis>()), Times.Never);
            _unitOfWorkMock.Verify(u => u.EmeliyyatiTesdiqleAsync(), Times.Never);
        }

        [Fact]
        public async Task SatisYaratAsync_NisyedeMusteriBorcuArtir()
        {
            // Arrange
            var mehsul = new Mehsul
            {
                Id = 1,
                Ad = "Test Məhsulu",
                MovcudSay = 10,
                PerakendeSatisQiymeti = 10.00m
            };

            var musteri = new Musteri
            {
                Id = 1,
                TamAd = "Test Müştəri",
                UmumiBorc = 50.00m
            };

            // Add entities to database
            _dbContext.Mehsullar.Add(mehsul);
            _dbContext.Musteriler.Add(musteri);
            await _dbContext.SaveChangesAsync();

            // Setup mocks
            _unitOfWorkMock.Setup(u => u.Mehsullar.GetirAsync(1))
                .ReturnsAsync(await _dbContext.Mehsullar.FirstAsync(m => m.Id == 1));
            
            _unitOfWorkMock.Setup(u => u.Musteriler.GetirAsync(1))
                .ReturnsAsync(await _dbContext.Musteriler.FirstAsync(m => m.Id == 1));

            _unitOfWorkMock.Setup(u => u.Satislar.ElaveEtAsync(It.IsAny<Satis>()))
                .Returns(Task.CompletedTask);

            // Setup nisyə manager mock to return successful result
            var nisyeNetice = EmeliyyatNeticesi<bool>.Ugurlu(true);
            _nisyeManagerMock.Setup(n => n.NisyeyeSatisElaveEtAsync(It.IsAny<Satis>()))
                .ReturnsAsync(nisyeNetice);

            var sebetElementleri = new List<SatisSebetiElementiDto>
            {
                new SatisSebetiElementiDto
                {
                    MehsulId = 1,
                    MehsulAdi = "Test Məhsulu",
                    Miqdar = 2,
                    VahidinQiymeti = 10
                }
            };

            var satisDto = new SatisYaratDto
            {
                SebetElementleri = sebetElementleri,
                OdenisMetodu = OdenisMetodu.Nisyə,
                NovbeId = 1,
                MusteriId = 1,
                UmumiMebleg = 20,
                YekunMebleg = 20
            };

            // Act
            var netice = await _satisManager.SatisYaratAsync(satisDto);

            // Assert
            Assert.True(netice.UgurluDur);
            _unitOfWorkMock.Verify(u => u.Mehsullar.GetirAsync(1), Times.Exactly(2));
            _unitOfWorkMock.Verify(u => u.Satislar.ElaveEtAsync(It.IsAny<Satis>()), Times.Once);
            _unitOfWorkMock.Verify(u => u.EmeliyyatiTesdiqleAsync(), Times.Once);
            _nisyeManagerMock.Verify(n => n.NisyeyeSatisElaveEtAsync(It.IsAny<Satis>()), Times.Once);
        }

        [Fact]
        public async Task SatisGetirAsync_Ugurlu_QebzMelumatlari()
        {
            // Arrange
            var mehsul = new Mehsul
            {
                Id = 1,
                Ad = "Test Məhsulu",
                PerakendeSatisQiymeti = 10.00m
            };

            var satis = new Satis
            {
                Id = 1,
                Tarix = DateTime.Now,
                OdenisMetodu = OdenisMetodu.Nağd,
                UmumiMebleg = 20.00m,
                NovbeId = 1
            };

            var satisDetali = new SatisDetali
            {
                Id = 1,
                SatisId = 1,
                MehsulId = 1,
                Miqdar = 2,
                Qiymet = 10.00m,
                UmumiMebleg = 20.00m
            };

            satis.SatisDetallari.Add(satisDetali);

            // Add entities to database
            _dbContext.Mehsullar.Add(mehsul);
            _dbContext.Satislar.Add(satis);
            _dbContext.SatisDetallari.Add(satisDetali);
            await _dbContext.SaveChangesAsync();

            // Setup mocks
            _unitOfWorkMock.Setup(u => u.Satislar.GetirAsync(1))
                .ReturnsAsync(await _dbContext.Satislar.Include(s => s.SatisDetallari).FirstAsync(s => s.Id == 1));
            
            _unitOfWorkMock.Setup(u => u.Mehsullar.GetirAsync(1))
                .ReturnsAsync(await _dbContext.Mehsullar.FirstAsync(m => m.Id == 1));

            // Act
            var netice = await _satisManager.SatisGetirAsync("1");

            // Assert
            Assert.True(netice.UgurluDur);
            Assert.NotNull(netice.Data);
            Assert.Equal(1, netice.Data.SatisId);
            Assert.Single(netice.Data.SatilanMehsullar);
            Assert.Equal("Test Məhsulu", netice.Data.SatilanMehsullar[0].MehsulAdi);
            Assert.Equal(2, netice.Data.SatilanMehsullar[0].Miqdar);
            Assert.Equal(10.00m, netice.Data.SatilanMehsullar[0].VahidinQiymeti);
            Assert.Equal(20.00m, netice.Data.CemiMebleg);
        }
    }
}