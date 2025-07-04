using System;

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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gbRepairDetails = new System.Windows.Forms.GroupBox();
            this.cmbTechnician = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnAddPart = new System.Windows.Forms.Button();
            this.numPartQuantity = new System.Windows.Forms.NumericUpDown();
            this.txtPartSearch = new System.Windows.Forms.TextBox();
            this.dgvSpareParts = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRepairs)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbRepairDetails.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPartQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpareParts)).BeginInit();
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
            this.dgvRepairs.Size = new System.Drawing.Size(973, 501);
            this.dgvRepairs.TabIndex = 0;
            this.dgvRepairs.SelectionChanged += new System.EventHandler(this.dgvRepairs_SelectionChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(987, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(262, 501);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gbRepairDetails);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(254, 444);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Əsas Məlumatlar";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gbRepairDetails
            // 
            this.gbRepairDetails.Controls.Add(this.cmbTechnician);
            this.gbRepairDetails.Controls.Add(this.label8);
            this.gbRepairDetails.Controls.Add(this.btnClear);
            this.gbRepairDetails.Controls.Add(this.btnDelete);
            this.gbRepairDetails.Controls.Add(this.btnUpdate);
            this.gbRepairDetails.Controls.Add(this.btnAdd);
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
            this.gbRepairDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbRepairDetails.Location = new System.Drawing.Point(3, 3);
            this.gbRepairDetails.Margin = new System.Windows.Forms.Padding(2);
            this.gbRepairDetails.Name = "gbRepairDetails";
            this.gbRepairDetails.Padding = new System.Windows.Forms.Padding(2);
            this.gbRepairDetails.Size = new System.Drawing.Size(248, 438);
            this.gbRepairDetails.TabIndex = 0;
            this.gbRepairDetails.TabStop = false;
            this.gbRepairDetails.Text = "Təmir Məlumatları";
            // 
            // cmbTechnician
            // 
            this.cmbTechnician.Location = new System.Drawing.Point(0, 0);
            this.cmbTechnician.Name = "cmbTechnician";
            this.cmbTechnician.Size = new System.Drawing.Size(121, 21);
            this.cmbTechnician.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 1;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(0, 0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 2;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(0, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(0, 0);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 4;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(0, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            // 
            // lblSelectedCustomer
            // 
            this.lblSelectedCustomer.Location = new System.Drawing.Point(0, 0);
            this.lblSelectedCustomer.Name = "lblSelectedCustomer";
            this.lblSelectedCustomer.Size = new System.Drawing.Size(100, 23);
            this.lblSelectedCustomer.TabIndex = 6;
            // 
            // btnSelectCustomer
            // 
            this.btnSelectCustomer.Location = new System.Drawing.Point(0, 0);
            this.btnSelectCustomer.Name = "btnSelectCustomer";
            this.btnSelectCustomer.Size = new System.Drawing.Size(75, 23);
            this.btnSelectCustomer.TabIndex = 7;
            // 
            // cmbStatus
            // 
            this.cmbStatus.Location = new System.Drawing.Point(0, 0);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbStatus.TabIndex = 8;
            // 
            // txtProblem
            // 
            this.txtProblem.Location = new System.Drawing.Point(0, 0);
            this.txtProblem.Name = "txtProblem";
            this.txtProblem.Size = new System.Drawing.Size(100, 20);
            this.txtProblem.TabIndex = 9;
            // 
            // txtSeriyaNomresi
            // 
            this.txtSeriyaNomresi.Location = new System.Drawing.Point(0, 0);
            this.txtSeriyaNomresi.Name = "txtSeriyaNomresi";
            this.txtSeriyaNomresi.Size = new System.Drawing.Size(100, 20);
            this.txtSeriyaNomresi.TabIndex = 10;
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(0, 0);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(100, 20);
            this.txtModel.TabIndex = 11;
            // 
            // txtMarka
            // 
            this.txtMarka.Location = new System.Drawing.Point(0, 0);
            this.txtMarka.Name = "txtMarka";
            this.txtMarka.Size = new System.Drawing.Size(100, 20);
            this.txtMarka.TabIndex = 12;
            // 
            // txtCihazAdi
            // 
            this.txtCihazAdi.Location = new System.Drawing.Point(0, 0);
            this.txtCihazAdi.Name = "txtCihazAdi";
            this.txtCihazAdi.Size = new System.Drawing.Size(100, 20);
            this.txtCihazAdi.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 20;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnAddPart);
            this.tabPage2.Controls.Add(this.numPartQuantity);
            this.tabPage2.Controls.Add(this.txtPartSearch);
            this.tabPage2.Controls.Add(this.dgvSpareParts);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(254, 475);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Ehtiyat Hissələri";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnAddPart
            // 
            this.btnAddPart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddPart.Location = new System.Drawing.Point(170, 441);
            this.btnAddPart.Name = "btnAddPart";
            this.btnAddPart.Size = new System.Drawing.Size(75, 23);
            this.btnAddPart.TabIndex = 3;
            this.btnAddPart.Text = "Əlavə Et";
            this.btnAddPart.UseVisualStyleBackColor = true;
            this.btnAddPart.Click += new System.EventHandler(this.btnAddPart_Click_1);
            // 
            // numPartQuantity
            // 
            this.numPartQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numPartQuantity.Location = new System.Drawing.Point(6, 442);
            this.numPartQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPartQuantity.Name = "numPartQuantity";
            this.numPartQuantity.Size = new System.Drawing.Size(60, 20);
            this.numPartQuantity.TabIndex = 2;
            this.numPartQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtPartSearch
            // 
            this.txtPartSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPartSearch.Location = new System.Drawing.Point(6, 6);
            this.txtPartSearch.Name = "txtPartSearch";
            this.txtPartSearch.Size = new System.Drawing.Size(242, 20);
            this.txtPartSearch.TabIndex = 1;
            // 
            // dgvSpareParts
            // 
            this.dgvSpareParts.AllowUserToAddRows = false;
            this.dgvSpareParts.AllowUserToDeleteRows = false;
            this.dgvSpareParts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSpareParts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSpareParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSpareParts.Location = new System.Drawing.Point(6, 32);
            this.dgvSpareParts.Name = "dgvSpareParts";
            this.dgvSpareParts.ReadOnly = true;
            this.dgvSpareParts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSpareParts.Size = new System.Drawing.Size(242, 403);
            this.dgvSpareParts.TabIndex = 0;
            // 
            // frmRepairs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 553);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dgvRepairs);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(679, 414);
            this.Name = "frmRepairs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Təmir İdarəçiliyi";
            this.Load += new System.EventHandler(this.frmRepairs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRepairs)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.gbRepairDetails.ResumeLayout(false);
            this.gbRepairDetails.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPartQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpareParts)).EndInit();
            this.ResumeLayout(false);

        }

        //private void txtPartSearch_TextChanged(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        #endregion

        private System.Windows.Forms.DataGridView dgvRepairs;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox gbRepairDetails;
        private System.Windows.Forms.ComboBox cmbTechnician;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
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
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnAddPart;
        private System.Windows.Forms.NumericUpDown numPartQuantity;
        private System.Windows.Forms.TextBox txtPartSearch;
        private System.Windows.Forms.DataGridView dgvSpareParts;
    }
}