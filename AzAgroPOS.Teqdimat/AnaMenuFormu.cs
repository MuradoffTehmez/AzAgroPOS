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
    private readonly Dictionary<TabPage, IServiceScope> _tabScopes = new();

    // IAnaMenuView interface implementasiyası
    public IServiceProvider ServiceProvider { get; }

    // Hadisələr
    public event EventHandler FormYuklendi;
    public event EventHandler<FormClosingEventArgs> FormBaglaniyor;

    public AnaMenuFormu(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        ServiceProvider = serviceProvider;

        Load += (sender, e) => FormYuklendi?.Invoke(this, EventArgs.Empty);
        Shown += AnaMenuFormu_Shown;
        FormClosing += (sender, e) => FormBaglaniyor?.Invoke(this, e);

        // Modern dizayn tətbiq edirik
        AnaMenuFormModernStyle.ApplyModernStyle(pnlMenu);
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

        // Dashboard panelini hazırlayırıq
        InitializeDashboard();
    }

    private void AnaMenuFormu_Load(object sender, EventArgs e)
    {
        IcazeleriYoxla();
        mdiTabControl.TabPages.Clear();
        UpdateActiveButtonHighlight();

        // Dashboard məlumatlarını yükləyirik
        _ = UpdateDashboardData(); // Fire and forget
    }

    private void AnaMenuFormu_Shown(object sender, EventArgs e)
    {
        // Form tam göstərildikdən sonra növbə yoxlamasını yeniləyirik
        // Bu, login zamanı növbənin yüklənməsini gözləyir
        IcazeleriYoxla();
    }

    #region Tab İdarəetməsi

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
            IServiceScope scope = ServiceProvider.CreateScope();
            T yeniForm = scope.ServiceProvider.GetRequiredService<T>();
            yeniForm.TopLevel = false;
            yeniForm.FormBorderStyle = FormBorderStyle.None;
            yeniForm.Dock = DockStyle.Fill;

            // Initialize presenter for forms that need it
            InitializeFormPresenter(yeniForm, scope.ServiceProvider);

            TabPage yeniSehife = new(yeniForm.Text) { Tag = yeniForm };
            yeniSehife.Controls.Add(yeniForm);
            mdiTabControl.TabPages.Add(yeniSehife);
            mdiTabControl.SelectedTab = yeniSehife;

            // Scope-u saxlayırıq
            _tabScopes[yeniSehife] = scope;

            // Tab bağlananda scope-u dispose edirik
            mdiTabControl.Deselecting += (s, e) =>
            {
                if (e.TabPage != null && _tabScopes.ContainsKey(e.TabPage) && e.Action == TabControlAction.Deselected)
                {
                    // Burada dispose etmirik, yalnız tab remove olunanda edəcəyik
                }
            };

            yeniForm.Show();
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
            SatisPresenter satisPresenter = new(satisFormu, satisManager, mehsulManager, musteriManager);
            satisFormu.InitializePresenter(satisPresenter);
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

    private void baglaToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (mdiTabControl.SelectedTab != null)
        {
            CloseTab(mdiTabControl.SelectedTab);
        }
    }

    private void hamisiniBaglaToolStripMenuItem_Click(object sender, EventArgs e)
    {
        while (mdiTabControl.TabPages.Count > 0)
        {
            CloseTab(mdiTabControl.TabPages[0]);
        }
    }

    private void CloseTab(TabPage tab)
    {
        if (tab.Controls.Count > 0 && tab.Controls[0] is Form form)
        {
            form.Close();
        }
        mdiTabControl.TabPages.Remove(tab);
    }

    private void mdiTabControl_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateActiveButtonHighlight();
    }
    #endregion

    #region UI Təkmilləşdirmələri
    private void UpdateActiveButtonHighlight()
    {
        // Bütün düymələri normal vəziyyətə qaytır
        foreach (MaterialButton btn in _formButtonMap.Values)
        {
            AnaMenuFormModernStyle.ResetButton(btn);
        }

        // Aktiv düyməni vurğula
        if (mdiTabControl.SelectedTab?.Tag is Form aktivForm)
        {
            Type formTipi = aktivForm.GetType();
            if (_formButtonMap.ContainsKey(formTipi))
            {
                MaterialButton aktivButton = _formButtonMap[formTipi];
                AnaMenuFormModernStyle.HighlightActiveButton(aktivButton);
            }
        }
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
            dashboardTimer = new Timer();
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
    }

    private async Task UpdateDashboardData()
    {
        try
        {
            // Günlük satış məbləğini hesablayırıq
            HesabatManager hesabatManager = ServiceProvider.GetRequiredService<HesabatManager>();
            EmeliyyatNeticesi<GunlukSatisHesabatDto> gunlukHesabat = await hesabatManager.GunlukSatisHesabatiGetirAsync(DateTime.Today);
            if (gunlukHesabat.UgurluDur && lblDailySalesValue != null)
            {
                lblDailySalesValue.Text = $"{gunlukHesabat.Data.UmumiDovriyye:N2} AZN";
            }
            else if (lblDailySalesValue != null)
            {
                lblDailySalesValue.Text = "0.00 AZN";
            }
        }
        catch
        {
            if (lblDailySalesValue != null)
            {
                lblDailySalesValue.Text = "0.00 AZN";
            }
        }

        // Aktiv növbə məlumatlarını göstəririk
        try
        {
            if (lblActiveShiftValue != null)
            {
                if (AktivSessiya.AktivNovbeId.HasValue)
                {
                    NovbeManager novbeManager = ServiceProvider.GetRequiredService<NovbeManager>();
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
            MusteriManager musteriManager = ServiceProvider.GetRequiredService<MusteriManager>();
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
                    lblDebtorCustomersValue.Text = "0";
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
                    lblTotalDebtValue.Text = "0.00 AZN";
                }
            }
        }
        catch
        {
            if (lblDebtorCustomersValue != null)
            {
                lblDebtorCustomersValue.Text = "0";
            }

            if (lblTotalDebtValue != null)
            {
                lblTotalDebtValue.Text = "0.00 AZN";
            }
        }

        // Aşağı stoklu məhsulların sayını hesablayırıq
        try
        {
            if (lblLowStockProductsValue != null)
            {
                MehsulMeneceri mehsulMeneceri = ServiceProvider.GetRequiredService<MehsulMeneceri>();
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

        // Aylıq satış məbləğini hesablayırıq (placeholder)
        if (lblMonthlySalesValue != null)
        {
            lblMonthlySalesValue.Text = "N/A";
        }

        // Aktiv təmir sayını hesablayırıq (placeholder)
        if (lblActiveRepairsValue != null)
        {
            lblActiveRepairsValue.Text = "N/A";
        }

        // Tədarükçü borcu (placeholder)
        if (lblSupplierDebtValue != null)
        {
            lblSupplierDebtValue.Text = "N/A";
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
