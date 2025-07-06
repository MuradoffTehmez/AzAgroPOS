using AzAgroPOS.Entities;
using AzAgroPOS.PL.Localization;
using AzAgroPOS.PL.Themes;
using System;
using System.Windows.Forms;

namespace AzAgroPOS.PL
{
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
            cmbLanguage.Items.Add(new { Text = "Azərbaycan", Value = "az-Latn-AZ" });
            cmbLanguage.Items.Add(new { Text = "English", Value = "en" });
            cmbLanguage.DisplayMember = "Text";
            cmbLanguage.ValueMember = "Value";

            string currentLang = Properties.Settings.Default.UserLanguage;
            foreach (var item in cmbLanguage.Items)
            {
                if ((item as dynamic).Value == currentLang)
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
            ThemeManager.CurrentTheme = selectedTheme; // Bu, canlı dəyişikliyi təmin edir

            // Dil seçimini yadda saxla
            string selectedCulture = (cmbLanguage.SelectedItem as dynamic).Value;
            Properties.Settings.Default.UserLanguage = selectedCulture;

            Properties.Settings.Default.Save();

            MessageBox.Show("Ayarlar yadda saxlanıldı. Dil dəyişikliklərinin tam tətbiq olunması üçün proqramı yenidən başladın.", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            // Bu pəncərə başqa bir pəncərənin içində açıla bilmədiyi üçün
            // ana pəncərədən (frmMain) açılmalıdır. Bu düyməni gələcəkdə
            // daha mürəkkəb bir məntiqlə işlədə bilərik. Hələlik bu şəkildə saxlayaq.
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