// Fayl: AzAgroPOS.Teqdimat/IstifadeciIdareetmeFormu.Designer.cs
namespace AzAgroPOS.Teqdimat
{
    partial class IstifadeciIdareetmeFormu
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            dgvIstifadeciler = new DataGridView();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            btnSil = new MaterialSkin.Controls.MaterialButton();
            btnYarat = new MaterialSkin.Controls.MaterialButton();
            cmbRollar = new MaterialSkin.Controls.MaterialComboBox();
            txtParol = new MaterialSkin.Controls.MaterialTextBox2();
            txtTamAd = new MaterialSkin.Controls.MaterialTextBox2();
            txtIstifadeciAdi = new MaterialSkin.Controls.MaterialTextBox2();
            txtId = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvIstifadeciler).BeginInit();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvIstifadeciler
            // 
            dgvIstifadeciler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIstifadeciler.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvIstifadeciler.Location = new Point(354, 77);
            dgvIstifadeciler.Name = "dgvIstifadeciler";
            dgvIstifadeciler.Size = new Size(528, 381);
            dgvIstifadeciler.TabIndex = 0;
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
            materialCard1.Depth = 0;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(17, 77);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(316, 381);
            materialCard1.TabIndex = 1;
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
            btnSil.Location = new Point(17, 324);
            btnSil.Margin = new Padding(4, 6, 4, 6);
            btnSil.MouseState = MaterialSkin.MouseState.HOVER;
            btnSil.Name = "btnSil";
            btnSil.NoAccentTextColor = Color.Empty;
            btnSil.Size = new Size(64, 36);
            btnSil.TabIndex = 5;
            btnSil.Text = "Sil";
            btnSil.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSil.UseAccentColor = false;
            btnSil.UseVisualStyleBackColor = false;
            btnSil.Click += btnSil_Click;
            // 
            // btnYarat
            // 
            btnYarat.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnYarat.BackColor = Color.FromArgb(242, 242, 242);
            btnYarat.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnYarat.Depth = 0;
            btnYarat.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnYarat.HighEmphasis = true;
            btnYarat.Icon = null;
            btnYarat.Location = new Point(219, 324);
            btnYarat.Margin = new Padding(4, 6, 4, 6);
            btnYarat.MouseState = MaterialSkin.MouseState.HOVER;
            btnYarat.Name = "btnYarat";
            btnYarat.NoAccentTextColor = Color.Empty;
            btnYarat.Size = new Size(68, 36);
            btnYarat.TabIndex = 4;
            btnYarat.Text = "Yarat";
            btnYarat.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnYarat.UseAccentColor = false;
            btnYarat.UseVisualStyleBackColor = false;
            btnYarat.Click += btnYarat_Click;
            // 
            // cmbRollar
            // 
            cmbRollar.AutoResize = false;
            cmbRollar.BackColor = Color.FromArgb(242, 242, 242);
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
            cmbRollar.Location = new Point(17, 252);
            cmbRollar.MaxDropDownItems = 4;
            cmbRollar.MouseState = MaterialSkin.MouseState.OUT;
            cmbRollar.Name = "cmbRollar";
            cmbRollar.Size = new Size(278, 49);
            cmbRollar.StartIndex = 0;
            cmbRollar.TabIndex = 3;
            // 
            // txtParol
            // 
            txtParol.AnimateReadOnly = false;
            txtParol.BackColor = Color.FromArgb(255, 255, 255);
            txtParol.BackgroundImageLayout = ImageLayout.None;
            txtParol.CharacterCasing = CharacterCasing.Normal;
            txtParol.Depth = 0;
            txtParol.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtParol.HideSelection = true;
            txtParol.Hint = "Parol";
            txtParol.LeadingIcon = null;
            txtParol.Location = new Point(17, 186);
            txtParol.MaxLength = 32767;
            txtParol.MouseState = MaterialSkin.MouseState.OUT;
            txtParol.Name = "txtParol";
            txtParol.PasswordChar = '*';
            txtParol.PrefixSuffixText = null;
            txtParol.ReadOnly = false;
            txtParol.RightToLeft = RightToLeft.No;
            txtParol.SelectedText = "";
            txtParol.SelectionLength = 0;
            txtParol.SelectionStart = 0;
            txtParol.ShortcutsEnabled = true;
            txtParol.Size = new Size(278, 48);
            txtParol.TabIndex = 2;
            txtParol.TabStop = false;
            txtParol.TextAlign = HorizontalAlignment.Left;
            txtParol.TrailingIcon = null;
            txtParol.UseSystemPasswordChar = false;
            // 
            // txtTamAd
            // 
            txtTamAd.AnimateReadOnly = false;
            txtTamAd.BackColor = Color.FromArgb(255, 255, 255);
            txtTamAd.BackgroundImageLayout = ImageLayout.None;
            txtTamAd.CharacterCasing = CharacterCasing.Normal;
            txtTamAd.Depth = 0;
            txtTamAd.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtTamAd.HideSelection = true;
            txtTamAd.Hint = "Tam Ad";
            txtTamAd.LeadingIcon = null;
            txtTamAd.Location = new Point(17, 101);
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
            txtTamAd.Size = new Size(278, 48);
            txtTamAd.TabIndex = 1;
            txtTamAd.TabStop = false;
            txtTamAd.TextAlign = HorizontalAlignment.Left;
            txtTamAd.TrailingIcon = null;
            txtTamAd.UseSystemPasswordChar = false;
            // 
            // txtIstifadeciAdi
            // 
            txtIstifadeciAdi.AnimateReadOnly = false;
            txtIstifadeciAdi.BackColor = Color.FromArgb(255, 255, 255);
            txtIstifadeciAdi.BackgroundImageLayout = ImageLayout.None;
            txtIstifadeciAdi.CharacterCasing = CharacterCasing.Normal;
            txtIstifadeciAdi.Depth = 0;
            txtIstifadeciAdi.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtIstifadeciAdi.HideSelection = true;
            txtIstifadeciAdi.Hint = "İstifadəçi Adı";
            txtIstifadeciAdi.LeadingIcon = null;
            txtIstifadeciAdi.Location = new Point(17, 21);
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
            txtIstifadeciAdi.Size = new Size(278, 48);
            txtIstifadeciAdi.TabIndex = 0;
            txtIstifadeciAdi.TabStop = false;
            txtIstifadeciAdi.TextAlign = HorizontalAlignment.Left;
            txtIstifadeciAdi.TrailingIcon = null;
            txtIstifadeciAdi.UseSystemPasswordChar = false;
            // 
            // txtId
            // 
            txtId.BackColor = Color.FromArgb(242, 242, 242);
            txtId.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtId.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtId.Location = new Point(293, 477);
            txtId.Name = "txtId";
            txtId.Size = new Size(40, 24);
            txtId.TabIndex = 2;
            txtId.Visible = false;
            // 
            // IstifadeciIdareetmeFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            ClientSize = new Size(901, 509);
            Controls.Add(txtId);
            Controls.Add(materialCard1);
            Controls.Add(dgvIstifadeciler);
            Name = "IstifadeciIdareetmeFormu";
            Text = "İstifadəçi İdarəetməsi";
            Load += IstifadeciIdareetmeFormu_Load;
            ((System.ComponentModel.ISupportInitialize)dgvIstifadeciler).EndInit();
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
        private System.Windows.Forms.DataGridView dgvIstifadeciler;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialButton btnSil;
        private MaterialSkin.Controls.MaterialButton btnYarat;
        private MaterialSkin.Controls.MaterialComboBox cmbRollar;
        private MaterialSkin.Controls.MaterialTextBox2 txtParol;
        private MaterialSkin.Controls.MaterialTextBox2 txtTamAd;
        private MaterialSkin.Controls.MaterialTextBox2 txtIstifadeciAdi;
        private System.Windows.Forms.TextBox txtId;
    }
}