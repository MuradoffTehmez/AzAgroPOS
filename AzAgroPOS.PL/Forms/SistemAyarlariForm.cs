using AzAgroPOS.BLL.Services;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.PL.Services;
using AzAgroPOS.PL.Styles;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class SistemAyarlariForm : BaseForm
    {
        private readonly SistemAyarlariService _sistemAyarlariService;
        private readonly IServiceProvider _serviceProvider;
        private Istifadeci _currentUser;
        private string _selectedLogoPath = "";

        public SistemAyarlariForm(Istifadeci currentUser, IServiceProvider serviceProvider) : base()
        {
            _serviceProvider = serviceProvider;
            _sistemAyarlariService = serviceProvider.GetRequiredService<SistemAyarlariService>();
            _currentUser = currentUser;
            InitializeComponent();
            this.Load += SistemAyarlariForm_Load;
        }

        public SistemAyarlariForm(Istifadeci currentUser) : this(currentUser, Program.ServiceProvider)
        {
        }

        private async void SistemAyarlariForm_Load(object sender, EventArgs e)
        {
            await LoadCurrentSettingsAsync();
        }

        private void PnlHeader_Paint(object sender, PaintEventArgs e)
        {
            using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                pnlHeader.ClientRectangle,
                ModernTheme.Colors.Primary,
                ModernTheme.Colors.PrimaryDark,
                System.Drawing.Drawing2D.LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(brush, pnlHeader.ClientRectangle);
            }
        }

        private async Task LoadCurrentSettingsAsync()
        {
            try
            {
                // Regional Settings
                var language = await _sistemAyarlariService.GetCurrentLanguageAsync();
                cmbLanguage.SelectedIndex = language == "en" ? 1 : 0;
                txtCurrency.Text = await _sistemAyarlariService.GetCurrentCurrencyAsync();

                var dateFormat = await _sistemAyarlariService.GetDateFormatAsync();
                var dateIndex = cmbDateFormat.Items.IndexOf(dateFormat);
                if (dateIndex >= 0) cmbDateFormat.SelectedIndex = dateIndex;

                nudDecimalPlaces.Value = await _sistemAyarlariService.GetDecimalPlacesAsync();

                // Appearance Settings
                var theme = await _sistemAyarlariService.GetCurrentThemeAsync();
                var themeIndex = cmbTheme.Items.IndexOf(theme);
                if (themeIndex >= 0) cmbTheme.SelectedIndex = themeIndex;

                var primaryColor = await _sistemAyarlariService.GetPrimaryColorAsync();
                pnlColorPicker.BackColor = primaryColor;
                lblColorPreview.Text = _sistemAyarlariService.ColorToHex(primaryColor);

                nudFontSize.Value = await _sistemAyarlariService.GetFontSizeAsync();
                txtCompanyName.Text = await _sistemAyarlariService.GetCompanyNameAsync();
                txtCompanyAddress.Text = await _sistemAyarlariService.GetCompanyAddressAsync();

                var logoPath = await _sistemAyarlariService.GetLogoPathAsync();
                LoadLogoImage(logoPath);

                // POS Settings
                chkReceiptPrinting.Checked = await _sistemAyarlariService.GetReceiptPrintingEnabledAsync();
                chkAutomaticReceipt.Checked = await _sistemAyarlariService.GetAutomaticReceiptAsync();

                // Business Settings
                nudVATRate.Value = await _sistemAyarlariService.GetVATRateAsync();
                txtVATNumber.Text = await _sistemAyarlariService.GetVATNumberAsync();
                txtPhoneNumber.Text = await _sistemAyarlariService.GetPhoneNumberAsync();
                txtEmailAddress.Text = await _sistemAyarlariService.GetEmailAddressAsync();

                // Security Settings
                nudMaxLoginAttempts.Value = await _sistemAyarlariService.GetMaxLoginAttemptsAsync();
                nudLockoutDuration.Value = await _sistemAyarlariService.GetLockoutDurationAsync();

                // Notification Settings
                nudStockAlertLevel.Value = await _sistemAyarlariService.GetStockAlertLevelAsync();
                chkSMSNotifications.Checked = await _sistemAyarlariService.GetSMSNotificationsEnabledAsync();
                chkEmailNotifications.Checked = await _sistemAyarlariService.GetEmailNotificationsEnabledAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ayarlar yüklənərkən xəta: {ex.Message}", "Xəta",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLogoImage(string logoPath)
        {
            try
            {
                if (!string.IsNullOrEmpty(logoPath))
                {
                    var fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, logoPath);
                    if (File.Exists(fullPath))
                    {
                        picLogo.Image = Image.FromFile(fullPath);
                        _selectedLogoPath = logoPath;
                    }
                }
            }
            catch (Exception)
            {
                // Logo yükləmə xətalarını nəzərə alma
            }
        }

        private void PnlColorPicker_Click(object sender, EventArgs e)
        {
            using (var colorDialog = new ColorDialog())
            {
                colorDialog.Color = pnlColorPicker.BackColor;
                colorDialog.AllowFullOpen = true;

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    pnlColorPicker.BackColor = colorDialog.Color;
                    lblColorPreview.Text = _sistemAyarlariService.ColorToHex(colorDialog.Color);
                }
            }
        }

        private void BtnSelectLogo_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Şəkil Faylları|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Bütün Fayllar|*.*";
                openFileDialog.Title = "Logo Seçin";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        picLogo.Image = Image.FromFile(openFileDialog.FileName);
                        _selectedLogoPath = openFileDialog.FileName;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Logo yüklənərkən xəta: {ex.Message}", "Xəta",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnRemoveLogo_Click(object sender, EventArgs e)
        {
            picLogo.Image = null;
            _selectedLogoPath = "";
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave.Enabled = false;
                btnSave.Text = "Saxlanılır...";

                // Bütün ayarları yadda saxlamaq üçün service metodlarını çağır
                var selectedLanguage = cmbLanguage.SelectedIndex == 1 ? "en" : "az";
                await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.Dil, selectedLanguage);
                await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.Valyuta, txtCurrency.Text);
                await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.TarixFormati, cmbDateFormat.SelectedItem?.ToString());
                await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.OndalikNoqte, (int)nudDecimalPlaces.Value);
                await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.Tema, cmbTheme.SelectedItem?.ToString());
                await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.EsasReng, lblColorPreview.Text);
                await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.YaziOlcusu, (int)nudFontSize.Value);
                await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.SirketAdi, txtCompanyName.Text);
                await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.SirketUnvani, txtCompanyAddress.Text);

                if (!string.IsNullOrEmpty(_selectedLogoPath) && File.Exists(_selectedLogoPath))
                {
                    var logoPath = await _sistemAyarlariService.SaveLogoAsync(_selectedLogoPath);
                    if (!string.IsNullOrEmpty(logoPath))
                    {
                        await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.LogoYolu, logoPath);
                    }
                }

                await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.QebzCapi, chkReceiptPrinting.Checked);
                await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.AvtomatikQebz, chkAutomaticReceipt.Checked);
                await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.EdvDerecesi, nudVATRate.Value);
                await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.EdvNomresi, txtVATNumber.Text);
                await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.TelefonNomresi, txtPhoneNumber.Text);
                await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.EmailAdresi, txtEmailAddress.Text);
                await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.GirisCehdSayi, (int)nudMaxLoginAttempts.Value);
                await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.BloklananMuddet, (int)nudLockoutDuration.Value);
                await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.MehsulQitligi, (int)nudStockAlertLevel.Value);
                await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.SmsAktiv, chkSMSNotifications.Checked);
                await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.EmailAktiv, chkEmailNotifications.Checked);

                MessageBox.Show("Sistem ayarları uğurla saxlanıldı.", "Uğur",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ayarlar saxlanılarkən xəta: {ex.Message}", "Xəta",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSave.Enabled = true;
                btnSave.Text = "💾 Saxla";
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async void BtnDefaults_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bütün ayarları defolt vəziyyətə qaytarmaq istədiyinizə əminsiniz?",
                "Təsdiq", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    await _sistemAyarlariService.InitializeDefaultSettingsAsync();
                    await LoadCurrentSettingsAsync();

                    MessageBox.Show("Ayarlar defolt vəziyyətə qaytarıldı.", "Uğur",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Defolt ayarlar yüklənərkən xəta: {ex.Message}", "Xəta",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

        }

        private void btnDefaults_Click_1(object sender, EventArgs e)
        {

        }
    }
}