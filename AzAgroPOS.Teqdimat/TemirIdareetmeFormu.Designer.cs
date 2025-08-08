// Fayl: AzAgroPOS.Teqdimat/TemirIdareetmeFormu.Designer.cs
namespace AzAgroPOS.Teqdimat
{
    partial class TemirIdareetmeFormu
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            dgvTemirSifarisleri = new DataGridView();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            btnYeniSifaris = new MaterialSkin.Controls.MaterialButton();
            txtYekunMebleg = new MaterialSkin.Controls.MaterialTextBox2();
            txtProblemTesviri = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            txtCihazAdi = new MaterialSkin.Controls.MaterialTextBox2();
            txtMusteriTelefonu = new MaterialSkin.Controls.MaterialTextBox2();
            txtMusteriAdi = new MaterialSkin.Controls.MaterialTextBox2();
            ((System.ComponentModel.ISupportInitialize)dgvTemirSifarisleri).BeginInit();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvTemirSifarisleri
            // 
            dgvTemirSifarisleri.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTemirSifarisleri.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTemirSifarisleri.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTemirSifarisleri.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvTemirSifarisleri.Location = new Point(6, 275);
            dgvTemirSifarisleri.Name = "dgvTemirSifarisleri";
            dgvTemirSifarisleri.ReadOnly = true;
            dgvTemirSifarisleri.Size = new Size(1172, 359);
            dgvTemirSifarisleri.TabIndex = 0;
            // 
            // materialCard1
            // 
            materialCard1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(btnYeniSifaris);
            materialCard1.Controls.Add(txtYekunMebleg);
            materialCard1.Controls.Add(txtProblemTesviri);
            materialCard1.Controls.Add(txtCihazAdi);
            materialCard1.Controls.Add(txtMusteriTelefonu);
            materialCard1.Controls.Add(txtMusteriAdi);
            materialCard1.Depth = 0;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(6, 67);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(1172, 202);
            materialCard1.TabIndex = 1;
            // 
            // btnYeniSifaris
            // 
            btnYeniSifaris.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnYeniSifaris.BackColor = Color.FromArgb(242, 242, 242);
            btnYeniSifaris.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnYeniSifaris.Depth = 0;
            btnYeniSifaris.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnYeniSifaris.HighEmphasis = true;
            btnYeniSifaris.Icon = null;
            btnYeniSifaris.Location = new Point(994, 145);
            btnYeniSifaris.Margin = new Padding(4, 6, 4, 6);
            btnYeniSifaris.MouseState = MaterialSkin.MouseState.HOVER;
            btnYeniSifaris.Name = "btnYeniSifaris";
            btnYeniSifaris.NoAccentTextColor = Color.Empty;
            btnYeniSifaris.Size = new Size(160, 36);
            btnYeniSifaris.TabIndex = 5;
            btnYeniSifaris.Text = "Yeni Sifariş Yarat";
            btnYeniSifaris.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnYeniSifaris.UseAccentColor = false;
            btnYeniSifaris.UseVisualStyleBackColor = false;
            btnYeniSifaris.Click += btnYeniSifaris_Click;
            // 
            // txtYekunMebleg
            // 
            txtYekunMebleg.AnimateReadOnly = false;
            txtYekunMebleg.BackColor = Color.FromArgb(255, 255, 255);
            txtYekunMebleg.BackgroundImageLayout = ImageLayout.None;
            txtYekunMebleg.CharacterCasing = CharacterCasing.Normal;
            txtYekunMebleg.Depth = 0;
            txtYekunMebleg.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtYekunMebleg.HideSelection = true;
            txtYekunMebleg.Hint = "Yekun Məbləğ";
            txtYekunMebleg.LeadingIcon = null;
            txtYekunMebleg.Location = new Point(905, 79);
            txtYekunMebleg.MaxLength = 32767;
            txtYekunMebleg.MouseState = MaterialSkin.MouseState.OUT;
            txtYekunMebleg.Name = "txtYekunMebleg";
            txtYekunMebleg.PasswordChar = '\0';
            txtYekunMebleg.PrefixSuffixText = null;
            txtYekunMebleg.ReadOnly = false;
            txtYekunMebleg.RightToLeft = RightToLeft.No;
            txtYekunMebleg.SelectedText = "";
            txtYekunMebleg.SelectionLength = 0;
            txtYekunMebleg.SelectionStart = 0;
            txtYekunMebleg.ShortcutsEnabled = true;
            txtYekunMebleg.Size = new Size(250, 48);
            txtYekunMebleg.TabIndex = 4;
            txtYekunMebleg.TabStop = false;
            txtYekunMebleg.TextAlign = HorizontalAlignment.Left;
            txtYekunMebleg.TrailingIcon = null;
            txtYekunMebleg.UseSystemPasswordChar = false;
            // 
            // txtProblemTesviri
            // 
            txtProblemTesviri.AnimateReadOnly = false;
            txtProblemTesviri.BackColor = Color.FromArgb(255, 255, 255);
            txtProblemTesviri.BackgroundImageLayout = ImageLayout.None;
            txtProblemTesviri.CharacterCasing = CharacterCasing.Normal;
            txtProblemTesviri.Depth = 0;
            txtProblemTesviri.HideSelection = true;
            txtProblemTesviri.Hint = "Problemin Təsviri";
            txtProblemTesviri.Location = new Point(475, 17);
            txtProblemTesviri.MaxLength = 32767;
            txtProblemTesviri.MouseState = MaterialSkin.MouseState.OUT;
            txtProblemTesviri.Name = "txtProblemTesviri";
            txtProblemTesviri.PasswordChar = '\0';
            txtProblemTesviri.ReadOnly = false;
            txtProblemTesviri.ScrollBars = ScrollBars.None;
            txtProblemTesviri.SelectedText = "";
            txtProblemTesviri.SelectionLength = 0;
            txtProblemTesviri.SelectionStart = 0;
            txtProblemTesviri.ShortcutsEnabled = true;
            txtProblemTesviri.Size = new Size(411, 164);
            txtProblemTesviri.TabIndex = 3;
            txtProblemTesviri.TabStop = false;
            txtProblemTesviri.TextAlign = HorizontalAlignment.Left;
            txtProblemTesviri.UseSystemPasswordChar = false;
            // 
            // txtCihazAdi
            // 
            txtCihazAdi.AnimateReadOnly = false;
            txtCihazAdi.BackColor = Color.FromArgb(255, 255, 255);
            txtCihazAdi.BackgroundImageLayout = ImageLayout.None;
            txtCihazAdi.CharacterCasing = CharacterCasing.Normal;
            txtCihazAdi.Depth = 0;
            txtCihazAdi.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtCihazAdi.HideSelection = true;
            txtCihazAdi.Hint = "Cihaz Adı (məs: iPhone 13)";
            txtCihazAdi.LeadingIcon = null;
            txtCihazAdi.Location = new Point(17, 133);
            txtCihazAdi.MaxLength = 32767;
            txtCihazAdi.MouseState = MaterialSkin.MouseState.OUT;
            txtCihazAdi.Name = "txtCihazAdi";
            txtCihazAdi.PasswordChar = '\0';
            txtCihazAdi.PrefixSuffixText = null;
            txtCihazAdi.ReadOnly = false;
            txtCihazAdi.RightToLeft = RightToLeft.No;
            txtCihazAdi.SelectedText = "";
            txtCihazAdi.SelectionLength = 0;
            txtCihazAdi.SelectionStart = 0;
            txtCihazAdi.ShortcutsEnabled = true;
            txtCihazAdi.Size = new Size(433, 48);
            txtCihazAdi.TabIndex = 2;
            txtCihazAdi.TabStop = false;
            txtCihazAdi.TextAlign = HorizontalAlignment.Left;
            txtCihazAdi.TrailingIcon = null;
            txtCihazAdi.UseSystemPasswordChar = false;
            // 
            // txtMusteriTelefonu
            // 
            txtMusteriTelefonu.AnimateReadOnly = false;
            txtMusteriTelefonu.BackColor = Color.FromArgb(255, 255, 255);
            txtMusteriTelefonu.BackgroundImageLayout = ImageLayout.None;
            txtMusteriTelefonu.CharacterCasing = CharacterCasing.Normal;
            txtMusteriTelefonu.Depth = 0;
            txtMusteriTelefonu.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtMusteriTelefonu.HideSelection = true;
            txtMusteriTelefonu.Hint = "Müştəri Telefonu";
            txtMusteriTelefonu.LeadingIcon = null;
            txtMusteriTelefonu.Location = new Point(17, 75);
            txtMusteriTelefonu.MaxLength = 32767;
            txtMusteriTelefonu.MouseState = MaterialSkin.MouseState.OUT;
            txtMusteriTelefonu.Name = "txtMusteriTelefonu";
            txtMusteriTelefonu.PasswordChar = '\0';
            txtMusteriTelefonu.PrefixSuffixText = null;
            txtMusteriTelefonu.ReadOnly = false;
            txtMusteriTelefonu.RightToLeft = RightToLeft.No;
            txtMusteriTelefonu.SelectedText = "";
            txtMusteriTelefonu.SelectionLength = 0;
            txtMusteriTelefonu.SelectionStart = 0;
            txtMusteriTelefonu.ShortcutsEnabled = true;
            txtMusteriTelefonu.Size = new Size(433, 48);
            txtMusteriTelefonu.TabIndex = 1;
            txtMusteriTelefonu.TabStop = false;
            txtMusteriTelefonu.TextAlign = HorizontalAlignment.Left;
            txtMusteriTelefonu.TrailingIcon = null;
            txtMusteriTelefonu.UseSystemPasswordChar = false;
            // 
            // txtMusteriAdi
            // 
            txtMusteriAdi.AnimateReadOnly = false;
            txtMusteriAdi.BackColor = Color.FromArgb(255, 255, 255);
            txtMusteriAdi.BackgroundImageLayout = ImageLayout.None;
            txtMusteriAdi.CharacterCasing = CharacterCasing.Normal;
            txtMusteriAdi.Depth = 0;
            txtMusteriAdi.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtMusteriAdi.HideSelection = true;
            txtMusteriAdi.Hint = "Müştəri Adı, Soyadı";
            txtMusteriAdi.LeadingIcon = null;
            txtMusteriAdi.Location = new Point(17, 17);
            txtMusteriAdi.MaxLength = 32767;
            txtMusteriAdi.MouseState = MaterialSkin.MouseState.OUT;
            txtMusteriAdi.Name = "txtMusteriAdi";
            txtMusteriAdi.PasswordChar = '\0';
            txtMusteriAdi.PrefixSuffixText = null;
            txtMusteriAdi.ReadOnly = false;
            txtMusteriAdi.RightToLeft = RightToLeft.No;
            txtMusteriAdi.SelectedText = "";
            txtMusteriAdi.SelectionLength = 0;
            txtMusteriAdi.SelectionStart = 0;
            txtMusteriAdi.ShortcutsEnabled = true;
            txtMusteriAdi.Size = new Size(433, 48);
            txtMusteriAdi.TabIndex = 0;
            txtMusteriAdi.TabStop = false;
            txtMusteriAdi.TextAlign = HorizontalAlignment.Left;
            txtMusteriAdi.TrailingIcon = null;
            txtMusteriAdi.UseSystemPasswordChar = false;
            // 
            // TemirIdareetmeFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            ClientSize = new Size(1184, 640);
            Controls.Add(materialCard1);
            Controls.Add(dgvTemirSifarisleri);
            Name = "TemirIdareetmeFormu";
            Text = "Təmir Sifarişlərinin İdarə Edilməsi";
            Load += TemirIdareetmeFormu_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTemirSifarisleri).EndInit();
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.DataGridView dgvTemirSifarisleri;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialButton btnYeniSifaris;
        private MaterialSkin.Controls.MaterialTextBox2 txtYekunMebleg;
        // DƏYİŞİKLİK BURADA BİTİR: Dəyişən tipi də dəyişir
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 txtProblemTesviri;
        private MaterialSkin.Controls.MaterialTextBox2 txtCihazAdi;
        private MaterialSkin.Controls.MaterialTextBox2 txtMusteriTelefonu;
        private MaterialSkin.Controls.MaterialTextBox2 txtMusteriAdi;
    }
}