// Fayl: AzAgroPOS.Tests/Mentiq/Istisnalar/CustomExceptionTests.cs

using AzAgroPOS.Mentiq.Istisnalar;

namespace AzAgroPOS.Tests.Mentiq.Istisnalar;

public class CustomExceptionTests
{
    [Fact]
    public void TesdiqIstisnasi_DuzgunYaradilir()
    {
        // Arrange
        var mesaj = "Ad sahəsi boş ola bilməz";
        var saheAdi = "Ad";

        // Act
        var exception = new TesdiqIstisnasi(mesaj, saheAdi);

        // Assert
        exception.IstifadeciMesaji.Should().Be(mesaj);
        exception.SaheAdi.Should().Be(saheAdi);
        exception.Message.Should().Be(mesaj);
    }

    [Fact]
    public void BiznesQaydasiIstisnasi_DuzgunYaradilir()
    {
        // Arrange
        var mesaj = "Stokda kifayət qədər məhsul yoxdur";
        var qaydaKodu = "STOK_KIFAYETSIZ";

        // Act
        var exception = new BiznesQaydasiIstisnasi(mesaj, qaydaKodu);

        // Assert
        exception.IstifadeciMesaji.Should().Be(mesaj);
        exception.QaydaKodu.Should().Be(qaydaKodu);
    }

    [Fact]
    public void MelumatTapilmadiIstisnasi_DuzgunYaradilir()
    {
        // Arrange
        var mesaj = "Məhsul tapılmadı";
        var entityNovu = "Məhsul";
        var identifikator = 123;

        // Act
        var exception = new MelumatTapilmadiIstisnasi(mesaj, entityNovu, identifikator);

        // Assert
        exception.IstifadeciMesaji.Should().Be(mesaj);
        exception.EntityNovu.Should().Be(entityNovu);
        exception.Identifikator.Should().Be(identifikator);
    }

    [Fact]
    public void VerilenlerBazasiIstisnasi_SqlKoduIle_DuzgunYaradilir()
    {
        // Arrange
        var mesaj = "Foreign key constraint pozuldu";
        var sqlKod = 547;
        var innerException = new Exception("Inner error");

        // Act
        var exception = new VerilenlerBazasiIstisnasi(mesaj, sqlKod, null, innerException);

        // Assert
        exception.IstifadeciMesaji.Should().Be(mesaj);
        exception.SqlXetaKodu.Should().Be(sqlKod);
        exception.InnerException.Should().Be(innerException);
    }

    [Fact]
    public void TehlukesizlikIstisnasi_DuzgunYaradilir()
    {
        // Arrange
        var mesaj = "İstifadəçi adı və ya parol yanlışdır";
        var xetaNovu = TehlukesizlikXetasiNovu.YanlisIstifadeciVeyaParol;

        // Act
        var exception = new TehlukesizlikIstisnasi(mesaj, xetaNovu);

        // Assert
        exception.IstifadeciMesaji.Should().Be(mesaj);
        exception.XetaNovu.Should().Be(xetaNovu);
    }

    [Theory]
    [InlineData(TehlukesizlikXetasiNovu.YanlisIstifadeciVeyaParol)]
    [InlineData(TehlukesizlikXetasiNovu.HesabKilidlenmə)]
    [InlineData(TehlukesizlikXetasiNovu.HesabDeaktiv)]
    [InlineData(TehlukesizlikXetasiNovu.IcazeYoxdur)]
    [InlineData(TehlukesizlikXetasiNovu.SessiyaBitib)]
    public void TehlukesizlikIstisnasi_ButunXetaNovleri_DuzgunYaradilir(TehlukesizlikXetasiNovu xetaNovu)
    {
        // Arrange
        var mesaj = "Test mesajı";

        // Act
        var exception = new TehlukesizlikIstisnasi(mesaj, xetaNovu);

        // Assert
        exception.XetaNovu.Should().Be(xetaNovu);
    }

    [Fact]
    public void AzAgroPOSIstisnasi_TexnikiDetallari_DuzgunSaxlanir()
    {
        // Arrange
        var istifadeciMesaji = "İstifadəçi mesajı";
        var texnikiDetallar = "Texniki detallar: Stack trace, inner details";

        // Act
        var exception = new TesdiqIstisnasi(istifadeciMesaji, null, texnikiDetallar);

        // Assert
        exception.IstifadeciMesaji.Should().Be(istifadeciMesaji);
        exception.TexnikiDetallar.Should().Be(texnikiDetallar);
    }
}
