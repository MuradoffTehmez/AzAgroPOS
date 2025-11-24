namespace AzAgroPOS.Teqdimat
{
    partial class SatisFormu
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            pnlMainContainer = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            pnlSearchSection = new MaterialSkin.Controls.MaterialCard();
            dgvAxtarisNeticeleri = new DataGridView();
            colAxtId = new DataGridViewTextBoxColumn();
            colAxtAd = new DataGridViewTextBoxColumn();
            colAxtStokKodu = new DataGridViewTextBoxColumn();
            colAxtBarkod = new DataGridViewTextBoxColumn();
            colAxtQiymet = new DataGridViewTextBoxColumn();
            colAxtStok = new DataGridViewTextBoxColumn();
            contextMenuStripAxtarisNeticeleri = new ContextMenuStrip(components);
            tsmiAxtarisDetallar = new ToolStripMenuItem();
            tsmiAxtarisRedakteEt = new ToolStripMenuItem();
            tsmiAxtarisSil = new ToolStripMenuItem();
            txtAxtaris = new MaterialSkin.Controls.MaterialTextBox2();
            pnlQuantityControls = new Panel();
            txtMiqdar = new MaterialSkin.Controls.MaterialTextBox2();
            btnSebeteElaveEt = new MaterialSkin.Controls.MaterialButton();
            pnlCartSection = new MaterialSkin.Controls.MaterialCard();
            dgvSebet = new DataGridView();
            colSebetMehsulId = new DataGridViewTextBoxColumn();
            colSebetMehsulAdi = new DataGridViewTextBoxColumn();
            colSebetMiqdar = new DataGridViewTextBoxColumn();
            colSebetQiymet = new DataGridViewTextBoxColumn();
            colSebetUmumiMebleg = new DataGridViewTextBoxColumn();
            contextMenuStripSebet = new ContextMenuStrip(components);
            tsmiSebetDetallar = new ToolStripMenuItem();
            tsmiSebetRedakteEt = new ToolStripMenuItem();
            tsmiSebetSil = new ToolStripMenuItem();
            pnlCartControls = new Panel();
            btnSebetdenSil = new MaterialSkin.Controls.MaterialButton();
            btnSebetTemizle = new MaterialSkin.Controls.MaterialButton();
            pnlPaymentSection = new MaterialSkin.Controls.MaterialCard();
            lblTotalTitle = new MaterialSkin.Controls.MaterialLabel();
            lblUmumiMebleg = new MaterialSkin.Controls.MaterialLabel();
            pnlPaymentMethods = new Panel();
            btnNagd = new MaterialSkin.Controls.MaterialButton();
            btnKart = new MaterialSkin.Controls.MaterialButton();
            btnNisye = new MaterialSkin.Controls.MaterialButton();
            btn5AZN = new MaterialSkin.Controls.MaterialButton();
            btn10AZN = new MaterialSkin.Controls.MaterialButton();
            btn20AZN = new MaterialSkin.Controls.MaterialButton();
            btn50AZN = new MaterialSkin.Controls.MaterialButton();
            btn100AZN = new MaterialSkin.Controls.MaterialButton();
            pnlAdvancedOptions = new Panel();
            btnYeniMusteri = new MaterialSkin.Controls.MaterialButton();
            cmbMusteriler = new MaterialSkin.Controls.MaterialComboBox();
            btnSatisiGozlet = new MaterialSkin.Controls.MaterialButton();
            btnGozleyenSatislar = new MaterialSkin.Controls.MaterialButton();
            btnIndirim = new MaterialSkin.Controls.MaterialButton();
            flpSuretliSatis = new FlowLayoutPanel();
            contextMenuStripGozleyenler = new ContextMenuStrip(components);
            toolTip1 = new ToolTip(components);
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            errorProvider1 = new ErrorProvider(components);
            pnlMainContainer.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            pnlSearchSection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAxtarisNeticeleri).BeginInit();
            contextMenuStripAxtarisNeticeleri.SuspendLayout();
            pnlQuantityControls.SuspendLayout();
            pnlCartSection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSebet).BeginInit();
            contextMenuStripSebet.SuspendLayout();
            pnlCartControls.SuspendLayout();
            pnlPaymentSection.SuspendLayout();
            pnlPaymentMethods.SuspendLayout();
            pnlAdvancedOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            //
            // pnlMainContainer - Ana konteyner (Gradient arka plan)
            //
            pnlMainContainer.BackColor = Color.FromArgb(245, 247, 250);
            pnlMainContainer.Controls.Add(tableLayoutPanel1);
            pnlMainContainer.Dock = DockStyle.Fill;
            pnlMainContainer.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            pnlMainContainer.ForeColor = Color.FromArgb(33, 37, 41);
            pnlMainContainer.Location = new Point(3, 64);
            pnlMainContainer.Name = "pnlMainContainer";
            pnlMainContainer.Padding = new Padding(12);
            pnlMainContainer.Size = new Size(1774, 769);
            pnlMainContainer.TabIndex = 0;
            //
            // tableLayoutPanel1 - Əsas layout
            //
            tableLayoutPanel1.BackColor = Color.FromArgb(245, 247, 250);
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 420F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(flpSuretliSatis, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            tableLayoutPanel1.ForeColor = Color.FromArgb(33, 37, 41);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(0);
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1754, 749);
            tableLayoutPanel1.TabIndex = 4;
            //
            // panel1 - Sol panel konteyneri
            //
            panel1.BackColor = Color.FromArgb(245, 247, 250);
            panel1.Controls.Add(pnlSearchSection);
            panel1.Controls.Add(pnlCartSection);
            panel1.Controls.Add(pnlPaymentSection);
            panel1.Dock = DockStyle.Fill;
            panel1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            panel1.ForeColor = Color.FromArgb(33, 37, 41);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0, 0, 10, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1298, 743);
            panel1.TabIndex = 0;
            //
            // pnlSearchSection - Axtarış Paneli (Professional Card Design)
            //
            pnlSearchSection.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pnlSearchSection.BackColor = Color.FromArgb(255, 255, 255);
            pnlSearchSection.Controls.Add(dgvAxtarisNeticeleri);
            pnlSearchSection.Controls.Add(txtAxtaris);
            pnlSearchSection.Controls.Add(pnlQuantityControls);
            pnlSearchSection.Depth = 0;
            pnlSearchSection.ForeColor = Color.FromArgb(33, 37, 41);
            pnlSearchSection.Location = new Point(0, 0);
            pnlSearchSection.Margin = new Padding(0, 0, 12, 0);
            pnlSearchSection.MouseState = MaterialSkin.MouseState.HOVER;
            pnlSearchSection.Name = "pnlSearchSection";
            pnlSearchSection.Padding = new Padding(20);
            pnlSearchSection.Size = new Size(420, 558);
            pnlSearchSection.TabIndex = 0;
            //
            // dgvAxtarisNeticeleri - Axtarış nəticələri (Modern Design)
            //
            dgvAxtarisNeticeleri.AllowUserToAddRows = false;
            dgvAxtarisNeticeleri.AllowUserToDeleteRows = false;
            dgvAxtarisNeticeleri.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAxtarisNeticeleri.AutoGenerateColumns = false;
            dgvAxtarisNeticeleri.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAxtarisNeticeleri.BackgroundColor = Color.White;
            dgvAxtarisNeticeleri.BorderStyle = BorderStyle.None;
            dgvAxtarisNeticeleri.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(25, 118, 210);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(25, 118, 210);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridViewCellStyle1.Padding = new Padding(8, 4, 8, 4);
            dgvAxtarisNeticeleri.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvAxtarisNeticeleri.ColumnHeadersHeight = 40;
            dgvAxtarisNeticeleri.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvAxtarisNeticeleri.Columns.AddRange(new DataGridViewColumn[] { colAxtId, colAxtAd, colAxtStokKodu, colAxtBarkod, colAxtQiymet, colAxtStok });
            dgvAxtarisNeticeleri.ContextMenuStrip = contextMenuStripAxtarisNeticeleri;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(227, 242, 253);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(25, 118, 210);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewCellStyle2.Padding = new Padding(8, 4, 8, 4);
            dgvAxtarisNeticeleri.DefaultCellStyle = dataGridViewCellStyle2;
            dgvAxtarisNeticeleri.EnableHeadersVisualStyles = false;
            dgvAxtarisNeticeleri.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            dgvAxtarisNeticeleri.GridColor = Color.FromArgb(238, 238, 238);
            dgvAxtarisNeticeleri.Location = new Point(20, 82);
            dgvAxtarisNeticeleri.MultiSelect = false;
            dgvAxtarisNeticeleri.Name = "dgvAxtarisNeticeleri";
            dgvAxtarisNeticeleri.ReadOnly = true;
            dgvAxtarisNeticeleri.RowHeadersVisible = false;
            dgvAxtarisNeticeleri.RowTemplate.Height = 38;
            dgvAxtarisNeticeleri.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAxtarisNeticeleri.Size = new Size(380, 390);
            dgvAxtarisNeticeleri.TabIndex = 1;
            dgvAxtarisNeticeleri.DoubleClick += dgvAxtarisNeticeleri_DoubleClick;
            //
            // colAxtId
            //
            colAxtId.DataPropertyName = "Id";
            colAxtId.HeaderText = "ID";
            colAxtId.Name = "colAxtId";
            colAxtId.ReadOnly = true;
            colAxtId.Visible = false;
            //
            // colAxtAd
            //
            colAxtAd.DataPropertyName = "Ad";
            colAxtAd.HeaderText = "Məhsul Adı";
            colAxtAd.Name = "colAxtAd";
            colAxtAd.ReadOnly = true;
            colAxtAd.FillWeight = 35;
            //
            // colAxtStokKodu
            //
            colAxtStokKodu.DataPropertyName = "StokKodu";
            colAxtStokKodu.HeaderText = "Stok Kodu";
            colAxtStokKodu.Name = "colAxtStokKodu";
            colAxtStokKodu.ReadOnly = true;
            colAxtStokKodu.FillWeight = 20;
            //
            // colAxtBarkod
            //
            colAxtBarkod.DataPropertyName = "Barkod";
            colAxtBarkod.HeaderText = "Barkod";
            colAxtBarkod.Name = "colAxtBarkod";
            colAxtBarkod.ReadOnly = true;
            colAxtBarkod.FillWeight = 20;
            //
            // colAxtQiymet
            //
            colAxtQiymet.DataPropertyName = "PerakendeSatisQiymeti";
            colAxtQiymet.HeaderText = "Qiymət";
            colAxtQiymet.Name = "colAxtQiymet";
            colAxtQiymet.ReadOnly = true;
            colAxtQiymet.FillWeight = 15;
            colAxtQiymet.DefaultCellStyle.Format = "N2";
            colAxtQiymet.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            // colAxtStok
            //
            colAxtStok.DataPropertyName = "MovcudSay";
            colAxtStok.HeaderText = "Stok";
            colAxtStok.Name = "colAxtStok";
            colAxtStok.ReadOnly = true;
            colAxtStok.FillWeight = 10;
            colAxtStok.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            // 
            // contextMenuStripAxtarisNeticeleri
            // 
            contextMenuStripAxtarisNeticeleri.Items.AddRange(new ToolStripItem[] { tsmiAxtarisDetallar, tsmiAxtarisRedakteEt, tsmiAxtarisSil });
            contextMenuStripAxtarisNeticeleri.Name = "contextMenuStripAxtarisNeticeleri";
            contextMenuStripAxtarisNeticeleri.Size = new Size(130, 70);
            // 
            // tsmiAxtarisDetallar
            // 
            tsmiAxtarisDetallar.Name = "tsmiAxtarisDetallar";
            tsmiAxtarisDetallar.Size = new Size(129, 22);
            tsmiAxtarisDetallar.Text = "Detallar";
            tsmiAxtarisDetallar.Click += tsmiAxtarisDetallar_Click;
            // 
            // tsmiAxtarisRedakteEt
            // 
            tsmiAxtarisRedakteEt.Name = "tsmiAxtarisRedakteEt";
            tsmiAxtarisRedakteEt.Size = new Size(129, 22);
            tsmiAxtarisRedakteEt.Text = "Redaktə Et";
            tsmiAxtarisRedakteEt.Click += tsmiAxtarisRedakteEt_Click;
            // 
            // tsmiAxtarisSil
            // 
            tsmiAxtarisSil.Name = "tsmiAxtarisSil";
            tsmiAxtarisSil.Size = new Size(129, 22);
            tsmiAxtarisSil.Text = "Sil";
            tsmiAxtarisSil.Click += tsmiAxtarisSil_Click;
            //
            // txtAxtaris - Axtarış sahəsi (Modern Input)
            //
            txtAxtaris.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAxtaris.AnimateReadOnly = false;
            txtAxtaris.BackColor = Color.FromArgb(250, 250, 250);
            txtAxtaris.BackgroundImageLayout = ImageLayout.None;
            txtAxtaris.CharacterCasing = CharacterCasing.Normal;
            txtAxtaris.Depth = 0;
            txtAxtaris.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtAxtaris.HideSelection = true;
            txtAxtaris.Hint = "Barkod, ad və ya kod ilə axtar... (Ctrl+F)";
            txtAxtaris.LeadingIcon = null;
            txtAxtaris.Location = new Point(20, 20);
            txtAxtaris.MaxLength = 100;
            txtAxtaris.MouseState = MaterialSkin.MouseState.OUT;
            txtAxtaris.Name = "txtAxtaris";
            txtAxtaris.PasswordChar = '\0';
            txtAxtaris.PrefixSuffixText = null;
            txtAxtaris.ReadOnly = false;
            txtAxtaris.RightToLeft = RightToLeft.No;
            txtAxtaris.SelectedText = "";
            txtAxtaris.SelectionLength = 0;
            txtAxtaris.SelectionStart = 0;
            txtAxtaris.ShortcutsEnabled = true;
            txtAxtaris.Size = new Size(380, 52);
            txtAxtaris.TabIndex = 0;
            txtAxtaris.TabStop = false;
            txtAxtaris.TextAlign = HorizontalAlignment.Left;
            txtAxtaris.TrailingIcon = null;
            txtAxtaris.UseSystemPasswordChar = false;
            txtAxtaris.TextChanged += txtAxtaris_TextChanged;
            //
            // pnlQuantityControls - Miqdar kontrolları
            //
            pnlQuantityControls.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlQuantityControls.BackColor = Color.FromArgb(255, 255, 255);
            pnlQuantityControls.Controls.Add(txtMiqdar);
            pnlQuantityControls.Controls.Add(btnSebeteElaveEt);
            pnlQuantityControls.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            pnlQuantityControls.ForeColor = Color.FromArgb(33, 37, 41);
            pnlQuantityControls.Location = new Point(20, 482);
            pnlQuantityControls.Name = "pnlQuantityControls";
            pnlQuantityControls.Size = new Size(380, 56);
            pnlQuantityControls.TabIndex = 2;
            //
            // txtMiqdar - Miqdar giriş sahəsi
            //
            txtMiqdar.AnimateReadOnly = false;
            txtMiqdar.BackColor = Color.FromArgb(250, 250, 250);
            txtMiqdar.BackgroundImageLayout = ImageLayout.None;
            txtMiqdar.CharacterCasing = CharacterCasing.Normal;
            txtMiqdar.Depth = 0;
            txtMiqdar.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            txtMiqdar.HideSelection = true;
            txtMiqdar.Hint = "Miqdar";
            txtMiqdar.LeadingIcon = null;
            txtMiqdar.Location = new Point(0, 4);
            txtMiqdar.MaxLength = 10;
            txtMiqdar.MouseState = MaterialSkin.MouseState.OUT;
            txtMiqdar.Name = "txtMiqdar";
            txtMiqdar.PasswordChar = '\0';
            txtMiqdar.PrefixSuffixText = null;
            txtMiqdar.ReadOnly = false;
            txtMiqdar.RightToLeft = RightToLeft.No;
            txtMiqdar.SelectedText = "";
            txtMiqdar.SelectionLength = 0;
            txtMiqdar.SelectionStart = 0;
            txtMiqdar.ShortcutsEnabled = true;
            txtMiqdar.Size = new Size(100, 48);
            txtMiqdar.TabIndex = 1;
            txtMiqdar.TabStop = false;
            txtMiqdar.Text = "1";
            txtMiqdar.TextAlign = HorizontalAlignment.Center;
            txtMiqdar.TrailingIcon = null;
            txtMiqdar.UseSystemPasswordChar = false;
            //
            // btnSebeteElaveEt - Səbətə əlavə et düyməsi (Primary Action)
            //
            btnSebeteElaveEt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnSebeteElaveEt.AutoSize = false;
            btnSebeteElaveEt.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSebeteElaveEt.BackColor = Color.FromArgb(25, 118, 210);
            btnSebeteElaveEt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSebeteElaveEt.Depth = 0;
            btnSebeteElaveEt.ForeColor = Color.White;
            btnSebeteElaveEt.HighEmphasis = true;
            btnSebeteElaveEt.Icon = null;
            btnSebeteElaveEt.Location = new Point(108, 4);
            btnSebeteElaveEt.Margin = new Padding(8, 6, 0, 6);
            btnSebeteElaveEt.MouseState = MaterialSkin.MouseState.HOVER;
            btnSebeteElaveEt.Name = "btnSebeteElaveEt";
            btnSebeteElaveEt.NoAccentTextColor = Color.Empty;
            btnSebeteElaveEt.Size = new Size(272, 48);
            btnSebeteElaveEt.TabIndex = 2;
            btnSebeteElaveEt.Text = "SƏBƏTƏ ƏLAVƏ ET (F7)";
            btnSebeteElaveEt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSebeteElaveEt.UseAccentColor = false;
            btnSebeteElaveEt.UseVisualStyleBackColor = false;
            btnSebeteElaveEt.Click += btnSebeteElaveEt_Click;
            //
            // pnlCartSection - Səbət Paneli (Main Content Area)
            //
            pnlCartSection.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlCartSection.BackColor = Color.FromArgb(255, 255, 255);
            pnlCartSection.Controls.Add(dgvSebet);
            pnlCartSection.Controls.Add(pnlCartControls);
            pnlCartSection.Depth = 0;
            pnlCartSection.ForeColor = Color.FromArgb(33, 37, 41);
            pnlCartSection.Location = new Point(432, 0);
            pnlCartSection.Margin = new Padding(12, 0, 0, 0);
            pnlCartSection.MouseState = MaterialSkin.MouseState.HOVER;
            pnlCartSection.Name = "pnlCartSection";
            pnlCartSection.Padding = new Padding(20);
            pnlCartSection.Size = new Size(866, 558);
            pnlCartSection.TabIndex = 1;
            //
            // dgvSebet - Səbət DataGridView (Modern Design with Green Theme)
            //
            dgvSebet.AllowUserToAddRows = false;
            dgvSebet.AllowUserToDeleteRows = false;
            dgvSebet.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSebet.AutoGenerateColumns = true;
            dgvSebet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSebet.BackgroundColor = Color.White;
            dgvSebet.BorderStyle = BorderStyle.None;
            dgvSebet.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(46, 125, 50);
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(46, 125, 50);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridViewCellStyle3.Padding = new Padding(10, 6, 10, 6);
            dgvSebet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvSebet.ColumnHeadersHeight = 44;
            dgvSebet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvSebet.Columns.AddRange(new DataGridViewColumn[] { colSebetMehsulId, colSebetMehsulAdi, colSebetMiqdar, colSebetQiymet, colSebetUmumiMebleg });
            dgvSebet.ContextMenuStrip = contextMenuStripSebet;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 11F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(232, 245, 233);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(46, 125, 50);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dataGridViewCellStyle4.Padding = new Padding(10, 4, 10, 4);
            dgvSebet.DefaultCellStyle = dataGridViewCellStyle4;
            dgvSebet.EnableHeadersVisualStyles = false;
            dgvSebet.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            dgvSebet.GridColor = Color.FromArgb(238, 238, 238);
            dgvSebet.Location = new Point(20, 20);
            dgvSebet.Name = "dgvSebet";
            dgvSebet.RowHeadersVisible = false;
            dgvSebet.RowTemplate.Height = 44;
            dgvSebet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSebet.Size = new Size(826, 450);
            dgvSebet.TabIndex = 0;
            dgvSebet.CellContentClick += dgvSebet_CellContentClick;
            //
            // colSebetMehsulId
            //
            colSebetMehsulId.DataPropertyName = "MehsulId";
            colSebetMehsulId.HeaderText = "ID";
            colSebetMehsulId.Name = "colSebetMehsulId";
            colSebetMehsulId.ReadOnly = true;
            colSebetMehsulId.Visible = false;
            //
            // colSebetMehsulAdi
            //
            colSebetMehsulAdi.DataPropertyName = "MehsulAdi";
            colSebetMehsulAdi.HeaderText = "Məhsul";
            colSebetMehsulAdi.Name = "colSebetMehsulAdi";
            colSebetMehsulAdi.ReadOnly = true;
            colSebetMehsulAdi.FillWeight = 40;
            //
            // colSebetMiqdar
            //
            colSebetMiqdar.DataPropertyName = "Miqdar";
            colSebetMiqdar.HeaderText = "Miqdar";
            colSebetMiqdar.Name = "colSebetMiqdar";
            colSebetMiqdar.ReadOnly = true;
            colSebetMiqdar.FillWeight = 15;
            colSebetMiqdar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //
            // colSebetQiymet
            //
            colSebetQiymet.DataPropertyName = "VahidinQiymeti";
            colSebetQiymet.HeaderText = "Qiymət";
            colSebetQiymet.Name = "colSebetQiymet";
            colSebetQiymet.ReadOnly = true;
            colSebetQiymet.FillWeight = 20;
            colSebetQiymet.DefaultCellStyle.Format = "N2";
            colSebetQiymet.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //
            // colSebetUmumiMebleg
            //
            colSebetUmumiMebleg.DataPropertyName = "UmumiMebleg";
            colSebetUmumiMebleg.HeaderText = "Cəm";
            colSebetUmumiMebleg.Name = "colSebetUmumiMebleg";
            colSebetUmumiMebleg.ReadOnly = true;
            colSebetUmumiMebleg.FillWeight = 25;
            colSebetUmumiMebleg.DefaultCellStyle.Format = "N2";
            colSebetUmumiMebleg.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            // 
            // contextMenuStripSebet
            // 
            contextMenuStripSebet.Items.AddRange(new ToolStripItem[] { tsmiSebetDetallar, tsmiSebetRedakteEt, tsmiSebetSil });
            contextMenuStripSebet.Name = "contextMenuStripSebet";
            contextMenuStripSebet.Size = new Size(130, 70);
            // 
            // tsmiSebetDetallar
            // 
            tsmiSebetDetallar.Name = "tsmiSebetDetallar";
            tsmiSebetDetallar.Size = new Size(129, 22);
            tsmiSebetDetallar.Text = "Detallar";
            tsmiSebetDetallar.Click += tsmiSebetDetallar_Click;
            // 
            // tsmiSebetRedakteEt
            // 
            tsmiSebetRedakteEt.Name = "tsmiSebetRedakteEt";
            tsmiSebetRedakteEt.Size = new Size(129, 22);
            tsmiSebetRedakteEt.Text = "Redaktə Et";
            tsmiSebetRedakteEt.Click += tsmiSebetRedakteEt_Click;
            // 
            // tsmiSebetSil
            // 
            tsmiSebetSil.Name = "tsmiSebetSil";
            tsmiSebetSil.Size = new Size(129, 22);
            tsmiSebetSil.Text = "Sil";
            tsmiSebetSil.Click += tsmiSebetSil_Click;
            //
            // pnlCartControls - Səbət əməliyyat düymələri
            //
            pnlCartControls.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlCartControls.BackColor = Color.FromArgb(255, 255, 255);
            pnlCartControls.Controls.Add(btnSebetdenSil);
            pnlCartControls.Controls.Add(btnSebetTemizle);
            pnlCartControls.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            pnlCartControls.ForeColor = Color.FromArgb(33, 37, 41);
            pnlCartControls.Location = new Point(20, 482);
            pnlCartControls.Name = "pnlCartControls";
            pnlCartControls.Size = new Size(826, 56);
            pnlCartControls.TabIndex = 1;
            //
            // btnSebetdenSil - Seçilmiş elementi sil
            //
            btnSebetdenSil.AutoSize = false;
            btnSebetdenSil.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSebetdenSil.BackColor = Color.FromArgb(211, 47, 47);
            btnSebetdenSil.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSebetdenSil.Depth = 0;
            btnSebetdenSil.ForeColor = Color.White;
            btnSebetdenSil.HighEmphasis = true;
            btnSebetdenSil.Icon = null;
            btnSebetdenSil.Location = new Point(0, 4);
            btnSebetdenSil.Margin = new Padding(0, 6, 8, 6);
            btnSebetdenSil.MouseState = MaterialSkin.MouseState.HOVER;
            btnSebetdenSil.Name = "btnSebetdenSil";
            btnSebetdenSil.NoAccentTextColor = Color.Empty;
            btnSebetdenSil.Size = new Size(160, 48);
            btnSebetdenSil.TabIndex = 16;
            btnSebetdenSil.Text = "SİL (F8)";
            btnSebetdenSil.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSebetdenSil.UseAccentColor = true;
            btnSebetdenSil.UseVisualStyleBackColor = false;
            btnSebetdenSil.Click += btnSebetdenSil_Click;
            //
            // btnSebetTemizle - Səbəti tamamilə təmizlə
            //
            btnSebetTemizle.AutoSize = false;
            btnSebetTemizle.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSebetTemizle.BackColor = Color.FromArgb(245, 245, 245);
            btnSebetTemizle.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSebetTemizle.Depth = 0;
            btnSebetTemizle.ForeColor = Color.FromArgb(97, 97, 97);
            btnSebetTemizle.HighEmphasis = false;
            btnSebetTemizle.Icon = null;
            btnSebetTemizle.Location = new Point(168, 4);
            btnSebetTemizle.Margin = new Padding(0, 6, 8, 6);
            btnSebetTemizle.MouseState = MaterialSkin.MouseState.HOVER;
            btnSebetTemizle.Name = "btnSebetTemizle";
            btnSebetTemizle.NoAccentTextColor = Color.Empty;
            btnSebetTemizle.Size = new Size(160, 48);
            btnSebetTemizle.TabIndex = 17;
            btnSebetTemizle.Text = "TƏMİZLƏ (F9)";
            btnSebetTemizle.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnSebetTemizle.UseAccentColor = false;
            btnSebetTemizle.UseVisualStyleBackColor = false;
            btnSebetTemizle.Click += btnSebetTemizle_Click;
            //
            // pnlPaymentSection - Ödəniş Paneli (Premium Design)
            //
            pnlPaymentSection.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlPaymentSection.BackColor = Color.FromArgb(255, 255, 255);
            pnlPaymentSection.Controls.Add(lblTotalTitle);
            pnlPaymentSection.Controls.Add(lblUmumiMebleg);
            pnlPaymentSection.Controls.Add(pnlPaymentMethods);
            pnlPaymentSection.Controls.Add(pnlAdvancedOptions);
            pnlPaymentSection.Depth = 0;
            pnlPaymentSection.ForeColor = Color.FromArgb(33, 37, 41);
            pnlPaymentSection.Location = new Point(0, 568);
            pnlPaymentSection.Margin = new Padding(0, 12, 0, 0);
            pnlPaymentSection.MouseState = MaterialSkin.MouseState.HOVER;
            pnlPaymentSection.Name = "pnlPaymentSection";
            pnlPaymentSection.Padding = new Padding(20);
            pnlPaymentSection.Size = new Size(1298, 175);
            pnlPaymentSection.TabIndex = 2;
            //
            // lblTotalTitle - Ümumi məbləğ başlığı
            //
            lblTotalTitle.AutoSize = true;
            lblTotalTitle.BackColor = Color.Transparent;
            lblTotalTitle.Depth = 0;
            lblTotalTitle.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblTotalTitle.ForeColor = Color.FromArgb(117, 117, 117);
            lblTotalTitle.Location = new Point(24, 16);
            lblTotalTitle.MouseState = MaterialSkin.MouseState.HOVER;
            lblTotalTitle.Name = "lblTotalTitle";
            lblTotalTitle.Size = new Size(135, 19);
            lblTotalTitle.TabIndex = 4;
            lblTotalTitle.Text = "CƏMİ ÖDƏNİLƏCƏK";
            //
            // lblUmumiMebleg - Ümumi məbləğ (Large Display)
            //
            lblUmumiMebleg.AutoSize = true;
            lblUmumiMebleg.BackColor = Color.Transparent;
            lblUmumiMebleg.Depth = 0;
            lblUmumiMebleg.Font = new Font("Segoe UI", 42F, FontStyle.Bold, GraphicsUnit.Point);
            lblUmumiMebleg.FontType = MaterialSkin.MaterialSkinManager.fontType.H3;
            lblUmumiMebleg.ForeColor = Color.FromArgb(46, 125, 50);
            lblUmumiMebleg.Location = new Point(20, 38);
            lblUmumiMebleg.MouseState = MaterialSkin.MouseState.HOVER;
            lblUmumiMebleg.Name = "lblUmumiMebleg";
            lblUmumiMebleg.Size = new Size(260, 75);
            lblUmumiMebleg.TabIndex = 0;
            lblUmumiMebleg.Text = "0.00 AZN";
            //
            // pnlPaymentMethods - Ödəniş metodları paneli
            //
            pnlPaymentMethods.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlPaymentMethods.BackColor = Color.FromArgb(255, 255, 255);
            pnlPaymentMethods.Controls.Add(btnNagd);
            pnlPaymentMethods.Controls.Add(btnKart);
            pnlPaymentMethods.Controls.Add(btnNisye);
            pnlPaymentMethods.Controls.Add(btn5AZN);
            pnlPaymentMethods.Controls.Add(btn10AZN);
            pnlPaymentMethods.Controls.Add(btn20AZN);
            pnlPaymentMethods.Controls.Add(btn50AZN);
            pnlPaymentMethods.Controls.Add(btn100AZN);
            pnlPaymentMethods.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            pnlPaymentMethods.ForeColor = Color.FromArgb(33, 37, 41);
            pnlPaymentMethods.Location = new Point(780, 8);
            pnlPaymentMethods.Name = "pnlPaymentMethods";
            pnlPaymentMethods.Size = new Size(500, 110);
            pnlPaymentMethods.TabIndex = 2;
            //
            // btnNagd - Nağd ödəniş düyməsi (Primary Green)
            //
            btnNagd.AutoSize = false;
            btnNagd.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnNagd.BackColor = Color.FromArgb(46, 125, 50);
            btnNagd.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnNagd.Depth = 0;
            btnNagd.ForeColor = Color.White;
            btnNagd.HighEmphasis = true;
            btnNagd.Icon = null;
            btnNagd.Location = new Point(0, 0);
            btnNagd.Margin = new Padding(0, 0, 8, 8);
            btnNagd.MouseState = MaterialSkin.MouseState.HOVER;
            btnNagd.Name = "btnNagd";
            btnNagd.NoAccentTextColor = Color.Empty;
            btnNagd.Size = new Size(160, 56);
            btnNagd.TabIndex = 13;
            btnNagd.Text = "NAĞD (F1)";
            btnNagd.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnNagd.UseAccentColor = false;
            btnNagd.UseVisualStyleBackColor = false;
            btnNagd.Click += btnNagd_Click;
            //
            // btnKart - Kart ödənişi düyməsi (Primary Blue)
            //
            btnKart.AutoSize = false;
            btnKart.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnKart.BackColor = Color.FromArgb(25, 118, 210);
            btnKart.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnKart.Depth = 0;
            btnKart.ForeColor = Color.White;
            btnKart.HighEmphasis = true;
            btnKart.Icon = null;
            btnKart.Location = new Point(168, 0);
            btnKart.Margin = new Padding(0, 0, 8, 8);
            btnKart.MouseState = MaterialSkin.MouseState.HOVER;
            btnKart.Name = "btnKart";
            btnKart.NoAccentTextColor = Color.Empty;
            btnKart.Size = new Size(160, 56);
            btnKart.TabIndex = 14;
            btnKart.Text = "KART (F2)";
            btnKart.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnKart.UseAccentColor = false;
            btnKart.UseVisualStyleBackColor = false;
            btnKart.Click += btnKart_Click;
            //
            // btnNisye - Nisyə ödəniş düyməsi (Accent Orange)
            //
            btnNisye.AutoSize = false;
            btnNisye.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnNisye.BackColor = Color.FromArgb(255, 152, 0);
            btnNisye.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnNisye.Depth = 0;
            btnNisye.ForeColor = Color.White;
            btnNisye.HighEmphasis = true;
            btnNisye.Icon = null;
            btnNisye.Location = new Point(336, 0);
            btnNisye.Margin = new Padding(0, 0, 0, 8);
            btnNisye.MouseState = MaterialSkin.MouseState.HOVER;
            btnNisye.Name = "btnNisye";
            btnNisye.NoAccentTextColor = Color.Empty;
            btnNisye.Size = new Size(160, 56);
            btnNisye.TabIndex = 15;
            btnNisye.Text = "NİSYƏ (F3)";
            btnNisye.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnNisye.UseAccentColor = true;
            btnNisye.UseVisualStyleBackColor = false;
            btnNisye.Click += btnNisye_Click;
            //
            // btn5AZN - Sürətli 5 AZN
            //
            btn5AZN.AutoSize = false;
            btn5AZN.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn5AZN.BackColor = Color.FromArgb(236, 239, 241);
            btn5AZN.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn5AZN.Depth = 0;
            btn5AZN.ForeColor = Color.FromArgb(55, 71, 79);
            btn5AZN.HighEmphasis = false;
            btn5AZN.Icon = null;
            btn5AZN.Location = new Point(0, 66);
            btn5AZN.Margin = new Padding(0, 0, 6, 0);
            btn5AZN.MouseState = MaterialSkin.MouseState.HOVER;
            btn5AZN.Name = "btn5AZN";
            btn5AZN.NoAccentTextColor = Color.Empty;
            btn5AZN.Size = new Size(92, 38);
            btn5AZN.TabIndex = 8;
            btn5AZN.Text = "5 AZN";
            btn5AZN.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btn5AZN.UseAccentColor = false;
            btn5AZN.UseVisualStyleBackColor = false;
            btn5AZN.Click += btn5AZN_Click;
            //
            // btn10AZN - Sürətli 10 AZN
            //
            btn10AZN.AutoSize = false;
            btn10AZN.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn10AZN.BackColor = Color.FromArgb(236, 239, 241);
            btn10AZN.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn10AZN.Depth = 0;
            btn10AZN.ForeColor = Color.FromArgb(55, 71, 79);
            btn10AZN.HighEmphasis = false;
            btn10AZN.Icon = null;
            btn10AZN.Location = new Point(98, 66);
            btn10AZN.Margin = new Padding(0, 0, 6, 0);
            btn10AZN.MouseState = MaterialSkin.MouseState.HOVER;
            btn10AZN.Name = "btn10AZN";
            btn10AZN.NoAccentTextColor = Color.Empty;
            btn10AZN.Size = new Size(92, 38);
            btn10AZN.TabIndex = 9;
            btn10AZN.Text = "10 AZN";
            btn10AZN.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btn10AZN.UseAccentColor = false;
            btn10AZN.UseVisualStyleBackColor = false;
            btn10AZN.Click += btn10AZN_Click;
            //
            // btn20AZN - Sürətli 20 AZN
            //
            btn20AZN.AutoSize = false;
            btn20AZN.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn20AZN.BackColor = Color.FromArgb(236, 239, 241);
            btn20AZN.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn20AZN.Depth = 0;
            btn20AZN.ForeColor = Color.FromArgb(55, 71, 79);
            btn20AZN.HighEmphasis = false;
            btn20AZN.Icon = null;
            btn20AZN.Location = new Point(196, 66);
            btn20AZN.Margin = new Padding(0, 0, 6, 0);
            btn20AZN.MouseState = MaterialSkin.MouseState.HOVER;
            btn20AZN.Name = "btn20AZN";
            btn20AZN.NoAccentTextColor = Color.Empty;
            btn20AZN.Size = new Size(92, 38);
            btn20AZN.TabIndex = 10;
            btn20AZN.Text = "20 AZN";
            btn20AZN.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btn20AZN.UseAccentColor = false;
            btn20AZN.UseVisualStyleBackColor = false;
            btn20AZN.Click += btn20AZN_Click;
            //
            // btn50AZN - Sürətli 50 AZN
            //
            btn50AZN.AutoSize = false;
            btn50AZN.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn50AZN.BackColor = Color.FromArgb(236, 239, 241);
            btn50AZN.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn50AZN.Depth = 0;
            btn50AZN.ForeColor = Color.FromArgb(55, 71, 79);
            btn50AZN.HighEmphasis = false;
            btn50AZN.Icon = null;
            btn50AZN.Location = new Point(294, 66);
            btn50AZN.Margin = new Padding(0, 0, 6, 0);
            btn50AZN.MouseState = MaterialSkin.MouseState.HOVER;
            btn50AZN.Name = "btn50AZN";
            btn50AZN.NoAccentTextColor = Color.Empty;
            btn50AZN.Size = new Size(92, 38);
            btn50AZN.TabIndex = 11;
            btn50AZN.Text = "50 AZN";
            btn50AZN.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btn50AZN.UseAccentColor = false;
            btn50AZN.UseVisualStyleBackColor = false;
            btn50AZN.Click += btn50AZN_Click;
            //
            // btn100AZN - Sürətli 100 AZN
            //
            btn100AZN.AutoSize = false;
            btn100AZN.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn100AZN.BackColor = Color.FromArgb(236, 239, 241);
            btn100AZN.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn100AZN.Depth = 0;
            btn100AZN.ForeColor = Color.FromArgb(55, 71, 79);
            btn100AZN.HighEmphasis = false;
            btn100AZN.Icon = null;
            btn100AZN.Location = new Point(392, 66);
            btn100AZN.Margin = new Padding(0);
            btn100AZN.MouseState = MaterialSkin.MouseState.HOVER;
            btn100AZN.Name = "btn100AZN";
            btn100AZN.NoAccentTextColor = Color.Empty;
            btn100AZN.Size = new Size(92, 38);
            btn100AZN.TabIndex = 12;
            btn100AZN.Text = "100 AZN";
            btn100AZN.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btn100AZN.UseAccentColor = false;
            btn100AZN.UseVisualStyleBackColor = false;
            btn100AZN.Click += btn100AZN_Click;
            //
            // pnlAdvancedOptions - Əlavə əməliyyatlar paneli
            //
            pnlAdvancedOptions.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlAdvancedOptions.BackColor = Color.FromArgb(255, 255, 255);
            pnlAdvancedOptions.Controls.Add(btnIndirim);
            pnlAdvancedOptions.Controls.Add(btnGozleyenSatislar);
            pnlAdvancedOptions.Controls.Add(btnYeniMusteri);
            pnlAdvancedOptions.Controls.Add(cmbMusteriler);
            pnlAdvancedOptions.Controls.Add(btnSatisiGozlet);
            pnlAdvancedOptions.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            pnlAdvancedOptions.ForeColor = Color.FromArgb(33, 37, 41);
            pnlAdvancedOptions.Location = new Point(20, 118);
            pnlAdvancedOptions.Name = "pnlAdvancedOptions";
            pnlAdvancedOptions.Size = new Size(1258, 50);
            pnlAdvancedOptions.TabIndex = 3;
            //
            // btnYeniMusteri - Yeni müştəri əlavə et düyməsi
            //
            btnYeniMusteri.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnYeniMusteri.AutoSize = false;
            btnYeniMusteri.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnYeniMusteri.BackColor = Color.FromArgb(25, 118, 210);
            btnYeniMusteri.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnYeniMusteri.Depth = 0;
            btnYeniMusteri.ForeColor = Color.White;
            btnYeniMusteri.HighEmphasis = true;
            btnYeniMusteri.Icon = null;
            btnYeniMusteri.Location = new Point(1208, 4);
            btnYeniMusteri.Margin = new Padding(0, 4, 0, 4);
            btnYeniMusteri.MouseState = MaterialSkin.MouseState.HOVER;
            btnYeniMusteri.Name = "btnYeniMusteri";
            btnYeniMusteri.NoAccentTextColor = Color.Empty;
            btnYeniMusteri.Size = new Size(48, 42);
            btnYeniMusteri.TabIndex = 4;
            btnYeniMusteri.Text = "+";
            btnYeniMusteri.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnYeniMusteri.UseAccentColor = false;
            btnYeniMusteri.UseVisualStyleBackColor = false;
            btnYeniMusteri.Click += btnYeniMusteri_Click;
            //
            // cmbMusteriler - Müştəri seçimi
            //
            cmbMusteriler.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbMusteriler.AutoResize = false;
            cmbMusteriler.BackColor = Color.FromArgb(250, 250, 250);
            cmbMusteriler.Depth = 0;
            cmbMusteriler.DrawMode = DrawMode.OwnerDrawVariable;
            cmbMusteriler.DropDownHeight = 200;
            cmbMusteriler.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMusteriler.DropDownWidth = 380;
            cmbMusteriler.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            cmbMusteriler.ForeColor = Color.FromArgb(33, 37, 41);
            cmbMusteriler.Hint = "Müştəri Seçin";
            cmbMusteriler.IntegralHeight = false;
            cmbMusteriler.ItemHeight = 43;
            cmbMusteriler.Location = new Point(820, 0);
            cmbMusteriler.MaxDropDownItems = 5;
            cmbMusteriler.MouseState = MaterialSkin.MouseState.OUT;
            cmbMusteriler.Name = "cmbMusteriler";
            cmbMusteriler.Size = new Size(380, 49);
            cmbMusteriler.StartIndex = 0;
            cmbMusteriler.TabIndex = 3;
            //
            // btnSatisiGozlet - Satışı gözlət düyməsi
            //
            btnSatisiGozlet.AutoSize = false;
            btnSatisiGozlet.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSatisiGozlet.BackColor = Color.FromArgb(245, 245, 245);
            btnSatisiGozlet.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSatisiGozlet.Depth = 0;
            btnSatisiGozlet.FlatStyle = FlatStyle.Flat;
            btnSatisiGozlet.ForeColor = Color.FromArgb(97, 97, 97);
            btnSatisiGozlet.HighEmphasis = false;
            btnSatisiGozlet.Icon = null;
            btnSatisiGozlet.Location = new Point(0, 4);
            btnSatisiGozlet.Margin = new Padding(0, 4, 8, 4);
            btnSatisiGozlet.MouseState = MaterialSkin.MouseState.HOVER;
            btnSatisiGozlet.Name = "btnSatisiGozlet";
            btnSatisiGozlet.NoAccentTextColor = Color.Empty;
            btnSatisiGozlet.Size = new Size(130, 42);
            btnSatisiGozlet.TabIndex = 6;
            btnSatisiGozlet.Text = "GÖZLƏT (F4)";
            btnSatisiGozlet.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnSatisiGozlet.UseAccentColor = false;
            btnSatisiGozlet.UseVisualStyleBackColor = false;
            btnSatisiGozlet.Click += btnSatisiGozlet_Click;
            //
            // btnGozleyenSatislar - Gözləyən satışlar düyməsi
            //
            btnGozleyenSatislar.AutoSize = false;
            btnGozleyenSatislar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnGozleyenSatislar.BackColor = Color.FromArgb(245, 245, 245);
            btnGozleyenSatislar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnGozleyenSatislar.Depth = 0;
            btnGozleyenSatislar.FlatStyle = FlatStyle.Flat;
            btnGozleyenSatislar.ForeColor = Color.FromArgb(97, 97, 97);
            btnGozleyenSatislar.HighEmphasis = false;
            btnGozleyenSatislar.Icon = null;
            btnGozleyenSatislar.Location = new Point(138, 4);
            btnGozleyenSatislar.Margin = new Padding(0, 4, 8, 4);
            btnGozleyenSatislar.MouseState = MaterialSkin.MouseState.HOVER;
            btnGozleyenSatislar.Name = "btnGozleyenSatislar";
            btnGozleyenSatislar.NoAccentTextColor = Color.Empty;
            btnGozleyenSatislar.Size = new Size(150, 42);
            btnGozleyenSatislar.TabIndex = 7;
            btnGozleyenSatislar.Text = "GÖZLƏYƏNLƏR (F5)";
            btnGozleyenSatislar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnGozleyenSatislar.UseAccentColor = false;
            btnGozleyenSatislar.UseVisualStyleBackColor = false;
            btnGozleyenSatislar.Click += btnGozleyenSatislar_Click;
            //
            // btnIndirim - Endirim tətbiq et düyməsi
            //
            btnIndirim.AutoSize = false;
            btnIndirim.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnIndirim.BackColor = Color.FromArgb(255, 243, 224);
            btnIndirim.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnIndirim.Depth = 0;
            btnIndirim.FlatStyle = FlatStyle.Flat;
            btnIndirim.ForeColor = Color.FromArgb(230, 81, 0);
            btnIndirim.HighEmphasis = false;
            btnIndirim.Icon = null;
            btnIndirim.Location = new Point(296, 4);
            btnIndirim.Margin = new Padding(0, 4, 8, 4);
            btnIndirim.MouseState = MaterialSkin.MouseState.HOVER;
            btnIndirim.Name = "btnIndirim";
            btnIndirim.NoAccentTextColor = Color.Empty;
            btnIndirim.Size = new Size(130, 42);
            btnIndirim.TabIndex = 5;
            btnIndirim.Text = "ENDİRİM (F6)";
            btnIndirim.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnIndirim.UseAccentColor = true;
            btnIndirim.UseVisualStyleBackColor = false;
            btnIndirim.Click += btnIndirim_Click;
            //
            // flpSuretliSatis - Sürətli satış paneli (Right Sidebar)
            //
            flpSuretliSatis.AutoScroll = true;
            flpSuretliSatis.BackColor = Color.FromArgb(255, 255, 255);
            flpSuretliSatis.Dock = DockStyle.Fill;
            flpSuretliSatis.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            flpSuretliSatis.ForeColor = Color.FromArgb(33, 37, 41);
            flpSuretliSatis.Location = new Point(1337, 3);
            flpSuretliSatis.Margin = new Padding(12, 0, 0, 0);
            flpSuretliSatis.Name = "flpSuretliSatis";
            flpSuretliSatis.Padding = new Padding(12);
            flpSuretliSatis.Size = new Size(414, 743);
            flpSuretliSatis.TabIndex = 1;
            // 
            // contextMenuStripGozleyenler
            // 
            contextMenuStripGozleyenler.Name = "contextMenuStripGozleyenler";
            contextMenuStripGozleyenler.Size = new Size(61, 4);
            contextMenuStripGozleyenler.ItemClicked += contextMenuStripGozleyenler_ItemClicked;
            //
            // statusStrip1 - Status bar
            //
            statusStrip1.BackColor = Color.FromArgb(250, 250, 250);
            statusStrip1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            statusStrip1.ForeColor = Color.FromArgb(97, 97, 97);
            statusStrip1.Location = new Point(3, 833);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(8, 0, 8, 0);
            statusStrip1.Size = new Size(1774, 26);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            //
            // toolStripStatusLabel1 - Status mesajı
            //
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(60, 20);
            toolStripStatusLabel1.Text = "Hazır";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // SatisFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1780, 858);
            Controls.Add(pnlMainContainer);
            Controls.Add(statusStrip1);
            KeyPreview = true;
            Name = "SatisFormu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Yeni Satış";
            WindowState = FormWindowState.Maximized;
            KeyDown += SatisFormu_KeyDown;
            Controls.SetChildIndex(statusStrip1, 0);
            Controls.SetChildIndex(pnlMainContainer, 0);
            pnlMainContainer.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            pnlSearchSection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAxtarisNeticeleri).EndInit();
            contextMenuStripAxtarisNeticeleri.ResumeLayout(false);
            pnlQuantityControls.ResumeLayout(false);
            pnlCartSection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSebet).EndInit();
            contextMenuStripSebet.ResumeLayout(false);
            pnlCartControls.ResumeLayout(false);
            pnlPaymentSection.ResumeLayout(false);
            pnlPaymentSection.PerformLayout();
            pnlPaymentMethods.ResumeLayout(false);
            pnlAdvancedOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlMainContainer;
        private MaterialSkin.Controls.MaterialCard pnlSearchSection;
        private System.Windows.Forms.DataGridView dgvAxtarisNeticeleri;
        private MaterialSkin.Controls.MaterialTextBox2 txtAxtaris;
        private System.Windows.Forms.Panel pnlQuantityControls;
        private MaterialSkin.Controls.MaterialTextBox2 txtMiqdar;
        private MaterialSkin.Controls.MaterialButton btnSebeteElaveEt;
        private MaterialSkin.Controls.MaterialCard pnlCartSection;
        private System.Windows.Forms.DataGridView dgvSebet;
        private System.Windows.Forms.Panel pnlCartControls;
        private MaterialSkin.Controls.MaterialButton btnSebetdenSil;
        private MaterialSkin.Controls.MaterialButton btnSebetTemizle;
        private MaterialSkin.Controls.MaterialCard pnlPaymentSection;
        private MaterialSkin.Controls.MaterialLabel lblTotalTitle;
        private MaterialSkin.Controls.MaterialLabel lblUmumiMebleg;
        private System.Windows.Forms.Panel pnlPaymentMethods;
        private MaterialSkin.Controls.MaterialButton btnNagd;
        private MaterialSkin.Controls.MaterialButton btnKart;
        private MaterialSkin.Controls.MaterialButton btnNisye;
        private MaterialSkin.Controls.MaterialButton btn5AZN;
        private MaterialSkin.Controls.MaterialButton btn10AZN;
        private MaterialSkin.Controls.MaterialButton btn20AZN;
        private MaterialSkin.Controls.MaterialButton btn50AZN;
        private MaterialSkin.Controls.MaterialButton btn100AZN;
        private System.Windows.Forms.Panel pnlAdvancedOptions;
        private MaterialSkin.Controls.MaterialComboBox cmbMusteriler;
        private MaterialSkin.Controls.MaterialButton btnSatisiGozlet;
        private MaterialSkin.Controls.MaterialButton btnGozleyenSatislar;
        private MaterialSkin.Controls.MaterialButton btnIndirim;
        private MaterialSkin.Controls.MaterialButton btnIxracEt;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGozleyenler;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripAxtarisNeticeleri;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSebet;
        private System.Windows.Forms.ToolStripMenuItem tsmiAxtarisDetallar;
        private System.Windows.Forms.ToolStripMenuItem tsmiAxtarisRedakteEt;
        private System.Windows.Forms.ToolStripMenuItem tsmiAxtarisSil;
        private System.Windows.Forms.ToolStripMenuItem tsmiSebetDetallar;
        private System.Windows.Forms.ToolStripMenuItem tsmiSebetRedakteEt;
        private System.Windows.Forms.ToolStripMenuItem tsmiSebetSil;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flpSuretliSatis;
        private MaterialSkin.Controls.MaterialButton btnYeniMusteri;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ErrorProvider errorProvider1;

        // dgvAxtarisNeticeleri sütunları
        private DataGridViewTextBoxColumn colAxtId;
        private DataGridViewTextBoxColumn colAxtAd;
        private DataGridViewTextBoxColumn colAxtStokKodu;
        private DataGridViewTextBoxColumn colAxtBarkod;
        private DataGridViewTextBoxColumn colAxtQiymet;
        private DataGridViewTextBoxColumn colAxtStok;

        // dgvSebet sütunları
        private DataGridViewTextBoxColumn colSebetMehsulId;
        private DataGridViewTextBoxColumn colSebetMehsulAdi;
        private DataGridViewTextBoxColumn colSebetMiqdar;
        private DataGridViewTextBoxColumn colSebetQiymet;
        private DataGridViewTextBoxColumn colSebetUmumiMebleg;
    }
}