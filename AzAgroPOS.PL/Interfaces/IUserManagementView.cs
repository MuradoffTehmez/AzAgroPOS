using AzAgroPOS.Entities.Domain;
using System;
using System.Collections.Generic;

namespace AzAgroPOS.PL.Interfaces
{
    /// <summary>
    /// MVP Pattern - User Management View Interface
    /// Bu interfeys, UserManagementForm-un Presenter ilə əlaqəsini təmin edir
    /// </summary>
    public interface IUserManagementView
    {
        // Properties - View-in göstərəcəyi məlumatlar
        string SearchTerm { get; set; }
        string StatusFilter { get; set; }
        string RoleFilter { get; set; }
        string StatusMessage { get; set; }
        int CurrentPage { get; set; }
        
        // Data binding
        List<Istifadeci> UserList { set; }
        List<string> StatusFilterOptions { set; }
        List<string> RoleFilterOptions { set; }
        
        // Events - View-dən Presenter-ə göndəriləcək hadisələr
        event Action LoadUsersEvent;
        event Action RefreshEvent;
        event Action SearchEvent;
        event Action FilterChangedEvent;
        event Action<Istifadeci> AddUserEvent;
        event Action<Istifadeci> EditUserEvent;
        event Action<Istifadeci> ToggleStatusEvent;
        event Action<Istifadeci> ResetPasswordEvent;
        
        // Methods - Presenter-in View-ə verəcəyi əmrlər
        void ShowMessage(string message, string title = "Məlumat", MessageType messageType = MessageType.Information);
        void ShowError(string error);
        void ShowSuccess(string message);
        bool ShowConfirmation(string message, string title = "Təsdiq");
        
        void EnableControls(bool enabled);
        void SetLoadingState(bool isLoading);
        
        Istifadeci GetSelectedUser();
        void RefreshUserList();
        void UpdateStatusMessage(string message);
        
        // Form lifecycle
        void CloseView();
        void OpenAddUserDialog();
        void OpenEditUserDialog(Istifadeci user);
        void OpenPasswordResetDialog(Istifadeci user);
    }
    
    /// <summary>
    /// Mesaj tipləri
    /// </summary>
    public enum MessageType
    {
        Information,
        Warning,
        Error,
        Success,
        Question
    }
}