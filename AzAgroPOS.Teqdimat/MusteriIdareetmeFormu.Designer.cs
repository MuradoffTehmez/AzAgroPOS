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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvMusteriler = new System.Windows.Forms.DataGridView();
            this.txtAxtaris = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.txtKreditLimiti = new MaterialSkin.Controls.MaterialTextBox2();
            this.btnYeni = new MaterialSkin.Controls.MaterialButton();
            this.btnSil = new MaterialSkin.Controls.MaterialButton();
            this.btnYaddaSaxla = new MaterialSkin.Controls.MaterialButton();
            this.txtUnvan = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtTelefon = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtTamAd = new MaterialSkin.Controls.MaterialTextBox2();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMusteriler)).BeginInit();
            this.materialCard1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 64);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvMusteriler);
            this.splitContainer1.Panel1.Controls.Add(this.txtAxtaris);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.materialCard1);
            this.splitContainer1.Size = new System.Drawing.Size(1078, 553);
            this.splitContainer1.SplitterDistance = 650;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgvMusteriler
            // 
            this.dgvMusteriler.AllowUserToAddRows = false;
            this.dgvMusteriler.AllowUserToDeleteRows = false;
            this.dgvMusteriler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMusteriler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMusteriler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMusteriler.Location = new System.Drawing.Point(9, 58);
            this.dgvMusteriler.MultiSelect = false;
            this.dgvMusteriler.Name = "dgvMusteriler";
            this.dgvMusteriler.ReadOnly = true;
            this.dgvMusteriler.RowTemplate.Height = 25;
            this.dgvMusteriler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMusteriler.Size = new System.Drawing.Size(638, 486);
            this.dgvMusteriler.TabIndex = 1;
            this.dgvMusteriler.SelectionChanged += new System.EventHandler(this.dgvMusteriler_SelectionChanged);
            // 
            // txtAxtaris
            // 
            this.txtAxtaris.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAxtaris.AnimateReadOnly = false;
            this.txtAxtaris.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtAxtaris.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAxtaris.Depth = 0;
            this.txtAxtaris.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtAxtaris.HideSelection = true;
            this.txtAxtaris.Hint = "Müştəri axtar (ad, telefon)...";
            this.txtAxtaris.LeadingIcon = null;
            this.txtAxtaris.Location = new System.Drawing.Point(9, 4);
            this.txtAxtaris.MaxLength = 32767;
            this.txtAxtaris.MouseState = MaterialSkin.MouseState.OUT;
            this.txtAxtaris.Name = "txtAxtaris";
            this.txtAxtaris.PasswordChar = '\0';
            this.txtAxtaris.PrefixSuffixText = null;
            this.txtAxtaris.ReadOnly = false;
            this.txtAxtaris.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAxtaris.SelectedText = "";
            this.txtAxtaris.SelectionLength = 0;
            this.txtAxtaris.SelectionStart = 0;
            this.txtAxtaris.ShortcutsEnabled = true;
            this.txtAxtaris.Size = new System.Drawing.Size(638, 48);
            this.txtAxtaris.TabIndex = 0;
            this.txtAxtaris.TabStop = false;
            this.txtAxtaris.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtAxtaris.TrailingIcon = null;
            this.txtAxtaris.UseSystemPasswordChar = false;
            this.txtAxtaris.TextChanged += new System.EventHandler(this.txtAxtaris_TextChanged);
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.txtKreditLimiti);
            this.materialCard1.Controls.Add(this.btnYeni);
            this.materialCard1.Controls.Add(this.btnSil);
            this.materialCard1.Controls.Add(this.btnYaddaSaxla);
            this.materialCard1.Controls.Add(this.txtUnvan);
            this.materialCard1.Controls.Add(this.txtTelefon);
            this.materialCard1.Controls.Add(this.txtTamAd);
            this.materialCard1.Depth = 0;
            this.materialCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(0, 0);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(424, 553);
            this.materialCard1.TabIndex = 0;
            // 
            // txtKreditLimiti
            // 
            this.txtKreditLimiti.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKreditLimiti.AnimateReadOnly = false;
            this.txtKreditLimiti.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtKreditLimiti.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtKreditLimiti.Depth = 0;
            this.txtKreditLimiti.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtKreditLimiti.HideSelection = true;
            this.txtKreditLimiti.Hint = "Kredit Limiti (0 = Limitsiz)";
            this.txtKreditLimiti.LeadingIcon = null;
            this.txtKreditLimiti.Location = new System.Drawing.Point(17, 203);
            this.txtKreditLimiti.MaxLength = 32767;
            this.txtKreditLimiti.MouseState = MaterialSkin.MouseState.OUT;
            this.txtKreditLimiti.Name = "txtKreditLimiti";
            this.txtKreditLimiti.PasswordChar = '\0';
            this.txtKreditLimiti.PrefixSuffixText = null;
            this.txtKreditLimiti.ReadOnly = false;
            this.txtKreditLimiti.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtKreditLimiti.SelectedText = "";
            this.txtKreditLimiti.SelectionLength = 0;
            this.txtKreditLimiti.SelectionStart = 0;
            this.txtKreditLimiti.ShortcutsEnabled = true;
            this.txtKreditLimiti.Size = new System.Drawing.Size(390, 48);
            this.txtKreditLimiti.TabIndex = 3;
            this.txtKreditLimiti.TabStop = false;
            this.txtKreditLimiti.Text = "0";
            this.txtKreditLimiti.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtKreditLimiti.TrailingIcon = null;
            this.txtKreditLimiti.UseSystemPasswordChar = false;
            // 
            // btnYeni
            // 
            this.btnYeni.AutoSize = false;
            this.btnYeni.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnYeni.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnYeni.Depth = 0;
            this.btnYeni.HighEmphasis = false;
            this.btnYeni.Icon = null;
            this.btnYeni.Location = new System.Drawing.Point(18, 276);
            this.btnYeni.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnYeni.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnYeni.Name = "btnYeni";
            this.btnYeni.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnYeni.Size = new System.Drawing.Size(120, 40);
            this.btnYeni.TabIndex = 6;
            this.btnYeni.Text = "Yeni / Ləğv et";
            this.btnYeni.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnYeni.UseAccentColor = false;
            this.btnYeni.UseVisualStyleBackColor = true;
            this.btnYeni.Click += new System.EventHandler(this.btnYeni_Click);
            // 
            // btnSil
            // 
            this.btnSil.AutoSize = false;
            this.btnSil.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSil.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSil.Depth = 0;
            this.btnSil.HighEmphasis = true;
            this.btnSil.Icon = null;
            this.btnSil.Location = new System.Drawing.Point(146, 276);
            this.btnSil.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSil.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSil.Name = "btnSil";
            this.btnSil.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSil.Size = new System.Drawing.Size(120, 40);
            this.btnSil.TabIndex = 5;
            this.btnSil.Text = "Sil";
            this.btnSil.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSil.UseAccentColor = true;
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnYaddaSaxla
            // 
            this.btnYaddaSaxla.AutoSize = false;
            this.btnYaddaSaxla.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnYaddaSaxla.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnYaddaSaxla.Depth = 0;
            this.btnYaddaSaxla.HighEmphasis = true;
            this.btnYaddaSaxla.Icon = null;
            this.btnYaddaSaxla.Location = new System.Drawing.Point(274, 276);
            this.btnYaddaSaxla.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnYaddaSaxla.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnYaddaSaxla.Name = "btnYaddaSaxla";
            this.btnYaddaSaxla.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnYaddaSaxla.Size = new System.Drawing.Size(133, 40);
            this.btnYaddaSaxla.TabIndex = 4;
            this.btnYaddaSaxla.Text = "Yadda Saxla";
            this.btnYaddaSaxla.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnYaddaSaxla.UseAccentColor = false;
            this.btnYaddaSaxla.UseVisualStyleBackColor = true;
            this.btnYaddaSaxla.Click += new System.EventHandler(this.btnYaddaSaxla_Click);
            // 
            // txtUnvan
            // 
            this.txtUnvan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnvan.AnimateReadOnly = false;
            this.txtUnvan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtUnvan.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtUnvan.Depth = 0;
            this.txtUnvan.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtUnvan.HideSelection = true;
            this.txtUnvan.Hint = "Ünvan";
            this.txtUnvan.LeadingIcon = null;
            this.txtUnvan.Location = new System.Drawing.Point(17, 140);
            this.txtUnvan.MaxLength = 32767;
            this.txtUnvan.MouseState = MaterialSkin.MouseState.OUT;
            this.txtUnvan.Name = "txtUnvan";
            this.txtUnvan.PasswordChar = '\0';
            this.txtUnvan.PrefixSuffixText = null;
            this.txtUnvan.ReadOnly = false;
            this.txtUnvan.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUnvan.SelectedText = "";
            this.txtUnvan.SelectionLength = 0;
            this.txtUnvan.SelectionStart = 0;
            this.txtUnvan.ShortcutsEnabled = true;
            this.txtUnvan.Size = new System.Drawing.Size(390, 48);
            this.txtUnvan.TabIndex = 2;
            this.txtUnvan.TabStop = false;
            this.txtUnvan.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUnvan.TrailingIcon = null;
            this.txtUnvan.UseSystemPasswordChar = false;
            // 
            // txtTelefon
            // 
            this.txtTelefon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTelefon.AnimateReadOnly = false;
            this.txtTelefon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtTelefon.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTelefon.Depth = 0;
            this.txtTelefon.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtTelefon.HideSelection = true;
            this.txtTelefon.Hint = "Telefon Nömrəsi";
            this.txtTelefon.LeadingIcon = null;
            this.txtTelefon.Location = new System.Drawing.Point(17, 77);
            this.txtTelefon.MaxLength = 32767;
            this.txtTelefon.MouseState = MaterialSkin.MouseState.OUT;
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.PasswordChar = '\0';
            this.txtTelefon.PrefixSuffixText = null;
            this.txtTelefon.ReadOnly = false;
            this.txtTelefon.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTelefon.SelectedText = "";
            this.txtTelefon.SelectionLength = 0;
            this.txtTelefon.SelectionStart = 0;
            this.txtTelefon.ShortcutsEnabled = true;
            this.txtTelefon.Size = new System.Drawing.Size(390, 48);
            this.txtTelefon.TabIndex = 1;
            this.txtTelefon.TabStop = false;
            this.txtTelefon.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTelefon.TrailingIcon = null;
            this.txtTelefon.UseSystemPasswordChar = false;
            // 
            // txtTamAd
            // 
            this.txtTamAd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTamAd.AnimateReadOnly = false;
            this.txtTamAd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtTamAd.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTamAd.Depth = 0;
            this.txtTamAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtTamAd.HideSelection = true;
            this.txtTamAd.Hint = "Tam Ad";
            this.txtTamAd.LeadingIcon = null;
            this.txtTamAd.Location = new System.Drawing.Point(17, 14);
            this.txtTamAd.MaxLength = 32767;
            this.txtTamAd.MouseState = MaterialSkin.MouseState.OUT;
            this.txtTamAd.Name = "txtTamAd";
            this.txtTamAd.PasswordChar = '\0';
            this.txtTamAd.PrefixSuffixText = null;
            this.txtTamAd.ReadOnly = false;
            this.txtTamAd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTamAd.SelectedText = "";
            this.txtTamAd.SelectionLength = 0;
            this.txtTamAd.SelectionStart = 0;
            this.txtTamAd.ShortcutsEnabled = true;
            this.txtTamAd.Size = new System.Drawing.Size(390, 48);
            this.txtTamAd.TabIndex = 0;
            this.txtTamAd.TabStop = false;
            this.txtTamAd.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTamAd.TrailingIcon = null;
            this.txtTamAd.UseSystemPasswordChar = false;
            // 
            // MusteriIdareetmeFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 620);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MusteriIdareetmeFormu";
            this.Text = "Müştəri İdarəetməsi";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMusteriler)).EndInit();
            this.materialCard1.ResumeLayout(false);
            this.ResumeLayout(false);

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
    }
}