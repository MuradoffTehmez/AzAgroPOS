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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMainContainer = new System.Windows.Forms.Panel();
            this.pnlSearchSection = new MaterialSkin.Controls.MaterialCard();
            this.lblSearchTitle = new MaterialSkin.Controls.MaterialLabel();
            this.txtAxtaris = new MaterialSkin.Controls.MaterialTextBox2();
            this.dgvAxtarisNeticeleri = new System.Windows.Forms.DataGridView();
            this.pnlQuantityControls = new System.Windows.Forms.Panel();
            this.txtMiqdar = new MaterialSkin.Controls.MaterialTextBox2();
            this.btnSebeteElaveEt = new MaterialSkin.Controls.MaterialButton();
            this.pnlCartSection = new MaterialSkin.Controls.MaterialCard();
            this.lblCartTitle = new MaterialSkin.Controls.MaterialLabel();
            this.dgvSebet = new System.Windows.Forms.DataGridView();
            this.pnlCartControls = new System.Windows.Forms.Panel();
            this.btnSebetdenSil = new MaterialSkin.Controls.MaterialButton();
            this.btnSebetTemizle = new MaterialSkin.Controls.MaterialButton();
            this.pnlPaymentSection = new MaterialSkin.Controls.MaterialCard();
            this.lblTotalTitle = new MaterialSkin.Controls.MaterialLabel();
            this.lblUmumiMebleg = new MaterialSkin.Controls.MaterialLabel();
            this.pnlPaymentMethods = new System.Windows.Forms.Panel();
            this.btnNagd = new MaterialSkin.Controls.MaterialButton();
            this.btnKart = new MaterialSkin.Controls.MaterialButton();
            this.btnNisye = new MaterialSkin.Controls.MaterialButton();
            this.pnlAdvancedOptions = new System.Windows.Forms.Panel();
            this.cmbMusteriler = new MaterialSkin.Controls.MaterialComboBox();
            this.btnSatisiGozlet = new MaterialSkin.Controls.MaterialButton();
            this.btnGozleyenSatislar = new MaterialSkin.Controls.MaterialButton();
            this.btnIndirim = new MaterialSkin.Controls.MaterialButton();
            this.contextMenuStripGozleyenler = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlMainContainer.SuspendLayout();
            this.pnlSearchSection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAxtarisNeticeleri)).BeginInit();
            this.pnlQuantityControls.SuspendLayout();
            this.pnlCartSection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSebet)).BeginInit();
            this.pnlCartControls.SuspendLayout();
            this.pnlPaymentSection.SuspendLayout();
            this.pnlPaymentMethods.SuspendLayout();
            this.pnlAdvancedOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMainContainer
            // 
            this.pnlMainContainer.Controls.Add(this.pnlSearchSection);
            this.pnlMainContainer.Controls.Add(this.pnlCartSection);
            this.pnlMainContainer.Controls.Add(this.pnlPaymentSection);
            this.pnlMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContainer.Location = new System.Drawing.Point(3, 64);
            this.pnlMainContainer.Name = "pnlMainContainer";
            this.pnlMainContainer.Padding = new System.Windows.Forms.Padding(10);
            this.pnlMainContainer.Size = new System.Drawing.Size(1378, 671);
            this.pnlMainContainer.TabIndex = 0;
            // 
            // pnlSearchSection
            // 
            this.pnlSearchSection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlSearchSection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlSearchSection.Controls.Add(this.lblSearchTitle);
            this.pnlSearchSection.Controls.Add(this.txtAxtaris);
            this.pnlSearchSection.Controls.Add(this.dgvAxtarisNeticeleri);
            this.pnlSearchSection.Controls.Add(this.pnlQuantityControls);
            this.pnlSearchSection.Depth = 0;
            this.pnlSearchSection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlSearchSection.Location = new System.Drawing.Point(13, 13);
            this.pnlSearchSection.Margin = new System.Windows.Forms.Padding(14);
            this.pnlSearchSection.MouseState = MaterialSkin.MouseState.HOVER;
            this.pnlSearchSection.Name = "pnlSearchSection";
            this.pnlSearchSection.Padding = new System.Windows.Forms.Padding(14);
            this.pnlSearchSection.Size = new System.Drawing.Size(480, 480);
            this.pnlSearchSection.TabIndex = 0;
            // 
            // lblSearchTitle
            // 
            this.lblSearchTitle.AutoSize = true;
            this.lblSearchTitle.Depth = 0;
            this.lblSearchTitle.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblSearchTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            this.lblSearchTitle.Location = new System.Drawing.Point(17, 14);
            this.lblSearchTitle.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblSearchTitle.Name = "lblSearchTitle";
            this.lblSearchTitle.Size = new System.Drawing.Size(117, 19);
            this.lblSearchTitle.TabIndex = 3;
            this.lblSearchTitle.Text = "Məhsul Axtarışı";
            // 
            // txtAxtaris
            // 
            this.txtAxtaris.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAxtaris.AnimateReadOnly = false;
            this.txtAxtaris.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtAxtaris.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAxtaris.Depth = 0;
            this.txtAxtaris.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtAxtaris.HideSelection = true;
            this.txtAxtaris.Hint = "Barkod, Stok Kodu və ya Ad";
            this.txtAxtaris.LeadingIcon = null;
            this.txtAxtaris.Location = new System.Drawing.Point(17, 45);
            this.txtAxtaris.MaxLength = 32767;
            this.txtAxtaris.MouseState = MaterialSkin.MouseState.OUT;
            this.txtAxtaris.Name = "txtAxtaris";
            this.txtAxtaris.PasswordChar = '\0';
            this.txtAxtaris.PrefixSuffixText = null;
            this.txtAxtaris.ReadOnly = false;
            this.txtAxtaris.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAxtaris.SelectedText = "";
            this.txtAxtaris.SelectionLength = 0;
            this.txtAxtaris.SelectionStart = 0;
            this.txtAxtaris.ShortcutsEnabled = true;
            this.txtAxtaris.Size = new System.Drawing.Size(446, 48);
            this.txtAxtaris.TabIndex = 0;
            this.txtAxtaris.TabStop = false;
            this.txtAxtaris.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtAxtaris.TrailingIcon = null;
            this.txtAxtaris.UseSystemPasswordChar = false;
            this.txtAxtaris.TextChanged += new System.EventHandler(this.txtAxtaris_TextChanged);
            // 
            // dgvAxtarisNeticeleri
            // 
            this.dgvAxtarisNeticeleri.AllowUserToAddRows = false;
            this.dgvAxtarisNeticeleri.AllowUserToDeleteRows = false;
            this.dgvAxtarisNeticeleri.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAxtarisNeticeleri.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAxtarisNeticeleri.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAxtarisNeticeleri.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAxtarisNeticeleri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAxtarisNeticeleri.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAxtarisNeticeleri.Location = new System.Drawing.Point(17, 99);
            this.dgvAxtarisNeticeleri.MultiSelect = false;
            this.dgvAxtarisNeticeleri.Name = "dgvAxtarisNeticeleri";
            this.dgvAxtarisNeticeleri.ReadOnly = true;
            this.dgvAxtarisNeticeleri.RowTemplate.Height = 25;
            this.dgvAxtarisNeticeleri.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAxtarisNeticeleri.Size = new System.Drawing.Size(446, 290);
            this.dgvAxtarisNeticeleri.TabIndex = 1;
            this.dgvAxtarisNeticeleri.DoubleClick += new System.EventHandler(this.dgvAxtarisNeticeleri_DoubleClick);
            // 
            // pnlQuantityControls
            // 
            this.pnlQuantityControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlQuantityControls.Controls.Add(this.txtMiqdar);
            this.pnlQuantityControls.Controls.Add(this.btnSebeteElaveEt);
            this.pnlQuantityControls.Location = new System.Drawing.Point(17, 408);
            this.pnlQuantityControls.Name = "pnlQuantityControls";
            this.pnlQuantityControls.Size = new System.Drawing.Size(446, 55);
            this.pnlQuantityControls.TabIndex = 2;
            // 
            // txtMiqdar
            // 
            this.txtMiqdar.AnimateReadOnly = false;
            this.txtMiqdar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtMiqdar.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtMiqdar.Depth = 0;
            this.txtMiqdar.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtMiqdar.HideSelection = true;
            this.txtMiqdar.Hint = "Miqdar";
            this.txtMiqdar.LeadingIcon = null;
            this.txtMiqdar.Location = new System.Drawing.Point(3, 3);
            this.txtMiqdar.MaxLength = 32767;
            this.txtMiqdar.MouseState = MaterialSkin.MouseState.OUT;
            this.txtMiqdar.Name = "txtMiqdar";
            this.txtMiqdar.PasswordChar = '\0';
            this.txtMiqdar.PrefixSuffixText = null;
            this.txtMiqdar.ReadOnly = false;
            this.txtMiqdar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMiqdar.SelectedText = "";
            this.txtMiqdar.SelectionLength = 0;
            this.txtMiqdar.SelectionStart = 0;
            this.txtMiqdar.ShortcutsEnabled = true;
            this.txtMiqdar.Size = new System.Drawing.Size(120, 48);
            this.txtMiqdar.TabIndex = 0;
            this.txtMiqdar.TabStop = false;
            this.txtMiqdar.Text = "1";
            this.txtMiqdar.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtMiqdar.TrailingIcon = null;
            this.txtMiqdar.UseSystemPasswordChar = false;
            // 
            // btnSebeteElaveEt
            // 
            this.btnSebeteElaveEt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSebeteElaveEt.AutoSize = false;
            this.btnSebeteElaveEt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSebeteElaveEt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSebeteElaveEt.Depth = 0;
            this.btnSebeteElaveEt.HighEmphasis = true;
            this.btnSebeteElaveEt.Icon = null;
            this.btnSebeteElaveEt.Location = new System.Drawing.Point(130, 4);
            this.btnSebeteElaveEt.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSebeteElaveEt.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSebeteElaveEt.Name = "btnSebeteElaveEt";
            this.btnSebeteElaveEt.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSebeteElaveEt.Size = new System.Drawing.Size(312, 48);
            this.btnSebeteElaveEt.TabIndex = 1;
            this.btnSebeteElaveEt.Text = "Səbətə Əlavə Et (F7)";
            this.btnSebeteElaveEt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSebeteElaveEt.UseAccentColor = false;
            this.btnSebeteElaveEt.UseVisualStyleBackColor = true;
            this.btnSebeteElaveEt.Click += new System.EventHandler(this.btnSebeteElaveEt_Click);
            // 
            // pnlCartSection
            // 
            this.pnlCartSection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCartSection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlCartSection.Controls.Add(this.lblCartTitle);
            this.pnlCartSection.Controls.Add(this.dgvSebet);
            this.pnlCartSection.Controls.Add(this.pnlCartControls);
            this.pnlCartSection.Depth = 0;
            this.pnlCartSection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlCartSection.Location = new System.Drawing.Point(511, 13);
            this.pnlCartSection.Margin = new System.Windows.Forms.Padding(14);
            this.pnlCartSection.MouseState = MaterialSkin.MouseState.HOVER;
            this.pnlCartSection.Name = "pnlCartSection";
            this.pnlCartSection.Padding = new System.Windows.Forms.Padding(14);
            this.pnlCartSection.Size = new System.Drawing.Size(854, 480);
            this.pnlCartSection.TabIndex = 1;
            // 
            // lblCartTitle
            // 
            this.lblCartTitle.AutoSize = true;
            this.lblCartTitle.Depth = 0;
            this.lblCartTitle.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblCartTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            this.lblCartTitle.Location = new System.Drawing.Point(17, 14);
            this.lblCartTitle.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblCartTitle.Name = "lblCartTitle";
            this.lblCartTitle.Size = new System.Drawing.Size(91, 19);
            this.lblCartTitle.TabIndex = 3;
            this.lblCartTitle.Text = "Satış Səbəti";
            // 
            // dgvSebet
            // 
            this.dgvSebet.AllowUserToAddRows = false;
            this.dgvSebet.AllowUserToDeleteRows = false;
            this.dgvSebet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSebet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSebet.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSebet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSebet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSebet.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSebet.Location = new System.Drawing.Point(17, 45);
            this.dgvSebet.Name = "dgvSebet";
            this.dgvSebet.RowTemplate.Height = 25;
            this.dgvSebet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSebet.Size = new System.Drawing.Size(820, 344);
            this.dgvSebet.TabIndex = 0;
            this.dgvSebet.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSebet_CellEndEdit);
            // 
            // pnlCartControls
            // 
            this.pnlCartControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCartControls.Controls.Add(this.btnSebetdenSil);
            this.pnlCartControls.Controls.Add(this.btnSebetTemizle);
            this.pnlCartControls.Location = new System.Drawing.Point(17, 408);
            this.pnlCartControls.Name = "pnlCartControls";
            this.pnlCartControls.Size = new System.Drawing.Size(820, 55);
            this.pnlCartControls.TabIndex = 1;
            // 
            // btnSebetdenSil
            // 
            this.btnSebetdenSil.AutoSize = false;
            this.btnSebetdenSil.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSebetdenSil.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSebetdenSil.Depth = 0;
            this.btnSebetdenSil.HighEmphasis = true;
            this.btnSebetdenSil.Icon = null;
            this.btnSebetdenSil.Location = new System.Drawing.Point(4, 4);
            this.btnSebetdenSil.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSebetdenSil.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSebetdenSil.Name = "btnSebetdenSil";
            this.btnSebetdenSil.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSebetdenSil.Size = new System.Drawing.Size(150, 48);
            this.btnSebetdenSil.TabIndex = 0;
            this.btnSebetdenSil.Text = "Səbətdən Sil";
            this.btnSebetdenSil.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSebetdenSil.UseAccentColor = true;
            this.btnSebetdenSil.UseVisualStyleBackColor = true;
            this.btnSebetdenSil.Click += new System.EventHandler(this.btnSebetdenSil_Click);
            // 
            // btnSebetTemizle
            // 
            this.btnSebetTemizle.AutoSize = false;
            this.btnSebetTemizle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSebetTemizle.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSebetTemizle.Depth = 0;
            this.btnSebetTemizle.HighEmphasis = false;
            this.btnSebetTemizle.Icon = null;
            this.btnSebetTemizle.Location = new System.Drawing.Point(162, 4);
            this.btnSebetTemizle.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSebetTemizle.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSebetTemizle.Name = "btnSebetTemizle";
            this.btnSebetTemizle.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSebetTemizle.Size = new System.Drawing.Size(150, 48);
            this.btnSebetTemizle.TabIndex = 1;
            this.btnSebetTemizle.Text = "Səbəti Təmizlə";
            this.btnSebetTemizle.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnSebetTemizle.UseAccentColor = false;
            this.btnSebetTemizle.UseVisualStyleBackColor = true;
            this.btnSebetTemizle.Click += new System.EventHandler(this.btnSebetTemizle_Click);
            // 
            // pnlPaymentSection
            // 
            this.pnlPaymentSection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPaymentSection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlPaymentSection.Controls.Add(this.lblTotalTitle);
            this.pnlPaymentSection.Controls.Add(this.lblUmumiMebleg);
            this.pnlPaymentSection.Controls.Add(this.pnlPaymentMethods);
            this.pnlPaymentSection.Controls.Add(this.pnlAdvancedOptions);
            this.pnlPaymentSection.Depth = 0;
            this.pnlPaymentSection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlPaymentSection.Location = new System.Drawing.Point(13, 507);
            this.pnlPaymentSection.Margin = new System.Windows.Forms.Padding(14);
            this.pnlPaymentSection.MouseState = MaterialSkin.MouseState.HOVER;
            this.pnlPaymentSection.Name = "pnlPaymentSection";
            this.pnlPaymentSection.Padding = new System.Windows.Forms.Padding(14);
            this.pnlPaymentSection.Size = new System.Drawing.Size(1352, 151);
            this.pnlPaymentSection.TabIndex = 2;
            // 
            // lblTotalTitle
            // 
            this.lblTotalTitle.AutoSize = true;
            this.lblTotalTitle.Depth = 0;
            this.lblTotalTitle.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTotalTitle.Location = new System.Drawing.Point(17, 14);
            this.lblTotalTitle.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTotalTitle.Name = "lblTotalTitle";
            this.lblTotalTitle.Size = new System.Drawing.Size(113, 19);
            this.lblTotalTitle.TabIndex = 4;
            this.lblTotalTitle.Text = "ÜMUMİ MƏBLƏĞ";
            // 
            // lblUmumiMebleg
            // 
            this.lblUmumiMebleg.AutoSize = true;
            this.lblUmumiMebleg.Depth = 0;
            this.lblUmumiMebleg.Font = new System.Drawing.Font("Roboto", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblUmumiMebleg.FontType = MaterialSkin.MaterialSkinManager.fontType.H3;
            this.lblUmumiMebleg.Location = new System.Drawing.Point(17, 42);
            this.lblUmumiMebleg.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblUmumiMebleg.Name = "lblUmumiMebleg";
            this.lblUmumiMebleg.Size = new System.Drawing.Size(194, 58);
            this.lblUmumiMebleg.TabIndex = 0;
            this.lblUmumiMebleg.Text = "0.00 AZN";
            // 
            // pnlPaymentMethods
            // 
            this.pnlPaymentMethods.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPaymentMethods.Controls.Add(this.btnNagd);
            this.pnlPaymentMethods.Controls.Add(this.btnKart);
            this.pnlPaymentMethods.Controls.Add(this.btnNisye);
            this.pnlPaymentMethods.Location = new System.Drawing.Point(882, 17);
            this.pnlPaymentMethods.Name = "pnlPaymentMethods";
            this.pnlPaymentMethods.Size = new System.Drawing.Size(453, 73);
            this.pnlPaymentMethods.TabIndex = 2;
            // 
            // btnNagd
            // 
            this.btnNagd.AutoSize = false;
            this.btnNagd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNagd.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnNagd.Depth = 0;
            this.btnNagd.HighEmphasis = true;
            this.btnNagd.Icon = null;
            this.btnNagd.Location = new System.Drawing.Point(4, 4);
            this.btnNagd.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnNagd.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNagd.Name = "btnNagd";
            this.btnNagd.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnNagd.Size = new System.Drawing.Size(140, 60);
            this.btnNagd.TabIndex = 0;
            this.btnNagd.Text = "NAĞD (F1)";
            this.btnNagd.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnNagd.UseAccentColor = false;
            this.btnNagd.UseVisualStyleBackColor = true;
            this.btnNagd.Click += new System.EventHandler(this.btnNagd_Click);
            // 
            // btnKart
            // 
            this.btnKart.AutoSize = false;
            this.btnKart.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnKart.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnKart.Depth = 0;
            this.btnKart.HighEmphasis = true;
            this.btnKart.Icon = null;
            this.btnKart.Location = new System.Drawing.Point(152, 4);
            this.btnKart.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnKart.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnKart.Name = "btnKart";
            this.btnKart.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnKart.Size = new System.Drawing.Size(140, 60);
            this.btnKart.TabIndex = 1;
            this.btnKart.Text = "KART (F2)";
            this.btnKart.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnKart.UseAccentColor = false;
            this.btnKart.UseVisualStyleBackColor = true;
            this.btnKart.Click += new System.EventHandler(this.btnKart_Click);
            // 
            // btnNisye
            // 
            this.btnNisye.AutoSize = false;
            this.btnNisye.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNisye.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnNisye.Depth = 0;
            this.btnNisye.HighEmphasis = true;
            this.btnNisye.Icon = null;
            this.btnNisye.Location = new System.Drawing.Point(300, 4);
            this.btnNisye.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnNisye.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnNisye.Name = "btnNisye";
            this.btnNisye.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnNisye.Size = new System.Drawing.Size(140, 60);
            this.btnNisye.TabIndex = 2;
            this.btnNisye.Text = "NİSYƏ (F3)";
            this.btnNisye.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnNisye.UseAccentColor = true;
            this.btnNisye.UseVisualStyleBackColor = true;
            this.btnNisye.Click += new System.EventHandler(this.btnNisye_Click);
            // 
            // pnlAdvancedOptions
            // 
            this.pnlAdvancedOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAdvancedOptions.Controls.Add(this.cmbMusteriler);
            this.pnlAdvancedOptions.Controls.Add(this.btnSatisiGozlet);
            this.pnlAdvancedOptions.Controls.Add(this.btnGozleyenSatislar);
            this.pnlAdvancedOptions.Controls.Add(this.btnIndirim);
            this.pnlAdvancedOptions.Location = new System.Drawing.Point(17, 103);
            this.pnlAdvancedOptions.Name = "pnlAdvancedOptions";
            this.pnlAdvancedOptions.Size = new System.Drawing.Size(1318, 45);
            this.pnlAdvancedOptions.TabIndex = 3;
            // 
            // cmbMusteriler
            // 
            this.cmbMusteriler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMusteriler.AutoResize = false;
            this.cmbMusteriler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbMusteriler.Depth = 0;
            this.cmbMusteriler.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbMusteriler.DropDownHeight = 174;
            this.cmbMusteriler.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMusteriler.DropDownWidth = 121;
            this.cmbMusteriler.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cmbMusteriler.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cmbMusteriler.Hint = "Müştəri Seçin";
            this.cmbMusteriler.IntegralHeight = false;
            this.cmbMusteriler.ItemHeight = 43;
            this.cmbMusteriler.Location = new System.Drawing.Point(865, 0);
            this.cmbMusteriler.MaxDropDownItems = 4;
            this.cmbMusteriler.MouseState = MaterialSkin.MouseState.OUT;
            this.cmbMusteriler.Name = "cmbMusteriler";
            this.cmbMusteriler.Size = new System.Drawing.Size(450, 49);
            this.cmbMusteriler.StartIndex = 0;
            this.cmbMusteriler.TabIndex = 3;
            // 
            // btnSatisiGozlet
            // 
            this.btnSatisiGozlet.AutoSize = false;
            this.btnSatisiGozlet.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSatisiGozlet.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSatisiGozlet.Depth = 0;
            this.btnSatisiGozlet.HighEmphasis = false;
            this.btnSatisiGozlet.Icon = null;
            this.btnSatisiGozlet.Location = new System.Drawing.Point(4, 0);
            this.btnSatisiGozlet.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSatisiGozlet.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSatisiGozlet.Name = "btnSatisiGozlet";
            this.btnSatisiGozlet.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSatisiGozlet.Size = new System.Drawing.Size(140, 40);
            this.btnSatisiGozlet.TabIndex = 0;
            this.btnSatisiGozlet.Text = "Gözlət (F4)";
            this.btnSatisiGozlet.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnSatisiGozlet.UseAccentColor = false;
            this.btnSatisiGozlet.UseVisualStyleBackColor = true;
            this.btnSatisiGozlet.Click += new System.EventHandler(this.btnSatisiGozlet_Click);
            // 
            // btnGozleyenSatislar
            // 
            this.btnGozleyenSatislar.AutoSize = false;
            this.btnGozleyenSatislar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGozleyenSatislar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnGozleyenSatislar.Depth = 0;
            this.btnGozleyenSatislar.HighEmphasis = false;
            this.btnGozleyenSatislar.Icon = null;
            this.btnGozleyenSatislar.Location = new System.Drawing.Point(152, 0);
            this.btnGozleyenSatislar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnGozleyenSatislar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnGozleyenSatislar.Name = "btnGozleyenSatislar";
            this.btnGozleyenSatislar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnGozleyenSatislar.Size = new System.Drawing.Size(140, 40);
            this.btnGozleyenSatislar.TabIndex = 1;
            this.btnGozleyenSatislar.Text = "Gözləyənlər (F5)";
            this.btnGozleyenSatislar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnGozleyenSatislar.UseAccentColor = false;
            this.btnGozleyenSatislar.UseVisualStyleBackColor = true;
            this.btnGozleyenSatislar.Click += new System.EventHandler(this.btnGozleyenSatislar_Click);
            // 
            // btnIndirim
            // 
            this.btnIndirim.AutoSize = false;
            this.btnIndirim.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnIndirim.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnIndirim.Depth = 0;
            this.btnIndirim.HighEmphasis = false;
            this.btnIndirim.Icon = null;
            this.btnIndirim.Location = new System.Drawing.Point(300, 0);
            this.btnIndirim.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnIndirim.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnIndirim.Name = "btnIndirim";
            this.btnIndirim.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnIndirim.Size = new System.Drawing.Size(140, 40);
            this.btnIndirim.TabIndex = 2;
            this.btnIndirim.Text = "İndirim (F6)";
            this.btnIndirim.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.btnIndirim.UseAccentColor = true;
            this.btnIndirim.UseVisualStyleBackColor = true;
            // 
            // contextMenuStripGozleyenler
            // 
            this.contextMenuStripGozleyenler.Name = "contextMenuStripGozleyenler";
            this.contextMenuStripGozleyenler.Size = new System.Drawing.Size(61, 4);
            this.contextMenuStripGozleyenler.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStripGozleyenler_ItemClicked);
            // 
            // SatisFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 738);
            this.Controls.Add(this.pnlMainContainer);
            this.KeyPreview = true;
            this.Name = "SatisFormu";
            this.Padding = new System.Windows.Forms.Padding(3, 64, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yeni Satış";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SatisFormu_KeyDown);
            this.pnlMainContainer.ResumeLayout(false);
            this.pnlSearchSection.ResumeLayout(false);
            this.pnlSearchSection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAxtarisNeticeleri)).EndInit();
            this.pnlQuantityControls.ResumeLayout(false);
            this.pnlCartSection.ResumeLayout(false);
            this.pnlCartSection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSebet)).EndInit();
            this.pnlCartControls.ResumeLayout(false);
            this.pnlPaymentSection.ResumeLayout(false);
            this.pnlPaymentSection.PerformLayout();
            this.pnlPaymentMethods.ResumeLayout(false);
            this.pnlAdvancedOptions.ResumeLayout(false);
            this.ResumeLayout(false);
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