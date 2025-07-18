using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AzAgroPOS.DAL;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.DAL.Interfaces;
using AzAgroPOS.BLL.Services;
using AzAgroPOS.PL.Services;
using AzAgroPOS.BLL.Interfaces;

namespace AzAgroPOS.PL.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            // DbContext
            services.AddScoped<AzAgroDbContext>();

            // Unit of Work Pattern
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Core Repositories
            services.AddScoped<IstifadeciRepository>();
            services.AddScoped<RolRepository>();
            services.AddScoped<MusteriRepository>();
            services.AddScoped<MehsulRepository>();
            services.AddScoped<SatisRepository>();
            services.AddScoped<SatisDetaliRepository>();
            services.AddScoped<SatisOdemesiRepository>();
            services.AddScoped<MusteriBorcRepository>();
            services.AddScoped<BorcOdenisRepository>();
            services.AddScoped<TamirIsiRepository>();
            services.AddScoped<TamirMerheleRepository>();
            services.AddScoped<TedarukcuRepository>();
            services.AddScoped<AlisOrderRepository>();
            services.AddScoped<AlisSenedRepository>();
            services.AddScoped<AnbarRepository>();
            services.AddScoped<AnbarQalikRepository>();
            services.AddScoped<AnbarHereketRepository>();
            services.AddScoped<GiderRepository>();
            services.AddScoped<SistemAyarlariRepository>();
            
            // Additional Core Repositories
            services.AddScoped<IsciRepository>();
            services.AddScoped<MehsulKateqoriyasiRepository>();
            services.AddScoped<VahidRepository>();
            services.AddScoped<AnbarTransferRepository>();
            services.AddScoped<MusteriQrupuRepository>();
            services.AddScoped<NovbeRepository>();
            services.AddScoped<SatisHesabatiRepository>();
            services.AddScoped<TedarukcuOdemeRepository>();
            
            // Shift Management Repositories
            services.AddScoped<NovbeCedveliRepository>();
            services.AddScoped<NovbeDetaliRepository>();
            services.AddScoped<IsciIzniRepository>();
            
            // Backup System Repositories
            services.AddScoped<BackupKaydiRepository>();
            services.AddScoped<BackupTenzimlemeRepository>();
            
            // Notification System Repositories
            services.AddScoped<BildirisRepository>();
            services.AddScoped<BildirisAyariRepository>();
            
            // Printer System Repositories
            services.AddScoped<PrinterKonfiqurasiyasiRepository>();
            services.AddScoped<PrintSablonuRepository>();
            services.AddScoped<PrintLogKaydiRepository>();

            // Services with interfaces
            services.AddScoped<IAuditLogService, AuditLogService>();
            services.AddScoped<IErrorHandlingService, ErrorHandlingService>();
            services.AddScoped<IUserContext, UserContext>();
            services.AddScoped<IAuthorizationService>(provider =>
            {
                var context = provider.GetRequiredService<AzAgroDbContext>();
                var rolRepository = new RolRepository(context);
                return new AuthorizationService(rolRepository);
            });
            services.AddScoped<IGiderRepository, GiderRepository>();
            
            // Loglama servisini Singleton olaraq qeydiyyatdan keçiririk
            // Singleton - bütün proqram boyunca eyni logger obyektindən istifadə edir
            services.AddSingleton<ILoggerService, FileLoggerService>();

            // Services (concrete implementations)
            services.AddScoped<AuthService>();
            services.AddScoped<MusteriService>();
            services.AddScoped<MehsulService>();
            services.AddScoped<SatisService>();
            services.AddScoped<BorcService>();
            services.AddScoped<TamirService>();
            services.AddScoped<TedarukcuService>();
            services.AddScoped<AnbarService>();
            services.AddScoped<ReportService>();
            services.AddScoped<ExportService>();
            services.AddScoped<DatabaseInitializationService>();
            services.AddScoped<CustomerAnalyticsService>();
            services.AddScoped<EmployeePerformanceService>();
            services.AddScoped<GiderService>();
            services.AddScoped<SistemAyarlariService>();
            services.AddScoped<LocalizationService>();
            
            // New Module Services
            services.AddScoped<NovbeIdaretmesiService>();
            services.AddScoped<BackupService>();
            services.AddScoped<BildirisService>();
            services.AddScoped<PrinterService>();

            // UI Services
            services.AddScoped<IUINotificationService, UINotificationService>();

            return services;
        }

        public static IHost CreateAppHost()
        {
            return Host.CreateDefaultBuilder()
                .UseContentRoot(System.AppContext.BaseDirectory)
                .ConfigureServices((context, services) =>
                {
                    services.ConfigureServices();
                })
                .Build();
        }
    }
}