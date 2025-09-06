namespace AzAgroPOS.Teqdimat
{
    partial class TedarukcuIdareetmeFormu
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
            grpTedarukcuMelumatlari = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblId = new Label();
            txtId = new TextBox();
            lblAd = new Label();
            txtAd = new TextBox();
            lblVoen = new Label();
            txtVoen = new TextBox();
            lblUnvan = new Label();
            txtUnvan = new TextBox();
            lblTelefon = new Label();
            txtTelefon = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblBankHesabi = new Label();
            txtBankHesabi = new TextBox();
            chkAktivdir = new CheckBox();
            pnlDugmeler = new Panel();
            btnTemizle = new Button();
            btnSil = new Button();
            btnYenile = new Button();
            btnYarat = new Button();
            grpTedarukculer = new GroupBox();
            dgvTedarukculer = new DataGridView();
            pnlTop.SuspendLayout();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            grpTedarukcuMelumatlari.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            pnlDugmeler.SuspendLayout();
            grpTedarukculer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTedarukculer).BeginInit();
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
            lblBaslik.Text = "Tədarükçü İdarəetmə";
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
            splitContainer1.Panel1.Controls.Add(grpTedarukcuMelumatlari);
            splitContainer1.Panel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            splitContainer1.Panel1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            splitContainer1.Panel1MinSize = 300;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.FromArgb(242, 242, 242);
            splitContainer1.Panel2.Controls.Add(grpTedarukculer);
            splitContainer1.Panel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            splitContainer1.Panel2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            splitContainer1.Size = new Size(974, 513);
            splitContainer1.SplitterDistance = 347;
            splitContainer1.TabIndex = 0;
            // 
            // grpTedarukcuMelumatlari
            // 
            grpTedarukcuMelumatlari.BackColor = Color.FromArgb(242, 242, 242);
            grpTedarukcuMelumatlari.Controls.Add(tableLayoutPanel1);
            grpTedarukcuMelumatlari.Controls.Add(pnlDugmeler);
            grpTedarukcuMelumatlari.Dock = DockStyle.Fill;
            grpTedarukcuMelumatlari.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            grpTedarukcuMelumatlari.ForeColor = Color.FromArgb(222, 0, 0, 0);
            grpTedarukcuMelumatlari.Location = new Point(0, 0);
            grpTedarukcuMelumatlari.Name = "grpTedarukcuMelumatlari";
            grpTedarukcuMelumatlari.Size = new Size(347, 513);
            grpTedarukcuMelumatlari.TabIndex = 0;
            grpTedarukcuMelumatlari.TabStop = false;
            grpTedarukcuMelumatlari.Text = "Tədarükçü Məlumatları";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.FromArgb(242, 242, 242);
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.Controls.Add(lblId, 0, 0);
            tableLayoutPanel1.Controls.Add(txtId, 1, 0);
            tableLayoutPanel1.Controls.Add(lblAd, 0, 1);
            tableLayoutPanel1.Controls.Add(txtAd, 1, 1);
            tableLayoutPanel1.Controls.Add(lblVoen, 0, 2);
            tableLayoutPanel1.Controls.Add(txtVoen, 1, 2);
            tableLayoutPanel1.Controls.Add(lblUnvan, 0, 3);
            tableLayoutPanel1.Controls.Add(txtUnvan, 1, 3);
            tableLayoutPanel1.Controls.Add(lblTelefon, 0, 4);
            tableLayoutPanel1.Controls.Add(txtTelefon, 1, 4);
            tableLayoutPanel1.Controls.Add(lblEmail, 0, 5);
            tableLayoutPanel1.Controls.Add(txtEmail, 1, 5);
            tableLayoutPanel1.Controls.Add(lblBankHesabi, 0, 6);
            tableLayoutPanel1.Controls.Add(txtBankHesabi, 1, 6);
            tableLayoutPanel1.Controls.Add(chkAktivdir, 1, 7);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            tableLayoutPanel1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            tableLayoutPanel1.Location = new Point(3, 20);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 9;
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
            // lblAd
            // 
            lblAd.AutoSize = true;
            lblAd.BackColor = Color.FromArgb(242, 242, 242);
            lblAd.Dock = DockStyle.Fill;
            lblAd.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblAd.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblAd.Location = new Point(3, 35);
            lblAd.Name = "lblAd";
            lblAd.Size = new Size(96, 35);
            lblAd.TabIndex = 2;
            lblAd.Text = "Ad:";
            lblAd.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtAd
            // 
            txtAd.BackColor = Color.FromArgb(242, 242, 242);
            txtAd.Dock = DockStyle.Fill;
            txtAd.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtAd.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtAd.Location = new Point(105, 38);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(233, 24);
            txtAd.TabIndex = 3;
            // 
            // lblVoen
            // 
            lblVoen.AutoSize = true;
            lblVoen.BackColor = Color.FromArgb(242, 242, 242);
            lblVoen.Dock = DockStyle.Fill;
            lblVoen.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblVoen.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblVoen.Location = new Point(3, 70);
            lblVoen.Name = "lblVoen";
            lblVoen.Size = new Size(96, 35);
            lblVoen.TabIndex = 4;
            lblVoen.Text = "VÖEN:";
            lblVoen.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtVoen
            // 
            txtVoen.BackColor = Color.FromArgb(242, 242, 242);
            txtVoen.Dock = DockStyle.Fill;
            txtVoen.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtVoen.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtVoen.Location = new Point(105, 73);
            txtVoen.Name = "txtVoen";
            txtVoen.Size = new Size(233, 24);
            txtVoen.TabIndex = 5;
            // 
            // lblUnvan
            // 
            lblUnvan.AutoSize = true;
            lblUnvan.BackColor = Color.FromArgb(242, 242, 242);
            lblUnvan.Dock = DockStyle.Fill;
            lblUnvan.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblUnvan.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblUnvan.Location = new Point(3, 105);
            lblUnvan.Name = "lblUnvan";
            lblUnvan.Size = new Size(96, 35);
            lblUnvan.TabIndex = 6;
            lblUnvan.Text = "Ünvan:";
            lblUnvan.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtUnvan
            // 
            txtUnvan.BackColor = Color.FromArgb(242, 242, 242);
            txtUnvan.Dock = DockStyle.Fill;
            txtUnvan.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtUnvan.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtUnvan.Location = new Point(105, 108);
            txtUnvan.Name = "txtUnvan";
            txtUnvan.Size = new Size(233, 24);
            txtUnvan.TabIndex = 7;
            // 
            // lblTelefon
            // 
            lblTelefon.AutoSize = true;
            lblTelefon.BackColor = Color.FromArgb(242, 242, 242);
            lblTelefon.Dock = DockStyle.Fill;
            lblTelefon.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblTelefon.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblTelefon.Location = new Point(3, 140);
            lblTelefon.Name = "lblTelefon";
            lblTelefon.Size = new Size(96, 35);
            lblTelefon.TabIndex = 8;
            lblTelefon.Text = "Telefon:";
            lblTelefon.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtTelefon
            // 
            txtTelefon.BackColor = Color.FromArgb(242, 242, 242);
            txtTelefon.Dock = DockStyle.Fill;
            txtTelefon.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtTelefon.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtTelefon.Location = new Point(105, 143);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(233, 24);
            txtTelefon.TabIndex = 9;
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
            // lblBankHesabi
            // 
            lblBankHesabi.AutoSize = true;
            lblBankHesabi.BackColor = Color.FromArgb(242, 242, 242);
            lblBankHesabi.Dock = DockStyle.Fill;
            lblBankHesabi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblBankHesabi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblBankHesabi.Location = new Point(3, 210);
            lblBankHesabi.Name = "lblBankHesabi";
            lblBankHesabi.Size = new Size(96, 35);
            lblBankHesabi.TabIndex = 12;
            lblBankHesabi.Text = "Bank Hesabı:";
            lblBankHesabi.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtBankHesabi
            // 
            txtBankHesabi.BackColor = Color.FromArgb(242, 242, 242);
            txtBankHesabi.Dock = DockStyle.Fill;
            txtBankHesabi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtBankHesabi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtBankHesabi.Location = new Point(105, 213);
            txtBankHesabi.Name = "txtBankHesabi";
            txtBankHesabi.Size = new Size(233, 24);
            txtBankHesabi.TabIndex = 13;
            // 
            // chkAktivdir
            // 
            chkAktivdir.AutoSize = true;
            chkAktivdir.BackColor = Color.FromArgb(242, 242, 242);
            chkAktivdir.Checked = true;
            chkAktivdir.CheckState = CheckState.Checked;
            chkAktivdir.Dock = DockStyle.Fill;
            chkAktivdir.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            chkAktivdir.ForeColor = Color.FromArgb(222, 0, 0, 0);
            chkAktivdir.Location = new Point(105, 248);
            chkAktivdir.Name = "chkAktivdir";
            chkAktivdir.Size = new Size(233, 29);
            chkAktivdir.TabIndex = 14;
            chkAktivdir.Text = "Aktivdir";
            chkAktivdir.UseVisualStyleBackColor = false;
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
            // grpTedarukculer
            // 
            grpTedarukculer.BackColor = Color.FromArgb(242, 242, 242);
            grpTedarukculer.Controls.Add(dgvTedarukculer);
            grpTedarukculer.Dock = DockStyle.Fill;
            grpTedarukculer.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            grpTedarukculer.ForeColor = Color.FromArgb(222, 0, 0, 0);
            grpTedarukculer.Location = new Point(0, 0);
            grpTedarukculer.Name = "grpTedarukculer";
            grpTedarukculer.Size = new Size(623, 513);
            grpTedarukculer.TabIndex = 0;
            grpTedarukculer.TabStop = false;
            grpTedarukculer.Text = "Tədarükçülər";
            // 
            // dgvTedarukculer
            // 
            dgvTedarukculer.AllowUserToAddRows = false;
            dgvTedarukculer.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvTedarukculer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvTedarukculer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvTedarukculer.DefaultCellStyle = dataGridViewCellStyle2;
            dgvTedarukculer.Dock = DockStyle.Fill;
            dgvTedarukculer.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvTedarukculer.Location = new Point(3, 20);
            dgvTedarukculer.MultiSelect = false;
            dgvTedarukculer.Name = "dgvTedarukculer";
            dgvTedarukculer.ReadOnly = true;
            dgvTedarukculer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTedarukculer.Size = new Size(617, 490);
            dgvTedarukculer.TabIndex = 0;
            dgvTedarukculer.SelectionChanged += dgvTedarukculer_SelectionChanged;
            // 
            // TedarukcuIdareetmeFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 660);
            Controls.Add(pnlMain);
            Controls.Add(pnlTop);
            Name = "TedarukcuIdareetmeFormu";
            Text = "Tədarükçü İdarəetmə";
            Load += TedarukcuIdareetmeFormu_Load;
            pnlTop.ResumeLayout(false);
            pnlMain.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            grpTedarukcuMelumatlari.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            pnlDugmeler.ResumeLayout(false);
            grpTedarukculer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTedarukculer).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpTedarukcuMelumatlari;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblAd;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.Label lblVoen;
        private System.Windows.Forms.TextBox txtVoen;
        private System.Windows.Forms.Label lblUnvan;
        private System.Windows.Forms.TextBox txtUnvan;
        private System.Windows.Forms.Label lblTelefon;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblBankHesabi;
        private System.Windows.Forms.TextBox txtBankHesabi;
        private System.Windows.Forms.CheckBox chkAktivdir;
        private System.Windows.Forms.Panel pnlDugmeler;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnYenile;
        private System.Windows.Forms.Button btnYarat;
        private System.Windows.Forms.GroupBox grpTedarukculer;
        private System.Windows.Forms.DataGridView dgvTedarukculer;
    }
}