using AzAgroPOS.BLL.Services;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.PL.Styles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AzAgroPOS.BLL.Interfaces;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class BildirisForm : BaseForm
    {
        private readonly BildirisService _bildirisService;
        private readonly int _currentUserId;
        private TabControl tabControl;
        private Panel notificationsPanel;
        private Panel settingsPanel;
        private DataGridView notificationsGrid;
        private DataGridView settingsGrid;
        private Timer refreshTimer;


        public BildirisForm(int userId = 1) : base()
        {
            _bildirisService = ServiceFactory.CreateBildirisService();
            _currentUserId = userId;
            InitializeComponent();
            SetupForm();
            ModernTheme.ApplyModernStyle(this);
            SetupRealTimeUpdates();
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
                Text = "BİLDİRİŞ İDARƏETMƏSİ",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Anchor = AnchorStyles.Left | AnchorStyles.Top
            };
            titleLabel.Location = new Point(20, 25);

            var unreadCountLabel = new Label
            {
                Name = "unreadCountLabel",
                Text = "Oxunmayan: 0",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.Yellow,
                AutoSize = true,
                Anchor = AnchorStyles.Right | AnchorStyles.Top
            };
            unreadCountLabel.Location = new Point(headerPanel.Width - 200, 30);

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

            headerPanel.Controls.AddRange(new Control[] { titleLabel, unreadCountLabel, refreshButton });
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

            // Notifications Tab
            var notificationsTab = new TabPage("Bildirişlər");
            CreateNotificationsPanel();
            notificationsTab.Controls.Add(notificationsPanel);
            tabControl.TabPages.Add(notificationsTab);

            // Settings Tab
            var settingsTab = new TabPage("Ayarlar");
            CreateSettingsPanel();
            settingsTab.Controls.Add(settingsPanel);
            tabControl.TabPages.Add(settingsTab);

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

        #region Notifications Panel

        private void CreateNotificationsPanel()
        {
            notificationsPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = ModernTheme.BackgroundColor,
                Padding = new Padding(20)
            };

            var toolbarPanel = CreateNotificationsToolbar();
            var gridPanel = CreateNotificationsGrid();

            notificationsPanel.Controls.AddRange(new Control[] { toolbarPanel, gridPanel });
        }

        private Panel CreateNotificationsToolbar()
        {
            var toolbar = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.White,
                Padding = new Padding(10)
            };

            var markReadButton = new Button
            {
                Text = "Oxunmuş say",
                Size = new Size(120, 35),
                BackColor = ModernTheme.SuccessColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(10, 12)
            };
            markReadButton.Click += MarkAsRead_Click;

            var markAllReadButton = new Button
            {
                Text = "Hamısını oxu",
                Size = new Size(120, 35),
                BackColor = ModernTheme.InfoColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(140, 12)
            };
            markAllReadButton.Click += MarkAllAsRead_Click;

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
            deleteButton.Click += DeleteNotification_Click;

            var filterComboBox = new ComboBox
            {
                Size = new Size(150, 35),
                Font = new Font("Segoe UI", 10),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(380, 15)
            };
            filterComboBox.Items.AddRange(new[] { "Hamısı", "Oxunmayan", "Oxunmuş", "Bu gün", "Bu həftə" });
            filterComboBox.SelectedIndex = 0;
            filterComboBox.SelectedIndexChanged += FilterComboBox_SelectedIndexChanged;

            var searchTextBox = new TextBox
            {
                Size = new Size(200, 35),
                Font = new Font("Segoe UI", 10),
                PlaceholderText = "Axtar...",
                Anchor = AnchorStyles.Right | AnchorStyles.Top
            };
            searchTextBox.Location = new Point(toolbar.Width - 220, 15);
            searchTextBox.TextChanged += SearchTextBox_TextChanged;

            toolbar.Controls.AddRange(new Control[] { 
                markReadButton, markAllReadButton, deleteButton, filterComboBox, searchTextBox 
            });

            ModernTheme.ApplyCardStyle(toolbar);
            return toolbar;
        }

        private Panel CreateNotificationsGrid()
        {
            var gridPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(10)
            };

            notificationsGrid = new DataGridView
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

            notificationsGrid.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", Width = 60, Visible = false },
                new DataGridViewTextBoxColumn { Name = "BildirisIkonu", HeaderText = "", Width = 40 },
                new DataGridViewTextBoxColumn { Name = "Basliq", HeaderText = "Başlıq", Width = 250 },
                new DataGridViewTextBoxColumn { Name = "QisaMesaj", HeaderText = "Mesaj", Width = 300 },
                new DataGridViewTextBoxColumn { Name = "BildirisNovu", HeaderText = "Tip", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "MenbeModulAdi", HeaderText = "Modul", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "Prioritet", HeaderText = "Prioritet", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "ZamanFerqi", HeaderText = "Vaxt", Width = 120 },
                new DataGridViewCheckBoxColumn { Name = "Oxundu", HeaderText = "Oxundu", Width = 80 }
            });

            notificationsGrid.CellDoubleClick += NotificationsGrid_CellDoubleClick;
            notificationsGrid.CellFormatting += NotificationsGrid_CellFormatting;

            ModernTheme.ApplyDataGridViewStyle(notificationsGrid);
            gridPanel.Controls.Add(notificationsGrid);
            ModernTheme.ApplyCardStyle(gridPanel);
            return gridPanel;
        }

        #endregion

        #region Settings Panel

        private void CreateSettingsPanel()
        {
            settingsPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = ModernTheme.BackgroundColor,
                Padding = new Padding(20)
            };

            var toolbarPanel = CreateSettingsToolbar();
            var gridPanel = CreateSettingsGrid();

            settingsPanel.Controls.AddRange(new Control[] { toolbarPanel, gridPanel });
        }

        private Panel CreateSettingsToolbar()
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
                Text = "Yeni Ayar",
                Size = new Size(120, 35),
                BackColor = ModernTheme.SuccessColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(10, 12)
            };
            addButton.Click += AddSetting_Click;

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
            editButton.Click += EditSetting_Click;

            var defaultsButton = new Button
            {
                Text = "Standart Ayarlar",
                Size = new Size(140, 35),
                BackColor = ModernTheme.WarningColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(270, 12)
            };
            defaultsButton.Click += SetDefaults_Click;

            toolbar.Controls.AddRange(new Control[] { 
                addButton, editButton, defaultsButton 
            });

            ModernTheme.ApplyCardStyle(toolbar);
            return toolbar;
        }

        private Panel CreateSettingsGrid()
        {
            var gridPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                Padding = new Padding(10)
            };

            settingsGrid = new DataGridView
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

            settingsGrid.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "ID", Width = 60, Visible = false },
                new DataGridViewTextBoxColumn { Name = "ModulAdi", HeaderText = "Modul", Width = 150 },
                new DataGridViewTextBoxColumn { Name = "BildirisNovu", HeaderText = "Bildiriş Növü", Width = 150 },
                new DataGridViewCheckBoxColumn { Name = "SistemBildirimi", HeaderText = "Sistem", Width = 80 },
                new DataGridViewCheckBoxColumn { Name = "EmailBildirimi", HeaderText = "Email", Width = 80 },
                new DataGridViewCheckBoxColumn { Name = "SesliSiqnal", HeaderText = "Səs", Width = 80 },
                new DataGridViewCheckBoxColumn { Name = "MasaustuBildirimi", HeaderText = "Masaüstü", Width = 80 },
                new DataGridViewTextBoxColumn { Name = "Prioritet", HeaderText = "Prioritet", Width = 100 },
                new DataGridViewCheckBoxColumn { Name = "GeceSessiz", HeaderText = "Gecə Sessiz", Width = 100 },
                new DataGridViewTextBoxColumn { Name = "HefteSonuRezhimi", HeaderText = "Həftə Sonu", Width = 120 }
            });

            ModernTheme.ApplyDataGridViewStyle(settingsGrid);
            gridPanel.Controls.Add(settingsGrid);
            ModernTheme.ApplyCardStyle(gridPanel);
            return gridPanel;
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
                new { Title = "Toplam Bildiriş", Value = "0", Color = ModernTheme.InfoColor },
                new { Title = "Oxunmayan", Value = "0", Color = ModernTheme.WarningColor },
                new { Title = "Bu gün", Value = "0", Color = ModernTheme.SuccessColor },
                new { Title = "Kritik", Value = "0", Color = ModernTheme.DangerColor }
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
                Text = "Bildiriş Statistikaları",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = ModernTheme.TextColor,
                Dock = DockStyle.Top,
                Height = 40
            };

            var chartPlaceholder = new Label
            {
                Text = "Bildiriş növləri və modullar üzrə qrafiklər burada göstəriləcək",
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

        private async void MarkAsRead_Click(object sender, EventArgs e)
        {
            if (notificationsGrid.SelectedRows.Count > 0)
            {
                var selectedRow = notificationsGrid.SelectedRows[0];
                var notificationId = (int)selectedRow.Cells["Id"].Value;
                
                await _bildirisService.MarkAsReadAsync(notificationId, _currentUserId);
                await RefreshDataAsync();
            }
        }

        private async void MarkAllAsRead_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bütün bildirişləri oxunmuş olaraq işarələmək istəyirsiniz?", 
                "Təsdiq", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                await _bildirisService.MarkAllAsReadAsync(_currentUserId);
                await RefreshDataAsync();
            }
        }

        private async void DeleteNotification_Click(object sender, EventArgs e)
        {
            if (notificationsGrid.SelectedRows.Count > 0)
            {
                var selectedRow = notificationsGrid.SelectedRows[0];
                var notificationId = (int)selectedRow.Cells["Id"].Value;
                
                var result = MessageBox.Show("Bu bildirişi silmək istəyirsiniz?", 
                    "Təsdiq", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    await _bildirisService.DeleteNotificationAsync(notificationId);
                    await RefreshDataAsync();
                }
            }
        }

        private async void FilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadNotificationsData();
        }

        private async void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            var searchBox = sender as TextBox;
            if (!string.IsNullOrWhiteSpace(searchBox.Text) && searchBox.Text.Length >= 3)
            {
                var searchResults = await _bildirisService.SearchNotificationsAsync(searchBox.Text, _currentUserId);
                LoadNotificationsToGrid(searchResults);
            }
            else if (string.IsNullOrWhiteSpace(searchBox.Text))
            {
                await LoadNotificationsData();
            }
        }

        private async void NotificationsGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var notificationId = (int)notificationsGrid.Rows[e.RowIndex].Cells["Id"].Value;
                var notification = await _bildirisService.GetNotificationByIdAsync(notificationId);
                
                if (notification != null)
                {
                    var detailForm = new NotificationDetailForm(notification, _bildirisService, _currentUserId);
                    detailForm.ShowDialog();
                    await RefreshDataAsync();
                }
            }
        }

        private void NotificationsGrid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (notificationsGrid.Columns[e.ColumnIndex].Name == "Oxundu")
            {
                var isRead = (bool)e.Value;
                if (!isRead)
                {
                    notificationsGrid.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
                    notificationsGrid.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                }
            }
        }

        private void AddSetting_Click(object sender, EventArgs e)
        {
            var settingForm = new NotificationSettingForm(_bildirisService, _currentUserId);
            if (settingForm.ShowDialog() == DialogResult.OK)
            {
                LoadSettingsData();
            }
        }

        private async void EditSetting_Click(object sender, EventArgs e)
        {
            if (settingsGrid.SelectedRows.Count > 0)
            {
                var selectedRow = settingsGrid.SelectedRows[0];
                var settingId = (int)selectedRow.Cells["Id"].Value;
                
                // Edit setting logic would go here
                MessageBox.Show("Ayar redaktə formu açılacaq", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void SetDefaults_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Standart bildiriş ayarlarını yükləmək istəyirsiniz?", 
                "Təsdiq", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                await _bildirisService.SetDefaultSettingsAsync(_currentUserId);
                await LoadSettingsData();
                MessageBox.Show("Standart ayarlar yükləndi", "Uğur", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async Task RefreshDataAsync()
        {
            await LoadData();
        }

        #endregion

        #region Real-time Updates

        private void SetupRealTimeUpdates()
        {
            // Subscribe to real-time events
            _bildirisService.NotificationCreated += OnNotificationCreated;
            _bildirisService.NotificationRead += OnNotificationRead;
            _bildirisService.UserNotificationsCleared += OnUserNotificationsCleared;

            // Setup refresh timer
            refreshTimer = new Timer
            {
                Interval = 30000 // Refresh every 30 seconds
            };
            refreshTimer.Tick += async (s, e) => await RefreshDataAsync();
            refreshTimer.Start();
        }

        private async void OnNotificationCreated(Bildiris notification)
        {
            if (notification.HedefIstifadeciId == _currentUserId || notification.HedefIstifadeciId == null)
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(async () => await RefreshDataAsync()));
                }
                else
                {
                    await RefreshDataAsync();
                }
            }
        }

        private async void OnNotificationRead(int notificationId, int userId)
        {
            if (userId == _currentUserId)
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(async () => await RefreshDataAsync()));
                }
                else
                {
                    await RefreshDataAsync();
                }
            }
        }

        private async void OnUserNotificationsCleared(int userId)
        {
            if (userId == _currentUserId)
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(async () => await RefreshDataAsync()));
                }
                else
                {
                    await RefreshDataAsync();
                }
            }
        }

        #endregion

        #region Data Loading

        private async Task LoadData()
        {
            try
            {
                await LoadNotificationsData();
                await LoadSettingsData();
                await LoadStatisticsData();
                await UpdateUnreadCount();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Məlumatları yükləyərkən xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadNotificationsData()
        {
            var notifications = await _bildirisService.GetUserNotificationsAsync(_currentUserId);
            LoadNotificationsToGrid(notifications);
        }

        private void LoadNotificationsToGrid(System.Collections.Generic.IEnumerable<Bildiris> notifications)
        {
            var notificationData = notifications.Select(n => new
            {
                n.Id,
                n.BildirisIkonu,
                n.Basliq,
                n.QisaMesaj,
                n.BildirisNovu,
                n.MenbeModulAdi,
                n.Prioritet,
                n.ZamanFerqi,
                n.Oxundu
            }).ToList();

            notificationsGrid.DataSource = notificationData;
        }

        private async Task LoadSettingsData()
        {
            var settings = await _bildirisService.GetUserSettingsAsync(_currentUserId);
            var settingsData = settings.Select(s => new
            {
                s.Id,
                s.ModulAdi,
                s.BildirisNovu,
                s.SistemBildirimi,
                s.EmailBildirimi,
                s.SesliSiqnal,
                s.MasaustuBildirimi,
                s.Prioritet,
                s.GeceSessiz,
                s.HefteSonuRezhimi
            }).ToList();

            settingsGrid.DataSource = settingsData;
        }

        private async Task LoadStatisticsData()
        {
            var stats = await _bildirisService.GetNotificationStatisticsAsync();
            var unreadCount = await _bildirisService.GetUnreadCountAsync(_currentUserId);
            
            UpdateStatCard(0, stats["TotalNotifications"].ToString());
            UpdateStatCard(1, unreadCount.ToString());
            UpdateStatCard(2, stats["TodayNotifications"].ToString());
            
            var priorityStats = stats["PriorityStatistics"] as System.Collections.Generic.Dictionary<string, int>;
            var criticalCount = priorityStats?.GetValueOrDefault(Bildiris.BildirisPrioritetleri.Kritik, 0) ?? 0;
            UpdateStatCard(3, criticalCount.ToString());
        }

        private async Task UpdateUnreadCount()
        {
            var unreadCount = await _bildirisService.GetUnreadCountAsync(_currentUserId);
            var unreadLabel = Controls.Find("unreadCountLabel", true).FirstOrDefault() as Label;
            if (unreadLabel != null)
            {
                unreadLabel.Text = $"Oxunmayan: {unreadCount}";
            }
        }

        private void UpdateStatCard(int index, string value)
        {
            var statsPanel = tabControl.TabPages[2].Controls[0].Controls[0];
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
            refreshTimer?.Stop();
            refreshTimer?.Dispose();
            
            // Unsubscribe from events
            _bildirisService.NotificationCreated -= OnNotificationCreated;
            _bildirisService.NotificationRead -= OnNotificationRead;
            _bildirisService.UserNotificationsCleared -= OnUserNotificationsCleared;
            
            _bildirisService?.Dispose();
            base.OnFormClosed(e);
        }
    }

    public partial class NotificationDetailForm : Form
    {
        private readonly Bildiris _notification;
        private readonly BildirisService _bildirisService;
        private readonly int _currentUserId;

        public NotificationDetailForm(Bildiris notification, BildirisService bildirisService, int currentUserId)
        {
            _notification = notification;
            _bildirisService = bildirisService;
            _currentUserId = currentUserId;
            InitializeComponent();
            SetupForm();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            
            Name = "NotificationDetailForm";
            Text = "Bildiriş Təfərrüatları";
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

            // Header
            var headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(_notification.BildirisRengi.Substring(1).Aggregate(0, (acc, c) => acc * 16 + "0123456789ABCDEF".IndexOf(char.ToUpper(c))))
            };

            var iconLabel = new Label
            {
                Text = _notification.BildirisIkonu,
                Font = new Font("Segoe UI", 24),
                ForeColor = Color.White,
                Location = new Point(20, 15),
                AutoSize = true
            };

            var titleLabel = new Label
            {
                Text = _notification.Basliq,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(70, 20),
                AutoSize = true
            };

            headerPanel.Controls.AddRange(new Control[] { iconLabel, titleLabel });

            // Content
            var contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20),
                BackColor = Color.White
            };

            var messageLabel = new Label
            {
                Text = _notification.Mesaj,
                Font = new Font("Segoe UI", 12),
                Location = new Point(20, 20),
                Size = new Size(540, 200),
                ForeColor = ModernTheme.TextColor
            };

            var detailsLabel = new Label
            {
                Text = $"Modul: {_notification.MenbeModulAdi}\n" +
                       $"Tip: {_notification.BildirisNovu}\n" +
                       $"Prioritet: {_notification.Prioritet}\n" +
                       $"Tarix: {_notification.GonderimeTarixi:dd.MM.yyyy HH:mm}\n" +
                       $"Status: {(_notification.Oxundu ? "Oxunmuş" : "Oxunmamış")}",
                Font = new Font("Segoe UI", 10),
                Location = new Point(20, 240),
                Size = new Size(540, 100),
                ForeColor = ModernTheme.TextColor
            };

            // Buttons
            var buttonPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                BackColor = Color.White,
                Padding = new Padding(20, 10, 20, 10)
            };

            var markReadButton = new Button
            {
                Text = _notification.Oxundu ? "Oxunmamış say" : "Oxunmuş say",
                Size = new Size(150, 40),
                Location = new Point(20, 10),
                BackColor = ModernTheme.InfoColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            markReadButton.Click += async (s, e) => await ToggleReadStatus();

            var closeButton = new Button
            {
                Text = "Bağla",
                Size = new Size(100, 40),
                Location = new Point(450, 10),
                BackColor = ModernTheme.DangerColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                DialogResult = DialogResult.OK
            };

            buttonPanel.Controls.AddRange(new Control[] { markReadButton, closeButton });
            contentPanel.Controls.AddRange(new Control[] { messageLabel, detailsLabel });
            Controls.AddRange(new Control[] { headerPanel, contentPanel, buttonPanel });
        }

        private async Task ToggleReadStatus()
        {
            if (_notification.Oxundu)
            {
                await _bildirisService.MarkAsUnreadAsync(_notification.Id, _currentUserId);
            }
            else
            {
                await _bildirisService.MarkAsReadAsync(_notification.Id, _currentUserId);
            }
            
            DialogResult = DialogResult.OK;
            Close();
        }
    }

    public partial class NotificationSettingForm : Form
    {
        private readonly BildirisService _bildirisService;
        private readonly int _currentUserId;

        public NotificationSettingForm(BildirisService bildirisService, int currentUserId)
        {
            _bildirisService = bildirisService;
            _currentUserId = currentUserId;
            InitializeComponent();
            SetupForm();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            
            Name = "NotificationSettingForm";
            Text = "Bildiriş Ayarları";
            Size = new Size(500, 400);
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            ResumeLayout(false);
        }

        private void SetupForm()
        {
            BackColor = ModernTheme.BackgroundColor;
            
            // Form content would be implemented here
            var placeholderLabel = new Label
            {
                Text = "Bildiriş ayarları formu burada olacaq",
                Font = new Font("Segoe UI", 12),
                ForeColor = ModernTheme.TextColor,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            
            Controls.Add(placeholderLabel);
        }
    }
}