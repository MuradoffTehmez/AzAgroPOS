using AzAgroPOS.BLL.Services;
using AzAgroPOS.Entities.DTO;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AzAgroPOS.PL.Forms
{
    public partial class DebtAnalysisForm : Form
    {
        private readonly ReportService _reportService;
        private readonly ExportService _exportService;
        private DebtReportDto _currentReport;

        private Button btnRefresh;
        private Button btnExport;
        private Panel pnlSummary;
        private DataGridView dgvCustomerDebts;
        private Chart chartDebtAnalysis;
        private Label lblTotalDebt;
        private Label lblTotalPaid;
        private Label lblRemainingDebt;
        private Label lblCustomersWithDebt;
        private Label lblCollectionRate;
        private Label lblAverageDebt;

        public DebtAnalysisForm()
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
            this.Text = "Borc Analizi";
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

            // Buttons
            btnRefresh = new Button
            {
                Text = "🔄 Yenilə",
                Location = new Point(20, 17),
                Size = new Size(100, 25),
                BackColor = Color.LightBlue
            };
            btnRefresh.Click += BtnRefresh_Click;

            btnExport = new Button
            {
                Text = "📤 İxrac Et",
                Location = new Point(130, 17),
                Size = new Size(100, 25),
                BackColor = Color.LightGreen,
                Enabled = false
            };
            btnExport.Click += BtnExport_Click;

            var lblTitle = new Label
            {
                Text = "Borc Balansı və Analitika",
                Location = new Point(250, 22),
                Size = new Size(200, 20),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            pnlControls.Controls.AddRange(new Control[] { btnRefresh, btnExport, lblTitle });

            // Summary Panel
            pnlSummary = new Panel
            {
                Dock = DockStyle.Top,
                Height = 120,
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

            // Chart for debt visualization
            chartDebtAnalysis = new Chart
            {
                Dock = DockStyle.Fill
            };
            InitializeChart();

            // DataGridView for customer debts
            dgvCustomerDebts = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
            InitializeDataGridView();

            splitContainer.Panel1.Controls.Add(chartDebtAnalysis);
            splitContainer.Panel2.Controls.Add(dgvCustomerDebts);
            pnlMain.Controls.Add(splitContainer);

            // Add controls to form
            this.Controls.Add(pnlMain);
            this.Controls.Add(pnlSummary);
            this.Controls.Add(pnlControls);

            this.ResumeLayout(false);
        }

        private void CreateSummaryLabels()
        {
            lblTotalDebt = new Label
            {
                Text = "Ümumi Borc: -",
                Location = new Point(20, 15),
                Size = new Size(200, 20),
                Font = new Font("Arial", 9, FontStyle.Bold),
                ForeColor = Color.Red
            };

            lblTotalPaid = new Label
            {
                Text = "Ödənilən: -",
                Location = new Point(20, 40),
                Size = new Size(200, 20),
                Font = new Font("Arial", 9, FontStyle.Bold),
                ForeColor = Color.Green
            };

            lblRemainingDebt = new Label
            {
                Text = "Qalan Borc: -",
                Location = new Point(20, 65),
                Size = new Size(200, 20),
                Font = new Font("Arial", 9, FontStyle.Bold),
                ForeColor = Color.DarkRed
            };

            lblCustomersWithDebt = new Label
            {
                Text = "Borclu Müştəri: -",
                Location = new Point(250, 15),
                Size = new Size(150, 20),
                Font = new Font("Arial", 9, FontStyle.Bold)
            };

            lblCollectionRate = new Label
            {
                Text = "Yığım Dərəcəsi: -",
                Location = new Point(250, 40),
                Size = new Size(150, 20),
                Font = new Font("Arial", 9, FontStyle.Bold),
                ForeColor = Color.Blue
            };

            lblAverageDebt = new Label
            {
                Text = "Orta Borc: -",
                Location = new Point(250, 65),
                Size = new Size(150, 20),
                Font = new Font("Arial", 9, FontStyle.Bold)
            };

            pnlSummary.Controls.AddRange(new Control[] 
            { 
                lblTotalDebt, lblTotalPaid, lblRemainingDebt, 
                lblCustomersWithDebt, lblCollectionRate, lblAverageDebt 
            });
        }

        private void InitializeChart()
        {
            chartDebtAnalysis.Series.Clear();
            chartDebtAnalysis.ChartAreas.Clear();

            var chartArea = new ChartArea("DebtArea");
            chartArea.AxisX.Title = "Müştərilər";
            chartArea.AxisY.Title = "Məbləğ (AZN)";
            chartArea.AxisY.LabelStyle.Format = "C0";
            chartDebtAnalysis.ChartAreas.Add(chartArea);

            // Series for remaining debt
            var debtSeries = new Series("Qalan Borc")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.Red
            };
            chartDebtAnalysis.Series.Add(debtSeries);

            // Series for paid amount
            var paidSeries = new Series("Ödənilən")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.Green
            };
            chartDebtAnalysis.Series.Add(paidSeries);

            chartDebtAnalysis.Legends.Add(new Legend("Legend1"));

            // Add pie chart for debt distribution
            var pieChartArea = new ChartArea("PieArea");
            pieChartArea.Position = new ElementPosition(60, 10, 35, 35);
            chartDebtAnalysis.ChartAreas.Add(pieChartArea);

            var pieSeries = new Series("Borc Bölgüsü")
            {
                ChartType = SeriesChartType.Pie,
                ChartArea = "PieArea"
            };
            chartDebtAnalysis.Series.Add(pieSeries);
        }

        private void InitializeDataGridView()
        {
            dgvCustomerDebts.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn 
                { 
                    Name = "CustomerName", 
                    HeaderText = "Müştəri Adı", 
                    Width = 200 
                },
                new DataGridViewTextBoxColumn 
                { 
                    Name = "TotalDebt", 
                    HeaderText = "Ümumi Borc", 
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "C", ForeColor = Color.Red }
                },
                new DataGridViewTextBoxColumn 
                { 
                    Name = "TotalPaid", 
                    HeaderText = "Ödənilən", 
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "C", ForeColor = Color.Green }
                },
                new DataGridViewTextBoxColumn 
                { 
                    Name = "RemainingDebt", 
                    HeaderText = "Qalan Borc", 
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "C", ForeColor = Color.DarkRed, BackColor = Color.LightPink }
                },
                new DataGridViewTextBoxColumn 
                { 
                    Name = "LastPaymentDate", 
                    HeaderText = "Son Ödəniş", 
                    Width = 100 
                },
                new DataGridViewTextBoxColumn 
                { 
                    Name = "DebtCount", 
                    HeaderText = "Borc Sayı", 
                    Width = 80 
                },
                new DataGridViewTextBoxColumn 
                { 
                    Name = "RiskLevel", 
                    HeaderText = "Risk Səviyyəsi", 
                    Width = 100 
                }
            });

            // Add context menu for actions
            var contextMenu = new ContextMenuStrip();
            var paymentMenuItem = new ToolStripMenuItem("Ödəniş Et");
            var contactMenuItem = new ToolStripMenuItem("Müştəri ilə Əlaqə");
            var historyMenuItem = new ToolStripMenuItem("Ödəniş Tarixçəsi");

            paymentMenuItem.Click += PaymentMenuItem_Click;
            contactMenuItem.Click += ContactMenuItem_Click;
            historyMenuItem.Click += HistoryMenuItem_Click;

            contextMenu.Items.AddRange(new ToolStripItem[] { paymentMenuItem, contactMenuItem, historyMenuItem });
            dgvCustomerDebts.ContextMenuStrip = contextMenu;
        }

        private void InitializeForm()
        {
            LoadDebtReport();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadDebtReport();
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            if (_currentReport == null)
            {
                MessageBox.Show("Əvvəlcə hesabat yükləyin.", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _exportService.ShowExportDebtReportDialog(_currentReport);
        }

        private void PaymentMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvCustomerDebts.SelectedRows.Count > 0)
            {
                var customerId = (int)dgvCustomerDebts.SelectedRows[0].Tag;
                var customerName = dgvCustomerDebts.SelectedRows[0].Cells["CustomerName"].Value.ToString();
                
                MessageBox.Show($"{customerName} üçün ödəniş formu açılacaq.", "Məlumat", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ContactMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvCustomerDebts.SelectedRows.Count > 0)
            {
                var customerName = dgvCustomerDebts.SelectedRows[0].Cells["CustomerName"].Value.ToString();
                var remainingDebt = dgvCustomerDebts.SelectedRows[0].Cells["RemainingDebt"].Value;
                
                MessageBox.Show($"{customerName}\nQalan Borc: {remainingDebt:C}\n\nMüştəri əlaqə məlumatları göstəriləcək.", 
                    "Müştəri Məlumatları", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void HistoryMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvCustomerDebts.SelectedRows.Count > 0)
            {
                var customerName = dgvCustomerDebts.SelectedRows[0].Cells["CustomerName"].Value.ToString();
                MessageBox.Show($"{customerName} üçün ödəniş tarixçəsi açılacaq.", "Məlumat", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadDebtReport()
        {
            try
            {
                btnRefresh.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                var report = _reportService.GetDebtBalanceReport();

                if (report != null)
                {
                    _currentReport = report;
                    DisplayReport(report);
                    btnExport.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Borc hesabatı alına bilmədi.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "Borc hesabatı yükləmərkən xəta baş verdi.");
            }
            finally
            {
                btnRefresh.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private void DisplayReport(DebtReportDto report)
        {
            // Update summary labels
            lblTotalDebt.Text = $"Ümumi Borc: {report.TotalDebt:C}";
            lblTotalPaid.Text = $"Ödənilən: {report.TotalPaid:C}";
            lblRemainingDebt.Text = $"Qalan Borc: {report.RemainingDebt:C}";
            lblCustomersWithDebt.Text = $"Borclu Müştəri: {report.CustomersWithDebt}";
            lblCollectionRate.Text = $"Yığım Dərəcəsi: {report.CollectionRate:F1}%";
            lblAverageDebt.Text = $"Orta Borc: {report.AverageDebtPerCustomer:C}";

            // Update chart
            UpdateChart(report);

            // Update debts grid
            UpdateDebtsGrid(report.CustomerDebts);
        }

        private void UpdateChart(DebtReportDto report)
        {
            // Clear existing data
            chartDebtAnalysis.Series["Qalan Borc"].Points.Clear();
            chartDebtAnalysis.Series["Ödənilən"].Points.Clear();
            chartDebtAnalysis.Series["Borc Bölgüsü"].Points.Clear();

            // Add top 10 customers with highest debt to column chart
            var topDebtors = report.CustomerDebts.OrderByDescending(c => c.RemainingDebt).Take(10);

            foreach (var debt in topDebtors)
            {
                var customerName = debt.CustomerName.Length > 15 ? 
                    debt.CustomerName.Substring(0, 12) + "..." : debt.CustomerName;
                
                chartDebtAnalysis.Series["Qalan Borc"].Points.AddXY(customerName, debt.RemainingDebt);
                chartDebtAnalysis.Series["Ödənilən"].Points.AddXY(customerName, debt.TotalPaid);
            }

            // Add pie chart data
            chartDebtAnalysis.Series["Borc Bölgüsü"].Points.AddXY("Ödənilən", (double)report.TotalPaid);
            chartDebtAnalysis.Series["Borc Bölgüsü"].Points.AddXY("Qalan", (double)report.RemainingDebt);
        }

        private void UpdateDebtsGrid(System.Collections.Generic.List<CustomerDebtDto> debts)
        {
            dgvCustomerDebts.Rows.Clear();

            if (debts?.Any() == true)
            {
                foreach (var debt in debts.OrderByDescending(d => d.RemainingDebt))
                {
                    // Calculate risk level
                    var riskLevel = CalculateRiskLevel(debt);
                    debt.RiskLevel = riskLevel;

                    var row = dgvCustomerDebts.Rows.Add(
                        debt.CustomerName,
                        debt.TotalDebt,
                        debt.TotalPaid,
                        debt.RemainingDebt,
                        debt.LastPaymentDate?.ToString("dd.MM.yyyy") ?? "Yoxdur",
                        debt.DebtCount,
                        riskLevel
                    );

                    // Store customer ID in row tag for context menu
                    dgvCustomerDebts.Rows[row].Tag = debt.CustomerId;

                    // Color code based on risk level
                    var rowColor = GetRiskColor(riskLevel);
                    dgvCustomerDebts.Rows[row].DefaultCellStyle.BackColor = rowColor;
                }
            }
        }

        private string CalculateRiskLevel(CustomerDebtDto debt)
        {
            var daysSinceLastPayment = debt.LastPaymentDate.HasValue ? 
                (DateTime.Now - debt.LastPaymentDate.Value).Days : 365;

            if (debt.RemainingDebt > 1000 && daysSinceLastPayment > 90)
                return "Yüksək";
            else if (debt.RemainingDebt > 500 && daysSinceLastPayment > 60)
                return "Orta";
            else if (daysSinceLastPayment > 30)
                return "Aşağı";
            else
                return "Normal";
        }

        private Color GetRiskColor(string riskLevel)
        {
            switch (riskLevel)
            {
                case "Yüksək": return Color.LightCoral;
                case "Orta": return Color.LightYellow;
                case "Aşağı": return Color.LightBlue;
                default: return Color.White;
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _reportService?.Dispose();
            _exportService?.Dispose();
            base.OnFormClosed(e);
        }
    }
}