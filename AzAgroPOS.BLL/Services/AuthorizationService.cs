using AzAgroPOS.BLL.Interfaces;
using AzAgroPOS.DAL;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.Entities.Constants;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.BLL.Services
{
    /// <summary>
    /// İcazə (Authorization) idarəetmə servisi
    /// </summary>
    public class AuthorizationService : IAuthorizationService
    {
        private readonly RolRepository _rolRepository;
        private Istifadeci _currentUser;

        public AuthorizationService()
        {
            var context = new AzAgroDbContext();
            _rolRepository = new RolRepository(context);
        }

        public AuthorizationService(RolRepository rolRepository)
        {
            _rolRepository = rolRepository ?? throw new ArgumentNullException(nameof(rolRepository));
        }

        public void SetCurrentUser(Istifadeci user)
        {
            _currentUser = user;
        }

        public Istifadeci GetCurrentUser()
        {
            return _currentUser;
        }

        public async Task<bool> HasPermissionAsync(string permission, Istifadeci user = null)
        {
            try
            {
                var targetUser = user ?? _currentUser;
                if (targetUser == null)
                    return false;

                // Admin istifadəçilərə bütün icazələr
                if (await IsAdminAsync(targetUser))
                    return true;

                // İstifadəçinin roluna əsasən icazələri yoxla
                var userPermissions = await GetUserPermissionsAsync(targetUser);
                return userPermissions.Contains(permission);
            }
            catch (Exception)
            {
                // Xəta halında təhlükəsizlik üçün false qaytar
                return false;
            }
        }

        public async Task<bool> IsAdminAsync(Istifadeci user = null)
        {
            try
            {
                var targetUser = user ?? _currentUser;
                if (targetUser == null)
                    return false;

                // Admin rolunu yoxla
                return await HasPermissionAsync(SystemConstants.Permissions.AdminAccess, targetUser);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<string[]> GetUserPermissionsAsync(Istifadeci user)
        {
            try
            {
                if (user?.RolId == null)
                    return new string[0];

                // İstifadəçinin rolunu və icazələrini əldə et
                var role = await _rolRepository.GetByIdAsync(user.RolId.Value);
                if (role?.RolIcazeleri == null)
                    return new string[0];

                // Rol icazələrini siyahıya çevir
                return role.RolIcazeleri
                    .Where(ri => ri.IcazeVerilib)
                    .Select(ri => $"{ri.Modul}.{ri.Emeliyyat}")
                    .ToArray();
            }
            catch (Exception)
            {
                return new string[0];
            }
        }

        /// <summary>
        /// Hazır icazə şablonları - Developer testing üçün
        /// </summary>
        public async Task<string[]> GetMockPermissionsForRole(string roleName)
        {
            switch (roleName?.ToUpper())
            {
                case "ADMINISTRATOR":
                case "ADMIN":
                    return new[]
                    {
                        SystemConstants.Permissions.AdminAccess,
                        SystemConstants.Permissions.SystemSettings,
                        SystemConstants.Permissions.UserManagement,
                        SystemConstants.Permissions.RoleManagement,
                        SystemConstants.Permissions.Musteri.View,
                        SystemConstants.Permissions.Musteri.Create,
                        SystemConstants.Permissions.Musteri.Edit,
                        SystemConstants.Permissions.Musteri.Delete,
                        SystemConstants.Permissions.Mehsul.View,
                        SystemConstants.Permissions.Mehsul.Create,
                        SystemConstants.Permissions.Mehsul.Edit,
                        SystemConstants.Permissions.Mehsul.Delete,
                        SystemConstants.Permissions.Satis.View,
                        SystemConstants.Permissions.Satis.Create,
                        SystemConstants.Permissions.Anbar.View,
                        SystemConstants.Permissions.Anbar.ManageStock,
                        SystemConstants.Permissions.Hesabat.ViewSales,
                        SystemConstants.Permissions.Hesabat.Export
                    };

                case "MANAGER":
                case "MUDUR":
                    return new[]
                    {
                        SystemConstants.Permissions.Musteri.View,
                        SystemConstants.Permissions.Musteri.Create,
                        SystemConstants.Permissions.Musteri.Edit,
                        SystemConstants.Permissions.Mehsul.View,
                        SystemConstants.Permissions.Mehsul.Create,
                        SystemConstants.Permissions.Mehsul.Edit,
                        SystemConstants.Permissions.Satis.View,
                        SystemConstants.Permissions.Satis.Create,
                        SystemConstants.Permissions.Anbar.View,
                        SystemConstants.Permissions.Hesabat.ViewSales
                    };

                case "CASHIER":
                case "KASSIR":
                    return new[]
                    {
                        SystemConstants.Permissions.Musteri.View,
                        SystemConstants.Permissions.Musteri.Create,
                        SystemConstants.Permissions.Mehsul.View,
                        SystemConstants.Permissions.Satis.View,
                        SystemConstants.Permissions.Satis.Create
                    };

                case "WORKER":
                case "ISCI":
                    return new[]
                    {
                        SystemConstants.Permissions.Musteri.View,
                        SystemConstants.Permissions.Mehsul.View,
                        SystemConstants.Permissions.Tamir.View,
                        SystemConstants.Permissions.Tamir.Edit,
                        SystemConstants.Permissions.Anbar.View
                    };

                default:
                    return new string[0];
            }
        }
    }
}