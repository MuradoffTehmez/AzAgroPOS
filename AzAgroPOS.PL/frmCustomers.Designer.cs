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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomers));
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.gbCustomerDetails = new System.Windows.Forms.GroupBox();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
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
            this.panelHeader.SuspendLayout();
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
            this.dgvCustomers.BackgroundColor = System.Drawing.Color.White;
            this.dgvCustomers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.dgvCustomers.Location = new System.Drawing.Point(12, 60);
            this.dgvCustomers.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.RowHeadersWidth = 30;
            this.dgvCustomers.RowTemplate.Height = 28;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(800, 550);
            this.dgvCustomers.TabIndex = 0;
            //this.dgvCustomers.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCustomers_CellFormatting);
            this.dgvCustomers.SelectionChanged += new System.EventHandler(this.dgvCustomers_SelectionChanged);
            // 
            // gbCustomerDetails
            // 
            this.gbCustomerDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCustomerDetails.BackColor = System.Drawing.Color.White;
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
            this.gbCustomerDetails.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCustomerDetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.gbCustomerDetails.Location = new System.Drawing.Point(820, 60);
            this.gbCustomerDetails.Name = "gbCustomerDetails";
            this.gbCustomerDetails.Size = new System.Drawing.Size(350, 550);
            this.gbCustomerDetails.TabIndex = 1;
            this.gbCustomerDetails.TabStop = false;
            this.gbCustomerDetails.Text = "Müştəri Məlumatları";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1182, 50);
            this.panelHeader.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(168, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Müştəri İdarəçiliyi";
            // 
            // chkAktivdir
            // 
            this.chkAktivdir.AutoSize = true;
            this.chkAktivdir.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.chkAktivdir.Location = new System.Drawing.Point(120, 280);
            this.chkAktivdir.Name = "chkAktivdir";
            this.chkAktivdir.Size = new System.Drawing.Size(70, 21);
            this.chkAktivdir.TabIndex = 9;
            this.chkAktivdir.Text = "Aktivdir";
            this.chkAktivdir.UseVisualStyleBackColor = true;
            // 
            // txtQeyd
            // 
            this.txtQeyd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQeyd.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtQeyd.Location = new System.Drawing.Point(120, 250);
            this.txtQeyd.Name = "txtQeyd";
            this.txtQeyd.Size = new System.Drawing.Size(200, 25);
            this.txtQeyd.TabIndex = 8;
            // 
            // txtEndirimFaizi
            // 
            this.txtEndirimFaizi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEndirimFaizi.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtEndirimFaizi.Location = new System.Drawing.Point(120, 220);
            this.txtEndirimFaizi.Name = "txtEndirimFaizi";
            this.txtEndirimFaizi.Size = new System.Drawing.Size(200, 25);
            this.txtEndirimFaizi.TabIndex = 7;
            // 
            // txtNisyeLimiti
            // 
            this.txtNisyeLimiti.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNisyeLimiti.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtNisyeLimiti.Location = new System.Drawing.Point(120, 190);
            this.txtNisyeLimiti.Name = "txtNisyeLimiti";
            this.txtNisyeLimiti.Size = new System.Drawing.Size(200, 25);
            this.txtNisyeLimiti.TabIndex = 6;
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtEmail.Location = new System.Drawing.Point(120, 160);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 25);
            this.txtEmail.TabIndex = 5;
            // 
            // txtUnvan
            // 
            this.txtUnvan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnvan.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtUnvan.Location = new System.Drawing.Point(120, 130);
            this.txtUnvan.Name = "txtUnvan";
            this.txtUnvan.Size = new System.Drawing.Size(200, 25);
            this.txtUnvan.TabIndex = 4;
            // 
            // txtTelefon
            // 
            this.txtTelefon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefon.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtTelefon.Location = new System.Drawing.Point(120, 100);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(200, 25);
            this.txtTelefon.TabIndex = 3;
            // 
            // txtSoyad
            // 
            this.txtSoyad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSoyad.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtSoyad.Location = new System.Drawing.Point(120, 70);
            this.txtSoyad.Name = "txtSoyad";
            this.txtSoyad.Size = new System.Drawing.Size(200, 25);
            this.txtSoyad.TabIndex = 2;
            // 
            // txtAd
            // 
            this.txtAd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAd.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtAd.Location = new System.Drawing.Point(120, 40);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(200, 25);
            this.txtAd.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label8.Location = new System.Drawing.Point(20, 253);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Qeyd:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label7.Location = new System.Drawing.Point(20, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Endirim Faizi (%):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label6.Location = new System.Drawing.Point(20, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Nisyə Limiti:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label5.Location = new System.Drawing.Point(20, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Email:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label4.Location = new System.Drawing.Point(20, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ünvan:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label3.Location = new System.Drawing.Point(20, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Telefon:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label2.Location = new System.Drawing.Point(20, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Soyad:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label1.Location = new System.Drawing.Point(20, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ad:";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(20, 480);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(300, 40);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Təmizlə";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(220, 430);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 40);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(110, 430);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 40);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Yenilə";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(20, 430);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 40);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Əlavə Et";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1182, 622);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.gbCustomerDetails);
            this.Controls.Add(this.dgvCustomers);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "frmCustomers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Müştəri İdarəçiliyi";
            this.Load += new System.EventHandler(this.frmCustomers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.gbCustomerDetails.ResumeLayout(false);
            this.gbCustomerDetails.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.GroupBox gbCustomerDetails;
        private System.Windows.Forms.CheckBox chkAktivdir;
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
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
    }
}