using AzAgroPOS.BLL.Interfaces;
using AzAgroPOS.DAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzAgroPOS.BLL.Services
{
    /// <summary>
    /// Servislərin lifecycle-ını düzgün idarə etmək üçün helper sinif
    /// YÜKSƏK PRİORİTET: IDisposable pattern-in təhlükəsiz tətbiqi
    /// </summary>
    public sealed class ServiceLifecycleManager : IDisposable
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IServiceScope _serviceScope;
        private readonly List<IDisposable> _disposables;
        private readonly ILoggerService _logger;
        private bool _disposed = false;

        public ServiceLifecycleManager(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _serviceScope = _serviceProvider.CreateScope();
            _disposables = new List<IDisposable>();
            _logger = _serviceScope.ServiceProvider.GetService<ILoggerService>();
        }

        /// <summary>
        /// Təhlükəsiz şəkildə servis yaradır və dispose tracking əlavə edir
        /// </summary>
        /// <typeparam name="T">Servis tipi</typeparam>
        /// <returns>Servis instance</returns>
        public T CreateService<T>() where T : class, IDisposable
        {
            ThrowIfDisposed();
            
            try
            {
                var service = _serviceScope.ServiceProvider.GetService<T>();
                if (service == null)
                {
                    throw new InvalidOperationException($"Service {typeof(T).Name} is not registered");
                }
                
                _disposables.Add(service);
                _logger?.LogInfo($"Service created: {typeof(T).Name}");
                
                return service;
            }
            catch (Exception ex)
            {
                _logger?.LogError($"Service creation failed: {typeof(T).Name}", ex);
                throw;
            }
        }

        /// <summary>
        /// Müəyyən bir funksiyanı servis ilə icra edir və avtomatik dispose edir
        /// </summary>
        /// <typeparam name="TService">Servis tipi</typeparam>
        /// <typeparam name="TResult">Nəticə tipi</typeparam>
        /// <param name="action">İcra ediləcək funksiya</param>
        /// <returns>Funksiya nəticəsi</returns>
        public TResult ExecuteWithService<TService, TResult>(Func<TService, TResult> action) 
            where TService : class, IDisposable
        {
            ThrowIfDisposed();
            
            using var service = CreateService<TService>();
            return action(service);
        }

        /// <summary>
        /// Müəyyən bir async funksiyanı servis ilə icra edir və avtomatik dispose edir
        /// </summary>
        /// <typeparam name="TService">Servis tipi</typeparam>
        /// <typeparam name="TResult">Nəticə tipi</typeparam>
        /// <param name="action">İcra ediləcək async funksiya</param>
        /// <returns>Async funksiya nəticəsi</returns>
        public async Task<TResult> ExecuteWithServiceAsync<TService, TResult>(Func<TService, Task<TResult>> action) 
            where TService : class, IDisposable
        {
            ThrowIfDisposed();
            
            using var service = CreateService<TService>();
            return await action(service);
        }

        /// <summary>
        /// Müəyyən bir funksiyanı servis ilə icra edir (void return)
        /// </summary>
        /// <typeparam name="TService">Servis tipi</typeparam>
        /// <param name="action">İcra ediləcək funksiya</param>
        public void ExecuteWithService<TService>(Action<TService> action) 
            where TService : class, IDisposable
        {
            ThrowIfDisposed();
            
            using var service = CreateService<TService>();
            action(service);
        }

        /// <summary>
        /// Müəyyən bir async funksiyanı servis ilə icra edir (void return)
        /// </summary>
        /// <typeparam name="TService">Servis tipi</typeparam>
        /// <param name="action">İcra ediləcək async funksiya</param>
        public async Task ExecuteWithServiceAsync<TService>(Func<TService, Task> action) 
            where TService : class, IDisposable
        {
            ThrowIfDisposed();
            
            using var service = CreateService<TService>();
            await action(service);
        }

        /// <summary>
        /// Birdən çox servis ilə əməliyyat icra edir
        /// </summary>
        /// <typeparam name="TService1">Birinci servis tipi</typeparam>
        /// <typeparam name="TService2">İkinci servis tipi</typeparam>
        /// <typeparam name="TResult">Nəticə tipi</typeparam>
        /// <param name="action">İcra ediləcək funksiya</param>
        /// <returns>Funksiya nəticəsi</returns>
        public TResult ExecuteWithServices<TService1, TService2, TResult>(
            Func<TService1, TService2, TResult> action) 
            where TService1 : class, IDisposable
            where TService2 : class, IDisposable
        {
            ThrowIfDisposed();
            
            using var service1 = CreateService<TService1>();
            using var service2 = CreateService<TService2>();
            return action(service1, service2);
        }

        /// <summary>
        /// Transaction ilə əməliyyat icra edir
        /// </summary>
        /// <typeparam name="TResult">Nəticə tipi</typeparam>
        /// <param name="action">İcra ediləcək funksiya</param>
        /// <returns>Funksiya nəticəsi</returns>
        public TResult ExecuteInTransaction<TResult>(Func<IUnitOfWork, TResult> action)
        {
            ThrowIfDisposed();
            
            var unitOfWork = _serviceScope.ServiceProvider.GetService<IUnitOfWork>();
            if (unitOfWork == null)
            {
                throw new InvalidOperationException("IUnitOfWork is not registered");
            }

            try
            {
                var result = action(unitOfWork);
                unitOfWork.Complete();
                return result;
            }
            catch
            {
                // Transaction rollback avtomatik olaraq UnitOfWork dispose zamanı baş verəcək
                throw;
            }
        }

        /// <summary>
        /// Async transaction ilə əməliyyat icra edir
        /// </summary>
        /// <typeparam name="TResult">Nəticə tipi</typeparam>
        /// <param name="action">İcra ediləcək async funksiya</param>
        /// <returns>Async funksiya nəticəsi</returns>
        public async Task<TResult> ExecuteInTransactionAsync<TResult>(Func<IUnitOfWork, Task<TResult>> action)
        {
            ThrowIfDisposed();
            
            var unitOfWork = _serviceScope.ServiceProvider.GetService<IUnitOfWork>();
            if (unitOfWork == null)
            {
                throw new InvalidOperationException("IUnitOfWork is not registered");
            }

            try
            {
                var result = await action(unitOfWork);
                await unitOfWork.CompleteAsync();
                return result;
            }
            catch
            {
                // Transaction rollback avtomatik olaraq UnitOfWork dispose zamanı baş verəcək
                throw;
            }
        }

        /// <summary>
        /// Aktiv servis sayını qaytarır
        /// </summary>
        /// <returns>Aktiv servis sayı</returns>
        public int GetActiveServiceCount()
        {
            ThrowIfDisposed();
            return _disposables.Count;
        }

        /// <summary>
        /// Disposed olunmuş vəziyyətdə istifadə yoxlama
        /// </summary>
        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(ServiceLifecycleManager));
            }
        }

        /// <summary>
        /// Bütün resursları təmizlə
        /// </summary>
        public void Dispose()
        {
            if (!_disposed)
            {
                try
                {
                    // Yaradılan servisləri dispose et
                    foreach (var disposable in _disposables)
                    {
                        try
                        {
                            disposable?.Dispose();
                        }
                        catch (Exception ex)
                        {
                            _logger?.LogError($"Error disposing service: {disposable.GetType().Name}", ex);
                        }
                    }
                    
                    _disposables.Clear();
                    
                    // Service scope-u dispose et
                    _serviceScope?.Dispose();
                    
                    _logger?.LogInfo("ServiceLifecycleManager disposed successfully");
                }
                catch (Exception ex)
                {
                    _logger?.LogError("Error during ServiceLifecycleManager disposal", ex);
                }
                finally
                {
                    _disposed = true;
                }
            }
        }
    }

    /// <summary>
    /// Form-lar üçün xüsusi lifecycle manager
    /// </summary>
    public sealed class FormServiceManager : IDisposable
    {
        private readonly ServiceLifecycleManager _lifecycleManager;
        private bool _disposed = false;

        public FormServiceManager(IServiceProvider serviceProvider)
        {
            _lifecycleManager = new ServiceLifecycleManager(serviceProvider);
        }

        /// <summary>
        /// Form load event-i üçün servislər hazırlayır
        /// </summary>
        /// <typeparam name="TService">Servis tipi</typeparam>
        /// <returns>Servis instance</returns>
        public TService PrepareService<TService>() where TService : class, IDisposable
        {
            return _lifecycleManager.CreateService<TService>();
        }

        /// <summary>
        /// Form-un bağlanması zamanı çağrılmalıdır
        /// </summary>
        public void OnFormClosing()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _lifecycleManager?.Dispose();
                _disposed = true;
            }
        }
    }
}