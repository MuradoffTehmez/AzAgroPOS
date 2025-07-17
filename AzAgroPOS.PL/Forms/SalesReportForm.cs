using AzAgroPOS.BLL.Services;
using AzAgroPOS.Entities.DTO;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class SalesReportForm : BaseForm
    {
        private readonly ReportService _reportService;
        private readonly ExportService _exportService;
        private SalesReportDto _currentReport;

        public SalesReportForm() : base()
        {
            _reportService = new ReportService();
            _exportService = new ExportService();
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            // Set default report type change handler
            cmbReportType.SelectedIndexChanged += CmbReportType_SelectedIndexChanged;
            btnGenerate.Click += BtnGenerate_Click;
            btnExport.Click += BtnExport_Click;

            // Load today's report by default
            LoadTodayReport();
        }

        private void CmbReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbReportType.SelectedItem.ToString())
            {
                case "Günlük":
                    dtpStartDate.Value = DateTime.Now.Date;
                    dtpEndDate.Value = DateTime.Now.Date;
                    break;
                case "Aylıq":
                    dtpStartDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    dtpEndDate.Value = dtpStartDate.Value.AddMonths(1).AddDays(-1);
                    break;
            }
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                btnGenerate.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                SalesReportDto report = null;

                switch (cmbReportType.SelectedItem.ToString())
                {
                    case "Günlük":
                        report = _reportService.GetDailySalesReport(dtpStartDate.Value);
                        break;
                    case "Aylıq":
                        report = _reportService.GetMonthlySalesReport(dtpStartDate.Value.Year, dtpStartDate.Value.Month);
                        break;
                    case "Sərbəst":
                        // Create custom report using monthly logic with date range
                        report = _reportService.GetMonthlySalesReport(dtpStartDate.Value.Year, dtpStartDate.Value.Month);
                        if (report != null)
                        {
                            report.StartDate = dtpStartDate.Value;
                            report.EndDate = dtpEndDate.Value;
                            report.ReportType = "Sərbəst";
                        }
                        break;
                }

                if (report != null)
                {
                    _currentReport = report;
                    DisplayReport(report);
                    btnExport.Enabled = true;
                    ErrorHandlingService.ShowSuccess("Hesabat uğurla yaradıldı!");
                }
                else
                {
                    MessageBox.Show("Hesabat yaradıla bilmədi.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "Hesabat yaradılarkən xəta baş verdi.");
            }
            finally
            {
                btnGenerate.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            if (_currentReport == null)
            {
                MessageBox.Show("Əvvəlcə hesabat yaradın.", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _exportService.ShowExportSalesReportDialog(_currentReport);
        }

        private void DisplayReport(SalesReportDto report)
        {
            // Update summary labels
            lblTotalSales.Text = $"Satış Sayı: {report.TotalSales:N0}";
            lblTotalAmount.Text = $"Ümumi Məbləğ: {report.TotalAmount:C}";
            lblNetAmount.Text = $"Net Məbləğ: {report.NetAmount:C}";
            lblAverageOrder.Text = $"Orta Sifariş: {report.AverageOrderValue:C}";
            lblDiscountPercent.Text = $"Endirim %: {report.DiscountPercentage:F1}%";

            // Update chart
            UpdateChart(report);

            // Update top products grid
            UpdateTopProductsGrid(report.TopProducts);
        }

        private void UpdateChart(SalesReportDto report)
        {
            // Chart yenilənməsi müvəqqəti deaktivdir
        }

        private void UpdateTopProductsGrid(System.Collections.Generic.List<ProductSalesDto> products)
        {
            dgvTopProducts.Rows.Clear();

            if (products?.Any() == true)
            {
                foreach (var product in products)
                {
                    dgvTopProducts.Rows.Add(
                        product.ProductName,
                        product.ProductCode,
                        product.TotalQuantity,
                        product.TotalAmount,
                        product.SalesCount,
                        product.AveragePrice
                    );
                }
            }
        }

        private void LoadTodayReport()
        {
            cmbReportType.SelectedIndex = 0; // Daily
            BtnGenerate_Click(null, null);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _reportService?.Dispose();
            _exportService?.Dispose();
            base.OnFormClosed(e);
        }
    }
}