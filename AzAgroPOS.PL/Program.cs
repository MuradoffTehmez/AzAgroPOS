using AzAgroPOS.BLL.Services;
using AzAgroPOS.DAL;
using AzAgroPOS.PL.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.PL
{
    internal static class Program
    {
        private static IHost _host;
        private static IServiceProvider _serviceProvider;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Configure dependency injection
            _host = ServiceCollectionExtensions.CreateAppHost();
            _serviceProvider = _host.Services;
            
            // Database-i initialize et
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<AzAgroDbContext>();
                var logger = CreateLogger();
                var dbInitService = new DatabaseInitializationService(context, logger);
                
                // Database mövcud deyilsə yaradın, mövcuddursa toxunmayın
                var initTask = dbInitService.InitializeDatabaseAsync();
                initTask.Wait();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database initialization xətası: {ex.Message}\n\nInner Exception: {ex.InnerException?.Message}", 
                    "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Start with LoginForm using DI
            using var loginScope = _serviceProvider.CreateScope();
            var loginForm = new LoginForm(loginScope.ServiceProvider);
            Application.Run(loginForm);

            _host?.Dispose();
        }

        public static IServiceProvider ServiceProvider => _serviceProvider;
        
        private static ILogger<DatabaseInitializationService> CreateLogger()
        {
            // Create a simple logger for database initialization
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                // Simple logger configuration without external dependencies
                builder.SetMinimumLevel(LogLevel.Information);
            });
            
            return loggerFactory.CreateLogger<DatabaseInitializationService>();
        }
    }
}
