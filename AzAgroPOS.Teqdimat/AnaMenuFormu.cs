// Fayl: AzAgroPOS.Teqdimat/AnaMenuFormu.cs
namespace AzAgroPOS.Teqdimat;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Yardimcilar;
using MaterialSkin.Controls;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

public partial class AnaMenuFormu : BazaForm
{
    private readonly IServiceProvider _serviceProvider;
    private readonly Dictionary<Type, MaterialButton> _formButtonMap;

    public AnaMenuFormu(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _serviceProvider = serviceProvider;

        this.Load += AnaMenuFormu_Load;

        _formButtonMap = new Dictionary<Type, MaterialButton>
        {
            { typeof(MehsulIdareetmeFormu), btnMehsulIdareetme },
            { typeof(SatisFormu), btnYeniSatis },
            { typeof(QaytarmaFormu), btnQaytarma },
            { typeof(NisyeIdareetmeFormu), btnNisyeIdareetme },
            { typeof(TemirIdareetmeFormu), btnTemirIdareetme },
            { typeof(IstifadeciIdareetmeFormu), btnIstifadeciIdareetme },
            { typeof(HesabatFormu), btnHesabatlar },
            { typeof(MehsulSatisHesabatFormu), btnMehsulSatisHesabati },
            { typeof(AnbarQaliqHesabatFormu), btnAnbarQaliqHesabati },
            { typeof(ZHesabatArxivFormu), btnZHesabatArxivi },
            { typeof(BarkodCapiFormu), btnBarkodCapi },
            { typeof(IsciIdareetmeFormu), btnIsciIdareetme },
            { typeof(MinimumStokMehsullariFormu), btnMinimumStokMehsullari }, // Əlavə edildi
            { typeof(KonfiqurasiyaFormu), btnKonfiqurasiya } // Əlavə edildi
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

    #region Tab İdarəetməsi

    private void UsaqFormuAc<T>() where T : Form
    {
        var mövcudSehife = mdiTabControl.TabPages.OfType<TabPage>().FirstOrDefault(p => p.Tag is T);

        if (mövcudSehife != null)
        {
            mdiTabControl.SelectedTab = mövcudSehife;
        }
        else
        {
            // Formanı 'new' ilə deyil, Service Provider ilə yaradırıq
            var yeniForm = _serviceProvider.GetRequiredService<T>();
            yeniForm.TopLevel = false;
            yeniForm.FormBorderStyle = FormBorderStyle.None;
            yeniForm.Dock = DockStyle.Fill;

            var yeniSehife = new TabPage(yeniForm.Text) { Tag = yeniForm };
            yeniSehife.Controls.Add(yeniForm);
            mdiTabControl.TabPages.Add(yeniSehife);
            mdiTabControl.SelectedTab = yeniSehife;
            yeniForm.Show();
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
        foreach (var btn in _formButtonMap.Values)
        {
            btn.HighEmphasis = false;
            btn.Type = MaterialButton.MaterialButtonType.Text;
        }

        if (mdiTabControl.SelectedTab?.Tag is Form aktivForm)
        {
            var formTipi = aktivForm.GetType();
            if (_formButtonMap.ContainsKey(formTipi))
            {
                var aktivButton = _formButtonMap[formTipi];
                aktivButton.HighEmphasis = true;
                aktivButton.Type = MaterialButton.MaterialButtonType.Contained;
            }
        }
    }

    private Image CreateInitialsAvatar(string fullName, Color backColor)
    {
        var initials = string.Concat(fullName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s[0])).ToUpper();
        if (initials.Length > 2)
        {
            initials = initials.Substring(0, 2);
        }

        var bmp = new Bitmap(50, 50);
        using (var g = Graphics.FromImage(bmp))
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var brush = new SolidBrush(backColor))
            {
                g.FillEllipse(brush, 0, 0, 50, 50);
            }

            using (var font = new Font("Segoe UI", 14, FontStyle.Bold))
            {
                var textSize = g.MeasureString(initials, font);
                var textPoint = new PointF((50 - textSize.Width) / 2, (50 - textSize.Height) / 2);
                g.DrawString(initials, font, Brushes.White, textPoint);
            }
        }
        return bmp;
    }
    #endregion

    #region Dashboard Methods

    private void InitializeDashboard()
    {
        // Dashboard panelinə kartları əlavə edirik
        dashboardPanel.Controls.Add(dailySalesCard);
        dashboardPanel.Controls.Add(activeShiftCard);
        dashboardPanel.Controls.Add(debtorCustomersCard);
        dashboardPanel.Controls.Add(lowStockProductsCard);

        // Kartlara etiketləri əlavə edirik
        dailySalesCard.Controls.Add(lblDailySales);
        dailySalesCard.Controls.Add(lblDailySalesValue);

        activeShiftCard.Controls.Add(lblActiveShift);
        activeShiftCard.Controls.Add(lblActiveShiftValue);

        debtorCustomersCard.Controls.Add(lblDebtorCustomers);
        debtorCustomersCard.Controls.Add(lblDebtorCustomersValue);

        lowStockProductsCard.Controls.Add(lblLowStockProducts);
        lowStockProductsCard.Controls.Add(lblLowStockProductsValue);

        // Timeri konfiqurasiya edirik
        dashboardTimer = new Timer();
        dashboardTimer.Interval = 300000; // 5 dəqiqə
        dashboardTimer.Tick += async (s, e) => await UpdateDashboardData();
        dashboardTimer.Start();

        // İlk dəfə məlumatları yükləyirik
        _ = UpdateDashboardData(); // Fire and forget
    }

