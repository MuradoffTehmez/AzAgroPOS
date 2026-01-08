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
            pnlFilter = new Panel();
            lblTarixBasliq = new Label();
            dtpTarix = new DateTimePicker();
            btnGoster = new MaterialSkin.Controls.MaterialButton();
            btnExcelIxrac = new MaterialSkin.Controls.MaterialButton();
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
            dgvSatislar = new DataGridView();
            lblMesaj = new Label();
            pnlFiltrPanel = new Panel();
            lblAxtaris = new Label();
            txtAxtaris = new TextBox();
            lblOdenisTipiFiltr = new Label();
            cmbOdenisTipiFiltr = new ComboBox();
            lblFiltreliSay = new Label();
            pnlFilter.SuspendLayout();
            pnlXulase.SuspendLayout();
            pnlUmumiDovriyye.SuspendLayout();
            pnlSatisSayi.SuspendLayout();
            pnlNagdSatis.SuspendLayout();
            pnlKartSatis.SuspendLayout();
            pnlNisyeSatis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSatislar).BeginInit();
            pnlFiltrPanel.SuspendLayout();
            SuspendLayout();
            // 
            // pnlFilter
            // 
            pnlFilter.BackColor = Color.FromArgb(242, 242, 242);
            pnlFilter.Controls.Add(lblTarixBasliq);
            pnlFilter.Controls.Add(dtpTarix);
            pnlFilter.Controls.Add(btnGoster);
            pnlFilter.Controls.Add(btnExcelIxrac);
            pnlFilter.Dock = DockStyle.Top;
            pnlFilter.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlFilter.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlFilter.Location = new Point(3, 64);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Padding = new Padding(20, 15, 20, 15);
            pnlFilter.Size = new Size(1178, 70);
            pnlFilter.TabIndex = 5;
            // 
            // lblTarixBasliq
            // 
            lblTarixBasliq.AutoSize = true;
            lblTarixBasliq.BackColor = Color.FromArgb(242, 242, 242);
            lblTarixBasliq.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblTarixBasliq.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblTarixBasliq.Location = new Point(25, 25);
            lblTarixBasliq.Name = "lblTarixBasliq";
            lblTarixBasliq.Size = new Size(41, 17);
            lblTarixBasliq.TabIndex = 0;
            lblTarixBasliq.Text = "Tarix:";
            // 
            // dtpTarix
            // 
            dtpTarix.BackColor = Color.FromArgb(242, 242, 242);
            dtpTarix.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dtpTarix.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dtpTarix.Format = DateTimePickerFormat.Short;
            dtpTarix.Location = new Point(75, 20);
            dtpTarix.Name = "dtpTarix";
            dtpTarix.Size = new Size(200, 24);
            dtpTarix.TabIndex = 1;
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
            btnGoster.Location = new Point(300, 15);
            btnGoster.Margin = new Padding(4, 6, 4, 6);
            btnGoster.MouseState = MaterialSkin.MouseState.HOVER;
            btnGoster.Name = "btnGoster";
            btnGoster.NoAccentTextColor = Color.Empty;
            btnGoster.Size = new Size(79, 36);
            btnGoster.TabIndex = 1;
            btnGoster.Text = "Gostər";
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
            btnExcelIxrac.Enabled = false;
            btnExcelIxrac.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnExcelIxrac.HighEmphasis = false;
            btnExcelIxrac.Icon = null;
            btnExcelIxrac.Location = new Point(420, 15);
            btnExcelIxrac.Margin = new Padding(4, 6, 4, 6);
            btnExcelIxrac.MouseState = MaterialSkin.MouseState.HOVER;
            btnExcelIxrac.Name = "btnExcelIxrac";
            btnExcelIxrac.NoAccentTextColor = Color.Empty;
            btnExcelIxrac.Size = new Size(111, 36);
            btnExcelIxrac.TabIndex = 2;
            btnExcelIxrac.Text = "Excel Ixrac";
            btnExcelIxrac.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnExcelIxrac.UseAccentColor = false;
            btnExcelIxrac.UseVisualStyleBackColor = false;
            btnExcelIxrac.Click += btnExcelIxrac_Click;
            // 
            // pnlXulase
            // 
            pnlXulase.BackColor = Color.FromArgb(242, 242, 242);
            pnlXulase.Controls.Add(pnlUmumiDovriyye);
            pnlXulase.Controls.Add(pnlSatisSayi);
            pnlXulase.Controls.Add(pnlNagdSatis);
            pnlXulase.Controls.Add(pnlKartSatis);
            pnlXulase.Controls.Add(pnlNisyeSatis);
            pnlXulase.Dock = DockStyle.Top;
            pnlXulase.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlXulase.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlXulase.Location = new Point(3, 134);
            pnlXulase.Name = "pnlXulase";
            pnlXulase.Padding = new Padding(15);
            pnlXulase.Size = new Size(1178, 130);
            pnlXulase.TabIndex = 4;
            pnlXulase.Visible = false;
            // 
            // pnlUmumiDovriyye
            // 
            pnlUmumiDovriyye.BackColor = Color.FromArgb(242, 242, 242);
            pnlUmumiDovriyye.Controls.Add(lblUmumiDovriyyeBasliq);
            pnlUmumiDovriyye.Controls.Add(lblUmumiDovriyyeDeyer);
            pnlUmumiDovriyye.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlUmumiDovriyye.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlUmumiDovriyye.Location = new Point(20, 15);
            pnlUmumiDovriyye.Name = "pnlUmumiDovriyye";
            pnlUmumiDovriyye.Size = new Size(210, 100);
            pnlUmumiDovriyye.TabIndex = 0;
            // 
            // lblUmumiDovriyyeBasliq
            // 
            lblUmumiDovriyyeBasliq.AutoSize = true;
            lblUmumiDovriyyeBasliq.BackColor = Color.FromArgb(242, 242, 242);
            lblUmumiDovriyyeBasliq.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblUmumiDovriyyeBasliq.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblUmumiDovriyyeBasliq.Location = new Point(15, 15);
            lblUmumiDovriyyeBasliq.Name = "lblUmumiDovriyyeBasliq";
            lblUmumiDovriyyeBasliq.Size = new Size(108, 17);
            lblUmumiDovriyyeBasliq.TabIndex = 0;
            lblUmumiDovriyyeBasliq.Text = "Umumi Dovriyye";
            // 
            // lblUmumiDovriyyeDeyer
            // 
            lblUmumiDovriyyeDeyer.AutoSize = true;
            lblUmumiDovriyyeDeyer.BackColor = Color.FromArgb(242, 242, 242);
            lblUmumiDovriyyeDeyer.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblUmumiDovriyyeDeyer.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblUmumiDovriyyeDeyer.Location = new Point(15, 45);
            lblUmumiDovriyyeDeyer.Name = "lblUmumiDovriyyeDeyer";
            lblUmumiDovriyyeDeyer.Size = new Size(48, 17);
            lblUmumiDovriyyeDeyer.TabIndex = 1;
            lblUmumiDovriyyeDeyer.Text = "0.00 ₼";
            // 
            // pnlSatisSayi
            // 
            pnlSatisSayi.BackColor = Color.FromArgb(242, 242, 242);
            pnlSatisSayi.Controls.Add(lblSatisSayiBasliq);
            pnlSatisSayi.Controls.Add(lblSatisSayiDeyer);
            pnlSatisSayi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlSatisSayi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlSatisSayi.Location = new Point(250, 15);
            pnlSatisSayi.Name = "pnlSatisSayi";
            pnlSatisSayi.Size = new Size(210, 100);
            pnlSatisSayi.TabIndex = 1;
            // 
            // lblSatisSayiBasliq
            // 
            lblSatisSayiBasliq.AutoSize = true;
            lblSatisSayiBasliq.BackColor = Color.FromArgb(242, 242, 242);
            lblSatisSayiBasliq.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSatisSayiBasliq.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblSatisSayiBasliq.Location = new Point(15, 15);
            lblSatisSayiBasliq.Name = "lblSatisSayiBasliq";
            lblSatisSayiBasliq.Size = new Size(68, 17);
            lblSatisSayiBasliq.TabIndex = 0;
            lblSatisSayiBasliq.Text = "Satis Sayi";
            // 
            // lblSatisSayiDeyer
            // 
            lblSatisSayiDeyer.AutoSize = true;
            lblSatisSayiDeyer.BackColor = Color.FromArgb(242, 242, 242);
            lblSatisSayiDeyer.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSatisSayiDeyer.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblSatisSayiDeyer.Location = new Point(15, 45);
            lblSatisSayiDeyer.Name = "lblSatisSayiDeyer";
            lblSatisSayiDeyer.Size = new Size(16, 17);
            lblSatisSayiDeyer.TabIndex = 1;
            lblSatisSayiDeyer.Text = "0";
            // 
            // pnlNagdSatis
            // 
            pnlNagdSatis.BackColor = Color.FromArgb(242, 242, 242);
            pnlNagdSatis.Controls.Add(lblNagdSatisBasliq);
            pnlNagdSatis.Controls.Add(lblNagdSatisDeyer);
            pnlNagdSatis.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlNagdSatis.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlNagdSatis.Location = new Point(480, 15);
            pnlNagdSatis.Name = "pnlNagdSatis";
            pnlNagdSatis.Size = new Size(210, 100);
            pnlNagdSatis.TabIndex = 2;
            // 
            // lblNagdSatisBasliq
            // 
            lblNagdSatisBasliq.AutoSize = true;
            lblNagdSatisBasliq.BackColor = Color.FromArgb(242, 242, 242);
            lblNagdSatisBasliq.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblNagdSatisBasliq.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblNagdSatisBasliq.Location = new Point(15, 15);
            lblNagdSatisBasliq.Name = "lblNagdSatisBasliq";
            lblNagdSatisBasliq.Size = new Size(76, 17);
            lblNagdSatisBasliq.TabIndex = 0;
            lblNagdSatisBasliq.Text = "Nagd Satis";
            // 
            // lblNagdSatisDeyer
            // 
            lblNagdSatisDeyer.AutoSize = true;
            lblNagdSatisDeyer.BackColor = Color.FromArgb(242, 242, 242);
            lblNagdSatisDeyer.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblNagdSatisDeyer.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblNagdSatisDeyer.Location = new Point(15, 45);
            lblNagdSatisDeyer.Name = "lblNagdSatisDeyer";
            lblNagdSatisDeyer.Size = new Size(48, 17);
            lblNagdSatisDeyer.TabIndex = 1;
            lblNagdSatisDeyer.Text = "0.00 ₼";
            // 
            // pnlKartSatis
            // 
            pnlKartSatis.BackColor = Color.FromArgb(242, 242, 242);
            pnlKartSatis.Controls.Add(lblKartSatisBasliq);
            pnlKartSatis.Controls.Add(lblKartSatisDeyer);
            pnlKartSatis.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlKartSatis.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlKartSatis.Location = new Point(710, 15);
            pnlKartSatis.Name = "pnlKartSatis";
            pnlKartSatis.Size = new Size(210, 100);
            pnlKartSatis.TabIndex = 3;
            // 
            // lblKartSatisBasliq
            // 
            lblKartSatisBasliq.AutoSize = true;
            lblKartSatisBasliq.BackColor = Color.FromArgb(242, 242, 242);
            lblKartSatisBasliq.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblKartSatisBasliq.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblKartSatisBasliq.Location = new Point(15, 15);
            lblKartSatisBasliq.Name = "lblKartSatisBasliq";
            lblKartSatisBasliq.Size = new Size(69, 17);
            lblKartSatisBasliq.TabIndex = 0;
            lblKartSatisBasliq.Text = "Kart Satis";
            // 
            // lblKartSatisDeyer
            // 
            lblKartSatisDeyer.AutoSize = true;
            lblKartSatisDeyer.BackColor = Color.FromArgb(242, 242, 242);
            lblKartSatisDeyer.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblKartSatisDeyer.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblKartSatisDeyer.Location = new Point(15, 45);
            lblKartSatisDeyer.Name = "lblKartSatisDeyer";
            lblKartSatisDeyer.Size = new Size(48, 17);
            lblKartSatisDeyer.TabIndex = 1;
            lblKartSatisDeyer.Text = "0.00 ₼";
            // 
            // pnlNisyeSatis
            // 
            pnlNisyeSatis.BackColor = Color.FromArgb(242, 242, 242);
            pnlNisyeSatis.Controls.Add(lblNisyeSatisBasliq);
            pnlNisyeSatis.Controls.Add(lblNisyeSatisDeyer);
            pnlNisyeSatis.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlNisyeSatis.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlNisyeSatis.Location = new Point(940, 15);
            pnlNisyeSatis.Name = "pnlNisyeSatis";
            pnlNisyeSatis.Size = new Size(210, 100);
            pnlNisyeSatis.TabIndex = 4;
            // 
            // lblNisyeSatisBasliq
            // 
            lblNisyeSatisBasliq.AutoSize = true;
            lblNisyeSatisBasliq.BackColor = Color.FromArgb(242, 242, 242);
            lblNisyeSatisBasliq.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblNisyeSatisBasliq.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblNisyeSatisBasliq.Location = new Point(15, 15);
            lblNisyeSatisBasliq.Name = "lblNisyeSatisBasliq";
            lblNisyeSatisBasliq.Size = new Size(76, 17);
            lblNisyeSatisBasliq.TabIndex = 0;
            lblNisyeSatisBasliq.Text = "Nisye Satis";
            // 
            // lblNisyeSatisDeyer
            // 
            lblNisyeSatisDeyer.AutoSize = true;
            lblNisyeSatisDeyer.BackColor = Color.FromArgb(242, 242, 242);
            lblNisyeSatisDeyer.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblNisyeSatisDeyer.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblNisyeSatisDeyer.Location = new Point(15, 45);
            lblNisyeSatisDeyer.Name = "lblNisyeSatisDeyer";
            lblNisyeSatisDeyer.Size = new Size(48, 17);
            lblNisyeSatisDeyer.TabIndex = 1;
            lblNisyeSatisDeyer.Text = "0.00 ₼";
            // 
            // dgvSatislar
            // 
            dgvSatislar.AllowUserToAddRows = false;
            dgvSatislar.AllowUserToDeleteRows = false;
            dgvSatislar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSatislar.BackgroundColor = Color.White;
            dgvSatislar.BorderStyle = BorderStyle.None;
            dgvSatislar.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvSatislar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSatislar.Dock = DockStyle.Fill;
            dgvSatislar.EnableHeadersVisualStyles = false;
            dgvSatislar.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvSatislar.GridColor = Color.FromArgb(224, 224, 224);
            dgvSatislar.Location = new Point(3, 314);
            dgvSatislar.Name = "dgvSatislar";
            dgvSatislar.ReadOnly = true;
            dgvSatislar.RowHeadersVisible = false;
            dgvSatislar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSatislar.Size = new Size(1178, 432);
            dgvSatislar.TabIndex = 1;
            dgvSatislar.Visible = false;
            // 
            // lblMesaj
            // 
            lblMesaj.BackColor = Color.FromArgb(242, 242, 242);
            lblMesaj.Dock = DockStyle.Fill;
            lblMesaj.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblMesaj.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblMesaj.Location = new Point(3, 314);
            lblMesaj.Name = "lblMesaj";
            lblMesaj.Size = new Size(1178, 432);
            lblMesaj.TabIndex = 2;
            lblMesaj.TextAlign = ContentAlignment.MiddleCenter;
            lblMesaj.Visible = false;
            // 
            // pnlFiltrPanel
            // 
            pnlFiltrPanel.BackColor = Color.FromArgb(242, 242, 242);
            pnlFiltrPanel.Controls.Add(lblAxtaris);
            pnlFiltrPanel.Controls.Add(txtAxtaris);
            pnlFiltrPanel.Controls.Add(lblOdenisTipiFiltr);
            pnlFiltrPanel.Controls.Add(cmbOdenisTipiFiltr);
            pnlFiltrPanel.Controls.Add(lblFiltreliSay);
            pnlFiltrPanel.Dock = DockStyle.Top;
            pnlFiltrPanel.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlFiltrPanel.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlFiltrPanel.Location = new Point(3, 264);
            pnlFiltrPanel.Name = "pnlFiltrPanel";
            pnlFiltrPanel.Size = new Size(1178, 50);
            pnlFiltrPanel.TabIndex = 3;
            pnlFiltrPanel.Visible = false;
            // 
            // lblAxtaris
            // 
            lblAxtaris.AutoSize = true;
            lblAxtaris.BackColor = Color.FromArgb(242, 242, 242);
            lblAxtaris.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblAxtaris.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblAxtaris.Location = new Point(20, 15);
            lblAxtaris.Name = "lblAxtaris";
            lblAxtaris.Size = new Size(55, 17);
            lblAxtaris.TabIndex = 0;
            lblAxtaris.Text = "Axtaris:";
            // 
            // txtAxtaris
            // 
            txtAxtaris.BackColor = Color.FromArgb(242, 242, 242);
            txtAxtaris.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtAxtaris.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtAxtaris.Location = new Point(85, 12);
            txtAxtaris.Name = "txtAxtaris";
            txtAxtaris.PlaceholderText = "Satis no ve ya kassir...";
            txtAxtaris.Size = new Size(200, 24);
            txtAxtaris.TabIndex = 1;
            // 
            // lblOdenisTipiFiltr
            // 
            lblOdenisTipiFiltr.AutoSize = true;
            lblOdenisTipiFiltr.BackColor = Color.FromArgb(242, 242, 242);
            lblOdenisTipiFiltr.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblOdenisTipiFiltr.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblOdenisTipiFiltr.Location = new Point(310, 15);
            lblOdenisTipiFiltr.Name = "lblOdenisTipiFiltr";
            lblOdenisTipiFiltr.Size = new Size(76, 17);
            lblOdenisTipiFiltr.TabIndex = 2;
            lblOdenisTipiFiltr.Text = "Odenis tipi:";
            // 
            // cmbOdenisTipiFiltr
            // 
            cmbOdenisTipiFiltr.BackColor = Color.FromArgb(242, 242, 242);
            cmbOdenisTipiFiltr.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOdenisTipiFiltr.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            cmbOdenisTipiFiltr.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbOdenisTipiFiltr.Items.AddRange(new object[] { "Hamisi", "Nagd", "Kart", "Nisye" });
            cmbOdenisTipiFiltr.Location = new Point(400, 11);
            cmbOdenisTipiFiltr.Name = "cmbOdenisTipiFiltr";
            cmbOdenisTipiFiltr.Size = new Size(150, 25);
            cmbOdenisTipiFiltr.TabIndex = 3;
            // 
            // lblFiltreliSay
            // 
            lblFiltreliSay.AutoSize = true;
            lblFiltreliSay.BackColor = Color.FromArgb(242, 242, 242);
            lblFiltreliSay.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblFiltreliSay.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblFiltreliSay.Location = new Point(580, 16);
            lblFiltreliSay.Name = "lblFiltreliSay";
            lblFiltreliSay.Size = new Size(105, 17);
            lblFiltreliSay.TabIndex = 4;
            lblFiltreliSay.Text = "Gosterilen: 0 / 0";
            // 
            // HesabatFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 749);
            Controls.Add(dgvSatislar);
            Controls.Add(lblMesaj);
            Controls.Add(pnlFiltrPanel);
            Controls.Add(pnlXulase);
            Controls.Add(pnlFilter);
            Name = "HesabatFormu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gunluk Satis Hesabati";
            Controls.SetChildIndex(pnlFilter, 0);
            Controls.SetChildIndex(pnlXulase, 0);
            Controls.SetChildIndex(pnlFiltrPanel, 0);
            Controls.SetChildIndex(lblMesaj, 0);
            Controls.SetChildIndex(dgvSatislar, 0);
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
            pnlFiltrPanel.ResumeLayout(false);
            pnlFiltrPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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

        // Filtr Panel
        private Panel pnlFiltrPanel;
        private Label lblAxtaris;
        private TextBox txtAxtaris;
        private Label lblOdenisTipiFiltr;
        private ComboBox cmbOdenisTipiFiltr;
        private Label lblFiltreliSay;

        // Data Grid
        private DataGridView dgvSatislar;
        private Label lblMesaj;
    }
}
