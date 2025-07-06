using AzAgroPOS.PL.Themes;
using System;
using System.Windows.Forms;

namespace AzAgroPOS.PL
{
    public partial class frmSettings : BaseForm
    {
        public frmSettings()
        {
            InitializeComponent();
            LoadCurrentTheme();
        }

        private void LoadCurrentTheme()
        {
            // Hazırkı temaya uyğun radio düyməsini seçirik
            if (ThemeManager.CurrentTheme == AppTheme.Dark)
            {
                rbDarkTheme.Checked = true;
            }
            else
            {
                rbLightTheme.Checked = true;
            }
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSaveSettings_Click_1(object sender, EventArgs e)
        {
            // Seçilmiş temaya uyğun dəyəri təyin edirik
            var selectedTheme = rbDarkTheme.Checked ? AppTheme.Dark : AppTheme.Light;

            // Temanı dəyişirik (bu, ThemeManager-dəki event-i işə salacaq)
            ThemeManager.CurrentTheme = selectedTheme;

            // Seçimi yadda saxlayırıq
            Properties.Settings.Default.UserTheme = selectedTheme.ToString();
            Properties.Settings.Default.Save();

            MessageBox.Show("Ayarlar yadda saxlanıldı.", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}