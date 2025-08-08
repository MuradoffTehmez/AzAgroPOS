// Fayl: AzAgroPOS.Teqdimat/SatisFormu.Designer.cs
namespace AzAgroPOS.Teqdimat
{
    partial class SatisFormu
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
            txtBarkodAxtaris = new MaterialSkin.Controls.MaterialTextBox2();
            dgvSebet = new DataGridView();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            btnSatisiTesdiqle = new MaterialSkin.Controls.MaterialButton();
            lblUmumiMebleg = new MaterialSkin.Controls.MaterialLabel();
            ((System.ComponentModel.ISupportInitialize)dgvSebet).BeginInit();
            materialCard1.SuspendLayout();
            SuspendLayout();
            // 
            // txtBarkodAxtaris
            // 
            txtBarkodAxtaris.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBarkodAxtaris.AnimateReadOnly = false;
            txtBarkodAxtaris.BackColor = Color.FromArgb(242, 242, 242);
            txtBarkodAxtaris.BackgroundImageLayout = ImageLayout.None;
            txtBarkodAxtaris.CharacterCasing = CharacterCasing.Normal;
            txtBarkodAxtaris.Depth = 0;
            txtBarkodAxtaris.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtBarkodAxtaris.HideSelection = true;
            txtBarkodAxtaris.Hint = "Barkod və ya Stok Kodu daxil edib ENTER basın";
            txtBarkodAxtaris.LeadingIcon = null;
            txtBarkodAxtaris.Location = new Point(20, 90);
            txtBarkodAxtaris.Margin = new Padding(4, 3, 4, 3);
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
            dgvSebet.Margin = new Padding(4, 3, 4, 3);
            dgvSebet.Name = "dgvSebet";
            dgvSebet.ReadOnly = true;
            dgvSebet.Size = new Size(1010, 517);
            dgvSebet.TabIndex = 1;
            // 
            // materialCard1
            // 
            materialCard1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(btnSatisiTesdiqle);
            materialCard1.Controls.Add(lblUmumiMebleg);
            materialCard1.Depth = 0;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(20, 676);
            materialCard1.Margin = new Padding(16, 16, 16, 16);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(16, 16, 16, 16);
            materialCard1.Size = new Size(1010, 102);
            materialCard1.TabIndex = 2;
            // 
            // btnSatisiTesdiqle
            // 
            btnSatisiTesdiqle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSatisiTesdiqle.AutoSize = false;
            btnSatisiTesdiqle.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSatisiTesdiqle.BackColor = Color.FromArgb(242, 242, 242);
            btnSatisiTesdiqle.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSatisiTesdiqle.Depth = 0;
            btnSatisiTesdiqle.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnSatisiTesdiqle.HighEmphasis = true;
            btnSatisiTesdiqle.Icon = null;
            btnSatisiTesdiqle.Location = new Point(705, 20);
            btnSatisiTesdiqle.Margin = new Padding(5, 7, 5, 7);
            btnSatisiTesdiqle.MouseState = MaterialSkin.MouseState.HOVER;
            btnSatisiTesdiqle.Name = "btnSatisiTesdiqle";
            btnSatisiTesdiqle.NoAccentTextColor = Color.Empty;
            btnSatisiTesdiqle.Size = new Size(286, 62);
            btnSatisiTesdiqle.TabIndex = 1;
            btnSatisiTesdiqle.Text = "Satışı Təsdiqlə";
            btnSatisiTesdiqle.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSatisiTesdiqle.UseAccentColor = true;
            btnSatisiTesdiqle.UseVisualStyleBackColor = false;
            btnSatisiTesdiqle.Click += btnSatisiTesdiqle_Click;
            // 
            // lblUmumiMebleg
            // 
            lblUmumiMebleg.AutoSize = true;
            lblUmumiMebleg.BackColor = Color.FromArgb(242, 242, 242);
            lblUmumiMebleg.Depth = 0;
            lblUmumiMebleg.Font = new Font("Roboto", 34F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblUmumiMebleg.FontType = MaterialSkin.MaterialSkinManager.fontType.H4;
            lblUmumiMebleg.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblUmumiMebleg.Location = new Point(20, 28);
            lblUmumiMebleg.Margin = new Padding(4, 0, 4, 0);
            lblUmumiMebleg.MouseState = MaterialSkin.MouseState.HOVER;
            lblUmumiMebleg.Name = "lblUmumiMebleg";
            lblUmumiMebleg.Size = new Size(416, 41);
            lblUmumiMebleg.TabIndex = 0;
            lblUmumiMebleg.Text = "ÜMUMİ MƏBLƏĞ: 0.00 AZN";
            // 
            // SatisFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1050, 808);
            Controls.Add(materialCard1);
            Controls.Add(dgvSebet);
            Controls.Add(txtBarkodAxtaris);
            Margin = new Padding(4, 3, 4, 3);
            Name = "SatisFormu";
            Padding = new Padding(4, 74, 4, 3);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Yeni Satış";
            ((System.ComponentModel.ISupportInitialize)dgvSebet).EndInit();
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox2 txtBarkodAxtaris;
        private System.Windows.Forms.DataGridView dgvSebet;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialButton btnSatisiTesdiqle;
        private MaterialSkin.Controls.MaterialLabel lblUmumiMebleg;
    }
}