using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Teqdimat.Interfeysler;

namespace AzAgroPOS.Teqdimat
{
    public partial class QaytarmaFormu : BazaForm, IQaytarmaView
    {
        public QaytarmaFormu()
        {
            InitializeComponent();
            StilVerDataGridView(dgvSatisMehsullari);

        }

        public string SatisNomresi => txtSatisNomresi.Text;

        public string QaytarmaSebebi => txtQaytarmaSebebi.Text;

        public List<SatisSebetiElementiDto> SecilmisMehsullar
        {
            get
            {
                var secilmisler = new List<SatisSebetiElementiDto>();
                foreach (DataGridViewRow row in dgvSatisMehsullari.Rows)
                {
                    if (row.Cells["Secim"].Value != null && (bool)row.Cells["Secim"].Value)
                    {
                        secilmisler.Add((SatisSebetiElementiDto)row.DataBoundItem);
                    }
                }
                return secilmisler;
            }
        }

        public event EventHandler SatisAxtarIstek;
        public event EventHandler QaytarmaEmeliyyatiIstek;

        public void SatisMehsullariniGoster(List<SatisSebetiElementiDto> mehsullar)
        {
            dgvSatisMehsullari.DataSource = mehsullar;
            // Configure columns if needed
            if (dgvSatisMehsullari.Columns.Count > 0)
            {
                // Assuming the Dto has these properties
                dgvSatisMehsullari.Columns[nameof(SatisSebetiElementiDto.MehsulAdi)].HeaderText = "Məhsul Adı";
                dgvSatisMehsullari.Columns[nameof(SatisSebetiElementiDto.Miqdar)].HeaderText = "Miqdar";
                dgvSatisMehsullari.Columns[nameof(SatisSebetiElementiDto.VahidinQiymeti)].HeaderText = "Qiymət";
                dgvSatisMehsullari.Columns[nameof(SatisSebetiElementiDto.UmumiMebleg)].HeaderText = "Cəmi Məbləğ";

                // Hide unnecessary columns
                dgvSatisMehsullari.Columns[nameof(SatisSebetiElementiDto.MehsulId)].Visible = false;
                // Add a checkbox column for selection if it doesn't exist
                if (dgvSatisMehsullari.Columns["Secim"] == null)
                {
                    DataGridViewCheckBoxColumn secimCol = new DataGridViewCheckBoxColumn();
                    secimCol.Name = "Secim";
                    secimCol.HeaderText = "Seç";
                    dgvSatisMehsullari.Columns.Insert(0, secimCol);
                }
            }
        }

        public DialogResult MesajGoster(string mesaj, string basliq, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(this, mesaj, basliq, buttons, icon);
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

        private void btnAxtar_Click(object sender, EventArgs e)
        {
            SatisAxtarIstek?.Invoke(this, EventArgs.Empty);
        }

        private void btnQaytar_Click(object sender, EventArgs e)
        {
            QaytarmaEmeliyyatiIstek?.Invoke(this, EventArgs.Empty);
        }
    }
}