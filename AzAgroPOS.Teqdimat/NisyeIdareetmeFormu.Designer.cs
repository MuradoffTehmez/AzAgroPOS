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
            panelMusteriler = new Panel();
            dgvMusteriler = new DataGridView();
            lblMusterilerBasliq = new MaterialSkin.Controls.MaterialLabel();
            panelSag = new Panel();
            dgvNisyeHereketleri = new DataGridView();
            lblHereketlerBasliq = new MaterialSkin.Controls.MaterialLabel();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            lblOdenisMeblegBasliq = new MaterialSkin.Controls.MaterialLabel();
            btnOdenisEt = new MaterialSkin.Controls.MaterialButton();
            txtOdenisMeblegi = new MaterialSkin.Controls.MaterialTextBox2();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panelMusteriler.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMusteriler).BeginInit();
            panelSag.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNisyeHereketleri).BeginInit();
            materialCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
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
            splitContainer1.Orientation = Orientation.Horizontal;
            //
            // splitContainer1.Panel1
            //
            splitContainer1.Panel1.BackColor = Color.FromArgb(250, 250, 250);
            splitContainer1.Panel1.Controls.Add(panelMusteriler);
            splitContainer1.Panel1.Padding = new Padding(10);
            //
            // splitContainer1.Panel2
            //
            splitContainer1.Panel2.BackColor = Color.FromArgb(250, 250, 250);
            splitContainer1.Panel2.Controls.Add(panelSag);
            splitContainer1.Panel2.Padding = new Padding(10);
            splitContainer1.Size = new Size(1178, 573);
            splitContainer1.SplitterDistance = 250;
            splitContainer1.TabIndex = 0;
            //
            // panelMusteriler
            //
            panelMusteriler.BackColor = Color.White;
            panelMusteriler.Controls.Add(dgvMusteriler);
            panelMusteriler.Controls.Add(lblMusterilerBasliq);
            panelMusteriler.Dock = DockStyle.Fill;
            panelMusteriler.Location = new Point(10, 10);
            panelMusteriler.Name = "panelMusteriler";
            panelMusteriler.Padding = new Padding(5);
            panelMusteriler.Size = new Size(1158, 230);
            panelMusteriler.TabIndex = 0;
            //
            // dgvMusteriler
            //
            dgvMusteriler.AllowUserToAddRows = false;
            dgvMusteriler.AllowUserToDeleteRows = false;
            dgvMusteriler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMusteriler.BackgroundColor = Color.White;
            dgvMusteriler.BorderStyle = BorderStyle.None;
            dgvMusteriler.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 105, 92);
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 105, 92);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMusteriler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMusteriler.ColumnHeadersHeight = 45;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle2.Padding = new Padding(5, 3, 5, 3);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(225, 245, 254);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(0, 77, 64);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvMusteriler.DefaultCellStyle = dataGridViewCellStyle2;
            dgvMusteriler.Dock = DockStyle.Fill;
            dgvMusteriler.EnableHeadersVisualStyles = false;
            dgvMusteriler.GridColor = Color.FromArgb(245, 245, 245);
            dgvMusteriler.Location = new Point(5, 45);
            dgvMusteriler.MultiSelect = false;
            dgvMusteriler.Name = "dgvMusteriler";
            dgvMusteriler.ReadOnly = true;
            dgvMusteriler.RowHeadersVisible = false;
            dgvMusteriler.RowTemplate.Height = 35;
            dgvMusteriler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMusteriler.Size = new Size(1148, 180);
            dgvMusteriler.TabIndex = 0;
            dgvMusteriler.SelectionChanged += dgvMusteriler_SelectionChanged;
            //
            // lblMusterilerBasliq
            //
            lblMusterilerBasliq.BackColor = Color.White;
            lblMusterilerBasliq.Depth = 0;
            lblMusterilerBasliq.Dock = DockStyle.Top;
            lblMusterilerBasliq.Font = new Font("Roboto", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblMusterilerBasliq.FontType = MaterialSkin.MaterialSkinManager.fontType.Button;
            lblMusterilerBasliq.ForeColor = Color.FromArgb(0, 77, 64);
            lblMusterilerBasliq.Location = new Point(5, 5);
            lblMusterilerBasliq.MouseState = MaterialSkin.MouseState.HOVER;
            lblMusterilerBasliq.Name = "lblMusterilerBasliq";
            lblMusterilerBasliq.Padding = new Padding(0, 5, 0, 5);
            lblMusterilerBasliq.Size = new Size(1148, 40);
            lblMusterilerBasliq.TabIndex = 1;
            lblMusterilerBasliq.Text = "MÜŞTƏRİLƏR VƏ BORCLARI";
            lblMusterilerBasliq.TextAlign = ContentAlignment.MiddleLeft;
            //
            // panelSag
            //
            panelSag.BackColor = Color.White;
            panelSag.Controls.Add(dgvNisyeHereketleri);
            panelSag.Controls.Add(lblHereketlerBasliq);
            panelSag.Controls.Add(materialCard1);
            panelSag.Dock = DockStyle.Fill;
            panelSag.Location = new Point(10, 10);
            panelSag.Name = "panelSag";
            panelSag.Padding = new Padding(5);
            panelSag.Size = new Size(1158, 299);
            panelSag.TabIndex = 0;
            //
            // dgvNisyeHereketleri
            //
            dgvNisyeHereketleri.AllowUserToAddRows = false;
            dgvNisyeHereketleri.AllowUserToDeleteRows = false;
            dgvNisyeHereketleri.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNisyeHereketleri.BackgroundColor = Color.White;
            dgvNisyeHereketleri.BorderStyle = BorderStyle.None;
            dgvNisyeHereketleri.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(0, 105, 92);
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(0, 105, 92);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvNisyeHereketleri.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvNisyeHereketleri.ColumnHeadersHeight = 45;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.White;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(64, 64, 64);
            dataGridViewCellStyle4.Padding = new Padding(5, 3, 5, 3);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(225, 245, 254);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(0, 77, 64);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvNisyeHereketleri.DefaultCellStyle = dataGridViewCellStyle4;
            dgvNisyeHereketleri.Dock = DockStyle.Fill;
            dgvNisyeHereketleri.EnableHeadersVisualStyles = false;
            dgvNisyeHereketleri.GridColor = Color.FromArgb(245, 245, 245);
            dgvNisyeHereketleri.Location = new Point(5, 45);
            dgvNisyeHereketleri.Name = "dgvNisyeHereketleri";
            dgvNisyeHereketleri.ReadOnly = true;
            dgvNisyeHereketleri.RowHeadersVisible = false;
            dgvNisyeHereketleri.RowTemplate.Height = 35;
            dgvNisyeHereketleri.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvNisyeHereketleri.Size = new Size(1148, 139);
            dgvNisyeHereketleri.TabIndex = 0;
            //
            // lblHereketlerBasliq
            //
            lblHereketlerBasliq.BackColor = Color.White;
            lblHereketlerBasliq.Depth = 0;
            lblHereketlerBasliq.Dock = DockStyle.Top;
            lblHereketlerBasliq.Font = new Font("Roboto", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblHereketlerBasliq.FontType = MaterialSkin.MaterialSkinManager.fontType.Button;
            lblHereketlerBasliq.ForeColor = Color.FromArgb(0, 77, 64);
            lblHereketlerBasliq.Location = new Point(5, 5);
            lblHereketlerBasliq.MouseState = MaterialSkin.MouseState.HOVER;
            lblHereketlerBasliq.Name = "lblHereketlerBasliq";
            lblHereketlerBasliq.Padding = new Padding(0, 5, 0, 5);
            lblHereketlerBasliq.Size = new Size(1148, 40);
            lblHereketlerBasliq.TabIndex = 2;
            lblHereketlerBasliq.Text = "BORC HƏRƏKƏTLƏRI";
            lblHereketlerBasliq.TextAlign = ContentAlignment.MiddleLeft;
            //
            // materialCard1
            //
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(lblOdenisMeblegBasliq);
            materialCard1.Controls.Add(btnOdenisEt);
            materialCard1.Controls.Add(txtOdenisMeblegi);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Bottom;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(5, 184);
            materialCard1.Margin = new Padding(10);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(20, 15, 20, 15);
            materialCard1.Size = new Size(1148, 110);
            materialCard1.TabIndex = 1;
            //
            // lblOdenisMeblegBasliq
            //
            lblOdenisMeblegBasliq.AutoSize = true;
            lblOdenisMeblegBasliq.BackColor = Color.White;
            lblOdenisMeblegBasliq.Depth = 0;
            lblOdenisMeblegBasliq.Font = new Font("Roboto", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblOdenisMeblegBasliq.FontType = MaterialSkin.MaterialSkinManager.fontType.Button;
            lblOdenisMeblegBasliq.ForeColor = Color.FromArgb(0, 77, 64);
            lblOdenisMeblegBasliq.Location = new Point(23, 18);
            lblOdenisMeblegBasliq.MouseState = MaterialSkin.MouseState.HOVER;
            lblOdenisMeblegBasliq.Name = "lblOdenisMeblegBasliq";
            lblOdenisMeblegBasliq.Size = new Size(127, 19);
            lblOdenisMeblegBasliq.TabIndex = 2;
            lblOdenisMeblegBasliq.Text = "BORC ÖDƏNİŞİ";
            //
            // btnOdenisEt
            //
            btnOdenisEt.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOdenisEt.AutoSize = false;
            btnOdenisEt.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnOdenisEt.BackColor = Color.FromArgb(242, 242, 242);
            btnOdenisEt.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnOdenisEt.Depth = 0;
            btnOdenisEt.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnOdenisEt.HighEmphasis = true;
            btnOdenisEt.Icon = null;
            btnOdenisEt.Location = new Point(1002, 45);
            btnOdenisEt.Margin = new Padding(4, 6, 4, 6);
            btnOdenisEt.MouseState = MaterialSkin.MouseState.HOVER;
            btnOdenisEt.Name = "btnOdenisEt";
            btnOdenisEt.NoAccentTextColor = Color.Empty;
            btnOdenisEt.Size = new Size(120, 42);
            btnOdenisEt.TabIndex = 1;
            btnOdenisEt.Text = "ÖDƏNİŞ ET";
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
            txtOdenisMeblegi.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtOdenisMeblegi.HideSelection = true;
            txtOdenisMeblegi.Hint = "Ödəniş Məbləği (AZN)";
            txtOdenisMeblegi.LeadingIcon = null;
            txtOdenisMeblegi.Location = new Point(23, 43);
            txtOdenisMeblegi.MaxLength = 32767;
            txtOdenisMeblegi.MouseState = MaterialSkin.MouseState.OUT;
            txtOdenisMeblegi.Name = "txtOdenisMeblegi";
            txtOdenisMeblegi.PasswordChar = '\0';
            txtOdenisMeblegi.PrefixSuffixText = "AZN";
            txtOdenisMeblegi.ReadOnly = false;
            txtOdenisMeblegi.RightToLeft = RightToLeft.No;
            txtOdenisMeblegi.SelectedText = "";
            txtOdenisMeblegi.SelectionLength = 0;
            txtOdenisMeblegi.SelectionStart = 0;
            txtOdenisMeblegi.ShortcutsEnabled = true;
            txtOdenisMeblegi.Size = new Size(350, 48);
            txtOdenisMeblegi.TabIndex = 0;
            txtOdenisMeblegi.TabStop = false;
            txtOdenisMeblegi.TextAlign = HorizontalAlignment.Left;
            txtOdenisMeblegi.TrailingIcon = null;
            txtOdenisMeblegi.UseSystemPasswordChar = false;
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
            panelMusteriler.ResumeLayout(false);
            panelMusteriler.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMusteriler).EndInit();
            panelSag.ResumeLayout(false);
            panelSag.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNisyeHereketleri).EndInit();
            materialCard1.ResumeLayout(false);
            materialCard1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panelMusteriler;
        private System.Windows.Forms.DataGridView dgvMusteriler;
        private MaterialSkin.Controls.MaterialLabel lblMusterilerBasliq;
        private System.Windows.Forms.Panel panelSag;
        private System.Windows.Forms.DataGridView dgvNisyeHereketleri;
        private MaterialSkin.Controls.MaterialLabel lblHereketlerBasliq;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialLabel lblOdenisMeblegBasliq;
        private MaterialSkin.Controls.MaterialButton btnOdenisEt;
        private MaterialSkin.Controls.MaterialTextBox2 txtOdenisMeblegi;
        private ErrorProvider errorProvider1;
    }
}
