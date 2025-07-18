using AzAgroPOS.BLL.Interfaces;
using AzAgroPOS.BLL.Services;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.PL.Interfaces;
using System;
using System.Threading.Tasks;

namespace AzAgroPOS.PL.Presenters
{
    /// <summary>
    /// MVP Pattern - Base Presenter
    /// Bütün presenter siniflərinin miras alacağı əsas sinif
    /// </summary>
    public abstract class BasePresenter<TView> : IDisposable where TView : IBaseView
    {
        protected readonly TView _view;
        protected readonly Istifadeci _currentUser;
        protected readonly IErrorHandlingService _errorHandlingService;
        protected readonly ILoggerService _loggerService;
        protected bool _disposed = false;

        protected BasePresenter(TView view, Istifadeci currentUser, 
            IErrorHandlingService errorHandlingService = null, 
            ILoggerService loggerService = null)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _currentUser = currentUser ?? throw new ArgumentNullException(nameof(currentUser));
            _errorHandlingService = errorHandlingService ?? ServiceFactory.CreateErrorHandlingService();
            _loggerService = loggerService ?? ServiceFactory.CreateLoggerService();

            SubscribeToBaseEvents();
        }

        /// <summary>
        /// Əsas View hadisələrinə abunə olmaq
        /// </summary>
        private void SubscribeToBaseEvents()
        {
            _view.InitializeEvent += OnInitialize;
            _view.RefreshEvent += OnRefresh;
        }

        /// <summary>
        /// Əsas View hadisələrindən abunəliyi ləğv etmək
        /// </summary>
        private void UnsubscribeFromBaseEvents()
        {
            _view.InitializeEvent -= OnInitialize;
            _view.RefreshEvent -= OnRefresh;
        }

        /// <summary>
        /// Presenter-i başlatmaq - mütləq override edilməlidir
        /// </summary>
        public virtual async Task InitializeAsync()
        {
            try
            {
                _view.SetLoadingState(true);
                await OnInitializeAsync();
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(ex, "Başlatma zamanı xəta baş verdi");
            }
            finally
            {
                _view.SetLoadingState(false);
            }
        }

        /// <summary>
        /// Başlatma məntiqi - alt siniflər tərəfindən override edilir
        /// </summary>
        protected virtual async Task OnInitializeAsync()
        {
            // Alt siniflər tərəfindən override ediləcək
            await Task.CompletedTask;
        }

        /// <summary>
        /// Mərkəzləşdirilmiş xəta idarəetməsi
        /// </summary>
        protected virtual async Task HandleErrorAsync(Exception ex, string userMessage = null)
        {
            try
            {
                // Log the error
                await _loggerService.LogErrorAsync(ex, userMessage ?? "Xəta baş verdi");
                
                // Handle the error through centralized service
                await _errorHandlingService.HandleErrorAsync(ex, userMessage);
                
                // Show user-friendly message
                var displayMessage = userMessage ?? "Gözlənilməz xəta baş verdi. Dəstək komandası ilə əlaqə saxlayın.";
                _view.ShowError(displayMessage);
            }
            catch (Exception handlingEx)
            {
                // Fallback error handling
                _view.ShowError($"Xəta idarəetmə sistemində problem: {handlingEx.Message}");
            }
        }

        /// <summary>
        /// Təhlükəsiz asinxron əməliyyat icra etmək
        /// </summary>
        protected virtual async Task ExecuteAsync(Func<Task> operation, string errorMessage = null)
        {
            try
            {
                _view.SetLoadingState(true);
                await operation();
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(ex, errorMessage);
            }
            finally
            {
                _view.SetLoadingState(false);
            }
        }

        /// <summary>
        /// Təhlükəsiz asinxron əməliyyat icra etmək (generic)
        /// </summary>
        protected virtual async Task<T> ExecuteAsync<T>(Func<Task<T>> operation, string errorMessage = null)
        {
            try
            {
                _view.SetLoadingState(true);
                return await operation();
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(ex, errorMessage);
                return default(T);
            }
            finally
            {
                _view.SetLoadingState(false);
            }
        }

        /// <summary>
        /// Sinxron əməliyyat icra etmək
        /// </summary>
        protected virtual void Execute(Action operation, string errorMessage = null)
        {
            try
            {
                _view.SetLoadingState(true);
                operation();
            }
            catch (Exception ex)
            {
                HandleErrorAsync(ex, errorMessage).GetAwaiter().GetResult();
            }
            finally
            {
                _view.SetLoadingState(false);
            }
        }

        /// <summary>
        /// Audit log yazmaq
        /// </summary>
        protected virtual async Task LogActionAsync(string entityType, string action, int? entityId = null, string details = null)
        {
            try
            {
                var auditService = ServiceFactory.CreateAuditLogService();
                var detailsWithEntityId = entityId.HasValue ? $"EntityId: {entityId}, {details}" : details;
                await auditService.LogAsync(
                    _currentUser.Id, 
                    entityType, 
                    action, 
                    GetClientInfo(), 
                    detailsWithEntityId);
            }
            catch (Exception ex)
            {
                // Audit log xətası əsas əməliyyatı pozmamalı
                await _loggerService.LogErrorAsync(ex, "Audit log yazılarkən xəta");
            }
        }

        /// <summary>
        /// Client məlumatlarını əldə etmək
        /// </summary>
        protected virtual string GetClientInfo()
        {
            return $"IP: {System.Net.Dns.GetHostName()}, Platform: Windows, User: {_currentUser.TamAd}";
        }

        #region Event Handlers

        private async void OnInitialize()
        {
            await InitializeAsync();
        }

        private async void OnRefresh()
        {
            await OnRefreshAsync();
        }

        /// <summary>
        /// Yenilənmə məntiqi - alt siniflər tərəfindən override edilir
        /// </summary>
        protected virtual async Task OnRefreshAsync()
        {
            await OnInitializeAsync();
        }

        #endregion

        #region IDisposable Implementation

        public virtual void Dispose()
        {
            if (!_disposed)
            {
                UnsubscribeFromBaseEvents();
                OnDispose();
                _disposed = true;
            }
        }

        /// <summary>
        /// Alt siniflər tərəfindən override ediləcək disposal məntiqi
        /// </summary>
        protected virtual void OnDispose()
        {
            // Alt siniflər tərəfindən override ediləcək
        }

        #endregion
    }
}