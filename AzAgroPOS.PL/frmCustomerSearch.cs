// Fayl: AzAgroPOS.PL/frmCustomerSearch.cs
using AzAgroPOS.BLL;
using AzAgroPOS.Entities;
using System;
using System.Windows.Forms;

namespace AzAgroPOS.PL
{
    public partial class frmCustomerSearch : Form
    {
        private readonly MusteriBLL _musteriBll = new MusteriBLL();
        public Musteri SelectedCustomer { get; private set; }

        public frmCustomerSearch()
        {
            InitializeComponent();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvCustomers.DataSource = _musteriBll.SearchByNameOrPhone(txtSearch.Text);
        }

        private void SelectAndClose()
        {
            if (dgvCustomers.CurrentRow != null)
            {
                SelectedCustomer = (Musteri)dgvCustomers.CurrentRow.DataBoundItem;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Zəhmət olmasa, bir müştəri seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectAndClose();
        }

        private void dgvCustomers_DoubleClick(object sender, EventArgs e)
        {
            SelectAndClose();
        }
    }
}