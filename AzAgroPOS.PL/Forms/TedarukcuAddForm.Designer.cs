namespace AzAgroPOS.PL.Forms
{
    partial class TedarukcuAddForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblAd;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.Label lblKod;
        private System.Windows.Forms.TextBox txtKod;
        private System.Windows.Forms.Label lblUnvan;
        private System.Windows.Forms.TextBox txtUnvan;
        private System.Windows.Forms.Label lblTelefon;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

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
            lblAd = new System.Windows.Forms.Label();
            txtAd = new System.Windows.Forms.TextBox();
            lblKod = new System.Windows.Forms.Label();
            txtKod = new System.Windows.Forms.TextBox();
            lblUnvan = new System.Windows.Forms.Label();
            txtUnvan = new System.Windows.Forms.TextBox();
            lblTelefon = new System.Windows.Forms.Label();
            txtTelefon = new System.Windows.Forms.TextBox();
            lblEmail = new System.Windows.Forms.Label();
            txtEmail = new System.Windows.Forms.TextBox();
            btnSave = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // lblAd
            // 
            lblAd.AutoSize = true;
            lblAd.Location = new System.Drawing.Point(20, 20);
            lblAd.Name = "lblAd";
            lblAd.Size = new System.Drawing.Size(99, 19);
            lblAd.TabIndex = 0;
            lblAd.Text = "Tədarükçü Adı:";
            // 
            // txtAd
            // 
            txtAd.Location = new System.Drawing.Point(120, 18);
            txtAd.Name = "txtAd";
            txtAd.Size = new System.Drawing.Size(200, 25);
            txtAd.TabIndex = 1;
            // 
            // lblKod
            // 
            lblKod.AutoSize = true;
            lblKod.Location = new System.Drawing.Point(20, 60);
            lblKod.Name = "lblKod";
            lblKod.Size = new System.Drawing.Size(36, 19);
            lblKod.TabIndex = 2;
            lblKod.Text = "Kod:";
            // 
            // txtKod
            // 
            txtKod.Location = new System.Drawing.Point(120, 58);
            txtKod.Name = "txtKod";
            txtKod.Size = new System.Drawing.Size(200, 25);
            txtKod.TabIndex = 3;
            // 
            // lblUnvan
            // 
            lblUnvan.AutoSize = true;
            lblUnvan.Location = new System.Drawing.Point(20, 100);
            lblUnvan.Name = "lblUnvan";
            lblUnvan.Size = new System.Drawing.Size(52, 19);
            lblUnvan.TabIndex = 4;
            lblUnvan.Text = "Ünvan:";
            // 
            // txtUnvan
            // 
            txtUnvan.Location = new System.Drawing.Point(120, 98);
            txtUnvan.Name = "txtUnvan";
            txtUnvan.Size = new System.Drawing.Size(200, 25);
            txtUnvan.TabIndex = 5;
            // 
            // lblTelefon
            // 
            lblTelefon.AutoSize = true;
            lblTelefon.Location = new System.Drawing.Point(20, 140);
            lblTelefon.Name = "lblTelefon";
            lblTelefon.Size = new System.Drawing.Size(55, 19);
            lblTelefon.TabIndex = 6;
            lblTelefon.Text = "Telefon:";
            // 
            // txtTelefon
            // 
            txtTelefon.Location = new System.Drawing.Point(120, 138);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new System.Drawing.Size(200, 25);
            txtTelefon.TabIndex = 7;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new System.Drawing.Point(20, 180);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new System.Drawing.Size(44, 19);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new System.Drawing.Point(120, 178);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new System.Drawing.Size(200, 25);
            txtEmail.TabIndex = 9;
            // 
            // btnSave
            // 
            btnSave.Location = new System.Drawing.Point(120, 220);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(100, 23);
            btnSave.TabIndex = 10;
            btnSave.Text = "Yadda Saxla";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(230, 220);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(100, 23);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Ləğv Et";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // TedarukcuAddForm
            // 
            ClientSize = new System.Drawing.Size(784, 561);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtTelefon);
            Controls.Add(lblTelefon);
            Controls.Add(txtUnvan);
            Controls.Add(lblUnvan);
            Controls.Add(txtKod);
            Controls.Add(lblKod);
            Controls.Add(txtAd);
            Controls.Add(lblAd);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TedarukcuAddForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Yeni Tədarükçü";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}