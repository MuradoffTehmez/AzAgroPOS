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
            this.txtIstifadeciAdi = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtParol = new MaterialSkin.Controls.MaterialTextBox2();
            this.btnDaxilOl = new MaterialSkin.Controls.MaterialButton();
            this.btnTest = new MaterialSkin.Controls.MaterialButton(); // YENİ DÜYMƏ
            this.SuspendLayout();
            // 
            // txtIstifadeciAdi
            // 
            this.txtIstifadeciAdi.AnimateReadOnly = false;
            this.txtIstifadeciAdi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtIstifadeciAdi.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtIstifadeciAdi.Depth = 0;
            this.txtIstifadeciAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtIstifadeciAdi.HideSelection = true;
            this.txtIstifadeciAdi.Hint = "İstifadəçi Adı";
            this.txtIstifadeciAdi.LeadingIcon = null;
            this.txtIstifadeciAdi.Location = new System.Drawing.Point(45, 96);
            this.txtIstifadeciAdi.MaxLength = 32767;
            this.txtIstifadeciAdi.MouseState = MaterialSkin.MouseState.OUT;
            this.txtIstifadeciAdi.Name = "txtIstifadeciAdi";
            this.txtIstifadeciAdi.PasswordChar = '\0';
            this.txtIstifadeciAdi.PrefixSuffixText = null;
            this.txtIstifadeciAdi.ReadOnly = false;
            this.txtIstifadeciAdi.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtIstifadeciAdi.SelectedText = "";
            this.txtIstifadeciAdi.SelectionLength = 0;
            this.txtIstifadeciAdi.SelectionStart = 0;
            this.txtIstifadeciAdi.ShortcutsEnabled = true;
            this.txtIstifadeciAdi.Size = new System.Drawing.Size(350, 48);
            this.txtIstifadeciAdi.TabIndex = 0;
            this.txtIstifadeciAdi.TabStop = false;
            this.txtIstifadeciAdi.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtIstifadeciAdi.TrailingIcon = null;
            this.txtIstifadeciAdi.UseSystemPasswordChar = false;
            // 
            // txtParol
            // 
            this.txtParol.AnimateReadOnly = false;
            this.txtParol.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtParol.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtParol.Depth = 0;
            this.txtParol.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtParol.HideSelection = true;
            this.txtParol.Hint = "Parol";
            this.txtParol.LeadingIcon = null;
            this.txtParol.Location = new System.Drawing.Point(45, 161);
            this.txtParol.MaxLength = 32767;
            this.txtParol.MouseState = MaterialSkin.MouseState.OUT;
            this.txtParol.Name = "txtParol";
            this.txtParol.PasswordChar = '●';
            this.txtParol.PrefixSuffixText = null;
            this.txtParol.ReadOnly = false;
            this.txtParol.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtParol.SelectedText = "";
            this.txtParol.SelectionLength = 0;
            this.txtParol.SelectionStart = 0;
            this.txtParol.ShortcutsEnabled = true;
            this.txtParol.Size = new System.Drawing.Size(350, 48);
            this.txtParol.TabIndex = 1;
            this.txtParol.TabStop = false;
            this.txtParol.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtParol.TrailingIcon = null;
            this.txtParol.UseSystemPasswordChar = true;
            // 
            // btnDaxilOl
            // 
            this.btnDaxilOl.AutoSize = false;
            this.btnDaxilOl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDaxilOl.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnDaxilOl.Depth = 0;
            this.btnDaxilOl.HighEmphasis = true;
            this.btnDaxilOl.Icon = null;
            this.btnDaxilOl.Location = new System.Drawing.Point(45, 230);
            this.btnDaxilOl.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnDaxilOl.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDaxilOl.Name = "btnDaxilOl";
            this.btnDaxilOl.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnDaxilOl.Size = new System.Drawing.Size(350, 45);
            this.btnDaxilOl.TabIndex = 2;
            this.btnDaxilOl.Text = "Daxil Ol";
            this.btnDaxilOl.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnDaxilOl.UseAccentColor = false;
            this.btnDaxilOl.UseVisualStyleBackColor = true;
            this.btnDaxilOl.Click += new System.EventHandler(this.btnDaxilOl_Click);
            // 
            // btnTest
            // 
            this.btnTest.AutoSize = false;
            this.btnTest.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTest.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnTest.Depth = 0;
            this.btnTest.HighEmphasis = false;
            this.btnTest.Icon = null;
            this.btnTest.Location = new System.Drawing.Point(45, 287);
            this.btnTest.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnTest.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnTest.Name = "btnTest";
            this.btnTest.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnTest.Size = new System.Drawing.Size(350, 36);
            this.btnTest.TabIndex = 3;
            this.btnTest.Text = "TEST";
            this.btnTest.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnTest.UseAccentColor = true;
            this.btnTest.UseVisualStyleBackColor = true;
            // 
            // LoginFormu
            // 
            this.ClientSize = new System.Drawing.Size(440, 350);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnDaxilOl);
            this.Controls.Add(this.txtParol);
            this.Controls.Add(this.txtIstifadeciAdi);
            this.Name = "LoginFormu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistemə Giriş";
            this.ResumeLayout(false);

        }
        #endregion
        private MaterialSkin.Controls.MaterialTextBox2 txtIstifadeciAdi;
        private MaterialSkin.Controls.MaterialTextBox2 txtParol;
        private MaterialSkin.Controls.MaterialButton btnDaxilOl;
        private MaterialSkin.Controls.MaterialButton btnTest; // YENİ DÜYMƏ
    }
}