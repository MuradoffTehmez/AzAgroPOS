// Fayl: AzAgroPOS.Teqdimat/AnaMenuFormu.cs

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Teqdimat.Xidmetler;
using AzAgroPOS.Teqdimat.Yardimcilar;
using AzAgroPOS.Varliglar;
using MaterialSkin.Controls;
using Microsoft.Extensions.DependencyInjection;
using System.Drawing.Drawing2D;

namespace AzAgroPOS.Teqdimat;

public partial class AnaMenuFormu : BazaForm, IAnaMenuView
{
    private readonly Dictionary<Type, MaterialButton> _formButtonMap;
    private readonly Dictionary<MaterialButton, ToolStripMenuItem> _menuItems = new();
    private readonly MenuStrip _mainMenu = new();
    private readonly ToolStripLabel _menuUserLabel = new();
    private readonly ToolStripMenuItem _customerMenuItem = new("Müştərilər");
    private readonly ToolStripMenuItem _homeMenuItem = new("Ana səhifə");
    private TabPage? _dashboardTab;
    private readonly TableLayoutPanel _workspaceLayout = new();
    private readonly Panel _tabHost = new();
    private readonly Panel _navigationCover = new();
    private readonly System.Windows.Forms.Timer _navigationTimer = new() { Interval = 16 };
    private DateTime _navigationStarted;
    private readonly Dictionary<TabPage, AsyncServiceScope> _tabScopes = new();
    private readonly SemaphoreSlim _dashboardKilidi = new(1, 1);
    private readonly SessiyaGirisFiltiri _girisFiltiri = new();
    private readonly System.Windows.Forms.Timer _sessiyaTimer = new() { Interval = 60_000 };
    private DateTime _sonSessiyaYenilemesi = DateTime.Now;

    // IAnaMenuView interface implementasiyası
    public IServiceProvider ServiceProvider { get; }

    // Hadisələr
    public event EventHandler FormYuklendi;
    public event EventHandler<FormClosingEventArgs> FormBaglaniyor;

    public AnaMenuFormu(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        ServiceProvider = serviceProvider;
        Application.AddMessageFilter(_girisFiltiri);
        _sessiyaTimer.Tick += async (_, _) => await SessiyaniYoxlaAsync();
        _sessiyaTimer.Start();
        FormClosed += (_, _) =>
        {
            _sessiyaTimer.Stop();
            _sessiyaTimer.Dispose();
            _navigationTimer.Stop();
            _navigationTimer.Dispose();
            Application.RemoveMessageFilter(_girisFiltiri);
        };

        Load += (sender, e) => FormYuklendi?.Invoke(this, EventArgs.Empty);
        Shown += AnaMenuFormu_Shown;
        FormClosing += (sender, e) => FormBaglaniyor?.Invoke(this, e);

        // Modern dizayn tətbiq edirik
        AnaMenuFormModernStyle.StyleDashboardCards(dashboardPanel);

        _formButtonMap = new Dictionary<Type, MaterialButton>
        {
            { typeof(NovbeIdareetmesiFormu), btnNovbeIdareetme },
            { typeof(SatisFormu), btnYeniSatis },
            { typeof(QaytarmaFormu), btnQaytarma },
            { typeof(XercIdareetmeFormu), btnXercIdareetme },
            { typeof(NisyeIdareetmeFormu), btnNisyeIdareetme },
            { typeof(TemirIdareetmeFormu), btnTemirIdareetme },
            { typeof(MehsulIdareetmeFormu), btnMehsulIdareetme },
            { typeof(IstifadeciIdareetmeFormu), btnIstifadeciIdareetme },
            { typeof(IsciIdareetmeFormu), btnIsciIdareetme },
            { typeof(HesabatFormu), btnHesabatlar },
            { typeof(MehsulSatisHesabatFormu), btnMehsulSatisHesabati },
            { typeof(AnbarQaliqHesabatFormu), btnAnbarQaliqHesabati },
            { typeof(ZHesabatArxivFormu), btnZHesabatArxivi },
            { typeof(BarkodCapiFormu), btnBarkodCapi },
            { typeof(MinimumStokMehsullariFormu), btnMinimumStokMehsullari },
            { typeof(KonfiqurasiyaFormu), btnKonfiqurasiya },
            { typeof(AlisSenedFormu), btnAlisSened },
            { typeof(KassaFormu), btnKassaIdareetme },
            { typeof(AlisSifarisFormu), btnAlisSifaris },
            { typeof(EhtiyatHissəsiFormu), btnEhtiyatHisse },
            { typeof(EmekHaqqiFormu), btnEmekHaqqi },
            { typeof(TedarukcuOdemeFormu), btnTedarukcuOdeme },
            { typeof(AnbarFormu), btnAnbar },
            { typeof(QebzFormu), btnQebz },
            { typeof(TedarukcuIdareetmeFormu), btnTedarukcuIdareetme },
        };

        InitializeMainMenu();

        // Dashboard panelini hazırlayırıq
        InitializeDashboard();
    }

