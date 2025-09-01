// Fayl: AzAgroPOS.Teqdimat/AnaMenuFormu.Designer.cs
namespace AzAgroPOS.Teqdimat
{
    partial class AnaMenuFormu
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
            this.components = new System.ComponentModel.Container();

            // Ana panellər
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlUserInfo = new System.Windows.Forms.Panel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblUserRole = new System.Windows.Forms.Label();
            this.picUserAvatar = new System.Windows.Forms.PictureBox();

            // Menyu düymələri
            this.btnNovbeIdareetme = new MaterialSkin.Controls.MaterialButton();
            this.btnMehsulIdareetme = new MaterialSkin.Controls.MaterialButton();
            this.btnYeniSatis = new MaterialSkin.Controls.MaterialButton();
            this.btnNisyeIdareetme = new MaterialSkin.Controls.MaterialButton();
            this.btnTemirIdareetme = new MaterialSkin.Controls.MaterialButton();
            this.btnIstifadeciIdareetme = new MaterialSkin.Controls.MaterialButton();
            this.btnHesabatlar = new MaterialSkin.Controls.MaterialButton();
            this.btnMehsulSatisHesabati = new MaterialSkin.Controls.MaterialButton();
            this.btnAnbarQaliqHesabati = new MaterialSkin.Controls.MaterialButton();
            this.btnZHesabatArxivi = new MaterialSkin.Controls.MaterialButton();
            this.btnBarkodCapi = new MaterialSkin.Controls.MaterialButton();

            // Tab control və context menu
            this.mdiTabControl = new MaterialSkin.Controls.MaterialTabControl();
            this.tabContextMenu = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.baglaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hamisiCloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            // Menyu bölücüləri
            this.separator1 = new System.Windows.Forms.Panel();
            this.separator2 = new System.Windows.Forms.Panel();
            this.separator3 = new System.Windows.Forms.Panel();

            // Footer
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();

            // Animasiya timeri
            this.animationTimer = new System.Windows.Forms.Timer(this.components);

