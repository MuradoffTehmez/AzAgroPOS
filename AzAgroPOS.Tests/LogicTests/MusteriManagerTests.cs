// AzAgroPOS.Tests/LogicTests/MusteriManagerTests.cs

using AzAgroPOS.Mentiq.DTOs;
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
    public class MusteriManagerTests : IDisposable
    {
        private readonly AzAgroPOSDbContext _dbContext;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly MusteriManager _musteriManager;

        public MusteriManagerTests()
        {
            _dbContext = DbContextHelper.GetInMemoryDbContext();

            _unitOfWorkMock = new Mock<IUnitOfWork>();

            // Setup UnitOfWork mock
            _unitOfWorkMock.Setup(u => u.Musteriler).Returns(new Mock<IMusteriRepozitori>().Object);
            _unitOfWorkMock.Setup(u => u.EmeliyyatiTesdiqleAsync()).Returns(Task.FromResult(1));

            _musteriManager = new MusteriManager(_unitOfWorkMock.Object);
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        [Fact]
        public async Task MusteriYaratAsync_UgurluMusteriYaratma()
        {
            // Arrange
            var musteriDto = new MusteriDto
            {
                TamAd = "Yeni Test Müştəri",
                TelefonNomresi = "+994501234567",
                Unvan = "Bakı şəhəri",
                KreditLimiti = 1000.00m,
                UmumiBorc = 0
            };

            var bosMusteriler = new List<Musteri>();
            var mockMusteriRepo = new Mock<IMusteriRepozitori>();
            mockMusteriRepo.Setup(r => r.AxtarAsync(It.IsAny<Expression<Func<Musteri, bool>>>(), null))
                .ReturnsAsync(bosMusteriler);
            mockMusteriRepo.Setup(r => r.ElaveEtAsync(It.IsAny<Musteri>()))
                .Returns(Task.CompletedTask);

            _unitOfWorkMock.Setup(u => u.Musteriler).Returns(mockMusteriRepo.Object);

            // Act
            var netice = await _musteriManager.MusteriYaratAsync(musteriDto);

            // Assert
            Assert.True(netice.UgurluDur);
            mockMusteriRepo.Verify(r => r.AxtarAsync(It.IsAny<Expression<Func<Musteri, bool>>>(), null), Times.Once);
            mockMusteriRepo.Verify(r => r.ElaveEtAsync(It.IsAny<Musteri>()), Times.Once);
            _unitOfWorkMock.Verify(u => u.EmeliyyatiTesdiqleAsync(), Times.Once);
        }

        [Fact]
        public async Task MusteriYaratAsync_MovcudTelefonNomresi_Ugursuz()
        {
            // Arrange
            var musteriDto = new MusteriDto
            {
                TamAd = "Yeni Test Müştəri",
                TelefonNomresi = "+994501234567",
                Unvan = "Bakı şəhəri",
                KreditLimiti = 1000.00m,
                UmumiBorc = 0
            };

            var movcudMusteriler = new List<Musteri>
            {
                new Musteri
                {
                    Id = 1,
                    TamAd = "Mövcud Müştəri",
                    TelefonNomresi = "+994501234567", // Eyni telefon nömrəsi
                    Unvan = "Sumqayıt şəhəri",
                    KreditLimiti = 500.00m,
                    UmumiBorc = 100.00m
                }
            };

            var mockMusteriRepo = new Mock<IMusteriRepozitori>();
            mockMusteriRepo.Setup(r => r.AxtarAsync(It.IsAny<Expression<Func<Musteri, bool>>>(), null))
                .ReturnsAsync(movcudMusteriler);

            _unitOfWorkMock.Setup(u => u.Musteriler).Returns(mockMusteriRepo.Object);

            // Act
            var netice = await _musteriManager.MusteriYaratAsync(musteriDto);

            // Assert
            Assert.False(netice.UgurluDur);
            Assert.Contains("Bu telefon nömrəsi ilə müştəri artıq mövcuddur", netice.Mesaj);
            mockMusteriRepo.Verify(r => r.AxtarAsync(It.IsAny<Expression<Func<Musteri, bool>>>(), null), Times.Once);
            mockMusteriRepo.Verify(r => r.ElaveEtAsync(It.IsAny<Musteri>()), Times.Never);
            _unitOfWorkMock.Verify(u => u.EmeliyyatiTesdiqleAsync(), Times.Never);
        }

        [Fact]
        public async Task MusteriYenileAsync_MovcudMusteriYenile()
        {
            // Arrange
            var movcudMusteri = new Musteri
            {
                Id = 1,
                TamAd = "Mövcud Müştəri",
                TelefonNomresi = "+994501234567",
                Unvan = "Sumqayıt şəhəri",
                KreditLimiti = 500.00m,
                UmumiBorc = 100.00m
            };

            var musteriDto = new MusteriDto
            {
                Id = 1,
                TamAd = "Yenilənmiş Müştəri",
                TelefonNomresi = "+994507654321", // Yenilənmiş nömrə
                Unvan = "Bakı şəhəri", // Yenilənmiş ünvan
                KreditLimiti = 1500.00m, // Yenilənmiş limit
                UmumiBorc = 100.00m // Dəyişmir
            };

            var mockMusteriRepo = new Mock<IMusteriRepozitori>();
            mockMusteriRepo.Setup(r => r.GetirAsync(1))
                .ReturnsAsync(movcudMusteri);
            mockMusteriRepo.Setup(r => r.Yenile(It.IsAny<Musteri>()))
                .Callback<Musteri>(m =>
                {
                    movcudMusteri.TamAd = m.TamAd;
                    movcudMusteri.TelefonNomresi = m.TelefonNomresi;
                    movcudMusteri.Unvan = m.Unvan;
                    movcudMusteri.KreditLimiti = m.KreditLimiti;
                });

            _unitOfWorkMock.Setup(u => u.Musteriler).Returns(mockMusteriRepo.Object);

            // Act
            var netice = await _musteriManager.MusteriYenileAsync(musteriDto);

            // Assert
            Assert.True(netice.UgurluDur);
            Assert.Equal("Yenilənmiş Müştəri", movcudMusteri.TamAd);
            Assert.Equal("+994507654321", movcudMusteri.TelefonNomresi);
            Assert.Equal("Bakı şəhəri", movcudMusteri.Unvan);
            Assert.Equal(1500.00m, movcudMusteri.KreditLimiti);
            mockMusteriRepo.Verify(r => r.GetirAsync(1), Times.Once);
            mockMusteriRepo.Verify(r => r.Yenile(It.IsAny<Musteri>()), Times.Once);
            _unitOfWorkMock.Verify(u => u.EmeliyyatiTesdiqleAsync(), Times.Once);
        }

        [Fact]
        public async Task MusteriYenileAsync_MusteriTapilmadi_Ugursuz()
        {
            // Arrange
            var musteriDto = new MusteriDto
            {
                Id = 999, // Mövcud olmayan ID
                TamAd = "Yenilənmiş Müştəri",
                TelefonNomresi = "+994507654321",
                Unvan = "Bakı şəhəri",
                KreditLimiti = 1500.00m,
                UmumiBorc = 0
            };

            var mockMusteriRepo = new Mock<IMusteriRepozitori>();
            mockMusteriRepo.Setup(r => r.GetirAsync(999))
                .ReturnsAsync((Musteri)null); // Mövcud olmayan müştəri

            _unitOfWorkMock.Setup(u => u.Musteriler).Returns(mockMusteriRepo.Object);

            // Act
            var netice = await _musteriManager.MusteriYenileAsync(musteriDto);

            // Assert
            Assert.False(netice.UgurluDur);
            Assert.Contains("Müştəri tapılmadı", netice.Mesaj);
            mockMusteriRepo.Verify(r => r.GetirAsync(999), Times.Once);
            mockMusteriRepo.Verify(r => r.Yenile(It.IsAny<Musteri>()), Times.Never);
            _unitOfWorkMock.Verify(u => u.EmeliyyatiTesdiqleAsync(), Times.Never);
        }

        [Fact]
        public async Task MusteriSilAsync_BorcsuzMusteriSilinir()
        {
            // Arrange
            int musteriId = 1;
            var movcudMusteri = new Musteri
            {
                Id = musteriId,
                TamAd = "Silinəcək Müştəri",
                TelefonNomresi = "+994501234567",
                Unvan = "Bakı şəhəri",
                KreditLimiti = 1000.00m,
                UmumiBorc = 0 // Borcu yoxdur
            };

            var mockMusteriRepo = new Mock<IMusteriRepozitori>();
            mockMusteriRepo.Setup(r => r.GetirAsync(musteriId))
                .ReturnsAsync(movcudMusteri);
            mockMusteriRepo.Setup(r => r.Sil(It.IsAny<Musteri>()));

            _unitOfWorkMock.Setup(u => u.Musteriler).Returns(mockMusteriRepo.Object);

            // Act
            var netice = await _musteriManager.MusteriSilAsync(musteriId);

            // Assert
            Assert.True(netice.UgurluDur);
            mockMusteriRepo.Verify(r => r.GetirAsync(musteriId), Times.Once);
            mockMusteriRepo.Verify(r => r.Sil(It.IsAny<Musteri>()), Times.Once);
            _unitOfWorkMock.Verify(u => u.EmeliyyatiTesdiqleAsync(), Times.Once);
        }

        [Fact]
        public async Task MusteriSilAsync_BorcluMusteriSilinmir_Ugursuz()
        {
            // Arrange
            int musteriId = 1;
            var movcudMusteri = new Musteri
            {
                Id = musteriId,
                TamAd = "Silinəcək Müştəri",
                TelefonNomresi = "+994501234567",
                Unvan = "Bakı şəhəri",
                KreditLimiti = 1000.00m,
                UmumiBorc = 500.00m // Borcu var
            };

            var mockMusteriRepo = new Mock<IMusteriRepozitori>();
            mockMusteriRepo.Setup(r => r.GetirAsync(musteriId))
                .ReturnsAsync(movcudMusteri);

            _unitOfWorkMock.Setup(u => u.Musteriler).Returns(mockMusteriRepo.Object);

            // Act
            var netice = await _musteriManager.MusteriSilAsync(musteriId);

            // Assert
            Assert.False(netice.UgurluDur);
            Assert.Contains("Borcu olan müştərini silmək olmaz", netice.Mesaj);
            mockMusteriRepo.Verify(r => r.GetirAsync(musteriId), Times.Once);
            mockMusteriRepo.Verify(r => r.Sil(It.IsAny<Musteri>()), Times.Never);
            _unitOfWorkMock.Verify(u => u.EmeliyyatiTesdiqleAsync(), Times.Never);
        }
    }
}