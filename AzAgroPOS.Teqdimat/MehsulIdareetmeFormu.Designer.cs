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
            dgvMehsullar = new DataGridView();
            txtAd = new MaterialSkin.Controls.MaterialTextBox2();
            txtStokKodu = new MaterialSkin.Controls.MaterialTextBox2();
            txtBarkod = new MaterialSkin.Controls.MaterialTextBox2();
            txtSatisQiymeti = new MaterialSkin.Controls.MaterialTextBox2();
            txtMevcudSay = new MaterialSkin.Controls.MaterialTextBox2();
            btnElaveEt = new MaterialSkin.Controls.MaterialButton();
            btnYenile = new MaterialSkin.Controls.MaterialButton();
            btnSil = new MaterialSkin.Controls.MaterialButton();
            btnTemizle = new MaterialSkin.Controls.MaterialButton();
            txtId = new MaterialSkin.Controls.MaterialTextBox2();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            txtAxtar = new MaterialSkin.Controls.MaterialTextBox2();
            ((System.ComponentModel.ISupportInitialize)dgvMehsullar).BeginInit();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvMehsullar
            // 
            dgvMehsullar.AllowUserToAddRows = false;
            dgvMehsullar.AllowUserToDeleteRows = false;
            dgvMehsullar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMehsullar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMehsullar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMehsullar.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvMehsullar.Location = new Point(406, 145);
            dgvMehsullar.Margin = new Padding(4, 3, 4, 3);
            dgvMehsullar.MultiSelect = false;
            dgvMehsullar.Name = "dgvMehsullar";
            dgvMehsullar.ReadOnly = true;
            dgvMehsullar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMehsullar.Size = new Size(861, 573);
            dgvMehsullar.TabIndex = 10;
            dgvMehsullar.SelectionChanged += dgvMehsullar_SelectionChanged;
            // 
            // txtAd
            // 
            txtAd.AnimateReadOnly = false;
            txtAd.BackColor = Color.FromArgb(255, 255, 255);
            txtAd.BackgroundImageLayout = ImageLayout.None;
            txtAd.CharacterCasing = CharacterCasing.Normal;
            txtAd.Depth = 0;
            txtAd.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtAd.HideSelection = true;
            txtAd.Hint = "Məhsulun Adı";
            txtAd.LeadingIcon = null;
            txtAd.Location = new Point(20, 21);
            txtAd.Margin = new Padding(4, 3, 4, 3);
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
            txtAd.Size = new Size(334, 48);
            txtAd.TabIndex = 0;
            txtAd.TabStop = false;
            txtAd.TextAlign = HorizontalAlignment.Left;
            txtAd.TrailingIcon = null;
            txtAd.UseSystemPasswordChar = false;
            // 
            // txtStokKodu
            // 
            txtStokKodu.AnimateReadOnly = false;
            txtStokKodu.BackColor = Color.FromArgb(255, 255, 255);
            txtStokKodu.BackgroundImageLayout = ImageLayout.None;
            txtStokKodu.CharacterCasing = CharacterCasing.Normal;
            txtStokKodu.Depth = 0;
            txtStokKodu.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtStokKodu.HideSelection = true;
            txtStokKodu.Hint = "Stok Kodu (SKU)";
            txtStokKodu.LeadingIcon = null;
            txtStokKodu.Location = new Point(20, 93);
            txtStokKodu.Margin = new Padding(4, 3, 4, 3);
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
            txtStokKodu.Size = new Size(334, 48);
            txtStokKodu.TabIndex = 1;
            txtStokKodu.TabStop = false;
            txtStokKodu.TextAlign = HorizontalAlignment.Left;
            txtStokKodu.TrailingIcon = null;
            txtStokKodu.UseSystemPasswordChar = false;
            // 
            // txtBarkod
            // 
            txtBarkod.AnimateReadOnly = false;
            txtBarkod.BackColor = Color.FromArgb(255, 255, 255);
            txtBarkod.BackgroundImageLayout = ImageLayout.None;
            txtBarkod.CharacterCasing = CharacterCasing.Normal;
            txtBarkod.Depth = 0;
            txtBarkod.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtBarkod.HideSelection = true;
            txtBarkod.Hint = "Barkod";
            txtBarkod.LeadingIcon = null;
            txtBarkod.Location = new Point(20, 166);
            txtBarkod.Margin = new Padding(4, 3, 4, 3);
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
            txtBarkod.Size = new Size(334, 48);
            txtBarkod.TabIndex = 2;
            txtBarkod.TabStop = false;
            txtBarkod.TextAlign = HorizontalAlignment.Left;
            txtBarkod.TrailingIcon = null;
            txtBarkod.UseSystemPasswordChar = false;
            // 
            // txtSatisQiymeti
            // 
            txtSatisQiymeti.AnimateReadOnly = false;
            txtSatisQiymeti.BackColor = Color.FromArgb(255, 255, 255);
            txtSatisQiymeti.BackgroundImageLayout = ImageLayout.None;
            txtSatisQiymeti.CharacterCasing = CharacterCasing.Normal;
            txtSatisQiymeti.Depth = 0;
            txtSatisQiymeti.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtSatisQiymeti.HideSelection = true;
            txtSatisQiymeti.Hint = "Satış Qiyməti";
            txtSatisQiymeti.LeadingIcon = null;
            txtSatisQiymeti.Location = new Point(20, 239);
            txtSatisQiymeti.Margin = new Padding(4, 3, 4, 3);
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
            txtSatisQiymeti.Size = new Size(334, 48);
            txtSatisQiymeti.TabIndex = 3;
            txtSatisQiymeti.TabStop = false;
            txtSatisQiymeti.TextAlign = HorizontalAlignment.Left;
            txtSatisQiymeti.TrailingIcon = null;
            txtSatisQiymeti.UseSystemPasswordChar = false;
            // 
            // txtMevcudSay
            // 
            txtMevcudSay.AnimateReadOnly = false;
            txtMevcudSay.BackColor = Color.FromArgb(255, 255, 255);
            txtMevcudSay.BackgroundImageLayout = ImageLayout.None;
            txtMevcudSay.CharacterCasing = CharacterCasing.Normal;
            txtMevcudSay.Depth = 0;
            txtMevcudSay.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtMevcudSay.HideSelection = true;
            txtMevcudSay.Hint = "Mövcud Say";
            txtMevcudSay.LeadingIcon = null;
            txtMevcudSay.Location = new Point(20, 312);
            txtMevcudSay.Margin = new Padding(4, 3, 4, 3);
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
            txtMevcudSay.Size = new Size(334, 48);
            txtMevcudSay.TabIndex = 4;
            txtMevcudSay.TabStop = false;
            txtMevcudSay.TextAlign = HorizontalAlignment.Left;
            txtMevcudSay.TrailingIcon = null;
            txtMevcudSay.UseSystemPasswordChar = false;
            // 
            // btnElaveEt
            // 
            btnElaveEt.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnElaveEt.BackColor = Color.FromArgb(242, 242, 242);
            btnElaveEt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnElaveEt.Depth = 0;
            btnElaveEt.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnElaveEt.HighEmphasis = true;
            btnElaveEt.Icon = null;
            btnElaveEt.Location = new Point(140, 387);
            btnElaveEt.Margin = new Padding(5, 7, 5, 7);
            btnElaveEt.MouseState = MaterialSkin.MouseState.HOVER;
            btnElaveEt.Name = "btnElaveEt";
            btnElaveEt.NoAccentTextColor = Color.Empty;
            btnElaveEt.Size = new Size(90, 36);
            btnElaveEt.TabIndex = 5;
            btnElaveEt.Text = "Əlavə Et";
            btnElaveEt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnElaveEt.UseAccentColor = false;
            btnElaveEt.UseVisualStyleBackColor = false;
            btnElaveEt.Click += btnElaveEt_Click;
            // 
            // btnYenile
            // 
            btnYenile.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnYenile.BackColor = Color.FromArgb(242, 242, 242);
            btnYenile.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnYenile.Depth = 0;
            btnYenile.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnYenile.HighEmphasis = true;
            btnYenile.Icon = null;
            btnYenile.Location = new Point(261, 387);
            btnYenile.Margin = new Padding(5, 7, 5, 7);
            btnYenile.MouseState = MaterialSkin.MouseState.HOVER;
            btnYenile.Name = "btnYenile";
            btnYenile.NoAccentTextColor = Color.Empty;
            btnYenile.Size = new Size(72, 36);
            btnYenile.TabIndex = 6;
            btnYenile.Text = "Yenilə";
            btnYenile.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnYenile.UseAccentColor = false;
            btnYenile.UseVisualStyleBackColor = false;
            btnYenile.Click += btnYenile_Click;
            // 
            // btnSil
            // 
            btnSil.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSil.BackColor = Color.FromArgb(242, 242, 242);
            btnSil.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSil.Depth = 0;
            btnSil.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnSil.HighEmphasis = true;
            btnSil.Icon = null;
            btnSil.Location = new Point(20, 450);
            btnSil.Margin = new Padding(5, 7, 5, 7);
            btnSil.MouseState = MaterialSkin.MouseState.HOVER;
            btnSil.Name = "btnSil";
            btnSil.NoAccentTextColor = Color.Empty;
            btnSil.Size = new Size(64, 36);
            btnSil.TabIndex = 7;
            btnSil.Text = "Sil";
            btnSil.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSil.UseAccentColor = true;
            btnSil.UseVisualStyleBackColor = false;
            btnSil.Click += btnSil_Click;
            // 
            // btnTemizle
            // 
            btnTemizle.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnTemizle.BackColor = Color.FromArgb(242, 242, 242);
            btnTemizle.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnTemizle.Depth = 0;
            btnTemizle.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnTemizle.HighEmphasis = false;
            btnTemizle.Icon = null;
            btnTemizle.Location = new Point(255, 450);
            btnTemizle.Margin = new Padding(5, 7, 5, 7);
            btnTemizle.MouseState = MaterialSkin.MouseState.HOVER;
            btnTemizle.Name = "btnTemizle";
            btnTemizle.NoAccentTextColor = Color.Empty;
            btnTemizle.Size = new Size(85, 36);
            btnTemizle.TabIndex = 8;
            btnTemizle.Text = "Təmizlə";
            btnTemizle.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnTemizle.UseAccentColor = false;
            btnTemizle.UseVisualStyleBackColor = false;
            btnTemizle.Click += btnTemizle_Click;
            // 
            // txtId
            // 
            txtId.AnimateReadOnly = false;
            txtId.BackColor = Color.FromArgb(255, 255, 255);
            txtId.BackgroundImageLayout = ImageLayout.None;
            txtId.CharacterCasing = CharacterCasing.Normal;
            txtId.Depth = 0;
            txtId.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtId.HideSelection = true;
            txtId.Hint = "ID";
            txtId.LeadingIcon = null;
            txtId.Location = new Point(20, 528);
            txtId.Margin = new Padding(4, 3, 4, 3);
            txtId.MaxLength = 32767;
            txtId.MouseState = MaterialSkin.MouseState.OUT;
            txtId.Name = "txtId";
            txtId.PasswordChar = '\0';
            txtId.PrefixSuffixText = null;
            txtId.ReadOnly = false;
            txtId.RightToLeft = RightToLeft.No;
            txtId.SelectedText = "";
            txtId.SelectionLength = 0;
            txtId.SelectionStart = 0;
            txtId.ShortcutsEnabled = true;
            txtId.Size = new Size(75, 48);
            txtId.TabIndex = 11;
            txtId.TabStop = false;
            txtId.TextAlign = HorizontalAlignment.Left;
            txtId.TrailingIcon = null;
            txtId.UseSystemPasswordChar = false;
            txtId.Visible = false;
            // 
            // materialCard1
            // 
            materialCard1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(txtAd);
            materialCard1.Controls.Add(txtId);
            materialCard1.Controls.Add(txtStokKodu);
            materialCard1.Controls.Add(btnTemizle);
            materialCard1.Controls.Add(txtBarkod);
            materialCard1.Controls.Add(btnSil);
            materialCard1.Controls.Add(txtSatisQiymeti);
            materialCard1.Controls.Add(btnYenile);
            materialCard1.Controls.Add(txtMevcudSay);
            materialCard1.Controls.Add(btnElaveEt);
            materialCard1.Depth = 0;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(20, 83);
            materialCard1.Margin = new Padding(16);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(16);
            materialCard1.Size = new Size(373, 636);
            materialCard1.TabIndex = 12;
            // 
            // txtAxtar
            // 
            txtAxtar.AnimateReadOnly = false;
            txtAxtar.BackColor = Color.FromArgb(242, 242, 242);
            txtAxtar.BackgroundImageLayout = ImageLayout.None;
            txtAxtar.CharacterCasing = CharacterCasing.Normal;
            txtAxtar.Depth = 0;
            txtAxtar.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtAxtar.HideSelection = true;
            txtAxtar.Hint = "Ada, Stok Koduna və ya Barkoda Görə Axtar";
            txtAxtar.LeadingIcon = null;
            txtAxtar.Location = new Point(406, 83);
            txtAxtar.Margin = new Padding(4, 3, 4, 3);
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
            txtAxtar.Size = new Size(542, 48);
            txtAxtar.TabIndex = 9;
            txtAxtar.TabStop = false;
            txtAxtar.TextAlign = HorizontalAlignment.Left;
            txtAxtar.TrailingIcon = null;
            txtAxtar.UseSystemPasswordChar = false;
            txtAxtar.TextChanged += txtAxtar_TextChanged;
            // 
            // MehsulIdareetmeFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1287, 738);
            Controls.Add(txtAxtar);
            Controls.Add(materialCard1);
            Controls.Add(dgvMehsullar);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MehsulIdareetmeFormu";
            Padding = new Padding(4, 74, 4, 3);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Məhsul İdarəetməsi";
            Load += MehsulIdareetmeFormu_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMehsullar).EndInit();
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);

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