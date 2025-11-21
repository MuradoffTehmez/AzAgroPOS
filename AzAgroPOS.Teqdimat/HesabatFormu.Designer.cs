// Fayl: AzAgroPOS.Teqdimat/HesabatFormu.Designer.cs
namespace AzAgroPOS.Teqdimat
{
    partial class HesabatFormu
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
            // Filter Panel
            pnlFilter = new Panel();
            lblTarixBasliq = new Label();
            dtpTarix = new DateTimePicker();
            btnGoster = new MaterialSkin.Controls.MaterialButton();
            btnExcelIxrac = new MaterialSkin.Controls.MaterialButton();

            // Summary Cards
            pnlXulase = new Panel();
            pnlUmumiDovriyye = new Panel();
            lblUmumiDovriyyeBasliq = new Label();
            lblUmumiDovriyyeDeyer = new Label();

            pnlSatisSayi = new Panel();
            lblSatisSayiBasliq = new Label();
            lblSatisSayiDeyer = new Label();

            pnlNagdSatis = new Panel();
            lblNagdSatisBasliq = new Label();
            lblNagdSatisDeyer = new Label();

            pnlKartSatis = new Panel();
            lblKartSatisBasliq = new Label();
            lblKartSatisDeyer = new Label();

            pnlNisyeSatis = new Panel();
            lblNisyeSatisBasliq = new Label();
            lblNisyeSatisDeyer = new Label();

            // Data Grid
            dgvSatislar = new DataGridView();
            lblMesaj = new Label();

