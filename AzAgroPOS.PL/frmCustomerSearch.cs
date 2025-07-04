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

        private void frmCustomerSearch_Load(object sender, EventArgs e)
        {
            // DÜZƏLİŞ: Sütunların avtomatik yaranmasını təmin edirik.
            dgvCustomers.AutoGenerateColumns = true;
            PerformSearch();
        }

        private void PerformSearch()
        {
            try
            {
                var customerList = _musteriBll.SearchByNameOrPhone(txtSearch.Text);
                dgvCustomers.DataSource = customerList; // Breakpoint-i bu sətrə qoyun
                SetupDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Müştərilər yüklənərkən xəta baş verdi: " + ex.Message, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void SetupDataGrid()
        {
            // Cədvəlin bütün sütunları əhatə etməsini təmin edirik
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Bəzi sütunları gizlədirik
            string[] hiddenColumns = { "Id", "NisyeLimiti", "EndirimFaizi", "Aktivdir", "Qeyd", "YaradilmaTarixi", "Unvan", "Email" };
            foreach (string colName in hiddenColumns)
            {
                if (dgvCustomers.Columns[colName] != null)
                {
                    dgvCustomers.Columns[colName].Visible = false;
                }
            }

            // Görünən sütunların başlıqlarını dəyişirik
            if (dgvCustomers.Columns["Ad"] != null) dgvCustomers.Columns["Ad"].HeaderText = "Ad";
            if (dgvCustomers.Columns["Soyad"] != null) dgvCustomers.Columns["Soyad"].HeaderText = "Soyad";
            if (dgvCustomers.Columns["Telefon"] != null) dgvCustomers.Columns["Telefon"].HeaderText = "Telefon Nömrəsi";
            if (dgvCustomers.Columns["CariNisyeBorcu"] != null) dgvCustomers.Columns["CariNisyeBorcu"].HeaderText = "Cari Borc";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            PerformSearch();
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

        private void dgvCustomers_DoubleClick(object sender, EventArgs e)
        {
            SelectAndClose();
        }

        private void btnSelect_Click_1(object sender, EventArgs e)
        {
            SelectAndClose();
        }

        private void frmCustomerSearch_Load_1(object sender, EventArgs e)
        {
            dgvCustomers.AutoGenerateColumns = true;
            PerformSearch();
        }
    }
}