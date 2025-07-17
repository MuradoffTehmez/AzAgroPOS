using AzAgroPOS.BLL.Services;
using AzAgroPOS.BLL.Interfaces;
using AzAgroPOS.DAL;
using AzAgroPOS.PL.Services;
using AzAgroPOS.PL.Security;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
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
            // Qlobal xəta tutucularını quraşdırırıq - Kritik Məsələ №3
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Kritik Məsələ №2: Connection String Şifrələnməsi
            ConfigProtector.Protect();
            
            // Configure dependency injection
            _host = ServiceCollectionExtensions.CreateAppHost();
            _serviceProvider = _host.Services;
            
            // ServiceFactory-ni ServiceProvider ilə initialize et
            ServiceFactory.Initialize(_serviceProvider);
            
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

            // Show splash screen first
            var splashScreen = new Forms.ModernSplashScreen();
            if (splashScreen.ShowDialog() == DialogResult.OK)
            {
                // Start with MaterialModernLoginForm using DI
                using var loginScope = _serviceProvider.CreateScope();
                var loginForm = new Forms.MaterialModernLoginForm(loginScope.ServiceProvider);
                
                // Login form-u əsas mesaj döngüsü kimi başlat
                Application.Run(loginForm);
            }

            // ServiceFactory resources təmizlə
            ServiceFactory.Cleanup();
            
            _host?.Dispose();
        }

        public static IServiceProvider ServiceProvider => _serviceProvider;
        
        #region Qlobal Xəta İdarəetməsi - Kritik Məsələ №3
        
        /// <summary>
        /// UI thread-də baş verən tutulmamış xətalar üçün
        /// </summary>
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            HandleException(e.Exception, "UI Thread Exception");
        }

        /// <summary>
        /// Arxa plan thread-lərdə baş verən tutulmamış xətalar üçün
        /// </summary>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException(e.ExceptionObject as Exception, "AppDomain Unhandled Exception");
        }

        /// <summary>
        /// Xətaları idarə edən mərkəzi metod
        /// </summary>
        private static void HandleException(Exception ex, string source = "Unknown")
        {
            if (ex == null) return;

            try
            {
                // Xətanı log faylına yazırıq
                ILoggerService logger = null;
                
                if (_serviceProvider != null)
                {
                    try
                    {
                        logger = _serviceProvider.GetService<ILoggerService>();
                    }
                    catch
                    {
                        // DI container-dən alına bilməzsə, manual yaradırıq
                        logger = new FileLoggerService();
                    }
                }
                else
                {
                    // ServiceProvider hələ hazır deyilsə, manual yaradırıq
                    logger = new FileLoggerService();
                }

                // Xəta məlumatını əlavə kontekst ilə loglayırıq
                logger?.LogError(new Exception($"[{source}] {ex.Message}", ex));
                
                // Əlavə sistem məlumatları
                logger?.LogInfo($"System Info - OS: {Environment.OSVersion}, .NET: {Environment.Version}");
                logger?.LogInfo($"Application: {Application.ProductName} v{Application.ProductVersion}");
            }
            catch (Exception loggingEx)
            {
                // Son çarə - Windows Event Log
                try
                {
                    System.Diagnostics.EventLog.WriteEntry("AzAgroPOS", 
                        $"Kritik xəta və loglama problemi!\nXəta: {ex?.Message}\nLoglama xətası: {loggingEx.Message}", 
                        System.Diagnostics.EventLogEntryType.Error);
                }
                catch
                {
                    // Heç bir log mexanizmi işləmirsə, sadəcə Windows mesaj qutusu göstər
                }
            }

            // İstifadəçiyə anlaşıqlı mesaj göstəririk
            try
            {
                MessageBox.Show(
                    "Gözlənilməz bir xəta baş verdi. Problem haqqında məlumat avtomatik olaraq qeydə alındı.\n\n" +
                    "Xəta məlumatları 'logs' qovluğunda saxlanılıb.\n\n" +
                    "Zəhmət olmasa proqramı yenidən başladın.",
                    "AzAgroPOS - Sistem Xətası",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch
            {
                // MessageBox də göstərilə bilmirsə, heç nə etmə
            }

            // Proqramı təhlükəsiz şəkildə bağlayırıq
            try
            {
                Application.Exit();
            }
            catch
            {
                // Son çarə
                Environment.Exit(1);
            }
        }
        
        #endregion
        
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
