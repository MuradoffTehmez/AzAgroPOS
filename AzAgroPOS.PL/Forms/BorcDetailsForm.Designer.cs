namespace AzAgroPOS.PL.Forms
{
    partial class BorcDetailsForm
    {
        private System.ComponentModel.IContainer components = null;

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDebtInfo = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblStatusLabel = new System.Windows.Forms.Label();
            this.lblBorcTipi = new System.Windows.Forms.Label();
            this.lblBorcTipiLabel = new System.Windows.Forms.Label();
            this.lblMusteriAdi = new System.Windows.Forms.Label();
            this.lblMusteriAdiLabel = new System.Windows.Forms.Label();
            this.lblBorcNomresi = new System.Windows.Forms.Label();
            this.lblBorcNomresiLabel = new System.Windows.Forms.Label();
            this.lblDebtInfoTitle = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblUmumiBorc = new System.Windows.Forms.Label();
            this.lblUmumiBorcLabel = new System.Windows.Forms.Label();
            this.lblFaizMeblegi = new System.Windows.Forms.Label();
            this.lblFaizMeblegLabel = new System.Windows.Forms.Label();
            this.lblQalanBorc = new System.Windows.Forms.Label();
            this.lblQalanBorcLabel = new System.Windows.Forms.Label();
            this.lblOdenilmisMebleg = new System.Windows.Forms.Label();
            this.lblOdenilmisMeblegLabel = new System.Windows.Forms.Label();
            this.lblBorcMeblegi = new System.Windows.Forms.Label();
            this.lblBorcMeblegLabel = new System.Windows.Forms.Label();
            this.lblAmountInfoTitle = new System.Windows.Forms.Label();
            this.tabPaymentHistory = new System.Windows.Forms.TabPage();
            this.dgvPayments = new System.Windows.Forms.DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblTotalPayments = new System.Windows.Forms.Label();
            this.lblTotalPaymentsLabel = new System.Windows.Forms.Label();
            this.lblPaymentHistoryTitle = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrintReport = new System.Windows.Forms.Button();
            this.btnEditDebt = new System.Windows.Forms.Button();
            this.btnAddPayment = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabDebtInfo.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPaymentHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 60);
            this.panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(246, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Borc Təfərrüatları";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDebtInfo);
            this.tabControl1.Controls.Add(this.tabPaymentHistory);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tabControl1.Location = new System.Drawing.Point(0, 60);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(900, 450);
            this.tabControl1.TabIndex = 1;
            // 
            // tabDebtInfo
            // 
            this.tabDebtInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.tabDebtInfo.Controls.Add(this.panel3);
            this.tabDebtInfo.Controls.Add(this.panel2);
            this.tabDebtInfo.Location = new System.Drawing.Point(4, 29);
            this.tabDebtInfo.Name = "tabDebtInfo";
            this.tabDebtInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabDebtInfo.Size = new System.Drawing.Size(892, 417);
            this.tabDebtInfo.TabIndex = 0;
            this.tabDebtInfo.Text = "Borc Məlumatları";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblStatus);
            this.panel2.Controls.Add(this.lblStatusLabel);
            this.panel2.Controls.Add(this.lblBorcTipi);
            this.panel2.Controls.Add(this.lblBorcTipiLabel);
            this.panel2.Controls.Add(this.lblMusteriAdi);
            this.panel2.Controls.Add(this.lblMusteriAdiLabel);
            this.panel2.Controls.Add(this.lblBorcNomresi);
            this.panel2.Controls.Add(this.lblBorcNomresiLabel);
            this.panel2.Controls.Add(this.lblDebtInfoTitle);
            this.panel2.Location = new System.Drawing.Point(20, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(420, 180);
            this.panel2.TabIndex = 0;
            // 
            // lblDebtInfoTitle
            // 
            this.lblDebtInfoTitle.AutoSize = true;
            this.lblDebtInfoTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDebtInfoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblDebtInfoTitle.Location = new System.Drawing.Point(15, 15);
            this.lblDebtInfoTitle.Name = "lblDebtInfoTitle";
            this.lblDebtInfoTitle.Size = new System.Drawing.Size(142, 25);
            this.lblDebtInfoTitle.TabIndex = 0;
            this.lblDebtInfoTitle.Text = "Əsas Məlumatlar";
            // 
            // lblBorcNomresiLabel
            // 
            this.lblBorcNomresiLabel.AutoSize = true;
            this.lblBorcNomresiLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBorcNomresiLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblBorcNomresiLabel.Location = new System.Drawing.Point(20, 55);
            this.lblBorcNomresiLabel.Name = "lblBorcNomresiLabel";
            this.lblBorcNomresiLabel.Size = new System.Drawing.Size(100, 19);
            this.lblBorcNomresiLabel.TabIndex = 1;
            this.lblBorcNomresiLabel.Text = "Borc Nömrəsi:";
            // 
            // lblBorcNomresi
            // 
            this.lblBorcNomresi.AutoSize = true;
            this.lblBorcNomresi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBorcNomresi.Location = new System.Drawing.Point(150, 55);
            this.lblBorcNomresi.Name = "lblBorcNomresi";
            this.lblBorcNomresi.Size = new System.Drawing.Size(17, 19);
            this.lblBorcNomresi.TabIndex = 2;
            this.lblBorcNomresi.Text = "-";
            // 
            // lblMusteriAdiLabel
            // 
            this.lblMusteriAdiLabel.AutoSize = true;
            this.lblMusteriAdiLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMusteriAdiLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblMusteriAdiLabel.Location = new System.Drawing.Point(20, 85);
            this.lblMusteriAdiLabel.Name = "lblMusteriAdiLabel";
            this.lblMusteriAdiLabel.Size = new System.Drawing.Size(91, 19);
            this.lblMusteriAdiLabel.TabIndex = 3;
            this.lblMusteriAdiLabel.Text = "Müştəri Adı:";
            // 
            // lblMusteriAdi
            // 
            this.lblMusteriAdi.AutoSize = true;
            this.lblMusteriAdi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMusteriAdi.Location = new System.Drawing.Point(150, 85);
            this.lblMusteriAdi.Name = "lblMusteriAdi";
            this.lblMusteriAdi.Size = new System.Drawing.Size(17, 19);
            this.lblMusteriAdi.TabIndex = 4;
            this.lblMusteriAdi.Text = "-";
            // 
            // lblBorcTipiLabel
            // 
            this.lblBorcTipiLabel.AutoSize = true;
            this.lblBorcTipiLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBorcTipiLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblBorcTipiLabel.Location = new System.Drawing.Point(20, 115);
            this.lblBorcTipiLabel.Name = "lblBorcTipiLabel";
            this.lblBorcTipiLabel.Size = new System.Drawing.Size(64, 19);
            this.lblBorcTipiLabel.TabIndex = 5;
            this.lblBorcTipiLabel.Text = "Borc Tipi:";
            // 
            // lblBorcTipi
            // 
            this.lblBorcTipi.AutoSize = true;
            this.lblBorcTipi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBorcTipi.Location = new System.Drawing.Point(150, 115);
            this.lblBorcTipi.Name = "lblBorcTipi";
            this.lblBorcTipi.Size = new System.Drawing.Size(17, 19);
            this.lblBorcTipi.TabIndex = 6;
            this.lblBorcTipi.Text = "-";
            // 
            // lblStatusLabel
            // 
            this.lblStatusLabel.AutoSize = true;
            this.lblStatusLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblStatusLabel.Location = new System.Drawing.Point(20, 145);
            this.lblStatusLabel.Name = "lblStatusLabel";
            this.lblStatusLabel.Size = new System.Drawing.Size(53, 19);
            this.lblStatusLabel.TabIndex = 7;
            this.lblStatusLabel.Text = "Status:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(150, 145);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(15, 19);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "-";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.lblUmumiBorc);
            this.panel3.Controls.Add(this.lblUmumiBorcLabel);
            this.panel3.Controls.Add(this.lblFaizMeblegi);
            this.panel3.Controls.Add(this.lblFaizMeblegLabel);
            this.panel3.Controls.Add(this.lblQalanBorc);
            this.panel3.Controls.Add(this.lblQalanBorcLabel);
            this.panel3.Controls.Add(this.lblOdenilmisMebleg);
            this.panel3.Controls.Add(this.lblOdenilmisMeblegLabel);
            this.panel3.Controls.Add(this.lblBorcMeblegi);
            this.panel3.Controls.Add(this.lblBorcMeblegLabel);
            this.panel3.Controls.Add(this.lblAmountInfoTitle);
            this.panel3.Location = new System.Drawing.Point(460, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(420, 180);
            this.panel3.TabIndex = 1;
            // 
            // lblAmountInfoTitle
            // 
            this.lblAmountInfoTitle.AutoSize = true;
            this.lblAmountInfoTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblAmountInfoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblAmountInfoTitle.Location = new System.Drawing.Point(15, 15);
            this.lblAmountInfoTitle.Name = "lblAmountInfoTitle";
            this.lblAmountInfoTitle.Size = new System.Drawing.Size(177, 25);
            this.lblAmountInfoTitle.TabIndex = 0;
            this.lblAmountInfoTitle.Text = "Məbləğ Məlumatları";
            // 
            // lblBorcMeblegLabel
            // 
            this.lblBorcMeblegLabel.AutoSize = true;
            this.lblBorcMeblegLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBorcMeblegLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblBorcMeblegLabel.Location = new System.Drawing.Point(20, 55);
            this.lblBorcMeblegLabel.Name = "lblBorcMeblegLabel";
            this.lblBorcMeblegLabel.Size = new System.Drawing.Size(108, 19);
            this.lblBorcMeblegLabel.TabIndex = 1;
            this.lblBorcMeblegLabel.Text = "Əsas Məbləği:";
            // 
            // lblBorcMeblegi
            // 
            this.lblBorcMeblegi.AutoSize = true;
            this.lblBorcMeblegi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBorcMeblegi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblBorcMeblegi.Location = new System.Drawing.Point(150, 55);
            this.lblBorcMeblegi.Name = "lblBorcMeblegi";
            this.lblBorcMeblegi.Size = new System.Drawing.Size(15, 19);
            this.lblBorcMeblegi.TabIndex = 2;
            this.lblBorcMeblegi.Text = "-";
            // 
            // lblOdenilmisMeblegLabel
            // 
            this.lblOdenilmisMeblegLabel.AutoSize = true;
            this.lblOdenilmisMeblegLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblOdenilmisMeblegLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblOdenilmisMeblegLabel.Location = new System.Drawing.Point(20, 85);
            this.lblOdenilmisMeblegLabel.Name = "lblOdenilmisMeblegLabel";
            this.lblOdenilmisMeblegLabel.Size = new System.Drawing.Size(123, 19);
            this.lblOdenilmisMeblegLabel.TabIndex = 3;
            this.lblOdenilmisMeblegLabel.Text = "Ödənilmiş Məbləğ:";
            // 
            // lblOdenilmisMebleg
            // 
            this.lblOdenilmisMebleg.AutoSize = true;
            this.lblOdenilmisMebleg.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblOdenilmisMebleg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblOdenilmisMebleg.Location = new System.Drawing.Point(150, 85);
            this.lblOdenilmisMebleg.Name = "lblOdenilmisMebleg";
            this.lblOdenilmisMebleg.Size = new System.Drawing.Size(15, 19);
            this.lblOdenilmisMebleg.TabIndex = 4;
            this.lblOdenilmisMebleg.Text = "-";
            // 
            // lblQalanBorcLabel
            // 
            this.lblQalanBorcLabel.AutoSize = true;
            this.lblQalanBorcLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblQalanBorcLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblQalanBorcLabel.Location = new System.Drawing.Point(20, 115);
            this.lblQalanBorcLabel.Name = "lblQalanBorcLabel";
            this.lblQalanBorcLabel.Size = new System.Drawing.Size(87, 19);
            this.lblQalanBorcLabel.TabIndex = 5;
            this.lblQalanBorcLabel.Text = "Qalan Borc:";
            // 
            // lblQalanBorc
            // 
            this.lblQalanBorc.AutoSize = true;
            this.lblQalanBorc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblQalanBorc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.lblQalanBorc.Location = new System.Drawing.Point(150, 113);
            this.lblQalanBorc.Name = "lblQalanBorc";
            this.lblQalanBorc.Size = new System.Drawing.Size(16, 21);
            this.lblQalanBorc.TabIndex = 6;
            this.lblQalanBorc.Text = "-";
            // 
            // lblFaizMeblegLabel
            // 
            this.lblFaizMeblegLabel.AutoSize = true;
            this.lblFaizMeblegLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFaizMeblegLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblFaizMeblegLabel.Location = new System.Drawing.Point(200, 55);
            this.lblFaizMeblegLabel.Name = "lblFaizMeblegLabel";
            this.lblFaizMeblegLabel.Size = new System.Drawing.Size(95, 19);
            this.lblFaizMeblegLabel.TabIndex = 7;
            this.lblFaizMeblegLabel.Text = "Faiz Məbləği:";
            // 
            // lblFaizMeblegi
            // 
            this.lblFaizMeblegi.AutoSize = true;
            this.lblFaizMeblegi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFaizMeblegi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.lblFaizMeblegi.Location = new System.Drawing.Point(310, 55);
            this.lblFaizMeblegi.Name = "lblFaizMeblegi";
            this.lblFaizMeblegi.Size = new System.Drawing.Size(15, 19);
            this.lblFaizMeblegi.TabIndex = 8;
            this.lblFaizMeblegi.Text = "-";
            // 
            // lblUmumiBorcLabel
            // 
            this.lblUmumiBorcLabel.AutoSize = true;
            this.lblUmumiBorcLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblUmumiBorcLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblUmumiBorcLabel.Location = new System.Drawing.Point(200, 115);
            this.lblUmumiBorcLabel.Name = "lblUmumiBorcLabel";
            this.lblUmumiBorcLabel.Size = new System.Drawing.Size(101, 20);
            this.lblUmumiBorcLabel.TabIndex = 9;
            this.lblUmumiBorcLabel.Text = "Ümumi Borc:";
            // 
            // lblUmumiBorc
            // 
            this.lblUmumiBorc.AutoSize = true;
            this.lblUmumiBorc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblUmumiBorc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.lblUmumiBorc.Location = new System.Drawing.Point(310, 114);
            this.lblUmumiBorc.Name = "lblUmumiBorc";
            this.lblUmumiBorc.Size = new System.Drawing.Size(16, 21);
            this.lblUmumiBorc.TabIndex = 10;
            this.lblUmumiBorc.Text = "-";
            // 
            // tabPaymentHistory
            // 
            this.tabPaymentHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.tabPaymentHistory.Controls.Add(this.dgvPayments);
            this.tabPaymentHistory.Controls.Add(this.panel6);
            this.tabPaymentHistory.Location = new System.Drawing.Point(4, 29);
            this.tabPaymentHistory.Name = "tabPaymentHistory";
            this.tabPaymentHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tabPaymentHistory.Size = new System.Drawing.Size(892, 417);
            this.tabPaymentHistory.TabIndex = 1;
            this.tabPaymentHistory.Text = "Ödəniş Tarixçəsi";
            // 
            // dgvPayments
            // 
            this.dgvPayments.BackgroundColor = System.Drawing.Color.White;
            this.dgvPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPayments.Location = new System.Drawing.Point(3, 63);
            this.dgvPayments.Name = "dgvPayments";
            this.dgvPayments.Size = new System.Drawing.Size(886, 351);
            this.dgvPayments.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.lblTotalPayments);
            this.panel6.Controls.Add(this.lblTotalPaymentsLabel);
            this.panel6.Controls.Add(this.lblPaymentHistoryTitle);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(886, 60);
            this.panel6.TabIndex = 0;
            // 
            // lblPaymentHistoryTitle
            // 
            this.lblPaymentHistoryTitle.AutoSize = true;
            this.lblPaymentHistoryTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPaymentHistoryTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblPaymentHistoryTitle.Location = new System.Drawing.Point(20, 18);
            this.lblPaymentHistoryTitle.Name = "lblPaymentHistoryTitle";
            this.lblPaymentHistoryTitle.Size = new System.Drawing.Size(157, 25);
            this.lblPaymentHistoryTitle.TabIndex = 0;
            this.lblPaymentHistoryTitle.Text = "Ödəniş Tarixçəsi";
            // 
            // lblTotalPaymentsLabel
            // 
            this.lblTotalPaymentsLabel.AutoSize = true;
            this.lblTotalPaymentsLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalPaymentsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTotalPaymentsLabel.Location = new System.Drawing.Point(500, 20);
            this.lblTotalPaymentsLabel.Name = "lblTotalPaymentsLabel";
            this.lblTotalPaymentsLabel.Size = new System.Drawing.Size(146, 20);
            this.lblTotalPaymentsLabel.TabIndex = 1;
            this.lblTotalPaymentsLabel.Text = "Ümumi Ödəniş Sayı:";
            // 
            // lblTotalPayments
            // 
            this.lblTotalPayments.AutoSize = true;
            this.lblTotalPayments.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalPayments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblTotalPayments.Location = new System.Drawing.Point(652, 20);
            this.lblTotalPayments.Name = "lblTotalPayments";
            this.lblTotalPayments.Size = new System.Drawing.Size(18, 20);
            this.lblTotalPayments.TabIndex = 2;
            this.lblTotalPayments.Text = "0";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Controls.Add(this.btnClose);
            this.panel7.Controls.Add(this.btnPrintReport);
            this.panel7.Controls.Add(this.btnEditDebt);
            this.panel7.Controls.Add(this.btnAddPayment);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 510);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(900, 70);
            this.panel7.TabIndex = 2;
            // 
            // btnAddPayment
            // 
            this.btnAddPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAddPayment.FlatAppearance.BorderSize = 0;
            this.btnAddPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPayment.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnAddPayment.ForeColor = System.Drawing.Color.White;
            this.btnAddPayment.Location = new System.Drawing.Point(20, 15);
            this.btnAddPayment.Name = "btnAddPayment";
            this.btnAddPayment.Size = new System.Drawing.Size(150, 40);
            this.btnAddPayment.TabIndex = 0;
            this.btnAddPayment.Text = "Ödəniş Et";
            this.btnAddPayment.UseVisualStyleBackColor = false;
            this.btnAddPayment.Click += new System.EventHandler(this.btnAddPayment_Click);
            // 
            // btnEditDebt
            // 
            this.btnEditDebt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnEditDebt.FlatAppearance.BorderSize = 0;
            this.btnEditDebt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditDebt.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnEditDebt.ForeColor = System.Drawing.Color.White;
            this.btnEditDebt.Location = new System.Drawing.Point(190, 15);
            this.btnEditDebt.Name = "btnEditDebt";
            this.btnEditDebt.Size = new System.Drawing.Size(150, 40);
            this.btnEditDebt.TabIndex = 1;
            this.btnEditDebt.Text = "Borcu Düzəlt";
            this.btnEditDebt.UseVisualStyleBackColor = false;
            this.btnEditDebt.Click += new System.EventHandler(this.btnEditDebt_Click);
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnPrintReport.FlatAppearance.BorderSize = 0;
            this.btnPrintReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintReport.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnPrintReport.ForeColor = System.Drawing.Color.White;
            this.btnPrintReport.Location = new System.Drawing.Point(360, 15);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(150, 40);
            this.btnPrintReport.TabIndex = 2;
            this.btnPrintReport.Text = "Hesabat Çap Et";
            this.btnPrintReport.UseVisualStyleBackColor = false;
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(720, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(150, 40);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Bağla";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // BorcDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(900, 580);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BorcDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Borc Təfərrüatları";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabDebtInfo.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabPaymentHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDebtInfo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblDebtInfoTitle;
        private System.Windows.Forms.Label lblBorcNomresiLabel;
        private System.Windows.Forms.Label lblBorcNomresi;
        private System.Windows.Forms.Label lblMusteriAdiLabel;
        private System.Windows.Forms.Label lblMusteriAdi;
        private System.Windows.Forms.Label lblBorcTipiLabel;
        private System.Windows.Forms.Label lblBorcTipi;
        private System.Windows.Forms.Label lblStatusLabel;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblAmountInfoTitle;
        private System.Windows.Forms.Label lblBorcMeblegLabel;
        private System.Windows.Forms.Label lblBorcMeblegi;
        private System.Windows.Forms.Label lblOdenilmisMeblegLabel;
        private System.Windows.Forms.Label lblOdenilmisMebleg;
        private System.Windows.Forms.Label lblQalanBorcLabel;
        private System.Windows.Forms.Label lblQalanBorc;
        private System.Windows.Forms.Label lblFaizMeblegLabel;
        private System.Windows.Forms.Label lblFaizMeblegi;
        private System.Windows.Forms.Label lblUmumiBorcLabel;
        private System.Windows.Forms.Label lblUmumiBorc;
        private System.Windows.Forms.TabPage tabPaymentHistory;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblPaymentHistoryTitle;
        private System.Windows.Forms.Label lblTotalPaymentsLabel;
        private System.Windows.Forms.Label lblTotalPayments;
        private System.Windows.Forms.DataGridView dgvPayments;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnAddPayment;
        private System.Windows.Forms.Button btnEditDebt;
        private System.Windows.Forms.Button btnPrintReport;
        private System.Windows.Forms.Button btnClose;
    }
}