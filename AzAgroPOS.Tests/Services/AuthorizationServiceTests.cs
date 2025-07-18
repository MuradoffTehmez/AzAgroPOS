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
    public class AuthorizationServiceTests
    {
        private readonly AuthorizationService _authorizationService;
        private readonly Mock<RolRepository> _mockRolRepository;

        public AuthorizationServiceTests()
        {
            _mockRolRepository = new Mock<RolRepository>();
            _authorizationService = new AuthorizationService(_mockRolRepository.Object);
        }

        [Fact]
        public void SetCurrentUser_ValidUser_SetsUserCorrectly()
        {
            // Arrange
            var user = new Istifadeci { Id = 1, Ad = "Test", Soyad = "User" };

            // Act
            _authorizationService.SetCurrentUser(user);
            var result = _authorizationService.GetCurrentUser();

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(1);
            result.Ad.Should().Be("Test");
        }

        [Fact]
        public void GetCurrentUser_WhenNoUserSet_ReturnsNull()
        {
            // Act
            var result = _authorizationService.GetCurrentUser();

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public async Task HasPermissionAsync_WhenUserIsNull_ReturnsFalse()
        {
            // Act
            var result = await _authorizationService.HasPermissionAsync("TestPermission");

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public async Task HasPermissionAsync_WhenUserHasPermission_ReturnsTrue()
        {
            // Arrange
            var user = new Istifadeci { Id = 1, RolId = 1 };
            var role = new Rol 
            { 
                Id = 1,
                RolIcazeleri = new List<RolIcazesi>
                {
                    new RolIcazesi { Modul = "Musteri", Emeliyyat = "Goruntule", IcazeVerilib = true }
                }
            };

            _authorizationService.SetCurrentUser(user);
            _mockRolRepository.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(role);

            // Act
            var result = await _authorizationService.HasPermissionAsync("Musteri.Goruntule");

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task HasPermissionAsync_WhenUserDoesNotHavePermission_ReturnsFalse()
        {
            // Arrange
            var user = new Istifadeci { Id = 1, RolId = 1 };
            var role = new Rol 
            { 
                Id = 1,
                RolIcazeleri = new List<RolIcazesi>
                {
                    new RolIcazesi { Modul = "Musteri", Emeliyyat = "Goruntule", IcazeVerilib = false }
                }
            };

            _authorizationService.SetCurrentUser(user);
            _mockRolRepository.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(role);

            // Act
            var result = await _authorizationService.HasPermissionAsync("Musteri.Goruntule");

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public async Task GetUserPermissionsAsync_ReturnsCorrectPermissions()
        {
            // Arrange
            var user = new Istifadeci { Id = 1, RolId = 1 };
            var role = new Rol 
            { 
                Id = 1,
                RolIcazeleri = new List<RolIcazesi>
                {
                    new RolIcazesi { Modul = "Musteri", Emeliyyat = "Goruntule", IcazeVerilib = true },
                    new RolIcazesi { Modul = "Musteri", Emeliyyat = "ElaveEt", IcazeVerilib = true },
                    new RolIcazesi { Modul = "Mehsul", Emeliyyat = "Goruntule", IcazeVerilib = false }
                }
            };

            _mockRolRepository.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(role);

            // Act
            var result = await _authorizationService.GetUserPermissionsAsync(user);

            // Assert
            result.Should().HaveCount(2);
            result.Should().Contain("Musteri.Goruntule");
            result.Should().Contain("Musteri.ElaveEt");
            result.Should().NotContain("Mehsul.Goruntule");
        }

        [Fact]
        public async Task GetMockPermissionsForRole_AdminRole_ReturnsAllPermissions()
        {
            // Act
            var result = await _authorizationService.GetMockPermissionsForRole("ADMIN");

            // Assert
            result.Should().NotBeEmpty();
            result.Should().Contain(SystemConstants.Permissions.AdminAccess);
            result.Should().Contain(SystemConstants.Permissions.Musteri.View);
            result.Should().Contain(SystemConstants.Permissions.Mehsul.Create);
        }

        [Fact]
        public async Task GetMockPermissionsForRole_CashierRole_ReturnsLimitedPermissions()
        {
            // Act
            var result = await _authorizationService.GetMockPermissionsForRole("KASSIR");

            // Assert
            result.Should().NotBeEmpty();
            result.Should().NotContain(SystemConstants.Permissions.AdminAccess);
            result.Should().Contain(SystemConstants.Permissions.Musteri.View);
            result.Should().Contain(SystemConstants.Permissions.Satis.Create);
        }

        [Fact]
        public async Task GetMockPermissionsForRole_UnknownRole_ReturnsEmpty()
        {
            // Act
            var result = await _authorizationService.GetMockPermissionsForRole("UNKNOWN");

            // Assert
            result.Should().BeEmpty();
        }
    }
}