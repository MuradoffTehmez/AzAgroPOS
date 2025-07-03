// Fayl: AzAgroPOS.PL/Program.cs

using AzAgroPOS.Entities;
using System;
using System.Windows.Forms;

namespace AzAgroPOS.PL
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Login formasını yarat və dialoq kimi göstər.
            // Kod bu sətirdə login forması bağlanana qədər gözləyəcək.
            frmLogin loginForm = new frmLogin();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Əgər login uğurlu olubsa (DialogResult.OK qayıdıbsa),
                // o zaman ana pəncərəni işə salırıq.
                // Daxil olan istifadəçi məlumatını login formasından alırıq.
                Application.Run(new frmMain(loginForm.LoggedInUser));
            }
            // Əgər login uğursuz olarsa (məsələn, Ləğv Et və ya X basılarsa),
            // if bloku işləməyəcək və Main metodu bitdiyi üçün proqram bağlanacaq.
        }
    }
}