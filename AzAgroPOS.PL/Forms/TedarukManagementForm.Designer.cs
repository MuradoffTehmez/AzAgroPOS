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
            tabControl = new System.Windows.Forms.TabControl();
            tabTedarukciler = new System.Windows.Forms.TabPage();
            panelTedarukcu = new System.Windows.Forms.Panel();
            dgvTedarukciler = new System.Windows.Forms.DataGridView();
            colTedarukcuKod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colTedarukcuAd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colTelefon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colCariBorc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colKreditLimiti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            panelTedarukcuButtons = new System.Windows.Forms.Panel();
            btnOdemeYap = new System.Windows.Forms.Button();
            btnSilTedarukcu = new System.Windows.Forms.Button();
            btnDuzenleTedarukcu = new System.Windows.Forms.Button();
            btnYeniTedarukcu = new System.Windows.Forms.Button();
            panelTedarukcuSearch = new System.Windows.Forms.Panel();
            lblTedarukcuAxtaris = new System.Windows.Forms.Label();
            txtTedarukcuAxtaris = new System.Windows.Forms.TextBox();
            tabAlisOrderleri = new System.Windows.Forms.TabPage();
            panelAlisOrder = new System.Windows.Forms.Panel();
            dgvAlisOrderleri = new System.Windows.Forms.DataGridView();
            colOrderNomresi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colOrderTarixi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colTedarukcu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colOrderMebleg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colOrderStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colTeslimTarixi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            panelOrderButtons = new System.Windows.Forms.Panel();
            btnOrderDetali = new System.Windows.Forms.Button();
            btnIptalOrder = new System.Windows.Forms.Button();
            btnTesdiqleOrder = new System.Windows.Forms.Button();
            btnDuzenleOrder = new System.Windows.Forms.Button();
            btnYeniOrder = new System.Windows.Forms.Button();
            panelOrderFilter = new System.Windows.Forms.Panel();
            txtOrderAxtaris = new System.Windows.Forms.Button();
            lblOrderTarix = new System.Windows.Forms.Label();
            dtpOrderEnd = new System.Windows.Forms.DateTimePicker();
            dtpOrderStart = new System.Windows.Forms.DateTimePicker();
            lblOrderStatus = new System.Windows.Forms.Label();
            cmbOrderStatus = new System.Windows.Forms.ComboBox();
            tabAlisSenedleri = new System.Windows.Forms.TabPage();
            panelAlisSened = new System.Windows.Forms.Panel();
            dgvAlisSenedleri = new System.Windows.Forms.DataGridView();
            colSenedNomresi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colSenedTarixi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colSenedTedarukcu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colSenedAnbar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colSenedMebleg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colSenedStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colOdemeStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            panelSenedButtons = new System.Windows.Forms.Panel();
            btnFaktura = new System.Windows.Forms.Button();
            btnSenedDetali = new System.Windows.Forms.Button();
            btnIptalSened = new System.Windows.Forms.Button();
            btnQebulEt = new System.Windows.Forms.Button();
            btnYeniSened = new System.Windows.Forms.Button();
            panelSenedFilter = new System.Windows.Forms.Panel();
            txtSenedAxtaris = new System.Windows.Forms.Button();
            lblOdemeStatus = new System.Windows.Forms.Label();
            cmbOdemeStatus = new System.Windows.Forms.ComboBox();
            lblSenedStatus = new System.Windows.Forms.Label();
            cmbSenedStatus = new System.Windows.Forms.ComboBox();
            tabAnbarTransfer = new System.Windows.Forms.TabPage();
            panelTransfer = new System.Windows.Forms.Panel();
            dgvTransferler = new System.Windows.Forms.DataGridView();
            colTransferNomresi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colTransferTarixi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colMenbAnbar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colHedefAnbar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colMehsulSayi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            colTransferStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            panelTransferButtons = new System.Windows.Forms.Panel();
            txtTransferAxtaris = new System.Windows.Forms.Button();
            btnTransferDetali = new System.Windows.Forms.Button();
            btnIptalTransfer = new System.Windows.Forms.Button();
            btnQebulTransfer = new System.Windows.Forms.Button();
            btnGonderTransfer = new System.Windows.Forms.Button();
            btnYeniTransfer = new System.Windows.Forms.Button();
            statusStrip = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            tabControl.SuspendLayout();
            tabTedarukciler.SuspendLayout();
            panelTedarukcu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTedarukciler).BeginInit();
            panelTedarukcuButtons.SuspendLayout();
            panelTedarukcuSearch.SuspendLayout();
            tabAlisOrderleri.SuspendLayout();
            panelAlisOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAlisOrderleri).BeginInit();
            panelOrderButtons.SuspendLayout();
            panelOrderFilter.SuspendLayout();
            tabAlisSenedleri.SuspendLayout();
            panelAlisSened.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAlisSenedleri).BeginInit();
            panelSenedButtons.SuspendLayout();
            panelSenedFilter.SuspendLayout();
            tabAnbarTransfer.SuspendLayout();
            panelTransfer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransferler).BeginInit();
            panelTransferButtons.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabTedarukciler);
            tabControl.Controls.Add(tabAlisOrderleri);
            tabControl.Controls.Add(tabAlisSenedleri);
            tabControl.Controls.Add(tabAnbarTransfer);
            tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            tabControl.Location = new System.Drawing.Point(0, 0);
            tabControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new System.Drawing.Size(1400, 753);
            tabControl.TabIndex = 0;
            // 
            // tabTedarukciler
            // 
            tabTedarukciler.Controls.Add(panelTedarukcu);
            tabTedarukciler.Location = new System.Drawing.Point(4, 26);
            tabTedarukciler.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabTedarukciler.Name = "tabTedarukciler";
            tabTedarukciler.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabTedarukciler.Size = new System.Drawing.Size(1392, 723);
            tabTedarukciler.TabIndex = 0;
            tabTedarukciler.Text = "Tədarükçülər";
            tabTedarukciler.UseVisualStyleBackColor = true;
            // 
            // panelTedarukcu
            // 
            panelTedarukcu.Controls.Add(dgvTedarukciler);
            panelTedarukcu.Controls.Add(panelTedarukcuButtons);
            panelTedarukcu.Controls.Add(panelTedarukcuSearch);
            panelTedarukcu.Dock = System.Windows.Forms.DockStyle.Fill;
            panelTedarukcu.Location = new System.Drawing.Point(4, 3);
            panelTedarukcu.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelTedarukcu.Name = "panelTedarukcu";
            panelTedarukcu.Size = new System.Drawing.Size(1384, 717);
            panelTedarukcu.TabIndex = 0;
            // 
            // dgvTedarukciler
            // 
            dgvTedarukciler.AllowUserToAddRows = false;
            dgvTedarukciler.AllowUserToDeleteRows = false;
            dgvTedarukciler.BackgroundColor = System.Drawing.Color.White;
            dgvTedarukciler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTedarukciler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colTedarukcuKod, colTedarukcuAd, colTelefon, colEmail, colCariBorc, colKreditLimiti, colStatus });
            dgvTedarukciler.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvTedarukciler.Location = new System.Drawing.Point(0, 69);
            dgvTedarukciler.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dgvTedarukciler.MultiSelect = false;
            dgvTedarukciler.Name = "dgvTedarukciler";
            dgvTedarukciler.ReadOnly = true;
            dgvTedarukciler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvTedarukciler.Size = new System.Drawing.Size(1384, 579);
            dgvTedarukciler.TabIndex = 0;
            // 
            // colTedarukcuKod
            // 
            colTedarukcuKod.HeaderText = "Kod";
            colTedarukcuKod.Name = "colTedarukcuKod";
            colTedarukcuKod.ReadOnly = true;
            colTedarukcuKod.Width = 80;
            // 
            // colTedarukcuAd
            // 
            colTedarukcuAd.HeaderText = "Tədarükçü Adı";
            colTedarukcuAd.Name = "colTedarukcuAd";
            colTedarukcuAd.ReadOnly = true;
            colTedarukcuAd.Width = 250;
            // 
            // colTelefon
            // 
            colTelefon.HeaderText = "Telefon";
            colTelefon.Name = "colTelefon";
            colTelefon.ReadOnly = true;
            colTelefon.Width = 120;
            // 
            // colEmail
            // 
            colEmail.HeaderText = "Email";
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            colEmail.Width = 200;
            // 
            // colCariBorc
            // 
            colCariBorc.HeaderText = "Cari Borc";
            colCariBorc.Name = "colCariBorc";
            colCariBorc.ReadOnly = true;
            colCariBorc.Width = 120;
            // 
            // colKreditLimiti
            // 
            colKreditLimiti.HeaderText = "Kredit Limiti";
            colKreditLimiti.Name = "colKreditLimiti";
            colKreditLimiti.ReadOnly = true;
            colKreditLimiti.Width = 120;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // panelTedarukcuButtons
            // 
            panelTedarukcuButtons.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            panelTedarukcuButtons.Controls.Add(btnOdemeYap);
            panelTedarukcuButtons.Controls.Add(btnSilTedarukcu);
            panelTedarukcuButtons.Controls.Add(btnDuzenleTedarukcu);
            panelTedarukcuButtons.Controls.Add(btnYeniTedarukcu);
            panelTedarukcuButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelTedarukcuButtons.Location = new System.Drawing.Point(0, 648);
            panelTedarukcuButtons.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelTedarukcuButtons.Name = "panelTedarukcuButtons";
            panelTedarukcuButtons.Size = new System.Drawing.Size(1384, 69);
            panelTedarukcuButtons.TabIndex = 1;
            // 
            // btnOdemeYap
            // 
            btnOdemeYap.BackColor = System.Drawing.Color.FromArgb(155, 89, 182);
            btnOdemeYap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnOdemeYap.ForeColor = System.Drawing.Color.White;
            btnOdemeYap.Location = new System.Drawing.Point(385, 17);
            btnOdemeYap.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnOdemeYap.Name = "btnOdemeYap";
            btnOdemeYap.Size = new System.Drawing.Size(117, 40);
            btnOdemeYap.TabIndex = 3;
            btnOdemeYap.Text = "Ödəmə Yap";
            btnOdemeYap.UseVisualStyleBackColor = false;
            // 
            // btnSilTedarukcu
            // 
            btnSilTedarukcu.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            btnSilTedarukcu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSilTedarukcu.ForeColor = System.Drawing.Color.White;
            btnSilTedarukcu.Location = new System.Drawing.Point(285, 17);
            btnSilTedarukcu.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSilTedarukcu.Name = "btnSilTedarukcu";
            btnSilTedarukcu.Size = new System.Drawing.Size(93, 40);
            btnSilTedarukcu.TabIndex = 2;
            btnSilTedarukcu.Text = "Sil";
            btnSilTedarukcu.UseVisualStyleBackColor = false;
            // 
            // btnDuzenleTedarukcu
            // 
            btnDuzenleTedarukcu.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            btnDuzenleTedarukcu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDuzenleTedarukcu.ForeColor = System.Drawing.Color.White;
            btnDuzenleTedarukcu.Location = new System.Drawing.Point(161, 17);
            btnDuzenleTedarukcu.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnDuzenleTedarukcu.Name = "btnDuzenleTedarukcu";
            btnDuzenleTedarukcu.Size = new System.Drawing.Size(117, 40);
            btnDuzenleTedarukcu.TabIndex = 1;
            btnDuzenleTedarukcu.Text = "Düzənlə";
            btnDuzenleTedarukcu.UseVisualStyleBackColor = false;
            // 
            // btnYeniTedarukcu
            // 
            btnYeniTedarukcu.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            btnYeniTedarukcu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnYeniTedarukcu.ForeColor = System.Drawing.Color.White;
            btnYeniTedarukcu.Location = new System.Drawing.Point(14, 17);
            btnYeniTedarukcu.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnYeniTedarukcu.Name = "btnYeniTedarukcu";
            btnYeniTedarukcu.Size = new System.Drawing.Size(140, 40);
            btnYeniTedarukcu.TabIndex = 0;
            btnYeniTedarukcu.Text = "Yeni Tədarükçü";
            btnYeniTedarukcu.UseVisualStyleBackColor = false;
            // 
            // panelTedarukcuSearch
            // 
            panelTedarukcuSearch.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            panelTedarukcuSearch.Controls.Add(lblTedarukcuAxtaris);
            panelTedarukcuSearch.Controls.Add(txtTedarukcuAxtaris);
            panelTedarukcuSearch.Dock = System.Windows.Forms.DockStyle.Top;
            panelTedarukcuSearch.Location = new System.Drawing.Point(0, 0);
            panelTedarukcuSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelTedarukcuSearch.Name = "panelTedarukcuSearch";
            panelTedarukcuSearch.Size = new System.Drawing.Size(1384, 69);
            panelTedarukcuSearch.TabIndex = 2;
            // 
            // lblTedarukcuAxtaris
            // 
            lblTedarukcuAxtaris.AutoSize = true;
            lblTedarukcuAxtaris.Location = new System.Drawing.Point(14, 28);
            lblTedarukcuAxtaris.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTedarukcuAxtaris.Name = "lblTedarukcuAxtaris";
            lblTedarukcuAxtaris.Size = new System.Drawing.Size(53, 19);
            lblTedarukcuAxtaris.TabIndex = 1;
            lblTedarukcuAxtaris.Text = "Axtarış:";
            // 
            // txtTedarukcuAxtaris
            // 
            txtTedarukcuAxtaris.Font = new System.Drawing.Font("Segoe UI", 11F);
            txtTedarukcuAxtaris.Location = new System.Drawing.Point(117, 23);
            txtTedarukcuAxtaris.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtTedarukcuAxtaris.Name = "txtTedarukcuAxtaris";
            txtTedarukcuAxtaris.Size = new System.Drawing.Size(349, 27);
            txtTedarukcuAxtaris.TabIndex = 0;
            // 
            // tabAlisOrderleri
            // 
            tabAlisOrderleri.Controls.Add(panelAlisOrder);
            tabAlisOrderleri.Location = new System.Drawing.Point(4, 26);
            tabAlisOrderleri.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabAlisOrderleri.Name = "tabAlisOrderleri";
            tabAlisOrderleri.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabAlisOrderleri.Size = new System.Drawing.Size(1392, 723);
            tabAlisOrderleri.TabIndex = 1;
            tabAlisOrderleri.Text = "Alış Sifarişləri";
            tabAlisOrderleri.UseVisualStyleBackColor = true;
            // 
            // panelAlisOrder
            // 
            panelAlisOrder.Controls.Add(dgvAlisOrderleri);
            panelAlisOrder.Controls.Add(panelOrderButtons);
            panelAlisOrder.Controls.Add(panelOrderFilter);
            panelAlisOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            panelAlisOrder.Location = new System.Drawing.Point(4, 3);
            panelAlisOrder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelAlisOrder.Name = "panelAlisOrder";
            panelAlisOrder.Size = new System.Drawing.Size(1384, 717);
            panelAlisOrder.TabIndex = 0;
            // 
            // dgvAlisOrderleri
            // 
            dgvAlisOrderleri.AllowUserToAddRows = false;
            dgvAlisOrderleri.AllowUserToDeleteRows = false;
            dgvAlisOrderleri.BackgroundColor = System.Drawing.Color.White;
            dgvAlisOrderleri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAlisOrderleri.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colOrderNomresi, colOrderTarixi, colTedarukcu, colOrderMebleg, colOrderStatus, colTeslimTarixi });
            dgvAlisOrderleri.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvAlisOrderleri.Location = new System.Drawing.Point(0, 69);
            dgvAlisOrderleri.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dgvAlisOrderleri.Name = "dgvAlisOrderleri";
            dgvAlisOrderleri.ReadOnly = true;
            dgvAlisOrderleri.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvAlisOrderleri.Size = new System.Drawing.Size(1384, 579);
            dgvAlisOrderleri.TabIndex = 0;
            // 
            // colOrderNomresi
            // 
            colOrderNomresi.HeaderText = "Order Nömrəsi";
            colOrderNomresi.Name = "colOrderNomresi";
            colOrderNomresi.ReadOnly = true;
            colOrderNomresi.Width = 120;
            // 
            // colOrderTarixi
            // 
            colOrderTarixi.HeaderText = "Tarix";
            colOrderTarixi.Name = "colOrderTarixi";
            colOrderTarixi.ReadOnly = true;
            // 
            // colTedarukcu
            // 
            colTedarukcu.HeaderText = "Tədarükçü";
            colTedarukcu.Name = "colTedarukcu";
            colTedarukcu.ReadOnly = true;
            colTedarukcu.Width = 200;
            // 
            // colOrderMebleg
            // 
            colOrderMebleg.HeaderText = "Məbləğ";
            colOrderMebleg.Name = "colOrderMebleg";
            colOrderMebleg.ReadOnly = true;
            colOrderMebleg.Width = 120;
            // 
            // colOrderStatus
            // 
            colOrderStatus.HeaderText = "Status";
            colOrderStatus.Name = "colOrderStatus";
            colOrderStatus.ReadOnly = true;
            colOrderStatus.Width = 120;
            // 
            // colTeslimTarixi
            // 
            colTeslimTarixi.HeaderText = "Təslim Tarixi";
            colTeslimTarixi.Name = "colTeslimTarixi";
            colTeslimTarixi.ReadOnly = true;
            colTeslimTarixi.Width = 120;
            // 
            // panelOrderButtons
            // 
            panelOrderButtons.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            panelOrderButtons.Controls.Add(btnOrderDetali);
            panelOrderButtons.Controls.Add(btnIptalOrder);
            panelOrderButtons.Controls.Add(btnTesdiqleOrder);
            panelOrderButtons.Controls.Add(btnDuzenleOrder);
            panelOrderButtons.Controls.Add(btnYeniOrder);
            panelOrderButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelOrderButtons.Location = new System.Drawing.Point(0, 648);
            panelOrderButtons.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelOrderButtons.Name = "panelOrderButtons";
            panelOrderButtons.Size = new System.Drawing.Size(1384, 69);
            panelOrderButtons.TabIndex = 1;
            // 
            // btnOrderDetali
            // 
            btnOrderDetali.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
            btnOrderDetali.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnOrderDetali.ForeColor = System.Drawing.Color.White;
            btnOrderDetali.Location = new System.Drawing.Point(485, 17);
            btnOrderDetali.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnOrderDetali.Name = "btnOrderDetali";
            btnOrderDetali.Size = new System.Drawing.Size(117, 40);
            btnOrderDetali.TabIndex = 4;
            btnOrderDetali.Text = "Detaylar";
            btnOrderDetali.UseVisualStyleBackColor = false;
            // 
            // btnIptalOrder
            // 
            btnIptalOrder.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            btnIptalOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnIptalOrder.ForeColor = System.Drawing.Color.White;
            btnIptalOrder.Location = new System.Drawing.Point(385, 17);
            btnIptalOrder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnIptalOrder.Name = "btnIptalOrder";
            btnIptalOrder.Size = new System.Drawing.Size(93, 40);
            btnIptalOrder.TabIndex = 3;
            btnIptalOrder.Text = "İptal";
            btnIptalOrder.UseVisualStyleBackColor = false;
            // 
            // btnTesdiqleOrder
            // 
            btnTesdiqleOrder.BackColor = System.Drawing.Color.FromArgb(155, 89, 182);
            btnTesdiqleOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnTesdiqleOrder.ForeColor = System.Drawing.Color.White;
            btnTesdiqleOrder.Location = new System.Drawing.Point(261, 17);
            btnTesdiqleOrder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnTesdiqleOrder.Name = "btnTesdiqleOrder";
            btnTesdiqleOrder.Size = new System.Drawing.Size(117, 40);
            btnTesdiqleOrder.TabIndex = 2;
            btnTesdiqleOrder.Text = "Təsdiqlə";
            btnTesdiqleOrder.UseVisualStyleBackColor = false;
            // 
            // btnDuzenleOrder
            // 
            btnDuzenleOrder.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            btnDuzenleOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDuzenleOrder.ForeColor = System.Drawing.Color.White;
            btnDuzenleOrder.Location = new System.Drawing.Point(138, 17);
            btnDuzenleOrder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnDuzenleOrder.Name = "btnDuzenleOrder";
            btnDuzenleOrder.Size = new System.Drawing.Size(117, 40);
            btnDuzenleOrder.TabIndex = 1;
            btnDuzenleOrder.Text = "Düzənlə";
            btnDuzenleOrder.UseVisualStyleBackColor = false;
            // 
            // btnYeniOrder
            // 
            btnYeniOrder.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            btnYeniOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnYeniOrder.ForeColor = System.Drawing.Color.White;
            btnYeniOrder.Location = new System.Drawing.Point(14, 17);
            btnYeniOrder.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnYeniOrder.Name = "btnYeniOrder";
            btnYeniOrder.Size = new System.Drawing.Size(117, 40);
            btnYeniOrder.TabIndex = 0;
            btnYeniOrder.Text = "Yeni Order";
            btnYeniOrder.UseVisualStyleBackColor = false;
            // 
            // panelOrderFilter
            // 
            panelOrderFilter.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            panelOrderFilter.Controls.Add(txtOrderAxtaris);
            panelOrderFilter.Controls.Add(lblOrderTarix);
            panelOrderFilter.Controls.Add(dtpOrderEnd);
            panelOrderFilter.Controls.Add(dtpOrderStart);
            panelOrderFilter.Controls.Add(lblOrderStatus);
            panelOrderFilter.Controls.Add(cmbOrderStatus);
            panelOrderFilter.Dock = System.Windows.Forms.DockStyle.Top;
            panelOrderFilter.Location = new System.Drawing.Point(0, 0);
            panelOrderFilter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelOrderFilter.Name = "panelOrderFilter";
            panelOrderFilter.Size = new System.Drawing.Size(1384, 69);
            panelOrderFilter.TabIndex = 2;
            // 
            // txtOrderAxtaris
            // 
            txtOrderAxtaris.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            txtOrderAxtaris.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            txtOrderAxtaris.ForeColor = System.Drawing.Color.White;
            txtOrderAxtaris.Location = new System.Drawing.Point(676, 23);
            txtOrderAxtaris.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtOrderAxtaris.Name = "txtOrderAxtaris";
            txtOrderAxtaris.Size = new System.Drawing.Size(110, 29);
            txtOrderAxtaris.TabIndex = 5;
            txtOrderAxtaris.Text = "Axtar";
            txtOrderAxtaris.UseVisualStyleBackColor = false;
            // 
            // lblOrderTarix
            // 
            lblOrderTarix.AutoSize = true;
            lblOrderTarix.Location = new System.Drawing.Point(280, 28);
            lblOrderTarix.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblOrderTarix.Name = "lblOrderTarix";
            lblOrderTarix.Size = new System.Drawing.Size(38, 19);
            lblOrderTarix.TabIndex = 4;
            lblOrderTarix.Text = "Tarix:";
            // 
            // dtpOrderEnd
            // 
            dtpOrderEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpOrderEnd.Location = new System.Drawing.Point(490, 23);
            dtpOrderEnd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dtpOrderEnd.Name = "dtpOrderEnd";
            dtpOrderEnd.Size = new System.Drawing.Size(139, 25);
            dtpOrderEnd.TabIndex = 3;
            // 
            // dtpOrderStart
            // 
            dtpOrderStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpOrderStart.Location = new System.Drawing.Point(338, 23);
            dtpOrderStart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dtpOrderStart.Name = "dtpOrderStart";
            dtpOrderStart.Size = new System.Drawing.Size(139, 25);
            dtpOrderStart.TabIndex = 2;
            // 
            // lblOrderStatus
            // 
            lblOrderStatus.AutoSize = true;
            lblOrderStatus.Location = new System.Drawing.Point(14, 28);
            lblOrderStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblOrderStatus.Name = "lblOrderStatus";
            lblOrderStatus.Size = new System.Drawing.Size(50, 19);
            lblOrderStatus.TabIndex = 1;
            lblOrderStatus.Text = "Status:";
            // 
            // cmbOrderStatus
            // 
            cmbOrderStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbOrderStatus.FormattingEnabled = true;
            cmbOrderStatus.Location = new System.Drawing.Point(82, 23);
            cmbOrderStatus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cmbOrderStatus.Name = "cmbOrderStatus";
            cmbOrderStatus.Size = new System.Drawing.Size(174, 25);
            cmbOrderStatus.TabIndex = 0;
            // 
            // tabAlisSenedleri
            // 
            tabAlisSenedleri.Controls.Add(panelAlisSened);
            tabAlisSenedleri.Location = new System.Drawing.Point(4, 26);
            tabAlisSenedleri.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabAlisSenedleri.Name = "tabAlisSenedleri";
            tabAlisSenedleri.Size = new System.Drawing.Size(1392, 723);
            tabAlisSenedleri.TabIndex = 2;
            tabAlisSenedleri.Text = "Alış Sənədləri";
            tabAlisSenedleri.UseVisualStyleBackColor = true;
            // 
            // panelAlisSened
            // 
            panelAlisSened.Controls.Add(dgvAlisSenedleri);
            panelAlisSened.Controls.Add(panelSenedButtons);
            panelAlisSened.Controls.Add(panelSenedFilter);
            panelAlisSened.Dock = System.Windows.Forms.DockStyle.Fill;
            panelAlisSened.Location = new System.Drawing.Point(0, 0);
            panelAlisSened.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelAlisSened.Name = "panelAlisSened";
            panelAlisSened.Size = new System.Drawing.Size(1392, 723);
            panelAlisSened.TabIndex = 0;
            // 
            // dgvAlisSenedleri
            // 
            dgvAlisSenedleri.AllowUserToAddRows = false;
            dgvAlisSenedleri.AllowUserToDeleteRows = false;
            dgvAlisSenedleri.BackgroundColor = System.Drawing.Color.White;
            dgvAlisSenedleri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAlisSenedleri.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colSenedNomresi, colSenedTarixi, colSenedTedarukcu, colSenedAnbar, colSenedMebleg, colSenedStatus, colOdemeStatus });
            dgvAlisSenedleri.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvAlisSenedleri.Location = new System.Drawing.Point(0, 69);
            dgvAlisSenedleri.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dgvAlisSenedleri.Name = "dgvAlisSenedleri";
            dgvAlisSenedleri.ReadOnly = true;
            dgvAlisSenedleri.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvAlisSenedleri.Size = new System.Drawing.Size(1392, 585);
            dgvAlisSenedleri.TabIndex = 0;
            // 
            // colSenedNomresi
            // 
            colSenedNomresi.HeaderText = "Sənəd Nömrəsi";
            colSenedNomresi.Name = "colSenedNomresi";
            colSenedNomresi.ReadOnly = true;
            colSenedNomresi.Width = 120;
            // 
            // colSenedTarixi
            // 
            colSenedTarixi.HeaderText = "Tarix";
            colSenedTarixi.Name = "colSenedTarixi";
            colSenedTarixi.ReadOnly = true;
            // 
            // colSenedTedarukcu
            // 
            colSenedTedarukcu.HeaderText = "Tədarükçü";
            colSenedTedarukcu.Name = "colSenedTedarukcu";
            colSenedTedarukcu.ReadOnly = true;
            colSenedTedarukcu.Width = 200;
            // 
            // colSenedAnbar
            // 
            colSenedAnbar.HeaderText = "Anbar";
            colSenedAnbar.Name = "colSenedAnbar";
            colSenedAnbar.ReadOnly = true;
            colSenedAnbar.Width = 150;
            // 
            // colSenedMebleg
            // 
            colSenedMebleg.HeaderText = "Məbləğ";
            colSenedMebleg.Name = "colSenedMebleg";
            colSenedMebleg.ReadOnly = true;
            colSenedMebleg.Width = 120;
            // 
            // colSenedStatus
            // 
            colSenedStatus.HeaderText = "Status";
            colSenedStatus.Name = "colSenedStatus";
            colSenedStatus.ReadOnly = true;
            colSenedStatus.Width = 120;
            // 
            // colOdemeStatus
            // 
            colOdemeStatus.HeaderText = "Ödəmə Status";
            colOdemeStatus.Name = "colOdemeStatus";
            colOdemeStatus.ReadOnly = true;
            colOdemeStatus.Width = 120;
            // 
            // panelSenedButtons
            // 
            panelSenedButtons.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            panelSenedButtons.Controls.Add(btnFaktura);
            panelSenedButtons.Controls.Add(btnSenedDetali);
            panelSenedButtons.Controls.Add(btnIptalSened);
            panelSenedButtons.Controls.Add(btnQebulEt);
            panelSenedButtons.Controls.Add(btnYeniSened);
            panelSenedButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelSenedButtons.Location = new System.Drawing.Point(0, 654);
            panelSenedButtons.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelSenedButtons.Name = "panelSenedButtons";
            panelSenedButtons.Size = new System.Drawing.Size(1392, 69);
            panelSenedButtons.TabIndex = 1;
            // 
            // btnFaktura
            // 
            btnFaktura.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            btnFaktura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnFaktura.ForeColor = System.Drawing.Color.White;
            btnFaktura.Location = new System.Drawing.Point(485, 17);
            btnFaktura.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnFaktura.Name = "btnFaktura";
            btnFaktura.Size = new System.Drawing.Size(117, 40);
            btnFaktura.TabIndex = 4;
            btnFaktura.Text = "Faktura Çap";
            btnFaktura.UseVisualStyleBackColor = false;
            // 
            // btnSenedDetali
            // 
            btnSenedDetali.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
            btnSenedDetali.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSenedDetali.ForeColor = System.Drawing.Color.White;
            btnSenedDetali.Location = new System.Drawing.Point(362, 17);
            btnSenedDetali.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnSenedDetali.Name = "btnSenedDetali";
            btnSenedDetali.Size = new System.Drawing.Size(117, 40);
            btnSenedDetali.TabIndex = 3;
            btnSenedDetali.Text = "Detaylar";
            btnSenedDetali.UseVisualStyleBackColor = false;
            // 
            // btnIptalSened
            // 
            btnIptalSened.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            btnIptalSened.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnIptalSened.ForeColor = System.Drawing.Color.White;
            btnIptalSened.Location = new System.Drawing.Point(261, 17);
            btnIptalSened.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnIptalSened.Name = "btnIptalSened";
            btnIptalSened.Size = new System.Drawing.Size(93, 40);
            btnIptalSened.TabIndex = 2;
            btnIptalSened.Text = "İptal";
            btnIptalSened.UseVisualStyleBackColor = false;
            // 
            // btnQebulEt
            // 
            btnQebulEt.BackColor = System.Drawing.Color.FromArgb(155, 89, 182);
            btnQebulEt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnQebulEt.ForeColor = System.Drawing.Color.White;
            btnQebulEt.Location = new System.Drawing.Point(138, 17);
            btnQebulEt.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnQebulEt.Name = "btnQebulEt";
            btnQebulEt.Size = new System.Drawing.Size(117, 40);
            btnQebulEt.TabIndex = 1;
            btnQebulEt.Text = "Qəbul Et";
            btnQebulEt.UseVisualStyleBackColor = false;
            // 
            // btnYeniSened
            // 
            btnYeniSened.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            btnYeniSened.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnYeniSened.ForeColor = System.Drawing.Color.White;
            btnYeniSened.Location = new System.Drawing.Point(14, 17);
            btnYeniSened.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnYeniSened.Name = "btnYeniSened";
            btnYeniSened.Size = new System.Drawing.Size(117, 40);
            btnYeniSened.TabIndex = 0;
            btnYeniSened.Text = "Yeni Sənəd";
            btnYeniSened.UseVisualStyleBackColor = false;
            // 
            // panelSenedFilter
            // 
            panelSenedFilter.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            panelSenedFilter.Controls.Add(txtSenedAxtaris);
            panelSenedFilter.Controls.Add(lblOdemeStatus);
            panelSenedFilter.Controls.Add(cmbOdemeStatus);
            panelSenedFilter.Controls.Add(lblSenedStatus);
            panelSenedFilter.Controls.Add(cmbSenedStatus);
            panelSenedFilter.Dock = System.Windows.Forms.DockStyle.Top;
            panelSenedFilter.Location = new System.Drawing.Point(0, 0);
            panelSenedFilter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelSenedFilter.Name = "panelSenedFilter";
            panelSenedFilter.Size = new System.Drawing.Size(1392, 69);
            panelSenedFilter.TabIndex = 2;
            // 
            // txtSenedAxtaris
            // 
            txtSenedAxtaris.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            txtSenedAxtaris.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            txtSenedAxtaris.ForeColor = System.Drawing.Color.White;
            txtSenedAxtaris.Location = new System.Drawing.Point(588, 21);
            txtSenedAxtaris.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtSenedAxtaris.Name = "txtSenedAxtaris";
            txtSenedAxtaris.Size = new System.Drawing.Size(110, 29);
            txtSenedAxtaris.TabIndex = 6;
            txtSenedAxtaris.Text = "Axtar";
            txtSenedAxtaris.UseVisualStyleBackColor = false;
            // 
            // lblOdemeStatus
            // 
            lblOdemeStatus.AutoSize = true;
            lblOdemeStatus.Location = new System.Drawing.Point(280, 28);
            lblOdemeStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblOdemeStatus.Name = "lblOdemeStatus";
            lblOdemeStatus.Size = new System.Drawing.Size(76, 19);
            lblOdemeStatus.TabIndex = 3;
            lblOdemeStatus.Text = "Ödəmə St.:";
            // 
            // cmbOdemeStatus
            // 
            cmbOdemeStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbOdemeStatus.FormattingEnabled = true;
            cmbOdemeStatus.Location = new System.Drawing.Point(373, 23);
            cmbOdemeStatus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cmbOdemeStatus.Name = "cmbOdemeStatus";
            cmbOdemeStatus.Size = new System.Drawing.Size(174, 25);
            cmbOdemeStatus.TabIndex = 2;
            // 
            // lblSenedStatus
            // 
            lblSenedStatus.AutoSize = true;
            lblSenedStatus.Location = new System.Drawing.Point(14, 28);
            lblSenedStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSenedStatus.Name = "lblSenedStatus";
            lblSenedStatus.Size = new System.Drawing.Size(50, 19);
            lblSenedStatus.TabIndex = 1;
            lblSenedStatus.Text = "Status:";
            // 
            // cmbSenedStatus
            // 
            cmbSenedStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbSenedStatus.FormattingEnabled = true;
            cmbSenedStatus.Location = new System.Drawing.Point(82, 23);
            cmbSenedStatus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cmbSenedStatus.Name = "cmbSenedStatus";
            cmbSenedStatus.Size = new System.Drawing.Size(174, 25);
            cmbSenedStatus.TabIndex = 0;
            // 
            // tabAnbarTransfer
            // 
            tabAnbarTransfer.Controls.Add(panelTransfer);
            tabAnbarTransfer.Location = new System.Drawing.Point(4, 26);
            tabAnbarTransfer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabAnbarTransfer.Name = "tabAnbarTransfer";
            tabAnbarTransfer.Size = new System.Drawing.Size(1392, 723);
            tabAnbarTransfer.TabIndex = 3;
            tabAnbarTransfer.Text = "Anbar Transferləri";
            tabAnbarTransfer.UseVisualStyleBackColor = true;
            // 
            // panelTransfer
            // 
            panelTransfer.Controls.Add(dgvTransferler);
            panelTransfer.Controls.Add(panelTransferButtons);
            panelTransfer.Dock = System.Windows.Forms.DockStyle.Fill;
            panelTransfer.Location = new System.Drawing.Point(0, 0);
            panelTransfer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelTransfer.Name = "panelTransfer";
            panelTransfer.Size = new System.Drawing.Size(1392, 723);
            panelTransfer.TabIndex = 0;
            // 
            // dgvTransferler
            // 
            dgvTransferler.AllowUserToAddRows = false;
            dgvTransferler.AllowUserToDeleteRows = false;
            dgvTransferler.BackgroundColor = System.Drawing.Color.White;
            dgvTransferler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransferler.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colTransferNomresi, colTransferTarixi, colMenbAnbar, colHedefAnbar, colMehsulSayi, colTransferStatus });
            dgvTransferler.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvTransferler.Location = new System.Drawing.Point(0, 0);
            dgvTransferler.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            dgvTransferler.Name = "dgvTransferler";
            dgvTransferler.ReadOnly = true;
            dgvTransferler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvTransferler.Size = new System.Drawing.Size(1392, 654);
            dgvTransferler.TabIndex = 0;
            // 
            // colTransferNomresi
            // 
            colTransferNomresi.HeaderText = "Transfer Nömrəsi";
            colTransferNomresi.Name = "colTransferNomresi";
            colTransferNomresi.ReadOnly = true;
            colTransferNomresi.Width = 140;
            // 
            // colTransferTarixi
            // 
            colTransferTarixi.HeaderText = "Tarix";
            colTransferTarixi.Name = "colTransferTarixi";
            colTransferTarixi.ReadOnly = true;
            // 
            // colMenbAnbar
            // 
            colMenbAnbar.HeaderText = "Mənbə Anbar";
            colMenbAnbar.Name = "colMenbAnbar";
            colMenbAnbar.ReadOnly = true;
            colMenbAnbar.Width = 150;
            // 
            // colHedefAnbar
            // 
            colHedefAnbar.HeaderText = "Hədəf Anbar";
            colHedefAnbar.Name = "colHedefAnbar";
            colHedefAnbar.ReadOnly = true;
            colHedefAnbar.Width = 150;
            // 
            // colMehsulSayi
            // 
            colMehsulSayi.HeaderText = "Məhsul Sayı";
            colMehsulSayi.Name = "colMehsulSayi";
            colMehsulSayi.ReadOnly = true;
            // 
            // colTransferStatus
            // 
            colTransferStatus.HeaderText = "Status";
            colTransferStatus.Name = "colTransferStatus";
            colTransferStatus.ReadOnly = true;
            colTransferStatus.Width = 120;
            // 
            // panelTransferButtons
            // 
            panelTransferButtons.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            panelTransferButtons.Controls.Add(txtTransferAxtaris);
            panelTransferButtons.Controls.Add(btnTransferDetali);
            panelTransferButtons.Controls.Add(btnIptalTransfer);
            panelTransferButtons.Controls.Add(btnQebulTransfer);
            panelTransferButtons.Controls.Add(btnGonderTransfer);
            panelTransferButtons.Controls.Add(btnYeniTransfer);
            panelTransferButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelTransferButtons.Location = new System.Drawing.Point(0, 654);
            panelTransferButtons.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelTransferButtons.Name = "panelTransferButtons";
            panelTransferButtons.Size = new System.Drawing.Size(1392, 69);
            panelTransferButtons.TabIndex = 1;
            // 
            // txtTransferAxtaris
            // 
            txtTransferAxtaris.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            txtTransferAxtaris.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            txtTransferAxtaris.ForeColor = System.Drawing.Color.White;
            txtTransferAxtaris.Location = new System.Drawing.Point(637, 17);
            txtTransferAxtaris.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            txtTransferAxtaris.Name = "txtTransferAxtaris";
            txtTransferAxtaris.Size = new System.Drawing.Size(113, 40);
            txtTransferAxtaris.TabIndex = 7;
            txtTransferAxtaris.Text = "Axtar";
            txtTransferAxtaris.UseVisualStyleBackColor = false;
            // 
            // btnTransferDetali
            // 
            btnTransferDetali.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
            btnTransferDetali.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnTransferDetali.ForeColor = System.Drawing.Color.White;
            btnTransferDetali.Location = new System.Drawing.Point(497, 17);
            btnTransferDetali.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnTransferDetali.Name = "btnTransferDetali";
            btnTransferDetali.Size = new System.Drawing.Size(117, 40);
            btnTransferDetali.TabIndex = 4;
            btnTransferDetali.Text = "Detaylar";
            btnTransferDetali.UseVisualStyleBackColor = false;
            // 
            // btnIptalTransfer
            // 
            btnIptalTransfer.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            btnIptalTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnIptalTransfer.ForeColor = System.Drawing.Color.White;
            btnIptalTransfer.Location = new System.Drawing.Point(397, 17);
            btnIptalTransfer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnIptalTransfer.Name = "btnIptalTransfer";
            btnIptalTransfer.Size = new System.Drawing.Size(93, 40);
            btnIptalTransfer.TabIndex = 3;
            btnIptalTransfer.Text = "İptal";
            btnIptalTransfer.UseVisualStyleBackColor = false;
            // 
            // btnQebulTransfer
            // 
            btnQebulTransfer.BackColor = System.Drawing.Color.FromArgb(155, 89, 182);
            btnQebulTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnQebulTransfer.ForeColor = System.Drawing.Color.White;
            btnQebulTransfer.Location = new System.Drawing.Point(273, 17);
            btnQebulTransfer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnQebulTransfer.Name = "btnQebulTransfer";
            btnQebulTransfer.Size = new System.Drawing.Size(117, 40);
            btnQebulTransfer.TabIndex = 2;
            btnQebulTransfer.Text = "Qəbul Et";
            btnQebulTransfer.UseVisualStyleBackColor = false;
            // 
            // btnGonderTransfer
            // 
            btnGonderTransfer.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            btnGonderTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnGonderTransfer.ForeColor = System.Drawing.Color.White;
            btnGonderTransfer.Location = new System.Drawing.Point(149, 17);
            btnGonderTransfer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnGonderTransfer.Name = "btnGonderTransfer";
            btnGonderTransfer.Size = new System.Drawing.Size(117, 40);
            btnGonderTransfer.TabIndex = 1;
            btnGonderTransfer.Text = "Göndər";
            btnGonderTransfer.UseVisualStyleBackColor = false;
            // 
            // btnYeniTransfer
            // 
            btnYeniTransfer.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            btnYeniTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnYeniTransfer.ForeColor = System.Drawing.Color.White;
            btnYeniTransfer.Location = new System.Drawing.Point(14, 17);
            btnYeniTransfer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            btnYeniTransfer.Name = "btnYeniTransfer";
            btnYeniTransfer.Size = new System.Drawing.Size(128, 40);
            btnYeniTransfer.TabIndex = 0;
            btnYeniTransfer.Text = "Yeni Transfer";
            btnYeniTransfer.UseVisualStyleBackColor = false;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripStatusLabel });
            statusStrip.Location = new System.Drawing.Point(0, 753);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            statusStrip.Size = new System.Drawing.Size(1400, 22);
            statusStrip.TabIndex = 1;
            statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new System.Drawing.Size(95, 17);
            toolStripStatusLabel.Text = "Tədarük Modulu";
            // 
            // TedarukManagementForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1400, 775);
            Controls.Add(tabControl);
            Controls.Add(statusStrip);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "TedarukManagementForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Tədarük və Anbar İdarəetməsi";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            tabControl.ResumeLayout(false);
            tabTedarukciler.ResumeLayout(false);
            panelTedarukcu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTedarukciler).EndInit();
            panelTedarukcuButtons.ResumeLayout(false);
            panelTedarukcuSearch.ResumeLayout(false);
            panelTedarukcuSearch.PerformLayout();
            tabAlisOrderleri.ResumeLayout(false);
            panelAlisOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAlisOrderleri).EndInit();
            panelOrderButtons.ResumeLayout(false);
            panelOrderFilter.ResumeLayout(false);
            panelOrderFilter.PerformLayout();
            tabAlisSenedleri.ResumeLayout(false);
            panelAlisSened.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAlisSenedleri).EndInit();
            panelSenedButtons.ResumeLayout(false);
            panelSenedFilter.ResumeLayout(false);
            panelSenedFilter.PerformLayout();
            tabAnbarTransfer.ResumeLayout(false);
            panelTransfer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTransferler).EndInit();
            panelTransferButtons.ResumeLayout(false);
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

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
        private System.Windows.Forms.Button txtOrderAxtaris;
        private System.Windows.Forms.Button txtSenedAxtaris;
        private System.Windows.Forms.Button txtTransferAxtaris;
    }
}