using AzAgroPOS.BLL.Services;
using AzAgroPOS.Entities.DTO;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class RepairAnalyticsForm : BaseForm
    {
        private readonly ReportService _reportService;
        private readonly ExportService _exportService;
        private RepairAnalyticsDto _currentReport;

        private DataGridView dgvRepairTypes;
        private DataGridView dgvWorkerPerformance;
        private Panel chartRepairAnalytics;

        // Summary labels
        private Label lblTotalRepairs;
        private Label lblCompletedRepairs;
        private Label lblPendingRepairs;
        private Label lblInProgressRepairs;
        private Label lblTotalCost;
        private Label lblAverageCost;
        private Label lblCompletionRate;
        private Label lblAverageTime;

        public RepairAnalyticsForm() : base()
        {
            _reportService = new ReportService();
            _exportService = new ExportService();
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            CreateSummaryLabels();
            CreateTabs();
            LoadDefaultReport();

            btnGenerate.Click += BtnGenerate_Click;
            btnExport.Click += BtnExport_Click;
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
            tabDetailed.Tag = rtbDetailedReport;

            tabControl.TabPages.AddRange(new TabPage[] { tabOverview, tabWorkers, tabDetailed });
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
                    ShowWarning("Təmir analitikası yaradıla bilmədi.");
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
                ShowInformation("Əvvəlcə analiz edin.");
                return;
            }

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

            // Update grids
            UpdateRepairTypesGrid(report.RepairsByType);
            UpdateWorkerPerformanceGrid(report.WorkerPerformance);

            // Update detailed report
            UpdateDetailedReport(report);
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
                        worker.SuccessRate / 100
                    );

                    dgvWorkerPerformance.Rows[row].Tag = worker.WorkerId;
                    dgvWorkerPerformance.Rows[row].DefaultCellStyle.BackColor = GetPerformanceColor(worker.SuccessRate);
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

                ShowInformation($"{workerName} üçün detallı performans hesabatı açılacaq.");
            }
        }

        private void AssignNewTask()
        {
            if (dgvWorkerPerformance.SelectedRows.Count > 0)
            {
                var workerName = dgvWorkerPerformance.SelectedRows[0].Cells["WorkerName"].Value.ToString();

                ShowInformation($"{workerName} üçün yeni tapşırıq təyin etmə formu açılacaq.");
            }
        }

        private void LoadDefaultReport()
        {
            dtpStartDate.Value = DateTime.Now.AddDays(-30);
            dtpEndDate.Value = DateTime.Now;
            BtnGenerate_Click(null, null);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _reportService?.Dispose();
            _exportService?.Dispose();
            base.OnFormClosed(e);
        }

        private void btnExport_Click_1(object sender, EventArgs e)
        {

        }

        private void btnGenerate_Click_1(object sender, EventArgs e)
        {

        }
    }
}