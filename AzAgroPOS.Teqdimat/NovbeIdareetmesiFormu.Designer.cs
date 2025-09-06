// Fayl: AzAgroPOS.Teqdimat/NovbeIdareetmesiFormu.Designer.cs
namespace AzAgroPOS.Teqdimat
{
    partial class NovbeIdareetmesiFormu
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            cardNovbeAc = new MaterialSkin.Controls.MaterialCard();
            btnNovbeAc = new MaterialSkin.Controls.MaterialButton();
            txtBaslangicMebleg = new MaterialSkin.Controls.MaterialTextBox2();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            cardNovbeBagla = new MaterialSkin.Controls.MaterialCard();
            btnNovbeBagla = new MaterialSkin.Controls.MaterialButton();
            txtFaktikiMebleg = new MaterialSkin.Controls.MaterialTextBox2();
            lblNovbeMelumat = new MaterialSkin.Controls.MaterialLabel();
            errorProvider1 = new ErrorProvider(components);
            cardNovbeAc.SuspendLayout();
            cardNovbeBagla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // cardNovbeAc
            // 
            cardNovbeAc.BackColor = Color.FromArgb(255, 255, 255);
            cardNovbeAc.Controls.Add(btnNovbeAc);
            cardNovbeAc.Controls.Add(txtBaslangicMebleg);
            cardNovbeAc.Controls.Add(materialLabel1);
            cardNovbeAc.Depth = 0;
            cardNovbeAc.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cardNovbeAc.Location = new Point(40, 90);
            cardNovbeAc.Margin = new Padding(14);
            cardNovbeAc.MouseState = MaterialSkin.MouseState.HOVER;
            cardNovbeAc.Name = "cardNovbeAc";
            cardNovbeAc.Padding = new Padding(14);
            cardNovbeAc.Size = new Size(461, 220);
            cardNovbeAc.TabIndex = 0;
            // 
            // btnNovbeAc
            // 
            btnNovbeAc.AutoSize = false;
            btnNovbeAc.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnNovbeAc.BackColor = Color.FromArgb(242, 242, 242);
            btnNovbeAc.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnNovbeAc.Depth = 0;
            btnNovbeAc.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnNovbeAc.HighEmphasis = true;
            btnNovbeAc.Icon = null;
            btnNovbeAc.Location = new Point(200, 150);
            btnNovbeAc.Margin = new Padding(4, 6, 4, 6);
            btnNovbeAc.MouseState = MaterialSkin.MouseState.HOVER;
            btnNovbeAc.Name = "btnNovbeAc";
            btnNovbeAc.NoAccentTextColor = Color.Empty;
            btnNovbeAc.Size = new Size(200, 45);
            btnNovbeAc.TabIndex = 2;
            btnNovbeAc.Text = "Növbəni Aç";
            btnNovbeAc.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnNovbeAc.UseAccentColor = false;
            btnNovbeAc.UseVisualStyleBackColor = false;
            btnNovbeAc.Click += btnNovbeAc_Click;
            // 
            // txtBaslangicMebleg
            // 
            txtBaslangicMebleg.AnimateReadOnly = false;
            txtBaslangicMebleg.BackColor = Color.FromArgb(255, 255, 255);
            txtBaslangicMebleg.BackgroundImageLayout = ImageLayout.None;
            txtBaslangicMebleg.CharacterCasing = CharacterCasing.Normal;
            txtBaslangicMebleg.Depth = 0;
            txtBaslangicMebleg.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtBaslangicMebleg.HideSelection = true;
            txtBaslangicMebleg.Hint = "Kassadakı ilkin məbləğ";
            txtBaslangicMebleg.LeadingIcon = null;
            txtBaslangicMebleg.Location = new Point(150, 80);
            txtBaslangicMebleg.MaxLength = 32767;
            txtBaslangicMebleg.MouseState = MaterialSkin.MouseState.OUT;
            txtBaslangicMebleg.Name = "txtBaslangicMebleg";
            txtBaslangicMebleg.PasswordChar = '\0';
            txtBaslangicMebleg.PrefixSuffixText = null;
            txtBaslangicMebleg.ReadOnly = false;
            txtBaslangicMebleg.RightToLeft = RightToLeft.No;
            txtBaslangicMebleg.SelectedText = "";
            txtBaslangicMebleg.SelectionLength = 0;
            txtBaslangicMebleg.SelectionStart = 0;
            txtBaslangicMebleg.ShortcutsEnabled = true;
            txtBaslangicMebleg.Size = new Size(300, 48);
            txtBaslangicMebleg.TabIndex = 1;
            txtBaslangicMebleg.TabStop = false;
            txtBaslangicMebleg.Text = "0";
            txtBaslangicMebleg.TextAlign = HorizontalAlignment.Left;
            txtBaslangicMebleg.TrailingIcon = null;
            txtBaslangicMebleg.UseSystemPasswordChar = false;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.BackColor = Color.FromArgb(242, 242, 242);
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            materialLabel1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel1.Location = new Point(220, 20);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(157, 29);
            materialLabel1.TabIndex = 0;
            materialLabel1.Text = "Yeni Növbə Aç";
            // 
            // cardNovbeBagla
            // 
            cardNovbeBagla.BackColor = Color.FromArgb(255, 255, 255);
            cardNovbeBagla.Controls.Add(btnNovbeBagla);
            cardNovbeBagla.Controls.Add(txtFaktikiMebleg);
            cardNovbeBagla.Controls.Add(lblNovbeMelumat);
            cardNovbeBagla.Depth = 0;
            cardNovbeBagla.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cardNovbeBagla.Location = new Point(40, 90);
            cardNovbeBagla.Margin = new Padding(14);
            cardNovbeBagla.MouseState = MaterialSkin.MouseState.HOVER;
            cardNovbeBagla.Name = "cardNovbeBagla";
            cardNovbeBagla.Padding = new Padding(14);
            cardNovbeBagla.Size = new Size(461, 220);
            cardNovbeBagla.TabIndex = 1;
            cardNovbeBagla.Visible = false;
            // 
            // btnNovbeBagla
            // 
            btnNovbeBagla.AutoSize = false;
            btnNovbeBagla.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnNovbeBagla.BackColor = Color.FromArgb(242, 242, 242);
            btnNovbeBagla.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnNovbeBagla.Depth = 0;
            btnNovbeBagla.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnNovbeBagla.HighEmphasis = true;
            btnNovbeBagla.Icon = null;
            btnNovbeBagla.Location = new Point(105, 125);
            btnNovbeBagla.Margin = new Padding(4, 6, 4, 6);
            btnNovbeBagla.MouseState = MaterialSkin.MouseState.HOVER;
            btnNovbeBagla.Name = "btnNovbeBagla";
            btnNovbeBagla.NoAccentTextColor = Color.Empty;
            btnNovbeBagla.Size = new Size(250, 48);
            btnNovbeBagla.TabIndex = 2;
            btnNovbeBagla.Text = "Növbəni Bağla və Hesabat al";
            btnNovbeBagla.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnNovbeBagla.UseAccentColor = false;
            btnNovbeBagla.UseVisualStyleBackColor = false;
            btnNovbeBagla.Click += btnNovbeBagla_Click;
            // 
            // txtFaktikiMebleg
            // 
            txtFaktikiMebleg.AnimateReadOnly = false;
            txtFaktikiMebleg.BackColor = Color.FromArgb(255, 255, 255);
            txtFaktikiMebleg.BackgroundImageLayout = ImageLayout.None;
            txtFaktikiMebleg.CharacterCasing = CharacterCasing.Normal;
            txtFaktikiMebleg.Depth = 0;
            txtFaktikiMebleg.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtFaktikiMebleg.HideSelection = true;
            txtFaktikiMebleg.Hint = "Kassada sayılan yekun məbləğ";
            txtFaktikiMebleg.LeadingIcon = null;
            txtFaktikiMebleg.Location = new Point(80, 55);
            txtFaktikiMebleg.MaxLength = 32767;
            txtFaktikiMebleg.MouseState = MaterialSkin.MouseState.OUT;
            txtFaktikiMebleg.Name = "txtFaktikiMebleg";
            txtFaktikiMebleg.PasswordChar = '\0';
            txtFaktikiMebleg.PrefixSuffixText = null;
            txtFaktikiMebleg.ReadOnly = false;
            txtFaktikiMebleg.RightToLeft = RightToLeft.No;
            txtFaktikiMebleg.SelectedText = "";
            txtFaktikiMebleg.SelectionLength = 0;
            txtFaktikiMebleg.SelectionStart = 0;
            txtFaktikiMebleg.ShortcutsEnabled = true;
            txtFaktikiMebleg.Size = new Size(300, 48);
            txtFaktikiMebleg.TabIndex = 1;
            txtFaktikiMebleg.TabStop = false;
            txtFaktikiMebleg.Text = "0";
            txtFaktikiMebleg.TextAlign = HorizontalAlignment.Left;
            txtFaktikiMebleg.TrailingIcon = null;
            txtFaktikiMebleg.UseSystemPasswordChar = false;
            // 
            // lblNovbeMelumat
            // 
            lblNovbeMelumat.AutoSize = true;
            lblNovbeMelumat.BackColor = Color.FromArgb(242, 242, 242);
            lblNovbeMelumat.Depth = 0;
            lblNovbeMelumat.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblNovbeMelumat.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblNovbeMelumat.Location = new Point(20, 20);
            lblNovbeMelumat.MouseState = MaterialSkin.MouseState.HOVER;
            lblNovbeMelumat.Name = "lblNovbeMelumat";
            lblNovbeMelumat.Size = new Size(1, 0);
            lblNovbeMelumat.TabIndex = 0;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // NovbeIdareetmesiFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            ClientSize = new Size(531, 331);
            Controls.Add(cardNovbeBagla);
            Controls.Add(cardNovbeAc);
            Name = "NovbeIdareetmesiFormu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Növbə İdarəetməsi";
            cardNovbeAc.ResumeLayout(false);
            cardNovbeAc.PerformLayout();
            cardNovbeBagla.ResumeLayout(false);
            cardNovbeBagla.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }
        #endregion
        private MaterialSkin.Controls.MaterialCard cardNovbeAc;
        private MaterialSkin.Controls.MaterialButton btnNovbeAc;
        private MaterialSkin.Controls.MaterialTextBox2 txtBaslangicMebleg;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialCard cardNovbeBagla;
        private MaterialSkin.Controls.MaterialButton btnNovbeBagla;
        private MaterialSkin.Controls.MaterialTextBox2 txtFaktikiMebleg;
        private MaterialSkin.Controls.MaterialLabel lblNovbeMelumat;
        private ErrorProvider errorProvider1;
    }
}