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
            pnlLoginCard = new Panel();
            pnlCardShadow = new Panel();
            lblVersion = new Label();
            lblCopyright = new Label();
            chkMeniXatirla = new MaterialSkin.Controls.MaterialCheckbox();
            lblCapsLock = new Label();
            btnParolGoster = new Button();
            txtIstifadeciAdi = new MaterialSkin.Controls.MaterialTextBox2();
            txtParol = new MaterialSkin.Controls.MaterialTextBox2();
            btnDaxilOl = new MaterialSkin.Controls.MaterialButton();
            pnlLoading = new Panel();
            lblLoading = new Label();
            picLoading = new PictureBox();
            picLogo = new PictureBox();
            pnlLogoContainer = new Panel();
            lblBasliq = new Label();
            lblAltBasliq = new Label();
            pnlDivider = new Panel();
            lblXosGeldin = new Label();
            errorProvider1 = new ErrorProvider(components);

            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLoading).BeginInit();
            pnlMain.SuspendLayout();
            pnlLoginCard.SuspendLayout();
            pnlLoading.SuspendLayout();
            pnlLogoContainer.SuspendLayout();
            SuspendLayout();

            //
            // pnlMain - Gradient background panel
            //
            pnlMain.BackColor = Color.FromArgb(25, 118, 210);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(pnlCardShadow);
            pnlMain.Controls.Add(pnlLoginCard);
            pnlMain.Controls.Add(lblVersion);
            pnlMain.Controls.Add(lblCopyright);
            pnlMain.Name = "pnlMain";

            //
            // pnlCardShadow - Shadow effect
            //
            pnlCardShadow.BackColor = Color.FromArgb(40, 0, 0, 0);
            pnlCardShadow.Size = new Size(430, 560);
            pnlCardShadow.Location = new Point(104, 48);
            pnlCardShadow.Anchor = AnchorStyles.None;
            pnlCardShadow.Name = "pnlCardShadow";

            //
            // pnlLoginCard - White card in center
            //
            pnlLoginCard.BackColor = Color.White;
            pnlLoginCard.Size = new Size(430, 560);
            pnlLoginCard.Location = new Point(99, 40);
            pnlLoginCard.Anchor = AnchorStyles.None;
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
            pnlLoginCard.Name = "pnlLoginCard";
            pnlLoginCard.Padding = new Padding(35);

            //
            // pnlLogoContainer - Logo background circle
            //
            pnlLogoContainer.Size = new Size(100, 100);
            pnlLogoContainer.Location = new Point(165, 25);
            pnlLogoContainer.BackColor = Color.FromArgb(25, 118, 210);
            pnlLogoContainer.Name = "pnlLogoContainer";
            pnlLogoContainer.Controls.Add(picLogo);

            //
            // picLogo
            //
            picLogo.Size = new Size(60, 60);
            picLogo.Location = new Point(20, 20);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.BackColor = Color.Transparent;
            picLogo.Name = "picLogo";

            //
            // lblXosGeldin
            //
            lblXosGeldin.AutoSize = false;
            lblXosGeldin.Size = new Size(360, 28);
            lblXosGeldin.Location = new Point(35, 135);
            lblXosGeldin.Text = "Xoş gəlmisiniz!";
            lblXosGeldin.Font = new Font("Segoe UI", 13F, FontStyle.Regular);
            lblXosGeldin.ForeColor = Color.FromArgb(25, 118, 210);
            lblXosGeldin.TextAlign = ContentAlignment.MiddleCenter;
            lblXosGeldin.Name = "lblXosGeldin";

            //
            // lblBasliq
            //
            lblBasliq.AutoSize = false;
            lblBasliq.Size = new Size(360, 40);
            lblBasliq.Location = new Point(35, 165);
            lblBasliq.Text = "AzAgroPOS";
            lblBasliq.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblBasliq.ForeColor = Color.FromArgb(33, 33, 33);
            lblBasliq.TextAlign = ContentAlignment.MiddleCenter;
            lblBasliq.Name = "lblBasliq";

            //
            // lblAltBasliq
            //
            lblAltBasliq.AutoSize = false;
            lblAltBasliq.Size = new Size(360, 25);
            lblAltBasliq.Location = new Point(35, 205);
            lblAltBasliq.Text = "Satış və İdarəetmə Sistemi";
            lblAltBasliq.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblAltBasliq.ForeColor = Color.FromArgb(117, 117, 117);
            lblAltBasliq.TextAlign = ContentAlignment.MiddleCenter;
            lblAltBasliq.Name = "lblAltBasliq";

            //
            // pnlDivider
            //
            pnlDivider.Size = new Size(360, 1);
            pnlDivider.Location = new Point(35, 245);
            pnlDivider.BackColor = Color.FromArgb(224, 224, 224);
            pnlDivider.Name = "pnlDivider";

            //
            // txtIstifadeciAdi
            //
            txtIstifadeciAdi.AnimateReadOnly = false;
            txtIstifadeciAdi.BackColor = Color.White;
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
            txtIstifadeciAdi.Size = new Size(360, 50);
            txtIstifadeciAdi.TabIndex = 0;
            txtIstifadeciAdi.TextAlign = HorizontalAlignment.Left;
            txtIstifadeciAdi.TrailingIcon = null;
            txtIstifadeciAdi.UseSystemPasswordChar = false;

            //
            // txtParol
            //
            txtParol.AnimateReadOnly = false;
            txtParol.BackColor = Color.White;
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
            txtParol.Size = new Size(360, 50);
            txtParol.TabIndex = 1;
            txtParol.TextAlign = HorizontalAlignment.Left;
            txtParol.TrailingIcon = null;
            txtParol.UseSystemPasswordChar = false;

            //
            // btnParolGoster - Toggle password visibility
            //
            btnParolGoster.Size = new Size(36, 36);
            btnParolGoster.Location = new Point(355, 342);
            btnParolGoster.FlatStyle = FlatStyle.Flat;
            btnParolGoster.FlatAppearance.BorderSize = 0;
            btnParolGoster.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 240, 240);
            btnParolGoster.BackColor = Color.Transparent;
            btnParolGoster.Cursor = Cursors.Hand;
            btnParolGoster.Text = "👁";
            btnParolGoster.Font = new Font("Segoe UI", 14F);
            btnParolGoster.Name = "btnParolGoster";
            btnParolGoster.TabStop = false;

            //
            // lblCapsLock - CAPS LOCK warning
            //
            lblCapsLock.AutoSize = false;
            lblCapsLock.Size = new Size(360, 24);
            lblCapsLock.Location = new Point(35, 390);
            lblCapsLock.Text = "CAPS LOCK aktivdir";
            lblCapsLock.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCapsLock.ForeColor = Color.FromArgb(244, 67, 54);
            lblCapsLock.BackColor = Color.FromArgb(255, 235, 238);
            lblCapsLock.TextAlign = ContentAlignment.MiddleCenter;
            lblCapsLock.Visible = false;
            lblCapsLock.Name = "lblCapsLock";

            //
            // chkMeniXatirla
            //
            chkMeniXatirla.AutoSize = true;
            chkMeniXatirla.Location = new Point(35, 420);
            chkMeniXatirla.Depth = 0;
            chkMeniXatirla.MouseLocation = new Point(-1, -1);
            chkMeniXatirla.MouseState = MaterialSkin.MouseState.HOVER;
            chkMeniXatirla.Name = "chkMeniXatirla";
            chkMeniXatirla.ReadOnly = false;
            chkMeniXatirla.Ripple = true;
            chkMeniXatirla.TabIndex = 2;
            chkMeniXatirla.Text = "Məni xatırla";
            chkMeniXatirla.UseVisualStyleBackColor = true;

            //
            // btnDaxilOl
            //
            btnDaxilOl.AutoSize = false;
            btnDaxilOl.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnDaxilOl.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnDaxilOl.Depth = 0;
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
            btnDaxilOl.UseVisualStyleBackColor = true;
            btnDaxilOl.Click += btnDaxilOl_Click;

            //
            // pnlLoading - Loading overlay with spinner
            //
            pnlLoading.Size = new Size(360, 50);
            pnlLoading.Location = new Point(35, 470);
            pnlLoading.BackColor = Color.FromArgb(25, 118, 210);
            pnlLoading.Visible = false;
            pnlLoading.Controls.Add(picLoading);
            pnlLoading.Controls.Add(lblLoading);
            pnlLoading.Name = "pnlLoading";

            //
            // picLoading - Loading spinner placeholder
            //
            picLoading.Size = new Size(24, 24);
            picLoading.Location = new Point(120, 13);
            picLoading.BackColor = Color.Transparent;
            picLoading.Name = "picLoading";

            //
            // lblLoading
            //
            lblLoading.AutoSize = false;
            lblLoading.Size = new Size(150, 24);
            lblLoading.Location = new Point(150, 13);
            lblLoading.Text = "Giriş edilir...";
            lblLoading.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblLoading.ForeColor = Color.White;
            lblLoading.TextAlign = ContentAlignment.MiddleLeft;
            lblLoading.Name = "lblLoading";

            //
            // lblVersion
            //
            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(12, 620);
            lblVersion.Text = "v1.0.0";
            lblVersion.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblVersion.ForeColor = Color.FromArgb(200, 255, 255, 255);
            lblVersion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblVersion.Name = "lblVersion";

            //
            // lblCopyright
            //
            lblCopyright.AutoSize = true;
            lblCopyright.Location = new Point(450, 620);
            lblCopyright.Text = "© 2024 AzAgroPOS";
            lblCopyright.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblCopyright.ForeColor = Color.FromArgb(200, 255, 255, 255);
            lblCopyright.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblCopyright.Name = "lblCopyright";

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
            ClientSize = new Size(650, 660);
            Controls.Add(pnlMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginFormu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AzAgroPOS - Sistemə Giriş";

            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLoading).EndInit();
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            pnlLoginCard.ResumeLayout(false);
            pnlLoginCard.PerformLayout();
            pnlLoading.ResumeLayout(false);
            pnlLogoContainer.ResumeLayout(false);
            ResumeLayout(false);
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
