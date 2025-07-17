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
    /// AuthorizationService-in unit testləri
    /// İcazə yoxlaması əməliyyatlarının düzgün işlədiyini test edir
    /// </summary>
    public class AuthorizationServiceTests : IDisposable
    {
        private readonly Mock<RolRepository> _mockRolRepository;
        private readonly AuthorizationService _authorizationService;
        private readonly Istifadeci _testUser;
        private readonly Rol _testRole;

        public AuthorizationServiceTests()
        {
            _mockRolRepository = new Mock<RolRepository>();
            _authorizationService = new AuthorizationService(_mockRolRepository.Object);

            // Test data hazırlığı
            _testRole = new Rol
            {
                Id = 1,
                Ad = "Manager",
                RolIcazeleri = new List<RolIcazesi>
                {
                    new RolIcazesi
                    {
                        RolId = 1,
                        IcazeId = 1,
                        Icaze = new Icaze { Id = 1, IcazeAdi = SystemConstants.Permissions.Musteri.View }
                    },
                    new RolIcazesi
                    {
                        RolId = 1,
                        IcazeId = 2,
                        Icaze = new Icaze { Id = 2, IcazeAdi = SystemConstants.Permissions.Musteri.Create }
                    }
                }
            };

            _testUser = new Istifadeci
            {
                Id = 1,
                IstifadeciAdi = "testuser",
                TamAd = "Test İstifadəçi",
                RolId = 1,
                Rol = _testRole
            };
        }

        #region HasPermissionAsync Tests

        [Fact]
        public async Task HasPermissionAsync_UserHasPermission_ReturnsTrue()
        {
            // Arrange
            _authorizationService.SetCurrentUser(_testUser);
            _mockRolRepository.Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(_testRole);

            // Act
            var result = await _authorizationService.HasPermissionAsync(SystemConstants.Permissions.Musteri.View);

            // Assert
            result.Should().BeTrue("çünki istifadəçinin bu icazəsi var");
        }

        [Fact]
        public async Task HasPermissionAsync_UserDoesNotHavePermission_ReturnsFalse()
        {
            // Arrange
            _authorizationService.SetCurrentUser(_testUser);
            _mockRolRepository.Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(_testRole);

            // Act
            var result = await _authorizationService.HasPermissionAsync(SystemConstants.Permissions.Anbar.Delete);

            // Assert
            result.Should().BeFalse("çünki istifadəçinin bu icazəsi yoxdur");
        }

        [Fact]
        public async Task HasPermissionAsync_NoCurrentUser_ReturnsFalse()
        {
            // Arrange
            _authorizationService.SetCurrentUser(null);

            // Act
            var result = await _authorizationService.HasPermissionAsync(SystemConstants.Permissions.Musteri.View);

            // Assert
            result.Should().BeFalse("çünki cari istifadəçi yoxdur");
        }

        [Fact]
        public async Task HasPermissionAsync_AdminUser_ReturnsTrue()
        {
            // Arrange
            var adminRole = new Rol
            {
                Id = 2,
                Ad = "Administrator",
                RolIcazeleri = new List<RolIcazesi>
                {
                    new RolIcazesi
                    {
                        RolId = 2,
                        IcazeId = 99,
                        Icaze = new Icaze { Id = 99, IcazeAdi = SystemConstants.Permissions.AdminAccess }
                    }
                }
            };

            var adminUser = new Istifadeci
            {
                Id = 2,
                IstifadeciAdi = "admin",
                RolId = 2,
                Rol = adminRole
            };

            _authorizationService.SetCurrentUser(adminUser);
            _mockRolRepository.Setup(r => r.GetByIdAsync(2))
                .ReturnsAsync(adminRole);

            // Act
            var result = await _authorizationService.HasPermissionAsync(SystemConstants.Permissions.Mehsul.Delete);

            // Assert
            result.Should().BeTrue("çünki admin istifadəçilərin bütün icazələri var");
        }

        [Fact]
        public async Task HasPermissionAsync_WithSpecificUser_ReturnsCorrectResult()
        {
            // Arrange
            var specificUser = new Istifadeci
            {
                Id = 3,
                IstifadeciAdi = "specificuser",
                RolId = 1
            };

            _mockRolRepository.Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(_testRole);

            // Act
            var result = await _authorizationService.HasPermissionAsync(
                SystemConstants.Permissions.Musteri.View, specificUser);

            // Assert
            result.Should().BeTrue("çünki müəyyən istifadəçinin bu icazəsi var");
        }

        [Fact]
        public async Task HasPermissionAsync_ExceptionThrown_ReturnsFalse()
        {
            // Arrange
            _authorizationService.SetCurrentUser(_testUser);
            _mockRolRepository.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                .ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _authorizationService.HasPermissionAsync(SystemConstants.Permissions.Musteri.View);

            // Assert
            result.Should().BeFalse("çünki xəta halında təhlükəsizlik üçün false qaytarılmalıdır");
        }

        #endregion

        #region IsAdminAsync Tests

        [Fact]
        public async Task IsAdminAsync_AdminUser_ReturnsTrue()
        {
            // Arrange
            var adminRole = new Rol
            {
                Id = 2,
                Ad = "Administrator",
                RolIcazeleri = new List<RolIcazesi>
                {
                    new RolIcazesi
                    {
                        RolId = 2,
                        IcazeId = 99,
                        Icaze = new Icaze { Id = 99, IcazeAdi = SystemConstants.Permissions.AdminAccess }
                    }
                }
            };

            var adminUser = new Istifadeci
            {
                Id = 2,
                IstifadeciAdi = "admin",
                RolId = 2
            };

            _authorizationService.SetCurrentUser(adminUser);
            _mockRolRepository.Setup(r => r.GetByIdAsync(2))
                .ReturnsAsync(adminRole);

            // Act
            var result = await _authorizationService.IsAdminAsync();

            // Assert
            result.Should().BeTrue("çünki istifadəçi admin icazəsinə malikdir");
        }

        [Fact]
        public async Task IsAdminAsync_NonAdminUser_ReturnsFalse()
        {
            // Arrange
            _authorizationService.SetCurrentUser(_testUser);
            _mockRolRepository.Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(_testRole);

            // Act
            var result = await _authorizationService.IsAdminAsync();

            // Assert
            result.Should().BeFalse("çünki istifadəçi admin deyil");
        }

        [Fact]
        public async Task IsAdminAsync_NoUser_ReturnsFalse()
        {
            // Arrange
            _authorizationService.SetCurrentUser(null);

            // Act
            var result = await _authorizationService.IsAdminAsync();

            // Assert
            result.Should().BeFalse("çünki cari istifadəçi yoxdur");
        }

        #endregion

        #region GetUserPermissionsAsync Tests

        [Fact]
        public async Task GetUserPermissionsAsync_ValidUser_ReturnsPermissions()
        {
            // Arrange
            _mockRolRepository.Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(_testRole);

            // Act
            var result = await _authorizationService.GetUserPermissionsAsync(_testUser);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result.Should().Contain(SystemConstants.Permissions.Musteri.View);
            result.Should().Contain(SystemConstants.Permissions.Musteri.Create);
        }

        [Fact]
        public async Task GetUserPermissionsAsync_UserWithNoRole_ReturnsEmptyArray()
        {
            // Arrange
            var userWithoutRole = new Istifadeci
            {
                Id = 5,
                IstifadeciAdi = "noroleuser",
                RolId = null
            };

            // Act
            var result = await _authorizationService.GetUserPermissionsAsync(userWithoutRole);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        [Fact]
        public async Task GetUserPermissionsAsync_RoleNotFound_ReturnsEmptyArray()
        {
            // Arrange
            _mockRolRepository.Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync((Rol)null);

            // Act
            var result = await _authorizationService.GetUserPermissionsAsync(_testUser);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        [Fact]
        public async Task GetUserPermissionsAsync_RoleWithNoPermissions_ReturnsEmptyArray()
        {
            // Arrange
            var emptyRole = new Rol
            {
                Id = 3,
                Ad = "EmptyRole",
                RolIcazeleri = new List<RolIcazesi>()
            };

            var userWithEmptyRole = new Istifadeci
            {
                Id = 6,
                RolId = 3
            };

            _mockRolRepository.Setup(r => r.GetByIdAsync(3))
                .ReturnsAsync(emptyRole);

            // Act
            var result = await _authorizationService.GetUserPermissionsAsync(userWithEmptyRole);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        [Fact]
        public async Task GetUserPermissionsAsync_ExceptionThrown_ReturnsEmptyArray()
        {
            // Arrange
            _mockRolRepository.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                .ThrowsAsync(new Exception("Database error"));

            // Act
            var result = await _authorizationService.GetUserPermissionsAsync(_testUser);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        #endregion

        #region SetCurrentUser and GetCurrentUser Tests

        [Fact]
        public void SetCurrentUser_ValidUser_SetsCurrentUser()
        {
            // Act
            _authorizationService.SetCurrentUser(_testUser);
            var result = _authorizationService.GetCurrentUser();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeSameAs(_testUser);
            result.Id.Should().Be(_testUser.Id);
        }

        [Fact]
        public void SetCurrentUser_NullUser_SetsCurrentUserToNull()
        {
            // Act
            _authorizationService.SetCurrentUser(null);
            var result = _authorizationService.GetCurrentUser();

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void GetCurrentUser_NoUserSet_ReturnsNull()
        {
            // Act
            var result = _authorizationService.GetCurrentUser();

            // Assert
            result.Should().BeNull();
        }

        #endregion

        #region GetMockPermissionsForRole Tests

        [Theory]
        [InlineData("ADMINISTRATOR")]
        [InlineData("ADMIN")]
        public async Task GetMockPermissionsForRole_AdminRole_ReturnsAllPermissions(string roleName)
        {
            // Act
            var result = await _authorizationService.GetMockPermissionsForRole(roleName);

            // Assert
            result.Should().NotBeEmpty();
            result.Should().Contain(SystemConstants.Permissions.AdminAccess);
            result.Should().Contain(SystemConstants.Permissions.Musteri.View);
            result.Should().Contain(SystemConstants.Permissions.Mehsul.Create);
            result.Should().Contain(SystemConstants.Permissions.Satis.View);
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
            result.Should().Contain(SystemConstants.Permissions.Musteri.View);
            result.Should().Contain(SystemConstants.Permissions.Mehsul.Create);
            result.Should().NotContain(SystemConstants.Permissions.AdminAccess);
            result.Should().NotContain(SystemConstants.Permissions.Mehsul.Delete);
        }

        [Theory]
        [InlineData("CASHIER")]
        [InlineData("KASSIR")]
        public async Task GetMockPermissionsForRole_CashierRole_ReturnsCashierPermissions(string roleName)
        {
            // Act
            var result = await _authorizationService.GetMockPermissionsForRole(roleName);

            // Assert
            result.Should().NotBeEmpty();
            result.Should().Contain(SystemConstants.Permissions.Musteri.View);
            result.Should().Contain(SystemConstants.Permissions.Satis.Create);
            result.Should().NotContain(SystemConstants.Permissions.Mehsul.Edit);
            result.Should().NotContain(SystemConstants.Permissions.AdminAccess);
        }

        [Theory]
        [InlineData("WORKER")]
        [InlineData("ISCI")]
        public async Task GetMockPermissionsForRole_WorkerRole_ReturnsWorkerPermissions(string roleName)
        {
            // Act
            var result = await _authorizationService.GetMockPermissionsForRole(roleName);

            // Assert
            result.Should().NotBeEmpty();
            result.Should().Contain(SystemConstants.Permissions.Tamir.View);
            result.Should().Contain(SystemConstants.Permissions.Anbar.View);
            result.Should().NotContain(SystemConstants.Permissions.Satis.Create);
            result.Should().NotContain(SystemConstants.Permissions.AdminAccess);
        }

        [Fact]
        public async Task GetMockPermissionsForRole_UnknownRole_ReturnsEmptyArray()
        {
            // Act
            var result = await _authorizationService.GetMockPermissionsForRole("UNKNOWN_ROLE");

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        [Fact]
        public async Task GetMockPermissionsForRole_NullRole_ReturnsEmptyArray()
        {
            // Act
            var result = await _authorizationService.GetMockPermissionsForRole(null);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        [Fact]
        public async Task GetMockPermissionsForRole_EmptyRole_ReturnsEmptyArray()
        {
            // Act
            var result = await _authorizationService.GetMockPermissionsForRole("");

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        #endregion

        #region Integration Tests

        [Fact]
        public async Task FullWorkflow_CreateUserCheckPermissions_WorksCorrectly()
        {
            // Arrange
            var managerRole = new Rol
            {
                Id = 10,
                Ad = "ProjectManager",
                RolIcazeleri = new List<RolIcazesi>
                {
                    new RolIcazesi
                    {
                        RolId = 10,
                        IcazeId = 1,
                        Icaze = new Icaze { Id = 1, IcazeAdi = SystemConstants.Permissions.Musteri.View }
                    },
                    new RolIcazesi
                    {
                        RolId = 10,
                        IcazeId = 2,
                        Icaze = new Icaze { Id = 2, IcazeAdi = SystemConstants.Permissions.Hesabat.ViewSales }
                    }
                }
            };

            var projectManager = new Istifadeci
            {
                Id = 100,
                IstifadeciAdi = "projectmanager",
                TamAd = "Layihə Meneceri",
                RolId = 10
            };

            _mockRolRepository.Setup(r => r.GetByIdAsync(10))
                .ReturnsAsync(managerRole);

            // Act & Assert
            _authorizationService.SetCurrentUser(projectManager);

            var currentUser = _authorizationService.GetCurrentUser();
            currentUser.Should().BeSameAs(projectManager);

            var hasCustomerView = await _authorizationService.HasPermissionAsync(SystemConstants.Permissions.Musteri.View);
            hasCustomerView.Should().BeTrue();

            var hasReportView = await _authorizationService.HasPermissionAsync(SystemConstants.Permissions.Hesabat.ViewSales);
            hasReportView.Should().BeTrue();

            var hasProductDelete = await _authorizationService.HasPermissionAsync(SystemConstants.Permissions.Mehsul.Delete);
            hasProductDelete.Should().BeFalse();

            var isAdmin = await _authorizationService.IsAdminAsync();
            isAdmin.Should().BeFalse();

            var permissions = await _authorizationService.GetUserPermissionsAsync(projectManager);
            permissions.Should().HaveCount(2);
            permissions.Should().Contain(SystemConstants.Permissions.Musteri.View);
            permissions.Should().Contain(SystemConstants.Permissions.Hesabat.ViewSales);
        }

        #endregion

        public void Dispose()
        {
            // Cleanup kod əlavə edilə bilər
        }
    }
}