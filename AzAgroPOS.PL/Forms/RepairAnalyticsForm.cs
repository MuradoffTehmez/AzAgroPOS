using AzAgroPOS.BLL.Services;
using AzAgroPOS.Entities.DTO;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
// using System.Windows.Forms.DataVisualization.Charting;

namespace AzAgroPOS.PL.Forms
{
    public partial class RepairAnalyticsForm : Form
    {
        private readonly ReportService _reportService;
        private readonly ExportService _exportService;
        private RepairAnalyticsDto _currentReport;

        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Button btnGenerate;
        private Button btnExport;
        private Panel pnlSummary;
        private DataGridView dgvRepairTypes;
        private DataGridView dgvWorkerPerformance;
        private Panel chartRepairAnalytics; // Chart placeholder
        private TabControl tabControl;
        
        // Summary labels
        private Label lblTotalRepairs;
        private Label lblCompletedRepairs;
        private Label lblPendingRepairs;
        private Label lblInProgressRepairs;
        private Label lblTotalCost;
        private Label lblAverageCost;
        private Label lblCompletionRate;
        private Label lblAverageTime;

        public RepairAnalyticsForm()
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
            this.Text = "Təmir Analitikası";
            this.Size = new Size(1400, 900);
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

            // Buttons
            btnGenerate = new Button
            {
                Text = "🔧 Analiz Et",
                Location = new Point(410, 17),
                Size = new Size(100, 25),
                BackColor = Color.LightBlue
            };
            btnGenerate.Click += BtnGenerate_Click;

            btnExport = new Button
            {
                Text = "📤 İxrac Et",
                Location = new Point(520, 17),
                Size = new Size(100, 25),
                BackColor = Color.LightGreen,
                Enabled = false
            };
            btnExport.Click += BtnExport_Click;

            var lblTitle = new Label
            {
                Text = "Təmir İşləri Performans Analizi",
                Location = new Point(640, 22),
                Size = new Size(250, 20),
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            pnlControls.Controls.AddRange(new Control[] 
            { 
                lblStartDate, dtpStartDate, lblEndDate, dtpEndDate, 
                btnGenerate, btnExport, lblTitle 
            });

            // Summary Panel
            pnlSummary = new Panel
            {
                Dock = DockStyle.Top,
                Height = 120,
                BackColor = Color.WhiteSmoke,
                BorderStyle = BorderStyle.FixedSingle
            };

            CreateSummaryLabels();

            // Main TabControl
            tabControl = new TabControl
            {
                Dock = DockStyle.Fill
            };

            CreateTabs();

            // Add controls to form
            this.Controls.Add(tabControl);
            this.Controls.Add(pnlSummary);
            this.Controls.Add(pnlControls);

            this.ResumeLayout(false);
        }

        private void CreateSummaryLabels()
        {
            // First row
            lblTotalRepairs = new Label
            {
                Text = "Ümumi Təmir: -",
                Location = new Point(20, 15),
                Size = new Size(150, 20),
                Font = new Font("Arial", 9, FontStyle.Bold)
            };

            lblCompletedRepairs = new Label
            {
                Text = "Tamamlanmış: -",
                Location = new Point(180, 15),
                Size = new Size(150, 20),
                Font = new Font("Arial", 9, FontStyle.Bold),
                ForeColor = Color.Green
            };

            lblPendingRepairs = new Label
            {
                Text = "Gözləyən: -",
                Location = new Point(340, 15),
                Size = new Size(150, 20),
                Font = new Font("Arial", 9, FontStyle.Bold),
                ForeColor = Color.Orange
            };

            lblInProgressRepairs = new Label
            {
                Text = "Davam edən: -",
                Location = new Point(500, 15),
                Size = new Size(150, 20),
                Font = new Font("Arial", 9, FontStyle.Bold),
                ForeColor = Color.Blue
            };

            // Second row
            lblTotalCost = new Label
            {
                Text = "Ümumi Xərc: -",
                Location = new Point(20, 45),
                Size = new Size(150, 20),
                Font = new Font("Arial", 9, FontStyle.Bold),
                ForeColor = Color.Red
            };

            lblAverageCost = new Label
            {
                Text = "Orta Xərc: -",
                Location = new Point(180, 45),
                Size = new Size(150, 20),
                Font = new Font("Arial", 9, FontStyle.Bold)
            };

            lblCompletionRate = new Label
            {
                Text = "Tamamlanma %: -",
                Location = new Point(340, 45),
                Size = new Size(150, 20),
                Font = new Font("Arial", 9, FontStyle.Bold),
                ForeColor = Color.Purple
            };

            lblAverageTime = new Label
            {
                Text = "Orta Vaxt: -",
                Location = new Point(500, 45),
                Size = new Size(150, 20),
                Font = new Font("Arial", 9, FontStyle.Bold)
            };

            pnlSummary.Controls.AddRange(new Control[] 
            { 
                lblTotalRepairs, lblCompletedRepairs, lblPendingRepairs, lblInProgressRepairs,
                lblTotalCost, lblAverageCost, lblCompletionRate, lblAverageTime
            });
        }

