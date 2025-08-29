// Fayl: AzAgroPOS.Teqdimat/SatisFormu.Designer.cs
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
            txtBarkodAxtaris = new MaterialSkin.Controls.MaterialTextBox2();
            dgvSebet = new DataGridView();
            materialCardOdenis = new MaterialSkin.Controls.MaterialCard();
            cmbMusteriler = new MaterialSkin.Controls.MaterialComboBox();
            btnNisye = new MaterialSkin.Controls.MaterialButton();
            btnKart = new MaterialSkin.Controls.MaterialButton();
            btnNagd = new MaterialSkin.Controls.MaterialButton();
            lblUmumiMebleg = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)dgvSebet).BeginInit();
            materialCardOdenis.SuspendLayout();
            SuspendLayout();
            // 
            // txtBarkodAxtaris
            // 
            txtBarkodAxtaris.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBarkodAxtaris.AnimateReadOnly = false;
            txtBarkodAxtaris.BackgroundImageLayout = ImageLayout.None;
            txtBarkodAxtaris.CharacterCasing = CharacterCasing.Normal;
            txtBarkodAxtaris.Depth = 0;
            txtBarkodAxtaris.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtBarkodAxtaris.HideSelection = true;
            txtBarkodAxtaris.Hint = "Barkod və ya Stok Kodu daxil edib ENTER basın";
            txtBarkodAxtaris.LeadingIcon = null;
            txtBarkodAxtaris.Location = new Point(20, 90);
            txtBarkodAxtaris.MaxLength = 32767;
            txtBarkodAxtaris.MouseState = MaterialSkin.MouseState.OUT;
            txtBarkodAxtaris.Name = "txtBarkodAxtaris";
            txtBarkodAxtaris.PasswordChar = '\0';
            txtBarkodAxtaris.PrefixSuffixText = null;
            txtBarkodAxtaris.ReadOnly = false;
            txtBarkodAxtaris.RightToLeft = RightToLeft.No;
            txtBarkodAxtaris.SelectedText = "";
            txtBarkodAxtaris.SelectionLength = 0;
            txtBarkodAxtaris.SelectionStart = 0;
            txtBarkodAxtaris.ShortcutsEnabled = true;
            txtBarkodAxtaris.Size = new Size(1010, 48);
            txtBarkodAxtaris.TabIndex = 0;
            txtBarkodAxtaris.TabStop = false;
            txtBarkodAxtaris.TextAlign = HorizontalAlignment.Left;
            txtBarkodAxtaris.TrailingIcon = null;
            txtBarkodAxtaris.UseSystemPasswordChar = false;
            txtBarkodAxtaris.KeyDown += txtBarkodAxtaris_KeyDown;
            // 
            // dgvSebet
            // 
            dgvSebet.AllowUserToAddRows = false;
            dgvSebet.AllowUserToDeleteRows = false;
            dgvSebet.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSebet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSebet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSebet.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvSebet.Location = new Point(20, 152);
            dgvSebet.Name = "dgvSebet";
            dgvSebet.ReadOnly = true;
            dgvSebet.RowTemplate.Height = 25;
            dgvSebet.Size = new Size(1010, 481);
            dgvSebet.TabIndex = 1;
            // 
            // materialCardOdenis
            // 
            materialCardOdenis.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            materialCardOdenis.BackColor = Color.FromArgb(255, 255, 255);
            materialCardOdenis.Controls.Add(cmbMusteriler);
            materialCardOdenis.Controls.Add(btnNisye);
            materialCardOdenis.Controls.Add(btnKart);
            materialCardOdenis.Controls.Add(btnNagd);
            materialCardOdenis.Controls.Add(lblUmumiMebleg);
            materialCardOdenis.Depth = 0;
            materialCardOdenis.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCardOdenis.Location = new Point(20, 642);
            materialCardOdenis.Margin = new Padding(14);
            materialCardOdenis.MouseState = MaterialSkin.MouseState.HOVER;
            materialCardOdenis.Name = "materialCardOdenis";
            materialCardOdenis.Padding = new Padding(14);
            materialCardOdenis.Size = new Size(1010, 151);
            materialCardOdenis.TabIndex = 2;
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
            cmbMusteriler.Location = new Point(694, 91);
            cmbMusteriler.MaxDropDownItems = 4;
            cmbMusteriler.MouseState = MaterialSkin.MouseState.OUT;
            cmbMusteriler.Name = "cmbMusteriler";
            cmbMusteriler.Size = new Size(300, 49);
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
            btnNisye.Location = new Point(854, 18);
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
            btnKart.Location = new Point(694, 18);
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
            btnNagd.Location = new Point(534, 18);
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
            lblUmumiMebleg.Size = new Size(323, 41);
            lblUmumiMebleg.TabIndex = 0;
            lblUmumiMebleg.Text = "ÜMUMİ MƏBLƏĞ: 0.00 AZN";
            // 
            // SatisFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1050, 808);
            Controls.Add(materialCardOdenis);
            Controls.Add(dgvSebet);
            Controls.Add(txtBarkodAxtaris);
            Name = "SatisFormu";
            Padding = new Padding(3, 64, 3, 3);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Yeni Satış";
            ((System.ComponentModel.ISupportInitialize)dgvSebet).EndInit();
            materialCardOdenis.ResumeLayout(false);
            materialCardOdenis.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox2 txtBarkodAxtaris;
        private System.Windows.Forms.DataGridView dgvSebet;
        private MaterialSkin.Controls.MaterialCard materialCardOdenis;
        private MaterialSkin.Controls.MaterialButton btnNagd;
        private MaterialSkin.Controls.MaterialLabel lblUmumiMebleg;
        private MaterialSkin.Controls.MaterialComboBox cmbMusteriler;
        private MaterialSkin.Controls.MaterialButton btnNisye;
        private MaterialSkin.Controls.MaterialButton btnKart;
    }
}