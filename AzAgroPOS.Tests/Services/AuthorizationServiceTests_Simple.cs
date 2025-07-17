using AzAgroPOS.BLL.Services;
using AzAgroPOS.BLL.Interfaces;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.Entities.Constants;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AzAgroPOS.Tests.Services
{
    /// <summary>
    /// AuthorizationService-in sadə unit testləri
    /// Sadəcə əsas funksiyaları test edir
    /// </summary>
    public class AuthorizationServiceSimpleTests : IDisposable
    {
        private readonly Mock<RolRepository> _mockRolRepository;
        private readonly AuthorizationService _authorizationService;

        public AuthorizationServiceSimpleTests()
        {
            _mockRolRepository = new Mock<RolRepository>();
            _authorizationService = new AuthorizationService(_mockRolRepository.Object);
        }

        [Fact]
        public void SetCurrentUser_ValidUser_SetsUserCorrectly()
        {
            // Arrange
            var user = new Istifadeci
            {
                Id = 1,
                Ad = "Test",
                Soyad = "User",
                Email = "test@example.com"
            };

            // Act
            _authorizationService.SetCurrentUser(user);
            var result = _authorizationService.GetCurrentUser();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeSameAs(user);
            result.Ad.Should().Be("Test");
        }

        [Fact]
        public void GetCurrentUser_NoUserSet_ReturnsNull()
        {
            // Act
            var result = _authorizationService.GetCurrentUser();

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task HasPermissionAsync_NoCurrentUser_ReturnsFalse()
        {
            // Arrange
            _authorizationService.SetCurrentUser(null);

            // Act
            var result = await _authorizationService.HasPermissionAsync("SomePermission");

            // Assert
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("ADMINISTRATOR")]
        [InlineData("ADMIN")]
        public async Task GetMockPermissionsForRole_AdminRole_ReturnsAdminPermissions(string roleName)
        {
            // Act
            var result = await _authorizationService.GetMockPermissionsForRole(roleName);

            // Assert
            result.Should().NotBeEmpty();
            result.Should().Contain(SystemConstants.Permissions.AdminAccess);
        }

        [Theory]
        [InlineData("MANAGER")]
        [InlineData("MUDUR")]
        public async Task GetMockPermissionsForRole_ManagerRole_ReturnsManagerPermissions(string roleName)
        {
            // Act
            var result = await _authorizationService.GetMockPermissionsForRole(roleName);

            // Assert
            result.Should().NotBeEmpty();
            result.Should().NotContain(SystemConstants.Permissions.AdminAccess);
        }

        [Fact]
        public async Task GetMockPermissionsForRole_UnknownRole_ReturnsEmptyArray()
        {
            // Act
            var result = await _authorizationService.GetMockPermissionsForRole("UNKNOWN");

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        [Fact]
        public async Task GetUserPermissionsAsync_UserWithoutRole_ReturnsEmptyArray()
        {
            // Arrange
            var user = new Istifadeci
            {
                Id = 1,
                Ad = "Test",
                RolId = null
            };

            // Act
            var result = await _authorizationService.GetUserPermissionsAsync(user);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        public void Dispose()
        {
            // Cleanup if needed
        }
    }
}