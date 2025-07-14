using AzAgroPOS.BLL.Services;
using AzAgroPOS.DAL;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.PL
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Database-i initialize et
            try
            {
                var context = new AzAgroDbContext();
                var logger = CreateLogger();
                var dbInitService = new DatabaseInitializationService(context, logger);
                
                // Database mövcud deyilsə yaradın, mövcuddursa toxunmayın
                var initTask = dbInitService.InitializeDatabaseAsync();
                initTask.Wait();
                
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database initialization xətası: {ex.Message}\n\nInner Exception: {ex.InnerException?.Message}", 
                    "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Application.Run(new LoginForm());
        }
        
        private static ILogger<DatabaseInitializationService> CreateLogger()
        {
            // Create a simple console logger for database initialization
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            
            return loggerFactory.CreateLogger<DatabaseInitializationService>();
        }
    }
}
