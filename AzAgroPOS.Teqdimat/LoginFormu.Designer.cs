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
            lblVersion = new Label();
            chkMeniXatirla = new MaterialSkin.Controls.MaterialCheckbox();
            lblCapsLock = new Label();
            btnParolGoster = new Button();
            txtIstifadeciAdi = new MaterialSkin.Controls.MaterialTextBox2();
            txtParol = new MaterialSkin.Controls.MaterialTextBox2();
            btnDaxilOl = new MaterialSkin.Controls.MaterialButton();
            pnlLoading = new Panel();
            lblLoading = new Label();
            picLogo = new PictureBox();
            lblBasliq = new Label();
            lblAltBasliq = new Label();
            errorProvider1 = new ErrorProvider(components);

            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            pnlMain.SuspendLayout();
            pnlLoginCard.SuspendLayout();
            pnlLoading.SuspendLayout();
            SuspendLayout();

            //
            // pnlMain - Gradient background panel
            //
            pnlMain.BackColor = Color.FromArgb(33, 150, 243);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(pnlLoginCard);
            pnlMain.Controls.Add(lblVersion);
            pnlMain.Name = "pnlMain";

            //
            // pnlLoginCard - White card in center
            //
            pnlLoginCard.BackColor = Color.White;
            pnlLoginCard.Size = new Size(420, 480);
            pnlLoginCard.Location = new Point(99, 40);
            pnlLoginCard.Anchor = AnchorStyles.None;
            pnlLoginCard.Controls.Add(picLogo);
            pnlLoginCard.Controls.Add(lblBasliq);
            pnlLoginCard.Controls.Add(lblAltBasliq);
            pnlLoginCard.Controls.Add(txtIstifadeciAdi);
            pnlLoginCard.Controls.Add(txtParol);
            pnlLoginCard.Controls.Add(btnParolGoster);
            pnlLoginCard.Controls.Add(lblCapsLock);
            pnlLoginCard.Controls.Add(chkMeniXatirla);
            pnlLoginCard.Controls.Add(btnDaxilOl);
            pnlLoginCard.Controls.Add(pnlLoading);
            pnlLoginCard.Name = "pnlLoginCard";
            pnlLoginCard.Padding = new Padding(30);

            //
            // picLogo
            //
            picLogo.Size = new Size(80, 80);
            picLogo.Location = new Point(170, 20);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.BackColor = Color.FromArgb(33, 150, 243);
            picLogo.Name = "picLogo";

            //
            // lblBasliq
            //
            lblBasliq.AutoSize = false;
            lblBasliq.Size = new Size(360, 35);
            lblBasliq.Location = new Point(30, 110);
            lblBasliq.Text = "AzAgroPOS";
            lblBasliq.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            lblBasliq.ForeColor = Color.FromArgb(33, 33, 33);
            lblBasliq.TextAlign = ContentAlignment.MiddleCenter;
            lblBasliq.Name = "lblBasliq";

            //
            // lblAltBasliq
            //
            lblAltBasliq.AutoSize = false;
            lblAltBasliq.Size = new Size(360, 25);
            lblAltBasliq.Location = new Point(30, 145);
            lblAltBasliq.Text = "Sistemə daxil olun";
            lblAltBasliq.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            lblAltBasliq.ForeColor = Color.FromArgb(117, 117, 117);
            lblAltBasliq.TextAlign = ContentAlignment.MiddleCenter;
            lblAltBasliq.Name = "lblAltBasliq";

            //
            // txtIstifadeciAdi
            //
            txtIstifadeciAdi.AnimateReadOnly = false;
            txtIstifadeciAdi.BackColor = Color.White;
            txtIstifadeciAdi.BackgroundImageLayout = ImageLayout.None;
            txtIstifadeciAdi.CharacterCasing = CharacterCasing.Normal;
            txtIstifadeciAdi.Depth = 0;
            txtIstifadeciAdi.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtIstifadeciAdi.HideSelection = true;
            txtIstifadeciAdi.Hint = "İstifadəçi adı";
            txtIstifadeciAdi.LeadingIcon = null;
            txtIstifadeciAdi.Location = new Point(30, 190);
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
            txtParol.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtParol.HideSelection = true;
            txtParol.Hint = "Parol";
            txtParol.LeadingIcon = null;
            txtParol.Location = new Point(30, 255);
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
            txtParol.TextAlign = HorizontalAlignment.Left;
            txtParol.TrailingIcon = null;
            txtParol.UseSystemPasswordChar = false;

            //
            // btnParolGoster - Toggle password visibility
            //
            btnParolGoster.Size = new Size(30, 30);
            btnParolGoster.Location = new Point(355, 265);
            btnParolGoster.FlatStyle = FlatStyle.Flat;
            btnParolGoster.FlatAppearance.BorderSize = 0;
            btnParolGoster.BackColor = Color.Transparent;
            btnParolGoster.Cursor = Cursors.Hand;
            btnParolGoster.Text = "👁";
            btnParolGoster.Font = new Font("Segoe UI", 12F);
            btnParolGoster.Name = "btnParolGoster";
            btnParolGoster.TabStop = false;

            //
            // lblCapsLock - CAPS LOCK warning
            //
            lblCapsLock.AutoSize = true;
            lblCapsLock.Location = new Point(30, 308);
            lblCapsLock.Text = "⚠ CAPS LOCK aktiv";
            lblCapsLock.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblCapsLock.ForeColor = Color.FromArgb(255, 152, 0);
            lblCapsLock.Visible = false;
            lblCapsLock.Name = "lblCapsLock";

            //
            // chkMeniXatirla
            //
            chkMeniXatirla.AutoSize = true;
            chkMeniXatirla.Location = new Point(30, 330);
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
            btnDaxilOl.Location = new Point(30, 380);
            btnDaxilOl.Margin = new Padding(5, 7, 5, 7);
            btnDaxilOl.MouseState = MaterialSkin.MouseState.HOVER;
            btnDaxilOl.Name = "btnDaxilOl";
            btnDaxilOl.NoAccentTextColor = Color.Empty;
            btnDaxilOl.Size = new Size(360, 45);
            btnDaxilOl.TabIndex = 3;
            btnDaxilOl.Text = "DAXİL OL";
            btnDaxilOl.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnDaxilOl.UseAccentColor = false;
            btnDaxilOl.UseVisualStyleBackColor = true;
            btnDaxilOl.Click += btnDaxilOl_Click;

            //
            // pnlLoading - Loading overlay
            //
            pnlLoading.Size = new Size(360, 45);
            pnlLoading.Location = new Point(30, 380);
            pnlLoading.BackColor = Color.FromArgb(33, 150, 243);
            pnlLoading.Visible = false;
            pnlLoading.Controls.Add(lblLoading);
            pnlLoading.Name = "pnlLoading";

            //
            // lblLoading
            //
            lblLoading.Dock = DockStyle.Fill;
            lblLoading.Text = "Yüklənir...";
            lblLoading.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            lblLoading.ForeColor = Color.White;
            lblLoading.TextAlign = ContentAlignment.MiddleCenter;
            lblLoading.Name = "lblLoading";

            //
            // lblVersion
            //
            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(12, 540);
            lblVersion.Text = "v1.0.0";
            lblVersion.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblVersion.ForeColor = Color.White;
            lblVersion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblVersion.Name = "lblVersion";

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
            ClientSize = new Size(618, 570);
            Controls.Add(pnlMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginFormu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AzAgroPOS - Sistemə Giriş";

            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            pnlLoginCard.ResumeLayout(false);
            pnlLoginCard.PerformLayout();
            pnlLoading.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMain;
        private Panel pnlLoginCard;
        private PictureBox picLogo;
        private Label lblBasliq;
        private Label lblAltBasliq;
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
