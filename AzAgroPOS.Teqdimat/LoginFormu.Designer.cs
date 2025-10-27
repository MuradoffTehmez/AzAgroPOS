// Fayl: AzAgroPOS.Teqdimat/LoginFormu.Designer.cs
namespace AzAgroPOS.Teqdimat
{
    partial class LoginFormu
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
            components = new System.ComponentModel.Container();
            txtIstifadeciAdi = new MaterialSkin.Controls.MaterialTextBox2();
            txtParol = new MaterialSkin.Controls.MaterialTextBox2();
            btnDaxilOl = new MaterialSkin.Controls.MaterialButton();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
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
            txtIstifadeciAdi.Location = new Point(105, 112);
            txtIstifadeciAdi.Margin = new Padding(4, 3, 4, 3);
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
            txtIstifadeciAdi.Size = new Size(408, 48);
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
            txtParol.Location = new Point(105, 187);
            txtParol.Margin = new Padding(4, 3, 4, 3);
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
            txtParol.Size = new Size(408, 48);
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
            btnDaxilOl.Location = new Point(105, 266);
            btnDaxilOl.Margin = new Padding(5, 7, 5, 7);
            btnDaxilOl.MouseState = MaterialSkin.MouseState.HOVER;
            btnDaxilOl.Name = "btnDaxilOl";
            btnDaxilOl.NoAccentTextColor = Color.Empty;
            btnDaxilOl.Size = new Size(408, 48);
            btnDaxilOl.TabIndex = 2;
            btnDaxilOl.Text = "Daxil Ol";
            btnDaxilOl.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnDaxilOl.UseAccentColor = false;
            btnDaxilOl.UseVisualStyleBackColor = false;
            btnDaxilOl.Click += btnDaxilOl_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // LoginFormu
            // 
            AcceptButton = btnDaxilOl;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(618, 372);
            Controls.Add(btnDaxilOl);
            Controls.Add(txtParol);
            Controls.Add(txtIstifadeciAdi);
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginFormu";
            Padding = new Padding(4, 74, 4, 3);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistemə Giriş";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox2 txtIstifadeciAdi;
        private MaterialSkin.Controls.MaterialTextBox2 txtParol;
        private MaterialSkin.Controls.MaterialButton btnDaxilOl;
        private ErrorProvider errorProvider1;
    }
}