        private void CreateTabs()
        {
            // Tab 1: Overview and Charts
            var tabOverview = new TabPage("📊 Ümumi Baxış");
            
            var splitMain = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Horizontal,
                SplitterDistance = 350
            };

            // Chart placeholder for repair analytics
            chartRepairAnalytics = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.LightGreen,
                BorderStyle = BorderStyle.FixedSingle
            };
            chartRepairAnalytics.Controls.Add(new Label 
            { 
                Text = "🔧 Təmir Analitikası (Chart kontrolları yüklənir...)", 
                Dock = DockStyle.Fill, 
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            });
            // InitializeChart(); // Chart yüklənəndən sonra aktiv ediləcək

            // Repair types grid
            dgvRepairTypes = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
            InitializeRepairTypesGrid();

            splitMain.Panel1.Controls.Add(chartRepairAnalytics);
            splitMain.Panel2.Controls.Add(dgvRepairTypes);
            tabOverview.Controls.Add(splitMain);

            // Tab 2: Worker Performance
            var tabWorkers = new TabPage("👥 İşçi Performansı");
            
            dgvWorkerPerformance = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
            InitializeWorkerPerformanceGrid();
            tabWorkers.Controls.Add(dgvWorkerPerformance);

            // Tab 3: Detailed Reports
            var tabDetailed = new TabPage("📋 Detallı Hesabat");
            var rtbDetailedReport = new RichTextBox
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                Font = new Font("Consolas", 10)
            };
            tabDetailed.Controls.Add(rtbDetailedReport);
            tabDetailed.Tag = rtbDetailedReport; // Store reference for later use

            tabControl.TabPages.AddRange(new TabPage[] { tabOverview, tabWorkers, tabDetailed });
        }

        private void InitializeChart()
        {
            // Chart initialize ediləcək (Chart paketlərinin yüklənməsindən sonra)
            /*
            chartRepairAnalytics.Series.Clear();
            chartRepairAnalytics.ChartAreas.Clear();

            // Main chart area for repair types
            var chartArea1 = new ChartArea("RepairTypesArea");
            chartArea1.AxisX.Title = "Təmir Növü";
            chartArea1.AxisY.Title = "Sayı";
            chartArea1.Position = new ElementPosition(5, 5, 45, 90);
            chartRepairAnalytics.ChartAreas.Add(chartArea1);

            // Pie chart area for status distribution
            var chartArea2 = new ChartArea("StatusArea");
            chartArea2.Position = new ElementPosition(55, 5, 40, 45);
            chartRepairAnalytics.ChartAreas.Add(chartArea2);

            // Cost chart area
            var chartArea3 = new ChartArea("CostArea");
            chartArea3.AxisX.Title = "Təmir Növü";
            chartArea3.AxisY.Title = "Məbləğ (AZN)";
            chartArea3.AxisY.LabelStyle.Format = "C0";
            chartArea3.Position = new ElementPosition(55, 55, 40, 40);
            chartRepairAnalytics.ChartAreas.Add(chartArea3);

            // Series for repair types count
            var countSeries = new Series("Təmir Sayı")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.SteelBlue,
                ChartArea = "RepairTypesArea"
            };
            chartRepairAnalytics.Series.Add(countSeries);

            // Series for status distribution (pie)
            var statusSeries = new Series("Status Bölgüsü")
            {
                ChartType = SeriesChartType.Pie,
                ChartArea = "StatusArea"
            };
            chartRepairAnalytics.Series.Add(statusSeries);

            // Series for cost analysis
            var costSeries = new Series("Xərc Analizi")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.Coral,
                ChartArea = "CostArea"
            };
            chartRepairAnalytics.Series.Add(costSeries);

            chartRepairAnalytics.Legends.Add(new Legend("Legend1"));
            */
        }

        private void InitializeRepairTypesGrid()
        {
            dgvRepairTypes.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn 
                { 
                    Name = "RepairType", 
                    HeaderText = "Təmir Növü", 
                    Width = 200 
                },
                new DataGridViewTextBoxColumn 
                { 
                    Name = "Count", 
                    HeaderText = "Sayı", 
                    Width = 80 
                },
                new DataGridViewTextBoxColumn 
                { 
                    Name = "TotalCost", 
                    HeaderText = "Ümumi Xərc", 
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "C" }
                },
                new DataGridViewTextBoxColumn 
                { 
                    Name = "AverageCost", 
                    HeaderText = "Orta Xərc", 
                    Width = 100,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "C" }
                },
                new DataGridViewTextBoxColumn 
                { 
                    Name = "Percentage", 
                    HeaderText = "Faiz", 
                    Width = 80,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "P1" }
                },
                new DataGridViewTextBoxColumn 
                { 
                    Name = "AverageCompletionDays", 
                    HeaderText = "Orta Müddət (gün)", 
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N1" }
                }
            });
        }

        private void InitializeWorkerPerformanceGrid()
        {
            dgvWorkerPerformance.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn 
                { 
                    Name = "WorkerName", 
                    HeaderText = "İşçi Adı", 
                    Width = 200 
                },
                new DataGridViewTextBoxColumn 
                { 
                    Name = "CompletedRepairs", 
                    HeaderText = "Tamamlanan", 
                    Width = 100 
                },
                new DataGridViewTextBoxColumn 
                { 
                    Name = "PendingRepairs", 
                    HeaderText = "Gözləyən", 
                    Width = 100 
                },
                new DataGridViewTextBoxColumn 
                { 
                    Name = "TotalRevenue", 
                    HeaderText = "Ümumi Gəlir", 
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "C" }
                },
                new DataGridViewTextBoxColumn 
                { 
                    Name = "AverageRepairTime", 
                    HeaderText = "Orta Vaxt (gün)", 
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N1" }
                },
                new DataGridViewTextBoxColumn 
                { 
                    Name = "SuccessRate", 
                    HeaderText = "Uğur Dərəcəsi", 
                    Width = 120,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "P1" }
                }
            });

            // Add context menu for worker performance
            var contextMenu = new ContextMenuStrip();
            var viewDetailsMenuItem = new ToolStripMenuItem("Detalları Göstər");
            var assignTaskMenuItem = new ToolStripMenuItem("Yeni Tapşırıq");
            
            viewDetailsMenuItem.Click += (s, e) => ShowWorkerDetails();
            assignTaskMenuItem.Click += (s, e) => AssignNewTask();
            
            contextMenu.Items.AddRange(new ToolStripItem[] { viewDetailsMenuItem, assignTaskMenuItem });
            dgvWorkerPerformance.ContextMenuStrip = contextMenu;
        }

        private void InitializeForm()
        {
            // Load default report (last 30 days)
            LoadDefaultReport();
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                btnGenerate.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                var report = _reportService.GetRepairAnalytics(dtpStartDate.Value, dtpEndDate.Value);

                if (report != null)
                {
                    _currentReport = report;
                    DisplayReport(report);
                    btnExport.Enabled = true;
                    ErrorHandlingService.ShowSuccess("Təmir analitikası uğurla yaradıldı!");
                }
                else
                {
                    MessageBox.Show("Təmir analitikası yaradıla bilmədi.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "Təmir analitikası yaradılarkən xəta baş verdi.");
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
                MessageBox.Show("Əvvəlcə analiz edin.", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // For now, export repair analytics using the existing export service
            try
            {
                using (var saveDialog = new SaveFileDialog())
                {
                    saveDialog.Title = "Təmir Analitikasını İxrac Et";
                    saveDialog.Filter = "CSV Files (*.csv)|*.csv|HTML Files (*.html)|*.html";
                    saveDialog.FileName = $"Tamir_Analitikasi_{DateTime.Now:yyyyMMdd_HHmm}";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        bool success = _exportService.ExportRepairAnalyticsToExcel(_currentReport, saveDialog.FileName);
                        
                        if (success)
                        {
                            ErrorHandlingService.ShowSuccess("Analitika uğurla ixrac edildi!");
                            
                            if (ErrorHandlingService.ShowConfirmation("Faylı açmaq istəyirsiniz?"))
                            {
                                System.Diagnostics.Process.Start(saveDialog.FileName);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "İxrac zamanı xəta baş verdi.");
            }
        }

        private void DisplayReport(RepairAnalyticsDto report)
        {
            // Update summary labels
            lblTotalRepairs.Text = $"Ümumi Təmir: {report.TotalRepairs}";
            lblCompletedRepairs.Text = $"Tamamlanmış: {report.CompletedRepairs}";
            lblPendingRepairs.Text = $"Gözləyən: {report.PendingRepairs}";
            lblInProgressRepairs.Text = $"Davam edən: {report.InProgressRepairs}";
            lblTotalCost.Text = $"Ümumi Xərc: {report.TotalCost:C}";
            lblAverageCost.Text = $"Orta Xərc: {report.AverageCost:C}";
            lblCompletionRate.Text = $"Tamamlanma %: {report.CompletionRate:F1}%";
            lblAverageTime.Text = $"Orta Vaxt: {report.AverageRepairTime:F1} gün";

            // Update charts
            UpdateCharts(report);

            // Update grids
            UpdateRepairTypesGrid(report.RepairsByType);
            UpdateWorkerPerformanceGrid(report.WorkerPerformance);

            // Update detailed report
            UpdateDetailedReport(report);
        }

        private void UpdateCharts(RepairAnalyticsDto report)
        {
            // Chart yenilənməsi müvəqqəti deaktivdir
            /*
            // Clear existing data
            chartRepairAnalytics.Series["Təmir Sayı"].Points.Clear();
            chartRepairAnalytics.Series["Status Bölgüsü"].Points.Clear();
            chartRepairAnalytics.Series["Xərc Analizi"].Points.Clear();

            // Update repair types chart
            if (report.RepairsByType?.Any() == true)
            {
                foreach (var repairType in report.RepairsByType.Take(10))
                {
                    chartRepairAnalytics.Series["Təmir Sayı"].Points.AddXY(repairType.RepairType, repairType.Count);
                    chartRepairAnalytics.Series["Xərc Analizi"].Points.AddXY(repairType.RepairType, (double)repairType.TotalCost);
                }
            }

            // Update status distribution pie chart
            chartRepairAnalytics.Series["Status Bölgüsü"].Points.AddXY("Tamamlanmış", report.CompletedRepairs);
            chartRepairAnalytics.Series["Status Bölgüsü"].Points.AddXY("Gözləyən", report.PendingRepairs);
            chartRepairAnalytics.Series["Status Bölgüsü"].Points.AddXY("Davam edən", report.InProgressRepairs);
            */
        }

        private void UpdateRepairTypesGrid(System.Collections.Generic.List<RepairTypeDto> repairTypes)
        {
            dgvRepairTypes.Rows.Clear();

            if (repairTypes?.Any() == true)
            {
                var totalCount = repairTypes.Sum(rt => rt.Count);

                foreach (var repairType in repairTypes.OrderByDescending(rt => rt.Count))
                {
                    var percentage = totalCount > 0 ? (decimal)repairType.Count / totalCount : 0;
                    
                    dgvRepairTypes.Rows.Add(
                        repairType.RepairType,
                        repairType.Count,
                        repairType.TotalCost,
                        repairType.AverageCost,
                        percentage,
                        repairType.AverageCompletionDays
                    );
                }
            }
        }

        private void UpdateWorkerPerformanceGrid(System.Collections.Generic.List<RepairWorkerDto> workers)
        {
            dgvWorkerPerformance.Rows.Clear();

            if (workers?.Any() == true)
            {
                foreach (var worker in workers.OrderByDescending(w => w.CompletedRepairs))
                {
                    var row = dgvWorkerPerformance.Rows.Add(
                        worker.WorkerName,
                        worker.CompletedRepairs,
                        worker.PendingRepairs,
                        worker.TotalRevenue,
                        worker.AverageRepairTime,
                        worker.SuccessRate / 100 // Convert to decimal for percentage format
                    );

                    // Store worker ID in row tag
                    dgvWorkerPerformance.Rows[row].Tag = worker.WorkerId;

                    // Color code based on performance
                    var rowColor = GetPerformanceColor(worker.SuccessRate);
                    dgvWorkerPerformance.Rows[row].DefaultCellStyle.BackColor = rowColor;
                }
            }
        }

        private void UpdateDetailedReport(RepairAnalyticsDto report)
        {
            var detailedTab = tabControl.TabPages[2];
            var rtb = detailedTab.Tag as RichTextBox;

            if (rtb != null)
            {
                rtb.Clear();
                rtb.SelectionFont = new Font("Consolas", 12, FontStyle.Bold);
                rtb.AppendText("TƏMİR ANALİTİKASI DETALLI HESABATI\n");
                rtb.AppendText("=" + new string('=', 50) + "\n\n");

                rtb.SelectionFont = new Font("Consolas", 10);
                rtb.AppendText($"Hesabat Dövrü: {report.StartDate:dd.MM.yyyy} - {report.EndDate:dd.MM.yyyy}\n");
                rtb.AppendText($"Yaradılma Tarixi: {report.GeneratedDate:dd.MM.yyyy HH:mm}\n\n");

                rtb.SelectionFont = new Font("Consolas", 11, FontStyle.Bold);
                rtb.AppendText("ÜMUMİ STATİSTİKA:\n");
                rtb.SelectionFont = new Font("Consolas", 10);
                rtb.AppendText($"• Ümumi təmir sayı: {report.TotalRepairs}\n");
                rtb.AppendText($"• Tamamlanmış: {report.CompletedRepairs} ({report.CompletionRate:F1}%)\n");
                rtb.AppendText($"• Gözləyən: {report.PendingRepairs}\n");
                rtb.AppendText($"• Davam edən: {report.InProgressRepairs}\n");
                rtb.AppendText($"• Ümumi xərc: {report.TotalCost:C}\n");
                rtb.AppendText($"• Orta xərc: {report.AverageCost:C}\n");
                rtb.AppendText($"• Orta təmir vaxtı: {report.AverageRepairTime:F1} gün\n\n");

                if (report.RepairsByType?.Any() == true)
                {
                    rtb.SelectionFont = new Font("Consolas", 11, FontStyle.Bold);
                    rtb.AppendText("TƏMİR NÖVLƏRI ÜZRƏ DAĞILIM:\n");
                    rtb.SelectionFont = new Font("Consolas", 10);
                    
                    foreach (var repairType in report.RepairsByType.OrderByDescending(rt => rt.Count))
                    {
                        rtb.AppendText($"• {repairType.RepairType}:\n");
                        rtb.AppendText($"  - Sayı: {repairType.Count}\n");
                        rtb.AppendText($"  - Xərc: {repairType.TotalCost:C} (Orta: {repairType.AverageCost:C})\n");
                        rtb.AppendText($"  - Orta tamamlanma: {repairType.AverageCompletionDays:F1} gün\n\n");
                    }
                }
            }
        }

        private Color GetPerformanceColor(decimal successRate)
        {
            if (successRate >= 90) return Color.LightGreen;
            if (successRate >= 80) return Color.LightYellow;
            if (successRate >= 70) return Color.LightBlue;
            return Color.LightPink;
        }

        private void ShowWorkerDetails()
        {
            if (dgvWorkerPerformance.SelectedRows.Count > 0)
            {
                var workerName = dgvWorkerPerformance.SelectedRows[0].Cells["WorkerName"].Value.ToString();
                var workerId = (int)dgvWorkerPerformance.SelectedRows[0].Tag;
                
                MessageBox.Show($"{workerName} üçün detallı performans hesabatı açılacaq.", 
                    "İşçi Detalları", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AssignNewTask()
        {
            if (dgvWorkerPerformance.SelectedRows.Count > 0)
            {
                var workerName = dgvWorkerPerformance.SelectedRows[0].Cells["WorkerName"].Value.ToString();
                
                MessageBox.Show($"{workerName} üçün yeni tapşırıq təyin etmə formu açılacaq.", 
                    "Yeni Tapşırıq", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadDefaultReport()
        {
            // Load last 30 days report by default
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