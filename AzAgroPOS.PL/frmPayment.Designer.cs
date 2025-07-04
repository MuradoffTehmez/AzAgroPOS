namespace AzAgroPOS.PL
{
    partial class frmPayment
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) { components.Dispose(); } base.Dispose(disposing); }
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCash = new System.Windows.Forms.TextBox();
            this.txtCard = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNisye = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPaidAmount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblChange = new System.Windows.Forms.Label();
            this.btnConfirmPayment = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // label1
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ödəniləcək Yekun Məbləğ:";

            // lblTotalAmount
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalAmount.Location = new System.Drawing.Point(435, 20);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(253, 57);
            this.lblTotalAmount.TabIndex = 1;
            this.lblTotalAmount.Text = "0.00 ₼";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // label6
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(128, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 24);
            this.label6.TabIndex = 15;
            this.label6.Text = "Endirim:";

            // txtDiscount
            this.txtDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.Location = new System.Drawing.Point(250, 80);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(437, 28);
            this.txtDiscount.TabIndex = 0;
            //this.txtDiscount.TextChanged += new System.EventHandler(this.txtDiscount_TextChanged);

            // label3
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(146, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nağd:";

            // txtCash
            this.txtCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCash.Location = new System.Drawing.Point(250, 130);
            this.txtCash.Name = "txtCash";
            this.txtCash.Size = new System.Drawing.Size(437, 28);
            this.txtCash.TabIndex = 1;
            //this.txtCash.TextChanged += new System.EventHandler(this.PaymentFields_TextChanged);

            // txtCard
            this.txtCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCard.Location = new System.Drawing.Point(251, 180);
            this.txtCard.Name = "txtCard";
            this.txtCard.Size = new System.Drawing.Size(437, 28);
            this.txtCard.TabIndex = 2;
            //this.txtCard.TextChanged += new System.EventHandler(this.PaymentFields_TextChanged);

            // label4
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(151, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "Kart:";

            // txtNisye
            this.txtNisye.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNisye.Location = new System.Drawing.Point(250, 230);
            this.txtNisye.Name = "txtNisye";
            this.txtNisye.Size = new System.Drawing.Size(437, 28);
            this.txtNisye.TabIndex = 3;
            //this.txtNisye.TextChanged += new System.EventHandler(this.PaymentFields_TextChanged);

            // label2
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(146, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 24);
            this.label2.TabIndex = 13;
            this.label2.Text = "Nisyə:";

            // label9
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(72, 287);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(144, 24);
            this.label9.TabIndex = 17;
            this.label9.Text = "Yekun Məbləğ:";

            // lblSubTotal
            this.lblSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.Location = new System.Drawing.Point(455, 280);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(232, 31);
            this.lblSubTotal.TabIndex = 16;
            this.lblSubTotal.Text = "0.00 ₼";
            this.lblSubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // label5
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(59, 330);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 24);
            this.label5.TabIndex = 8;
            this.label5.Text = "Cəmi Ödənilmiş:";

            // lblPaidAmount
            this.lblPaidAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaidAmount.Location = new System.Drawing.Point(455, 323);
            this.lblPaidAmount.Name = "lblPaidAmount";
            this.lblPaidAmount.Size = new System.Drawing.Size(232, 31);
            this.lblPaidAmount.TabIndex = 9;
            this.lblPaidAmount.Text = "0.00 ₼";
            this.lblPaidAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // label7
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(151, 373);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 24);
            this.label7.TabIndex = 10;
            this.label7.Text = "Qalıq:";

            // lblChange
            this.lblChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChange.ForeColor = System.Drawing.Color.Red;
            this.lblChange.Location = new System.Drawing.Point(455, 366);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(232, 31);
            this.lblChange.TabIndex = 11;
            this.lblChange.Text = "0.00 ₼";
            this.lblChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // btnConfirmPayment
            this.btnConfirmPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmPayment.Location = new System.Drawing.Point(385, 455);
            this.btnConfirmPayment.Name = "btnConfirmPayment";
            this.btnConfirmPayment.Size = new System.Drawing.Size(303, 78);
            this.btnConfirmPayment.TabIndex = 4;
            this.btnConfirmPayment.Text = "Ödənişi Təsdiqlə";
            this.btnConfirmPayment.UseVisualStyleBackColor = true;
            this.btnConfirmPayment.Click += new System.EventHandler(this.btnConfirmPayment_Click_1);

            // btnCancel
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(50, 455);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(303, 78);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Ləğv Et";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // frmPayment
            this.AcceptButton = this.btnConfirmPayment;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(710, 558);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblSubTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.txtNisye);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblChange);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblPaidAmount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirmPayment);
            this.Controls.Add(this.txtCard);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCash);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ödəniş";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCash;
        private System.Windows.Forms.TextBox txtCard;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnConfirmPayment;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPaidAmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.TextBox txtNisye;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label label9;
    }
}