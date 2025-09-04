// Fayl: AzAgroPOS.Teqdimat/HesabatFormu.Designer.cs
namespace AzAgroPOS.Teqdimat
{
    partial class HesabatFormu
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            dtpTarix = new DateTimePicker();
            btnGoster = new MaterialSkin.Controls.MaterialButton();
            pnlNetice = new Panel();
            dgvSatislar = new DataGridView();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            lblNisye = new MaterialSkin.Controls.MaterialLabel();
            materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            lblKart = new MaterialSkin.Controls.MaterialLabel();
            materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            lblNagd = new MaterialSkin.Controls.MaterialLabel();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            lblSatisSayi = new MaterialSkin.Controls.MaterialLabel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            lblUmumiDovriyye = new MaterialSkin.Controls.MaterialLabel();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            lblMesaj = new MaterialSkin.Controls.MaterialLabel();
            pnlNetice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSatislar).BeginInit();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // dtpTarix
            // 
            dtpTarix.BackColor = Color.FromArgb(242, 242, 242);
            dtpTarix.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dtpTarix.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dtpTarix.Location = new Point(32, 85);
            dtpTarix.Name = "dtpTarix";
            dtpTarix.Size = new Size(300, 24);
            dtpTarix.TabIndex = 0;
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
            btnGoster.Location = new Point(352, 81);
            btnGoster.Margin = new Padding(4, 6, 4, 6);
            btnGoster.MouseState = MaterialSkin.MouseState.HOVER;
            btnGoster.Name = "btnGoster";
            btnGoster.NoAccentTextColor = Color.Empty;
            btnGoster.Size = new Size(79, 36);
            btnGoster.TabIndex = 1;
            btnGoster.Text = "Göstər";
            btnGoster.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnGoster.UseAccentColor = false;
            btnGoster.UseVisualStyleBackColor = false;
            btnGoster.Click += btnGoster_Click;
            // 
            // pnlNetice
            // 
            pnlNetice.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlNetice.BackColor = Color.FromArgb(242, 242, 242);
            pnlNetice.Controls.Add(dgvSatislar);
            pnlNetice.Controls.Add(materialCard1);
            pnlNetice.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlNetice.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlNetice.Location = new Point(32, 140);
            pnlNetice.Name = "pnlNetice";
            pnlNetice.Size = new Size(1120, 580);
            pnlNetice.TabIndex = 2;
            // 
            // dgvSatislar
            // 
            dgvSatislar.AllowUserToAddRows = false;
            dgvSatislar.AllowUserToDeleteRows = false;
            dgvSatislar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSatislar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvSatislar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvSatislar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvSatislar.DefaultCellStyle = dataGridViewCellStyle2;
            dgvSatislar.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvSatislar.Location = new Point(0, 150);
            dgvSatislar.Name = "dgvSatislar";
            dgvSatislar.ReadOnly = true;
            dgvSatislar.Size = new Size(1120, 430);
            dgvSatislar.TabIndex = 1;
            // 
            // materialCard1
            // 
            materialCard1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(lblNisye);
            materialCard1.Controls.Add(materialLabel8);
            materialCard1.Controls.Add(lblKart);
            materialCard1.Controls.Add(materialLabel6);
            materialCard1.Controls.Add(lblNagd);
            materialCard1.Controls.Add(materialLabel4);
            materialCard1.Controls.Add(lblSatisSayi);
            materialCard1.Controls.Add(materialLabel2);
            materialCard1.Controls.Add(lblUmumiDovriyye);
            materialCard1.Controls.Add(materialLabel1);
            materialCard1.Depth = 0;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(0, 3);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(1120, 129);
            materialCard1.TabIndex = 0;
            // 
            // lblNisye
            // 
            lblNisye.AutoSize = true;
            lblNisye.BackColor = Color.FromArgb(242, 242, 242);
            lblNisye.Depth = 0;
            lblNisye.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblNisye.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            lblNisye.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblNisye.Location = new Point(950, 60);
            lblNisye.MouseState = MaterialSkin.MouseState.HOVER;
            lblNisye.Name = "lblNisye";
            lblNisye.Size = new Size(67, 19);
            lblNisye.TabIndex = 9;
            lblNisye.Text = "0.00 AZN";
            // 
            // materialLabel8
            // 
            materialLabel8.AutoSize = true;
            materialLabel8.BackColor = Color.FromArgb(242, 242, 242);
            materialLabel8.Depth = 0;
            materialLabel8.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel8.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            materialLabel8.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel8.Location = new Point(830, 62);
            materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel8.Name = "materialLabel8";
            materialLabel8.Size = new Size(75, 17);
            materialLabel8.TabIndex = 8;
            materialLabel8.Text = "Nisyə Satış:";
            // 
            // lblKart
            // 
            lblKart.AutoSize = true;
            lblKart.BackColor = Color.FromArgb(242, 242, 242);
            lblKart.Depth = 0;
            lblKart.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblKart.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            lblKart.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblKart.Location = new Point(950, 24);
            lblKart.MouseState = MaterialSkin.MouseState.HOVER;
            lblKart.Name = "lblKart";
            lblKart.Size = new Size(67, 19);
            lblKart.TabIndex = 7;
            lblKart.Text = "0.00 AZN";
            // 
            // materialLabel6
            // 
            materialLabel6.AutoSize = true;
            materialLabel6.BackColor = Color.FromArgb(242, 242, 242);
            materialLabel6.Depth = 0;
            materialLabel6.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel6.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            materialLabel6.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel6.Location = new Point(830, 26);
            materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel6.Name = "materialLabel6";
            materialLabel6.Size = new Size(67, 17);
            materialLabel6.TabIndex = 6;
            materialLabel6.Text = "Kart Satış:";
            // 
            // lblNagd
            // 
            lblNagd.AutoSize = true;
            lblNagd.BackColor = Color.FromArgb(242, 242, 242);
            lblNagd.Depth = 0;
            lblNagd.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblNagd.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            lblNagd.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblNagd.Location = new Point(620, 24);
            lblNagd.MouseState = MaterialSkin.MouseState.HOVER;
            lblNagd.Name = "lblNagd";
            lblNagd.Size = new Size(67, 19);
            lblNagd.TabIndex = 5;
            lblNagd.Text = "0.00 AZN";
            // 
            // materialLabel4
            // 
            materialLabel4.AutoSize = true;
            materialLabel4.BackColor = Color.FromArgb(242, 242, 242);
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel4.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            materialLabel4.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel4.Location = new Point(500, 26);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(74, 17);
            materialLabel4.TabIndex = 4;
            materialLabel4.Text = "Nağd Satış:";
            // 
            // lblSatisSayi
            // 
            lblSatisSayi.AutoSize = true;
            lblSatisSayi.BackColor = Color.FromArgb(242, 242, 242);
            lblSatisSayi.Depth = 0;
            lblSatisSayi.Font = new Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblSatisSayi.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            lblSatisSayi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblSatisSayi.Location = new Point(220, 70);
            lblSatisSayi.MouseState = MaterialSkin.MouseState.HOVER;
            lblSatisSayi.Name = "lblSatisSayi";
            lblSatisSayi.Size = new Size(14, 29);
            lblSatisSayi.TabIndex = 3;
            lblSatisSayi.Text = "0";
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.BackColor = Color.FromArgb(242, 242, 242);
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            materialLabel2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel2.Location = new Point(20, 80);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(125, 17);
            materialLabel2.TabIndex = 2;
            materialLabel2.Text = "Cəmi Satışların Sayı:";
            // 
            // lblUmumiDovriyye
            // 
            lblUmumiDovriyye.AutoSize = true;
            lblUmumiDovriyye.BackColor = Color.FromArgb(242, 242, 242);
            lblUmumiDovriyye.Depth = 0;
            lblUmumiDovriyye.Font = new Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblUmumiDovriyye.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            lblUmumiDovriyye.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblUmumiDovriyye.Location = new Point(220, 14);
            lblUmumiDovriyye.MouseState = MaterialSkin.MouseState.HOVER;
            lblUmumiDovriyye.Name = "lblUmumiDovriyye";
            lblUmumiDovriyye.Size = new Size(141, 41);
            lblUmumiDovriyye.TabIndex = 1;
            lblUmumiDovriyye.Text = "0.00 AZN";
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.BackColor = Color.FromArgb(242, 242, 242);
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            materialLabel1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel1.Location = new Point(17, 24);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(181, 29);
            materialLabel1.TabIndex = 0;
            materialLabel1.Text = "Ümumi Dövriyyə:";
            // 
            // lblMesaj
            // 
            lblMesaj.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblMesaj.BackColor = Color.FromArgb(242, 242, 242);
            lblMesaj.Depth = 0;
            lblMesaj.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblMesaj.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            lblMesaj.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblMesaj.Location = new Point(32, 140);
            lblMesaj.MouseState = MaterialSkin.MouseState.HOVER;
            lblMesaj.Name = "lblMesaj";
            lblMesaj.Size = new Size(1120, 580);
            lblMesaj.TabIndex = 3;
            lblMesaj.Text = "Mesaj Mətni";
            lblMesaj.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // HesabatFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 749);
            Controls.Add(lblMesaj);
            Controls.Add(pnlNetice);
            Controls.Add(btnGoster);
            Controls.Add(dtpTarix);
            Name = "HesabatFormu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Günlük Satış Hesabatı";
            pnlNetice.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSatislar).EndInit();
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
        private DateTimePicker dtpTarix;
        private MaterialSkin.Controls.MaterialButton btnGoster;
        private Panel pnlNetice;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private DataGridView dgvSatislar;
        private MaterialSkin.Controls.MaterialLabel lblUmumiDovriyye;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel lblNisye;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private MaterialSkin.Controls.MaterialLabel lblKart;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialLabel lblNagd;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialLabel lblSatisSayi;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel lblMesaj;
    }
}