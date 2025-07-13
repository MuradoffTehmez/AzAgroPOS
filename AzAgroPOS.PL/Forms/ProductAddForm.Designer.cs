namespace AzAgroPOS.PL.Forms
{
    partial class ProductAddForm
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.btnGenerateBarcode = new System.Windows.Forms.Button();
            this.lblSKU = new System.Windows.Forms.Label();
            this.txtSKU = new System.Windows.Forms.TextBox();
            this.btnGenerateSKU = new System.Windows.Forms.Button();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.lblPurchasePrice = new System.Windows.Forms.Label();
            this.txtPurchasePrice = new System.Windows.Forms.TextBox();
            this.lblSalePrice = new System.Windows.Forms.Label();
            this.txtSalePrice = new System.Windows.Forms.TextBox();
            this.lblCurrentStock = new System.Windows.Forms.Label();
            this.txtCurrentStock = new System.Windows.Forms.TextBox();
            this.lblMinStock = new System.Windows.Forms.Label();
            this.txtMinStock = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblProfit = new System.Windows.Forms.Label();
            this.lblProfitPercent = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.DarkBlue;
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(600, 60);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(200, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Məhsul Əlavə Etmə";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(30, 90);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(96, 22);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Məhsul Adı";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(170, 87);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(400, 29);
            this.txtName.TabIndex = 2;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(30, 130);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(58, 22);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Təsvir";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(170, 127);
            this.txtDescription.MaxLength = 500;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(400, 60);
            this.txtDescription.TabIndex = 4;
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Location = new System.Drawing.Point(30, 210);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(65, 22);
            this.lblBarcode.TabIndex = 5;
            this.lblBarcode.Text = "Barkod";
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(170, 207);
            this.txtBarcode.MaxLength = 50;
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(300, 29);
            this.txtBarcode.TabIndex = 6;
            // 
            // btnGenerateBarcode
            // 
            this.btnGenerateBarcode.BackColor = System.Drawing.Color.DarkOrange;
            this.btnGenerateBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateBarcode.ForeColor = System.Drawing.Color.White;
            this.btnGenerateBarcode.Location = new System.Drawing.Point(480, 207);
            this.btnGenerateBarcode.Name = "btnGenerateBarcode";
            this.btnGenerateBarcode.Size = new System.Drawing.Size(90, 29);
            this.btnGenerateBarcode.TabIndex = 7;
            this.btnGenerateBarcode.Text = "Avtomatik";
            this.btnGenerateBarcode.UseVisualStyleBackColor = false;
            this.btnGenerateBarcode.Click += new System.EventHandler(this.btnGenerateBarcode_Click);
            // 
            // lblSKU
            // 
            this.lblSKU.AutoSize = true;
            this.lblSKU.Location = new System.Drawing.Point(30, 250);
            this.lblSKU.Name = "lblSKU";
            this.lblSKU.Size = new System.Drawing.Size(44, 22);
            this.lblSKU.TabIndex = 8;
            this.lblSKU.Text = "SKU";
            // 
            // txtSKU
            // 
            this.txtSKU.Location = new System.Drawing.Point(170, 247);
            this.txtSKU.MaxLength = 50;
            this.txtSKU.Name = "txtSKU";
            this.txtSKU.Size = new System.Drawing.Size(300, 29);
            this.txtSKU.TabIndex = 9;
            // 
            // btnGenerateSKU
            // 
            this.btnGenerateSKU.BackColor = System.Drawing.Color.DarkOrange;
            this.btnGenerateSKU.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateSKU.ForeColor = System.Drawing.Color.White;
            this.btnGenerateSKU.Location = new System.Drawing.Point(480, 247);
            this.btnGenerateSKU.Name = "btnGenerateSKU";
            this.btnGenerateSKU.Size = new System.Drawing.Size(90, 29);
            this.btnGenerateSKU.TabIndex = 10;
            this.btnGenerateSKU.Text = "Avtomatik";
            this.btnGenerateSKU.UseVisualStyleBackColor = false;
            this.btnGenerateSKU.Click += new System.EventHandler(this.btnGenerateSKU_Click);
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(30, 290);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(94, 22);
            this.lblCategory.TabIndex = 11;
            this.lblCategory.Text = "Kateqoriya";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(170, 287);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(300, 30);
            this.cmbCategory.TabIndex = 12;
            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(30, 330);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(53, 22);
            this.lblUnit.TabIndex = 13;
            this.lblUnit.Text = "Vahid";
            // 
            // cmbUnit
            // 
            this.cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(170, 327);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(300, 30);
            this.cmbUnit.TabIndex = 14;
            // 
            // lblPurchasePrice
            // 
            this.lblPurchasePrice.AutoSize = true;
            this.lblPurchasePrice.Location = new System.Drawing.Point(30, 370);
            this.lblPurchasePrice.Name = "lblPurchasePrice";
            this.lblPurchasePrice.Size = new System.Drawing.Size(103, 22);
            this.lblPurchasePrice.TabIndex = 15;
            this.lblPurchasePrice.Text = "Alış Qiyməti";
            // 
            // txtPurchasePrice
            // 
            this.txtPurchasePrice.Location = new System.Drawing.Point(170, 367);
            this.txtPurchasePrice.Name = "txtPurchasePrice";
            this.txtPurchasePrice.Size = new System.Drawing.Size(150, 29);
            this.txtPurchasePrice.TabIndex = 16;
            this.txtPurchasePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPurchasePrice.TextChanged += new System.EventHandler(this.txtPrices_TextChanged);
            this.txtPurchasePrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrices_KeyPress);
            // 
            // lblSalePrice
            // 
            this.lblSalePrice.AutoSize = true;
            this.lblSalePrice.Location = new System.Drawing.Point(340, 370);
            this.lblSalePrice.Name = "lblSalePrice";
            this.lblSalePrice.Size = new System.Drawing.Size(108, 22);
            this.lblSalePrice.TabIndex = 17;
            this.lblSalePrice.Text = "Satış Qiyməti";
            // 
            // txtSalePrice
            // 
            this.txtSalePrice.Location = new System.Drawing.Point(454, 367);
            this.txtSalePrice.Name = "txtSalePrice";
            this.txtSalePrice.Size = new System.Drawing.Size(116, 29);
            this.txtSalePrice.TabIndex = 18;
            this.txtSalePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSalePrice.TextChanged += new System.EventHandler(this.txtPrices_TextChanged);
            this.txtSalePrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrices_KeyPress);
            // 
            // lblCurrentStock
            // 
            this.lblCurrentStock.AutoSize = true;
            this.lblCurrentStock.Location = new System.Drawing.Point(30, 450);
            this.lblCurrentStock.Name = "lblCurrentStock";
            this.lblCurrentStock.Size = new System.Drawing.Size(133, 22);
            this.lblCurrentStock.TabIndex = 21;
            this.lblCurrentStock.Text = "Mövcud Miqdar";
            // 
            // txtCurrentStock
            // 
            this.txtCurrentStock.Location = new System.Drawing.Point(170, 447);
            this.txtCurrentStock.Name = "txtCurrentStock";
            this.txtCurrentStock.Size = new System.Drawing.Size(150, 29);
            this.txtCurrentStock.TabIndex = 22;
            this.txtCurrentStock.Text = "0";
            this.txtCurrentStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCurrentStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // lblMinStock
            // 
            this.lblMinStock.AutoSize = true;
            this.lblMinStock.Location = new System.Drawing.Point(340, 450);
            this.lblMinStock.Name = "lblMinStock";
            this.lblMinStock.Size = new System.Drawing.Size(139, 22);
            this.lblMinStock.TabIndex = 23;
            this.lblMinStock.Text = "Minimum Miqdar";
            // 
            // txtMinStock
            // 
            this.txtMinStock.Location = new System.Drawing.Point(485, 447);
            this.txtMinStock.Name = "txtMinStock";
            this.txtMinStock.Size = new System.Drawing.Size(85, 29);
            this.txtMinStock.TabIndex = 24;
            this.txtMinStock.Text = "0";
            this.txtMinStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMinStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(30, 490);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(71, 22);
            this.lblNotes.TabIndex = 25;
            this.lblNotes.Text = "Qeydlər";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(170, 487);
            this.txtNotes.MaxLength = 500;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(400, 60);
            this.txtNotes.TabIndex = 26;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkGreen;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(250, 570);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Saxla";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Crimson;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(470, 570);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.Text = "Ləğv Et";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.DarkOrange;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(360, 570);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 40);
            this.btnClear.TabIndex = 28;
            this.btnClear.Text = "Təmizlə";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblProfit
            // 
            this.lblProfit.AutoSize = true;
            this.lblProfit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.lblProfit.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblProfit.Location = new System.Drawing.Point(170, 410);
            this.lblProfit.Name = "lblProfit";
            this.lblProfit.Size = new System.Drawing.Size(107, 19);
            this.lblProfit.TabIndex = 19;
            this.lblProfit.Text = "Mənfəət: 0 AZN";
            // 
            // lblProfitPercent
            // 
            this.lblProfitPercent.AutoSize = true;
            this.lblProfitPercent.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.lblProfitPercent.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblProfitPercent.Location = new System.Drawing.Point(340, 410);
            this.lblProfitPercent.Name = "lblProfitPercent";
            this.lblProfitPercent.Size = new System.Drawing.Size(125, 19);
            this.lblProfitPercent.TabIndex = 20;
            this.lblProfitPercent.Text = "Mənfəət Faizi: 0%";
            // 
            // ProductAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 630);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.txtMinStock);
            this.Controls.Add(this.lblMinStock);
            this.Controls.Add(this.txtCurrentStock);
            this.Controls.Add(this.lblCurrentStock);
            this.Controls.Add(this.lblProfitPercent);
            this.Controls.Add(this.lblProfit);
            this.Controls.Add(this.txtSalePrice);
            this.Controls.Add(this.lblSalePrice);
            this.Controls.Add(this.txtPurchasePrice);
            this.Controls.Add(this.lblPurchasePrice);
            this.Controls.Add(this.cmbUnit);
            this.Controls.Add(this.lblUnit);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.btnGenerateSKU);
            this.Controls.Add(this.txtSKU);
            this.Controls.Add(this.lblSKU);
            this.Controls.Add(this.btnGenerateBarcode);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.lblBarcode);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProductAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Məhsul Əlavə Etmə - AzAgroPOS";
            this.Load += new System.EventHandler(this.ProductAddForm_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Button btnGenerateBarcode;
        private System.Windows.Forms.Label lblSKU;
        private System.Windows.Forms.TextBox txtSKU;
        private System.Windows.Forms.Button btnGenerateSKU;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.Label lblPurchasePrice;
        private System.Windows.Forms.TextBox txtPurchasePrice;
        private System.Windows.Forms.Label lblSalePrice;
        private System.Windows.Forms.TextBox txtSalePrice;
        private System.Windows.Forms.Label lblCurrentStock;
        private System.Windows.Forms.TextBox txtCurrentStock;
        private System.Windows.Forms.Label lblMinStock;
        private System.Windows.Forms.TextBox txtMinStock;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblProfit;
        private System.Windows.Forms.Label lblProfitPercent;
    }
}