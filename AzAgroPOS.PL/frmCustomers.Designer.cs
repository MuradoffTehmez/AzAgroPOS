namespace AzAgroPOS.PL
{
    partial class frmCustomers
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
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.gbCustomerDetails = new System.Windows.Forms.GroupBox();
            this.chkAktivdir = new System.Windows.Forms.CheckBox();
            this.txtQeyd = new System.Windows.Forms.TextBox();
            this.txtEndirimFaizi = new System.Windows.Forms.TextBox();
            this.txtNisyeLimiti = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtUnvan = new System.Windows.Forms.TextBox();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.txtSoyad = new System.Windows.Forms.TextBox();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.gbCustomerDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Location = new System.Drawing.Point(9, 10);
            this.dgvCustomers.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.RowHeadersWidth = 51;
            this.dgvCustomers.RowTemplate.Height = 24;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(1078, 619);
            this.dgvCustomers.TabIndex = 0;
            this.dgvCustomers.SelectionChanged += new System.EventHandler(this.dgvCustomers_SelectionChanged);
            // 
            // gbCustomerDetails
            // 
            this.gbCustomerDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCustomerDetails.Controls.Add(this.chkAktivdir);
            this.gbCustomerDetails.Controls.Add(this.txtQeyd);
            this.gbCustomerDetails.Controls.Add(this.txtEndirimFaizi);
            this.gbCustomerDetails.Controls.Add(this.txtNisyeLimiti);
            this.gbCustomerDetails.Controls.Add(this.txtEmail);
            this.gbCustomerDetails.Controls.Add(this.txtUnvan);
            this.gbCustomerDetails.Controls.Add(this.txtTelefon);
            this.gbCustomerDetails.Controls.Add(this.txtSoyad);
            this.gbCustomerDetails.Controls.Add(this.txtAd);
            this.gbCustomerDetails.Controls.Add(this.label8);
            this.gbCustomerDetails.Controls.Add(this.label7);
            this.gbCustomerDetails.Controls.Add(this.label6);
            this.gbCustomerDetails.Controls.Add(this.label5);
            this.gbCustomerDetails.Controls.Add(this.label4);
            this.gbCustomerDetails.Controls.Add(this.label3);
            this.gbCustomerDetails.Controls.Add(this.label2);
            this.gbCustomerDetails.Controls.Add(this.label1);
            this.gbCustomerDetails.Controls.Add(this.btnClear);
            this.gbCustomerDetails.Controls.Add(this.btnDelete);
            this.gbCustomerDetails.Controls.Add(this.btnUpdate);
            this.gbCustomerDetails.Controls.Add(this.btnAdd);
            this.gbCustomerDetails.Location = new System.Drawing.Point(1091, 10);
            this.gbCustomerDetails.Margin = new System.Windows.Forms.Padding(2);
            this.gbCustomerDetails.Name = "gbCustomerDetails";
            this.gbCustomerDetails.Padding = new System.Windows.Forms.Padding(2);
            this.gbCustomerDetails.Size = new System.Drawing.Size(252, 619);
            this.gbCustomerDetails.TabIndex = 1;
            this.gbCustomerDetails.TabStop = false;
            this.gbCustomerDetails.Text = "Müştəri Məlumatları";
            // 
            // chkAktivdir
            // 
            this.chkAktivdir.AutoSize = true;
            this.chkAktivdir.Location = new System.Drawing.Point(101, 280);
            this.chkAktivdir.Name = "chkAktivdir";
            this.chkAktivdir.Size = new System.Drawing.Size(64, 17);
            this.chkAktivdir.TabIndex = 9;
            this.chkAktivdir.Text = "Aktivdir";
            this.chkAktivdir.UseVisualStyleBackColor = true;
            // 
            // txtQeyd
            // 
            this.txtQeyd.Location = new System.Drawing.Point(101, 254);
            this.txtQeyd.Margin = new System.Windows.Forms.Padding(2);
            this.txtQeyd.Name = "txtQeyd";
            this.txtQeyd.Size = new System.Drawing.Size(140, 20);
            this.txtQeyd.TabIndex = 8;
            // 
            // txtEndirimFaizi
            // 
            this.txtEndirimFaizi.Location = new System.Drawing.Point(101, 226);
            this.txtEndirimFaizi.Margin = new System.Windows.Forms.Padding(2);
            this.txtEndirimFaizi.Name = "txtEndirimFaizi";
            this.txtEndirimFaizi.Size = new System.Drawing.Size(140, 20);
            this.txtEndirimFaizi.TabIndex = 7;
            // 
            // txtNisyeLimiti
            // 
            this.txtNisyeLimiti.Location = new System.Drawing.Point(101, 198);
            this.txtNisyeLimiti.Margin = new System.Windows.Forms.Padding(2);
            this.txtNisyeLimiti.Name = "txtNisyeLimiti";
            this.txtNisyeLimiti.Size = new System.Drawing.Size(140, 20);
            this.txtNisyeLimiti.TabIndex = 6;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(101, 170);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(140, 20);
            this.txtEmail.TabIndex = 5;
            // 
            // txtUnvan
            // 
            this.txtUnvan.Location = new System.Drawing.Point(101, 142);
            this.txtUnvan.Margin = new System.Windows.Forms.Padding(2);
            this.txtUnvan.Name = "txtUnvan";
            this.txtUnvan.Size = new System.Drawing.Size(140, 20);
            this.txtUnvan.TabIndex = 4;
            // 
            // txtTelefon
            // 
            this.txtTelefon.Location = new System.Drawing.Point(101, 114);
            this.txtTelefon.Margin = new System.Windows.Forms.Padding(2);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(140, 20);
            this.txtTelefon.TabIndex = 3;
            // 
            // txtSoyad
            // 
            this.txtSoyad.Location = new System.Drawing.Point(101, 86);
            this.txtSoyad.Margin = new System.Windows.Forms.Padding(2);
            this.txtSoyad.Name = "txtSoyad";
            this.txtSoyad.Size = new System.Drawing.Size(140, 20);
            this.txtSoyad.TabIndex = 2;
            // 
            // txtAd
            // 
            this.txtAd.Location = new System.Drawing.Point(101, 58);
            this.txtAd.Margin = new System.Windows.Forms.Padding(2);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(140, 20);
            this.txtAd.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 256);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Qeyd:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 228);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Endirim Faizi (%):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 200);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Nisyə Limiti:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 172);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Email:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 144);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ünvan:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 116);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Telefon:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 88);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Soyad:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ad:";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(14, 330);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(226, 28);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Təmizlə";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(174, 298);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(66, 28);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(94, 298);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(66, 28);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Yenilə";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(14, 298);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(66, 28);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Əlavə Et";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 639);
            this.Controls.Add(this.gbCustomerDetails);
            this.Controls.Add(this.dgvCustomers);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(679, 414);
            this.Name = "frmCustomers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Müştəri İdarəçiliyi";
            this.Load += new System.EventHandler(this.frmCustomers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.gbCustomerDetails.ResumeLayout(false);
            this.gbCustomerDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.GroupBox gbCustomerDetails;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtQeyd;
        private System.Windows.Forms.TextBox txtEndirimFaizi;
        private System.Windows.Forms.TextBox txtNisyeLimiti;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtUnvan;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.TextBox txtSoyad;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAktivdir;
    }
}