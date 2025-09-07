using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AzAgroPOS.Mentiq.Testler
{
    public class SatisManagerTests
    {
        [Fact]
        public async Task SatisYaratAsync_Ugurlu_Satis()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var nisyeManagerMock = new Mock<NisyeManager>(unitOfWorkMock.Object);
            
            var satisManager = new SatisManager(unitOfWorkMock.Object, nisyeManagerMock.Object);
            
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
            
            var mehsul = new Mehsul
            {
                Id = 1,
                MovcudSay = 5
            };
            
            unitOfWorkMock.Setup(u => u.Mehsullar.GetirAsync(1)).ReturnsAsync(mehsul);
            
            unitOfWorkMock.Setup(u => u.Satislar.ElaveEtAsync(It.IsAny<Satis>())).Returns(Task.CompletedTask);
            unitOfWorkMock.Setup(u => u.EmeliyyatiTesdiqleAsync()).Returns(Task.FromResult(1));
            
            // Act
            var netice = await satisManager.SatisYaratAsync(satisDto);
            
            // Assert
            Assert.True(netice.UgurluDur);
            unitOfWorkMock.Verify(u => u.Mehsullar.GetirAsync(1), Times.Exactly(2));
            unitOfWorkMock.Verify(u => u.Satislar.ElaveEtAsync(It.IsAny<Satis>()), Times.Once);
            unitOfWorkMock.Verify(u => u.EmeliyyatiTesdiqleAsync(), Times.Once);
        }
        
        [Fact]
        public async Task SatisYaratAsync_StokdaMehsulYoxdur()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var nisyeManagerMock = new Mock<NisyeManager>(unitOfWorkMock.Object);
            
            var satisManager = new SatisManager(unitOfWorkMock.Object, nisyeManagerMock.Object);
            
            var sebetElementleri = new List<SatisSebetiElementiDto>
            {
                new SatisSebetiElementiDto
                {
                    MehsulId = 1,
                    MehsulAdi = "Test Məhsulu",
                    Miqdar = 10,
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
            
            var mehsul = new Mehsul
            {
                Id = 1,
                MovcudSay = 5
            };
            
            unitOfWorkMock.Setup(u => u.Mehsullar.GetirAsync(1)).ReturnsAsync(mehsul);
            
            // Act
            var netice = await satisManager.SatisYaratAsync(satisDto);
            
            // Assert
            Assert.False(netice.UgurluDur);
            Assert.Contains("stokda kifayət qədər məhsul yoxdur", netice.Mesaj);
            unitOfWorkMock.Verify(u => u.Mehsullar.GetirAsync(1), Times.Once);
            unitOfWorkMock.Verify(u => u.Satislar.ElaveEtAsync(It.IsAny<Satis>()), Times.Never);
            unitOfWorkMock.Verify(u => u.EmeliyyatiTesdiqleAsync(), Times.Never);
        }
        
        [Fact]
        public async Task SatisYaratAsync_NisyedeMusteriSecilmeyib()
        {
            // Arrange
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var nisyeManagerMock = new Mock<NisyeManager>(unitOfWorkMock.Object);
            
            var satisManager = new SatisManager(unitOfWorkMock.Object, nisyeManagerMock.Object);
            
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
            };
            
            var mehsul = new Mehsul
            {
                Id = 1,
                MovcudSay = 5
            };
            
            unitOfWorkMock.Setup(u => u.Mehsullar.GetirAsync(1)).ReturnsAsync(mehsul);
            
            // Act
            var netice = await satisManager.SatisYaratAsync(satisDto);
            
            // Assert
            Assert.False(netice.UgurluDur);
            Assert.Contains("Nisyə satış üçün müştəri seçilməlidir", netice.Mesaj);
            unitOfWorkMock.Verify(u => u.Mehsullar.GetirAsync(1), Times.Never);
            unitOfWorkMock.Verify(u => u.Satislar.ElaveEtAsync(It.IsAny<Satis>()), Times.Never);
            unitOfWorkMock.Verify(u => u.EmeliyyatiTesdiqleAsync(), Times.Never);
        }
    }
}