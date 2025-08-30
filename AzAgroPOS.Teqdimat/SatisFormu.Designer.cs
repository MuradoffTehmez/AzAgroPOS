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
            splitContainer1 = new SplitContainer();
            btnSebeteElaveEt = new MaterialSkin.Controls.MaterialButton();
            txtMiqdar = new MaterialSkin.Controls.MaterialTextBox2();
            dgvAxtarisNeticeleri = new DataGridView();
            txtAxtaris = new MaterialSkin.Controls.MaterialTextBox2();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            btnGozleyenSatislar = new MaterialSkin.Controls.MaterialButton();
            btnSatisiGozlet = new MaterialSkin.Controls.MaterialButton();
            cmbMusteriler = new MaterialSkin.Controls.MaterialComboBox();
            btnNisye = new MaterialSkin.Controls.MaterialButton();
            btnKart = new MaterialSkin.Controls.MaterialButton();
            btnNagd = new MaterialSkin.Controls.MaterialButton();
            lblUmumiMebleg = new MaterialSkin.Controls.MaterialLabel();
            btnSebetdenSil = new MaterialSkin.Controls.MaterialButton();
            dgvSebet = new DataGridView();
            contextMenuStripGozleyenler = new ContextMenuStrip(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAxtarisNeticeleri).BeginInit();
            materialCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSebet).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 64);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btnSebeteElaveEt);
            splitContainer1.Panel1.Controls.Add(txtMiqdar);
            splitContainer1.Panel1.Controls.Add(dgvAxtarisNeticeleri);
            splitContainer1.Panel1.Controls.Add(txtAxtaris);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(materialCard1);
            splitContainer1.Panel2.Controls.Add(btnSebetdenSil);
            splitContainer1.Panel2.Controls.Add(dgvSebet);
            splitContainer1.Size = new Size(1378, 671);
            splitContainer1.SplitterDistance = 500;
            splitContainer1.TabIndex = 0;
            // 
            // btnSebeteElaveEt
            // 
            btnSebeteElaveEt.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnSebeteElaveEt.AutoSize = false;
            btnSebeteElaveEt.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSebeteElaveEt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSebeteElaveEt.Depth = 0;
            btnSebeteElaveEt.HighEmphasis = true;
            btnSebeteElaveEt.Icon = null;
            btnSebeteElaveEt.Location = new Point(148, 617);
            btnSebeteElaveEt.Margin = new Padding(4, 6, 4, 6);
            btnSebeteElaveEt.MouseState = MaterialSkin.MouseState.HOVER;
            btnSebeteElaveEt.Name = "btnSebeteElaveEt";
            btnSebeteElaveEt.NoAccentTextColor = Color.Empty;
            btnSebeteElaveEt.Size = new Size(335, 48);
            btnSebeteElaveEt.TabIndex = 3;
            btnSebeteElaveEt.Text = "Səbətə Əlavə Et";
            btnSebeteElaveEt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSebeteElaveEt.UseAccentColor = false;
            btnSebeteElaveEt.UseVisualStyleBackColor = true;
            btnSebeteElaveEt.Click += btnSebeteElaveEt_Click;
            // 
            // txtMiqdar
            // 
            txtMiqdar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtMiqdar.AnimateReadOnly = false;
            txtMiqdar.BackgroundImageLayout = ImageLayout.None;
            txtMiqdar.CharacterCasing = CharacterCasing.Normal;
            txtMiqdar.Depth = 0;
            txtMiqdar.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtMiqdar.HideSelection = true;
            txtMiqdar.Hint = "Miqdar";
            txtMiqdar.LeadingIcon = null;
            txtMiqdar.Location = new Point(16, 617);
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
            txtMiqdar.TabIndex = 2;
            txtMiqdar.TabStop = false;
            txtMiqdar.Text = "1";
            txtMiqdar.TextAlign = HorizontalAlignment.Left;
            txtMiqdar.TrailingIcon = null;
            txtMiqdar.UseSystemPasswordChar = false;
            // 
            // dgvAxtarisNeticeleri
            // 
            dgvAxtarisNeticeleri.AllowUserToAddRows = false;
            dgvAxtarisNeticeleri.AllowUserToDeleteRows = false;
            dgvAxtarisNeticeleri.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAxtarisNeticeleri.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAxtarisNeticeleri.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAxtarisNeticeleri.Location = new Point(16, 66);
            dgvAxtarisNeticeleri.MultiSelect = false;
            dgvAxtarisNeticeleri.Name = "dgvAxtarisNeticeleri";
            dgvAxtarisNeticeleri.ReadOnly = true;
            dgvAxtarisNeticeleri.RowTemplate.Height = 25;
            dgvAxtarisNeticeleri.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAxtarisNeticeleri.Size = new Size(467, 542);
            dgvAxtarisNeticeleri.TabIndex = 1;
            // 
            // txtAxtaris
            // 
            txtAxtaris.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAxtaris.AnimateReadOnly = false;
            txtAxtaris.BackgroundImageLayout = ImageLayout.None;
            txtAxtaris.CharacterCasing = CharacterCasing.Normal;
            txtAxtaris.Depth = 0;
            txtAxtaris.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtAxtaris.HideSelection = true;
            txtAxtaris.Hint = "Barkod, Stok Kodu və ya Məhsul Adı ilə Axtar";
            txtAxtaris.LeadingIcon = null;
            txtAxtaris.Location = new Point(16, 12);
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
            txtAxtaris.Size = new Size(467, 48);
            txtAxtaris.TabIndex = 0;
            txtAxtaris.TabStop = false;
            txtAxtaris.TextAlign = HorizontalAlignment.Left;
            txtAxtaris.TrailingIcon = null;
            txtAxtaris.UseSystemPasswordChar = false;
            txtAxtaris.TextChanged += txtAxtaris_TextChanged;
            // 
            // materialCard1
            // 
            materialCard1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(btnGozleyenSatislar);
            materialCard1.Controls.Add(btnSatisiGozlet);
            materialCard1.Controls.Add(cmbMusteriler);
            materialCard1.Controls.Add(btnNisye);
            materialCard1.Controls.Add(btnKart);
            materialCard1.Controls.Add(btnNagd);
            materialCard1.Controls.Add(lblUmumiMebleg);
            materialCard1.Depth = 0;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(18, 510);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(834, 155);
            materialCard1.TabIndex = 2;
            // 
            // btnGozleyenSatislar
            // 
            btnGozleyenSatislar.AutoSize = false;
            btnGozleyenSatislar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnGozleyenSatislar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnGozleyenSatislar.Depth = 0;
            btnGozleyenSatislar.HighEmphasis = false;
            btnGozleyenSatislar.Icon = null;
            btnGozleyenSatislar.Location = new Point(187, 94);
            btnGozleyenSatislar.Margin = new Padding(4, 6, 4, 6);
            btnGozleyenSatislar.MouseState = MaterialSkin.MouseState.HOVER;
            btnGozleyenSatislar.Name = "btnGozleyenSatislar";
            btnGozleyenSatislar.NoAccentTextColor = Color.Empty;
            btnGozleyenSatislar.Size = new Size(160, 40);
            btnGozleyenSatislar.TabIndex = 6;
            btnGozleyenSatislar.Text = "Gözləyənlər";
            btnGozleyenSatislar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnGozleyenSatislar.UseAccentColor = false;
            btnGozleyenSatislar.UseVisualStyleBackColor = true;
            btnGozleyenSatislar.Click += btnGozleyenSatislar_Click;
            // 
            // btnSatisiGozlet
            // 
            btnSatisiGozlet.AutoSize = false;
            btnSatisiGozlet.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSatisiGozlet.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSatisiGozlet.Depth = 0;
            btnSatisiGozlet.HighEmphasis = false;
            btnSatisiGozlet.Icon = null;
            btnSatisiGozlet.Location = new Point(17, 94);
            btnSatisiGozlet.Margin = new Padding(4, 6, 4, 6);
            btnSatisiGozlet.MouseState = MaterialSkin.MouseState.HOVER;
            btnSatisiGozlet.Name = "btnSatisiGozlet";
            btnSatisiGozlet.NoAccentTextColor = Color.Empty;
            btnSatisiGozlet.Size = new Size(160, 40);
            btnSatisiGozlet.TabIndex = 5;
            btnSatisiGozlet.Text = "Satışı Gözlət";
            btnSatisiGozlet.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnSatisiGozlet.UseAccentColor = false;
            btnSatisiGozlet.UseVisualStyleBackColor = true;
            btnSatisiGozlet.Click += btnSatisiGozlet_Click;
            // 
            // cmbMusteriler
            // 
            cmbMusteriler.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbMusteriler.AutoResize = false;
            cmbMusteriler.BackColor = Color.FromArgb(255, 255, 255);
            cmbMusteriler.Depth = 0;
            cmbMusteriler.DrawMode = DrawMode.OwnerDrawVariable;
            cmbMusteriler.DropDownHeight = 174;
            cmbMusteriler.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMusteriler.DropDownWidth = 121;
            cmbMusteriler.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbMusteriler.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbMusteriler.Hint = "Nisyə üçün Müştəri Seçin";
            cmbMusteriler.IntegralHeight = false;
            cmbMusteriler.ItemHeight = 43;
            cmbMusteriler.Location = new Point(393, 91);
            cmbMusteriler.MaxDropDownItems = 4;
            cmbMusteriler.MouseState = MaterialSkin.MouseState.OUT;
            cmbMusteriler.Name = "cmbMusteriler";
            cmbMusteriler.Size = new Size(424, 49);
            cmbMusteriler.StartIndex = 0;
            cmbMusteriler.TabIndex = 4;
            // 
            // btnNisye
            // 
            btnNisye.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNisye.AutoSize = false;
            btnNisye.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnNisye.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnNisye.Depth = 0;
            btnNisye.HighEmphasis = true;
            btnNisye.Icon = null;
            btnNisye.Location = new Point(677, 18);
            btnNisye.Margin = new Padding(4, 6, 4, 6);
            btnNisye.MouseState = MaterialSkin.MouseState.HOVER;
            btnNisye.Name = "btnNisye";
            btnNisye.NoAccentTextColor = Color.Empty;
            btnNisye.Size = new Size(140, 55);
            btnNisye.TabIndex = 3;
            btnNisye.Text = "Nisyə";
            btnNisye.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnNisye.UseAccentColor = true;
            btnNisye.UseVisualStyleBackColor = true;
            btnNisye.Click += btnNisye_Click;
            // 
            // btnKart
            // 
            btnKart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnKart.AutoSize = false;
            btnKart.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnKart.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnKart.Depth = 0;
            btnKart.HighEmphasis = true;
            btnKart.Icon = null;
            btnKart.Location = new Point(529, 18);
            btnKart.Margin = new Padding(4, 6, 4, 6);
            btnKart.MouseState = MaterialSkin.MouseState.HOVER;
            btnKart.Name = "btnKart";
            btnKart.NoAccentTextColor = Color.Empty;
            btnKart.Size = new Size(140, 55);
            btnKart.TabIndex = 2;
            btnKart.Text = "Kart";
            btnKart.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnKart.UseAccentColor = false;
            btnKart.UseVisualStyleBackColor = true;
            btnKart.Click += btnKart_Click;
            // 
            // btnNagd
            // 
            btnNagd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNagd.AutoSize = false;
            btnNagd.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnNagd.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnNagd.Depth = 0;
            btnNagd.HighEmphasis = true;
            btnNagd.Icon = null;
            btnNagd.Location = new Point(381, 18);
            btnNagd.Margin = new Padding(4, 6, 4, 6);
            btnNagd.MouseState = MaterialSkin.MouseState.HOVER;
            btnNagd.Name = "btnNagd";
            btnNagd.NoAccentTextColor = Color.Empty;
            btnNagd.Size = new Size(140, 55);
            btnNagd.TabIndex = 1;
            btnNagd.Text = "Nağd";
            btnNagd.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnNagd.UseAccentColor = false;
            btnNagd.UseVisualStyleBackColor = true;
            btnNagd.Click += btnNagd_Click;
            // 
            // lblUmumiMebleg
            // 
            lblUmumiMebleg.AutoSize = true;
            lblUmumiMebleg.Depth = 0;
            lblUmumiMebleg.Font = new Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblUmumiMebleg.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            lblUmumiMebleg.Location = new Point(17, 30);
            lblUmumiMebleg.MouseState = MaterialSkin.MouseState.HOVER;
            lblUmumiMebleg.Name = "lblUmumiMebleg";
            lblUmumiMebleg.Size = new Size(135, 41);
            lblUmumiMebleg.TabIndex = 0;
            lblUmumiMebleg.Text = "0.00 AZN";
            // 
            // btnSebetdenSil
            // 
            btnSebetdenSil.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSebetdenSil.AutoSize = false;
            btnSebetdenSil.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSebetdenSil.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSebetdenSil.Depth = 0;
            btnSebetdenSil.HighEmphasis = true;
            btnSebetdenSil.Icon = null;
            btnSebetdenSil.Location = new Point(18, 465);
            btnSebetdenSil.Margin = new Padding(4, 6, 4, 6);
            btnSebetdenSil.MouseState = MaterialSkin.MouseState.HOVER;
            btnSebetdenSil.Name = "btnSebetdenSil";
            btnSebetdenSil.NoAccentTextColor = Color.Empty;
            btnSebetdenSil.Size = new Size(168, 36);
            btnSebetdenSil.TabIndex = 1;
            btnSebetdenSil.Text = "Səbətdən Sil";
            btnSebetdenSil.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSebetdenSil.UseAccentColor = true;
            btnSebetdenSil.UseVisualStyleBackColor = true;
            btnSebetdenSil.Click += btnSebetdenSil_Click;
            // 
            // dgvSebet
            // 
            dgvSebet.AllowUserToAddRows = false;
            dgvSebet.AllowUserToDeleteRows = false;
            dgvSebet.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSebet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSebet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSebet.Location = new Point(18, 12);
            dgvSebet.Name = "dgvSebet";
            dgvSebet.RowTemplate.Height = 25;
            dgvSebet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSebet.Size = new Size(834, 444);
            dgvSebet.TabIndex = 0;
            dgvSebet.CellEndEdit += dgvSebet_CellEndEdit;
            // 
            // contextMenuStripGozleyenler
            // 
            contextMenuStripGozleyenler.Name = "contextMenuStripGozleyenler";
            contextMenuStripGozleyenler.Size = new Size(61, 4);
            contextMenuStripGozleyenler.ItemClicked += contextMenuStripGozleyenler_ItemClicked;
            // 
            // SatisFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1384, 738);
            Controls.Add(splitContainer1);
            Name = "SatisFormu";
            Padding = new Padding(3, 64, 3, 3);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Yeni Satış";
            WindowState = FormWindowState.Maximized;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAxtarisNeticeleri).EndInit();
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSebet).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private DataGridView dgvAxtarisNeticeleri;
        private MaterialSkin.Controls.MaterialTextBox2 txtAxtaris;
        private DataGridView dgvSebet;
        private MaterialSkin.Controls.MaterialButton btnSebetdenSil;
        private MaterialSkin.Controls.MaterialButton btnSebeteElaveEt;
        private MaterialSkin.Controls.MaterialTextBox2 txtMiqdar;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialButton btnNisye;
        private MaterialSkin.Controls.MaterialButton btnKart;
        private MaterialSkin.Controls.MaterialButton btnNagd;
        private MaterialSkin.Controls.MaterialLabel lblUmumiMebleg;
        private MaterialSkin.Controls.MaterialButton btnGozleyenSatislar;
        private MaterialSkin.Controls.MaterialButton btnSatisiGozlet;
        private MaterialSkin.Controls.MaterialComboBox cmbMusteriler;
        private ContextMenuStrip contextMenuStripGozleyenler;
    }
}