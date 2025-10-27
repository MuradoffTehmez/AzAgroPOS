namespace AzAgroPOS.Teqdimat
{
    partial class QaytarmaFormu
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlMain = new MaterialSkin.Controls.MaterialCard();
            txtQaytarmaSebebi = new MaterialSkin.Controls.MaterialTextBox2();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            dgvSatisMehsullari = new DataGridView();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            txtSatisNomresi = new MaterialSkin.Controls.MaterialTextBox2();
            btnAxtar = new MaterialSkin.Controls.MaterialButton();
            btnQaytar = new MaterialSkin.Controls.MaterialButton();
            errorProvider1 = new ErrorProvider(components);
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSatisMehsullari).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(255, 255, 255);
            pnlMain.Controls.Add(txtQaytarmaSebebi);
            pnlMain.Controls.Add(materialLabel2);
            pnlMain.Controls.Add(dgvSatisMehsullari);
            pnlMain.Controls.Add(materialLabel1);
            pnlMain.Controls.Add(txtSatisNomresi);
            pnlMain.Controls.Add(btnAxtar);
            pnlMain.Controls.Add(btnQaytar);
            pnlMain.Depth = 0;
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.ForeColor = Color.FromArgb(222, 0, 0, 0);
            pnlMain.Location = new Point(4, 74);
            pnlMain.Margin = new Padding(16);
            pnlMain.MouseState = MaterialSkin.MouseState.HOVER;
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(16);
            pnlMain.Size = new Size(1364, 735);
            pnlMain.TabIndex = 0;
            // 
            // txtQaytarmaSebebi
            // 
            txtQaytarmaSebebi.AnimateReadOnly = false;
            txtQaytarmaSebebi.BackColor = Color.FromArgb(255, 255, 255);
            txtQaytarmaSebebi.BackgroundImageLayout = ImageLayout.None;
            txtQaytarmaSebebi.CharacterCasing = CharacterCasing.Normal;
            txtQaytarmaSebebi.Depth = 0;
            txtQaytarmaSebebi.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtQaytarmaSebebi.HideSelection = true;
            txtQaytarmaSebebi.LeadingIcon = null;
            txtQaytarmaSebebi.Location = new Point(20, 117);
            txtQaytarmaSebebi.Margin = new Padding(4, 3, 4, 3);
            txtQaytarmaSebebi.MaxLength = 32767;
            txtQaytarmaSebebi.MouseState = MaterialSkin.MouseState.OUT;
            txtQaytarmaSebebi.Name = "txtQaytarmaSebebi";
            txtQaytarmaSebebi.PasswordChar = '\0';
            txtQaytarmaSebebi.PrefixSuffixText = null;
            txtQaytarmaSebebi.ReadOnly = false;
            txtQaytarmaSebebi.RightToLeft = RightToLeft.No;
            txtQaytarmaSebebi.SelectedText = "";
            txtQaytarmaSebebi.SelectionLength = 0;
            txtQaytarmaSebebi.SelectionStart = 0;
            txtQaytarmaSebebi.ShortcutsEnabled = true;
            txtQaytarmaSebebi.Size = new Size(408, 48);
            txtQaytarmaSebebi.TabIndex = 6;
            txtQaytarmaSebebi.TabStop = false;
            txtQaytarmaSebebi.TextAlign = HorizontalAlignment.Left;
            txtQaytarmaSebebi.TrailingIcon = null;
            txtQaytarmaSebebi.UseSystemPasswordChar = false;
            // 
            // materialLabel2
            // 
            materialLabel2.AutoSize = true;
            materialLabel2.BackColor = Color.FromArgb(242, 242, 242);
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel2.Location = new Point(20, 91);
            materialLabel2.Margin = new Padding(4, 0, 4, 0);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(127, 19);
            materialLabel2.TabIndex = 5;
            materialLabel2.Text = "Qaytarma Səbəbi:";
            // 
            // dgvSatisMehsullari
            // 
            dgvSatisMehsullari.AllowUserToAddRows = false;
            dgvSatisMehsullari.AllowUserToDeleteRows = false;
            dgvSatisMehsullari.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSatisMehsullari.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvSatisMehsullari.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvSatisMehsullari.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(222, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvSatisMehsullari.DefaultCellStyle = dataGridViewCellStyle2;
            dgvSatisMehsullari.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            dgvSatisMehsullari.Location = new Point(20, 192);
            dgvSatisMehsullari.Margin = new Padding(4, 3, 4, 3);
            dgvSatisMehsullari.MultiSelect = false;
            dgvSatisMehsullari.Name = "dgvSatisMehsullari";
            dgvSatisMehsullari.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSatisMehsullari.Size = new Size(1324, 470);
            dgvSatisMehsullari.TabIndex = 4;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.BackColor = Color.FromArgb(242, 242, 242);
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialLabel1.Location = new Point(20, 17);
            materialLabel1.Margin = new Padding(4, 0, 4, 0);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(104, 19);
            materialLabel1.TabIndex = 3;
            materialLabel1.Text = "Satış Nömrəsi:";
            // 
            // txtSatisNomresi
            // 
            txtSatisNomresi.AnimateReadOnly = false;
            txtSatisNomresi.BackColor = Color.FromArgb(255, 255, 255);
            txtSatisNomresi.BackgroundImageLayout = ImageLayout.None;
            txtSatisNomresi.CharacterCasing = CharacterCasing.Normal;
            txtSatisNomresi.Depth = 0;
            txtSatisNomresi.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtSatisNomresi.HideSelection = true;
            txtSatisNomresi.LeadingIcon = null;
            txtSatisNomresi.Location = new Point(20, 43);
            txtSatisNomresi.Margin = new Padding(4, 3, 4, 3);
            txtSatisNomresi.MaxLength = 32767;
            txtSatisNomresi.MouseState = MaterialSkin.MouseState.OUT;
            txtSatisNomresi.Name = "txtSatisNomresi";
            txtSatisNomresi.PasswordChar = '\0';
            txtSatisNomresi.PrefixSuffixText = null;
            txtSatisNomresi.ReadOnly = false;
            txtSatisNomresi.RightToLeft = RightToLeft.No;
            txtSatisNomresi.SelectedText = "";
            txtSatisNomresi.SelectionLength = 0;
            txtSatisNomresi.SelectionStart = 0;
            txtSatisNomresi.ShortcutsEnabled = true;
            txtSatisNomresi.Size = new Size(292, 48);
            txtSatisNomresi.TabIndex = 2;
            txtSatisNomresi.TabStop = false;
            txtSatisNomresi.TextAlign = HorizontalAlignment.Left;
            txtSatisNomresi.TrailingIcon = null;
            txtSatisNomresi.UseSystemPasswordChar = false;
            // 
            // btnAxtar
            // 
            btnAxtar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnAxtar.BackColor = Color.FromArgb(242, 242, 242);
            btnAxtar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnAxtar.Depth = 0;
            btnAxtar.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnAxtar.HighEmphasis = true;
            btnAxtar.Icon = null;
            btnAxtar.Location = new Point(327, 48);
            btnAxtar.Margin = new Padding(5, 7, 5, 7);
            btnAxtar.MouseState = MaterialSkin.MouseState.HOVER;
            btnAxtar.Name = "btnAxtar";
            btnAxtar.NoAccentTextColor = Color.Empty;
            btnAxtar.Size = new Size(68, 36);
            btnAxtar.TabIndex = 1;
            btnAxtar.Text = "Axtar";
            btnAxtar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnAxtar.UseAccentColor = false;
            btnAxtar.UseVisualStyleBackColor = false;
            btnAxtar.Click += btnAxtar_Click;
            // 
            // btnQaytar
            // 
            btnQaytar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnQaytar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnQaytar.BackColor = Color.FromArgb(242, 242, 242);
            btnQaytar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnQaytar.Depth = 0;
            btnQaytar.ForeColor = Color.FromArgb(222, 0, 0, 0);
            btnQaytar.HighEmphasis = true;
            btnQaytar.Icon = null;
            btnQaytar.Location = new Point(1266, 682);
            btnQaytar.Margin = new Padding(5, 7, 5, 7);
            btnQaytar.MouseState = MaterialSkin.MouseState.HOVER;
            btnQaytar.Name = "btnQaytar";
            btnQaytar.NoAccentTextColor = Color.Empty;
            btnQaytar.Size = new Size(78, 36);
            btnQaytar.TabIndex = 0;
            btnQaytar.Text = "Qaytar";
            btnQaytar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnQaytar.UseAccentColor = false;
            btnQaytar.UseVisualStyleBackColor = false;
            btnQaytar.Click += btnQaytar_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // QaytarmaFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1372, 812);
            Controls.Add(pnlMain);
            Margin = new Padding(4, 3, 4, 3);
            Name = "QaytarmaFormu";
            Padding = new Padding(4, 74, 4, 3);
            Text = "Qaytarma";
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSatisMehsullari).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialCard pnlMain;
        private MaterialSkin.Controls.MaterialButton btnQaytar;
        private MaterialSkin.Controls.MaterialButton btnAxtar;
        private MaterialSkin.Controls.MaterialTextBox2 txtSatisNomresi;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.DataGridView dgvSatisMehsullari;
        private MaterialSkin.Controls.MaterialTextBox2 txtQaytarmaSebebi;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private ErrorProvider errorProvider1;
    }
}