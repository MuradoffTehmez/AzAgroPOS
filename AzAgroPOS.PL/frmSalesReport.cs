using AzAgroPOS.BLL;
using System;
using System.Globalization;
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
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today; // Günün sonunu düyməyə basanda təyin edəcəyik
            btnShowReport_Click(null, null); // Pəncərə açılan kimi bu günün hesabatını göstərsin
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            try
            {
                var startDate = dtpStartDate.Value.Date;
                var endDate = dtpEndDate.Value.Date.AddDays(1).AddTicks(-1); // Günün son anı

                dgvSales.DataSource = _satisBll.GetByDateRange(startDate, endDate);
                SetupSalesGrid();
                dgvSaleDetails.DataSource = null; // Üst cədvəl yenilənəndə alt cədvəli təmizləyirik
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hesabat yüklənərkən xəta baş verdi: " + ex.Message, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupSalesGrid()
        {
            if (dgvSales.Columns.Count == 0) return;

            dgvSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Sütunların adlarını və formatlarını dəyişirik
            dgvSales.Columns["Id"].HeaderText = "Satış ID";
            dgvSales.Columns["SatisTarixi"].HeaderText = "Tarix və Vaxt";
            dgvSales.Columns["MusteriAdi"].HeaderText = "Müştəri";
            dgvSales.Columns["IstifadeciAdi"].HeaderText = "Kassir";
            dgvSales.Columns["EndirimMeblegi"].HeaderText = "Endirim (₼)";
            dgvSales.Columns["YekunMebleg"].HeaderText = "Yekun Məbləğ (₼)";

            dgvSales.Columns["EndirimMeblegi"].DefaultCellStyle.Format = "F2";
            dgvSales.Columns["YekunMebleg"].DefaultCellStyle.Format = "F2";
            dgvSales.Columns["SatisTarixi"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";

            // Lazımsız sütunları gizlədirik
            string[] hiddenColumns = { "MusteriId", "IstifadeciId", "OdenmisMebleg", "SatisMehsullari", "Odenisler" };
            foreach (var colName in hiddenColumns)
            {
                if (dgvSales.Columns[colName] != null) dgvSales.Columns[colName].Visible = false;
            }
        }

        private void dgvSales_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSales.CurrentRow == null) return;
            try
            {
                int selectedSatisId = (int)dgvSales.CurrentRow.Cells["Id"].Value;
                dgvSaleDetails.DataSource = _satisMehsullariBll.GetBySatisId(selectedSatisId);
                SetupDetailsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Satış detalları yüklənərkən xəta baş verdi: " + ex.Message, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDetailsGrid()
        {
            if (dgvSaleDetails.Columns.Count == 0) return;

            dgvSaleDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvSaleDetails.Columns["MehsulAdi"].HeaderText = "Məhsul Adı";
            dgvSaleDetails.Columns["Miqdar"].HeaderText = "Miqdar";
            dgvSaleDetails.Columns["QiymetBirEdede"].HeaderText = "Vahid Qiyməti (₼)";
            dgvSaleDetails.Columns["EndirimMeblegi"].HeaderText = "Endirim (₼)";

            dgvSaleDetails.Columns["QiymetBirEdede"].DefaultCellStyle.Format = "F2";
            dgvSaleDetails.Columns["EndirimMeblegi"].DefaultCellStyle.Format = "F2";

            string[] hiddenColumns = { "Id", "SatisId", "MehsulId" };
            foreach (var colName in hiddenColumns)
            {
                if (dgvSaleDetails.Columns[colName] != null) dgvSaleDetails.Columns[colName].Visible = false;
            }
        }
    }
}