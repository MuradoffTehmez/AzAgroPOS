namespace AzAgroPOS.PL.Forms
{
    partial class POSForm
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.dgvSatisDetallari = new System.Windows.Forms.DataGridView();
            this.colBarkod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMehsulAdi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMiqdar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQiymet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSil = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panelSatisInfo = new System.Windows.Forms.Panel();
            this.lblUmumiMebleg = new System.Windows.Forms.Label();
            this.lblUmumiMeblegValue = new System.Windows.Forms.Label();
            this.lblEndirim = new System.Windows.Forms.Label();
            this.txtEndirim = new System.Windows.Forms.TextBox();
            this.lblVergi = new System.Windows.Forms.Label();
            this.lblVergiValue = new System.Windows.Forms.Label();
            this.lblNetMebleg = new System.Windows.Forms.Label();
            this.lblNetMeblegValue = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.groupBoxBarkod = new System.Windows.Forms.GroupBox();
            this.txtBarkod = new System.Windows.Forms.TextBox();
            this.btnBarkodOxu = new System.Windows.Forms.Button();
            this.groupBoxMehsulAxtaris = new System.Windows.Forms.GroupBox();
            this.txtMehsulAxtaris = new System.Windows.Forms.TextBox();
            this.lstMehsullar = new System.Windows.Forms.ListBox();
            this.groupBoxOdeme = new System.Windows.Forms.GroupBox();
            this.rbNagd = new System.Windows.Forms.RadioButton();
            this.rbKart = new System.Windows.Forms.RadioButton();
            this.rbNisye = new System.Windows.Forms.RadioButton();
            this.txtOdemeDetali = new System.Windows.Forms.TextBox();
            this.lblOdemeDetali = new System.Windows.Forms.Label();
            this.btnSatisıTamamla = new System.Windows.Forms.Button();
            this.btnYeniSatis = new System.Windows.Forms.Button();
            this.btnQezbCap = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelTop.SuspendLayout();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSatisDetallari)).BeginInit();
            this.panelSatisInfo.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.groupBoxBarkod.SuspendLayout();
            this.groupBoxMehsulAxtaris.SuspendLayout();
            this.groupBoxOdeme.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Controls.Add(this.btnMinimize);
            this.panelTop.Controls.Add(this.btnClose);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1200, 40);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(129, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "POS - Satış";
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(1128, 5);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(30, 30);
            this.btnMinimize.TabIndex = 1;
            this.btnMinimize.Text = "−";
            this.btnMinimize.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1164, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "×";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.dgvSatisDetallari);
            this.panelLeft.Controls.Add(this.panelSatisInfo);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 40);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(800, 587);
            this.panelLeft.TabIndex = 1;
            // 
            // dgvSatisDetallari
            // 
            this.dgvSatisDetallari.AllowUserToAddRows = false;
            this.dgvSatisDetallari.BackgroundColor = System.Drawing.Color.White;
            this.dgvSatisDetallari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSatisDetallari.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBarkod,
            this.colMehsulAdi,
            this.colMiqdar,
            this.colQiymet,
            this.colCem,
            this.colSil});
            this.dgvSatisDetallari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSatisDetallari.Location = new System.Drawing.Point(0, 0);
            this.dgvSatisDetallari.Name = "dgvSatisDetallari";
            this.dgvSatisDetallari.Size = new System.Drawing.Size(800, 437);
            this.dgvSatisDetallari.TabIndex = 0;
            // 
            // colBarkod
            // 
            this.colBarkod.HeaderText = "Barkod";
            this.colBarkod.Name = "colBarkod";
            this.colBarkod.ReadOnly = true;
            this.colBarkod.Width = 120;
            // 
            // colMehsulAdi
            // 
            this.colMehsulAdi.HeaderText = "Məhsul Adı";
            this.colMehsulAdi.Name = "colMehsulAdi";
            this.colMehsulAdi.ReadOnly = true;
            this.colMehsulAdi.Width = 250;
            // 
            // colMiqdar
            // 
            this.colMiqdar.HeaderText = "Miqdar";
            this.colMiqdar.Name = "colMiqdar";
            this.colMiqdar.Width = 80;
            // 
            // colQiymet
            // 
            this.colQiymet.HeaderText = "Qiymət";
            this.colQiymet.Name = "colQiymet";
            this.colQiymet.ReadOnly = true;
            this.colQiymet.Width = 100;
            // 
            // colCem
            // 
            this.colCem.HeaderText = "Cəm";
            this.colCem.Name = "colCem";
            this.colCem.ReadOnly = true;
            this.colCem.Width = 120;
            // 
            // colSil
            // 
            this.colSil.HeaderText = "Sil";
            this.colSil.Name = "colSil";
            this.colSil.Text = "Sil";
            this.colSil.UseColumnTextForButtonValue = true;
            this.colSil.Width = 60;
            // 
            // panelSatisInfo
            // 
            this.panelSatisInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelSatisInfo.Controls.Add(this.lblNetMeblegValue);
            this.panelSatisInfo.Controls.Add(this.lblNetMebleg);
            this.panelSatisInfo.Controls.Add(this.lblVergiValue);
            this.panelSatisInfo.Controls.Add(this.lblVergi);
            this.panelSatisInfo.Controls.Add(this.txtEndirim);
            this.panelSatisInfo.Controls.Add(this.lblEndirim);
            this.panelSatisInfo.Controls.Add(this.lblUmumiMeblegValue);
            this.panelSatisInfo.Controls.Add(this.lblUmumiMebleg);
            this.panelSatisInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSatisInfo.Location = new System.Drawing.Point(0, 437);
            this.panelSatisInfo.Name = "panelSatisInfo";
            this.panelSatisInfo.Size = new System.Drawing.Size(800, 150);
            this.panelSatisInfo.TabIndex = 1;
            // 
            // lblUmumiMebleg
            // 
            this.lblUmumiMebleg.AutoSize = true;
            this.lblUmumiMebleg.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblUmumiMebleg.Location = new System.Drawing.Point(12, 15);
            this.lblUmumiMebleg.Name = "lblUmumiMebleg";
            this.lblUmumiMebleg.Size = new System.Drawing.Size(117, 21);
            this.lblUmumiMebleg.TabIndex = 0;
            this.lblUmumiMebleg.Text = "Ümumi Məbləğ:";
            // 
            // lblUmumiMeblegValue
            // 
            this.lblUmumiMeblegValue.AutoSize = true;
            this.lblUmumiMeblegValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblUmumiMeblegValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblUmumiMeblegValue.Location = new System.Drawing.Point(150, 12);
            this.lblUmumiMeblegValue.Name = "lblUmumiMeblegValue";
            this.lblUmumiMeblegValue.Size = new System.Drawing.Size(68, 25);
            this.lblUmumiMeblegValue.TabIndex = 1;
            this.lblUmumiMeblegValue.Text = "0.00 ₼";
            // 
            // lblEndirim
            // 
            this.lblEndirim.AutoSize = true;
            this.lblEndirim.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblEndirim.Location = new System.Drawing.Point(12, 50);
            this.lblEndirim.Name = "lblEndirim";
            this.lblEndirim.Size = new System.Drawing.Size(71, 21);
            this.lblEndirim.TabIndex = 2;
            this.lblEndirim.Text = "Endirim:";
            // 
            // txtEndirim
            // 
            this.txtEndirim.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtEndirim.Location = new System.Drawing.Point(150, 47);
            this.txtEndirim.Name = "txtEndirim";
            this.txtEndirim.Size = new System.Drawing.Size(100, 29);
            this.txtEndirim.TabIndex = 3;
            this.txtEndirim.Text = "0.00";
            this.txtEndirim.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblVergi
            // 
            this.lblVergi.AutoSize = true;
            this.lblVergi.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblVergi.Location = new System.Drawing.Point(12, 85);
            this.lblVergi.Name = "lblVergi";
            this.lblVergi.Size = new System.Drawing.Size(84, 21);
            this.lblVergi.TabIndex = 4;
            this.lblVergi.Text = "Vergi (18%):";
            // 
            // lblVergiValue
            // 
            this.lblVergiValue.AutoSize = true;
            this.lblVergiValue.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblVergiValue.Location = new System.Drawing.Point(150, 85);
            this.lblVergiValue.Name = "lblVergiValue";
            this.lblVergiValue.Size = new System.Drawing.Size(48, 21);
            this.lblVergiValue.TabIndex = 5;
            this.lblVergiValue.Text = "0.00 ₼";
            // 
            // lblNetMebleg
            // 
            this.lblNetMebleg.AutoSize = true;
            this.lblNetMebleg.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblNetMebleg.Location = new System.Drawing.Point(12, 115);
            this.lblNetMebleg.Name = "lblNetMebleg";
            this.lblNetMebleg.Size = new System.Drawing.Size(126, 25);
            this.lblNetMebleg.TabIndex = 6;
            this.lblNetMebleg.Text = "Net Məbləğ:";
            // 
            // lblNetMeblegValue
            // 
            this.lblNetMeblegValue.AutoSize = true;
            this.lblNetMeblegValue.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblNetMeblegValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblNetMeblegValue.Location = new System.Drawing.Point(150, 110);
            this.lblNetMeblegValue.Name = "lblNetMeblegValue";
            this.lblNetMeblegValue.Size = new System.Drawing.Size(88, 32);
            this.lblNetMeblegValue.TabIndex = 7;
            this.lblNetMeblegValue.Text = "0.00 ₼";
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.btnQezbCap);
            this.panelRight.Controls.Add(this.btnYeniSatis);
            this.panelRight.Controls.Add(this.btnSatisıTamamla);
            this.panelRight.Controls.Add(this.groupBoxOdeme);
            this.panelRight.Controls.Add(this.groupBoxMehsulAxtaris);
            this.panelRight.Controls.Add(this.groupBoxBarkod);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(800, 40);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(400, 587);
            this.panelRight.TabIndex = 2;
            // 
            // groupBoxBarkod
            // 
            this.groupBoxBarkod.Controls.Add(this.btnBarkodOxu);
            this.groupBoxBarkod.Controls.Add(this.txtBarkod);
            this.groupBoxBarkod.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupBoxBarkod.Location = new System.Drawing.Point(12, 12);
            this.groupBoxBarkod.Name = "groupBoxBarkod";
            this.groupBoxBarkod.Size = new System.Drawing.Size(376, 80);
            this.groupBoxBarkod.TabIndex = 0;
            this.groupBoxBarkod.TabStop = false;
            this.groupBoxBarkod.Text = "Barkod Oxuma";
            // 
            // txtBarkod
            // 
            this.txtBarkod.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtBarkod.Location = new System.Drawing.Point(15, 30);
            this.txtBarkod.Name = "txtBarkod";
            this.txtBarkod.Size = new System.Drawing.Size(250, 32);
            this.txtBarkod.TabIndex = 0;
            // 
            // btnBarkodOxu
            // 
            this.btnBarkodOxu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnBarkodOxu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBarkodOxu.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnBarkodOxu.ForeColor = System.Drawing.Color.White;
            this.btnBarkodOxu.Location = new System.Drawing.Point(275, 30);
            this.btnBarkodOxu.Name = "btnBarkodOxu";
            this.btnBarkodOxu.Size = new System.Drawing.Size(85, 32);
            this.btnBarkodOxu.TabIndex = 1;
            this.btnBarkodOxu.Text = "Əlavə Et";
            this.btnBarkodOxu.UseVisualStyleBackColor = false;
            // 
            // groupBoxMehsulAxtaris
            // 
            this.groupBoxMehsulAxtaris.Controls.Add(this.lstMehsullar);
            this.groupBoxMehsulAxtaris.Controls.Add(this.txtMehsulAxtaris);
            this.groupBoxMehsulAxtaris.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupBoxMehsulAxtaris.Location = new System.Drawing.Point(12, 98);
            this.groupBoxMehsulAxtaris.Name = "groupBoxMehsulAxtaris";
            this.groupBoxMehsulAxtaris.Size = new System.Drawing.Size(376, 200);
            this.groupBoxMehsulAxtaris.TabIndex = 1;
            this.groupBoxMehsulAxtaris.TabStop = false;
            this.groupBoxMehsulAxtaris.Text = "Məhsul Axtarışı";
            // 
            // txtMehsulAxtaris
            // 
            this.txtMehsulAxtaris.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtMehsulAxtaris.Location = new System.Drawing.Point(15, 30);
            this.txtMehsulAxtaris.Name = "txtMehsulAxtaris";
            this.txtMehsulAxtaris.Size = new System.Drawing.Size(345, 29);
            this.txtMehsulAxtaris.TabIndex = 0;
            // 
            // lstMehsullar
            // 
            this.lstMehsullar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lstMehsullar.FormattingEnabled = true;
            this.lstMehsullar.ItemHeight = 17;
            this.lstMehsullar.Location = new System.Drawing.Point(15, 65);
            this.lstMehsullar.Name = "lstMehsullar";
            this.lstMehsullar.Size = new System.Drawing.Size(345, 123);
            this.lstMehsullar.TabIndex = 1;
            // 
            // groupBoxOdeme
            // 
            this.groupBoxOdeme.Controls.Add(this.lblOdemeDetali);
            this.groupBoxOdeme.Controls.Add(this.txtOdemeDetali);
            this.groupBoxOdeme.Controls.Add(this.rbNisye);
            this.groupBoxOdeme.Controls.Add(this.rbKart);
            this.groupBoxOdeme.Controls.Add(this.rbNagd);
            this.groupBoxOdeme.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.groupBoxOdeme.Location = new System.Drawing.Point(12, 304);
            this.groupBoxOdeme.Name = "groupBoxOdeme";
            this.groupBoxOdeme.Size = new System.Drawing.Size(376, 150);
            this.groupBoxOdeme.TabIndex = 2;
            this.groupBoxOdeme.TabStop = false;
            this.groupBoxOdeme.Text = "Ödəmə Növü";
            // 
            // rbNagd
            // 
            this.rbNagd.AutoSize = true;
            this.rbNagd.Checked = true;
            this.rbNagd.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.rbNagd.Location = new System.Drawing.Point(15, 30);
            this.rbNagd.Name = "rbNagd";
            this.rbNagd.Size = new System.Drawing.Size(62, 25);
            this.rbNagd.TabIndex = 0;
            this.rbNagd.TabStop = true;
            this.rbNagd.Text = "Nağd";
            this.rbNagd.UseVisualStyleBackColor = true;
            // 
            // rbKart
            // 
            this.rbKart.AutoSize = true;
            this.rbKart.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.rbKart.Location = new System.Drawing.Point(100, 30);
            this.rbKart.Name = "rbKart";
            this.rbKart.Size = new System.Drawing.Size(56, 25);
            this.rbKart.TabIndex = 1;
            this.rbKart.Text = "Kart";
            this.rbKart.UseVisualStyleBackColor = true;
            // 
            // rbNisye
            // 
            this.rbNisye.AutoSize = true;
            this.rbNisye.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.rbNisye.Location = new System.Drawing.Point(180, 30);
            this.rbNisye.Name = "rbNisye";
            this.rbNisye.Size = new System.Drawing.Size(67, 25);
            this.rbNisye.TabIndex = 2;
            this.rbNisye.Text = "Nisyə";
            this.rbNisye.UseVisualStyleBackColor = true;
            // 
            // txtOdemeDetali
            // 
            this.txtOdemeDetali.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtOdemeDetali.Location = new System.Drawing.Point(15, 85);
            this.txtOdemeDetali.Multiline = true;
            this.txtOdemeDetali.Name = "txtOdemeDetali";
            this.txtOdemeDetali.Size = new System.Drawing.Size(345, 50);
            this.txtOdemeDetali.TabIndex = 3;
            // 
            // lblOdemeDetali
            // 
            this.lblOdemeDetali.AutoSize = true;
            this.lblOdemeDetali.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblOdemeDetali.Location = new System.Drawing.Point(15, 65);
            this.lblOdemeDetali.Name = "lblOdemeDetali";
            this.lblOdemeDetali.Size = new System.Drawing.Size(95, 19);
            this.lblOdemeDetali.TabIndex = 4;
            this.lblOdemeDetali.Text = "Ödəmə Detali:";
            // 
            // btnSatisıTamamla
            // 
            this.btnSatisıTamamla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSatisıTamamla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSatisıTamamla.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnSatisıTamamla.ForeColor = System.Drawing.Color.White;
            this.btnSatisıTamamla.Location = new System.Drawing.Point(12, 470);
            this.btnSatisıTamamla.Name = "btnSatisıTamamla";
            this.btnSatisıTamamla.Size = new System.Drawing.Size(376, 50);
            this.btnSatisıTamamla.TabIndex = 3;
            this.btnSatisıTamamla.Text = "Satışı Tamamla";
            this.btnSatisıTamamla.UseVisualStyleBackColor = false;
            // 
            // btnYeniSatis
            // 
            this.btnYeniSatis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnYeniSatis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYeniSatis.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnYeniSatis.ForeColor = System.Drawing.Color.White;
            this.btnYeniSatis.Location = new System.Drawing.Point(12, 530);
            this.btnYeniSatis.Name = "btnYeniSatis";
            this.btnYeniSatis.Size = new System.Drawing.Size(180, 40);
            this.btnYeniSatis.TabIndex = 4;
            this.btnYeniSatis.Text = "Yeni Satış";
            this.btnYeniSatis.UseVisualStyleBackColor = false;
            // 
            // btnQezbCap
            // 
            this.btnQezbCap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnQezbCap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQezbCap.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnQezbCap.ForeColor = System.Drawing.Color.White;
            this.btnQezbCap.Location = new System.Drawing.Point(208, 530);
            this.btnQezbCap.Name = "btnQezbCap";
            this.btnQezbCap.Size = new System.Drawing.Size(180, 40);
            this.btnQezbCap.TabIndex = 5;
            this.btnQezbCap.Text = "Qəbz Çapı";
            this.btnQezbCap.UseVisualStyleBackColor = false;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 627);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1200, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Hazır";
            // 
            // POSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 649);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.statusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "POSForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "POS - Satış";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSatisDetallari)).EndInit();
            this.panelSatisInfo.ResumeLayout(false);
            this.panelSatisInfo.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.groupBoxBarkod.ResumeLayout(false);
            this.groupBoxBarkod.PerformLayout();
            this.groupBoxMehsulAxtaris.ResumeLayout(false);
            this.groupBoxMehsulAxtaris.PerformLayout();
            this.groupBoxOdeme.ResumeLayout(false);
            this.groupBoxOdeme.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.DataGridView dgvSatisDetallari;
        private System.Windows.Forms.Panel panelSatisInfo;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.GroupBox groupBoxBarkod;
        private System.Windows.Forms.TextBox txtBarkod;
        private System.Windows.Forms.Button btnBarkodOxu;
        private System.Windows.Forms.GroupBox groupBoxMehsulAxtaris;
        private System.Windows.Forms.TextBox txtMehsulAxtaris;
        private System.Windows.Forms.ListBox lstMehsullar;
        private System.Windows.Forms.GroupBox groupBoxOdeme;
        private System.Windows.Forms.RadioButton rbNagd;
        private System.Windows.Forms.RadioButton rbKart;
        private System.Windows.Forms.RadioButton rbNisye;
        private System.Windows.Forms.TextBox txtOdemeDetali;
        private System.Windows.Forms.Label lblOdemeDetali;
        private System.Windows.Forms.Button btnSatisıTamamla;
        private System.Windows.Forms.Button btnYeniSatis;
        private System.Windows.Forms.Button btnQezbCap;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Label lblUmumiMebleg;
        private System.Windows.Forms.Label lblUmumiMeblegValue;
        private System.Windows.Forms.Label lblEndirim;
        private System.Windows.Forms.TextBox txtEndirim;
        private System.Windows.Forms.Label lblVergi;
        private System.Windows.Forms.Label lblVergiValue;
        private System.Windows.Forms.Label lblNetMebleg;
        private System.Windows.Forms.Label lblNetMeblegValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarkod;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMehsulAdi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMiqdar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQiymet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCem;
        private System.Windows.Forms.DataGridViewButtonColumn colSil;
    }
}