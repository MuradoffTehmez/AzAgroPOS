namespace AzAgroPOS.Teqdimat
{
    partial class QebzFormu
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
            lblBasliq = new Label();
            tblMelumatlar = new TableLayoutPanel();
            panel1 = new Panel();
            btnCapEt = new Button();
            btnBagla = new Button();
            errorProvider1 = new ErrorProvider(components);
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblBasliq
            // 
            lblBasliq.BackColor = Color.FromArgb(20, 25, 72);
            lblBasliq.Dock = DockStyle.Top;
            lblBasliq.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            lblBasliq.ForeColor = Color.White;
            lblBasliq.Location = new Point(0, 0);
            lblBasliq.Name = "lblBasliq";
            lblBasliq.Size = new Size(504, 40);
            lblBasliq.TabIndex = 0;
            lblBasliq.Text = "Qəbz";
            lblBasliq.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tblMelumatlar
            // 
            tblMelumatlar.ColumnCount = 2;
            tblMelumatlar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tblMelumatlar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tblMelumatlar.Dock = DockStyle.Fill;
            tblMelumatlar.Location = new Point(0, 40);
            tblMelumatlar.Name = "tblMelumatlar";
            tblMelumatlar.Padding = new Padding(10);
            tblMelumatlar.RowCount = 1;
            tblMelumatlar.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblMelumatlar.Size = new Size(504, 371);
            tblMelumatlar.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCapEt);
            panel1.Controls.Add(btnBagla);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 411);
            panel1.Name = "panel1";
            panel1.Size = new Size(504, 50);
            panel1.TabIndex = 2;
            // 
            // btnCapEt
            // 
            btnCapEt.Location = new Point(336, 12);
            btnCapEt.Name = "btnCapEt";
            btnCapEt.Size = new Size(75, 27);
            btnCapEt.TabIndex = 1;
            btnCapEt.Text = "Çap Et";
            btnCapEt.UseVisualStyleBackColor = true;
            btnCapEt.Click += btnCapEt_Click;
            // 
            // btnBagla
            // 
            btnBagla.Location = new Point(417, 12);
            btnBagla.Name = "btnBagla";
            btnBagla.Size = new Size(75, 27);
            btnBagla.TabIndex = 0;
            btnBagla.Text = "Bağla";
            btnBagla.UseVisualStyleBackColor = true;
            btnBagla.Click += btnBagla_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // QebzFormu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(504, 461);
            Controls.Add(tblMelumatlar);
            Controls.Add(panel1);
            Controls.Add(lblBasliq);
            Name = "QebzFormu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Qəbz";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblBasliq;
        private TableLayoutPanel tblMelumatlar;
        private Panel panel1;
        private Button btnCapEt;
        private Button btnBagla;
        private ErrorProvider errorProvider1;
    }
}