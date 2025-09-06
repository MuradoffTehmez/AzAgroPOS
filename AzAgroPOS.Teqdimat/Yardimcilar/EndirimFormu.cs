using AzAgroPOS.Mentiq.DTOs;
using System;
using System.Windows.Forms;

namespace AzAgroPOS.Teqdimat.Yardimcilar
{
    public partial class EndirimFormu : Form
    {
        public EndirimParametrləriDto EndirimParametrləri { get; private set; }

        public EndirimFormu(SatisSebetiElementiDto? secilmisElement)
        {
            InitializeComponent();
            EndirimParametrləri = new EndirimParametrləriDto();

            // Set default values
            rbCart.Checked = true;
            rbPercentage.Checked = true;
            txtEndirimDeyer.Text = "0";

            // Enable/disable item selection based on cart selection
            rbSelectedItem.Enabled = secilmisElement != null;
            if (secilmisElement == null)
            {
                rbCart.Checked = true;
            }
        }

        private void btnTətbiqEt_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtEndirimDeyer.Text, out decimal deyer) || deyer < 0)
            {
                MessageBox.Show("Zəhmət olmasa, düzgün bir endirim dəyəri daxil edin.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            EndirimParametrləri.Scope = rbCart.Checked ? EndirimScope.Cart : EndirimScope.SelectedItem;
            EndirimParametrləri.Type = rbPercentage.Checked ? EndirimType.Percentage : EndirimType.FixedAmount;
            EndirimParametrləri.Value = deyer;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void rbSelectedItem_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSelectedItem.Checked && !rbSelectedItem.Enabled)
            {
                rbCart.Checked = true;
            }
        }

        private void rbCart_CheckedChanged(object sender, EventArgs e)
        {
            // Optional: Add logic if needed when cart is selected
        }
    }
}