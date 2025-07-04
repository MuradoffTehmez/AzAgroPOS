using AzAgroPOS.BLL;
using System;
using System.Windows.Forms;

namespace AzAgroPOS.PL
{
    public partial class frmSalesReport : Form
    {
        private readonly SatisBLL _satisBll = new SatisBLL();
        private readonly SatisMehsullariBLL _satisMehsullariBll = new SatisMehsullariBLL();

        public frmSalesReport()
        {
            InitializeComponent();
        }

        private void frmSalesReport_Load(object sender, EventArgs e)
        {
            // Bu günün tarixini təyin edirik
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today.AddDays(1).AddTicks(-1); // Günün sonu
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            var startDate = dtpStartDate.Value.Date;
            var endDate = dtpEndDate.Value.Date.AddDays(1).AddTicks(-1); // Günün sonu

            dgvSales.DataSource = _satisBll.GetByDateRange(startDate, endDate);
            SetupSalesGrid();
        }

        private void SetupSalesGrid()
        {
            dgvSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Lazımsız sütunları gizlədirik və başlıqları dəyişirik
        }

        private void dgvSales_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSales.CurrentRow == null) return;

            int selectedSatisId = (int)dgvSales.CurrentRow.Cells["Id"].Value;
            dgvSaleDetails.DataSource = _satisMehsullariBll.GetBySatisId(selectedSatisId);
            SetupDetailsGrid();
        }

        private void SetupDetailsGrid()
        {
            dgvSaleDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Detallar cədvəlinin sütunlarını səliqəyə salırıq
        }
    }
}