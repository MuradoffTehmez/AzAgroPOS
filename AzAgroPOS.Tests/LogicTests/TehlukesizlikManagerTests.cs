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
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace AzAgroPOS.Tests.LogicTests
{
    public class TehlukesizlikManagerTests : IDisposable
    {
        private readonly AzAgroPOSDbContext _dbContext;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly TehlukesizlikManager _tehlukesizlikManager;

        public TehlukesizlikManagerTests()
        {
            _dbContext = DbContextHelper.GetInMemoryDbContext();
            
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            
            // Setup UnitOfWork mock
            _unitOfWorkMock.Setup(u => u.Istifadeciler).Returns(new Mock<IIstifadeciRepozitori>().Object);
            
            _tehlukesizlikManager = new TehlukesizlikManager(_unitOfWorkMock.Object);
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        [Fact]
        public async Task GirisEtAsync_DuzgunSifre_Ugurlu()
        {
            // Arrange
            string istifadeciAdi = "testuser";
            string sifre = "correctpassword";
            
            // BCrypt hash of "correctpassword"
            string sifreHash = "$2a$11$wvv2PHlk9LWlv4vuz3eEBl.ynUDwxFQSIHWle5nHfS3sL7hTkTQPG";
            
            var istifadeci = new Istifadeci
            {
                Id = 1,
                IstifadeciAdi = istifadeciAdi,
                ParolHash = sifreHash, // Hash of "correctpassword"
                TamAd = "Test İstifadəçi"
            };

            var mockIstifadeciRepo = new Mock<IIstifadeciRepozitori>();
            mockIstifadeciRepo.Setup(r => r.AxtarAsync(It.IsAny<Func<Istifadeci, bool>>(), null))
                .ReturnsAsync(new List<Istifadeci> { istifadeci });
            
            _unitOfWorkMock.Setup(u => u.Istifadeciler).Returns(mockIstifadeciRepo.Object);

            // Act
            var netice = await _tehlukesizlikManager.GirisEtAsync(istifadeciAdi, sifre);

            // Assert
            Assert.True(netice.UgurluDur);
            Assert.NotNull(netice.Netice);
            Assert.Equal(istifadeci.Id, netice.Netice.Id);
            Assert.Equal(istifadeci.IstifadeciAdi, netice.Netice.IstifadeciAdi);
            Assert.Equal(istifadeci.TamAd, netice.Netice.TamAd);
            mockIstifadeciRepo.Verify(r => r.AxtarAsync(It.IsAny<Func<Istifadeci, bool>>(), null), Times.Once);
        }

        [Fact]
        public async Task GirisEtAsync_YanlisSifre_Ugursuz()
        {
            // Arrange
            string istifadeciAdi = "testuser";
            string sifre = "wrongpassword"; // Yanlış şifrə
            
            // BCrypt hash of "correctpassword"
            string sifreHash = "$2a$11$wvv2PHlk9LWlv4vuz3eEBl.ynUDwxFQSIHWle5nHfS3sL7hTkTQPG";
            
            var istifadeci = new Istifadeci
            {
                Id = 1,
                IstifadeciAdi = istifadeciAdi,
                ParolHash = sifreHash, // Hash of "correctpassword"
                TamAd = "Test İstifadəçi"
            };

            var mockIstifadeciRepo = new Mock<IIstifadeciRepozitori>();
            mockIstifadeciRepo.Setup(r => r.AxtarAsync(It.IsAny<Func<Istifadeci, bool>>(), null))
                .ReturnsAsync(new List<Istifadeci> { istifadeci });
            
            _unitOfWorkMock.Setup(u => u.Istifadeciler).Returns(mockIstifadeciRepo.Object);

            // Act
            var netice = await _tehlukesizlikManager.GirisEtAsync(istifadeciAdi, sifre);

            // Assert
            Assert.False(netice.UgurluDur);
            Assert.Contains("İstifadəçi adı və ya şifrə yanlışdır", netice.Mesaj);
            mockIstifadeciRepo.Verify(r => r.AxtarAsync(It.IsAny<Func<Istifadeci, bool>>(), null), Times.Once);
        }

        [Fact]
        public async Task GirisEtAsync_IstifadeciTapilmadi_Ugursuz()
        {
            // Arrange
            string istifadeciAdi = "nonexistentuser";
            string sifre = "anypassword";
            
            var bosIstifadeciler = new List<Istifadeci>();

            var mockIstifadeciRepo = new Mock<IIstifadeciRepozitori>();
            mockIstifadeciRepo.Setup(r => r.AxtarAsync(It.IsAny<Func<Istifadeci, bool>>(), null))
                .ReturnsAsync(bosIstifadeciler);
            
            _unitOfWorkMock.Setup(u => u.Istifadeciler).Returns(mockIstifadeciRepo.Object);

            // Act
            var netice = await _tehlukesizlikManager.GirisEtAsync(istifadeciAdi, sifre);

            // Assert
            Assert.False(netice.UgurluDur);
            Assert.Contains("İstifadəçi adı və ya şifrə yanlışdır", netice.Mesaj);
            mockIstifadeciRepo.Verify(r => r.AxtarAsync(It.IsAny<Func<Istifadeci, bool>>(), null), Times.Once);
        }

        [Fact]
        public async Task GirisEtAsync_BosIstifadeciAdi_Ugursuz()
        {
            // Arrange
            string istifadeciAdi = ""; // Boş istifadəçi adı
            string sifre = "anypassword";

            // Act
            var netice = await _tehlukesizlikManager.GirisEtAsync(istifadeciAdi, sifre);

            // Assert
            Assert.False(netice.UgurluDur);
            Assert.Contains("İstifadəçi adı və şifrə daxil edilməlidir", netice.Mesaj);
        }

        [Fact]
        public async Task GirisEtAsync_BosSifre_Ugursuz()
        {
            // Arrange
            string istifadeciAdi = "testuser";
            string sifre = ""; // Boş şifrə

            // Act
            var netice = await _tehlukesizlikManager.GirisEtAsync(istifadeciAdi, sifre);

            // Assert
            Assert.False(netice.UgurluDur);
            Assert.Contains("İstifadəçi adı və şifrə daxil edilməlidir", netice.Mesaj);
        }
    }
}