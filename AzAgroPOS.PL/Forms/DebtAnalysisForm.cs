using AzAgroPOS.BLL.Services;
using AzAgroPOS.Entities.DTO;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
// using System.Windows.Forms.DataVisualization.Charting;

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
        private Panel chartDebtAnalysis; // Chart placeholder
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
            this.pnlControls = new Panel();
            btnRefresh = new Button();
            btnExport = new Button();
            this.lblTitle = new Label();
            pnlSummary = new Panel();
            this.pnlMain = new Panel();
            this.splitContainer = new SplitContainer();
            chartDebtAnalysis = new Panel();
            dgvCustomerDebts = new DataGridView();
            this.pnlControls.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.splitContainer).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomerDebts).BeginInit();
            SuspendLayout();
            // 
            // pnlControls
            // 
            this.pnlControls.Controls.Add(btnRefresh);
            this.pnlControls.Controls.Add(btnExport);
            this.pnlControls.Controls.Add(this.lblTitle);
            this.pnlControls.Location = new Point(0, 0);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new Size(200, 100);
            this.pnlControls.TabIndex = 2;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(0, 0);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(75, 23);
            btnRefresh.TabIndex = 0;
            btnRefresh.Click += BtnRefresh_Click;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(0, 0);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(75, 23);
            btnExport.TabIndex = 1;
            btnExport.Click += BtnExport_Click;
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(100, 23);
            this.lblTitle.TabIndex = 2;
            // 
            // pnlSummary
            // 
            pnlSummary.Location = new Point(0, 0);
            pnlSummary.Name = "pnlSummary";
            pnlSummary.Size = new Size(200, 100);
            pnlSummary.TabIndex = 1;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.splitContainer);
            this.pnlMain.Location = new Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new Size(200, 100);
            this.pnlMain.TabIndex = 0;
            // 
            // splitContainer
            // 
            this.splitContainer.Location = new Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(chartDebtAnalysis);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(dgvCustomerDebts);
            this.splitContainer.Size = new Size(150, 100);
            this.splitContainer.TabIndex = 0;
            // 
            // chartDebtAnalysis
            // 
            chartDebtAnalysis.Location = new Point(0, 0);
            chartDebtAnalysis.Name = "chartDebtAnalysis";
            chartDebtAnalysis.Size = new Size(200, 100);
            chartDebtAnalysis.TabIndex = 0;
            // 
            // dgvCustomerDebts
            // 
            dgvCustomerDebts.Location = new Point(0, 0);
            dgvCustomerDebts.Name = "dgvCustomerDebts";
            dgvCustomerDebts.Size = new Size(240, 150);
            dgvCustomerDebts.TabIndex = 0;
            // 
            // DebtAnalysisForm
            // 
            ClientSize = new Size(1184, 761);
            Controls.Add(this.pnlMain);
            Controls.Add(pnlSummary);
            Controls.Add(this.pnlControls);
            Name = "DebtAnalysisForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Borc Analizi";
            WindowState = FormWindowState.Maximized;
            this.pnlControls.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.splitContainer).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCustomerDebts).EndInit();
            ResumeLayout(false);
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
            // Chart initialize ediləcək (Chart paketlərinin yüklənməsindən sonra)
            /*
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
            */
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

            // Show save file dialog in UI layer
            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Title = "Borc Hesabatını İxrac Et";
                saveDialog.Filter = "CSV Files (*.csv)|*.csv|HTML Files (*.html)|*.html";
                saveDialog.FileName = $"Borc_Hesabati_{DateTime.Now:yyyyMMdd_HHmm}";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    bool success = _exportService.ExportDebtReport(_currentReport, saveDialog.FileName);
                    
                    if (success)
                    {
                        MessageBox.Show("Hesabat uğurla ixrac edildi!", "Uğur", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Ask if user wants to open the file
                        if (MessageBox.Show("Faylı açmaq istəyirsiniz?", "Təsdiq", 
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = saveDialog.FileName,
                                UseShellExecute = true
                            });
                        }
                    }
                    else
                    {
                        MessageBox.Show("İxrac zamanı xəta baş verdi.", "Xəta", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
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
            // Chart yenilənməsi müvəqqəti deaktivdir
            /*
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
            */
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