    private async Task UpdateDashboardData()
    {
        try
        {
            // Günlük satış məbləğini hesablayırıq
            var hesabatManager = _serviceProvider.GetRequiredService<HesabatManager>();
            var gunlukHesabat = await hesabatManager.GunlukSatisHesabatiGetirAsync(DateTime.Today);
            if (gunlukHesabat.UgurluDur)
            {
                lblDailySalesValue.Text = $"{gunlukHesabat.Data.UmumiDovriyye:N2} AZN";
            }
            else
            {
                lblDailySalesValue.Text = "0.00 AZN";
            }

            // Aktiv növbə məlumatlarını göstəririk
            if (AktivSessiya.AktivNovbeId.HasValue)
            {
                var novbeManager = _serviceProvider.GetRequiredService<NovbeManager>();
                var novbe = await novbeManager.NovbeGetirAsync(AktivSessiya.AktivNovbeId.Value);
                if (novbe.UgurluDur)
                {
                    lblActiveShiftValue.Text = $"{AktivSessiya.AktivIstifadeci?.TamAd}\n{novbe.Data.BaslangicTarixi:HH:mm}";
                }
                else
                {
                    lblActiveShiftValue.Text = "Məlumat tapılmadı";
                }
            }
            else
            {
                lblActiveShiftValue.Text = "Növbə Yoxdur";
            }

            // Borclu müştəri sayını hesablayırıq
            var musteriManager = _serviceProvider.GetRequiredService<MusteriManager>();
            var musteriler = await musteriManager.ButunMusterileriGetirAsync();
            if (musteriler.UgurluDur)
            {
                var borcluMusteriSayi = musteriler.Data.Count(m => m.UmumiBorc > 0);
                lblDebtorCustomersValue.Text = borcluMusteriSayi.ToString();
            }
            else
            {
                lblDebtorCustomersValue.Text = "0";
            }

            // Aşağı stoklu məhsulların sayını hesablayırıq
            var mehsulMeneceri = _serviceProvider.GetRequiredService<MehsulMeneceri>();
            var minimumStokMehsullari = await mehsulMeneceri.MinimumStokMehsullariniGetirAsync();
            if (minimumStokMehsullari.UgurluDur)
            {
                lblLowStockProductsValue.Text = minimumStokMehsullari.Data.Count.ToString();
            }
            else
            {
                lblLowStockProductsValue.Text = "0";
            }
        }
        catch (Exception ex)
        {
            // Xətanı log edirik amma dashboardu ləğv etmirik
            System.Diagnostics.Debug.WriteLine($"Dashboard update error: {ex.Message}");
        }
    }

    #endregion

    #region İcazələr və Düymə Klikləri
    private void IcazeleriYoxla()
    {
        var istifadeci = AktivSessiya.AktivIstifadeci;
        if (istifadeci == null)
        {
            MessageBox.Show("Aktiv istifadəçi sessiyası tapılmadı.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            Application.Exit();
            return;
        }

        this.Text = $"AzAgroPOS - (İstifadəçi: {istifadeci.TamAd})";
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
                if (c is MaterialButton button) button.Enabled = false;
            }
        }

        pnlUserInfo.BackColor = panelColor;
        picUserIcon.Image = CreateInitialsAvatar(istifadeci.TamAd, panelColor);

        btnYeniSatis.Enabled = AktivSessiya.AktivNovbeId.HasValue;
    }

    private void btnMehsulIdareetme_Click(object sender, EventArgs e) => UsaqFormuAc<MehsulIdareetmeFormu>();
    private void btnYeniSatis_Click(object sender, EventArgs e) => UsaqFormuAc<SatisFormu>();
    private void btnQaytarma_Click(object sender, EventArgs e) => UsaqFormuAc<QaytarmaFormu>();
    private void btnNisyeIdareetme_Click(object sender, EventArgs e) => UsaqFormuAc<NisyeIdareetmeFormu>();
    private void btnTemirIdareetme_Click(object sender, EventArgs e) => UsaqFormuAc<TemirIdareetmeFormu>();

    private void btnNovbeIdareetme_Click(object sender, EventArgs e)
    {
        using (var form = _serviceProvider.GetRequiredService<NovbeIdareetmesiFormu>())
        {
            form.ShowDialog();
        }
        IcazeleriYoxla();
    }

    private void btnIstifadeciIdareetme_Click(object sender, EventArgs e) => UsaqFormuAc<IstifadeciIdareetmeFormu>();
    private void btnHesabatlar_Click(object sender, EventArgs e) => UsaqFormuAc<HesabatFormu>();
    private void btnMehsulSatisHesabati_Click(object sender, EventArgs e) => UsaqFormuAc<MehsulSatisHesabatFormu>();
    private void btnAnbarQaliqHesabati_Click(object sender, EventArgs e) => UsaqFormuAc<AnbarQaliqHesabatFormu>();
    private void btnZHesabatArxivi_Click(object sender, EventArgs e) => UsaqFormuAc<ZHesabatArxivFormu>();
    private void btnBarkodCapi_Click(object sender, EventArgs e) => UsaqFormuAc<BarkodCapiFormu>();
    private void btnIsciIdareetme_Click(object sender, EventArgs e) => UsaqFormuAc<IsciIdareetmeFormu>();
    private void btnMinimumStokMehsullari_Click(object sender, EventArgs e) => UsaqFormuAc<MinimumStokMehsullariFormu>(); // Əlavə edildi
    private void btnKonfiqurasiya_Click(object sender, EventArgs e) => UsaqFormuAc<KonfiqurasiyaFormu>(); // Əlavə edildi

    #endregion

    private void AnaMenuFormu_FormClosing(object sender, FormClosingEventArgs e)
    {
        Application.Exit();
    }
}