using System;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class BorcFilterForm : Form
    {
        public string SelectedStatus { get; set; }
        public int? SelectedCustomerId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public BorcFilterForm()
        {
            InitializeComponent();
            MessageBox.Show("Borc filtr formu tezliklə əlavə ediləcək.", "Məlumat", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.Cancel;
        }
    }

    public partial class BorcFilterForm
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
            this.Name = "BorcFilterForm";
            this.Text = "Borc Filtri";
            this.ResumeLayout(false);
        }
    }
}