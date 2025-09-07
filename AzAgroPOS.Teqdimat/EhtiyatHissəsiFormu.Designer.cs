namespace AzAgroPOS.Teqdimat
{
    partial class EhtiyatHissəsiFormu
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            lblBaslik = new Label();
            splitContainer1 = new SplitContainer();
            groupBox1 = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            txtAxtar = new TextBox();
            dgvMehsullar = new DataGridView();
            groupBox2 = new GroupBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            label2 = new Label();
            txtMiqdar = new TextBox();
            btnElaveEt = new Button();
            dgvSeçilmişMehsullar = new DataGridView();
            tableLayoutPanel3 = new TableLayoutPanel();
            btnSil = new Button();
            btnİmtina = new Button();
            btnTamam = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMehsullar).BeginInit();
            groupBox2.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSeçilmişMehsullar).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lblBaslik
            // 
            lblBaslik.BackColor = Color.FromArgb(20, 25, 72);
            lblBaslik.Dock = DockStyle.Top;
            lblBaslik.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblBaslik.ForeColor = Color.White;
            lblBaslik.Location = new Point(0, 0);
            lblBaslik.Name = "lblBaslik";
            lblBaslik.Size = new Size(1004, 40);
            lblBaslik.TabIndex = 0;
            lblBaslik.Text = "Ehtiyat Hissəsi Əlavə Et";
            lblBaslik.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 40);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(groupBox2);
            splitContainer1.Size = new Size(1004, 521);
            splitContainer1.SplitterDistance = 500;
            splitContainer1.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(tableLayoutPanel1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(500, 521);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Məhsullar";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(txtAxtar, 1, 0);
            tableLayoutPanel1.Controls.Add(dgvMehsullar, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 19);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(494, 499);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(92, 30);
            label1.TabIndex = 0;
            label1.Text = "Axtar:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtAxtar
            // 
            txtAxtar.Dock = DockStyle.Fill;
            txtAxtar.Location = new Point(101, 3);
            txtAxtar.Name = "txtAxtar";
            txtAxtar.Size = new Size(390, 23);
            txtAxtar.TabIndex = 1;
            txtAxtar.TextChanged += txtAxtar_TextChanged;
            // 
            // dgvMehsullar
            // 
            dgvMehsullar.AllowUserToAddRows = false;
            dgvMehsullar.AllowUserToDeleteRows = false;
            dgvMehsullar.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(224, 224, 224);
            dgvMehsullar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvMehsullar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(20, 25, 72);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvMehsullar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvMehsullar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableLayoutPanel1.SetColumnSpan(dgvMehsullar, 2);
            dgvMehsullar.Dock = DockStyle.Fill;
            dgvMehsullar.EnableHeadersVisualStyles = false;
            dgvMehsullar.Location = new Point(3, 33);
            dgvMehsullar.MultiSelect = false;
            dgvMehsullar.Name = "dgvMehsullar";
            dgvMehsullar.ReadOnly = true;
            dgvMehsullar.RowHeadersVisible = false;
            dgvMehsullar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMehsullar.Size = new Size(488, 463);
            dgvMehsullar.TabIndex = 2;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(tableLayoutPanel2);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(500, 521);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Seçilmiş Məhsullar";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel2.Controls.Add(label2, 0, 0);
            tableLayoutPanel2.Controls.Add(txtMiqdar, 1, 0);
            tableLayoutPanel2.Controls.Add(btnElaveEt, 2, 0);
            tableLayoutPanel2.Controls.Add(dgvSeçilmişMehsullar, 0, 1);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 2);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 19);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel2.Size = new Size(494, 499);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(142, 30);
            label2.TabIndex = 0;
            label2.Text = "Miqdar:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtMiqdar
            // 
            txtMiqdar.Dock = DockStyle.Fill;
            txtMiqdar.Location = new Point(151, 3);
            txtMiqdar.Name = "txtMiqdar";
            txtMiqdar.Size = new Size(191, 23);
            txtMiqdar.TabIndex = 1;
            txtMiqdar.Text = "1";
            // 
            // btnElaveEt
            // 
            btnElaveEt.Dock = DockStyle.Fill;
            btnElaveEt.Location = new Point(348, 3);
            btnElaveEt.Name = "btnElaveEt";
            btnElaveEt.Size = new Size(143, 24);
            btnElaveEt.TabIndex = 2;
            btnElaveEt.Text = "Əlavə Et";
            btnElaveEt.UseVisualStyleBackColor = true;
            btnElaveEt.Click += btnElaveEt_Click;
            // 
            // dgvSeçilmişMehsullar
            // 
            dgvSeçilmişMehsullar.AllowUserToAddRows = false;
            dgvSeçilmişMehsullar.AllowUserToDeleteRows = false;
            dgvSeçilmişMehsullar.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(224, 224, 224);
            dgvSeçilmişMehsullar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvSeçilmişMehsullar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(20, 25, 72);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvSeçilmişMehsullar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvSeçilmişMehsullar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableLayoutPanel2.SetColumnSpan(dgvSeçilmişMehsullar, 3);
            dgvSeçilmişMehsullar.Dock = DockStyle.Fill;
            dgvSeçilmişMehsullar.EnableHeadersVisualStyles = false;
            dgvSeçilmişMehsullar.Location = new Point(3, 33);
            dgvSeçilmişMehsullar.MultiSelect = false;
            dgvSeçilmişMehsullar.Name = "dgvSeçilmişMehsullar";
            dgvSeçilmişMehsullar.ReadOnly = true;
            dgvSeçilmişMehsullar.RowHeadersVisible = false;
            dgvSeçilmişMehsullar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSeçilmişMehsullar.Size = new Size(488, 423);
            dgvSeçilmişMehsullar.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            tableLayoutPanel3.Controls.Add(btnSil, 0, 0);
            tableLayoutPanel3.Controls.Add(btnİmtina, 1, 0);
            tableLayoutPanel3.Controls.Add(btnTamam, 2, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 462);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(142, 34);
            tableLayoutPanel3.TabIndex = 4;
            // 
            // btnSil
            // 
            btnSil.Dock = DockStyle.Fill;
            btnSil.Location = new Point(3, 3);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(41, 28);
            btnSil.TabIndex = 0;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // btnİmtina
            // 
            btnİmtina.Dock = DockStyle.Fill;
            btnİmtina.Location = new Point(50, 3);
            btnİmtina.Name = "btnİmtina";
            btnİmtina.Size = new Size(41, 28);
            btnİmtina.TabIndex = 1;
            btnİmtina.Text = "İmtina";
            btnİmtina.UseVisualStyleBackColor = true;
            btnİmtina.Click += btnİmtina_Click;
            // 
            // btnTamam
            // 
            btnTamam.Dock = DockStyle.Fill;
            btnTamam.Location = new Point(97, 3);
            btnTamam.Name = "btnTamam";
            btnTamam.Size = new Size(42, 28);
            btnTamam.TabIndex = 2;
            btnTamam.Text = "Tamam";
            btnTamam.UseVisualStyleBackColor = true;
            btnTamam.Click += btnTamam_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // EhtiyatHissəsiFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1004, 561);
            Controls.Add(splitContainer1);
            Controls.Add(lblBaslik);
            Name = "EhtiyatHissəsiFormu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ehtiyat Hissəsi Əlavə Et";
            Load += EhtiyatHissəsiFormu_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMehsullar).EndInit();
            groupBox2.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSeçilmişMehsullar).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblBaslik;
        private SplitContainer splitContainer1;
        private GroupBox groupBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private TextBox txtAxtar;
        private DataGridView dgvMehsullar;
        private GroupBox groupBox2;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label2;
        private TextBox txtMiqdar;
        private Button btnElaveEt;
        private DataGridView dgvSeçilmişMehsullar;
        private TableLayoutPanel tableLayoutPanel3;
        private Button btnSil;
        private Button btnİmtina;
        private Button btnTamam;
        private ErrorProvider errorProvider1;
    }
}