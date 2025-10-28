namespace AzAgroPOS.Teqdimat
{
    partial class MehsulIdareetmeFormu
    {
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MehsulIdareetmeFormu));
            splitContainer1 = new SplitContainer();
            toolTip1 = new ToolTip(components);
            dgvMehsullar = new DataGridView();
            contextMenuStripMehsullar = new ContextMenuStrip(components);
            tsmiMehsulDetallar = new ToolStripMenuItem();
            tsmiMehsulRedakteEt = new ToolStripMenuItem();
            tsmiMehsulSil = new ToolStripMenuItem();
            txtAxtar = new MaterialSkin.Controls.MaterialTextBox2();
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            tabPage2 = new TabPage();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            cmbTedarukcu = new MaterialSkin.Controls.MaterialComboBox();
            cmbBrend = new MaterialSkin.Controls.MaterialComboBox();
            cmbKateqoriya = new MaterialSkin.Controls.MaterialComboBox();
            txtMinimumStok = new MaterialSkin.Controls.MaterialTextBox2();
            btnKopyala = new MaterialSkin.Controls.MaterialButton();
            txtTekEdedSatisQiymeti = new MaterialSkin.Controls.MaterialTextBox2();
            txtTopdanSatisQiymeti = new MaterialSkin.Controls.MaterialTextBox2();
            cmbOlcuVahidi = new MaterialSkin.Controls.MaterialComboBox();
            btnYenile = new MaterialSkin.Controls.MaterialButton();
            btnElaveEt = new MaterialSkin.Controls.MaterialButton();
            btnTemizle = new MaterialSkin.Controls.MaterialButton();
            btnSil = new MaterialSkin.Controls.MaterialButton();
            btnBarkodYarat = new MaterialSkin.Controls.MaterialButton();
            btnStokKoduYarat = new MaterialSkin.Controls.MaterialButton();
            txtMevcudSay = new MaterialSkin.Controls.MaterialTextBox2();
            txtAlisQiymeti = new MaterialSkin.Controls.MaterialTextBox2();
            txtPerakendeSatisQiymeti = new MaterialSkin.Controls.MaterialTextBox2();
            txtBarkod = new MaterialSkin.Controls.MaterialTextBox2();
            txtStokKodu = new MaterialSkin.Controls.MaterialTextBox2();
            txtAd = new MaterialSkin.Controls.MaterialTextBox2();
            txtId = new TextBox();
            tabPage1 = new TabPage();
            dgvAlisTarixcesi = new DataGridView();
            contextMenuStripAlisTarixcesi = new ContextMenuStrip(components);
            tsmiAlisDetallar = new ToolStripMenuItem();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMehsullar).BeginInit();
            contextMenuStripMehsullar.SuspendLayout();
            materialTabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            materialCard1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAlisTarixcesi).BeginInit();
            contextMenuStripAlisTarixcesi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = Color.FromArgb(242, 242, 242);
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            splitContainer1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            splitContainer1.Location = new Point(3, 64);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.FromArgb(242, 242, 242);
            splitContainer1.Panel1.Controls.Add(dgvMehsullar);
            splitContainer1.Panel1.Controls.Add(txtAxtar);
            splitContainer1.Panel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            splitContainer1.Panel1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.FromArgb(242, 242, 242);
            splitContainer1.Panel2.Controls.Add(materialTabControl1);
            splitContainer1.Panel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            splitContainer1.Panel2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            splitContainer1.Size = new Size(1281, 794);
            splitContainer1.SplitterDistance = 750;
            splitContainer1.TabIndex = 0;
            // 
            // dgvMehsullar
            // 
            dgvMehsullar.AllowUserToAddRows = false;
            dgvMehsullar.AllowUserToDeleteRows = false;
            dgvMehsullar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMehsullar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMehsullar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMehsullar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMehsullar.ContextMenuStrip = contextMenuStripMehsullar;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvMehsullar.DefaultCellStyle = dataGridViewCellStyle2;
            dgvMehsullar.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvMehsullar.Location = new Point(15, 67);
            dgvMehsullar.Name = "dgvMehsullar";
            dgvMehsullar.ReadOnly = true;
            dgvMehsullar.Size = new Size(720, 713);
            dgvMehsullar.TabIndex = 1;
            dgvMehsullar.SelectionChanged += dgvMehsullar_SelectionChanged;
            // 
            // contextMenuStripMehsullar
            // 
            contextMenuStripMehsullar.Items.AddRange(new ToolStripItem[] { tsmiMehsulDetallar, tsmiMehsulRedakteEt, tsmiMehsulSil, tsmiMehsulBarkodCapEt });
            contextMenuStripMehsullar.Name = "contextMenuStripMehsullar";
            contextMenuStripMehsullar.Size = new Size(130, 92);
            // 
            // tsmiMehsulDetallar
            // 
            tsmiMehsulDetallar.Name = "tsmiMehsulDetallar";
            tsmiMehsulDetallar.Size = new Size(129, 22);
            tsmiMehsulDetallar.Text = "Detallar";
            tsmiMehsulDetallar.Click += tsmiMehsulDetallar_Click;
            // 
            // tsmiMehsulRedakteEt
            // 
            tsmiMehsulRedakteEt.Name = "tsmiMehsulRedakteEt";
            tsmiMehsulRedakteEt.Size = new Size(129, 22);
            tsmiMehsulRedakteEt.Text = "Redaktə Et";
            tsmiMehsulRedakteEt.Click += tsmiMehsulRedakteEt_Click;
            // 
            // tsmiMehsulSil
            // 
            tsmiMehsulSil.Name = "tsmiMehsulSil";
            tsmiMehsulSil.Size = new Size(129, 22);
            tsmiMehsulSil.Text = "Sil";
            tsmiMehsulSil.Click += tsmiMehsulSil_Click;
            // 
            // tsmiMehsulBarkodCapEt
            // 
            tsmiMehsulBarkodCapEt.Name = "tsmiMehsulBarkodCapEt";
            tsmiMehsulBarkodCapEt.Size = new Size(129, 22);
            tsmiMehsulBarkodCapEt.Text = "Barkod Çap Et";
            tsmiMehsulBarkodCapEt.Click += tsmiMehsulBarkodCapEt_Click;
            // 
            // txtAxtar
            // 
            txtAxtar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAxtar.AnimateReadOnly = false;
            txtAxtar.BackColor = Color.FromArgb(242, 242, 242);
            txtAxtar.BackgroundImageLayout = ImageLayout.None;
            txtAxtar.CharacterCasing = CharacterCasing.Normal;
            txtAxtar.Depth = 0;
            txtAxtar.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtAxtar.HideSelection = true;
            txtAxtar.Hint = "Məhsul axtar...";
            txtAxtar.LeadingIcon = null;
            txtAxtar.Location = new Point(15, 15);
            txtAxtar.MaxLength = 32767;
            txtAxtar.MouseState = MaterialSkin.MouseState.OUT;
            txtAxtar.Name = "txtAxtar";
            txtAxtar.PasswordChar = '\0';
            txtAxtar.PrefixSuffixText = null;
            txtAxtar.ReadOnly = false;
            txtAxtar.RightToLeft = RightToLeft.No;
            txtAxtar.SelectedText = "";
            txtAxtar.SelectionLength = 0;
            txtAxtar.SelectionStart = 0;
            txtAxtar.ShortcutsEnabled = true;
            txtAxtar.Size = new Size(720, 48);
            txtAxtar.TabIndex = 11;
            txtAxtar.TabStop = false;
            txtAxtar.TextAlign = HorizontalAlignment.Left;
            txtAxtar.TrailingIcon = null;
            txtAxtar.UseSystemPasswordChar = false;
            txtAxtar.TextChanged += txtAxtar_TextChanged;
            // 
            // materialTabControl1
            // 
            materialTabControl1.Controls.Add(tabPage2);
            materialTabControl1.Controls.Add(tabPage1);
            materialTabControl1.Depth = 0;
            materialTabControl1.Dock = DockStyle.Fill;
            materialTabControl1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialTabControl1.Location = new Point(0, 0);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(527, 794);
            materialTabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.FromArgb(242, 242, 242);
            tabPage2.Controls.Add(materialCard1);
            tabPage2.Location = new Point(4, 26);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(519, 764);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Əsas Məlumatlar";
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(cmbTedarukcu);
            materialCard1.Controls.Add(cmbBrend);
            materialCard1.Controls.Add(cmbKateqoriya);
            materialCard1.Controls.Add(txtMinimumStok);
            materialCard1.Controls.Add(btnKopyala);
            materialCard1.Controls.Add(txtTekEdedSatisQiymeti);
            materialCard1.Controls.Add(txtTopdanSatisQiymeti);
            materialCard1.Controls.Add(cmbOlcuVahidi);
            materialCard1.Controls.Add(btnYenile);
            materialCard1.Controls.Add(btnElaveEt);
            materialCard1.Controls.Add(btnTemizle);
            materialCard1.Controls.Add(btnSil);
            materialCard1.Controls.Add(btnBarkodYarat);
            materialCard1.Controls.Add(btnStokKoduYarat);
            materialCard1.Controls.Add(txtMevcudSay);
            materialCard1.Controls.Add(txtAlisQiymeti);
            materialCard1.Controls.Add(txtPerakendeSatisQiymeti);
            materialCard1.Controls.Add(txtBarkod);
            materialCard1.Controls.Add(txtStokKodu);
            materialCard1.Controls.Add(txtAd);
            materialCard1.Controls.Add(txtId);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(3, 3);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(513, 758);
            materialCard1.TabIndex = 2;
            // 
            // cmbTedarukcu
            // 
            cmbTedarukcu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbTedarukcu.AutoResize = false;
            cmbTedarukcu.BackColor = Color.FromArgb(242, 242, 242);
            cmbTedarukcu.Depth = 0;
            cmbTedarukcu.DrawMode = DrawMode.OwnerDrawVariable;
            cmbTedarukcu.DropDownHeight = 174;
            cmbTedarukcu.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTedarukcu.DropDownWidth = 121;
            cmbTedarukcu.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbTedarukcu.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbTedarukcu.Hint = "Tədarükçü";
            cmbTedarukcu.IntegralHeight = false;
            cmbTedarukcu.ItemHeight = 43;
            cmbTedarukcu.Location = new Point(18, 538);
            cmbTedarukcu.MaxDropDownItems = 4;
            cmbTedarukcu.MouseState = MaterialSkin.MouseState.OUT;
            cmbTedarukcu.Name = "cmbTedarukcu";
            cmbTedarukcu.Size = new Size(478, 49);
            cmbTedarukcu.StartIndex = 0;
            cmbTedarukcu.TabIndex = 10;
            // 
            // cmbBrend
            // 
            cmbBrend.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbBrend.AutoResize = false;
            cmbBrend.BackColor = Color.FromArgb(242, 242, 242);
            cmbBrend.Depth = 0;
            cmbBrend.DrawMode = DrawMode.OwnerDrawVariable;
            cmbBrend.DropDownHeight = 174;
            cmbBrend.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBrend.DropDownWidth = 121;
            cmbBrend.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbBrend.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbBrend.Hint = "Brend";
            cmbBrend.IntegralHeight = false;
            cmbBrend.ItemHeight = 43;
            cmbBrend.Location = new Point(18, 486);
            cmbBrend.MaxDropDownItems = 4;
            cmbBrend.MouseState = MaterialSkin.MouseState.OUT;
            cmbBrend.Name = "cmbBrend";
            cmbBrend.Size = new Size(478, 49);
            cmbBrend.StartIndex = 0;
            cmbBrend.TabIndex = 9;
            // 
            // cmbKateqoriya
            // 
            cmbKateqoriya.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbKateqoriya.AutoResize = false;
            cmbKateqoriya.BackColor = Color.FromArgb(242, 242, 242);
            cmbKateqoriya.Depth = 0;
            cmbKateqoriya.DrawMode = DrawMode.OwnerDrawVariable;
            cmbKateqoriya.DropDownHeight = 174;
            cmbKateqoriya.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKateqoriya.DropDownWidth = 121;
            cmbKateqoriya.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbKateqoriya.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbKateqoriya.Hint = "Kateqoriya";
            cmbKateqoriya.IntegralHeight = false;
            cmbKateqoriya.ItemHeight = 43;
            cmbKateqoriya.Location = new Point(18, 434);
            cmbKateqoriya.MaxDropDownItems = 4;
            cmbKateqoriya.MouseState = MaterialSkin.MouseState.OUT;
            cmbKateqoriya.Name = "cmbKateqoriya";
            cmbKateqoriya.Size = new Size(478, 49);
            cmbKateqoriya.StartIndex = 0;
            cmbKateqoriya.TabIndex = 8;
            // 
            // txtMinimumStok
            // 
            txtMinimumStok.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMinimumStok.AnimateReadOnly = false;
            txtMinimumStok.BackColor = Color.FromArgb(255, 255, 255);
            txtMinimumStok.BackgroundImageLayout = ImageLayout.None;
            txtMinimumStok.CharacterCasing = CharacterCasing.Normal;
            txtMinimumStok.Depth = 0;
            txtMinimumStok.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtMinimumStok.HideSelection = true;
            txtMinimumStok.Hint = "Minimum Stok";
            txtMinimumStok.LeadingIcon = null;
            txtMinimumStok.Location = new Point(250, 380);
            txtMinimumStok.MaxLength = 32767;
            txtMinimumStok.MouseState = MaterialSkin.MouseState.OUT;
            txtMinimumStok.Name = "txtMinimumStok";
            txtMinimumStok.PasswordChar = '\0';
            txtMinimumStok.PrefixSuffixText = null;
            txtMinimumStok.ReadOnly = false;
            txtMinimumStok.RightToLeft = RightToLeft.No;
            txtMinimumStok.SelectedText = "";
            txtMinimumStok.SelectionLength = 0;
            txtMinimumStok.SelectionStart = 0;
            txtMinimumStok.ShortcutsEnabled = true;
            txtMinimumStok.Size = new Size(246, 48);
            txtMinimumStok.TabIndex = 6;
            txtMinimumStok.TabStop = false;
            txtMinimumStok.TextAlign = HorizontalAlignment.Left;
            txtMinimumStok.TrailingIcon = null;
            txtMinimumStok.UseSystemPasswordChar = false;
            // 
            // btnKopyala
            // 
            btnKopyala.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnKopyala.AutoSize = false;
            btnKopyala.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnKopyala.BackColor = Color.FromArgb(242, 242, 242);
            btnKopyala.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnKopyala.Depth = 0;
            btnKopyala.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnKopyala.HighEmphasis = false;
            btnKopyala.Icon = null;
            btnKopyala.Location = new Point(137, 700);
            btnKopyala.Margin = new Padding(4, 6, 4, 6);
            btnKopyala.MouseState = MaterialSkin.MouseState.HOVER;
            btnKopyala.Name = "btnKopyala";
            btnKopyala.NoAccentTextColor = Color.Empty;
            btnKopyala.Size = new Size(114, 40);
            btnKopyala.TabIndex = 18;
            btnKopyala.Text = "Kopyala";
            btnKopyala.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnKopyala.UseAccentColor = false;
            btnKopyala.UseVisualStyleBackColor = false;
            btnKopyala.Click += btnKopyala_Click;
            // 
            // txtTekEdedSatisQiymeti
            // 
            txtTekEdedSatisQiymeti.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTekEdedSatisQiymeti.AnimateReadOnly = false;
            txtTekEdedSatisQiymeti.BackColor = Color.FromArgb(255, 255, 255);
            txtTekEdedSatisQiymeti.BackgroundImageLayout = ImageLayout.None;
            txtTekEdedSatisQiymeti.CharacterCasing = CharacterCasing.Normal;
            txtTekEdedSatisQiymeti.Depth = 0;
            txtTekEdedSatisQiymeti.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtTekEdedSatisQiymeti.HideSelection = true;
            txtTekEdedSatisQiymeti.Hint = "Tək Ədəd Qiyməti";
            txtTekEdedSatisQiymeti.LeadingIcon = null;
            txtTekEdedSatisQiymeti.Location = new Point(18, 324);
            txtTekEdedSatisQiymeti.MaxLength = 32767;
            txtTekEdedSatisQiymeti.MouseState = MaterialSkin.MouseState.OUT;
            txtTekEdedSatisQiymeti.Name = "txtTekEdedSatisQiymeti";
            txtTekEdedSatisQiymeti.PasswordChar = '\0';
            txtTekEdedSatisQiymeti.PrefixSuffixText = null;
            txtTekEdedSatisQiymeti.ReadOnly = false;
            txtTekEdedSatisQiymeti.RightToLeft = RightToLeft.No;
            txtTekEdedSatisQiymeti.SelectedText = "";
            txtTekEdedSatisQiymeti.SelectionLength = 0;
            txtTekEdedSatisQiymeti.SelectionStart = 0;
            txtTekEdedSatisQiymeti.ShortcutsEnabled = true;
            txtTekEdedSatisQiymeti.Size = new Size(478, 48);
            txtTekEdedSatisQiymeti.TabIndex = 4;
            txtTekEdedSatisQiymeti.TabStop = false;
            txtTekEdedSatisQiymeti.TextAlign = HorizontalAlignment.Left;
            txtTekEdedSatisQiymeti.TrailingIcon = null;
            txtTekEdedSatisQiymeti.UseSystemPasswordChar = false;
            // 
            // txtTopdanSatisQiymeti
            // 
            txtTopdanSatisQiymeti.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTopdanSatisQiymeti.AnimateReadOnly = false;
            txtTopdanSatisQiymeti.BackColor = Color.FromArgb(255, 255, 255);
            txtTopdanSatisQiymeti.BackgroundImageLayout = ImageLayout.None;
            txtTopdanSatisQiymeti.CharacterCasing = CharacterCasing.Normal;
            txtTopdanSatisQiymeti.Depth = 0;
            txtTopdanSatisQiymeti.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtTopdanSatisQiymeti.HideSelection = true;
            txtTopdanSatisQiymeti.Hint = "Topdan Satış Qiyməti";
            txtTopdanSatisQiymeti.LeadingIcon = null;
            txtTopdanSatisQiymeti.Location = new Point(18, 270);
            txtTopdanSatisQiymeti.MaxLength = 32767;
            txtTopdanSatisQiymeti.MouseState = MaterialSkin.MouseState.OUT;
            txtTopdanSatisQiymeti.Name = "txtTopdanSatisQiymeti";
            txtTopdanSatisQiymeti.PasswordChar = '\0';
            txtTopdanSatisQiymeti.PrefixSuffixText = null;
            txtTopdanSatisQiymeti.ReadOnly = false;
            txtTopdanSatisQiymeti.RightToLeft = RightToLeft.No;
            txtTopdanSatisQiymeti.SelectedText = "";
            txtTopdanSatisQiymeti.SelectionLength = 0;
            txtTopdanSatisQiymeti.SelectionStart = 0;
            txtTopdanSatisQiymeti.ShortcutsEnabled = true;
            txtTopdanSatisQiymeti.Size = new Size(478, 48);
            txtTopdanSatisQiymeti.TabIndex = 3;
            txtTopdanSatisQiymeti.TabStop = false;
            txtTopdanSatisQiymeti.TextAlign = HorizontalAlignment.Left;
            txtTopdanSatisQiymeti.TrailingIcon = null;
            txtTopdanSatisQiymeti.UseSystemPasswordChar = false;
            // 
            // cmbOlcuVahidi
            // 
            cmbOlcuVahidi.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbOlcuVahidi.AutoResize = false;
            cmbOlcuVahidi.BackColor = Color.FromArgb(242, 242, 242);
            cmbOlcuVahidi.Depth = 0;
            cmbOlcuVahidi.DrawMode = DrawMode.OwnerDrawVariable;
            cmbOlcuVahidi.DropDownHeight = 174;
            cmbOlcuVahidi.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbOlcuVahidi.DropDownWidth = 121;
            cmbOlcuVahidi.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbOlcuVahidi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbOlcuVahidi.Hint = "Ölçü Vahidi";
            cmbOlcuVahidi.IntegralHeight = false;
            cmbOlcuVahidi.ItemHeight = 43;
            cmbOlcuVahidi.Location = new Point(18, 380);
            cmbOlcuVahidi.MaxDropDownItems = 4;
            cmbOlcuVahidi.MouseState = MaterialSkin.MouseState.OUT;
            cmbOlcuVahidi.Name = "cmbOlcuVahidi";
            cmbOlcuVahidi.Size = new Size(226, 49);
            cmbOlcuVahidi.StartIndex = 0;
            cmbOlcuVahidi.TabIndex = 7;
            // 
            // btnYenile
            // 
            btnYenile.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnYenile.AutoSize = false;
            btnYenile.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnYenile.BackColor = Color.FromArgb(242, 242, 242);
            btnYenile.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnYenile.Depth = 0;
            btnYenile.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnYenile.HighEmphasis = true;
            btnYenile.Icon = null;
            btnYenile.Location = new Point(258, 700);
            btnYenile.Margin = new Padding(4, 6, 4, 6);
            btnYenile.MouseState = MaterialSkin.MouseState.HOVER;
            btnYenile.Name = "btnYenile";
            btnYenile.NoAccentTextColor = Color.Empty;
            btnYenile.Size = new Size(236, 40);
            btnYenile.TabIndex = 15;
            btnYenile.Text = "Yenilə";
            btnYenile.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnYenile.UseAccentColor = false;
            btnYenile.UseVisualStyleBackColor = false;
            btnYenile.Click += btnYenile_Click;
            // 
            // btnElaveEt
            // 
            btnElaveEt.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnElaveEt.AutoSize = false;
            btnElaveEt.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnElaveEt.BackColor = Color.FromArgb(242, 242, 242);
            btnElaveEt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnElaveEt.Depth = 0;
            btnElaveEt.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnElaveEt.HighEmphasis = true;
            btnElaveEt.Icon = null;
            btnElaveEt.Location = new Point(18, 700);
            btnElaveEt.Margin = new Padding(4, 6, 4, 6);
            btnElaveEt.MouseState = MaterialSkin.MouseState.HOVER;
            btnElaveEt.Name = "btnElaveEt";
            btnElaveEt.NoAccentTextColor = Color.Empty;
            btnElaveEt.Size = new Size(111, 40);
            btnElaveEt.TabIndex = 14;
            btnElaveEt.Text = "Əlavə Et";
            btnElaveEt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnElaveEt.UseAccentColor = false;
            btnElaveEt.UseVisualStyleBackColor = false;
            btnElaveEt.Click += btnElaveEt_Click;
            // 
            // btnTemizle
            // 
            btnTemizle.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnTemizle.AutoSize = false;
            btnTemizle.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnTemizle.BackColor = Color.FromArgb(242, 242, 242);
            btnTemizle.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnTemizle.Depth = 0;
            btnTemizle.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnTemizle.HighEmphasis = true;
            btnTemizle.Icon = null;
            btnTemizle.Location = new Point(258, 648);
            btnTemizle.Margin = new Padding(4, 6, 4, 6);
            btnTemizle.MouseState = MaterialSkin.MouseState.HOVER;
            btnTemizle.Name = "btnTemizle";
            btnTemizle.NoAccentTextColor = Color.Empty;
            btnTemizle.Size = new Size(236, 40);
            btnTemizle.TabIndex = 17;
            btnTemizle.Text = "Təmizlə";
            btnTemizle.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnTemizle.UseAccentColor = false;
            btnTemizle.UseVisualStyleBackColor = false;
            btnTemizle.Click += btnTemizle_Click;
            // 
            // btnIxracEt
            // 
            btnIxracEt.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnIxracEt.AutoSize = false;
            btnIxracEt.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnIxracEt.BackColor = Color.FromArgb(242, 242, 242);
            btnIxracEt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnIxracEt.Depth = 0;
            btnIxracEt.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnIxracEt.HighEmphasis = true;
            btnIxracEt.Icon = null;
            btnIxracEt.Location = new Point(18, 700);
            btnIxracEt.Margin = new Padding(4, 6, 4, 6);
            btnIxracEt.MouseState = MaterialSkin.MouseState.HOVER;
            btnIxracEt.Name = "btnIxracEt";
            btnIxracEt.NoAccentTextColor = Color.Empty;
            btnIxracEt.Size = new Size(150, 40);
            btnIxracEt.TabIndex = 18;
            btnIxracEt.Text = "Excel-ə İxrac Et";
            btnIxracEt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnIxracEt.UseAccentColor = true;
            btnIxracEt.UseVisualStyleBackColor = false;
            btnIxracEt.Click += btnIxracEt_Click;
            // 
            // btnSil
            // 
            btnSil.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnSil.AutoSize = false;
            btnSil.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSil.BackColor = Color.FromArgb(242, 242, 242);
            btnSil.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSil.Depth = 0;
            btnSil.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnSil.HighEmphasis = true;
            btnSil.Icon = null;
            btnSil.Location = new Point(18, 648);
            btnSil.Margin = new Padding(4, 6, 4, 6);
            btnSil.MouseState = MaterialSkin.MouseState.HOVER;
            btnSil.Name = "btnSil";
            btnSil.NoAccentTextColor = Color.Empty;
            btnSil.Size = new Size(232, 40);
            btnSil.TabIndex = 16;
            btnSil.Text = "Sil";
            btnSil.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSil.UseAccentColor = false;
            btnSil.UseVisualStyleBackColor = false;
            btnSil.Click += btnSil_Click;
            // 
            // btnBarkodYarat
            // 
            btnBarkodYarat.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBarkodYarat.AutoSize = false;
            btnBarkodYarat.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBarkodYarat.BackColor = Color.FromArgb(242, 242, 242);
            btnBarkodYarat.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnBarkodYarat.Depth = 0;
            btnBarkodYarat.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnBarkodYarat.HighEmphasis = true;
            btnBarkodYarat.Icon = null;
            btnBarkodYarat.Location = new Point(421, 112);
            btnBarkodYarat.Margin = new Padding(4, 6, 4, 6);
            btnBarkodYarat.MouseState = MaterialSkin.MouseState.HOVER;
            btnBarkodYarat.Name = "btnBarkodYarat";
            btnBarkodYarat.NoAccentTextColor = Color.Empty;
            btnBarkodYarat.Size = new Size(75, 40);
            btnBarkodYarat.TabIndex = 13;
            btnBarkodYarat.Text = "Yarat";
            btnBarkodYarat.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnBarkodYarat.UseAccentColor = false;
            btnBarkodYarat.UseVisualStyleBackColor = false;
            btnBarkodYarat.Click += btnBarkodYarat_Click;
            // 
            // btnStokKoduYarat
            // 
            btnStokKoduYarat.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnStokKoduYarat.AutoSize = false;
            btnStokKoduYarat.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnStokKoduYarat.BackColor = Color.FromArgb(242, 242, 242);
            btnStokKoduYarat.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnStokKoduYarat.Depth = 0;
            btnStokKoduYarat.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnStokKoduYarat.HighEmphasis = true;
            btnStokKoduYarat.Icon = null;
            btnStokKoduYarat.Location = new Point(421, 58);
            btnStokKoduYarat.Margin = new Padding(4, 6, 4, 6);
            btnStokKoduYarat.MouseState = MaterialSkin.MouseState.HOVER;
            btnStokKoduYarat.Name = "btnStokKoduYarat";
            btnStokKoduYarat.NoAccentTextColor = Color.Empty;
            btnStokKoduYarat.Size = new Size(75, 40);
            btnStokKoduYarat.TabIndex = 12;
            btnStokKoduYarat.Text = "Yarat";
            btnStokKoduYarat.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnStokKoduYarat.UseAccentColor = false;
            btnStokKoduYarat.UseVisualStyleBackColor = false;
            btnStokKoduYarat.Click += btnStokKoduYarat_Click;
            // 
            // txtMevcudSay
            // 
            txtMevcudSay.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMevcudSay.AnimateReadOnly = false;
            txtMevcudSay.BackColor = Color.FromArgb(255, 255, 255);
            txtMevcudSay.BackgroundImageLayout = ImageLayout.None;
            txtMevcudSay.CharacterCasing = CharacterCasing.Normal;
            txtMevcudSay.Depth = 0;
            txtMevcudSay.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtMevcudSay.HideSelection = true;
            txtMevcudSay.Hint = "Mövcud Say";
            txtMevcudSay.LeadingIcon = null;
            txtMevcudSay.Location = new Point(18, 162);
            txtMevcudSay.MaxLength = 32767;
            txtMevcudSay.MouseState = MaterialSkin.MouseState.OUT;
            txtMevcudSay.Name = "txtMevcudSay";
            txtMevcudSay.PasswordChar = '\0';
            txtMevcudSay.PrefixSuffixText = null;
            txtMevcudSay.ReadOnly = false;
            txtMevcudSay.RightToLeft = RightToLeft.No;
            txtMevcudSay.SelectedText = "";
            txtMevcudSay.SelectionLength = 0;
            txtMevcudSay.SelectionStart = 0;
            txtMevcudSay.ShortcutsEnabled = true;
            txtMevcudSay.Size = new Size(478, 48);
            txtMevcudSay.TabIndex = 5;
            txtMevcudSay.TabStop = false;
            txtMevcudSay.TextAlign = HorizontalAlignment.Left;
            txtMevcudSay.TrailingIcon = null;
            txtMevcudSay.UseSystemPasswordChar = false;
            // 
            // txtAlisQiymeti
            // 
            txtAlisQiymeti.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAlisQiymeti.AnimateReadOnly = false;
            txtAlisQiymeti.BackColor = Color.FromArgb(255, 255, 255);
            txtAlisQiymeti.BackgroundImageLayout = ImageLayout.None;
            txtAlisQiymeti.CharacterCasing = CharacterCasing.Normal;
            txtAlisQiymeti.Depth = 0;
            txtAlisQiymeti.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtAlisQiymeti.HideSelection = true;
            txtAlisQiymeti.Hint = "Alış Qiyməti";
            txtAlisQiymeti.LeadingIcon = null;
            txtAlisQiymeti.Location = new Point(18, 326);
            txtAlisQiymeti.MaxLength = 32767;
            txtAlisQiymeti.MouseState = MaterialSkin.MouseState.OUT;
            txtAlisQiymeti.Name = "txtAlisQiymeti";
            txtAlisQiymeti.PasswordChar = '\0';
            txtAlisQiymeti.PrefixSuffixText = null;
            txtAlisQiymeti.ReadOnly = false;
            txtAlisQiymeti.RightToLeft = RightToLeft.No;
            txtAlisQiymeti.SelectedText = "";
            txtAlisQiymeti.SelectionLength = 0;
            txtAlisQiymeti.SelectionStart = 0;
            txtAlisQiymeti.ShortcutsEnabled = true;
            txtAlisQiymeti.Size = new Size(226, 48);
            txtAlisQiymeti.TabIndex = 2;
            txtAlisQiymeti.TabStop = false;
            txtAlisQiymeti.TextAlign = HorizontalAlignment.Left;
            txtAlisQiymeti.TrailingIcon = null;
            txtAlisQiymeti.UseSystemPasswordChar = false;
            // 
            // txtPerakendeSatisQiymeti
            // 
            txtPerakendeSatisQiymeti.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPerakendeSatisQiymeti.AnimateReadOnly = false;
            txtPerakendeSatisQiymeti.BackColor = Color.FromArgb(255, 255, 255);
            txtPerakendeSatisQiymeti.BackgroundImageLayout = ImageLayout.None;
            txtPerakendeSatisQiymeti.CharacterCasing = CharacterCasing.Normal;
            txtPerakendeSatisQiymeti.Depth = 0;
            txtPerakendeSatisQiymeti.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtPerakendeSatisQiymeti.HideSelection = true;
            txtPerakendeSatisQiymeti.Hint = "Pərakəndə Satış Qiyməti";
            txtPerakendeSatisQiymeti.LeadingIcon = null;
            txtPerakendeSatisQiymeti.Location = new Point(18, 216);
            txtPerakendeSatisQiymeti.MaxLength = 32767;
            txtPerakendeSatisQiymeti.MouseState = MaterialSkin.MouseState.OUT;
            txtPerakendeSatisQiymeti.Name = "txtPerakendeSatisQiymeti";
            txtPerakendeSatisQiymeti.PasswordChar = '\0';
            txtPerakendeSatisQiymeti.PrefixSuffixText = null;
            txtPerakendeSatisQiymeti.ReadOnly = false;
            txtPerakendeSatisQiymeti.RightToLeft = RightToLeft.No;
            txtPerakendeSatisQiymeti.SelectedText = "";
            txtPerakendeSatisQiymeti.SelectionLength = 0;
            txtPerakendeSatisQiymeti.SelectionStart = 0;
            txtPerakendeSatisQiymeti.ShortcutsEnabled = true;
            txtPerakendeSatisQiymeti.Size = new Size(478, 48);
            txtPerakendeSatisQiymeti.TabIndex = 4;
            txtPerakendeSatisQiymeti.TabStop = false;
            txtPerakendeSatisQiymeti.TextAlign = HorizontalAlignment.Left;
            txtPerakendeSatisQiymeti.TrailingIcon = null;
            txtPerakendeSatisQiymeti.UseSystemPasswordChar = false;
            // 
            // txtBarkod
            // 
            txtBarkod.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBarkod.AnimateReadOnly = false;
            txtBarkod.BackColor = Color.FromArgb(255, 255, 255);
            txtBarkod.BackgroundImageLayout = ImageLayout.None;
            txtBarkod.CharacterCasing = CharacterCasing.Normal;
            txtBarkod.Depth = 0;
            txtBarkod.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtBarkod.HideSelection = true;
            txtBarkod.Hint = "Barkod";
            txtBarkod.LeadingIcon = null;
            txtBarkod.Location = new Point(18, 108);
            txtBarkod.MaxLength = 32767;
            txtBarkod.MouseState = MaterialSkin.MouseState.OUT;
            txtBarkod.Name = "txtBarkod";
            txtBarkod.PasswordChar = '\0';
            txtBarkod.PrefixSuffixText = null;
            txtBarkod.ReadOnly = false;
            txtBarkod.RightToLeft = RightToLeft.No;
            txtBarkod.SelectedText = "";
            txtBarkod.SelectionLength = 0;
            txtBarkod.SelectionStart = 0;
            txtBarkod.ShortcutsEnabled = true;
            txtBarkod.Size = new Size(396, 48);
            txtBarkod.TabIndex = 0;
            txtBarkod.TabStop = false;
            txtBarkod.TextAlign = HorizontalAlignment.Left;
            txtBarkod.TrailingIcon = null;
            txtBarkod.UseSystemPasswordChar = false;
            // 
            // txtStokKodu
            // 
            txtStokKodu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtStokKodu.AnimateReadOnly = false;
            txtStokKodu.BackColor = Color.FromArgb(255, 255, 255);
            txtStokKodu.BackgroundImageLayout = ImageLayout.None;
            txtStokKodu.CharacterCasing = CharacterCasing.Normal;
            txtStokKodu.Depth = 0;
            txtStokKodu.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtStokKodu.HideSelection = true;
            txtStokKodu.Hint = "Stok Kodu";
            txtStokKodu.LeadingIcon = null;
            txtStokKodu.Location = new Point(18, 54);
            txtStokKodu.MaxLength = 32767;
            txtStokKodu.MouseState = MaterialSkin.MouseState.OUT;
            txtStokKodu.Name = "txtStokKodu";
            txtStokKodu.PasswordChar = '\0';
            txtStokKodu.PrefixSuffixText = null;
            txtStokKodu.ReadOnly = false;
            txtStokKodu.RightToLeft = RightToLeft.No;
            txtStokKodu.SelectedText = "";
            txtStokKodu.SelectionLength = 0;
            txtStokKodu.SelectionStart = 0;
            txtStokKodu.ShortcutsEnabled = true;
            txtStokKodu.Size = new Size(396, 48);
            txtStokKodu.TabIndex = 1;
            txtStokKodu.TabStop = false;
            txtStokKodu.TextAlign = HorizontalAlignment.Left;
            txtStokKodu.TrailingIcon = null;
            txtStokKodu.UseSystemPasswordChar = false;
            // 
            // txtAd
            // 
            txtAd.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAd.AnimateReadOnly = false;
            txtAd.BackColor = Color.FromArgb(255, 255, 255);
            txtAd.BackgroundImageLayout = ImageLayout.None;
            txtAd.CharacterCasing = CharacterCasing.Normal;
            txtAd.Depth = 0;
            txtAd.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtAd.HideSelection = true;
            txtAd.Hint = "Ad";
            txtAd.LeadingIcon = null;
            txtAd.Location = new Point(18, 0);
            txtAd.MaxLength = 32767;
            txtAd.MouseState = MaterialSkin.MouseState.OUT;
            txtAd.Name = "txtAd";
            txtAd.PasswordChar = '\0';
            txtAd.PrefixSuffixText = null;
            txtAd.ReadOnly = false;
            txtAd.RightToLeft = RightToLeft.No;
            txtAd.SelectedText = "";
            txtAd.SelectionLength = 0;
            txtAd.SelectionStart = 0;
            txtAd.ShortcutsEnabled = true;
            txtAd.Size = new Size(478, 48);
            txtAd.TabIndex = 1;
            txtAd.TabStop = false;
            txtAd.TextAlign = HorizontalAlignment.Left;
            txtAd.TrailingIcon = null;
            txtAd.UseSystemPasswordChar = false;
            // 
            // txtId
            // 
            txtId.BackColor = Color.FromArgb(255, 255, 255);
            txtId.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtId.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtId.Location = new Point(18, 558);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 24);
            txtId.TabIndex = 20;
            txtId.Visible = false;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.FromArgb(242, 242, 242);
            tabPage1.Controls.Add(dgvAlisTarixcesi);
            tabPage1.Location = new Point(4, 26);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(519, 764);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "Alış Tarixçəsi";
            // 
            // dgvAlisTarixcesi
            // 
            dgvAlisTarixcesi.AllowUserToAddRows = false;
            dgvAlisTarixcesi.AllowUserToDeleteRows = false;
            dgvAlisTarixcesi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvAlisTarixcesi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvAlisTarixcesi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAlisTarixcesi.ContextMenuStrip = contextMenuStripAlisTarixcesi;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvAlisTarixcesi.DefaultCellStyle = dataGridViewCellStyle4;
            dgvAlisTarixcesi.Dock = DockStyle.Fill;
            dgvAlisTarixcesi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvAlisTarixcesi.Location = new Point(3, 3);
            dgvAlisTarixcesi.Name = "dgvAlisTarixcesi";
            dgvAlisTarixcesi.ReadOnly = true;
            dgvAlisTarixcesi.Size = new Size(513, 758);
            dgvAlisTarixcesi.TabIndex = 0;
            // 
            // contextMenuStripAlisTarixcesi
            // 
            contextMenuStripAlisTarixcesi.Items.AddRange(new ToolStripItem[] { tsmiAlisDetallar });
            contextMenuStripAlisTarixcesi.Name = "contextMenuStripAlisTarixcesi";
            contextMenuStripAlisTarixcesi.Size = new Size(115, 26);
            // 
            // tsmiAlisDetallar
            // 
            tsmiAlisDetallar.Name = "tsmiAlisDetallar";
            tsmiAlisDetallar.Size = new Size(114, 22);
            tsmiAlisDetallar.Text = "Detallar";
            tsmiAlisDetallar.Click += tsmiAlisDetallar_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // MehsulIdareetmeFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1287, 861);
            Controls.Add(splitContainer1);
            Name = "MehsulIdareetmeFormu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Məhsul İdarəetməsi";
            Load += MehsulIdareetmeFormu_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMehsullar).EndInit();
            contextMenuStripMehsullar.ResumeLayout(false);
            materialTabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAlisTarixcesi).EndInit();
            contextMenuStripAlisTarixcesi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvMehsullar;
        private MaterialSkin.Controls.MaterialTextBox2 txtAxtar;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialButton btnKopyala;
        private MaterialSkin.Controls.MaterialTextBox2 txtTekEdedSatisQiymeti;
        private MaterialSkin.Controls.MaterialTextBox2 txtTopdanSatisQiymeti;
        private MaterialSkin.Controls.MaterialComboBox cmbOlcuVahidi;
        private MaterialSkin.Controls.MaterialButton btnYenile;
        private MaterialSkin.Controls.MaterialButton btnElaveEt;
        private MaterialSkin.Controls.MaterialButton btnTemizle;
        private MaterialSkin.Controls.MaterialButton btnSil;
        private MaterialSkin.Controls.MaterialButton btnBarkodYarat;
        private MaterialSkin.Controls.MaterialButton btnStokKoduYarat;
        private MaterialSkin.Controls.MaterialTextBox2 txtMevcudSay;
        private MaterialSkin.Controls.MaterialTextBox2 txtAlisQiymeti;
        private MaterialSkin.Controls.MaterialTextBox2 txtPerakendeSatisQiymeti;
        private MaterialSkin.Controls.MaterialTextBox2 txtBarkod;
        private MaterialSkin.Controls.MaterialTextBox2 txtStokKodu;
        private MaterialSkin.Controls.MaterialTextBox2 txtAd;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvAlisTarixcesi;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMehsullar;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripAlisTarixcesi;
        private System.Windows.Forms.ToolStripMenuItem tsmiMehsulDetallar;
        private System.Windows.Forms.ToolStripMenuItem tsmiMehsulRedakteEt;
        private System.Windows.Forms.ToolStripMenuItem tsmiMehsulSil;
        private System.Windows.Forms.ToolStripMenuItem tsmiMehsulBarkodCapEt;
        private System.Windows.Forms.ToolStripMenuItem tsmiAlisDetallar;
        private MaterialSkin.Controls.MaterialTextBox2 txtMinimumStok;
        private MaterialSkin.Controls.MaterialComboBox cmbKateqoriya;
        private MaterialSkin.Controls.MaterialComboBox cmbBrend;
        private MaterialSkin.Controls.MaterialComboBox cmbTedarukcu;
        private ErrorProvider errorProvider1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolTip toolTip1;
        private MaterialSkin.Controls.MaterialButton btnIxracEt;
    }
}
