using System;
using System.Windows.Forms;
using AzAgroPOS.Entities.Domain;

namespace AzAgroPOS.PL.Forms
{
    public partial class BorcPaymentForm : Form
    {
        public BorcPaymentForm(int debtId, Istifadeci currentUser)
        {
            InitializeComponent();
            MessageBox.Show("Ödəniş formu tezliklə əlavə ediləcək.", "Məlumat", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.Cancel;
        }
    }

    public partial class BorcPaymentForm
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

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Name = "BorcPaymentForm";
            this.Text = "Borc Ödənişi";
            this.ResumeLayout(false);
        }
    }
}