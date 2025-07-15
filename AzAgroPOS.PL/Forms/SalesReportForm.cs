using AzAgroPOS.BLL.Services;
using AzAgroPOS.Entities.DTO;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
// using System.Windows.Forms.DataVisualization.Charting;

namespace AzAgroPOS.PL.Forms
{
    public partial class SalesReportForm : Form
    {
        private readonly ReportService _reportService;
        private readonly ExportService _exportService;
        private SalesReportDto _currentReport;

        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private ComboBox cmbReportType;
        private Button btnGenerate;
        private Button btnExport;
        private Panel pnlSummary;
        private DataGridView dgvTopProducts;
        private Panel chartSales; // Chart placeholder
        private Label lblTotalSales;
        private Label lblTotalAmount;
        private Label lblNetAmount;
        private Label lblAverageOrder;
        private Label lblDiscountPercent;

        public SalesReportForm()
        {
            _reportService = new ReportService();
            _exportService = new ExportService();
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Form properties
            this.Text = "Satış Hesabatları";
            this.Size = new Size(1200, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;

            // Controls Panel
            var pnlControls = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.LightGray
            };

            // Date controls
            var lblStartDate = new Label
            {
                Text = "Başlanğıc:",
                Location = new Point(10, 20),
                Size = new Size(70, 20)
            };

            dtpStartDate = new DateTimePicker
            {
                Location = new Point(85, 18),
                Size = new Size(120, 22),
                Value = DateTime.Now.AddDays(-30)
            };

            var lblEndDate = new Label
            {
                Text = "Bitmə:",
                Location = new Point(220, 20),
                Size = new Size(50, 20)
            };

            dtpEndDate = new DateTimePicker
            {
                Location = new Point(275, 18),
                Size = new Size(120, 22),
                Value = DateTime.Now
            };

            // Report type
            var lblReportType = new Label
            {
                Text = "Növ:",
                Location = new Point(410, 20),
                Size = new Size(40, 20)
            };

            cmbReportType = new ComboBox
            {
                Location = new Point(455, 18),
                Size = new Size(100, 22),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbReportType.Items.AddRange(new[] { "Günlük", "Aylıq", "Sərbəst" });
            cmbReportType.SelectedIndex = 2;

            // Buttons
            btnGenerate = new Button
            {
                Text = "Hesabat Al",
                Location = new Point(570, 17),
                Size = new Size(100, 25),
                BackColor = Color.LightBlue
            };
            btnGenerate.Click += BtnGenerate_Click;

            btnExport = new Button
            {
                Text = "İxrac Et",
                Location = new Point(680, 17),
                Size = new Size(80, 25),
                BackColor = Color.LightGreen,
                Enabled = false
            };
            btnExport.Click += BtnExport_Click;

            pnlControls.Controls.AddRange(new Control[] 
            { 
                lblStartDate, dtpStartDate, lblEndDate, dtpEndDate, 
                lblReportType, cmbReportType, btnGenerate, btnExport 
            });

            // Summary Panel
            pnlSummary = new Panel
            {
                Dock = DockStyle.Top,
                Height = 100,
                BackColor = Color.WhiteSmoke,
                BorderStyle = BorderStyle.FixedSingle
            };

            CreateSummaryLabels();

            // Main content panel
            var pnlMain = new Panel
            {
                Dock = DockStyle.Fill
            };

            // Split container for chart and grid
            var splitContainer = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Horizontal,
                SplitterDistance = 300
            };

            // Chart placeholder for sales visualization
            chartSales = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.LightBlue,
                BorderStyle = BorderStyle.FixedSingle
            };
            chartSales.Controls.Add(new Label 
            { 
                Text = "📈 Satış Analitikası (Chart kontrolları yüklənir...)", 
                Dock = DockStyle.Fill, 
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            });
            // InitializeChart(); // Chart yüklənəndən sonra aktiv ediləcək

            // DataGridView for top products
            dgvTopProducts = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
            InitializeDataGridView();

            splitContainer.Panel1.Controls.Add(chartSales);
            splitContainer.Panel2.Controls.Add(dgvTopProducts);
            pnlMain.Controls.Add(splitContainer);

            // Add controls to form
            this.Controls.Add(pnlMain);
            this.Controls.Add(pnlSummary);
            this.Controls.Add(pnlControls);

