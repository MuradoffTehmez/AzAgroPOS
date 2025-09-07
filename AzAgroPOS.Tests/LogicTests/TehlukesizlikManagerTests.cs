// AzAgroPOS.Tests/LogicTests/TehlukesizlikManagerTests.cs

using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Tests.Helpers;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using Moq;
using System;
using System.Collections.Generic;
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
            _unitOfWorkMock.Setup(u => u.Rollar).Returns(new Mock<IRolRepozitori>().Object);

            _tehlukesizlikManager = new TehlukesizlikManager(_unitOfWorkMock.Object);
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        [Fact]
        public async Task DaxilOlAsync_DuzgunSifre_Ugurlu()
        {
            // Arrange
            string istifadeciAdi = "testuser";
            string sifre = "correctpassword";

            // BCrypt hash of "correctpassword"
            string sifreHash = BCrypt.Net.BCrypt.HashPassword(sifre);

            var istifadeci = new Istifadeci
            {
                Id = 1,
                IstifadeciAdi = istifadeciAdi,
                ParolHash = sifreHash,
                TamAd = "Test İstifadəçi",
                RolId = 1
            };

            var rol = new Rol { Id = 1, Ad = "Admin" };

            var mockIstifadeciRepo = new Mock<IIstifadeciRepozitori>();
            mockIstifadeciRepo.Setup(r => r.AxtarAsync(It.IsAny<Expression<Func<Istifadeci, bool>>>(), null))
                .ReturnsAsync(new List<Istifadeci> { istifadeci });

            var mockRolRepo = new Mock<IRolRepozitori>();
            mockRolRepo.Setup(r => r.GetirAsync(1)).ReturnsAsync(rol);

            _unitOfWorkMock.Setup(u => u.Istifadeciler).Returns(mockIstifadeciRepo.Object);
            _unitOfWorkMock.Setup(u => u.Rollar).Returns(mockRolRepo.Object);

            // Act
            var netice = await _tehlukesizlikManager.DaxilOlAsync(istifadeciAdi, sifre);

            // Assert
            Assert.True(netice.UgurluDur);
            Assert.NotNull(netice.Data);
            Assert.Equal(istifadeci.Id, netice.Data.Id);
            Assert.Equal(istifadeci.IstifadeciAdi, netice.Data.IstifadeciAdi);
            Assert.Equal(istifadeci.TamAd, netice.Data.TamAd);
            Assert.Equal(rol.Ad, netice.Data.RolAdi);
            mockIstifadeciRepo.Verify(r => r.AxtarAsync(It.IsAny<Expression<Func<Istifadeci, bool>>>(), null), Times.Once);
        }

        [Fact]
        public async Task DaxilOlAsync_YanlisSifre_Ugursuz()
        {
            // Arrange
            string istifadeciAdi = "testuser";
            string sifre = "wrongpassword"; // Yanlış şifrə

            string dogruSifreHash = BCrypt.Net.BCrypt.HashPassword("correctpassword");

            var istifadeci = new Istifadeci
            {
                Id = 1,
                IstifadeciAdi = istifadeciAdi,
                ParolHash = dogruSifreHash,
                TamAd = "Test İstifadəçi"
            };

            var mockIstifadeciRepo = new Mock<IIstifadeciRepozitori>();
            mockIstifadeciRepo.Setup(r => r.AxtarAsync(It.IsAny<Expression<Func<Istifadeci, bool>>>(), null))
                .ReturnsAsync(new List<Istifadeci> { istifadeci });

            _unitOfWorkMock.Setup(u => u.Istifadeciler).Returns(mockIstifadeciRepo.Object);

            // Act
            var netice = await _tehlukesizlikManager.DaxilOlAsync(istifadeciAdi, sifre);

            // Assert
            Assert.False(netice.UgurluDur);
            Assert.Contains("İstifadəçi adı və ya parol yanlışdır", netice.Mesaj);
            mockIstifadeciRepo.Verify(r => r.AxtarAsync(It.IsAny<Expression<Func<Istifadeci, bool>>>(), null), Times.Once);
        }

        [Fact]
        public async Task DaxilOlAsync_IstifadeciTapilmadi_Ugursuz()
        {
            // Arrange
            string istifadeciAdi = "nonexistentuser";
            string sifre = "anypassword";

            var bosIstifadeciler = new List<Istifadeci>();

            var mockIstifadeciRepo = new Mock<IIstifadeciRepozitori>();
            mockIstifadeciRepo.Setup(r => r.AxtarAsync(It.IsAny<Expression<Func<Istifadeci, bool>>>(), null))
                .ReturnsAsync(bosIstifadeciler);

            _unitOfWorkMock.Setup(u => u.Istifadeciler).Returns(mockIstifadeciRepo.Object);

            // Act
            var netice = await _tehlukesizlikManager.DaxilOlAsync(istifadeciAdi, sifre);

            // Assert
            Assert.False(netice.UgurluDur);
            Assert.Contains("İstifadəçi adı və ya parol yanlışdır", netice.Mesaj);
            mockIstifadeciRepo.Verify(r => r.AxtarAsync(It.IsAny<Expression<Func<Istifadeci, bool>>>(), null), Times.Once);
        }

        [Fact]
        public async Task DaxilOlAsync_BosIstifadeciAdi_Ugursuz()
        {
            // Arrange
            string istifadeciAdi = ""; // Boş istifadəçi adı
            string sifre = "anypassword";

            // Act
            var netice = await _tehlukesizlikManager.DaxilOlAsync(istifadeciAdi, sifre);

            // Assert
            Assert.False(netice.UgurluDur);
            Assert.Contains("İstifadəçi adı və parol boş ola bilməz.", netice.Mesaj);
        }

        [Fact]
        public async Task DaxilOlAsync_BosSifre_Ugursuz()
        {
            // Arrange
            string istifadeciAdi = "testuser";
            string sifre = ""; // Boş şifrə

            // Act
            var netice = await _tehlukesizlikManager.DaxilOlAsync(istifadeciAdi, sifre);

            // Assert
            Assert.False(netice.UgurluDur);
            Assert.Contains("İstifadəçi adı və parol boş ola bilməz.", netice.Mesaj);
        }
    }
}