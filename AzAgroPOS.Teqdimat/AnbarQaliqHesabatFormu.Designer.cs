// Fayl: AzAgroPOS.Teqdimat/AnbarQaliqHesabatFormu.Designer.cs
namespace AzAgroPOS.Teqdimat
{
    partial class AnbarQaliqHesabatFormu
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            pnlFiltr = new Panel();
            lblLimit = new MaterialSkin.Controls.MaterialLabel();
            txtLimit = new MaterialSkin.Controls.MaterialTextBox2();
            lblKateqoriya = new MaterialSkin.Controls.MaterialLabel();
            cmbKateqoriya = new MaterialSkin.Controls.MaterialComboBox();
            chkYalnizTukenenleri = new MaterialSkin.Controls.MaterialCheckbox();
            btnGoster = new MaterialSkin.Controls.MaterialButton();
            pnlXulase = new Panel();
            pnlMehsulSayi = new Panel();
            lblMehsulSayiBasliq = new Label();
            lblMehsulSayiDeyer = new Label();
            pnlUmumiDeger = new Panel();
            lblUmumiDegerBasliq = new Label();
            lblUmumiDegerDeyer = new Label();
            pnlKritikSay = new Panel();
            lblKritikSayBasliq = new Label();
            lblKritikSayDeyer = new Label();
            pnlTukenmisSay = new Panel();
            lblTukenmisSayBasliq = new Label();
            lblTukenmisSayDeyer = new Label();
            pnlContent = new Panel();
            dgvHesabat = new DataGridView();
            lblMesaj = new MaterialSkin.Controls.MaterialLabel();
            pnlButtons = new Panel();
            btnExcelIxrac = new MaterialSkin.Controls.MaterialButton();
            pnlFiltr.SuspendLayout();
            pnlXulase.SuspendLayout();
            pnlMehsulSayi.SuspendLayout();
            pnlUmumiDeger.SuspendLayout();
            pnlKritikSay.SuspendLayout();
            pnlTukenmisSay.SuspendLayout();
            pnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHesabat).BeginInit();
            pnlButtons.SuspendLayout();
            SuspendLayout();
            // 
            // pnlFiltr
            // 
            pnlFiltr.BackColor = Color.FromArgb(242, 242, 242);
            pnlFiltr.Controls.Add(lblLimit);
            pnlFiltr.Controls.Add(txtLimit);
            pnlFiltr.Controls.Add(lblKateqoriya);
            pnlFiltr.Controls.Add(cmbKateqoriya);
            pnlFiltr.Controls.Add(chkYalnizTukenenleri);
            pnlFiltr.Controls.Add(btnGoster);
            pnlFiltr.Dock = DockStyle.Top;
            pnlFiltr.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlFiltr.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlFiltr.Location = new Point(3, 64);
            pnlFiltr.Name = "pnlFiltr";
            pnlFiltr.Padding = new Padding(15, 10, 15, 10);
            pnlFiltr.Size = new Size(1194, 70);
            pnlFiltr.TabIndex = 3;
            // 
            // lblLimit
            // 
            lblLimit.AutoSize = true;
            lblLimit.BackColor = Color.FromArgb(242, 242, 242);
            lblLimit.Depth = 0;
            lblLimit.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblLimit.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblLimit.Location = new Point(18, 25);
            lblLimit.MouseState = MaterialSkin.MouseState.HOVER;
            lblLimit.Name = "lblLimit";
            lblLimit.Size = new Size(74, 19);
            lblLimit.TabIndex = 0;
            lblLimit.Text = "Limit sayı:";
            // 
            // txtLimit
            // 
            txtLimit.AnimateReadOnly = false;
            txtLimit.BackColor = Color.FromArgb(242, 242, 242);
            txtLimit.BackgroundImageLayout = ImageLayout.None;
            txtLimit.CharacterCasing = CharacterCasing.Normal;
            txtLimit.Depth = 0;
            txtLimit.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtLimit.HideSelection = true;
            txtLimit.Hint = "Limit";
            txtLimit.LeadingIcon = null;
            txtLimit.Location = new Point(95, 12);
            txtLimit.MaxLength = 10;
            txtLimit.MouseState = MaterialSkin.MouseState.OUT;
            txtLimit.Name = "txtLimit";
            txtLimit.PasswordChar = '\0';
            txtLimit.PrefixSuffixText = null;
            txtLimit.ReadOnly = false;
            txtLimit.RightToLeft = RightToLeft.No;
            txtLimit.SelectedText = "";
            txtLimit.SelectionLength = 0;
            txtLimit.SelectionStart = 0;
            txtLimit.ShortcutsEnabled = true;
            txtLimit.Size = new Size(100, 48);
            txtLimit.TabIndex = 0;
            txtLimit.TabStop = false;
            txtLimit.Text = "10";
            txtLimit.TextAlign = HorizontalAlignment.Center;
            txtLimit.TrailingIcon = null;
            txtLimit.UseSystemPasswordChar = false;
            // 
            // lblKateqoriya
            // 
            lblKateqoriya.AutoSize = true;
            lblKateqoriya.BackColor = Color.FromArgb(242, 242, 242);
            lblKateqoriya.Depth = 0;
            lblKateqoriya.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblKateqoriya.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblKateqoriya.Location = new Point(220, 25);
            lblKateqoriya.MouseState = MaterialSkin.MouseState.HOVER;
            lblKateqoriya.Name = "lblKateqoriya";
            lblKateqoriya.Size = new Size(81, 19);
            lblKateqoriya.TabIndex = 1;
            lblKateqoriya.Text = "Kateqoriya:";
            // 
            // cmbKateqoriya
            // 
            cmbKateqoriya.AutoResize = false;
            cmbKateqoriya.BackColor = Color.FromArgb(242, 242, 242);
            cmbKateqoriya.Depth = 0;
            cmbKateqoriya.DrawMode = DrawMode.OwnerDrawVariable;
            cmbKateqoriya.DropDownHeight = 174;
            cmbKateqoriya.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbKateqoriya.DropDownWidth = 180;
            cmbKateqoriya.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmbKateqoriya.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmbKateqoriya.FormattingEnabled = true;
            cmbKateqoriya.IntegralHeight = false;
            cmbKateqoriya.ItemHeight = 43;
            cmbKateqoriya.Location = new Point(305, 12);
            cmbKateqoriya.MaxDropDownItems = 4;
            cmbKateqoriya.MouseState = MaterialSkin.MouseState.OUT;
            cmbKateqoriya.Name = "cmbKateqoriya";
            cmbKateqoriya.Size = new Size(180, 49);
            cmbKateqoriya.StartIndex = 0;
            cmbKateqoriya.TabIndex = 1;
            // 
            // chkYalnizTukenenleri
            // 
            chkYalnizTukenenleri.AutoSize = true;
            chkYalnizTukenenleri.BackColor = Color.FromArgb(242, 242, 242);
            chkYalnizTukenenleri.Depth = 0;
            chkYalnizTukenenleri.ForeColor = Color.FromArgb(222, 0, 0, 0);
            chkYalnizTukenenleri.Location = new Point(510, 20);
            chkYalnizTukenenleri.Margin = new Padding(0);
            chkYalnizTukenenleri.MouseLocation = new Point(-1, -1);
            chkYalnizTukenenleri.MouseState = MaterialSkin.MouseState.HOVER;
            chkYalnizTukenenleri.Name = "chkYalnizTukenenleri";
            chkYalnizTukenenleri.ReadOnly = false;
            chkYalnizTukenenleri.Ripple = true;
            chkYalnizTukenenleri.Size = new Size(208, 37);
            chkYalnizTukenenleri.TabIndex = 2;
            chkYalnizTukenenleri.Text = "Yalnız tükənənləri göstər";
            chkYalnizTukenenleri.UseVisualStyleBackColor = false;
            // 
            // btnGoster
            // 
            btnGoster.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnGoster.BackColor = Color.FromArgb(242, 242, 242);
            btnGoster.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnGoster.Depth = 0;
            btnGoster.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnGoster.HighEmphasis = true;
            btnGoster.Icon = null;
            btnGoster.Location = new Point(750, 15);
            btnGoster.Margin = new Padding(4, 6, 4, 6);
            btnGoster.MouseState = MaterialSkin.MouseState.HOVER;
            btnGoster.Name = "btnGoster";
            btnGoster.NoAccentTextColor = Color.Empty;
            btnGoster.Size = new Size(152, 36);
            btnGoster.TabIndex = 3;
            btnGoster.Text = "Hesabatı Göstər";
            btnGoster.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnGoster.UseAccentColor = false;
            btnGoster.UseVisualStyleBackColor = false;
            // 
            // pnlXulase
            // 
            pnlXulase.BackColor = Color.FromArgb(242, 242, 242);
            pnlXulase.Controls.Add(pnlMehsulSayi);
            pnlXulase.Controls.Add(pnlUmumiDeger);
            pnlXulase.Controls.Add(pnlKritikSay);
            pnlXulase.Controls.Add(pnlTukenmisSay);
            pnlXulase.Dock = DockStyle.Top;
            pnlXulase.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlXulase.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlXulase.Location = new Point(3, 134);
            pnlXulase.Name = "pnlXulase";
            pnlXulase.Padding = new Padding(15, 10, 15, 10);
            pnlXulase.Size = new Size(1194, 100);
            pnlXulase.TabIndex = 2;
            pnlXulase.Visible = false;
            // 
            // pnlMehsulSayi
            // 
            pnlMehsulSayi.BackColor = Color.FromArgb(242, 242, 242);
            pnlMehsulSayi.Controls.Add(lblMehsulSayiBasliq);
            pnlMehsulSayi.Controls.Add(lblMehsulSayiDeyer);
            pnlMehsulSayi.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlMehsulSayi.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlMehsulSayi.Location = new Point(18, 15);
            pnlMehsulSayi.Name = "pnlMehsulSayi";
            pnlMehsulSayi.Size = new Size(270, 70);
            pnlMehsulSayi.TabIndex = 0;
            // 
            // lblMehsulSayiBasliq
            // 
            lblMehsulSayiBasliq.BackColor = Color.FromArgb(242, 242, 242);
            lblMehsulSayiBasliq.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblMehsulSayiBasliq.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblMehsulSayiBasliq.Location = new Point(10, 8);
            lblMehsulSayiBasliq.Name = "lblMehsulSayiBasliq";
            lblMehsulSayiBasliq.Size = new Size(250, 20);
            lblMehsulSayiBasliq.TabIndex = 0;
            lblMehsulSayiBasliq.Text = "Cəmi Məhsul";
            // 
            // lblMehsulSayiDeyer
            // 
            lblMehsulSayiDeyer.BackColor = Color.FromArgb(242, 242, 242);
            lblMehsulSayiDeyer.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblMehsulSayiDeyer.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblMehsulSayiDeyer.Location = new Point(10, 30);
            lblMehsulSayiDeyer.Name = "lblMehsulSayiDeyer";
            lblMehsulSayiDeyer.Size = new Size(250, 35);
            lblMehsulSayiDeyer.TabIndex = 1;
            lblMehsulSayiDeyer.Text = "0";
            // 
            // pnlUmumiDeger
            // 
            pnlUmumiDeger.BackColor = Color.FromArgb(242, 242, 242);
            pnlUmumiDeger.Controls.Add(lblUmumiDegerBasliq);
            pnlUmumiDeger.Controls.Add(lblUmumiDegerDeyer);
            pnlUmumiDeger.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlUmumiDeger.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlUmumiDeger.Location = new Point(308, 15);
            pnlUmumiDeger.Name = "pnlUmumiDeger";
            pnlUmumiDeger.Size = new Size(270, 70);
            pnlUmumiDeger.TabIndex = 1;
            // 
            // lblUmumiDegerBasliq
            // 
            lblUmumiDegerBasliq.BackColor = Color.FromArgb(242, 242, 242);
            lblUmumiDegerBasliq.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblUmumiDegerBasliq.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblUmumiDegerBasliq.Location = new Point(10, 8);
            lblUmumiDegerBasliq.Name = "lblUmumiDegerBasliq";
            lblUmumiDegerBasliq.Size = new Size(250, 20);
            lblUmumiDegerBasliq.TabIndex = 0;
            lblUmumiDegerBasliq.Text = "Ümumi Dəyər";
            // 
            // lblUmumiDegerDeyer
            // 
            lblUmumiDegerDeyer.BackColor = Color.FromArgb(242, 242, 242);
            lblUmumiDegerDeyer.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblUmumiDegerDeyer.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblUmumiDegerDeyer.Location = new Point(10, 30);
            lblUmumiDegerDeyer.Name = "lblUmumiDegerDeyer";
            lblUmumiDegerDeyer.Size = new Size(250, 35);
            lblUmumiDegerDeyer.TabIndex = 1;
            lblUmumiDegerDeyer.Text = "0.00 ₼";
            // 
            // pnlKritikSay
            // 
            pnlKritikSay.BackColor = Color.FromArgb(242, 242, 242);
            pnlKritikSay.Controls.Add(lblKritikSayBasliq);
            pnlKritikSay.Controls.Add(lblKritikSayDeyer);
            pnlKritikSay.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlKritikSay.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlKritikSay.Location = new Point(598, 15);
            pnlKritikSay.Name = "pnlKritikSay";
            pnlKritikSay.Size = new Size(270, 70);
            pnlKritikSay.TabIndex = 2;
            // 
            // lblKritikSayBasliq
            // 
            lblKritikSayBasliq.BackColor = Color.FromArgb(242, 242, 242);
            lblKritikSayBasliq.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblKritikSayBasliq.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblKritikSayBasliq.Location = new Point(10, 8);
            lblKritikSayBasliq.Name = "lblKritikSayBasliq";
            lblKritikSayBasliq.Size = new Size(250, 20);
            lblKritikSayBasliq.TabIndex = 0;
            lblKritikSayBasliq.Text = "Kritik Səviyyədə";
            // 
            // lblKritikSayDeyer
            // 
            lblKritikSayDeyer.BackColor = Color.FromArgb(242, 242, 242);
            lblKritikSayDeyer.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblKritikSayDeyer.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblKritikSayDeyer.Location = new Point(10, 30);
            lblKritikSayDeyer.Name = "lblKritikSayDeyer";
            lblKritikSayDeyer.Size = new Size(250, 35);
            lblKritikSayDeyer.TabIndex = 1;
            lblKritikSayDeyer.Text = "0";
            // 
            // pnlTukenmisSay
            // 
            pnlTukenmisSay.BackColor = Color.FromArgb(242, 242, 242);
            pnlTukenmisSay.Controls.Add(lblTukenmisSayBasliq);
            pnlTukenmisSay.Controls.Add(lblTukenmisSayDeyer);
            pnlTukenmisSay.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlTukenmisSay.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlTukenmisSay.Location = new Point(888, 15);
            pnlTukenmisSay.Name = "pnlTukenmisSay";
            pnlTukenmisSay.Size = new Size(270, 70);
            pnlTukenmisSay.TabIndex = 3;
            // 
            // lblTukenmisSayBasliq
            // 
            lblTukenmisSayBasliq.BackColor = Color.FromArgb(242, 242, 242);
            lblTukenmisSayBasliq.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblTukenmisSayBasliq.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblTukenmisSayBasliq.Location = new Point(10, 8);
            lblTukenmisSayBasliq.Name = "lblTukenmisSayBasliq";
            lblTukenmisSayBasliq.Size = new Size(250, 20);
            lblTukenmisSayBasliq.TabIndex = 0;
            lblTukenmisSayBasliq.Text = "Stokda Yox";
            // 
            // lblTukenmisSayDeyer
            // 
            lblTukenmisSayDeyer.BackColor = Color.FromArgb(242, 242, 242);
            lblTukenmisSayDeyer.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblTukenmisSayDeyer.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblTukenmisSayDeyer.Location = new Point(10, 30);
            lblTukenmisSayDeyer.Name = "lblTukenmisSayDeyer";
            lblTukenmisSayDeyer.Size = new Size(250, 35);
            lblTukenmisSayDeyer.TabIndex = 1;
            lblTukenmisSayDeyer.Text = "0";
            // 
            // pnlContent
            // 
            pnlContent.BackColor = Color.FromArgb(242, 242, 242);
            pnlContent.Controls.Add(dgvHesabat);
            pnlContent.Controls.Add(lblMesaj);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlContent.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlContent.Location = new Point(3, 234);
            pnlContent.Name = "pnlContent";
            pnlContent.Padding = new Padding(15);
            pnlContent.Size = new Size(1194, 381);
            pnlContent.TabIndex = 1;
            // 
            // dgvHesabat
            // 
            dgvHesabat.AllowUserToAddRows = false;
            dgvHesabat.AllowUserToDeleteRows = false;
            dgvHesabat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHesabat.BackgroundColor = Color.White;
            dgvHesabat.BorderStyle = BorderStyle.None;
            dgvHesabat.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvHesabat.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvHesabat.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvHesabat.ColumnHeadersHeight = 40;
            dgvHesabat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvHesabat.Dock = DockStyle.Fill;
            dgvHesabat.EnableHeadersVisualStyles = false;
            dgvHesabat.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvHesabat.GridColor = Color.FromArgb(224, 224, 224);
            dgvHesabat.Location = new Point(15, 15);
            dgvHesabat.MultiSelect = false;
            dgvHesabat.Name = "dgvHesabat";
            dgvHesabat.ReadOnly = true;
            dgvHesabat.RowHeadersVisible = false;
            dgvHesabat.RowTemplate.Height = 35;
            dgvHesabat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHesabat.Size = new Size(1164, 351);
            dgvHesabat.TabIndex = 0;
            dgvHesabat.Visible = false;
            // 
            // lblMesaj
            // 
            lblMesaj.BackColor = Color.FromArgb(242, 242, 242);
            lblMesaj.Depth = 0;
            lblMesaj.Dock = DockStyle.Fill;
            lblMesaj.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblMesaj.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            lblMesaj.ForeColor = Color.FromArgb(222, 0, 0, 0);
            lblMesaj.Location = new Point(15, 15);
            lblMesaj.MouseState = MaterialSkin.MouseState.HOVER;
            lblMesaj.Name = "lblMesaj";
            lblMesaj.Size = new Size(1164, 351);
            lblMesaj.TabIndex = 1;
            lblMesaj.Text = "Hesabatı görmək üçün limit sayını daxil edin və 'Hesabatı Göstər' düyməsinə basın.";
            lblMesaj.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlButtons
            // 
            pnlButtons.BackColor = Color.FromArgb(242, 242, 242);
            pnlButtons.Controls.Add(btnExcelIxrac);
            pnlButtons.Dock = DockStyle.Bottom;
            pnlButtons.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            pnlButtons.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlButtons.Location = new Point(3, 615);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Padding = new Padding(15);
            pnlButtons.Size = new Size(1194, 60);
            pnlButtons.TabIndex = 4;
            // 
            // btnExcelIxrac
            // 
            btnExcelIxrac.Anchor = AnchorStyles.Right;
            btnExcelIxrac.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnExcelIxrac.BackColor = Color.FromArgb(242, 242, 242);
            btnExcelIxrac.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnExcelIxrac.Depth = 0;
            btnExcelIxrac.Enabled = false;
            btnExcelIxrac.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnExcelIxrac.HighEmphasis = true;
            btnExcelIxrac.Icon = null;
            btnExcelIxrac.Location = new Point(1055, 12);
            btnExcelIxrac.Margin = new Padding(4, 6, 4, 6);
            btnExcelIxrac.MouseState = MaterialSkin.MouseState.HOVER;
            btnExcelIxrac.Name = "btnExcelIxrac";
            btnExcelIxrac.NoAccentTextColor = Color.Empty;
            btnExcelIxrac.Size = new Size(125, 36);
            btnExcelIxrac.TabIndex = 0;
            btnExcelIxrac.Text = "Excel-ə İxrac";
            btnExcelIxrac.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnExcelIxrac.UseAccentColor = true;
            btnExcelIxrac.UseVisualStyleBackColor = false;
            // 
            // AnbarQaliqHesabatFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 700);
            Controls.Add(pnlContent);
            Controls.Add(pnlXulase);
            Controls.Add(pnlFiltr);
            Controls.Add(pnlButtons);
            Name = "AnbarQaliqHesabatFormu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Anbar Qalığı Hesabatı";
            Controls.SetChildIndex(pnlButtons, 0);
            Controls.SetChildIndex(pnlFiltr, 0);
            Controls.SetChildIndex(pnlXulase, 0);
            Controls.SetChildIndex(pnlContent, 0);
            pnlFiltr.ResumeLayout(false);
            pnlFiltr.PerformLayout();
            pnlXulase.ResumeLayout(false);
            pnlMehsulSayi.ResumeLayout(false);
            pnlUmumiDeger.ResumeLayout(false);
            pnlKritikSay.ResumeLayout(false);
            pnlTukenmisSay.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHesabat).EndInit();
            pnlButtons.ResumeLayout(false);
            pnlButtons.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // Filtr
        private Panel pnlFiltr;
        private MaterialSkin.Controls.MaterialLabel lblLimit;
        private MaterialSkin.Controls.MaterialTextBox2 txtLimit;
        private MaterialSkin.Controls.MaterialLabel lblKateqoriya;
        private MaterialSkin.Controls.MaterialComboBox cmbKateqoriya;
        private MaterialSkin.Controls.MaterialCheckbox chkYalnizTukenenleri;
        private MaterialSkin.Controls.MaterialButton btnGoster;

        // Xülasə kartları
        private Panel pnlXulase;
        private Panel pnlMehsulSayi;
        private Label lblMehsulSayiBasliq;
        private Label lblMehsulSayiDeyer;
        private Panel pnlUmumiDeger;
        private Label lblUmumiDegerBasliq;
        private Label lblUmumiDegerDeyer;
        private Panel pnlKritikSay;
        private Label lblKritikSayBasliq;
        private Label lblKritikSayDeyer;
        private Panel pnlTukenmisSay;
        private Label lblTukenmisSayBasliq;
        private Label lblTukenmisSayDeyer;

        // Content
        private Panel pnlContent;
        private DataGridView dgvHesabat;
        private MaterialSkin.Controls.MaterialLabel lblMesaj;

        // Buttons
        private Panel pnlButtons;
        private MaterialSkin.Controls.MaterialButton btnExcelIxrac;
    }
}
