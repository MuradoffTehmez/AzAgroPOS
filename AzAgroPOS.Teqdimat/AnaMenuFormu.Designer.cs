// Fayl: AzAgroPOS.Teqdimat/AnaMenuFormu.Designer.cs
namespace AzAgroPOS.Teqdimat
{
    partial class AnaMenuFormu
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pnlMenu = new Panel();
            btnIsciIdareetme = new MaterialSkin.Controls.MaterialButton();
            btnBarkodCapi = new MaterialSkin.Controls.MaterialButton();
            sidebarImageList = new ImageList(components);
            separator2 = new Panel();
            btnZHesabatArxivi = new MaterialSkin.Controls.MaterialButton();
            btnAnbarQaliqHesabati = new MaterialSkin.Controls.MaterialButton();
            btnMehsulSatisHesabati = new MaterialSkin.Controls.MaterialButton();
            btnHesabatlar = new MaterialSkin.Controls.MaterialButton();
            btnIstifadeciIdareetme = new MaterialSkin.Controls.MaterialButton();
            separator1 = new Panel();
            btnTemirIdareetme = new MaterialSkin.Controls.MaterialButton();
            btnNisyeIdareetme = new MaterialSkin.Controls.MaterialButton();
            btnYeniSatis = new MaterialSkin.Controls.MaterialButton();
            btnMehsulIdareetme = new MaterialSkin.Controls.MaterialButton();
            btnNovbeIdareetme = new MaterialSkin.Controls.MaterialButton();
            pnlUserInfo = new Panel();
            lblUserName = new Label();
            picUserIcon = new PictureBox();
            mdiTabControl = new MaterialSkin.Controls.MaterialTabControl();
            tabContextMenu = new MaterialSkin.Controls.MaterialContextMenuStrip();
            baglaToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            hamisiniBaglaToolStripMenuItem = new ToolStripMenuItem();
            pnlMenu.SuspendLayout();
            pnlUserInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picUserIcon).BeginInit();
            tabContextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.FromArgb(242, 242, 242);
            pnlMenu.Controls.Add(btnIsciIdareetme);
            pnlMenu.Controls.Add(btnBarkodCapi);
            pnlMenu.Controls.Add(separator2);
            pnlMenu.Controls.Add(btnZHesabatArxivi);
            pnlMenu.Controls.Add(btnAnbarQaliqHesabati);
            pnlMenu.Controls.Add(btnMehsulSatisHesabati);
            pnlMenu.Controls.Add(btnHesabatlar);
            pnlMenu.Controls.Add(btnIstifadeciIdareetme);
            pnlMenu.Controls.Add(separator1);
            pnlMenu.Controls.Add(btnTemirIdareetme);
            pnlMenu.Controls.Add(btnNisyeIdareetme);
            pnlMenu.Controls.Add(btnYeniSatis);
            pnlMenu.Controls.Add(btnMehsulIdareetme);
            pnlMenu.Controls.Add(btnNovbeIdareetme);
            pnlMenu.Controls.Add(pnlUserInfo);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlMenu.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlMenu.Location = new Point(3, 64);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(240, 673);
            pnlMenu.TabIndex = 1;
            // 
            // btnIsciIdareetme
            // 
            btnIsciIdareetme.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnIsciIdareetme.BackColor = Color.FromArgb(242, 242, 242);
            btnIsciIdareetme.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnIsciIdareetme.Depth = 0;
            btnIsciIdareetme.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnIsciIdareetme.HighEmphasis = true;
            btnIsciIdareetme.Icon = null;
            btnIsciIdareetme.Location = new Point(49, 567);
            btnIsciIdareetme.Margin = new Padding(4, 6, 4, 6);
            btnIsciIdareetme.MouseState = MaterialSkin.MouseState.HOVER;
            btnIsciIdareetme.Name = "btnIsciIdareetme";
            btnIsciIdareetme.NoAccentTextColor = Color.Empty;
            btnIsciIdareetme.Size = new Size(64, 36);
            btnIsciIdareetme.TabIndex = 0;
            btnIsciIdareetme.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnIsciIdareetme.UseAccentColor = false;
            btnIsciIdareetme.UseVisualStyleBackColor = false;
            btnIsciIdareetme.Click += btnIsciIdareetme_Click_1;
            // 
            // btnBarkodCapi
            // 
            btnBarkodCapi.AutoSize = false;
            btnBarkodCapi.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBarkodCapi.BackColor = Color.FromArgb(242, 242, 242);
            btnBarkodCapi.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnBarkodCapi.Depth = 0;
            btnBarkodCapi.Dock = DockStyle.Top;
            btnBarkodCapi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnBarkodCapi.HighEmphasis = false;
            btnBarkodCapi.Icon = null;
            btnBarkodCapi.ImageAlign = ContentAlignment.MiddleLeft;
            btnBarkodCapi.ImageList = sidebarImageList;
            btnBarkodCapi.Location = new Point(0, 527);
            btnBarkodCapi.Margin = new Padding(4, 6, 4, 6);
            btnBarkodCapi.MouseState = MaterialSkin.MouseState.HOVER;
            btnBarkodCapi.Name = "btnBarkodCapi";
            btnBarkodCapi.NoAccentTextColor = Color.Empty;
            btnBarkodCapi.Size = new Size(240, 45);
            btnBarkodCapi.TabIndex = 10;
            btnBarkodCapi.Text = "Barkod Çapı";
            btnBarkodCapi.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            btnBarkodCapi.UseAccentColor = false;
            btnBarkodCapi.UseVisualStyleBackColor = false;
            btnBarkodCapi.Click += btnBarkodCapi_Click;
            // 
            // sidebarImageList
            // 
            sidebarImageList.ColorDepth = ColorDepth.Depth32Bit;
            sidebarImageList.ImageSize = new Size(24, 24);
            sidebarImageList.TransparentColor = Color.Transparent;
            // 
            // separator2
            // 
            separator2.BackColor = Color.FromArgb(242, 242, 242);
            separator2.Dock = DockStyle.Top;
            separator2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            separator2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            separator2.Location = new Point(0, 526);
            separator2.Name = "separator2";
            separator2.Size = new Size(240, 1);
            separator2.TabIndex = 12;
            // 
            // btnZHesabatArxivi
            // 
            btnZHesabatArxivi.AutoSize = false;
            btnZHesabatArxivi.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnZHesabatArxivi.BackColor = Color.FromArgb(242, 242, 242);
            btnZHesabatArxivi.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnZHesabatArxivi.Depth = 0;
            btnZHesabatArxivi.Dock = DockStyle.Top;
            btnZHesabatArxivi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnZHesabatArxivi.HighEmphasis = false;
            btnZHesabatArxivi.Icon = null;
            btnZHesabatArxivi.ImageAlign = ContentAlignment.MiddleLeft;
            btnZHesabatArxivi.ImageList = sidebarImageList;
            btnZHesabatArxivi.Location = new Point(0, 481);
            btnZHesabatArxivi.Margin = new Padding(4, 6, 4, 6);
            btnZHesabatArxivi.MouseState = MaterialSkin.MouseState.HOVER;
            btnZHesabatArxivi.Name = "btnZHesabatArxivi";
            btnZHesabatArxivi.NoAccentTextColor = Color.Empty;
            btnZHesabatArxivi.Size = new Size(240, 45);
            btnZHesabatArxivi.TabIndex = 9;
            btnZHesabatArxivi.Text = "Z-Hesabat Arxivi";
            btnZHesabatArxivi.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            btnZHesabatArxivi.UseAccentColor = false;
            btnZHesabatArxivi.UseVisualStyleBackColor = false;
            btnZHesabatArxivi.Click += btnZHesabatArxivi_Click;
            // 
            // btnAnbarQaliqHesabati
            // 
            btnAnbarQaliqHesabati.AutoSize = false;
            btnAnbarQaliqHesabati.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAnbarQaliqHesabati.BackColor = Color.FromArgb(242, 242, 242);
            btnAnbarQaliqHesabati.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnAnbarQaliqHesabati.Depth = 0;
            btnAnbarQaliqHesabati.Dock = DockStyle.Top;
            btnAnbarQaliqHesabati.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnAnbarQaliqHesabati.HighEmphasis = false;
            btnAnbarQaliqHesabati.Icon = null;
            btnAnbarQaliqHesabati.ImageAlign = ContentAlignment.MiddleLeft;
            btnAnbarQaliqHesabati.ImageList = sidebarImageList;
            btnAnbarQaliqHesabati.Location = new Point(0, 436);
            btnAnbarQaliqHesabati.Margin = new Padding(4, 6, 4, 6);
            btnAnbarQaliqHesabati.MouseState = MaterialSkin.MouseState.HOVER;
            btnAnbarQaliqHesabati.Name = "btnAnbarQaliqHesabati";
            btnAnbarQaliqHesabati.NoAccentTextColor = Color.Empty;
            btnAnbarQaliqHesabati.Size = new Size(240, 45);
            btnAnbarQaliqHesabati.TabIndex = 8;
            btnAnbarQaliqHesabati.Text = "Anbar Qalığı";
            btnAnbarQaliqHesabati.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            btnAnbarQaliqHesabati.UseAccentColor = false;
            btnAnbarQaliqHesabati.UseVisualStyleBackColor = false;
            // 
            // btnMehsulSatisHesabati
            // 
            btnMehsulSatisHesabati.AutoSize = false;
            btnMehsulSatisHesabati.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnMehsulSatisHesabati.BackColor = Color.FromArgb(242, 242, 242);
            btnMehsulSatisHesabati.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnMehsulSatisHesabati.Depth = 0;
            btnMehsulSatisHesabati.Dock = DockStyle.Top;
            btnMehsulSatisHesabati.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnMehsulSatisHesabati.HighEmphasis = false;
            btnMehsulSatisHesabati.Icon = null;
            btnMehsulSatisHesabati.ImageAlign = ContentAlignment.MiddleLeft;
            btnMehsulSatisHesabati.ImageList = sidebarImageList;
            btnMehsulSatisHesabati.Location = new Point(0, 391);
            btnMehsulSatisHesabati.Margin = new Padding(4, 6, 4, 6);
            btnMehsulSatisHesabati.MouseState = MaterialSkin.MouseState.HOVER;
            btnMehsulSatisHesabati.Name = "btnMehsulSatisHesabati";
            btnMehsulSatisHesabati.NoAccentTextColor = Color.Empty;
            btnMehsulSatisHesabati.Size = new Size(240, 45);
            btnMehsulSatisHesabati.TabIndex = 7;
            btnMehsulSatisHesabati.Text = "Məhsul Hesabatı";
            btnMehsulSatisHesabati.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            btnMehsulSatisHesabati.UseAccentColor = false;
            btnMehsulSatisHesabati.UseVisualStyleBackColor = false;
            btnMehsulSatisHesabati.Click += btnMehsulSatisHesabati_Click;
            // 
            // btnHesabatlar
            // 
            btnHesabatlar.AutoSize = false;
            btnHesabatlar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnHesabatlar.BackColor = Color.FromArgb(242, 242, 242);
            btnHesabatlar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnHesabatlar.Depth = 0;
            btnHesabatlar.Dock = DockStyle.Top;
            btnHesabatlar.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnHesabatlar.HighEmphasis = false;
            btnHesabatlar.Icon = null;
            btnHesabatlar.ImageAlign = ContentAlignment.MiddleLeft;
            btnHesabatlar.ImageList = sidebarImageList;
            btnHesabatlar.Location = new Point(0, 346);
            btnHesabatlar.Margin = new Padding(4, 6, 4, 6);
            btnHesabatlar.MouseState = MaterialSkin.MouseState.HOVER;
            btnHesabatlar.Name = "btnHesabatlar";
            btnHesabatlar.NoAccentTextColor = Color.Empty;
            btnHesabatlar.Size = new Size(240, 45);
            btnHesabatlar.TabIndex = 6;
            btnHesabatlar.Text = "Günlük Hesabat";
            btnHesabatlar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            btnHesabatlar.UseAccentColor = false;
            btnHesabatlar.UseVisualStyleBackColor = false;
            btnHesabatlar.Click += btnHesabatlar_Click;
            // 
            // btnIstifadeciIdareetme
            // 
            btnIstifadeciIdareetme.AutoSize = false;
            btnIstifadeciIdareetme.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnIstifadeciIdareetme.BackColor = Color.FromArgb(242, 242, 242);
            btnIstifadeciIdareetme.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnIstifadeciIdareetme.Depth = 0;
            btnIstifadeciIdareetme.Dock = DockStyle.Top;
            btnIstifadeciIdareetme.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnIstifadeciIdareetme.HighEmphasis = false;
            btnIstifadeciIdareetme.Icon = null;
            btnIstifadeciIdareetme.ImageAlign = ContentAlignment.MiddleLeft;
            btnIstifadeciIdareetme.ImageList = sidebarImageList;
            btnIstifadeciIdareetme.Location = new Point(0, 301);
            btnIstifadeciIdareetme.Margin = new Padding(4, 6, 4, 6);
            btnIstifadeciIdareetme.MouseState = MaterialSkin.MouseState.HOVER;
            btnIstifadeciIdareetme.Name = "btnIstifadeciIdareetme";
            btnIstifadeciIdareetme.NoAccentTextColor = Color.Empty;
            btnIstifadeciIdareetme.Size = new Size(240, 45);
            btnIstifadeciIdareetme.TabIndex = 0;
            btnIstifadeciIdareetme.Text = "İstifadəçilər";
            btnIstifadeciIdareetme.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            btnIstifadeciIdareetme.UseAccentColor = false;
            btnIstifadeciIdareetme.UseVisualStyleBackColor = false;
            btnIstifadeciIdareetme.Click += btnIstifadeciIdareetme_Click;
            // 
            // separator1
            // 
            separator1.BackColor = Color.FromArgb(242, 242, 242);
            separator1.Dock = DockStyle.Top;
            separator1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            separator1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            separator1.Location = new Point(0, 300);
            separator1.Name = "separator1";
            separator1.Size = new Size(240, 1);
            separator1.TabIndex = 11;
            // 
            // btnTemirIdareetme
            // 
            btnTemirIdareetme.AutoSize = false;
            btnTemirIdareetme.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnTemirIdareetme.BackColor = Color.FromArgb(242, 242, 242);
            btnTemirIdareetme.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnTemirIdareetme.Depth = 0;
            btnTemirIdareetme.Dock = DockStyle.Top;
            btnTemirIdareetme.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnTemirIdareetme.HighEmphasis = false;
            btnTemirIdareetme.Icon = null;
            btnTemirIdareetme.ImageAlign = ContentAlignment.MiddleLeft;
            btnTemirIdareetme.ImageList = sidebarImageList;
            btnTemirIdareetme.Location = new Point(0, 255);
            btnTemirIdareetme.Margin = new Padding(4, 6, 4, 6);
            btnTemirIdareetme.MouseState = MaterialSkin.MouseState.HOVER;
            btnTemirIdareetme.Name = "btnTemirIdareetme";
            btnTemirIdareetme.NoAccentTextColor = Color.Empty;
            btnTemirIdareetme.Size = new Size(240, 45);
            btnTemirIdareetme.TabIndex = 1;
            btnTemirIdareetme.Text = "Təmir";
            btnTemirIdareetme.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            btnTemirIdareetme.UseAccentColor = false;
            btnTemirIdareetme.UseVisualStyleBackColor = false;
            btnTemirIdareetme.Click += btnTemirIdareetme_Click;
            // 
            // btnNisyeIdareetme
            // 
            btnNisyeIdareetme.AutoSize = false;
            btnNisyeIdareetme.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnNisyeIdareetme.BackColor = Color.FromArgb(242, 242, 242);
            btnNisyeIdareetme.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnNisyeIdareetme.Depth = 0;
            btnNisyeIdareetme.Dock = DockStyle.Top;
            btnNisyeIdareetme.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnNisyeIdareetme.HighEmphasis = false;
            btnNisyeIdareetme.Icon = null;
            btnNisyeIdareetme.ImageAlign = ContentAlignment.MiddleLeft;
            btnNisyeIdareetme.ImageList = sidebarImageList;
            btnNisyeIdareetme.Location = new Point(0, 210);
            btnNisyeIdareetme.Margin = new Padding(4, 6, 4, 6);
            btnNisyeIdareetme.MouseState = MaterialSkin.MouseState.HOVER;
            btnNisyeIdareetme.Name = "btnNisyeIdareetme";
            btnNisyeIdareetme.NoAccentTextColor = Color.Empty;
            btnNisyeIdareetme.Size = new Size(240, 45);
            btnNisyeIdareetme.TabIndex = 2;
            btnNisyeIdareetme.Text = "Nisyə / Borc";
            btnNisyeIdareetme.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            btnNisyeIdareetme.UseAccentColor = false;
            btnNisyeIdareetme.UseVisualStyleBackColor = false;
            btnNisyeIdareetme.Click += btnNisyeIdareetme_Click;
            // 
            // btnYeniSatis
            // 
            btnYeniSatis.AutoSize = false;
            btnYeniSatis.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnYeniSatis.BackColor = Color.FromArgb(242, 242, 242);
            btnYeniSatis.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnYeniSatis.Depth = 0;
            btnYeniSatis.Dock = DockStyle.Top;
            btnYeniSatis.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnYeniSatis.HighEmphasis = false;
            btnYeniSatis.Icon = null;
            btnYeniSatis.ImageAlign = ContentAlignment.MiddleLeft;
            btnYeniSatis.ImageList = sidebarImageList;
            btnYeniSatis.Location = new Point(0, 165);
            btnYeniSatis.Margin = new Padding(4, 6, 4, 6);
            btnYeniSatis.MouseState = MaterialSkin.MouseState.HOVER;
            btnYeniSatis.Name = "btnYeniSatis";
            btnYeniSatis.NoAccentTextColor = Color.Empty;
            btnYeniSatis.Size = new Size(240, 45);
            btnYeniSatis.TabIndex = 4;
            btnYeniSatis.Text = "Yeni Satış";
            btnYeniSatis.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            btnYeniSatis.UseAccentColor = false;
            btnYeniSatis.UseVisualStyleBackColor = false;
            btnYeniSatis.Click += btnYeniSatis_Click;
            // 
            // btnMehsulIdareetme
            // 
            btnMehsulIdareetme.AutoSize = false;
            btnMehsulIdareetme.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnMehsulIdareetme.BackColor = Color.FromArgb(242, 242, 242);
            btnMehsulIdareetme.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnMehsulIdareetme.Depth = 0;
            btnMehsulIdareetme.Dock = DockStyle.Top;
            btnMehsulIdareetme.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnMehsulIdareetme.HighEmphasis = false;
            btnMehsulIdareetme.Icon = null;
            btnMehsulIdareetme.ImageAlign = ContentAlignment.MiddleLeft;
            btnMehsulIdareetme.ImageList = sidebarImageList;
            btnMehsulIdareetme.Location = new Point(0, 120);
            btnMehsulIdareetme.Margin = new Padding(4, 6, 4, 6);
            btnMehsulIdareetme.MouseState = MaterialSkin.MouseState.HOVER;
            btnMehsulIdareetme.Name = "btnMehsulIdareetme";
            btnMehsulIdareetme.NoAccentTextColor = Color.Empty;
            btnMehsulIdareetme.Size = new Size(240, 45);
            btnMehsulIdareetme.TabIndex = 3;
            btnMehsulIdareetme.Text = "Məhsullar";
            btnMehsulIdareetme.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            btnMehsulIdareetme.UseAccentColor = false;
            btnMehsulIdareetme.UseVisualStyleBackColor = false;
            btnMehsulIdareetme.Click += btnMehsulIdareetme_Click;
            // 
            // btnNovbeIdareetme
            // 
            btnNovbeIdareetme.AutoSize = false;
            btnNovbeIdareetme.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnNovbeIdareetme.BackColor = Color.FromArgb(242, 242, 242);
            btnNovbeIdareetme.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnNovbeIdareetme.Depth = 0;
            btnNovbeIdareetme.Dock = DockStyle.Top;
            btnNovbeIdareetme.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnNovbeIdareetme.HighEmphasis = true;
            btnNovbeIdareetme.Icon = null;
            btnNovbeIdareetme.ImageAlign = ContentAlignment.MiddleLeft;
            btnNovbeIdareetme.ImageList = sidebarImageList;
            btnNovbeIdareetme.Location = new Point(0, 75);
            btnNovbeIdareetme.Margin = new Padding(4, 6, 4, 6);
            btnNovbeIdareetme.MouseState = MaterialSkin.MouseState.HOVER;
            btnNovbeIdareetme.Name = "btnNovbeIdareetme";
            btnNovbeIdareetme.NoAccentTextColor = Color.Empty;
            btnNovbeIdareetme.Size = new Size(240, 45);
            btnNovbeIdareetme.TabIndex = 5;
            btnNovbeIdareetme.Text = "Növbəni İdarə Et";
            btnNovbeIdareetme.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnNovbeIdareetme.UseAccentColor = true;
            btnNovbeIdareetme.UseVisualStyleBackColor = false;
            btnNovbeIdareetme.Click += btnNovbeIdareetme_Click;
            // 
            // pnlUserInfo
            // 
            pnlUserInfo.BackColor = Color.FromArgb(242, 242, 242);
            pnlUserInfo.Controls.Add(lblUserName);
            pnlUserInfo.Controls.Add(picUserIcon);
            pnlUserInfo.Dock = DockStyle.Top;
            pnlUserInfo.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlUserInfo.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlUserInfo.Location = new Point(0, 0);
            pnlUserInfo.Name = "pnlUserInfo";
            pnlUserInfo.Size = new Size(240, 75);
            pnlUserInfo.TabIndex = 0;
            // 
            // lblUserName
            // 
            lblUserName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblUserName.BackColor = Color.FromArgb(242, 242, 242);
            lblUserName.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblUserName.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblUserName.Location = new Point(74, 28);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(163, 23);
            lblUserName.TabIndex = 1;
            lblUserName.Text = "İstifadəçi Adı";
            // 
            // picUserIcon
            // 
            picUserIcon.BackColor = Color.FromArgb(242, 242, 242);
            picUserIcon.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            picUserIcon.ForeColor = Color.FromArgb(222, 0, 0, 0);
            picUserIcon.Location = new Point(12, 12);
            picUserIcon.Name = "picUserIcon";
            picUserIcon.Size = new Size(50, 50);
            picUserIcon.SizeMode = PictureBoxSizeMode.Zoom;
            picUserIcon.TabIndex = 0;
            picUserIcon.TabStop = false;
            // 
            // mdiTabControl
            // 
            mdiTabControl.Depth = 0;
            mdiTabControl.Dock = DockStyle.Fill;
            mdiTabControl.ForeColor = Color.FromArgb(222, 0, 0, 0);
            mdiTabControl.Location = new Point(243, 64);
            mdiTabControl.MouseState = MaterialSkin.MouseState.HOVER;
            mdiTabControl.Multiline = true;
            mdiTabControl.Name = "mdiTabControl";
            mdiTabControl.SelectedIndex = 0;
            mdiTabControl.Size = new Size(954, 673);
            mdiTabControl.TabIndex = 2;
            mdiTabControl.SelectedIndexChanged += mdiTabControl_SelectedIndexChanged;
            mdiTabControl.MouseClick += mdiTabControl_MouseClick;
            // 
            // tabContextMenu
            // 
            tabContextMenu.BackColor = Color.FromArgb(255, 255, 255);
            tabContextMenu.Depth = 0;
            tabContextMenu.Items.AddRange(new ToolStripItem[] { baglaToolStripMenuItem, toolStripSeparator1, hamisiniBaglaToolStripMenuItem });
            tabContextMenu.MouseState = MaterialSkin.MouseState.HOVER;
            tabContextMenu.Name = "tabContextMenu";
            tabContextMenu.Size = new Size(154, 54);
            // 
            // baglaToolStripMenuItem
            // 
            baglaToolStripMenuItem.Name = "baglaToolStripMenuItem";
            baglaToolStripMenuItem.Size = new Size(153, 22);
            baglaToolStripMenuItem.Text = "Bağla";
            baglaToolStripMenuItem.Click += baglaToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(150, 6);
            // 
            // hamisiniBaglaToolStripMenuItem
            // 
            hamisiniBaglaToolStripMenuItem.Name = "hamisiniBaglaToolStripMenuItem";
            hamisiniBaglaToolStripMenuItem.Size = new Size(153, 22);
            hamisiniBaglaToolStripMenuItem.Text = "Hamısını Bağla";
            hamisiniBaglaToolStripMenuItem.Click += hamisiniBaglaToolStripMenuItem_Click;
            // 
            // AnaMenuFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 740);
            Controls.Add(mdiTabControl);
            Controls.Add(pnlMenu);
            DrawerShowIconsWhenHidden = true;
            Name = "AnaMenuFormu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AzAgroPOS - Ana Menyu";
            WindowState = FormWindowState.Maximized;
            pnlMenu.ResumeLayout(false);
            pnlMenu.PerformLayout();
            pnlUserInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picUserIcon).EndInit();
            tabContextMenu.ResumeLayout(false);
            ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Panel pnlMenu;
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
        private MaterialSkin.Controls.MaterialButton btnIsciIdareetme;
        private MaterialSkin.Controls.MaterialTabControl mdiTabControl;
        private MaterialSkin.Controls.MaterialContextMenuStrip tabContextMenu;
        private System.Windows.Forms.ToolStripMenuItem baglaToolStripMenuItem;
        private System.Windows.Forms.Panel pnlUserInfo;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.PictureBox picUserIcon;
        private System.Windows.Forms.Panel separator2;
        private System.Windows.Forms.Panel separator1;
        private System.Windows.Forms.ImageList sidebarImageList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem hamisiniBaglaToolStripMenuItem;
    }
}