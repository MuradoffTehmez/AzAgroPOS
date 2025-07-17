using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    partial class SistemAyarlariForm
    {
        private System.ComponentModel.IContainer components = null;

        private TabControl tabMain;
        private Panel pnlHeader;
        private Panel pnlButtons;
        private Label lblTitle;
        private Button btnSave;
        private Button btnCancel;
        private Button btnDefaults;
        private Button btnImport;
        private Button btnExport;

        private TabPage tabRegional;
        private ComboBox cmbLanguage;
        private TextBox txtCurrency;
        private ComboBox cmbDateFormat;
        private NumericUpDown nudDecimalPlaces;

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

        private TabPage tabPOS;
        private CheckBox chkReceiptPrinting;
        private ComboBox cmbPrinter;
        private CheckBox chkAutomaticReceipt;
        private TextBox txtCashierName;

        private TabPage tabBusiness;
        private NumericUpDown nudVATRate;
        private TextBox txtVATNumber;
        private TextBox txtPhoneNumber;
        private TextBox txtEmailAddress;
        private TextBox txtBusinessAddress;

        private TabPage tabSecurity;
        private NumericUpDown nudMaxLoginAttempts;
        private NumericUpDown nudLockoutDuration;
        private NumericUpDown nudSessionTimeout;

        private TabPage tabNotifications;
        private NumericUpDown nudStockAlertLevel;
        private CheckBox chkSMSNotifications;
        private CheckBox chkEmailNotifications;
        private CheckBox chkDebtAlerts;
        private CheckBox chkRepairAlerts;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            tabMain = new TabControl();
            pnlHeader = new Panel();
            lblTitle = new Label();
            pnlButtons = new Panel();
            btnSave = new Button();
            btnCancel = new Button();
            btnDefaults = new Button();
            tabRegional = new TabPage();
            nudDecimalPlaces = new NumericUpDown();
            cmbDateFormat = new ComboBox();
            txtCurrency = new TextBox();
            cmbLanguage = new ComboBox();
            tabAppearance = new TabPage();
            btnRemoveLogo = new Button();
            btnSelectLogo = new Button();
            picLogo = new PictureBox();
            txtCompanyAddress = new TextBox();
            txtCompanyName = new TextBox();
            nudFontSize = new NumericUpDown();
            lblColorPreview = new Label();
            pnlColorPicker = new Panel();
            cmbTheme = new ComboBox();
            tabPOS = new TabPage();
            chkAutomaticReceipt = new CheckBox();
            chkReceiptPrinting = new CheckBox();
            tabBusiness = new TabPage();
            txtEmailAddress = new TextBox();
            txtPhoneNumber = new TextBox();
            txtVATNumber = new TextBox();
            nudVATRate = new NumericUpDown();
            tabSecurity = new TabPage();
            nudLockoutDuration = new NumericUpDown();
            nudMaxLoginAttempts = new NumericUpDown();
            tabNotifications = new TabPage();
            chkEmailNotifications = new CheckBox();
            chkSMSNotifications = new CheckBox();
            nudStockAlertLevel = new NumericUpDown();
            pnlHeader.SuspendLayout();
            pnlButtons.SuspendLayout();
            tabRegional.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudDecimalPlaces).BeginInit();
            tabAppearance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudFontSize).BeginInit();
            tabPOS.SuspendLayout();
            tabBusiness.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudVATRate).BeginInit();
            tabSecurity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudLockoutDuration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMaxLoginAttempts).BeginInit();
            tabNotifications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudStockAlertLevel).BeginInit();
            SuspendLayout();
            // 
            // tabMain
            // 
            tabMain.Dock = DockStyle.Fill;
            tabMain.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 162);
            tabMain.Location = new System.Drawing.Point(0, 60);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new System.Drawing.Size(800, 580);
            tabMain.TabIndex = 0;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new System.Drawing.Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new System.Drawing.Size(800, 60);
            pnlHeader.TabIndex = 1;
            pnlHeader.Paint += PnlHeader_Paint;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(20, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(171, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "⚙️ Sistem Ayarları";
            // 
            // pnlButtons
            // 
            pnlButtons.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            pnlButtons.Controls.Add(btnSave);
            pnlButtons.Controls.Add(btnCancel);
            pnlButtons.Controls.Add(btnDefaults);
            pnlButtons.Dock = DockStyle.Bottom;
            pnlButtons.Location = new System.Drawing.Point(0, 640);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Padding = new Padding(20, 10, 20, 10);
            pnlButtons.Size = new System.Drawing.Size(800, 60);
            pnlButtons.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnSave.ForeColor = System.Drawing.Color.White;
            btnSave.Location = new System.Drawing.Point(480, 10);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(100, 40);
            btnSave.TabIndex = 0;
            btnSave.Text = "💾 Saxla";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click_1;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancel.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnCancel.ForeColor = System.Drawing.Color.White;
            btnCancel.Location = new System.Drawing.Point(590, 10);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(100, 40);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "❌ Ləğv Et";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click_1;
            // 
            // btnDefaults
            // 
            btnDefaults.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDefaults.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            btnDefaults.FlatAppearance.BorderSize = 0;
            btnDefaults.FlatStyle = FlatStyle.Flat;
            btnDefaults.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnDefaults.ForeColor = System.Drawing.Color.White;
            btnDefaults.Location = new System.Drawing.Point(700, 10);
            btnDefaults.Name = "btnDefaults";
            btnDefaults.Size = new System.Drawing.Size(100, 40);
            btnDefaults.TabIndex = 2;
            btnDefaults.Text = "🔄 Defolt";
            btnDefaults.UseVisualStyleBackColor = false;
            btnDefaults.Click += btnDefaults_Click_1;
            // 
            // tabRegional
            // 
            tabRegional.Controls.Add(nudDecimalPlaces);
            tabRegional.Controls.Add(cmbDateFormat);
            tabRegional.Controls.Add(txtCurrency);
            tabRegional.Controls.Add(cmbLanguage);
            tabRegional.Location = new System.Drawing.Point(4, 24);
            tabRegional.Name = "tabRegional";
            tabRegional.Padding = new Padding(3);
            tabRegional.Size = new System.Drawing.Size(792, 552);
            tabRegional.TabIndex = 0;
            tabRegional.Text = "🌍 Regional";
            tabRegional.UseVisualStyleBackColor = true;
            // 
            // nudDecimalPlaces
            // 
            nudDecimalPlaces.Location = new System.Drawing.Point(180, 140);
            nudDecimalPlaces.Maximum = new decimal(new int[] { 6, 0, 0, 0 });
            nudDecimalPlaces.Name = "nudDecimalPlaces";
            nudDecimalPlaces.Size = new System.Drawing.Size(100, 23);
            nudDecimalPlaces.TabIndex = 3;
            nudDecimalPlaces.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // cmbDateFormat
            // 
            cmbDateFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDateFormat.FormattingEnabled = true;
            cmbDateFormat.Items.AddRange(new object[] { "dd.MM.yyyy", "dd/MM/yyyy", "yyyy-MM-dd", "MM/dd/yyyy" });
            cmbDateFormat.Location = new System.Drawing.Point(180, 100);
            cmbDateFormat.Name = "cmbDateFormat";
            cmbDateFormat.Size = new System.Drawing.Size(200, 23);
            cmbDateFormat.TabIndex = 2;
            // 
            // txtCurrency
            // 
            txtCurrency.Location = new System.Drawing.Point(180, 60);
            txtCurrency.Name = "txtCurrency";
            txtCurrency.Size = new System.Drawing.Size(100, 23);
            txtCurrency.TabIndex = 1;
            txtCurrency.Text = "₼";
            // 
            // cmbLanguage
            // 
            cmbLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLanguage.FormattingEnabled = true;
            cmbLanguage.Items.AddRange(new object[] { "Azərbaycan", "English" });
            cmbLanguage.Location = new System.Drawing.Point(180, 20);
            cmbLanguage.Name = "cmbLanguage";
            cmbLanguage.Size = new System.Drawing.Size(200, 23);
            cmbLanguage.TabIndex = 0;
            // 
            // tabAppearance
            // 
            tabAppearance.Controls.Add(btnRemoveLogo);
            tabAppearance.Controls.Add(btnSelectLogo);
            tabAppearance.Controls.Add(picLogo);
            tabAppearance.Controls.Add(txtCompanyAddress);
            tabAppearance.Controls.Add(txtCompanyName);
            tabAppearance.Controls.Add(nudFontSize);
            tabAppearance.Controls.Add(lblColorPreview);
            tabAppearance.Controls.Add(pnlColorPicker);
            tabAppearance.Controls.Add(cmbTheme);
            tabAppearance.Location = new System.Drawing.Point(4, 24);
            tabAppearance.Name = "tabAppearance";
            tabAppearance.Padding = new Padding(3);
            tabAppearance.Size = new System.Drawing.Size(792, 552);
            tabAppearance.TabIndex = 1;
            tabAppearance.Text = "🎨 Görünüş";
            tabAppearance.UseVisualStyleBackColor = true;
            // 
            // btnRemoveLogo
            // 
            btnRemoveLogo.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            btnRemoveLogo.FlatAppearance.BorderSize = 0;
            btnRemoveLogo.FlatStyle = FlatStyle.Flat;
            btnRemoveLogo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnRemoveLogo.ForeColor = System.Drawing.Color.White;
            btnRemoveLogo.Location = new System.Drawing.Point(380, 260);
            btnRemoveLogo.Name = "btnRemoveLogo";
            btnRemoveLogo.Size = new System.Drawing.Size(80, 30);
            btnRemoveLogo.TabIndex = 8;
            btnRemoveLogo.Text = "🗑️ Sil";
            btnRemoveLogo.UseVisualStyleBackColor = false;
            // 
            // btnSelectLogo
            // 
            btnSelectLogo.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            btnSelectLogo.FlatAppearance.BorderSize = 0;
            btnSelectLogo.FlatStyle = FlatStyle.Flat;
            btnSelectLogo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnSelectLogo.ForeColor = System.Drawing.Color.White;
            btnSelectLogo.Location = new System.Drawing.Point(290, 260);
            btnSelectLogo.Name = "btnSelectLogo";
            btnSelectLogo.Size = new System.Drawing.Size(80, 30);
            btnSelectLogo.TabIndex = 7;
            btnSelectLogo.Text = "📁 Seç";
            btnSelectLogo.UseVisualStyleBackColor = false;
            // 
            // picLogo
            // 
            picLogo.BackColor = System.Drawing.Color.White;
            picLogo.BorderStyle = BorderStyle.FixedSingle;
            picLogo.Location = new System.Drawing.Point(180, 260);
            picLogo.Name = "picLogo";
            picLogo.Size = new System.Drawing.Size(100, 60);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 6;
            picLogo.TabStop = false;
            // 
            // txtCompanyAddress
            // 
            txtCompanyAddress.Location = new System.Drawing.Point(180, 180);
            txtCompanyAddress.Multiline = true;
            txtCompanyAddress.Name = "txtCompanyAddress";
            txtCompanyAddress.ScrollBars = ScrollBars.Vertical;
            txtCompanyAddress.Size = new System.Drawing.Size(300, 60);
            txtCompanyAddress.TabIndex = 5;
            // 
            // txtCompanyName
            // 
            txtCompanyName.Location = new System.Drawing.Point(180, 140);
            txtCompanyName.Name = "txtCompanyName";
            txtCompanyName.Size = new System.Drawing.Size(300, 23);
            txtCompanyName.TabIndex = 4;
            txtCompanyName.Text = "AzAgroPOS";
            // 
            // nudFontSize
            // 
            nudFontSize.Location = new System.Drawing.Point(180, 100);
            nudFontSize.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
            nudFontSize.Minimum = new decimal(new int[] { 8, 0, 0, 0 });
            nudFontSize.Name = "nudFontSize";
            nudFontSize.Size = new System.Drawing.Size(100, 23);
            nudFontSize.TabIndex = 3;
            nudFontSize.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // lblColorPreview
            // 
            lblColorPreview.AutoSize = true;
            lblColorPreview.Location = new System.Drawing.Point(240, 65);
            lblColorPreview.Name = "lblColorPreview";
            lblColorPreview.Size = new System.Drawing.Size(52, 15);
            lblColorPreview.TabIndex = 2;
            lblColorPreview.Text = "#3498db";
            // 
            // pnlColorPicker
            // 
            pnlColorPicker.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            pnlColorPicker.BorderStyle = BorderStyle.FixedSingle;
            pnlColorPicker.Cursor = Cursors.Hand;
            pnlColorPicker.Location = new System.Drawing.Point(180, 60);
            pnlColorPicker.Name = "pnlColorPicker";
            pnlColorPicker.Size = new System.Drawing.Size(50, 30);
            pnlColorPicker.TabIndex = 1;
            // 
            // cmbTheme
            // 
            cmbTheme.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTheme.FormattingEnabled = true;
            cmbTheme.Items.AddRange(new object[] { "Modern", "Classic", "Dark", "Light" });
            cmbTheme.Location = new System.Drawing.Point(180, 20);
            cmbTheme.Name = "cmbTheme";
            cmbTheme.Size = new System.Drawing.Size(200, 23);
            cmbTheme.TabIndex = 0;
            // 
            // tabPOS
            // 
            tabPOS.Controls.Add(chkAutomaticReceipt);
            tabPOS.Controls.Add(chkReceiptPrinting);
            tabPOS.Location = new System.Drawing.Point(4, 24);
            tabPOS.Name = "tabPOS";
            tabPOS.Size = new System.Drawing.Size(792, 552);
            tabPOS.TabIndex = 2;
            tabPOS.Text = "\U0001f6d2 POS";
            tabPOS.UseVisualStyleBackColor = true;
            // 
            // chkAutomaticReceipt
            // 
            chkAutomaticReceipt.AutoSize = true;
            chkAutomaticReceipt.Checked = true;
            chkAutomaticReceipt.CheckState = CheckState.Checked;
            chkAutomaticReceipt.Location = new System.Drawing.Point(20, 60);
            chkAutomaticReceipt.Name = "chkAutomaticReceipt";
            chkAutomaticReceipt.Size = new System.Drawing.Size(134, 19);
            chkAutomaticReceipt.TabIndex = 1;
            chkAutomaticReceipt.Text = "Avtomatik qəbz çapı";
            chkAutomaticReceipt.UseVisualStyleBackColor = true;
            // 
            // chkReceiptPrinting
            // 
            chkReceiptPrinting.AutoSize = true;
            chkReceiptPrinting.Checked = true;
            chkReceiptPrinting.CheckState = CheckState.Checked;
            chkReceiptPrinting.Location = new System.Drawing.Point(20, 20);
            chkReceiptPrinting.Name = "chkReceiptPrinting";
            chkReceiptPrinting.Size = new System.Drawing.Size(129, 19);
            chkReceiptPrinting.TabIndex = 0;
            chkReceiptPrinting.Text = "Qəbz çapını aktiv et";
            chkReceiptPrinting.UseVisualStyleBackColor = true;
            // 
            // tabBusiness
            // 
            tabBusiness.Controls.Add(txtEmailAddress);
            tabBusiness.Controls.Add(txtPhoneNumber);
            tabBusiness.Controls.Add(txtVATNumber);
            tabBusiness.Controls.Add(nudVATRate);
            tabBusiness.Location = new System.Drawing.Point(4, 24);
            tabBusiness.Name = "tabBusiness";
            tabBusiness.Size = new System.Drawing.Size(792, 552);
            tabBusiness.TabIndex = 3;
            tabBusiness.Text = "🏢 Biznes";
            tabBusiness.UseVisualStyleBackColor = true;
            // 
            // txtEmailAddress
            // 
            txtEmailAddress.Location = new System.Drawing.Point(180, 140);
            txtEmailAddress.Name = "txtEmailAddress";
            txtEmailAddress.Size = new System.Drawing.Size(250, 23);
            txtEmailAddress.TabIndex = 3;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new System.Drawing.Point(180, 100);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new System.Drawing.Size(200, 23);
            txtPhoneNumber.TabIndex = 2;
            // 
            // txtVATNumber
            // 
            txtVATNumber.Location = new System.Drawing.Point(180, 60);
            txtVATNumber.Name = "txtVATNumber";
            txtVATNumber.Size = new System.Drawing.Size(200, 23);
            txtVATNumber.TabIndex = 1;
            // 
            // nudVATRate
            // 
            nudVATRate.DecimalPlaces = 2;
            nudVATRate.Location = new System.Drawing.Point(180, 20);
            nudVATRate.Name = "nudVATRate";
            nudVATRate.Size = new System.Drawing.Size(100, 23);
            nudVATRate.TabIndex = 0;
            nudVATRate.Value = new decimal(new int[] { 18, 0, 0, 0 });
            // 
            // tabSecurity
            // 
            tabSecurity.Controls.Add(nudLockoutDuration);
            tabSecurity.Controls.Add(nudMaxLoginAttempts);
            tabSecurity.Location = new System.Drawing.Point(4, 24);
            tabSecurity.Name = "tabSecurity";
            tabSecurity.Size = new System.Drawing.Size(792, 552);
            tabSecurity.TabIndex = 4;
            tabSecurity.Text = "🔒 Təhlükəsizlik";
            tabSecurity.UseVisualStyleBackColor = true;
            // 
            // nudLockoutDuration
            // 
            nudLockoutDuration.Location = new System.Drawing.Point(180, 60);
            nudLockoutDuration.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            nudLockoutDuration.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudLockoutDuration.Name = "nudLockoutDuration";
            nudLockoutDuration.Size = new System.Drawing.Size(100, 23);
            nudLockoutDuration.TabIndex = 1;
            nudLockoutDuration.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // nudMaxLoginAttempts
            // 
            nudMaxLoginAttempts.Location = new System.Drawing.Point(180, 20);
            nudMaxLoginAttempts.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudMaxLoginAttempts.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudMaxLoginAttempts.Name = "nudMaxLoginAttempts";
            nudMaxLoginAttempts.Size = new System.Drawing.Size(100, 23);
            nudMaxLoginAttempts.TabIndex = 0;
            nudMaxLoginAttempts.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // tabNotifications
            // 
            tabNotifications.Controls.Add(chkEmailNotifications);
            tabNotifications.Controls.Add(chkSMSNotifications);
            tabNotifications.Controls.Add(nudStockAlertLevel);
            tabNotifications.Location = new System.Drawing.Point(4, 24);
            tabNotifications.Name = "tabNotifications";
            tabNotifications.Size = new System.Drawing.Size(792, 552);
            tabNotifications.TabIndex = 5;
            tabNotifications.Text = "🔔 Bildirişlər";
            tabNotifications.UseVisualStyleBackColor = true;
            // 
            // chkEmailNotifications
            // 
            chkEmailNotifications.AutoSize = true;
            chkEmailNotifications.Location = new System.Drawing.Point(20, 100);
            chkEmailNotifications.Name = "chkEmailNotifications";
            chkEmailNotifications.Size = new System.Drawing.Size(150, 19);
            chkEmailNotifications.TabIndex = 2;
            chkEmailNotifications.Text = "Email bildirişləri aktiv et";
            chkEmailNotifications.UseVisualStyleBackColor = true;
            // 
            // chkSMSNotifications
            // 
            chkSMSNotifications.AutoSize = true;
            chkSMSNotifications.Location = new System.Drawing.Point(20, 60);
            chkSMSNotifications.Name = "chkSMSNotifications";
            chkSMSNotifications.Size = new System.Drawing.Size(144, 19);
            chkSMSNotifications.TabIndex = 1;
            chkSMSNotifications.Text = "SMS bildirişləri aktiv et";
            chkSMSNotifications.UseVisualStyleBackColor = true;
            // 
            // nudStockAlertLevel
            // 
            nudStockAlertLevel.Location = new System.Drawing.Point(180, 20);
            nudStockAlertLevel.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudStockAlertLevel.Name = "nudStockAlertLevel";
            nudStockAlertLevel.Size = new System.Drawing.Size(100, 23);
            nudStockAlertLevel.TabIndex = 0;
            nudStockAlertLevel.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // SistemAyarlariForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 700);
            Controls.Add(tabMain);
            Controls.Add(pnlButtons);
            Controls.Add(pnlHeader);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SistemAyarlariForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Sistem Ayarları";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlButtons.ResumeLayout(false);
            tabRegional.ResumeLayout(false);
            tabRegional.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudDecimalPlaces).EndInit();
            tabAppearance.ResumeLayout(false);
            tabAppearance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudFontSize).EndInit();
            tabPOS.ResumeLayout(false);
            tabPOS.PerformLayout();
            tabBusiness.ResumeLayout(false);
            tabBusiness.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudVATRate).EndInit();
            tabSecurity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudLockoutDuration).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMaxLoginAttempts).EndInit();
            tabNotifications.ResumeLayout(false);
            tabNotifications.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudStockAlertLevel).EndInit();
            ResumeLayout(false);

        }

        #endregion
    }
}