namespace AzAgroPOS.PL.Forms
{
    partial class BorcDetailsForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDebtInfo = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblDebtInfoTitle = new System.Windows.Forms.Label();
            this.lblBorcNomresiLabel = new System.Windows.Forms.Label();
            this.lblBorcNomresi = new System.Windows.Forms.Label();
            this.lblMusteriAdiLabel = new System.Windows.Forms.Label();
            this.lblMusteriAdi = new System.Windows.Forms.Label();
            this.lblBorcTipiLabel = new System.Windows.Forms.Label();
            this.lblBorcTipi = new System.Windows.Forms.Label();
            this.lblStatusLabel = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblAmountInfoTitle = new System.Windows.Forms.Label();
            this.lblBorcMeblegLabel = new System.Windows.Forms.Label();
            this.lblBorcMeblegi = new System.Windows.Forms.Label();
            this.lblOdenilmisMeblegLabel = new System.Windows.Forms.Label();
            this.lblOdenilmisMebleg = new System.Windows.Forms.Label();
            this.lblQalanBorcLabel = new System.Windows.Forms.Label();
            this.lblQalanBorc = new System.Windows.Forms.Label();
            this.lblFaizMeblegLabel = new System.Windows.Forms.Label();
            this.lblFaizMeblegi = new System.Windows.Forms.Label();
            this.lblUmumiBorcLabel = new System.Windows.Forms.Label();
            this.lblUmumiBorc = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblDateInfoTitle = new System.Windows.Forms.Label();
            this.lblBorcTarixiLabel = new System.Windows.Forms.Label();
            this.lblBorcTarixi = new System.Windows.Forms.Label();
            this.lblSonOdemeTarixiLabel = new System.Windows.Forms.Label();
            this.lblSonOdemeTarixi = new System.Windows.Forms.Label();
            this.lblGecikmeGunleriLabel = new System.Windows.Forms.Label();
            this.lblGecikmeGunleri = new System.Windows.Forms.Label();
            this.lblFaizDerecesiLabel = new System.Windows.Forms.Label();
            this.lblFaizDerecesi = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblAdditionalInfoTitle = new System.Windows.Forms.Label();
            this.lblAciklamaLabel = new System.Windows.Forms.Label();
            this.lblAciklama = new System.Windows.Forms.Label();
            this.lblYaradanLabel = new System.Windows.Forms.Label();
            this.lblYaradan = new System.Windows.Forms.Label();
            this.lblYaradilmaTarixiLabel = new System.Windows.Forms.Label();
            this.lblYaradilmaTarixi = new System.Windows.Forms.Label();
            this.tabPaymentHistory = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblPaymentHistoryTitle = new System.Windows.Forms.Label();
            this.lblTotalPaymentsLabel = new System.Windows.Forms.Label();
            this.lblTotalPayments = new System.Windows.Forms.Label();
            this.dgvPayments = new System.Windows.Forms.DataGridView();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnAddPayment = new System.Windows.Forms.Button();
            this.btnEditDebt = new System.Windows.Forms.Button();
            this.btnPrintReport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabDebtInfo.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabPaymentHistory.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).BeginInit();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173))));
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 60);
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
            this.lblTitle.Text = "📊 Borc Təfərrüatları";
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
            this.tabControl1.Size = new System.Drawing.Size(1000, 500);
            this.tabControl1.TabIndex = 1;
            // 
            // tabDebtInfo
            // 
            this.tabDebtInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241))));
            this.tabDebtInfo.Controls.Add(this.panel5);
            this.tabDebtInfo.Controls.Add(this.panel4);
            this.tabDebtInfo.Controls.Add(this.panel3);
            this.tabDebtInfo.Controls.Add(this.panel2);
            this.tabDebtInfo.Location = new System.Drawing.Point(4, 29);
            this.tabDebtInfo.Name = "tabDebtInfo";
            this.tabDebtInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabDebtInfo.Size = new System.Drawing.Size(992, 467);
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
            this.panel2.Size = new System.Drawing.Size(460, 200);
            this.panel2.TabIndex = 0;
            // 
            // lblDebtInfoTitle
            // 
            this.lblDebtInfoTitle.AutoSize = true;
            this.lblDebtInfoTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDebtInfoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94))));
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
            this.lblBorcNomresiLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94))));
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
            this.lblBorcNomresi.Location = new System.Drawing.Point(180, 55);
            this.lblBorcNomresi.Name = "lblBorcNomresi";
            this.lblBorcNomresi.Size = new System.Drawing.Size(17, 19);
            this.lblBorcNomresi.TabIndex = 2;
            this.lblBorcNomresi.Text = "-";
            // 
            // lblMusteriAdiLabel
            // 
            this.lblMusteriAdiLabel.AutoSize = true;
            this.lblMusteriAdiLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMusteriAdiLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94))));
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
            this.lblMusteriAdi.Location = new System.Drawing.Point(180, 85);
            this.lblMusteriAdi.Name = "lblMusteriAdi";
            this.lblMusteriAdi.Size = new System.Drawing.Size(17, 19);
            this.lblMusteriAdi.TabIndex = 4;
            this.lblMusteriAdi.Text = "-";
            // 
            // lblBorcTipiLabel
            // 
            this.lblBorcTipiLabel.AutoSize = true;
            this.lblBorcTipiLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBorcTipiLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94))));
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
            this.lblBorcTipi.Location = new System.Drawing.Point(180, 115);
            this.lblBorcTipi.Name = "lblBorcTipi";
            this.lblBorcTipi.Size = new System.Drawing.Size(17, 19);
            this.lblBorcTipi.TabIndex = 6;
            this.lblBorcTipi.Text = "-";
            // 
            // lblStatusLabel
            // 
            this.lblStatusLabel.AutoSize = true;
            this.lblStatusLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94))));
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
            this.lblStatus.Location = new System.Drawing.Point(180, 145);
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
            this.panel3.Location = new System.Drawing.Point(500, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(460, 200);
            this.panel3.TabIndex = 1;
            // 
            // lblAmountInfoTitle
            // 
            this.lblAmountInfoTitle.AutoSize = true;
            this.lblAmountInfoTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblAmountInfoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94))));
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
            this.lblBorcMeblegLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94))));
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
            this.lblBorcMeblegi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185))));
            this.lblBorcMeblegi.Location = new System.Drawing.Point(180, 55);
            this.lblBorcMeblegi.Name = "lblBorcMeblegi";
            this.lblBorcMeblegi.Size = new System.Drawing.Size(15, 19);
            this.lblBorcMeblegi.TabIndex = 2;
            this.lblBorcMeblegi.Text = "-";
            // 
            // lblOdenilmisMeblegLabel
            // 
            this.lblOdenilmisMeblegLabel.AutoSize = true;
            this.lblOdenilmisMeblegLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblOdenilmisMeblegLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94))));
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
            this.lblOdenilmisMebleg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96))));
            this.lblOdenilmisMebleg.Location = new System.Drawing.Point(180, 85);
            this.lblOdenilmisMebleg.Name = "lblOdenilmisMebleg";
            this.lblOdenilmisMebleg.Size = new System.Drawing.Size(15, 19);
            this.lblOdenilmisMebleg.TabIndex = 4;
            this.lblOdenilmisMebleg.Text = "-";
            // 
            // lblQalanBorcLabel
            // 
            this.lblQalanBorcLabel.AutoSize = true;
            this.lblQalanBorcLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblQalanBorcLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94))));
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
            this.lblQalanBorc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43))));
            this.lblQalanBorc.Location = new System.Drawing.Point(180, 113);
            this.lblQalanBorc.Name = "lblQalanBorc";
            this.lblQalanBorc.Size = new System.Drawing.Size(16, 21);
            this.lblQalanBorc.TabIndex = 6;
            this.lblQalanBorc.Text = "-";
            // 
            // lblFaizMeblegLabel
            // 
            this.lblFaizMeblegLabel.AutoSize = true;
            this.lblFaizMeblegLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFaizMeblegLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94))));
            this.lblFaizMeblegLabel.Location = new System.Drawing.Point(20, 145);
            this.lblFaizMeblegLabel.Name = "lblFaizMeblegLabel";
            this.lblFaizMeblegLabel.Size = new System.Drawing.Size(95, 19);
            this.lblFaizMeblegLabel.TabIndex = 7;
            this.lblFaizMeblegLabel.Text = "Faiz Məbləği:";
            // 
            // lblFaizMeblegi
            // 
            this.lblFaizMeblegi.AutoSize = true;
            this.lblFaizMeblegi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFaizMeblegi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34))));
            this.lblFaizMeblegi.Location = new System.Drawing.Point(180, 145);
            this.lblFaizMeblegi.Name = "lblFaizMeblegi";
            this.lblFaizMeblegi.Size = new System.Drawing.Size(15, 19);
            this.lblFaizMeblegi.TabIndex = 8;
            this.lblFaizMeblegi.Text = "-";
            // 
            // lblUmumiBorcLabel
            // 
            this.lblUmumiBorcLabel.AutoSize = true;
            this.lblUmumiBorcLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblUmumiBorcLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94))));
            this.lblUmumiBorcLabel.Location = new System.Drawing.Point(20, 175);
            this.lblUmumiBorcLabel.Name = "lblUmumiBorcLabel";
            this.lblUmumiBorcLabel.Size = new System.Drawing.Size(101, 20);
            this.lblUmumiBorcLabel.TabIndex = 9;
            this.lblUmumiBorcLabel.Text = "Ümumi Borc:";
            // 
            // lblUmumiBorc
            // 
            this.lblUmumiBorc.AutoSize = true;
            this.lblUmumiBorc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblUmumiBorc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182))));
            this.lblUmumiBorc.Location = new System.Drawing.Point(180, 174);
            this.lblUmumiBorc.Name = "lblUmumiBorc";
            this.lblUmumiBorc.Size = new System.Drawing.Size(16, 21);
            this.lblUmumiBorc.TabIndex = 10;
            this.lblUmumiBorc.Text = "-";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.lblFaizDerecesi);
            this.panel4.Controls.Add(this.lblFaizDerecesiLabel);
            this.panel4.Controls.Add(this.lblGecikmeGunleri);
            this.panel4.Controls.Add(this.lblGecikmeGunleriLabel);
            this.panel4.Controls.Add(this.lblSonOdemeTarixi);
            this.panel4.Controls.Add(this.lblSonOdemeTarixiLabel);
            this.panel4.Controls.Add(this.lblBorcTarixi);
            this.panel4.Controls.Add(this.lblBorcTarixiLabel);
            this.panel4.Controls.Add(this.lblDateInfoTitle);
            this.panel4.Location = new System.Drawing.Point(20, 240);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(460, 160);
            this.panel4.TabIndex = 2;
            // 
            // lblDateInfoTitle
            // 
            this.lblDateInfoTitle.AutoSize = true;
            this.lblDateInfoTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDateInfoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94))));
            this.lblDateInfoTitle.Location = new System.Drawing.Point(15, 15);
            this.lblDateInfoTitle.Name = "lblDateInfoTitle";
            this.lblDateInfoTitle.Size = new System.Drawing.Size(156, 25);
            this.lblDateInfoTitle.TabIndex = 0;
            this.lblDateInfoTitle.Text = "Tarix Məlumatları";
            // 
            // lblBorcTarixiLabel
            // 
            this.lblBorcTarixiLabel.AutoSize = true;
            this.lblBorcTarixiLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBorcTarixiLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94))));
            this.lblBorcTarixiLabel.Location = new System.Drawing.Point(20, 55);
            this.lblBorcTarixiLabel.Name = "lblBorcTarixiLabel";
            this.lblBorcTarixiLabel.Size = new System.Drawing.Size(87, 19);
            this.lblBorcTarixiLabel.TabIndex = 1;
            this.lblBorcTarixiLabel.Text = "Borc Tarixi:";
            // 
            // lblBorcTarixi
            // 
            this.lblBorcTarixi.AutoSize = true;
            this.lblBorcTarixi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBorcTarixi.Location = new System.Drawing.Point(200, 55);
            this.lblBorcTarixi.Name = "lblBorcTarixi";
            this.lblBorcTarixi.Size = new System.Drawing.Size(17, 19);
            this.lblBorcTarixi.TabIndex = 2;
            this.lblBorcTarixi.Text = "-";
            // 
            // lblSonOdemeTarixiLabel
            // 
            this.lblSonOdemeTarixiLabel.AutoSize = true;
            this.lblSonOdemeTarixiLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSonOdemeTarixiLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94))));
            this.lblSonOdemeTarixiLabel.Location = new System.Drawing.Point(20, 85);
            this.lblSonOdemeTarixiLabel.Name = "lblSonOdemeTarixiLabel";
            this.lblSonOdemeTarixiLabel.Size = new System.Drawing.Size(134, 19);
            this.lblSonOdemeTarixiLabel.TabIndex = 3;
            this.lblSonOdemeTarixiLabel.Text = "Son Ödəmə Tarixi:";
            // 
            // lblSonOdemeTarixi
            // 
            this.lblSonOdemeTarixi.AutoSize = true;
            this.lblSonOdemeTarixi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSonOdemeTarixi.Location = new System.Drawing.Point(200, 85);
            this.lblSonOdemeTarixi.Name = "lblSonOdemeTarixi";
            this.lblSonOdemeTarixi.Size = new System.Drawing.Size(17, 19);
            this.lblSonOdemeTarixi.TabIndex = 4;
            this.lblSonOdemeTarixi.Text = "-";
            // 
            // lblGecikmeGunleriLabel
            // 
            this.lblGecikmeGunleriLabel.AutoSize = true;
            this.lblGecikmeGunleriLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGecikmeGunleriLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94))));
            this.lblGecikmeGunleriLabel.Location = new System.Drawing.Point(20, 115);
            this.lblGecikmeGunleriLabel.Name = "lblGecikmeGunleriLabel";
            this.lblGecikmeGunleriLabel.Size = new System.Drawing.Size(124, 19);
            this.lblGecikmeGunleriLabel.TabIndex = 5;
            this.lblGecikmeGunleriLabel.Text = "Gecikən Günlər:";
            // 
            // lblGecikmeGunleri
            // 
            this.lblGecikmeGunleri.AutoSize = true;
            this.lblGecikmeGunleri.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGecikmeGunleri.Location = new System.Drawing.Point(200, 115);
            this.lblGecikmeGunleri.Name = "lblGecikmeGunleri";
            this.lblGecikmeGunleri.Size = new System.Drawing.Size(15, 19);
            this.lblGecikmeGunleri.TabIndex = 6;
            this.lblGecikmeGunleri.Text = "-";
            // 
            // lblFaizDerecesiLabel
            // 
            this.lblFaizDerecesiLabel.AutoSize = true;
            this.lblFaizDerecesiLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFaizDerecesiLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94))));
            this.lblFaizDerecesiLabel.Location = new System.Drawing.Point(20, 145);
            this.lblFaizDerecesiLabel.Name = "lblFaizDerecesiLabel";
            this.lblFaizDerecesiLabel.Size = new System.Drawing.Size(108, 19);
            this.lblFaizDerecesiLabel.TabIndex = 7;
            this.lblFaizDerecesiLabel.Text = "Faiz Dərəcəsi:";
            // 
            // lblFaizDerecesi
            // 
            this.lblFaizDerecesi.AutoSize = true;
            this.lblFaizDerecesi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFaizDerecesi.Location = new System.Drawing.Point(200, 145);
            this.lblFaizDerecesi.Name = "lblFaizDerecesi";
            this.lblFaizDerecesi.Size = new System.Drawing.Size(17, 19);
            this.lblFaizDerecesi.TabIndex = 8;
            this.lblFaizDerecesi.Text = "-";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.lblYaradilmaTarixi);
            this.panel5.Controls.Add(this.lblYaradilmaTarixiLabel);
            this.panel5.Controls.Add(this.lblYaradan);
            this.panel5.Controls.Add(this.lblYaradanLabel);
            this.panel5.Controls.Add(this.lblAciklama);
            this.panel5.Controls.Add(this.lblAciklamaLabel);
            this.panel5.Controls.Add(this.lblAdditionalInfoTitle);
            this.panel5.Location = new System.Drawing.Point(500, 240);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(460, 160);
            this.panel5.TabIndex = 3;
            // 
            // lblAdditionalInfoTitle
            // 
            this.lblAdditionalInfoTitle.AutoSize = true;
            this.lblAdditionalInfoTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblAdditionalInfoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94))));
            this.lblAdditionalInfoTitle.Location = new System.Drawing.Point(15, 15);
            this.lblAdditionalInfoTitle.Name = "lblAdditionalInfoTitle";
            this.lblAdditionalInfoTitle.Size = new System.Drawing.Size(165, 25);
            this.lblAdditionalInfoTitle.TabIndex = 0;
            this.lblAdditionalInfoTitle.Text = "Əlavə Məlumatlar";
            // 
            // lblAciklamaLabel
            // 
            this.lblAciklamaLabel.AutoSize = true;
            this.lblAciklamaLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAciklamaLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94))));
            this.lblAciklamaLabel.Location = new System.Drawing.Point(20, 55);
            this.lblAciklamaLabel.Name = "lblAciklamaLabel";
            this.lblAciklamaLabel.Size = new System.Drawing.Size(76, 19);
            this.lblAciklamaLabel.TabIndex = 1;
            this.lblAciklamaLabel.Text = "Açıqlama:";
            // 
            // lblAciklama
            // 
            this.lblAciklama.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAciklama.Location = new System.Drawing.Point(20, 80);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Size = new System.Drawing.Size(420, 40);
            this.lblAciklama.TabIndex = 2;
            this.lblAciklama.Text = "-";
            // 
            // lblYaradanLabel
            // 
            this.lblYaradanLabel.AutoSize = true;
            this.lblYaradanLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblYaradanLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94))));
            this.lblYaradanLabel.Location = new System.Drawing.Point(20, 125);
            this.lblYaradanLabel.Name = "lblYaradanLabel";
            this.lblYaradanLabel.Size = new System.Drawing.Size(66, 19);
            this.lblYaradanLabel.TabIndex = 3;
            this.lblYaradanLabel.Text = "Yaradan:";
            // 
            // lblYaradan
            // 
            this.lblYaradan.AutoSize = true;
            this.lblYaradan.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblYaradan.Location = new System.Drawing.Point(150, 125);
            this.lblYaradan.Name = "lblYaradan";
            this.lblYaradan.Size = new System.Drawing.Size(17, 19);
            this.lblYaradan.TabIndex = 4;
            this.lblYaradan.Text = "-";
            // 
            // lblYaradilmaTarixiLabel
            // 
            this.lblYaradilmaTarixiLabel.AutoSize = true;
            this.lblYaradilmaTarixiLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblYaradilmaTarixiLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94))));
            this.lblYaradilmaTarixiLabel.Location = new System.Drawing.Point(230, 125);
            this.lblYaradilmaTarixiLabel.Name = "lblYaradilmaTarixiLabel";
            this.lblYaradilmaTarixiLabel.Size = new System.Drawing.Size(125, 19);
            this.lblYaradilmaTarixiLabel.TabIndex = 5;
            this.lblYaradilmaTarixiLabel.Text = "Yaradılma Tarixi:";
            // 
            // lblYaradilmaTarixi
            // 
            this.lblYaradilmaTarixi.AutoSize = true;
            this.lblYaradilmaTarixi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblYaradilmaTarixi.Location = new System.Drawing.Point(360, 125);
            this.lblYaradilmaTarixi.Name = "lblYaradilmaTarixi";
            this.lblYaradilmaTarixi.Size = new System.Drawing.Size(11, 15);
            this.lblYaradilmaTarixi.TabIndex = 6;
            this.lblYaradilmaTarixi.Text = "-";
            // 
            // tabPaymentHistory
            // 
            this.tabPaymentHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241))));
            this.tabPaymentHistory.Controls.Add(this.dgvPayments);
            this.tabPaymentHistory.Controls.Add(this.panel6);
            this.tabPaymentHistory.Location = new System.Drawing.Point(4, 29);
            this.tabPaymentHistory.Name = "tabPaymentHistory";
            this.tabPaymentHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tabPaymentHistory.Size = new System.Drawing.Size(992, 467);
            this.tabPaymentHistory.TabIndex = 1;
            this.tabPaymentHistory.Text = "Ödəniş Tarixçəsi";
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
            this.panel6.Size = new System.Drawing.Size(986, 60);
            this.panel6.TabIndex = 0;
            // 
            // lblPaymentHistoryTitle
            // 
            this.lblPaymentHistoryTitle.AutoSize = true;
            this.lblPaymentHistoryTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblPaymentHistoryTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94))));
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
            this.lblTotalPaymentsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94))));
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
            this.lblTotalPayments.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185))));
            this.lblTotalPayments.Location = new System.Drawing.Point(652, 20);
            this.lblTotalPayments.Name = "lblTotalPayments";
            this.lblTotalPayments.Size = new System.Drawing.Size(18, 20);
            this.lblTotalPayments.TabIndex = 2;
            this.lblTotalPayments.Text = "0";
            // 
            // dgvPayments
            // 
            this.dgvPayments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) \n            | System.Windows.Forms.AnchorStyles.Left) \n            | System.Windows.Forms.AnchorStyles.Right)));\n            this.dgvPayments.BackgroundColor = System.Drawing.Color.White;\n            this.dgvPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;\n            this.dgvPayments.Location = new System.Drawing.Point(20, 80);\n            this.dgvPayments.Name = "dgvPayments";\n            this.dgvPayments.Size = new System.Drawing.Size(950, 360);\n            this.dgvPayments.TabIndex = 1;\n            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;\n            this.panel7.Controls.Add(this.btnClose);\n            this.panel7.Controls.Add(this.btnPrintReport);\n            this.panel7.Controls.Add(this.btnEditDebt);\n            this.panel7.Controls.Add(this.btnAddPayment);\n            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;\n            this.panel7.Location = new System.Drawing.Point(0, 560);\n            this.panel7.Name = "panel7";\n            this.panel7.Size = new System.Drawing.Size(1000, 70);\n            this.panel7.TabIndex = 2;\n            // \n            // btnAddPayment\n            // \n            this.btnAddPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));\n            this.btnAddPayment.FlatAppearance.BorderSize = 0;\n            this.btnAddPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;\n            this.btnAddPayment.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);\n            this.btnAddPayment.ForeColor = System.Drawing.Color.White;\n            this.btnAddPayment.Location = new System.Drawing.Point(20, 15);\n            this.btnAddPayment.Name = "btnAddPayment";\n            this.btnAddPayment.Size = new System.Drawing.Size(150, 40);\n            this.btnAddPayment.TabIndex = 0;\n            this.btnAddPayment.Text = "💰 Ödəniş Et";\n            this.btnAddPayment.UseVisualStyleBackColor = false;\n            this.btnAddPayment.Click += new System.EventHandler(this.btnAddPayment_Click);\n            // \n            // btnEditDebt\n            // \n            this.btnEditDebt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));\n            this.btnEditDebt.FlatAppearance.BorderSize = 0;\n            this.btnEditDebt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;\n            this.btnEditDebt.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);\n            this.btnEditDebt.ForeColor = System.Drawing.Color.White;\n            this.btnEditDebt.Location = new System.Drawing.Point(190, 15);\n            this.btnEditDebt.Name = "btnEditDebt";\n            this.btnEditDebt.Size = new System.Drawing.Size(150, 40);\n            this.btnEditDebt.TabIndex = 1;\n            this.btnEditDebt.Text = "✏️ Borcu Düzəlt";\n            this.btnEditDebt.UseVisualStyleBackColor = false;\n            this.btnEditDebt.Click += new System.EventHandler(this.btnEditDebt_Click);\n            // \n            // btnPrintReport\n            // \n            this.btnPrintReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));\n            this.btnPrintReport.FlatAppearance.BorderSize = 0;\n            this.btnPrintReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;\n            this.btnPrintReport.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);\n            this.btnPrintReport.ForeColor = System.Drawing.Color.White;\n            this.btnPrintReport.Location = new System.Drawing.Point(360, 15);\n            this.btnPrintReport.Name = "btnPrintReport";\n            this.btnPrintReport.Size = new System.Drawing.Size(150, 40);\n            this.btnPrintReport.TabIndex = 2;\n            this.btnPrintReport.Text = "🖨️ Hesabat Çap Et";\n            this.btnPrintReport.UseVisualStyleBackColor = false;\n            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);\n            // \n            // btnClose\n            // \n            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));\n            this.btnClose.FlatAppearance.BorderSize = 0;\n            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;\n            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);\n            this.btnClose.ForeColor = System.Drawing.Color.White;\n            this.btnClose.Location = new System.Drawing.Point(820, 15);\n            this.btnClose.Name = "btnClose";\n            this.btnClose.Size = new System.Drawing.Size(150, 40);\n            this.btnClose.TabIndex = 3;\n            this.btnClose.Text = "❌ Bağla";\n            this.btnClose.UseVisualStyleBackColor = false;\n            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);\n            // \n            // BorcDetailsForm\n            // \n            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);\n            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;\n            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));\n            this.ClientSize = new System.Drawing.Size(1000, 630);\n            this.Controls.Add(this.panel7);\n            this.Controls.Add(this.tabControl1);\n            this.Controls.Add(this.panel1);\n            this.Font = new System.Drawing.Font("Segoe UI", 9F);\n            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;\n            this.MaximizeBox = false;\n            this.MinimizeBox = false;\n            this.Name = "BorcDetailsForm";\n            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;\n            this.Text = "Borc Təfərrüatları";\n            this.panel1.ResumeLayout(false);\n            this.panel1.PerformLayout();\n            this.tabControl1.ResumeLayout(false);\n            this.tabDebtInfo.ResumeLayout(false);\n            this.panel2.ResumeLayout(false);\n            this.panel2.PerformLayout();\n            this.panel3.ResumeLayout(false);\n            this.panel3.PerformLayout();\n            this.panel4.ResumeLayout(false);\n            this.panel4.PerformLayout();\n            this.panel5.ResumeLayout(false);\n            this.panel5.PerformLayout();\n            this.tabPaymentHistory.ResumeLayout(false);\n            this.panel6.ResumeLayout(false);\n            this.panel6.PerformLayout();\n            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).EndInit();\n            this.panel7.ResumeLayout(false);\n            this.ResumeLayout(false);\n\n        }\n\n        #endregion\n\n        private System.Windows.Forms.Panel panel1;\n        private System.Windows.Forms.Label lblTitle;\n        private System.Windows.Forms.TabControl tabControl1;\n        private System.Windows.Forms.TabPage tabDebtInfo;\n        private System.Windows.Forms.Panel panel2;\n        private System.Windows.Forms.Label lblDebtInfoTitle;\n        private System.Windows.Forms.Label lblBorcNomresiLabel;\n        private System.Windows.Forms.Label lblBorcNomresi;\n        private System.Windows.Forms.Label lblMusteriAdiLabel;\n        private System.Windows.Forms.Label lblMusteriAdi;\n        private System.Windows.Forms.Label lblBorcTipiLabel;\n        private System.Windows.Forms.Label lblBorcTipi;\n        private System.Windows.Forms.Label lblStatusLabel;\n        private System.Windows.Forms.Label lblStatus;\n        private System.Windows.Forms.Panel panel3;\n        private System.Windows.Forms.Label lblAmountInfoTitle;\n        private System.Windows.Forms.Label lblBorcMeblegLabel;\n        private System.Windows.Forms.Label lblBorcMeblegi;\n        private System.Windows.Forms.Label lblOdenilmisMeblegLabel;\n        private System.Windows.Forms.Label lblOdenilmisMebleg;\n        private System.Windows.Forms.Label lblQalanBorcLabel;\n        private System.Windows.Forms.Label lblQalanBorc;\n        private System.Windows.Forms.Label lblFaizMeblegLabel;\n        private System.Windows.Forms.Label lblFaizMeblegi;\n        private System.Windows.Forms.Label lblUmumiBorcLabel;\n        private System.Windows.Forms.Label lblUmumiBorc;\n        private System.Windows.Forms.Panel panel4;\n        private System.Windows.Forms.Label lblDateInfoTitle;\n        private System.Windows.Forms.Label lblBorcTarixiLabel;\n        private System.Windows.Forms.Label lblBorcTarixi;\n        private System.Windows.Forms.Label lblSonOdemeTarixiLabel;\n        private System.Windows.Forms.Label lblSonOdemeTarixi;\n        private System.Windows.Forms.Label lblGecikmeGunleriLabel;\n        private System.Windows.Forms.Label lblGecikmeGunleri;\n        private System.Windows.Forms.Label lblFaizDerecesiLabel;\n        private System.Windows.Forms.Label lblFaizDerecesi;\n        private System.Windows.Forms.Panel panel5;\n        private System.Windows.Forms.Label lblAdditionalInfoTitle;\n        private System.Windows.Forms.Label lblAciklamaLabel;\n        private System.Windows.Forms.Label lblAciklama;\n        private System.Windows.Forms.Label lblYaradanLabel;\n        private System.Windows.Forms.Label lblYaradan;\n        private System.Windows.Forms.Label lblYaradilmaTarixiLabel;\n        private System.Windows.Forms.Label lblYaradilmaTarixi;\n        private System.Windows.Forms.TabPage tabPaymentHistory;\n        private System.Windows.Forms.Panel panel6;\n        private System.Windows.Forms.Label lblPaymentHistoryTitle;\n        private System.Windows.Forms.Label lblTotalPaymentsLabel;\n        private System.Windows.Forms.Label lblTotalPayments;\n        private System.Windows.Forms.DataGridView dgvPayments;\n        private System.Windows.Forms.Panel panel7;\n        private System.Windows.Forms.Button btnAddPayment;\n        private System.Windows.Forms.Button btnEditDebt;\n        private System.Windows.Forms.Button btnPrintReport;\n        private System.Windows.Forms.Button btnClose;\n    }\n}