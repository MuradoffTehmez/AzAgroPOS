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
            materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            tabPage1 = new TabPage();
            dgvMehsullar = new DataGridView();
            txtAxtar = new MaterialSkin.Controls.MaterialTextBox2();
            tabPage2 = new TabPage();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            cmbOlcuVahidi = new MaterialSkin.Controls.MaterialComboBox();
            btnYenile = new MaterialSkin.Controls.MaterialButton();
            btnElaveEt = new MaterialSkin.Controls.MaterialButton();
            btnTemizle = new MaterialSkin.Controls.MaterialButton();
            btnSil = new MaterialSkin.Controls.MaterialButton();
            btnBarkodYarat = new MaterialSkin.Controls.MaterialButton();
            btnStokKoduYarat = new MaterialSkin.Controls.MaterialButton();
            txtMevcudSay = new MaterialSkin.Controls.MaterialTextBox2();
            txtAlisQiymeti = new MaterialSkin.Controls.MaterialTextBox2();
            txtSatisQiymeti = new MaterialSkin.Controls.MaterialTextBox2();
            txtBarkod = new MaterialSkin.Controls.MaterialTextBox2();
            txtStokKodu = new MaterialSkin.Controls.MaterialTextBox2();
            txtAd = new MaterialSkin.Controls.MaterialTextBox2();
            txtId = new TextBox();
            materialTabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMehsullar).BeginInit();
            tabPage2.SuspendLayout();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // materialTabControl1
            // 
            materialTabControl1.Controls.Add(tabPage1);
            materialTabControl1.Controls.Add(tabPage2);
            materialTabControl1.Depth = 0;
            materialTabControl1.Dock = DockStyle.Fill;
            materialTabControl1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialTabControl1.Location = new Point(3, 64);
            materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            materialTabControl1.Multiline = true;
            materialTabControl1.Name = "materialTabControl1";
            materialTabControl1.SelectedIndex = 0;
            materialTabControl1.Size = new Size(1281, 671);
            materialTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.FromArgb(242, 242, 242);
            tabPage1.Controls.Add(dgvMehsullar);
            tabPage1.Controls.Add(txtAxtar);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1273, 643);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Məhsul Siyahısı";
            // 
            // dgvMehsullar
            // 
            dgvMehsullar.AllowUserToAddRows = false;
            dgvMehsullar.AllowUserToDeleteRows = false;
            dgvMehsullar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMehsullar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMehsullar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMehsullar.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvMehsullar.Location = new Point(6, 58);
            dgvMehsullar.MultiSelect = false;
            dgvMehsullar.Name = "dgvMehsullar";
            dgvMehsullar.ReadOnly = true;
            dgvMehsullar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMehsullar.Size = new Size(1261, 579);
            dgvMehsullar.TabIndex = 1;
            dgvMehsullar.SelectionChanged += dgvMehsullar_SelectionChanged;
            dgvMehsullar.DoubleClick += dgvMehsullar_DoubleClick;
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
            txtAxtar.Hint = "Ada, Stok Koduna və ya Barkoda Görə Axtar";
            txtAxtar.LeadingIcon = null;
            txtAxtar.Location = new Point(6, 6);
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
            txtAxtar.Size = new Size(1261, 48);
            txtAxtar.TabIndex = 0;
            txtAxtar.TabStop = false;
            txtAxtar.TextAlign = HorizontalAlignment.Left;
            txtAxtar.TrailingIcon = null;
            txtAxtar.UseSystemPasswordChar = false;
            txtAxtar.TextChanged += txtAxtar_TextChanged;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.FromArgb(242, 242, 242);
            tabPage2.Controls.Add(materialCard1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1273, 643);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Yeni Məhsul / Redaktə";
            // 
            // materialCard1
            // 
            materialCard1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(cmbOlcuVahidi);
            materialCard1.Controls.Add(btnYenile);
            materialCard1.Controls.Add(btnElaveEt);
            materialCard1.Controls.Add(btnTemizle);
            materialCard1.Controls.Add(btnSil);
            materialCard1.Controls.Add(btnBarkodYarat);
            materialCard1.Controls.Add(btnStokKoduYarat);
            materialCard1.Controls.Add(txtMevcudSay);
            materialCard1.Controls.Add(txtAlisQiymeti);
            materialCard1.Controls.Add(txtSatisQiymeti);
            materialCard1.Controls.Add(txtBarkod);
            materialCard1.Controls.Add(txtStokKodu);
            materialCard1.Controls.Add(txtAd);
            materialCard1.Controls.Add(txtId);
            materialCard1.Depth = 0;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(16, 16);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(500, 610);
            materialCard1.TabIndex = 1;
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
            cmbOlcuVahidi.Size = new Size(464, 49);
            cmbOlcuVahidi.StartIndex = 0;
            cmbOlcuVahidi.TabIndex = 16;
            // 
            // btnYenile
            // 
            btnYenile.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnYenile.AutoSize = false;
            btnYenile.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnYenile.BackColor = Color.FromArgb(242, 242, 242);
            btnYenile.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnYenile.Depth = 0;
            btnYenile.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnYenile.HighEmphasis = true;
            btnYenile.Icon = null;
            btnYenile.Location = new Point(252, 498);
            btnYenile.Margin = new Padding(4, 6, 4, 6);
            btnYenile.MouseState = MaterialSkin.MouseState.HOVER;
            btnYenile.Name = "btnYenile";
            btnYenile.NoAccentTextColor = Color.Empty;
            btnYenile.Size = new Size(230, 40);
            btnYenile.TabIndex = 15;
            btnYenile.Text = "Yenilə";
            btnYenile.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnYenile.UseAccentColor = false;
            btnYenile.UseVisualStyleBackColor = false;
            btnYenile.Click += btnYenile_Click;
            // 
            // btnElaveEt
            // 
            btnElaveEt.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnElaveEt.AutoSize = false;
            btnElaveEt.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnElaveEt.BackColor = Color.FromArgb(242, 242, 242);
            btnElaveEt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnElaveEt.Depth = 0;
            btnElaveEt.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnElaveEt.HighEmphasis = true;
            btnElaveEt.Icon = null;
            btnElaveEt.Location = new Point(18, 498);
            btnElaveEt.Margin = new Padding(4, 6, 4, 6);
            btnElaveEt.MouseState = MaterialSkin.MouseState.HOVER;
            btnElaveEt.Name = "btnElaveEt";
            btnElaveEt.NoAccentTextColor = Color.Empty;
            btnElaveEt.Size = new Size(226, 40);
            btnElaveEt.TabIndex = 14;
            btnElaveEt.Text = "Əlavə Et";
            btnElaveEt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnElaveEt.UseAccentColor = false;
            btnElaveEt.UseVisualStyleBackColor = false;
            btnElaveEt.Click += btnElaveEt_Click;
            // 
            // btnTemizle
            // 
            btnTemizle.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnTemizle.AutoSize = false;
            btnTemizle.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnTemizle.BackColor = Color.FromArgb(242, 242, 242);
            btnTemizle.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnTemizle.Depth = 0;
            btnTemizle.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnTemizle.HighEmphasis = false;
            btnTemizle.Icon = null;
            btnTemizle.Location = new Point(252, 550);
            btnTemizle.Margin = new Padding(4, 6, 4, 6);
            btnTemizle.MouseState = MaterialSkin.MouseState.HOVER;
            btnTemizle.Name = "btnTemizle";
            btnTemizle.NoAccentTextColor = Color.Empty;
            btnTemizle.Size = new Size(230, 40);
            btnTemizle.TabIndex = 13;
            btnTemizle.Text = "Təmizlə";
            btnTemizle.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnTemizle.UseAccentColor = false;
            btnTemizle.UseVisualStyleBackColor = false;
            btnTemizle.Click += btnTemizle_Click;
            // 
            // btnSil
            // 
            btnSil.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSil.AutoSize = false;
            btnSil.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSil.BackColor = Color.FromArgb(242, 242, 242);
            btnSil.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSil.Depth = 0;
            btnSil.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnSil.HighEmphasis = true;
            btnSil.Icon = null;
            btnSil.Location = new Point(18, 550);
            btnSil.Margin = new Padding(4, 6, 4, 6);
            btnSil.MouseState = MaterialSkin.MouseState.HOVER;
            btnSil.Name = "btnSil";
            btnSil.NoAccentTextColor = Color.Empty;
            btnSil.Size = new Size(226, 40);
            btnSil.TabIndex = 9;
            btnSil.Text = "Sil";
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
            btnBarkodYarat.Location = new Point(370, 162);
            btnBarkodYarat.Margin = new Padding(4, 6, 4, 6);
            btnBarkodYarat.MouseState = MaterialSkin.MouseState.HOVER;
            btnBarkodYarat.Name = "btnBarkodYarat";
            btnBarkodYarat.NoAccentTextColor = Color.Empty;
            btnBarkodYarat.Size = new Size(112, 36);
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
            btnStokKoduYarat.Location = new Point(370, 90);
            btnStokKoduYarat.Margin = new Padding(4, 6, 4, 6);
            btnStokKoduYarat.MouseState = MaterialSkin.MouseState.HOVER;
            btnStokKoduYarat.Name = "btnStokKoduYarat";
            btnStokKoduYarat.NoAccentTextColor = Color.Empty;
            btnStokKoduYarat.Size = new Size(112, 36);
            btnStokKoduYarat.TabIndex = 11;
            btnStokKoduYarat.Text = "Yarat";
            btnStokKoduYarat.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnStokKoduYarat.UseAccentColor = false;
            btnStokKoduYarat.UseVisualStyleBackColor = false;
            btnStokKoduYarat.Click += btnStokKoduYarat_Click;
            // 
            // txtMevcudSay
            // 
            txtMevcudSay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtMevcudSay.AnimateReadOnly = false;
            txtMevcudSay.BackColor = Color.FromArgb(255, 255, 255);
            txtMevcudSay.BackgroundImageLayout = ImageLayout.None;
            txtMevcudSay.CharacterCasing = CharacterCasing.Normal;
            txtMevcudSay.Depth = 0;
            txtMevcudSay.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtMevcudSay.HideSelection = true;
            txtMevcudSay.Hint = "Mövcud Say";
            txtMevcudSay.LeadingIcon = null;
            txtMevcudSay.Location = new Point(252, 318);
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
            txtAlisQiymeti.Location = new Point(18, 318);
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
            // txtSatisQiymeti
            // 
            txtSatisQiymeti.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSatisQiymeti.AnimateReadOnly = false;
            txtSatisQiymeti.BackColor = Color.FromArgb(255, 255, 255);
            txtSatisQiymeti.BackgroundImageLayout = ImageLayout.None;
            txtSatisQiymeti.CharacterCasing = CharacterCasing.Normal;
            txtSatisQiymeti.Depth = 0;
            txtSatisQiymeti.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtSatisQiymeti.HideSelection = true;
            txtSatisQiymeti.Hint = "Pərakəndə Satış Qiyməti";
            txtSatisQiymeti.LeadingIcon = null;
            txtSatisQiymeti.Location = new Point(18, 264);
            txtSatisQiymeti.MaxLength = 32767;
            txtSatisQiymeti.MouseState = MaterialSkin.MouseState.OUT;
            txtSatisQiymeti.Name = "txtSatisQiymeti";
            txtSatisQiymeti.PasswordChar = '\0';
            txtSatisQiymeti.PrefixSuffixText = null;
            txtSatisQiymeti.ReadOnly = false;
            txtSatisQiymeti.RightToLeft = RightToLeft.No;
            txtSatisQiymeti.SelectedText = "";
            txtSatisQiymeti.SelectionLength = 0;
            txtSatisQiymeti.SelectionStart = 0;
            txtSatisQiymeti.ShortcutsEnabled = true;
            txtSatisQiymeti.Size = new Size(464, 48);
            txtSatisQiymeti.TabIndex = 4;
            txtSatisQiymeti.TabStop = false;
            txtSatisQiymeti.TextAlign = HorizontalAlignment.Left;
            txtSatisQiymeti.TrailingIcon = null;
            txtSatisQiymeti.UseSystemPasswordChar = false;
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
            // MehsulIdareetmeFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1287, 738);
            Controls.Add(materialTabControl1);
            DrawerShowIconsWhenHidden = true;
            DrawerTabControl = materialTabControl1;
            Name = "MehsulIdareetmeFormu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Məhsul İdarəetməsi";
            Load += MehsulIdareetmeFormu_Load;
            materialTabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMehsullar).EndInit();
            tabPage2.ResumeLayout(false);
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView dgvMehsullar;
        private MaterialSkin.Controls.MaterialTextBox2 txtAxtar;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialComboBox cmbOlcuVahidi;
        private MaterialSkin.Controls.MaterialButton btnYenile;
        private MaterialSkin.Controls.MaterialButton btnElaveEt;
        private MaterialSkin.Controls.MaterialButton btnTemizle;
        private MaterialSkin.Controls.MaterialButton btnSil;
        private MaterialSkin.Controls.MaterialButton btnBarkodYarat;
        private MaterialSkin.Controls.MaterialButton btnStokKoduYarat;
        private MaterialSkin.Controls.MaterialTextBox2 txtMevcudSay;
        private MaterialSkin.Controls.MaterialTextBox2 txtAlisQiymeti;
        private MaterialSkin.Controls.MaterialTextBox2 txtSatisQiymeti;
        private MaterialSkin.Controls.MaterialTextBox2 txtBarkod;
        private MaterialSkin.Controls.MaterialTextBox2 txtStokKodu;
        private MaterialSkin.Controls.MaterialTextBox2 txtAd;
        private TextBox txtId;
    }
}