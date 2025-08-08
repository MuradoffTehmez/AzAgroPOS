// Fayl: AzAgroPOS.Teqdimat/LoginFormu.Designer.cs
namespace AzAgroPOS.Teqdimat
{
    partial class LoginFormu
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            txtIstifadeciAdi = new MaterialSkin.Controls.MaterialTextBox2();
            txtParol = new MaterialSkin.Controls.MaterialTextBox2();
            btnDaxilOl = new MaterialSkin.Controls.MaterialButton();
            btnTest = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // txtIstifadeciAdi
            // 
            txtIstifadeciAdi.AnimateReadOnly = false;
            txtIstifadeciAdi.BackColor = Color.FromArgb(242, 242, 242);
            txtIstifadeciAdi.BackgroundImageLayout = ImageLayout.None;
            txtIstifadeciAdi.CharacterCasing = CharacterCasing.Normal;
            txtIstifadeciAdi.Depth = 0;
            txtIstifadeciAdi.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtIstifadeciAdi.HideSelection = true;
            txtIstifadeciAdi.Hint = "İstifadəçi Adı";
            txtIstifadeciAdi.LeadingIcon = null;
            txtIstifadeciAdi.Location = new Point(45, 96);
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
            txtIstifadeciAdi.Size = new Size(350, 48);
            txtIstifadeciAdi.TabIndex = 0;
            txtIstifadeciAdi.TabStop = false;
            txtIstifadeciAdi.TextAlign = HorizontalAlignment.Left;
            txtIstifadeciAdi.TrailingIcon = null;
            txtIstifadeciAdi.UseSystemPasswordChar = false;
            // 
            // txtParol
            // 
            txtParol.AnimateReadOnly = false;
            txtParol.BackColor = Color.FromArgb(242, 242, 242);
            txtParol.BackgroundImageLayout = ImageLayout.None;
            txtParol.CharacterCasing = CharacterCasing.Normal;
            txtParol.Depth = 0;
            txtParol.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtParol.HideSelection = true;
            txtParol.Hint = "Parol";
            txtParol.LeadingIcon = null;
            txtParol.Location = new Point(45, 161);
            txtParol.MaxLength = 32767;
            txtParol.MouseState = MaterialSkin.MouseState.OUT;
            txtParol.Name = "txtParol";
            txtParol.PasswordChar = '●';
            txtParol.PrefixSuffixText = null;
            txtParol.ReadOnly = false;
            txtParol.RightToLeft = RightToLeft.No;
            txtParol.SelectedText = "";
            txtParol.SelectionLength = 0;
            txtParol.SelectionStart = 0;
            txtParol.ShortcutsEnabled = true;
            txtParol.Size = new Size(350, 48);
            txtParol.TabIndex = 1;
            txtParol.TabStop = false;
            txtParol.TextAlign = HorizontalAlignment.Left;
            txtParol.TrailingIcon = null;
            txtParol.UseSystemPasswordChar = true;
            // 
            // btnDaxilOl
            // 
            btnDaxilOl.AutoSize = false;
            btnDaxilOl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDaxilOl.BackColor = Color.FromArgb(242, 242, 242);
            btnDaxilOl.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnDaxilOl.Depth = 0;
            btnDaxilOl.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnDaxilOl.HighEmphasis = true;
            btnDaxilOl.Icon = null;
            btnDaxilOl.Location = new Point(45, 230);
            btnDaxilOl.Margin = new Padding(4, 6, 4, 6);
            btnDaxilOl.MouseState = MaterialSkin.MouseState.HOVER;
            btnDaxilOl.Name = "btnDaxilOl";
            btnDaxilOl.NoAccentTextColor = Color.Empty;
            btnDaxilOl.Size = new Size(350, 45);
            btnDaxilOl.TabIndex = 2;
            btnDaxilOl.Text = "Daxil Ol";
            btnDaxilOl.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnDaxilOl.UseAccentColor = false;
            btnDaxilOl.UseVisualStyleBackColor = false;
            btnDaxilOl.Click += btnDaxilOl_Click;
            // 
            // btnTest
            // 
            btnTest.AutoSize = false;
            btnTest.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnTest.BackColor = Color.FromArgb(242, 242, 242);
            btnTest.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnTest.Depth = 0;
            btnTest.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnTest.HighEmphasis = false;
            btnTest.Icon = null;
            btnTest.Location = new Point(45, 287);
            btnTest.Margin = new Padding(4, 6, 4, 6);
            btnTest.MouseState = MaterialSkin.MouseState.HOVER;
            btnTest.Name = "btnTest";
            btnTest.NoAccentTextColor = Color.Empty;
            btnTest.Size = new Size(350, 36);
            btnTest.TabIndex = 3;
            btnTest.Text = "TEST";
            btnTest.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnTest.UseAccentColor = true;
            btnTest.UseVisualStyleBackColor = false;
            // 
            // LoginFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            ClientSize = new Size(440, 350);
            Controls.Add(btnTest);
            Controls.Add(btnDaxilOl);
            Controls.Add(txtParol);
            Controls.Add(txtIstifadeciAdi);
            Name = "LoginFormu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistemə Giriş";
            ResumeLayout(false);

        }
        #endregion
        private MaterialSkin.Controls.MaterialTextBox2 txtIstifadeciAdi;
        private MaterialSkin.Controls.MaterialTextBox2 txtParol;
        private MaterialSkin.Controls.MaterialButton btnDaxilOl;
        private MaterialSkin.Controls.MaterialButton btnTest; // YENİ DÜYMƏ
    }
}