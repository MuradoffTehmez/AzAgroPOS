namespace AzAgroPOS.Teqdimat
{
    partial class IstifadeciIdareetmeFormu
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            dgvIstifadeciler = new DataGridView();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            btnSil = new MaterialSkin.Controls.MaterialButton();
            btnYarat = new MaterialSkin.Controls.MaterialButton();
            cmbRollar = new MaterialSkin.Controls.MaterialComboBox();
            txtParol = new MaterialSkin.Controls.MaterialTextBox2();
            txtTamAd = new MaterialSkin.Controls.MaterialTextBox2();
            txtIstifadeciAdi = new MaterialSkin.Controls.MaterialTextBox2();
            txtId = new TextBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIstifadeciler).BeginInit();
            materialCard1.SuspendLayout();
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
            splitContainer1.Panel1.Controls.Add(dgvIstifadeciler);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(materialCard1);
            splitContainer1.Size = new Size(978, 517);
            splitContainer1.SplitterDistance = 550;
            splitContainer1.TabIndex = 0;
            // 
            // dgvIstifadeciler
            // 
            dgvIstifadeciler.AllowUserToAddRows = false;
            dgvIstifadeciler.AllowUserToDeleteRows = false;
            dgvIstifadeciler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIstifadeciler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIstifadeciler.Dock = DockStyle.Fill;
            dgvIstifadeciler.Location = new Point(0, 0);
            dgvIstifadeciler.MultiSelect = false;
            dgvIstifadeciler.Name = "dgvIstifadeciler";
            dgvIstifadeciler.ReadOnly = true;
            dgvIstifadeciler.RowTemplate.Height = 25;
            dgvIstifadeciler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIstifadeciler.Size = new Size(550, 517);
            dgvIstifadeciler.TabIndex = 0;
            dgvIstifadeciler.SelectionChanged += dgvIstifadeciler_SelectionChanged;
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(btnSil);
            materialCard1.Controls.Add(btnYarat);
            materialCard1.Controls.Add(cmbRollar);
            materialCard1.Controls.Add(txtParol);
            materialCard1.Controls.Add(txtTamAd);
            materialCard1.Controls.Add(txtIstifadeciAdi);
            materialCard1.Controls.Add(txtId);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(0, 0);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(424, 517);
            materialCard1.TabIndex = 2;
            // 
            // btnSil
            // 
            btnSil.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSil.AutoSize = false;
            btnSil.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSil.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSil.Depth = 0;
            btnSil.HighEmphasis = true;
            btnSil.Icon = null;
            btnSil.Location = new Point(17, 461);
            btnSil.Margin = new Padding(4, 6, 4, 6);
            btnSil.MouseState = MaterialSkin.MouseState.HOVER;
            btnSil.Name = "btnSil";
            btnSil.NoAccentTextColor = Color.Empty;
            btnSil.Size = new Size(180, 40);
            btnSil.TabIndex = 5;
            btnSil.Text = "Seçilmişi Sil";
            btnSil.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSil.UseAccentColor = true;
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // btnYarat
            // 
            btnYarat.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnYarat.AutoSize = false;
            btnYarat.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnYarat.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnYarat.Depth = 0;
            btnYarat.HighEmphasis = true;
            btnYarat.Icon = null;
            btnYarat.Location = new Point(218, 461);
            btnYarat.Margin = new Padding(4, 6, 4, 6);
            btnYarat.MouseState = MaterialSkin.MouseState.HOVER;
            btnYarat.Name = "btnYarat";
            btnYarat.NoAccentTextColor = Color.Empty;
            btnYarat.Size = new Size(180, 40);
            btnYarat.TabIndex = 4;
            btnYarat.Text = "Yarat / Yenilə";
            btnYarat.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnYarat.UseAccentColor = false;
            btnYarat.UseVisualStyleBackColor = true;
            btnYarat.Click += btnYarat_Click;
            // 
            // cmbRollar
            // 
            cmbRollar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbRollar.AutoResize = false;
            cmbRollar.BackColor = Color.FromArgb(255, 255, 255);
            cmbRollar.Depth = 0;
            cmbRollar.DrawMode = DrawMode.OwnerDrawVariable;
            cmbRollar.DropDownHeight = 174;
            cmbRollar.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRollar.DropDownWidth = 121;
            cmbRollar.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbRollar.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbRollar.Hint = "Rol";
            cmbRollar.IntegralHeight = false;
            cmbRollar.ItemHeight = 43;
            cmbRollar.Location = new Point(17, 186);
            cmbRollar.MaxDropDownItems = 4;
            cmbRollar.MouseState = MaterialSkin.MouseState.OUT;
            cmbRollar.Name = "cmbRollar";
            cmbRollar.Size = new Size(381, 49);
            cmbRollar.StartIndex = 0;
            cmbRollar.TabIndex = 3;
            // 
            // txtParol
            // 
            txtParol.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtParol.AnimateReadOnly = false;
            txtParol.BackgroundImageLayout = ImageLayout.None;
            txtParol.CharacterCasing = CharacterCasing.Normal;
            txtParol.Depth = 0;
            txtParol.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtParol.HideSelection = true;
            txtParol.Hint = "Parol (Boş buraxsanız dəyişməyəcək)";
            txtParol.LeadingIcon = null;
            txtParol.Location = new Point(17, 132);
            txtParol.MaxLength = 32767;
            txtParol.MouseState = MaterialSkin.MouseState.OUT;
            txtParol.Name = "txtParol";
            txtParol.PasswordChar = '●';
            txtParol.PrefixSuffixText = null;
            txtParol.ReadOnly = false;
            txtParol.RightToLeft = RightToLeft.No;
            txtParol.SelectedText = "";
            txtParol.SelectionLength = 0;
            txtParol.SelectionStart = 0;
            txtParol.ShortcutsEnabled = true;
            txtParol.Size = new Size(381, 48);
            txtParol.TabIndex = 2;
            txtParol.TabStop = false;
            txtParol.TextAlign = HorizontalAlignment.Left;
            txtParol.TrailingIcon = null;
            txtParol.UseSystemPasswordChar = true;
            // 
            // txtTamAd
            // 
            txtTamAd.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTamAd.AnimateReadOnly = false;
            txtTamAd.BackgroundImageLayout = ImageLayout.None;
            txtTamAd.CharacterCasing = CharacterCasing.Normal;
            txtTamAd.Depth = 0;
            txtTamAd.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtTamAd.HideSelection = true;
            txtTamAd.Hint = "Tam Ad";
            txtTamAd.LeadingIcon = null;
            txtTamAd.Location = new Point(17, 78);
            txtTamAd.MaxLength = 32767;
            txtTamAd.MouseState = MaterialSkin.MouseState.OUT;
            txtTamAd.Name = "txtTamAd";
            txtTamAd.PasswordChar = '\0';
            txtTamAd.PrefixSuffixText = null;
            txtTamAd.ReadOnly = false;
            txtTamAd.RightToLeft = RightToLeft.No;
            txtTamAd.SelectedText = "";
            txtTamAd.SelectionLength = 0;
            txtTamAd.SelectionStart = 0;
            txtTamAd.ShortcutsEnabled = true;
            txtTamAd.Size = new Size(381, 48);
            txtTamAd.TabIndex = 1;
            txtTamAd.TabStop = false;
            txtTamAd.TextAlign = HorizontalAlignment.Left;
            txtTamAd.TrailingIcon = null;
            txtTamAd.UseSystemPasswordChar = false;
            // 
            // txtIstifadeciAdi
            // 
            txtIstifadeciAdi.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtIstifadeciAdi.AnimateReadOnly = false;
            txtIstifadeciAdi.BackgroundImageLayout = ImageLayout.None;
            txtIstifadeciAdi.CharacterCasing = CharacterCasing.Normal;
            txtIstifadeciAdi.Depth = 0;
            txtIstifadeciAdi.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtIstifadeciAdi.HideSelection = true;
            txtIstifadeciAdi.Hint = "İstifadəçi Adı";
            txtIstifadeciAdi.LeadingIcon = null;
            txtIstifadeciAdi.Location = new Point(17, 24);
            txtIstifadeciAdi.MaxLength = 32767;
            txtIstifadeciAdi.MouseState = MaterialSkin.MouseState.OUT;
            txtIstifadeciAdi.Name = "txtIstifadeciAdi";
            txtIstifadeciAdi.PasswordChar = '\0';
            txtIstifadeciAdi.PrefixSuffixText = null;
            txtIstifadeciAdi.ReadOnly = false;
            txtIstifadeciAdi.RightToLeft = RightToLeft.No;
            txtIstifadeciAdi.SelectedText = "";
            txtIstifadeciAdi.SelectionLength = 0;
            txtIstifadeciAdi.SelectionStart = 0;
            txtIstifadeciAdi.ShortcutsEnabled = true;
            txtIstifadeciAdi.Size = new Size(381, 48);
            txtIstifadeciAdi.TabIndex = 0;
            txtIstifadeciAdi.TabStop = false;
            txtIstifadeciAdi.TextAlign = HorizontalAlignment.Left;
            txtIstifadeciAdi.TrailingIcon = null;
            txtIstifadeciAdi.UseSystemPasswordChar = false;
            // 
            // txtId
            // 
            txtId.Location = new Point(17, 252);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 6;
            txtId.Visible = false;
            // 
            // IstifadeciIdareetmeFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 584);
            Controls.Add(splitContainer1);
            Name = "IstifadeciIdareetmeFormu";
            Padding = new Padding(3, 64, 3, 3);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "İstifadəçi İdarəetməsi";
            Load += IstifadeciIdareetmeFormu_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvIstifadeciler).EndInit();
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private DataGridView dgvIstifadeciler;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialButton btnSil;
        private MaterialSkin.Controls.MaterialButton btnYarat;
        private MaterialSkin.Controls.MaterialComboBox cmbRollar;
        private MaterialSkin.Controls.MaterialTextBox2 txtParol;
        private MaterialSkin.Controls.MaterialTextBox2 txtTamAd;
        private MaterialSkin.Controls.MaterialTextBox2 txtIstifadeciAdi;
        private TextBox txtId;
    }
}