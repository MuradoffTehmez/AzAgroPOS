// Fayl: AzAgroPOS.Teqdimat/ZHesabatArxivFormu.Designer.cs
namespace AzAgroPOS.Teqdimat
{
    partial class ZHesabatArxivFormu
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
            pnlFiltr = new Panel();
            lblBaslangicTarixi = new MaterialSkin.Controls.MaterialLabel();
            dtpBaslangic = new DateTimePicker();
            lblBitisTarixi = new MaterialSkin.Controls.MaterialLabel();
            dtpBitis = new DateTimePicker();
            btnFiltrle = new MaterialSkin.Controls.MaterialButton();
            pnlXulase = new Panel();
            pnlNovbeSayi = new Panel();
            lblNovbeSayiBasliq = new Label();
            lblNovbeSayiDeyer = new Label();
            pnlCemiSatis = new Panel();
            lblCemiSatisBasliq = new Label();
            lblCemiSatisDeyer = new Label();
            pnlNagdSatis = new Panel();
            lblNagdSatisBasliq = new Label();
            lblNagdSatisDeyer = new Label();
            pnlKartSatis = new Panel();
            lblKartSatisBasliq = new Label();
            lblKartSatisDeyer = new Label();
            pnlContent = new Panel();
            dgvNovbeler = new DataGridView();
            pnlDetallar = new Panel();
            lblDetallarBasliq = new MaterialSkin.Controls.MaterialLabel();
            pnlDetalContent = new Panel();
            lblAcilisTarixi = new Label();
            lblAcilisTarixiDeyer = new Label();
            lblBaglanmaTarixi = new Label();
            lblBaglanmaTarixiDeyer = new Label();
            lblKassir = new Label();
            lblKassirDeyer = new Label();
            lblBaslangicMebleg = new Label();
            lblBaslangicMeblegDeyer = new Label();
            lblSatisSayi = new Label();
            lblSatisSayiDeyer = new Label();
            lblGozlenilenMebleg = new Label();
            lblGozlenilenMeblegDeyer = new Label();
            lblFaktikiMebleg = new Label();
            lblFaktikiMeblegDeyer = new Label();
            lblFerq = new Label();
            lblFerqDeyer = new Label();
            lblNagdSatisDetalDeyer = new Label();
            lblKartSatisDetalDeyer = new Label();
            lblCemiSatisDetalDeyer = new Label();
            pnlButtons = new Panel();
            btnCap = new MaterialSkin.Controls.MaterialButton();
            btnGoster = new MaterialSkin.Controls.MaterialButton();
            pnlFiltr.SuspendLayout();
            pnlXulase.SuspendLayout();
            pnlNovbeSayi.SuspendLayout();
            pnlCemiSatis.SuspendLayout();
            pnlNagdSatis.SuspendLayout();
            pnlKartSatis.SuspendLayout();
            pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNovbeler).BeginInit();
            pnlDetallar.SuspendLayout();
            pnlDetalContent.SuspendLayout();
            pnlButtons.SuspendLayout();
            SuspendLayout();
            // 
            // pnlFiltr
            // 
            pnlFiltr.BackColor = Color.FromArgb(242, 242, 242);
            pnlFiltr.Controls.Add(lblBaslangicTarixi);
            pnlFiltr.Controls.Add(dtpBaslangic);
            pnlFiltr.Controls.Add(lblBitisTarixi);
            pnlFiltr.Controls.Add(dtpBitis);
            pnlFiltr.Controls.Add(btnFiltrle);
            pnlFiltr.Dock = DockStyle.Top;
            pnlFiltr.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlFiltr.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlFiltr.Location = new Point(3, 64);
            pnlFiltr.Name = "pnlFiltr";
            pnlFiltr.Padding = new Padding(15, 10, 15, 10);
            pnlFiltr.Size = new Size(1194, 60);
            pnlFiltr.TabIndex = 3;
            // 
            // lblBaslangicTarixi
            // 
            lblBaslangicTarixi.AutoSize = true;
            lblBaslangicTarixi.BackColor = Color.FromArgb(242, 242, 242);
            lblBaslangicTarixi.Depth = 0;
            lblBaslangicTarixi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblBaslangicTarixi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblBaslangicTarixi.Location = new Point(18, 20);
            lblBaslangicTarixi.MouseState = MaterialSkin.MouseState.HOVER;
            lblBaslangicTarixi.Name = "lblBaslangicTarixi";
            lblBaslangicTarixi.Size = new Size(114, 19);
            lblBaslangicTarixi.TabIndex = 0;
            lblBaslangicTarixi.Text = "Başlanğıc tarixi:";
            // 
            // dtpBaslangic
            // 
            dtpBaslangic.BackColor = Color.FromArgb(242, 242, 242);
            dtpBaslangic.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dtpBaslangic.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dtpBaslangic.Format = DateTimePickerFormat.Short;
            dtpBaslangic.Location = new Point(130, 17);
            dtpBaslangic.Name = "dtpBaslangic";
            dtpBaslangic.Size = new Size(130, 24);
            dtpBaslangic.TabIndex = 1;
            // 
            // lblBitisTarixi
            // 
            lblBitisTarixi.AutoSize = true;
            lblBitisTarixi.BackColor = Color.FromArgb(242, 242, 242);
            lblBitisTarixi.Depth = 0;
            lblBitisTarixi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblBitisTarixi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblBitisTarixi.Location = new Point(280, 20);
            lblBitisTarixi.MouseState = MaterialSkin.MouseState.HOVER;
            lblBitisTarixi.Name = "lblBitisTarixi";
            lblBitisTarixi.Size = new Size(75, 19);
            lblBitisTarixi.TabIndex = 2;
            lblBitisTarixi.Text = "Bitiş tarixi:";
            // 
            // dtpBitis
            // 
            dtpBitis.BackColor = Color.FromArgb(242, 242, 242);
            dtpBitis.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dtpBitis.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dtpBitis.Format = DateTimePickerFormat.Short;
            dtpBitis.Location = new Point(360, 17);
            dtpBitis.Name = "dtpBitis";
            dtpBitis.Size = new Size(130, 24);
            dtpBitis.TabIndex = 3;
            // 
            // btnFiltrle
            // 
            btnFiltrle.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnFiltrle.BackColor = Color.FromArgb(242, 242, 242);
            btnFiltrle.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnFiltrle.Depth = 0;
            btnFiltrle.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnFiltrle.HighEmphasis = true;
            btnFiltrle.Icon = null;
            btnFiltrle.Location = new Point(510, 10);
            btnFiltrle.Margin = new Padding(4, 6, 4, 6);
            btnFiltrle.MouseState = MaterialSkin.MouseState.HOVER;
            btnFiltrle.Name = "btnFiltrle";
            btnFiltrle.NoAccentTextColor = Color.Empty;
            btnFiltrle.Size = new Size(78, 36);
            btnFiltrle.TabIndex = 4;
            btnFiltrle.Text = "Filtrlə";
            btnFiltrle.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnFiltrle.UseAccentColor = false;
            btnFiltrle.UseVisualStyleBackColor = false;
            // 
            // pnlXulase
            // 
            pnlXulase.BackColor = Color.FromArgb(242, 242, 242);
            pnlXulase.Controls.Add(pnlNovbeSayi);
            pnlXulase.Controls.Add(pnlCemiSatis);
            pnlXulase.Controls.Add(pnlNagdSatis);
            pnlXulase.Controls.Add(pnlKartSatis);
            pnlXulase.Dock = DockStyle.Top;
            pnlXulase.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlXulase.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlXulase.Location = new Point(3, 124);
            pnlXulase.Name = "pnlXulase";
            pnlXulase.Padding = new Padding(15, 10, 15, 10);
            pnlXulase.Size = new Size(1194, 100);
            pnlXulase.TabIndex = 2;
            //
            // pnlNovbeSayi - Modern statistik kart
            //
            pnlNovbeSayi.BackColor = Color.White;
            pnlNovbeSayi.Controls.Add(lblNovbeSayiBasliq);
            pnlNovbeSayi.Controls.Add(lblNovbeSayiDeyer);
            pnlNovbeSayi.Font = new Font("Segoe UI", 10F);
            pnlNovbeSayi.ForeColor = Color.FromArgb(33, 33, 33);
            pnlNovbeSayi.Location = new Point(18, 15);
            pnlNovbeSayi.Name = "pnlNovbeSayi";
            pnlNovbeSayi.Size = new Size(270, 70);
            pnlNovbeSayi.TabIndex = 0;
            pnlNovbeSayi.BorderStyle = BorderStyle.None;
            //
            // lblNovbeSayiBasliq
            //
            lblNovbeSayiBasliq.BackColor = Color.White;
            lblNovbeSayiBasliq.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblNovbeSayiBasliq.ForeColor = Color.FromArgb(117, 117, 117);
            lblNovbeSayiBasliq.Location = new Point(15, 10);
            lblNovbeSayiBasliq.Name = "lblNovbeSayiBasliq";
            lblNovbeSayiBasliq.Size = new Size(240, 20);
            lblNovbeSayiBasliq.TabIndex = 0;
            lblNovbeSayiBasliq.Text = "NOVBE SAYI";
            //
            // lblNovbeSayiDeyer
            //
            lblNovbeSayiDeyer.BackColor = Color.White;
            lblNovbeSayiDeyer.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblNovbeSayiDeyer.ForeColor = Color.FromArgb(33, 150, 243);
            lblNovbeSayiDeyer.Location = new Point(15, 30);
            lblNovbeSayiDeyer.Name = "lblNovbeSayiDeyer";
            lblNovbeSayiDeyer.Size = new Size(240, 35);
            lblNovbeSayiDeyer.TabIndex = 1;
            lblNovbeSayiDeyer.Text = "0";
            //
            // pnlCemiSatis - Modern statistik kart
            //
            pnlCemiSatis.BackColor = Color.White;
            pnlCemiSatis.Controls.Add(lblCemiSatisBasliq);
            pnlCemiSatis.Controls.Add(lblCemiSatisDeyer);
            pnlCemiSatis.Font = new Font("Segoe UI", 10F);
            pnlCemiSatis.ForeColor = Color.FromArgb(33, 33, 33);
            pnlCemiSatis.Location = new Point(308, 15);
            pnlCemiSatis.Name = "pnlCemiSatis";
            pnlCemiSatis.Size = new Size(270, 70);
            pnlCemiSatis.TabIndex = 1;
            pnlCemiSatis.BorderStyle = BorderStyle.None;
            //
            // lblCemiSatisBasliq
            //
            lblCemiSatisBasliq.BackColor = Color.White;
            lblCemiSatisBasliq.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblCemiSatisBasliq.ForeColor = Color.FromArgb(117, 117, 117);
            lblCemiSatisBasliq.Location = new Point(15, 10);
            lblCemiSatisBasliq.Name = "lblCemiSatisBasliq";
            lblCemiSatisBasliq.Size = new Size(240, 20);
            lblCemiSatisBasliq.TabIndex = 0;
            lblCemiSatisBasliq.Text = "CEMI SATIS";
            //
            // lblCemiSatisDeyer
            //
            lblCemiSatisDeyer.BackColor = Color.White;
            lblCemiSatisDeyer.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblCemiSatisDeyer.ForeColor = Color.FromArgb(76, 175, 80);
            lblCemiSatisDeyer.Location = new Point(15, 30);
            lblCemiSatisDeyer.Name = "lblCemiSatisDeyer";
            lblCemiSatisDeyer.Size = new Size(240, 35);
            lblCemiSatisDeyer.TabIndex = 1;
            lblCemiSatisDeyer.Text = "0.00 M";
            //
            // pnlNagdSatis - Modern statistik kart
            //
            pnlNagdSatis.BackColor = Color.White;
            pnlNagdSatis.Controls.Add(lblNagdSatisBasliq);
            pnlNagdSatis.Controls.Add(lblNagdSatisDeyer);
            pnlNagdSatis.Font = new Font("Segoe UI", 10F);
            pnlNagdSatis.ForeColor = Color.FromArgb(33, 33, 33);
            pnlNagdSatis.Location = new Point(598, 15);
            pnlNagdSatis.Name = "pnlNagdSatis";
            pnlNagdSatis.Size = new Size(270, 70);
            pnlNagdSatis.TabIndex = 2;
            pnlNagdSatis.BorderStyle = BorderStyle.None;
            //
            // lblNagdSatisBasliq
            //
            lblNagdSatisBasliq.BackColor = Color.White;
            lblNagdSatisBasliq.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblNagdSatisBasliq.ForeColor = Color.FromArgb(117, 117, 117);
            lblNagdSatisBasliq.Location = new Point(15, 10);
            lblNagdSatisBasliq.Name = "lblNagdSatisBasliq";
            lblNagdSatisBasliq.Size = new Size(240, 20);
            lblNagdSatisBasliq.TabIndex = 0;
            lblNagdSatisBasliq.Text = "NAGD SATIS";
            //
            // lblNagdSatisDeyer
            //
            lblNagdSatisDeyer.BackColor = Color.White;
            lblNagdSatisDeyer.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblNagdSatisDeyer.ForeColor = Color.FromArgb(255, 152, 0);
            lblNagdSatisDeyer.Location = new Point(15, 30);
            lblNagdSatisDeyer.Name = "lblNagdSatisDeyer";
            lblNagdSatisDeyer.Size = new Size(240, 35);
            lblNagdSatisDeyer.TabIndex = 1;
            lblNagdSatisDeyer.Text = "0.00 M";
            //
            // pnlKartSatis - Modern statistik kart
            //
            pnlKartSatis.BackColor = Color.White;
            pnlKartSatis.Controls.Add(lblKartSatisBasliq);
            pnlKartSatis.Controls.Add(lblKartSatisDeyer);
            pnlKartSatis.Font = new Font("Segoe UI", 10F);
            pnlKartSatis.ForeColor = Color.FromArgb(33, 33, 33);
            pnlKartSatis.Location = new Point(888, 15);
            pnlKartSatis.Name = "pnlKartSatis";
            pnlKartSatis.Size = new Size(270, 70);
            pnlKartSatis.TabIndex = 3;
            pnlKartSatis.BorderStyle = BorderStyle.None;
            //
            // lblKartSatisBasliq
            //
            lblKartSatisBasliq.BackColor = Color.White;
            lblKartSatisBasliq.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblKartSatisBasliq.ForeColor = Color.FromArgb(117, 117, 117);
            lblKartSatisBasliq.Location = new Point(15, 10);
            lblKartSatisBasliq.Name = "lblKartSatisBasliq";
            lblKartSatisBasliq.Size = new Size(240, 20);
            lblKartSatisBasliq.TabIndex = 0;
            lblKartSatisBasliq.Text = "KARTLA SATIS";
            //
            // lblKartSatisDeyer
            //
            lblKartSatisDeyer.BackColor = Color.White;
            lblKartSatisDeyer.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblKartSatisDeyer.ForeColor = Color.FromArgb(156, 39, 176);
            lblKartSatisDeyer.Location = new Point(15, 30);
            lblKartSatisDeyer.Name = "lblKartSatisDeyer";
            lblKartSatisDeyer.Size = new Size(240, 35);
            lblKartSatisDeyer.TabIndex = 1;
            lblKartSatisDeyer.Text = "0.00 M";
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.FromArgb(242, 242, 242);
            pnlContent.Controls.Add(dgvNovbeler);
            pnlContent.Controls.Add(pnlDetallar);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlContent.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlContent.Location = new Point(3, 224);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(15);
            pnlContent.Size = new Size(1194, 391);
            pnlContent.TabIndex = 1;
            // 
            // dgvNovbeler
            // 
            dgvNovbeler.AllowUserToAddRows = false;
            dgvNovbeler.AllowUserToDeleteRows = false;
            dgvNovbeler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNovbeler.BackgroundColor = Color.White;
            dgvNovbeler.BorderStyle = BorderStyle.None;
            dgvNovbeler.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvNovbeler.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvNovbeler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvNovbeler.ColumnHeadersHeight = 40;
            dgvNovbeler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvNovbeler.Dock = DockStyle.Fill;
            dgvNovbeler.EnableHeadersVisualStyles = false;
            dgvNovbeler.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvNovbeler.GridColor = Color.FromArgb(224, 224, 224);
            dgvNovbeler.Location = new Point(15, 15);
            dgvNovbeler.MultiSelect = false;
            dgvNovbeler.Name = "dgvNovbeler";
            dgvNovbeler.ReadOnly = true;
            dgvNovbeler.RowHeadersVisible = false;
            dgvNovbeler.RowTemplate.Height = 35;
            dgvNovbeler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNovbeler.Size = new Size(814, 361);
            dgvNovbeler.TabIndex = 0;
            // 
            // pnlDetallar
            // 
            pnlDetallar.BackColor = Color.FromArgb(242, 242, 242);
            pnlDetallar.BorderStyle = BorderStyle.FixedSingle;
            pnlDetallar.Controls.Add(lblDetallarBasliq);
            pnlDetallar.Controls.Add(pnlDetalContent);
            pnlDetallar.Dock = DockStyle.Right;
            pnlDetallar.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlDetallar.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlDetallar.Location = new Point(829, 15);
            pnlDetallar.Name = "pnlDetallar";
            pnlDetallar.Size = new Size(350, 361);
            pnlDetallar.TabIndex = 1;
            // 
            // lblDetallarBasliq
            // 
            lblDetallarBasliq.BackColor = Color.FromArgb(242, 242, 242);
            lblDetallarBasliq.Depth = 0;
            lblDetallarBasliq.Dock = DockStyle.Top;
            lblDetallarBasliq.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblDetallarBasliq.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblDetallarBasliq.Location = new Point(0, 0);
            lblDetallarBasliq.MouseState = MaterialSkin.MouseState.HOVER;
            lblDetallarBasliq.Name = "lblDetallarBasliq";
            lblDetallarBasliq.Size = new Size(348, 35);
            lblDetallarBasliq.TabIndex = 0;
            lblDetallarBasliq.Text = "   Hesabat Detalları";
            lblDetallarBasliq.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlDetalContent
            // 
            pnlDetalContent.AutoScroll = true;
            pnlDetalContent.BackColor = Color.FromArgb(242, 242, 242);
            pnlDetalContent.Controls.Add(lblAcilisTarixi);
            pnlDetalContent.Controls.Add(lblAcilisTarixiDeyer);
            pnlDetalContent.Controls.Add(lblBaglanmaTarixi);
            pnlDetalContent.Controls.Add(lblBaglanmaTarixiDeyer);
            pnlDetalContent.Controls.Add(lblKassir);
            pnlDetalContent.Controls.Add(lblKassirDeyer);
            pnlDetalContent.Controls.Add(lblBaslangicMebleg);
            pnlDetalContent.Controls.Add(lblBaslangicMeblegDeyer);
            pnlDetalContent.Controls.Add(lblSatisSayi);
            pnlDetalContent.Controls.Add(lblSatisSayiDeyer);
            pnlDetalContent.Controls.Add(lblGozlenilenMebleg);
            pnlDetalContent.Controls.Add(lblGozlenilenMeblegDeyer);
            pnlDetalContent.Controls.Add(lblFaktikiMebleg);
            pnlDetalContent.Controls.Add(lblFaktikiMeblegDeyer);
            pnlDetalContent.Controls.Add(lblFerq);
            pnlDetalContent.Controls.Add(lblFerqDeyer);
            pnlDetalContent.Dock = DockStyle.Fill;
            pnlDetalContent.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlDetalContent.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlDetalContent.Location = new Point(0, 0);
            pnlDetalContent.Name = "pnlDetalContent";
            pnlDetalContent.Padding = new Padding(10);
            pnlDetalContent.Size = new Size(348, 359);
            pnlDetalContent.TabIndex = 1;
            //
            // lblAcilisTarixi
            //
            lblAcilisTarixi.BackColor = Color.FromArgb(242, 242, 242);
            lblAcilisTarixi.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblAcilisTarixi.ForeColor = Color.FromArgb(117, 117, 117);
            lblAcilisTarixi.Location = new Point(10, 45);
            lblAcilisTarixi.Name = "lblAcilisTarixi";
            lblAcilisTarixi.Size = new Size(140, 25);
            lblAcilisTarixi.TabIndex = 0;
            lblAcilisTarixi.Text = "Acilis Tarixi:";
            lblAcilisTarixi.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblAcilisTarixiDeyer
            //
            lblAcilisTarixiDeyer.BackColor = Color.FromArgb(242, 242, 242);
            lblAcilisTarixiDeyer.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblAcilisTarixiDeyer.ForeColor = Color.FromArgb(33, 33, 33);
            lblAcilisTarixiDeyer.Location = new Point(155, 45);
            lblAcilisTarixiDeyer.Name = "lblAcilisTarixiDeyer";
            lblAcilisTarixiDeyer.Size = new Size(180, 25);
            lblAcilisTarixiDeyer.TabIndex = 1;
            lblAcilisTarixiDeyer.Text = "-";
            lblAcilisTarixiDeyer.TextAlign = ContentAlignment.MiddleRight;
            //
            // lblBaglanmaTarixi
            //
            lblBaglanmaTarixi.BackColor = Color.FromArgb(242, 242, 242);
            lblBaglanmaTarixi.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblBaglanmaTarixi.ForeColor = Color.FromArgb(117, 117, 117);
            lblBaglanmaTarixi.Location = new Point(10, 75);
            lblBaglanmaTarixi.Name = "lblBaglanmaTarixi";
            lblBaglanmaTarixi.Size = new Size(140, 25);
            lblBaglanmaTarixi.TabIndex = 2;
            lblBaglanmaTarixi.Text = "Baglanma Tarixi:";
            lblBaglanmaTarixi.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblBaglanmaTarixiDeyer
            //
            lblBaglanmaTarixiDeyer.BackColor = Color.FromArgb(242, 242, 242);
            lblBaglanmaTarixiDeyer.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblBaglanmaTarixiDeyer.ForeColor = Color.FromArgb(33, 33, 33);
            lblBaglanmaTarixiDeyer.Location = new Point(155, 75);
            lblBaglanmaTarixiDeyer.Name = "lblBaglanmaTarixiDeyer";
            lblBaglanmaTarixiDeyer.Size = new Size(180, 25);
            lblBaglanmaTarixiDeyer.TabIndex = 3;
            lblBaglanmaTarixiDeyer.Text = "-";
            lblBaglanmaTarixiDeyer.TextAlign = ContentAlignment.MiddleRight;
            //
            // lblKassir
            //
            lblKassir.BackColor = Color.FromArgb(242, 242, 242);
            lblKassir.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblKassir.ForeColor = Color.FromArgb(117, 117, 117);
            lblKassir.Location = new Point(10, 105);
            lblKassir.Name = "lblKassir";
            lblKassir.Size = new Size(140, 25);
            lblKassir.TabIndex = 4;
            lblKassir.Text = "Kassir:";
            lblKassir.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblKassirDeyer
            //
            lblKassirDeyer.BackColor = Color.FromArgb(242, 242, 242);
            lblKassirDeyer.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblKassirDeyer.ForeColor = Color.FromArgb(33, 33, 33);
            lblKassirDeyer.Location = new Point(155, 105);
            lblKassirDeyer.Name = "lblKassirDeyer";
            lblKassirDeyer.Size = new Size(180, 25);
            lblKassirDeyer.TabIndex = 5;
            lblKassirDeyer.Text = "-";
            lblKassirDeyer.TextAlign = ContentAlignment.MiddleRight;
            //
            // lblBaslangicMebleg
            //
            lblBaslangicMebleg.BackColor = Color.FromArgb(242, 242, 242);
            lblBaslangicMebleg.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblBaslangicMebleg.ForeColor = Color.FromArgb(117, 117, 117);
            lblBaslangicMebleg.Location = new Point(10, 145);
            lblBaslangicMebleg.Name = "lblBaslangicMebleg";
            lblBaslangicMebleg.Size = new Size(140, 25);
            lblBaslangicMebleg.TabIndex = 6;
            lblBaslangicMebleg.Text = "Baslangic Mebleg:";
            lblBaslangicMebleg.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblBaslangicMeblegDeyer
            //
            lblBaslangicMeblegDeyer.BackColor = Color.FromArgb(242, 242, 242);
            lblBaslangicMeblegDeyer.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblBaslangicMeblegDeyer.ForeColor = Color.FromArgb(33, 33, 33);
            lblBaslangicMeblegDeyer.Location = new Point(155, 145);
            lblBaslangicMeblegDeyer.Name = "lblBaslangicMeblegDeyer";
            lblBaslangicMeblegDeyer.Size = new Size(180, 25);
            lblBaslangicMeblegDeyer.TabIndex = 7;
            lblBaslangicMeblegDeyer.Text = "0.00 M";
            lblBaslangicMeblegDeyer.TextAlign = ContentAlignment.MiddleRight;
            //
            // lblSatisSayi
            //
            lblSatisSayi.BackColor = Color.FromArgb(242, 242, 242);
            lblSatisSayi.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblSatisSayi.ForeColor = Color.FromArgb(117, 117, 117);
            lblSatisSayi.Location = new Point(10, 175);
            lblSatisSayi.Name = "lblSatisSayi";
            lblSatisSayi.Size = new Size(140, 25);
            lblSatisSayi.TabIndex = 8;
            lblSatisSayi.Text = "Satis Sayi:";
            lblSatisSayi.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblSatisSayiDeyer
            //
            lblSatisSayiDeyer.BackColor = Color.FromArgb(242, 242, 242);
            lblSatisSayiDeyer.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblSatisSayiDeyer.ForeColor = Color.FromArgb(33, 33, 33);
            lblSatisSayiDeyer.Location = new Point(155, 175);
            lblSatisSayiDeyer.Name = "lblSatisSayiDeyer";
            lblSatisSayiDeyer.Size = new Size(180, 25);
            lblSatisSayiDeyer.TabIndex = 9;
            lblSatisSayiDeyer.Text = "0";
            lblSatisSayiDeyer.TextAlign = ContentAlignment.MiddleRight;
            //
            // lblGozlenilenMebleg
            //
            lblGozlenilenMebleg.BackColor = Color.FromArgb(242, 242, 242);
            lblGozlenilenMebleg.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblGozlenilenMebleg.ForeColor = Color.FromArgb(117, 117, 117);
            lblGozlenilenMebleg.Location = new Point(10, 215);
            lblGozlenilenMebleg.Name = "lblGozlenilenMebleg";
            lblGozlenilenMebleg.Size = new Size(140, 25);
            lblGozlenilenMebleg.TabIndex = 10;
            lblGozlenilenMebleg.Text = "Gozlenilen Mebleg:";
            lblGozlenilenMebleg.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblGozlenilenMeblegDeyer
            //
            lblGozlenilenMeblegDeyer.BackColor = Color.FromArgb(242, 242, 242);
            lblGozlenilenMeblegDeyer.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblGozlenilenMeblegDeyer.ForeColor = Color.FromArgb(33, 33, 33);
            lblGozlenilenMeblegDeyer.Location = new Point(155, 215);
            lblGozlenilenMeblegDeyer.Name = "lblGozlenilenMeblegDeyer";
            lblGozlenilenMeblegDeyer.Size = new Size(180, 25);
            lblGozlenilenMeblegDeyer.TabIndex = 11;
            lblGozlenilenMeblegDeyer.Text = "0.00 M";
            lblGozlenilenMeblegDeyer.TextAlign = ContentAlignment.MiddleRight;
            //
            // lblFaktikiMebleg
            //
            lblFaktikiMebleg.BackColor = Color.FromArgb(242, 242, 242);
            lblFaktikiMebleg.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblFaktikiMebleg.ForeColor = Color.FromArgb(117, 117, 117);
            lblFaktikiMebleg.Location = new Point(10, 245);
            lblFaktikiMebleg.Name = "lblFaktikiMebleg";
            lblFaktikiMebleg.Size = new Size(140, 25);
            lblFaktikiMebleg.TabIndex = 12;
            lblFaktikiMebleg.Text = "Faktiki Mebleg:";
            lblFaktikiMebleg.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblFaktikiMeblegDeyer
            //
            lblFaktikiMeblegDeyer.BackColor = Color.FromArgb(242, 242, 242);
            lblFaktikiMeblegDeyer.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lblFaktikiMeblegDeyer.ForeColor = Color.FromArgb(33, 33, 33);
            lblFaktikiMeblegDeyer.Location = new Point(155, 245);
            lblFaktikiMeblegDeyer.Name = "lblFaktikiMeblegDeyer";
            lblFaktikiMeblegDeyer.Size = new Size(180, 25);
            lblFaktikiMeblegDeyer.TabIndex = 13;
            lblFaktikiMeblegDeyer.Text = "0.00 M";
            lblFaktikiMeblegDeyer.TextAlign = ContentAlignment.MiddleRight;
            //
            // lblFerq
            //
            lblFerq.BackColor = Color.FromArgb(232, 245, 233);
            lblFerq.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblFerq.ForeColor = Color.FromArgb(33, 33, 33);
            lblFerq.Location = new Point(10, 285);
            lblFerq.Name = "lblFerq";
            lblFerq.Size = new Size(140, 30);
            lblFerq.TabIndex = 14;
            lblFerq.Text = "FERQ:";
            lblFerq.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblFerqDeyer
            //
            lblFerqDeyer.BackColor = Color.FromArgb(232, 245, 233);
            lblFerqDeyer.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblFerqDeyer.ForeColor = Color.FromArgb(76, 175, 80);
            lblFerqDeyer.Location = new Point(155, 285);
            lblFerqDeyer.Name = "lblFerqDeyer";
            lblFerqDeyer.Size = new Size(180, 30);
            lblFerqDeyer.TabIndex = 15;
            lblFerqDeyer.Text = "0.00 M";
            lblFerqDeyer.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblNagdSatisDetalDeyer
            // 
            lblNagdSatisDetalDeyer.Location = new Point(0, 0);
            lblNagdSatisDetalDeyer.Name = "lblNagdSatisDetalDeyer";
            lblNagdSatisDetalDeyer.Size = new Size(100, 23);
            lblNagdSatisDetalDeyer.TabIndex = 0;
            // 
            // lblKartSatisDetalDeyer
            // 
            lblKartSatisDetalDeyer.Location = new Point(0, 0);
            lblKartSatisDetalDeyer.Name = "lblKartSatisDetalDeyer";
            lblKartSatisDetalDeyer.Size = new Size(100, 23);
            lblKartSatisDetalDeyer.TabIndex = 0;
            // 
            // lblCemiSatisDetalDeyer
            // 
            lblCemiSatisDetalDeyer.Location = new Point(0, 0);
            lblCemiSatisDetalDeyer.Name = "lblCemiSatisDetalDeyer";
            lblCemiSatisDetalDeyer.Size = new Size(100, 23);
            lblCemiSatisDetalDeyer.TabIndex = 0;
            // 
            // pnlButtons
            // 
            pnlButtons.BackColor = Color.FromArgb(242, 242, 242);
            pnlButtons.Controls.Add(btnCap);
            pnlButtons.Controls.Add(btnGoster);
            pnlButtons.Dock = DockStyle.Bottom;
            pnlButtons.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlButtons.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlButtons.Location = new Point(3, 615);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Padding = new Padding(15);
            pnlButtons.Size = new Size(1194, 60);
            pnlButtons.TabIndex = 4;
            // 
            // btnCap
            // 
            btnCap.Anchor = AnchorStyles.Right;
            btnCap.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCap.BackColor = Color.FromArgb(242, 242, 242);
            btnCap.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnCap.Depth = 0;
            btnCap.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnCap.HighEmphasis = true;
            btnCap.Icon = null;
            btnCap.Location = new Point(1109, 12);
            btnCap.Margin = new Padding(4, 6, 4, 6);
            btnCap.MouseState = MaterialSkin.MouseState.HOVER;
            btnCap.Name = "btnCap";
            btnCap.NoAccentTextColor = Color.Empty;
            btnCap.Size = new Size(71, 36);
            btnCap.TabIndex = 0;
            btnCap.Text = "Çap Et";
            btnCap.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnCap.UseAccentColor = true;
            btnCap.UseVisualStyleBackColor = false;
            // 
            // btnGoster
            // 
            btnGoster.Anchor = AnchorStyles.Right;
            btnGoster.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnGoster.BackColor = Color.FromArgb(242, 242, 242);
            btnGoster.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnGoster.Depth = 0;
            btnGoster.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnGoster.HighEmphasis = false;
            btnGoster.Icon = null;
            btnGoster.Location = new Point(868, 12);
            btnGoster.Margin = new Padding(4, 6, 4, 6);
            btnGoster.MouseState = MaterialSkin.MouseState.HOVER;
            btnGoster.Name = "btnGoster";
            btnGoster.NoAccentTextColor = Color.Empty;
            btnGoster.Size = new Size(152, 36);
            btnGoster.TabIndex = 1;
            btnGoster.Text = "Hesabatı Göstər";
            btnGoster.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnGoster.UseAccentColor = false;
            btnGoster.UseVisualStyleBackColor = false;
            // 
            // ZHesabatArxivFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 700);
            Controls.Add(pnlContent);
            Controls.Add(pnlXulase);
            Controls.Add(pnlFiltr);
            Controls.Add(pnlButtons);
            Name = "ZHesabatArxivFormu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Z-Hesabat Arxivi";
            Load += ZHesabatArxivFormu_Load;
            Controls.SetChildIndex(pnlButtons, 0);
            Controls.SetChildIndex(pnlFiltr, 0);
            Controls.SetChildIndex(pnlXulase, 0);
            Controls.SetChildIndex(pnlContent, 0);
            pnlFiltr.ResumeLayout(false);
            pnlFiltr.PerformLayout();
            pnlXulase.ResumeLayout(false);
            pnlNovbeSayi.ResumeLayout(false);
            pnlCemiSatis.ResumeLayout(false);
            pnlNagdSatis.ResumeLayout(false);
            pnlKartSatis.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNovbeler).EndInit();
            pnlDetallar.ResumeLayout(false);
            pnlDetalContent.ResumeLayout(false);
            pnlButtons.ResumeLayout(false);
            pnlButtons.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void SetupDetalLabel(Label lbl, string text, int top)
        {
            lbl.AutoSize = false;
            lbl.Font = new Font("Segoe UI", 9F);
            lbl.ForeColor = Color.FromArgb(117, 117, 117);
            lbl.Location = new Point(10, top);
            lbl.Size = new Size(150, 25);
            lbl.Text = text;
            lbl.TextAlign = ContentAlignment.MiddleLeft;
        }

        private void SetupDetalValueLabel(Label lbl, string text, int top)
        {
            lbl.AutoSize = false;
            lbl.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            lbl.ForeColor = Color.FromArgb(33, 33, 33);
            lbl.Location = new Point(160, top);
            lbl.Size = new Size(175, 25);
            lbl.Text = text;
            lbl.TextAlign = ContentAlignment.MiddleRight;
        }

        #endregion

        // Filtr
        private Panel pnlFiltr;
        private MaterialSkin.Controls.MaterialLabel lblBaslangicTarixi;
        private DateTimePicker dtpBaslangic;
        private MaterialSkin.Controls.MaterialLabel lblBitisTarixi;
        private DateTimePicker dtpBitis;
        private MaterialSkin.Controls.MaterialButton btnFiltrle;

        // Xülasə kartları
        private Panel pnlXulase;
        private Panel pnlNovbeSayi;
        private Label lblNovbeSayiBasliq;
        private Label lblNovbeSayiDeyer;
        private Panel pnlCemiSatis;
        private Label lblCemiSatisBasliq;
        private Label lblCemiSatisDeyer;
        private Panel pnlNagdSatis;
        private Label lblNagdSatisBasliq;
        private Label lblNagdSatisDeyer;
        private Panel pnlKartSatis;
        private Label lblKartSatisBasliq;
        private Label lblKartSatisDeyer;

        // Content
        private Panel pnlContent;
        private DataGridView dgvNovbeler;
        private Panel pnlDetallar;
        private MaterialSkin.Controls.MaterialLabel lblDetallarBasliq;
        private Panel pnlDetalContent;
        private Label lblAcilisTarixi;
        private Label lblAcilisTarixiDeyer;
        private Label lblBaglanmaTarixi;
        private Label lblBaglanmaTarixiDeyer;
        private Label lblKassir;
        private Label lblKassirDeyer;
        private Label lblBaslangicMebleg;
        private Label lblBaslangicMeblegDeyer;
        private Label lblSatisSayi;
        private Label lblSatisSayiDeyer;
        private Label lblNagdSatisDetalDeyer;
        private Label lblKartSatisDetalDeyer;
        private Label lblCemiSatisDetalDeyer;
        private Label lblGozlenilenMebleg;
        private Label lblGozlenilenMeblegDeyer;
        private Label lblFaktikiMebleg;
        private Label lblFaktikiMeblegDeyer;
        private Label lblFerq;
        private Label lblFerqDeyer;

        // Buttons
        private Panel pnlButtons;
        private MaterialSkin.Controls.MaterialButton btnGoster;
        private MaterialSkin.Controls.MaterialButton btnCap;
    }
}
