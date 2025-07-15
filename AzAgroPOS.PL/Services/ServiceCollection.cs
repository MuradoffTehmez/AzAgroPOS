using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AzAgroPOS.DAL;
using AzAgroPOS.DAL.Repositories;
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

            // Repositories
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

            // Services
            services.AddScoped<AuthService>();
            services.AddScoped<MusteriService>();
            services.AddScoped<MehsulService>();
            services.AddScoped<SatisService>();
            services.AddScoped<BorcService>();
            services.AddScoped<TamirService>();
            services.AddScoped<ReportService>();
            services.AddScoped<ExportService>();
            services.AddScoped<AuditLogService>();
            services.AddScoped<DatabaseInitializationService>();
            services.AddScoped<CustomerAnalyticsService>();
            services.AddScoped<EmployeePerformanceService>();
            services.AddScoped<GiderService>();

            // Error Handling
            services.AddScoped<IErrorHandlingService, ErrorHandlingService>();

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