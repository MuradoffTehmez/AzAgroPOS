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
            // pnlMainContainer
            //
            pnlMainContainer.BackColor = Color.FromArgb(250, 250, 250);
            pnlMainContainer.Controls.Add(tableLayoutPanel1);
            pnlMainContainer.Dock = DockStyle.Fill;
            pnlMainContainer.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlMainContainer.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlMainContainer.Location = new Point(3, 64);
            pnlMainContainer.Name = "pnlMainContainer";
            pnlMainContainer.Padding = new Padding(15);
            pnlMainContainer.Size = new Size(1774, 769);
            pnlMainContainer.TabIndex = 0;
            // 
            // tableLayoutPanel1
            //
            tableLayoutPanel1.BackColor = Color.FromArgb(250, 250, 250);
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 480F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(flpSuretliSatis, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            tableLayoutPanel1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            tableLayoutPanel1.Location = new Point(15, 15);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(0, 0, 0, 0);
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1754, 749);
            tableLayoutPanel1.TabIndex = 4;
            // 
            // panel1
            //
            panel1.BackColor = Color.FromArgb(250, 250, 250);
            panel1.Controls.Add(pnlSearchSection);
            panel1.Controls.Add(pnlCartSection);
            panel1.Controls.Add(pnlPaymentSection);
            panel1.Dock = DockStyle.Fill;
            panel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            panel1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0, 0, 8, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1298, 743);
            panel1.TabIndex = 0;
            // 
            // pnlSearchSection
            //
            pnlSearchSection.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pnlSearchSection.BackColor = Color.FromArgb(255, 255, 255);
            pnlSearchSection.Controls.Add(dgvAxtarisNeticeleri);
            pnlSearchSection.Controls.Add(txtAxtaris);
            pnlSearchSection.Controls.Add(pnlQuantityControls);
            pnlSearchSection.Depth = 0;
            pnlSearchSection.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlSearchSection.Location = new Point(0, 0);
            pnlSearchSection.Margin = new Padding(0, 0, 8, 0);
            pnlSearchSection.MouseState = MaterialSkin.MouseState.HOVER;
            pnlSearchSection.Name = "pnlSearchSection";
            pnlSearchSection.Padding = new Padding(16);
            pnlSearchSection.Size = new Size(450, 558);
            pnlSearchSection.TabIndex = 0;
            //
            // dgvAxtarisNeticeleri
            //
            dgvAxtarisNeticeleri.AllowUserToAddRows = false;
            dgvAxtarisNeticeleri.AllowUserToDeleteRows = false;
            dgvAxtarisNeticeleri.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAxtarisNeticeleri.AutoGenerateColumns = false;
            dgvAxtarisNeticeleri.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(63, 81, 181);
            dataGridViewCellStyle1.Font = new Font("Roboto", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(63, 81, 181);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvAxtarisNeticeleri.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvAxtarisNeticeleri.ColumnHeadersHeight = 32;
            dgvAxtarisNeticeleri.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvAxtarisNeticeleri.Columns.AddRange(new DataGridViewColumn[] { colAxtId, colAxtAd, colAxtStokKodu, colAxtBarkod, colAxtQiymet, colAxtStok });
            dgvAxtarisNeticeleri.ContextMenuStrip = contextMenuStripAxtarisNeticeleri;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Roboto", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvAxtarisNeticeleri.DefaultCellStyle = dataGridViewCellStyle2;
            dgvAxtarisNeticeleri.EnableHeadersVisualStyles = false;
            dgvAxtarisNeticeleri.Font = new Font("Roboto", 11F, FontStyle.Regular, GraphicsUnit.Point);
            dgvAxtarisNeticeleri.GridColor = Color.FromArgb(224, 224, 224);
            dgvAxtarisNeticeleri.Location = new Point(16, 78);
            dgvAxtarisNeticeleri.MultiSelect = false;
            dgvAxtarisNeticeleri.Name = "dgvAxtarisNeticeleri";
            dgvAxtarisNeticeleri.ReadOnly = true;
            dgvAxtarisNeticeleri.RowHeadersVisible = false;
            dgvAxtarisNeticeleri.RowTemplate.Height = 32;
            dgvAxtarisNeticeleri.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAxtarisNeticeleri.Size = new Size(418, 398);
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
            // txtAxtaris
            // 
            txtAxtaris.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAxtaris.AnimateReadOnly = false;
            txtAxtaris.BackColor = Color.FromArgb(255, 255, 255);
            txtAxtaris.BackgroundImageLayout = ImageLayout.None;
            txtAxtaris.CharacterCasing = CharacterCasing.Normal;
            txtAxtaris.Depth = 0;
            txtAxtaris.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtAxtaris.HideSelection = true;
            txtAxtaris.Hint = "🔍 Barkod, ad və ya kod ilə axtar...";
            txtAxtaris.LeadingIcon = null;
            txtAxtaris.Location = new Point(16, 16);
            txtAxtaris.MaxLength = 32767;
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
            txtAxtaris.Size = new Size(418, 52);
            txtAxtaris.TabIndex = 0;
            txtAxtaris.TabStop = false;
            txtAxtaris.TextAlign = HorizontalAlignment.Left;
            txtAxtaris.TrailingIcon = null;
            txtAxtaris.UseSystemPasswordChar = false;
            txtAxtaris.TextChanged += txtAxtaris_TextChanged;
            // 
            // pnlQuantityControls
            // 
            pnlQuantityControls.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlQuantityControls.BackColor = Color.FromArgb(255, 255, 255);
            pnlQuantityControls.Controls.Add(txtMiqdar);
            pnlQuantityControls.Controls.Add(btnSebeteElaveEt);
            pnlQuantityControls.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlQuantityControls.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlQuantityControls.Location = new Point(16, 486);
            pnlQuantityControls.Name = "pnlQuantityControls";
            pnlQuantityControls.Size = new Size(418, 56);
            pnlQuantityControls.TabIndex = 2;
            // 
            // txtMiqdar
            // 
            txtMiqdar.AnimateReadOnly = false;
            txtMiqdar.BackColor = Color.FromArgb(255, 255, 255);
            txtMiqdar.BackgroundImageLayout = ImageLayout.None;
            txtMiqdar.CharacterCasing = CharacterCasing.Normal;
            txtMiqdar.Depth = 0;
            txtMiqdar.Font = new Font("Roboto", 16F, FontStyle.Bold, GraphicsUnit.Pixel);
            txtMiqdar.HideSelection = true;
            txtMiqdar.Hint = "Miqdar";
            txtMiqdar.LeadingIcon = null;
            txtMiqdar.Location = new Point(0, 4);
            txtMiqdar.MaxLength = 32767;
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
            txtMiqdar.Size = new Size(125, 48);
            txtMiqdar.TabIndex = 1;
            txtMiqdar.TabStop = false;
            txtMiqdar.Text = "1";
            txtMiqdar.TextAlign = HorizontalAlignment.Center;
            txtMiqdar.TrailingIcon = null;
            txtMiqdar.UseSystemPasswordChar = false;
            // 
            // btnSebeteElaveEt
            // 
            btnSebeteElaveEt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnSebeteElaveEt.AutoSize = false;
            btnSebeteElaveEt.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSebeteElaveEt.BackColor = Color.FromArgb(242, 242, 242);
            btnSebeteElaveEt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSebeteElaveEt.Depth = 0;
            btnSebeteElaveEt.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnSebeteElaveEt.HighEmphasis = true;
            btnSebeteElaveEt.Icon = null;
            btnSebeteElaveEt.Location = new Point(133, 4);
            btnSebeteElaveEt.Margin = new Padding(4, 6, 4, 6);
            btnSebeteElaveEt.MouseState = MaterialSkin.MouseState.HOVER;
            btnSebeteElaveEt.Name = "btnSebeteElaveEt";
            btnSebeteElaveEt.NoAccentTextColor = Color.Empty;
            btnSebeteElaveEt.Size = new Size(285, 48);
            btnSebeteElaveEt.TabIndex = 2;
            btnSebeteElaveEt.Text = "➕ Səbətə Əlavə Et (F7)";
            btnSebeteElaveEt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSebeteElaveEt.UseAccentColor = false;
            btnSebeteElaveEt.UseVisualStyleBackColor = false;
            btnSebeteElaveEt.Click += btnSebeteElaveEt_Click;
            // 
            // pnlCartSection
            //
            pnlCartSection.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlCartSection.BackColor = Color.FromArgb(255, 255, 255);
            pnlCartSection.Controls.Add(dgvSebet);
            pnlCartSection.Controls.Add(pnlCartControls);
            pnlCartSection.Depth = 0;
            pnlCartSection.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlCartSection.Location = new Point(458, 0);
            pnlCartSection.Margin = new Padding(0);
            pnlCartSection.MouseState = MaterialSkin.MouseState.HOVER;
            pnlCartSection.Name = "pnlCartSection";
            pnlCartSection.Padding = new Padding(16);
            pnlCartSection.Size = new Size(840, 558);
            pnlCartSection.TabIndex = 1;
            //
            // dgvSebet
            //
            dgvSebet.AllowUserToAddRows = false;
            dgvSebet.AllowUserToDeleteRows = false;
            dgvSebet.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSebet.AutoGenerateColumns = false;
            dgvSebet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(63, 81, 181);
            dataGridViewCellStyle3.Font = new Font("Roboto", 9F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(63, 81, 181);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvSebet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvSebet.ColumnHeadersHeight = 32;
            dgvSebet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvSebet.Columns.AddRange(new DataGridViewColumn[] { colSebetMehsulId, colSebetMehsulAdi, colSebetMiqdar, colSebetQiymet, colSebetUmumiMebleg });
            dgvSebet.ContextMenuStrip = contextMenuStripSebet;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Roboto", 9F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(224, 224, 224);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvSebet.DefaultCellStyle = dataGridViewCellStyle4;
            dgvSebet.EnableHeadersVisualStyles = false;
            dgvSebet.Font = new Font("Roboto", 11F, FontStyle.Regular, GraphicsUnit.Point);
            dgvSebet.GridColor = Color.FromArgb(224, 224, 224);
            dgvSebet.Location = new Point(16, 16);
            dgvSebet.Name = "dgvSebet";
            dgvSebet.RowHeadersVisible = false;
            dgvSebet.RowTemplate.Height = 36;
            dgvSebet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSebet.Size = new Size(808, 458);
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
            // pnlCartControls
            // 
            pnlCartControls.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlCartControls.BackColor = Color.FromArgb(255, 255, 255);
            pnlCartControls.Controls.Add(btnSebetdenSil);
            pnlCartControls.Controls.Add(btnSebetTemizle);
            pnlCartControls.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlCartControls.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlCartControls.Location = new Point(16, 486);
            pnlCartControls.Name = "pnlCartControls";
            pnlCartControls.Size = new Size(808, 56);
            pnlCartControls.TabIndex = 1;
            // 
            // btnSebetdenSil
            // 
            btnSebetdenSil.AutoSize = false;
            btnSebetdenSil.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSebetdenSil.BackColor = Color.FromArgb(242, 242, 242);
            btnSebetdenSil.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSebetdenSil.Depth = 0;
            btnSebetdenSil.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnSebetdenSil.HighEmphasis = true;
            btnSebetdenSil.Icon = null;
            btnSebetdenSil.Location = new Point(0, 4);
            btnSebetdenSil.Margin = new Padding(4, 6, 4, 6);
            btnSebetdenSil.MouseState = MaterialSkin.MouseState.HOVER;
            btnSebetdenSil.Name = "btnSebetdenSil";
            btnSebetdenSil.NoAccentTextColor = Color.Empty;
            btnSebetdenSil.Size = new Size(180, 48);
            btnSebetdenSil.TabIndex = 16;
            btnSebetdenSil.Text = "🗑️ Səbətdən Sil (F8)";
            btnSebetdenSil.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSebetdenSil.UseAccentColor = true;
            btnSebetdenSil.UseVisualStyleBackColor = false;
            btnSebetdenSil.Click += btnSebetdenSil_Click;
            // 
            // btnSebetTemizle
            // 
            btnSebetTemizle.AutoSize = false;
            btnSebetTemizle.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSebetTemizle.BackColor = Color.FromArgb(242, 242, 242);
            btnSebetTemizle.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSebetTemizle.Depth = 0;
            btnSebetTemizle.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnSebetTemizle.HighEmphasis = false;
            btnSebetTemizle.Icon = null;
            btnSebetTemizle.Location = new Point(188, 4);
            btnSebetTemizle.Margin = new Padding(4, 6, 4, 6);
            btnSebetTemizle.MouseState = MaterialSkin.MouseState.HOVER;
            btnSebetTemizle.Name = "btnSebetTemizle";
            btnSebetTemizle.NoAccentTextColor = Color.Empty;
            btnSebetTemizle.Size = new Size(180, 48);
            btnSebetTemizle.TabIndex = 17;
            btnSebetTemizle.Text = "🧹 Səbəti Təmizlə (F9)";
            btnSebetTemizle.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnSebetTemizle.UseAccentColor = false;
            btnSebetTemizle.UseVisualStyleBackColor = false;
            btnSebetTemizle.Click += btnSebetTemizle_Click;
            // 
            // pnlPaymentSection
            //
            pnlPaymentSection.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlPaymentSection.BackColor = Color.FromArgb(255, 255, 255);
            pnlPaymentSection.Controls.Add(lblTotalTitle);
            pnlPaymentSection.Controls.Add(lblUmumiMebleg);
            pnlPaymentSection.Controls.Add(pnlPaymentMethods);
            pnlPaymentSection.Controls.Add(pnlAdvancedOptions);
            pnlPaymentSection.Depth = 0;
            pnlPaymentSection.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlPaymentSection.Location = new Point(0, 568);
            pnlPaymentSection.Margin = new Padding(0, 10, 0, 0);
            pnlPaymentSection.MouseState = MaterialSkin.MouseState.HOVER;
            pnlPaymentSection.Name = "pnlPaymentSection";
            pnlPaymentSection.Padding = new Padding(16);
            pnlPaymentSection.Size = new Size(1298, 175);
            pnlPaymentSection.TabIndex = 2;
            // 
            // lblTotalTitle
            //
            lblTotalTitle.AutoSize = true;
            lblTotalTitle.BackColor = Color.Transparent;
            lblTotalTitle.Depth = 0;
            lblTotalTitle.Font = new Font("Roboto Medium", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTotalTitle.ForeColor = Color.FromArgb(100, 100, 100);
            lblTotalTitle.Location = new Point(16, 16);
            lblTotalTitle.MouseState = MaterialSkin.MouseState.HOVER;
            lblTotalTitle.Name = "lblTotalTitle";
            lblTotalTitle.Size = new Size(135, 19);
            lblTotalTitle.TabIndex = 4;
            lblTotalTitle.Text = "💰 ÜMUMİ MƏBLƏĞ";
            // 
            // lblUmumiMebleg
            //
            lblUmumiMebleg.AutoSize = true;
            lblUmumiMebleg.BackColor = Color.Transparent;
            lblUmumiMebleg.Depth = 0;
            lblUmumiMebleg.Font = new Font("Roboto", 52F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblUmumiMebleg.FontType = MaterialSkin.MaterialSkinManager.fontType.H3;
            lblUmumiMebleg.ForeColor = Color.FromArgb(33, 150, 243);
            lblUmumiMebleg.Location = new Point(16, 44);
            lblUmumiMebleg.MouseState = MaterialSkin.MouseState.HOVER;
            lblUmumiMebleg.Name = "lblUmumiMebleg";
            lblUmumiMebleg.Size = new Size(218, 62);
            lblUmumiMebleg.TabIndex = 0;
            lblUmumiMebleg.Text = "0.00 AZN";
            // 
            // pnlPaymentMethods
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
            pnlPaymentMethods.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlPaymentMethods.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlPaymentMethods.Location = new Point(796, 4);
            pnlPaymentMethods.Name = "pnlPaymentMethods";
            pnlPaymentMethods.Size = new Size(486, 110);
            pnlPaymentMethods.TabIndex = 2;
            // 
            // btnNagd
            // 
            btnNagd.AutoSize = false;
            btnNagd.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnNagd.BackColor = Color.FromArgb(242, 242, 242);
            btnNagd.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnNagd.Depth = 0;
            btnNagd.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnNagd.HighEmphasis = true;
            btnNagd.Icon = null;
            btnNagd.Location = new Point(0, 0);
            btnNagd.Margin = new Padding(4, 6, 4, 6);
            btnNagd.MouseState = MaterialSkin.MouseState.HOVER;
            btnNagd.Name = "btnNagd";
            btnNagd.NoAccentTextColor = Color.Empty;
            btnNagd.Size = new Size(150, 64);
            btnNagd.TabIndex = 13;
            btnNagd.Text = "💵 NAĞD (F1)";
            btnNagd.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnNagd.UseAccentColor = false;
            btnNagd.UseVisualStyleBackColor = false;
            btnNagd.Click += btnNagd_Click;
            // 
            // btnKart
            // 
            btnKart.AutoSize = false;
            btnKart.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnKart.BackColor = Color.FromArgb(242, 242, 242);
            btnKart.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnKart.Depth = 0;
            btnKart.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnKart.HighEmphasis = true;
            btnKart.Icon = null;
            btnKart.Location = new Point(158, 0);
            btnKart.Margin = new Padding(4, 6, 4, 6);
            btnKart.MouseState = MaterialSkin.MouseState.HOVER;
            btnKart.Name = "btnKart";
            btnKart.NoAccentTextColor = Color.Empty;
            btnKart.Size = new Size(150, 64);
            btnKart.TabIndex = 14;
            btnKart.Text = "💳 KART (F2)";
            btnKart.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnKart.UseAccentColor = false;
            btnKart.UseVisualStyleBackColor = false;
            btnKart.Click += btnKart_Click;
            // 
            // btnNisye
            // 
            btnNisye.AutoSize = false;
            btnNisye.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnNisye.BackColor = Color.FromArgb(242, 242, 242);
            btnNisye.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnNisye.Depth = 0;
            btnNisye.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnNisye.HighEmphasis = true;
            btnNisye.Icon = null;
            btnNisye.Location = new Point(316, 0);
            btnNisye.Margin = new Padding(4, 6, 4, 6);
            btnNisye.MouseState = MaterialSkin.MouseState.HOVER;
            btnNisye.Name = "btnNisye";
            btnNisye.NoAccentTextColor = Color.Empty;
            btnNisye.Size = new Size(170, 64);
            btnNisye.TabIndex = 15;
            btnNisye.Text = "📋 NİSYƏ (F3)";
            btnNisye.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnNisye.UseAccentColor = true;
            btnNisye.UseVisualStyleBackColor = false;
            btnNisye.Click += btnNisye_Click;
            // 
            // btn5AZN
            // 
            btn5AZN.AutoSize = false;
            btn5AZN.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn5AZN.BackColor = Color.FromArgb(242, 242, 242);
            btn5AZN.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn5AZN.Depth = 0;
            btn5AZN.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btn5AZN.HighEmphasis = true;
            btn5AZN.Icon = null;
            btn5AZN.Location = new Point(0, 72);
            btn5AZN.Margin = new Padding(4, 6, 4, 6);
            btn5AZN.MouseState = MaterialSkin.MouseState.HOVER;
            btn5AZN.Name = "btn5AZN";
            btn5AZN.NoAccentTextColor = Color.Empty;
            btn5AZN.Size = new Size(74, 34);
            btn5AZN.TabIndex = 8;
            btn5AZN.Text = "5";
            btn5AZN.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn5AZN.UseAccentColor = false;
            btn5AZN.UseVisualStyleBackColor = false;
            btn5AZN.Click += btn5AZN_Click;
            // 
            // btn10AZN
            // 
            btn10AZN.AutoSize = false;
            btn10AZN.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn10AZN.BackColor = Color.FromArgb(242, 242, 242);
            btn10AZN.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn10AZN.Depth = 0;
            btn10AZN.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btn10AZN.HighEmphasis = true;
            btn10AZN.Icon = null;
            btn10AZN.Location = new Point(82, 72);
            btn10AZN.Margin = new Padding(4, 6, 4, 6);
            btn10AZN.MouseState = MaterialSkin.MouseState.HOVER;
            btn10AZN.Name = "btn10AZN";
            btn10AZN.NoAccentTextColor = Color.Empty;
            btn10AZN.Size = new Size(74, 34);
            btn10AZN.TabIndex = 9;
            btn10AZN.Text = "10";
            btn10AZN.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn10AZN.UseAccentColor = false;
            btn10AZN.UseVisualStyleBackColor = false;
            btn10AZN.Click += btn10AZN_Click;
            // 
            // btn20AZN
            // 
            btn20AZN.AutoSize = false;
            btn20AZN.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn20AZN.BackColor = Color.FromArgb(242, 242, 242);
            btn20AZN.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn20AZN.Depth = 0;
            btn20AZN.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btn20AZN.HighEmphasis = true;
            btn20AZN.Icon = null;
            btn20AZN.Location = new Point(164, 72);
            btn20AZN.Margin = new Padding(4, 6, 4, 6);
            btn20AZN.MouseState = MaterialSkin.MouseState.HOVER;
            btn20AZN.Name = "btn20AZN";
            btn20AZN.NoAccentTextColor = Color.Empty;
            btn20AZN.Size = new Size(74, 34);
            btn20AZN.TabIndex = 10;
            btn20AZN.Text = "20";
            btn20AZN.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn20AZN.UseAccentColor = false;
            btn20AZN.UseVisualStyleBackColor = false;
            btn20AZN.Click += btn20AZN_Click;
            // 
            // btn50AZN
            // 
            btn50AZN.AutoSize = false;
            btn50AZN.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn50AZN.BackColor = Color.FromArgb(242, 242, 242);
            btn50AZN.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn50AZN.Depth = 0;
            btn50AZN.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btn50AZN.HighEmphasis = true;
            btn50AZN.Icon = null;
            btn50AZN.Location = new Point(246, 72);
            btn50AZN.Margin = new Padding(4, 6, 4, 6);
            btn50AZN.MouseState = MaterialSkin.MouseState.HOVER;
            btn50AZN.Name = "btn50AZN";
            btn50AZN.NoAccentTextColor = Color.Empty;
            btn50AZN.Size = new Size(74, 34);
            btn50AZN.TabIndex = 11;
            btn50AZN.Text = "50";
            btn50AZN.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn50AZN.UseAccentColor = false;
            btn50AZN.UseVisualStyleBackColor = false;
            btn50AZN.Click += btn50AZN_Click;
            // 
            // btn100AZN
            // 
            btn100AZN.AutoSize = false;
            btn100AZN.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn100AZN.BackColor = Color.FromArgb(242, 242, 242);
            btn100AZN.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn100AZN.Depth = 0;
            btn100AZN.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btn100AZN.HighEmphasis = true;
            btn100AZN.Icon = null;
            btn100AZN.Location = new Point(328, 72);
            btn100AZN.Margin = new Padding(4, 6, 4, 6);
            btn100AZN.MouseState = MaterialSkin.MouseState.HOVER;
            btn100AZN.Name = "btn100AZN";
            btn100AZN.NoAccentTextColor = Color.Empty;
            btn100AZN.Size = new Size(74, 34);
            btn100AZN.TabIndex = 12;
            btn100AZN.Text = "100";
            btn100AZN.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn100AZN.UseAccentColor = false;
            btn100AZN.UseVisualStyleBackColor = false;
            btn100AZN.Click += btn100AZN_Click;
            // 
            // pnlAdvancedOptions
            // 
            pnlAdvancedOptions.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlAdvancedOptions.BackColor = Color.FromArgb(255, 255, 255);
            pnlAdvancedOptions.Controls.Add(btnIndirim);
            pnlAdvancedOptions.Controls.Add(btnGozleyenSatislar);
            pnlAdvancedOptions.Controls.Add(btnYeniMusteri);
            pnlAdvancedOptions.Controls.Add(cmbMusteriler);
            pnlAdvancedOptions.Controls.Add(btnSatisiGozlet);
            pnlAdvancedOptions.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlAdvancedOptions.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlAdvancedOptions.Location = new Point(16, 118);
            pnlAdvancedOptions.Name = "pnlAdvancedOptions";
            pnlAdvancedOptions.Size = new Size(1266, 50);
            pnlAdvancedOptions.TabIndex = 3;
            // 
            // btnYeniMusteri
            // 
            btnYeniMusteri.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnYeniMusteri.AutoSize = false;
            btnYeniMusteri.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnYeniMusteri.BackColor = Color.FromArgb(242, 242, 242);
            btnYeniMusteri.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnYeniMusteri.Depth = 0;
            btnYeniMusteri.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnYeniMusteri.HighEmphasis = true;
            btnYeniMusteri.Icon = null;
            btnYeniMusteri.Location = new Point(1212, 2);
            btnYeniMusteri.Margin = new Padding(4, 6, 4, 6);
            btnYeniMusteri.MouseState = MaterialSkin.MouseState.HOVER;
            btnYeniMusteri.Name = "btnYeniMusteri";
            btnYeniMusteri.NoAccentTextColor = Color.Empty;
            btnYeniMusteri.Size = new Size(42, 40);
            btnYeniMusteri.TabIndex = 4;
            btnYeniMusteri.Text = "+";
            btnYeniMusteri.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnYeniMusteri.UseAccentColor = false;
            btnYeniMusteri.UseVisualStyleBackColor = false;
            btnYeniMusteri.Click += btnYeniMusteri_Click;
            // 
            // cmbMusteriler
            // 
            cmbMusteriler.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbMusteriler.AutoResize = false;
            cmbMusteriler.BackColor = Color.FromArgb(242, 242, 242);
            cmbMusteriler.Depth = 0;
            cmbMusteriler.DrawMode = DrawMode.OwnerDrawVariable;
            cmbMusteriler.DropDownHeight = 174;
            cmbMusteriler.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMusteriler.DropDownWidth = 121;
            cmbMusteriler.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbMusteriler.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbMusteriler.Hint = "Müştəri Seçin";
            cmbMusteriler.IntegralHeight = false;
            cmbMusteriler.ItemHeight = 43;
            cmbMusteriler.Location = new Point(805, -3);
            cmbMusteriler.MaxDropDownItems = 4;
            cmbMusteriler.MouseState = MaterialSkin.MouseState.OUT;
            cmbMusteriler.Name = "cmbMusteriler";
            cmbMusteriler.Size = new Size(400, 49);
            cmbMusteriler.StartIndex = 0;
            cmbMusteriler.TabIndex = 3;
            // 
            // btnSatisiGozlet
            // 
            btnSatisiGozlet.AutoSize = false;
            btnSatisiGozlet.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSatisiGozlet.BackColor = Color.FromArgb(242, 242, 242);
            btnSatisiGozlet.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSatisiGozlet.Depth = 0;
            btnSatisiGozlet.FlatStyle = FlatStyle.Flat;
            btnSatisiGozlet.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnSatisiGozlet.HighEmphasis = false;
            btnSatisiGozlet.Icon = null;
            btnSatisiGozlet.Location = new Point(4, 6);
            btnSatisiGozlet.Margin = new Padding(4, 6, 4, 6);
            btnSatisiGozlet.MouseState = MaterialSkin.MouseState.HOVER;
            btnSatisiGozlet.Name = "btnSatisiGozlet";
            btnSatisiGozlet.NoAccentTextColor = Color.Empty;
            btnSatisiGozlet.Size = new Size(140, 40);
            btnSatisiGozlet.TabIndex = 6;
            btnSatisiGozlet.Text = "Gözlət (F4)";
            btnSatisiGozlet.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnSatisiGozlet.UseAccentColor = false;
            btnSatisiGozlet.UseVisualStyleBackColor = false;
            btnSatisiGozlet.Click += btnSatisiGozlet_Click;
            // 
            // btnGozleyenSatislar
            // 
            btnGozleyenSatislar.AutoSize = false;
            btnGozleyenSatislar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnGozleyenSatislar.BackColor = Color.FromArgb(242, 242, 242);
            btnGozleyenSatislar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnGozleyenSatislar.Depth = 0;
            btnGozleyenSatislar.FlatStyle = FlatStyle.Flat;
            btnGozleyenSatislar.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnGozleyenSatislar.HighEmphasis = false;
            btnGozleyenSatislar.Icon = null;
            btnGozleyenSatislar.Location = new Point(152, 6);
            btnGozleyenSatislar.Margin = new Padding(4, 6, 4, 6);
            btnGozleyenSatislar.MouseState = MaterialSkin.MouseState.HOVER;
            btnGozleyenSatislar.Name = "btnGozleyenSatislar";
            btnGozleyenSatislar.NoAccentTextColor = Color.Empty;
            btnGozleyenSatislar.Size = new Size(140, 40);
            btnGozleyenSatislar.TabIndex = 7;
            btnGozleyenSatislar.Text = "Gözləyənlər (F5)";
            btnGozleyenSatislar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnGozleyenSatislar.UseAccentColor = false;
            btnGozleyenSatislar.UseVisualStyleBackColor = false;
            btnGozleyenSatislar.Click += btnGozleyenSatislar_Click;
            // 
            // btnIndirim
            // 
            btnIndirim.AutoSize = false;
            btnIndirim.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnIndirim.BackColor = Color.FromArgb(242, 242, 242);
            btnIndirim.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnIndirim.Depth = 0;
            btnIndirim.FlatStyle = FlatStyle.Flat;
            btnIndirim.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnIndirim.HighEmphasis = false;
            btnIndirim.Icon = null;
            btnIndirim.Location = new Point(300, 6);
            btnIndirim.Margin = new Padding(4, 6, 4, 6);
            btnIndirim.MouseState = MaterialSkin.MouseState.HOVER;
            btnIndirim.Name = "btnIndirim";
            btnIndirim.NoAccentTextColor = Color.Empty;
            btnIndirim.Size = new Size(140, 40);
            btnIndirim.TabIndex = 5;
            btnIndirim.Text = "ENDİRİM (F6)";
            btnIndirim.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            btnIndirim.UseAccentColor = true;
            btnIndirim.UseVisualStyleBackColor = false;
            btnIndirim.Click += btnIndirim_Click;
            // 
            // flpSuretliSatis
            //
            flpSuretliSatis.AutoScroll = true;
            flpSuretliSatis.BackColor = Color.FromArgb(250, 250, 250);
            flpSuretliSatis.Dock = DockStyle.Fill;
            flpSuretliSatis.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            flpSuretliSatis.ForeColor = Color.FromArgb(222, 0, 0, 0);
            flpSuretliSatis.Location = new Point(1307, 3);
            flpSuretliSatis.Margin = new Padding(0);
            flpSuretliSatis.Name = "flpSuretliSatis";
            flpSuretliSatis.Padding = new Padding(8);
            flpSuretliSatis.Size = new Size(444, 743);
            flpSuretliSatis.TabIndex = 1;
            // 
            // contextMenuStripGozleyenler
            // 
            contextMenuStripGozleyenler.Name = "contextMenuStripGozleyenler";
            contextMenuStripGozleyenler.Size = new Size(61, 4);
            contextMenuStripGozleyenler.ItemClicked += contextMenuStripGozleyenler_ItemClicked;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.FromArgb(242, 242, 242);
            statusStrip1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            statusStrip1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            statusStrip1.Location = new Point(3, 833);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1774, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(42, 17);
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