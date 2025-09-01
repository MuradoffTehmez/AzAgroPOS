namespace AzAgroPOS.Teqdimat
{
    partial class MehsulIdareetmeFormu
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            splitContainer1 = new SplitContainer();
            dgvMehsullar = new DataGridView();
            txtAxtar = new MaterialSkin.Controls.MaterialTextBox2();
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            tabPage2 = new TabPage();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
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
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMehsullar).BeginInit();
            materialTabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            materialCard1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAlisTarixcesi).BeginInit();
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
            splitContainer1.Size = new Size(1281, 671);
            splitContainer1.SplitterDistance = 750;
            splitContainer1.TabIndex = 0;
            // 
            // dgvMehsullar
            // 
            dgvMehsullar.AllowUserToAddRows = false;
            dgvMehsullar.AllowUserToDeleteRows = false;
            dgvMehsullar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMehsullar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvMehsullar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvMehsullar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvMehsullar.DefaultCellStyle = dataGridViewCellStyle6;
            dgvMehsullar.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvMehsullar.Location = new Point(3, 57);
            dgvMehsullar.MultiSelect = false;
            dgvMehsullar.Name = "dgvMehsullar";
            dgvMehsullar.ReadOnly = true;
            dgvMehsullar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMehsullar.Size = new Size(744, 611);
            dgvMehsullar.TabIndex = 1;
            dgvMehsullar.SelectionChanged += dgvMehsullar_SelectionChanged;
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
            txtAxtar.Hint = "Məhsul Siyahısında Axtar...";
            txtAxtar.LeadingIcon = null;
            txtAxtar.Location = new Point(3, 3);
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
            txtAxtar.Size = new Size(744, 48);
            txtAxtar.TabIndex = 0;
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
            materialTabControl1.Size = new Size(527, 671);
            materialTabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.FromArgb(242, 242, 242);
            tabPage2.Controls.Add(materialCard1);
            tabPage2.Location = new Point(4, 26);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(519, 641);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Əsas Məlumatlar";
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
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
            materialCard1.Size = new Size(513, 635);
            materialCard1.TabIndex = 2;
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
            btnKopyala.Location = new Point(137, 577);
            btnKopyala.Margin = new Padding(4, 6, 4, 6);
            btnKopyala.MouseState = MaterialSkin.MouseState.HOVER;
            btnKopyala.Name = "btnKopyala";
            btnKopyala.NoAccentTextColor = Color.Empty;
            btnKopyala.Size = new Size(114, 40);
            btnKopyala.TabIndex = 19;
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
            txtTekEdedSatisQiymeti.TabIndex = 18;
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
            txtTopdanSatisQiymeti.TabIndex = 17;
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
            cmbOlcuVahidi.Location = new Point(18, 432);
            cmbOlcuVahidi.MaxDropDownItems = 4;
            cmbOlcuVahidi.MouseState = MaterialSkin.MouseState.OUT;
            cmbOlcuVahidi.Name = "cmbOlcuVahidi";
            cmbOlcuVahidi.Size = new Size(478, 49);
            cmbOlcuVahidi.StartIndex = 0;
            cmbOlcuVahidi.TabIndex = 16;
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
            btnYenile.Location = new Point(258, 525);
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
            btnElaveEt.Location = new Point(18, 525);
            btnElaveEt.Margin = new Padding(4, 6, 4, 6);
            btnElaveEt.MouseState = MaterialSkin.MouseState.HOVER;
            btnElaveEt.Name = "btnElaveEt";
            btnElaveEt.NoAccentTextColor = Color.Empty;
            btnElaveEt.Size = new Size(233, 40);
            btnElaveEt.TabIndex = 14;
            btnElaveEt.Text = "Yeni Məhsulu Yadda Saxla";
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
            btnTemizle.HighEmphasis = false;
            btnTemizle.Icon = null;
            btnTemizle.Location = new Point(258, 577);
            btnTemizle.Margin = new Padding(4, 6, 4, 6);
            btnTemizle.MouseState = MaterialSkin.MouseState.HOVER;
            btnTemizle.Name = "btnTemizle";
            btnTemizle.NoAccentTextColor = Color.Empty;
            btnTemizle.Size = new Size(236, 40);
            btnTemizle.TabIndex = 13;
            btnTemizle.Text = "Formu Təmizlə";
            btnTemizle.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnTemizle.UseAccentColor = false;
            btnTemizle.UseVisualStyleBackColor = false;
            btnTemizle.Click += btnTemizle_Click;
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
            btnSil.Location = new Point(18, 577);
            btnSil.Margin = new Padding(4, 6, 4, 6);
            btnSil.MouseState = MaterialSkin.MouseState.HOVER;
            btnSil.Name = "btnSil";
            btnSil.NoAccentTextColor = Color.Empty;
            btnSil.Size = new Size(111, 40);
            btnSil.TabIndex = 9;
            btnSil.Text = "Seçilmişi Sil";
            btnSil.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSil.UseAccentColor = true;
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
            btnBarkodYarat.HighEmphasis = false;
            btnBarkodYarat.Icon = null;
            btnBarkodYarat.Location = new Point(380, 162);
            btnBarkodYarat.Margin = new Padding(4, 6, 4, 6);
            btnBarkodYarat.MouseState = MaterialSkin.MouseState.HOVER;
            btnBarkodYarat.Name = "btnBarkodYarat";
            btnBarkodYarat.NoAccentTextColor = Color.Empty;
            btnBarkodYarat.Size = new Size(102, 36);
            btnBarkodYarat.TabIndex = 12;
            btnBarkodYarat.Text = "Yarat";
            btnBarkodYarat.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
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
            btnStokKoduYarat.HighEmphasis = false;
            btnStokKoduYarat.Icon = null;
            btnStokKoduYarat.Location = new Point(380, 90);
            btnStokKoduYarat.Margin = new Padding(4, 6, 4, 6);
            btnStokKoduYarat.MouseState = MaterialSkin.MouseState.HOVER;
            btnStokKoduYarat.Name = "btnStokKoduYarat";
            btnStokKoduYarat.NoAccentTextColor = Color.Empty;
            btnStokKoduYarat.Size = new Size(102, 36);
            btnStokKoduYarat.TabIndex = 11;
            btnStokKoduYarat.Text = "Yarat";
            btnStokKoduYarat.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
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
            txtMevcudSay.Location = new Point(252, 378);
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
            txtMevcudSay.Size = new Size(230, 48);
            txtMevcudSay.TabIndex = 6;
            txtMevcudSay.TabStop = false;
            txtMevcudSay.TextAlign = HorizontalAlignment.Left;
            txtMevcudSay.TrailingIcon = null;
            txtMevcudSay.UseSystemPasswordChar = false;
            // 
            // txtAlisQiymeti
            // 
            txtAlisQiymeti.AnimateReadOnly = false;
            txtAlisQiymeti.BackColor = Color.FromArgb(255, 255, 255);
            txtAlisQiymeti.BackgroundImageLayout = ImageLayout.None;
            txtAlisQiymeti.CharacterCasing = CharacterCasing.Normal;
            txtAlisQiymeti.Depth = 0;
            txtAlisQiymeti.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtAlisQiymeti.HideSelection = true;
            txtAlisQiymeti.Hint = "Alış Qiyməti";
            txtAlisQiymeti.LeadingIcon = null;
            txtAlisQiymeti.Location = new Point(18, 378);
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
            txtAlisQiymeti.TabIndex = 5;
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
            txtPerakendeSatisQiymeti.Size = new Size(464, 48);
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
            txtBarkod.Location = new Point(18, 156);
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
            txtBarkod.Size = new Size(345, 48);
            txtBarkod.TabIndex = 3;
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
            txtStokKodu.Hint = "Stok Kodu (SKU)";
            txtStokKodu.LeadingIcon = null;
            txtStokKodu.Location = new Point(18, 88);
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
            txtStokKodu.Size = new Size(345, 48);
            txtStokKodu.TabIndex = 2;
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
            txtAd.Hint = "Məhsulun Adı";
            txtAd.LeadingIcon = null;
            txtAd.Location = new Point(18, 28);
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
            txtAd.Size = new Size(464, 48);
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
            txtId.TabIndex = 0;
            txtId.Visible = false;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.FromArgb(242, 242, 242);
            tabPage1.Controls.Add(dgvAlisTarixcesi);
            tabPage1.Location = new Point(4, 26);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(519, 641);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "Alış Tarixçəsi";
            // 
            // dgvAlisTarixcesi
            // 
            dgvAlisTarixcesi.AllowUserToAddRows = false;
            dgvAlisTarixcesi.AllowUserToDeleteRows = false;
            dgvAlisTarixcesi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = SystemColors.Control;
            dataGridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvAlisTarixcesi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvAlisTarixcesi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dgvAlisTarixcesi.DefaultCellStyle = dataGridViewCellStyle8;
            dgvAlisTarixcesi.Dock = DockStyle.Fill;
            dgvAlisTarixcesi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvAlisTarixcesi.Location = new Point(3, 3);
            dgvAlisTarixcesi.Name = "dgvAlisTarixcesi";
            dgvAlisTarixcesi.ReadOnly = true;
            dgvAlisTarixcesi.Size = new Size(513, 635);
            dgvAlisTarixcesi.TabIndex = 0;
            // 
            // MehsulIdareetmeFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1287, 738);
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
            materialTabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAlisTarixcesi).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvMehsullar;
        private MaterialSkin.Controls.MaterialTextBox2 txtAxtar;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private MaterialSkin.Controls.MaterialCard materialCard1;
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
        private MaterialSkin.Controls.MaterialButton btnKopyala;
    }
}