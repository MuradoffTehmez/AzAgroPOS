using AzAgroPOS.BLL.Interfaces;
using AzAgroPOS.DAL.Interfaces;
using AzAgroPOS.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace AzAgroPOS.BLL.Services
{
    /// <summary>
    /// Asılılıqların İdarəsi (Dependency Injection) Container
    /// MEMARLIQ PROBLEMİ: Asılılıqların İdarə Edilməsi problemini həll edir
    /// </summary>
    public class DependencyInjectionContainer : IDisposable
    {
        private readonly ServiceProvider _serviceProvider;
        private readonly IServiceCollection _services;
        private bool _disposed = false;

        public DependencyInjectionContainer()
        {
            _services = new ServiceCollection();
            ConfigureServices();
            _serviceProvider = _services.BuildServiceProvider();
        }

        /// <summary>
        /// Bütün servislər və onların asılılıqları qeydiyyatdan keçir
        /// </summary>
        private void ConfigureServices()
        {
            // Core Services
            _services.AddSingleton<ILoggerService, FileLoggerService>();
            _services.AddScoped<IAuditLogService, AuditLogService>();
            _services.AddScoped<IErrorHandlingService, ErrorHandlingService>();

            // Data Access Layer
            _services.AddScoped<IUnitOfWork, UnitOfWork>();
            
            // Repository Pattern - Scoped lifecycle
            _services.AddScoped<IstifadeciRepository>();
            _services.AddScoped<MusteriRepository>();
            _services.AddScoped<MehsulRepository>();
            _services.AddScoped<SatisRepository>();
            _services.AddScoped<SatisDetaliRepository>();
            _services.AddScoped<AnbarRepository>();
            _services.AddScoped<AnbarQalikRepository>();
            _services.AddScoped<AnbarHereketRepository>();
            _services.AddScoped<MusteriBorcRepository>();
            _services.AddScoped<RolRepository>();
            _services.AddScoped<TamirIsiRepository>();
            _services.AddScoped<TedarukcuRepository>();
            _services.AddScoped<GiderRepository>();

            // Business Logic Layer - Scoped lifecycle
            _services.AddScoped<AuthService>();
            _services.AddScoped<MusteriService>();
            _services.AddScoped<MehsulService>();
            _services.AddScoped<SatisService>();
            _services.AddScoped<TransactionalSalesService>();
            _services.AddScoped<ValidationService>();
            _services.AddScoped<AnbarService>();
            _services.AddScoped<TamirService>();
            _services.AddScoped<TedarukcuService>();
            _services.AddScoped<GiderService>();
            _services.AddScoped<HesabatService>();
            _services.AddScoped<BackupService>();
            _services.AddScoped<DatabaseMigrationService>();

            // Security Services
            _services.AddScoped<PasswordSecurityService>();
            _services.AddScoped<ComprehensiveErrorHandler>();
            
            // Performance Services
            _services.AddSingleton<CacheService>();
            _services.AddScoped<AsyncUIService>();
            
            // Resource Management
            _services.AddScoped<ServiceLifecycleManager>();
        }

        /// <summary>
        /// Servis əldə edir
        /// </summary>
        /// <typeparam name="T">Servis tipi</typeparam>
        /// <returns>Servis instance</returns>
        public T GetService<T>() where T : class
        {
            ThrowIfDisposed();
            return _serviceProvider.GetService<T>();
        }

        /// <summary>
        /// Məcburi servis əldə edir (tapılmasa exception)
        /// </summary>
        /// <typeparam name="T">Servis tipi</typeparam>
        /// <returns>Servis instance</returns>
        public T GetRequiredService<T>() where T : class
        {
            ThrowIfDisposed();
            return _serviceProvider.GetRequiredService<T>();
        }

        /// <summary>
        /// Bütün servislər əldə edir
        /// </summary>
        /// <typeparam name="T">Servis tipi</typeparam>
        /// <returns>Servis collection</returns>
        public IEnumerable<T> GetServices<T>() where T : class
        {
            ThrowIfDisposed();
            return _serviceProvider.GetServices<T>();
        }

        /// <summary>
        /// Servis scope yaradır
        /// </summary>
        /// <returns>Service scope</returns>
        public IServiceScope CreateScope()
        {
            ThrowIfDisposed();
            return _serviceProvider.CreateScope();
        }

        /// <summary>
        /// Servis lifecycle manager yaradır
        /// </summary>
        /// <returns>Service lifecycle manager</returns>
        public ServiceLifecycleManager CreateLifecycleManager()
        {
            ThrowIfDisposed();
            return new ServiceLifecycleManager(_serviceProvider);
        }

        /// <summary>
        /// Form üçün servis manager yaradır
        /// </summary>
        /// <returns>Form service manager</returns>
        public FormServiceManager CreateFormManager()
        {
            ThrowIfDisposed();
            return new FormServiceManager(_serviceProvider);
        }

        /// <summary>
        /// Servis mövcudluğunu yoxlayır
        /// </summary>
        /// <typeparam name="T">Servis tipi</typeparam>
        /// <returns>Mövcuddursa true</returns>
        public bool IsServiceRegistered<T>() where T : class
        {
            ThrowIfDisposed();
            return _serviceProvider.GetService<T>() != null;
        }

        /// <summary>
        /// Servis məlumatlarını əldə edir
        /// </summary>
        /// <returns>Servis məlumatları</returns>
        public DIContainerInfo GetContainerInfo()
        {
            ThrowIfDisposed();
            
            var info = new DIContainerInfo
            {
                RegisteredServices = new List<string>(),
                SingletonServices = new List<string>(),
                ScopedServices = new List<string>(),
                TransientServices = new List<string>()
            };

            // ServiceCollection-dan məlumatları çıxarırıq
            foreach (var service in _services)
            {
                var serviceType = service.ServiceType.Name;
                var implementationType = service.ImplementationType?.Name ?? "Factory";
                
                info.RegisteredServices.Add($"{serviceType} -> {implementationType}");
                
                switch (service.Lifetime)
                {
                    case ServiceLifetime.Singleton:
                        info.SingletonServices.Add(serviceType);
                        break;
                    case ServiceLifetime.Scoped:
                        info.ScopedServices.Add(serviceType);
                        break;
                    case ServiceLifetime.Transient:
                        info.TransientServices.Add(serviceType);
                        break;
                }
            }

            info.TotalServices = info.RegisteredServices.Count;
            
            return info;
        }

        /// <summary>
        /// Disposed olunmuş vəziyyətdə istifadə yoxlama
        /// </summary>
        private void ThrowIfDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(DependencyInjectionContainer));
            }
        }

        /// <summary>
        /// Container-i dispose edir
        /// </summary>
        public void Dispose()
        {
            if (!_disposed)
            {
                _serviceProvider?.Dispose();
                _disposed = true;
            }
        }
    }

    /// <summary>
    /// DI Container məlumatları
    /// </summary>
    public class DIContainerInfo
    {
        public List<string> RegisteredServices { get; set; } = new List<string>();
        public List<string> SingletonServices { get; set; } = new List<string>();
        public List<string> ScopedServices { get; set; } = new List<string>();
        public List<string> TransientServices { get; set; } = new List<string>();
        public int TotalServices { get; set; }
    }

    /// <summary>
    /// Static DI Container helper
    /// </summary>
    public static class DIContainer
    {
        private static readonly Lazy<DependencyInjectionContainer> _instance = 
            new Lazy<DependencyInjectionContainer>(() => new DependencyInjectionContainer());

        /// <summary>
        /// Global DI Container instance
        /// </summary>
        public static DependencyInjectionContainer Instance => _instance.Value;

        /// <summary>
        /// Servis əldə edir
        /// </summary>
        /// <typeparam name="T">Servis tipi</typeparam>
        /// <returns>Servis instance</returns>
        public static T GetService<T>() where T : class
        {
            return Instance.GetService<T>();
        }

        /// <summary>
        /// Məcburi servis əldə edir
        /// </summary>
        /// <typeparam name="T">Servis tipi</typeparam>
        /// <returns>Servis instance</returns>
        public static T GetRequiredService<T>() where T : class
        {
            return Instance.GetRequiredService<T>();
        }

        /// <summary>
        /// Servis scope yaradır
        /// </summary>
        /// <returns>Service scope</returns>
        public static IServiceScope CreateScope()
        {
            return Instance.CreateScope();
        }

        /// <summary>
        /// Lifecycle manager yaradır
        /// </summary>
        /// <returns>Service lifecycle manager</returns>
        public static ServiceLifecycleManager CreateLifecycleManager()
        {
            return Instance.CreateLifecycleManager();
        }

        /// <summary>
        /// Form manager yaradır
        /// </summary>
        /// <returns>Form service manager</returns>
        public static FormServiceManager CreateFormManager()
        {
            return Instance.CreateFormManager();
        }

        /// <summary>
        /// Container məlumatlarını əldə edir
        /// </summary>
        /// <returns>Container info</returns>
        public static DIContainerInfo GetContainerInfo()
        {
            return Instance.GetContainerInfo();
        }
    }
}