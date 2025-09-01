// Fayl: AzAgroPOS.Teqdimat/SatisFormu.Designer.cs
namespace AzAgroPOS.Teqdimat
{
    partial class SatisFormu
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            pnlMainContainer = new Panel();
            pnlSearchSection = new MaterialSkin.Controls.MaterialCard();
            lblSearchTitle = new MaterialSkin.Controls.MaterialLabel();
            txtAxtaris = new MaterialSkin.Controls.MaterialTextBox2();
            dgvAxtarisNeticeleri = new DataGridView();
            pnlQuantityControls = new Panel();
            txtMiqdar = new MaterialSkin.Controls.MaterialTextBox2();
            btnSebeteElaveEt = new MaterialSkin.Controls.MaterialButton();
            pnlCartSection = new MaterialSkin.Controls.MaterialCard();
            lblCartTitle = new MaterialSkin.Controls.MaterialLabel();
            dgvSebet = new DataGridView();
            pnlCartControls = new Panel();
            btnSebetdenSil = new MaterialSkin.Controls.MaterialButton();
            btnSebetTemizle = new MaterialSkin.Controls.MaterialButton();
            pnlPaymentSection = new MaterialSkin.Controls.MaterialCard();
            lblTotalTitle = new MaterialSkin.Controls.MaterialLabel();
            lblUmumiMebleg = new MaterialSkin.Controls.MaterialLabel();
            pnlPaymentMethods = new Panel();
            btnNagd = new MaterialSkin.Controls.MaterialButton();
            btnKart = new MaterialSkin.Controls.MaterialButton();
            btnNisye = new MaterialSkin.Controls.MaterialButton();
            pnlAdvancedOptions = new Panel();
            cmbMusteriler = new MaterialSkin.Controls.MaterialComboBox();
            btnSatisiGozlet = new MaterialSkin.Controls.MaterialButton();
            btnGozleyenSatislar = new MaterialSkin.Controls.MaterialButton();
            btnIndirim = new MaterialSkin.Controls.MaterialButton();
            contextMenuStripGozleyenler = new ContextMenuStrip(components);
            toolTip1 = new ToolTip(components);
            pnlMainContainer.SuspendLayout();
            pnlSearchSection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAxtarisNeticeleri).BeginInit();
            pnlQuantityControls.SuspendLayout();
            pnlCartSection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSebet).BeginInit();
            pnlCartControls.SuspendLayout();
            pnlPaymentSection.SuspendLayout();
            pnlPaymentMethods.SuspendLayout();
            pnlAdvancedOptions.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMainContainer
            // 
            pnlMainContainer.BackColor = Color.FromArgb(242, 242, 242);
            pnlMainContainer.Controls.Add(pnlSearchSection);
            pnlMainContainer.Controls.Add(pnlCartSection);
            pnlMainContainer.Controls.Add(pnlPaymentSection);
            pnlMainContainer.Dock = DockStyle.Fill;
            pnlMainContainer.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlMainContainer.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlMainContainer.Location = new Point(3, 64);
            pnlMainContainer.Name = "pnlMainContainer";
            pnlMainContainer.Padding = new Padding(10);
            pnlMainContainer.Size = new Size(1378, 671);
            pnlMainContainer.TabIndex = 0;
            // 
            // pnlSearchSection
            // 
            pnlSearchSection.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pnlSearchSection.BackColor = Color.FromArgb(255, 255, 255);
            pnlSearchSection.Controls.Add(lblSearchTitle);
            pnlSearchSection.Controls.Add(txtAxtaris);
            pnlSearchSection.Controls.Add(dgvAxtarisNeticeleri);
            pnlSearchSection.Controls.Add(pnlQuantityControls);
            pnlSearchSection.Depth = 0;
            pnlSearchSection.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlSearchSection.Location = new Point(13, 13);
            pnlSearchSection.Margin = new Padding(14);
            pnlSearchSection.MouseState = MaterialSkin.MouseState.HOVER;
            pnlSearchSection.Name = "pnlSearchSection";
            pnlSearchSection.Padding = new Padding(14);
            pnlSearchSection.Size = new Size(480, 480);
            pnlSearchSection.TabIndex = 0;
            // 
            // lblSearchTitle
            // 
            lblSearchTitle.AutoSize = true;
            lblSearchTitle.BackColor = Color.FromArgb(242, 242, 242);
            lblSearchTitle.Depth = 0;
            lblSearchTitle.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSearchTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            lblSearchTitle.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblSearchTitle.Location = new Point(17, 14);
            lblSearchTitle.MouseState = MaterialSkin.MouseState.HOVER;
            lblSearchTitle.Name = "lblSearchTitle";
            lblSearchTitle.Size = new Size(110, 19);
            lblSearchTitle.TabIndex = 3;
            lblSearchTitle.Text = "Məhsul Axtarışı";
            // 
            // txtAxtaris
            // 
            txtAxtaris.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAxtaris.AnimateReadOnly = false;
            txtAxtaris.BackColor = Color.FromArgb(255, 255, 255);
            txtAxtaris.BackgroundImageLayout = ImageLayout.None;
            txtAxtaris.CharacterCasing = CharacterCasing.Normal;
            txtAxtaris.Depth = 0;
            txtAxtaris.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtAxtaris.HideSelection = true;
            txtAxtaris.Hint = "Barkod, Stok Kodu və ya Ad";
            txtAxtaris.LeadingIcon = null;
            txtAxtaris.Location = new Point(17, 45);
            txtAxtaris.MaxLength = 32767;
            txtAxtaris.MouseState = MaterialSkin.MouseState.OUT;
            txtAxtaris.Name = "txtAxtaris";
            txtAxtaris.PasswordChar = '\0';
            txtAxtaris.PrefixSuffixText = null;
            txtAxtaris.ReadOnly = false;
            txtAxtaris.RightToLeft = RightToLeft.No;
            txtAxtaris.SelectedText = "";
            txtAxtaris.SelectionLength = 0;
            txtAxtaris.SelectionStart = 0;
            txtAxtaris.ShortcutsEnabled = true;
            txtAxtaris.Size = new Size(446, 48);
            txtAxtaris.TabIndex = 0;
            txtAxtaris.TabStop = false;
            txtAxtaris.TextAlign = HorizontalAlignment.Left;
            txtAxtaris.TrailingIcon = null;
            txtAxtaris.UseSystemPasswordChar = false;
            txtAxtaris.TextChanged += txtAxtaris_TextChanged;
            // 
            // dgvAxtarisNeticeleri
            // 
            dgvAxtarisNeticeleri.AllowUserToAddRows = false;
            dgvAxtarisNeticeleri.AllowUserToDeleteRows = false;
            dgvAxtarisNeticeleri.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAxtarisNeticeleri.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAxtarisNeticeleri.BackgroundColor = Color.WhiteSmoke;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvAxtarisNeticeleri.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvAxtarisNeticeleri.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvAxtarisNeticeleri.DefaultCellStyle = dataGridViewCellStyle2;
            dgvAxtarisNeticeleri.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvAxtarisNeticeleri.Location = new Point(17, 99);
            dgvAxtarisNeticeleri.MultiSelect = false;
            dgvAxtarisNeticeleri.Name = "dgvAxtarisNeticeleri";
            dgvAxtarisNeticeleri.ReadOnly = true;
            dgvAxtarisNeticeleri.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAxtarisNeticeleri.Size = new Size(446, 290);
            dgvAxtarisNeticeleri.TabIndex = 1;
            dgvAxtarisNeticeleri.DoubleClick += dgvAxtarisNeticeleri_DoubleClick;
            // 
            // pnlQuantityControls
            // 
            pnlQuantityControls.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlQuantityControls.BackColor = Color.FromArgb(255, 255, 255);
            pnlQuantityControls.Controls.Add(txtMiqdar);
            pnlQuantityControls.Controls.Add(btnSebeteElaveEt);
            pnlQuantityControls.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlQuantityControls.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlQuantityControls.Location = new Point(17, 408);
            pnlQuantityControls.Name = "pnlQuantityControls";
            pnlQuantityControls.Size = new Size(446, 55);
            pnlQuantityControls.TabIndex = 2;
            // 
            // txtMiqdar
            // 
            txtMiqdar.AnimateReadOnly = false;
            txtMiqdar.BackColor = Color.FromArgb(255, 255, 255);
            txtMiqdar.BackgroundImageLayout = ImageLayout.None;
            txtMiqdar.CharacterCasing = CharacterCasing.Normal;
            txtMiqdar.Depth = 0;
            txtMiqdar.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtMiqdar.HideSelection = true;
            txtMiqdar.Hint = "Miqdar";
            txtMiqdar.LeadingIcon = null;
            txtMiqdar.Location = new Point(3, 3);
            txtMiqdar.MaxLength = 32767;
            txtMiqdar.MouseState = MaterialSkin.MouseState.OUT;
            txtMiqdar.Name = "txtMiqdar";
            txtMiqdar.PasswordChar = '\0';
            txtMiqdar.PrefixSuffixText = null;
            txtMiqdar.ReadOnly = false;
            txtMiqdar.RightToLeft = RightToLeft.No;
            txtMiqdar.SelectedText = "";
            txtMiqdar.SelectionLength = 0;
            txtMiqdar.SelectionStart = 0;
            txtMiqdar.ShortcutsEnabled = true;
            txtMiqdar.Size = new Size(120, 48);
            txtMiqdar.TabIndex = 0;
            txtMiqdar.TabStop = false;
            txtMiqdar.Text = "1";
            txtMiqdar.TextAlign = HorizontalAlignment.Left;
            txtMiqdar.TrailingIcon = null;
            txtMiqdar.UseSystemPasswordChar = false;
            // 
            // btnSebeteElaveEt
            // 
            btnSebeteElaveEt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnSebeteElaveEt.AutoSize = false;
            btnSebeteElaveEt.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSebeteElaveEt.BackColor = Color.FromArgb(242, 242, 242);
            btnSebeteElaveEt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSebeteElaveEt.Depth = 0;
            btnSebeteElaveEt.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnSebeteElaveEt.HighEmphasis = true;
            btnSebeteElaveEt.Icon = null;
            btnSebeteElaveEt.Location = new Point(130, 4);
            btnSebeteElaveEt.Margin = new Padding(4, 6, 4, 6);
            btnSebeteElaveEt.MouseState = MaterialSkin.MouseState.HOVER;
            btnSebeteElaveEt.Name = "btnSebeteElaveEt";
            btnSebeteElaveEt.NoAccentTextColor = Color.Empty;
            btnSebeteElaveEt.Size = new Size(312, 48);
            btnSebeteElaveEt.TabIndex = 1;
            btnSebeteElaveEt.Text = "Səbətə Əlavə Et (F7)";
            btnSebeteElaveEt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSebeteElaveEt.UseAccentColor = false;
            btnSebeteElaveEt.UseVisualStyleBackColor = false;
            btnSebeteElaveEt.Click += btnSebeteElaveEt_Click;
            // 
            // pnlCartSection
            // 
            pnlCartSection.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlCartSection.BackColor = Color.FromArgb(255, 255, 255);
            pnlCartSection.Controls.Add(lblCartTitle);
            pnlCartSection.Controls.Add(dgvSebet);
            pnlCartSection.Controls.Add(pnlCartControls);
            pnlCartSection.Depth = 0;
            pnlCartSection.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlCartSection.Location = new Point(511, 13);
            pnlCartSection.Margin = new Padding(14);
            pnlCartSection.MouseState = MaterialSkin.MouseState.HOVER;
            pnlCartSection.Name = "pnlCartSection";
            pnlCartSection.Padding = new Padding(14);
            pnlCartSection.Size = new Size(854, 480);
            pnlCartSection.TabIndex = 1;
            // 
            // lblCartTitle
            // 
            lblCartTitle.AutoSize = true;
            lblCartTitle.BackColor = Color.FromArgb(242, 242, 242);
            lblCartTitle.Depth = 0;
            lblCartTitle.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblCartTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            lblCartTitle.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblCartTitle.Location = new Point(17, 14);
            lblCartTitle.MouseState = MaterialSkin.MouseState.HOVER;
            lblCartTitle.Name = "lblCartTitle";
            lblCartTitle.Size = new Size(85, 19);
            lblCartTitle.TabIndex = 3;
            lblCartTitle.Text = "Satış Səbəti";
            // 
            // dgvSebet
            // 
            dgvSebet.AllowUserToAddRows = false;
            dgvSebet.AllowUserToDeleteRows = false;
            dgvSebet.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSebet.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSebet.BackgroundColor = Color.WhiteSmoke;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvSebet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvSebet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvSebet.DefaultCellStyle = dataGridViewCellStyle4;
            dgvSebet.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvSebet.Location = new Point(17, 45);
            dgvSebet.Name = "dgvSebet";
            dgvSebet.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSebet.Size = new Size(820, 344);
            dgvSebet.TabIndex = 0;
            dgvSebet.CellEndEdit += dgvSebet_CellEndEdit;
            // 
            // pnlCartControls
            // 
            pnlCartControls.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlCartControls.BackColor = Color.FromArgb(255, 255, 255);
            pnlCartControls.Controls.Add(btnSebetdenSil);
            pnlCartControls.Controls.Add(btnSebetTemizle);
            pnlCartControls.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlCartControls.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlCartControls.Location = new Point(34, 405);
            pnlCartControls.Name = "pnlCartControls";
            pnlCartControls.Size = new Size(820, 55);
            pnlCartControls.TabIndex = 1;
            // 
            // btnSebetdenSil
            // 
            btnSebetdenSil.AutoSize = false;
            btnSebetdenSil.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSebetdenSil.BackColor = Color.FromArgb(242, 242, 242);
            btnSebetdenSil.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSebetdenSil.Depth = 0;
            btnSebetdenSil.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnSebetdenSil.HighEmphasis = true;
            btnSebetdenSil.Icon = null;
            btnSebetdenSil.Location = new Point(4, 4);
            btnSebetdenSil.Margin = new Padding(4, 6, 4, 6);
            btnSebetdenSil.MouseState = MaterialSkin.MouseState.HOVER;
            btnSebetdenSil.Name = "btnSebetdenSil";
            btnSebetdenSil.NoAccentTextColor = Color.Empty;
            btnSebetdenSil.Size = new Size(150, 48);
            btnSebetdenSil.TabIndex = 0;
            btnSebetdenSil.Text = "Səbətdən Sil";
            btnSebetdenSil.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSebetdenSil.UseAccentColor = true;
            btnSebetdenSil.UseVisualStyleBackColor = false;
            btnSebetdenSil.Click += btnSebetdenSil_Click;
            // 
            // btnSebetTemizle
            // 
            btnSebetTemizle.AutoSize = false;
            btnSebetTemizle.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSebetTemizle.BackColor = Color.FromArgb(242, 242, 242);
            btnSebetTemizle.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSebetTemizle.Depth = 0;
            btnSebetTemizle.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnSebetTemizle.HighEmphasis = false;
            btnSebetTemizle.Icon = null;
            btnSebetTemizle.Location = new Point(162, 4);
            btnSebetTemizle.Margin = new Padding(4, 6, 4, 6);
            btnSebetTemizle.MouseState = MaterialSkin.MouseState.HOVER;
            btnSebetTemizle.Name = "btnSebetTemizle";
            btnSebetTemizle.NoAccentTextColor = Color.Empty;
            btnSebetTemizle.Size = new Size(150, 48);
            btnSebetTemizle.TabIndex = 1;
            btnSebetTemizle.Text = "Səbəti Təmizlə";
            btnSebetTemizle.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnSebetTemizle.UseAccentColor = false;
            btnSebetTemizle.UseVisualStyleBackColor = false;
            btnSebetTemizle.Click += btnSebetTemizle_Click;
            // 
            // pnlPaymentSection
            // 
            pnlPaymentSection.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlPaymentSection.BackColor = Color.FromArgb(255, 255, 255);
            pnlPaymentSection.Controls.Add(lblTotalTitle);
            pnlPaymentSection.Controls.Add(lblUmumiMebleg);
            pnlPaymentSection.Controls.Add(pnlPaymentMethods);
            pnlPaymentSection.Controls.Add(pnlAdvancedOptions);
            pnlPaymentSection.Depth = 0;
            pnlPaymentSection.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlPaymentSection.Location = new Point(13, 507);
            pnlPaymentSection.Margin = new Padding(14);
            pnlPaymentSection.MouseState = MaterialSkin.MouseState.HOVER;
            pnlPaymentSection.Name = "pnlPaymentSection";
            pnlPaymentSection.Padding = new Padding(14);
            pnlPaymentSection.Size = new Size(1352, 151);
            pnlPaymentSection.TabIndex = 2;
            // 
            // lblTotalTitle
            // 
            lblTotalTitle.AutoSize = true;
            lblTotalTitle.BackColor = Color.FromArgb(242, 242, 242);
            lblTotalTitle.Depth = 0;
            lblTotalTitle.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblTotalTitle.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblTotalTitle.Location = new Point(17, 14);
            lblTotalTitle.MouseState = MaterialSkin.MouseState.HOVER;
            lblTotalTitle.Name = "lblTotalTitle";
            lblTotalTitle.Size = new Size(123, 19);
            lblTotalTitle.TabIndex = 4;
            lblTotalTitle.Text = "ÜMUMİ MƏBLƏĞ";
            // 
            // lblUmumiMebleg
            // 
            lblUmumiMebleg.AutoSize = true;
            lblUmumiMebleg.BackColor = Color.FromArgb(242, 242, 242);
            lblUmumiMebleg.Depth = 0;
            lblUmumiMebleg.Font = new Font("Roboto", 48F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblUmumiMebleg.FontType = MaterialSkin.MaterialSkinManager.fontType.H3;
            lblUmumiMebleg.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblUmumiMebleg.Location = new Point(17, 42);
            lblUmumiMebleg.MouseState = MaterialSkin.MouseState.HOVER;
            lblUmumiMebleg.Name = "lblUmumiMebleg";
            lblUmumiMebleg.Size = new Size(201, 58);
            lblUmumiMebleg.TabIndex = 0;
            lblUmumiMebleg.Text = "0.00 AZN";
            // 
            // pnlPaymentMethods
            // 
            pnlPaymentMethods.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlPaymentMethods.BackColor = Color.FromArgb(255, 255, 255);
            pnlPaymentMethods.Controls.Add(btnNagd);
            pnlPaymentMethods.Controls.Add(btnKart);
            pnlPaymentMethods.Controls.Add(btnNisye);
            pnlPaymentMethods.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlPaymentMethods.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlPaymentMethods.Location = new Point(882, 17);
            pnlPaymentMethods.Name = "pnlPaymentMethods";
            pnlPaymentMethods.Size = new Size(453, 73);
            pnlPaymentMethods.TabIndex = 2;
            // 
            // btnNagd
            // 
            btnNagd.AutoSize = false;
            btnNagd.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnNagd.BackColor = Color.FromArgb(242, 242, 242);
            btnNagd.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnNagd.Depth = 0;
            btnNagd.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnNagd.HighEmphasis = true;
            btnNagd.Icon = null;
            btnNagd.Location = new Point(4, 4);
            btnNagd.Margin = new Padding(4, 6, 4, 6);
            btnNagd.MouseState = MaterialSkin.MouseState.HOVER;
            btnNagd.Name = "btnNagd";
            btnNagd.NoAccentTextColor = Color.Empty;
            btnNagd.Size = new Size(140, 60);
            btnNagd.TabIndex = 0;
            btnNagd.Text = "NAĞD (F1)";
            btnNagd.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnNagd.UseAccentColor = false;
            btnNagd.UseVisualStyleBackColor = false;
            btnNagd.Click += btnNagd_Click;
            // 
            // btnKart
            // 
            btnKart.AutoSize = false;
            btnKart.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnKart.BackColor = Color.FromArgb(242, 242, 242);
            btnKart.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnKart.Depth = 0;
            btnKart.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnKart.HighEmphasis = true;
            btnKart.Icon = null;
            btnKart.Location = new Point(152, 4);
            btnKart.Margin = new Padding(4, 6, 4, 6);
            btnKart.MouseState = MaterialSkin.MouseState.HOVER;
            btnKart.Name = "btnKart";
            btnKart.NoAccentTextColor = Color.Empty;
            btnKart.Size = new Size(140, 60);
            btnKart.TabIndex = 1;
            btnKart.Text = "KART (F2)";
            btnKart.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnKart.UseAccentColor = false;
            btnKart.UseVisualStyleBackColor = false;
            btnKart.Click += btnKart_Click;
            // 
            // btnNisye
            // 
            btnNisye.AutoSize = false;
            btnNisye.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnNisye.BackColor = Color.FromArgb(242, 242, 242);
            btnNisye.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnNisye.Depth = 0;
            btnNisye.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnNisye.HighEmphasis = true;
            btnNisye.Icon = null;
            btnNisye.Location = new Point(300, 4);
            btnNisye.Margin = new Padding(4, 6, 4, 6);
            btnNisye.MouseState = MaterialSkin.MouseState.HOVER;
            btnNisye.Name = "btnNisye";
            btnNisye.NoAccentTextColor = Color.Empty;
            btnNisye.Size = new Size(140, 60);
            btnNisye.TabIndex = 2;
            btnNisye.Text = "NİSYƏ (F3)";
            btnNisye.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnNisye.UseAccentColor = true;
            btnNisye.UseVisualStyleBackColor = false;
            btnNisye.Click += btnNisye_Click;
            // 
            // pnlAdvancedOptions
            // 
            pnlAdvancedOptions.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlAdvancedOptions.BackColor = Color.FromArgb(255, 255, 255);
            pnlAdvancedOptions.Controls.Add(cmbMusteriler);
            pnlAdvancedOptions.Controls.Add(btnSatisiGozlet);
            pnlAdvancedOptions.Controls.Add(btnGozleyenSatislar);
            pnlAdvancedOptions.Controls.Add(btnIndirim);
            pnlAdvancedOptions.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlAdvancedOptions.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlAdvancedOptions.Location = new Point(17, 103);
            pnlAdvancedOptions.Name = "pnlAdvancedOptions";
            pnlAdvancedOptions.Size = new Size(1318, 45);
            pnlAdvancedOptions.TabIndex = 3;
            // 
            // cmbMusteriler
            // 
            cmbMusteriler.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbMusteriler.AutoResize = false;
            cmbMusteriler.BackColor = Color.FromArgb(242, 242, 242);
            cmbMusteriler.Depth = 0;
            cmbMusteriler.DrawMode = DrawMode.OwnerDrawVariable;
            cmbMusteriler.DropDownHeight = 174;
            cmbMusteriler.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMusteriler.DropDownWidth = 121;
            cmbMusteriler.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbMusteriler.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbMusteriler.Hint = "Müştəri Seçin";
            cmbMusteriler.IntegralHeight = false;
            cmbMusteriler.ItemHeight = 43;
            cmbMusteriler.Location = new Point(865, 0);
            cmbMusteriler.MaxDropDownItems = 4;
            cmbMusteriler.MouseState = MaterialSkin.MouseState.OUT;
            cmbMusteriler.Name = "cmbMusteriler";
            cmbMusteriler.Size = new Size(450, 49);
            cmbMusteriler.StartIndex = 0;
            cmbMusteriler.TabIndex = 3;
            // 
            // btnSatisiGozlet
            // 
            btnSatisiGozlet.AutoSize = false;
            btnSatisiGozlet.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSatisiGozlet.BackColor = Color.FromArgb(242, 242, 242);
            btnSatisiGozlet.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSatisiGozlet.Depth = 0;
            btnSatisiGozlet.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnSatisiGozlet.HighEmphasis = false;
            btnSatisiGozlet.Icon = null;
            btnSatisiGozlet.Location = new Point(4, 0);
            btnSatisiGozlet.Margin = new Padding(4, 6, 4, 6);
            btnSatisiGozlet.MouseState = MaterialSkin.MouseState.HOVER;
            btnSatisiGozlet.Name = "btnSatisiGozlet";
            btnSatisiGozlet.NoAccentTextColor = Color.Empty;
            btnSatisiGozlet.Size = new Size(140, 40);
            btnSatisiGozlet.TabIndex = 0;
            btnSatisiGozlet.Text = "Gözlət (F4)";
            btnSatisiGozlet.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnSatisiGozlet.UseAccentColor = false;
            btnSatisiGozlet.UseVisualStyleBackColor = false;
            btnSatisiGozlet.Click += btnSatisiGozlet_Click;
            // 
            // btnGozleyenSatislar
            // 
            btnGozleyenSatislar.AutoSize = false;
            btnGozleyenSatislar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnGozleyenSatislar.BackColor = Color.FromArgb(242, 242, 242);
            btnGozleyenSatislar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnGozleyenSatislar.Depth = 0;
            btnGozleyenSatislar.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnGozleyenSatislar.HighEmphasis = false;
            btnGozleyenSatislar.Icon = null;
            btnGozleyenSatislar.Location = new Point(152, 0);
            btnGozleyenSatislar.Margin = new Padding(4, 6, 4, 6);
            btnGozleyenSatislar.MouseState = MaterialSkin.MouseState.HOVER;
            btnGozleyenSatislar.Name = "btnGozleyenSatislar";
            btnGozleyenSatislar.NoAccentTextColor = Color.Empty;
            btnGozleyenSatislar.Size = new Size(140, 40);
            btnGozleyenSatislar.TabIndex = 1;
            btnGozleyenSatislar.Text = "Gözləyənlər (F5)";
            btnGozleyenSatislar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            btnGozleyenSatislar.UseAccentColor = false;
            btnGozleyenSatislar.UseVisualStyleBackColor = false;
            btnGozleyenSatislar.Click += btnGozleyenSatislar_Click;
            // 
            // btnIndirim
            // 
            btnIndirim.AutoSize = false;
            btnIndirim.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnIndirim.BackColor = Color.FromArgb(242, 242, 242);
            btnIndirim.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnIndirim.Depth = 0;
            btnIndirim.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnIndirim.HighEmphasis = false;
            btnIndirim.Icon = null;
            btnIndirim.Location = new Point(300, 0);
            btnIndirim.Margin = new Padding(4, 6, 4, 6);
            btnIndirim.MouseState = MaterialSkin.MouseState.HOVER;
            btnIndirim.Name = "btnIndirim";
            btnIndirim.NoAccentTextColor = Color.Empty;
            btnIndirim.Size = new Size(140, 40);
            btnIndirim.TabIndex = 2;
            btnIndirim.Text = "İndirim (F6)";
            btnIndirim.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            btnIndirim.UseAccentColor = true;
            btnIndirim.UseVisualStyleBackColor = false;
            btnIndirim.Click += btnIndirim_Click;
            // 
            // contextMenuStripGozleyenler
            // 
            contextMenuStripGozleyenler.Name = "contextMenuStripGozleyenler";
            contextMenuStripGozleyenler.Size = new Size(61, 4);
            contextMenuStripGozleyenler.ItemClicked += contextMenuStripGozleyenler_ItemClicked;
            // 
            // SatisFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1384, 738);
            Controls.Add(pnlMainContainer);
            KeyPreview = true;
            Name = "SatisFormu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Yeni Satış";
            WindowState = FormWindowState.Maximized;
            KeyDown += SatisFormu_KeyDown;
            pnlMainContainer.ResumeLayout(false);
            pnlSearchSection.ResumeLayout(false);
            pnlSearchSection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAxtarisNeticeleri).EndInit();
            pnlQuantityControls.ResumeLayout(false);
            pnlCartSection.ResumeLayout(false);
            pnlCartSection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSebet).EndInit();
            pnlCartControls.ResumeLayout(false);
            pnlPaymentSection.ResumeLayout(false);
            pnlPaymentSection.PerformLayout();
            pnlPaymentMethods.ResumeLayout(false);
            pnlAdvancedOptions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlMainContainer;
        private MaterialSkin.Controls.MaterialCard pnlSearchSection;
        private MaterialSkin.Controls.MaterialLabel lblSearchTitle;
        private MaterialSkin.Controls.MaterialTextBox2 txtAxtaris;
        private System.Windows.Forms.DataGridView dgvAxtarisNeticeleri;
        private System.Windows.Forms.Panel pnlQuantityControls;
        private MaterialSkin.Controls.MaterialTextBox2 txtMiqdar;
        private MaterialSkin.Controls.MaterialButton btnSebeteElaveEt;
        private MaterialSkin.Controls.MaterialCard pnlCartSection;
        private MaterialSkin.Controls.MaterialLabel lblCartTitle;
        private System.Windows.Forms.DataGridView dgvSebet;
        private System.Windows.Forms.Panel pnlCartControls;
        private MaterialSkin.Controls.MaterialButton btnSebetdenSil;
        private MaterialSkin.Controls.MaterialButton btnSebetTemizle;
        private MaterialSkin.Controls.MaterialCard pnlPaymentSection;
        private MaterialSkin.Controls.MaterialLabel lblTotalTitle;
        private MaterialSkin.Controls.MaterialLabel lblUmumiMebleg;
        private System.Windows.Forms.Panel pnlPaymentMethods;
        private MaterialSkin.Controls.MaterialButton btnNagd;
        private MaterialSkin.Controls.MaterialButton btnKart;
        private MaterialSkin.Controls.MaterialButton btnNisye;
        private System.Windows.Forms.Panel pnlAdvancedOptions;
        private MaterialSkin.Controls.MaterialComboBox cmbMusteriler;
        private MaterialSkin.Controls.MaterialButton btnSatisiGozlet;
        private MaterialSkin.Controls.MaterialButton btnGozleyenSatislar;
        private MaterialSkin.Controls.MaterialButton btnIndirim;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGozleyenler;
    }
}