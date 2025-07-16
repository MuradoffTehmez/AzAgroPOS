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

        // UI Controls
        private TabControl tabMain;
        private Panel pnlHeader;
        private Panel pnlButtons;
        private Label lblTitle;
        private Button btnSave;
        private Button btnCancel;
        private Button btnDefaults;
        private Button btnImport;
        private Button btnExport;

        // Regional Tab
        private TabPage tabRegional;
        private ComboBox cmbLanguage;
        private TextBox txtCurrency;
        private ComboBox cmbDateFormat;
        private NumericUpDown nudDecimalPlaces;

        // Appearance Tab
        private TabPage tabAppearance;
        private ComboBox cmbTheme;
        private Panel pnlColorPicker;
        private Label lblColorPreview;
        private NumericUpDown nudFontSize;
        private TextBox txtCompanyName;
        private TextBox txtCompanyAddress;
        private PictureBox picLogo;
        private Button btnSelectLogo;
        private Button btnRemoveLogo;

        // POS Tab
        private TabPage tabPOS;
        private CheckBox chkReceiptPrinting;
        private ComboBox cmbPrinter;
        private CheckBox chkAutomaticReceipt;
        private TextBox txtCashierName;

        // Business Tab
        private TabPage tabBusiness;
        private NumericUpDown nudVATRate;
        private TextBox txtVATNumber;
        private TextBox txtPhoneNumber;
        private TextBox txtEmailAddress;
        private TextBox txtBusinessAddress;

        // Security Tab
        private TabPage tabSecurity;
        private NumericUpDown nudMaxLoginAttempts;
        private NumericUpDown nudLockoutDuration;
        private NumericUpDown nudSessionTimeout;

        // Notifications Tab
        private TabPage tabNotifications;
        private NumericUpDown nudStockAlertLevel;
        private CheckBox chkSMSNotifications;
        private CheckBox chkEmailNotifications;
        private CheckBox chkDebtAlerts;
        private CheckBox chkRepairAlerts;

        private string _selectedLogoPath = "";

        public SistemAyarlariForm(Istifadeci currentUser, IServiceProvider serviceProvider) : base()
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _sistemAyarlariService = serviceProvider.GetRequiredService<SistemAyarlariService>();
            _currentUser = currentUser;
            InitializeCustomComponents();
            SetupModernDesign();
            this.Load += SistemAyarlariForm_Load;
        }

        public SistemAyarlariForm(Istifadeci currentUser) : this(currentUser, Program.ServiceProvider)
        {
        }

        private async void SistemAyarlariForm_Load(object sender, EventArgs e)
        {
            await LoadCurrentSettingsAsync();
        }

        private void InitializeCustomComponents()
        {
            this.Text = "⚙️ Sistem Ayarları";
            this.Size = new Size(800, 700);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            CreateHeaderPanel();
            CreateTabControl();
            CreateButtonPanel();
            CreateRegionalTab();
            CreateAppearanceTab();
            CreatePOSTab();
            CreateBusinessTab();
            CreateSecurityTab();
            CreateNotificationsTab();

            this.Controls.AddRange(new Control[] { pnlHeader, tabMain, pnlButtons });
        }

        private void CreateHeaderPanel()
        {
            pnlHeader = new Panel
            {
                Height = 60,
                Dock = DockStyle.Top,
                BackColor = ModernTheme.Colors.Primary
            };
            pnlHeader.Paint += PnlHeader_Paint;

            lblTitle = new Label
            {
                Text = "⚙️ Sistem Ayarları",
                Font = ModernTheme.Fonts.Heading,
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(20, 18)
            };
            pnlHeader.Controls.Add(lblTitle);
        }

        private void CreateTabControl()
        {
            tabMain = new TabControl
            {
                Dock = DockStyle.Fill,
                Font = ModernTheme.Fonts.Body
            };
        }

        private void CreateButtonPanel()
        {
            pnlButtons = new Panel
            {
                Height = 60,
                Dock = DockStyle.Bottom,
                BackColor = ModernTheme.Colors.Surface,
                Padding = new Padding(20, 10, 20, 10)
            };

            // Save button
            btnSave = new Button
            {
                Text = "💾 Saxla",
                Size = new Size(100, 40),
                Location = new Point(pnlButtons.Width - 320, 10),
                Font = ModernTheme.Fonts.Button,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnSave.Click += BtnSave_Click;
            ModernTheme.ApplyButtonStyle(btnSave, true);

            // Cancel button
            btnCancel = new Button
            {
                Text = "❌ Ləğv Et",
                Size = new Size(100, 40),
                Location = new Point(pnlButtons.Width - 210, 10),
                Font = ModernTheme.Fonts.Button,
                DialogResult = DialogResult.Cancel,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnCancel.Click += BtnCancel_Click;
            ModernTheme.ApplyButtonStyle(btnCancel, false);

            // Defaults button
            btnDefaults = new Button
            {
                Text = "🔄 Defolt",
                Size = new Size(100, 40),
                Location = new Point(pnlButtons.Width - 100, 10),
                Font = ModernTheme.Fonts.Button,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            btnDefaults.Click += BtnDefaults_Click;
            ModernTheme.ApplyButtonStyle(btnDefaults, false);

            pnlButtons.Controls.AddRange(new Control[] { btnSave, btnCancel, btnDefaults });
        }

        private void CreateRegionalTab()
        {
            tabRegional = new TabPage("🌍 Regional");
            var panel = ModernTheme.CreateCard();
            panel.Dock = DockStyle.Fill;

            int y = 20;
            int labelHeight = 25;
            int inputHeight = 35;
            int spacing = 15;

            // Language
            var lblLanguage = new Label
            {
                Text = "Dil:",
                Font = ModernTheme.Fonts.BodyBold,
                Location = new Point(20, y),
                Size = new Size(150, labelHeight)
            };
            panel.Controls.Add(lblLanguage);

            cmbLanguage = new ComboBox
            {
                Location = new Point(180, y),
                Size = new Size(200, inputHeight),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbLanguage.Items.AddRange(new[] { "Azərbaycan", "English" });
            cmbLanguage.SelectedIndex = 0;
            ModernTheme.ApplyComboBoxStyle(cmbLanguage);
            panel.Controls.Add(cmbLanguage);

            y += inputHeight + spacing;

            // Currency
            var lblCurrency = new Label
            {
                Text = "Valyuta:",
                Font = ModernTheme.Fonts.BodyBold,
                Location = new Point(20, y),
                Size = new Size(150, labelHeight)
            };
            panel.Controls.Add(lblCurrency);

            txtCurrency = new TextBox
            {
                Location = new Point(180, y),
                Size = new Size(100, inputHeight),
                Text = "₼"
            };
            ModernTheme.ApplyTextBoxStyle(txtCurrency);
            panel.Controls.Add(txtCurrency);

            y += inputHeight + spacing;

            // Date Format
            var lblDateFormat = new Label
            {
                Text = "Tarix Formatı:",
                Font = ModernTheme.Fonts.BodyBold,
                Location = new Point(20, y),
                Size = new Size(150, labelHeight)
            };
            panel.Controls.Add(lblDateFormat);

            cmbDateFormat = new ComboBox
            {
                Location = new Point(180, y),
                Size = new Size(200, inputHeight),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbDateFormat.Items.AddRange(new[] { "dd.MM.yyyy", "dd/MM/yyyy", "yyyy-MM-dd", "MM/dd/yyyy" });
            cmbDateFormat.SelectedIndex = 0;
            ModernTheme.ApplyComboBoxStyle(cmbDateFormat);
            panel.Controls.Add(cmbDateFormat);

            y += inputHeight + spacing;

            // Decimal Places
            var lblDecimal = new Label
            {
                Text = "Ondalık Nöqtə:",
                Font = ModernTheme.Fonts.BodyBold,
                Location = new Point(20, y),
                Size = new Size(150, labelHeight)
            };
            panel.Controls.Add(lblDecimal);

            nudDecimalPlaces = new NumericUpDown
            {
                Location = new Point(180, y),
                Size = new Size(100, inputHeight),
                Minimum = 0,
                Maximum = 6,
                Value = 2
            };
            panel.Controls.Add(nudDecimalPlaces);

            tabRegional.Controls.Add(panel);
            tabMain.TabPages.Add(tabRegional);
        }

        private void CreateAppearanceTab()
        {
            tabAppearance = new TabPage("🎨 Görünüş");
            var panel = ModernTheme.CreateCard();
            panel.Dock = DockStyle.Fill;

            int y = 20;
            int labelHeight = 25;
            int inputHeight = 35;
            int spacing = 15;

            // Theme
            var lblTheme = new Label
            {
                Text = "Tema:",
                Font = ModernTheme.Fonts.BodyBold,
                Location = new Point(20, y),
                Size = new Size(150, labelHeight)
            };
            panel.Controls.Add(lblTheme);

            cmbTheme = new ComboBox
            {
                Location = new Point(180, y),
                Size = new Size(200, inputHeight),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbTheme.Items.AddRange(new[] { "Modern", "Classic", "Dark", "Light" });
            cmbTheme.SelectedIndex = 0;
            ModernTheme.ApplyComboBoxStyle(cmbTheme);
            panel.Controls.Add(cmbTheme);

            y += inputHeight + spacing;

            // Primary Color
            var lblColor = new Label
            {
                Text = "Əsas Rəng:",
                Font = ModernTheme.Fonts.BodyBold,
                Location = new Point(20, y),
                Size = new Size(150, labelHeight)
            };
            panel.Controls.Add(lblColor);

            pnlColorPicker = new Panel
            {
                Location = new Point(180, y),
                Size = new Size(50, 30),
                BackColor = ModernTheme.Colors.Primary,
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand
            };
            pnlColorPicker.Click += PnlColorPicker_Click;
            panel.Controls.Add(pnlColorPicker);

            lblColorPreview = new Label
            {
                Text = "#3498db",
                Location = new Point(240, y + 5),
                Size = new Size(100, 20),
                Font = ModernTheme.Fonts.Body
            };
            panel.Controls.Add(lblColorPreview);

            y += inputHeight + spacing;

            // Font Size
            var lblFontSize = new Label
            {
                Text = "Yazı Ölçüsü:",
                Font = ModernTheme.Fonts.BodyBold,
                Location = new Point(20, y),
                Size = new Size(150, labelHeight)
            };
            panel.Controls.Add(lblFontSize);

            nudFontSize = new NumericUpDown
            {
                Location = new Point(180, y),
                Size = new Size(100, inputHeight),
                Minimum = 8,
                Maximum = 16,
                Value = 10
            };
            panel.Controls.Add(nudFontSize);

            y += inputHeight + spacing;

            // Company Name
            var lblCompanyName = new Label
            {
                Text = "Şirkət Adı:",
                Font = ModernTheme.Fonts.BodyBold,
                Location = new Point(20, y),
                Size = new Size(150, labelHeight)
            };
            panel.Controls.Add(lblCompanyName);

            txtCompanyName = new TextBox
            {
                Location = new Point(180, y),
                Size = new Size(300, inputHeight),
                Text = "AzAgroPOS"
            };
            ModernTheme.ApplyTextBoxStyle(txtCompanyName);
            panel.Controls.Add(txtCompanyName);

            y += inputHeight + spacing;

            // Company Address
            var lblCompanyAddress = new Label
            {
                Text = "Şirkət Ünvanı:",
                Font = ModernTheme.Fonts.BodyBold,
                Location = new Point(20, y),
                Size = new Size(150, labelHeight)
            };
            panel.Controls.Add(lblCompanyAddress);

            txtCompanyAddress = new TextBox
            {
                Location = new Point(180, y),
                Size = new Size(300, 60),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };
            ModernTheme.ApplyTextBoxStyle(txtCompanyAddress);
            panel.Controls.Add(txtCompanyAddress);

            y += 60 + spacing;

            // Logo
            var lblLogo = new Label
            {
                Text = "Logo:",
                Font = ModernTheme.Fonts.BodyBold,
                Location = new Point(20, y),
                Size = new Size(150, labelHeight)
            };
            panel.Controls.Add(lblLogo);

            picLogo = new PictureBox
            {
                Location = new Point(180, y),
                Size = new Size(100, 60),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.White
            };
            panel.Controls.Add(picLogo);

            btnSelectLogo = new Button
            {
                Text = "📁 Seç",
                Location = new Point(290, y),
                Size = new Size(80, 30)
            };
            btnSelectLogo.Click += BtnSelectLogo_Click;
            ModernTheme.ApplyButtonStyle(btnSelectLogo, false);
            panel.Controls.Add(btnSelectLogo);

            btnRemoveLogo = new Button
            {
                Text = "🗑️ Sil",
                Location = new Point(380, y),
                Size = new Size(80, 30)
            };
            btnRemoveLogo.Click += BtnRemoveLogo_Click;
            ModernTheme.ApplyButtonStyle(btnRemoveLogo, false);
            panel.Controls.Add(btnRemoveLogo);

            tabAppearance.Controls.Add(panel);
            tabMain.TabPages.Add(tabAppearance);
        }

        private void CreatePOSTab()
        {
            tabPOS = new TabPage("🛒 POS");
            var panel = ModernTheme.CreateCard();
            panel.Dock = DockStyle.Fill;

            int y = 20;
            int spacing = 15;

            // Receipt Printing
            chkReceiptPrinting = new CheckBox
            {
                Text = "Qəbz çapını aktiv et",
                Location = new Point(20, y),
                Size = new Size(300, 25),
                Checked = true
            };
            panel.Controls.Add(chkReceiptPrinting);

            y += 25 + spacing;

            // Automatic Receipt
            chkAutomaticReceipt = new CheckBox
            {
                Text = "Avtomatik qəbz çapı",
                Location = new Point(20, y),
                Size = new Size(300, 25),
                Checked = true
            };
            panel.Controls.Add(chkAutomaticReceipt);

            tabPOS.Controls.Add(panel);
            tabMain.TabPages.Add(tabPOS);
        }

        private void CreateBusinessTab()
        {
            tabBusiness = new TabPage("🏢 Biznes");
            var panel = ModernTheme.CreateCard();
            panel.Dock = DockStyle.Fill;

            int y = 20;
            int labelHeight = 25;
            int inputHeight = 35;
            int spacing = 15;

            // VAT Rate
            var lblVAT = new Label
            {
                Text = "ƏDV Dərəcəsi (%):",
                Font = ModernTheme.Fonts.BodyBold,
                Location = new Point(20, y),
                Size = new Size(150, labelHeight)
            };
            panel.Controls.Add(lblVAT);

            nudVATRate = new NumericUpDown
            {
                Location = new Point(180, y),
                Size = new Size(100, inputHeight),
                DecimalPlaces = 2,
                Maximum = 100,
                Value = 18
            };
            panel.Controls.Add(nudVATRate);

            y += inputHeight + spacing;

            // VAT Number
            var lblVATNumber = new Label
            {
                Text = "ƏDV Nömrəsi:",
                Font = ModernTheme.Fonts.BodyBold,
                Location = new Point(20, y),
                Size = new Size(150, labelHeight)
            };
            panel.Controls.Add(lblVATNumber);

            txtVATNumber = new TextBox
            {
                Location = new Point(180, y),
                Size = new Size(200, inputHeight)
            };
            ModernTheme.ApplyTextBoxStyle(txtVATNumber);
            panel.Controls.Add(txtVATNumber);

            y += inputHeight + spacing;

            // Phone
            var lblPhone = new Label
            {
                Text = "Telefon:",
                Font = ModernTheme.Fonts.BodyBold,
                Location = new Point(20, y),
                Size = new Size(150, labelHeight)
            };
            panel.Controls.Add(lblPhone);

            txtPhoneNumber = new TextBox
            {
                Location = new Point(180, y),
                Size = new Size(200, inputHeight)
            };
            ModernTheme.ApplyTextBoxStyle(txtPhoneNumber);
            panel.Controls.Add(txtPhoneNumber);

            y += inputHeight + spacing;

            // Email
            var lblEmail = new Label
            {
                Text = "Email:",
                Font = ModernTheme.Fonts.BodyBold,
                Location = new Point(20, y),
                Size = new Size(150, labelHeight)
            };
            panel.Controls.Add(lblEmail);

            txtEmailAddress = new TextBox
            {
                Location = new Point(180, y),
                Size = new Size(250, inputHeight)
            };
            ModernTheme.ApplyTextBoxStyle(txtEmailAddress);
            panel.Controls.Add(txtEmailAddress);

            tabBusiness.Controls.Add(panel);
            tabMain.TabPages.Add(tabBusiness);
        }

        private void CreateSecurityTab()
        {
            tabSecurity = new TabPage("🔒 Təhlükəsizlik");
            var panel = ModernTheme.CreateCard();
            panel.Dock = DockStyle.Fill;

            int y = 20;
            int labelHeight = 25;
            int inputHeight = 35;
            int spacing = 15;

            // Max Login Attempts
            var lblMaxAttempts = new Label
            {
                Text = "Maks. Giriş Cəhdi:",
                Font = ModernTheme.Fonts.BodyBold,
                Location = new Point(20, y),
                Size = new Size(150, labelHeight)
            };
            panel.Controls.Add(lblMaxAttempts);

            nudMaxLoginAttempts = new NumericUpDown
            {
                Location = new Point(180, y),
                Size = new Size(100, inputHeight),
                Minimum = 1,
                Maximum = 10,
                Value = 3
            };
            panel.Controls.Add(nudMaxLoginAttempts);

            y += inputHeight + spacing;

            // Lockout Duration
            var lblLockout = new Label
            {
                Text = "Bloklanma (dəq):",
                Font = ModernTheme.Fonts.BodyBold,
                Location = new Point(20, y),
                Size = new Size(150, labelHeight)
            };
            panel.Controls.Add(lblLockout);

            nudLockoutDuration = new NumericUpDown
            {
                Location = new Point(180, y),
                Size = new Size(100, inputHeight),
                Minimum = 1,
                Maximum = 120,
                Value = 15
            };
            panel.Controls.Add(nudLockoutDuration);

            tabSecurity.Controls.Add(panel);
            tabMain.TabPages.Add(tabSecurity);
        }

        private void CreateNotificationsTab()
        {
            tabNotifications = new TabPage("🔔 Bildirişlər");
            var panel = ModernTheme.CreateCard();
            panel.Dock = DockStyle.Fill;

            int y = 20;
            int labelHeight = 25;
            int inputHeight = 35;
            int spacing = 15;

            // Stock Alert Level
            var lblStockAlert = new Label
            {
                Text = "Məhsul Qıtlığı Hədd:",
                Font = ModernTheme.Fonts.BodyBold,
                Location = new Point(20, y),
                Size = new Size(150, labelHeight)
            };
            panel.Controls.Add(lblStockAlert);

            nudStockAlertLevel = new NumericUpDown
            {
                Location = new Point(180, y),
                Size = new Size(100, inputHeight),
                Minimum = 1,
                Maximum = 100,
                Value = 5
            };
            panel.Controls.Add(nudStockAlertLevel);

            y += inputHeight + spacing;

            // SMS Notifications
            chkSMSNotifications = new CheckBox
            {
                Text = "SMS bildirişləri aktiv et",
                Location = new Point(20, y),
                Size = new Size(300, 25)
            };
            panel.Controls.Add(chkSMSNotifications);

            y += 25 + spacing;

            // Email Notifications
            chkEmailNotifications = new CheckBox
            {
                Text = "Email bildirişləri aktiv et",
                Location = new Point(20, y),
                Size = new Size(300, 25)
            };
            panel.Controls.Add(chkEmailNotifications);

            tabNotifications.Controls.Add(panel);
            tabMain.TabPages.Add(tabNotifications);
        }

        private void SetupModernDesign()
        {
            ModernTheme.ApplyModernStyle(this);
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
                // Ignore logo loading errors
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

                // Save Regional Settings
                var selectedLanguage = cmbLanguage.SelectedIndex == 1 ? "en" : "az";
                await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.Dil, selectedLanguage);
                await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.Valyuta, txtCurrency.Text);
                await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.TarixFormati, cmbDateFormat.SelectedItem?.ToString());
                await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.OndalikNoqte, (int)nudDecimalPlaces.Value);

                // Save Appearance Settings
                await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.Tema, cmbTheme.SelectedItem?.ToString());
                await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.EsasReng, lblColorPreview.Text);
                await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.YaziOlcusu, (int)nudFontSize.Value);
                await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.SirketAdi, txtCompanyName.Text);
                await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.SirketUnvani, txtCompanyAddress.Text);

                // Save logo if changed
                if (!string.IsNullOrEmpty(_selectedLogoPath) && File.Exists(_selectedLogoPath))
                {
                    var logoPath = await _sistemAyarlariService.SaveLogoAsync(_selectedLogoPath);
                    if (!string.IsNullOrEmpty(logoPath))
                    {
                        await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.LogoYolu, logoPath);
                    }
                }

                // Save POS Settings
                await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.QebzCapi, chkReceiptPrinting.Checked);
                await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.AvtomatikQebz, chkAutomaticReceipt.Checked);

                // Save Business Settings
                await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.EdvDerecesi, nudVATRate.Value);
                await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.EdvNomresi, txtVATNumber.Text);
                await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.TelefonNomresi, txtPhoneNumber.Text);
                await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.EmailAdresi, txtEmailAddress.Text);

                // Save Security Settings
                await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.GirisCehdSayi, (int)nudMaxLoginAttempts.Value);
                await _sistemAyarlariService.SetSettingAsync(SistemAyarlari.Keys.BloklananMuddet, (int)nudLockoutDuration.Value);

                // Save Notification Settings
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
    }
}