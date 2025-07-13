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
            Task.Run(async () =>
            {
                try
                {
                    var dbInitService = new DatabaseInitializationService();
                    await dbInitService.InitializeDatabaseAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database initialization xətası: {ex.Message}", 
                        "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }).Wait();

            Application.Run(new LoginForm());
        }
    }
}
