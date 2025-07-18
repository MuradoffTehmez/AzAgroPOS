using System;

namespace AzAgroPOS.PL.Interfaces
{
    /// <summary>
    /// MVP Pattern - Base View Interface
    /// Bütün View interfeyslərinin miras alacağı əsas interfeys
    /// </summary>
    public interface IBaseView
    {
        // Common UI operations
        void ShowMessage(string message, string title = "Məlumat", MessageType messageType = MessageType.Information);
        void ShowError(string error);
        void ShowSuccess(string message);
        bool ShowConfirmation(string message, string title = "Təsdiq");
        
        // Loading state management
        void SetLoadingState(bool isLoading);
        void EnableControls(bool enabled);
        
        // Form lifecycle
        void CloseView();
        
        // Common events
        event Action InitializeEvent;
        event Action RefreshEvent;
    }
    
    /// <summary>
    /// CRUD əməliyyatları üçün genişləndirilmiş View interfeysi
    /// </summary>
    public interface ICrudView<TEntity> : IBaseView
    {
        // CRUD Events
        event Action<TEntity> AddEvent;
        event Action<TEntity> EditEvent;
        event Action<TEntity> DeleteEvent;
        event Action<TEntity> ViewDetailsEvent;
        
        // Data binding
        void SetDataSource(System.Collections.Generic.List<TEntity> data);
        TEntity GetSelectedItem();
        void RefreshDataSource();
        
        // Filter/Search
        string SearchTerm { get; set; }
        event Action SearchEvent;
        event Action FilterChangedEvent;
    }
    
    /// <summary>
    /// Mesaj tiplərinin genişləndirilmiş versiyası
    /// </summary>
    public enum MessageType
    {
        Information,
        Warning,
        Error,
        Success,
        Question,
        Loading
    }
}