            this.ResumeLayout(false);
        }

        private void CreateSummaryLabels()
        {
            lblTotalSales = new Label
            {
                Text = "Satış Sayı: -",
                Location = new Point(20, 15),
                Size = new Size(150, 20),
                Font = new Font("Arial", 9, FontStyle.Bold)
            };

            lblTotalAmount = new Label
            {
                Text = "Ümumi Məbləğ: -",
                Location = new Point(20, 40),
                Size = new Size(200, 20),
                Font = new Font("Arial", 9, FontStyle.Bold)
            };

            lblNetAmount = new Label
            {
                Text = "Net Məbləğ: -",
                Location = new Point(250, 15),
                Size = new Size(200, 20),
                Font = new Font("Arial", 9, FontStyle.Bold),
                ForeColor = Color.Green
            };

            lblAverageOrder = new Label
            {
                Text = "Orta Sifariş: -",
                Location = new Point(250, 40),
                Size = new Size(200, 20),
                Font = new Font("Arial", 9, FontStyle.Bold)
            };

            lblDiscountPercent = new Label
            {
                Text = "Endirim %: -",
                Location = new Point(480, 15),
                Size = new Size(150, 20),
                Font = new Font("Arial", 9, FontStyle.Bold),
                ForeColor = Color.Orange
            };

            pnlSummary.Controls.AddRange(new Control[] 
            { 
                lblTotalSales, lblTotalAmount, lblNetAmount, 
                lblAverageOrder, lblDiscountPercent 
            });
        }

        private void InitializeChart()
        {
            // Chart initialize ediləcək (Chart paketlərinin yüklənməsindən sonra)
            /*
            chartSales.Series.Clear();
            chartSales.ChartAreas.Clear();

            var chartArea = new ChartArea("SalesArea");
            chartArea.AxisX.Title = "Vaxt";
            chartArea.AxisY.Title = "Məbləğ (AZN)";
            chartArea.AxisY.LabelStyle.Format = "C0";
            chartSales.ChartAreas.Add(chartArea);

            var series = new Series("Satışlar")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.SteelBlue
            };
            chartSales.Series.Add(series);

            chartSales.Legends.Add(new Legend("Legend1"));
            */
        }

        private void InitializeDataGridView()
        {
            dgvTopProducts.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn 
                { 
                    Name = "ProductName", 
                    HeaderText = "Məhsul Adı", 
                    Width = 200 
                },
                new DataGridViewTextBoxColumn 
                { 
                    Name = "ProductCode", 
                    HeaderText = "Kodu", 
                    Width = 100 
                },
                new DataGridViewTextBoxColumn 
                { 
                    Name = "TotalQuantity", 
                    HeaderText = "Miqdar", 
                    Width = 80,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
                },
                new DataGridViewTextBoxColumn 
                { 
                    Name = "TotalAmount", 
                    HeaderText = "Məbləğ", 
                    Width = 100,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "C" }
                },
                new DataGridViewTextBoxColumn 
                { 
                    Name = "SalesCount", 
                    HeaderText = "Satış Sayı", 
                    Width = 80 
                },
                new DataGridViewTextBoxColumn 
                { 
                    Name = "AveragePrice", 
                    HeaderText = "Orta Qiymət", 
                    Width = 100,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "C" }
                }
            });
        }

        private void InitializeForm()
        {
            // Set default report type change handler
            cmbReportType.SelectedIndexChanged += CmbReportType_SelectedIndexChanged;
            
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
            /*
            chartSales.Series["Satışlar"].Points.Clear();

            if (report.SalesByHour?.Any() == true && report.ReportType == "Günlük")
            {
                chartSales.ChartAreas[0].AxisX.Title = "Saat";
                foreach (var sale in report.SalesByHour.OrderBy(s => s.Key))
                {
                    chartSales.Series["Satışlar"].Points.AddXY($"{sale.Key:D2}:00", sale.Value);
                }
            }
            else if (report.SalesByDay?.Any() == true)
            {
                chartSales.ChartAreas[0].AxisX.Title = "Gün";
                foreach (var sale in report.SalesByDay.OrderBy(s => s.Key))
                {
                    chartSales.Series["Satışlar"].Points.AddXY(sale.Key, sale.Value);
                }
            }
            */
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