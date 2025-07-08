using AzAgroPOS.Entities;
using AzAgroPOS.PL.Localization;
using AzAgroPOS.PL.Themes;
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
            // 1. DİL AYARINI YADDAŞDAN OXUYUB TƏTBİQ EDİRİK
            string culture = Properties.Settings.Default.UserLanguage;
            // Etdiyimiz dəyişikliklə, bu metod artıq Thread-in Culture məlumatlarını özü təyin edir.
            LocalizationManager.SetLanguage(culture);

            // 2. TEMA AYARINI YADDAŞDAN OXUYUB TƏTBİQ EDİRİK
            string savedTheme = Properties.Settings.Default.UserTheme;
            ThemeManager.CurrentTheme = savedTheme == "Dark" ? AppTheme.Dark : AppTheme.Light;

            // 3. STANDART WINDOWS FORMS AYARLARINI EDİRİK
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 4. LOGIN PROSESİNİ BAŞLADIRIQ
            using (frmLogin loginForm = new frmLogin())
            {
                // Login pəncərəsini dialoq kimi göstəririk və nəticəsini yoxlayırıq
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Əgər giriş uğurlu olubsa (istifadəçi "Daxil Ol" basıbsa),
                    // daxil olan istifadəçinin məlumatlarını login formasından götürürük
                    Istifadeci loggedInUser = loginForm.LoggedInUser;

                    // və əsas pəncərəni həmin istifadəçi ilə birlikdə işə salırıq.
                    Application.Run(new frmMain(loggedInUser));
                }
                // Əgər login uğursuz olarsa (pəncərə "Ləğv Et" və ya X ilə bağlanarsa),
                // if bloku işləməyəcək və Main metodu bitdiyi üçün proqram bağlanacaq.
            }
        }
    }
}