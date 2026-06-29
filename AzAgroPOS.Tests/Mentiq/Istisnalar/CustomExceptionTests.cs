// Fayl: AzAgroPOS.Tests/Mentiq/Istisnalar/CustomExceptionTests.cs

using AzAgroPOS.Mentiq.Istisnalar;

namespace AzAgroPOS.Tests.Mentiq.Istisnalar;

public class CustomExceptionTests
{
    [Fact]
    public void TesdiqIstisnasi_DuzgunYaradilir()
    {
        // Arrange
        string mesaj = "Ad sahəsi boş ola bilməz";
        string saheAdi = "Ad";

        // Act
        TesdiqIstisnasi exception = new(mesaj, saheAdi);

        // Assert
        exception.IstifadeciMesaji.Should().Be(mesaj);
        exception.SaheAdi.Should().Be(saheAdi);
        exception.Message.Should().Be(mesaj);
    }

    [Fact]
    public void BiznesQaydasiIstisnasi_DuzgunYaradilir()
    {
        // Arrange
        string mesaj = "Stokda kifayət qədər məhsul yoxdur";
        string qaydaKodu = "STOK_KIFAYETSIZ";

        // Act
        BiznesQaydasiIstisnasi exception = new(mesaj, qaydaKodu);

        // Assert
        exception.IstifadeciMesaji.Should().Be(mesaj);
        exception.QaydaKodu.Should().Be(qaydaKodu);
    }

    [Fact]
    public void MelumatTapilmadiIstisnasi_DuzgunYaradilir()
    {
        // Arrange
        string mesaj = "Məhsul tapılmadı";
        string entityNovu = "Məhsul";
        int identifikator = 123;

        // Act
        MelumatTapilmadiIstisnasi exception = new(mesaj, entityNovu, identifikator);

        // Assert
        exception.IstifadeciMesaji.Should().Be(mesaj);
        exception.EntityNovu.Should().Be(entityNovu);
        exception.Identifikator.Should().Be(identifikator);
    }

    [Fact]
    public void VerilenlerBazasiIstisnasi_SqlKoduIle_DuzgunYaradilir()
    {
        // Arrange
        string mesaj = "Foreign key constraint pozuldu";
        int sqlKod = 547;
        Exception innerException = new("Inner error");

        // Act
        VerilenlerBazasiIstisnasi exception = new(mesaj, sqlKod, null, innerException);

        // Assert
        exception.IstifadeciMesaji.Should().Be(mesaj);
        exception.SqlXetaKodu.Should().Be(sqlKod);
        exception.InnerException.Should().Be(innerException);
    }

    [Fact]
    public void TehlukesizlikIstisnasi_DuzgunYaradilir()
    {
        // Arrange
        string mesaj = "İstifadəçi adı və ya parol yanlışdır";
        TehlukesizlikXetasiNovu xetaNovu = TehlukesizlikXetasiNovu.YanlisIstifadeciVeyaParol;

        // Act
        TehlukesizlikIstisnasi exception = new(mesaj, xetaNovu);

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
        string mesaj = "Test mesajı";

        // Act
        TehlukesizlikIstisnasi exception = new(mesaj, xetaNovu);

        // Assert
        exception.XetaNovu.Should().Be(xetaNovu);
    }

    [Fact]
    public void AzAgroPOSIstisnasi_TexnikiDetallari_DuzgunSaxlanir()
    {
        // Arrange
        string istifadeciMesaji = "İstifadəçi mesajı";
        string texnikiDetallar = "Texniki detallar: Stack trace, inner details";

        // Act
        TesdiqIstisnasi exception = new(istifadeciMesaji, null, texnikiDetallar);

        // Assert
        exception.IstifadeciMesaji.Should().Be(istifadeciMesaji);
        exception.TexnikiDetallar.Should().Be(texnikiDetallar);
    }
}
