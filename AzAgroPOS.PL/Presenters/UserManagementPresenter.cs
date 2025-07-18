using AzAgroPOS.BLL.Interfaces;
using AzAgroPOS.BLL.Services;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.PL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzAgroPOS.PL.Presenters
{
    /// <summary>
    /// MVP Pattern - User Management Presenter
    /// Bu sinif, UserManagementForm və biznes məntiqi arasında körpü rolunu oynayır
    /// </summary>
    public class UserManagementPresenter : IDisposable
    {
        private readonly IUserManagementView _view;
        private readonly IstifadeciRepository _istifadeciRepository;
        private readonly RolRepository _rolRepository;
        private readonly AuthService _authService;
        private readonly AuditLogService _auditLogService;
        private readonly Istifadeci _currentUser;
        
        private List<Istifadeci> _filteredUsers;
        private int _currentPageNumber = 1;
        private const int PageSize = 100;
        private bool _disposed = false;

        public UserManagementPresenter(
            IUserManagementView view,
            IstifadeciRepository istifadeciRepository,
            RolRepository rolRepository,
            AuthService authService,
            AuditLogService auditLogService,
            Istifadeci currentUser)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _istifadeciRepository = istifadeciRepository ?? throw new ArgumentNullException(nameof(istifadeciRepository));
            _rolRepository = rolRepository ?? throw new ArgumentNullException(nameof(rolRepository));
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            _auditLogService = auditLogService ?? throw new ArgumentNullException(nameof(auditLogService));
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));

            SubscribeToViewEvents();
        }

        /// <summary>
        /// View-in hadisələrinə abunə olmaq
        /// </summary>
        private void SubscribeToViewEvents()
        {
            _view.LoadUsersEvent += OnLoadUsers;
            _view.RefreshEvent += OnRefresh;
            _view.SearchEvent += OnSearch;
            _view.FilterChangedEvent += OnFilterChanged;
            _view.AddUserEvent += OnAddUser;
            _view.EditUserEvent += OnEditUser;
            _view.ToggleStatusEvent += OnToggleStatus;
            _view.ResetPasswordEvent += OnResetPassword;
        }

        /// <summary>
        /// View-in hadisələrindən abunəliyi ləğv etmək
        /// </summary>
        private void UnsubscribeFromViewEvents()
        {
            _view.LoadUsersEvent -= OnLoadUsers;
            _view.RefreshEvent -= OnRefresh;
            _view.SearchEvent -= OnSearch;
            _view.FilterChangedEvent -= OnFilterChanged;
            _view.AddUserEvent -= OnAddUser;
            _view.EditUserEvent -= OnEditUser;
            _view.ToggleStatusEvent -= OnToggleStatus;
            _view.ResetPasswordEvent -= OnResetPassword;
        }

        /// <summary>
        /// Presenter-i başlatmaq və ilkin datanı yükləmək
        /// </summary>
        public async Task InitializeAsync()
        {
            try
            {
                _view.SetLoadingState(true);
                await LoadFilterOptionsAsync();
                await LoadUsersAsync();
            }
            catch (Exception ex)
            {
                _view.ShowError($"Başlatma zamanı xəta: {ex.Message}");
            }
            finally
            {
                _view.SetLoadingState(false);
            }
        }

        /// <summary>
        /// Filter seçimlərini yükləmək
        /// </summary>
        private async Task LoadFilterOptionsAsync()
        {
            try
            {
                // Status filter options
                _view.StatusFilterOptions = new List<string> { "Hamısı", "Aktiv", "Deaktiv", "Bloklu" };
                
                // Role filter options
                var roles = await _rolRepository.GetAllAsync();
                var roleNames = new List<string> { "Hamısı" };
                roleNames.AddRange(roles.Where(r => r.Status == "Aktiv").Select(r => r.Ad));
                _view.RoleFilterOptions = roleNames;
                
                // Set default values
                _view.StatusFilter = "Hamısı";
                _view.RoleFilter = "Hamısı";
            }
            catch (Exception ex)
            {
                _view.ShowError($"Filter seçimləri yüklənərkən xəta: {ex.Message}");
            }
        }

        /// <summary>
        /// İstifadəçiləri yükləmək
        /// </summary>
        private async Task LoadUsersAsync()
        {
            try
            {
                _view.SetLoadingState(true);
                _view.StatusMessage = "İstifadəçilər yüklənir...";
                
                // Get filter values
                string searchTerm = _view.SearchTerm?.Trim();
                string status = _view.StatusFilter == "Hamısı" ? null : _view.StatusFilter;
                
                int? rolId = null;
                if (_view.RoleFilter != "Hamısı")
                {
                    var roles = await _rolRepository.GetAllAsync();
                    var selectedRole = roles.FirstOrDefault(r => r.Ad == _view.RoleFilter);
                    rolId = selectedRole?.Id;
                }
                
                // Load filtered users from database
                _filteredUsers = await _istifadeciRepository.GetFilteredUsersAsync(
                    searchTerm, status, rolId, PageSize, _currentPageNumber);
                
                // Update view
                _view.UserList = _filteredUsers;
                
                // Get total count for status display
                int totalCount = await _istifadeciRepository.GetFilteredUsersCountAsync(
                    searchTerm, status, rolId);
                
                _view.StatusMessage = $"Cəmi {totalCount} istifadəçi (Səhifə {_currentPageNumber})";
            }
            catch (Exception ex)
            {
                _view.ShowError($"İstifadəçilər yüklənərkən xəta: {ex.Message}");
            }
            finally
            {
                _view.SetLoadingState(false);
            }
        }

        #region Event Handlers

        private async void OnLoadUsers()
        {
            await LoadUsersAsync();
        }

        private async void OnRefresh()
        {
            await LoadUsersAsync();
        }

        private async void OnSearch()
        {
            _currentPageNumber = 1; // Reset to first page
            await LoadUsersAsync();
        }

        private async void OnFilterChanged()
        {
            _currentPageNumber = 1; // Reset to first page
            await LoadUsersAsync();
        }

        private async void OnAddUser(Istifadeci user)
        {
            try
            {
                _view.OpenAddUserDialog();
                await LoadUsersAsync(); // Refresh after adding
                await _auditLogService.LogAsync(_currentUser.Id, "İstifadəçi", "Yeni istifadəçi əlavə edildi", GetClientInfo());
            }
            catch (Exception ex)
            {
                _view.ShowError($"İstifadəçi əlavə edilərkən xəta: {ex.Message}");
            }
        }

        private async void OnEditUser(Istifadeci user)
        {
            try
            {
                if (user == null)
                {
                    _view.ShowMessage("Redaktə etmək üçün istifadəçi seçin.", "Məlumat", MessageType.Information);
                    return;
                }

                _view.OpenEditUserDialog(user);
                await LoadUsersAsync(); // Refresh after editing
                await _auditLogService.LogAsync(_currentUser.Id, "İstifadəçi", 
                    $"İstifadəçi redaktə edildi: {user.Email}", GetClientInfo());
            }
            catch (Exception ex)
            {
                _view.ShowError($"İstifadəçi redaktə edilərkən xəta: {ex.Message}");
            }
        }

        private async void OnToggleStatus(Istifadeci user)
        {
            try
            {
                if (user == null)
                {
                    _view.ShowMessage("Status dəyişmək üçün istifadəçi seçin.", "Məlumat", MessageType.Information);
                    return;
                }

                if (user.Id == _currentUser.Id)
                {
                    _view.ShowMessage("Öz statusunuzu dəyişə bilməzsiniz.", "Xəta", MessageType.Warning);
                    return;
                }

                var newStatus = user.Status == "Aktiv" ? "Deaktiv" : "Aktiv";
                bool confirmed = _view.ShowConfirmation(
                    $"İstifadəçinin statusunu '{newStatus}' etmək istədiyinizə əminsiniz?", 
                    "Təsdiq");

                if (confirmed)
                {
                    user.Status = newStatus;
                    await _istifadeciRepository.UpdateAsync(user);
                    await LoadUsersAsync(); // Refresh list
                    await _auditLogService.LogAsync(_currentUser.Id, "İstifadəçi", 
                        $"İstifadəçi statusu dəyişdirildi: {user.Email} -> {newStatus}", GetClientInfo());
                    _view.ShowSuccess("Status uğurla dəyişdirildi.");
                }
            }
            catch (Exception ex)
            {
                _view.ShowError($"Status dəyişdirilərkən xəta: {ex.Message}");
            }
        }

        private async void OnResetPassword(Istifadeci user)
        {
            try
            {
                if (user == null)
                {
                    _view.ShowMessage("Şifrə sıfırlamaq üçün istifadəçi seçin.", "Məlumat", MessageType.Information);
                    return;
                }

                _view.OpenPasswordResetDialog(user);
                await _auditLogService.LogAsync(_currentUser.Id, "İstifadəçi", 
                    $"İstifadəçi şifrəsi sıfırlandı: {user.Email}", GetClientInfo());
                _view.ShowSuccess("Şifrə uğurla sıfırlandı.");
            }
            catch (Exception ex)
            {
                _view.ShowError($"Şifrə sıfırlanarkən xəta: {ex.Message}");
            }
        }

        #endregion

        /// <summary>
        /// Client məlumatlarını əldə etmək
        /// </summary>
        private string GetClientInfo()
        {
            return $"IP: {System.Net.Dns.GetHostName()}, Platform: Windows";
        }

        /// <summary>
        /// Resources-ləri təmizləmək
        /// </summary>
        public void Dispose()
        {
            if (!_disposed)
            {
                UnsubscribeFromViewEvents();
                _istifadeciRepository?.Dispose();
                _rolRepository?.Dispose();
                _authService?.Dispose();
                _auditLogService?.Dispose();
                _disposed = true;
            }
        }
    }
}