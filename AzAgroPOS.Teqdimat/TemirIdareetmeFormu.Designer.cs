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
            this.dgvTemirSifarisleri = new System.Windows.Forms.DataGridView();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.btnYeniSifaris = new MaterialSkin.Controls.MaterialButton();
            this.txtYekunMebleg = new MaterialSkin.Controls.MaterialTextBox2();
            // DƏYİŞİKLİK BURADA BAŞLAYIR: MaterialMultiLineTextBox2 istifadə edirik
            this.txtProblemTesviri = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.txtCihazAdi = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtMusteriTelefonu = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtMusteriAdi = new MaterialSkin.Controls.MaterialTextBox2();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTemirSifarisleri)).BeginInit();
            this.materialCard1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTemirSifarisleri
            // 
            this.dgvTemirSifarisleri.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTemirSifarisleri.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTemirSifarisleri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTemirSifarisleri.Location = new System.Drawing.Point(6, 275);
            this.dgvTemirSifarisleri.Name = "dgvTemirSifarisleri";
            this.dgvTemirSifarisleri.ReadOnly = true;
            this.dgvTemirSifarisleri.Size = new System.Drawing.Size(1172, 359);
            this.dgvTemirSifarisleri.TabIndex = 0;
            // 
            // materialCard1
            // 
            this.materialCard1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.btnYeniSifaris);
            this.materialCard1.Controls.Add(this.txtYekunMebleg);
            this.materialCard1.Controls.Add(this.txtProblemTesviri);
            this.materialCard1.Controls.Add(this.txtCihazAdi);
            this.materialCard1.Controls.Add(this.txtMusteriTelefonu);
            this.materialCard1.Controls.Add(this.txtMusteriAdi);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(6, 67);
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(1172, 202);
            this.materialCard1.TabIndex = 1;
            // 
            // btnYeniSifaris
            // 
            this.btnYeniSifaris.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnYeniSifaris.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnYeniSifaris.Depth = 0;
            this.btnYeniSifaris.HighEmphasis = true;
            this.btnYeniSifaris.Icon = null;
            this.btnYeniSifaris.Location = new System.Drawing.Point(994, 145);
            this.btnYeniSifaris.Name = "btnYeniSifaris";
            this.btnYeniSifaris.Size = new System.Drawing.Size(161, 36);
            this.btnYeniSifaris.TabIndex = 5;
            this.btnYeniSifaris.Text = "Yeni Sifariş Yarat";
            this.btnYeniSifaris.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnYeniSifaris.Click += new System.EventHandler(this.btnYeniSifaris_Click);
            // 
            // txtYekunMebleg
            // 
            this.txtYekunMebleg.AnimateReadOnly = false;
            this.txtYekunMebleg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtYekunMebleg.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtYekunMebleg.Depth = 0;
            this.txtYekunMebleg.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtYekunMebleg.HideSelection = true;
            this.txtYekunMebleg.Hint = "Yekun Məbləğ";
            this.txtYekunMebleg.LeadingIcon = null;
            this.txtYekunMebleg.Location = new System.Drawing.Point(905, 79);
            this.txtYekunMebleg.Name = "txtYekunMebleg";
            this.txtYekunMebleg.PasswordChar = '\0';
            this.txtYekunMebleg.PrefixSuffixText = null;
            this.txtYekunMebleg.ReadOnly = false;
            this.txtYekunMebleg.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtYekunMebleg.SelectedText = "";
            this.txtYekunMebleg.SelectionLength = 0;
            this.txtYekunMebleg.SelectionStart = 0;
            this.txtYekunMebleg.ShortcutsEnabled = true;
            this.txtYekunMebleg.Size = new System.Drawing.Size(250, 48);
            this.txtYekunMebleg.TabIndex = 4;
            this.txtYekunMebleg.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtYekunMebleg.UseSystemPasswordChar = false;
            // 
            // txtProblemTesviri
            // 
            this.txtProblemTesviri.AnimateReadOnly = false;
            this.txtProblemTesviri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtProblemTesviri.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtProblemTesviri.Depth = 0;
            this.txtProblemTesviri.HideSelection = true;
            this.txtProblemTesviri.Hint = "Problemin Təsviri";
            this.txtProblemTesviri.Location = new System.Drawing.Point(475, 17);
            this.txtProblemTesviri.MaxLength = 32767;
            this.txtProblemTesviri.MouseState = MaterialSkin.MouseState.OUT;
            this.txtProblemTesviri.Name = "txtProblemTesviri";
            this.txtProblemTesviri.PasswordChar = '\0';
            this.txtProblemTesviri.ReadOnly = false;
            this.txtProblemTesviri.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtProblemTesviri.SelectedText = "";
            this.txtProblemTesviri.SelectionLength = 0;
            this.txtProblemTesviri.SelectionStart = 0;
            this.txtProblemTesviri.ShortcutsEnabled = true;
            this.txtProblemTesviri.Size = new System.Drawing.Size(411, 164);
            this.txtProblemTesviri.TabIndex = 3;
            this.txtProblemTesviri.TabStop = false;
            this.txtProblemTesviri.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtProblemTesviri.UseSystemPasswordChar = false;
            // 
            // txtCihazAdi
            // 
            this.txtCihazAdi.AnimateReadOnly = false;
            this.txtCihazAdi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtCihazAdi.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCihazAdi.Depth = 0;
            this.txtCihazAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtCihazAdi.HideSelection = true;
            this.txtCihazAdi.Hint = "Cihaz Adı (məs: iPhone 13)";
            this.txtCihazAdi.LeadingIcon = null;
            this.txtCihazAdi.Location = new System.Drawing.Point(17, 133);
            this.txtCihazAdi.Name = "txtCihazAdi";
            this.txtCihazAdi.PasswordChar = '\0';
            this.txtCihazAdi.PrefixSuffixText = null;
            this.txtCihazAdi.ReadOnly = false;
            this.txtCihazAdi.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCihazAdi.SelectedText = "";
            this.txtCihazAdi.SelectionLength = 0;
            this.txtCihazAdi.SelectionStart = 0;
            this.txtCihazAdi.ShortcutsEnabled = true;
            this.txtCihazAdi.Size = new System.Drawing.Size(433, 48);
            this.txtCihazAdi.TabIndex = 2;
            this.txtCihazAdi.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCihazAdi.UseSystemPasswordChar = false;
            // 
            // txtMusteriTelefonu
            // 
            this.txtMusteriTelefonu.AnimateReadOnly = false;
            this.txtMusteriTelefonu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtMusteriTelefonu.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMusteriTelefonu.Depth = 0;
            this.txtMusteriTelefonu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtMusteriTelefonu.HideSelection = true;
            this.txtMusteriTelefonu.Hint = "Müştəri Telefonu";
            this.txtMusteriTelefonu.LeadingIcon = null;
            this.txtMusteriTelefonu.Location = new System.Drawing.Point(17, 75);
            this.txtMusteriTelefonu.Name = "txtMusteriTelefonu";
            this.txtMusteriTelefonu.PasswordChar = '\0';
            this.txtMusteriTelefonu.PrefixSuffixText = null;
            this.txtMusteriTelefonu.ReadOnly = false;
            this.txtMusteriTelefonu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMusteriTelefonu.SelectedText = "";
            this.txtMusteriTelefonu.SelectionLength = 0;
            this.txtMusteriTelefonu.SelectionStart = 0;
            this.txtMusteriTelefonu.ShortcutsEnabled = true;
            this.txtMusteriTelefonu.Size = new System.Drawing.Size(433, 48);
            this.txtMusteriTelefonu.TabIndex = 1;
            this.txtMusteriTelefonu.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtMusteriTelefonu.UseSystemPasswordChar = false;
            // 
            // txtMusteriAdi
            // 
            this.txtMusteriAdi.AnimateReadOnly = false;
            this.txtMusteriAdi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtMusteriAdi.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMusteriAdi.Depth = 0;
            this.txtMusteriAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtMusteriAdi.HideSelection = true;
            this.txtMusteriAdi.Hint = "Müştəri Adı, Soyadı";
            this.txtMusteriAdi.LeadingIcon = null;
            this.txtMusteriAdi.Location = new System.Drawing.Point(17, 17);
            this.txtMusteriAdi.Name = "txtMusteriAdi";
            this.txtMusteriAdi.PasswordChar = '\0';
            this.txtMusteriAdi.PrefixSuffixText = null;
            this.txtMusteriAdi.ReadOnly = false;
            this.txtMusteriAdi.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMusteriAdi.SelectedText = "";
            this.txtMusteriAdi.SelectionLength = 0;
            this.txtMusteriAdi.SelectionStart = 0;
            this.txtMusteriAdi.ShortcutsEnabled = true;
            this.txtMusteriAdi.Size = new System.Drawing.Size(433, 48);
            this.txtMusteriAdi.TabIndex = 0;
            this.txtMusteriAdi.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtMusteriAdi.UseSystemPasswordChar = false;
            // 
            // TemirIdareetmeFormu
            // 
            this.ClientSize = new System.Drawing.Size(1184, 640);
            this.Controls.Add(this.materialCard1);
            this.Controls.Add(this.dgvTemirSifarisleri);
            this.Name = "TemirIdareetmeFormu";
            this.Text = "Təmir Sifarişlərinin İdarə Edilməsi";
            this.Load += new System.EventHandler(this.TemirIdareetmeFormu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTemirSifarisleri)).EndInit();
            this.materialCard1.ResumeLayout(false);
            this.materialCard1.PerformLayout();
            this.ResumeLayout(false);

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