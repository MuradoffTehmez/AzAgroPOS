// Fayl: AzAgroPOS.Teqdimat/MehsulIdareetmeFormu.Designer.cs
namespace AzAgroPOS.Teqdimat
{
    partial class MehsulIdareetmeFormu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
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
            this.dgvMehsullar = new System.Windows.Forms.DataGridView();
            this.txtAd = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtStokKodu = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtBarkod = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtSatisQiymeti = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtMevcudSay = new MaterialSkin.Controls.MaterialTextBox2();
            this.btnElaveEt = new MaterialSkin.Controls.MaterialButton();
            this.btnYenile = new MaterialSkin.Controls.MaterialButton();
            this.btnSil = new MaterialSkin.Controls.MaterialButton();
            this.btnTemizle = new MaterialSkin.Controls.MaterialButton();
            this.txtId = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.txtAxtar = new MaterialSkin.Controls.MaterialTextBox2();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMehsullar)).BeginInit();
            this.materialCard1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMehsullar
            // 
            this.dgvMehsullar.AllowUserToAddRows = false;
            this.dgvMehsullar.AllowUserToDeleteRows = false;
            this.dgvMehsullar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMehsullar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMehsullar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMehsullar.Location = new System.Drawing.Point(348, 126);
            this.dgvMehsullar.MultiSelect = false;
            this.dgvMehsullar.Name = "dgvMehsullar";
            this.dgvMehsullar.ReadOnly = true;
            this.dgvMehsullar.RowTemplate.Height = 25;
            this.dgvMehsullar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMehsullar.Size = new System.Drawing.Size(738, 497);
            this.dgvMehsullar.TabIndex = 10;
            this.dgvMehsullar.SelectionChanged += new System.EventHandler(this.dgvMehsullar_SelectionChanged);
            // 
            // txtAd
            // 
            this.txtAd.AnimateReadOnly = false;
            this.txtAd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtAd.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAd.Depth = 0;
            this.txtAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtAd.HideSelection = true;
            this.txtAd.Hint = "Məhsulun Adı";
            this.txtAd.LeadingIcon = null;
            this.txtAd.Location = new System.Drawing.Point(17, 18);
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
            this.txtAd.Size = new System.Drawing.Size(286, 48);
            this.txtAd.TabIndex = 0;
            this.txtAd.TabStop = false;
            this.txtAd.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtAd.TrailingIcon = null;
            this.txtAd.UseSystemPasswordChar = false;
            // 
            // txtStokKodu
            // 
            this.txtStokKodu.AnimateReadOnly = false;
            this.txtStokKodu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtStokKodu.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtStokKodu.Depth = 0;
            this.txtStokKodu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtStokKodu.HideSelection = true;
            this.txtStokKodu.Hint = "Stok Kodu (SKU)";
            this.txtStokKodu.LeadingIcon = null;
            this.txtStokKodu.Location = new System.Drawing.Point(17, 81);
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
            this.txtStokKodu.Size = new System.Drawing.Size(286, 48);
            this.txtStokKodu.TabIndex = 1;
            this.txtStokKodu.TabStop = false;
            this.txtStokKodu.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtStokKodu.TrailingIcon = null;
            this.txtStokKodu.UseSystemPasswordChar = false;
            // 
            // txtBarkod
            // 
            this.txtBarkod.AnimateReadOnly = false;
            this.txtBarkod.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtBarkod.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBarkod.Depth = 0;
            this.txtBarkod.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtBarkod.HideSelection = true;
            this.txtBarkod.Hint = "Barkod";
            this.txtBarkod.LeadingIcon = null;
            this.txtBarkod.Location = new System.Drawing.Point(17, 144);
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
            this.txtBarkod.Size = new System.Drawing.Size(286, 48);
            this.txtBarkod.TabIndex = 2;
            this.txtBarkod.TabStop = false;
            this.txtBarkod.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtBarkod.TrailingIcon = null;
            this.txtBarkod.UseSystemPasswordChar = false;
            // 
            // txtSatisQiymeti
            // 
            this.txtSatisQiymeti.AnimateReadOnly = false;
            this.txtSatisQiymeti.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtSatisQiymeti.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSatisQiymeti.Depth = 0;
            this.txtSatisQiymeti.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtSatisQiymeti.HideSelection = true;
            this.txtSatisQiymeti.Hint = "Satış Qiyməti";
            this.txtSatisQiymeti.LeadingIcon = null;
            this.txtSatisQiymeti.Location = new System.Drawing.Point(17, 207);
            this.txtSatisQiymeti.MaxLength = 32767;
            this.txtSatisQiymeti.MouseState = MaterialSkin.MouseState.OUT;
            this.txtSatisQiymeti.Name = "txtSatisQiymeti";
            this.txtSatisQiymeti.PasswordChar = '\0';
            this.txtSatisQiymeti.PrefixSuffixText = null;
            this.txtSatisQiymeti.ReadOnly = false;
            this.txtSatisQiymeti.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSatisQiymeti.SelectedText = "";
            this.txtSatisQiymeti.SelectionLength = 0;
            this.txtSatisQiymeti.SelectionStart = 0;
            this.txtSatisQiymeti.ShortcutsEnabled = true;
            this.txtSatisQiymeti.Size = new System.Drawing.Size(286, 48);
            this.txtSatisQiymeti.TabIndex = 3;
            this.txtSatisQiymeti.TabStop = false;
            this.txtSatisQiymeti.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSatisQiymeti.TrailingIcon = null;
            this.txtSatisQiymeti.UseSystemPasswordChar = false;
            // 
            // txtMevcudSay
            // 
            this.txtMevcudSay.AnimateReadOnly = false;
            this.txtMevcudSay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtMevcudSay.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMevcudSay.Depth = 0;
            this.txtMevcudSay.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtMevcudSay.HideSelection = true;
            this.txtMevcudSay.Hint = "Mövcud Say";
            this.txtMevcudSay.LeadingIcon = null;
            this.txtMevcudSay.Location = new System.Drawing.Point(17, 270);
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
            this.txtMevcudSay.Size = new System.Drawing.Size(286, 48);
            this.txtMevcudSay.TabIndex = 4;
            this.txtMevcudSay.TabStop = false;
            this.txtMevcudSay.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtMevcudSay.TrailingIcon = null;
            this.txtMevcudSay.UseSystemPasswordChar = false;
            // 
            // btnElaveEt
            // 
            this.btnElaveEt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnElaveEt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnElaveEt.Depth = 0;
            this.btnElaveEt.HighEmphasis = true;
            this.btnElaveEt.Icon = null;
            this.btnElaveEt.Location = new System.Drawing.Point(120, 335);
            this.btnElaveEt.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnElaveEt.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnElaveEt.Name = "btnElaveEt";
            this.btnElaveEt.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnElaveEt.Size = new System.Drawing.Size(87, 36);
            this.btnElaveEt.TabIndex = 5;
            this.btnElaveEt.Text = "Əlavə Et";
            this.btnElaveEt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnElaveEt.UseAccentColor = false;
            this.btnElaveEt.UseVisualStyleBackColor = true;
            this.btnElaveEt.Click += new System.EventHandler(this.btnElaveEt_Click);
            // 
            // btnYenile
            // 
            this.btnYenile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnYenile.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnYenile.Depth = 0;
            this.btnYenile.HighEmphasis = true;
            this.btnYenile.Icon = null;
            this.btnYenile.Location = new System.Drawing.Point(224, 335);
            this.btnYenile.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnYenile.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnYenile.Size = new System.Drawing.Size(79, 36);
            this.btnYenile.TabIndex = 6;
            this.btnYenile.Text = "Yenilə";
            this.btnYenile.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnYenile.UseAccentColor = false;
            this.btnYenile.UseVisualStyleBackColor = true;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // btnSil
            // 
            this.btnSil.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSil.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSil.Depth = 0;
            this.btnSil.HighEmphasis = true;
            this.btnSil.Icon = null;
            this.btnSil.Location = new System.Drawing.Point(17, 390);
            this.btnSil.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSil.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSil.Name = "btnSil";
            this.btnSil.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSil.Size = new System.Drawing.Size(64, 36);
            this.btnSil.TabIndex = 7;
            this.btnSil.Text = "Sil";
            this.btnSil.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSil.UseAccentColor = true;
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnTemizle
            // 
            this.btnTemizle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTemizle.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnTemizle.Depth = 0;
            this.btnTemizle.HighEmphasis = false;
            this.btnTemizle.Icon = null;
            this.btnTemizle.Location = new System.Drawing.Point(219, 390);
            this.btnTemizle.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnTemizle.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnTemizle.Size = new System.Drawing.Size(84, 36);
            this.btnTemizle.TabIndex = 8;
            this.btnTemizle.Text = "Təmizlə";
            this.btnTemizle.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnTemizle.UseAccentColor = false;
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // txtId
            // 
            this.txtId.AnimateReadOnly = false;
            this.txtId.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtId.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtId.Depth = 0;
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtId.HideSelection = true;
            this.txtId.Hint = "ID";
            this.txtId.LeadingIcon = null;
            this.txtId.Location = new System.Drawing.Point(17, 458);
            this.txtId.MaxLength = 32767;
            this.txtId.MouseState = MaterialSkin.MouseState.OUT;
            this.txtId.Name = "txtId";
            this.txtId.PasswordChar = '\0';
            this.txtId.PrefixSuffixText = null;
            this.txtId.ReadOnly = false;
            this.txtId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtId.SelectedText = "";
            this.txtId.SelectionLength = 0;
            this.txtId.SelectionStart = 0;
            this.txtId.ShortcutsEnabled = true;
            this.txtId.Size = new System.Drawing.Size(64, 48);
            this.txtId.TabIndex = 11;
            this.txtId.TabStop = false;
            this.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtId.TrailingIcon = null;
            this.txtId.UseSystemPasswordChar = false;
            this.txtId.Visible = false;
            // 
            // materialCard1
            // 
            this.materialCard1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.txtAd);
            this.materialCard1.Controls.Add(this.txtId);
            this.materialCard1.Controls.Add(this.txtStokKodu);
            this.materialCard1.Controls.Add(this.btnTemizle);
            this.materialCard1.Controls.Add(this.txtBarkod);
            this.materialCard1.Controls.Add(this.btnSil);
            this.materialCard1.Controls.Add(this.txtSatisQiymeti);
            this.materialCard1.Controls.Add(this.btnYenile);
            this.materialCard1.Controls.Add(this.txtMevcudSay);
            this.materialCard1.Controls.Add(this.btnElaveEt);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(17, 72);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(320, 551);
            this.materialCard1.TabIndex = 12;
            // 
            // txtAxtar
            // 
            this.txtAxtar.AnimateReadOnly = false;
            this.txtAxtar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtAxtar.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAxtar.Depth = 0;
            this.txtAxtar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtAxtar.HideSelection = true;
            this.txtAxtar.Hint = "Ada, Stok Koduna və ya Barkoda Görə Axtar";
            this.txtAxtar.LeadingIcon = null;
            this.txtAxtar.Location = new System.Drawing.Point(348, 72);
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
            this.txtAxtar.Size = new System.Drawing.Size(465, 48);
            this.txtAxtar.TabIndex = 9;
            this.txtAxtar.TabStop = false;
            this.txtAxtar.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtAxtar.TrailingIcon = null;
            this.txtAxtar.UseSystemPasswordChar = false;
            this.txtAxtar.TextChanged += new System.EventHandler(this.txtAxtar_TextChanged);
            // 
            // MehsulIdareetmeFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 640);
            this.Controls.Add(this.txtAxtar);
            this.Controls.Add(this.materialCard1);
            this.Controls.Add(this.dgvMehsullar);
            this.Name = "MehsulIdareetmeFormu";
            this.Padding = new System.Windows.Forms.Padding(3, 64, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Məhsul İdarəetməsi";
            this.Load += new System.EventHandler(this.MehsulIdareetmeFormu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMehsullar)).EndInit();
            this.materialCard1.ResumeLayout(false);
            this.materialCard1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMehsullar;
        private MaterialSkin.Controls.MaterialTextBox2 txtAd;
        private MaterialSkin.Controls.MaterialTextBox2 txtStokKodu;
        private MaterialSkin.Controls.MaterialTextBox2 txtBarkod;
        private MaterialSkin.Controls.MaterialTextBox2 txtSatisQiymeti;
        private MaterialSkin.Controls.MaterialTextBox2 txtMevcudSay;
        private MaterialSkin.Controls.MaterialButton btnElaveEt;
        private MaterialSkin.Controls.MaterialButton btnYenile;
        private MaterialSkin.Controls.MaterialButton btnSil;
        private MaterialSkin.Controls.MaterialButton btnTemizle;
        private MaterialSkin.Controls.MaterialTextBox2 txtId;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialTextBox2 txtAxtar;
    }
}