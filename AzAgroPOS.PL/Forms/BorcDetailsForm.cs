using System;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class BorcDetailsForm : Form
    {
        public BorcDetailsForm(int debtId)
        {
            InitializeComponent();
            MessageBox.Show("Borc təfərrüat formu tezliklə əlavə ediləcək.", "Məlumat", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    public partial class BorcDetailsForm
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
            this.Name = "BorcDetailsForm";
            this.Text = "Borc Təfərrüatları";
            this.ResumeLayout(false);
        }
    }
}