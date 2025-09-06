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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grpIsciMelumatlari = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblTamAd = new System.Windows.Forms.Label();
            this.txtTamAd = new System.Windows.Forms.TextBox();
            this.lblDogumTarixi = new System.Windows.Forms.Label();
            this.dtpDogumTarixi = new System.Windows.Forms.DateTimePicker();
            this.lblTelefonNomresi = new System.Windows.Forms.Label();
            this.txtTelefonNomresi = new System.Windows.Forms.TextBox();
            this.lblUnvan = new System.Windows.Forms.Label();
            this.txtUnvan = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblIseBaslamaTarixi = new System.Windows.Forms.Label();
            this.dtpIseBaslamaTarixi = new System.Windows.Forms.DateTimePicker();
            this.lblMaas = new System.Windows.Forms.Label();
            this.txtMaas = new System.Windows.Forms.TextBox();
            this.lblVezife = new System.Windows.Forms.Label();
            this.txtVezife = new System.Windows.Forms.TextBox();
            this.lblDepartament = new System.Windows.Forms.Label();
            this.txtDepartament = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblSvsNo = new System.Windows.Forms.Label();
            this.txtSvsNo = new System.Windows.Forms.TextBox();
            this.lblQeydiyyatUnvani = new System.Windows.Forms.Label();
            this.txtQeydiyyatUnvani = new System.Windows.Forms.TextBox();
            this.lblBankMelumatlari = new System.Windows.Forms.Label();
            this.txtBankMelumatlari = new System.Windows.Forms.TextBox();
            this.lblSistemIstifadeciAdi = new System.Windows.Forms.Label();
            this.txtSistemIstifadeciAdi = new System.Windows.Forms.TextBox();
            this.pnlDugmeler = new System.Windows.Forms.Panel();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnYenile = new System.Windows.Forms.Button();
            this.btnYarat = new System.Windows.Forms.Button();
            this.grpIsciler = new System.Windows.Forms.GroupBox();
            this.dgvIsciler = new System.Windows.Forms.DataGridView();
            this.pnlTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpIsciMelumatlari.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlDugmeler.SuspendLayout();
            this.grpIsciler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIsciler)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.pnlTop.Controls.Add(this.lblBaslik);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1000, 60);
            this.pnlTop.TabIndex = 0;
            // 
            // lblBaslik
            // 
            this.lblBaslik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBaslik.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBaslik.ForeColor = System.Drawing.Color.White;
            this.lblBaslik.Location = new System.Drawing.Point(0, 0);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(1000, 60);
            this.lblBaslik.TabIndex = 0;
            this.lblBaslik.Text = "İşçi İdarəetmə";
            this.lblBaslik.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.splitContainer1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 60);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(10);
            this.pnlMain.Size = new System.Drawing.Size(1000, 600);
            this.pnlMain.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(10, 10);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grpIsciMelumatlari);
            this.splitContainer1.Panel1MinSize = 300;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grpIsciler);
            this.splitContainer1.Size = new System.Drawing.Size(980, 580);
            this.splitContainer1.SplitterDistance = 350;
            this.splitContainer1.TabIndex = 0;
            // 
            // grpIsciMelumatlari
            // 
            this.grpIsciMelumatlari.Controls.Add(this.tableLayoutPanel1);
            this.grpIsciMelumatlari.Controls.Add(this.pnlDugmeler);
            this.grpIsciMelumatlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpIsciMelumatlari.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.grpIsciMelumatlari.Location = new System.Drawing.Point(0, 0);
            this.grpIsciMelumatlari.Name = "grpIsciMelumatlari";
            this.grpIsciMelumatlari.Size = new System.Drawing.Size(350, 580);
            this.grpIsciMelumatlari.TabIndex = 0;
            this.grpIsciMelumatlari.TabStop = false;
            this.grpIsciMelumatlari.Text = "İşçi Məlumatları";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.lblId, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtId, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTamAd, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTamAd, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDogumTarixi, 0, 2);
            this.tableLayoutPanel1.ControlsAdd(this.dtpDogumTarixi, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblTelefonNomresi, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtTelefonNomresi, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblUnvan, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtUnvan, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblEmail, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtEmail, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblIseBaslamaTarixi, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.dtpIseBaslamaTarixi, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblMaas, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtMaas, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.lblVezife, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.txtVezife, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.lblDepartament, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.txtDepartament, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.lblStatus, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.cmbStatus, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.lblSvsNo, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.txtSvsNo, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.lblQeydiyyatUnvani, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.txtQeydiyyatUnvani, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.lblBankMelumatlari, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.txtBankMelumatlari, 1, 13);
            this.tableLayoutPanel1.Controls.Add(this.lblSistemIstifadeciAdi, 0, 14);
            this.tableLayoutPanel1.Controls.Add(this.txtSistemIstifadeciAdi, 1, 14);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 21);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 16;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(344, 485);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblId.Location = new System.Drawing.Point(3, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(97, 35);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "ID:";
            this.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtId
            // 
            this.txtId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtId.Location = new System.Drawing.Point(106, 3);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(235, 25);
            this.txtId.TabIndex = 1;
            // 
            // lblTamAd
            // 
            this.lblTamAd.AutoSize = true;
            this.lblTamAd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTamAd.Location = new System.Drawing.Point(3, 35);
            this.lblTamAd.Name = "lblTamAd";
            this.lblTamAd.Size = new System.Drawing.Size(97, 35);
            this.lblTamAd.TabIndex = 2;
            this.lblTamAd.Text = "Tam Ad:";
            this.lblTamAd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTamAd
            // 
            this.txtTamAd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTamAd.Location = new System.Drawing.Point(106, 38);
            this.txtTamAd.Name = "txtTamAd";
            this.txtTamAd.Size = new System.Drawing.Size(235, 25);
            this.txtTamAd.TabIndex = 3;
            // 
            // lblDogumTarixi
            // 
            this.lblDogumTarixi.AutoSize = true;
            this.lblDogumTarixi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDogumTarixi.Location = new System.Drawing.Point(3, 70);
            this.lblDogumTarixi.Name = "lblDogumTarixi";
            this.lblDogumTarixi.Size = new System.Drawing.Size(97, 35);
            this.lblDogumTarixi.TabIndex = 4;
            this.lblDogumTarixi.Text = "Doğum Tarixi:";
            this.lblDogumTarixi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpDogumTarixi
            // 
            this.dtpDogumTarixi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpDogumTarixi.Location = new System.Drawing.Point(106, 73);
            this.dtpDogumTarixi.Name = "dtpDogumTarixi";
            this.dtpDogumTarixi.Size = new System.Drawing.Size(235, 25);
            this.dtpDogumTarixi.TabIndex = 5;
            // 
            // lblTelefonNomresi
            // 
            this.lblTelefonNomresi.AutoSize = true;
            this.lblTelefonNomresi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTelefonNomresi.Location = new System.Drawing.Point(3, 105);
            this.lblTelefonNomresi.Name = "lblTelefonNomresi";
            this.lblTelefonNomresi.Size = new System.Drawing.Size(97, 35);
            this.lblTelefonNomresi.TabIndex = 6;
            this.lblTelefonNomresi.Text = "Telefon Nömrəsi:";
            this.lblTelefonNomresi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTelefonNomresi
            // 
            this.txtTelefonNomresi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTelefonNomresi.Location = new System.Drawing.Point(106, 108);
            this.txtTelefonNomresi.Name = "txtTelefonNomresi";
            this.txtTelefonNomresi.Size = new System.Drawing.Size(235, 25);
            this.txtTelefonNomresi.TabIndex = 7;
            // 
            // lblUnvan
            // 
            this.lblUnvan.AutoSize = true;
            this.lblUnvan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUnvan.Location = new System.Drawing.Point(3, 140);
            this.lblUnvan.Name = "lblUnvan";
            this.lblUnvan.Size = new System.Drawing.Size(97, 35);
            this.lblUnvan.TabIndex = 8;
            this.lblUnvan.Text = "Ünvan:";
            this.lblUnvan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUnvan
            // 
            this.txtUnvan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUnvan.Location = new System.Drawing.Point(106, 143);
            this.txtUnvan.Name = "txtUnvan";
            this.txtUnvan.Size = new System.Drawing.Size(235, 25);
            this.txtUnvan.TabIndex = 9;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEmail.Location = new System.Drawing.Point(3, 175);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(97, 35);
            this.lblEmail.TabIndex = 10;
            this.lblEmail.Text = "Email:";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEmail
            // 
            this.txtEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEmail.Location = new System.Drawing.Point(106, 178);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(235, 25);
            this.txtEmail.TabIndex = 11;
            // 
            // lblIseBaslamaTarixi
            // 
            this.lblIseBaslamaTarixi.AutoSize = true;
            this.lblIseBaslamaTarixi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIseBaslamaTarixi.Location = new System.Drawing.Point(3, 210);
            this.lblIseBaslamaTarixi.Name = "lblIseBaslamaTarixi";
            this.lblIseBaslamaTarixi.Size = new System.Drawing.Size(97, 35);
            this.lblIseBaslamaTarixi.TabIndex = 12;
            this.lblIseBaslamaTarixi.Text = "İşə Başlama Tarixi:";
            this.lblIseBaslamaTarixi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpIseBaslamaTarixi
            // 
            this.dtpIseBaslamaTarixi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpIseBaslamaTarixi.Location = new System.Drawing.Point(106, 213);
            this.dtpIseBaslamaTarixi.Name = "dtpIseBaslamaTarixi";
            this.dtpIseBaslamaTarixi.Size = new System.Drawing.Size(235, 25);
            this.dtpIseBaslamaTarixi.TabIndex = 13;
            // 
            // lblMaas
            // 
            this.lblMaas.AutoSize = true;
            this.lblMaas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaas.Location = new System.Drawing.Point(3, 245);
            this.lblMaas.Name = "lblMaas";
            this.lblMaas.Size = new System.Drawing.Size(97, 35);
            this.lblMaas.TabIndex = 14;
            this.lblMaas.Text = "Maaş:";
            this.lblMaas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMaas
            // 
            this.txtMaas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaas.Location = new System.Drawing.Point(106, 248);
            this.txtMaas.Name = "txtMaas";
            this.txtMaas.Size = new System.Drawing.Size(235, 25);
            this.txtMaas.TabIndex = 15;
            // 
            // lblVezife
            // 
            this.lblVezife.AutoSize = true;
            this.lblVezife.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVezife.Location = new System.Drawing.Point(3, 280);
            this.lblVezife.Name = "lblVezife";
            this.lblVezife.Size = new System.Drawing.Size(97, 35);
            this.lblVezife.TabIndex = 16;
            this.lblVezife.Text = "Vəzifə:";
            this.lblVezife.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtVezife
            // 
            this.txtVezife.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtVezife.Location = new System.Drawing.Point(106, 283);
            this.txtVezife.Name = "txtVezife";
            this.txtVezife.Size = new System.Drawing.Size(235, 25);
            this.txtVezife.TabIndex = 17;
            // 
            // lblDepartament
            // 
            this.lblDepartament.AutoSize = true;
            this.lblDepartament.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDepartament.Location = new System.Drawing.Point(3, 315);
            this.lblDepartament.Name = "lblDepartament";
            this.lblDepartament.Size = new System.Drawing.Size(97, 35);
            this.lblDepartament.TabIndex = 18;
            this.lblDepartament.Text = "Departament:";
            this.lblDepartament.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDepartament
            // 
            this.txtDepartament.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDepartament.Location = new System.Drawing.Point(106, 318);
            this.txtDepartament.Name = "txtDepartament";
            this.txtDepartament.Size = new System.Drawing.Size(235, 25);
            this.txtDepartament.TabIndex = 19;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.Location = new System.Drawing.Point(3, 350);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(97, 35);
            this.lblStatus.TabIndex = 20;
            this.lblStatus.Text = "Status:";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbStatus
            // 
            this.cmbStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(106, 353);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(235, 25);
            this.cmbStatus.TabIndex = 21;
            // 
            // lblSvsNo
            // 
            this.lblSvsNo.AutoSize = true;
            this.lblSvsNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSvsNo.Location = new System.Drawing.Point(3, 385);
            this.lblSvsNo.Name = "lblSvsNo";
            this.lblSvsNo.Size = new System.Drawing.Size(97, 35);
            this.lblSvsNo.TabIndex = 22;
            this.lblSvsNo.Text = "SVS No:";
            this.lblSvsNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSvsNo
            // 
            this.txtSvsNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSvsNo.Location = new System.Drawing.Point(106, 388);
            this.txtSvsNo.Name = "txtSvsNo";
            this.txtSvsNo.Size = new System.Drawing.Size(235, 25);
            this.txtSvsNo.TabIndex = 23;
            // 
            // lblQeydiyyatUnvani
            // 
            this.lblQeydiyyatUnvani.AutoSize = true;
            this.lblQeydiyyatUnvani.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQeydiyyatUnvani.Location = new System.Drawing.Point(3, 420);
            this.lblQeydiyyatUnvani.Name = "lblQeydiyyatUnvani";
            this.lblQeydiyyatUnvani.Size = new System.Drawing.Size(97, 35);
            this.lblQeydiyyatUnvani.TabIndex = 24;
            this.lblQeydiyyatUnvani.Text = "Qeydiyyat Ünvanı:";
            this.lblQeydiyyatUnvani.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtQeydiyyatUnvani
            // 
            this.txtQeydiyyatUnvani.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtQeydiyyatUnvani.Location = new System.Drawing.Point(106, 423);
            this.txtQeydiyyatUnvani.Name = "txtQeydiyyatUnvani";
            this.txtQeydiyyatUnvani.Size = new System.Drawing.Size(235, 25);
            this.txtQeydiyyatUnvani.TabIndex = 25;
            // 
            // lblBankMelumatlari
            // 
            this.lblBankMelumatlari.AutoSize = true;
            this.lblBankMelumatlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBankMelumatlari.Location = new System.Drawing.Point(3, 455);
            this.lblBankMelumatlari.Name = "lblBankMelumatlari";
            this.lblBankMelumatlari.Size = new System.Drawing.Size(97, 35);
            this.lblBankMelumatlari.TabIndex = 26;
            this.lblBankMelumatlari.Text = "Bank Məlumatları:";
            this.lblBankMelumatlari.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtBankMelumatlari
            // 
            this.txtBankMelumatlari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBankMelumatlari.Location = new System.Drawing.Point(106, 458);
            this.txtBankMelumatlari.Name = "txtBankMelumatlari";
            this.txtBankMelumatlari.Size = new System.Drawing.Size(235, 25);
            this.txtBankMelumatlari.TabIndex = 27;
            // 
            // lblSistemIstifadeciAdi
            // 
            this.lblSistemIstifadeciAdi.AutoSize = true;
            this.lblSistemIstifadeciAdi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSistemIstifadeciAdi.Location = new System.Drawing.Point(3, 490);
            this.lblSistemIstifadeciAdi.Name = "lblSistemIstifadeciAdi";
            this.lblSistemIstifadeciAdi.Size = new System.Drawing.Size(97, 35);
            this.lblSistemIstifadeciAdi.TabIndex = 28;
            this.lblSistemIstifadeciAdi.Text = "Sistem İstifadəçi Adı:";
            this.lblSistemIstifadeciAdi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSistemIstifadeciAdi
            // 
            this.txtSistemIstifadeciAdi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSistemIstifadeciAdi.Location = new System.Drawing.Point(106, 493);
            this.txtSistemIstifadeciAdi.Name = "txtSistemIstifadeciAdi";
            this.txtSistemIstifadeciAdi.Size = new System.Drawing.Size(235, 25);
            this.txtSistemIstifadeciAdi.TabIndex = 29;
            // 
            // pnlDugmeler
            // 
            this.pnlDugmeler.Controls.Add(this.btnTemizle);
            this.pnlDugmeler.Controls.Add(this.btnSil);
            this.pnlDugmeler.Controls.Add(this.btnYenile);
            this.pnlDugmeler.Controls.Add(this.btnYarat);
            this.pnlDugmeler.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDugmeler.Location = new System.Drawing.Point(3, 506);
            this.pnlDugmeler.Name = "pnlDugmeler";
            this.pnlDugmeler.Size = new System.Drawing.Size(344, 71);
            this.pnlDugmeler.TabIndex = 1;
            // 
            // btnTemizle
            // 
            this.btnTemizle.Location = new System.Drawing.Point(240, 20);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(100, 35);
            this.btnTemizle.TabIndex = 3;
            this.btnTemizle.Text = "Təmizlə";
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(160, 20);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(75, 35);
            this.btnSil.TabIndex = 2;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnYenile
            // 
            this.btnYenile.Location = new System.Drawing.Point(80, 20);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(75, 35);
            this.btnYenile.TabIndex = 1;
            this.btnYenile.Text = "Yenilə";
            this.btnYenile.UseVisualStyleBackColor = true;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // btnYarat
            // 
            this.btnYarat.Location = new System.Drawing.Point(5, 20);
            this.btnYarat.Name = "btnYarat";
            this.btnYarat.Size = new System.Drawing.Size(70, 35);
            this.btnYarat.TabIndex = 0;
            this.btnYarat.Text = "Yarat";
            this.btnYarat.UseVisualStyleBackColor = true;
            this.btnYarat.Click += new System.EventHandler(this.btnYarat_Click);
            // 
            // grpIsciler
            // 
            this.grpIsciler.Controls.Add(this.dgvIsciler);
            this.grpIsciler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpIsciler.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.grpIsciler.Location = new System.Drawing.Point(0, 0);
            this.grpIsciler.Name = "grpIsciler";
            this.grpIsciler.Size = new System.Drawing.Size(626, 580);
            this.grpIsciler.TabIndex = 0;
            this.grpIsciler.TabStop = false;
            this.grpIsciler.Text = "İşçilər";
            // 
            // dgvIsciler
            // 
            this.dgvIsciler.AllowUserToAddRows = false;
            this.dgvIsciler.AllowUserToDeleteRows = false;
            this.dgvIsciler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIsciler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIsciler.Location = new System.Drawing.Point(3, 21);
            this.dgvIsciler.MultiSelect = false;
            this.dgvIsciler.Name = "dgvIsciler";
            this.dgvIsciler.ReadOnly = true;
            this.dgvIsciler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIsciler.Size = new System.Drawing.Size(620, 556);
            this.dgvIsciler.TabIndex = 0;
            this.dgvIsciler.SelectionChanged += new System.EventHandler(this.dgvIsciler_SelectionChanged);
            // 
            // IsciIdareetmeFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 660);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTop);
            this.Name = "IsciIdareetmeFormu";
            this.Text = "İşçi İdarəetmə";
            this.Load += new System.EventHandler(this.IsciIdareetmeFormu_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpIsciMelumatlari.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlDugmeler.ResumeLayout(false);
            this.grpIsciler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIsciler)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Label lblTelefonNomresi;
        private System.Windows.Forms.TextBox txtTelefonNomresi;
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
        private System.Windows.Forms.Label lblSistemIstifadeciAdi;
        private System.Windows.Forms.TextBox txtSistemIstifadeciAdi;
        private System.Windows.Forms.Panel pnlDugmeler;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnYenile;
        private System.Windows.Forms.Button btnYarat;
        private System.Windows.Forms.GroupBox grpIsciler;
        private System.Windows.Forms.DataGridView dgvIsciler;
    }
}