using AzAgroPOS.Entities.Domain;
using System.Threading.Tasks;

namespace AzAgroPOS.BLL.Interfaces
{
    /// <summary>
    /// İcazə (Authorization) idarəetmə servisi interface
    /// </summary>
    public interface IAuthorizationService
    {
        /// <summary>
        /// İstifadəçinin müəyyən icazəsinin olub-olmadığını yoxlayır
        /// </summary>
        /// <param name="permission">İcazə adı</param>
        /// <param name="user">İstifadəçi (null olarsa hazırkı istifadəçi götürülür)</param>
        /// <returns>İcazə varmı?</returns>
        Task<bool> HasPermissionAsync(string permission, Istifadeci user = null);

        /// <summary>
        /// İstifadəçinin admin icazəsinin olub-olmadığını yoxlayır
        /// </summary>
        /// <param name="user">İstifadəçi (null olarsa hazırkı istifadəçi götürülür)</param>
        /// <returns>Admin icazəsi varmı?</returns>
        Task<bool> IsAdminAsync(Istifadeci user = null);

        /// <summary>
        /// İstifadəçinin roluna əsasən icazələri yükləyir
        /// </summary>
        /// <param name="user">İstifadəçi</param>
        /// <returns>İcazələrin siyahısı</returns>
        Task<string[]> GetUserPermissionsAsync(Istifadeci user);

        /// <summary>
        /// Hazırkı sessiya istifadəçisini təyin edir
        /// </summary>
        /// <param name="user">İstifadəçi</param>
        void SetCurrentUser(Istifadeci user);

        /// <summary>
        /// Hazırkı sessiya istifadəçisini alır
        /// </summary>
        /// <returns>Hazırkı istifadəçi</returns>
        Istifadeci GetCurrentUser();
    }
}