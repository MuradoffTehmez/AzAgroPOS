using Xunit;
using FluentAssertions;

namespace AzAgroPOS.Tests;

/// <summary>
/// Əsas test infrastrukturunun işlədiyini yoxlayan sadə test
/// </summary>
public class BasicInfrastructureTests
{
    [Fact]
    public void TestInfrastructure_IsWorking()
    {
        // Arrange
        var expected = 42;
        
        // Act
        var actual = 42;
        
        // Assert
        actual.Should().Be(expected, "test infrastructure düzgün işləməlidir");
    }

    [Theory]
    [InlineData(1, 1, 2)]
    [InlineData(5, 3, 8)]
    [InlineData(-1, 1, 0)]
    public void BasicMath_Addition_WorksCorrectly(int a, int b, int expected)
    {
        // Act
        var result = a + b;
        
        // Assert
        result.Should().Be(expected, $"çünki {a} + {b} = {expected} olmalıdır");
    }
}