            this.pnlSidebar.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.pnlUserInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUserAvatar)).BeginInit();
            this.tabContextMenu.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.pnlSidebar.Controls.Add(this.pnlFooter);
            this.pnlSidebar.Controls.Add(this.btnBarkodCapi);
            this.pnlSidebar.Controls.Add(this.btnZHesabatArxivi);
            this.pnlSidebar.Controls.Add(this.btnAnbarQaliqHesabati);
            this.pnlSidebar.Controls.Add(this.btnMehsulSatisHesabati);
            this.pnlSidebar.Controls.Add(this.separator3);
            this.pnlSidebar.Controls.Add(this.btnHesabatlar);
            this.pnlSidebar.Controls.Add(this.separator2);
            this.pnlSidebar.Controls.Add(this.btnIstifadeciIdareetme);
            this.pnlSidebar.Controls.Add(this.btnTemirIdareetme);
            this.pnlSidebar.Controls.Add(this.btnNisyeIdareetme);
            this.pnlSidebar.Controls.Add(this.btnYeniSatis);
            this.pnlSidebar.Controls.Add(this.btnMehsulIdareetme);
            this.pnlSidebar.Controls.Add(this.separator1);
            this.pnlSidebar.Controls.Add(this.btnNovbeIdareetme);
            this.pnlSidebar.Controls.Add(this.pnlUserInfo);
            this.pnlSidebar.Controls.Add(this.pnlLogo);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(3, 64);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pnlSidebar.Size = new System.Drawing.Size(260, 673);
            this.pnlSidebar.TabIndex = 1;

            // 
            // pnlLogo
            // 
            this.pnlLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlLogo.Controls.Add(this.lblCompanyName);
            this.pnlLogo.Controls.Add(this.picLogo);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 10);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.pnlLogo.Size = new System.Drawing.Size(260, 80);
            this.pnlLogo.TabIndex = 0;

            // 
            // picLogo
            // 
            this.picLogo.BackgroundImage = null;
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picLogo.Location = new System.Drawing.Point(15, 15);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(50, 50);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;

            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCompanyName.ForeColor = System.Drawing.Color.White;
            this.lblCompanyName.Location = new System.Drawing.Point(75, 20);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(110, 27);
            this.lblCompanyName.TabIndex = 1;
            this.lblCompanyName.Text = "AzAgroPOS";

            // 
            // pnlUserInfo
            // 
            this.pnlUserInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(45)))));
            this.pnlUserInfo.Controls.Add(this.lblUserRole);
            this.pnlUserInfo.Controls.Add(this.lblUserName);
            this.pnlUserInfo.Controls.Add(this.picUserAvatar);
            this.pnlUserInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlUserInfo.Location = new System.Drawing.Point(0, 90);
            this.pnlUserInfo.Name = "pnlUserInfo";
            this.pnlUserInfo.Padding = new System.Windows.Forms.Padding(15, 15, 15, 10);
            this.pnlUserInfo.Size = new System.Drawing.Size(260, 75);
            this.pnlUserInfo.TabIndex = 1;

            // 
            // picUserAvatar
            // 
            this.picUserAvatar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.picUserAvatar.Location = new System.Drawing.Point(15, 15);
            this.picUserAvatar.Name = "picUserAvatar";
            this.picUserAvatar.Size = new System.Drawing.Size(45, 45);
            this.picUserAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUserAvatar.TabIndex = 0;
            this.picUserAvatar.TabStop = false;

            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblUserName.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Location = new System.Drawing.Point(70, 18);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(91, 19);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "İstifadəçi";

            // 
            // lblUserRole
            // 
            this.lblUserRole.AutoSize = true;
            this.lblUserRole.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUserRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.lblUserRole.Location = new System.Drawing.Point(70, 40);
            this.lblUserRole.Name = "lblUserRole";
            this.lblUserRole.Size = new System.Drawing.Size(31, 17);
            this.lblUserRole.TabIndex = 2;
            this.lblUserRole.Text = "Rol";

            // Menyu düymələri
            CreateMenuButton(this.btnNovbeIdareetme, "Növbəni İdarə Et", 165, true, "🎯");
            CreateMenuButton(this.btnMehsulIdareetme, "Məhsullar", 215, false, "📦");
            CreateMenuButton(this.btnYeniSatis, "Yeni Satış", 265, false, "🛒");
            CreateMenuButton(this.btnNisyeIdareetme, "Nisyə / Borc", 315, false, "💳");
            CreateMenuButton(this.btnTemirIdareetme, "Təmir", 365, false, "🔧");
            CreateMenuButton(this.btnIstifadeciIdareetme, "İstifadəçilər", 415, false, "👥");
            CreateMenuButton(this.btnHesabatlar, "Günlük Hesabat", 485, false, "📊");
            CreateMenuButton(this.btnMehsulSatisHesabati, "Məhsul Hesabatı", 535, false, "📈");
            CreateMenuButton(this.btnAnbarQaliqHesabati, "Anbar Qalığı", 585, false, "📋");
            CreateMenuButton(this.btnZHesabatArxivi, "Z-Hesabat Arxivi", 635, false, "🗂️");
            CreateMenuButton(this.btnBarkodCapi, "Barkod Çapı", 685, false, "🏷️");

            // Bölücülər
            CreateSeparator(this.separator1, 190);
            CreateSeparator(this.separator2, 460);
            CreateSeparator(this.separator3, 510);

            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(35)))));
            this.pnlFooter.Controls.Add(this.lblVersion);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 643);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Padding = new System.Windows.Forms.Padding(15, 8, 15, 8);
            this.pnlFooter.Size = new System.Drawing.Size(260, 30);
            this.pnlFooter.TabIndex = 12;

            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lblVersion.Location = new System.Drawing.Point(15, 8);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(77, 14);
            this.lblVersion.TabIndex = 0;
            this.lblVersion.Text = "Versiya 2.0.0";

            // 
            // mdiTabControl
            // 
            this.mdiTabControl.Depth = 0;
            this.mdiTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mdiTabControl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mdiTabControl.Location = new System.Drawing.Point(263, 64);
            this.mdiTabControl.MouseState = MaterialSkin.MouseState.HOVER;
            this.mdiTabControl.Multiline = true;
            this.mdiTabControl.Name = "mdiTabControl";
            this.mdiTabControl.SelectedIndex = 0;
            this.mdiTabControl.Size = new System.Drawing.Size(1210, 673);
            this.mdiTabControl.TabIndex = 2;
            this.mdiTabControl.MouseClick += this.mdiTabControl_MouseClick;

            // 
            // tabContextMenu
            // 
            this.tabContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tabContextMenu.Depth = 0;
            this.tabContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.baglaToolStripMenuItem,
                this.hamisiCloseToolStripMenuItem
            });
            this.tabContextMenu.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabContextMenu.Name = "tabContextMenu";
            this.tabContextMenu.Size = new System.Drawing.Size(180, 48);

            // 
            // baglaToolStripMenuItem
            // 
            this.baglaToolStripMenuItem.Name = "baglaToolStripMenuItem";
            this.baglaToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.baglaToolStripMenuItem.Text = "Bağla";
            this.baglaToolStripMenuItem.Click += this.baglaToolStripMenuItem_Click;

            // 
            // hamisiCloseToolStripMenuItem
            // 
            this.hamisiCloseToolStripMenuItem.Name = "hamisiCloseToolStripMenuItem";
            this.hamisiCloseToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.hamisiCloseToolStripMenuItem.Text = "Hamısını Bağla";
            this.hamisiCloseToolStripMenuItem.Click += this.hamisiCloseToolStripMenuItem_Click;

            // 
            // animationTimer
            // 
            this.animationTimer.Interval = 16;
            this.animationTimer.Tick += this.animationTimer_Tick;

            // 
            // AnaMenuFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1473, 740);
            this.Controls.Add(this.mdiTabControl);
            this.Controls.Add(this.pnlSidebar);
            this.DrawerShowIconsWhenHidden = true;
            this.Name = "AnaMenuFormu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AzAgroPOS - Ana Menyu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            this.pnlSidebar.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            this.pnlLogo.PerformLayout();
            this.pnlUserInfo.ResumeLayout(false);
            this.pnlUserInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUserAvatar)).EndInit();
            this.tabContextMenu.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
        }

        private void CreateMenuButton(MaterialSkin.Controls.MaterialButton btn, string text, int top, bool isAccent, string icon)
        {
            btn.AutoSize = false;
            btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            btn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn.Depth = 0;
            btn.ForeColor = System.Drawing.Color.White;
            btn.HighEmphasis = true;
            btn.Icon = null;
            btn.Location = new System.Drawing.Point(10, top);
            btn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            btn.MouseState = MaterialSkin.MouseState.HOVER;
            btn.Name = btn.Name;
            btn.NoAccentTextColor = System.Drawing.Color.Empty;
            btn.Size = new System.Drawing.Size(240, 45);
            btn.TabIndex = 0;
            btn.Text = $"{icon}  {text}";
            btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            btn.UseAccentColor = isAccent;
            btn.UseVisualStyleBackColor = false;

            // Hover efekti üçün
            btn.MouseEnter += MenuButton_MouseEnter;
            btn.MouseLeave += MenuButton_MouseLeave;
        }

        private void CreateSeparator(System.Windows.Forms.Panel separator, int top)
        {
            separator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(63)))));
            separator.Location = new System.Drawing.Point(20, top);
            separator.Name = separator.Name;
            separator.Size = new System.Drawing.Size(220, 1);
            separator.TabIndex = 0;
        }

        private void MenuButton_MouseEnter(object sender, EventArgs e)
        {
            if (sender is MaterialSkin.Controls.MaterialButton btn)
            {
                btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(58)))));
            }
        }

        private void MenuButton_MouseLeave(object sender, EventArgs e)
        {
            if (sender is MaterialSkin.Controls.MaterialButton btn)
            {
                btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            }
        }

        #endregion

        // Kontrol dəyişənləri
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel pnlUserInfo;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblUserRole;
        private System.Windows.Forms.PictureBox picUserAvatar;

        private MaterialSkin.Controls.MaterialButton btnNovbeIdareetme;
        private MaterialSkin.Controls.MaterialButton btnMehsulIdareetme;
        private MaterialSkin.Controls.MaterialButton btnYeniSatis;
        private MaterialSkin.Controls.MaterialButton btnNisyeIdareetme;
        private MaterialSkin.Controls.MaterialButton btnTemirIdareetme;
        private MaterialSkin.Controls.MaterialButton btnIstifadeciIdareetme;
        private MaterialSkin.Controls.MaterialButton btnHesabatlar;
        private MaterialSkin.Controls.MaterialButton btnMehsulSatisHesabati;
        private MaterialSkin.Controls.MaterialButton btnAnbarQaliqHesabati;
        private MaterialSkin.Controls.MaterialButton btnZHesabatArxivi;
        private MaterialSkin.Controls.MaterialButton btnBarkodCapi;

        private MaterialSkin.Controls.MaterialTabControl mdiTabControl;
        private MaterialSkin.Controls.MaterialContextMenuStrip tabContextMenu;
        private System.Windows.Forms.ToolStripMenuItem baglaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hamisiCloseToolStripMenuItem;

        private System.Windows.Forms.Panel separator1;
        private System.Windows.Forms.Panel separator2;
        private System.Windows.Forms.Panel separator3;

        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblVersion;

        private System.Windows.Forms.Timer animationTimer;
    }
}