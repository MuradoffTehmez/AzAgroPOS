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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvMehsullar = new System.Windows.Forms.DataGridView();
            this.txtAxtar = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.btnKopyala = new MaterialSkin.Controls.MaterialButton();
            this.txtTekEdedSatisQiymeti = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtTopdanSatisQiymeti = new MaterialSkin.Controls.MaterialTextBox2();
            this.cmbOlcuVahidi = new MaterialSkin.Controls.MaterialComboBox();
            this.btnYenile = new MaterialSkin.Controls.MaterialButton();
            this.btnElaveEt = new MaterialSkin.Controls.MaterialButton();
            this.btnTemizle = new MaterialSkin.Controls.MaterialButton();
            this.btnSil = new MaterialSkin.Controls.MaterialButton();
            this.btnBarkodYarat = new MaterialSkin.Controls.MaterialButton();
            this.btnStokKoduYarat = new MaterialSkin.Controls.MaterialButton();
            this.txtMevcudSay = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtAlisQiymeti = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtPerakendeSatisQiymeti = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtBarkod = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtStokKodu = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtAd = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtId = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvAlisTarixcesi = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMehsullar)).BeginInit();
            this.materialTabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.materialCard1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlisTarixcesi)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.splitContainer1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.splitContainer1.Location = new System.Drawing.Point(3, 64);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.splitContainer1.Panel1.Controls.Add(this.dgvMehsullar);
            this.splitContainer1.Panel1.Controls.Add(this.txtAxtar);
            this.splitContainer1.Panel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.splitContainer1.Panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.splitContainer1.Panel2.Controls.Add(this.materialTabControl1);
            this.splitContainer1.Panel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.splitContainer1.Panel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.splitContainer1.Size = new System.Drawing.Size(1281, 671);
            this.splitContainer1.SplitterDistance = 750;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgvMehsullar
            // 
            this.dgvMehsullar.AllowUserToAddRows = false;
            this.dgvMehsullar.AllowUserToDeleteRows = false;
            this.dgvMehsullar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMehsullar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMehsullar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMehsullar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMehsullar.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMehsullar.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvMehsullar.Location = new System.Drawing.Point(3, 57);
            this.dgvMehsullar.MultiSelect = false;
            this.dgvMehsullar.Name = "dgvMehsullar";
            this.dgvMehsullar.ReadOnly = true;
            this.dgvMehsullar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMehsullar.Size = new System.Drawing.Size(744, 611);
            this.dgvMehsullar.TabIndex = 1;
            this.dgvMehsullar.SelectionChanged += new System.EventHandler(this.dgvMehsullar_SelectionChanged);
            // 
            // txtAxtar
            // 
            this.txtAxtar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAxtar.AnimateReadOnly = false;
            this.txtAxtar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.txtAxtar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtAxtar.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAxtar.Depth = 0;
            this.txtAxtar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtAxtar.HideSelection = true;
            this.txtAxtar.Hint = "Məhsul Siyahısında Axtar...";
            this.txtAxtar.LeadingIcon = null;
            this.txtAxtar.Location = new System.Drawing.Point(3, 3);
            this.txtAxtar.MaxLength = 32767;
            this.txtAxtar.MouseState = MaterialSkin.MouseState.OUT;
            this.txtAxtar.Name = "txtAxtar";
            this.txtAxtar.PasswordChar = '\0';
            this.txtAxtar.PrefixSuffixText = null;
            this.txtAxtar.ReadOnly = false;
            this.txtAxtar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAxtar.SelectedText = "";
            this.txtAxtar.SelectionLength = 0;
            this.txtAxtar.SelectionStart = 0;
            this.txtAxtar.ShortcutsEnabled = true;
            this.txtAxtar.Size = new System.Drawing.Size(744, 48);
            this.txtAxtar.TabIndex = 0;
            this.txtAxtar.TabStop = false;
            this.txtAxtar.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtAxtar.TrailingIcon = null;
            this.txtAxtar.UseSystemPasswordChar = false;
            this.txtAxtar.TextChanged += new System.EventHandler(this.txtAxtar_TextChanged);
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPage2);
            this.materialTabControl1.Controls.Add(this.tabPage1);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabControl1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialTabControl1.Location = new System.Drawing.Point(0, 0);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Multiline = true;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(527, 671);
            this.materialTabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.tabPage2.Controls.Add(this.materialCard1);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(519, 641);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Əsas Məlumatlar";
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.btnKopyala);
            this.materialCard1.Controls.Add(this.txtTekEdedSatisQiymeti);
            this.materialCard1.Controls.Add(this.txtTopdanSatisQiymeti);
            this.materialCard1.Controls.Add(this.cmbOlcuVahidi);
            this.materialCard1.Controls.Add(this.btnYenile);
            this.materialCard1.Controls.Add(this.btnElaveEt);
            this.materialCard1.Controls.Add(this.btnTemizle);
            this.materialCard1.Controls.Add(this.btnSil);
            this.materialCard1.Controls.Add(this.btnBarkodYarat);
            this.materialCard1.Controls.Add(this.btnStokKoduYarat);
            this.materialCard1.Controls.Add(this.txtMevcudSay);
            this.materialCard1.Controls.Add(this.txtAlisQiymeti);
            this.materialCard1.Controls.Add(this.txtPerakendeSatisQiymeti);
            this.materialCard1.Controls.Add(this.txtBarkod);
            this.materialCard1.Controls.Add(this.txtStokKodu);
            this.materialCard1.Controls.Add(this.txtAd);
            this.materialCard1.Controls.Add(this.txtId);
            this.materialCard1.Depth = 0;
            this.materialCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(3, 3);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(513, 635);
            this.materialCard1.TabIndex = 2;
            // 
            // btnKopyala
            // 
            this.btnKopyala.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnKopyala.AutoSize = false;
            this.btnKopyala.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnKopyala.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnKopyala.Depth = 0;
            this.btnKopyala.HighEmphasis = false;
            this.btnKopyala.Icon = null;
            this.btnKopyala.Location = new System.Drawing.Point(137, 577);
            this.btnKopyala.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnKopyala.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnKopyala.Name = "btnKopyala";
            this.btnKopyala.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnKopyala.Size = new System.Drawing.Size(114, 40);
            this.btnKopyala.TabIndex = 19;
            this.btnKopyala.Text = "Kopyala";
            this.btnKopyala.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnKopyala.UseAccentColor = false;
            this.btnKopyala.UseVisualStyleBackColor = true;
            this.btnKopyala.Click += new System.EventHandler(this.btnKopyala_Click);
            // 
            // txtTekEdedSatisQiymeti
            // 
            this.txtTekEdedSatisQiymeti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTekEdedSatisQiymeti.AnimateReadOnly = false;
            this.txtTekEdedSatisQiymeti.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtTekEdedSatisQiymeti.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtTekEdedSatisQiymeti.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTekEdedSatisQiymeti.Depth = 0;
            this.txtTekEdedSatisQiymeti.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtTekEdedSatisQiymeti.HideSelection = true;
            this.txtTekEdedSatisQiymeti.Hint = "Tək Ədəd Qiyməti";
            this.txtTekEdedSatisQiymeti.LeadingIcon = null;
            this.txtTekEdedSatisQiymeti.Location = new System.Drawing.Point(18, 324);
            this.txtTekEdedSatisQiymeti.MaxLength = 32767;
            this.txtTekEdedSatisQiymeti.MouseState = MaterialSkin.MouseState.OUT;
            this.txtTekEdedSatisQiymeti.Name = "txtTekEdedSatisQiymeti";
            this.txtTekEdedSatisQiymeti.PasswordChar = '\0';
            this.txtTekEdedSatisQiymeti.PrefixSuffixText = null;
            this.txtTekEdedSatisQiymeti.ReadOnly = false;
            this.txtTekEdedSatisQiymeti.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTekEdedSatisQiymeti.SelectedText = "";
            this.txtTekEdedSatisQiymeti.SelectionLength = 0;
            this.txtTekEdedSatisQiymeti.SelectionStart = 0;
            this.txtTekEdedSatisQiymeti.ShortcutsEnabled = true;
            this.txtTekEdedSatisQiymeti.Size = new System.Drawing.Size(478, 48);
            this.txtTekEdedSatisQiymeti.TabIndex = 18;
            this.txtTekEdedSatisQiymeti.TabStop = false;
            this.txtTekEdedSatisQiymeti.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTekEdedSatisQiymeti.TrailingIcon = null;
            this.txtTekEdedSatisQiymeti.UseSystemPasswordChar = false;
            // 
            // txtTopdanSatisQiymeti
            // 
            this.txtTopdanSatisQiymeti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTopdanSatisQiymeti.AnimateReadOnly = false;
            this.txtTopdanSatisQiymeti.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtTopdanSatisQiymeti.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtTopdanSatisQiymeti.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTopdanSatisQiymeti.Depth = 0;
            this.txtTopdanSatisQiymeti.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtTopdanSatisQiymeti.HideSelection = true;
            this.txtTopdanSatisQiymeti.Hint = "Topdan Satış Qiyməti";
            this.txtTopdanSatisQiymeti.LeadingIcon = null;
            this.txtTopdanSatisQiymeti.Location = new System.Drawing.Point(18, 270);
            this.txtTopdanSatisQiymeti.MaxLength = 32767;
            this.txtTopdanSatisQiymeti.MouseState = MaterialSkin.MouseState.OUT;
            this.txtTopdanSatisQiymeti.Name = "txtTopdanSatisQiymeti";
            this.txtTopdanSatisQiymeti.PasswordChar = '\0';
            this.txtTopdanSatisQiymeti.PrefixSuffixText = null;
            this.txtTopdanSatisQiymeti.ReadOnly = false;
            this.txtTopdanSatisQiymeti.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTopdanSatisQiymeti.SelectedText = "";
            this.txtTopdanSatisQiymeti.SelectionLength = 0;
            this.txtTopdanSatisQiymeti.SelectionStart = 0;
            this.txtTopdanSatisQiymeti.ShortcutsEnabled = true;
            this.txtTopdanSatisQiymeti.Size = new System.Drawing.Size(478, 48);
            this.txtTopdanSatisQiymeti.TabIndex = 17;
            this.txtTopdanSatisQiymeti.TabStop = false;
            this.txtTopdanSatisQiymeti.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTopdanSatisQiymeti.TrailingIcon = null;
            this.txtTopdanSatisQiymeti.UseSystemPasswordChar = false;
            // 
            // cmbOlcuVahidi
            // 
            this.cmbOlcuVahidi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbOlcuVahidi.AutoResize = false;
            this.cmbOlcuVahidi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.cmbOlcuVahidi.Depth = 0;
            this.cmbOlcuVahidi.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbOlcuVahidi.DropDownHeight = 174;
            this.cmbOlcuVahidi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOlcuVahidi.DropDownWidth = 121;
            this.cmbOlcuVahidi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbOlcuVahidi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbOlcuVahidi.Hint = "Ölçü Vahidi";
            this.cmbOlcuVahidi.IntegralHeight = false;
            this.cmbOlcuVahidi.ItemHeight = 43;
            this.cmbOlcuVahidi.Location = new System.Drawing.Point(18, 432);
            this.cmbOlcuVahidi.MaxDropDownItems = 4;
            this.cmbOlcuVahidi.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbOlcuVahidi.Name = "cmbOlcuVahidi";
            this.cmbOlcuVahidi.Size = new System.Drawing.Size(478, 49);
            this.cmbOlcuVahidi.StartIndex = 0;
            this.cmbOlcuVahidi.TabIndex = 16;
            // 
            // btnYenile
            // 
            this.btnYenile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYenile.AutoSize = false;
            this.btnYenile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnYenile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnYenile.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnYenile.Depth = 0;
            this.btnYenile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnYenile.HighEmphasis = true;
            this.btnYenile.Icon = null;
            this.btnYenile.Location = new System.Drawing.Point(258, 525);
            this.btnYenile.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnYenile.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnYenile.Size = new System.Drawing.Size(236, 40);
            this.btnYenile.TabIndex = 15;
            this.btnYenile.Text = "Yenilə";
            this.btnYenile.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnYenile.UseAccentColor = false;
            this.btnYenile.UseVisualStyleBackColor = false;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // btnElaveEt
            // 
            this.btnElaveEt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnElaveEt.AutoSize = false;
            this.btnElaveEt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnElaveEt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnElaveEt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnElaveEt.Depth = 0;
            this.btnElaveEt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnElaveEt.HighEmphasis = true;
            this.btnElaveEt.Icon = null;
            this.btnElaveEt.Location = new System.Drawing.Point(18, 525);
            this.btnElaveEt.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnElaveEt.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnElaveEt.Name = "btnElaveEt";
            this.btnElaveEt.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnElaveEt.Size = new System.Drawing.Size(233, 40);
            this.btnElaveEt.TabIndex = 14;
            this.btnElaveEt.Text = "Yeni Məhsulu Yadda Saxla";
            this.btnElaveEt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnElaveEt.UseAccentColor = false;
            this.btnElaveEt.UseVisualStyleBackColor = false;
            this.btnElaveEt.Click += new System.EventHandler(this.btnElaveEt_Click);
            // 
            // btnTemizle
            // 
            this.btnTemizle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTemizle.AutoSize = false;
            this.btnTemizle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTemizle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnTemizle.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnTemizle.Depth = 0;
            this.btnTemizle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnTemizle.HighEmphasis = false;
            this.btnTemizle.Icon = null;
            this.btnTemizle.Location = new System.Drawing.Point(258, 577);
            this.btnTemizle.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnTemizle.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnTemizle.Size = new System.Drawing.Size(236, 40);
            this.btnTemizle.TabIndex = 13;
            this.btnTemizle.Text = "Formu Təmizlə";
            this.btnTemizle.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnTemizle.UseAccentColor = false;
            this.btnTemizle.UseVisualStyleBackColor = false;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSil.AutoSize = false;
            this.btnSil.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnSil.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSil.Depth = 0;
            this.btnSil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSil.HighEmphasis = true;
            this.btnSil.Icon = null;
            this.btnSil.Location = new System.Drawing.Point(18, 577);
            this.btnSil.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSil.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSil.Name = "btnSil";
            this.btnSil.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSil.Size = new System.Drawing.Size(111, 40);
            this.btnSil.TabIndex = 9;
            this.btnSil.Text = "Seçilmişi Sil";
            this.btnSil.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSil.UseAccentColor = true;
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnBarkodYarat
            // 
            this.btnBarkodYarat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBarkodYarat.AutoSize = false;
            this.btnBarkodYarat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBarkodYarat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnBarkodYarat.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnBarkodYarat.Depth = 0;
            this.btnBarkodYarat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnBarkodYarat.HighEmphasis = false;
            this.btnBarkodYarat.Icon = null;
            this.btnBarkodYarat.Location = new System.Drawing.Point(380, 162);
            this.btnBarkodYarat.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBarkodYarat.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBarkodYarat.Name = "btnBarkodYarat";
            this.btnBarkodYarat.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnBarkodYarat.Size = new System.Drawing.Size(102, 36);
            this.btnBarkodYarat.TabIndex = 12;
            this.btnBarkodYarat.Text = "Yarat";
            this.btnBarkodYarat.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnBarkodYarat.UseAccentColor = false;
            this.btnBarkodYarat.UseVisualStyleBackColor = false;
            this.btnBarkodYarat.Click += new System.EventHandler(this.btnBarkodYarat_Click);
            // 
            // btnStokKoduYarat
            // 
            this.btnStokKoduYarat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStokKoduYarat.AutoSize = false;
            this.btnStokKoduYarat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnStokKoduYarat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.btnStokKoduYarat.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnStokKoduYarat.Depth = 0;
            this.btnStokKoduYarat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnStokKoduYarat.HighEmphasis = false;
            this.btnStokKoduYarat.Icon = null;
            this.btnStokKoduYarat.Location = new System.Drawing.Point(380, 90);
            this.btnStokKoduYarat.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnStokKoduYarat.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnStokKoduYarat.Name = "btnStokKoduYarat";
            this.btnStokKoduYarat.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnStokKoduYarat.Size = new System.Drawing.Size(102, 36);
            this.btnStokKoduYarat.TabIndex = 11;
            this.btnStokKoduYarat.Text = "Yarat";
            this.btnStokKoduYarat.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnStokKoduYarat.UseAccentColor = false;
            this.btnStokKoduYarat.UseVisualStyleBackColor = false;
            this.btnStokKoduYarat.Click += new System.EventHandler(this.btnStokKoduYarat_Click);
            // 
            // txtMevcudSay
            // 
            this.txtMevcudSay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMevcudSay.AnimateReadOnly = false;
            this.txtMevcudSay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtMevcudSay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtMevcudSay.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMevcudSay.Depth = 0;
            this.txtMevcudSay.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtMevcudSay.HideSelection = true;
            this.txtMevcudSay.Hint = "Mövcud Say";
            this.txtMevcudSay.LeadingIcon = null;
            this.txtMevcudSay.Location = new System.Drawing.Point(252, 378);
            this.txtMevcudSay.MaxLength = 32767;
            this.txtMevcudSay.MouseState = MaterialSkin.MouseState.OUT;
            this.txtMevcudSay.Name = "txtMevcudSay";
            this.txtMevcudSay.PasswordChar = '\0';
            this.txtMevcudSay.PrefixSuffixText = null;
            this.txtMevcudSay.ReadOnly = false;
            this.txtMevcudSay.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMevcudSay.SelectedText = "";
            this.txtMevcudSay.SelectionLength = 0;
            this.txtMevcudSay.SelectionStart = 0;
            this.txtMevcudSay.ShortcutsEnabled = true;
            this.txtMevcudSay.Size = new System.Drawing.Size(230, 48);
            this.txtMevcudSay.TabIndex = 6;
            this.txtMevcudSay.TabStop = false;
            this.txtMevcudSay.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtMevcudSay.TrailingIcon = null;
            this.txtMevcudSay.UseSystemPasswordChar = false;
            // 
            // txtAlisQiymeti
            // 
            this.txtAlisQiymeti.AnimateReadOnly = false;
            this.txtAlisQiymeti.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtAlisQiymeti.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtAlisQiymeti.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAlisQiymeti.Depth = 0;
            this.txtAlisQiymeti.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtAlisQiymeti.HideSelection = true;
            this.txtAlisQiymeti.Hint = "Alış Qiyməti";
            this.txtAlisQiymeti.LeadingIcon = null;
            this.txtAlisQiymeti.Location = new System.Drawing.Point(18, 378);
            this.txtAlisQiymeti.MaxLength = 32767;
            this.txtAlisQiymeti.MouseState = MaterialSkin.MouseState.OUT;
            this.txtAlisQiymeti.Name = "txtAlisQiymeti";
            this.txtAlisQiymeti.PasswordChar = '\0';
            this.txtAlisQiymeti.PrefixSuffixText = null;
            this.txtAlisQiymeti.ReadOnly = false;
            this.txtAlisQiymeti.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAlisQiymeti.SelectedText = "";
            this.txtAlisQiymeti.SelectionLength = 0;
            this.txtAlisQiymeti.SelectionStart = 0;
            this.txtAlisQiymeti.ShortcutsEnabled = true;
            this.txtAlisQiymeti.Size = new System.Drawing.Size(226, 48);
            this.txtAlisQiymeti.TabIndex = 5;
            this.txtAlisQiymeti.TabStop = false;
            this.txtAlisQiymeti.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtAlisQiymeti.TrailingIcon = null;
            this.txtAlisQiymeti.UseSystemPasswordChar = false;
            // 
            // txtPerakendeSatisQiymeti
            // 
            this.txtPerakendeSatisQiymeti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPerakendeSatisQiymeti.AnimateReadOnly = false;
            this.txtPerakendeSatisQiymeti.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtPerakendeSatisQiymeti.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtPerakendeSatisQiymeti.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPerakendeSatisQiymeti.Depth = 0;
            this.txtPerakendeSatisQiymeti.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPerakendeSatisQiymeti.HideSelection = true;
            this.txtPerakendeSatisQiymeti.Hint = "Pərakəndə Satış Qiyməti";
            this.txtPerakendeSatisQiymeti.LeadingIcon = null;
            this.txtPerakendeSatisQiymeti.Location = new System.Drawing.Point(18, 216);
            this.txtPerakendeSatisQiymeti.MaxLength = 32767;
            this.txtPerakendeSatisQiymeti.MouseState = MaterialSkin.MouseState.OUT;
            this.txtPerakendeSatisQiymeti.Name = "txtPerakendeSatisQiymeti";
            this.txtPerakendeSatisQiymeti.PasswordChar = '\0';
            this.txtPerakendeSatisQiymeti.PrefixSuffixText = null;
            this.txtPerakendeSatisQiymeti.ReadOnly = false;
            this.txtPerakendeSatisQiymeti.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPerakendeSatisQiymeti.SelectedText = "";
            this.txtPerakendeSatisQiymeti.SelectionLength = 0;
            this.txtPerakendeSatisQiymeti.SelectionStart = 0;
            this.txtPerakendeSatisQiymeti.ShortcutsEnabled = true;
            this.txtPerakendeSatisQiymeti.Size = new System.Drawing.Size(464, 48);
            this.txtPerakendeSatisQiymeti.TabIndex = 4;
            this.txtPerakendeSatisQiymeti.TabStop = false;
            this.txtPerakendeSatisQiymeti.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPerakendeSatisQiymeti.TrailingIcon = null;
            this.txtPerakendeSatisQiymeti.UseSystemPasswordChar = false;
            // 
            // txtBarkod
            // 
            this.txtBarkod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBarkod.AnimateReadOnly = false;
            this.txtBarkod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtBarkod.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtBarkod.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBarkod.Depth = 0;
            this.txtBarkod.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtBarkod.HideSelection = true;
            this.txtBarkod.Hint = "Barkod";
            this.txtBarkod.LeadingIcon = null;
            this.txtBarkod.Location = new System.Drawing.Point(18, 156);
            this.txtBarkod.MaxLength = 32767;
            this.txtBarkod.MouseState = MaterialSkin.MouseState.OUT;
            this.txtBarkod.Name = "txtBarkod";
            this.txtBarkod.PasswordChar = '\0';
            this.txtBarkod.PrefixSuffixText = null;
            this.txtBarkod.ReadOnly = false;
            this.txtBarkod.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBarkod.SelectedText = "";
            this.txtBarkod.SelectionLength = 0;
            this.txtBarkod.SelectionStart = 0;
            this.txtBarkod.ShortcutsEnabled = true;
            this.txtBarkod.Size = new System.Drawing.Size(345, 48);
            this.txtBarkod.TabIndex = 3;
            this.txtBarkod.TabStop = false;
            this.txtBarkod.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBarkod.TrailingIcon = null;
            this.txtBarkod.UseSystemPasswordChar = false;
            // 
            // txtStokKodu
            // 
            this.txtStokKodu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStokKodu.AnimateReadOnly = false;
            this.txtStokKodu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtStokKodu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtStokKodu.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtStokKodu.Depth = 0;
            this.txtStokKodu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtStokKodu.HideSelection = true;
            this.txtStokKodu.Hint = "Stok Kodu (SKU)";
            this.txtStokKodu.LeadingIcon = null;
            this.txtStokKodu.Location = new System.Drawing.Point(18, 88);
            this.txtStokKodu.MaxLength = 32767;
            this.txtStokKodu.MouseState = MaterialSkin.MouseState.OUT;
            this.txtStokKodu.Name = "txtStokKodu";
            this.txtStokKodu.PasswordChar = '\0';
            this.txtStokKodu.PrefixSuffixText = null;
            this.txtStokKodu.ReadOnly = false;
            this.txtStokKodu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtStokKodu.SelectedText = "";
            this.txtStokKodu.SelectionLength = 0;
            this.txtStokKodu.SelectionStart = 0;
            this.txtStokKodu.ShortcutsEnabled = true;
            this.txtStokKodu.Size = new System.Drawing.Size(345, 48);
            this.txtStokKodu.TabIndex = 2;
            this.txtStokKodu.TabStop = false;
            this.txtStokKodu.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtStokKodu.TrailingIcon = null;
            this.txtStokKodu.UseSystemPasswordChar = false;
            // 
            // txtAd
            // 
            this.txtAd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAd.AnimateReadOnly = false;
            this.txtAd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtAd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtAd.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAd.Depth = 0;
            this.txtAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtAd.HideSelection = true;
            this.txtAd.Hint = "Məhsulun Adı";
            this.txtAd.LeadingIcon = null;
            this.txtAd.Location = new System.Drawing.Point(18, 28);
            this.txtAd.MaxLength = 32767;
            this.txtAd.MouseState = MaterialSkin.MouseState.OUT;
            this.txtAd.Name = "txtAd";
            this.txtAd.PasswordChar = '\0';
            this.txtAd.PrefixSuffixText = null;
            this.txtAd.ReadOnly = false;
            this.txtAd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAd.SelectedText = "";
            this.txtAd.SelectionLength = 0;
            this.txtAd.SelectionStart = 0;
            this.txtAd.ShortcutsEnabled = true;
            this.txtAd.Size = new System.Drawing.Size(464, 48);
            this.txtAd.TabIndex = 1;
            this.txtAd.TabStop = false;
            this.txtAd.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtAd.TrailingIcon = null;
            this.txtAd.UseSystemPasswordChar = false;
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtId.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtId.Location = new System.Drawing.Point(18, 558);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 24);
            this.txtId.TabIndex = 0;
            this.txtId.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.tabPage1.Controls.Add(this.dgvAlisTarixcesi);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(519, 641);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Alış Tarixçəsi";
            // 
            // dgvAlisTarixcesi
            // 
            this.dgvAlisTarixcesi.AllowUserToAddRows = false;
            this.dgvAlisTarixcesi.AllowUserToDeleteRows = false;
            this.dgvAlisTarixcesi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAlisTarixcesi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAlisTarixcesi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAlisTarixcesi.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAlisTarixcesi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlisTarixcesi.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgvAlisTarixcesi.Location = new System.Drawing.Point(3, 3);
            this.dgvAlisTarixcesi.Name = "dgvAlisTarixcesi";
            this.dgvAlisTarixcesi.ReadOnly = true;
            this.dgvAlisTarixcesi.Size = new System.Drawing.Size(513, 635);
            this.dgvAlisTarixcesi.TabIndex = 0;
            // 
            // MehsulIdareetmeFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1287, 738);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MehsulIdareetmeFormu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Məhsul İdarəetməsi";
            this.Load += new System.EventHandler(this.MehsulIdareetmeFormu_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMehsullar)).EndInit();
            this.materialTabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.materialCard1.ResumeLayout(false);
            this.materialCard1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlisTarixcesi)).EndInit();
            this.ResumeLayout(false);
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