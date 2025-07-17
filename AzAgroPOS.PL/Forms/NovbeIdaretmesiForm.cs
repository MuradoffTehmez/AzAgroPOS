using AzAgroPOS.BLL.Services;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.BLL.Interfaces;
using AzAgroPOS.PL.Styles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class NovbeIdaretmesiForm : BaseForm
    {
        private readonly NovbeIdaretmesiService _service;
        private TabControl tabControl;
        private Panel dashboardPanel;
        private Panel shiftsPanel;
        private Panel leavesPanel;

        public NovbeIdaretmesiForm() : base()
        {
            _service = ServiceFactory.CreateNovbeIdaretmesiService();
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

            LoadDashboardData();
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
                Text = "NÖVBƏ İDARƏETMƏSİ",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Anchor = AnchorStyles.Left | AnchorStyles.Top
            };
            titleLabel.Location = new Point(20, 25);

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

            headerPanel.Controls.AddRange(new Control[] { titleLabel, refreshButton });
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

            // Dashboard Tab
            var dashboardTab = new TabPage("Ana Səhifə");
            CreateDashboardPanel();
            dashboardTab.Controls.Add(dashboardPanel);
            tabControl.TabPages.Add(dashboardTab);

            // Shifts Tab
            var shiftsTab = new TabPage("Növbələr");
            CreateShiftsPanel();
            shiftsTab.Controls.Add(shiftsPanel);
            tabControl.TabPages.Add(shiftsTab);

            // Leaves Tab
            var leavesTab = new TabPage("İzinlər");
            CreateLeavesPanel();
            leavesTab.Controls.Add(leavesPanel);
            tabControl.TabPages.Add(leavesTab);

            // Schedules Tab
            var schedulesTab = new TabPage("Növbə Cədvəlləri");
            var schedulesPanel = CreateSchedulesPanel();
            schedulesTab.Controls.Add(schedulesPanel);
            tabControl.TabPages.Add(schedulesTab);
        }

        private void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            ModernTheme.DrawTabItem(sender as TabControl, e);
        }

        #region Dashboard Panel

        private void CreateDashboardPanel()
        {
            dashboardPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = ModernTheme.BackgroundColor,
                Padding = new Padding(20)
            };

            var statsPanel = CreateStatsPanel();
            var recentPanel = CreateRecentActivitiesPanel();

            dashboardPanel.Controls.AddRange(new Control[] { statsPanel, recentPanel });
        }

        private Panel CreateStatsPanel()
        {
            var statsPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 200,
                BackColor = ModernTheme.BackgroundColor
            };

            var stats = new[]
            {
                new { Title = "Bugünkü Növbələr", Value = "0", Color = ModernTheme.SuccessColor },
                new { Title = "Aktiv Növbələr", Value = "0", Color = ModernTheme.InfoColor },
                new { Title = "Gözləyən Təsdiqlər", Value = "0", Color = ModernTheme.WarningColor },
                new { Title = "Aktiv İzinlər", Value = "0", Color = ModernTheme.DangerColor }
            };

            for (int i = 0; i < stats.Length; i++)
            {
                var statCard = CreateStatCard(stats[i].Title, stats[i].Value, stats[i].Color);
                statCard.Location = new Point(i * 280, 20);
                statCard.Name = $"statCard{i}";
                statsPanel.Controls.Add(statCard);
            }

            return statsPanel;
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

        private Panel CreateRecentActivitiesPanel()
        {
            var recentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(20)
            };

            var titleLabel = new Label
            {
                Text = "Son Fəaliyyətlər",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = ModernTheme.TextColor,
                Dock = DockStyle.Top,
                Height = 40
            };

            var activitiesListView = new ListView
            {
                Dock = DockStyle.Fill,
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Font = new Font("Segoe UI", 10)
            };

            activitiesListView.Columns.AddRange(new[]
            {
                new ColumnHeader { Text = "Tarix", Width = 120 },
                new ColumnHeader { Text = "İşçi", Width = 200 },
                new ColumnHeader { Text = "Növ", Width = 150 },
                new ColumnHeader { Text = "Status", Width = 120 },
                new ColumnHeader { Text = "Təfərrüat", Width = 300 }
            });

            recentPanel.Controls.AddRange(new Control[] { titleLabel, activitiesListView });
            ModernTheme.ApplyCardStyle(recentPanel);
            return recentPanel;
        }

        #endregion

        #region Shifts Panel

        private void CreateShiftsPanel()
        {
            shiftsPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = ModernTheme.BackgroundColor,
                Padding = new Padding(20)
            };

            var toolbarPanel = CreateShiftsToolbar();
            var gridPanel = CreateShiftsGrid();

            shiftsPanel.Controls.AddRange(new Control[] { toolbarPanel, gridPanel });
        }

        private Panel CreateShiftsToolbar()
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
                Text = "Yeni Növbə",
                Size = new Size(120, 35),
                BackColor = ModernTheme.SuccessColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(10, 12)
            };
            addButton.Click += AddShift_Click;

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

            var deleteButton = new Button
            {
                Text = "Sil",
                Size = new Size(100, 35),
                BackColor = ModernTheme.DangerColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(270, 12)
            };

            var approveButton = new Button
            {
                Text = "Təsdiqlə",
                Size = new Size(120, 35),
                BackColor = ModernTheme.WarningColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(380, 12)
            };

            var searchTextBox = new TextBox
            {
                Size = new Size(200, 35),
                Font = new Font("Segoe UI", 10),
                PlaceholderText = "Axtar...",
                Anchor = AnchorStyles.Right | AnchorStyles.Top
            };
            searchTextBox.Location = new Point(toolbar.Width - 220, 15);

            toolbar.Controls.AddRange(new Control[] { 
                addButton, editButton, deleteButton, approveButton, searchTextBox 
            });

            ModernTheme.ApplyCardStyle(toolbar);
            return toolbar;
        }

        private Panel CreateShiftsGrid()
        {
            var gridPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(10)
            };

            var shiftsDataGridView = new DataGridView
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

            shiftsDataGridView.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", Width = 60, Visible = false },
                new DataGridViewTextBoxColumn { Name = "IsciAdi", HeaderText = "İşçi", Width = 200 },
                new DataGridViewTextBoxColumn { Name = "NovbeTarixi", HeaderText = "Tarix", Width = 120 },
                new DataGridViewTextBoxColumn { Name = "NovbeVaxti", HeaderText = "Vaxt", Width = 150 },
                new DataGridViewTextBoxColumn { Name = "NovbeAdi", HeaderText = "Növbə", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "ToplamSaat", HeaderText = "Toplam Saat", Width = 120 },
                new DataGridViewTextBoxColumn { Name = "TesdiqStatusu", HeaderText = "Status", Width = 120 },
                new DataGridViewTextBoxColumn { Name = "TesdiqEden", HeaderText = "Təsdiqləyən", Width = 150 }
            });

            ModernTheme.ApplyDataGridViewStyle(shiftsDataGridView);
            gridPanel.Controls.Add(shiftsDataGridView);
            ModernTheme.ApplyCardStyle(gridPanel);
            return gridPanel;
        }

        #endregion

        #region Leaves Panel

        private void CreateLeavesPanel()
        {
            leavesPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = ModernTheme.BackgroundColor,
                Padding = new Padding(20)
            };

            var toolbarPanel = CreateLeavesToolbar();
            var gridPanel = CreateLeavesGrid();

            leavesPanel.Controls.AddRange(new Control[] { toolbarPanel, gridPanel });
        }

        private Panel CreateLeavesToolbar()
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
                Text = "Yeni İzin",
                Size = new Size(120, 35),
                BackColor = ModernTheme.SuccessColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(10, 12)
            };

            var approveButton = new Button
            {
                Text = "Təsdiqlə",
                Size = new Size(120, 35),
                BackColor = ModernTheme.InfoColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(140, 12)
            };

            var rejectButton = new Button
            {
                Text = "Rədd Et",
                Size = new Size(120, 35),
                BackColor = ModernTheme.DangerColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(270, 12)
            };

            var searchTextBox = new TextBox
            {
                Size = new Size(200, 35),
                Font = new Font("Segoe UI", 10),
                PlaceholderText = "Axtar...",
                Anchor = AnchorStyles.Right | AnchorStyles.Top
            };
            searchTextBox.Location = new Point(toolbar.Width - 220, 15);

            toolbar.Controls.AddRange(new Control[] { 
                addButton, approveButton, rejectButton, searchTextBox 
            });

            ModernTheme.ApplyCardStyle(toolbar);
            return toolbar;
        }

        private Panel CreateLeavesGrid()
        {
            var gridPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(10)
            };

            var leavesDataGridView = new DataGridView
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

            leavesDataGridView.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", Width = 60, Visible = false },
                new DataGridViewTextBoxColumn { Name = "IsciAdi", HeaderText = "İşçi", Width = 200 },
                new DataGridViewTextBoxColumn { Name = "IzinTipi", HeaderText = "İzin Tipi", Width = 150 },
                new DataGridViewTextBoxColumn { Name = "IzinMuddeti", HeaderText = "Müddət", Width = 200 },
                new DataGridViewTextBoxColumn { Name = "IzinGunSayi", HeaderText = "Gün Sayı", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "Statusu", HeaderText = "Status", Width = 120 },
                new DataGridViewTextBoxColumn { Name = "TesdiqEden", HeaderText = "Təsdiqləyən", Width = 150 },
                new DataGridViewTextBoxColumn { Name = "SebebOzuru", HeaderText = "Səbəb", Width = 300 }
            });

            ModernTheme.ApplyDataGridViewStyle(leavesDataGridView);
            gridPanel.Controls.Add(leavesDataGridView);
            ModernTheme.ApplyCardStyle(gridPanel);
            return gridPanel;
        }

        #endregion

        #region Schedules Panel

        private Panel CreateSchedulesPanel()
        {
            var schedulesPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = ModernTheme.BackgroundColor,
                Padding = new Padding(20)
            };

            var toolbar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.White,
                Padding = new Padding(10)
            };

            var addButton = new Button
            {
                Text = "Yeni Cədvəl",
                Size = new Size(120, 35),
                BackColor = ModernTheme.SuccessColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(10, 12)
            };

            toolbar.Controls.Add(addButton);
            ModernTheme.ApplyCardStyle(toolbar);

            var gridPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(10)
            };

            var schedulesDataGridView = new DataGridView
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

            schedulesDataGridView.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", Width = 60, Visible = false },
                new DataGridViewTextBoxColumn { Name = "Ad", HeaderText = "Adı", Width = 200 },
                new DataGridViewTextBoxColumn { Name = "NovbeTipi", HeaderText = "Növbə Tipi", Width = 150 },
                new DataGridViewTextBoxColumn { Name = "BaslamaTarixi", HeaderText = "Başlama", Width = 120 },
                new DataGridViewTextBoxColumn { Name = "BitisTarixi", HeaderText = "Bitiş", Width = 120 },
                new DataGridViewCheckBoxColumn { Name = "Aktiv", HeaderText = "Aktiv", Width = 80 },
                new DataGridViewTextBoxColumn { Name = "Aciqlama", HeaderText = "Açıqlama", Width = 300 }
            });

            ModernTheme.ApplyDataGridViewStyle(schedulesDataGridView);
            gridPanel.Controls.Add(schedulesDataGridView);
            ModernTheme.ApplyCardStyle(gridPanel);

            schedulesPanel.Controls.AddRange(new Control[] { toolbar, gridPanel });
            return schedulesPanel;
        }

        #endregion

        #region Event Handlers

        private void AddShift_Click(object sender, EventArgs e)
        {
            // Open shift creation form
            ShowInfo("Növbə əlavə etmə formu açılacaq");
        }

        private async Task RefreshDataAsync()
        {
            try
            {
                await LoadDashboardData();
                ShowSuccess("Məlumatlar yeniləndi");
            }
            catch (Exception ex)
            {
                ShowError($"Məlumatları yeniləyərkən xəta: {ex.Message}");
            }
        }

        #endregion

        #region Data Loading

        private async Task LoadDashboardData()
        {
            try
            {
                var dashboardData = await _service.GetDashboardDataAsync();
                
                UpdateStatCard(0, dashboardData["TodayShiftsCount"].ToString());
                UpdateStatCard(1, dashboardData["ActiveShiftsCount"].ToString());
                UpdateStatCard(2, dashboardData["PendingShiftsCount"].ToString());
                UpdateStatCard(3, dashboardData["ActiveLeavesCount"].ToString());
            }
            catch (Exception ex)
            {
                ShowError($"Dashboard məlumatlarını yükləyərkən xəta: {ex.Message}");
            }
        }

        private void UpdateStatCard(int index, string value)
        {
            var statCard = dashboardPanel.Controls.Find($"statCard{index}", true).FirstOrDefault();
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
            _service?.Dispose();
            base.OnFormClosed(e);
        }
    }
}