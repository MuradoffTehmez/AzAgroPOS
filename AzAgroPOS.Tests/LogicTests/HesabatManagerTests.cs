// AzAgroPOS.Tests/LogicTests/HesabatManagerTests.cs

using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Tests.Helpers;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace AzAgroPOS.Tests.LogicTests
{
    public class HesabatManagerTests : IDisposable
    {
        private readonly AzAgroPOSDbContext _dbContext;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly HesabatManager _hesabatManager;

        public HesabatManagerTests()
        {
            _dbContext = DbContextHelper.GetInMemoryDbContext();

            _unitOfWorkMock = new Mock<IUnitOfWork>();

            // Setup UnitOfWork mock
            _unitOfWorkMock.Setup(u => u.Satislar).Returns(new Mock<ISatisRepozitori>().Object);
            _unitOfWorkMock.Setup(u => u.Musteriler).Returns(new Mock<IMusteriRepozitori>().Object);
            _unitOfWorkMock.Setup(u => u.Mehsullar).Returns(new Mock<IMehsulRepozitori>().Object);
            _unitOfWorkMock.Setup(u => u.Novbeler).Returns(new Mock<INovbeRepozitori>().Object);
            _unitOfWorkMock.Setup(u => u.Istifadeciler).Returns(new Mock<IIstifadeciRepozitori>().Object);

            _hesabatManager = new HesabatManager(_unitOfWorkMock.Object);
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        [Fact]
        public async Task GunlukSatisHesabatiGetirAsync_TarixUcunSatisYoxdur_Ugursuz()
        {
            // Arrange
            DateTime tarix = DateTime.Today;

            var bosSatislar = new List<Satis>();
            var mockSatisRepo = new Mock<ISatisRepozitori>();
            mockSatisRepo.Setup(r => r.AxtarAsync(It.IsAny<Expression<Func<Satis, bool>>>(), null))
                .ReturnsAsync(bosSatislar);

            _unitOfWorkMock.Setup(u => u.Satislar).Returns(mockSatisRepo.Object);

            // Act
            var netice = await _hesabatManager.GunlukSatisHesabatiGetirAsync(tarix);

            // Assert
            Assert.False(netice.UgurluDur);
            Assert.Contains("Seçilmiş tarix üçün heç bir satış tapılmadı", netice.Mesaj);
        }

        [Fact]
        public async Task GunlukSatisHesabatiGetirAsync_NagdKartVeNisyeSatislar_Ugurlu()
        {
            // Arrange
            DateTime tarix = DateTime.Today;
            var gununBasi = tarix.Date;
            var gununSonu = gununBasi.AddDays(1).AddTicks(-1);

            var musteriler = new List<Musteri>
            {
                new Musteri { Id = 1, TamAd = "Test Müştəri 1" },
                new Musteri { Id = 2, TamAd = "Test Müştəri 2" }
            };

            var satislar = new List<Satis>
            {
                new Satis
                {
                    Id = 1,
                    Tarix = gununBasi.AddHours(10),
                    UmumiMebleg = 50.00m,
                    OdenisMetodu = OdenisMetodu.Nağd,
                    MusteriId = 1
                },
                new Satis
                {
                    Id = 2,
                    Tarix = gununBasi.AddHours(12),
                    UmumiMebleg = 75.50m,
                    OdenisMetodu = OdenisMetodu.Kart,
                    MusteriId = 2
                },
                new Satis
                {
                    Id = 3,
                    Tarix = gununBasi.AddHours(14),
                    UmumiMebleg = 30.25m,
                    OdenisMetodu = OdenisMetodu.Nisyə,
                    MusteriId = 1
                }
            };

            var mockSatisRepo = new Mock<ISatisRepozitori>();
            mockSatisRepo.Setup(r => r.AxtarAsync(It.IsAny<Expression<Func<Satis, bool>>>(), null))
                .ReturnsAsync(satislar);

            var mockMusteriRepo = new Mock<IMusteriRepozitori>();
            mockMusteriRepo.Setup(r => r.AxtarAsync(It.IsAny<Expression<Func<Musteri, bool>>>(), null))
                .ReturnsAsync(musteriler);

            _unitOfWorkMock.Setup(u => u.Satislar).Returns(mockSatisRepo.Object);
            _unitOfWorkMock.Setup(u => u.Musteriler).Returns(mockMusteriRepo.Object);

            // Act
            var netice = await _hesabatManager.GunlukSatisHesabatiGetirAsync(tarix);

            // Assert
            Assert.True(netice.UgurluDur);
            Assert.NotNull(netice.Data);
            Assert.Equal(155.75m, netice.Data.UmumiDovriyye); // 50.00 + 75.50 + 30.25
            Assert.Equal(3, netice.Data.CemiSatisSayi);
            Assert.Equal(50.00m, netice.Data.NagdSatisCemi);
            Assert.Equal(75.50m, netice.Data.KartSatisCemi);
            Assert.Equal(30.25m, netice.Data.NisyeSatisCemi);
            Assert.Equal(3, netice.Data.SatislarinSiyahisi.Count);
        }

        [Fact]
        public async Task GunlukSatisHesabatiGetirAsync_MusteriAdlariDuzgun_Ugurlu()
        {
            // Arrange
            DateTime tarix = DateTime.Today;
            var gununBasi = tarix.Date;
            var gununSonu = gununBasi.AddDays(1).AddTicks(-1);

            var musteriler = new List<Musteri>
            {
                new Musteri { Id = 1, TamAd = "Test Müştəri 1" },
                new Musteri { Id = 2, TamAd = "Test Müştəri 2" }
            };

            var satislar = new List<Satis>
            {
                new Satis
                {
                    Id = 1,
                    Tarix = gununBasi.AddHours(10),
                    UmumiMebleg = 50.00m,
                    OdenisMetodu = OdenisMetodu.Nağd,
                    MusteriId = 1
                },
                new Satis
                {
                    Id = 2,
                    Tarix = gununBasi.AddHours(12),
                    UmumiMebleg = 75.50m,
                    OdenisMetodu = OdenisMetodu.Kart,
                    MusteriId = 2
                },
                new Satis
                {
                    Id = 3,
                    Tarix = gununBasi.AddHours(14),
                    UmumiMebleg = 30.25m,
                    OdenisMetodu = OdenisMetodu.Nağd
                    // MusteriId is null for this sale
                }
            };

            var mockSatisRepo = new Mock<ISatisRepozitori>();
            mockSatisRepo.Setup(r => r.AxtarAsync(It.IsAny<Expression<Func<Satis, bool>>>(), null))
                .ReturnsAsync(satislar);

            var mockMusteriRepo = new Mock<IMusteriRepozitori>();
            mockMusteriRepo.Setup(r => r.AxtarAsync(It.IsAny<Expression<Func<Musteri, bool>>>(), null))
                .ReturnsAsync(musteriler);

            _unitOfWorkMock.Setup(u => u.Satislar).Returns(mockSatisRepo.Object);
            _unitOfWorkMock.Setup(u => u.Musteriler).Returns(mockMusteriRepo.Object);

            // Act
            var netice = await _hesabatManager.GunlukSatisHesabatiGetirAsync(tarix);

            // Assert
            Assert.True(netice.UgurluDur);
            Assert.NotNull(netice.Data);
            Assert.Equal(3, netice.Data.SatislarinSiyahisi.Count);
            Assert.Equal("Test Müştəri 1", netice.Data.SatislarinSiyahisi[0].MusteriAdi);
            Assert.Equal("Test Müştəri 2", netice.Data.SatislarinSiyahisi[1].MusteriAdi);
            Assert.Equal("N/A", netice.Data.SatislarinSiyahisi[2].MusteriAdi);
        }

        [Fact]
        public async Task MehsulUzreSatisHesabatiGetirAsync_TarixAraligindaSatisYoxdur_Ugursuz()
        {
            // Arrange
            DateTime baslangic = DateTime.Today.AddDays(-7);
            DateTime bitis = DateTime.Today;

            var bosSatislar = new List<Satis>();
            var mockSatisRepo = new Mock<ISatisRepozitori>();
            mockSatisRepo.Setup(r => r.AxtarAsync(It.IsAny<Expression<Func<Satis, bool>>>(), null))
                .ReturnsAsync(bosSatislar);

            _unitOfWorkMock.Setup(u => u.Satislar).Returns(mockSatisRepo.Object);

            // Act
            var netice = await _hesabatManager.MehsulUzreSatisHesabatiGetirAsync(baslangic, bitis);

            // Assert
            Assert.False(netice.UgurluDur);
            Assert.Contains("Seçilmiş tarix aralığı üçün heç bir satış tapılmadı", netice.Mesaj);
        }

        [Fact]
        public async Task MehsulUzreSatisHesabatiGetirAsync_MehsulUzreSatislar_Ugurlu()
        {
            // Arrange
            DateTime baslangic = DateTime.Today.AddDays(-7);
            DateTime bitis = DateTime.Today;

            var mehsullar = new List<Mehsul>
            {
                new Mehsul { Id = 1, Ad = "Test Məhsulu 1", StokKodu = "SK001" },
                new Mehsul { Id = 2, Ad = "Test Məhsulu 2", StokKodu = "SK002" }
            };

            var satislar = new List<Satis>
            {
                new Satis
                {
                    Id = 1,
                    Tarix = DateTime.Today.AddDays(-5),
                    SatisDetallari = new List<SatisDetali>
                    {
                        new SatisDetali { Id = 1, MehsulId = 1, Miqdar = 2, Qiymet = 10.00m },
                        new SatisDetali { Id = 2, MehsulId = 2, Miqdar = 1, Qiymet = 15.00m }
                    }
                },
                new Satis
                {
                    Id = 2,
                    Tarix = DateTime.Today.AddDays(-3),
                    SatisDetallari = new List<SatisDetali>
                    {
                        new SatisDetali { Id = 3, MehsulId = 1, Miqdar = 3, Qiymet = 10.00m }
                    }
                }
            };

            var mockSatisRepo = new Mock<ISatisRepozitori>();
            mockSatisRepo.Setup(r => r.AxtarAsync(It.IsAny<Expression<Func<Satis, bool>>>(), null))
                .ReturnsAsync(satislar);

            var mockMehsulRepo = new Mock<IMehsulRepozitori>();
            mockMehsulRepo.Setup(r => r.AxtarAsync(It.IsAny<Expression<Func<Mehsul, bool>>>(), null))
                .ReturnsAsync(mehsullar);

            _unitOfWorkMock.Setup(u => u.Satislar).Returns(mockSatisRepo.Object);
            _unitOfWorkMock.Setup(u => u.Mehsullar).Returns(mockMehsulRepo.Object);

            // Act
            var netice = await _hesabatManager.MehsulUzreSatisHesabatiGetirAsync(baslangic, bitis);

            // Assert
            Assert.True(netice.UgurluDur);
            Assert.NotNull(netice.Data);
            Assert.Equal(2, netice.Data.Count);

            // Product 1: 5 units sold (2 + 3) for 50.00 AZN (5 * 10.00)
            var mehsul1 = netice.Data.FirstOrDefault(m => m.StokKodu == "SK001");
            Assert.NotNull(mehsul1);
            Assert.Equal(5, mehsul1.CemiSatilanMiqdar);
            Assert.Equal(50.00m, mehsul1.CemiMebleg);

            // Product 2: 1 unit sold for 15.00 AZN (1 * 15.00)
            var mehsul2 = netice.Data.FirstOrDefault(m => m.StokKodu == "SK002");
            Assert.NotNull(mehsul2);
            Assert.Equal(1, mehsul2.CemiSatilanMiqdar);
            Assert.Equal(15.00m, mehsul2.CemiMebleg);
        }
    }
}