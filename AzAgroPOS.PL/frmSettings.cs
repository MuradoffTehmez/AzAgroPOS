using AzAgroPOS.Entities;
using AzAgroPOS.PL.Localization;
using AzAgroPOS.PL.Themes;
using System;
using System.Windows.Forms;

namespace AzAgroPOS.PL
{
    /// <summary>
    /// Dil seçimlərini ComboBox-da saxlamaq üçün köməkçi sinif
    /// </summary>
    public class LanguageItem
    {
        public string Text { get; set; }
        public string Value { get; set; }

        // ComboBox-da düzgün görünməsi üçün
        public override string ToString()
        {
            return Text;
        }
    }

    public partial class frmSettings : BaseForm
    {
        private readonly Istifadeci _currentUser;
        public frmSettings(Istifadeci currentUser)
        {
            InitializeComponent();
            _currentUser = currentUser;

            // Düymələrə stil üçün Tag veririk
            btnSaveSettings.Tag = "Success";
            btnUsers.Tag = "Primary";
            btnAuditLog.Tag = "Primary";
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            LoadCurrentTheme();
            LoadLanguages();
        }

        private void LoadCurrentTheme()
        {
            if (ThemeManager.CurrentTheme == AppTheme.Dark)
            {
                rbDarkTheme.Checked = true;
            }
            else
            {
                rbLightTheme.Checked = true;
            }
        }

        private void LoadLanguages()
        {
            cmbLanguage.Items.Clear();
            // DÜZƏLİŞ: Artıq xüsusi LanguageItem sinifindən istifadə edirik
            cmbLanguage.Items.Add(new LanguageItem { Text = "Azərbaycan", Value = "az-Latn-AZ" });
            cmbLanguage.Items.Add(new LanguageItem { Text = "English", Value = "en" });

            string currentLang = Properties.Settings.Default.UserLanguage;
            foreach (LanguageItem item in cmbLanguage.Items)
            {
                if (item.Value == currentLang)
                {
                    cmbLanguage.SelectedItem = item;
                    break;
                }
            }
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            // Tema seçimini yadda saxla və tətbiq et
            var selectedTheme = rbDarkTheme.Checked ? AppTheme.Dark : AppTheme.Light;
            Properties.Settings.Default.UserTheme = selectedTheme.ToString();
            ThemeManager.CurrentTheme = selectedTheme;

            // Dil seçimini yadda saxlayırıq
            if (cmbLanguage.SelectedItem is LanguageItem selectedLang)
            {
                Properties.Settings.Default.UserLanguage = selectedLang.Value;
            }

            Properties.Settings.Default.Save();

            // Dili dinamik olaraq dəyişirik
            LocalizationManager.SetLanguage(Properties.Settings.Default.UserLanguage);

            MessageBox.Show("Ayarlar yadda saxlanıldı. Bəzi dəyişikliklər üçün proqramı yenidən başlatmaq lazım ola bilər.", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            using (var userForm = new frmUsers(_currentUser))
            {
                userForm.ShowDialog();
            }
        }

        private void btnAuditLog_Click(object sender, EventArgs e)
        {
            using (var logForm = new frmAuditLog())
            {
                logForm.ShowDialog();
            }
        }
    }
}