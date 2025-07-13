using System;
using System.Windows.Forms;
using AzAgroPOS.Entities.Domain;

namespace AzAgroPOS.PL.Forms
{
    public partial class TamirWorkerAssignForm : Form
    {
        public TamirWorkerAssignForm(int repairId, Istifadeci currentUser)
        {
            InitializeComponent();
            MessageBox.Show("İşçi təyinatı formu tezliklə əlavə ediləcək.", "Məlumat", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.Cancel;
        }
    }

    public partial class TamirWorkerAssignForm
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
            this.Name = "TamirWorkerAssignForm";
            this.Text = "İşçi Təyinatı";
            this.ResumeLayout(false);
        }
    }
}