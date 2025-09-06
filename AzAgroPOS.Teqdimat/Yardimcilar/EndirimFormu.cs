using AzAgroPOS.Mentiq.DTOs;

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

        /// <summary>
        /// Shows a validation error on a control
        /// </summary>
        /// <param name="control">Control to show error on</param>
        /// <param name="message">Error message</param>
        public void XetaGoster(Control control, string message)
        {
            errorProvider1.SetError(control, message);
            errorProvider1.SetIconAlignment(control, ErrorIconAlignment.MiddleRight);
            errorProvider1.SetIconPadding(control, 2);
        }

        /// <summary>
        /// Clears validation error from a control
        /// </summary>
        /// <param name="control">Control to clear error from</param>
        public void XetaniTemizle(Control control)
        {
            errorProvider1.SetError(control, string.Empty);
        }

        /// <summary>
        /// Clears all validation errors
        /// </summary>
        public void ButunXetalariTemizle()
        {
            // Clear errors from all controls
            foreach (Control control in this.Controls)
            {
                ClearErrorsRecursive(control);
            }
        }

        /// <summary>
        /// Recursively clears errors from all controls
        /// </summary>
        /// <param name="control">Control to clear errors from</param>
        private void ClearErrorsRecursive(Control control)
        {
            errorProvider1.SetError(control, string.Empty);
            foreach (Control child in control.Controls)
            {
                ClearErrorsRecursive(child);
            }
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