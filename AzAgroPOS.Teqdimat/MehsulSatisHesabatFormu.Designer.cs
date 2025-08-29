// Fayl: AzAgroPOS.Teqdimat/MehsulSatisHesabatFormu.Designer.cs
namespace AzAgroPOS.Teqdimat
{
    partial class MehsulSatisHesabatFormu
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            dtpBaslangic = new DateTimePicker();
            dtpBitis = new DateTimePicker();
            btnGoster = new MaterialSkin.Controls.MaterialButton();
            dgvHesabat = new DataGridView();
            lblMesaj = new MaterialSkin.Controls.MaterialLabel();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)dgvHesabat).BeginInit();
            SuspendLayout();
            // 
            // dtpBaslangic
            // 
            dtpBaslangic.BackColor = Color.FromArgb(242, 242, 242);
            dtpBaslangic.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dtpBaslangic.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dtpBaslangic.Location = new Point(32, 107);
            dtpBaslangic.Name = "dtpBaslangic";
            dtpBaslangic.Size = new Size(280, 24);
            dtpBaslangic.TabIndex = 0;
            // 
            // dtpBitis
            // 
            dtpBitis.BackColor = Color.FromArgb(242, 242, 242);
            dtpBitis.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dtpBitis.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dtpBitis.Location = new Point(342, 107);
            dtpBitis.Name = "dtpBitis";
            dtpBitis.Size = new Size(280, 24);
            dtpBitis.TabIndex = 1;
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
            btnGoster.Location = new Point(646, 103);
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
            dgvHesabat.Location = new Point(32, 160);
            dgvHesabat.Name = "dgvHesabat";
            dgvHesabat.ReadOnly = true;
            dgvHesabat.Size = new Size(1120, 560);
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
            lblMesaj.Location = new Point(32, 160);
            lblMesaj.MouseState = MaterialSkin.MouseState.HOVER;
            lblMesaj.Name = "lblMesaj";
            lblMesaj.Size = new Size(1120, 560);
            lblMesaj.TabIndex = 4;
            lblMesaj.Text = "Mesaj";
            lblMesaj.TextAlign = ContentAlignment.MiddleCenter;
            lblMesaj.Visible = false;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.BackColor = Color.FromArgb(242, 242, 242);
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            materialLabel1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel1.Location = new Point(32, 85);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(99, 17);
            materialLabel1.TabIndex = 5;
            materialLabel1.Text = "Başlanğıc Tarixi";
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.BackColor = Color.FromArgb(242, 242, 242);
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            materialLabel2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel2.Location = new Point(342, 85);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(65, 17);
            materialLabel2.TabIndex = 6;
            materialLabel2.Text = "Bitiş Tarixi";
            // 
            // MehsulSatisHesabatFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 749);
            Controls.Add(materialLabel2);
            Controls.Add(materialLabel1);
            Controls.Add(lblMesaj);
            Controls.Add(dgvHesabat);
            Controls.Add(btnGoster);
            Controls.Add(dtpBitis);
            Controls.Add(dtpBaslangic);
            Name = "MehsulSatisHesabatFormu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Məhsul üzrə Satış Hesabatı";
            ((System.ComponentModel.ISupportInitialize)dgvHesabat).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
        private DateTimePicker dtpBaslangic;
        private DateTimePicker dtpBitis;
        private MaterialSkin.Controls.MaterialButton btnGoster;
        private DataGridView dgvHesabat;
        private MaterialSkin.Controls.MaterialLabel lblMesaj;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
    }
}