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
                
                // Debug məqsədi ilə database-i təmizlə və yenidən yarat
                var initTask = dbInitService.ClearAndInitializeDatabaseAsync();
                initTask.Wait();
                
                MessageBox.Show("Database uğurla hazırlandı!\n\nTest məlumatları:\nEmail: admin@azagropos.az\nŞifrə: admin123", 
                    "Sistem Hazır", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
