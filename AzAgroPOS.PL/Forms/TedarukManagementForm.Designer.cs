namespace AzAgroPOS.PL.Forms
{
    partial class TedarukManagementForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabTedarukciler = new System.Windows.Forms.TabPage();
            this.panelTedarukcu = new System.Windows.Forms.Panel();
            this.dgvTedarukciler = new System.Windows.Forms.DataGridView();
            this.colTedarukcuKod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTedarukcuAd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTelefon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCariBorc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKreditLimiti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTedarukcuButtons = new System.Windows.Forms.Panel();
            this.btnYeniTedarukcu = new System.Windows.Forms.Button();
            this.btnDuzenleTedarukcu = new System.Windows.Forms.Button();
            this.btnSilTedarukcu = new System.Windows.Forms.Button();
            this.btnOdemeYap = new System.Windows.Forms.Button();
            this.panelTedarukcuSearch = new System.Windows.Forms.Panel();
            this.txtTedarukcuAxtaris = new System.Windows.Forms.TextBox();
            this.lblTedarukcuAxtaris = new System.Windows.Forms.Label();
            this.tabAlisOrderleri = new System.Windows.Forms.TabPage();
            this.panelAlisOrder = new System.Windows.Forms.Panel();
            this.dgvAlisOrderleri = new System.Windows.Forms.DataGridView();
            this.colOrderNomresi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderTarixi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTedarukcu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderMebleg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOrderStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTeslimTarixi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelOrderButtons = new System.Windows.Forms.Panel();
            this.btnYeniOrder = new System.Windows.Forms.Button();
            this.btnDuzenleOrder = new System.Windows.Forms.Button();
            this.btnTesdiqleOrder = new System.Windows.Forms.Button();
            this.btnIptalOrder = new System.Windows.Forms.Button();
            this.btnOrderDetali = new System.Windows.Forms.Button();
            this.panelOrderFilter = new System.Windows.Forms.Panel();
            this.cmbOrderStatus = new System.Windows.Forms.ComboBox();
            this.lblOrderStatus = new System.Windows.Forms.Label();
            this.dtpOrderStart = new System.Windows.Forms.DateTimePicker();
            this.dtpOrderEnd = new System.Windows.Forms.DateTimePicker();
            this.lblOrderTarix = new System.Windows.Forms.Label();
            this.tabAlisSenedleri = new System.Windows.Forms.TabPage();
            this.panelAlisSened = new System.Windows.Forms.Panel();
            this.dgvAlisSenedleri = new System.Windows.Forms.DataGridView();
            this.colSenedNomresi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSenedTarixi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSenedTedarukcu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSenedAnbar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSenedMebleg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSenedStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOdemeStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelSenedButtons = new System.Windows.Forms.Panel();
            this.btnYeniSened = new System.Windows.Forms.Button();
            this.btnQebulEt = new System.Windows.Forms.Button();
            this.btnIptalSened = new System.Windows.Forms.Button();
            this.btnSenedDetali = new System.Windows.Forms.Button();
            this.btnFaktura = new System.Windows.Forms.Button();
            this.panelSenedFilter = new System.Windows.Forms.Panel();
            this.cmbSenedStatus = new System.Windows.Forms.ComboBox();
            this.lblSenedStatus = new System.Windows.Forms.Label();
            this.cmbOdemeStatus = new System.Windows.Forms.ComboBox();
            this.lblOdemeStatus = new System.Windows.Forms.Label();
            this.tabAnbarTransfer = new System.Windows.Forms.TabPage();
            this.panelTransfer = new System.Windows.Forms.Panel();
            this.dgvTransferler = new System.Windows.Forms.DataGridView();
            this.colTransferNomresi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransferTarixi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMenbAnbar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHedefAnbar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMehsulSayi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTransferStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTransferButtons = new System.Windows.Forms.Panel();
            this.btnYeniTransfer = new System.Windows.Forms.Button();
            this.btnGonderTransfer = new System.Windows.Forms.Button();
            this.btnQebulTransfer = new System.Windows.Forms.Button();
            this.btnIptalTransfer = new System.Windows.Forms.Button();
            this.btnTransferDetali = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl.SuspendLayout();
            this.tabTedarukciler.SuspendLayout();
            this.panelTedarukcu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTedarukciler)).BeginInit();
            this.panelTedarukcuButtons.SuspendLayout();
            this.panelTedarukcuSearch.SuspendLayout();
            this.tabAlisOrderleri.SuspendLayout();
            this.panelAlisOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlisOrderleri)).BeginInit();
            this.panelOrderButtons.SuspendLayout();
            this.panelOrderFilter.SuspendLayout();
            this.tabAlisSenedleri.SuspendLayout();
            this.panelAlisSened.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlisSenedleri)).BeginInit();
            this.panelSenedButtons.SuspendLayout();
            this.panelSenedFilter.SuspendLayout();
            this.tabAnbarTransfer.SuspendLayout();
            this.panelTransfer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferler)).BeginInit();
            this.panelTransferButtons.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabTedarukciler);
            this.tabControl.Controls.Add(this.tabAlisOrderleri);
            this.tabControl.Controls.Add(this.tabAlisSenedleri);
            this.tabControl.Controls.Add(this.tabAnbarTransfer);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1200, 650);
            this.tabControl.TabIndex = 0;
            // 
            // tabTedarukciler
            // 
            this.tabTedarukciler.Controls.Add(this.panelTedarukcu);
            this.tabTedarukciler.Location = new System.Drawing.Point(4, 28);
            this.tabTedarukciler.Name = "tabTedarukciler";
            this.tabTedarukciler.Padding = new System.Windows.Forms.Padding(3);
            this.tabTedarukciler.Size = new System.Drawing.Size(1192, 618);
            this.tabTedarukciler.TabIndex = 0;
            this.tabTedarukciler.Text = "Tədarükçülər";
            this.tabTedarukciler.UseVisualStyleBackColor = true;
            // 
            // panelTedarukcu
            // 
            this.panelTedarukcu.Controls.Add(this.dgvTedarukciler);
            this.panelTedarukcu.Controls.Add(this.panelTedarukcuButtons);
            this.panelTedarukcu.Controls.Add(this.panelTedarukcuSearch);
            this.panelTedarukcu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTedarukcu.Location = new System.Drawing.Point(3, 3);
            this.panelTedarukcu.Name = "panelTedarukcu";
            this.panelTedarukcu.Size = new System.Drawing.Size(1186, 612);
            this.panelTedarukcu.TabIndex = 0;
            // 
            // dgvTedarukciler
            // 
            this.dgvTedarukciler.AllowUserToAddRows = false;
            this.dgvTedarukciler.AllowUserToDeleteRows = false;
            this.dgvTedarukciler.BackgroundColor = System.Drawing.Color.White;
            this.dgvTedarukciler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTedarukciler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTedarukcuKod,
            this.colTedarukcuAd,
            this.colTelefon,
            this.colEmail,
            this.colCariBorc,
            this.colKreditLimiti,
            this.colStatus});
            this.dgvTedarukciler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTedarukciler.Location = new System.Drawing.Point(0, 60);
            this.dgvTedarukciler.MultiSelect = false;
            this.dgvTedarukciler.Name = "dgvTedarukciler";
            this.dgvTedarukciler.ReadOnly = true;
            this.dgvTedarukciler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTedarukciler.Size = new System.Drawing.Size(1186, 492);
            this.dgvTedarukciler.TabIndex = 0;
            // 
            // colTedarukcuKod
            // 
            this.colTedarukcuKod.HeaderText = "Kod";
            this.colTedarukcuKod.Name = "colTedarukcuKod";
            this.colTedarukcuKod.ReadOnly = true;
            this.colTedarukcuKod.Width = 80;
            // 
            // colTedarukcuAd
            // 
            this.colTedarukcuAd.HeaderText = "Tədarükçü Adı";
            this.colTedarukcuAd.Name = "colTedarukcuAd";
            this.colTedarukcuAd.ReadOnly = true;
            this.colTedarukcuAd.Width = 250;
            // 
            // colTelefon
            // 
            this.colTelefon.HeaderText = "Telefon";
            this.colTelefon.Name = "colTelefon";
            this.colTelefon.ReadOnly = true;
            this.colTelefon.Width = 120;
            // 
            // colEmail
            // 
            this.colEmail.HeaderText = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.ReadOnly = true;
            this.colEmail.Width = 200;
            // 
            // colCariBorc
            // 
            this.colCariBorc.HeaderText = "Cari Borc";
            this.colCariBorc.Name = "colCariBorc";
            this.colCariBorc.ReadOnly = true;
            this.colCariBorc.Width = 120;
            // 
            // colKreditLimiti
            // 
            this.colKreditLimiti.HeaderText = "Kredit Limiti";
            this.colKreditLimiti.Name = "colKreditLimiti";
            this.colKreditLimiti.ReadOnly = true;
            this.colKreditLimiti.Width = 120;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 100;
            // 
            // panelTedarukcuButtons
            // 
            this.panelTedarukcuButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelTedarukcuButtons.Controls.Add(this.btnOdemeYap);
            this.panelTedarukcuButtons.Controls.Add(this.btnSilTedarukcu);
            this.panelTedarukcuButtons.Controls.Add(this.btnDuzenleTedarukcu);
            this.panelTedarukcuButtons.Controls.Add(this.btnYeniTedarukcu);
            this.panelTedarukcuButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTedarukcuButtons.Location = new System.Drawing.Point(0, 552);
            this.panelTedarukcuButtons.Name = "panelTedarukcuButtons";
            this.panelTedarukcuButtons.Size = new System.Drawing.Size(1186, 60);
            this.panelTedarukcuButtons.TabIndex = 1;
            // 
            // btnYeniTedarukcu
            // 
            this.btnYeniTedarukcu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnYeniTedarukcu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYeniTedarukcu.ForeColor = System.Drawing.Color.White;
            this.btnYeniTedarukcu.Location = new System.Drawing.Point(12, 15);
            this.btnYeniTedarukcu.Name = "btnYeniTedarukcu";
            this.btnYeniTedarukcu.Size = new System.Drawing.Size(120, 35);
            this.btnYeniTedarukcu.TabIndex = 0;
            this.btnYeniTedarukcu.Text = "Yeni Tədarükçü";
            this.btnYeniTedarukcu.UseVisualStyleBackColor = false;
            // 
            // btnDuzenleTedarukcu
            // 
            this.btnDuzenleTedarukcu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnDuzenleTedarukcu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDuzenleTedarukcu.ForeColor = System.Drawing.Color.White;
            this.btnDuzenleTedarukcu.Location = new System.Drawing.Point(138, 15);
            this.btnDuzenleTedarukcu.Name = "btnDuzenleTedarukcu";
            this.btnDuzenleTedarukcu.Size = new System.Drawing.Size(100, 35);
            this.btnDuzenleTedarukcu.TabIndex = 1;
            this.btnDuzenleTedarukcu.Text = "Düzənlə";
            this.btnDuzenleTedarukcu.UseVisualStyleBackColor = false;
            // 
            // btnSilTedarukcu
            // 
            this.btnSilTedarukcu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnSilTedarukcu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSilTedarukcu.ForeColor = System.Drawing.Color.White;
            this.btnSilTedarukcu.Location = new System.Drawing.Point(244, 15);
            this.btnSilTedarukcu.Name = "btnSilTedarukcu";
            this.btnSilTedarukcu.Size = new System.Drawing.Size(80, 35);
            this.btnSilTedarukcu.TabIndex = 2;
            this.btnSilTedarukcu.Text = "Sil";
            this.btnSilTedarukcu.UseVisualStyleBackColor = false;
            // 
            // btnOdemeYap
            // 
            this.btnOdemeYap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnOdemeYap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOdemeYap.ForeColor = System.Drawing.Color.White;
            this.btnOdemeYap.Location = new System.Drawing.Point(330, 15);
            this.btnOdemeYap.Name = "btnOdemeYap";
            this.btnOdemeYap.Size = new System.Drawing.Size(100, 35);
            this.btnOdemeYap.TabIndex = 3;
            this.btnOdemeYap.Text = "Ödəmə Yap";
            this.btnOdemeYap.UseVisualStyleBackColor = false;
            // 
            // panelTedarukcuSearch
            // 
            this.panelTedarukcuSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelTedarukcuSearch.Controls.Add(this.lblTedarukcuAxtaris);
            this.panelTedarukcuSearch.Controls.Add(this.txtTedarukcuAxtaris);
            this.panelTedarukcuSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTedarukcuSearch.Location = new System.Drawing.Point(0, 0);
            this.panelTedarukcuSearch.Name = "panelTedarukcuSearch";
            this.panelTedarukcuSearch.Size = new System.Drawing.Size(1186, 60);
            this.panelTedarukcuSearch.TabIndex = 2;
            // 
            // txtTedarukcuAxtaris
            // 
            this.txtTedarukcuAxtaris.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTedarukcuAxtaris.Location = new System.Drawing.Point(100, 20);
            this.txtTedarukcuAxtaris.Name = "txtTedarukcuAxtaris";
            this.txtTedarukcuAxtaris.Size = new System.Drawing.Size(300, 27);
            this.txtTedarukcuAxtaris.TabIndex = 0;
            // 
            // lblTedarukcuAxtaris
            // 
            this.lblTedarukcuAxtaris.AutoSize = true;
            this.lblTedarukcuAxtaris.Location = new System.Drawing.Point(12, 24);
            this.lblTedarukcuAxtaris.Name = "lblTedarukcuAxtaris";
            this.lblTedarukcuAxtaris.Size = new System.Drawing.Size(56, 19);
            this.lblTedarukcuAxtaris.TabIndex = 1;
            this.lblTedarukcuAxtaris.Text = "Axtarış:";
            // 
            // tabAlisOrderleri
            // 
            this.tabAlisOrderleri.Controls.Add(this.panelAlisOrder);
            this.tabAlisOrderleri.Location = new System.Drawing.Point(4, 28);
            this.tabAlisOrderleri.Name = "tabAlisOrderleri";
            this.tabAlisOrderleri.Padding = new System.Windows.Forms.Padding(3);
            this.tabAlisOrderleri.Size = new System.Drawing.Size(1192, 618);
            this.tabAlisOrderleri.TabIndex = 1;
            this.tabAlisOrderleri.Text = "Alış Sifarişləri";
            this.tabAlisOrderleri.UseVisualStyleBackColor = true;
            // 
            // panelAlisOrder
            // 
            this.panelAlisOrder.Controls.Add(this.dgvAlisOrderleri);
            this.panelAlisOrder.Controls.Add(this.panelOrderButtons);
            this.panelAlisOrder.Controls.Add(this.panelOrderFilter);
            this.panelAlisOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAlisOrder.Location = new System.Drawing.Point(3, 3);
            this.panelAlisOrder.Name = "panelAlisOrder";
            this.panelAlisOrder.Size = new System.Drawing.Size(1186, 612);
            this.panelAlisOrder.TabIndex = 0;
            // 
            // dgvAlisOrderleri
            // 
            this.dgvAlisOrderleri.AllowUserToAddRows = false;
            this.dgvAlisOrderleri.AllowUserToDeleteRows = false;
            this.dgvAlisOrderleri.BackgroundColor = System.Drawing.Color.White;
            this.dgvAlisOrderleri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlisOrderleri.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOrderNomresi,
            this.colOrderTarixi,
            this.colTedarukcu,
            this.colOrderMebleg,
            this.colOrderStatus,
            this.colTeslimTarixi});
            this.dgvAlisOrderleri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlisOrderleri.Location = new System.Drawing.Point(0, 60);
            this.dgvAlisOrderleri.Name = "dgvAlisOrderleri";
            this.dgvAlisOrderleri.ReadOnly = true;
            this.dgvAlisOrderleri.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlisOrderleri.Size = new System.Drawing.Size(1186, 492);
            this.dgvAlisOrderleri.TabIndex = 0;
            // 
            // colOrderNomresi
            // 
            this.colOrderNomresi.HeaderText = "Order Nömrəsi";
            this.colOrderNomresi.Name = "colOrderNomresi";
            this.colOrderNomresi.ReadOnly = true;
            this.colOrderNomresi.Width = 120;
            // 
            // colOrderTarixi
            // 
            this.colOrderTarixi.HeaderText = "Tarix";
            this.colOrderTarixi.Name = "colOrderTarixi";
            this.colOrderTarixi.ReadOnly = true;
            this.colOrderTarixi.Width = 100;
            // 
            // colTedarukcu
            // 
            this.colTedarukcu.HeaderText = "Tədarükçü";
            this.colTedarukcu.Name = "colTedarukcu";
            this.colTedarukcu.ReadOnly = true;
            this.colTedarukcu.Width = 200;
            // 
            // colOrderMebleg
            // 
            this.colOrderMebleg.HeaderText = "Məbləğ";
            this.colOrderMebleg.Name = "colOrderMebleg";
            this.colOrderMebleg.ReadOnly = true;
            this.colOrderMebleg.Width = 120;
            // 
            // colOrderStatus
            // 
            this.colOrderStatus.HeaderText = "Status";
            this.colOrderStatus.Name = "colOrderStatus";
            this.colOrderStatus.ReadOnly = true;
            this.colOrderStatus.Width = 120;
            // 
            // colTeslimTarixi
            // 
            this.colTeslimTarixi.HeaderText = "Təslim Tarixi";
            this.colTeslimTarixi.Name = "colTeslimTarixi";
            this.colTeslimTarixi.ReadOnly = true;
            this.colTeslimTarixi.Width = 120;
            // 
            // panelOrderButtons
            // 
            this.panelOrderButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelOrderButtons.Controls.Add(this.btnOrderDetali);
            this.panelOrderButtons.Controls.Add(this.btnIptalOrder);
            this.panelOrderButtons.Controls.Add(this.btnTesdiqleOrder);
            this.panelOrderButtons.Controls.Add(this.btnDuzenleOrder);
            this.panelOrderButtons.Controls.Add(this.btnYeniOrder);
            this.panelOrderButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelOrderButtons.Location = new System.Drawing.Point(0, 552);
            this.panelOrderButtons.Name = "panelOrderButtons";
            this.panelOrderButtons.Size = new System.Drawing.Size(1186, 60);
            this.panelOrderButtons.TabIndex = 1;
            // 
            // btnYeniOrder
            // 
            this.btnYeniOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnYeniOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYeniOrder.ForeColor = System.Drawing.Color.White;
            this.btnYeniOrder.Location = new System.Drawing.Point(12, 15);
            this.btnYeniOrder.Name = "btnYeniOrder";
            this.btnYeniOrder.Size = new System.Drawing.Size(100, 35);
            this.btnYeniOrder.TabIndex = 0;
            this.btnYeniOrder.Text = "Yeni Order";
            this.btnYeniOrder.UseVisualStyleBackColor = false;
            // 
            // btnDuzenleOrder
            // 
            this.btnDuzenleOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnDuzenleOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDuzenleOrder.ForeColor = System.Drawing.Color.White;
            this.btnDuzenleOrder.Location = new System.Drawing.Point(118, 15);
            this.btnDuzenleOrder.Name = "btnDuzenleOrder";
            this.btnDuzenleOrder.Size = new System.Drawing.Size(100, 35);
            this.btnDuzenleOrder.TabIndex = 1;
            this.btnDuzenleOrder.Text = "Düzənlə";
            this.btnDuzenleOrder.UseVisualStyleBackColor = false;
            // 
            // btnTesdiqleOrder
            // 
            this.btnTesdiqleOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnTesdiqleOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTesdiqleOrder.ForeColor = System.Drawing.Color.White;
            this.btnTesdiqleOrder.Location = new System.Drawing.Point(224, 15);
            this.btnTesdiqleOrder.Name = "btnTesdiqleOrder";
            this.btnTesdiqleOrder.Size = new System.Drawing.Size(100, 35);
            this.btnTesdiqleOrder.TabIndex = 2;
            this.btnTesdiqleOrder.Text = "Təsdiqlə";
            this.btnTesdiqleOrder.UseVisualStyleBackColor = false;
            // 
            // btnIptalOrder
            // 
            this.btnIptalOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnIptalOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIptalOrder.ForeColor = System.Drawing.Color.White;
            this.btnIptalOrder.Location = new System.Drawing.Point(330, 15);
            this.btnIptalOrder.Name = "btnIptalOrder";
            this.btnIptalOrder.Size = new System.Drawing.Size(80, 35);
            this.btnIptalOrder.TabIndex = 3;
            this.btnIptalOrder.Text = "İptal";
            this.btnIptalOrder.UseVisualStyleBackColor = false;
            // 
            // btnOrderDetali
            // 
            this.btnOrderDetali.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnOrderDetali.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderDetali.ForeColor = System.Drawing.Color.White;
            this.btnOrderDetali.Location = new System.Drawing.Point(416, 15);
            this.btnOrderDetali.Name = "btnOrderDetali";
            this.btnOrderDetali.Size = new System.Drawing.Size(100, 35);
            this.btnOrderDetali.TabIndex = 4;
            this.btnOrderDetali.Text = "Detaylar";
            this.btnOrderDetali.UseVisualStyleBackColor = false;
            // 
            // panelOrderFilter
            // 
            this.panelOrderFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelOrderFilter.Controls.Add(this.lblOrderTarix);
            this.panelOrderFilter.Controls.Add(this.dtpOrderEnd);
            this.panelOrderFilter.Controls.Add(this.dtpOrderStart);
            this.panelOrderFilter.Controls.Add(this.lblOrderStatus);
            this.panelOrderFilter.Controls.Add(this.cmbOrderStatus);
            this.panelOrderFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelOrderFilter.Location = new System.Drawing.Point(0, 0);
            this.panelOrderFilter.Name = "panelOrderFilter";
            this.panelOrderFilter.Size = new System.Drawing.Size(1186, 60);
            this.panelOrderFilter.TabIndex = 2;
            // 
            // cmbOrderStatus
            // 
            this.cmbOrderStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrderStatus.FormattingEnabled = true;
            this.cmbOrderStatus.Location = new System.Drawing.Point(70, 20);
            this.cmbOrderStatus.Name = "cmbOrderStatus";
            this.cmbOrderStatus.Size = new System.Drawing.Size(150, 25);
            this.cmbOrderStatus.TabIndex = 0;
            // 
            // lblOrderStatus
            // 
            this.lblOrderStatus.AutoSize = true;
            this.lblOrderStatus.Location = new System.Drawing.Point(12, 24);
            this.lblOrderStatus.Name = "lblOrderStatus";
            this.lblOrderStatus.Size = new System.Drawing.Size(50, 19);
            this.lblOrderStatus.TabIndex = 1;
            this.lblOrderStatus.Text = "Status:";
            // 
            // dtpOrderStart
            // 
            this.dtpOrderStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOrderStart.Location = = System.Drawing.Point(290, 20);
            this.dtpOrderStart.Name = "dtpOrderStart";
            this.dtpOrderStart.Size = new System.Drawing.Size(120, 25);
            this.dtpOrderStart.TabIndex = 2;
            // 
            // dtpOrderEnd
            // 
            this.dtpOrderEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOrderEnd.Location = new System.Drawing.Point(420, 20);
            this.dtpOrderEnd.Name = "dtpOrderEnd";
            this.dtpOrderEnd.Size = new System.Drawing.Size(120, 25);
            this.dtpOrderEnd.TabIndex = 3;
            // 
            // lblOrderTarix
            // 
            this.lblOrderTarix.AutoSize = true;
            this.lblOrderTarix.Location = new System.Drawing.Point(240, 24);
            this.lblOrderTarix.Name = "lblOrderTarix";
            this.lblOrderTarix.Size = new System.Drawing.Size(42, 19);
            this.lblOrderTarix.TabIndex = 4;
            this.lblOrderTarix.Text = "Tarix:";
            // 
            // tabAlisSenedleri
            // 
            this.tabAlisSenedleri.Controls.Add(this.panelAlisSened);
            this.tabAlisSenedleri.Location = new System.Drawing.Point(4, 28);
            this.tabAlisSenedleri.Name = "tabAlisSenedleri";
            this.tabAlisSenedleri.Size = new System.Drawing.Size(1192, 618);
            this.tabAlisSenedleri.TabIndex = 2;
            this.tabAlisSenedleri.Text = "Alış Sənədləri";
            this.tabAlisSenedleri.UseVisualStyleBackColor = true;
            // 
            // panelAlisSened
            // 
            this.panelAlisSened.Controls.Add(this.dgvAlisSenedleri);
            this.panelAlisSened.Controls.Add(this.panelSenedButtons);
            this.panelAlisSened.Controls.Add(this.panelSenedFilter);
            this.panelAlisSened.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAlisSened.Location = new System.Drawing.Point(0, 0);
            this.panelAlisSened.Name = "panelAlisSened";
            this.panelAlisSened.Size = new System.Drawing.Size(1192, 618);
            this.panelAlisSened.TabIndex = 0;
            // 
            // dgvAlisSenedleri
            // 
            this.dgvAlisSenedleri.AllowUserToAddRows = false;
            this.dgvAlisSenedleri.AllowUserToDeleteRows = false;
            this.dgvAlisSenedleri.BackgroundColor = System.Drawing.Color.White;
            this.dgvAlisSenedleri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlisSenedleri.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSenedNomresi,
            this.colSenedTarixi,
            this.colSenedTedarukcu,
            this.colSenedAnbar,
            this.colSenedMebleg,
            this.colSenedStatus,
            this.colOdemeStatus});
            this.dgvAlisSenedleri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlisSenedleri.Location = new System.Drawing.Point(0, 60);
            this.dgvAlisSenedleri.Name = "dgvAlisSenedleri";
            this.dgvAlisSenedleri.ReadOnly = true;
            this.dgvAlisSenedleri.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlisSenedleri.Size = new System.Drawing.Size(1192, 498);
            this.dgvAlisSenedleri.TabIndex = 0;
            // 
            // colSenedNomresi
            // 
            this.colSenedNomresi.HeaderText = "Sənəd Nömrəsi";
            this.colSenedNomresi.Name = "colSenedNomresi";
            this.colSenedNomresi.ReadOnly = true;
            this.colSenedNomresi.Width = 120;
            // 
            // colSenedTarixi
            // 
            this.colSenedTarixi.HeaderText = "Tarix";
            this.colSenedTarixi.Name = "colSenedTarixi";
            this.colSenedTarixi.ReadOnly = true;
            this.colSenedTarixi.Width = 100;
            // 
            // colSenedTedarukcu
            // 
            this.colSenedTedarukcu.HeaderText = "Tədarükçü";
            this.colSenedTedarukcu.Name = "colSenedTedarukcu";
            this.colSenedTedarukcu.ReadOnly = true;
            this.colSenedTedarukcu.Width = 200;
            // 
            // colSenedAnbar
            // 
            this.colSenedAnbar.HeaderText = "Anbar";
            this.colSenedAnbar.Name = "colSenedAnbar";
            this.colSenedAnbar.ReadOnly = true;
            this.colSenedAnbar.Width = 150;
            // 
            // colSenedMebleg
            // 
            this.colSenedMebleg.HeaderText = "Məbləğ";
            this.colSenedMebleg.Name = "colSenedMebleg";
            this.colSenedMebleg.ReadOnly = true;
            this.colSenedMebleg.Width = 120;
            // 
            // colSenedStatus
            // 
            this.colSenedStatus.HeaderText = "Status";
            this.colSenedStatus.Name = "colSenedStatus";
            this.colSenedStatus.ReadOnly = true;
            this.colSenedStatus.Width = 120;
            // 
            // colOdemeStatus
            // 
            this.colOdemeStatus.HeaderText = "Ödəmə Status";
            this.colOdemeStatus.Name = "colOdemeStatus";
            this.colOdemeStatus.ReadOnly = true;
            this.colOdemeStatus.Width = 120;
            // 
            // panelSenedButtons
            // 
            this.panelSenedButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelSenedButtons.Controls.Add(this.btnFaktura);
            this.panelSenedButtons.Controls.Add(this.btnSenedDetali);
            this.panelSenedButtons.Controls.Add(this.btnIptalSened);
            this.panelSenedButtons.Controls.Add(this.btnQebulEt);
            this.panelSenedButtons.Controls.Add(this.btnYeniSened);
            this.panelSenedButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSenedButtons.Location = new System.Drawing.Point(0, 558);
            this.panelSenedButtons.Name = "panelSenedButtons";
            this.panelSenedButtons.Size = new System.Drawing.Size(1192, 60);
            this.panelSenedButtons.TabIndex = 1;
            // 
            // btnYeniSened
            // 
            this.btnYeniSened.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnYeniSened.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYeniSened.ForeColor = System.Drawing.Color.White;
            this.btnYeniSened.Location = new System.Drawing.Point(12, 15);
            this.btnYeniSened.Name = "btnYeniSened";
            this.btnYeniSened.Size = new System.Drawing.Size(100, 35);
            this.btnYeniSened.TabIndex = 0;
            this.btnYeniSened.Text = "Yeni Sənəd";
            this.btnYeniSened.UseVisualStyleBackColor = false;
            // 
            // btnQebulEt
            // 
            this.btnQebulEt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnQebulEt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQebulEt.ForeColor = System.Drawing.Color.White;
            this.btnQebulEt.Location = new System.Drawing.Point(118, 15);
            this.btnQebulEt.Name = "btnQebulEt";
            this.btnQebulEt.Size = new System.Drawing.Size(100, 35);
            this.btnQebulEt.TabIndex = 1;
            this.btnQebulEt.Text = "Qəbul Et";
            this.btnQebulEt.UseVisualStyleBackColor = false;
            // 
            // btnIptalSened
            // 
            this.btnIptalSened.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnIptalSened.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIptalSened.ForeColor = System.Drawing.Color.White;
            this.btnIptalSened.Location = new System.Drawing.Point(224, 15);
            this.btnIptalSened.Name = "btnIptalSened";
            this.btnIptalSened.Size = new System.Drawing.Size(80, 35);
            this.btnIptalSened.TabIndex = 2;
            this.btnIptalSened.Text = "İptal";
            this.btnIptalSened.UseVisualStyleBackColor = false;
            // 
            // btnSenedDetali
            // 
            this.btnSenedDetali.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnSenedDetali.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSenedDetali.ForeColor = System.Drawing.Color.White;
            this.btnSenedDetali.Location = new System.Drawing.Point(310, 15);
            this.btnSenedDetali.Name = "btnSenedDetali";
            this.btnSenedDetali.Size = new System.Drawing.Size(100, 35);
            this.btnSenedDetali.TabIndex = 3;
            this.btnSenedDetali.Text = "Detaylar";
            this.btnSenedDetali.UseVisualStyleBackColor = false;
            // 
            // btnFaktura
            // 
            this.btnFaktura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnFaktura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFaktura.ForeColor = System.Drawing.Color.White;
            this.btnFaktura.Location = new System.Drawing.Point(416, 15);
            this.btnFaktura.Name = "btnFaktura";
            this.btnFaktura.Size = new System.Drawing.Size(100, 35);
            this.btnFaktura.TabIndex = 4;
            this.btnFaktura.Text = "Faktura Çap";
            this.btnFaktura.UseVisualStyleBackColor = false;
            // 
            // panelSenedFilter
            // 
            this.panelSenedFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.panelSenedFilter.Controls.Add(this.lblOdemeStatus);
            this.panelSenedFilter.Controls.Add(this.cmbOdemeStatus);
            this.panelSenedFilter.Controls.Add(this.lblSenedStatus);
            this.panelSenedFilter.Controls.Add(this.cmbSenedStatus);
            this.panelSenedFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSenedFilter.Location = new System.Drawing.Point(0, 0);
            this.panelSenedFilter.Name = "panelSenedFilter";
            this.panelSenedFilter.Size = new System.Drawing.Size(1192, 60);
            this.panelSenedFilter.TabIndex = 2;
            // 
            // cmbSenedStatus
            // 
            this.cmbSenedStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSenedStatus.FormattingEnabled = true;
            this.cmbSenedStatus.Location = new System.Drawing.Point(70, 20);
            this.cmbSenedStatus.Name = "cmbSenedStatus";
            this.cmbSenedStatus.Size = new System.Drawing.Size(150, 25);
            this.cmbSenedStatus.TabIndex = 0;
            // 
            // lblSenedStatus
            // 
            this.lblSenedStatus.AutoSize = true;
            this.lblSenedStatus.Location = new System.Drawing.Point(12, 24);
            this.lblSenedStatus.Name = "lblSenedStatus";
            this.lblSenedStatus.Size = new System.Drawing.Size(50, 19);
            this.lblSenedStatus.TabIndex = 1;
            this.lblSenedStatus.Text = "Status:";
            // 
            // cmbOdemeStatus
            // 
            this.cmbOdemeStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOdemeStatus.FormattingEnabled = true;
            this.cmbOdemeStatus.Location = new System.Drawing.Point(320, 20);
            this.cmbOdemeStatus.Name = "cmbOdemeStatus";
            this.cmbOdemeStatus.Size = new System.Drawing.Size(150, 25);
            this.cmbOdemeStatus.TabIndex = 2;
            // 
            // lblOdemeStatus
            // 
            this.lblOdemeStatus.AutoSize = true;
            this.lblOdemeStatus.Location = new System.Drawing.Point(240, 24);
            this.lblOdemeStatus.Name = "lblOdemeStatus";
            this.lblOdemeStatus.Size = new System.Drawing.Size(77, 19);
            this.lblOdemeStatus.TabIndex = 3;
            this.lblOdemeStatus.Text = "Ödəmə St.:";
            // 
            // tabAnbarTransfer
            // 
            this.tabAnbarTransfer.Controls.Add(this.panelTransfer);
            this.tabAnbarTransfer.Location = new System.Drawing.Point(4, 28);
            this.tabAnbarTransfer.Name = "tabAnbarTransfer";
            this.tabAnbarTransfer.Size = new System.Drawing.Size(1192, 618);
            this.tabAnbarTransfer.TabIndex = 3;
            this.tabAnbarTransfer.Text = "Anbar Transferləri";
            this.tabAnbarTransfer.UseVisualStyleBackColor = true;
            // 
            // panelTransfer
            // 
            this.panelTransfer.Controls.Add(this.dgvTransferler);
            this.panelTransfer.Controls.Add(this.panelTransferButtons);
            this.panelTransfer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTransfer.Location = new System.Drawing.Point(0, 0);
            this.panelTransfer.Name = "panelTransfer";
            this.panelTransfer.Size = new System.Drawing.Size(1192, 618);
            this.panelTransfer.TabIndex = 0;
            // 
            // dgvTransferler
            // 
            this.dgvTransferler.AllowUserToAddRows = false;
            this.dgvTransferler.AllowUserToDeleteRows = false;
            this.dgvTransferler.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransferler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransferler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTransferNomresi,
            this.colTransferTarixi,
            this.colMenbAnbar,
            this.colHedefAnbar,
            this.colMehsulSayi,
            this.colTransferStatus});
            this.dgvTransferler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTransferler.Location = new System.Drawing.Point(0, 0);
            this.dgvTransferler.Name = "dgvTransferler";
            this.dgvTransferler.ReadOnly = true;
            this.dgvTransferler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransferler.Size = new System.Drawing.Size(1192, 558);
            this.dgvTransferler.TabIndex = 0;
            // 
            // colTransferNomresi
            // 
            this.colTransferNomresi.HeaderText = "Transfer Nömrəsi";
            this.colTransferNomresi.Name = "colTransferNomresi";
            this.colTransferNomresi.ReadOnly = true;
            this.colTransferNomresi.Width = 140;
            // 
            // colTransferTarixi
            // 
            this.colTransferTarixi.HeaderText = "Tarix";
            this.colTransferTarixi.Name = "colTransferTarixi";
            this.colTransferTarixi.ReadOnly = true;
            this.colTransferTarixi.Width = 100;
            // 
            // colMenbAnbar
            // 
            this.colMenbAnbar.HeaderText = "Mənbə Anbar";
            this.colMenbAnbar.Name = "colMenbAnbar";
            this.colMenbAnbar.ReadOnly = true;
            this.colMenbAnbar.Width = 150;
            // 
            // colHedefAnbar
            // 
            this.colHedefAnbar.HeaderText = "Hədəf Anbar";
            this.colHedefAnbar.Name = "colHedefAnbar";
            this.colHedefAnbar.ReadOnly = true;
            this.colHedefAnbar.Width = 150;
            // 
            // colMehsulSayi
            // 
            this.colMehsulSayi.HeaderText = "Məhsul Sayı";
            this.colMehsulSayi.Name = "colMehsulSayi";
            this.colMehsulSayi.ReadOnly = true;
            this.colMehsulSayi.Width = 100;
            // 
            // colTransferStatus
            // 
            this.colTransferStatus.HeaderText = "Status";
            this.colTransferStatus.Name = "colTransferStatus";
            this.colTransferStatus.ReadOnly = true;
            this.colTransferStatus.Width = 120;
            // 
            // panelTransferButtons
            // 
            this.panelTransferButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelTransferButtons.Controls.Add(this.btnTransferDetali);
            this.panelTransferButtons.Controls.Add(this.btnIptalTransfer);
            this.panelTransferButtons.Controls.Add(this.btnQebulTransfer);
            this.panelTransferButtons.Controls.Add(this.btnGonderTransfer);
            this.panelTransferButtons.Controls.Add(this.btnYeniTransfer);
            this.panelTransferButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTransferButtons.Location = new System.Drawing.Point(0, 558);
            this.panelTransferButtons.Name = "panelTransferButtons";
            this.panelTransferButtons.Size = new System.Drawing.Size(1192, 60);
            this.panelTransferButtons.TabIndex = 1;
            // 
            // btnYeniTransfer
            // 
            this.btnYeniTransfer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnYeniTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYeniTransfer.ForeColor = System.Drawing.Color.White;
            this.btnYeniTransfer.Location = new System.Drawing.Point(12, 15);
            this.btnYeniTransfer.Name = "btnYeniTransfer";
            this.btnYeniTransfer.Size = new System.Drawing.Size(110, 35);
            this.btnYeniTransfer.TabIndex = 0;
            this.btnYeniTransfer.Text = "Yeni Transfer";
            this.btnYeniTransfer.UseVisualStyleBackColor = false;
            // 
            // btnGonderTransfer
            // 
            this.btnGonderTransfer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnGonderTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGonderTransfer.ForeColor = System.Drawing.Color.White;
            this.btnGonderTransfer.Location = new System.Drawing.Point(128, 15);
            this.btnGonderTransfer.Name = "btnGonderTransfer";
            this.btnGonderTransfer.Size = new System.Drawing.Size(100, 35);
            this.btnGonderTransfer.TabIndex = 1;
            this.btnGonderTransfer.Text = "Göndər";
            this.btnGonderTransfer.UseVisualStyleBackColor = false;
            // 
            // btnQebulTransfer
            // 
            this.btnQebulTransfer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnQebulTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQebulTransfer.ForeColor = System.Drawing.Color.White;
            this.btnQebulTransfer.Location = new System.Drawing.Point(234, 15);
            this.btnQebulTransfer.Name = "btnQebulTransfer";
            this.btnQebulTransfer.Size = new System.Drawing.Size(100, 35);
            this.btnQebulTransfer.TabIndex = 2;
            this.btnQebulTransfer.Text = "Qəbul Et";
            this.btnQebulTransfer.UseVisualStyleBackColor = false;
            // 
            // btnIptalTransfer
            // 
            this.btnIptalTransfer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnIptalTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIptalTransfer.ForeColor = System.Drawing.Color.White;
            this.btnIptalTransfer.Location = new System.Drawing.Point(340, 15);
            this.btnIptalTransfer.Name = "btnIptalTransfer";
            this.btnIptalTransfer.Size = new System.Drawing.Size(80, 35);
            this.btnIptalTransfer.TabIndex = 3;
            this.btnIptalTransfer.Text = "İptal";
            this.btnIptalTransfer.UseVisualStyleBackColor = false;
            // 
            // btnTransferDetali
            // 
            this.btnTransferDetali.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnTransferDetali.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransferDetali.ForeColor = System.Drawing.Color.White;
            this.btnTransferDetali.Location = new System.Drawing.Point(426, 15);
            this.btnTransferDetali.Name = "btnTransferDetali";
            this.btnTransferDetali.Size = new System.Drawing.Size(100, 35);
            this.btnTransferDetali.TabIndex = 4;
            this.btnTransferDetali.Text = "Detaylar";
            this.btnTransferDetali.UseVisualStyleBackColor = false;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 650);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1200, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(85, 17);
            this.toolStripStatusLabel.Text = "Tədarük Modulu";
            // 
            // TedarukManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 672);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip);
            this.Name = "TedarukManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tədarük və Anbar İdarəetməsi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl.ResumeLayout(false);
            this.tabTedarukciler.ResumeLayout(false);
            this.panelTedarukcu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTedarukciler)).EndInit();
            this.panelTedarukcuButtons.ResumeLayout(false);
            this.panelTedarukcuSearch.ResumeLayout(false);
            this.panelTedarukcuSearch.PerformLayout();
            this.tabAlisOrderleri.ResumeLayout(false);
            this.panelAlisOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlisOrderleri)).EndInit();
            this.panelOrderButtons.ResumeLayout(false);
            this.panelOrderFilter.ResumeLayout(false);
            this.panelOrderFilter.PerformLayout();
            this.tabAlisSenedleri.ResumeLayout(false);
            this.panelAlisSened.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlisSenedleri)).EndInit();
            this.panelSenedButtons.ResumeLayout(false);
            this.panelSenedFilter.ResumeLayout(false);
            this.panelSenedFilter.PerformLayout();
            this.tabAnbarTransfer.ResumeLayout(false);
            this.panelTransfer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferler)).EndInit();
            this.panelTransferButtons.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabTedarukciler;
        private System.Windows.Forms.TabPage tabAlisOrderleri;
        private System.Windows.Forms.TabPage tabAlisSenedleri;
        private System.Windows.Forms.TabPage tabAnbarTransfer;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        
        // Suppliers Tab
        private System.Windows.Forms.Panel panelTedarukcu;
        private System.Windows.Forms.DataGridView dgvTedarukciler;
        private System.Windows.Forms.Panel panelTedarukcuButtons;
        private System.Windows.Forms.Panel panelTedarukcuSearch;
        private System.Windows.Forms.Button btnYeniTedarukcu;
        private System.Windows.Forms.Button btnDuzenleTedarukcu;
        private System.Windows.Forms.Button btnSilTedarukcu;
        private System.Windows.Forms.Button btnOdemeYap;
        private System.Windows.Forms.TextBox txtTedarukcuAxtaris;
        private System.Windows.Forms.Label lblTedarukcuAxtaris;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTedarukcuKod;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTedarukcuAd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCariBorc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKreditLimiti;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        
        // Orders Tab
        private System.Windows.Forms.Panel panelAlisOrder;
        private System.Windows.Forms.DataGridView dgvAlisOrderleri;
        private System.Windows.Forms.Panel panelOrderButtons;
        private System.Windows.Forms.Panel panelOrderFilter;
        private System.Windows.Forms.Button btnYeniOrder;
        private System.Windows.Forms.Button btnDuzenleOrder;
        private System.Windows.Forms.Button btnTesdiqleOrder;
        private System.Windows.Forms.Button btnIptalOrder;
        private System.Windows.Forms.Button btnOrderDetali;
        private System.Windows.Forms.ComboBox cmbOrderStatus;
        private System.Windows.Forms.Label lblOrderStatus;
        private System.Windows.Forms.DateTimePicker dtpOrderStart;
        private System.Windows.Forms.DateTimePicker dtpOrderEnd;
        private System.Windows.Forms.Label lblOrderTarix;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderNomresi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderTarixi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTedarukcu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderMebleg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrderStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTeslimTarixi;
        
        // Documents Tab
        private System.Windows.Forms.Panel panelAlisSened;
        private System.Windows.Forms.DataGridView dgvAlisSenedleri;
        private System.Windows.Forms.Panel panelSenedButtons;
        private System.Windows.Forms.Panel panelSenedFilter;
        private System.Windows.Forms.Button btnYeniSened;
        private System.Windows.Forms.Button btnQebulEt;
        private System.Windows.Forms.Button btnIptalSened;
        private System.Windows.Forms.Button btnSenedDetali;
        private System.Windows.Forms.Button btnFaktura;
        private System.Windows.Forms.ComboBox cmbSenedStatus;
        private System.Windows.Forms.Label lblSenedStatus;
        private System.Windows.Forms.ComboBox cmbOdemeStatus;
        private System.Windows.Forms.Label lblOdemeStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSenedNomresi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSenedTarixi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSenedTedarukcu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSenedAnbar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSenedMebleg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSenedStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOdemeStatus;
        
        // Transfers Tab
        private System.Windows.Forms.Panel panelTransfer;
        private System.Windows.Forms.DataGridView dgvTransferler;
        private System.Windows.Forms.Panel panelTransferButtons;
        private System.Windows.Forms.Button btnYeniTransfer;
        private System.Windows.Forms.Button btnGonderTransfer;
        private System.Windows.Forms.Button btnQebulTransfer;
        private System.Windows.Forms.Button btnIptalTransfer;
        private System.Windows.Forms.Button btnTransferDetali;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransferNomresi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransferTarixi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMenbAnbar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHedefAnbar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMehsulSayi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTransferStatus;
    }
}