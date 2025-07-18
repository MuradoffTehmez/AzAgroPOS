using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using AzAgroPOS.PL.Services;
using AzAgroPOS.PL.Styles;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.Entities.Constants;
using AzAgroPOS.BLL.Interfaces;
using AzAgroPOS.BLL.Services;

namespace AzAgroPOS.PL.Forms
{
    /// <summary>
    /// Form üçün tələb olunan icazəni müəyyən edən Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class RequirePermissionAttribute : Attribute
    {
        public string Permission { get; }
        public bool BypassForAdmin { get; }

        public RequirePermissionAttribute(string permission, bool bypassForAdmin = true)
        {
            Permission = permission;
            BypassForAdmin = bypassForAdmin;
        }
    }

    public partial class BaseForm : Form
    {
        protected readonly IUINotificationService _notificationService;
        protected Istifadeci _currentUser;
        protected IAuthorizationService _authorizationService;

        public BaseForm()
        {
            _notificationService = new UINotificationService();
            
            // Get current user from session or login context
            _currentUser = GetCurrentUser();
            
            // Initialize authorization service
            _authorizationService = ServiceFactory.CreateAuthorizationService();
            
            // Apply modern styling
            InitializeModernDesign();
            
            // Form-level permission check
            this.Load += BaseForm_Load;
        }

        public BaseForm(IUINotificationService notificationService)
        {
            _notificationService = notificationService;
            _currentUser = GetCurrentUser();
            _authorizationService = ServiceFactory.CreateAuthorizationService();
            InitializeModernDesign();
            this.Load += BaseForm_Load;
        }

        public BaseForm(string title)
        {
            _notificationService = new UINotificationService();
            _currentUser = GetCurrentUser();
            _authorizationService = ServiceFactory.CreateAuthorizationService();
            this.Text = title;
            InitializeModernDesign();
            this.Load += BaseForm_Load;
        }

        private void InitializeModernDesign()
        {
            // Set form properties for modern look
            this.Font = ModernTheme.Fonts.Body;
            this.BackColor = ModernTheme.Colors.Background;
            this.ForeColor = ModernTheme.Colors.TextPrimary;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(800, 600);
            
            // Apply modern theme when the form loads
            this.Load += (s, e) => ModernTheme.ApplyModernStyle(this);
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

        /// <summary>
        /// Form açıldıqda avtomatik icazə yoxlaması
        /// </summary>
        private async void BaseForm_Load(object sender, EventArgs e)
        {
            // MainForm və ya login formlar üçün icazə yoxlaması olmasın
            if (this is MainForm || this.GetType().Name.Contains("Login") || this.GetType().Name.Contains("Auth"))
                return;

            await CheckFormPermission();
        }

        /// <summary>
        /// Form səviyyəsində icazə yoxlaması
        /// </summary>
        private async Task CheckFormPermission()
        {
            try
            {
                // Form-un RequirePermission attribute-unu yoxla
                var permissionAttribute = (RequirePermissionAttribute)Attribute.GetCustomAttribute(
                    this.GetType(), typeof(RequirePermissionAttribute));

                if (permissionAttribute != null)
                {
                    // Admin bypass yoxla
                    if (permissionAttribute.BypassForAdmin && 
                        await _authorizationService.HasPermissionAsync(SystemConstants.Permissions.AdminAccess))
                    {
                        return; // Admin icazəsi var, keç
                    }

                    // Spesifik icazəni yoxla
                    bool hasPermission = await _authorizationService.HasPermissionAsync(permissionAttribute.Permission);
                    
                    if (!hasPermission)
                    {
                        // İcazə yoxdur - formu bağla və xəbərdarlıq göstər
                        ShowError($"Bu səhifəyə daxil olmaq üçün icazəniz yoxdur.\nTələb olunan icazə: {permissionAttribute.Permission}");
                        
                        // Form-u bağla
                        this.WindowState = FormWindowState.Minimized;
                        this.Close();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError($"İcazə yoxlaması zamanı xəta: {ex.Message}");
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