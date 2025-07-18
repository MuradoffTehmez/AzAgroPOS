using AzAgroPOS.DAL;
using AzAgroPOS.DAL.Interfaces;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.BLL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AzAgroPOS.BLL.Services
{
    /// <summary>
    /// Servisləri yaratmaq üçün Factory pattern
    /// UI layer üçün asanlıq yaradır və dependency injection mexanizmi təmin edir
    /// </summary>
    public static class ServiceFactory
    {
        private static IServiceProvider _serviceProvider;

        /// <summary>
        /// Factory-ni ServiceProvider ilə başlat
        /// </summary>
        public static void Initialize(IServiceProvider serviceProvider = null)
        {
            _serviceProvider = serviceProvider;
            
            // Əgər serviceProvider verilməyibsə, legacy yolla yarad
            if (_serviceProvider == null)
            {
                var context = new AzAgroDbContext();
                _unitOfWork = new UnitOfWork(context);
                _auditLogService = new AuditLogService(context);
            }
        }

        private static IUnitOfWork _unitOfWork;
        private static IAuditLogService _auditLogService;

        /// <summary>
        /// Factory resources təmizlə
        /// </summary>
        public static void Cleanup()
        {
            _auditLogService?.Dispose();
            _unitOfWork?.Dispose();
        }

        // Əsas servislər
        public static SatisService CreateSatisService()
        {
            return CreateService(() => new SatisService(_unitOfWork));
        }

        public static MehsulService CreateMehsulService()
        {
            return CreateService(() => new MehsulService(_unitOfWork, _auditLogService));
        }

        public static MusteriService CreateMusteriService()
        {
            EnsureInitialized();
            return new MusteriService(_unitOfWork, _auditLogService);
        }

        public static AuthService CreateAuthService()
        {
            EnsureInitialized();
            return new AuthService(_unitOfWork, _auditLogService);
        }

        public static AuthorizationService CreateAuthorizationService()
        {
            EnsureInitialized();
            var rolRepository = new RolRepository(new AzAgroDbContext());
            return new AuthorizationService(rolRepository);
        }

        public static BorcService CreateBorcService()
        {
            EnsureInitialized();
            return new BorcService(_unitOfWork, _auditLogService);
        }

        public static AnbarService CreateAnbarService()
        {
            EnsureInitialized();
            return new AnbarService(_unitOfWork);
        }

        public static TamirService CreateTamirService()
        {
            EnsureInitialized();
            return new TamirService(_unitOfWork, _auditLogService);
        }

        public static TedarukcuService CreateTedarukcuService()
        {
            EnsureInitialized();
            return new TedarukcuService(_unitOfWork, _auditLogService);
        }

        public static BackupService CreateBackupService()
        {
            EnsureInitialized();
            return new BackupService(_unitOfWork, _auditLogService);
        }

        public static BildirisService CreateBildirisService()
        {
            EnsureInitialized();
            return new BildirisService(_unitOfWork, _auditLogService);
        }

        public static NovbeIdaretmesiService CreateNovbeIdaretmesiService()
        {
            EnsureInitialized();
            return new NovbeIdaretmesiService(_unitOfWork, _auditLogService);
        }

        public static PrinterService CreatePrinterService()
        {
            EnsureInitialized();
            return new PrinterService(_unitOfWork, _auditLogService);
        }

        public static IsciService CreateIsciService()
        {
            EnsureInitialized();
            // IsciService hələ köhnə pattern istifadə edir, ona görə DbContext veririk
            var context = new AzAgroDbContext();
            return new IsciService(context, _auditLogService);
        }

        public static HesabatService CreateHesabatService()
        {
            EnsureInitialized();
            // HesabatService hələ köhnə pattern istifadə edir, ona görə DbContext veririk
            var context = new AzAgroDbContext();
            return new HesabatService(context, _auditLogService);
        }

        public static AuditLogService CreateAuditLogService()
        {
            EnsureInitialized();
            return _auditLogService as AuditLogService ?? new AuditLogService();
        }

        public static ILoggerService CreateLoggerService()
        {
            return CreateService(() => new FileLoggerService());
        }

        public static IErrorHandlingService CreateErrorHandlingService()
        {
            EnsureInitialized();
            var logger = CreateLoggerService();
            var userContext = CreateUserContext();
            return new ErrorHandlingService(logger, userContext);
        }

        public static IUserContext CreateUserContext()
        {
            EnsureInitialized();
            // UserContext service-ni yaradırıq
            return new UserContext();
        }

        /// <summary>
        /// Generic servis yaratma metodu
        /// </summary>
        private static T CreateService<T>(Func<T> fallbackFactory) where T : class
        {
            if (_serviceProvider != null)
            {
                using var scope = _serviceProvider.CreateScope();
                return scope.ServiceProvider.GetRequiredService<T>();
            }
            
            EnsureInitialized();
            return fallbackFactory();
        }

        private static void EnsureInitialized()
        {
            if (_unitOfWork == null || _auditLogService == null)
            {
                Initialize();
            }
        }
    }
}