    private void InitializeMainMenu()
    {
        SuspendLayout();
        pnlMenu.Visible = false;
        _mainMenu.Name = "mainMenuStrip";
        _mainMenu.Dock = DockStyle.Top;
        _mainMenu.AutoSize = false;
        _mainMenu.Height = 44;
        _mainMenu.Padding = new Padding(12, 4, 12, 4);
        _mainMenu.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
        _mainMenu.BackColor = Color.FromArgb(247, 250, 247);
        _mainMenu.ForeColor = Color.FromArgb(31, 84, 43);
        _mainMenu.RenderMode = ToolStripRenderMode.Professional;

        _homeMenuItem.ForeColor = Color.FromArgb(31, 84, 43);
        _homeMenuItem.Padding = new Padding(10, 4, 10, 4);
        _homeMenuItem.Click += (_, _) => OpenDashboard();
        _mainMenu.Items.Add(_homeMenuItem);

        ToolStripMenuItem satis = AddMenuGroup("Satış");
        AddMenuAction(satis, "Yeni satış", btnYeniSatis, btnYeniSatis_Click);
        AddMenuAction(satis, "Qaytarma", btnQaytarma, btnQaytarma_Click);
        AddMenuAction(satis, "Nisyə və borclar", btnNisyeIdareetme, btnNisyeIdareetme_Click);
        _customerMenuItem.ForeColor = Color.FromArgb(31, 48, 36);
        _customerMenuItem.Padding = new Padding(8, 5, 8, 5);
        _customerMenuItem.Click += (_, _) => UsaqFormuAc<MusteriIdareetmeFormu>();
        satis.DropDownItems.Add(_customerMenuItem);
        AddMenuAction(satis, "Qəbzlər", btnQebz, btnQebz_Click);

        ToolStripMenuItem mehsullar = AddMenuGroup("Məhsullar və anbar");
        AddMenuAction(mehsullar, "Məhsul idarəetməsi", btnMehsulIdareetme, btnMehsulIdareetme_Click);
        AddMenuAction(mehsullar, "Anbar", btnAnbar, btnAnbar_Click);
        AddMenuAction(mehsullar, "Minimum stok", btnMinimumStokMehsullari, btnMinimumStokMehsullari_Click);
        AddMenuAction(mehsullar, "Barkod çapı", btnBarkodCapi, btnBarkodCapi_Click);
        AddMenuAction(mehsullar, "Ehtiyat hissələri", btnEhtiyatHisse, btnEhtiyatHisse_Click);

        ToolStripMenuItem alis = AddMenuGroup("Satınalma");
        AddMenuAction(alis, "Tədarükçülər", btnTedarukcuIdareetme, btnTedarukcuIdareetme_Click);
        AddMenuAction(alis, "Alış sifarişləri", btnAlisSifaris, btnAlisSifaris_Click);
        AddMenuAction(alis, "Alış sənədləri", btnAlisSened, btnAlisSened_Click);
        AddMenuAction(alis, "Tədarükçü ödənişləri", btnTedarukcuOdeme, btnTedarukcuOdeme_Click);

        ToolStripMenuItem maliyye = AddMenuGroup("Maliyyə");
        AddMenuAction(maliyye, "Növbə idarəetməsi", btnNovbeIdareetme, btnNovbeIdareetme_Click);
        AddMenuAction(maliyye, "Kassa", btnKassaIdareetme, btnKassaIdareetme_Click);
        AddMenuAction(maliyye, "Xərclər", btnXercIdareetme, btnXercIdareetme_Click);
        AddMenuAction(maliyye, "Əmək haqqı", btnEmekHaqqi, btnEmekHaqqi_Click);

        ToolStripMenuItem servis = AddMenuGroup("Servis");
        AddMenuAction(servis, "Təmir idarəetməsi", btnTemirIdareetme, btnTemirIdareetme_Click);
        AddMenuAction(servis, "İşçi idarəetməsi", btnIsciIdareetme, btnIsciIdareetme_Click);

        ToolStripMenuItem hesabat = AddMenuGroup("Hesabatlar");
        AddMenuAction(hesabat, "Ümumi hesabatlar", btnHesabatlar, btnHesabatlar_Click);
        AddMenuAction(hesabat, "Məhsul satış hesabatı", btnMehsulSatisHesabati, btnMehsulSatisHesabati_Click);
        AddMenuAction(hesabat, "Anbar qalıq hesabatı", btnAnbarQaliqHesabati, btnAnbarQaliqHesabati_Click);
        AddMenuAction(hesabat, "Z hesabat arxivi", btnZHesabatArxivi, btnZHesabatArxivi_Click);

        ToolStripMenuItem sistem = AddMenuGroup("Sistem");
        AddMenuAction(sistem, "İstifadəçi və icazələr", btnIstifadeciIdareetme, btnIstifadeciIdareetme_Click);
        AddMenuAction(sistem, "Konfiqurasiya", btnKonfiqurasiya, btnKonfiqurasiya_Click);

        _menuUserLabel.Alignment = ToolStripItemAlignment.Right;
        _menuUserLabel.ForeColor = Color.FromArgb(42, 62, 48);
        _menuUserLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        _mainMenu.Items.Add(_menuUserLabel);
        // Menyu və tablar eyni Dock sahəsini paylaşanda forma başlığı örtülürdü.
        // Ayrı sətirlər məzmunun həmişə menyunun altında başlamasını təmin edir.
        Controls.Remove(mdiTabControl);
        _workspaceLayout.Dock = DockStyle.Fill;
        _workspaceLayout.Margin = Padding.Empty;
        _workspaceLayout.Padding = Padding.Empty;
        _workspaceLayout.ColumnCount = 1;
        _workspaceLayout.RowCount = 2;
        _workspaceLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        _workspaceLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 44));
        _workspaceLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

        _tabHost.Dock = DockStyle.Fill;
        _tabHost.Margin = Padding.Empty;
        _tabHost.Controls.Add(mdiTabControl);
        _navigationCover.BackColor = Color.FromArgb(247, 250, 247);
        _navigationCover.Visible = false;
        _navigationCover.Enabled = false;
        _tabHost.Controls.Add(_navigationCover);
        _navigationTimer.Tick += NavigationTimer_Tick;

        _workspaceLayout.Controls.Add(_mainMenu, 0, 0);
        _workspaceLayout.Controls.Add(_tabHost, 0, 1);
        MainMenuStrip = _mainMenu;
        Controls.Add(_workspaceLayout);
        _workspaceLayout.BringToFront();
        ResumeLayout(true);
    }

    private void StartNavigationTransition()
    {
        if (_tabHost.ClientSize.Width <= 0 || mdiTabControl.SelectedTab == null) return;
        _navigationTimer.Stop();
        _navigationStarted = DateTime.UtcNow;
        _navigationCover.SetBounds(0, 0, _tabHost.ClientSize.Width, _tabHost.ClientSize.Height);
        _navigationCover.Visible = true;
        _navigationCover.BringToFront();
        _navigationTimer.Start();
    }

    private void NavigationTimer_Tick(object? sender, EventArgs e)
    {
        double progress = Math.Min(1, (DateTime.UtcNow - _navigationStarted).TotalMilliseconds / 180);
        if (progress >= 1 || IsDisposed)
        {
            _navigationTimer.Stop();
            _navigationCover.Visible = false;
            return;
        }

        // Qısa soldan sağa açılma effekti; forma daxilində animasiya gedir.
        int left = (int)Math.Round(_tabHost.ClientSize.Width * progress);
        _navigationCover.SetBounds(left, 0, Math.Max(0, _tabHost.ClientSize.Width - left), _tabHost.ClientSize.Height);
    }

    private ToolStripMenuItem AddMenuGroup(string title)
    {
        ToolStripMenuItem group = new(title)
        {
            ForeColor = Color.FromArgb(31, 84, 43),
            Padding = new Padding(10, 4, 10, 4)
        };
        _mainMenu.Items.Add(group);
        return group;
    }

    private void AddMenuAction(ToolStripMenuItem group, string title, MaterialButton legacyButton, EventHandler action)
    {
        ToolStripMenuItem item = new(title)
        {
            ForeColor = Color.FromArgb(31, 48, 36),
            Padding = new Padding(8, 5, 8, 5),
            Tag = legacyButton
        };
        item.Click += action;
        group.DropDownItems.Add(item);
        _menuItems.Add(legacyButton, item);
    }

    private void AnaMenuFormu_Load(object sender, EventArgs e)
    {
        IcazeleriYoxla();
        mdiTabControl.TabPages.Clear();
        CreateDashboardTab();
        UpdateActiveButtonHighlight();

        // Dashboard məlumatlarını yükləyirik
        _ = UpdateDashboardDataSafe();
    }

    private void AnaMenuFormu_Shown(object sender, EventArgs e)
    {
        // Form tam göstərildikdən sonra növbə yoxlamasını yeniləyirik
        // Bu, login zamanı növbənin yüklənməsini gözləyir
        IcazeleriYoxla();
    }

    private async Task SessiyaniYoxlaAsync()
    {
        _sessiyaTimer.Stop();
        try
        {
            int? istifadeciId = AktivSessiya.AktivIstifadeci?.Id;
            if (!istifadeciId.HasValue) return;
            await using AsyncServiceScope scope = ServiceProvider.CreateAsyncScope();
            TehlukesizlikManager manager = scope.ServiceProvider.GetRequiredService<TehlukesizlikManager>();
            if (!await manager.SessiyaKecerlidirasAsync(istifadeciId.Value))
            {
                MessageBox.Show("Sessiyanın müddəti bitdi. Yenidən daxil olun.", "Sessiya bitdi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
                return;
            }
            if (_girisFiltiri.SonGiris > _sonSessiyaYenilemesi)
            {
                await manager.SessiyaAktivliyiniYenileAsync(istifadeciId.Value);
                _sonSessiyaYenilemesi = DateTime.Now;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Sessiya yoxlaması: {ex}");
        }
        finally
        {
            if (!IsDisposed) _sessiyaTimer.Start();
        }
    }

    private sealed class SessiyaGirisFiltiri : IMessageFilter
    {
        public DateTime SonGiris { get; private set; } = DateTime.Now;
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg is >= 0x0100 and <= 0x0109 or >= 0x0200 and <= 0x020E)
                SonGiris = DateTime.Now;
            return false;
        }
    }

    #region Tab İdarəetməsi

    private void CreateDashboardTab()
    {
        var surface = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(247, 250, 247) };
        var heading = new Label
        {
            Dock = DockStyle.Top,
            Height = 100,
            Padding = new Padding(24, 22, 16, 0),
            Font = new Font("Segoe UI", 21F, FontStyle.Bold),
            ForeColor = Color.FromArgb(31, 84, 43),
            Text = "Ana səhifə\nMağazanın cari göstəriciləri"
        };
        var cards = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            AutoScroll = true,
            WrapContents = true,
            Padding = new Padding(18, 12, 18, 18),
            BackColor = surface.BackColor
        };
        foreach (var (card, title, value) in new[]
        {
            (dailySalesCard, lblDailySales, lblDailySalesValue),
            (activeShiftCard, lblActiveShift, lblActiveShiftValue),
            (monthlySalesCard, lblMonthlySales, lblMonthlySalesValue),
            (totalDebtCard, lblTotalDebt, lblTotalDebtValue),
            (debtorCustomersCard, lblDebtorCustomers, lblDebtorCustomersValue),
            (lowStockProductsCard, lblLowStockProducts, lblLowStockProductsValue)
        })
        {
            dashboardPanel.Controls.Remove(card);
            card.Margin = new Padding(7);
            card.Height = 112;
            title.AutoSize = false;
            title.SetBounds(16, 13, 220, 25);
            title.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            value.AutoSize = false;
            value.SetBounds(16, 47, 220, 54);
            value.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            cards.Controls.Add(card);
        }
        cards.Resize += (_, _) =>
        {
            int columns = cards.ClientSize.Width >= 900 ? 3 : cards.ClientSize.Width >= 600 ? 2 : 1;
            int width = Math.Max(220, (cards.ClientSize.Width - cards.Padding.Horizontal - columns * 14 - 18) / columns);
            foreach (Control card in cards.Controls)
            {
                card.Width = width;
                foreach (Control label in card.Controls)
                    label.Width = width - 32;
            }
        };
        surface.Controls.Add(cards);
        surface.Controls.Add(heading);
        _dashboardTab = new TabPage("Ana səhifə") { Padding = Padding.Empty };
        _dashboardTab.Controls.Add(surface);
        mdiTabControl.TabPages.Add(_dashboardTab);
        mdiTabControl.SelectedTab = _dashboardTab;
    }

    private void OpenDashboard()
    {
        if (_dashboardTab != null && mdiTabControl.TabPages.Contains(_dashboardTab))
            mdiTabControl.SelectedTab = _dashboardTab;
    }

    public void UsaqFormuAc<T>() where T : Form
    {
        TabPage? mövcudSehife = mdiTabControl.TabPages.OfType<TabPage>().FirstOrDefault(p => p.Tag is T);

        if (mövcudSehife != null)
        {
            mdiTabControl.SelectedTab = mövcudSehife;
        }
        else
        {
            // Hər form üçün yeni scope yaradırıq
            AsyncServiceScope scope = ServiceProvider.CreateAsyncScope();
            T yeniForm = scope.ServiceProvider.GetRequiredService<T>();
            yeniForm.TopLevel = false;
            yeniForm.FormBorderStyle = FormBorderStyle.None;
            yeniForm.Dock = DockStyle.Fill;

            // Initialize presenter for forms that need it
            InitializeFormPresenter(yeniForm, scope.ServiceProvider);

            TabPage yeniSehife = new(yeniForm.Text) { Tag = yeniForm, Padding = Padding.Empty };
            yeniSehife.Controls.Add(yeniForm);
            mdiTabControl.TabPages.Add(yeniSehife);
            mdiTabControl.SelectedTab = yeniSehife;

            // Scope-u saxlayırıq
            _tabScopes[yeniSehife] = scope;

            yeniForm.Show();
            // MaterialSkin formaları ilk dəfə tabda göstəriləndə köhnə ölçüdə qala bilir.
            BeginInvoke(() =>
            {
                if (yeniForm.IsDisposed || yeniSehife.IsDisposed) return;
                yeniForm.Bounds = yeniSehife.ClientRectangle;
                yeniSehife.PerformLayout();
                yeniForm.PerformLayout();
            });
        }
    }

    private void InitializeFormPresenter(Form form, IServiceProvider serviceProvider)
    {
        // Initialize presenter for SatisFormu
        if (form is SatisFormu satisFormu)
        {
            SatisManager satisManager = serviceProvider.GetRequiredService<SatisManager>();
            MehsulManager mehsulManager = serviceProvider.GetRequiredService<MehsulManager>();
            MusteriManager musteriManager = serviceProvider.GetRequiredService<MusteriManager>();
            KonfiqurasiyaManager konfiqurasiyaManager = serviceProvider.GetRequiredService<KonfiqurasiyaManager>();
            SatisPresenter satisPresenter = new(satisFormu, satisManager, mehsulManager, musteriManager, konfiqurasiyaManager);
            satisFormu.InitializePresenter(satisPresenter);
        }
        else if (form is MusteriIdareetmeFormu musteriFormu)
        {
            MusteriManager musteriManager = serviceProvider.GetRequiredService<MusteriManager>();
            musteriFormu.InitializePresenter(new MusteriPresenter(musteriFormu, musteriManager));
        }
        // Initialize presenter for TemirIdareetmeFormu
        else if (form is TemirIdareetmeFormu temirFormu)
        {
            TemirManager temirManager = serviceProvider.GetRequiredService<TemirManager>();
            MusteriManager musteriManager = serviceProvider.GetRequiredService<MusteriManager>();
            IstifadeciManager istifadeciManager = serviceProvider.GetRequiredService<IstifadeciManager>();
            MehsulManager mehsulManager = serviceProvider.GetRequiredService<MehsulManager>();
            DialogXidmeti dialogXidmeti = new();
            TemirPresenter temirPresenter = new(temirFormu, temirManager, musteriManager, istifadeciManager, mehsulManager, dialogXidmeti);
            temirFormu.InitializePresenter(temirPresenter);
        }
        // Initialize presenter for QaytarmaFormu
        else if (form is QaytarmaFormu qaytarmaFormu)
        {
            QaytarmaManager qaytarmaManager = serviceProvider.GetRequiredService<QaytarmaManager>();
            SatisManager satisManager = serviceProvider.GetRequiredService<SatisManager>();
            MehsulManager mehsulManager = serviceProvider.GetRequiredService<MehsulManager>();
            MaliyyeManager maliyyeManager = serviceProvider.GetRequiredService<MaliyyeManager>();
            QaytarmaPresenter qaytarmaPresenter = new(qaytarmaFormu, qaytarmaManager, satisManager, mehsulManager, maliyyeManager);
            qaytarmaFormu.InitializePresenter(qaytarmaPresenter);
        }
        // Initialize presenter for XercIdareetmeFormu
        else if (form is XercIdareetmeFormu xercFormu)
        {
            MaliyyeManager maliyyeManager = serviceProvider.GetRequiredService<MaliyyeManager>();
            XercPresenter xercPresenter = new(xercFormu, maliyyeManager);
            xercFormu.InitializePresenter(xercPresenter);
        }
    }

    private void mdiTabControl_MouseClick(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Right)
        {
            for (int i = 0; i < mdiTabControl.TabCount; i++)
            {
                if (mdiTabControl.GetTabRect(i).Contains(e.Location))
                {
                    mdiTabControl.SelectedIndex = i;
                    tabContextMenu.Show(mdiTabControl, e.Location);
                    break;
                }
            }
        }
    }

    private async void baglaToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (mdiTabControl.SelectedTab != null)
        {
            await CloseTabAsync(mdiTabControl.SelectedTab);
        }
    }

    private async void hamisiniBaglaToolStripMenuItem_Click(object sender, EventArgs e)
    {
        while (mdiTabControl.TabPages.Cast<TabPage>().Any(t => t != _dashboardTab))
        {
            await CloseTabAsync(mdiTabControl.TabPages.Cast<TabPage>().First(t => t != _dashboardTab));
        }
        OpenDashboard();
    }

    private async Task CloseTabAsync(TabPage tab)
    {
        if (tab == _dashboardTab) return;
        if (tab.Controls.Count > 0 && tab.Controls[0] is Form form)
        {
            form.Close();
        }
        mdiTabControl.TabPages.Remove(tab);
        if (_tabScopes.Remove(tab, out AsyncServiceScope scope))
        {
            await scope.DisposeAsync();
        }
        tab.Dispose();
    }

    private void mdiTabControl_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateActiveButtonHighlight();
        StartNavigationTransition();
    }
    #endregion

    #region UI Təkmilləşdirmələri
    private void UpdateActiveButtonHighlight()
    {
        _homeMenuItem.Checked = mdiTabControl.SelectedTab == _dashboardTab;
        foreach (ToolStripMenuItem item in _menuItems.Values)
            item.Checked = false;
        _customerMenuItem.Checked = mdiTabControl.SelectedTab?.Tag is MusteriIdareetmeFormu;

        if (mdiTabControl.SelectedTab?.Tag is Form aktivForm &&
            _formButtonMap.TryGetValue(aktivForm.GetType(), out MaterialButton? button) &&
            _menuItems.TryGetValue(button, out ToolStripMenuItem? activeItem))
            activeItem.Checked = true;
    }

    private Image CreateInitialsAvatar(string fullName, Color backColor)
    {
        string initials = string.Concat(fullName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s[0])).ToUpper();
        if (initials.Length > 2)
        {
            initials = initials[..2];
        }

        Bitmap bmp = new(50, 50);
        using (Graphics g = Graphics.FromImage(bmp))
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (SolidBrush brush = new(backColor))
            {
                g.FillEllipse(brush, 0, 0, 50, 50);
            }

            using Font font = new("Segoe UI", 14, FontStyle.Bold);
            SizeF textSize = g.MeasureString(initials, font);
            PointF textPoint = new((50 - textSize.Width) / 2, (50 - textSize.Height) / 2);
            g.DrawString(initials, font, Brushes.White, textPoint);
        }
        return bmp;
    }
    #endregion

    #region Dashboard Methods

    /// <summary>
    /// Dashboard panelini və təkmilləşmiş məlumat yeniləmə funksiyasını başlatır
    /// </summary>
    private void InitializeDashboard()
    {
        // Timeri konfiqurasiya edirik
        if (dashboardTimer == null)
        {
            dashboardTimer = new System.Windows.Forms.Timer();
        }
        else
        {
            dashboardTimer.Stop();
            dashboardTimer.Tick -= DashboardTimer_Tick;
        }

        dashboardTimer.Interval = 300000; // 5 dəqiqə
        dashboardTimer.Tick += DashboardTimer_Tick;
        dashboardTimer.Start();

        // İlk dəfə məlumatları yükləyirik
        _ = UpdateDashboardDataSafe();
    }

    private void DashboardTimer_Tick(object? sender, EventArgs e)
    {
        _ = UpdateDashboardDataSafe();
    }

    private async Task UpdateDashboardDataSafe()
    {
        if (!await _dashboardKilidi.WaitAsync(0)) return;
        try
        {
            await UpdateDashboardData();
        }
        catch (Exception ex)
        {
            // Xətanı log edirik və ya istifadəçiyə bildiririk
            System.Diagnostics.Debug.WriteLine($"Dashboard yenilənərkən xəta: {ex.Message}");
            // Kritik xətalarda istifadəçiyə də məlumat verə bilərik
            MessageBox.Show($"Dashboard yenilənərkən xəta: {ex.Message}", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        finally
        {
            _dashboardKilidi.Release();
        }
    }

    private async Task UpdateDashboardData()
    {
        await using AsyncServiceScope scope = ServiceProvider.CreateAsyncScope();
        IServiceProvider provider = scope.ServiceProvider;
        try
        {
            // Günlük satış məbləğini hesablayırıq
            HesabatManager hesabatManager = provider.GetRequiredService<HesabatManager>();
            EmeliyyatNeticesi<GunlukSatisHesabatDto> gunlukHesabat = await hesabatManager.GunlukSatisHesabatiGetirAsync(DateTime.Today);
            if (gunlukHesabat.UgurluDur && lblDailySalesValue != null)
            {
                lblDailySalesValue.Text = $"{gunlukHesabat.Data.UmumiDovriyye:N2} AZN";
            }
            else if (lblDailySalesValue != null)
            {
                lblDailySalesValue.Text = "Xəta";
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
            if (lblDailySalesValue != null)
            {
                lblDailySalesValue.Text = "Xəta";
            }
        }

        // Aktiv növbə məlumatlarını göstəririk
        try
        {
            if (lblActiveShiftValue != null)
            {
                if (AktivSessiya.AktivNovbeId.HasValue)
                {
                    NovbeManager novbeManager = provider.GetRequiredService<NovbeManager>();
                    Novbe? novbe = await novbeManager.NovbeGetirAsync(AktivSessiya.AktivNovbeId.Value);
                    lblActiveShiftValue.Text = novbe != null ? $"{AktivSessiya.AktivIstifadeci?.TamAd}\n{novbe.AcilmaTarixi:HH:mm}" : "Məlumat tapılmadı";
                }
                else
                {
                    lblActiveShiftValue.Text = "Növbə Yoxdur";
                }
            }
        }
        catch
        {
            if (lblActiveShiftValue != null)
            {
                lblActiveShiftValue.Text = "Xəta";
            }
        }

        // Borclu müştəri sayını və ümumi borcu hesablayırıq
        try
        {
            MusteriManager musteriManager = provider.GetRequiredService<MusteriManager>();
            EmeliyyatNeticesi<List<MusteriDto>> musteriler = await musteriManager.ButunMusterileriGetirAsync();

            if (lblDebtorCustomersValue != null)
            {
                if (musteriler.UgurluDur && musteriler.Data != null)
                {
                    int borcluMusteriSayi = musteriler.Data.Count(m => m.UmumiBorc > 0);
                    lblDebtorCustomersValue.Text = borcluMusteriSayi.ToString();
                }
                else
                {
                    lblDebtorCustomersValue.Text = "Xəta";
                }
            }

            // Ümumi borc məbləğini hesablayırıq
            if (lblTotalDebtValue != null)
            {
                if (musteriler.UgurluDur && musteriler.Data != null)
                {
                    decimal umumiBorc = musteriler.Data.Sum(m => m.UmumiBorc);
                    lblTotalDebtValue.Text = $"{umumiBorc:N2} AZN";
                }
                else
                {
                    lblTotalDebtValue.Text = "Xəta";
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
            if (lblDebtorCustomersValue != null)
            {
                lblDebtorCustomersValue.Text = "Xəta";
            }

            if (lblTotalDebtValue != null)
            {
                lblTotalDebtValue.Text = "Xəta";
            }
        }

        // Aşağı stoklu məhsulların sayını hesablayırıq
        try
        {
            if (lblLowStockProductsValue != null)
            {
                MehsulMeneceri mehsulMeneceri = provider.GetRequiredService<MehsulMeneceri>();
                EmeliyyatNeticesi<List<MehsulDto>> minimumStokMehsullari = await mehsulMeneceri.MinimumStokMehsullariniGetirAsync();
                lblLowStockProductsValue.Text = minimumStokMehsullari.UgurluDur ? minimumStokMehsullari.Data.Count.ToString() : "0";
            }
        }
        catch
        {
            if (lblLowStockProductsValue != null)
            {
                lblLowStockProductsValue.Text = "0";
            }
        }

        try
        {
            decimal ayliqSatis = await provider.GetRequiredService<HesabatManager>().AyligSatisCemiGetirAsync(DateTime.Today);
            if (lblMonthlySalesValue != null) lblMonthlySalesValue.Text = $"{ayliqSatis:N2} AZN";
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
            if (lblMonthlySalesValue != null) lblMonthlySalesValue.Text = "Xəta";
        }

        try
        {
            EmeliyyatNeticesi<List<TemirDto>> temirler = await provider.GetRequiredService<TemirManager>().ButunSifarisleriGetirAsync();
            if (lblActiveRepairsValue != null)
                lblActiveRepairsValue.Text = temirler.UgurluDur
                    ? temirler.Data.Count(t => t.Status == TemirStatusu.Gözləmədə || t.Status == TemirStatusu.Təmirdə).ToString()
                    : "Xəta";
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
            if (lblActiveRepairsValue != null) lblActiveRepairsValue.Text = "Xəta";
        }

        try
        {
            AlisManager alisManager = provider.GetRequiredService<AlisManager>();
            EmeliyyatNeticesi<List<AlisSenedDto>> senedler = await alisManager.ButunAlisSenetleriniGetirAsync();
            EmeliyyatNeticesi<List<TedarukcuOdemeDto>> odenisler = await alisManager.ButunTedarukcuOdemeleriniGetirAsync();
            if (lblSupplierDebtValue != null)
                lblSupplierDebtValue.Text = senedler.UgurluDur && odenisler.UgurluDur
                    ? $"{Math.Max(0, senedler.Data.Where(s => s.Status == AlisSenedStatusu.Tesdiqlendi).Sum(s => s.UmumiMebleg) - odenisler.Data.Where(o => o.Status == OdemeStatusu.Tesdiqlendi).Sum(o => o.Mebleg)):N2} AZN"
                    : "Xəta";
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex);
            if (lblSupplierDebtValue != null) lblSupplierDebtValue.Text = "Xəta";
        }
    }

    #endregion

    // IAnaMenuView interface implementasiyası
    public void IcazeleriYoxla()
    {
        IstifadeciDto? istifadeci = AktivSessiya.AktivIstifadeci;
        if (istifadeci == null)
        {
            MessageBox.Show("Aktiv istifadəçi sessiyası tapılmadı.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            Application.Exit();
            return;
        }

        Text = $"AzAgroPOS - (İstifadəçi: {istifadeci.TamAd})";
        lblUserName.Text = istifadeci.TamAd;
        _menuUserLabel.Text = $"{istifadeci.TamAd}  |  {istifadeci.RolAdi}";

        foreach (MaterialButton button in _menuItems.Keys)
            button.Enabled = true;

        Color panelColor;
        if (istifadeci.RolAdi == "Admin")
        {
            panelColor = Color.FromArgb(192, 57, 43); // Tünd qırmızı
        }
        else if (istifadeci.RolAdi == "Kassir")
        {
            panelColor = Color.FromArgb(243, 156, 18); // Narıncı/Sarı
            btnIstifadeciIdareetme.Enabled = false;
        }
        else
        {
            panelColor = Color.FromArgb(44, 62, 80); // Neytral
            foreach (Control c in pnlMenu.Controls)
            {
                if (c is MaterialButton button)
                {
                    button.Enabled = false;
                }
            }
        }

        pnlUserInfo.BackColor = panelColor;
        picUserIcon.Image = CreateInitialsAvatar(istifadeci.TamAd, panelColor);

        btnYeniSatis.Enabled = AktivSessiya.AktivNovbeId.HasValue;
        btnKonfiqurasiya.Enabled = istifadeci.RolAdi == "Admin";
        _customerMenuItem.Enabled = istifadeci.RolAdi is "Admin" or "Kassir";
        foreach ((MaterialButton button, ToolStripMenuItem item) in _menuItems)
            item.Enabled = button.Enabled;
    }

    public void MesajGoster(string mesaj, string basliq, MessageBoxButtons düymələr, MessageBoxIcon ikon)
    {
        MessageBox.Show(mesaj, basliq, düymələr, ikon);
    }

    #region Button Click Events

    // Operational Functions
    private void btnNovbeIdareetme_Click(object sender, EventArgs e)
    {
        using (NovbeIdareetmesiFormu form = ServiceProvider.GetRequiredService<NovbeIdareetmesiFormu>())
        {
            form.ShowDialog();
        }
        IcazeleriYoxla();
    }

    private void btnYeniSatis_Click(object sender, EventArgs e)
    {
        // Növbə açılmayıbsa istifadəçiyə növbə açmaq təklif edirik
        if (!AktivSessiya.AktivNovbeId.HasValue)
        {
            DialogResult netice = MessageBox.Show(
                "Satış əməliyyatı üçün növbə açılmalıdır.\n\nİndi növbə açmaq istəyirsiniz?",
                "Növbə Tələb Olunur",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (netice == DialogResult.Yes)
            {
                // Növbə idarəetməsi formasını açırıq
                using (NovbeIdareetmesiFormu form = ServiceProvider.GetRequiredService<NovbeIdareetmesiFormu>())
                {
                    form.ShowDialog();
                }
                IcazeleriYoxla(); // İcazələri yeniləyirik

                // Növbə açılıbsa satış formasını açırıq
                if (AktivSessiya.AktivNovbeId.HasValue)
                {
                    UsaqFormuAc<SatisFormu>();
                }
            }
        }
        else
        {
            UsaqFormuAc<SatisFormu>();
        }
    }

    private void btnQaytarma_Click(object sender, EventArgs e)
    {
        UsaqFormuAc<QaytarmaFormu>();
    }

    private void btnNisyeIdareetme_Click(object sender, EventArgs e)
    {
        UsaqFormuAc<NisyeIdareetmeFormu>();
    }

    // Product Management
    private void btnMehsulIdareetme_Click(object sender, EventArgs e)
    {
        UsaqFormuAc<MehsulIdareetmeFormu>();
    }

    private void btnMinimumStokMehsullari_Click(object sender, EventArgs e)
    {
        UsaqFormuAc<MinimumStokMehsullariFormu>();
    }

    private void btnBarkodCapi_Click(object sender, EventArgs e)
    {
        UsaqFormuAc<BarkodCapiFormu>();
    }

    // Financial Management
    private void btnXercIdareetme_Click(object sender, EventArgs e)
    {
        UsaqFormuAc<XercIdareetmeFormu>();
    }

    private void btnTemirIdareetme_Click(object sender, EventArgs e)
    {
        UsaqFormuAc<TemirIdareetmeFormu>();
    }

    private void btnAlisSened_Click(object sender, EventArgs e)
    {
        UsaqFormuAc<AlisSenedFormu>();
    }

    private void btnAlisSifaris_Click(object sender, EventArgs e)
    {
        UsaqFormuAc<AlisSifarisFormu>();
    }

    private void btnKassaIdareetme_Click(object sender, EventArgs e)
    {
        UsaqFormuAc<KassaFormu>();
    }

    private void btnQebz_Click(object sender, EventArgs e)
    {
        UsaqFormuAc<QebzFormu>();
    }

    private void btnTedarukcuOdeme_Click(object sender, EventArgs e)
    {
        UsaqFormuAc<TedarukcuOdemeFormu>();
    }

    private void btnTedarukcuIdareetme_Click(object sender, EventArgs e)
    {
        UsaqFormuAc<TedarukcuIdareetmeFormu>();
    }

    private void btnEhtiyatHisse_Click(object sender, EventArgs e)
    {
        UsaqFormuAc<EhtiyatHissəsiFormu>();
    }

    private void btnEmekHaqqi_Click(object sender, EventArgs e)
    {
        UsaqFormuAc<EmekHaqqiFormu>();
    }

    // Inventory & Storage
    private void btnAnbar_Click(object sender, EventArgs e)
    {
        UsaqFormuAc<AnbarFormu>();
    }

    // Staff & User Management
    private void btnIstifadeciIdareetme_Click(object sender, EventArgs e)
    {
        UsaqFormuAc<IstifadeciIdareetmeFormu>();
    }

    private void btnIsciIdareetme_Click(object sender, EventArgs e)
    {
        UsaqFormuAc<IsciIdareetmeFormu>();
    }

    // Reports
    private void btnHesabatlar_Click(object sender, EventArgs e)
    {
        UsaqFormuAc<HesabatFormu>();
    }

    private void btnMehsulSatisHesabati_Click(object sender, EventArgs e)
    {
        UsaqFormuAc<MehsulSatisHesabatFormu>();
    }

    private void btnAnbarQaliqHesabati_Click(object sender, EventArgs e)
    {
        UsaqFormuAc<AnbarQaliqHesabatFormu>();
    }

    private void btnZHesabatArxivi_Click(object sender, EventArgs e)
    {
        UsaqFormuAc<ZHesabatArxivFormu>();
    }

    // System Configuration
    private void btnKonfiqurasiya_Click(object sender, EventArgs e)
    {
        UsaqFormuAc<KonfiqurasiyaFormu>();
    }

    #endregion

    #region Form Events

    private void AnaMenuFormu_FormClosing(object sender, FormClosingEventArgs e)
    {
        // Tətbiqi düzgün şəkildə bağlayırıq
        Application.Exit();
    }

    private void lblActiveShiftValue_Click(object sender, EventArgs e)
    {
        // Aktiv növbəyə aid əlavə funksionallıq burada tətbiq edilə bilər
    }

    #endregion


}
