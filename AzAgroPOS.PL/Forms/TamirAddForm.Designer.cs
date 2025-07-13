namespace AzAgroPOS.PL.Forms
{
    partial class TamirAddForm
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
            this.tabBasicInfo = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtProblemTasviri = new System.Windows.Forms.TextBox();
            this.lblProblemTasviri = new System.Windows.Forms.Label();
            this.txtSeriyaNomresi = new System.Windows.Forms.TextBox();
            this.lblSeriyaNomresi = new System.Windows.Forms.Label();
            this.txtMehsulModeli = new System.Windows.Forms.TextBox();
            this.lblMehsulModeli = new System.Windows.Forms.Label();
            this.txtMehsulAdi = new System.Windows.Forms.TextBox();
            this.lblMehsulAdi = new System.Windows.Forms.Label();
            this.cmbMehsul = new System.Windows.Forms.ComboBox();
            this.lblMehsul = new System.Windows.Forms.Label();
            this.lblProductInfoTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtMusteriQeydleri = new System.Windows.Forms.TextBox();
            this.lblMusteriQeydleri = new System.Windows.Forms.Label();
            this.cmbMusteri = new System.Windows.Forms.ComboBox();
            this.lblMusteri = new System.Windows.Forms.Label();
            this.lblCustomerInfoTitle = new System.Windows.Forms.Label();
            this.tabRepairInfo = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtTamirciQeydleri = new System.Windows.Forms.TextBox();
            this.lblTamirciQeydleri = new System.Windows.Forms.Label();
            this.cmbTeyinEdilenIsci = new System.Windows.Forms.ComboBox();
            this.lblTeyinEdilenIsci = new System.Windows.Forms.Label();
            this.cmbPrioritet = new System.Windows.Forms.ComboBox();
            this.lblPrioritet = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblRepairDetailsTitle = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.numTaxminQiymet = new System.Windows.Forms.NumericUpDown();
            this.lblTaxminQiymet = new System.Windows.Forms.Label();
            this.dtpTaxminiBitirmeTarixi = new System.Windows.Forms.DateTimePicker();
            this.lblTaxminiBitirmeTarixi = new System.Windows.Forms.Label();
            this.dtpQebulTarixi = new System.Windows.Forms.DateTimePicker();
            this.lblQebulTarixi = new System.Windows.Forms.Label();
            this.lblDateInfoTitle = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabBasicInfo.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabRepairInfo.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTaxminQiymet)).BeginInit();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(230, 126, 34);
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
            this.lblTitle.Size = new System.Drawing.Size(236, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🔧 Yeni Təmir İşi";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabBasicInfo);
            this.tabControl1.Controls.Add(this.tabRepairInfo);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tabControl1.Location = new System.Drawing.Point(0, 60);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(900, 470);
            this.tabControl1.TabIndex = 1;
            // 
            // tabBasicInfo
            // 
            this.tabBasicInfo.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.tabBasicInfo.Controls.Add(this.panel3);
            this.tabBasicInfo.Controls.Add(this.panel2);
            this.tabBasicInfo.Location = new System.Drawing.Point(4, 29);
            this.tabBasicInfo.Name = "tabBasicInfo";
            this.tabBasicInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabBasicInfo.Size = new System.Drawing.Size(892, 437);
            this.tabBasicInfo.TabIndex = 0;
            this.tabBasicInfo.Text = "Əsas Məlumatlar";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.txtProblemTasviri);
            this.panel3.Controls.Add(this.lblProblemTasviri);
            this.panel3.Controls.Add(this.txtSeriyaNomresi);
            this.panel3.Controls.Add(this.lblSeriyaNomresi);
            this.panel3.Controls.Add(this.txtMehsulModeli);
            this.panel3.Controls.Add(this.lblMehsulModeli);
            this.panel3.Controls.Add(this.txtMehsulAdi);
            this.panel3.Controls.Add(this.lblMehsulAdi);
            this.panel3.Controls.Add(this.cmbMehsul);
            this.panel3.Controls.Add(this.lblMehsul);
            this.panel3.Controls.Add(this.lblProductInfoTitle);
            this.panel3.Location = new System.Drawing.Point(20, 190);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(850, 240);
            this.panel3.TabIndex = 1;
            // 
            // txtProblemTasviri
            // 
            this.txtProblemTasviri.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtProblemTasviri.Location = new System.Drawing.Point(150, 157);
            this.txtProblemTasviri.Multiline = true;
            this.txtProblemTasviri.Name = "txtProblemTasviri";
            this.txtProblemTasviri.Size = new System.Drawing.Size(650, 70);
            this.txtProblemTasviri.TabIndex = 10;
            // 
            // lblProblemTasviri
            // 
            this.lblProblemTasviri.AutoSize = true;
            this.lblProblemTasviri.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblProblemTasviri.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblProblemTasviri.Location = new System.Drawing.Point(20, 160);
            this.lblProblemTasviri.Name = "lblProblemTasviri";
            this.lblProblemTasviri.Size = new System.Drawing.Size(130, 19);
            this.lblProblemTasviri.TabIndex = 9;
            this.lblProblemTasviri.Text = "Problem Təsviri: *";
            // 
            // txtSeriyaNomresi
            // 
            this.txtSeriyaNomresi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSeriyaNomresi.Location = new System.Drawing.Point(150, 122);
            this.txtSeriyaNomresi.Name = "txtSeriyaNomresi";
            this.txtSeriyaNomresi.Size = new System.Drawing.Size(300, 25);
            this.txtSeriyaNomresi.TabIndex = 8;
            // 
            // lblSeriyaNomresi
            // 
            this.lblSeriyaNomresi.AutoSize = true;
            this.lblSeriyaNomresi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSeriyaNomresi.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblSeriyaNomresi.Location = new System.Drawing.Point(20, 125);
            this.lblSeriyaNomresi.Name = "lblSeriyaNomresi";
            this.lblSeriyaNomresi.Size = new System.Drawing.Size(115, 19);
            this.lblSeriyaNomresi.TabIndex = 7;
            this.lblSeriyaNomresi.Text = "Seriya Nömrəsi:";
            // 
            // txtMehsulModeli
            // 
            this.txtMehsulModeli.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMehsulModeli.Location = new System.Drawing.Point(600, 87);
            this.txtMehsulModeli.Name = "txtMehsulModeli";
            this.txtMehsulModeli.Size = new System.Drawing.Size(200, 25);
            this.txtMehsulModeli.TabIndex = 6;
            // 
            // lblMehsulModeli
            // 
            this.lblMehsulModeli.AutoSize = true;
            this.lblMehsulModeli.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMehsulModeli.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblMehsulModeli.Location = new System.Drawing.Point(480, 90);
            this.lblMehsulModeli.Name = "lblMehsulModeli";
            this.lblMehsulModeli.Size = new System.Drawing.Size(110, 19);
            this.lblMehsulModeli.TabIndex = 5;
            this.lblMehsulModeli.Text = "Məhsul Modeli:";
            // 
            // txtMehsulAdi
            // 
            this.txtMehsulAdi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMehsulAdi.Location = new System.Drawing.Point(150, 87);
            this.txtMehsulAdi.Name = "txtMehsulAdi";
            this.txtMehsulAdi.Size = new System.Drawing.Size(300, 25);
            this.txtMehsulAdi.TabIndex = 4;
            // 
            // lblMehsulAdi
            // 
            this.lblMehsulAdi.AutoSize = true;
            this.lblMehsulAdi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMehsulAdi.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblMehsulAdi.Location = new System.Drawing.Point(20, 90);
            this.lblMehsulAdi.Name = "lblMehsulAdi";
            this.lblMehsulAdi.Size = new System.Drawing.Size(95, 19);
            this.lblMehsulAdi.TabIndex = 3;
            this.lblMehsulAdi.Text = "Məhsul Adı: *";
            // 
            // cmbMehsul
            // 
            this.cmbMehsul.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMehsul.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbMehsul.FormattingEnabled = true;
            this.cmbMehsul.Location = new System.Drawing.Point(150, 52);
            this.cmbMehsul.Name = "cmbMehsul";
            this.cmbMehsul.Size = new System.Drawing.Size(300, 25);
            this.cmbMehsul.TabIndex = 2;
            this.cmbMehsul.SelectedIndexChanged += new System.EventHandler(this.cmbMehsul_SelectedIndexChanged);
            // 
            // lblMehsul
            // 
            this.lblMehsul.AutoSize = true;
            this.lblMehsul.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMehsul.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblMehsul.Location = new System.Drawing.Point(20, 55);
            this.lblMehsul.Name = "lblMehsul";
            this.lblMehsul.Size = new System.Drawing.Size(93, 19);
            this.lblMehsul.TabIndex = 1;
            this.lblMehsul.Text = "Məhsul Seç:";
            // 
            // lblProductInfoTitle
            // 
            this.lblProductInfoTitle.AutoSize = true;
            this.lblProductInfoTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblProductInfoTitle.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblProductInfoTitle.Location = new System.Drawing.Point(15, 15);
            this.lblProductInfoTitle.Name = "lblProductInfoTitle";
            this.lblProductInfoTitle.Size = new System.Drawing.Size(179, 25);
            this.lblProductInfoTitle.TabIndex = 0;
            this.lblProductInfoTitle.Text = "Məhsul Məlumatları";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.txtMusteriQeydleri);
            this.panel2.Controls.Add(this.lblMusteriQeydleri);
            this.panel2.Controls.Add(this.cmbMusteri);
            this.panel2.Controls.Add(this.lblMusteri);
            this.panel2.Controls.Add(this.lblCustomerInfoTitle);
            this.panel2.Location = new System.Drawing.Point(20, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(850, 150);
            this.panel2.TabIndex = 0;
            // 
            // txtMusteriQeydleri
            // 
            this.txtMusteriQeydleri.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMusteriQeydleri.Location = new System.Drawing.Point(150, 87);
            this.txtMusteriQeydleri.Multiline = true;
            this.txtMusteriQeydleri.Name = "txtMusteriQeydleri";
            this.txtMusteriQeydleri.Size = new System.Drawing.Size(650, 50);
            this.txtMusteriQeydleri.TabIndex = 4;
            // 
            // lblMusteriQeydleri
            // 
            this.lblMusteriQeydleri.AutoSize = true;
            this.lblMusteriQeydleri.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMusteriQeydleri.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblMusteriQeydleri.Location = new System.Drawing.Point(20, 90);
            this.lblMusteriQeydleri.Name = "lblMusteriQeydleri";
            this.lblMusteriQeydleri.Size = new System.Drawing.Size(124, 19);
            this.lblMusteriQeydleri.TabIndex = 3;
            this.lblMusteriQeydleri.Text = "Müştəri Qeydləri:";
            // 
            // cmbMusteri
            // 
            this.cmbMusteri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMusteri.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbMusteri.FormattingEnabled = true;
            this.cmbMusteri.Location = new System.Drawing.Point(150, 52);
            this.cmbMusteri.Name = "cmbMusteri";
            this.cmbMusteri.Size = new System.Drawing.Size(300, 25);
            this.cmbMusteri.TabIndex = 2;
            // 
            // lblMusteri
            // 
            this.lblMusteri.AutoSize = true;
            this.lblMusteri.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMusteri.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblMusteri.Location = new System.Drawing.Point(20, 55);
            this.lblMusteri.Name = "lblMusteri";
            this.lblMusteri.Size = new System.Drawing.Size(68, 19);
            this.lblMusteri.TabIndex = 1;
            this.lblMusteri.Text = "Müştəri: *";
            // 
            // lblCustomerInfoTitle
            // 
            this.lblCustomerInfoTitle.AutoSize = true;
            this.lblCustomerInfoTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblCustomerInfoTitle.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblCustomerInfoTitle.Location = new System.Drawing.Point(15, 15);
            this.lblCustomerInfoTitle.Name = "lblCustomerInfoTitle";
            this.lblCustomerInfoTitle.Size = new System.Drawing.Size(179, 25);
            this.lblCustomerInfoTitle.TabIndex = 0;
            this.lblCustomerInfoTitle.Text = "Müştəri Məlumatları";
            // 
            // tabRepairInfo
            // 
            this.tabRepairInfo.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.tabRepairInfo.Controls.Add(this.panel5);
            this.tabRepairInfo.Controls.Add(this.panel4);
            this.tabRepairInfo.Location = new System.Drawing.Point(4, 29);
            this.tabRepairInfo.Name = "tabRepairInfo";
            this.tabRepairInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabRepairInfo.Size = new System.Drawing.Size(892, 437);
            this.tabRepairInfo.TabIndex = 1;
            this.tabRepairInfo.Text = "Təmir Məlumatları";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.txtTamirciQeydleri);
            this.panel5.Controls.Add(this.lblTamirciQeydleri);
            this.panel5.Controls.Add(this.cmbTeyinEdilenIsci);
            this.panel5.Controls.Add(this.lblTeyinEdilenIsci);
            this.panel5.Controls.Add(this.cmbPrioritet);
            this.panel5.Controls.Add(this.lblPrioritet);
            this.panel5.Controls.Add(this.cmbStatus);
            this.panel5.Controls.Add(this.lblStatus);
            this.panel5.Controls.Add(this.lblRepairDetailsTitle);
            this.panel5.Location = new System.Drawing.Point(20, 220);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(850, 210);
            this.panel5.TabIndex = 1;
            // 
            // txtTamirciQeydleri
            // 
            this.txtTamirciQeydleri.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTamirciQeydleri.Location = new System.Drawing.Point(150, 122);
            this.txtTamirciQeydleri.Multiline = true;
            this.txtTamirciQeydleri.Name = "txtTamirciQeydleri";
            this.txtTamirciQeydleri.Size = new System.Drawing.Size(650, 70);
            this.txtTamirciQeydleri.TabIndex = 8;
            // 
            // lblTamirciQeydleri
            // 
            this.lblTamirciQeydleri.AutoSize = true;
            this.lblTamirciQeydleri.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTamirciQeydleri.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblTamirciQeydleri.Location = new System.Drawing.Point(20, 125);
            this.lblTamirciQeydleri.Name = "lblTamirciQeydleri";
            this.lblTamirciQeydleri.Size = new System.Drawing.Size(124, 19);
            this.lblTamirciQeydleri.TabIndex = 7;
            this.lblTamirciQeydleri.Text = "Tamirçi Qeydləri:";
            // 
            // cmbTeyinEdilenIsci
            // 
            this.cmbTeyinEdilenIsci.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTeyinEdilenIsci.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTeyinEdilenIsci.FormattingEnabled = true;
            this.cmbTeyinEdilenIsci.Location = new System.Drawing.Point(150, 87);
            this.cmbTeyinEdilenIsci.Name = "cmbTeyinEdilenIsci";
            this.cmbTeyinEdilenIsci.Size = new System.Drawing.Size(300, 25);
            this.cmbTeyinEdilenIsci.TabIndex = 6;
            // 
            // lblTeyinEdilenIsci
            // 
            this.lblTeyinEdilenIsci.AutoSize = true;
            this.lblTeyinEdilenIsci.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTeyinEdilenIsci.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblTeyinEdilenIsci.Location = new System.Drawing.Point(20, 90);
            this.lblTeyinEdilenIsci.Name = "lblTeyinEdilenIsci";
            this.lblTeyinEdilenIsci.Size = new System.Drawing.Size(124, 19);
            this.lblTeyinEdilenIsci.TabIndex = 5;
            this.lblTeyinEdilenIsci.Text = "Təyin Edilən İşçi:";
            // 
            // cmbPrioritet
            // 
            this.cmbPrioritet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrioritet.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbPrioritet.FormattingEnabled = true;
            this.cmbPrioritet.Location = new System.Drawing.Point(480, 52);
            this.cmbPrioritet.Name = "cmbPrioritet";
            this.cmbPrioritet.Size = new System.Drawing.Size(200, 25);
            this.cmbPrioritet.TabIndex = 4;
            // 
            // lblPrioritet
            // 
            this.lblPrioritet.AutoSize = true;
            this.lblPrioritet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPrioritet.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblPrioritet.Location = new System.Drawing.Point(380, 55);
            this.lblPrioritet.Name = "lblPrioritet";
            this.lblPrioritet.Size = new System.Drawing.Size(67, 19);
            this.lblPrioritet.TabIndex = 3;
            this.lblPrioritet.Text = "Prioritet:";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(150, 52);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(200, 25);
            this.cmbStatus.TabIndex = 2;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblStatus.Location = new System.Drawing.Point(20, 55);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(53, 19);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Status:";
            // 
            // lblRepairDetailsTitle
            // 
            this.lblRepairDetailsTitle.AutoSize = true;
            this.lblRepairDetailsTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblRepairDetailsTitle.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblRepairDetailsTitle.Location = new System.Drawing.Point(15, 15);
            this.lblRepairDetailsTitle.Name = "lblRepairDetailsTitle";
            this.lblRepairDetailsTitle.Size = new System.Drawing.Size(188, 25);
            this.lblRepairDetailsTitle.TabIndex = 0;
            this.lblRepairDetailsTitle.Text = "Təmir Təfərrüatları";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.numTaxminQiymet);
            this.panel4.Controls.Add(this.lblTaxminQiymet);
            this.panel4.Controls.Add(this.dtpTaxminiBitirmeTarixi);
            this.panel4.Controls.Add(this.lblTaxminiBitirmeTarixi);
            this.panel4.Controls.Add(this.dtpQebulTarixi);
            this.panel4.Controls.Add(this.lblQebulTarixi);
            this.panel4.Controls.Add(this.lblDateInfoTitle);
            this.panel4.Location = new System.Drawing.Point(20, 20);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(850, 180);
            this.panel4.TabIndex = 0;
            // 
            // numTaxminQiymet
            // 
            this.numTaxminQiymet.DecimalPlaces = 2;
            this.numTaxminQiymet.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.numTaxminQiymet.Location = new System.Drawing.Point(200, 122);
            this.numTaxminQiymet.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numTaxminQiymet.Name = "numTaxminQiymet";
            this.numTaxminQiymet.Size = new System.Drawing.Size(150, 25);
            this.numTaxminQiymet.TabIndex = 6;
            // 
            // lblTaxminQiymet
            // 
            this.lblTaxminQiymet.AutoSize = true;
            this.lblTaxminQiymet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTaxminQiymet.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblTaxminQiymet.Location = new System.Drawing.Point(20, 125);
            this.lblTaxminQiymet.Name = "lblTaxminQiymet";
            this.lblTaxminQiymet.Size = new System.Drawing.Size(129, 19);
            this.lblTaxminQiymet.TabIndex = 5;
            this.lblTaxminQiymet.Text = "Təxmini Qiymət: *";
            // 
            // dtpTaxminiBitirmeTarixi
            // 
            this.dtpTaxminiBitirmeTarixi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpTaxminiBitirmeTarixi.Location = new System.Drawing.Point(200, 87);
            this.dtpTaxminiBitirmeTarixi.Name = "dtpTaxminiBitirmeTarixi";
            this.dtpTaxminiBitirmeTarixi.Size = new System.Drawing.Size(200, 25);
            this.dtpTaxminiBitirmeTarixi.TabIndex = 4;
            // 
            // lblTaxminiBitirmeTarixi
            // 
            this.lblTaxminiBitirmeTarixi.AutoSize = true;
            this.lblTaxminiBitirmeTarixi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTaxminiBitirmeTarixi.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblTaxminiBitirmeTarixi.Location = new System.Drawing.Point(20, 90);
            this.lblTaxminiBitirmeTarixi.Name = "lblTaxminiBitirmeTarixi";
            this.lblTaxminiBitirmeTarixi.Size = new System.Drawing.Size(170, 19);
            this.lblTaxminiBitirmeTarixi.TabIndex = 3;
            this.lblTaxminiBitirmeTarixi.Text = "Təxmini Bitirmə Tarixi:";
            // 
            // dtpQebulTarixi
            // 
            this.dtpQebulTarixi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpQebulTarixi.Location = new System.Drawing.Point(200, 52);
            this.dtpQebulTarixi.Name = "dtpQebulTarixi";
            this.dtpQebulTarixi.Size = new System.Drawing.Size(200, 25);
            this.dtpQebulTarixi.TabIndex = 2;
            // 
            // lblQebulTarixi
            // 
            this.lblQebulTarixi.AutoSize = true;
            this.lblQebulTarixi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblQebulTarixi.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblQebulTarixi.Location = new System.Drawing.Point(20, 55);
            this.lblQebulTarixi.Name = "lblQebulTarixi";
            this.lblQebulTarixi.Size = new System.Drawing.Size(94, 19);
            this.lblQebulTarixi.TabIndex = 1;
            this.lblQebulTarixi.Text = "Qəbul Tarixi:";
            // 
            // lblDateInfoTitle
            // 
            this.lblDateInfoTitle.AutoSize = true;
            this.lblDateInfoTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDateInfoTitle.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblDateInfoTitle.Location = new System.Drawing.Point(15, 15);
            this.lblDateInfoTitle.Name = "lblDateInfoTitle";
            this.lblDateInfoTitle.Size = new System.Drawing.Size(156, 25);
            this.lblDateInfoTitle.TabIndex = 0;
            this.lblDateInfoTitle.Text = "Tarix Məlumatları";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.btnCancel);
            this.panel6.Controls.Add(this.btnSave);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 530);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(900, 70);
            this.panel6.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(760, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 40);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "✗ Ləğv Et";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(600, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 40);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "✓ Yadda Saxla";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // TamirAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TamirAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Yeni Təmir İşi";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabBasicInfo.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabRepairInfo.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTaxminQiymet)).EndInit();
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabBasicInfo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtProblemTasviri;
        private System.Windows.Forms.Label lblProblemTasviri;
        private System.Windows.Forms.TextBox txtSeriyaNomresi;
        private System.Windows.Forms.Label lblSeriyaNomresi;
        private System.Windows.Forms.TextBox txtMehsulModeli;
        private System.Windows.Forms.Label lblMehsulModeli;
        private System.Windows.Forms.TextBox txtMehsulAdi;
        private System.Windows.Forms.Label lblMehsulAdi;
        private System.Windows.Forms.ComboBox cmbMehsul;
        private System.Windows.Forms.Label lblMehsul;
        private System.Windows.Forms.Label lblProductInfoTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtMusteriQeydleri;
        private System.Windows.Forms.Label lblMusteriQeydleri;
        private System.Windows.Forms.ComboBox cmbMusteri;
        private System.Windows.Forms.Label lblMusteri;
        private System.Windows.Forms.Label lblCustomerInfoTitle;
        private System.Windows.Forms.TabPage tabRepairInfo;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtTamirciQeydleri;
        private System.Windows.Forms.Label lblTamirciQeydleri;
        private System.Windows.Forms.ComboBox cmbTeyinEdilenIsci;
        private System.Windows.Forms.Label lblTeyinEdilenIsci;
        private System.Windows.Forms.ComboBox cmbPrioritet;
        private System.Windows.Forms.Label lblPrioritet;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblRepairDetailsTitle;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.NumericUpDown numTaxminQiymet;
        private System.Windows.Forms.Label lblTaxminQiymet;
        private System.Windows.Forms.DateTimePicker dtpTaxminiBitirmeTarixi;
        private System.Windows.Forms.Label lblTaxminiBitirmeTarixi;
        private System.Windows.Forms.DateTimePicker dtpQebulTarixi;
        private System.Windows.Forms.Label lblQebulTarixi;
        private System.Windows.Forms.Label lblDateInfoTitle;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}