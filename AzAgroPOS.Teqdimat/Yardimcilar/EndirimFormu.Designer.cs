namespace AzAgroPOS.Teqdimat.Yardimcilar
{
    partial class EndirimFormu
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbSelectedItem = new System.Windows.Forms.RadioButton();
            this.rbCart = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbFixedAmount = new System.Windows.Forms.RadioButton();
            this.rbPercentage = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEndirimDeyer = new System.Windows.Forms.TextBox();
            this.btnTətbiqEt = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSelectedItem);
            this.groupBox1.Controls.Add(this.rbCart);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 70);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Endirim Əhatəsi";
            // 
            // rbSelectedItem
            // 
            this.rbSelectedItem.AutoSize = true;
            this.rbSelectedItem.Location = new System.Drawing.Point(6, 42);
            this.rbSelectedItem.Name = "rbSelectedItem";
            this.rbSelectedItem.Size = new System.Drawing.Size(115, 17);
            this.rbSelectedItem.TabIndex = 1;
            this.rbSelectedItem.Text = "Seçilmiş Məhsul";
            this.rbSelectedItem.UseVisualStyleBackColor = true;
            this.rbSelectedItem.CheckedChanged += new System.EventHandler(this.rbSelectedItem_CheckedChanged);
            // 
            // rbCart
            // 
            this.rbCart.AutoSize = true;
            this.rbCart.Checked = true;
            this.rbCart.Location = new System.Drawing.Point(6, 19);
            this.rbCart.Name = "rbCart";
            this.rbCart.Size = new System.Drawing.Size(59, 17);
            this.rbCart.TabIndex = 0;
            this.rbCart.TabStop = true;
            this.rbCart.Text = "Səbət";
            this.rbCart.UseVisualStyleBackColor = true;
            this.rbCart.CheckedChanged += new System.EventHandler(this.rbCart_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbFixedAmount);
            this.groupBox2.Controls.Add(this.rbPercentage);
            this.groupBox2.Location = new System.Drawing.Point(12, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 70);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Endirim Növü";
            // 
            // rbFixedAmount
            // 
            this.rbFixedAmount.AutoSize = true;
            this.rbFixedAmount.Location = new System.Drawing.Point(6, 42);
            this.rbFixedAmount.Name = "rbFixedAmount";
            this.rbFixedAmount.Size = new System.Drawing.Size(97, 17);
            this.rbFixedAmount.TabIndex = 1;
            this.rbFixedAmount.Text = "Sabit Məbləğ";
            this.rbFixedAmount.UseVisualStyleBackColor = true;
            // 
            // rbPercentage
            // 
            this.rbPercentage.AutoSize = true;
            this.rbPercentage.Checked = true;
            this.rbPercentage.Location = new System.Drawing.Point(6, 19);
            this.rbPercentage.Name = "rbPercentage";
            this.rbPercentage.Size = new System.Drawing.Size(63, 17);
            this.rbPercentage.TabIndex = 0;
            this.rbPercentage.TabStop = true;
            this.rbPercentage.Text = "Faiz (%)";
            this.rbPercentage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dəyər";
            // 
            // txtEndirimDeyer
            // 
            this.txtEndirimDeyer.Location = new System.Drawing.Point(54, 167);
            this.txtEndirimDeyer.Name = "txtEndirimDeyer";
            this.txtEndirimDeyer.Size = new System.Drawing.Size(158, 20);
            this.txtEndirimDeyer.TabIndex = 3;
            // 
            // btnTətbiqEt
            // 
            this.btnTətbiqEt.Location = new System.Drawing.Point(12, 200);
            this.btnTətbiqEt.Name = "btnTətbiqEt";
            this.btnTətbiqEt.Size = new System.Drawing.Size(75, 23);
            this.btnTətbiqEt.TabIndex = 4;
            this.btnTətbiqEt.Text = "Tətbiq Et";
            this.btnTətbiqEt.UseVisualStyleBackColor = true;
            this.btnTətbiqEt.Click += new System.EventHandler(this.btnTətbiqEt_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(137, 200);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Ləğv et";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // EndirimFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 235);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnTətbiqEt);
            this.Controls.Add(this.txtEndirimDeyer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EndirimFormu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Endirim";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbSelectedItem;
        private System.Windows.Forms.RadioButton rbCart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbFixedAmount;
        private System.Windows.Forms.RadioButton rbPercentage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEndirimDeyer;
        private System.Windows.Forms.Button btnTətbiqEt;
        private System.Windows.Forms.Button btnCancel;
    }
}