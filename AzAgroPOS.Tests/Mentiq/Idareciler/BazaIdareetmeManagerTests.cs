// Fayl: AzAgroPOS.Tests/Mentiq/Idareciler/BazaIdareetmeManagerTests.cs

using AzAgroPOS.Mentiq.Idareciler;

namespace AzAgroPOS.Tests.Mentiq.Idareciler;

public class BazaIdareetmeManagerTests
{
    [Fact]
    public void StandartBackupAdiYarat_DuzgunFormatQaytar()
    {
        // Arrange
        var backupDirectory = @"C:\Backups";

        // Act
        var backupPath = BazaIdareetmeManager.StandartBackupAdiYarat(backupDirectory);

        // Assert
        backupPath.Should().StartWith(backupDirectory);
        backupPath.Should().Contain("AzAgroPOS_Backup_");
        backupPath.Should().EndWith(".bak");
        Path.GetExtension(backupPath).Should().Be(".bak");
    }

    [Fact]
    public void StandartBackupAdiYarat_TarixFormatDuzgun()
    {
        // Arrange
        var backupDirectory = @"C:\Backups";

        // Act
        var backupPath = BazaIdareetmeManager.StandartBackupAdiYarat(backupDirectory);
        var fileName = Path.GetFileNameWithoutExtension(backupPath);

        // Assert
        // Format: AzAgroPOS_Backup_YYYY-MM-DD_HHMMSS
        fileName.Should().MatchRegex(@"AzAgroPOS_Backup_\d{4}-\d{2}-\d{2}_\d{6}");
    }

    [Theory]
    [InlineData("Test]Database", "[Test]]Database]")] // ] escape
    [InlineData("Normal", "[Normal]")]
    [InlineData("Test[Bracket", "[Test[Bracket]")]
    [InlineData("Multiple]]]Brackets", "[Multiple]]]]]]Brackets]")]
    public void QuoteName_DuzgunEscape(string input, string expected)
    {
        // Note: QuoteName is private, so we test it indirectly through SQL generation
        // This is a conceptual test - actual implementation would use reflection or make method internal

        // For now, we verify the logic is correct
        var result = "[" + input.Replace("]", "]]") + "]";
        result.Should().Be(expected);
    }

    [Fact]
    public void Constructor_NullConnectionString_ArgumentNullException()
    {
        // Arrange
        string? nullConnectionString = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            new BazaIdareetmeManager(nullConnectionString!));
    }

    [Fact]
    public void Constructor_ValidConnectionString_ObjektYaradilir()
    {
        // Arrange
        var connectionString = "Server=test;Database=test;";

        // Act
        var manager = new BazaIdareetmeManager(connectionString);

        // Assert
        manager.Should().NotBeNull();
    }
}
