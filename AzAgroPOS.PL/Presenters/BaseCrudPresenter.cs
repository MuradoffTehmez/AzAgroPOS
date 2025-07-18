using AzAgroPOS.BLL.Interfaces;
using AzAgroPOS.BLL.Services;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.PL.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzAgroPOS.PL.Presenters
{
    /// <summary>
    /// MVP Pattern - Base CRUD Presenter
    /// CRUD əməliyyatları üçün ümumi presenter sinfi
    /// </summary>
    public abstract class BaseCrudPresenter<TView, TEntity> : BasePresenter<TView> 
        where TView : ICrudView<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly AuditLogService _auditLogService;
        protected List<TEntity> _entities;
        protected string _entityName;

        protected BaseCrudPresenter(TView view, Istifadeci currentUser, string entityName,
            IErrorHandlingService errorHandlingService = null, 
            ILoggerService loggerService = null,
            AuditLogService auditLogService = null) 
            : base(view, currentUser, errorHandlingService, loggerService)
        {
            _entityName = entityName ?? typeof(TEntity).Name;
            _auditLogService = auditLogService ?? ServiceFactory.CreateAuditLogService();
            _entities = new List<TEntity>();
            
            SubscribeToCrudEvents();
        }

        /// <summary>
        /// CRUD hadisələrinə abunə olmaq
        /// </summary>
        private void SubscribeToCrudEvents()
        {
            _view.AddEvent += OnAdd;
            _view.EditEvent += OnEdit;
            _view.DeleteEvent += OnDelete;
            _view.ViewDetailsEvent += OnViewDetails;
            _view.SearchEvent += OnSearch;
            _view.FilterChangedEvent += OnFilterChanged;
        }

        /// <summary>
        /// CRUD hadisələrindən abunəliyi ləğv etmək
        /// </summary>
        private void UnsubscribeFromCrudEvents()
        {
            _view.AddEvent -= OnAdd;
            _view.EditEvent -= OnEdit;
            _view.DeleteEvent -= OnDelete;
            _view.ViewDetailsEvent -= OnViewDetails;
            _view.SearchEvent -= OnSearch;
            _view.FilterChangedEvent -= OnFilterChanged;
        }

        /// <summary>
        /// Verilənləri yükləmək - mütləq override edilməlidir
        /// </summary>
        protected abstract Task<List<TEntity>> LoadDataAsync();

        /// <summary>
        /// Axtarış məntiqi - override edilə bilər
        /// </summary>
        protected virtual async Task<List<TEntity>> SearchAsync(string searchTerm)
        {
            var allData = await LoadDataAsync();
            if (string.IsNullOrWhiteSpace(searchTerm))
                return allData;

            // Default axtarış məntiqi - alt siniflər tərəfindən override ediləcək
            return allData;
        }

        /// <summary>
        /// Əlavə etmə əməliyyatını yerinə yetirmək
        /// </summary>
        protected virtual async Task<bool> AddEntityAsync(TEntity entity)
        {
            // Alt siniflər tərəfindən override ediləcək
            await Task.CompletedTask;
            return true;
        }

        /// <summary>
        /// Yenilənmə əməliyyatını yerinə yetirmək
        /// </summary>
        protected virtual async Task<bool> UpdateEntityAsync(TEntity entity)
        {
            // Alt siniflər tərəfindən override ediləcək
            await Task.CompletedTask;
            return true;
        }

        /// <summary>
        /// Silmə əməliyyatını yerinə yetirmək
        /// </summary>
        protected virtual async Task<bool> DeleteEntityAsync(TEntity entity)
        {
            // Alt siniflər tərəfindən override ediləcək
            await Task.CompletedTask;
            return true;
        }

        /// <summary>
        /// Entity validasiyası
        /// </summary>
        protected virtual async Task<bool> ValidateEntityAsync(TEntity entity)
        {
            if (entity == null)
            {
                await _errorHandlingService.HandleValidationErrorAsync("Entity null ola bilməz");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Başlatma məntiqi
        /// </summary>
        protected override async Task OnInitializeAsync()
        {
            await LoadEntitiesAsync();
        }

        /// <summary>
        /// Verilənləri yükləyib View-ə göndərmək
        /// </summary>
        protected virtual async Task LoadEntitiesAsync()
        {
            try
            {
                _entities = await LoadDataAsync();
                _view.SetDataSource(_entities);
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(ex, $"{_entityName} məlumatları yüklənərkən xəta baş verdi");
            }
        }

        #region Event Handlers

        private async void OnAdd(TEntity entity)
        {
            await ExecuteAsync(async () =>
            {
                if (await ValidateEntityAsync(entity))
                {
                    if (await AddEntityAsync(entity))
                    {
                        await LogActionAsync(_entityName, "CREATE", entity?.Id, $"Yeni {_entityName} əlavə edildi");
                        await LoadEntitiesAsync();
                        await _errorHandlingService.ShowSuccessAsync($"{_entityName} uğurla əlavə edildi");
                    }
                }
            }, $"{_entityName} əlavə edilərkən xəta baş verdi");
        }

        private async void OnEdit(TEntity entity)
        {
            await ExecuteAsync(async () =>
            {
                if (entity == null)
                {
                    await _errorHandlingService.HandleValidationErrorAsync($"Redaktə etmək üçün {_entityName} seçin");
                    return;
                }

                if (await ValidateEntityAsync(entity))
                {
                    if (await UpdateEntityAsync(entity))
                    {
                        await LogActionAsync(_entityName, "UPDATE", entity.Id, $"{_entityName} yeniləndi");
                        await LoadEntitiesAsync();
                        await _errorHandlingService.ShowSuccessAsync($"{_entityName} uğurla yeniləndi");
                    }
                }
            }, $"{_entityName} yenilənərkən xəta baş verdi");
        }

        private async void OnDelete(TEntity entity)
        {
            await ExecuteAsync(async () =>
            {
                if (entity == null)
                {
                    await _errorHandlingService.HandleValidationErrorAsync($"Silmək üçün {_entityName} seçin");
                    return;
                }

                // Təsdiq məlumatı
                if (_view.ShowConfirmation($"{_entityName} silmək istədiyinizə əminsiniz?", "Silmə Təsdiqi"))
                {
                    if (await DeleteEntityAsync(entity))
                    {
                        await LogActionAsync(_entityName, "DELETE", entity.Id, $"{_entityName} silindi");
                        await LoadEntitiesAsync();
                        await _errorHandlingService.ShowSuccessAsync($"{_entityName} uğurla silindi");
                    }
                }
            }, $"{_entityName} silinərkən xəta baş verdi");
        }

        private async void OnViewDetails(TEntity entity)
        {
            await ExecuteAsync(async () =>
            {
                if (entity == null)
                {
                    await _errorHandlingService.HandleValidationErrorAsync($"Detalları görmək üçün {_entityName} seçin");
                    return;
                }

                // Entity detalları göstərmək - alt siniflər tərəfindən override ediləcək
                await ShowEntityDetailsAsync(entity);
            }, $"{_entityName} detalları göstərilərkən xəta baş verdi");
        }

        private async void OnSearch()
        {
            await ExecuteAsync(async () =>
            {
                var searchTerm = _view.SearchTerm;
                var filteredData = await SearchAsync(searchTerm);
                _view.SetDataSource(filteredData);
            }, "Axtarış zamanı xəta baş verdi");
        }

        private async void OnFilterChanged()
        {
            await ExecuteAsync(async () =>
            {
                await LoadEntitiesAsync();
            }, "Filter dəyişdirilər xəta baş verdi");
        }

        #endregion

        /// <summary>
        /// Entity detallarını göstərmək - alt siniflər tərəfindən override ediləcək
        /// </summary>
        protected virtual async Task ShowEntityDetailsAsync(TEntity entity)
        {
            _view.ShowMessage($"{_entityName} detalları:\nID: {entity.Id}\nYaradılma tarixi: {entity.YaranmaTarixi}");
            await Task.CompletedTask;
        }

        /// <summary>
        /// Resources-ləri təmizləmək
        /// </summary>
        protected override void OnDispose()
        {
            UnsubscribeFromCrudEvents();
            _auditLogService?.Dispose();
            base.OnDispose();
        }
    }
}