using AzAgroPOS.BLL.Services;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.PL.Styles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class BackupForm : Form
    {
        private readonly BackupService _backupService;
        private TabControl tabControl;
        private Panel backupHistoryPanel;
        private Panel configurationPanel;
        private DataGridView backupHistoryGrid;
        private DataGridView configurationGrid;

        public BackupForm()
        {
            _backupService = new BackupService();
            InitializeComponent();
            SetupForm();
            ModernTheme.ApplyTheme(this);
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            
            Name = "BackupForm";
            Text = "Backup İdarəetməsi";
            Size = new Size(1200, 800);
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
            MinimumSize = new Size(1000, 600);

            ResumeLayout(false);
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
                Text = "BACKUP İDARƏETMƏSİ",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Anchor = AnchorStyles.Left | AnchorStyles.Top
            };
            titleLabel.Location = new Point(20, 25);

            var manualBackupButton = new Button
            {
                Text = "Manuel Backup",
                Size = new Size(140, 35),
                BackColor = ModernTheme.SuccessColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Anchor = AnchorStyles.Right | AnchorStyles.Top
            };
            manualBackupButton.Location = new Point(headerPanel.Width - 300, 23);
            manualBackupButton.Click += ManualBackup_Click;

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
            refreshButton.Location = new Point(headerPanel.Width - 150, 23);
            refreshButton.Click += async (s, e) => await RefreshDataAsync();

            headerPanel.Controls.AddRange(new Control[] { titleLabel, manualBackupButton, refreshButton });
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
            var dashboardTab = new TabPage("Statistika");
            var dashboardPanel = CreateDashboardPanel();
            dashboardTab.Controls.Add(dashboardPanel);
            tabControl.TabPages.Add(dashboardTab);

            // Backup History Tab
            var historyTab = new TabPage("Backup Tarixçəsi");
            CreateBackupHistoryPanel();
            historyTab.Controls.Add(backupHistoryPanel);
            tabControl.TabPages.Add(historyTab);

            // Configuration Tab
            var configTab = new TabPage("Konfiqurasiyalar");
            CreateConfigurationPanel();
            configTab.Controls.Add(configurationPanel);
            tabControl.TabPages.Add(configTab);

            // Restore Tab
            var restoreTab = new TabPage("Bərpa Et");
            var restorePanel = CreateRestorePanel();
            restoreTab.Controls.Add(restorePanel);
            tabControl.TabPages.Add(restoreTab);
        }

        private void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            ModernTheme.DrawTabItem(sender as TabControl, e);
        }

        #region Dashboard Panel

        private Panel CreateDashboardPanel()
        {
            var dashboardPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = ModernTheme.BackgroundColor,
                Padding = new Padding(20)
            };

            var statsPanel = CreateStatsPanel();
            var recentPanel = CreateRecentBackupsPanel();

            dashboardPanel.Controls.AddRange(new Control[] { statsPanel, recentPanel });
            return dashboardPanel;
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
                new { Title = "Toplam Backup", Value = "0", Color = ModernTheme.InfoColor },
                new { Title = "Uğurlu Backup", Value = "0", Color = ModernTheme.SuccessColor },
                new { Title = "Uğursuz Backup", Value = "0", Color = ModernTheme.DangerColor },
                new { Title = "Toplam Ölçü (MB)", Value = "0", Color = ModernTheme.WarningColor }
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

        private Panel CreateRecentBackupsPanel()
        {
            var recentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(20)
            };

            var titleLabel = new Label
            {
                Text = "Son Backup-lar",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = ModernTheme.TextColor,
                Dock = DockStyle.Top,
                Height = 40
            };

            var recentListView = new ListView
            {
                Dock = DockStyle.Fill,
                View = View.Details,
                FullRowSelect = true,
                GridLines = true,
                Font = new Font("Segoe UI", 10)
            };

            recentListView.Columns.AddRange(new[]
            {
                new ColumnHeader { Text = "Backup Adı", Width = 250 },
                new ColumnHeader { Text = "Tarix", Width = 150 },
                new ColumnHeader { Text = "Tip", Width = 120 },
                new ColumnHeader { Text = "Ölçü", Width = 100 },
                new ColumnHeader { Text = "Status", Width = 120 },
                new ColumnHeader { Text = "Müddət", Width = 100 }
            });

            recentPanel.Controls.AddRange(new Control[] { titleLabel, recentListView });
            ModernTheme.ApplyCardStyle(recentPanel);
            return recentPanel;
        }

        #endregion

        #region Backup History Panel

        private void CreateBackupHistoryPanel()
        {
            backupHistoryPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = ModernTheme.BackgroundColor,
                Padding = new Padding(20)
            };

            var toolbarPanel = CreateHistoryToolbar();
            var gridPanel = CreateHistoryGrid();

            backupHistoryPanel.Controls.AddRange(new Control[] { toolbarPanel, gridPanel });
        }

        private Panel CreateHistoryToolbar()
        {
            var toolbar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.White,
                Padding = new Padding(10)
            };

            var deleteButton = new Button
            {
                Text = "Sil",
                Size = new Size(100, 35),
                BackColor = ModernTheme.DangerColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(10, 12)
            };

            var restoreButton = new Button
            {
                Text = "Bərpa Et",
                Size = new Size(120, 35),
                BackColor = ModernTheme.InfoColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(120, 12)
            };

            var verifyButton = new Button
            {
                Text = "Yoxla",
                Size = new Size(100, 35),
                BackColor = ModernTheme.WarningColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(250, 12)
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
                deleteButton, restoreButton, verifyButton, searchTextBox 
            });

            ModernTheme.ApplyCardStyle(toolbar);
            return toolbar;
        }

        private Panel CreateHistoryGrid()
        {
            var gridPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(10)
            };

            backupHistoryGrid = new DataGridView
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

            backupHistoryGrid.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", Width = 60, Visible = false },
                new DataGridViewTextBoxColumn { Name = "BackupAdi", HeaderText = "Backup Adı", Width = 250 },
                new DataGridViewTextBoxColumn { Name = "BackupTarixi", HeaderText = "Tarix", Width = 150 },
                new DataGridViewTextBoxColumn { Name = "BackupTipi", HeaderText = "Tip", Width = 120 },
                new DataGridViewTextBoxColumn { Name = "FaylOlcusuText", HeaderText = "Ölçü", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "Statusu", HeaderText = "Status", Width = 120 },
                new DataGridViewTextBoxColumn { Name = "BackupMuddeteText", HeaderText = "Müddət", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "IstifadeciAdi", HeaderText = "İstifadəçi", Width = 150 }
            });

            ModernTheme.ApplyDataGridViewStyle(backupHistoryGrid);
            gridPanel.Controls.Add(backupHistoryGrid);
            ModernTheme.ApplyCardStyle(gridPanel);
            return gridPanel;
        }

        #endregion

        #region Configuration Panel

        private void CreateConfigurationPanel()
        {
            configurationPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = ModernTheme.BackgroundColor,
                Padding = new Padding(20)
            };

            var toolbarPanel = CreateConfigToolbar();
            var gridPanel = CreateConfigGrid();

            configurationPanel.Controls.AddRange(new Control[] { toolbarPanel, gridPanel });
        }

        private Panel CreateConfigToolbar()
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
                Text = "Yeni Konfiqurasiya",
                Size = new Size(150, 35),
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
                Location = new Point(170, 12)
            };

            var deleteButton = new Button
            {
                Text = "Sil",
                Size = new Size(100, 35),
                BackColor = ModernTheme.DangerColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(300, 12)
            };

            var testButton = new Button
            {
                Text = "Test Et",
                Size = new Size(100, 35),
                BackColor = ModernTheme.WarningColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(410, 12)
            };

            toolbar.Controls.AddRange(new Control[] { 
                addButton, editButton, deleteButton, testButton 
            });

            ModernTheme.ApplyCardStyle(toolbar);
            return toolbar;
        }

        private Panel CreateConfigGrid()
        {
            var gridPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(10)
            };

            configurationGrid = new DataGridView
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

            configurationGrid.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", Width = 60, Visible = false },
                new DataGridViewTextBoxColumn { Name = "TenzimlemeAdi", HeaderText = "Konfiqurasiya Adı", Width = 200 },
                new DataGridViewTextBoxColumn { Name = "BackupTipi", HeaderText = "Backup Tipi", Width = 120 },
                new DataGridViewTextBoxColumn { Name = "BackupVaxtiText", HeaderText = "Vaxt", Width = 100 },
                new DataGridViewCheckBoxColumn { Name = "OtomatikBackup", HeaderText = "Otomatik", Width = 80 },
                new DataGridViewCheckBoxColumn { Name = "Aktiv", HeaderText = "Aktiv", Width = 80 },
                new DataGridViewTextBoxColumn { Name = "SonrakiBackupMuddeteText", HeaderText = "Sonrakı Backup", Width = 200 },
                new DataGridViewTextBoxColumn { Name = "BackupYolu", HeaderText = "Yol", Width = 300 }
            });

            ModernTheme.ApplyDataGridViewStyle(configurationGrid);
            gridPanel.Controls.Add(configurationGrid);
            ModernTheme.ApplyCardStyle(gridPanel);
            return gridPanel;
        }

        #endregion

        #region Restore Panel

        private Panel CreateRestorePanel()
        {
            var restorePanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = ModernTheme.BackgroundColor,
                Padding = new Padding(20)
            };

            var instructionPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 100,
                BackColor = Color.White,
                Padding = new Padding(20)
            };

            var instructionLabel = new Label
            {
                Text = "XƏBƏRDARLIQ: Backup bərpa etmə əməliyyatı hazırkı məlumatları əvəz edəcək.\nBu əməliyyatdan əvvəl mövcud məlumatlardan backup yaradın.",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = ModernTheme.DangerColor,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            instructionPanel.Controls.Add(instructionLabel);
            ModernTheme.ApplyCardStyle(instructionPanel);

            var restoreFormPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(20),
                Margin = new Padding(0, 20, 0, 0)
            };

            var selectLabel = new Label
            {
                Text = "Bərpa ediləcək backup faylını seçin:",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };

            var browseButton = new Button
            {
                Text = "Fayl Seç...",
                Size = new Size(120, 35),
                Location = new Point(20, 60),
                BackColor = ModernTheme.InfoColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            var pathTextBox = new TextBox
            {
                Size = new Size(500, 35),
                Location = new Point(150, 60),
                Font = new Font("Segoe UI", 10),
                ReadOnly = true
            };

            var restoreButton = new Button
            {
                Text = "BƏRPA ET",
                Size = new Size(150, 45),
                Location = new Point(20, 120),
                BackColor = ModernTheme.DangerColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Enabled = false
            };

            restoreFormPanel.Controls.AddRange(new Control[] { 
                selectLabel, browseButton, pathTextBox, restoreButton 
            });
            ModernTheme.ApplyCardStyle(restoreFormPanel);

            restorePanel.Controls.AddRange(new Control[] { instructionPanel, restoreFormPanel });
            return restorePanel;
        }

        #endregion

        #region Event Handlers

        private async void ManualBackup_Click(object sender, EventArgs e)
        {
            var dialog = new ManualBackupDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var result = await _backupService.CreateManualBackupAsync(1, dialog.BackupName, dialog.Description);
                    MessageBox.Show($"Backup uğurla yaradıldı: {result.BackupAdi}", "Uğur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await RefreshDataAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Backup yaradarkən xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task RefreshDataAsync()
        {
            try
            {
                await LoadData();
                MessageBox.Show("Məlumatlar yeniləndi", "Uğur", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Məlumatları yeniləyərkən xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Data Loading

        private async Task LoadData()
        {
            try
            {
                await LoadDashboardData();
                await LoadBackupHistory();
                await LoadConfigurations();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Məlumatları yükləyərkən xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadDashboardData()
        {
            var stats = await _backupService.GetBackupStatisticsAsync();
            
            UpdateStatCard(0, stats["TotalBackups"].ToString());
            UpdateStatCard(1, stats["SuccessfulBackups"].ToString());
            UpdateStatCard(2, stats["FailedBackups"].ToString());
            UpdateStatCard(3, $"{stats["TotalSizeMB"]:F2}");
        }

        private async Task LoadBackupHistory()
        {
            var backups = await _backupService.GetAllBackupsAsync();
            var backupData = backups.Select(b => new
            {
                b.Id,
                b.BackupAdi,
                BackupTarixi = b.BackupTarixi.ToString("dd.MM.yyyy HH:mm"),
                b.BackupTipi,
                b.FaylOlcusuText,
                b.Statusu,
                b.BackupMuddeteText,
                IstifadeciAdi = b.Istifadeci?.Ad + " " + b.Istifadeci?.Soyad
            }).ToList();

            backupHistoryGrid.DataSource = backupData;
        }

        private async Task LoadConfigurations()
        {
            var configs = await _backupService.GetAllConfigurationsAsync();
            var configData = configs.Select(c => new
            {
                c.Id,
                c.TenzimlemeAdi,
                c.BackupTipi,
                c.BackupVaxtiText,
                c.OtomatikBackup,
                c.Aktiv,
                c.SonrakiBackupMuddeteText,
                c.BackupYolu
            }).ToList();

            configurationGrid.DataSource = configData;
        }

        private void UpdateStatCard(int index, string value)
        {
            var dashboardPanel = tabControl.TabPages[0].Controls[0];
            var statsPanel = dashboardPanel.Controls[0];
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
            _backupService?.Dispose();
            base.OnFormClosed(e);
        }
    }

    public partial class ManualBackupDialog : Form
    {
        public string BackupName { get; private set; }
        public string Description { get; private set; }

        private TextBox nameTextBox;
        private TextBox descriptionTextBox;

        public ManualBackupDialog()
        {
            InitializeComponent();
            SetupDialog();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            
            Name = "ManualBackupDialog";
            Text = "Manuel Backup";
            Size = new Size(450, 300);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            ResumeLayout(false);
        }

        private void SetupDialog()
        {
            BackColor = ModernTheme.BackgroundColor;

            var nameLabel = new Label
            {
                Text = "Backup Adı:",
                Location = new Point(20, 30),
                Size = new Size(100, 23),
                Font = new Font("Segoe UI", 10)
            };

            nameTextBox = new TextBox
            {
                Location = new Point(20, 55),
                Size = new Size(390, 23),
                Font = new Font("Segoe UI", 10),
                Text = $"Manuel Backup {DateTime.Now:yyyy-MM-dd HH-mm-ss}"
            };

            var descLabel = new Label
            {
                Text = "Açıqlama:",
                Location = new Point(20, 90),
                Size = new Size(100, 23),
                Font = new Font("Segoe UI", 10)
            };

            descriptionTextBox = new TextBox
            {
                Location = new Point(20, 115),
                Size = new Size(390, 80),
                Font = new Font("Segoe UI", 10),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical
            };

            var okButton = new Button
            {
                Text = "Backup Yarat",
                Size = new Size(120, 35),
                Location = new Point(170, 220),
                BackColor = ModernTheme.SuccessColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                DialogResult = DialogResult.OK
            };

            var cancelButton = new Button
            {
                Text = "Ləğv et",
                Size = new Size(100, 35),
                Location = new Point(300, 220),
                BackColor = ModernTheme.DangerColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                DialogResult = DialogResult.Cancel
            };

            okButton.Click += (s, e) =>
            {
                BackupName = nameTextBox.Text.Trim();
                Description = descriptionTextBox.Text.Trim();
                
                if (string.IsNullOrEmpty(BackupName))
                {
                    MessageBox.Show("Backup adı boş ola bilməz!", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            };

            Controls.AddRange(new Control[] { 
                nameLabel, nameTextBox, descLabel, descriptionTextBox, okButton, cancelButton 
            });
        }
    }
}