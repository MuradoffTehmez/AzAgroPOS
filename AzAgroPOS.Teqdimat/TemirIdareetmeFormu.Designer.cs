namespace AzAgroPOS.Teqdimat
{
    partial class TemirIdareetmeFormu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlTop = new Panel();
            lblBaslik = new Label();
            pnlMain = new Panel();
            splitContainer1 = new SplitContainer();
            grpSifarisMelumatlari = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblMusteriAdi = new Label();
            txtMusteriAdi = new TextBox();
            lblMusteriTelefonu = new Label();
            txtMusteriTelefonu = new TextBox();
            lblCihazAdi = new Label();
            txtCihazAdi = new TextBox();
            lblProblemTesviri = new Label();
            txtProblemTesviri = new TextBox();
            lblYekunMebleg = new Label();
            txtYekunMebleg = new TextBox();
            lblSeriyaNomresi = new Label();
            txtSeriyaNomresi = new TextBox();
            lblTemirXerci = new Label();
            txtTemirXerci = new TextBox();
            lblServisHaqqi = new Label();
            txtServisHaqqi = new TextBox();
            lblUsta = new Label();
            cmbUsta = new ComboBox();
            btnEhtiyatHissəsiElaveEt = new Button();
            btnÖdənişiTamamla = new Button();
            pnlDugmeler = new Panel();
            btnTemizle = new Button();
            btnSil = new Button();
            btnYenile = new Button();
            btnYarat = new Button();
            grpSifarisler = new GroupBox();
            dgvSifarisler = new DataGridView();
            pnlTop.SuspendLayout();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            grpSifarisMelumatlari.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            pnlDugmeler.SuspendLayout();
            grpSifarisler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSifarisler).BeginInit();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(242, 242, 242);
            pnlTop.Controls.Add(lblBaslik);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlTop.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlTop.Location = new Point(3, 64);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(994, 60);
            pnlTop.TabIndex = 0;
            // 
            // lblBaslik
            // 
            lblBaslik.BackColor = Color.FromArgb(242, 242, 242);
            lblBaslik.Dock = DockStyle.Fill;
            lblBaslik.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblBaslik.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblBaslik.Location = new Point(0, 0);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(994, 60);
            lblBaslik.TabIndex = 0;
            lblBaslik.Text = "Təmir İdarəetmə";
            lblBaslik.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(242, 242, 242);
            pnlMain.Controls.Add(splitContainer1);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlMain.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlMain.Location = new Point(3, 124);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(10);
            pnlMain.Size = new Size(994, 533);
            pnlMain.TabIndex = 1;
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = Color.FromArgb(242, 242, 242);
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            splitContainer1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            splitContainer1.Location = new Point(10, 10);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.FromArgb(242, 242, 242);
            splitContainer1.Panel1.Controls.Add(grpSifarisMelumatlari);
            splitContainer1.Panel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            splitContainer1.Panel1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            splitContainer1.Panel1MinSize = 300;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.FromArgb(242, 242, 242);
            splitContainer1.Panel2.Controls.Add(grpSifarisler);
            splitContainer1.Panel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            splitContainer1.Panel2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            splitContainer1.Size = new Size(974, 513);
            splitContainer1.SplitterDistance = 347;
            splitContainer1.TabIndex = 0;
            // 
            // grpSifarisMelumatlari
            // 
            grpSifarisMelumatlari.BackColor = Color.FromArgb(242, 242, 242);
            grpSifarisMelumatlari.Controls.Add(tableLayoutPanel1);
            grpSifarisMelumatlari.Controls.Add(pnlDugmeler);
            grpSifarisMelumatlari.Dock = DockStyle.Fill;
            grpSifarisMelumatlari.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            grpSifarisMelumatlari.ForeColor = Color.FromArgb(222, 0, 0, 0);
            grpSifarisMelumatlari.Location = new Point(0, 0);
            grpSifarisMelumatlari.Name = "grpSifarisMelumatlari";
            grpSifarisMelumatlari.Size = new Size(347, 513);
            grpSifarisMelumatlari.TabIndex = 0;
            grpSifarisMelumatlari.TabStop = false;
            grpSifarisMelumatlari.Text = "Sifariş Məlumatları";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.FromArgb(242, 242, 242);
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.Controls.Add(lblMusteriAdi, 0, 0);
            tableLayoutPanel1.Controls.Add(txtMusteriAdi, 1, 0);
            tableLayoutPanel1.Controls.Add(lblMusteriTelefonu, 0, 1);
            tableLayoutPanel1.Controls.Add(txtMusteriTelefonu, 1, 1);
            tableLayoutPanel1.Controls.Add(lblCihazAdi, 0, 2);
            tableLayoutPanel1.Controls.Add(txtCihazAdi, 1, 2);
            tableLayoutPanel1.Controls.Add(lblSeriyaNomresi, 0, 3);
            tableLayoutPanel1.Controls.Add(txtSeriyaNomresi, 1, 3);
            tableLayoutPanel1.Controls.Add(lblProblemTesviri, 0, 4);
            tableLayoutPanel1.Controls.Add(txtProblemTesviri, 1, 4);
            tableLayoutPanel1.Controls.Add(lblTemirXerci, 0, 5);
            tableLayoutPanel1.Controls.Add(txtTemirXerci, 1, 5);
            tableLayoutPanel1.Controls.Add(lblServisHaqqi, 0, 6);
            tableLayoutPanel1.Controls.Add(txtServisHaqqi, 1, 6);
            tableLayoutPanel1.Controls.Add(lblYekunMebleg, 0, 7);
            tableLayoutPanel1.Controls.Add(txtYekunMebleg, 1, 7);
            tableLayoutPanel1.Controls.Add(lblUsta, 0, 8);
            tableLayoutPanel1.Controls.Add(cmbUsta, 1, 8);
            tableLayoutPanel1.Controls.Add(btnEhtiyatHissəsiElaveEt, 1, 9);
            tableLayoutPanel1.Controls.Add(btnÖdənişiTamamla, 1, 10);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            tableLayoutPanel1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            tableLayoutPanel1.Location = new Point(3, 20);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 12;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(341, 419);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblMusteriAdi
            // 
            lblMusteriAdi.AutoSize = true;
            lblMusteriAdi.BackColor = Color.FromArgb(242, 242, 242);
            lblMusteriAdi.Dock = DockStyle.Fill;
            lblMusteriAdi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblMusteriAdi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblMusteriAdi.Location = new Point(3, 0);
            lblMusteriAdi.Name = "lblMusteriAdi";
            lblMusteriAdi.Size = new Size(96, 35);
            lblMusteriAdi.TabIndex = 0;
            lblMusteriAdi.Text = "Müştəri Adı:";
            lblMusteriAdi.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtMusteriAdi
            // 
            txtMusteriAdi.BackColor = Color.FromArgb(242, 242, 242);
            txtMusteriAdi.Dock = DockStyle.Fill;
            txtMusteriAdi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtMusteriAdi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtMusteriAdi.Location = new Point(105, 3);
            txtMusteriAdi.Name = "txtMusteriAdi";
            txtMusteriAdi.Size = new Size(233, 24);
            txtMusteriAdi.TabIndex = 1;
            // 
            // lblMusteriTelefonu
            // 
            lblMusteriTelefonu.AutoSize = true;
            lblMusteriTelefonu.BackColor = Color.FromArgb(242, 242, 242);
            lblMusteriTelefonu.Dock = DockStyle.Fill;
            lblMusteriTelefonu.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblMusteriTelefonu.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblMusteriTelefonu.Location = new Point(3, 35);
            lblMusteriTelefonu.Name = "lblMusteriTelefonu";
            lblMusteriTelefonu.Size = new Size(96, 35);
            lblMusteriTelefonu.TabIndex = 2;
            lblMusteriTelefonu.Text = "Telefon Nömrəsi:";
            lblMusteriTelefonu.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtMusteriTelefonu
            // 
            txtMusteriTelefonu.BackColor = Color.FromArgb(242, 242, 242);
            txtMusteriTelefonu.Dock = DockStyle.Fill;
            txtMusteriTelefonu.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtMusteriTelefonu.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtMusteriTelefonu.Location = new Point(105, 38);
            txtMusteriTelefonu.Name = "txtMusteriTelefonu";
            txtMusteriTelefonu.Size = new Size(233, 24);
            txtMusteriTelefonu.TabIndex = 3;
            // 
            // lblCihazAdi
            // 
            lblCihazAdi.AutoSize = true;
            lblCihazAdi.BackColor = Color.FromArgb(242, 242, 242);
            lblCihazAdi.Dock = DockStyle.Fill;
            lblCihazAdi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblCihazAdi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblCihazAdi.Location = new Point(3, 70);
            lblCihazAdi.Name = "lblCihazAdi";
            lblCihazAdi.Size = new Size(96, 35);
            lblCihazAdi.TabIndex = 4;
            lblCihazAdi.Text = "Cihaz Adı:";
            lblCihazAdi.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtCihazAdi
            // 
            txtCihazAdi.BackColor = Color.FromArgb(242, 242, 242);
            txtCihazAdi.Dock = DockStyle.Fill;
            txtCihazAdi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtCihazAdi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtCihazAdi.Location = new Point(105, 73);
            txtCihazAdi.Name = "txtCihazAdi";
            txtCihazAdi.Size = new Size(233, 24);
            txtCihazAdi.TabIndex = 5;
            // 
            // lblSeriyaNomresi
            // 
            lblSeriyaNomresi.AutoSize = true;
            lblSeriyaNomresi.BackColor = Color.FromArgb(242, 242, 242);
            lblSeriyaNomresi.Dock = DockStyle.Fill;
            lblSeriyaNomresi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSeriyaNomresi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblSeriyaNomresi.Location = new Point(3, 105);
            lblSeriyaNomresi.Name = "lblSeriyaNomresi";
            lblSeriyaNomresi.Size = new Size(96, 35);
            lblSeriyaNomresi.TabIndex = 18;
            lblSeriyaNomresi.Text = "Seriya Nömrəsi:";
            lblSeriyaNomresi.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtSeriyaNomresi
            // 
            txtSeriyaNomresi.BackColor = Color.FromArgb(242, 242, 242);
            txtSeriyaNomresi.Dock = DockStyle.Fill;
            txtSeriyaNomresi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtSeriyaNomresi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtSeriyaNomresi.Location = new Point(105, 108);
            txtSeriyaNomresi.Name = "txtSeriyaNomresi";
            txtSeriyaNomresi.Size = new Size(233, 24);
            txtSeriyaNomresi.TabIndex = 19;
            // 
            // lblProblemTesviri
            // 
            lblProblemTesviri.AutoSize = true;
            lblProblemTesviri.BackColor = Color.FromArgb(242, 242, 242);
            lblProblemTesviri.Dock = DockStyle.Fill;
            lblProblemTesviri.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblProblemTesviri.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblProblemTesviri.Location = new Point(3, 140);
            lblProblemTesviri.Name = "lblProblemTesviri";
            lblProblemTesviri.Size = new Size(96, 100);
            lblProblemTesviri.TabIndex = 6;
            lblProblemTesviri.Text = "Problem Təsviri:";
            lblProblemTesviri.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtProblemTesviri
            // 
            txtProblemTesviri.BackColor = Color.FromArgb(242, 242, 242);
            txtProblemTesviri.Dock = DockStyle.Fill;
            txtProblemTesviri.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtProblemTesviri.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtProblemTesviri.Location = new Point(105, 143);
            txtProblemTesviri.Multiline = true;
            txtProblemTesviri.Name = "txtProblemTesviri";
            txtProblemTesviri.ScrollBars = ScrollBars.Vertical;
            txtProblemTesviri.Size = new Size(233, 94);
            txtProblemTesviri.TabIndex = 7;
            // 
            // lblYekunMebleg
            // 
            lblYekunMebleg.AutoSize = true;
            lblYekunMebleg.BackColor = Color.FromArgb(242, 242, 242);
            lblYekunMebleg.Dock = DockStyle.Fill;
            lblYekunMebleg.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblYekunMebleg.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblYekunMebleg.Location = new Point(3, 205);
            lblYekunMebleg.Name = "lblYekunMebleg";
            lblYekunMebleg.Size = new Size(96, 35);
            lblYekunMebleg.TabIndex = 8;
            lblYekunMebleg.Text = "Yekun Məbləğ:";
            lblYekunMebleg.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTemirXerci
            // 
            lblTemirXerci.AutoSize = true;
            lblTemirXerci.BackColor = Color.FromArgb(242, 242, 242);
            lblTemirXerci.Dock = DockStyle.Fill;
            lblTemirXerci.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblTemirXerci.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblTemirXerci.Location = new Point(3, 205);
            lblTemirXerci.Name = "lblTemirXerci";
            lblTemirXerci.Size = new Size(96, 35);
            lblTemirXerci.TabIndex = 10;
            lblTemirXerci.Text = "Təmir Xərci:";
            lblTemirXerci.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtTemirXerci
            // 
            txtTemirXerci.BackColor = Color.FromArgb(242, 242, 242);
            txtTemirXerci.Dock = DockStyle.Fill;
            txtTemirXerci.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtTemirXerci.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtTemirXerci.Location = new Point(105, 208);
            txtTemirXerci.Name = "txtTemirXerci";
            txtTemirXerci.Size = new Size(233, 24);
            txtTemirXerci.TabIndex = 11;
            txtTemirXerci.TextChanged += txtTemirXerci_TextChanged;
            // 
            // lblServisHaqqi
            // 
            lblServisHaqqi.AutoSize = true;
            lblServisHaqqi.BackColor = Color.FromArgb(242, 242, 242);
            lblServisHaqqi.Dock = DockStyle.Fill;
            lblServisHaqqi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblServisHaqqi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblServisHaqqi.Location = new Point(3, 240);
            lblServisHaqqi.Name = "lblServisHaqqi";
            lblServisHaqqi.Size = new Size(96, 35);
            lblServisHaqqi.TabIndex = 12;
            lblServisHaqqi.Text = "Servis Haqqı:";
            lblServisHaqqi.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtServisHaqqi
            // 
            txtServisHaqqi.BackColor = Color.FromArgb(242, 242, 242);
            txtServisHaqqi.Dock = DockStyle.Fill;
            txtServisHaqqi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtServisHaqqi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtServisHaqqi.Location = new Point(105, 243);
            txtServisHaqqi.Name = "txtServisHaqqi";
            txtServisHaqqi.Size = new Size(233, 24);
            txtServisHaqqi.TabIndex = 13;
            txtServisHaqqi.TextChanged += txtServisHaqqi_TextChanged;
            // 
            // lblYekunMebleg
            // 
            lblYekunMebleg.AutoSize = true;
            lblYekunMebleg.BackColor = Color.FromArgb(242, 242, 242);
            lblYekunMebleg.Dock = DockStyle.Fill;
            lblYekunMebleg.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblYekunMebleg.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblYekunMebleg.Location = new Point(3, 275);
            lblYekunMebleg.Name = "lblYekunMebleg";
            lblYekunMebleg.Size = new Size(96, 35);
            lblYekunMebleg.TabIndex = 8;
            lblYekunMebleg.Text = "Yekun Məbləğ:";
            lblYekunMebleg.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtYekunMebleg
            // 
            txtYekunMebleg.BackColor = Color.FromArgb(242, 242, 242);
            txtYekunMebleg.Dock = DockStyle.Fill;
            txtYekunMebleg.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtYekunMebleg.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtYekunMebleg.Location = new Point(105, 278);
            txtYekunMebleg.Name = "txtYekunMebleg";
            txtYekunMebleg.ReadOnly = true;
            txtYekunMebleg.Size = new Size(233, 24);
            txtYekunMebleg.TabIndex = 9;
            // 
            // btnEhtiyatHissəsiElaveEt
            // 
            btnEhtiyatHissəsiElaveEt.BackColor = Color.FromArgb(242, 242, 242);
            btnEhtiyatHissəsiElaveEt.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            btnEhtiyatHissəsiElaveEt.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnEhtiyatHissəsiElaveEt.Location = new Point(105, 313);
            btnEhtiyatHissəsiElaveEt.Name = "btnEhtiyatHissəsiElaveEt";
            btnEhtiyatHissəsiElaveEt.Size = new Size(233, 29);
            btnEhtiyatHissəsiElaveEt.TabIndex = 14;
            btnEhtiyatHissəsiElaveEt.Text = "Ehtiyat Hissəsi Əlavə Et";
            btnEhtiyatHissəsiElaveEt.UseVisualStyleBackColor = false;
            btnEhtiyatHissəsiElaveEt.Click += btnEhtiyatHissəsiElaveEt_Click;
            // 
            // lblUsta
            // 
            lblUsta.AutoSize = true;
            lblUsta.BackColor = Color.FromArgb(242, 242, 242);
            lblUsta.Dock = DockStyle.Fill;
            lblUsta.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblUsta.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblUsta.Location = new Point(3, 310);
            lblUsta.Name = "lblUsta";
            lblUsta.Size = new Size(96, 35);
            lblUsta.TabIndex = 16;
            lblUsta.Text = "Usta:";
            lblUsta.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbUsta
            // 
            cmbUsta.BackColor = Color.FromArgb(242, 242, 242);
            cmbUsta.Dock = DockStyle.Fill;
            cmbUsta.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            cmbUsta.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbUsta.FormattingEnabled = true;
            cmbUsta.Location = new Point(105, 313);
            cmbUsta.Name = "cmbUsta";
            cmbUsta.Size = new Size(233, 25);
            cmbUsta.TabIndex = 17;
            // 
            // btnEhtiyatHissəsiElaveEt
            // 
            btnEhtiyatHissəsiElaveEt.BackColor = Color.FromArgb(242, 242, 242);
            btnEhtiyatHissəsiElaveEt.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            btnEhtiyatHissəsiElaveEt.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnEhtiyatHissəsiElaveEt.Location = new Point(105, 348);
            btnEhtiyatHissəsiElaveEt.Name = "btnEhtiyatHissəsiElaveEt";
            btnEhtiyatHissəsiElaveEt.Size = new Size(233, 29);
            btnEhtiyatHissəsiElaveEt.TabIndex = 14;
            btnEhtiyatHissəsiElaveEt.Text = "Ehtiyat Hissəsi Əlavə Et";
            btnEhtiyatHissəsiElaveEt.UseVisualStyleBackColor = false;
            btnEhtiyatHissəsiElaveEt.Click += btnEhtiyatHissəsiElaveEt_Click;
            // 
            // btnÖdənişiTamamla
            // 
            btnÖdənişiTamamla.BackColor = Color.FromArgb(242, 242, 242);
            btnÖdənişiTamamla.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            btnÖdənişiTamamla.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnÖdənişiTamamla.Location = new Point(105, 383);
            btnÖdənişiTamamla.Name = "btnÖdənişiTamamla";
            btnÖdənişiTamamla.Size = new Size(233, 29);
            btnÖdənişiTamamla.TabIndex = 15;
            btnÖdənişiTamamla.Text = "Ödənişi Tamamla";
            btnÖdənişiTamamla.UseVisualStyleBackColor = false;
            btnÖdənişiTamamla.Click += btnÖdənişiTamamla_Click;
            // 
            // pnlDugmeler
            // 
            pnlDugmeler.BackColor = Color.FromArgb(242, 242, 242);
            pnlDugmeler.Controls.Add(btnTemizle);
            pnlDugmeler.Controls.Add(btnSil);
            pnlDugmeler.Controls.Add(btnYenile);
            pnlDugmeler.Controls.Add(btnYarat);
            pnlDugmeler.Dock = DockStyle.Bottom;
            pnlDugmeler.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlDugmeler.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlDugmeler.Location = new Point(3, 439);
            pnlDugmeler.Name = "pnlDugmeler";
            pnlDugmeler.Size = new Size(341, 71);
            pnlDugmeler.TabIndex = 1;
            // 
            // btnTemizle
            // 
            btnTemizle.BackColor = Color.FromArgb(242, 242, 242);
            btnTemizle.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            btnTemizle.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnTemizle.Location = new Point(240, 20);
            btnTemizle.Name = "btnTemizle";
            btnTemizle.Size = new Size(100, 35);
            btnTemizle.TabIndex = 3;
            btnTemizle.Text = "Təmizlə";
            btnTemizle.UseVisualStyleBackColor = false;
            btnTemizle.Click += btnTemizle_Click;
            // 
            // btnSil
            // 
            btnSil.BackColor = Color.FromArgb(242, 242, 242);
            btnSil.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            btnSil.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnSil.Location = new Point(160, 20);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(75, 35);
            btnSil.TabIndex = 2;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = false;
            btnSil.Click += btnSil_Click;
            // 
            // btnYenile
            // 
            btnYenile.BackColor = Color.FromArgb(242, 242, 242);
            btnYenile.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            btnYenile.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnYenile.Location = new Point(80, 20);
            btnYenile.Name = "btnYenile";
            btnYenile.Size = new Size(75, 35);
            btnYenile.TabIndex = 1;
            btnYenile.Text = "Yenilə";
            btnYenile.UseVisualStyleBackColor = false;
            btnYenile.Click += btnYenile_Click;
            // 
            // btnYarat
            // 
            btnYarat.BackColor = Color.FromArgb(242, 242, 242);
            btnYarat.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            btnYarat.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnYarat.Location = new Point(5, 20);
            btnYarat.Name = "btnYarat";
            btnYarat.Size = new Size(70, 35);
            btnYarat.TabIndex = 0;
            btnYarat.Text = "Yarat";
            btnYarat.UseVisualStyleBackColor = false;
            btnYarat.Click += btnYarat_Click;
            // 
            // grpSifarisler
            // 
            grpSifarisler.BackColor = Color.FromArgb(242, 242, 242);
            grpSifarisler.Controls.Add(dgvSifarisler);
            grpSifarisler.Dock = DockStyle.Fill;
            grpSifarisler.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            grpSifarisler.ForeColor = Color.FromArgb(222, 0, 0, 0);
            grpSifarisler.Location = new Point(0, 0);
            grpSifarisler.Name = "grpSifarisler";
            grpSifarisler.Size = new Size(623, 513);
            grpSifarisler.TabIndex = 0;
            grpSifarisler.TabStop = false;
            grpSifarisler.Text = "Sifarişlər";
            // 
            // dgvSifarisler
            // 
            dgvSifarisler.AllowUserToAddRows = false;
            dgvSifarisler.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvSifarisler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvSifarisler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvSifarisler.DefaultCellStyle = dataGridViewCellStyle2;
            dgvSifarisler.Dock = DockStyle.Fill;
            dgvSifarisler.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvSifarisler.Location = new Point(3, 20);
            dgvSifarisler.MultiSelect = false;
            dgvSifarisler.Name = "dgvSifarisler";
            dgvSifarisler.ReadOnly = true;
            dgvSifarisler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSifarisler.Size = new Size(617, 490);
            dgvSifarisler.TabIndex = 0;
            dgvSifarisler.SelectionChanged += dgvSifarisler_SelectionChanged;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // TemirIdareetmeFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 660);
            Controls.Add(pnlMain);
            Controls.Add(pnlTop);
            Name = "TemirIdareetmeFormu";
            Text = "Təmir İdarəetmə";
            Load += TemirIdareetmeFormu_Load;
            pnlTop.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            grpSifarisMelumatlari.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            pnlDugmeler.ResumeLayout(false);
            grpSifarisler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSifarisler).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpSifarisMelumatlari;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblMusteriAdi;
        private System.Windows.Forms.TextBox txtMusteriAdi;
        private System.Windows.Forms.Label lblMusteriTelefonu;
        private System.Windows.Forms.TextBox txtMusteriTelefonu;
        private System.Windows.Forms.Label lblCihazAdi;
        private System.Windows.Forms.TextBox txtCihazAdi;
        private System.Windows.Forms.Label lblProblemTesviri;
        private System.Windows.Forms.TextBox txtProblemTesviri;
        private System.Windows.Forms.Label lblYekunMebleg;
        private System.Windows.Forms.TextBox txtYekunMebleg;
        private System.Windows.Forms.Panel pnlDugmeler;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnYenile;
        private System.Windows.Forms.Button btnYarat;
        private System.Windows.Forms.GroupBox grpSifarisler;
        private System.Windows.Forms.DataGridView dgvSifarisler;
        private System.Windows.Forms.Button btnEhtiyatHissəsiElaveEt;
        private System.Windows.Forms.Label lblTemirXerci;
        private System.Windows.Forms.TextBox txtTemirXerci;
        private System.Windows.Forms.Label lblServisHaqqi;
        private System.Windows.Forms.TextBox txtServisHaqqi;
        private System.Windows.Forms.Button btnÖdənişiTamamla;
        private System.Windows.Forms.Label lblUsta;
        private System.Windows.Forms.ComboBox cmbUsta;
        private System.Windows.Forms.Label lblSeriyaNomresi;
        private System.Windows.Forms.TextBox txtSeriyaNomresi;
        private ErrorProvider errorProvider1;
    }
}