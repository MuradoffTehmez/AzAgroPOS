// Fayl: AzAgroPOS.Teqdimat/LoginFormu.Designer.cs
namespace AzAgroPOS.Teqdimat
{
    partial class LoginFormu
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
            components = new System.ComponentModel.Container();
            pnlMain = new Panel();
            lblVersion = new Label();
            lblCopyright = new Label();
            pnlCardShadow = new Panel();
            pnlLoginCard = new Panel();
            pnlLogoContainer = new Panel();
            picLogo = new PictureBox();
            lblXosGeldin = new Label();
            lblBasliq = new Label();
            lblAltBasliq = new Label();
            pnlDivider = new Panel();
            txtIstifadeciAdi = new MaterialSkin.Controls.MaterialTextBox2();
            txtParol = new MaterialSkin.Controls.MaterialTextBox2();
            btnParolGoster = new Button();
            lblCapsLock = new Label();
            chkMeniXatirla = new MaterialSkin.Controls.MaterialCheckbox();
            btnDaxilOl = new MaterialSkin.Controls.MaterialButton();
            pnlLoading = new Panel();
            picLoading = new PictureBox();
            lblLoading = new Label();
            errorProvider1 = new ErrorProvider(components);
            pnlMain.SuspendLayout();
            pnlLoginCard.SuspendLayout();
            pnlLogoContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            pnlLoading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLoading).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(242, 242, 242);
            pnlMain.Controls.Add(pnlLoginCard);
            pnlMain.Controls.Add(lblVersion);
            pnlMain.Controls.Add(lblCopyright);
            pnlMain.Controls.Add(pnlCardShadow);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlMain.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlMain.Location = new Point(3, 64);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(660, 632);
            pnlMain.TabIndex = 1;
            // 
            // lblVersion
            // 
            lblVersion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblVersion.AutoSize = true;
            lblVersion.BackColor = Color.FromArgb(242, 242, 242);
            lblVersion.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblVersion.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblVersion.Location = new Point(12, 1152);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(47, 17);
            lblVersion.TabIndex = 0;
            lblVersion.Text = "v1.0.0";
            // 
            // lblCopyright
            // 
            lblCopyright.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblCopyright.AutoSize = true;
            lblCopyright.BackColor = Color.FromArgb(242, 242, 242);
            lblCopyright.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblCopyright.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblCopyright.Location = new Point(910, 1152);
            lblCopyright.Name = "lblCopyright";
            lblCopyright.Size = new Size(130, 17);
            lblCopyright.TabIndex = 1;
            lblCopyright.Text = "© 2024 AzAgroPOS";
            // 
            // pnlCardShadow
            // 
            pnlCardShadow.Anchor = AnchorStyles.None;
            pnlCardShadow.BackColor = Color.FromArgb(242, 242, 242);
            pnlCardShadow.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlCardShadow.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlCardShadow.Location = new Point(334, 314);
            pnlCardShadow.Name = "pnlCardShadow";
            pnlCardShadow.Size = new Size(430, 560);
            pnlCardShadow.TabIndex = 2;
            // 
            // pnlLoginCard
            // 
            pnlLoginCard.Anchor = AnchorStyles.None;
            pnlLoginCard.BackColor = Color.FromArgb(242, 242, 242);
            pnlLoginCard.Controls.Add(pnlLogoContainer);
            pnlLoginCard.Controls.Add(lblXosGeldin);
            pnlLoginCard.Controls.Add(lblBasliq);
            pnlLoginCard.Controls.Add(lblAltBasliq);
            pnlLoginCard.Controls.Add(pnlDivider);
            pnlLoginCard.Controls.Add(txtIstifadeciAdi);
            pnlLoginCard.Controls.Add(txtParol);
            pnlLoginCard.Controls.Add(btnParolGoster);
            pnlLoginCard.Controls.Add(lblCapsLock);
            pnlLoginCard.Controls.Add(chkMeniXatirla);
            pnlLoginCard.Controls.Add(btnDaxilOl);
            pnlLoginCard.Controls.Add(pnlLoading);
            pnlLoginCard.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlLoginCard.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlLoginCard.Location = new Point(329, 306);
            pnlLoginCard.Name = "pnlLoginCard";
            pnlLoginCard.Padding = new Padding(35);
            pnlLoginCard.Size = new Size(430, 560);
            pnlLoginCard.TabIndex = 3;
            // 
            // pnlLogoContainer
            // 
            pnlLogoContainer.BackColor = Color.FromArgb(242, 242, 242);
            pnlLogoContainer.Controls.Add(picLogo);
            pnlLogoContainer.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlLogoContainer.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlLogoContainer.Location = new Point(165, 25);
            pnlLogoContainer.Name = "pnlLogoContainer";
            pnlLogoContainer.Size = new Size(100, 100);
            pnlLogoContainer.TabIndex = 0;
            // 
            // picLogo
            // 
            picLogo.BackColor = Color.FromArgb(242, 242, 242);
            picLogo.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            picLogo.ForeColor = Color.FromArgb(222, 0, 0, 0);
            picLogo.Location = new Point(20, 20);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(60, 60);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // lblXosGeldin
            // 
            lblXosGeldin.BackColor = Color.FromArgb(242, 242, 242);
            lblXosGeldin.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblXosGeldin.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblXosGeldin.Location = new Point(35, 135);
            lblXosGeldin.Name = "lblXosGeldin";
            lblXosGeldin.Size = new Size(360, 28);
            lblXosGeldin.TabIndex = 1;
            lblXosGeldin.Text = "Xoş gəlmisiniz!";
            lblXosGeldin.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblBasliq
            // 
            lblBasliq.BackColor = Color.FromArgb(242, 242, 242);
            lblBasliq.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblBasliq.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblBasliq.Location = new Point(35, 165);
            lblBasliq.Name = "lblBasliq";
            lblBasliq.Size = new Size(360, 40);
            lblBasliq.TabIndex = 2;
            lblBasliq.Text = "AzAgroPOS";
            lblBasliq.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAltBasliq
            // 
            lblAltBasliq.BackColor = Color.FromArgb(242, 242, 242);
            lblAltBasliq.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblAltBasliq.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblAltBasliq.Location = new Point(35, 205);
            lblAltBasliq.Name = "lblAltBasliq";
            lblAltBasliq.Size = new Size(360, 25);
            lblAltBasliq.TabIndex = 3;
            lblAltBasliq.Text = "Satış və İdarəetmə Sistemi";
            lblAltBasliq.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlDivider
            // 
            pnlDivider.BackColor = Color.FromArgb(242, 242, 242);
            pnlDivider.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlDivider.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlDivider.Location = new Point(35, 245);
            pnlDivider.Name = "pnlDivider";
            pnlDivider.Size = new Size(360, 1);
            pnlDivider.TabIndex = 4;
            // 
            // txtIstifadeciAdi
            // 
            txtIstifadeciAdi.AnimateReadOnly = false;
            txtIstifadeciAdi.BackColor = Color.FromArgb(242, 242, 242);
            txtIstifadeciAdi.BackgroundImageLayout = ImageLayout.None;
            txtIstifadeciAdi.CharacterCasing = CharacterCasing.Normal;
            txtIstifadeciAdi.Depth = 0;
            txtIstifadeciAdi.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtIstifadeciAdi.HideSelection = true;
            txtIstifadeciAdi.Hint = "İstifadəçi adı";
            txtIstifadeciAdi.LeadingIcon = null;
            txtIstifadeciAdi.Location = new Point(35, 265);
            txtIstifadeciAdi.MaxLength = 50;
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
            txtIstifadeciAdi.Size = new Size(360, 48);
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
            txtParol.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtParol.HideSelection = true;
            txtParol.Hint = "Parol";
            txtParol.LeadingIcon = null;
            txtParol.Location = new Point(35, 335);
            txtParol.MaxLength = 100;
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
            txtParol.Size = new Size(360, 48);
            txtParol.TabIndex = 1;
            txtParol.TabStop = false;
            txtParol.TextAlign = HorizontalAlignment.Left;
            txtParol.TrailingIcon = null;
            txtParol.UseSystemPasswordChar = false;
            // 
            // btnParolGoster
            // 
            btnParolGoster.BackColor = Color.FromArgb(242, 242, 242);
            btnParolGoster.Cursor = Cursors.Hand;
            btnParolGoster.FlatAppearance.BorderSize = 0;
            btnParolGoster.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 240, 240);
            btnParolGoster.FlatStyle = FlatStyle.Flat;
            btnParolGoster.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            btnParolGoster.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnParolGoster.Location = new Point(355, 342);
            btnParolGoster.Name = "btnParolGoster";
            btnParolGoster.Size = new Size(36, 36);
            btnParolGoster.TabIndex = 5;
            btnParolGoster.TabStop = false;
            btnParolGoster.Text = "👁";
            btnParolGoster.UseVisualStyleBackColor = false;
            // 
            // lblCapsLock
            // 
            lblCapsLock.BackColor = Color.FromArgb(242, 242, 242);
            lblCapsLock.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblCapsLock.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblCapsLock.Location = new Point(35, 390);
            lblCapsLock.Name = "lblCapsLock";
            lblCapsLock.Size = new Size(360, 24);
            lblCapsLock.TabIndex = 6;
            lblCapsLock.Text = "CAPS LOCK aktivdir";
            lblCapsLock.TextAlign = ContentAlignment.MiddleCenter;
            lblCapsLock.Visible = false;
            // 
            // chkMeniXatirla
            // 
            chkMeniXatirla.AutoSize = true;
            chkMeniXatirla.BackColor = Color.FromArgb(242, 242, 242);
            chkMeniXatirla.Depth = 0;
            chkMeniXatirla.ForeColor = Color.FromArgb(222, 0, 0, 0);
            chkMeniXatirla.Location = new Point(35, 420);
            chkMeniXatirla.Margin = new Padding(0);
            chkMeniXatirla.MouseLocation = new Point(-1, -1);
            chkMeniXatirla.MouseState = MaterialSkin.MouseState.HOVER;
            chkMeniXatirla.Name = "chkMeniXatirla";
            chkMeniXatirla.ReadOnly = false;
            chkMeniXatirla.Ripple = true;
            chkMeniXatirla.Size = new Size(118, 37);
            chkMeniXatirla.TabIndex = 2;
            chkMeniXatirla.Text = "Məni xatırla";
            chkMeniXatirla.UseVisualStyleBackColor = false;
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
            btnDaxilOl.Location = new Point(35, 470);
            btnDaxilOl.Margin = new Padding(5, 7, 5, 7);
            btnDaxilOl.MouseState = MaterialSkin.MouseState.HOVER;
            btnDaxilOl.Name = "btnDaxilOl";
            btnDaxilOl.NoAccentTextColor = Color.Empty;
            btnDaxilOl.Size = new Size(360, 50);
            btnDaxilOl.TabIndex = 3;
            btnDaxilOl.Text = "DAXİL OL";
            btnDaxilOl.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnDaxilOl.UseAccentColor = false;
            btnDaxilOl.UseVisualStyleBackColor = false;
            btnDaxilOl.Click += btnDaxilOl_Click;
            // 
            // pnlLoading
            // 
            pnlLoading.BackColor = Color.FromArgb(242, 242, 242);
            pnlLoading.Controls.Add(picLoading);
            pnlLoading.Controls.Add(lblLoading);
            pnlLoading.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlLoading.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlLoading.Location = new Point(35, 470);
            pnlLoading.Name = "pnlLoading";
            pnlLoading.Size = new Size(360, 50);
            pnlLoading.TabIndex = 7;
            pnlLoading.Visible = false;
            // 
            // picLoading
            // 
            picLoading.BackColor = Color.FromArgb(242, 242, 242);
            picLoading.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            picLoading.ForeColor = Color.FromArgb(222, 0, 0, 0);
            picLoading.Location = new Point(120, 13);
            picLoading.Name = "picLoading";
            picLoading.Size = new Size(24, 24);
            picLoading.TabIndex = 0;
            picLoading.TabStop = false;
            // 
            // lblLoading
            // 
            lblLoading.BackColor = Color.FromArgb(242, 242, 242);
            lblLoading.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblLoading.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblLoading.Location = new Point(150, 13);
            lblLoading.Name = "lblLoading";
            lblLoading.Size = new Size(150, 24);
            lblLoading.TabIndex = 1;
            lblLoading.Text = "Giriş edilir...";
            lblLoading.TextAlign = ContentAlignment.MiddleLeft;
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
            ClientSize = new Size(666, 699);
            Controls.Add(pnlMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginFormu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AzAgroPOS - Sistemə Giriş";
            Controls.SetChildIndex(pnlMain, 0);
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            pnlLoginCard.ResumeLayout(false);
            pnlLoginCard.PerformLayout();
            pnlLogoContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            pnlLoading.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLoading).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlMain;
        private Panel pnlLoginCard;
        private Panel pnlCardShadow;
        private Panel pnlLogoContainer;
        private Panel pnlDivider;
        private PictureBox picLogo;
        private PictureBox picLoading;
        private Label lblBasliq;
        private Label lblAltBasliq;
        private Label lblXosGeldin;
        private Label lblCopyright;
        private MaterialSkin.Controls.MaterialTextBox2 txtIstifadeciAdi;
        private MaterialSkin.Controls.MaterialTextBox2 txtParol;
        private Button btnParolGoster;
        private Label lblCapsLock;
        private MaterialSkin.Controls.MaterialCheckbox chkMeniXatirla;
        private MaterialSkin.Controls.MaterialButton btnDaxilOl;
        private Panel pnlLoading;
        private Label lblLoading;
        private Label lblVersion;
        private ErrorProvider errorProvider1;
    }
}
