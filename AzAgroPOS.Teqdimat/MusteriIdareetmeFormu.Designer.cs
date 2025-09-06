namespace AzAgroPOS.Teqdimat
{
    partial class MusteriIdareetmeFormu
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
            splitContainer1 = new SplitContainer();
            dgvMusteriler = new DataGridView();
            txtAxtaris = new MaterialSkin.Controls.MaterialTextBox2();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            txtKreditLimiti = new MaterialSkin.Controls.MaterialTextBox2();
            btnYeni = new MaterialSkin.Controls.MaterialButton();
            btnSil = new MaterialSkin.Controls.MaterialButton();
            btnYaddaSaxla = new MaterialSkin.Controls.MaterialButton();
            txtUnvan = new MaterialSkin.Controls.MaterialTextBox2();
            txtTelefon = new MaterialSkin.Controls.MaterialTextBox2();
            txtTamAd = new MaterialSkin.Controls.MaterialTextBox2();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMusteriler).BeginInit();
            materialCard1.SuspendLayout();
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
            splitContainer1.Panel1.Controls.Add(dgvMusteriler);
            splitContainer1.Panel1.Controls.Add(txtAxtaris);
            splitContainer1.Panel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            splitContainer1.Panel1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.FromArgb(242, 242, 242);
            splitContainer1.Panel2.Controls.Add(materialCard1);
            splitContainer1.Panel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            splitContainer1.Panel2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            splitContainer1.Size = new Size(1078, 553);
            splitContainer1.SplitterDistance = 650;
            splitContainer1.TabIndex = 0;
            // 
            // dgvMusteriler
            // 
            dgvMusteriler.AllowUserToAddRows = false;
            dgvMusteriler.AllowUserToDeleteRows = false;
            dgvMusteriler.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMusteriler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMusteriler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMusteriler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvMusteriler.DefaultCellStyle = dataGridViewCellStyle2;
            dgvMusteriler.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvMusteriler.Location = new Point(9, 58);
            dgvMusteriler.MultiSelect = false;
            dgvMusteriler.Name = "dgvMusteriler";
            dgvMusteriler.ReadOnly = true;
            dgvMusteriler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMusteriler.Size = new Size(638, 486);
            dgvMusteriler.TabIndex = 1;
            dgvMusteriler.SelectionChanged += dgvMusteriler_SelectionChanged;
            dgvMusteriler.CellDoubleClick += dgvMusteriler_CellDoubleClick;
            dgvMusteriler.CellDoubleClick += dgvMusteriler_CellDoubleClick;
            // 
            // txtAxtaris
            // 
            txtAxtaris.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAxtaris.AnimateReadOnly = false;
            txtAxtaris.BackColor = Color.FromArgb(242, 242, 242);
            txtAxtaris.BackgroundImageLayout = ImageLayout.None;
            txtAxtaris.CharacterCasing = CharacterCasing.Normal;
            txtAxtaris.Depth = 0;
            txtAxtaris.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtAxtaris.HideSelection = true;
            txtAxtaris.Hint = "Müştəri axtar (ad, telefon)...";
            txtAxtaris.LeadingIcon = null;
            txtAxtaris.Location = new Point(9, 4);
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
            txtAxtaris.Size = new Size(638, 48);
            txtAxtaris.TabIndex = 0;
            txtAxtaris.TabStop = false;
            txtAxtaris.TextAlign = HorizontalAlignment.Left;
            txtAxtaris.TrailingIcon = null;
            txtAxtaris.UseSystemPasswordChar = false;
            txtAxtaris.TextChanged += txtAxtaris_TextChanged;
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(txtKreditLimiti);
            materialCard1.Controls.Add(btnYeni);
            materialCard1.Controls.Add(btnSil);
            materialCard1.Controls.Add(btnYaddaSaxla);
            materialCard1.Controls.Add(txtUnvan);
            materialCard1.Controls.Add(txtTelefon);
            materialCard1.Controls.Add(txtTamAd);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(0, 0);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(424, 553);
            materialCard1.TabIndex = 0;
            // 
            // txtKreditLimiti
            // 
            txtKreditLimiti.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtKreditLimiti.AnimateReadOnly = false;
            txtKreditLimiti.BackColor = Color.FromArgb(255, 255, 255);
            txtKreditLimiti.BackgroundImageLayout = ImageLayout.None;
            txtKreditLimiti.CharacterCasing = CharacterCasing.Normal;
            txtKreditLimiti.Depth = 0;
            txtKreditLimiti.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtKreditLimiti.HideSelection = true;
            txtKreditLimiti.Hint = "Kredit Limiti (0 = Limitsiz)";
            txtKreditLimiti.LeadingIcon = null;
            txtKreditLimiti.Location = new Point(17, 203);
            txtKreditLimiti.MaxLength = 32767;
            txtKreditLimiti.MouseState = MaterialSkin.MouseState.OUT;
            txtKreditLimiti.Name = "txtKreditLimiti";
            txtKreditLimiti.PasswordChar = '\0';
            txtKreditLimiti.PrefixSuffixText = null;
            txtKreditLimiti.ReadOnly = false;
            txtKreditLimiti.RightToLeft = RightToLeft.No;
            txtKreditLimiti.SelectedText = "";
            txtKreditLimiti.SelectionLength = 0;
            txtKreditLimiti.SelectionStart = 0;
            txtKreditLimiti.ShortcutsEnabled = true;
            txtKreditLimiti.Size = new Size(390, 48);
            txtKreditLimiti.TabIndex = 3;
            txtKreditLimiti.TabStop = false;
            txtKreditLimiti.Text = "0";
            txtKreditLimiti.TextAlign = HorizontalAlignment.Left;
            txtKreditLimiti.TrailingIcon = null;
            txtKreditLimiti.UseSystemPasswordChar = false;
            // 
            // btnYeni
            // 
            btnYeni.AutoSize = false;
            btnYeni.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnYeni.BackColor = Color.FromArgb(242, 242, 242);
            btnYeni.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnYeni.Depth = 0;
            btnYeni.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnYeni.HighEmphasis = false;
            btnYeni.Icon = null;
            btnYeni.Location = new Point(18, 276);
            btnYeni.Margin = new Padding(4, 6, 4, 6);
            btnYeni.MouseState = MaterialSkin.MouseState.HOVER;
            btnYeni.Name = "btnYeni";
            btnYeni.NoAccentTextColor = Color.Empty;
            btnYeni.Size = new Size(120, 40);
            btnYeni.TabIndex = 6;
            btnYeni.Text = "Yeni / Ləğv et";
            btnYeni.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnYeni.UseAccentColor = false;
            btnYeni.UseVisualStyleBackColor = false;
            btnYeni.Click += btnYeni_Click;
            // 
            // btnSil
            // 
            btnSil.AutoSize = false;
            btnSil.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSil.BackColor = Color.FromArgb(242, 242, 242);
            btnSil.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSil.Depth = 0;
            btnSil.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnSil.HighEmphasis = true;
            btnSil.Icon = null;
            btnSil.Location = new Point(146, 276);
            btnSil.Margin = new Padding(4, 6, 4, 6);
            btnSil.MouseState = MaterialSkin.MouseState.HOVER;
            btnSil.Name = "btnSil";
            btnSil.NoAccentTextColor = Color.Empty;
            btnSil.Size = new Size(120, 40);
            btnSil.TabIndex = 5;
            btnSil.Text = "Sil";
            btnSil.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSil.UseAccentColor = true;
            btnSil.UseVisualStyleBackColor = false;
            btnSil.Click += btnSil_Click;
            // 
            // btnYaddaSaxla
            // 
            btnYaddaSaxla.AutoSize = false;
            btnYaddaSaxla.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnYaddaSaxla.BackColor = Color.FromArgb(242, 242, 242);
            btnYaddaSaxla.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnYaddaSaxla.Depth = 0;
            btnYaddaSaxla.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnYaddaSaxla.HighEmphasis = true;
            btnYaddaSaxla.Icon = null;
            btnYaddaSaxla.Location = new Point(274, 276);
            btnYaddaSaxla.Margin = new Padding(4, 6, 4, 6);
            btnYaddaSaxla.MouseState = MaterialSkin.MouseState.HOVER;
            btnYaddaSaxla.Name = "btnYaddaSaxla";
            btnYaddaSaxla.NoAccentTextColor = Color.Empty;
            btnYaddaSaxla.Size = new Size(133, 40);
            btnYaddaSaxla.TabIndex = 4;
            btnYaddaSaxla.Text = "Yadda Saxla";
            btnYaddaSaxla.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnYaddaSaxla.UseAccentColor = false;
            btnYaddaSaxla.UseVisualStyleBackColor = false;
            btnYaddaSaxla.Click += btnYaddaSaxla_Click;
            // 
            // txtUnvan
            // 
            txtUnvan.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUnvan.AnimateReadOnly = false;
            txtUnvan.BackColor = Color.FromArgb(255, 255, 255);
            txtUnvan.BackgroundImageLayout = ImageLayout.None;
            txtUnvan.CharacterCasing = CharacterCasing.Normal;
            txtUnvan.Depth = 0;
            txtUnvan.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtUnvan.HideSelection = true;
            txtUnvan.Hint = "Ünvan";
            txtUnvan.LeadingIcon = null;
            txtUnvan.Location = new Point(17, 140);
            txtUnvan.MaxLength = 32767;
            txtUnvan.MouseState = MaterialSkin.MouseState.OUT;
            txtUnvan.Name = "txtUnvan";
            txtUnvan.PasswordChar = '\0';
            txtUnvan.PrefixSuffixText = null;
            txtUnvan.ReadOnly = false;
            txtUnvan.RightToLeft = RightToLeft.No;
            txtUnvan.SelectedText = "";
            txtUnvan.SelectionLength = 0;
            txtUnvan.SelectionStart = 0;
            txtUnvan.ShortcutsEnabled = true;
            txtUnvan.Size = new Size(390, 48);
            txtUnvan.TabIndex = 2;
            txtUnvan.TabStop = false;
            txtUnvan.TextAlign = HorizontalAlignment.Left;
            txtUnvan.TrailingIcon = null;
            txtUnvan.UseSystemPasswordChar = false;
            // 
            // txtTelefon
            // 
            txtTelefon.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTelefon.AnimateReadOnly = false;
            txtTelefon.BackColor = Color.FromArgb(255, 255, 255);
            txtTelefon.BackgroundImageLayout = ImageLayout.None;
            txtTelefon.CharacterCasing = CharacterCasing.Normal;
            txtTelefon.Depth = 0;
            txtTelefon.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtTelefon.HideSelection = true;
            txtTelefon.Hint = "Telefon Nömrəsi";
            txtTelefon.LeadingIcon = null;
            txtTelefon.Location = new Point(17, 77);
            txtTelefon.MaxLength = 32767;
            txtTelefon.MouseState = MaterialSkin.MouseState.OUT;
            txtTelefon.Name = "txtTelefon";
            txtTelefon.PasswordChar = '\0';
            txtTelefon.PrefixSuffixText = null;
            txtTelefon.ReadOnly = false;
            txtTelefon.RightToLeft = RightToLeft.No;
            txtTelefon.SelectedText = "";
            txtTelefon.SelectionLength = 0;
            txtTelefon.SelectionStart = 0;
            txtTelefon.ShortcutsEnabled = true;
            txtTelefon.Size = new Size(390, 48);
            txtTelefon.TabIndex = 1;
            txtTelefon.TabStop = false;
            txtTelefon.TextAlign = HorizontalAlignment.Left;
            txtTelefon.TrailingIcon = null;
            txtTelefon.UseSystemPasswordChar = false;
            // 
            // txtTamAd
            // 
            txtTamAd.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTamAd.AnimateReadOnly = false;
            txtTamAd.BackColor = Color.FromArgb(255, 255, 255);
            txtTamAd.BackgroundImageLayout = ImageLayout.None;
            txtTamAd.CharacterCasing = CharacterCasing.Normal;
            txtTamAd.Depth = 0;
            txtTamAd.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtTamAd.HideSelection = true;
            txtTamAd.Hint = "Tam Ad";
            txtTamAd.LeadingIcon = null;
            txtTamAd.Location = new Point(17, 14);
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
            txtTamAd.Size = new Size(390, 48);
            txtTamAd.TabIndex = 0;
            txtTamAd.TabStop = false;
            txtTamAd.TextAlign = HorizontalAlignment.Left;
            txtTamAd.TrailingIcon = null;
            txtTamAd.UseSystemPasswordChar = false;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // MusteriIdareetmeFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1084, 620);
            Controls.Add(splitContainer1);
            Name = "MusteriIdareetmeFormu";
            Text = "Müştəri İdarəetməsi";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMusteriler).EndInit();
            materialCard1.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private MaterialSkin.Controls.MaterialTextBox2 txtAxtaris;
        private System.Windows.Forms.DataGridView dgvMusteriler;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialTextBox2 txtUnvan;
        private MaterialSkin.Controls.MaterialTextBox2 txtTelefon;
        private MaterialSkin.Controls.MaterialTextBox2 txtTamAd;
        private MaterialSkin.Controls.MaterialButton btnYaddaSaxla;
        private MaterialSkin.Controls.MaterialButton btnYeni;
        private MaterialSkin.Controls.MaterialButton btnSil;
        private MaterialSkin.Controls.MaterialTextBox2 txtKreditLimiti;
        private ErrorProvider errorProvider1;
    }
}