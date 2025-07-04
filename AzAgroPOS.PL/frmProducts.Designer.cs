namespace AzAgroPOS.PL
{
    partial class frmProducts
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
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.gbProductDetails = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cmbVahid = new System.Windows.Forms.ComboBox();
            this.cmbKateqoriya = new System.Windows.Forms.ComboBox();
            this.txtMinimumStok = new System.Windows.Forms.TextBox();
            this.txtSatisQiymeti = new System.Windows.Forms.TextBox();
            this.txtAlisQiymeti = new System.Windows.Forms.TextBox();
            this.txtBarkod = new System.Windows.Forms.TextBox();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.gbProductDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(9, 10);
            this.dgvProducts.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.RowTemplate.Height = 24;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(614, 470);
            this.dgvProducts.TabIndex = 0;
            // 
            // gbProductDetails
            // 
            this.gbProductDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbProductDetails.Controls.Add(this.btnClear);
            this.gbProductDetails.Controls.Add(this.btnDelete);
            this.gbProductDetails.Controls.Add(this.btnUpdate);
            this.gbProductDetails.Controls.Add(this.btnAdd);
            this.gbProductDetails.Controls.Add(this.cmbVahid);
            this.gbProductDetails.Controls.Add(this.cmbKateqoriya);
            this.gbProductDetails.Controls.Add(this.txtMinimumStok);
            this.gbProductDetails.Controls.Add(this.txtSatisQiymeti);
            this.gbProductDetails.Controls.Add(this.txtAlisQiymeti);
            this.gbProductDetails.Controls.Add(this.txtBarkod);
            this.gbProductDetails.Controls.Add(this.txtAd);
            this.gbProductDetails.Controls.Add(this.label7);
            this.gbProductDetails.Controls.Add(this.label6);
            this.gbProductDetails.Controls.Add(this.label5);
            this.gbProductDetails.Controls.Add(this.label4);
            this.gbProductDetails.Controls.Add(this.label3);
            this.gbProductDetails.Controls.Add(this.label2);
            this.gbProductDetails.Controls.Add(this.label1);
            this.gbProductDetails.Location = new System.Drawing.Point(627, 10);
            this.gbProductDetails.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbProductDetails.Name = "gbProductDetails";
            this.gbProductDetails.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gbProductDetails.Size = new System.Drawing.Size(252, 470);
            this.gbProductDetails.TabIndex = 1;
            this.gbProductDetails.TabStop = false;
            this.gbProductDetails.Text = "Məhsul Məlumatları";
            this.gbProductDetails.Enter += new System.EventHandler(this.gbProductDetails_Enter);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(14, 292);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(226, 28);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Təmizlə";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(174, 259);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(66, 28);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(94, 259);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(66, 28);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Yenilə";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(14, 259);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(66, 28);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Əlavə Et";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cmbVahid
            // 
            this.cmbVahid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVahid.FormattingEnabled = true;
            this.cmbVahid.Location = new System.Drawing.Point(101, 111);
            this.cmbVahid.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbVahid.Name = "cmbVahid";
            this.cmbVahid.Size = new System.Drawing.Size(140, 21);
            this.cmbVahid.TabIndex = 4;
            // 
            // cmbKateqoriya
            // 
            this.cmbKateqoriya.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKateqoriya.FormattingEnabled = true;
            this.cmbKateqoriya.Location = new System.Drawing.Point(101, 83);
            this.cmbKateqoriya.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbKateqoriya.Name = "cmbKateqoriya";
            this.cmbKateqoriya.Size = new System.Drawing.Size(140, 21);
            this.cmbKateqoriya.TabIndex = 3;
            // 
            // txtMinimumStok
            // 
            this.txtMinimumStok.Location = new System.Drawing.Point(101, 197);
            this.txtMinimumStok.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMinimumStok.Name = "txtMinimumStok";
            this.txtMinimumStok.Size = new System.Drawing.Size(140, 20);
            this.txtMinimumStok.TabIndex = 6;
            // 
            // txtSatisQiymeti
            // 
            this.txtSatisQiymeti.Location = new System.Drawing.Point(101, 168);
            this.txtSatisQiymeti.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSatisQiymeti.Name = "txtSatisQiymeti";
            this.txtSatisQiymeti.Size = new System.Drawing.Size(140, 20);
            this.txtSatisQiymeti.TabIndex = 5;
            // 
            // txtAlisQiymeti
            // 
            this.txtAlisQiymeti.Location = new System.Drawing.Point(101, 140);
            this.txtAlisQiymeti.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAlisQiymeti.Name = "txtAlisQiymeti";
            this.txtAlisQiymeti.Size = new System.Drawing.Size(140, 20);
            this.txtAlisQiymeti.TabIndex = 4;
            // 
            // txtBarkod
            // 
            this.txtBarkod.Location = new System.Drawing.Point(101, 54);
            this.txtBarkod.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBarkod.Name = "txtBarkod";
            this.txtBarkod.Size = new System.Drawing.Size(140, 20);
            this.txtBarkod.TabIndex = 2;
            // 
            // txtAd
            // 
            this.txtAd.Location = new System.Drawing.Point(101, 26);
            this.txtAd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(140, 20);
            this.txtAd.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 199);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Minimum Stok:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 171);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Satış Qiyməti:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 142);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Alış Qiyməti:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 114);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Vahid:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Kateqoria:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Barkod:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Məhsul Adı:";
            // 
            // frmProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 490);
            this.Controls.Add(this.gbProductDetails);
            this.Controls.Add(this.dgvProducts);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(679, 414);
            this.Name = "frmProducts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Məhsul İdarəçiliyi";
            this.Load += new System.EventHandler(this.frmProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.gbProductDetails.ResumeLayout(false);
            this.gbProductDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.GroupBox gbProductDetails;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cmbVahid;
        private System.Windows.Forms.ComboBox cmbKateqoriya;
        private System.Windows.Forms.TextBox txtMinimumStok;
        private System.Windows.Forms.TextBox txtSatisQiymeti;
        private System.Windows.Forms.TextBox txtAlisQiymeti;
        private System.Windows.Forms.TextBox txtBarkod;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}