// Fayl: AzAgroPOS.Teqdimat/AnbarQaliqHesabatFormu.Designer.cs
namespace AzAgroPOS.Teqdimat
{
    partial class AnbarQaliqHesabatFormu
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            btnGoster = new MaterialSkin.Controls.MaterialButton();
            dgvHesabat = new DataGridView();
            lblMesaj = new MaterialSkin.Controls.MaterialLabel();
            txtLimit = new MaterialSkin.Controls.MaterialTextBox2();
            ((System.ComponentModel.ISupportInitialize)dgvHesabat).BeginInit();
            SuspendLayout();
            // 
            // btnGoster
            // 
            btnGoster.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnGoster.BackColor = Color.FromArgb(242, 242, 242);
            btnGoster.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnGoster.Depth = 0;
            btnGoster.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnGoster.HighEmphasis = true;
            btnGoster.Icon = null;
            btnGoster.Location = new Point(349, 90);
            btnGoster.Margin = new Padding(4, 6, 4, 6);
            btnGoster.MouseState = MaterialSkin.MouseState.HOVER;
            btnGoster.Name = "btnGoster";
            btnGoster.NoAccentTextColor = Color.Empty;
            btnGoster.Size = new Size(79, 36);
            btnGoster.TabIndex = 2;
            btnGoster.Text = "Göstər";
            btnGoster.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnGoster.UseAccentColor = false;
            btnGoster.UseVisualStyleBackColor = false;
            btnGoster.Click += btnGoster_Click;
            // 
            // dgvHesabat
            // 
            dgvHesabat.AllowUserToAddRows = false;
            dgvHesabat.AllowUserToDeleteRows = false;
            dgvHesabat.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHesabat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHesabat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHesabat.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvHesabat.Location = new Point(32, 148);
            dgvHesabat.Name = "dgvHesabat";
            dgvHesabat.ReadOnly = true;
            dgvHesabat.Size = new Size(1120, 579);
            dgvHesabat.TabIndex = 3;
            // 
            // lblMesaj
            // 
            lblMesaj.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblMesaj.BackColor = Color.FromArgb(242, 242, 242);
            lblMesaj.Depth = 0;
            lblMesaj.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblMesaj.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            lblMesaj.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblMesaj.Location = new Point(32, 148);
            lblMesaj.MouseState = MaterialSkin.MouseState.HOVER;
            lblMesaj.Name = "lblMesaj";
            lblMesaj.Size = new Size(1120, 579);
            lblMesaj.TabIndex = 4;
            lblMesaj.Text = "Mesaj";
            lblMesaj.TextAlign = ContentAlignment.MiddleCenter;
            lblMesaj.Visible = false;
            // 
            // txtLimit
            // 
            txtLimit.AnimateReadOnly = false;
            txtLimit.BackColor = Color.FromArgb(242, 242, 242);
            txtLimit.BackgroundImageLayout = ImageLayout.None;
            txtLimit.CharacterCasing = CharacterCasing.Normal;
            txtLimit.Depth = 0;
            txtLimit.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtLimit.HideSelection = true;
            txtLimit.Hint = "Limit Say";
            txtLimit.LeadingIcon = null;
            txtLimit.Location = new Point(32, 84);
            txtLimit.MaxLength = 32767;
            txtLimit.MouseState = MaterialSkin.MouseState.OUT;
            txtLimit.Name = "txtLimit";
            txtLimit.PasswordChar = '\0';
            txtLimit.PrefixSuffixText = null;
            txtLimit.ReadOnly = false;
            txtLimit.RightToLeft = RightToLeft.No;
            txtLimit.SelectedText = "";
            txtLimit.SelectionLength = 0;
            txtLimit.SelectionStart = 0;
            txtLimit.ShortcutsEnabled = true;
            txtLimit.Size = new Size(295, 48);
            txtLimit.TabIndex = 5;
            txtLimit.TabStop = false;
            txtLimit.Text = "10";
            txtLimit.TextAlign = HorizontalAlignment.Left;
            txtLimit.TrailingIcon = null;
            txtLimit.UseSystemPasswordChar = false;
            // 
            // AnbarQaliqHesabatFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 749);
            Controls.Add(txtLimit);
            Controls.Add(lblMesaj);
            Controls.Add(dgvHesabat);
            Controls.Add(btnGoster);
            Name = "AnbarQaliqHesabatFormu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Anbar Qalığı Hesabatı";
            ((System.ComponentModel.ISupportInitialize)dgvHesabat).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
        private MaterialSkin.Controls.MaterialButton btnGoster;
        private DataGridView dgvHesabat;
        private MaterialSkin.Controls.MaterialLabel lblMesaj;
        private MaterialSkin.Controls.MaterialTextBox2 txtLimit;
    }
}