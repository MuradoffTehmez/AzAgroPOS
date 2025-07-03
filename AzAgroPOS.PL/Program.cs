// Düzgün FAYL: AzAgroPOS.PL/Program.cs
using AzAgroPOS.Entities;
using System;
using System.Windows.Forms;

namespace AzAgroPOS.PL
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmLogin loginForm = new frmLogin();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new frmMain(loginForm.LoggedInUser));
            }
        }
    }
}