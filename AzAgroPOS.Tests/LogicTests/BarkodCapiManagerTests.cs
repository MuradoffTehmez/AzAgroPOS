// AzAgroPOS.Tests/LogicTests/BarkodCapiManagerTests.cs

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
    public class BarkodCapiManagerTests : IDisposable
    {
        private readonly AzAgroPOSDbContext _dbContext;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly BarkodCapiManager _barkodCapiManager;

        public BarkodCapiManagerTests()
        {
            _dbContext = DbContextHelper.GetInMemoryDbContext();

            _unitOfWorkMock = new Mock<IUnitOfWork>();

            // Setup UnitOfWork mock to return our in-memory database context
            _unitOfWorkMock.Setup(u => u.Mehsullar).Returns(new Mock<IMehsulRepozitori>().Object);

            _barkodCapiManager = new BarkodCapiManager(_unitOfWorkMock.Object);
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        [Fact]
        public async Task MehsullariAxtarAsync_BosAxtarisMetni_Ugursuz()
        {
            // Arrange
            string axtarisMetni = "";

            // Act
            var netice = await _barkodCapiManager.MehsullariAxtarAsync(axtarisMetni);

            // Assert
            Assert.False(netice.UgurluDur);
            Assert.Contains("Axtarış üçün mətn daxil edin", netice.Mesaj);
        }

        [Fact]
        public async Task MehsullariAxtarAsync_MehsulTapilmadi_Ugursuz()
        {
            // Arrange
            string axtarisMetni = "yox olmayan məhsul";

            var bosMehsullar = new List<Mehsul>();
            var mockMehsulRepo = new Mock<IMehsulRepozitori>();
            mockMehsulRepo.Setup(r => r.AxtarAsync(It.IsAny<Expression<Func<Mehsul, bool>>>(), null))
                .ReturnsAsync(bosMehsullar);

            _unitOfWorkMock.Setup(u => u.Mehsullar).Returns(mockMehsulRepo.Object);

            // Act
            var netice = await _barkodCapiManager.MehsullariAxtarAsync(axtarisMetni);

            // Assert
            Assert.False(netice.UgurluDur);
            Assert.Contains("Axtarışa uyğun məhsul tapılmadı", netice.Mesaj);
        }

        [Fact]
        public async Task MehsullariAxtarAsync_MehsulAdinaGoreAxtar_Ugurlu()
        {
            // Arrange
            string axtarisMetni = "çörək";

            var mehsullar = new List<Mehsul>
            {
                new Mehsul
                {
                    Id = 1,
                    Ad = "Çörək",
                    StokKodu = "SK001",
                    Barkod = "869000000001",
                    PerakendeSatisQiymeti = 0.70m,
                    AlisQiymeti = 0.50m,
                    MovcudSay = 100,
                    OlcuVahidi = OlcuVahidi.Ədəd
                }
            };

            var mockMehsulRepo = new Mock<IMehsulRepozitori>();
            mockMehsulRepo.Setup(r => r.AxtarAsync(It.IsAny<Expression<Func<Mehsul, bool>>>(), null))
                .ReturnsAsync(mehsullar);

            _unitOfWorkMock.Setup(u => u.Mehsullar).Returns(mockMehsulRepo.Object);

            // Act
            var netice = await _barkodCapiManager.MehsullariAxtarAsync(axtarisMetni);

            // Assert
            Assert.True(netice.UgurluDur);
            Assert.NotNull(netice.Data);
            Assert.Single(netice.Data);
            Assert.Equal("Çörək", netice.Data[0].Ad);
            Assert.Equal("SK001", netice.Data[0].StokKodu);
            Assert.Equal("869000000001", netice.Data[0].Barkod);
            Assert.Equal(0.70m, netice.Data[0].PerakendeSatisQiymeti);
        }

        [Fact]
        public async Task MehsullariAxtarAsync_StokKodunaGoreAxtar_Ugurlu()
        {
            // Arrange
            string axtarisMetni = "SK002";

            var mehsullar = new List<Mehsul>
            {
                new Mehsul
                {
                    Id = 2,
                    Ad = "Süd 1L",
                    StokKodu = "SK002",
                    Barkod = "869000000002",
                    PerakendeSatisQiymeti = 2.50m,
                    AlisQiymeti = 2.00m,
                    MovcudSay = 50,
                    OlcuVahidi = OlcuVahidi.Litr
                }
            };

            var mockMehsulRepo = new Mock<IMehsulRepozitori>();
            mockMehsulRepo.Setup(r => r.AxtarAsync(It.IsAny<Expression<Func<Mehsul, bool>>>(), null))
                .ReturnsAsync(mehsullar);

            _unitOfWorkMock.Setup(u => u.Mehsullar).Returns(mockMehsulRepo.Object);

            // Act
            var netice = await _barkodCapiManager.MehsullariAxtarAsync(axtarisMetni);

            // Assert
            Assert.True(netice.UgurluDur);
            Assert.NotNull(netice.Data);
            Assert.Single(netice.Data);
            Assert.Equal("Süd 1L", netice.Data[0].Ad);
            Assert.Equal("SK002", netice.Data[0].StokKodu);
            Assert.Equal("869000000002", netice.Data[0].Barkod);
            Assert.Equal(2.50m, netice.Data[0].PerakendeSatisQiymeti);
        }

        [Fact]
        public async Task MehsullariAxtarAsync_BarkodaGoreAxtar_Ugurlu()
        {
            // Arrange
            string axtarisMetni = "869000000003";

            var mehsullar = new List<Mehsul>
            {
                new Mehsul
                {
                    Id = 3,
                    Ad = "Yumurta (10 ədəd)",
                    StokKodu = "SK003",
                    Barkod = "869000000003",
                    PerakendeSatisQiymeti = 3.20m,
                    AlisQiymeti = 2.80m,
                    MovcudSay = 200,
                    OlcuVahidi = OlcuVahidi.Paket
                }
            };

            var mockMehsulRepo = new Mock<IMehsulRepozitori>();
            mockMehsulRepo.Setup(r => r.AxtarAsync(It.IsAny<Expression<Func<Mehsul, bool>>>(), null))
                .ReturnsAsync(mehsullar);

            _unitOfWorkMock.Setup(u => u.Mehsullar).Returns(mockMehsulRepo.Object);

            // Act
            var netice = await _barkodCapiManager.MehsullariAxtarAsync(axtarisMetni);

            // Assert
            Assert.True(netice.UgurluDur);
            Assert.NotNull(netice.Data);
            Assert.Single(netice.Data);
            Assert.Equal("Yumurta (10 ədəd)", netice.Data[0].Ad);
            Assert.Equal("SK003", netice.Data[0].StokKodu);
            Assert.Equal("869000000003", netice.Data[0].Barkod);
            Assert.Equal(3.20m, netice.Data[0].PerakendeSatisQiymeti);
        }

        [Fact]
        public async Task MehsullariAxtarAsync_BirNeceMehsulTapildi_Ugurlu()
        {
            // Arrange
            string axtarisMetni = "süd";

            var mehsullar = new List<Mehsul>
            {
                new Mehsul
                {
                    Id = 2,
                    Ad = "Süd 1L",
                    StokKodu = "SK002",
                    Barkod = "869000000002",
                    PerakendeSatisQiymeti = 2.50m,
                    AlisQiymeti = 2.00m,
                    MovcudSay = 50,
                    OlcuVahidi = OlcuVahidi.Litr
                },
                new Mehsul
                {
                    Id = 4,
                    Ad = "Süd Tozu 400q",
                    StokKodu = "SK004",
                    Barkod = "869000000004",
                    PerakendeSatisQiymeti = 4.50m,
                    AlisQiymeti = 3.80m,
                    MovcudSay = 30,
                    OlcuVahidi = OlcuVahidi.Paket
                }
            };

            var mockMehsulRepo = new Mock<IMehsulRepozitori>();
            mockMehsulRepo.Setup(r => r.AxtarAsync(It.IsAny<Expression<Func<Mehsul, bool>>>(), null))
                .ReturnsAsync(mehsullar);

            _unitOfWorkMock.Setup(u => u.Mehsullar).Returns(mockMehsulRepo.Object);

            // Act
            var netice = await _barkodCapiManager.MehsullariAxtarAsync(axtarisMetni);

            // Assert
            Assert.True(netice.UgurluDur);
            Assert.NotNull(netice.Data);
            Assert.Equal(2, netice.Data.Count);
            Assert.Equal("Süd 1L", netice.Data[0].Ad);
            Assert.Equal("Süd Tozu 400q", netice.Data[1].Ad);
        }
    }
}