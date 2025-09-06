// Fayl: AzAgroPOS.Teqdimat/AnbarFormu.Designer.cs
namespace AzAgroPOS.Teqdimat
{
    partial class AnbarFormu
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            txtAxtaris = new MaterialSkin.Controls.MaterialTextBox2();
            btnAxtar = new MaterialSkin.Controls.MaterialButton();
            pnlMelumat = new Panel();
            btnTesdiqle = new MaterialSkin.Controls.MaterialButton();
            txtElaveOlunanSay = new MaterialSkin.Controls.MaterialTextBox2();
            lblMehsulMelumat = new MaterialSkin.Controls.MaterialLabel();
            lblMehsulId = new Label();
            errorProvider1 = new ErrorProvider(components);
            pnlMelumat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // txtAxtaris
            // 
            txtAxtaris.AnimateReadOnly = false;
            txtAxtaris.BackColor = Color.FromArgb(242, 242, 242);
            txtAxtaris.BackgroundImageLayout = ImageLayout.None;
            txtAxtaris.CharacterCasing = CharacterCasing.Normal;
            txtAxtaris.Depth = 0;
            txtAxtaris.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtAxtaris.HideSelection = true;
            txtAxtaris.Hint = "Barkod və ya Stok Kodu";
            txtAxtaris.LeadingIcon = null;
            txtAxtaris.Location = new Point(34, 98);
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
            txtAxtaris.Size = new Size(393, 48);
            txtAxtaris.TabIndex = 0;
            txtAxtaris.TabStop = false;
            txtAxtaris.TextAlign = HorizontalAlignment.Left;
            txtAxtaris.TrailingIcon = null;
            txtAxtaris.UseSystemPasswordChar = false;
            txtAxtaris.KeyDown += txtAxtaris_KeyDown;
            // 
            // btnAxtar
            // 
            btnAxtar.AutoSize = false;
            btnAxtar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAxtar.BackColor = Color.FromArgb(242, 242, 242);
            btnAxtar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnAxtar.Depth = 0;
            btnAxtar.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnAxtar.HighEmphasis = true;
            btnAxtar.Icon = null;
            btnAxtar.Location = new Point(447, 104);
            btnAxtar.Margin = new Padding(4, 6, 4, 6);
            btnAxtar.MouseState = MaterialSkin.MouseState.HOVER;
            btnAxtar.Name = "btnAxtar";
            btnAxtar.NoAccentTextColor = Color.Empty;
            btnAxtar.Size = new Size(130, 36);
            btnAxtar.TabIndex = 1;
            btnAxtar.Text = "Axtar";
            btnAxtar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAxtar.UseAccentColor = false;
            btnAxtar.UseVisualStyleBackColor = false;
            btnAxtar.Click += btnAxtar_Click;
            // 
            // pnlMelumat
            // 
            pnlMelumat.BackColor = Color.FromArgb(242, 242, 242);
            pnlMelumat.Controls.Add(btnTesdiqle);
            pnlMelumat.Controls.Add(txtElaveOlunanSay);
            pnlMelumat.Controls.Add(lblMehsulMelumat);
            pnlMelumat.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlMelumat.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlMelumat.Location = new Point(34, 169);
            pnlMelumat.Name = "pnlMelumat";
            pnlMelumat.Size = new Size(543, 167);
            pnlMelumat.TabIndex = 2;
            pnlMelumat.Visible = false;
            // 
            // btnTesdiqle
            // 
            btnTesdiqle.AutoSize = false;
            btnTesdiqle.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnTesdiqle.BackColor = Color.FromArgb(242, 242, 242);
            btnTesdiqle.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnTesdiqle.Depth = 0;
            btnTesdiqle.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnTesdiqle.HighEmphasis = true;
            btnTesdiqle.Icon = null;
            btnTesdiqle.Location = new Point(413, 110);
            btnTesdiqle.Margin = new Padding(4, 6, 4, 6);
            btnTesdiqle.MouseState = MaterialSkin.MouseState.HOVER;
            btnTesdiqle.Name = "btnTesdiqle";
            btnTesdiqle.NoAccentTextColor = Color.Empty;
            btnTesdiqle.Size = new Size(130, 36);
            btnTesdiqle.TabIndex = 2;
            btnTesdiqle.Text = "Təsdiq Et";
            btnTesdiqle.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnTesdiqle.UseAccentColor = true;
            btnTesdiqle.UseVisualStyleBackColor = false;
            btnTesdiqle.Click += btnTesdiqle_Click;
            // 
            // txtElaveOlunanSay
            // 
            txtElaveOlunanSay.AnimateReadOnly = false;
            txtElaveOlunanSay.BackColor = Color.FromArgb(242, 242, 242);
            txtElaveOlunanSay.BackgroundImageLayout = ImageLayout.None;
            txtElaveOlunanSay.CharacterCasing = CharacterCasing.Normal;
            txtElaveOlunanSay.Depth = 0;
            txtElaveOlunanSay.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtElaveOlunanSay.HideSelection = true;
            txtElaveOlunanSay.Hint = "Əlavə Olunacaq Say";
            txtElaveOlunanSay.LeadingIcon = null;
            txtElaveOlunanSay.Location = new Point(0, 104);
            txtElaveOlunanSay.MaxLength = 32767;
            txtElaveOlunanSay.MouseState = MaterialSkin.MouseState.OUT;
            txtElaveOlunanSay.Name = "txtElaveOlunanSay";
            txtElaveOlunanSay.PasswordChar = '\0';
            txtElaveOlunanSay.PrefixSuffixText = null;
            txtElaveOlunanSay.ReadOnly = false;
            txtElaveOlunanSay.RightToLeft = RightToLeft.No;
            txtElaveOlunanSay.SelectedText = "";
            txtElaveOlunanSay.SelectionLength = 0;
            txtElaveOlunanSay.SelectionStart = 0;
            txtElaveOlunanSay.ShortcutsEnabled = true;
            txtElaveOlunanSay.Size = new Size(393, 48);
            txtElaveOlunanSay.TabIndex = 1;
            txtElaveOlunanSay.TabStop = false;
            txtElaveOlunanSay.TextAlign = HorizontalAlignment.Left;
            txtElaveOlunanSay.TrailingIcon = null;
            txtElaveOlunanSay.UseSystemPasswordChar = false;
            // 
            // lblMehsulMelumat
            // 
            lblMehsulMelumat.BackColor = Color.FromArgb(242, 242, 242);
            lblMehsulMelumat.Depth = 0;
            lblMehsulMelumat.Font = new Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblMehsulMelumat.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            lblMehsulMelumat.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblMehsulMelumat.Location = new Point(4, 4);
            lblMehsulMelumat.MouseState = MaterialSkin.MouseState.HOVER;
            lblMehsulMelumat.Name = "lblMehsulMelumat";
            lblMehsulMelumat.Size = new Size(536, 82);
            lblMehsulMelumat.TabIndex = 0;
            lblMehsulMelumat.Text = "Məhsul Adı\r\nMövcud Say: 0";
            // 
            // lblMehsulId
            // 
            lblMehsulId.AutoSize = true;
            lblMehsulId.BackColor = Color.FromArgb(242, 242, 242);
            lblMehsulId.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblMehsulId.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblMehsulId.Location = new Point(12, 360);
            lblMehsulId.Name = "lblMehsulId";
            lblMehsulId.Size = new Size(0, 17);
            lblMehsulId.TabIndex = 3;
            lblMehsulId.Visible = false;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // AnbarFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(613, 364);
            Controls.Add(lblMehsulId);
            Controls.Add(pnlMelumat);
            Controls.Add(btnAxtar);
            Controls.Add(txtAxtaris);
            Name = "AnbarFormu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Anbar Qeydiyyatı";
            pnlMelumat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion
        private MaterialSkin.Controls.MaterialTextBox2 txtAxtaris;
        private MaterialSkin.Controls.MaterialButton btnAxtar;
        private Panel pnlMelumat;
        private MaterialSkin.Controls.MaterialButton btnTesdiqle;
        private MaterialSkin.Controls.MaterialTextBox2 txtElaveOlunanSay;
        private MaterialSkin.Controls.MaterialLabel lblMehsulMelumat;
        private Label lblMehsulId;
        private ErrorProvider errorProvider1;
    }
}