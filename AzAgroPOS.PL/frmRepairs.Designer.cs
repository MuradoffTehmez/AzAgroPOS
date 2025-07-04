namespace AzAgroPOS.PL
{
    partial class frmRepairs
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
            this.dgvRepairs = new System.Windows.Forms.DataGridView();
            this.gbRepairDetails = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblSelectedCustomer = new System.Windows.Forms.Label();
            this.btnSelectCustomer = new System.Windows.Forms.Button();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.txtProblem = new System.Windows.Forms.TextBox();
            this.txtSeriyaNomresi = new System.Windows.Forms.TextBox();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtMarka = new System.Windows.Forms.TextBox();
            this.txtCihazAdi = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRepairs)).BeginInit();
            this.gbRepairDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvRepairs
            // 
            this.dgvRepairs.AllowUserToAddRows = false;
            this.dgvRepairs.AllowUserToDeleteRows = false;
            this.dgvRepairs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRepairs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRepairs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRepairs.Location = new System.Drawing.Point(9, 10);
            this.dgvRepairs.Margin = new System.Windows.Forms.Padding(2);
            this.dgvRepairs.Name = "dgvRepairs";
            this.dgvRepairs.ReadOnly = true;
            this.dgvRepairs.RowHeadersWidth = 51;
            this.dgvRepairs.RowTemplate.Height = 24;
            this.dgvRepairs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRepairs.Size = new System.Drawing.Size(1119, 619);
            this.dgvRepairs.TabIndex = 0;
            // 
            // gbRepairDetails
            // 
            this.gbRepairDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbRepairDetails.Controls.Add(this.btnClear);
            this.gbRepairDetails.Controls.Add(this.btnDelete);
            this.gbRepairDetails.Controls.Add(this.btnUpdate);
            this.gbRepairDetails.Controls.Add(this.btnSave);
            this.gbRepairDetails.Controls.Add(this.lblSelectedCustomer);
            this.gbRepairDetails.Controls.Add(this.btnSelectCustomer);
            this.gbRepairDetails.Controls.Add(this.cmbStatus);
            this.gbRepairDetails.Controls.Add(this.txtProblem);
            this.gbRepairDetails.Controls.Add(this.txtSeriyaNomresi);
            this.gbRepairDetails.Controls.Add(this.txtModel);
            this.gbRepairDetails.Controls.Add(this.txtMarka);
            this.gbRepairDetails.Controls.Add(this.txtCihazAdi);
            this.gbRepairDetails.Controls.Add(this.label7);
            this.gbRepairDetails.Controls.Add(this.label6);
            this.gbRepairDetails.Controls.Add(this.label5);
            this.gbRepairDetails.Controls.Add(this.label4);
            this.gbRepairDetails.Controls.Add(this.label3);
            this.gbRepairDetails.Controls.Add(this.label2);
            this.gbRepairDetails.Controls.Add(this.label1);
            this.gbRepairDetails.Location = new System.Drawing.Point(1132, 9);
            this.gbRepairDetails.Margin = new System.Windows.Forms.Padding(2);
            this.gbRepairDetails.Name = "gbRepairDetails";
            this.gbRepairDetails.Padding = new System.Windows.Forms.Padding(2);
            this.gbRepairDetails.Size = new System.Drawing.Size(259, 619);
            this.gbRepairDetails.TabIndex = 1;
            this.gbRepairDetails.TabStop = false;
            this.gbRepairDetails.Text = "Təmir Məlumatları";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(21, 385);
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
            this.btnDelete.Location = new System.Drawing.Point(181, 353);
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
            this.btnUpdate.Location = new System.Drawing.Point(101, 353);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(66, 28);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Yenilə";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(21, 353);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 28);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Yadda Saxla";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblSelectedCustomer
            // 
            this.lblSelectedCustomer.AutoSize = true;
            this.lblSelectedCustomer.Location = new System.Drawing.Point(115, 79);
            this.lblSelectedCustomer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSelectedCustomer.Name = "lblSelectedCustomer";
            this.lblSelectedCustomer.Size = new System.Drawing.Size(0, 13);
            this.lblSelectedCustomer.TabIndex = 9;
            // 
            // btnSelectCustomer
            // 
            this.btnSelectCustomer.Location = new System.Drawing.Point(21, 24);
            this.btnSelectCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectCustomer.Name = "btnSelectCustomer";
            this.btnSelectCustomer.Size = new System.Drawing.Size(94, 28);
            this.btnSelectCustomer.TabIndex = 8;
            this.btnSelectCustomer.Text = "Müştəri Seç";
            this.btnSelectCustomer.UseVisualStyleBackColor = true;
            this.btnSelectCustomer.Click += new System.EventHandler(this.btnSelectCustomer_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(101, 308);
            this.cmbStatus.Margin = new System.Windows.Forms.Padding(2);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(140, 21);
            this.cmbStatus.TabIndex = 7;
            // 
            // txtProblem
            // 
            this.txtProblem.Location = new System.Drawing.Point(101, 226);
            this.txtProblem.Margin = new System.Windows.Forms.Padding(2);
            this.txtProblem.Multiline = true;
            this.txtProblem.Name = "txtProblem";
            this.txtProblem.Size = new System.Drawing.Size(140, 78);
            this.txtProblem.TabIndex = 6;
            // 
            // txtSeriyaNomresi
            // 
            this.txtSeriyaNomresi.Location = new System.Drawing.Point(101, 198);
            this.txtSeriyaNomresi.Margin = new System.Windows.Forms.Padding(2);
            this.txtSeriyaNomresi.Name = "txtSeriyaNomresi";
            this.txtSeriyaNomresi.Size = new System.Drawing.Size(140, 20);
            this.txtSeriyaNomresi.TabIndex = 5;
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(101, 170);
            this.txtModel.Margin = new System.Windows.Forms.Padding(2);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(140, 20);
            this.txtModel.TabIndex = 4;
            // 
            // txtMarka
            // 
            this.txtMarka.Location = new System.Drawing.Point(101, 142);
            this.txtMarka.Margin = new System.Windows.Forms.Padding(2);
            this.txtMarka.Name = "txtMarka";
            this.txtMarka.Size = new System.Drawing.Size(140, 20);
            this.txtMarka.TabIndex = 3;
            // 
            // txtCihazAdi
            // 
            this.txtCihazAdi.Location = new System.Drawing.Point(101, 114);
            this.txtCihazAdi.Margin = new System.Windows.Forms.Padding(2);
            this.txtCihazAdi.Name = "txtCihazAdi";
            this.txtCihazAdi.Size = new System.Drawing.Size(140, 20);
            this.txtCihazAdi.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(47, 313);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Status:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 233);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Problem Təsviri:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 205);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Seriya Nömrəsi:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 177);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Model:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 149);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Marka:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 121);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cihaz Adı:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 79);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Müştəri:";
            // 
            // frmRepairs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1402, 639);
            this.Controls.Add(this.gbRepairDetails);
            this.Controls.Add(this.dgvRepairs);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(679, 414);
            this.Name = "frmRepairs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Təmir İdarəçiliyi";
            this.Load += new System.EventHandler(this.frmRepairs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRepairs)).EndInit();
            this.gbRepairDetails.ResumeLayout(false);
            this.gbRepairDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRepairs;
        private System.Windows.Forms.GroupBox gbRepairDetails;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblSelectedCustomer;
        private System.Windows.Forms.Button btnSelectCustomer;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.TextBox txtProblem;
        private System.Windows.Forms.TextBox txtSeriyaNomresi;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtMarka;
        private System.Windows.Forms.TextBox txtCihazAdi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}