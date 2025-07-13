using AzAgroPOS.BLL.Services;
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
                var dbInitService = new DatabaseInitializationService();
                
                // Database mövcud deyilsə yaradın, mövcuddursa toxunmayın
                var initTask = dbInitService.InitializeDatabaseAsync();
                initTask.Wait();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database initialization xətası: {ex.Message}\n\nInner Exception: {ex.InnerException?.Message}", 
                    "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Application.Run(new LoginForm());
        }
    }
}
