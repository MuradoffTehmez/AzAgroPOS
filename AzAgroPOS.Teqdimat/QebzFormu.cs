namespace AzAgroPOS.Teqdimat
{
    public partial class QebzFormu : Form
    {
        public QebzFormu()
        {
            InitializeComponent();
        }

        public void QebzMelumatlariniGoster(string basliq, Dictionary<string, string> melumatlar)
        {
            lblBasliq.Text = basliq;

            // Mevcud satırları təmizləyirik
            tblMelumatlar.Controls.Clear();
            tblMelumatlar.RowStyles.Clear();

            // Yeni məlumatları əlavə edirik
            int satir = 0;
            foreach (var melumat in melumatlar)
            {
                tblMelumatlar.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));

                var lblAcar = new Label();
                lblAcar.Text = melumat.Key + ":";
                lblAcar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
                lblAcar.Dock = DockStyle.Fill;
                lblAcar.TextAlign = ContentAlignment.MiddleLeft;
                tblMelumatlar.Controls.Add(lblAcar, 0, satir);

                var lblDeyer = new Label();
                lblDeyer.Text = melumat.Value;
                lblDeyer.Font = new Font("Microsoft Sans Serif", 10F);
                lblDeyer.Dock = DockStyle.Fill;
                lblDeyer.TextAlign = ContentAlignment.MiddleLeft;
                tblMelumatlar.Controls.Add(lblDeyer, 1, satir);

                satir++;
            }
        }

        private void btnCapEt_Click(object sender, EventArgs e)
        {
            // Çap funksionallığını tətbiq edin
            MessageBox.Show("Çap funksionallığı hələ tətbiq edilməyib.", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBagla_Click(object sender, EventArgs e)
        {
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
    }
}