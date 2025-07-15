using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using AzAgroPOS.PL.Services;
using AzAgroPOS.Entities.Domain;

namespace AzAgroPOS.PL.Forms
{
    public partial class BaseForm : Form
    {
        protected readonly IUINotificationService _notificationService;
        protected Istifadeci _currentUser;

        public BaseForm()
        {
            _notificationService = new UINotificationService();
            
            // Get current user from session or login context
            _currentUser = GetCurrentUser();
        }

        public BaseForm(IUINotificationService notificationService)
        {
            _notificationService = notificationService;
            _currentUser = GetCurrentUser();
        }

        protected virtual Istifadeci GetCurrentUser()
        {
            // Use SessionManager to get current user
            if (SessionManager.IsLoggedIn)
            {
                return SessionManager.CurrentUser;
            }

            // Fallback for development/testing
            return new Istifadeci 
            { 
                Id = 1, 
                Ad = "Admin", 
                Email = "admin@azagropos.com" 
            };
        }

        protected async Task<T> ExecuteAsync<T>(Func<Task<T>> operation, string errorMessage = "Əməliyyat zamanı xəta baş verdi")
        {
            try
            {
                return await operation();
            }
            catch (Exception ex)
            {
                _notificationService.HandleError(ex, errorMessage);
                return default(T);
            }
        }

        protected async Task ExecuteAsync(Func<Task> operation, string errorMessage = "Əməliyyat zamanı xəta baş verdi")
        {
            try
            {
                await operation();
            }
            catch (Exception ex)
            {
                _notificationService.HandleError(ex, errorMessage);
            }
        }

        protected T Execute<T>(Func<T> operation, string errorMessage = "Əməliyyat zamanı xəta baş verdi")
        {
            try
            {
                return operation();
            }
            catch (Exception ex)
            {
                _notificationService.HandleError(ex, errorMessage);
                return default(T);
            }
        }

        protected void Execute(Action operation, string errorMessage = "Əməliyyat zamanı xəta baş verdi")
        {
            try
            {
                operation();
            }
            catch (Exception ex)
            {
                _notificationService.HandleError(ex, errorMessage);
            }
        }

        protected bool ShowConfirmation(string message, string title = "Təsdiq")
        {
            return _notificationService.ShowConfirmation(message, title);
        }

        protected void ShowSuccess(string message, string title = "Uğur")
        {
            _notificationService.ShowSuccess(message, title);
        }

        protected void ShowError(string message, string title = "Xəta")
        {
            _notificationService.ShowError(message, title);
        }

        protected void ShowWarning(string message, string title = "Xəbərdarlıq")
        {
            _notificationService.ShowWarning(message, title);
        }

        protected void ShowInfo(string message, string title = "Məlumat")
        {
            _notificationService.ShowInfo(message, title);
        }

        protected virtual void OnFormLoad()
        {
            // Override in derived forms for async initialization
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            OnFormLoad();
        }
    }
}