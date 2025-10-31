// Fayl: AzAgroPOS.Teqdimat/AlisSifarisFormu.Designer.cs
namespace AzAgroPOS.Teqdimat
{
    partial class AlisSifarisFormu
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

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            panelTop = new Panel();
            lblBasliq = new MaterialSkin.Controls.MaterialLabel();
            tabControl = new TabControl();
            tabSifarisler = new TabPage();
            dgvSifarisler = new DataGridView();
            tabYeniSifaris = new TabPage();
            panelYeniSifaris = new Panel();
            groupSetirler = new GroupBox();
            btnSetirSil = new MaterialSkin.Controls.MaterialButton();
            btnSetirElaveEt = new MaterialSkin.Controls.MaterialButton();
            numBirVahidQiymet = new NumericUpDown();
            lblBirVahidQiymet = new MaterialSkin.Controls.MaterialLabel();
            numMiqdar = new NumericUpDown();
            lblMiqdar = new MaterialSkin.Controls.MaterialLabel();
            cmbMehsul = new ComboBox();
            lblMehsul = new MaterialSkin.Controls.MaterialLabel();
            dgvSetirler = new DataGridView();
            groupSifarisInfo = new GroupBox();
            txtQeydler = new MaterialSkin.Controls.MaterialTextBox();
            lblQeydler = new MaterialSkin.Controls.MaterialLabel();
            cmbStatus = new ComboBox();
            lblStatus = new MaterialSkin.Controls.MaterialLabel();
            numUmumiMebleg = new NumericUpDown();
            lblUmumiMebleg = new MaterialSkin.Controls.MaterialLabel();
            dtpGozlenilenTehvilTarixi = new DateTimePicker();
            chkGozlenilenTehvil = new CheckBox();
            dtpTesdiqTarixi = new DateTimePicker();
            chkTesdiq = new CheckBox();
            cmbTedarukcu = new ComboBox();
            lblTedarukcu = new MaterialSkin.Controls.MaterialLabel();
            dtpYaradilmaTarixi = new DateTimePicker();
            lblYaradilmaTarixi = new MaterialSkin.Controls.MaterialLabel();
            txtSifarisNomresi = new MaterialSkin.Controls.MaterialTextBox();
            lblSifarisNomresi = new MaterialSkin.Controls.MaterialLabel();
            panelButtons = new Panel();
            btnTemizle = new MaterialSkin.Controls.MaterialButton();
            btnTesdiqle = new MaterialSkin.Controls.MaterialButton();
            btnSil = new MaterialSkin.Controls.MaterialButton();
            btnYenile = new MaterialSkin.Controls.MaterialButton();
            btnYarat = new MaterialSkin.Controls.MaterialButton();
            panelTop.SuspendLayout();
            tabControl.SuspendLayout();
            tabSifarisler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSifarisler).BeginInit();
            tabYeniSifaris.SuspendLayout();
            panelYeniSifaris.SuspendLayout();
            groupSetirler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numBirVahidQiymet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMiqdar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSetirler).BeginInit();
            groupSifarisInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numUmumiMebleg).BeginInit();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(242, 242, 242);
            panelTop.Controls.Add(lblBasliq);
            panelTop.Dock = DockStyle.Top;
            panelTop.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            panelTop.ForeColor = Color.FromArgb(222, 0, 0, 0);
            panelTop.Location = new Point(4, 74);
            panelTop.Margin = new Padding(4, 3, 4, 3);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1625, 69);
            panelTop.TabIndex = 0;
            // 
            // lblBasliq
            // 
            lblBasliq.AutoSize = true;
            lblBasliq.BackColor = Color.FromArgb(242, 242, 242);
            lblBasliq.Depth = 0;
            lblBasliq.Font = new Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblBasliq.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            lblBasliq.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblBasliq.Location = new Point(18, 17);
            lblBasliq.Margin = new Padding(4, 0, 4, 0);
            lblBasliq.MouseState = MaterialSkin.MouseState.HOVER;
            lblBasliq.Name = "lblBasliq";
            lblBasliq.Size = new Size(147, 29);
            lblBasliq.TabIndex = 0;
            lblBasliq.Text = "Alış Sifarişləri";
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabSifarisler);
            tabControl.Controls.Add(tabYeniSifaris);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            tabControl.ForeColor = Color.FromArgb(222, 0, 0, 0);
            tabControl.Location = new Point(4, 143);
            tabControl.Margin = new Padding(4, 3, 4, 3);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1625, 697);
            tabControl.TabIndex = 1;
            // 
            // tabSifarisler
            // 
            tabSifarisler.BackColor = Color.FromArgb(242, 242, 242);
            tabSifarisler.Controls.Add(dgvSifarisler);
            tabSifarisler.Location = new Point(4, 26);
            tabSifarisler.Margin = new Padding(4, 3, 4, 3);
            tabSifarisler.Name = "tabSifarisler";
            tabSifarisler.Padding = new Padding(12, 12, 12, 12);
            tabSifarisler.Size = new Size(1617, 667);
            tabSifarisler.TabIndex = 0;
            tabSifarisler.Text = "Sifarişlər";
            // 
            // dgvSifarisler
            // 
            dgvSifarisler.AllowUserToAddRows = false;
            dgvSifarisler.AllowUserToDeleteRows = false;
            dgvSifarisler.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvSifarisler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvSifarisler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvSifarisler.DefaultCellStyle = dataGridViewCellStyle2;
            dgvSifarisler.Dock = DockStyle.Fill;
            dgvSifarisler.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvSifarisler.Location = new Point(12, 12);
            dgvSifarisler.Margin = new Padding(4, 3, 4, 3);
            dgvSifarisler.MultiSelect = false;
            dgvSifarisler.Name = "dgvSifarisler";
            dgvSifarisler.ReadOnly = true;
            dgvSifarisler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSifarisler.Size = new Size(1593, 643);
            dgvSifarisler.TabIndex = 0;
            dgvSifarisler.SelectionChanged += dgvSifarisler_SelectionChanged;
            // 
            // tabYeniSifaris
            // 
            tabYeniSifaris.BackColor = Color.FromArgb(242, 242, 242);
            tabYeniSifaris.Controls.Add(panelYeniSifaris);
            tabYeniSifaris.Location = new Point(4, 26);
            tabYeniSifaris.Margin = new Padding(4, 3, 4, 3);
            tabYeniSifaris.Name = "tabYeniSifaris";
            tabYeniSifaris.Padding = new Padding(12, 12, 12, 12);
            tabYeniSifaris.Size = new Size(1617, 667);
            tabYeniSifaris.TabIndex = 1;
            tabYeniSifaris.Text = "Yeni Sifariş / Redaktə";
            // 
            // panelYeniSifaris
            // 
            panelYeniSifaris.BackColor = Color.FromArgb(242, 242, 242);
            panelYeniSifaris.Controls.Add(groupSetirler);
            panelYeniSifaris.Controls.Add(groupSifarisInfo);
            panelYeniSifaris.Dock = DockStyle.Fill;
            panelYeniSifaris.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            panelYeniSifaris.ForeColor = Color.FromArgb(222, 0, 0, 0);
            panelYeniSifaris.Location = new Point(12, 12);
            panelYeniSifaris.Margin = new Padding(4, 3, 4, 3);
            panelYeniSifaris.Name = "panelYeniSifaris";
            panelYeniSifaris.Size = new Size(1593, 643);
            panelYeniSifaris.TabIndex = 0;
            // 
            // groupSetirler
            // 
            groupSetirler.BackColor = Color.FromArgb(242, 242, 242);
            groupSetirler.Controls.Add(btnSetirSil);
            groupSetirler.Controls.Add(btnSetirElaveEt);
            groupSetirler.Controls.Add(numBirVahidQiymet);
            groupSetirler.Controls.Add(lblBirVahidQiymet);
            groupSetirler.Controls.Add(numMiqdar);
            groupSetirler.Controls.Add(lblMiqdar);
            groupSetirler.Controls.Add(cmbMehsul);
            groupSetirler.Controls.Add(lblMehsul);
            groupSetirler.Controls.Add(dgvSetirler);
            groupSetirler.Dock = DockStyle.Fill;
            groupSetirler.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            groupSetirler.ForeColor = Color.FromArgb(222, 0, 0, 0);
            groupSetirler.Location = new Point(0, 254);
            groupSetirler.Margin = new Padding(4, 3, 4, 3);
            groupSetirler.Name = "groupSetirler";
            groupSetirler.Padding = new Padding(12, 12, 12, 12);
            groupSetirler.Size = new Size(1593, 389);
            groupSetirler.TabIndex = 1;
            groupSetirler.TabStop = false;
            groupSetirler.Text = "Sifariş Sətirləri";
            // 
            // btnSetirSil
            // 
            btnSetirSil.AutoSize = false;
            btnSetirSil.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSetirSil.BackColor = Color.FromArgb(242, 242, 242);
            btnSetirSil.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSetirSil.Depth = 0;
            btnSetirSil.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnSetirSil.HighEmphasis = true;
            btnSetirSil.Icon = null;
            btnSetirSil.Location = new Point(1435, 69);
            btnSetirSil.Margin = new Padding(5, 7, 5, 7);
            btnSetirSil.MouseState = MaterialSkin.MouseState.HOVER;
            btnSetirSil.Name = "btnSetirSil";
            btnSetirSil.NoAccentTextColor = Color.Empty;
            btnSetirSil.Size = new Size(140, 42);
            btnSetirSil.TabIndex = 8;
            btnSetirSil.Text = "SƏTİRİ SİL";
            btnSetirSil.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSetirSil.UseAccentColor = false;
            btnSetirSil.UseVisualStyleBackColor = false;
            btnSetirSil.Click += btnSetirSil_Click;
            // 
            // btnSetirElaveEt
            // 
            btnSetirElaveEt.AutoSize = false;
            btnSetirElaveEt.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSetirElaveEt.BackColor = Color.FromArgb(242, 242, 242);
            btnSetirElaveEt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSetirElaveEt.Depth = 0;
            btnSetirElaveEt.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnSetirElaveEt.HighEmphasis = true;
            btnSetirElaveEt.Icon = null;
            btnSetirElaveEt.Location = new Point(1260, 69);
            btnSetirElaveEt.Margin = new Padding(5, 7, 5, 7);
            btnSetirElaveEt.MouseState = MaterialSkin.MouseState.HOVER;
            btnSetirElaveEt.Name = "btnSetirElaveEt";
            btnSetirElaveEt.NoAccentTextColor = Color.Empty;
            btnSetirElaveEt.Size = new Size(163, 42);
            btnSetirElaveEt.TabIndex = 7;
            btnSetirElaveEt.Text = "SƏTİR ƏLAVƏ ET";
            btnSetirElaveEt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSetirElaveEt.UseAccentColor = false;
            btnSetirElaveEt.UseVisualStyleBackColor = false;
            btnSetirElaveEt.Click += btnSetirElaveEt_Click;
            // 
            // numBirVahidQiymet
            // 
            numBirVahidQiymet.BackColor = Color.FromArgb(242, 242, 242);
            numBirVahidQiymet.DecimalPlaces = 2;
            numBirVahidQiymet.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            numBirVahidQiymet.ForeColor = Color.FromArgb(222, 0, 0, 0);
            numBirVahidQiymet.Location = new Point(1015, 77);
            numBirVahidQiymet.Margin = new Padding(4, 3, 4, 3);
            numBirVahidQiymet.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numBirVahidQiymet.Name = "numBirVahidQiymet";
            numBirVahidQiymet.Size = new Size(233, 24);
            numBirVahidQiymet.TabIndex = 6;
            numBirVahidQiymet.ThousandsSeparator = true;
            // 
            // lblBirVahidQiymet
            // 
            lblBirVahidQiymet.AutoSize = true;
            lblBirVahidQiymet.BackColor = Color.FromArgb(242, 242, 242);
            lblBirVahidQiymet.Depth = 0;
            lblBirVahidQiymet.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblBirVahidQiymet.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblBirVahidQiymet.Location = new Point(1015, 48);
            lblBirVahidQiymet.Margin = new Padding(4, 0, 4, 0);
            lblBirVahidQiymet.MouseState = MaterialSkin.MouseState.HOVER;
            lblBirVahidQiymet.Name = "lblBirVahidQiymet";
            lblBirVahidQiymet.Size = new Size(123, 19);
            lblBirVahidQiymet.TabIndex = 5;
            lblBirVahidQiymet.Text = "Bir Vahid Qiymət:";
            // 
            // numMiqdar
            // 
            numMiqdar.BackColor = Color.FromArgb(242, 242, 242);
            numMiqdar.DecimalPlaces = 2;
            numMiqdar.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            numMiqdar.ForeColor = Color.FromArgb(222, 0, 0, 0);
            numMiqdar.Location = new Point(712, 77);
            numMiqdar.Margin = new Padding(4, 3, 4, 3);
            numMiqdar.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numMiqdar.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numMiqdar.Name = "numMiqdar";
            numMiqdar.Size = new Size(292, 24);
            numMiqdar.TabIndex = 4;
            numMiqdar.ThousandsSeparator = true;
            numMiqdar.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblMiqdar
            // 
            lblMiqdar.AutoSize = true;
            lblMiqdar.BackColor = Color.FromArgb(242, 242, 242);
            lblMiqdar.Depth = 0;
            lblMiqdar.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblMiqdar.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblMiqdar.Location = new Point(712, 48);
            lblMiqdar.Margin = new Padding(4, 0, 4, 0);
            lblMiqdar.MouseState = MaterialSkin.MouseState.HOVER;
            lblMiqdar.Name = "lblMiqdar";
            lblMiqdar.Size = new Size(55, 19);
            lblMiqdar.TabIndex = 3;
            lblMiqdar.Text = "Miqdar:";
            // 
            // cmbMehsul
            // 
            cmbMehsul.BackColor = Color.FromArgb(242, 242, 242);
            cmbMehsul.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMehsul.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            cmbMehsul.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbMehsul.FormattingEnabled = true;
            cmbMehsul.Location = new Point(23, 77);
            cmbMehsul.Margin = new Padding(4, 3, 4, 3);
            cmbMehsul.Name = "cmbMehsul";
            cmbMehsul.Size = new Size(676, 25);
            cmbMehsul.TabIndex = 2;
            // 
            // lblMehsul
            // 
            lblMehsul.AutoSize = true;
            lblMehsul.BackColor = Color.FromArgb(242, 242, 242);
            lblMehsul.Depth = 0;
            lblMehsul.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblMehsul.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblMehsul.Location = new Point(23, 48);
            lblMehsul.Margin = new Padding(4, 0, 4, 0);
            lblMehsul.MouseState = MaterialSkin.MouseState.HOVER;
            lblMehsul.Name = "lblMehsul";
            lblMehsul.Size = new Size(57, 19);
            lblMehsul.TabIndex = 1;
            lblMehsul.Text = "Məhsul:";
            // 
            // dgvSetirler
            // 
            dgvSetirler.AllowUserToAddRows = false;
            dgvSetirler.AllowUserToDeleteRows = false;
            dgvSetirler.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSetirler.BackgroundColor = Color.White;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvSetirler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvSetirler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvSetirler.DefaultCellStyle = dataGridViewCellStyle4;
            dgvSetirler.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvSetirler.Location = new Point(15, 127);
            dgvSetirler.Margin = new Padding(4, 3, 4, 3);
            dgvSetirler.MultiSelect = false;
            dgvSetirler.Name = "dgvSetirler";
            dgvSetirler.ReadOnly = true;
            dgvSetirler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSetirler.Size = new Size(1562, 247);
            dgvSetirler.TabIndex = 0;
            // 
            // groupSifarisInfo
            // 
            groupSifarisInfo.BackColor = Color.FromArgb(242, 242, 242);
            groupSifarisInfo.Controls.Add(txtQeydler);
            groupSifarisInfo.Controls.Add(lblQeydler);
            groupSifarisInfo.Controls.Add(cmbStatus);
            groupSifarisInfo.Controls.Add(lblStatus);
            groupSifarisInfo.Controls.Add(numUmumiMebleg);
            groupSifarisInfo.Controls.Add(lblUmumiMebleg);
            groupSifarisInfo.Controls.Add(dtpGozlenilenTehvilTarixi);
            groupSifarisInfo.Controls.Add(chkGozlenilenTehvil);
            groupSifarisInfo.Controls.Add(dtpTesdiqTarixi);
            groupSifarisInfo.Controls.Add(chkTesdiq);
            groupSifarisInfo.Controls.Add(cmbTedarukcu);
            groupSifarisInfo.Controls.Add(lblTedarukcu);
            groupSifarisInfo.Controls.Add(dtpYaradilmaTarixi);
            groupSifarisInfo.Controls.Add(lblYaradilmaTarixi);
            groupSifarisInfo.Controls.Add(txtSifarisNomresi);
            groupSifarisInfo.Controls.Add(lblSifarisNomresi);
            groupSifarisInfo.Dock = DockStyle.Top;
            groupSifarisInfo.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            groupSifarisInfo.ForeColor = Color.FromArgb(222, 0, 0, 0);
            groupSifarisInfo.Location = new Point(0, 0);
            groupSifarisInfo.Margin = new Padding(4, 3, 4, 3);
            groupSifarisInfo.Name = "groupSifarisInfo";
            groupSifarisInfo.Padding = new Padding(12, 12, 12, 12);
            groupSifarisInfo.Size = new Size(1593, 254);
            groupSifarisInfo.TabIndex = 0;
            groupSifarisInfo.TabStop = false;
            groupSifarisInfo.Text = "Sifariş Məlumatları";
            // 
            // txtQeydler
            // 
            txtQeydler.AnimateReadOnly = false;
            txtQeydler.BackColor = Color.FromArgb(242, 242, 242);
            txtQeydler.BorderStyle = BorderStyle.None;
            txtQeydler.Depth = 0;
            txtQeydler.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtQeydler.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtQeydler.LeadingIcon = null;
            txtQeydler.Location = new Point(23, 173);
            txtQeydler.Margin = new Padding(4, 3, 4, 3);
            txtQeydler.MaxLength = 500;
            txtQeydler.MouseState = MaterialSkin.MouseState.OUT;
            txtQeydler.Multiline = false;
            txtQeydler.Name = "txtQeydler";
            txtQeydler.Size = new Size(793, 50);
            txtQeydler.TabIndex = 15;
            txtQeydler.Text = "";
            txtQeydler.TrailingIcon = null;
            // 
            // lblQeydler
            // 
            lblQeydler.AutoSize = true;
            lblQeydler.BackColor = Color.FromArgb(242, 242, 242);
            lblQeydler.Depth = 0;
            lblQeydler.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblQeydler.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblQeydler.Location = new Point(23, 144);
            lblQeydler.Margin = new Padding(4, 0, 4, 0);
            lblQeydler.MouseState = MaterialSkin.MouseState.HOVER;
            lblQeydler.Name = "lblQeydler";
            lblQeydler.Size = new Size(58, 19);
            lblQeydler.TabIndex = 14;
            lblQeydler.Text = "Qeydlər:";
            // 
            // cmbStatus
            // 
            cmbStatus.BackColor = Color.FromArgb(242, 242, 242);
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Enabled = false;
            cmbStatus.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            cmbStatus.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(1283, 173);
            cmbStatus.Margin = new Padding(4, 3, 4, 3);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(291, 25);
            cmbStatus.TabIndex = 13;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.BackColor = Color.FromArgb(242, 242, 242);
            lblStatus.Depth = 0;
            lblStatus.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblStatus.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblStatus.Location = new Point(1283, 144);
            lblStatus.Margin = new Padding(4, 0, 4, 0);
            lblStatus.MouseState = MaterialSkin.MouseState.HOVER;
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(51, 19);
            lblStatus.TabIndex = 12;
            lblStatus.Text = "Status:";
            // 
            // numUmumiMebleg
            // 
            numUmumiMebleg.BackColor = Color.FromArgb(242, 242, 242);
            numUmumiMebleg.DecimalPlaces = 2;
            numUmumiMebleg.Enabled = false;
            numUmumiMebleg.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            numUmumiMebleg.ForeColor = Color.FromArgb(222, 0, 0, 0);
            numUmumiMebleg.Location = new Point(840, 173);
            numUmumiMebleg.Margin = new Padding(4, 3, 4, 3);
            numUmumiMebleg.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numUmumiMebleg.Name = "numUmumiMebleg";
            numUmumiMebleg.Size = new Size(420, 24);
            numUmumiMebleg.TabIndex = 11;
            numUmumiMebleg.ThousandsSeparator = true;
            // 
            // lblUmumiMebleg
            // 
            lblUmumiMebleg.AutoSize = true;
            lblUmumiMebleg.BackColor = Color.FromArgb(242, 242, 242);
            lblUmumiMebleg.Depth = 0;
            lblUmumiMebleg.Font = new Font("Roboto", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblUmumiMebleg.FontType = MaterialSkin.MaterialSkinManager.fontType.Button;
            lblUmumiMebleg.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblUmumiMebleg.Location = new Point(840, 144);
            lblUmumiMebleg.Margin = new Padding(4, 0, 4, 0);
            lblUmumiMebleg.MouseState = MaterialSkin.MouseState.HOVER;
            lblUmumiMebleg.Name = "lblUmumiMebleg";
            lblUmumiMebleg.Size = new Size(113, 17);
            lblUmumiMebleg.TabIndex = 10;
            lblUmumiMebleg.Text = "ÜMUMİ MƏBLƏĞ:";
            // 
            // dtpGozlenilenTehvilTarixi
            // 
            dtpGozlenilenTehvilTarixi.BackColor = Color.FromArgb(242, 242, 242);
            dtpGozlenilenTehvilTarixi.Enabled = false;
            dtpGozlenilenTehvilTarixi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dtpGozlenilenTehvilTarixi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dtpGozlenilenTehvilTarixi.Format = DateTimePickerFormat.Short;
            dtpGozlenilenTehvilTarixi.Location = new Point(1283, 98);
            dtpGozlenilenTehvilTarixi.Margin = new Padding(4, 3, 4, 3);
            dtpGozlenilenTehvilTarixi.Name = "dtpGozlenilenTehvilTarixi";
            dtpGozlenilenTehvilTarixi.Size = new Size(291, 24);
            dtpGozlenilenTehvilTarixi.TabIndex = 9;
            // 
            // chkGozlenilenTehvil
            // 
            chkGozlenilenTehvil.AutoSize = true;
            chkGozlenilenTehvil.BackColor = Color.FromArgb(242, 242, 242);
            chkGozlenilenTehvil.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            chkGozlenilenTehvil.ForeColor = Color.FromArgb(222, 0, 0, 0);
            chkGozlenilenTehvil.Location = new Point(1283, 69);
            chkGozlenilenTehvil.Margin = new Padding(4, 3, 4, 3);
            chkGozlenilenTehvil.Name = "chkGozlenilenTehvil";
            chkGozlenilenTehvil.Size = new Size(166, 21);
            chkGozlenilenTehvil.TabIndex = 8;
            chkGozlenilenTehvil.Text = "Gözlənilən Təhvil Tarixi";
            chkGozlenilenTehvil.UseVisualStyleBackColor = false;
            chkGozlenilenTehvil.CheckedChanged += chkGozlenilenTehvil_CheckedChanged;
            // 
            // dtpTesdiqTarixi
            // 
            dtpTesdiqTarixi.BackColor = Color.FromArgb(242, 242, 242);
            dtpTesdiqTarixi.Enabled = false;
            dtpTesdiqTarixi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dtpTesdiqTarixi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dtpTesdiqTarixi.Format = DateTimePickerFormat.Short;
            dtpTesdiqTarixi.Location = new Point(840, 98);
            dtpTesdiqTarixi.Margin = new Padding(4, 3, 4, 3);
            dtpTesdiqTarixi.Name = "dtpTesdiqTarixi";
            dtpTesdiqTarixi.Size = new Size(419, 24);
            dtpTesdiqTarixi.TabIndex = 7;
            // 
            // chkTesdiq
            // 
            chkTesdiq.AutoSize = true;
            chkTesdiq.BackColor = Color.FromArgb(242, 242, 242);
            chkTesdiq.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            chkTesdiq.ForeColor = Color.FromArgb(222, 0, 0, 0);
            chkTesdiq.Location = new Point(840, 69);
            chkTesdiq.Margin = new Padding(4, 3, 4, 3);
            chkTesdiq.Name = "chkTesdiq";
            chkTesdiq.Size = new Size(104, 21);
            chkTesdiq.TabIndex = 6;
            chkTesdiq.Text = "Təsdiq Tarixi";
            chkTesdiq.UseVisualStyleBackColor = false;
            chkTesdiq.CheckedChanged += chkTesdiq_CheckedChanged;
            // 
            // cmbTedarukcu
            // 
            cmbTedarukcu.BackColor = Color.FromArgb(242, 242, 242);
            cmbTedarukcu.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTedarukcu.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            cmbTedarukcu.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbTedarukcu.FormattingEnabled = true;
            cmbTedarukcu.Location = new Point(420, 98);
            cmbTedarukcu.Margin = new Padding(4, 3, 4, 3);
            cmbTedarukcu.Name = "cmbTedarukcu";
            cmbTedarukcu.Size = new Size(396, 25);
            cmbTedarukcu.TabIndex = 5;
            // 
            // lblTedarukcu
            // 
            lblTedarukcu.AutoSize = true;
            lblTedarukcu.BackColor = Color.FromArgb(242, 242, 242);
            lblTedarukcu.Depth = 0;
            lblTedarukcu.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblTedarukcu.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblTedarukcu.Location = new Point(420, 69);
            lblTedarukcu.Margin = new Padding(4, 0, 4, 0);
            lblTedarukcu.MouseState = MaterialSkin.MouseState.HOVER;
            lblTedarukcu.Name = "lblTedarukcu";
            lblTedarukcu.Size = new Size(80, 19);
            lblTedarukcu.TabIndex = 4;
            lblTedarukcu.Text = "Tədarükçü:";
            // 
            // dtpYaradilmaTarixi
            // 
            dtpYaradilmaTarixi.BackColor = Color.FromArgb(242, 242, 242);
            dtpYaradilmaTarixi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dtpYaradilmaTarixi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dtpYaradilmaTarixi.Format = DateTimePickerFormat.Short;
            dtpYaradilmaTarixi.Location = new Point(23, 98);
            dtpYaradilmaTarixi.Margin = new Padding(4, 3, 4, 3);
            dtpYaradilmaTarixi.Name = "dtpYaradilmaTarixi";
            dtpYaradilmaTarixi.Size = new Size(373, 24);
            dtpYaradilmaTarixi.TabIndex = 3;
            // 
            // lblYaradilmaTarixi
            // 
            lblYaradilmaTarixi.AutoSize = true;
            lblYaradilmaTarixi.BackColor = Color.FromArgb(242, 242, 242);
            lblYaradilmaTarixi.Depth = 0;
            lblYaradilmaTarixi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblYaradilmaTarixi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblYaradilmaTarixi.Location = new Point(23, 69);
            lblYaradilmaTarixi.Margin = new Padding(4, 0, 4, 0);
            lblYaradilmaTarixi.MouseState = MaterialSkin.MouseState.HOVER;
            lblYaradilmaTarixi.Name = "lblYaradilmaTarixi";
            lblYaradilmaTarixi.Size = new Size(122, 19);
            lblYaradilmaTarixi.TabIndex = 2;
            lblYaradilmaTarixi.Text = "Yaradılma Tarixi:";
            // 
            // txtSifarisNomresi
            // 
            txtSifarisNomresi.AnimateReadOnly = false;
            txtSifarisNomresi.BackColor = Color.FromArgb(242, 242, 242);
            txtSifarisNomresi.BorderStyle = BorderStyle.None;
            txtSifarisNomresi.Depth = 0;
            txtSifarisNomresi.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtSifarisNomresi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            txtSifarisNomresi.LeadingIcon = null;
            txtSifarisNomresi.Location = new Point(840, 23);
            txtSifarisNomresi.Margin = new Padding(4, 3, 4, 3);
            txtSifarisNomresi.MaxLength = 50;
            txtSifarisNomresi.MouseState = MaterialSkin.MouseState.OUT;
            txtSifarisNomresi.Multiline = false;
            txtSifarisNomresi.Name = "txtSifarisNomresi";
            txtSifarisNomresi.Size = new Size(735, 50);
            txtSifarisNomresi.TabIndex = 1;
            txtSifarisNomresi.Text = "";
            txtSifarisNomresi.TrailingIcon = null;
            // 
            // lblSifarisNomresi
            // 
            lblSifarisNomresi.AutoSize = true;
            lblSifarisNomresi.BackColor = Color.FromArgb(242, 242, 242);
            lblSifarisNomresi.Depth = 0;
            lblSifarisNomresi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblSifarisNomresi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblSifarisNomresi.Location = new Point(840, -6);
            lblSifarisNomresi.Margin = new Padding(4, 0, 4, 0);
            lblSifarisNomresi.MouseState = MaterialSkin.MouseState.HOVER;
            lblSifarisNomresi.Name = "lblSifarisNomresi";
            lblSifarisNomresi.Size = new Size(114, 19);
            lblSifarisNomresi.TabIndex = 0;
            lblSifarisNomresi.Text = "Sifariş Nömrəsi:";
            // 
            // panelButtons
            // 
            panelButtons.BackColor = Color.FromArgb(242, 242, 242);
            panelButtons.Controls.Add(btnTemizle);
            panelButtons.Controls.Add(btnTesdiqle);
            panelButtons.Controls.Add(btnSil);
            panelButtons.Controls.Add(btnYenile);
            panelButtons.Controls.Add(btnYarat);
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            panelButtons.ForeColor = Color.FromArgb(222, 0, 0, 0);
            panelButtons.Location = new Point(4, 840);
            panelButtons.Margin = new Padding(4, 3, 4, 3);
            panelButtons.Name = "panelButtons";
            panelButtons.Padding = new Padding(12, 12, 12, 12);
            panelButtons.Size = new Size(1625, 69);
            panelButtons.TabIndex = 2;
            // 
            // btnTemizle
            // 
            btnTemizle.AutoSize = false;
            btnTemizle.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnTemizle.BackColor = Color.FromArgb(242, 242, 242);
            btnTemizle.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnTemizle.Depth = 0;
            btnTemizle.Dock = DockStyle.Right;
            btnTemizle.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnTemizle.HighEmphasis = true;
            btnTemizle.Icon = null;
            btnTemizle.Location = new Point(1444, 12);
            btnTemizle.Margin = new Padding(5, 7, 5, 7);
            btnTemizle.MouseState = MaterialSkin.MouseState.HOVER;
            btnTemizle.Name = "btnTemizle";
            btnTemizle.NoAccentTextColor = Color.Empty;
            btnTemizle.Size = new Size(169, 45);
            btnTemizle.TabIndex = 4;
            btnTemizle.Text = "TƏMİZLƏ";
            btnTemizle.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnTemizle.UseAccentColor = false;
            btnTemizle.UseVisualStyleBackColor = false;
            btnTemizle.Click += btnTemizle_Click;
            // 
            // btnTesdiqle
            // 
            btnTesdiqle.AutoSize = false;
            btnTesdiqle.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnTesdiqle.BackColor = Color.FromArgb(242, 242, 242);
            btnTesdiqle.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnTesdiqle.Depth = 0;
            btnTesdiqle.Dock = DockStyle.Left;
            btnTesdiqle.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnTesdiqle.HighEmphasis = true;
            btnTesdiqle.Icon = null;
            btnTesdiqle.Location = new Point(537, 12);
            btnTesdiqle.Margin = new Padding(5, 7, 5, 7);
            btnTesdiqle.MouseState = MaterialSkin.MouseState.HOVER;
            btnTesdiqle.Name = "btnTesdiqle";
            btnTesdiqle.NoAccentTextColor = Color.Empty;
            btnTesdiqle.Size = new Size(175, 45);
            btnTesdiqle.TabIndex = 3;
            btnTesdiqle.Text = "TƏSDİQLƏ";
            btnTesdiqle.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnTesdiqle.UseAccentColor = false;
            btnTesdiqle.UseVisualStyleBackColor = false;
            btnTesdiqle.Click += btnTesdiqle_Click;
            // 
            // btnSil
            // 
            btnSil.AutoSize = false;
            btnSil.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnSil.BackColor = Color.FromArgb(242, 242, 242);
            btnSil.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnSil.Depth = 0;
            btnSil.Dock = DockStyle.Left;
            btnSil.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnSil.HighEmphasis = true;
            btnSil.Icon = null;
            btnSil.Location = new Point(362, 12);
            btnSil.Margin = new Padding(5, 7, 5, 7);
            btnSil.MouseState = MaterialSkin.MouseState.HOVER;
            btnSil.Name = "btnSil";
            btnSil.NoAccentTextColor = Color.Empty;
            btnSil.Size = new Size(175, 45);
            btnSil.TabIndex = 2;
            btnSil.Text = "SİL";
            btnSil.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnSil.UseAccentColor = false;
            btnSil.UseVisualStyleBackColor = false;
            btnSil.Click += btnSil_Click;
            // 
            // btnYenile
            // 
            btnYenile.AutoSize = false;
            btnYenile.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnYenile.BackColor = Color.FromArgb(242, 242, 242);
            btnYenile.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnYenile.Depth = 0;
            btnYenile.Dock = DockStyle.Left;
            btnYenile.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnYenile.HighEmphasis = true;
            btnYenile.Icon = null;
            btnYenile.Location = new Point(187, 12);
            btnYenile.Margin = new Padding(5, 7, 5, 7);
            btnYenile.MouseState = MaterialSkin.MouseState.HOVER;
            btnYenile.Name = "btnYenile";
            btnYenile.NoAccentTextColor = Color.Empty;
            btnYenile.Size = new Size(175, 45);
            btnYenile.TabIndex = 1;
            btnYenile.Text = "YENİLƏ";
            btnYenile.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnYenile.UseAccentColor = false;
            btnYenile.UseVisualStyleBackColor = false;
            btnYenile.Click += btnYenile_Click;
            // 
            // btnYarat
            // 
            btnYarat.AutoSize = false;
            btnYarat.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnYarat.BackColor = Color.FromArgb(242, 242, 242);
            btnYarat.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnYarat.Depth = 0;
            btnYarat.Dock = DockStyle.Left;
            btnYarat.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnYarat.HighEmphasis = true;
            btnYarat.Icon = null;
            btnYarat.Location = new Point(12, 12);
            btnYarat.Margin = new Padding(5, 7, 5, 7);
            btnYarat.MouseState = MaterialSkin.MouseState.HOVER;
            btnYarat.Name = "btnYarat";
            btnYarat.NoAccentTextColor = Color.Empty;
            btnYarat.Size = new Size(175, 45);
            btnYarat.TabIndex = 0;
            btnYarat.Text = "YARAT";
            btnYarat.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnYarat.UseAccentColor = false;
            btnYarat.UseVisualStyleBackColor = false;
            btnYarat.Click += btnYarat_Click;
            // 
            // AlisSifarisFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1633, 912);
            Controls.Add(tabControl);
            Controls.Add(panelButtons);
            Controls.Add(panelTop);
            Margin = new Padding(4, 3, 4, 3);
            Name = "AlisSifarisFormu";
            Padding = new Padding(4, 74, 4, 3);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Alış Sifarişləri";
            Controls.SetChildIndex(panelTop, 0);
            Controls.SetChildIndex(panelButtons, 0);
            Controls.SetChildIndex(tabControl, 0);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            tabControl.ResumeLayout(false);
            tabSifarisler.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSifarisler).EndInit();
            tabYeniSifaris.ResumeLayout(false);
            panelYeniSifaris.ResumeLayout(false);
            groupSetirler.ResumeLayout(false);
            groupSetirler.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numBirVahidQiymet).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMiqdar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSetirler).EndInit();
            groupSifarisInfo.ResumeLayout(false);
            groupSifarisInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numUmumiMebleg).EndInit();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private MaterialSkin.Controls.MaterialLabel lblBasliq;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabSifarisler;
        private System.Windows.Forms.DataGridView dgvSifarisler;
        private System.Windows.Forms.TabPage tabYeniSifaris;
        private System.Windows.Forms.Panel panelYeniSifaris;
        private System.Windows.Forms.GroupBox groupSifarisInfo;
        private System.Windows.Forms.GroupBox groupSetirler;
        private System.Windows.Forms.DataGridView dgvSetirler;
        private MaterialSkin.Controls.MaterialTextBox txtSifarisNomresi;
        private MaterialSkin.Controls.MaterialLabel lblSifarisNomresi;
        private System.Windows.Forms.DateTimePicker dtpYaradilmaTarixi;
        private MaterialSkin.Controls.MaterialLabel lblYaradilmaTarixi;
        private System.Windows.Forms.ComboBox cmbTedarukcu;
        private MaterialSkin.Controls.MaterialLabel lblTedarukcu;
        private System.Windows.Forms.CheckBox chkTesdiq;
        private System.Windows.Forms.DateTimePicker dtpTesdiqTarixi;
        private System.Windows.Forms.CheckBox chkGozlenilenTehvil;
        private System.Windows.Forms.DateTimePicker dtpGozlenilenTehvilTarixi;
        private System.Windows.Forms.NumericUpDown numUmumiMebleg;
        private MaterialSkin.Controls.MaterialLabel lblUmumiMebleg;
        private System.Windows.Forms.ComboBox cmbStatus;
        private MaterialSkin.Controls.MaterialLabel lblStatus;
        private MaterialSkin.Controls.MaterialTextBox txtQeydler;
        private MaterialSkin.Controls.MaterialLabel lblQeydler;
        private System.Windows.Forms.ComboBox cmbMehsul;
        private MaterialSkin.Controls.MaterialLabel lblMehsul;
        private System.Windows.Forms.NumericUpDown numMiqdar;
        private MaterialSkin.Controls.MaterialLabel lblMiqdar;
        private System.Windows.Forms.NumericUpDown numBirVahidQiymet;
        private MaterialSkin.Controls.MaterialLabel lblBirVahidQiymet;
        private MaterialSkin.Controls.MaterialButton btnSetirElaveEt;
        private MaterialSkin.Controls.MaterialButton btnSetirSil;
        private System.Windows.Forms.Panel panelButtons;
        private MaterialSkin.Controls.MaterialButton btnYarat;
        private MaterialSkin.Controls.MaterialButton btnYenile;
        private MaterialSkin.Controls.MaterialButton btnSil;
        private MaterialSkin.Controls.MaterialButton btnTesdiqle;
        private MaterialSkin.Controls.MaterialButton btnTemizle;
    }
}
