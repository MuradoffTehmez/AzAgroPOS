using AzAgroPOS.Entities;
using AzAgroPOS.PL.Themes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AzAgroPOS.PL
{
    /// <summary>
    /// Əsas proqram pəncərəsi. Bütün digər formlar bu pəncərədən idarə olunur.
    /// İndi sol tərəfdə genişlənə bilən alt menyular dəstəklənir.
    /// </summary>
    public partial class frmMain : BaseForm
    {
        private readonly Istifadeci _currentUser;
        private Form _activeForm = null;
        private Button _sonBasilanMenuDuyumesi = null;
        private Panel _altMenuPaneli = null;

        /// <summary>
        /// frmMain konstruktoru. Daxil olmuş istifadəçi məlumatlarını qəbul edir.
        /// </summary>
        /// <param name="user">Daxil olmuş istifadəçi obyekti</param>
        /// <exception cref="ArgumentNullException">user parametri null olduqda baş verir</exception>
        public frmMain(Istifadeci user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "İstifadəçi məlumatları boş ola bilməz");
            }

            InitializeComponent();
            _currentUser = user;
            AltMenuSisteminiBaslat();
        }

        #region İlkin Qurulum

        /// <summary>
        /// Alt menyu sistemini işə salır və ilkin konfiqurasiyanı edir.
        /// </summary>
        private void AltMenuSisteminiBaslat()
        {
            // Əsas menyu paneli
            panelYanMenu.BackColor = Color.FromArgb(51, 51, 76);

            // Alt menyu panelini yaradırıq
            _altMenuPaneli = new Panel
            {
                BackColor = Color.FromArgb(39, 39, 58),
                Width = panelYanMenu.Width,
                Visible = false
            };
            panelYanMenu.Controls.Add(_altMenuPaneli);
            _altMenuPaneli.BringToFront();
        }

        /// <summary>
        /// Alt menyu elementlərini yaradır və konfiqurasiya edir.
        /// </summary>
        /// <param name="anaDuyume">Ana menyu düyməsi</param>
        /// <param name="altMenyuElementleri">Alt menyu elementləri massivi</param>
        private void AltMenyuYarat(Button anaDuyume, (string Metn, EventHandler ClickHandler)[] altMenyuElementleri)
        {
            // Köhnə alt menyu elementlərini təmizləyirik
            _altMenuPaneli.Controls.Clear();

            // Alt menyu elementlərini yaradırıq
            int yPozisiyasi = 0;
            foreach (var element in altMenyuElementleri)
            {
                var altDuyume = new Button
                {
                    Text = element.Metn,
                    FlatStyle = FlatStyle.Flat,
                    ForeColor = Color.Gainsboro,
                    BackColor = Color.FromArgb(39, 39, 58),
                    Width = _altMenuPaneli.Width,
                    Height = 45,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(35, 0, 0, 0),
                    Tag = anaDuyume,
                    Dock = DockStyle.Top
                };
                altDuyume.FlatAppearance.BorderSize = 0;
                altDuyume.Click += element.ClickHandler;
                altDuyume.Click += AltMenyuElementiKlik;

                _altMenuPaneli.Controls.Add(altDuyume);
                altDuyume.BringToFront();
                yPozisiyasi += altDuyume.Height;
            }

            // Alt menyu panelinin ölçüsünü tənzimləyirik
            _altMenuPaneli.Height = yPozisiyasi;
            _altMenuPaneli.Location = new Point(0, anaDuyume.Location.Y + anaDuyume.Height);
            _altMenuPaneli.Visible = true;
            _altMenuPaneli.BringToFront();
        }

        #endregion

        #region Form Hadisələri

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                lblCurrentUser.Text = $"İstifadəçi: {_currentUser.Ad} {_currentUser.Soyad} ({_currentUser.RolAdi})";

                // Rol əsaslı giriş nəzarəti
                if (_currentUser.RolAdi != "Admin")
                {
                    btnSettings.Visible = false;
                }

                // Dashboardu ilkin olaraq açırıq
                btnDashboard_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Form yüklənərkən xəta baş verdi: {ex.Message}",
                    "Xəta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Menyu Əməliyyatları

        /// <summary>
        /// Ana menyu düyməsinə klik edildikdə işə düşür.
        /// Uyğun alt menyunu göstərir və ya gizlədir.
        /// </summary>
        private void AnaMenyuDuyumesiKlik(object sender, EventArgs e)
        {
            var basilanDuyume = (Button)sender;

            // Eyni düyməyə yenidən kliklənibsə, alt menyunu bağlayırıq
            if (_sonBasilanMenuDuyumesi == basilanDuyume)
            {
                _altMenuPaneli.Visible = false;
                _sonBasilanMenuDuyumesi = null;
                return;
            }

            // Yeni alt menyunu konfiqurasiya edirik
            switch (basilanDuyume.Name)
            {
                case "btnSales":
                    AltMenyuYarat(basilanDuyume, new (string, EventHandler)[]
                    {
                        ("Yeni Satış", (s, args) => PaneldəFormAç(new frmSales(_currentUser))),
                        ("Satış Qaytarma", (s, args) => SatışQaytarmaFormunuAç()),
                        //("Satış Siyahısı", (s, args) => PaneldəFormAç(new frmSalesList(_currentUser)))
                    });
                    break;

                case "btnProducts":
                    AltMenyuYarat(basilanDuyume, new (string, EventHandler)[]
                    {
                        ("Məhsul Siyahısı", (s, args) => PaneldəFormAç(new frmProducts(_currentUser))),
                        //("Məhsul Qrupları", (s, args) => PaneldəFormAç(new frmProductGroups())),
                        //("Stok Əməliyyatları", (s, args) => PaneldəFormAç(new frmStockOperations()))
                    });
                    break;

                case "btnCustomers":
                    AltMenyuYarat(basilanDuyume, new (string, EventHandler)[]
                    {
                        ("Müştəri Siyahısı", (s, args) => PaneldəFormAç(new frmCustomers(_currentUser))),
                        //("Müştəri Qrupları", (s, args) => PaneldəFormAç(new frmCustomerGroups()))
                    });
                    break;

                case "btnReports":
                    AltMenyuYarat(basilanDuyume, new (string, EventHandler)[]
                    {
                        ("Satış Hesabatları", (s, args) => PaneldəFormAç(new frmSalesReport())),
                        //("Məhsul Hesabatları", (s, args) => PaneldəFormAç(new frmProductReports())),
                        //("Maliyyə Hesabatları", (s, args) => PaneldəFormAç(new frmFinancialReports()))
                    });
                    break;

                case "btnSettings":
                    AltMenyuYarat(basilanDuyume, new (string, EventHandler)[]
                    {
                        ("İstifadəçilər", (s, args) => PaneldəFormAç(new frmUsers(_currentUser))),
                        ("Parametrlər", (s, args) => PaneldəFormAç(new frmSettings())),
                        ("Əməliyyat Jurnalı", (s, args) => AuditJurnalınıAç())
                    });
                    break;

                default:
                    // Alt menyu tələb etməyən düymələr üçün (Dashboard kimi)
                    _altMenuPaneli.Visible = false;
                    break;
            }

            _sonBasilanMenuDuyumesi = basilanDuyume;
        }

        /// <summary>
        /// Alt menyu elementinə klik edildikdə işə düşür.
        /// Ana menyu düyməsinin görünüşünü yeniləyir.
        /// </summary>
        private void AltMenyuElementiKlik(object sender, EventArgs e)
        {
            var altDuyume = (Button)sender;
            var anaDuyume = (Button)altDuyume.Tag;

            // Ana menyu düyməsini vurğulayırıq
            AnaMenyuDuyumesiniVurgula(anaDuyume);
        }

        /// <summary>
        /// Ana menyu düyməsini vurğulayır.
        /// </summary>
        private void AnaMenyuDuyumesiniVurgula(Button anaDuyume)
        {
            // Bütün ana menyu düymələrini standart vəziyyətə gətiririk
            foreach (Control kontrol in panelYanMenu.Controls)
            {
                if (kontrol is Button btn && btn != anaDuyume)
                {
                    btn.BackColor = Color.FromArgb(51, 51, 76);
                }
            }

            // Seçilmiş düyməni vurğulayırıq
            anaDuyume.BackColor = Color.FromArgb(0, 150, 136);
        }

        #endregion

        #region Form İdarəetmə

        /// <summary>
        /// Verilmiş pəncərəni əsas məzmun panelinin içində açır.
        /// </summary>
        /// <param name="uşaqForm">Açılacaq form</param>
        private void PaneldəFormAç(Form uşaqForm)
        {
            try
            {
                if (uşaqForm == null)
                {
                    throw new ArgumentNullException(nameof(uşaqForm), "Açılacaq form boş ola bilməz");
                }

                if (_activeForm != null)
                {
                    _activeForm.Close();
                }

                _activeForm = uşaqForm;
                uşaqForm.TopLevel = false;
                uşaqForm.FormBorderStyle = FormBorderStyle.None;
                uşaqForm.Dock = DockStyle.Fill;
                panelMainContent.Controls.Add(uşaqForm);
                panelMainContent.Tag = uşaqForm;
                uşaqForm.BringToFront();
                uşaqForm.Show();
                lblTitle.Text = uşaqForm.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Form açıla bilmədi: {ex.Message}",
                    "Xəta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Düymə Klik Hadisələri

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            try
            {
                _altMenuPaneli.Visible = false;
                AnaMenyuDuyumesiniVurgula(btnDashboard);
                PaneldəFormAç(new frmDashboard());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Dashboard açıla bilmədi: {ex.Message}",
                    "Xəta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            AnaMenyuDuyumesiKlik(sender, e);
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            AnaMenyuDuyumesiKlik(sender, e);
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            AnaMenyuDuyumesiKlik(sender, e);
        }

        private void btnRepairs_Click(object sender, EventArgs e)
        {
            try
            {
                _altMenuPaneli.Visible = false;
                AnaMenyuDuyumesiniVurgula(btnRepairs);
                PaneldəFormAç(new frmRepairs(_currentUser));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Təmir pəncərəsi açıla bilmədi: {ex.Message}",
                    "Xəta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            AnaMenyuDuyumesiKlik(sender, e);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            AnaMenyuDuyumesiKlik(sender, e);
        }

        #endregion

        #region Əlavə Funksionallıq

        private void SatışQaytarmaFormunuAç()
        {
            try
            {
                var qaytarmaFormu = new frmReturn(_currentUser);
                qaytarmaFormu.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Satış qaytarılarkən xəta: {ex.Message}",
                    "Xəta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void AuditJurnalınıAç()
        {
            try
            {
                var jurnalFormu = new frmAuditLog();
                jurnalFormu.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Əməliyyat jurnalı açıla bilmədi: {ex.Message}",
                    "Xəta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        #endregion

        //private void btnToggleTheme_Click(object sender, EventArgs e)
        //{
        //    // Temanı dəyişirik
        //    ThemeManager.CurrentTheme = (ThemeManager.CurrentTheme == AppTheme.Light) ? AppTheme.Dark : AppTheme.Light;

        //    // Proqramı yenidən başlatmaq yerinə, sadəcə ana pəncərəni yenidən yaradırıq
        //    // Bu, bütün stillərin yenidən tətbiq olunmasını təmin edəcək
        //    this.Hide();
        //    var newMainForm = new frmMain(_currentUser); // _currentUser sahəsinin mövcud olduğundan əmin olun
        //    newMainForm.FormClosed += (s, args) => this.Close();
        //    newMainForm.Show();
        //}
    }
}