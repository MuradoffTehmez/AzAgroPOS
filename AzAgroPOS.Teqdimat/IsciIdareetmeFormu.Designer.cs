namespace AzAgroPOS.Teqdimat
{
    partial class IsciIdareetmeFormu
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlTop = new Panel();
            lblBaslik = new Label();
            pnlMain = new Panel();
            splitContainer1 = new SplitContainer();
            grpIsciMelumatlari = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblId = new Label();
            txtId = new TextBox();
            lblTamAd = new Label();
            txtTamAd = new TextBox();
            lblDogumTarixi = new Label();
            dtpDogumTarixi = new DateTimePicker();
            lblTelefon = new Label();
            txtTelefon = new TextBox();
            lblUnvan = new Label();
            txtUnvan = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblIseBaslamaTarixi = new Label();
            dtpIseBaslamaTarixi = new DateTimePicker();
            lblMaas = new Label();
            txtMaas = new TextBox();
            lblVezife = new Label();
            txtVezife = new TextBox();
            lblDepartament = new Label();
            txtDepartament = new TextBox();
            lblStatus = new Label();
            cmbStatus = new ComboBox();
            lblSvsNo = new Label();
            txtSvsNo = new TextBox();
            lblQeydiyyatUnvani = new Label();
            txtQeydiyyatUnvani = new TextBox();
            lblBankMelumatlari = new Label();
            txtBankMelumatlari = new TextBox();
            pnlDugmeler = new Panel();
            btnTemizle = new Button();
            btnSil = new Button();
            btnYenile = new Button();
            btnYarat = new Button();
            grpIsciler = new GroupBox();
            dgvIsciler = new DataGridView();
            pnlTop.SuspendLayout();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            grpIsciMelumatlari.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            pnlDugmeler.SuspendLayout();
            grpIsciler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIsciler).BeginInit();
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
            lblBaslik.Text = "İşçi İdarəetmə";
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
            splitContainer1.Panel1.Controls.Add(grpIsciMelumatlari);
            splitContainer1.Panel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            splitContainer1.Panel1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            splitContainer1.Panel1MinSize = 300;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.FromArgb(242, 242, 242);
            splitContainer1.Panel2.Controls.Add(grpIsciler);
            splitContainer1.Panel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            splitContainer1.Panel2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            splitContainer1.Size = new Size(974, 513);
            splitContainer1.SplitterDistance = 347;
            splitContainer1.TabIndex = 0;
            // 
            // grpIsciMelumatlari
            // 
            grpIsciMelumatlari.BackColor = Color.FromArgb(242, 242, 242);
            grpIsciMelumatlari.Controls.Add(tableLayoutPanel1);
            grpIsciMelumatlari.Controls.Add(pnlDugmeler);
            grpIsciMelumatlari.Dock = DockStyle.Fill;
            grpIsciMelumatlari.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            grpIsciMelumatlari.ForeColor = Color.FromArgb(222, 0, 0, 0);
            grpIsciMelumatlari.Location = new Point(0, 0);
            grpIsciMelumatlari.Name = "grpIsciMelumatlari";
            grpIsciMelumatlari.Size = new Size(347, 513);
            grpIsciMelumatlari.TabIndex = 0;
            grpIsciMelumatlari.TabStop = false;
            grpIsciMelumatlari.Text = "İşçi Məlumatları";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.FromArgb(242, 242, 242);
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.Controls.Add(lblId, 0, 0);
            tableLayoutPanel1.Controls.Add(txtId, 1, 0);
            tableLayoutPanel1.Controls.Add(lblTamAd, 0, 1);
            tableLayoutPanel1.Controls.Add(txtTamAd, 1, 1);
            tableLayoutPanel1.Controls.Add(lblDogumTarixi, 0, 2);
            tableLayoutPanel1.Controls.Add(dtpDogumTarixi, 1, 2);
            tableLayoutPanel1.Controls.Add(lblTelefon, 0, 3);
            tableLayoutPanel1.Controls.Add(txtTelefon, 1, 3);
            tableLayoutPanel1.Controls.Add(lblUnvan, 0, 4);
            tableLayoutPanel1.Controls.Add(txtUnvan, 1, 4);
            tableLayoutPanel1.Controls.Add(lblEmail, 0, 5);
            tableLayoutPanel1.Controls.Add(txtEmail, 1, 5);
            tableLayoutPanel1.Controls.Add(lblIseBaslamaTarixi, 0, 6);
            tableLayoutPanel1.Controls.Add(dtpIseBaslamaTarixi, 1, 6);
            tableLayoutPanel1.Controls.Add(lblMaas, 0, 7);
            tableLayoutPanel1.Controls.Add(txtMaas, 1, 7);
            tableLayoutPanel1.Controls.Add(lblVezife, 0, 8);
            tableLayoutPanel1.Controls.Add(txtVezife, 1, 8);
            tableLayoutPanel1.Controls.Add(lblDepartament, 0, 9);
            tableLayoutPanel1.Controls.Add(txtDepartament, 1, 9);
            tableLayoutPanel1.Controls.Add(lblStatus, 0, 10);
            tableLayoutPanel1.Controls.Add(cmbStatus, 1, 10);
            tableLayoutPanel1.Controls.Add(lblSvsNo, 0, 11);
            tableLayoutPanel1.Controls.Add(txtSvsNo, 1, 11);
            tableLayoutPanel1.Controls.Add(lblQeydiyyatUnvani, 0, 12);
            tableLayoutPanel1.Controls.Add(txtQeydiyyatUnvani, 1, 12);
            tableLayoutPanel1.Controls.Add(lblBankMelumatlari, 0, 13);
            tableLayoutPanel1.Controls.Add(txtBankMelumatlari, 1, 13);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            tableLayoutPanel1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            tableLayoutPanel1.Location = new Point(3, 20);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 15;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
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
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.BackColor = Color.FromArgb(242, 242, 242);
            lblId.Dock = DockStyle.Fill;
            lblId.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblId.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblId.Location = new Point(3, 0);
            lblId.Name = "lblId";
            lblId.Size = new Size(96, 35);
            lblId.TabIndex = 0;
            lblId.Text = "ID:";
            lblId.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtId
            // 
            txtId.BackColor = Color.FromArgb(242, 242, 242);
            txtId.Dock = DockStyle.Fill;
            txtId.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtId.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtId.Location = new Point(105, 3);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(233, 24);
            txtId.TabIndex = 1;
            // 
            // lblTamAd
            // 
            lblTamAd.AutoSize = true;
            lblTamAd.BackColor = Color.FromArgb(242, 242, 242);
            lblTamAd.Dock = DockStyle.Fill;
            lblTamAd.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblTamAd.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblTamAd.Location = new Point(3, 35);
            lblTamAd.Name = "lblTamAd";
            lblTamAd.Size = new Size(96, 35);
            lblTamAd.TabIndex = 2;
            lblTamAd.Text = "Tam Ad:";
            lblTamAd.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtTamAd
            // 
            txtTamAd.BackColor = Color.FromArgb(242, 242, 242);
            txtTamAd.Dock = DockStyle.Fill;
            txtTamAd.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtTamAd.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtTamAd.Location = new Point(105, 38);
            txtTamAd.Name = "txtTamAd";
            txtTamAd.Size = new Size(233, 24);
            txtTamAd.TabIndex = 3;
            // 
            // lblDogumTarixi
            // 
            lblDogumTarixi.AutoSize = true;
            lblDogumTarixi.BackColor = Color.FromArgb(242, 242, 242);
            lblDogumTarixi.Dock = DockStyle.Fill;
            lblDogumTarixi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblDogumTarixi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblDogumTarixi.Location = new Point(3, 70);
            lblDogumTarixi.Name = "lblDogumTarixi";
            lblDogumTarixi.Size = new Size(96, 35);
            lblDogumTarixi.TabIndex = 4;
            lblDogumTarixi.Text = "Doğum Tarixi:";
            lblDogumTarixi.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtpDogumTarixi
            // 
            dtpDogumTarixi.BackColor = Color.FromArgb(242, 242, 242);
            dtpDogumTarixi.Dock = DockStyle.Fill;
            dtpDogumTarixi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dtpDogumTarixi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dtpDogumTarixi.Location = new Point(105, 73);
            dtpDogumTarixi.Name = "dtpDogumTarixi";
            dtpDogumTarixi.Size = new Size(233, 24);
            dtpDogumTarixi.TabIndex = 5;
            // 
            // lblTelefon
            // 
            lblTelefon.AutoSize = true;
            lblTelefon.BackColor = Color.FromArgb(242, 242, 242);
            lblTelefon.Dock = DockStyle.Fill;
            lblTelefon.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblTelefon.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblTelefon.Location = new Point(3, 105);
            lblTelefon.Name = "lblTelefon";
            lblTelefon.Size = new Size(96, 35);
            lblTelefon.TabIndex = 6;
            lblTelefon.Text = "Telefon:";
            lblTelefon.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtTelefon
            // 
            txtTelefon.BackColor = Color.FromArgb(242, 242, 242);
            txtTelefon.Dock = DockStyle.Fill;
            txtTelefon.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtTelefon.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtTelefon.Location = new Point(105, 108);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(233, 24);
            txtTelefon.TabIndex = 7;
            // 
            // lblUnvan
            // 
            lblUnvan.AutoSize = true;
            lblUnvan.BackColor = Color.FromArgb(242, 242, 242);
            lblUnvan.Dock = DockStyle.Fill;
            lblUnvan.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblUnvan.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblUnvan.Location = new Point(3, 140);
            lblUnvan.Name = "lblUnvan";
            lblUnvan.Size = new Size(96, 35);
            lblUnvan.TabIndex = 8;
            lblUnvan.Text = "Ünvan:";
            lblUnvan.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtUnvan
            // 
            txtUnvan.BackColor = Color.FromArgb(242, 242, 242);
            txtUnvan.Dock = DockStyle.Fill;
            txtUnvan.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtUnvan.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtUnvan.Location = new Point(105, 143);
            txtUnvan.Name = "txtUnvan";
            txtUnvan.Size = new Size(233, 24);
            txtUnvan.TabIndex = 9;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.BackColor = Color.FromArgb(242, 242, 242);
            lblEmail.Dock = DockStyle.Fill;
            lblEmail.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblEmail.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblEmail.Location = new Point(3, 175);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(96, 35);
            lblEmail.TabIndex = 10;
            lblEmail.Text = "Email:";
            lblEmail.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(242, 242, 242);
            txtEmail.Dock = DockStyle.Fill;
            txtEmail.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtEmail.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtEmail.Location = new Point(105, 178);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(233, 24);
            txtEmail.TabIndex = 11;
            // 
            // lblIseBaslamaTarixi
            // 
            lblIseBaslamaTarixi.AutoSize = true;
            lblIseBaslamaTarixi.BackColor = Color.FromArgb(242, 242, 242);
            lblIseBaslamaTarixi.Dock = DockStyle.Fill;
            lblIseBaslamaTarixi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblIseBaslamaTarixi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblIseBaslamaTarixi.Location = new Point(3, 210);
            lblIseBaslamaTarixi.Name = "lblIseBaslamaTarixi";
            lblIseBaslamaTarixi.Size = new Size(96, 35);
            lblIseBaslamaTarixi.TabIndex = 12;
            lblIseBaslamaTarixi.Text = "İşə Başlama Tarixi:";
            lblIseBaslamaTarixi.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtpIseBaslamaTarixi
            // 
            dtpIseBaslamaTarixi.BackColor = Color.FromArgb(242, 242, 242);
            dtpIseBaslamaTarixi.Dock = DockStyle.Fill;
            dtpIseBaslamaTarixi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dtpIseBaslamaTarixi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dtpIseBaslamaTarixi.Location = new Point(105, 213);
            dtpIseBaslamaTarixi.Name = "dtpIseBaslamaTarixi";
            dtpIseBaslamaTarixi.Size = new Size(233, 24);
            dtpIseBaslamaTarixi.TabIndex = 13;
            // 
            // lblMaas
            // 
            lblMaas.AutoSize = true;
            lblMaas.BackColor = Color.FromArgb(242, 242, 242);
            lblMaas.Dock = DockStyle.Fill;
            lblMaas.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblMaas.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblMaas.Location = new Point(3, 245);
            lblMaas.Name = "lblMaas";
            lblMaas.Size = new Size(96, 35);
            lblMaas.TabIndex = 14;
            lblMaas.Text = "Maaş:";
            lblMaas.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtMaas
            // 
            txtMaas.BackColor = Color.FromArgb(242, 242, 242);
            txtMaas.Dock = DockStyle.Fill;
            txtMaas.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtMaas.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtMaas.Location = new Point(105, 248);
            txtMaas.Name = "txtMaas";
            txtMaas.Size = new Size(233, 24);
            txtMaas.TabIndex = 15;
            // 
            // lblVezife
            // 
            lblVezife.AutoSize = true;
            lblVezife.BackColor = Color.FromArgb(242, 242, 242);
            lblVezife.Dock = DockStyle.Fill;
            lblVezife.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblVezife.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblVezife.Location = new Point(3, 280);
            lblVezife.Name = "lblVezife";
            lblVezife.Size = new Size(96, 35);
            lblVezife.TabIndex = 16;
            lblVezife.Text = "Vəzifə:";
            lblVezife.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtVezife
            // 
            txtVezife.BackColor = Color.FromArgb(242, 242, 242);
            txtVezife.Dock = DockStyle.Fill;
            txtVezife.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtVezife.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtVezife.Location = new Point(105, 283);
            txtVezife.Name = "txtVezife";
            txtVezife.Size = new Size(233, 24);
            txtVezife.TabIndex = 17;
            // 
            // lblDepartament
            // 
            lblDepartament.AutoSize = true;
            lblDepartament.BackColor = Color.FromArgb(242, 242, 242);
            lblDepartament.Dock = DockStyle.Fill;
            lblDepartament.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblDepartament.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblDepartament.Location = new Point(3, 315);
            lblDepartament.Name = "lblDepartament";
            lblDepartament.Size = new Size(96, 35);
            lblDepartament.TabIndex = 18;
            lblDepartament.Text = "Departament:";
            lblDepartament.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtDepartament
            // 
            txtDepartament.BackColor = Color.FromArgb(242, 242, 242);
            txtDepartament.Dock = DockStyle.Fill;
            txtDepartament.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtDepartament.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtDepartament.Location = new Point(105, 318);
            txtDepartament.Name = "txtDepartament";
            txtDepartament.Size = new Size(233, 24);
            txtDepartament.TabIndex = 19;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.BackColor = Color.FromArgb(242, 242, 242);
            lblStatus.Dock = DockStyle.Fill;
            lblStatus.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblStatus.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblStatus.Location = new Point(3, 350);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(96, 35);
            lblStatus.TabIndex = 20;
            lblStatus.Text = "Status:";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbStatus
            // 
            cmbStatus.BackColor = Color.FromArgb(242, 242, 242);
            cmbStatus.Dock = DockStyle.Fill;
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            cmbStatus.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(105, 353);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(233, 25);
            cmbStatus.TabIndex = 21;
            // 
            // lblSvsNo
            // 
            lblSvsNo.AutoSize = true;
            lblSvsNo.BackColor = Color.FromArgb(242, 242, 242);
            lblSvsNo.Dock = DockStyle.Fill;
            lblSvsNo.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSvsNo.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblSvsNo.Location = new Point(3, 385);
            lblSvsNo.Name = "lblSvsNo";
            lblSvsNo.Size = new Size(96, 35);
            lblSvsNo.TabIndex = 22;
            lblSvsNo.Text = "SVS No:";
            lblSvsNo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtSvsNo
            // 
            txtSvsNo.BackColor = Color.FromArgb(242, 242, 242);
            txtSvsNo.Dock = DockStyle.Fill;
            txtSvsNo.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtSvsNo.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtSvsNo.Location = new Point(105, 388);
            txtSvsNo.Name = "txtSvsNo";
            txtSvsNo.Size = new Size(233, 24);
            txtSvsNo.TabIndex = 23;
            // 
            // lblQeydiyyatUnvani
            // 
            lblQeydiyyatUnvani.AutoSize = true;
            lblQeydiyyatUnvani.BackColor = Color.FromArgb(242, 242, 242);
            lblQeydiyyatUnvani.Dock = DockStyle.Fill;
            lblQeydiyyatUnvani.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblQeydiyyatUnvani.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblQeydiyyatUnvani.Location = new Point(3, 420);
            lblQeydiyyatUnvani.Name = "lblQeydiyyatUnvani";
            lblQeydiyyatUnvani.Size = new Size(96, 35);
            lblQeydiyyatUnvani.TabIndex = 24;
            lblQeydiyyatUnvani.Text = "Qeydiyyat Ünvanı:";
            lblQeydiyyatUnvani.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtQeydiyyatUnvani
            // 
            txtQeydiyyatUnvani.BackColor = Color.FromArgb(242, 242, 242);
            txtQeydiyyatUnvani.Dock = DockStyle.Fill;
            txtQeydiyyatUnvani.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtQeydiyyatUnvani.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtQeydiyyatUnvani.Location = new Point(105, 423);
            txtQeydiyyatUnvani.Name = "txtQeydiyyatUnvani";
            txtQeydiyyatUnvani.Size = new Size(233, 24);
            txtQeydiyyatUnvani.TabIndex = 25;
            // 
            // lblBankMelumatlari
            // 
            lblBankMelumatlari.AutoSize = true;
            lblBankMelumatlari.BackColor = Color.FromArgb(242, 242, 242);
            lblBankMelumatlari.Dock = DockStyle.Fill;
            lblBankMelumatlari.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblBankMelumatlari.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblBankMelumatlari.Location = new Point(3, 455);
            lblBankMelumatlari.Name = "lblBankMelumatlari";
            lblBankMelumatlari.Size = new Size(96, 35);
            lblBankMelumatlari.TabIndex = 26;
            lblBankMelumatlari.Text = "Bank Məlumatları:";
            lblBankMelumatlari.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtBankMelumatlari
            // 
            txtBankMelumatlari.BackColor = Color.FromArgb(242, 242, 242);
            txtBankMelumatlari.Dock = DockStyle.Fill;
            txtBankMelumatlari.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtBankMelumatlari.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtBankMelumatlari.Location = new Point(105, 458);
            txtBankMelumatlari.Name = "txtBankMelumatlari";
            txtBankMelumatlari.Size = new Size(233, 24);
            txtBankMelumatlari.TabIndex = 27;
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
            btnTemizle.TabIndex = 2;
            btnTemizle.Text = "Təmizlə";
            btnTemizle.UseVisualStyleBackColor = false;
            btnTemizle.Click += btnTemizle_Click;
            // 
            // btnSil
            // 
            btnSil.BackColor = Color.FromArgb(242, 242, 242);
            btnSil.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            btnSil.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnSil.Location = new Point(120, 20);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(100, 35);
            btnSil.TabIndex = 1;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = false;
            btnSil.Click += btnSil_Click;
            // 
            // btnYenile
            // 
            btnYenile.BackColor = Color.FromArgb(242, 242, 242);
            btnYenile.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            btnYenile.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnYenile.Location = new Point(5, 20);
            btnYenile.Name = "btnYenile";
            btnYenile.Size = new Size(100, 35);
            btnYenile.TabIndex = 0;
            btnYenile.Text = "Yarat/Yenilə";
            btnYenile.UseVisualStyleBackColor = false;
            btnYenile.Click += btnYarat_Click;
            // 
            // btnYarat
            // 
            btnYarat.BackColor = Color.FromArgb(242, 242, 242);
            btnYarat.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            btnYarat.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnYarat.Location = new Point(5, 20);
            btnYarat.Name = "btnYarat";
            btnYarat.Size = new Size(100, 35);
            btnYarat.TabIndex = 0;
            btnYarat.Text = "Yarat/Yenilə";
            btnYarat.UseVisualStyleBackColor = false;
            btnYarat.Click += btnYarat_Click;
            // 
            // grpIsciler
            // 
            grpIsciler.BackColor = Color.FromArgb(242, 242, 242);
            grpIsciler.Controls.Add(dgvIsciler);
            grpIsciler.Dock = DockStyle.Fill;
            grpIsciler.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            grpIsciler.ForeColor = Color.FromArgb(222, 0, 0, 0);
            grpIsciler.Location = new Point(0, 0);
            grpIsciler.Name = "grpIsciler";
            grpIsciler.Size = new Size(623, 513);
            grpIsciler.TabIndex = 0;
            grpIsciler.TabStop = false;
            grpIsciler.Text = "İşçilər";
            // 
            // dgvIsciler
            // 
            dgvIsciler.AllowUserToAddRows = false;
            dgvIsciler.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvIsciler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvIsciler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvIsciler.DefaultCellStyle = dataGridViewCellStyle2;
            dgvIsciler.Dock = DockStyle.Fill;
            dgvIsciler.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvIsciler.Location = new Point(3, 20);
            dgvIsciler.MultiSelect = false;
            dgvIsciler.Name = "dgvIsciler";
            dgvIsciler.ReadOnly = true;
            dgvIsciler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIsciler.Size = new Size(617, 490);
            dgvIsciler.TabIndex = 0;
            dgvIsciler.SelectionChanged += dgvIsciler_SelectionChanged;
            // 
            // IsciIdareetmeFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 660);
            Controls.Add(pnlMain);
            Controls.Add(pnlTop);
            Name = "IsciIdareetmeFormu";
            Text = "İşçi İdarəetmə";
            Load += IsciIdareetmeFormu_Load;
            pnlTop.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            grpIsciMelumatlari.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            pnlDugmeler.ResumeLayout(false);
            grpIsciler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvIsciler).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpIsciMelumatlari;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblTamAd;
        private System.Windows.Forms.TextBox txtTamAd;
        private System.Windows.Forms.Label lblDogumTarixi;
        private System.Windows.Forms.DateTimePicker dtpDogumTarixi;
        private System.Windows.Forms.Label lblTelefon;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.Label lblUnvan;
        private System.Windows.Forms.TextBox txtUnvan;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblIseBaslamaTarixi;
        private System.Windows.Forms.DateTimePicker dtpIseBaslamaTarixi;
        private System.Windows.Forms.Label lblMaas;
        private System.Windows.Forms.TextBox txtMaas;
        private System.Windows.Forms.Label lblVezife;
        private System.Windows.Forms.TextBox txtVezife;
        private System.Windows.Forms.Label lblDepartament;
        private System.Windows.Forms.TextBox txtDepartament;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblSvsNo;
        private System.Windows.Forms.TextBox txtSvsNo;
        private System.Windows.Forms.Label lblQeydiyyatUnvani;
        private System.Windows.Forms.TextBox txtQeydiyyatUnvani;
        private System.Windows.Forms.Label lblBankMelumatlari;
        private System.Windows.Forms.TextBox txtBankMelumatlari;
        private System.Windows.Forms.Panel pnlDugmeler;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnYenile;
        private System.Windows.Forms.Button btnYarat;
        private System.Windows.Forms.GroupBox grpIsciler;
        private System.Windows.Forms.DataGridView dgvIsciler;
    }
}