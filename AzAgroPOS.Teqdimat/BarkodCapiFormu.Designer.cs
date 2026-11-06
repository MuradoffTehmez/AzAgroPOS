// Fayl: AzAgroPOS.Teqdimat/BarkodCapiFormu.Designer.cs
namespace AzAgroPOS.Teqdimat
{
    partial class BarkodCapiFormu
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
            splitContainer1 = new SplitContainer();
            lblAxtarisXeta = new MaterialSkin.Controls.MaterialLabel();
            btnSiyahiyaElaveEt = new MaterialSkin.Controls.MaterialButton();
            dgvAxtarisNeticeleri = new DataGridView();
            btnAxtar = new MaterialSkin.Controls.MaterialButton();
            txtAxtar = new MaterialSkin.Controls.MaterialTextBox2();
            btnCapiBaslat = new MaterialSkin.Controls.MaterialButton();
            btnSiyahidanSil = new MaterialSkin.Controls.MaterialButton();
            dgvCapSiyahisi = new DataGridView();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAxtarisNeticeleri).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCapSiyahisi).BeginInit();
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
            splitContainer1.Panel1.Controls.Add(lblAxtarisXeta);
            splitContainer1.Panel1.Controls.Add(btnSiyahiyaElaveEt);
            splitContainer1.Panel1.Controls.Add(dgvAxtarisNeticeleri);
            splitContainer1.Panel1.Controls.Add(btnAxtar);
            splitContainer1.Panel1.Controls.Add(txtAxtar);
            splitContainer1.Panel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            splitContainer1.Panel1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.FromArgb(242, 242, 242);
            splitContainer1.Panel2.Controls.Add(btnCapiBaslat);
            splitContainer1.Panel2.Controls.Add(btnSiyahidanSil);
            splitContainer1.Panel2.Controls.Add(dgvCapSiyahisi);
            splitContainer1.Panel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            splitContainer1.Panel2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            splitContainer1.Size = new Size(1278, 649);
            splitContainer1.SplitterDistance = 600;
            splitContainer1.TabIndex = 0;
            // 
            // lblAxtarisXeta
            // 
            lblAxtarisXeta.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblAxtarisXeta.BackColor = Color.FromArgb(242, 242, 242);
            lblAxtarisXeta.Depth = 0;
            lblAxtarisXeta.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblAxtarisXeta.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblAxtarisXeta.Location = new Point(22, 128);
            lblAxtarisXeta.MouseState = MaterialSkin.MouseState.HOVER;
            lblAxtarisXeta.Name = "lblAxtarisXeta";
            lblAxtarisXeta.Size = new Size(556, 445);
            lblAxtarisXeta.TabIndex = 4;
            lblAxtarisXeta.Text = "Axtarışa uyğun məhsul tapılmadı.";
            lblAxtarisXeta.TextAlign = ContentAlignment.MiddleCenter;
            lblAxtarisXeta.Visible = false;
            // 
            // btnSiyahiyaElaveEt
            // 
            btnSiyahiyaElaveEt.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSiyahiyaElaveEt.AutoSize = false;
            btnSiyahiyaElaveEt.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSiyahiyaElaveEt.BackColor = Color.FromArgb(242, 242, 242);
            btnSiyahiyaElaveEt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSiyahiyaElaveEt.Depth = 0;
            btnSiyahiyaElaveEt.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnSiyahiyaElaveEt.HighEmphasis = true;
            btnSiyahiyaElaveEt.Icon = null;
            btnSiyahiyaElaveEt.Location = new Point(410, 594);
            btnSiyahiyaElaveEt.Margin = new Padding(4, 6, 4, 6);
            btnSiyahiyaElaveEt.MouseState = MaterialSkin.MouseState.HOVER;
            btnSiyahiyaElaveEt.Name = "btnSiyahiyaElaveEt";
            btnSiyahiyaElaveEt.NoAccentTextColor = Color.Empty;
            btnSiyahiyaElaveEt.Size = new Size(168, 36);
            btnSiyahiyaElaveEt.TabIndex = 3;
            btnSiyahiyaElaveEt.Text = "Siyahıya Əlavə Et >>";
            btnSiyahiyaElaveEt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSiyahiyaElaveEt.UseAccentColor = false;
            btnSiyahiyaElaveEt.UseVisualStyleBackColor = false;
            btnSiyahiyaElaveEt.Click += btnSiyahiyaElaveEt_Click;
            // 
            // dgvAxtarisNeticeleri
            // 
            dgvAxtarisNeticeleri.AllowUserToAddRows = false;
            dgvAxtarisNeticeleri.AllowUserToDeleteRows = false;
            dgvAxtarisNeticeleri.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAxtarisNeticeleri.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvAxtarisNeticeleri.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvAxtarisNeticeleri.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvAxtarisNeticeleri.DefaultCellStyle = dataGridViewCellStyle2;
            dgvAxtarisNeticeleri.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvAxtarisNeticeleri.Location = new Point(22, 73);
            dgvAxtarisNeticeleri.MultiSelect = false;
            dgvAxtarisNeticeleri.Name = "dgvAxtarisNeticeleri";
            dgvAxtarisNeticeleri.ReadOnly = true;
            dgvAxtarisNeticeleri.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAxtarisNeticeleri.Size = new Size(556, 500);
            dgvAxtarisNeticeleri.TabIndex = 2;
            // 
            // btnAxtar
            // 
            btnAxtar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAxtar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAxtar.BackColor = Color.FromArgb(242, 242, 242);
            btnAxtar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnAxtar.Depth = 0;
            btnAxtar.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnAxtar.HighEmphasis = true;
            btnAxtar.Icon = null;
            btnAxtar.Location = new Point(510, 23);
            btnAxtar.Margin = new Padding(4, 6, 4, 6);
            btnAxtar.MouseState = MaterialSkin.MouseState.HOVER;
            btnAxtar.Name = "btnAxtar";
            btnAxtar.NoAccentTextColor = Color.Empty;
            btnAxtar.Size = new Size(68, 36);
            btnAxtar.TabIndex = 1;
            btnAxtar.Text = "Axtar";
            btnAxtar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAxtar.UseAccentColor = false;
            btnAxtar.UseVisualStyleBackColor = false;
            btnAxtar.Click += btnAxtar_Click;
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
            txtAxtar.Hint = "Məhsul adı, stok kodu və ya barkod";
            txtAxtar.LeadingIcon = null;
            txtAxtar.Location = new Point(22, 17);
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
            txtAxtar.Size = new Size(473, 48);
            txtAxtar.TabIndex = 0;
            txtAxtar.TabStop = false;
            txtAxtar.TextAlign = HorizontalAlignment.Left;
            txtAxtar.TrailingIcon = null;
            txtAxtar.UseSystemPasswordChar = false;
            // 
            // btnCapiBaslat
            // 
            btnCapiBaslat.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCapiBaslat.AutoSize = false;
            btnCapiBaslat.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnCapiBaslat.BackColor = Color.FromArgb(242, 242, 242);
            btnCapiBaslat.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnCapiBaslat.Depth = 0;
            btnCapiBaslat.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnCapiBaslat.HighEmphasis = true;
            btnCapiBaslat.Icon = null;
            btnCapiBaslat.Location = new Point(483, 594);
            btnCapiBaslat.Margin = new Padding(4, 6, 4, 6);
            btnCapiBaslat.MouseState = MaterialSkin.MouseState.HOVER;
            btnCapiBaslat.Name = "btnCapiBaslat";
            btnCapiBaslat.NoAccentTextColor = Color.Empty;
            btnCapiBaslat.Size = new Size(168, 36);
            btnCapiBaslat.TabIndex = 5;
            btnCapiBaslat.Text = "Çapı Başlat";
            btnCapiBaslat.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnCapiBaslat.UseAccentColor = true;
            btnCapiBaslat.UseVisualStyleBackColor = false;
            btnCapiBaslat.Click += btnCapiBaslat_Click;
            // 
            // btnSiyahidanSil
            // 
            btnSiyahidanSil.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSiyahidanSil.AutoSize = false;
            btnSiyahidanSil.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSiyahidanSil.BackColor = Color.FromArgb(242, 242, 242);
            btnSiyahidanSil.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSiyahidanSil.Depth = 0;
            btnSiyahidanSil.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnSiyahidanSil.HighEmphasis = false;
            btnSiyahidanSil.Icon = null;
            btnSiyahidanSil.Location = new Point(22, 594);
            btnSiyahidanSil.Margin = new Padding(4, 6, 4, 6);
            btnSiyahidanSil.MouseState = MaterialSkin.MouseState.HOVER;
            btnSiyahidanSil.Name = "btnSiyahidanSil";
            btnSiyahidanSil.NoAccentTextColor = Color.Empty;
            btnSiyahidanSil.Size = new Size(168, 36);
            btnSiyahidanSil.TabIndex = 4;
            btnSiyahidanSil.Text = "Seçilmişi Sil";
            btnSiyahidanSil.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnSiyahidanSil.UseAccentColor = false;
            btnSiyahidanSil.UseVisualStyleBackColor = false;
            btnSiyahidanSil.Click += btnSiyahidanSil_Click;
            // 
            // dgvCapSiyahisi
            // 
            dgvCapSiyahisi.AllowUserToAddRows = false;
            dgvCapSiyahisi.AllowUserToDeleteRows = false;
            dgvCapSiyahisi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCapSiyahisi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvCapSiyahisi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvCapSiyahisi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvCapSiyahisi.DefaultCellStyle = dataGridViewCellStyle4;
            dgvCapSiyahisi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvCapSiyahisi.Location = new Point(22, 17);
            dgvCapSiyahisi.MultiSelect = false;
            dgvCapSiyahisi.Name = "dgvCapSiyahisi";
            dgvCapSiyahisi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCapSiyahisi.Size = new Size(629, 556);
            dgvCapSiyahisi.TabIndex = 3;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // BarkodCapiFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1284, 738);
            Controls.Add(splitContainer1);
            Name = "BarkodCapiFormu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Barkod Etiketi Çapı";
            Controls.SetChildIndex(splitContainer1, 0);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAxtarisNeticeleri).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCapSiyahisi).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SplitContainer splitContainer1;
        private MaterialSkin.Controls.MaterialTextBox2 txtAxtar;
        private MaterialSkin.Controls.MaterialButton btnAxtar;
        private DataGridView dgvAxtarisNeticeleri;
        private MaterialSkin.Controls.MaterialButton btnSiyahiyaElaveEt;
        private DataGridView dgvCapSiyahisi;
        private MaterialSkin.Controls.MaterialButton btnCapiBaslat;
        private MaterialSkin.Controls.MaterialButton btnSiyahidanSil;
        private MaterialSkin.Controls.MaterialLabel lblAxtarisXeta;
        private ErrorProvider errorProvider1;
    }
}