namespace AzAgroPOS.Teqdimat
{
    partial class AnaMenuFormu
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
            sidebarImageList = new ImageList(components);
            pnlMenu = new Panel();
            btnMinimumStokMehsullari = new MaterialSkin.Controls.MaterialButton();
            btnIsciIdareetme = new MaterialSkin.Controls.MaterialButton();
            btnBarkodCapi = new MaterialSkin.Controls.MaterialButton();
            btnZHesabatArxivi = new MaterialSkin.Controls.MaterialButton();
            btnAnbarQaliqHesabati = new MaterialSkin.Controls.MaterialButton();
            btnMehsulSatisHesabati = new MaterialSkin.Controls.MaterialButton();
            btnHesabatlar = new MaterialSkin.Controls.MaterialButton();
            btnIstifadeciIdareetme = new MaterialSkin.Controls.MaterialButton();
            btnTemirIdareetme = new MaterialSkin.Controls.MaterialButton();
            btnNisyeIdareetme = new MaterialSkin.Controls.MaterialButton();
            btnQaytarma = new MaterialSkin.Controls.MaterialButton();
            btnYeniSatis = new MaterialSkin.Controls.MaterialButton();
            btnMehsulIdareetme = new MaterialSkin.Controls.MaterialButton();
            btnNovbeIdareetme = new MaterialSkin.Controls.MaterialButton();
            btnKonfiqurasiya = new MaterialSkin.Controls.MaterialButton(); // Əlavə edildi
            separator2 = new Panel();
            separator1 = new Panel();
            pnlUserInfo = new Panel();
            lblUserName = new Label();
            picUserIcon = new PictureBox();
            mdiTabControl = new MaterialSkin.Controls.MaterialTabControl();
            tabContextMenu = new MaterialSkin.Controls.MaterialContextMenuStrip();
            baglaToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            hamisiniBaglaToolStripMenuItem = new ToolStripMenuItem();
            dashboardPanel = new Panel();
            dailySalesCard = new MaterialSkin.Controls.MaterialCard();
            activeShiftCard = new MaterialSkin.Controls.MaterialCard();
            debtorCustomersCard = new MaterialSkin.Controls.MaterialCard();
            lowStockProductsCard = new MaterialSkin.Controls.MaterialCard();
            lblDailySales = new Label();
            lblActiveShift = new Label();
            lblDebtorCustomers = new Label();
            lblLowStockProducts = new Label();
            lblDailySalesValue = new Label();
            lblActiveShiftValue = new Label();
            lblDebtorCustomersValue = new Label();
            lblLowStockProductsValue = new Label();
            dashboardTimer = new System.Windows.Forms.Timer(components);
            pnlMenu.SuspendLayout();
            dashboardPanel.SuspendLayout();
            dailySalesCard.SuspendLayout();
            activeShiftCard.SuspendLayout();
            debtorCustomersCard.SuspendLayout();
            lowStockProductsCard.SuspendLayout();
            pnlUserInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picUserIcon).BeginInit();
            tabContextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // sidebarImageList
            // 
            sidebarImageList.ColorDepth = ColorDepth.Depth32Bit;
            sidebarImageList.ImageSize = new Size(16, 16);
            sidebarImageList.TransparentColor = Color.Transparent;
            // 
            // settings.png image
            // 
            // Note: You'll need to add the actual image resource to your project
            // For now, we're just setting up the image list structure
            // 
            // pnlMenu
            // 
            pnlMenu.AutoScroll = true;
            pnlMenu.BackColor = Color.FromArgb(242, 242, 242);
            pnlMenu.Controls.Add(btnMinimumStokMehsullari);
            pnlMenu.Controls.Add(btnIsciIdareetme);
            pnlMenu.Controls.Add(btnBarkodCapi);
            pnlMenu.Controls.Add(btnZHesabatArxivi);
            pnlMenu.Controls.Add(btnAnbarQaliqHesabati);
            pnlMenu.Controls.Add(btnMehsulSatisHesabati);
            pnlMenu.Controls.Add(btnHesabatlar);
            pnlMenu.Controls.Add(btnIstifadeciIdareetme);
            pnlMenu.Controls.Add(btnTemirIdareetme);
            pnlMenu.Controls.Add(btnNisyeIdareetme);
            pnlMenu.Controls.Add(btnQaytarma);
            pnlMenu.Controls.Add(btnYeniSatis);
            pnlMenu.Controls.Add(btnMehsulIdareetme);
            pnlMenu.Controls.Add(btnNovbeIdareetme);
            pnlMenu.Controls.Add(btnKonfiqurasiya);
            pnlMenu.Controls.Add(separator2);
            pnlMenu.Controls.Add(separator1);
            pnlMenu.Controls.Add(pnlUserInfo);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlMenu.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlMenu.Location = new Point(3, 64);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(240, 673);
            pnlMenu.TabIndex = 0;
            // 
            // btnKonfiqurasiya
            // 
            btnKonfiqurasiya.AutoSize = false;
            btnKonfiqurasiya.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnKonfiqurasiya.BackColor = Color.FromArgb(242, 242, 242);
            btnKonfiqurasiya.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnKonfiqurasiya.Depth = 0;
            btnKonfiqurasiya.Dock = DockStyle.Top;
            btnKonfiqurasiya.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnKonfiqurasiya.HighEmphasis = false;
            btnKonfiqurasiya.Icon = null;
            btnKonfiqurasiya.ImageAlign = ContentAlignment.MiddleLeft;
            btnKonfiqurasiya.ImageKey = "settings.png";
            btnKonfiqurasiya.ImageList = sidebarImageList;
            btnKonfiqurasiya.Location = new Point(0, 660);
            btnKonfiqurasiya.Margin = new Padding(4, 6, 4, 6);
            btnKonfiqurasiya.MouseState = MaterialSkin.MouseState.HOVER;
            btnKonfiqurasiya.Name = "btnKonfiqurasiya";
            btnKonfiqurasiya.NoAccentTextColor = Color.Empty;
            btnKonfiqurasiya.Size = new Size(240, 45);
            btnKonfiqurasiya.TabIndex = 17;
            btnKonfiqurasiya.Text = "Konfiqurasiya";
            btnKonfiqurasiya.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            btnKonfiqurasiya.UseAccentColor = false;
            btnKonfiqurasiya.UseVisualStyleBackColor = false;
            btnKonfiqurasiya.Click += btnKonfiqurasiya_Click;
            // 
            // btnMinimumStokMehsullari
            // 
            btnMinimumStokMehsullari.AutoSize = false;
            btnMinimumStokMehsullari.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnMinimumStokMehsullari.BackColor = Color.FromArgb(242, 242, 242);
            btnMinimumStokMehsullari.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnMinimumStokMehsullari.Depth = 0;
            btnMinimumStokMehsullari.Dock = DockStyle.Top;
            btnMinimumStokMehsullari.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnMinimumStokMehsullari.HighEmphasis = false;
            btnMinimumStokMehsullari.Icon = null;
            btnMinimumStokMehsullari.ImageAlign = ContentAlignment.MiddleLeft;
            btnMinimumStokMehsullari.ImageList = sidebarImageList;
            btnMinimumStokMehsullari.Location = new Point(0, 705);
            btnMinimumStokMehsullari.Margin = new Padding(4, 6, 4, 6);
            btnMinimumStokMehsullari.MouseState = MaterialSkin.MouseState.HOVER;
            btnMinimumStokMehsullari.Name = "btnMinimumStokMehsullari";
            btnMinimumStokMehsullari.NoAccentTextColor = Color.Empty;
            btnMinimumStokMehsullari.Size = new Size(240, 45);
            btnMinimumStokMehsullari.TabIndex = 18;
            btnMinimumStokMehsullari.Text = "Minimum Stok Məhsulları";
            btnMinimumStokMehsullari.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            btnMinimumStokMehsullari.UseAccentColor = false;
            btnMinimumStokMehsullari.UseVisualStyleBackColor = false;
            btnMinimumStokMehsullari.Click += btnMinimumStokMehsullari_Click;
            // 
            // btnIsciIdareetme
            // 
            btnIsciIdareetme.AutoSize = false;
            btnIsciIdareetme.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnIsciIdareetme.BackColor = Color.FromArgb(242, 242, 242);
            btnIsciIdareetme.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnIsciIdareetme.Depth = 0;
            btnIsciIdareetme.Dock = DockStyle.Top;
            btnIsciIdareetme.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnIsciIdareetme.HighEmphasis = false;
            btnIsciIdareetme.Icon = null;
            btnIsciIdareetme.ImageAlign = ContentAlignment.MiddleLeft;
            btnIsciIdareetme.ImageKey = "employee.png";
            btnIsciIdareetme.ImageList = sidebarImageList;
            btnIsciIdareetme.Location = new Point(0, 615);
            btnIsciIdareetme.Margin = new Padding(4, 6, 4, 6);
            btnIsciIdareetme.MouseState = MaterialSkin.MouseState.HOVER;
            btnIsciIdareetme.Name = "btnIsciIdareetme";
            btnIsciIdareetme.NoAccentTextColor = Color.Empty;
            btnIsciIdareetme.Size = new Size(240, 45);
            btnIsciIdareetme.TabIndex = 16;
            btnIsciIdareetme.Text = "İşçi İdarəetmə";
            btnIsciIdareetme.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            btnIsciIdareetme.UseAccentColor = false;
            btnIsciIdareetme.UseVisualStyleBackColor = false;
            btnIsciIdareetme.Click += btnIsciIdareetme_Click;
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
            btnBarkodCapi.ImageKey = "barcode.png";
            btnBarkodCapi.ImageList = sidebarImageList;
            btnBarkodCapi.Location = new Point(0, 570);
            btnBarkodCapi.Margin = new Padding(4, 6, 4, 6);
            btnBarkodCapi.MouseState = MaterialSkin.MouseState.HOVER;
            btnBarkodCapi.Name = "btnBarkodCapi";
            btnBarkodCapi.NoAccentTextColor = Color.Empty;
            btnBarkodCapi.Size = new Size(240, 45);
            btnBarkodCapi.TabIndex = 15;
            btnBarkodCapi.Text = "Barkod Çapı";
            btnBarkodCapi.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            btnBarkodCapi.UseAccentColor = false;
            btnBarkodCapi.UseVisualStyleBackColor = false;
            btnBarkodCapi.Click += btnBarkodCapi_Click;
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
            btnZHesabatArxivi.Location = new Point(0, 525);
            btnZHesabatArxivi.Margin = new Padding(4, 6, 4, 6);
            btnZHesabatArxivi.MouseState = MaterialSkin.MouseState.HOVER;
            btnZHesabatArxivi.Name = "btnZHesabatArxivi";
            btnZHesabatArxivi.NoAccentTextColor = Color.Empty;
            btnZHesabatArxivi.Size = new Size(240, 45);
            btnZHesabatArxivi.TabIndex = 14;
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
            btnAnbarQaliqHesabati.Location = new Point(0, 480);
            btnAnbarQaliqHesabati.Margin = new Padding(4, 6, 4, 6);
            btnAnbarQaliqHesabati.MouseState = MaterialSkin.MouseState.HOVER;
            btnAnbarQaliqHesabati.Name = "btnAnbarQaliqHesabati";
            btnAnbarQaliqHesabati.NoAccentTextColor = Color.Empty;
            btnAnbarQaliqHesabati.Size = new Size(240, 45);
            btnAnbarQaliqHesabati.TabIndex = 13;
            btnAnbarQaliqHesabati.Text = "Anbar Qalıq Hesabatı";
            btnAnbarQaliqHesabati.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            btnAnbarQaliqHesabati.UseAccentColor = false;
            btnAnbarQaliqHesabati.UseVisualStyleBackColor = false;
            btnAnbarQaliqHesabati.Click += btnAnbarQaliqHesabati_Click;
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
            btnMehsulSatisHesabati.Location = new Point(0, 435);
            btnMehsulSatisHesabati.Margin = new Padding(4, 6, 4, 6);
            btnMehsulSatisHesabati.MouseState = MaterialSkin.MouseState.HOVER;
            btnMehsulSatisHesabati.Name = "btnMehsulSatisHesabati";
            btnMehsulSatisHesabati.NoAccentTextColor = Color.Empty;
            btnMehsulSatisHesabati.Size = new Size(240, 45);
            btnMehsulSatisHesabati.TabIndex = 12;
            btnMehsulSatisHesabati.Text = "Məhsul Satış Hesabatı";
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
            btnHesabatlar.ImageKey = "report.png";
            btnHesabatlar.ImageList = sidebarImageList;
            btnHesabatlar.Location = new Point(0, 390);
            btnHesabatlar.Margin = new Padding(4, 6, 4, 6);
            btnHesabatlar.MouseState = MaterialSkin.MouseState.HOVER;
            btnHesabatlar.Name = "btnHesabatlar";
            btnHesabatlar.NoAccentTextColor = Color.Empty;
            btnHesabatlar.Size = new Size(240, 45);
            btnHesabatlar.TabIndex = 11;
            btnHesabatlar.Text = "Hesabatlar";
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
            btnIstifadeciIdareetme.ImageKey = "user.png";
            btnIstifadeciIdareetme.ImageList = sidebarImageList;
            btnIstifadeciIdareetme.Location = new Point(0, 345);
            btnIstifadeciIdareetme.Margin = new Padding(4, 6, 4, 6);
            btnIstifadeciIdareetme.MouseState = MaterialSkin.MouseState.HOVER;
            btnIstifadeciIdareetme.Name = "btnIstifadeciIdareetme";
            btnIstifadeciIdareetme.NoAccentTextColor = Color.Empty;
            btnIstifadeciIdareetme.Size = new Size(240, 45);
            btnIstifadeciIdareetme.TabIndex = 10;
            btnIstifadeciIdareetme.Text = "İstifadəçi İdarəetmə";
            btnIstifadeciIdareetme.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            btnIstifadeciIdareetme.UseAccentColor = false;
            btnIstifadeciIdareetme.UseVisualStyleBackColor = false;
            btnIstifadeciIdareetme.Click += btnIstifadeciIdareetme_Click;
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
            btnTemirIdareetme.ImageKey = "repair.png";
            btnTemirIdareetme.ImageList = sidebarImageList;
            btnTemirIdareetme.Location = new Point(0, 300);
            btnTemirIdareetme.Margin = new Padding(4, 6, 4, 6);
            btnTemirIdareetme.MouseState = MaterialSkin.MouseState.HOVER;
            btnTemirIdareetme.Name = "btnTemirIdareetme";
            btnTemirIdareetme.NoAccentTextColor = Color.Empty;
            btnTemirIdareetme.Size = new Size(240, 45);
            btnTemirIdareetme.TabIndex = 9;
            btnTemirIdareetme.Text = "Təmir İdarəetmə";
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
            btnNisyeIdareetme.Location = new Point(0, 255);
            btnNisyeIdareetme.Margin = new Padding(4, 6, 4, 6);
            btnNisyeIdareetme.MouseState = MaterialSkin.MouseState.HOVER;
            btnNisyeIdareetme.Name = "btnNisyeIdareetme";
            btnNisyeIdareetme.NoAccentTextColor = Color.Empty;
            btnNisyeIdareetme.Size = new Size(240, 45);
            btnNisyeIdareetme.TabIndex = 8;
            btnNisyeIdareetme.Text = "Nisyə İdarəetmə";
            btnNisyeIdareetme.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            btnNisyeIdareetme.UseAccentColor = false;
            btnNisyeIdareetme.UseVisualStyleBackColor = false;
            btnNisyeIdareetme.Click += btnNisyeIdareetme_Click;
            // 
            // btnQaytarma
            // 
            btnQaytarma.AutoSize = false;
            btnQaytarma.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnQaytarma.BackColor = Color.FromArgb(242, 242, 242);
            btnQaytarma.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnQaytarma.Depth = 0;
            btnQaytarma.Dock = DockStyle.Top;
            btnQaytarma.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnQaytarma.HighEmphasis = false;
            btnQaytarma.Icon = null;
            btnQaytarma.ImageAlign = ContentAlignment.MiddleLeft;
            btnQaytarma.ImageList = sidebarImageList;
            btnQaytarma.Location = new Point(0, 210);
            btnQaytarma.Margin = new Padding(4, 6, 4, 6);
            btnQaytarma.MouseState = MaterialSkin.MouseState.HOVER;
            btnQaytarma.Name = "btnQaytarma";
            btnQaytarma.NoAccentTextColor = Color.Empty;
            btnQaytarma.Size = new Size(240, 45);
            btnQaytarma.TabIndex = 19;
            btnQaytarma.Text = "Qaytarma";
            btnQaytarma.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            btnQaytarma.UseAccentColor = false;
            btnQaytarma.UseVisualStyleBackColor = false;
            btnQaytarma.Click += btnQaytarma_Click;
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
            btnYeniSatis.ImageKey = "sale.png";
            btnYeniSatis.ImageList = sidebarImageList;
            btnYeniSatis.Location = new Point(0, 165);
            btnYeniSatis.Margin = new Padding(4, 6, 4, 6);
            btnYeniSatis.MouseState = MaterialSkin.MouseState.HOVER;
            btnYeniSatis.Name = "btnYeniSatis";
            btnYeniSatis.NoAccentTextColor = Color.Empty;
            btnYeniSatis.Size = new Size(240, 45);
            btnYeniSatis.TabIndex = 7;
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
            btnMehsulIdareetme.ImageKey = "product.png";
            btnMehsulIdareetme.ImageList = sidebarImageList;
            btnMehsulIdareetme.Location = new Point(0, 120);
            btnMehsulIdareetme.Margin = new Padding(4, 6, 4, 6);
            btnMehsulIdareetme.MouseState = MaterialSkin.MouseState.HOVER;
            btnMehsulIdareetme.Name = "btnMehsulIdareetme";
            btnMehsulIdareetme.NoAccentTextColor = Color.Empty;
            btnMehsulIdareetme.Size = new Size(240, 45);
            btnMehsulIdareetme.TabIndex = 6;
            btnMehsulIdareetme.Text = "Məhsul İdarəetmə";
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
            btnNovbeIdareetme.HighEmphasis = false;
            btnNovbeIdareetme.Icon = null;
            btnNovbeIdareetme.ImageAlign = ContentAlignment.MiddleLeft;
            btnNovbeIdareetme.ImageKey = "shift.png";
            btnNovbeIdareetme.ImageList = sidebarImageList;
            btnNovbeIdareetme.Location = new Point(0, 75);
            btnNovbeIdareetme.Margin = new Padding(4, 6, 4, 6);
            btnNovbeIdareetme.MouseState = MaterialSkin.MouseState.HOVER;
            btnNovbeIdareetme.Name = "btnNovbeIdareetme";
            btnNovbeIdareetme.NoAccentTextColor = Color.Empty;
            btnNovbeIdareetme.Size = new Size(240, 45);
            btnNovbeIdareetme.TabIndex = 5;
            btnNovbeIdareetme.Text = "Növbə İdarəetmə";
            btnNovbeIdareetme.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            btnNovbeIdareetme.UseAccentColor = false;
            btnNovbeIdareetme.UseVisualStyleBackColor = false;
            btnNovbeIdareetme.Click += btnNovbeIdareetme_Click;
            // 
            // separator2
            // 
            separator2.BackColor = Color.FromArgb(242, 242, 242);
            separator2.Dock = DockStyle.Top;
            separator2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            separator2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            separator2.Location = new Point(0, 25);
            separator2.Name = "separator2";
            separator2.Size = new Size(240, 5);
            separator2.TabIndex = 2;
            // 
            // separator1
            // 
            separator1.BackColor = Color.FromArgb(242, 242, 242);
            separator1.Dock = DockStyle.Top;
            separator1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            separator1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            separator1.Location = new Point(0, 20);
            separator1.Name = "separator1";
            separator1.Size = new Size(240, 5);
            separator1.TabIndex = 1;
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
            pnlUserInfo.Size = new Size(240, 20);
            pnlUserInfo.TabIndex = 0;
            // 
            // lblUserName
            // 
            lblUserName.BackColor = Color.FromArgb(242, 242, 242);
            lblUserName.Dock = DockStyle.Fill;
            lblUserName.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblUserName.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblUserName.Location = new Point(20, 0);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(220, 20);
            lblUserName.TabIndex = 1;
            lblUserName.Text = "İstifadəçi Adı";
            lblUserName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // picUserIcon
            // 
            picUserIcon.BackColor = Color.FromArgb(242, 242, 242);
            picUserIcon.Dock = DockStyle.Left;
            picUserIcon.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            picUserIcon.ForeColor = Color.FromArgb(222, 0, 0, 0);
            picUserIcon.Location = new Point(0, 0);
            picUserIcon.Name = "picUserIcon";
            picUserIcon.Size = new Size(20, 20);
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
            mdiTabControl.TabIndex = 1;
            mdiTabControl.SelectedIndexChanged += mdiTabControl_SelectedIndexChanged;
            mdiTabControl.MouseClick += mdiTabControl_MouseClick;
            
            // 
            // dashboardPanel
            // 
            dashboardPanel.BackColor = Color.FromArgb(242, 242, 242);
            dashboardPanel.Dock = DockStyle.Top;
            dashboardPanel.Location = new Point(243, 64);
            dashboardPanel.Name = "dashboardPanel";
            dashboardPanel.Size = new Size(954, 150);
            dashboardPanel.TabIndex = 2;
            
            // 
            // dailySalesCard
            // 
            dailySalesCard.BackColor = Color.FromArgb(255, 255, 255);
            dailySalesCard.Depth = 0;
            dailySalesCard.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dailySalesCard.Location = new Point(10, 10);
            dailySalesCard.Margin = new Padding(14);
            dailySalesCard.MouseState = MaterialSkin.MouseState.HOVER;
            dailySalesCard.Name = "dailySalesCard";
            dailySalesCard.Padding = new Padding(14);
            dailySalesCard.Size = new Size(220, 130);
            dailySalesCard.TabIndex = 0;
            
            // 
            // activeShiftCard
            // 
            activeShiftCard.BackColor = Color.FromArgb(255, 255, 255);
            activeShiftCard.Depth = 0;
            activeShiftCard.ForeColor = Color.FromArgb(222, 0, 0, 0);
            activeShiftCard.Location = new Point(250, 10);
            activeShiftCard.Margin = new Padding(14);
            activeShiftCard.MouseState = MaterialSkin.MouseState.HOVER;
            activeShiftCard.Name = "activeShiftCard";
            activeShiftCard.Padding = new Padding(14);
            activeShiftCard.Size = new Size(220, 130);
            activeShiftCard.TabIndex = 1;
            
            // 
            // debtorCustomersCard
            // 
            debtorCustomersCard.BackColor = Color.FromArgb(255, 255, 255);
            debtorCustomersCard.Depth = 0;
            debtorCustomersCard.ForeColor = Color.FromArgb(222, 0, 0, 0);
            debtorCustomersCard.Location = new Point(490, 10);
            debtorCustomersCard.Margin = new Padding(14);
            debtorCustomersCard.MouseState = MaterialSkin.MouseState.HOVER;
            debtorCustomersCard.Name = "debtorCustomersCard";
            debtorCustomersCard.Padding = new Padding(14);
            debtorCustomersCard.Size = new Size(220, 130);
            debtorCustomersCard.TabIndex = 2;
            
            // 
            // lowStockProductsCard
            // 
            lowStockProductsCard.BackColor = Color.FromArgb(255, 255, 255);
            lowStockProductsCard.Depth = 0;
            lowStockProductsCard.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lowStockProductsCard.Location = new Point(730, 10);
            lowStockProductsCard.Margin = new Padding(14);
            lowStockProductsCard.MouseState = MaterialSkin.MouseState.HOVER;
            lowStockProductsCard.Name = "lowStockProductsCard";
            lowStockProductsCard.Padding = new Padding(14);
            lowStockProductsCard.Size = new Size(220, 130);
            lowStockProductsCard.TabIndex = 3;
            
            // 
            // lblDailySales
            // 
            lblDailySales.AutoSize = true;
            lblDailySales.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblDailySales.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblDailySales.Location = new Point(20, 20);
            lblDailySales.Name = "lblDailySales";
            lblDailySales.Size = new Size(95, 15);
            lblDailySales.TabIndex = 0;
            lblDailySales.Text = "Günlük Satışlar";
            
            // 
            // lblActiveShift
            // 
            lblActiveShift.AutoSize = true;
            lblActiveShift.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblActiveShift.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblActiveShift.Location = new Point(20, 20);
            lblActiveShift.Name = "lblActiveShift";
            lblActiveShift.Size = new Size(85, 15);
            lblActiveShift.TabIndex = 0;
            lblActiveShift.Text = "Aktiv Növbə";
            
            // 
            // lblDebtorCustomers
            // 
            lblDebtorCustomers.AutoSize = true;
            lblDebtorCustomers.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblDebtorCustomers.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblDebtorCustomers.Location = new Point(20, 20);
            lblDebtorCustomers.Name = "lblDebtorCustomers";
            lblDebtorCustomers.Size = new Size(120, 15);
            lblDebtorCustomers.TabIndex = 0;
            lblDebtorCustomers.Text = "Borclu Müştərilər";
            
            // 
            // lblLowStockProducts
            // 
            lblLowStockProducts.AutoSize = true;
            lblLowStockProducts.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblLowStockProducts.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblLowStockProducts.Location = new Point(20, 20);
            lblLowStockProducts.Name = "lblLowStockProducts";
            lblLowStockProducts.Size = new Size(135, 15);
            lblLowStockProducts.TabIndex = 0;
            lblLowStockProducts.Text = "Aşağı Stoklu Məhsullar";
            
            // 
            // lblDailySalesValue
            // 
            lblDailySalesValue.AutoSize = true;
            lblDailySalesValue.Font = new Font("Roboto", 24F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblDailySalesValue.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblDailySalesValue.Location = new Point(20, 60);
            lblDailySalesValue.Name = "lblDailySalesValue";
            lblDailySalesValue.Size = new Size(55, 30);
            lblDailySalesValue.TabIndex = 1;
            lblDailySalesValue.Text = "0.00";
            
            // 
            // lblActiveShiftValue
            // 
            lblActiveShiftValue.AutoSize = true;
            lblActiveShiftValue.Font = new Font("Roboto", 18F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblActiveShiftValue.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblActiveShiftValue.Location = new Point(20, 60);
            lblActiveShiftValue.Name = "lblActiveShiftValue";
            lblActiveShiftValue.Size = new Size(100, 22);
            lblActiveShiftValue.TabIndex = 1;
            lblActiveShiftValue.Text = "Növbə Yoxdur";
            
            // 
            // lblDebtorCustomersValue
            // 
            lblDebtorCustomersValue.AutoSize = true;
            lblDebtorCustomersValue.Font = new Font("Roboto", 24F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblDebtorCustomersValue.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblDebtorCustomersValue.Location = new Point(20, 60);
            lblDebtorCustomersValue.Name = "lblDebtorCustomersValue";
            lblDebtorCustomersValue.Size = new Size(25, 30);
            lblDebtorCustomersValue.TabIndex = 1;
            lblDebtorCustomersValue.Text = "0";
            
            // 
            // lblLowStockProductsValue
            // 
            lblLowStockProductsValue.AutoSize = true;
            lblLowStockProductsValue.Font = new Font("Roboto", 24F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblLowStockProductsValue.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblLowStockProductsValue.Location = new Point(20, 60);
            lblLowStockProductsValue.Name = "lblLowStockProductsValue";
            lblLowStockProductsValue.Size = new Size(25, 30);
            lblLowStockProductsValue.TabIndex = 1;
            lblLowStockProductsValue.Text = "0";
            
            // 
            // Dashboard layout composition
            // 
            dailySalesCard.Controls.Add(lblDailySalesValue);
            dailySalesCard.Controls.Add(lblDailySales);
            activeShiftCard.Controls.Add(lblActiveShiftValue);
            activeShiftCard.Controls.Add(lblActiveShift);
            debtorCustomersCard.Controls.Add(lblDebtorCustomersValue);
            debtorCustomersCard.Controls.Add(lblDebtorCustomers);
            lowStockProductsCard.Controls.Add(lblLowStockProductsValue);
            lowStockProductsCard.Controls.Add(lblLowStockProducts);

            dashboardPanel.Controls.Add(lowStockProductsCard);
            dashboardPanel.Controls.Add(debtorCustomersCard);
            dashboardPanel.Controls.Add(activeShiftCard);
            dashboardPanel.Controls.Add(dailySalesCard);

            // 
            // dashboardTimer
            // 
            dashboardTimer.Interval = 300000; // 5 dəqiqə
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
            Controls.Add(dashboardPanel);
            Controls.Add(mdiTabControl);
            Controls.Add(pnlMenu);
            //DrawerShowIconsWhenHidden = true;
            Name = "AnaMenuFormu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AzAgroPOS - Ana Menyu";
            WindowState = FormWindowState.Maximized;
            FormClosing += AnaMenuFormu_FormClosing;
            Load += AnaMenuFormu_Load;
            dashboardPanel.ResumeLayout(false);
            dailySalesCard.ResumeLayout(false);
            dailySalesCard.PerformLayout();
            activeShiftCard.ResumeLayout(false);
            activeShiftCard.PerformLayout();
            debtorCustomersCard.ResumeLayout(false);
            debtorCustomersCard.PerformLayout();
            lowStockProductsCard.ResumeLayout(false);
            lowStockProductsCard.PerformLayout();
            pnlMenu.ResumeLayout(false);
            pnlUserInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picUserIcon).EndInit();
            tabContextMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMenu;
        private MaterialSkin.Controls.MaterialButton btnMinimumStokMehsullari; // Əlavə edildi
        private MaterialSkin.Controls.MaterialButton btnIsciIdareetme;
        private MaterialSkin.Controls.MaterialButton btnQaytarma;
        private MaterialSkin.Controls.MaterialButton btnBarkodCapi;
        private MaterialSkin.Controls.MaterialButton btnZHesabatArxivi;
        private MaterialSkin.Controls.MaterialButton btnAnbarQaliqHesabati;
        private MaterialSkin.Controls.MaterialButton btnMehsulSatisHesabati;
        private MaterialSkin.Controls.MaterialButton btnHesabatlar;
        private MaterialSkin.Controls.MaterialButton btnIstifadeciIdareetme;
        private MaterialSkin.Controls.MaterialButton btnTemirIdareetme;
        private MaterialSkin.Controls.MaterialButton btnNisyeIdareetme;
        private MaterialSkin.Controls.MaterialButton btnYeniSatis;
        private MaterialSkin.Controls.MaterialButton btnMehsulIdareetme;
        private MaterialSkin.Controls.MaterialButton btnNovbeIdareetme;
        private MaterialSkin.Controls.MaterialButton btnKonfiqurasiya; // Əlavə edildi
        private Panel separator2;
        private Panel separator1;
        private Panel pnlUserInfo;
        private Label lblUserName;
        private PictureBox picUserIcon;
        private MaterialSkin.Controls.MaterialTabControl mdiTabControl;
        private MaterialSkin.Controls.MaterialContextMenuStrip tabContextMenu;
        private ToolStripMenuItem baglaToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem hamisiniBaglaToolStripMenuItem;
        private ImageList sidebarImageList;
        // Dashboard controls
        private Panel dashboardPanel;
        private MaterialSkin.Controls.MaterialCard dailySalesCard;
        private MaterialSkin.Controls.MaterialCard activeShiftCard;
        private MaterialSkin.Controls.MaterialCard debtorCustomersCard;
        private MaterialSkin.Controls.MaterialCard lowStockProductsCard;
        private Label lblDailySales;
        private Label lblActiveShift;
        private Label lblDebtorCustomers;
        private Label lblLowStockProducts;
        private Label lblDailySalesValue;
        private Label lblActiveShiftValue;
        private Label lblDebtorCustomersValue;
        private Label lblLowStockProductsValue;
        private System.Windows.Forms.Timer dashboardTimer;
    }
}
