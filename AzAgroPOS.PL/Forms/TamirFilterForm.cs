using System;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class TamirFilterForm : Form
    {
        public string SelectedStatus { get; set; }
        public int? SelectedCustomerId { get; set; }
        public string SelectedPriority { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public TamirFilterForm()
        {
            InitializeComponent();
            MessageBox.Show("Təmir filtr formu tezliklə əlavə ediləcək.", "Məlumat", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.Cancel;
        }
    }

    public partial class TamirFilterForm
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
            this.Name = "TamirFilterForm";
            this.Text = "Təmir Filtri";
            this.ResumeLayout(false);
        }
    }
}