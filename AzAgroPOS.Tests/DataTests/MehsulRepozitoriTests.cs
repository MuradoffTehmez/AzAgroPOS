using AzAgroPOS.Tests.Helpers;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AzAgroPOS.Tests.DataTests
{
    public class MehsulRepozitoriTests : IDisposable
    {
        private readonly AzAgroPOSDbContext _dbContext;
        private readonly MehsulRepozitori _mehsulRepozitori;

        public MehsulRepozitoriTests()
        {
            _dbContext = DbContextHelper.GetInMemoryDbContext();
            _mehsulRepozitori = new MehsulRepozitori(_dbContext);
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }

        [Fact]
        public async Task ElaveEtAsync_MehsulElaveEdilir()
        {
            // Arrange
            var yeniMehsul = new Mehsul
            {
                Ad = "Test Məhsulu",
                StokKodu = "SK999",
                Barkod = "999999999999",
                PerakendeSatisQiymeti = 15.50m,
                AlisQiymeti = 12.00m,
                MovcudSay = 100,
                OlcuVahidi = OlcuVahidi.Ədəd
            };

            // Act
            await _mehsulRepozitori.ElaveEtAsync(yeniMehsul);
            await _dbContext.SaveChangesAsync();

            // Assert
            var elaveEdilmisMehsul = await _dbContext.Mehsullar.FirstOrDefaultAsync(m => m.StokKodu == "SK999");
            Assert.NotNull(elaveEdilmisMehsul);
            Assert.Equal("Test Məhsulu", elaveEdilmisMehsul.Ad);
            Assert.Equal("999999999999", elaveEdilmisMehsul.Barkod);
            Assert.Equal(15.50m, elaveEdilmisMehsul.PerakendeSatisQiymeti);
        }

        [Fact]
        public async Task GetirAsync_MehsulIdyeGoreMehsulGetirilir()
        {
            // Arrange
            var mehsul = new Mehsul
            {
                Ad = "Test Məhsulu",
                StokKodu = "SK999",
                Barkod = "999999999999",
                PerakendeSatisQiymeti = 15.50m,
                AlisQiymeti = 12.00m,
                MovcudSay = 100,
                OlcuVahidi = OlcuVahidi.Ədəd
            };

            _dbContext.Mehsullar.Add(mehsul);
            await _dbContext.SaveChangesAsync();

            // Act
            var eldeEdilmisMehsul = await _mehsulRepozitori.GetirAsync(mehsul.Id);

            // Assert
            Assert.NotNull(eldeEdilmisMehsul);
            Assert.Equal(mehsul.Id, eldeEdilmisMehsul.Id);
            Assert.Equal("Test Məhsulu", eldeEdilmisMehsul.Ad);
            Assert.Equal("SK999", eldeEdilmisMehsul.StokKodu);
        }

        [Fact]
        public async Task ButununuGetirAsync_ButunMehsullarGetirilir()
        {
            // Arrange
            var mehsullar = new List<Mehsul>
            {
                new Mehsul
                {
                    Ad = "Test Məhsulu 1",
                    StokKodu = "SK001",
                    Barkod = "869000000001",
                    PerakendeSatisQiymeti = 10.00m,
                    AlisQiymeti = 8.00m,
                    MovcudSay = 50,
                    OlcuVahidi = OlcuVahidi.Ədəd
                },
                new Mehsul
                {
                    Ad = "Test Məhsulu 2",
                    StokKodu = "SK002",
                    Barkod = "869000000002",
                    PerakendeSatisQiymeti = 15.50m,
                    AlisQiymeti = 12.00m,
                    MovcudSay = 30,
                    OlcuVahidi = OlcuVahidi.Ədəd
                }
            };

            _dbContext.Mehsullar.AddRange(mehsullar);
            await _dbContext.SaveChangesAsync();

            // Act
            var eldeEdilmisMehsullar = await _mehsulRepozitori.ButununuGetirAsync();

            // Assert
            Assert.NotNull(eldeEdilmisMehsullar);
            Assert.Equal(2, eldeEdilmisMehsullar.Count());
            Assert.Contains(eldeEdilmisMehsullar, m => m.StokKodu == "SK001");
            Assert.Contains(eldeEdilmisMehsullar, m => m.StokKodu == "SK002");
        }

        [Fact]
        public async Task AxtarAsync_MehsulAdinaGoreAxtar()
        {
            // Arrange
            var mehsullar = new List<Mehsul>
            {
                new Mehsul
                {
                    Ad = "Çörək",
                    StokKodu = "SK001",
                    Barkod = "869000000001",
                    PerakendeSatisQiymeti = 0.70m,
                    AlisQiymeti = 0.50m,
                    MovcudSay = 100,
                    OlcuVahidi = OlcuVahidi.Ədəd
                },
                new Mehsul
                {
                    Ad = "Süd 1L",
                    StokKodu = "SK002",
                    Barkod = "869000000002",
                    PerakendeSatisQiymeti = 2.50m,
                    AlisQiymeti = 2.00m,
                    MovcudSay = 50,
                    OlcuVahidi = OlcuVahidi.Litr
                }
            };

            _dbContext.Mehsullar.AddRange(mehsullar);
            await _dbContext.SaveChangesAsync();

            // Act
            var tapilanMehsullar = await _mehsulRepozitori.AxtarAsync(m => m.Ad.Contains("Çörək"));

            // Assert
            Assert.NotNull(tapilanMehsullar);
            Assert.Single(tapilanMehsullar);
            Assert.Equal("Çörək", tapilanMehsullar.First().Ad);
        }

        [Fact]
        public async Task AxtarAsync_StokKodunaGoreAxtar()
        {
            // Arrange
            var mehsullar = new List<Mehsul>
            {
                new Mehsul
                {
                    Ad = "Çörək",
                    StokKodu = "SK001",
                    Barkod = "869000000001",
                    PerakendeSatisQiymeti = 0.70m,
                    AlisQiymeti = 0.50m,
                    MovcudSay = 100,
                    OlcuVahidi = OlcuVahidi.Ədəd
                },
                new Mehsul
                {
                    Ad = "Süd 1L",
                    StokKodu = "SK002",
                    Barkod = "869000000002",
                    PerakendeSatisQiymeti = 2.50m,
                    AlisQiymeti = 2.00m,
                    MovcudSay = 50,
                    OlcuVahidi = OlcuVahidi.Litr
                }
            };

            _dbContext.Mehsullar.AddRange(mehsullar);
            await _dbContext.SaveChangesAsync();

            // Act
            var tapilanMehsullar = await _mehsulRepozitori.AxtarAsync(m => m.StokKodu == "SK002");

            // Assert
            Assert.NotNull(tapilanMehsullar);
            Assert.Single(tapilanMehsullar);
            Assert.Equal("Süd 1L", tapilanMehsullar.First().Ad);
            Assert.Equal("SK002", tapilanMehsullar.First().StokKodu);
        }

        [Fact]
        public async Task YenileAsync_MehsulMəlumatlarıYenilənir()
        {
            // Arrange
            var mehsul = new Mehsul
            {
                Ad = "Əvvəlki Ad",
                StokKodu = "SK999",
                Barkod = "999999999999",
                PerakendeSatisQiymeti = 10.00m,
                AlisQiymeti = 8.00m,
                MovcudSay = 50,
                OlcuVahidi = OlcuVahidi.Ədəd
            };

            _dbContext.Mehsullar.Add(mehsul);
            await _dbContext.SaveChangesAsync();

            // Act
            mehsul.Ad = "Yenilənmiş Ad";
            mehsul.PerakendeSatisQiymeti = 12.50m;
            _mehsulRepozitori.Yenile(mehsul);
            await _dbContext.SaveChangesAsync();

            // Assert
            var yenilənmişMehsul = await _dbContext.Mehsullar.FirstOrDefaultAsync(m => m.Id == mehsul.Id);
            Assert.NotNull(yenilənmişMehsul);
            Assert.Equal("Yenilənmiş Ad", yenilənmişMehsul.Ad);
            Assert.Equal(12.50m, yenilənmişMehsul.PerakendeSatisQiymeti);
        }

        [Fact]
        public async Task SilAsync_MehsulSilinir()
        {
            // Arrange
            var mehsul = new Mehsul
            {
                Ad = "Silinəcək Məhsul",
                StokKodu = "SK999",
                Barkod = "999999999999",
                PerakendeSatisQiymeti = 10.00m,
                AlisQiymeti = 8.00m,
                MovcudSay = 50,
                OlcuVahidi = OlcuVahidi.Ədəd
            };

            _dbContext.Mehsullar.Add(mehsul);
            await _dbContext.SaveChangesAsync();

            // Act
            _mehsulRepozitori.Sil(mehsul);
            await _dbContext.SaveChangesAsync();

            // Assert
            var silinmişMehsul = await _dbContext.Mehsullar.FirstOrDefaultAsync(m => m.Id == mehsul.Id);
            Assert.Null(silinmişMehsul);
        }
    }
}