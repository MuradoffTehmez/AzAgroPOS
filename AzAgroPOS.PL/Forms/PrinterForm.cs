using AzAgroPOS.BLL.Services;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.PL.Styles;
using AzAgroPOS.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class PrinterForm : BaseForm
    {
        private readonly PrinterService _printerService;
        private readonly int _currentUserId;
        private TabControl tabControl;
        private Panel printersPanel;
        private Panel templatesPanel;
        private Panel printLogsPanel;
        private DataGridView printersGrid;
        private DataGridView templatesGrid;
        private DataGridView printLogsGrid;

        public PrinterForm(int userId = 1) : base()
        {
            _printerService = ServiceFactory.CreatePrinterService();
            _currentUserId = userId;
            InitializeComponent();
            SetupForm();
            ModernTheme.ApplyModernStyle(this);
        }


        private void SetupForm()
        {
            BackColor = ModernTheme.BackgroundColor;
            ForeColor = ModernTheme.TextColor;

            // Header Panel
            var headerPanel = CreateHeaderPanel();
            Controls.Add(headerPanel);

            // Tab Control
            CreateTabControl();
            Controls.Add(tabControl);

            LoadData();
        }

        private Panel CreateHeaderPanel()
        {
            var headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = ModernTheme.PrimaryColor,
                Padding = new Padding(20, 0, 20, 0)
            };

            var titleLabel = new Label
            {
                Text = "PRİNTER İDARƏETMƏSİ",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Anchor = AnchorStyles.Left | AnchorStyles.Top
            };
            titleLabel.Location = new Point(20, 25);

            var testAllButton = new Button
            {
                Text = "Hamısını Test Et",
                Size = new Size(140, 35),
                BackColor = ModernTheme.WarningColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Anchor = AnchorStyles.Right | AnchorStyles.Top
            };
            testAllButton.Location = new Point(headerPanel.Width - 290, 23);
            testAllButton.Click += TestAllPrinters_Click;

            var refreshButton = new Button
            {
                Text = "Yenilə",
                Size = new Size(100, 35),
                BackColor = Color.White,
                ForeColor = ModernTheme.PrimaryColor,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Anchor = AnchorStyles.Right | AnchorStyles.Top
            };
            refreshButton.Location = new Point(headerPanel.Width - 130, 23);
            refreshButton.Click += async (s, e) => await RefreshDataAsync();

            headerPanel.Controls.AddRange(new Control[] { titleLabel, testAllButton, refreshButton });
            return headerPanel;
        }

        private void CreateTabControl()
        {
            tabControl = new TabControl
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10),
                DrawMode = TabDrawMode.OwnerDrawFixed,
                Appearance = TabAppearance.FlatButtons
            };

            tabControl.DrawItem += TabControl_DrawItem;

            // Printers Tab
            var printersTab = new TabPage("Printerlər");
            CreatePrintersPanel();
            printersTab.Controls.Add(printersPanel);
            tabControl.TabPages.Add(printersTab);

            // Templates Tab
            var templatesTab = new TabPage("Şablonlar");
            CreateTemplatesPanel();
            templatesTab.Controls.Add(templatesPanel);
            tabControl.TabPages.Add(templatesTab);

            // Print Logs Tab
            var logsTab = new TabPage("Print Logları");
            CreatePrintLogsPanel();
            logsTab.Controls.Add(printLogsPanel);
            tabControl.TabPages.Add(logsTab);

            // Quick Print Tab
            var quickPrintTab = new TabPage("Sürətli Print");
            var quickPrintPanel = CreateQuickPrintPanel();
            quickPrintTab.Controls.Add(quickPrintPanel);
            tabControl.TabPages.Add(quickPrintTab);

            // Statistics Tab
            var statsTab = new TabPage("Statistika");
            var statsPanel = CreateStatisticsPanel();
            statsTab.Controls.Add(statsPanel);
            tabControl.TabPages.Add(statsTab);
        }

        private void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            ModernTheme.DrawTabItem(sender as TabControl, e);
        }

        #region Printers Panel

        private void CreatePrintersPanel()
        {
            printersPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = ModernTheme.BackgroundColor,
                Padding = new Padding(20)
            };

            var toolbarPanel = CreatePrintersToolbar();
            var gridPanel = CreatePrintersGrid();

            printersPanel.Controls.AddRange(new Control[] { toolbarPanel, gridPanel });
        }

        private Panel CreatePrintersToolbar()
        {
            var toolbar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.White,
                Padding = new Padding(10)
            };

            var addButton = new Button
            {
                Text = "Yeni Printer",
                Size = new Size(120, 35),
                BackColor = ModernTheme.SuccessColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(10, 12)
            };
            addButton.Click += AddPrinter_Click;

            var editButton = new Button
            {
                Text = "Redaktə Et",
                Size = new Size(120, 35),
                BackColor = ModernTheme.InfoColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(140, 12)
            };
            editButton.Click += EditPrinter_Click;

            var testButton = new Button
            {
                Text = "Test Et",
                Size = new Size(100, 35),
                BackColor = ModernTheme.WarningColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(270, 12)
            };
            testButton.Click += TestPrinter_Click;

            var deleteButton = new Button
            {
                Text = "Sil",
                Size = new Size(100, 35),
                BackColor = ModernTheme.DangerColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(380, 12)
            };
            deleteButton.Click += DeletePrinter_Click;

            var setDefaultButton = new Button
            {
                Text = "Standart Et",
                Size = new Size(120, 35),
                BackColor = ModernTheme.PrimaryColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(490, 12)
            };
            setDefaultButton.Click += SetDefaultPrinter_Click;

            toolbar.Controls.AddRange(new Control[] { 
                addButton, editButton, testButton, deleteButton, setDefaultButton 
            });

            ModernTheme.ApplyCardStyle(toolbar);
            return toolbar;
        }

        private Panel CreatePrintersGrid()
        {
            var gridPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(10)
            };

            printersGrid = new DataGridView
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10),
                AutoGenerateColumns = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false
            };

            printersGrid.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", Width = 60, Visible = false },
                new DataGridViewTextBoxColumn { Name = "PrinterAdi", HeaderText = "Printer Adı", Width = 200 },
                new DataGridViewTextBoxColumn { Name = "PrinterTipi", HeaderText = "Tip", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "BaglantiTipi", HeaderText = "Bağlantı", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "BaglantiAdresi", HeaderText = "Adres", Width = 200 },
                new DataGridViewTextBoxColumn { Name = "KagizOlculeri", HeaderText = "Kağız Ölçüsü", Width = 120 },
                new DataGridViewCheckBoxColumn { Name = "Aktiv", HeaderText = "Aktiv", Width = 80 },
                new DataGridViewCheckBoxColumn { Name = "StandartPrinter", HeaderText = "Standart", Width = 80 },
                new DataGridViewTextBoxColumn { Name = "Statusu", HeaderText = "Status", Width = 120 },
                new DataGridViewTextBoxColumn { Name = "SonTestTarixi", HeaderText = "Son Test", Width = 150 }
            });

            printersGrid.CellFormatting += PrintersGrid_CellFormatting;
            ModernTheme.ApplyDataGridViewStyle(printersGrid);
            gridPanel.Controls.Add(printersGrid);
            ModernTheme.ApplyCardStyle(gridPanel);
            return gridPanel;
        }

        #endregion

        #region Templates Panel

        private void CreateTemplatesPanel()
        {
            templatesPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = ModernTheme.BackgroundColor,
                Padding = new Padding(20)
            };

            var toolbarPanel = CreateTemplatesToolbar();
            var gridPanel = CreateTemplatesGrid();

            templatesPanel.Controls.AddRange(new Control[] { toolbarPanel, gridPanel });
        }

        private Panel CreateTemplatesToolbar()
        {
            var toolbar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.White,
                Padding = new Padding(10)
            };

            var addButton = new Button
            {
                Text = "Yeni Şablon",
                Size = new Size(120, 35),
                BackColor = ModernTheme.SuccessColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(10, 12)
            };

            var editButton = new Button
            {
                Text = "Redaktə Et",
                Size = new Size(120, 35),
                BackColor = ModernTheme.InfoColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(140, 12)
            };

            var copyButton = new Button
            {
                Text = "Kopyala",
                Size = new Size(100, 35),
                BackColor = ModernTheme.WarningColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(270, 12)
            };

            var previewButton = new Button
            {
                Text = "Önizlə",
                Size = new Size(100, 35),
                BackColor = ModernTheme.InfoColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(380, 12)
            };

            toolbar.Controls.AddRange(new Control[] { 
                addButton, editButton, copyButton, previewButton 
            });

            ModernTheme.ApplyCardStyle(toolbar);
            return toolbar;
        }

        private Panel CreateTemplatesGrid()
        {
            var gridPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(10)
            };

            templatesGrid = new DataGridView
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10),
                AutoGenerateColumns = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false
            };

            templatesGrid.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", Width = 60, Visible = false },
                new DataGridViewTextBoxColumn { Name = "SablonAdi", HeaderText = "Şablon Adı", Width = 200 },
                new DataGridViewTextBoxColumn { Name = "SablonTipi", HeaderText = "Tip", Width = 120 },
                new DataGridViewTextBoxColumn { Name = "PrinterTipi", HeaderText = "Printer Tipi", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "SablonOlculeri", HeaderText = "Ölçü", Width = 120 },
                new DataGridViewCheckBoxColumn { Name = "Aktiv", HeaderText = "Aktiv", Width = 80 },
                new DataGridViewCheckBoxColumn { Name = "StandartSablon", HeaderText = "Standart", Width = 80 },
                new DataGridViewTextBoxColumn { Name = "IstifadeSayisi", HeaderText = "İstifadə", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "SonIstifadeTarixi", HeaderText = "Son İstifadə", Width = 150 }
            });

            ModernTheme.ApplyDataGridViewStyle(templatesGrid);
            gridPanel.Controls.Add(templatesGrid);
            ModernTheme.ApplyCardStyle(gridPanel);
            return gridPanel;
        }

        #endregion

        #region Print Logs Panel

        private void CreatePrintLogsPanel()
        {
            printLogsPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = ModernTheme.BackgroundColor,
                Padding = new Padding(20)
            };

            var toolbarPanel = CreateLogsToolbar();
            var gridPanel = CreateLogsGrid();

            printLogsPanel.Controls.AddRange(new Control[] { toolbarPanel, gridPanel });
        }

        private Panel CreateLogsToolbar()
        {
            var toolbar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.White,
                Padding = new Padding(10)
            };

            var filterComboBox = new ComboBox
            {
                Size = new Size(150, 35),
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(10, 15)
            };
            filterComboBox.Items.AddRange(new[] { "Hamısı", "Uğurlu", "Uğursuz", "Bu gün", "Bu həftə" });
            filterComboBox.SelectedIndex = 0;

            var reprintButton = new Button
            {
                Text = "Yenidən Print",
                Size = new Size(130, 35),
                BackColor = ModernTheme.WarningColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(170, 12)
            };

            var cleanupButton = new Button
            {
                Text = "Köhnə Logları Təmizlə",
                Size = new Size(160, 35),
                BackColor = ModernTheme.DangerColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(310, 12)
            };
            cleanupButton.Click += CleanupLogs_Click;

            toolbar.Controls.AddRange(new Control[] { 
                filterComboBox, reprintButton, cleanupButton 
            });

            ModernTheme.ApplyCardStyle(toolbar);
            return toolbar;
        }

        private Panel CreateLogsGrid()
        {
            var gridPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(10)
            };

            printLogsGrid = new DataGridView
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10),
                AutoGenerateColumns = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false
            };

            printLogsGrid.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", Width = 60, Visible = false },
                new DataGridViewTextBoxColumn { Name = "PrintTarixi", HeaderText = "Tarix", Width = 150 },
                new DataGridViewTextBoxColumn { Name = "PrinterAdi", HeaderText = "Printer", Width = 150 },
                new DataGridViewTextBoxColumn { Name = "SablonAdi", HeaderText = "Şablon", Width = 120 },
                new DataGridViewTextBoxColumn { Name = "PrintTipi", HeaderText = "Tip", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "SuretiSayi", HeaderText = "Nüsxə", Width = 80 },
                new DataGridViewTextBoxColumn { Name = "PrintStatusu", HeaderText = "Status", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "PrintMuddetiText", HeaderText = "Müddət", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "IstifadeciAdi", HeaderText = "İstifadəçi", Width = 120 },
                new DataGridViewTextBoxColumn { Name = "MenbeModul", HeaderText = "Mənbə", Width = 100 }
            });

            printLogsGrid.CellFormatting += PrintLogsGrid_CellFormatting;
            ModernTheme.ApplyDataGridViewStyle(printLogsGrid);
            gridPanel.Controls.Add(printLogsGrid);
            ModernTheme.ApplyCardStyle(gridPanel);
            return gridPanel;
        }

        #endregion

        #region Quick Print Panel

        private Panel CreateQuickPrintPanel()
        {
            var quickPrintPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = ModernTheme.BackgroundColor,
                Padding = new Padding(20)
            };

            var printCard = new Panel
            {
                Size = new Size(600, 400),
                BackColor = Color.White,
                Location = new Point(50, 50)
            };

            var titleLabel = new Label
            {
                Text = "Sürətli Etiket Yazdırma",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };

            var printerLabel = new Label
            {
                Text = "Printer:",
                Location = new Point(20, 70),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };

            var printerComboBox = new ComboBox
            {
                Location = new Point(100, 67),
                Size = new Size(200, 23),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Name = "printerComboBox"
            };

            var templateLabel = new Label
            {
                Text = "Şablon:",
                Location = new Point(320, 70),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };

            var templateComboBox = new ComboBox
            {
                Location = new Point(380, 67),
                Size = new Size(200, 23),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Name = "templateComboBox"
            };

            var productNameLabel = new Label
            {
                Text = "Məhsul Adı:",
                Location = new Point(20, 110),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };

            var productNameTextBox = new TextBox
            {
                Location = new Point(100, 107),
                Size = new Size(200, 23),
                Name = "productNameTextBox"
            };

            var barcodeLabel = new Label
            {
                Text = "Barkod:",
                Location = new Point(320, 110),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };

            var barcodeTextBox = new TextBox
            {
                Location = new Point(380, 107),
                Size = new Size(200, 23),
                Name = "barcodeTextBox"
            };

            var priceLabel = new Label
            {
                Text = "Qiymət:",
                Location = new Point(20, 150),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };

            var priceTextBox = new TextBox
            {
                Location = new Point(100, 147),
                Size = new Size(200, 23),
                Name = "priceTextBox"
            };

            var copiesLabel = new Label
            {
                Text = "Nüsxə Sayı:",
                Location = new Point(320, 150),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };

            var copiesNumericUpDown = new NumericUpDown
            {
                Location = new Point(400, 147),
                Size = new Size(80, 23),
                Minimum = 1,
                Maximum = 100,
                Value = 1,
                Name = "copiesNumericUpDown"
            };

            var printButton = new Button
            {
                Text = "PRINT ET",
                Size = new Size(150, 40),
                Location = new Point(225, 200),
                BackColor = ModernTheme.SuccessColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            printButton.Click += QuickPrint_Click;

            var testPrintButton = new Button
            {
                Text = "Test Print",
                Size = new Size(120, 35),
                Location = new Point(100, 260),
                BackColor = ModernTheme.WarningColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            testPrintButton.Click += QuickTestPrint_Click;

            printCard.Controls.AddRange(new Control[] {
                titleLabel, printerLabel, printerComboBox, templateLabel, templateComboBox,
                productNameLabel, productNameTextBox, barcodeLabel, barcodeTextBox,
                priceLabel, priceTextBox, copiesLabel, copiesNumericUpDown,
                printButton, testPrintButton
            });

            ModernTheme.ApplyCardStyle(printCard);
            quickPrintPanel.Controls.Add(printCard);
            return quickPrintPanel;
        }

        #endregion

        #region Statistics Panel

        private Panel CreateStatisticsPanel()
        {
            var statsPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = ModernTheme.BackgroundColor,
                Padding = new Padding(20)
            };

            var cardsPanel = CreateStatsCardsPanel();
            var chartsPanel = CreateChartsPanel();

            statsPanel.Controls.AddRange(new Control[] { cardsPanel, chartsPanel });
            return statsPanel;
        }

        private Panel CreateStatsCardsPanel()
        {
            var cardsPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 200,
                BackColor = ModernTheme.BackgroundColor
            };

            var stats = new[]
            {
                new { Title = "Toplam Print", Value = "0", Color = ModernTheme.InfoColor },
                new { Title = "Uğur Oranı", Value = "0%", Color = ModernTheme.SuccessColor },
                new { Title = "Aktiv Printerlər", Value = "0", Color = ModernTheme.WarningColor },
                new { Title = "Kağız İstifadəsi", Value = "0 cm²", Color = ModernTheme.DangerColor }
            };

            for (int i = 0; i < stats.Length; i++)
            {
                var statCard = CreateStatCard(stats[i].Title, stats[i].Value, stats[i].Color);
                statCard.Location = new Point(i * 280, 20);
                statCard.Name = $"statCard{i}";
                cardsPanel.Controls.Add(statCard);
            }

            return cardsPanel;
        }

        private Panel CreateStatCard(string title, string value, Color color)
        {
            var card = new Panel
            {
                Size = new Size(260, 150),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None
            };

            var colorStrip = new Panel
            {
                Dock = DockStyle.Top,
                Height = 5,
                BackColor = color
            };

            var titleLabel = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = ModernTheme.TextColor,
                AutoSize = true,
                Location = new Point(20, 25)
            };

            var valueLabel = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 28, FontStyle.Bold),
                ForeColor = color,
                AutoSize = true,
                Location = new Point(20, 60)
            };

            card.Controls.AddRange(new Control[] { colorStrip, titleLabel, valueLabel });
            ModernTheme.ApplyCardStyle(card);
            return card;
        }

        private Panel CreateChartsPanel()
        {
            var chartsPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(20),
                Margin = new Padding(0, 20, 0, 0)
            };

            var titleLabel = new Label
            {
                Text = "Print İstatistikaları",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = ModernTheme.TextColor,
                Dock = DockStyle.Top,
                Height = 40
            };

            var chartPlaceholder = new Label
            {
                Text = "Print statistikaları və qrafiklər burada göstəriləcək",
                Font = new Font("Segoe UI", 12),
                ForeColor = ModernTheme.TextColor,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };

            chartsPanel.Controls.AddRange(new Control[] { titleLabel, chartPlaceholder });
            ModernTheme.ApplyCardStyle(chartsPanel);
            return chartsPanel;
        }

        #endregion

        #region Event Handlers

        private void AddPrinter_Click(object sender, EventArgs e)
        {
            var printerForm = new PrinterConfigForm(_printerService);
            if (printerForm.ShowDialog() == DialogResult.OK)
            {
                LoadPrintersData();
            }
        }

        private async void EditPrinter_Click(object sender, EventArgs e)
        {
            if (printersGrid.SelectedRows.Count > 0)
            {
                var selectedRow = printersGrid.SelectedRows[0];
                var printerId = (int)selectedRow.Cells["Id"].Value;
                
                var printer = await _printerService.GetPrinterByIdAsync(printerId);
                if (printer != null)
                {
                    var printerForm = new PrinterConfigForm(_printerService, printer);
                    if (printerForm.ShowDialog() == DialogResult.OK)
                    {
                        await LoadPrintersData();
                    }
                }
            }
        }

        private async void TestPrinter_Click(object sender, EventArgs e)
        {
            if (printersGrid.SelectedRows.Count > 0)
            {
                var selectedRow = printersGrid.SelectedRows[0];
                var printerId = (int)selectedRow.Cells["Id"].Value;
                
                try
                {
                    await _printerService.TestPrintAsync(printerId, _currentUserId);
                    ShowInformation("Test print göndərildi");
                    await LoadPrintersData();
                    await LoadPrintLogsData();
                }
                catch (Exception ex)
                {
                    ShowError($"Test print xətası: {ex.Message}");
                }
            }
        }

        private async void DeletePrinter_Click(object sender, EventArgs e)
        {
            if (printersGrid.SelectedRows.Count > 0)
            {
                var selectedRow = printersGrid.SelectedRows[0];
                var printerId = (int)selectedRow.Cells["Id"].Value;
                var printerName = selectedRow.Cells["PrinterAdi"].Value.ToString();
                
                var result = ShowQuestion($"'{printerName}' printerini silmək istəyirsiniz?");
                
                if (result == DialogResult.Yes)
                {
                    await _printerService.DeletePrinterAsync(printerId);
                    await LoadPrintersData();
                }
            }
        }

        private async void SetDefaultPrinter_Click(object sender, EventArgs e)
        {
            if (printersGrid.SelectedRows.Count > 0)
            {
                var selectedRow = printersGrid.SelectedRows[0];
                var printerId = (int)selectedRow.Cells["Id"].Value;
                
                await _printerService.SetDefaultPrinterAsync(printerId);
                await LoadPrintersData();
                ShowSuccess("Standart printer təyin edildi");
            }
        }

        private async void TestAllPrinters_Click(object sender, EventArgs e)
        {
            try
            {
                var result = await _printerService.TestAllPrintersAsync();
                var message = result ? "Bütün printerlər test edildi" : "Bəzi printerlər test edilmədi";
                ShowInformation(message);
                await LoadPrintersData();
                await LoadPrintLogsData();
            }
            catch (Exception ex)
            {
                ShowError($"Test əməliyyatı xətası: {ex.Message}");
            }
        }

        private async void QuickPrint_Click(object sender, EventArgs e)
        {
            var quickPrintCard = tabControl.TabPages[3].Controls[0].Controls[0];
            var printerComboBox = quickPrintCard.Controls.Find("printerComboBox", false)[0] as ComboBox;
            var templateComboBox = quickPrintCard.Controls.Find("templateComboBox", false)[0] as ComboBox;
            var productNameTextBox = quickPrintCard.Controls.Find("productNameTextBox", false)[0] as TextBox;
            var barcodeTextBox = quickPrintCard.Controls.Find("barcodeTextBox", false)[0] as TextBox;
            var priceTextBox = quickPrintCard.Controls.Find("priceTextBox", false)[0] as TextBox;
            var copiesNumericUpDown = quickPrintCard.Controls.Find("copiesNumericUpDown", false)[0] as NumericUpDown;

            if (printerComboBox.SelectedItem == null || templateComboBox.SelectedItem == null ||
                string.IsNullOrWhiteSpace(productNameTextBox.Text) || string.IsNullOrWhiteSpace(barcodeTextBox.Text) ||
                !decimal.TryParse(priceTextBox.Text, out decimal price))
            {
                ShowWarning("Bütün sahələri doldurun");
                return;
            }

            try
            {
                var printer = printerComboBox.SelectedItem as PrinterKonfiqurasiyasi;
                var template = templateComboBox.SelectedItem as PrintSablonu;
                
                await _printerService.PrintLabelAsync(
                    printer.Id, 
                    template.Id, 
                    productNameTextBox.Text, 
                    barcodeTextBox.Text, 
                    price, 
                    _currentUserId, 
                    (int)copiesNumericUpDown.Value);

                ShowSuccess("Print əməliyyatı başladı");
                await LoadPrintLogsData();
            }
            catch (Exception ex)
            {
                ShowError($"Print xətası: {ex.Message}");
            }
        }

        private async void QuickTestPrint_Click(object sender, EventArgs e)
        {
            var quickPrintCard = tabControl.TabPages[3].Controls[0].Controls[0];
            var printerComboBox = quickPrintCard.Controls.Find("printerComboBox", false)[0] as ComboBox;

            if (printerComboBox.SelectedItem == null)
            {
                ShowWarning("Printer seçin");
                return;
            }

            try
            {
                var printer = printerComboBox.SelectedItem as PrinterKonfiqurasiyasi;
                await _printerService.TestPrintAsync(printer.Id, _currentUserId);
                ShowSuccess("Test print göndərildi");
                await LoadPrintLogsData();
            }
            catch (Exception ex)
            {
                ShowError($"Test print xətası: {ex.Message}");
            }
        }

        private async void CleanupLogs_Click(object sender, EventArgs e)
        {
            var result = ShowQuestion("90 gündən köhnə print loglarını silmək istəyirsiniz?");
            
            if (result == DialogResult.Yes)
            {
                var deletedCount = await _printerService.CleanupOldLogsAsync(90);
                ShowSuccess($"{deletedCount} köhnə log silindi");
                await LoadPrintLogsData();
            }
        }

        private void PrintersGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (printersGrid.Columns[e.ColumnIndex].Name == "Statusu")
            {
                var status = e.Value?.ToString();
                var row = printersGrid.Rows[e.RowIndex];
                
                switch (status)
                {
                    case "Aktiv":
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        break;
                    case "Bağlantı problemi":
                        row.DefaultCellStyle.BackColor = Color.LightCoral;
                        break;
                    case "Deaktiv":
                        row.DefaultCellStyle.BackColor = Color.LightGray;
                        break;
                }
            }
        }

        private void PrintLogsGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (printLogsGrid.Columns[e.ColumnIndex].Name == "PrintStatusu")
            {
                var status = e.Value?.ToString();
                var row = printLogsGrid.Rows[e.RowIndex];
                
                if (status != "Uğurlu")
                {
                    row.DefaultCellStyle.BackColor = Color.LightPink;
                }
            }
        }

        private async Task RefreshDataAsync()
        {
            await LoadData();
            ShowSuccess("Məlumatlar yeniləndi");
        }

        #endregion

        #region Data Loading

        private async Task LoadData()
        {
            try
            {
                await LoadPrintersData();
                await LoadTemplatesData();
                await LoadPrintLogsData();
                await LoadQuickPrintComboBoxes();
                await LoadStatisticsData();
            }
            catch (Exception ex)
            {
                ShowError($"Məlumatları yükləyərkən xəta: {ex.Message}");
            }
        }

        private async Task LoadPrintersData()
        {
            var printers = await _printerService.GetAllPrintersAsync();
            var printerData = printers.Select(p => new
            {
                p.Id,
                p.PrinterAdi,
                p.PrinterTipi,
                p.BaglantiTipi,
                p.BaglantiAdresi,
                p.KagizOlculeri,
                p.Aktiv,
                p.StandartPrinter,
                p.Statusu,
                SonTestTarixi = p.SonTestTarixi.ToString("dd.MM.yyyy HH:mm")
            }).ToList();

            printersGrid.DataSource = printerData;
        }

        private async Task LoadTemplatesData()
        {
            var templates = await _printerService.GetAllTemplatesAsync();
            var templateData = templates.Select(t => new
            {
                t.Id,
                t.SablonAdi,
                t.SablonTipi,
                t.PrinterTipi,
                t.SablonOlculeri,
                t.Aktiv,
                t.StandartSablon,
                t.IstifadeSayisi,
                SonIstifadeTarixi = t.SonIstifadeTarixi.ToString("dd.MM.yyyy")
            }).ToList();

            templatesGrid.DataSource = templateData;
        }

        private async Task LoadPrintLogsData()
        {
            var logs = await _printerService.GetRecentPrintLogsAsync(100);
            var logData = logs.Select(l => new
            {
                l.Id,
                PrintTarixi = l.PrintTarixi.ToString("dd.MM.yyyy HH:mm"),
                PrinterAdi = l.PrinterKonfiqurasiya?.PrinterAdi ?? "N/A",
                SablonAdi = l.PrintSablonu?.SablonAdi ?? "N/A",
                l.PrintTipi,
                l.SuretiSayi,
                l.PrintStatusu,
                l.PrintMuddetiText,
                IstifadeciAdi = l.Istifadeci?.Ad + " " + l.Istifadeci?.Soyad,
                l.MenbeModul
            }).ToList();

            printLogsGrid.DataSource = logData;
        }

        private async Task LoadQuickPrintComboBoxes()
        {
            var quickPrintCard = tabControl.TabPages[3].Controls[0].Controls[0];
            var printerComboBox = quickPrintCard.Controls.Find("printerComboBox", false)[0] as ComboBox;
            var templateComboBox = quickPrintCard.Controls.Find("templateComboBox", false)[0] as ComboBox;

            var activePrinters = await _printerService.GetActivePrintersAsync();
            printerComboBox.DataSource = activePrinters.ToList();
            printerComboBox.DisplayMember = "PrinterAdi";
            printerComboBox.ValueMember = "Id";

            var activeTemplates = await _printerService.GetActiveTemplatesAsync();
            templateComboBox.DataSource = activeTemplates.ToList();
            templateComboBox.DisplayMember = "SablonAdi";
            templateComboBox.ValueMember = "Id";
        }

        private async Task LoadStatisticsData()
        {
            var stats = await _printerService.GetPrintStatisticsAsync();
            var printStats = stats["PrintStatistics"] as Dictionary<string, object>;
            var printerHealth = stats["PrinterHealth"] as Dictionary<string, object>;

            if (printStats != null && printerHealth != null)
            {
                UpdateStatCard(0, printStats["TotalPrints"].ToString());
                UpdateStatCard(1, $"{printStats["SuccessRate"]:F1}%");
                UpdateStatCard(2, printerHealth["ActivePrinters"].ToString());
                UpdateStatCard(3, $"{printStats["TotalPaperUsage"]:F2} cm²");
            }
        }

        private void UpdateStatCard(int index, string value)
        {
            var statsPanel = tabControl.TabPages[4].Controls[0].Controls[0];
            var statCard = statsPanel.Controls.Find($"statCard{index}", false).FirstOrDefault();
            if (statCard != null)
            {
                var valueLabel = statCard.Controls.OfType<Label>().LastOrDefault();
                if (valueLabel != null)
                    valueLabel.Text = value;
            }
        }

        #endregion

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _printerService?.Dispose();
            base.OnFormClosed(e);
        }
    }

    public partial class PrinterConfigForm : BaseForm
    {
        private readonly PrinterService _printerService;
        private readonly PrinterKonfiqurasiyasi _printer;
        private readonly bool _isEditMode;

        public PrinterConfigForm(PrinterService printerService, PrinterKonfiqurasiyasi printer = null) : base()
        {
            _printerService = printerService;
            _printer = printer;
            _isEditMode = printer != null;
            InitializeComponent();
            SetupForm();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            
            Name = "PrinterConfigForm";
            Text = _isEditMode ? "Printer Redaktəsi" : "Yeni Printer";
            Size = new Size(600, 500);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            ResumeLayout(false);
        }

        private void SetupForm()
        {
            BackColor = ModernTheme.BackgroundColor;
            
            // Form content would be implemented here with all printer configuration fields
            var placeholderLabel = new Label
            {
                Text = "Printer konfiqurasiya formu burada olacaq",
                Font = new Font("Segoe UI", 12),
                ForeColor = ModernTheme.TextColor,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            
            Controls.Add(placeholderLabel);
        }
    }
}