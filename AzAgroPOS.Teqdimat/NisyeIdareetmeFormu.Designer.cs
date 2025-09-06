// Fayl: AzAgroPOS.Teqdimat/NisyeIdareetmeFormu.Designer.cs
namespace AzAgroPOS.Teqdimat
{
    partial class NisyeIdareetmeFormu
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
            splitContainer1 = new SplitContainer();
            dgvMusteriler = new DataGridView();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            btnOdenisEt = new MaterialSkin.Controls.MaterialButton();
            txtOdenisMeblegi = new MaterialSkin.Controls.MaterialTextBox2();
            dgvNisyeHereketleri = new DataGridView();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMusteriler).BeginInit();
            materialCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNisyeHereketleri).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = Color.FromArgb(242, 242, 242);
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            splitContainer1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            splitContainer1.Location = new Point(3, 64);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.FromArgb(242, 242, 242);
            splitContainer1.Panel1.Controls.Add(dgvMusteriler);
            splitContainer1.Panel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            splitContainer1.Panel1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.FromArgb(242, 242, 242);
            splitContainer1.Panel2.Controls.Add(materialCard1);
            splitContainer1.Panel2.Controls.Add(dgvNisyeHereketleri);
            splitContainer1.Panel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            splitContainer1.Panel2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            splitContainer1.Size = new Size(1178, 573);
            splitContainer1.SplitterDistance = 392;
            splitContainer1.TabIndex = 0;
            // 
            // dgvMusteriler
            // 
            dgvMusteriler.AllowUserToAddRows = false;
            dgvMusteriler.AllowUserToDeleteRows = false;
            dgvMusteriler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMusteriler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMusteriler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvMusteriler.DefaultCellStyle = dataGridViewCellStyle2;
            dgvMusteriler.Dock = DockStyle.Fill;
            dgvMusteriler.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvMusteriler.Location = new Point(0, 0);
            dgvMusteriler.MultiSelect = false;
            dgvMusteriler.Name = "dgvMusteriler";
            dgvMusteriler.ReadOnly = true;
            dgvMusteriler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMusteriler.Size = new Size(392, 573);
            dgvMusteriler.TabIndex = 0;
            dgvMusteriler.SelectionChanged += dgvMusteriler_SelectionChanged;
            // 
            // materialCard1
            // 
            materialCard1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(btnOdenisEt);
            materialCard1.Controls.Add(txtOdenisMeblegi);
            materialCard1.Depth = 0;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(3, 490);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(765, 80);
            materialCard1.TabIndex = 1;
            // 
            // btnOdenisEt
            // 
            btnOdenisEt.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnOdenisEt.BackColor = Color.FromArgb(242, 242, 242);
            btnOdenisEt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnOdenisEt.Depth = 0;
            btnOdenisEt.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnOdenisEt.HighEmphasis = true;
            btnOdenisEt.Icon = null;
            btnOdenisEt.Location = new Point(291, 23);
            btnOdenisEt.Margin = new Padding(4, 6, 4, 6);
            btnOdenisEt.MouseState = MaterialSkin.MouseState.HOVER;
            btnOdenisEt.Name = "btnOdenisEt";
            btnOdenisEt.NoAccentTextColor = Color.Empty;
            btnOdenisEt.Size = new Size(96, 36);
            btnOdenisEt.TabIndex = 1;
            btnOdenisEt.Text = "Ödəniş Et";
            btnOdenisEt.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnOdenisEt.UseAccentColor = true;
            btnOdenisEt.UseVisualStyleBackColor = false;
            btnOdenisEt.Click += btnOdenisEt_Click;
            // 
            // txtOdenisMeblegi
            // 
            txtOdenisMeblegi.AnimateReadOnly = false;
            txtOdenisMeblegi.BackColor = Color.FromArgb(255, 255, 255);
            txtOdenisMeblegi.BackgroundImageLayout = ImageLayout.None;
            txtOdenisMeblegi.CharacterCasing = CharacterCasing.Normal;
            txtOdenisMeblegi.Depth = 0;
            txtOdenisMeblegi.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtOdenisMeblegi.HideSelection = true;
            txtOdenisMeblegi.Hint = "Ödəniş Məbləği";
            txtOdenisMeblegi.LeadingIcon = null;
            txtOdenisMeblegi.Location = new Point(17, 17);
            txtOdenisMeblegi.MaxLength = 32767;
            txtOdenisMeblegi.MouseState = MaterialSkin.MouseState.OUT;
            txtOdenisMeblegi.Name = "txtOdenisMeblegi";
            txtOdenisMeblegi.PasswordChar = '\0';
            txtOdenisMeblegi.PrefixSuffixText = null;
            txtOdenisMeblegi.ReadOnly = false;
            txtOdenisMeblegi.RightToLeft = RightToLeft.No;
            txtOdenisMeblegi.SelectedText = "";
            txtOdenisMeblegi.SelectionLength = 0;
            txtOdenisMeblegi.SelectionStart = 0;
            txtOdenisMeblegi.ShortcutsEnabled = true;
            txtOdenisMeblegi.Size = new Size(250, 48);
            txtOdenisMeblegi.TabIndex = 0;
            txtOdenisMeblegi.TabStop = false;
            txtOdenisMeblegi.TextAlign = HorizontalAlignment.Left;
            txtOdenisMeblegi.TrailingIcon = null;
            txtOdenisMeblegi.UseSystemPasswordChar = false;
            // 
            // dgvNisyeHereketleri
            // 
            dgvNisyeHereketleri.AllowUserToAddRows = false;
            dgvNisyeHereketleri.AllowUserToDeleteRows = false;
            dgvNisyeHereketleri.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvNisyeHereketleri.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvNisyeHereketleri.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvNisyeHereketleri.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvNisyeHereketleri.DefaultCellStyle = dataGridViewCellStyle4;
            dgvNisyeHereketleri.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvNisyeHereketleri.Location = new Point(3, 0);
            dgvNisyeHereketleri.Name = "dgvNisyeHereketleri";
            dgvNisyeHereketleri.ReadOnly = true;
            dgvNisyeHereketleri.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNisyeHereketleri.Size = new Size(775, 479);
            dgvNisyeHereketleri.TabIndex = 0;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // NisyeIdareetmeFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            ClientSize = new Size(1184, 640);
            Controls.Add(splitContainer1);
            Name = "NisyeIdareetmeFormu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Nisyə və Borc İdarəetməsi";
            Load += NisyeIdareetmeFormu_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMusteriler).EndInit();
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNisyeHereketleri).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvMusteriler;
        private System.Windows.Forms.DataGridView dgvNisyeHereketleri;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialButton btnOdenisEt;
        private MaterialSkin.Controls.MaterialTextBox2 txtOdenisMeblegi;
        private ErrorProvider errorProvider1;
    }
}