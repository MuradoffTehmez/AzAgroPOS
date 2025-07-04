using AzAgroPOS.BLL;
using AzAgroPOS.Entities;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Windows.Forms;

namespace AzAgroPOS.PL
{
    public partial class frmRepairs : Form
    {
        private Musteri _selectedCustomer;
        private readonly TemirBLL _temirBll = new TemirBLL();
        private readonly TemirStatusuBLL _temirStatusuBll = new TemirStatusuBLL();
        // private readonly IstifadeciBLL _istifadeciBll = new IstifadeciBLL(); // Təmirçilər üçün

        public frmRepairs()
        {
            InitializeComponent();
        }

        private void frmRepairs_Load(object sender, EventArgs e)
        {
            LoadStatuses();
            // LoadTechnicians();
            // LoadRepairs();
        }

        private void LoadStatuses()
        {
            // Bu ComboBox-un adı dizaynda cmbStatus olmalıdır
            cmbStatus.DataSource = _temirStatusuBll.GetAll();
            cmbStatus.DisplayMember = "Ad";
            cmbStatus.ValueMember = "Id";
        }

        private void btnSelectCustomer_Click(object sender, EventArgs e)
        {
            using (var searchForm = new frmCustomerSearch())
            {
                if (searchForm.ShowDialog() == DialogResult.OK)
                {
                    _selectedCustomer = searchForm.SelectedCustomer;
                    // lblSelectedCustomer (Label) üzərində müştəri adını göstərin
                    lblSelectedCustomer.Text = $"{_selectedCustomer.Ad} {_selectedCustomer.Soyad}";
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_selectedCustomer == null)
            {
                MessageBox.Show("Zəhmət olmasa, müştəri seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var yeniTemir = new Temir
            {
                MusteriId = _selectedCustomer.Id,
                CihazAdi = txtCihazAdi.Text,
                Marka = txtMarka.Text,
                Model = txtModel.Text,
                SeriyaNomresi = txtSeriyaNomresi.Text,
                ProblemTesviri = txtProblem.Text,
                StatusId = (int)cmbStatus.SelectedValue,
                TemirciId = null // Hələlik təmirçi təyin etmirik
            };

            bool result = _temirBll.Add(yeniTemir, out string message);
            MessageBox.Show(message);

            if (result)
            {
                // ClearForm();
                // LoadRepairs();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }
    }
}