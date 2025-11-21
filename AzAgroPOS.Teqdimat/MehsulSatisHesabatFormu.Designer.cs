// Fayl: AzAgroPOS.Teqdimat/MehsulSatisHesabatFormu.Designer.cs
namespace AzAgroPOS.Teqdimat
{
    partial class MehsulSatisHesabatFormu
    {
        private System.ComponentModel.IContainer components = null;

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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pnlFiltr = new Panel();
            lblBaslangicTarix = new MaterialSkin.Controls.MaterialLabel();
            dtpBaslangic = new DateTimePicker();
            lblBitisTarix = new MaterialSkin.Controls.MaterialLabel();
            dtpBitis = new DateTimePicker();
            btnGoster = new MaterialSkin.Controls.MaterialButton();
            btnExcelIxrac = new MaterialSkin.Controls.MaterialButton();
            pnlXulase = new Panel();
            cardUmumiSatis = new MaterialSkin.Controls.MaterialCard();
            lblUmumiSatisBasliq = new MaterialSkin.Controls.MaterialLabel();
            lblUmumiSatisDeger = new MaterialSkin.Controls.MaterialLabel();
            cardMehsulSayi = new MaterialSkin.Controls.MaterialCard();
            lblMehsulSayiBasliq = new MaterialSkin.Controls.MaterialLabel();
            lblMehsulSayiDeger = new MaterialSkin.Controls.MaterialLabel();
            cardEnCoxSatilan = new MaterialSkin.Controls.MaterialCard();
            lblEnCoxSatilanBasliq = new MaterialSkin.Controls.MaterialLabel();
            lblEnCoxSatilanDeger = new MaterialSkin.Controls.MaterialLabel();
            dgvHesabat = new DataGridView();
            lblMesaj = new MaterialSkin.Controls.MaterialLabel();
            pnlFiltr.SuspendLayout();
            pnlXulase.SuspendLayout();
            cardUmumiSatis.SuspendLayout();
            cardMehsulSayi.SuspendLayout();
            cardEnCoxSatilan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHesabat).BeginInit();
            SuspendLayout();
            // 
            // pnlFiltr
            // 
            pnlFiltr.BackColor = Color.FromArgb(250, 250, 250);
            pnlFiltr.Controls.Add(lblBaslangicTarix);
            pnlFiltr.Controls.Add(dtpBaslangic);
            pnlFiltr.Controls.Add(lblBitisTarix);
            pnlFiltr.Controls.Add(dtpBitis);
            pnlFiltr.Controls.Add(btnGoster);
            pnlFiltr.Controls.Add(btnExcelIxrac);
            pnlFiltr.Dock = DockStyle.Top;
            pnlFiltr.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlFiltr.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlFiltr.Location = new Point(3, 64);
            pnlFiltr.Name = "pnlFiltr";
            pnlFiltr.Padding = new Padding(20, 15, 20, 15);
            pnlFiltr.Size = new Size(1178, 70);
            pnlFiltr.TabIndex = 0;
            // 
            // lblBaslangicTarix
            // 
            lblBaslangicTarix.AutoSize = true;
            lblBaslangicTarix.BackColor = Color.FromArgb(242, 242, 242);
            lblBaslangicTarix.Depth = 0;
            lblBaslangicTarix.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblBaslangicTarix.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblBaslangicTarix.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblBaslangicTarix.Location = new Point(20, 8);
            lblBaslangicTarix.MouseState = MaterialSkin.MouseState.HOVER;
            lblBaslangicTarix.Name = "lblBaslangicTarix";
            lblBaslangicTarix.Size = new Size(99, 17);
            lblBaslangicTarix.TabIndex = 0;
            lblBaslangicTarix.Text = "Baslangic Tarixi";
            // 
            // dtpBaslangic
            // 
            dtpBaslangic.BackColor = Color.FromArgb(250, 250, 250);
            dtpBaslangic.CalendarFont = new Font("Segoe UI", 10F);
            dtpBaslangic.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dtpBaslangic.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dtpBaslangic.Format = DateTimePickerFormat.Short;
            dtpBaslangic.Location = new Point(20, 28);
            dtpBaslangic.Name = "dtpBaslangic";
            dtpBaslangic.Size = new Size(150, 24);
            dtpBaslangic.TabIndex = 1;
            // 
            // lblBitisTarix
            // 
            lblBitisTarix.AutoSize = true;
            lblBitisTarix.BackColor = Color.FromArgb(242, 242, 242);
            lblBitisTarix.Depth = 0;
            lblBitisTarix.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblBitisTarix.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblBitisTarix.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblBitisTarix.Location = new Point(190, 8);
            lblBitisTarix.MouseState = MaterialSkin.MouseState.HOVER;
            lblBitisTarix.Name = "lblBitisTarix";
            lblBitisTarix.Size = new Size(65, 17);
            lblBitisTarix.TabIndex = 2;
            lblBitisTarix.Text = "Bitis Tarixi";
            // 
            // dtpBitis
            // 
            dtpBitis.BackColor = Color.FromArgb(250, 250, 250);
            dtpBitis.CalendarFont = new Font("Segoe UI", 10F);
            dtpBitis.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dtpBitis.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dtpBitis.Format = DateTimePickerFormat.Short;
            dtpBitis.Location = new Point(190, 28);
            dtpBitis.Name = "dtpBitis";
            dtpBitis.Size = new Size(150, 24);
            dtpBitis.TabIndex = 3;
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
            btnGoster.Location = new Point(360, 22);
            btnGoster.Margin = new Padding(4, 6, 4, 6);
            btnGoster.MouseState = MaterialSkin.MouseState.HOVER;
            btnGoster.Name = "btnGoster";
            btnGoster.NoAccentTextColor = Color.Empty;
            btnGoster.Size = new Size(150, 36);
            btnGoster.TabIndex = 4;
            btnGoster.Text = "Hesabati Goster";
            btnGoster.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnGoster.UseAccentColor = false;
            btnGoster.UseVisualStyleBackColor = false;
            btnGoster.Click += btnGoster_Click;
            // 
            // btnExcelIxrac
            // 
            btnExcelIxrac.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnExcelIxrac.BackColor = Color.FromArgb(242, 242, 242);
            btnExcelIxrac.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnExcelIxrac.Depth = 0;
            btnExcelIxrac.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnExcelIxrac.HighEmphasis = false;
            btnExcelIxrac.Icon = null;
            btnExcelIxrac.Location = new Point(540, 21);
            btnExcelIxrac.Margin = new Padding(4, 6, 4, 6);
            btnExcelIxrac.MouseState = MaterialSkin.MouseState.HOVER;
            btnExcelIxrac.Name = "btnExcelIxrac";
            btnExcelIxrac.NoAccentTextColor = Color.Empty;
            btnExcelIxrac.Size = new Size(111, 36);
            btnExcelIxrac.TabIndex = 5;
            btnExcelIxrac.Text = "Excel Ixrac";
            btnExcelIxrac.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnExcelIxrac.UseAccentColor = false;
            btnExcelIxrac.UseVisualStyleBackColor = false;
            btnExcelIxrac.Click += btnExcelIxrac_Click;
            // 
            // pnlXulase
            // 
            pnlXulase.BackColor = Color.FromArgb(250, 250, 250);
            pnlXulase.Controls.Add(cardUmumiSatis);
            pnlXulase.Controls.Add(cardMehsulSayi);
            pnlXulase.Controls.Add(cardEnCoxSatilan);
            pnlXulase.Dock = DockStyle.Top;
            pnlXulase.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlXulase.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlXulase.Location = new Point(3, 134);
            pnlXulase.Name = "pnlXulase";
            pnlXulase.Padding = new Padding(15, 10, 15, 10);
            pnlXulase.Size = new Size(1178, 120);
            pnlXulase.TabIndex = 1;
            pnlXulase.Visible = false;
            // 
            // cardUmumiSatis
            // 
            cardUmumiSatis.BackColor = Color.FromArgb(255, 255, 255);
            cardUmumiSatis.Controls.Add(lblUmumiSatisBasliq);
            cardUmumiSatis.Controls.Add(lblUmumiSatisDeger);
            cardUmumiSatis.Depth = 0;
            cardUmumiSatis.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cardUmumiSatis.Location = new Point(20, 10);
            cardUmumiSatis.Margin = new Padding(14);
            cardUmumiSatis.MouseState = MaterialSkin.MouseState.HOVER;
            cardUmumiSatis.Name = "cardUmumiSatis";
            cardUmumiSatis.Padding = new Padding(14);
            cardUmumiSatis.Size = new Size(280, 95);
            cardUmumiSatis.TabIndex = 0;
            // 
            // lblUmumiSatisBasliq
            // 
            lblUmumiSatisBasliq.AutoSize = true;
            lblUmumiSatisBasliq.BackColor = Color.FromArgb(242, 242, 242);
            lblUmumiSatisBasliq.Depth = 0;
            lblUmumiSatisBasliq.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblUmumiSatisBasliq.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblUmumiSatisBasliq.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblUmumiSatisBasliq.Location = new Point(14, 14);
            lblUmumiSatisBasliq.MouseState = MaterialSkin.MouseState.HOVER;
            lblUmumiSatisBasliq.Name = "lblUmumiSatisBasliq";
            lblUmumiSatisBasliq.Size = new Size(79, 17);
            lblUmumiSatisBasliq.TabIndex = 0;
            lblUmumiSatisBasliq.Text = "Umumi Satis";
            // 
            // lblUmumiSatisDeger
            // 
            lblUmumiSatisDeger.AutoSize = true;
            lblUmumiSatisDeger.BackColor = Color.FromArgb(242, 242, 242);
            lblUmumiSatisDeger.Depth = 0;
            lblUmumiSatisDeger.Font = new Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblUmumiSatisDeger.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            lblUmumiSatisDeger.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblUmumiSatisDeger.Location = new Point(14, 40);
            lblUmumiSatisDeger.MouseState = MaterialSkin.MouseState.HOVER;
            lblUmumiSatisDeger.Name = "lblUmumiSatisDeger";
            lblUmumiSatisDeger.Size = new Size(141, 41);
            lblUmumiSatisDeger.TabIndex = 1;
            lblUmumiSatisDeger.Text = "0.00 AZN";
            // 
            // cardMehsulSayi
            // 
            cardMehsulSayi.BackColor = Color.FromArgb(255, 255, 255);
            cardMehsulSayi.Controls.Add(lblMehsulSayiBasliq);
            cardMehsulSayi.Controls.Add(lblMehsulSayiDeger);
            cardMehsulSayi.Depth = 0;
            cardMehsulSayi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cardMehsulSayi.Location = new Point(320, 10);
            cardMehsulSayi.Margin = new Padding(14);
            cardMehsulSayi.MouseState = MaterialSkin.MouseState.HOVER;
            cardMehsulSayi.Name = "cardMehsulSayi";
            cardMehsulSayi.Padding = new Padding(14);
            cardMehsulSayi.Size = new Size(200, 95);
            cardMehsulSayi.TabIndex = 1;
            // 
            // lblMehsulSayiBasliq
            // 
            lblMehsulSayiBasliq.AutoSize = true;
            lblMehsulSayiBasliq.BackColor = Color.FromArgb(242, 242, 242);
            lblMehsulSayiBasliq.Depth = 0;
            lblMehsulSayiBasliq.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblMehsulSayiBasliq.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblMehsulSayiBasliq.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblMehsulSayiBasliq.Location = new Point(14, 14);
            lblMehsulSayiBasliq.MouseState = MaterialSkin.MouseState.HOVER;
            lblMehsulSayiBasliq.Name = "lblMehsulSayiBasliq";
            lblMehsulSayiBasliq.Size = new Size(75, 17);
            lblMehsulSayiBasliq.TabIndex = 0;
            lblMehsulSayiBasliq.Text = "Mehsul Sayi";
            // 
            // lblMehsulSayiDeger
            // 
            lblMehsulSayiDeger.AutoSize = true;
            lblMehsulSayiDeger.BackColor = Color.FromArgb(242, 242, 242);
            lblMehsulSayiDeger.Depth = 0;
            lblMehsulSayiDeger.Font = new Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblMehsulSayiDeger.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            lblMehsulSayiDeger.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblMehsulSayiDeger.Location = new Point(14, 40);
            lblMehsulSayiDeger.MouseState = MaterialSkin.MouseState.HOVER;
            lblMehsulSayiDeger.Name = "lblMehsulSayiDeger";
            lblMehsulSayiDeger.Size = new Size(20, 41);
            lblMehsulSayiDeger.TabIndex = 1;
            lblMehsulSayiDeger.Text = "0";
            // 
            // cardEnCoxSatilan
            // 
            cardEnCoxSatilan.BackColor = Color.FromArgb(255, 255, 255);
            cardEnCoxSatilan.Controls.Add(lblEnCoxSatilanBasliq);
            cardEnCoxSatilan.Controls.Add(lblEnCoxSatilanDeger);
            cardEnCoxSatilan.Depth = 0;
            cardEnCoxSatilan.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cardEnCoxSatilan.Location = new Point(540, 10);
            cardEnCoxSatilan.Margin = new Padding(14);
            cardEnCoxSatilan.MouseState = MaterialSkin.MouseState.HOVER;
            cardEnCoxSatilan.Name = "cardEnCoxSatilan";
            cardEnCoxSatilan.Padding = new Padding(14);
            cardEnCoxSatilan.Size = new Size(350, 95);
            cardEnCoxSatilan.TabIndex = 2;
            // 
            // lblEnCoxSatilanBasliq
            // 
            lblEnCoxSatilanBasliq.AutoSize = true;
            lblEnCoxSatilanBasliq.BackColor = Color.FromArgb(242, 242, 242);
            lblEnCoxSatilanBasliq.Depth = 0;
            lblEnCoxSatilanBasliq.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblEnCoxSatilanBasliq.FontType = MaterialSkin.MaterialSkinManager.fontType.Body2;
            lblEnCoxSatilanBasliq.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblEnCoxSatilanBasliq.Location = new Point(14, 14);
            lblEnCoxSatilanBasliq.MouseState = MaterialSkin.MouseState.HOVER;
            lblEnCoxSatilanBasliq.Name = "lblEnCoxSatilanBasliq";
            lblEnCoxSatilanBasliq.Size = new Size(138, 17);
            lblEnCoxSatilanBasliq.TabIndex = 0;
            lblEnCoxSatilanBasliq.Text = "En Cox Satilan Mehsul";
            // 
            // lblEnCoxSatilanDeger
            // 
            lblEnCoxSatilanDeger.AutoSize = true;
            lblEnCoxSatilanDeger.BackColor = Color.FromArgb(242, 242, 242);
            lblEnCoxSatilanDeger.Depth = 0;
            lblEnCoxSatilanDeger.Font = new Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblEnCoxSatilanDeger.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            lblEnCoxSatilanDeger.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblEnCoxSatilanDeger.Location = new Point(14, 45);
            lblEnCoxSatilanDeger.MouseState = MaterialSkin.MouseState.HOVER;
            lblEnCoxSatilanDeger.Name = "lblEnCoxSatilanDeger";
            lblEnCoxSatilanDeger.Size = new Size(8, 29);
            lblEnCoxSatilanDeger.TabIndex = 1;
            lblEnCoxSatilanDeger.Text = "-";
            // 
            // dgvHesabat
            // 
            dgvHesabat.AllowUserToAddRows = false;
            dgvHesabat.AllowUserToDeleteRows = false;
            dgvHesabat.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(250, 250, 250);
            dgvHesabat.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvHesabat.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHesabat.BackgroundColor = Color.White;
            dgvHesabat.BorderStyle = BorderStyle.None;
            dgvHesabat.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvHesabat.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(33, 150, 243);
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(33, 150, 243);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvHesabat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvHesabat.ColumnHeadersHeight = 45;
            dgvHesabat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(232, 240, 254);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvHesabat.DefaultCellStyle = dataGridViewCellStyle3;
            dgvHesabat.EnableHeadersVisualStyles = false;
            dgvHesabat.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvHesabat.GridColor = Color.FromArgb(230, 230, 230);
            dgvHesabat.Location = new Point(20, 260);
            dgvHesabat.MultiSelect = false;
            dgvHesabat.Name = "dgvHesabat";
            dgvHesabat.ReadOnly = true;
            dgvHesabat.RowHeadersVisible = false;
            dgvHesabat.RowTemplate.Height = 40;
            dgvHesabat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHesabat.Size = new Size(1140, 450);
            dgvHesabat.TabIndex = 2;
            // 
            // lblMesaj
            // 
            lblMesaj.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblMesaj.BackColor = Color.FromArgb(242, 242, 242);
            lblMesaj.Depth = 0;
            lblMesaj.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblMesaj.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            lblMesaj.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblMesaj.Location = new Point(20, 260);
            lblMesaj.MouseState = MaterialSkin.MouseState.HOVER;
            lblMesaj.Name = "lblMesaj";
            lblMesaj.Size = new Size(1140, 450);
            lblMesaj.TabIndex = 3;
            lblMesaj.Text = "Hesabati gormek ucun tarix araligini secin ve 'Hesabati Goster' duymesine basin.";
            lblMesaj.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MehsulSatisHesabatFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 250, 250);
            ClientSize = new Size(1184, 749);
            Controls.Add(lblMesaj);
            Controls.Add(dgvHesabat);
            Controls.Add(pnlXulase);
            Controls.Add(pnlFiltr);
            MinimumSize = new Size(900, 600);
            Name = "MehsulSatisHesabatFormu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mehsul uzre Satis Hesabati";
            Load += MehsulSatisHesabatFormu_Load;
            Controls.SetChildIndex(pnlFiltr, 0);
            Controls.SetChildIndex(pnlXulase, 0);
            Controls.SetChildIndex(dgvHesabat, 0);
            Controls.SetChildIndex(lblMesaj, 0);
            pnlFiltr.ResumeLayout(false);
            pnlFiltr.PerformLayout();
            pnlXulase.ResumeLayout(false);
            cardUmumiSatis.ResumeLayout(false);
            cardUmumiSatis.PerformLayout();
            cardMehsulSayi.ResumeLayout(false);
            cardMehsulSayi.PerformLayout();
            cardEnCoxSatilan.ResumeLayout(false);
            cardEnCoxSatilan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHesabat).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlFiltr;
        private MaterialSkin.Controls.MaterialLabel lblBaslangicTarix;
        private DateTimePicker dtpBaslangic;
        private MaterialSkin.Controls.MaterialLabel lblBitisTarix;
        private DateTimePicker dtpBitis;
        private MaterialSkin.Controls.MaterialButton btnGoster;
        private MaterialSkin.Controls.MaterialButton btnExcelIxrac;

        private Panel pnlXulase;
        private MaterialSkin.Controls.MaterialCard cardUmumiSatis;
        private MaterialSkin.Controls.MaterialLabel lblUmumiSatisBasliq;
        private MaterialSkin.Controls.MaterialLabel lblUmumiSatisDeger;
        private MaterialSkin.Controls.MaterialCard cardMehsulSayi;
        private MaterialSkin.Controls.MaterialLabel lblMehsulSayiBasliq;
        private MaterialSkin.Controls.MaterialLabel lblMehsulSayiDeger;
        private MaterialSkin.Controls.MaterialCard cardEnCoxSatilan;
        private MaterialSkin.Controls.MaterialLabel lblEnCoxSatilanBasliq;
        private MaterialSkin.Controls.MaterialLabel lblEnCoxSatilanDeger;

        private DataGridView dgvHesabat;
        private DataGridViewTextBoxColumn colStokKodu;
        private DataGridViewTextBoxColumn colMehsulAdi;
        private DataGridViewTextBoxColumn colCemiMiqdar;
        private DataGridViewTextBoxColumn colCemiMebleg;

        private MaterialSkin.Controls.MaterialLabel lblMesaj;
    }
}
