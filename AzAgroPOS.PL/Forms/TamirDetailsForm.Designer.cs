namespace AzAgroPOS.PL.Forms
{
    partial class TamirDetailsForm
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
            this.tabRepairInfo = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTamirciQeydleri = new System.Windows.Forms.Label();
            this.lblTamirciQeydleriLabel = new System.Windows.Forms.Label();
            this.lblMusteriQeydleri = new System.Windows.Forms.Label();
            this.lblMusteriQeydleriLabel = new System.Windows.Forms.Label();
            this.lblTeyinEdilenIsci = new System.Windows.Forms.Label();
            this.lblTeyinEdilenIsciLabel = new System.Windows.Forms.Label();
            this.lblPrioritet = new System.Windows.Forms.Label();
            this.lblPrioritetLabel = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblStatusLabel = new System.Windows.Forms.Label();
            this.lblSonQiymet = new System.Windows.Forms.Label();
            this.lblSonQiymetLabel = new System.Windows.Forms.Label();
            this.lblTaxminQiymet = new System.Windows.Forms.Label();
            this.lblTaxminQiymetLabel = new System.Windows.Forms.Label();
            this.lblRepairInfoTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTaxminiBitirmeTarixi = new System.Windows.Forms.Label();
            this.lblTaxminiBitirmeTarixiLabel = new System.Windows.Forms.Label();
            this.lblQebulTarixi = new System.Windows.Forms.Label();
            this.lblQebulTarixiLabel = new System.Windows.Forms.Label();
            this.lblProblemTasviri = new System.Windows.Forms.Label();
            this.lblProblemTasviriLabel = new System.Windows.Forms.Label();
            this.lblSeriNomresi = new System.Windows.Forms.Label();
            this.lblSeriNomresiLabel = new System.Windows.Forms.Label();
            this.lblMehsulModeli = new System.Windows.Forms.Label();
            this.lblMehsulModeliLabel = new System.Windows.Forms.Label();
            this.lblMehsulAdi = new System.Windows.Forms.Label();
            this.lblMehsulAdiLabel = new System.Windows.Forms.Label();
            this.lblMusteriAdi = new System.Windows.Forms.Label();
            this.lblMusteriAdiLabel = new System.Windows.Forms.Label();
            this.lblTamirNomresi = new System.Windows.Forms.Label();
            this.lblTamirNomresiLabel = new System.Windows.Forms.Label();
            this.lblBasicInfoTitle = new System.Windows.Forms.Label();
            this.tabRepairSteps = new System.Windows.Forms.TabPage();
            this.dgvSteps = new System.Windows.Forms.DataGridView();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblStepsTitle = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrintReport = new System.Windows.Forms.Button();
            this.btnAssignWorker = new System.Windows.Forms.Button();
            this.btnChangeStatus = new System.Windows.Forms.Button();
            this.btnEditRepair = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabRepairInfo.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabRepairSteps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSteps)).BeginInit();
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
            this.lblTitle.Size = new System.Drawing.Size(216, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Təmir Təfərrüatları";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabRepairInfo);
            this.tabControl1.Controls.Add(this.tabRepairSteps);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tabControl1.Location = new System.Drawing.Point(0, 60);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1000, 520);
            this.tabControl1.TabIndex = 1;
            // 
            // tabRepairInfo
            // 
            this.tabRepairInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.tabRepairInfo.Controls.Add(this.panel3);
            this.tabRepairInfo.Controls.Add(this.panel2);
            this.tabRepairInfo.Location = new System.Drawing.Point(4, 29);
            this.tabRepairInfo.Name = "tabRepairInfo";
            this.tabRepairInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabRepairInfo.Size = new System.Drawing.Size(992, 487);
            this.tabRepairInfo.TabIndex = 0;
            this.tabRepairInfo.Text = "Əsas Məlumatlar";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.lblTamirciQeydleri);
            this.panel3.Controls.Add(this.lblTamirciQeydleriLabel);
            this.panel3.Controls.Add(this.lblMusteriQeydleri);
            this.panel3.Controls.Add(this.lblMusteriQeydleriLabel);
            this.panel3.Controls.Add(this.lblTeyinEdilenIsci);
            this.panel3.Controls.Add(this.lblTeyinEdilenIsciLabel);
            this.panel3.Controls.Add(this.lblPrioritet);
            this.panel3.Controls.Add(this.lblPrioritetLabel);
            this.panel3.Controls.Add(this.lblStatus);
            this.panel3.Controls.Add(this.lblStatusLabel);
            this.panel3.Controls.Add(this.lblSonQiymet);
            this.panel3.Controls.Add(this.lblSonQiymetLabel);
            this.panel3.Controls.Add(this.lblTaxminQiymet);
            this.panel3.Controls.Add(this.lblTaxminQiymetLabel);
            this.panel3.Controls.Add(this.lblRepairInfoTitle);
            this.panel3.Location = new System.Drawing.Point(500, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(470, 450);
            this.panel3.TabIndex = 1;
            // 
            // lblTamirciQeydleri
            // 
            this.lblTamirciQeydleri.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTamirciQeydleri.Location = new System.Drawing.Point(150, 350);
            this.lblTamirciQeydleri.Name = "lblTamirciQeydleri";
            this.lblTamirciQeydleri.Size = new System.Drawing.Size(300, 80);
            this.lblTamirciQeydleri.TabIndex = 14;
            this.lblTamirciQeydleri.Text = "-";
            // 
            // lblTamirciQeydleriLabel
            // 
            this.lblTamirciQeydleriLabel.AutoSize = true;
            this.lblTamirciQeydleriLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTamirciQeydleriLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTamirciQeydleriLabel.Location = new System.Drawing.Point(20, 350);
            this.lblTamirciQeydleriLabel.Name = "lblTamirciQeydleriLabel";
            this.lblTamirciQeydleriLabel.Size = new System.Drawing.Size(125, 19);
            this.lblTamirciQeydleriLabel.TabIndex = 13;
            this.lblTamirciQeydleriLabel.Text = "Tamirçi Qeydləri:";
            // 
            // lblMusteriQeydleri
            // 
            this.lblMusteriQeydleri.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMusteriQeydleri.Location = new System.Drawing.Point(150, 260);
            this.lblMusteriQeydleri.Name = "lblMusteriQeydleri";
            this.lblMusteriQeydleri.Size = new System.Drawing.Size(300, 80);
            this.lblMusteriQeydleri.TabIndex = 12;
            this.lblMusteriQeydleri.Text = "-";
            // 
            // lblMusteriQeydleriLabel
            // 
            this.lblMusteriQeydleriLabel.AutoSize = true;
            this.lblMusteriQeydleriLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMusteriQeydleriLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblMusteriQeydleriLabel.Location = new System.Drawing.Point(20, 260);
            this.lblMusteriQeydleriLabel.Name = "lblMusteriQeydleriLabel";
            this.lblMusteriQeydleriLabel.Size = new System.Drawing.Size(124, 19);
            this.lblMusteriQeydleriLabel.TabIndex = 11;
            this.lblMusteriQeydleriLabel.Text = "Müştəri Qeydləri:";
            // 
            // lblTeyinEdilenIsci
            // 
            this.lblTeyinEdilenIsci.AutoSize = true;
            this.lblTeyinEdilenIsci.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTeyinEdilenIsci.Location = new System.Drawing.Point(150, 225);
            this.lblTeyinEdilenIsci.Name = "lblTeyinEdilenIsci";
            this.lblTeyinEdilenIsci.Size = new System.Drawing.Size(15, 19);
            this.lblTeyinEdilenIsci.TabIndex = 10;
            this.lblTeyinEdilenIsci.Text = "-";
            // 
            // lblTeyinEdilenIsciLabel
            // 
            this.lblTeyinEdilenIsciLabel.AutoSize = true;
            this.lblTeyinEdilenIsciLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTeyinEdilenIsciLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTeyinEdilenIsciLabel.Location = new System.Drawing.Point(20, 225);
            this.lblTeyinEdilenIsciLabel.Name = "lblTeyinEdilenIsciLabel";
            this.lblTeyinEdilenIsciLabel.Size = new System.Drawing.Size(127, 19);
            this.lblTeyinEdilenIsciLabel.TabIndex = 9;
            this.lblTeyinEdilenIsciLabel.Text = "Təyin Edilən İşçi:";
            // 
            // lblPrioritet
            // 
            this.lblPrioritet.AutoSize = true;
            this.lblPrioritet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPrioritet.Location = new System.Drawing.Point(150, 185);
            this.lblPrioritet.Name = "lblPrioritet";
            this.lblPrioritet.Size = new System.Drawing.Size(15, 19);
            this.lblPrioritet.TabIndex = 8;
            this.lblPrioritet.Text = "-";
            // 
            // lblPrioritetLabel
            // 
            this.lblPrioritetLabel.AutoSize = true;
            this.lblPrioritetLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPrioritetLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblPrioritetLabel.Location = new System.Drawing.Point(20, 185);
            this.lblPrioritetLabel.Name = "lblPrioritetLabel";
            this.lblPrioritetLabel.Size = new System.Drawing.Size(71, 19);
            this.lblPrioritetLabel.TabIndex = 7;
            this.lblPrioritetLabel.Text = "Prioritet:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(150, 145);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(15, 19);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "-";
            // 
            // lblStatusLabel
            // 
            this.lblStatusLabel.AutoSize = true;
            this.lblStatusLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblStatusLabel.Location = new System.Drawing.Point(20, 145);
            this.lblStatusLabel.Name = "lblStatusLabel";
            this.lblStatusLabel.Size = new System.Drawing.Size(53, 19);
            this.lblStatusLabel.TabIndex = 5;
            this.lblStatusLabel.Text = "Status:";
            // 
            // lblSonQiymet
            // 
            this.lblSonQiymet.AutoSize = true;
            this.lblSonQiymet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSonQiymet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblSonQiymet.Location = new System.Drawing.Point(150, 105);
            this.lblSonQiymet.Name = "lblSonQiymet";
            this.lblSonQiymet.Size = new System.Drawing.Size(15, 19);
            this.lblSonQiymet.TabIndex = 4;
            this.lblSonQiymet.Text = "-";
            // 
            // lblSonQiymetLabel
            // 
            this.lblSonQiymetLabel.AutoSize = true;
            this.lblSonQiymetLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSonQiymetLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblSonQiymetLabel.Location = new System.Drawing.Point(20, 105);
            this.lblSonQiymetLabel.Name = "lblSonQiymetLabel";
            this.lblSonQiymetLabel.Size = new System.Drawing.Size(84, 19);
            this.lblSonQiymetLabel.TabIndex = 3;
            this.lblSonQiymetLabel.Text = "Son Qiymət:";
            // 
            // lblTaxminQiymet
            // 
            this.lblTaxminQiymet.AutoSize = true;
            this.lblTaxminQiymet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTaxminQiymet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblTaxminQiymet.Location = new System.Drawing.Point(150, 65);
            this.lblTaxminQiymet.Name = "lblTaxminQiymet";
            this.lblTaxminQiymet.Size = new System.Drawing.Size(15, 19);
            this.lblTaxminQiymet.TabIndex = 2;
            this.lblTaxminQiymet.Text = "-";
            // 
            // lblTaxminQiymetLabel
            // 
            this.lblTaxminQiymetLabel.AutoSize = true;
            this.lblTaxminQiymetLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTaxminQiymetLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTaxminQiymetLabel.Location = new System.Drawing.Point(20, 65);
            this.lblTaxminQiymetLabel.Name = "lblTaxminQiymetLabel";
            this.lblTaxminQiymetLabel.Size = new System.Drawing.Size(109, 19);
            this.lblTaxminQiymetLabel.TabIndex = 1;
            this.lblTaxminQiymetLabel.Text = "Təxmini Qiymət:";
            // 
            // lblRepairInfoTitle
            // 
            this.lblRepairInfoTitle.AutoSize = true;
            this.lblRepairInfoTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblRepairInfoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblRepairInfoTitle.Location = new System.Drawing.Point(15, 15);
            this.lblRepairInfoTitle.Name = "lblRepairInfoTitle";
            this.lblRepairInfoTitle.Size = new System.Drawing.Size(173, 25);
            this.lblRepairInfoTitle.TabIndex = 0;
            this.lblRepairInfoTitle.Text = "Təmir Məlumatları";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblTaxminiBitirmeTarixi);
            this.panel2.Controls.Add(this.lblTaxminiBitirmeTarixiLabel);
            this.panel2.Controls.Add(this.lblQebulTarixi);
            this.panel2.Controls.Add(this.lblQebulTarixiLabel);
            this.panel2.Controls.Add(this.lblProblemTasviri);
            this.panel2.Controls.Add(this.lblProblemTasviriLabel);
            this.panel2.Controls.Add(this.lblSeriNomresi);
            this.panel2.Controls.Add(this.lblSeriNomresiLabel);
            this.panel2.Controls.Add(this.lblMehsulModeli);
            this.panel2.Controls.Add(this.lblMehsulModeliLabel);
            this.panel2.Controls.Add(this.lblMehsulAdi);
            this.panel2.Controls.Add(this.lblMehsulAdiLabel);
            this.panel2.Controls.Add(this.lblMusteriAdi);
            this.panel2.Controls.Add(this.lblMusteriAdiLabel);
            this.panel2.Controls.Add(this.lblTamirNomresi);
            this.panel2.Controls.Add(this.lblTamirNomresiLabel);
            this.panel2.Controls.Add(this.lblBasicInfoTitle);
            this.panel2.Location = new System.Drawing.Point(20, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(460, 450);
            this.panel2.TabIndex = 0;
            // 
            // lblTaxminiBitirmeTarixi
            // 
            this.lblTaxminiBitirmeTarixi.AutoSize = true;
            this.lblTaxminiBitirmeTarixi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTaxminiBitirmeTarixi.Location = new System.Drawing.Point(170, 275);
            this.lblTaxminiBitirmeTarixi.Name = "lblTaxminiBitirmeTarixi";
            this.lblTaxminiBitirmeTarixi.Size = new System.Drawing.Size(15, 19);
            this.lblTaxminiBitirmeTarixi.TabIndex = 16;
            this.lblTaxminiBitirmeTarixi.Text = "-";
            // 
            // lblTaxminiBitirmeTarixiLabel
            // 
            this.lblTaxminiBitirmeTarixiLabel.AutoSize = true;
            this.lblTaxminiBitirmeTarixiLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTaxminiBitirmeTarixiLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTaxminiBitirmeTarixiLabel.Location = new System.Drawing.Point(20, 275);
            this.lblTaxminiBitirmeTarixiLabel.Name = "lblTaxminiBitirmeTarixiLabel";
            this.lblTaxminiBitirmeTarixiLabel.Size = new System.Drawing.Size(148, 19);
            this.lblTaxminiBitirmeTarixiLabel.TabIndex = 15;
            this.lblTaxminiBitirmeTarixiLabel.Text = "Təxmini Bitirmə Tarix:";
            // 
            // lblQebulTarixi
            // 
            this.lblQebulTarixi.AutoSize = true;
            this.lblQebulTarixi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblQebulTarixi.Location = new System.Drawing.Point(170, 245);
            this.lblQebulTarixi.Name = "lblQebulTarixi";
            this.lblQebulTarixi.Size = new System.Drawing.Size(15, 19);
            this.lblQebulTarixi.TabIndex = 14;
            this.lblQebulTarixi.Text = "-";
            // 
            // lblQebulTarixiLabel
            // 
            this.lblQebulTarixiLabel.AutoSize = true;
            this.lblQebulTarixiLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblQebulTarixiLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblQebulTarixiLabel.Location = new System.Drawing.Point(20, 245);
            this.lblQebulTarixiLabel.Name = "lblQebulTarixiLabel";
            this.lblQebulTarixiLabel.Size = new System.Drawing.Size(94, 19);
            this.lblQebulTarixiLabel.TabIndex = 13;
            this.lblQebulTarixiLabel.Text = "Qəbul Tarixi:";
            // 
            // lblProblemTasviri
            // 
            this.lblProblemTasviri.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblProblemTasviri.Location = new System.Drawing.Point(170, 165);
            this.lblProblemTasviri.Name = "lblProblemTasviri";
            this.lblProblemTasviri.Size = new System.Drawing.Size(270, 70);
            this.lblProblemTasviri.TabIndex = 12;
            this.lblProblemTasviri.Text = "-";
            // 
            // lblProblemTasviriLabel
            // 
            this.lblProblemTasviriLabel.AutoSize = true;
            this.lblProblemTasviriLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblProblemTasviriLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblProblemTasviriLabel.Location = new System.Drawing.Point(20, 165);
            this.lblProblemTasviriLabel.Name = "lblProblemTasviriLabel";
            this.lblProblemTasviriLabel.Size = new System.Drawing.Size(117, 19);
            this.lblProblemTasviriLabel.TabIndex = 11;
            this.lblProblemTasviriLabel.Text = "Problem Təsviri:";
            // 
            // lblSeriNomresi
            // 
            this.lblSeriNomresi.AutoSize = true;
            this.lblSeriNomresi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSeriNomresi.Location = new System.Drawing.Point(170, 135);
            this.lblSeriNomresi.Name = "lblSeriNomresi";
            this.lblSeriNomresi.Size = new System.Drawing.Size(15, 19);
            this.lblSeriNomresi.TabIndex = 10;
            this.lblSeriNomresi.Text = "-";
            // 
            // lblSeriNomresiLabel
            // 
            this.lblSeriNomresiLabel.AutoSize = true;
            this.lblSeriNomresiLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSeriNomresiLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblSeriNomresiLabel.Location = new System.Drawing.Point(20, 135);
            this.lblSeriNomresiLabel.Name = "lblSeriNomresiLabel";
            this.lblSeriNomresiLabel.Size = new System.Drawing.Size(100, 19);
            this.lblSeriNomresiLabel.TabIndex = 9;
            this.lblSeriNomresiLabel.Text = "Seri Nömrəsi:";
            // 
            // lblMehsulModeli
            // 
            this.lblMehsulModeli.AutoSize = true;
            this.lblMehsulModeli.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMehsulModeli.Location = new System.Drawing.Point(170, 105);
            this.lblMehsulModeli.Name = "lblMehsulModeli";
            this.lblMehsulModeli.Size = new System.Drawing.Size(15, 19);
            this.lblMehsulModeli.TabIndex = 8;
            this.lblMehsulModeli.Text = "-";
            // 
            // lblMehsulModeliLabel
            // 
            this.lblMehsulModeliLabel.AutoSize = true;
            this.lblMehsulModeliLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMehsulModeliLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblMehsulModeliLabel.Location = new System.Drawing.Point(20, 105);
            this.lblMehsulModeliLabel.Name = "lblMehsulModeliLabel";
            this.lblMehsulModeliLabel.Size = new System.Drawing.Size(108, 19);
            this.lblMehsulModeliLabel.TabIndex = 7;
            this.lblMehsulModeliLabel.Text = "Məhsul Modeli:";
            // 
            // lblMehsulAdi
            // 
            this.lblMehsulAdi.AutoSize = true;
            this.lblMehsulAdi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMehsulAdi.Location = new System.Drawing.Point(170, 75);
            this.lblMehsulAdi.Name = "lblMehsulAdi";
            this.lblMehsulAdi.Size = new System.Drawing.Size(15, 19);
            this.lblMehsulAdi.TabIndex = 6;
            this.lblMehsulAdi.Text = "-";
            // 
            // lblMehsulAdiLabel
            // 
            this.lblMehsulAdiLabel.AutoSize = true;
            this.lblMehsulAdiLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMehsulAdiLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblMehsulAdiLabel.Location = new System.Drawing.Point(20, 75);
            this.lblMehsulAdiLabel.Name = "lblMehsulAdiLabel";
            this.lblMehsulAdiLabel.Size = new System.Drawing.Size(87, 19);
            this.lblMehsulAdiLabel.TabIndex = 5;
            this.lblMehsulAdiLabel.Text = "Məhsul Adı:";
            // 
            // lblMusteriAdi
            // 
            this.lblMusteriAdi.AutoSize = true;
            this.lblMusteriAdi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMusteriAdi.Location = new System.Drawing.Point(170, 45);
            this.lblMusteriAdi.Name = "lblMusteriAdi";
            this.lblMusteriAdi.Size = new System.Drawing.Size(15, 19);
            this.lblMusteriAdi.TabIndex = 4;
            this.lblMusteriAdi.Text = "-";
            // 
            // lblMusteriAdiLabel
            // 
            this.lblMusteriAdiLabel.AutoSize = true;
            this.lblMusteriAdiLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMusteriAdiLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblMusteriAdiLabel.Location = new System.Drawing.Point(20, 45);
            this.lblMusteriAdiLabel.Name = "lblMusteriAdiLabel";
            this.lblMusteriAdiLabel.Size = new System.Drawing.Size(90, 19);
            this.lblMusteriAdiLabel.TabIndex = 3;
            this.lblMusteriAdiLabel.Text = "Müştəri Adı:";
            // 
            // lblTamirNomresi
            // 
            this.lblTamirNomresi.AutoSize = true;
            this.lblTamirNomresi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTamirNomresi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblTamirNomresi.Location = new System.Drawing.Point(170, 15);
            this.lblTamirNomresi.Name = "lblTamirNomresi";
            this.lblTamirNomresi.Size = new System.Drawing.Size(15, 19);
            this.lblTamirNomresi.TabIndex = 2;
            this.lblTamirNomresi.Text = "-";
            // 
            // lblTamirNomresiLabel
            // 
            this.lblTamirNomresiLabel.AutoSize = true;
            this.lblTamirNomresiLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTamirNomresiLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTamirNomresiLabel.Location = new System.Drawing.Point(20, 15);
            this.lblTamirNomresiLabel.Name = "lblTamirNomresiLabel";
            this.lblTamirNomresiLabel.Size = new System.Drawing.Size(111, 19);
            this.lblTamirNomresiLabel.TabIndex = 1;
            this.lblTamirNomresiLabel.Text = "Təmir Nömrəsi:";
            // 
            // lblBasicInfoTitle
            // 
            this.lblBasicInfoTitle.AutoSize = true;
            this.lblBasicInfoTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBasicInfoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblBasicInfoTitle.Location = new System.Drawing.Point(15, 15);
            this.lblBasicInfoTitle.Name = "lblBasicInfoTitle";
            this.lblBasicInfoTitle.Size = new System.Drawing.Size(159, 25);
            this.lblBasicInfoTitle.TabIndex = 0;
            this.lblBasicInfoTitle.Text = "Əsas Məlumatlar";
            this.lblBasicInfoTitle.Visible = false;
            // 
            // tabRepairSteps
            // 
            this.tabRepairSteps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.tabRepairSteps.Controls.Add(this.dgvSteps);
            this.tabRepairSteps.Controls.Add(this.panel6);
            this.tabRepairSteps.Location = new System.Drawing.Point(4, 29);
            this.tabRepairSteps.Name = "tabRepairSteps";
            this.tabRepairSteps.Padding = new System.Windows.Forms.Padding(3);
            this.tabRepairSteps.Size = new System.Drawing.Size(992, 487);
            this.tabRepairSteps.TabIndex = 1;
            this.tabRepairSteps.Text = "Təmir Mərhələləri";
            // 
            // dgvSteps
            // 
            this.dgvSteps.BackgroundColor = System.Drawing.Color.White;
            this.dgvSteps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSteps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSteps.Location = new System.Drawing.Point(3, 63);
            this.dgvSteps.Name = "dgvSteps";
            this.dgvSteps.Size = new System.Drawing.Size(986, 421);
            this.dgvSteps.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.lblStepsTitle);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(986, 60);
            this.panel6.TabIndex = 0;
            // 
            // lblStepsTitle
            // 
            this.lblStepsTitle.AutoSize = true;
            this.lblStepsTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblStepsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblStepsTitle.Location = new System.Drawing.Point(20, 18);
            this.lblStepsTitle.Name = "lblStepsTitle";
            this.lblStepsTitle.Size = new System.Drawing.Size(167, 25);
            this.lblStepsTitle.TabIndex = 0;
            this.lblStepsTitle.Text = "Təmir Mərhələləri";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Controls.Add(this.btnClose);
            this.panel7.Controls.Add(this.btnPrintReport);
            this.panel7.Controls.Add(this.btnAssignWorker);
            this.panel7.Controls.Add(this.btnChangeStatus);
            this.panel7.Controls.Add(this.btnEditRepair);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 510);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1000, 70);
            this.panel7.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(820, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(150, 40);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Bağla";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnPrintReport.FlatAppearance.BorderSize = 0;
            this.btnPrintReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintReport.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnPrintReport.ForeColor = System.Drawing.Color.White;
            this.btnPrintReport.Location = new System.Drawing.Point(650, 15);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(150, 40);
            this.btnPrintReport.TabIndex = 3;
            this.btnPrintReport.Text = "Hesabat Çap Et";
            this.btnPrintReport.UseVisualStyleBackColor = false;
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // btnAssignWorker
            // 
            this.btnAssignWorker.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnAssignWorker.FlatAppearance.BorderSize = 0;
            this.btnAssignWorker.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssignWorker.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnAssignWorker.ForeColor = System.Drawing.Color.White;
            this.btnAssignWorker.Location = new System.Drawing.Point(480, 15);
            this.btnAssignWorker.Name = "btnAssignWorker";
            this.btnAssignWorker.Size = new System.Drawing.Size(150, 40);
            this.btnAssignWorker.TabIndex = 2;
            this.btnAssignWorker.Text = "İşçi Təyin Et";
            this.btnAssignWorker.UseVisualStyleBackColor = false;
            this.btnAssignWorker.Click += new System.EventHandler(this.btnAssignWorker_Click);
            // 
            // btnChangeStatus
            // 
            this.btnChangeStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnChangeStatus.FlatAppearance.BorderSize = 0;
            this.btnChangeStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeStatus.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnChangeStatus.ForeColor = System.Drawing.Color.White;
            this.btnChangeStatus.Location = new System.Drawing.Point(310, 15);
            this.btnChangeStatus.Name = "btnChangeStatus";
            this.btnChangeStatus.Size = new System.Drawing.Size(150, 40);
            this.btnChangeStatus.TabIndex = 1;
            this.btnChangeStatus.Text = "Status Dəyiş";
            this.btnChangeStatus.UseVisualStyleBackColor = false;
            this.btnChangeStatus.Click += new System.EventHandler(this.btnChangeStatus_Click);
            // 
            // btnEditRepair
            // 
            this.btnEditRepair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnEditRepair.FlatAppearance.BorderSize = 0;
            this.btnEditRepair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditRepair.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnEditRepair.ForeColor = System.Drawing.Color.White;
            this.btnEditRepair.Location = new System.Drawing.Point(140, 15);
            this.btnEditRepair.Name = "btnEditRepair";
            this.btnEditRepair.Size = new System.Drawing.Size(150, 40);
            this.btnEditRepair.TabIndex = 0;
            this.btnEditRepair.Text = "Təmiri Düzəlt";
            this.btnEditRepair.UseVisualStyleBackColor = false;
            this.btnEditRepair.Click += new System.EventHandler(this.btnEditRepair_Click);
            // 
            // TamirDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1000, 580);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TamirDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Təmir Təfərrüatları";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabRepairInfo.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabRepairSteps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSteps)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabRepairInfo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblBasicInfoTitle;
        private System.Windows.Forms.Label lblTamirNomresiLabel;
        private System.Windows.Forms.Label lblTamirNomresi;
        private System.Windows.Forms.Label lblMusteriAdiLabel;
        private System.Windows.Forms.Label lblMusteriAdi;
        private System.Windows.Forms.Label lblMehsulAdiLabel;
        private System.Windows.Forms.Label lblMehsulAdi;
        private System.Windows.Forms.Label lblMehsulModeliLabel;
        private System.Windows.Forms.Label lblMehsulModeli;
        private System.Windows.Forms.Label lblSeriNomresiLabel;
        private System.Windows.Forms.Label lblSeriNomresi;
        private System.Windows.Forms.Label lblProblemTasviriLabel;
        private System.Windows.Forms.Label lblProblemTasviri;
        private System.Windows.Forms.Label lblQebulTarixiLabel;
        private System.Windows.Forms.Label lblQebulTarixi;
        private System.Windows.Forms.Label lblTaxminiBitirmeTarixiLabel;
        private System.Windows.Forms.Label lblTaxminiBitirmeTarixi;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblRepairInfoTitle;
        private System.Windows.Forms.Label lblTaxminQiymetLabel;
        private System.Windows.Forms.Label lblTaxminQiymet;
        private System.Windows.Forms.Label lblSonQiymetLabel;
        private System.Windows.Forms.Label lblSonQiymet;
        private System.Windows.Forms.Label lblStatusLabel;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblPrioritetLabel;
        private System.Windows.Forms.Label lblPrioritet;
        private System.Windows.Forms.Label lblTeyinEdilenIsciLabel;
        private System.Windows.Forms.Label lblTeyinEdilenIsci;
        private System.Windows.Forms.Label lblMusteriQeydleriLabel;
        private System.Windows.Forms.Label lblMusteriQeydleri;
        private System.Windows.Forms.Label lblTamirciQeydleriLabel;
        private System.Windows.Forms.Label lblTamirciQeydleri;
        private System.Windows.Forms.TabPage tabRepairSteps;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lblStepsTitle;
        private System.Windows.Forms.DataGridView dgvSteps;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnEditRepair;
        private System.Windows.Forms.Button btnChangeStatus;
        private System.Windows.Forms.Button btnAssignWorker;
        private System.Windows.Forms.Button btnPrintReport;
        private System.Windows.Forms.Button btnClose;
    }
}