            pnlFilter.SuspendLayout();
            pnlXulase.SuspendLayout();
            pnlUmumiDovriyye.SuspendLayout();
            pnlSatisSayi.SuspendLayout();
            pnlNagdSatis.SuspendLayout();
            pnlKartSatis.SuspendLayout();
            pnlNisyeSatis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSatislar).BeginInit();
            SuspendLayout();

            // ========================================
            // Filter Panel
            // ========================================
            pnlFilter.BackColor = Color.White;
            pnlFilter.Dock = DockStyle.Top;
            pnlFilter.Location = new Point(3, 64);
            pnlFilter.Size = new Size(1178, 70);
            pnlFilter.Padding = new Padding(20, 15, 20, 15);
            pnlFilter.Controls.Add(lblTarixBasliq);
            pnlFilter.Controls.Add(dtpTarix);
            pnlFilter.Controls.Add(btnGoster);
            pnlFilter.Controls.Add(btnExcelIxrac);

            // lblTarixBasliq
            lblTarixBasliq.AutoSize = true;
            lblTarixBasliq.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblTarixBasliq.ForeColor = Color.FromArgb(66, 66, 66);
            lblTarixBasliq.Location = new Point(25, 25);
            lblTarixBasliq.Text = "Tarix:";

            // dtpTarix
            dtpTarix.Font = new Font("Segoe UI", 11F);
            dtpTarix.Format = DateTimePickerFormat.Short;
            dtpTarix.Location = new Point(75, 20);
            dtpTarix.Size = new Size(200, 27);

            // btnGoster
            btnGoster.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnGoster.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnGoster.Depth = 0;
            btnGoster.HighEmphasis = true;
            btnGoster.Icon = null;
            btnGoster.Location = new Point(300, 15);
            btnGoster.MouseState = MaterialSkin.MouseState.HOVER;
            btnGoster.Name = "btnGoster";
            btnGoster.Size = new Size(100, 36);
            btnGoster.TabIndex = 1;
            btnGoster.Text = "Gostər";
            btnGoster.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnGoster.UseAccentColor = false;
            btnGoster.Click += btnGoster_Click;

            // btnExcelIxrac
            btnExcelIxrac.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnExcelIxrac.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnExcelIxrac.Depth = 0;
            btnExcelIxrac.HighEmphasis = false;
            btnExcelIxrac.Icon = null;
            btnExcelIxrac.Location = new Point(420, 15);
            btnExcelIxrac.MouseState = MaterialSkin.MouseState.HOVER;
            btnExcelIxrac.Name = "btnExcelIxrac";
            btnExcelIxrac.Size = new Size(130, 36);
            btnExcelIxrac.TabIndex = 2;
            btnExcelIxrac.Text = "Excel Ixrac";
            btnExcelIxrac.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnExcelIxrac.UseAccentColor = false;
            btnExcelIxrac.Enabled = false;
            btnExcelIxrac.Click += btnExcelIxrac_Click;

            // ========================================
            // Summary Cards Panel
            // ========================================
            pnlXulase.BackColor = Color.FromArgb(245, 245, 245);
            pnlXulase.Dock = DockStyle.Top;
            pnlXulase.Location = new Point(3, 134);
            pnlXulase.Size = new Size(1178, 130);
            pnlXulase.Padding = new Padding(15, 15, 15, 15);
            pnlXulase.Visible = false;
            pnlXulase.Controls.Add(pnlUmumiDovriyye);
            pnlXulase.Controls.Add(pnlSatisSayi);
            pnlXulase.Controls.Add(pnlNagdSatis);
            pnlXulase.Controls.Add(pnlKartSatis);
            pnlXulase.Controls.Add(pnlNisyeSatis);

            // ========================================
            // Card 1 - Umumi Dovriyye (Blue)
            // ========================================
            pnlUmumiDovriyye.BackColor = Color.FromArgb(33, 150, 243);
            pnlUmumiDovriyye.Location = new Point(20, 15);
            pnlUmumiDovriyye.Size = new Size(210, 100);
            pnlUmumiDovriyye.Controls.Add(lblUmumiDovriyyeBasliq);
            pnlUmumiDovriyye.Controls.Add(lblUmumiDovriyyeDeyer);

            lblUmumiDovriyyeBasliq.AutoSize = true;
            lblUmumiDovriyyeBasliq.Font = new Font("Segoe UI", 10F);
            lblUmumiDovriyyeBasliq.ForeColor = Color.White;
            lblUmumiDovriyyeBasliq.Location = new Point(15, 15);
            lblUmumiDovriyyeBasliq.Text = "Umumi Dovriyye";

            lblUmumiDovriyyeDeyer.AutoSize = true;
            lblUmumiDovriyyeDeyer.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblUmumiDovriyyeDeyer.ForeColor = Color.White;
            lblUmumiDovriyyeDeyer.Location = new Point(15, 45);
            lblUmumiDovriyyeDeyer.Text = "0.00 ₼";

            // ========================================
            // Card 2 - Satis Sayi (Green)
            // ========================================
            pnlSatisSayi.BackColor = Color.FromArgb(76, 175, 80);
            pnlSatisSayi.Location = new Point(250, 15);
            pnlSatisSayi.Size = new Size(210, 100);
            pnlSatisSayi.Controls.Add(lblSatisSayiBasliq);
            pnlSatisSayi.Controls.Add(lblSatisSayiDeyer);

            lblSatisSayiBasliq.AutoSize = true;
            lblSatisSayiBasliq.Font = new Font("Segoe UI", 10F);
            lblSatisSayiBasliq.ForeColor = Color.White;
            lblSatisSayiBasliq.Location = new Point(15, 15);
            lblSatisSayiBasliq.Text = "Satis Sayi";

            lblSatisSayiDeyer.AutoSize = true;
            lblSatisSayiDeyer.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblSatisSayiDeyer.ForeColor = Color.White;
            lblSatisSayiDeyer.Location = new Point(15, 45);
            lblSatisSayiDeyer.Text = "0";

            // ========================================
            // Card 3 - Nagd Satis (Teal)
            // ========================================
            pnlNagdSatis.BackColor = Color.FromArgb(0, 150, 136);
            pnlNagdSatis.Location = new Point(480, 15);
            pnlNagdSatis.Size = new Size(210, 100);
            pnlNagdSatis.Controls.Add(lblNagdSatisBasliq);
            pnlNagdSatis.Controls.Add(lblNagdSatisDeyer);

            lblNagdSatisBasliq.AutoSize = true;
            lblNagdSatisBasliq.Font = new Font("Segoe UI", 10F);
            lblNagdSatisBasliq.ForeColor = Color.White;
            lblNagdSatisBasliq.Location = new Point(15, 15);
            lblNagdSatisBasliq.Text = "Nagd Satis";

            lblNagdSatisDeyer.AutoSize = true;
            lblNagdSatisDeyer.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblNagdSatisDeyer.ForeColor = Color.White;
            lblNagdSatisDeyer.Location = new Point(15, 45);
            lblNagdSatisDeyer.Text = "0.00 ₼";

            // ========================================
            // Card 4 - Kart Satis (Purple)
            // ========================================
            pnlKartSatis.BackColor = Color.FromArgb(156, 39, 176);
            pnlKartSatis.Location = new Point(710, 15);
            pnlKartSatis.Size = new Size(210, 100);
            pnlKartSatis.Controls.Add(lblKartSatisBasliq);
            pnlKartSatis.Controls.Add(lblKartSatisDeyer);

            lblKartSatisBasliq.AutoSize = true;
            lblKartSatisBasliq.Font = new Font("Segoe UI", 10F);
            lblKartSatisBasliq.ForeColor = Color.White;
            lblKartSatisBasliq.Location = new Point(15, 15);
            lblKartSatisBasliq.Text = "Kart Satis";

            lblKartSatisDeyer.AutoSize = true;
            lblKartSatisDeyer.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblKartSatisDeyer.ForeColor = Color.White;
            lblKartSatisDeyer.Location = new Point(15, 45);
            lblKartSatisDeyer.Text = "0.00 ₼";

            // ========================================
            // Card 5 - Nisye Satis (Orange)
            // ========================================
            pnlNisyeSatis.BackColor = Color.FromArgb(255, 152, 0);
            pnlNisyeSatis.Location = new Point(940, 15);
            pnlNisyeSatis.Size = new Size(210, 100);
            pnlNisyeSatis.Controls.Add(lblNisyeSatisBasliq);
            pnlNisyeSatis.Controls.Add(lblNisyeSatisDeyer);

            lblNisyeSatisBasliq.AutoSize = true;
            lblNisyeSatisBasliq.Font = new Font("Segoe UI", 10F);
            lblNisyeSatisBasliq.ForeColor = Color.White;
            lblNisyeSatisBasliq.Location = new Point(15, 15);
            lblNisyeSatisBasliq.Text = "Nisye Satis";

            lblNisyeSatisDeyer.AutoSize = true;
            lblNisyeSatisDeyer.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblNisyeSatisDeyer.ForeColor = Color.White;
            lblNisyeSatisDeyer.Location = new Point(15, 45);
            lblNisyeSatisDeyer.Text = "0.00 ₼";

            // ========================================
            // DataGridView
            // ========================================
            dgvSatislar.AllowUserToAddRows = false;
            dgvSatislar.AllowUserToDeleteRows = false;
            dgvSatislar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSatislar.BackgroundColor = Color.White;
            dgvSatislar.BorderStyle = BorderStyle.None;
            dgvSatislar.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvSatislar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSatislar.Dock = DockStyle.Fill;
            dgvSatislar.EnableHeadersVisualStyles = false;
            dgvSatislar.GridColor = Color.FromArgb(224, 224, 224);
            dgvSatislar.Location = new Point(3, 264);
            dgvSatislar.Name = "dgvSatislar";
            dgvSatislar.ReadOnly = true;
            dgvSatislar.RowHeadersVisible = false;
            dgvSatislar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSatislar.Size = new Size(1178, 482);
            dgvSatislar.Visible = false;

            // ========================================
            // Mesaj Label
            // ========================================
            lblMesaj.Dock = DockStyle.Fill;
            lblMesaj.Font = new Font("Segoe UI", 14F);
            lblMesaj.ForeColor = Color.FromArgb(158, 158, 158);
            lblMesaj.Location = new Point(3, 264);
            lblMesaj.Name = "lblMesaj";
            lblMesaj.Size = new Size(1178, 482);
            lblMesaj.TextAlign = ContentAlignment.MiddleCenter;
            lblMesaj.Visible = false;

            // ========================================
            // HesabatFormu
            // ========================================
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 749);
            Controls.Add(dgvSatislar);
            Controls.Add(lblMesaj);
            Controls.Add(pnlXulase);
            Controls.Add(pnlFilter);
            Name = "HesabatFormu";
            Padding = new Padding(3, 64, 3, 3);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gunluk Satis Hesabati";

            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            pnlXulase.ResumeLayout(false);
            pnlUmumiDovriyye.ResumeLayout(false);
            pnlUmumiDovriyye.PerformLayout();
            pnlSatisSayi.ResumeLayout(false);
            pnlSatisSayi.PerformLayout();
            pnlNagdSatis.ResumeLayout(false);
            pnlNagdSatis.PerformLayout();
            pnlKartSatis.ResumeLayout(false);
            pnlKartSatis.PerformLayout();
            pnlNisyeSatis.ResumeLayout(false);
            pnlNisyeSatis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSatislar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        // Filter Panel
        private Panel pnlFilter;
        private Label lblTarixBasliq;
        private DateTimePicker dtpTarix;
        private MaterialSkin.Controls.MaterialButton btnGoster;
        private MaterialSkin.Controls.MaterialButton btnExcelIxrac;

        // Summary Cards Panel
        private Panel pnlXulase;
        private Panel pnlUmumiDovriyye;
        private Label lblUmumiDovriyyeBasliq;
        private Label lblUmumiDovriyyeDeyer;

        private Panel pnlSatisSayi;
        private Label lblSatisSayiBasliq;
        private Label lblSatisSayiDeyer;

        private Panel pnlNagdSatis;
        private Label lblNagdSatisBasliq;
        private Label lblNagdSatisDeyer;

        private Panel pnlKartSatis;
        private Label lblKartSatisBasliq;
        private Label lblKartSatisDeyer;

        private Panel pnlNisyeSatis;
        private Label lblNisyeSatisBasliq;
        private Label lblNisyeSatisDeyer;

        // Data Grid
        private DataGridView dgvSatislar;
        private Label lblMesaj;
    }
}
