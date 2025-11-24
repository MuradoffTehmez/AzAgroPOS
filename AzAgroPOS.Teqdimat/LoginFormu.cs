// Fayl: AzAgroPOS.Teqdimat/LoginFormu.cs
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using MaterialSkin;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Runtime.InteropServices;

namespace AzAgroPOS.Teqdimat
{
    public partial class LoginFormu : BazaForm, ILoginView
    {
        private LoginPresenter _presenter = null!;
        private bool _parolGorunur = false;
        private bool _girişEdilir = false;
        private System.Windows.Forms.Timer? _loadingTimer;
        private int _loadingDots = 0;

        // CAPS LOCK detection
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern short GetKeyState(int keyCode);
        private const int VK_CAPITAL = 0x14;

        public bool UgurluDaxilOlundu { get; set; } = false;
        public string IstifadeciAdi => txtIstifadeciAdi.Text;
        public string Parol => txtParol.Text;
        public bool MeniXatirla => chkMeniXatirla.Checked;

        public event EventHandler? DaxilOl_Istek;

        public LoginFormu()
        {
            InitializeComponent();

            // Versiya nömrəsini göstər
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            lblVersion.Text = $"v{version?.Major}.{version?.Minor}.{version?.Build}";

            // Hadisələri qoş
            txtParol.KeyUp += TxtParol_KeyUp;
            txtParol.Enter += TxtParol_Enter;
            btnParolGoster.Click += BtnParolGoster_Click;
            this.Load += LoginFormu_Load;
            this.KeyPreview = true;
            this.KeyUp += LoginFormu_KeyUp;

            // Gradient background və dairəvi elementləri konfiqurasiya et
            pnlMain.Paint += PnlMain_Paint;
            pnlLogoContainer.Paint += PnlLogoContainer_Paint;
            pnlCardShadow.Paint += PnlCardShadow_Paint;
            pnlLoginCard.Paint += PnlLoginCard_Paint;

            // Logo üçün placeholder rəng
            picLogo.Paint += PicLogo_Paint;

            // Loading animasiya timer
            _loadingTimer = new System.Windows.Forms.Timer();
            _loadingTimer.Interval = 400;
            _loadingTimer.Tick += LoadingTimer_Tick;
        }

        private void LoginFormu_Load(object? sender, EventArgs e)
        {
            // Kontrolların rənglərini MaterialSkin-dən sonra yenidən təyin et
            RengleriBerpaEt();

            // CAPS LOCK vəziyyətini yoxla
            CapsLockYoxla();

            // "Məni xatırla" seçimi saxlanılıbsa yüklə
            YaddaSaxlananMelumatlarıYukle();

            // Login card-ı mərkəzləşdir - forma tam render olunduqdan sonra
            BeginInvoke(new Action(() => CenterLoginCard()));
        }

        private void RengleriBerpaEt()
        {
            // Ana panel - mavi gradient background
            pnlMain.BackColor = Color.FromArgb(25, 118, 210);

            // Login kartı - ağ
            pnlLoginCard.BackColor = Color.White;

            // Shadow panel - yarı şəffaf
            pnlCardShadow.BackColor = Color.FromArgb(40, 0, 0, 0);

            // Logo konteyneri - mavi
            pnlLogoContainer.BackColor = Color.FromArgb(25, 118, 210);
            picLogo.BackColor = Color.Transparent;

            // Başlıqlar
            lblXosGeldin.BackColor = Color.White;
            lblXosGeldin.ForeColor = Color.FromArgb(25, 118, 210);
            lblXosGeldin.Font = new Font("Segoe UI", 13F, FontStyle.Regular);

            lblBasliq.BackColor = Color.White;
            lblBasliq.ForeColor = Color.FromArgb(33, 33, 33);
            lblBasliq.Font = new Font("Segoe UI", 24F, FontStyle.Bold);

            lblAltBasliq.BackColor = Color.White;
            lblAltBasliq.ForeColor = Color.FromArgb(117, 117, 117);
            lblAltBasliq.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

            // Divider
            pnlDivider.BackColor = Color.FromArgb(224, 224, 224);

            // TextBox-lar
            txtIstifadeciAdi.BackColor = Color.White;
            txtParol.BackColor = Color.White;

            // Parol göstər düyməsi
            btnParolGoster.BackColor = Color.Transparent;
            btnParolGoster.Font = new Font("Segoe UI", 14F);

            // CAPS LOCK xəbərdarlığı
            lblCapsLock.BackColor = Color.FromArgb(255, 235, 238);
            lblCapsLock.ForeColor = Color.FromArgb(244, 67, 54);
            lblCapsLock.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            // Checkbox
            chkMeniXatirla.BackColor = Color.White;

            // Loading panel
            pnlLoading.BackColor = Color.FromArgb(25, 118, 210);
            lblLoading.BackColor = Color.FromArgb(25, 118, 210);
            lblLoading.ForeColor = Color.White;
            lblLoading.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            picLoading.BackColor = Color.Transparent;

            // Version və Copyright
            lblVersion.BackColor = Color.Transparent;
            lblVersion.ForeColor = Color.FromArgb(200, 255, 255, 255);
            lblVersion.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

            lblCopyright.BackColor = Color.Transparent;
            lblCopyright.ForeColor = Color.FromArgb(200, 255, 255, 255);
            lblCopyright.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

            // Panelləri yenidən çək
            pnlMain.Invalidate();
            pnlLoginCard.Invalidate();
            pnlLogoContainer.Invalidate();
        }

        private void CenterLoginCard()
        {
            if (pnlLoginCard != null && pnlMain != null)
            {
                // Form tam yüklənməyibsə çıx
                if (pnlMain.ClientSize.Width <= 0 || pnlMain.ClientSize.Height <= 0)
                    return;

                int x = (pnlMain.ClientSize.Width - pnlLoginCard.Width) / 2;
                int y = (pnlMain.ClientSize.Height - pnlLoginCard.Height) / 2 - 20;
                pnlLoginCard.Location = new Point(Math.Max(0, x), Math.Max(30, y));

                // Shadow paneli də hərəkət etdir
                if (pnlCardShadow != null)
                {
                    pnlCardShadow.Location = new Point(Math.Max(5, x + 5), Math.Max(38, y + 8));
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            CenterLoginCard();
        }

        private void PnlMain_Paint(object? sender, PaintEventArgs e)
        {
            // Gradient background çək
            using var brush = new LinearGradientBrush(
                pnlMain.ClientRectangle,
                Color.FromArgb(25, 118, 210),  // Mavi
                Color.FromArgb(21, 101, 192),  // Daha tünd mavi
                LinearGradientMode.ForwardDiagonal);
            e.Graphics.FillRectangle(brush, pnlMain.ClientRectangle);
        }

        private void PnlLoginCard_Paint(object? sender, PaintEventArgs e)
        {
            // Kartın kənarlarını yuvarlaqlaşdır (vizual olaraq, Region olmadan)
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var path = GetRoundedRectPath(new Rectangle(0, 0, pnlLoginCard.Width, pnlLoginCard.Height), 12);
            using var brush = new SolidBrush(pnlLoginCard.BackColor);
            e.Graphics.FillPath(brush, path);
        }

        private void PnlCardShadow_Paint(object? sender, PaintEventArgs e)
        {
            // Kölgəni yarı-şəffaf çək
            using var brush = new SolidBrush(Color.FromArgb(30, 0, 0, 0));
            var path = GetRoundedRectPath(new Rectangle(0, 0, pnlCardShadow.Width, pnlCardShadow.Height), 12);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillPath(brush, path);
        }

        private void PnlLogoContainer_Paint(object? sender, PaintEventArgs e)
        {
            // Dairəvi logo konteyneri (Region olmadan, yalnız vizual)
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var brush = new SolidBrush(Color.FromArgb(25, 118, 210));
            e.Graphics.FillEllipse(brush, 0, 0, pnlLogoContainer.Width - 1, pnlLogoContainer.Height - 1);
        }

        private void PicLogo_Paint(object? sender, PaintEventArgs e)
        {
            // Logo olmadıqda "AZ" yazısı göstər
            if (picLogo.Image == null)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                using var font = new Font("Segoe UI", 22F, FontStyle.Bold);
                using var brush = new SolidBrush(Color.White);
                var text = "AZ";
                var size = e.Graphics.MeasureString(text, font);
                var x = (picLogo.Width - size.Width) / 2;
                var y = (picLogo.Height - size.Height) / 2;
                e.Graphics.DrawString(text, font, brush, x, y);
            }
        }

        private void LoadingTimer_Tick(object? sender, EventArgs e)
        {
            _loadingDots = (_loadingDots + 1) % 4;
            var dots = new string('.', _loadingDots);
            lblLoading.Text = $"Giriş edilir{dots}";
        }

        private static GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
            path.AddArc(rect.Right - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90);
            path.AddArc(rect.Right - radius * 2, rect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseFigure();
            return path;
        }

        public void InitializePresenter(LoginPresenter presenter)
        {
            _presenter = presenter;
        }

        private void LoginFormu_KeyUp(object? sender, KeyEventArgs e)
        {
            CapsLockYoxla();
        }

        private void TxtParol_KeyUp(object? sender, KeyEventArgs e)
        {
            CapsLockYoxla();
        }

        private void TxtParol_Enter(object? sender, EventArgs e)
        {
            CapsLockYoxla();
        }

        private void CapsLockYoxla()
        {
            bool capsLockAktiv = (GetKeyState(VK_CAPITAL) & 1) == 1;
            lblCapsLock.Visible = capsLockAktiv;
        }

        private void BtnParolGoster_Click(object? sender, EventArgs e)
        {
            _parolGorunur = !_parolGorunur;

            if (_parolGorunur)
            {
                txtParol.PasswordChar = '\0';
                btnParolGoster.Text = "🙈";
            }
            else
            {
                txtParol.PasswordChar = '●';
                btnParolGoster.Text = "👁";
            }
        }

        private void btnDaxilOl_Click(object sender, EventArgs e)
        {
            if (_girişEdilir) return;

            YuklemeGoster();
            DaxilOl_Istek?.Invoke(this, EventArgs.Empty);
        }

        public void YuklemeGoster()
        {
            _girişEdilir = true;
            btnDaxilOl.Visible = false;
            pnlLoading.Visible = true;
            txtIstifadeciAdi.Enabled = false;
            txtParol.Enabled = false;
            chkMeniXatirla.Enabled = false;
            btnParolGoster.Enabled = false;

            // Loading animasiyasını başlat
            _loadingDots = 0;
            lblLoading.Text = "Giriş edilir";
            _loadingTimer?.Start();
        }

        public void YuklemeGizle()
        {
            _girişEdilir = false;
            btnDaxilOl.Visible = true;
            pnlLoading.Visible = false;
            txtIstifadeciAdi.Enabled = true;
            txtParol.Enabled = true;
            chkMeniXatirla.Enabled = true;
            btnParolGoster.Enabled = true;

            // Loading animasiyasını dayandır
            _loadingTimer?.Stop();
        }

        public void MesajGoster(string mesaj)
        {
            YuklemeGizle();
            MessageBox.Show(mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void FormuBagla()
        {
            // "Məni xatırla" seçilibsə məlumatları saxla
            if (chkMeniXatirla.Checked)
            {
                MelumatlarıYaddaSaxla();
            }
            else
            {
                YaddaSaxlananMelumatlariSil();
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private static readonly string _settingsPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "AzAgroPOS", "login_settings.txt");

        private void MelumatlarıYaddaSaxla()
        {
            try
            {
                var dir = Path.GetDirectoryName(_settingsPath);
                if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                    Directory.CreateDirectory(dir);

                File.WriteAllText(_settingsPath, txtIstifadeciAdi.Text);
            }
            catch
            {
                // Ayarlar saxlanıla bilmirsə səssiz keç
            }
        }

        private void YaddaSaxlananMelumatlarıYukle()
        {
            try
            {
                if (File.Exists(_settingsPath))
                {
                    var savedUsername = File.ReadAllText(_settingsPath);
                    if (!string.IsNullOrWhiteSpace(savedUsername))
                    {
                        txtIstifadeciAdi.Text = savedUsername;
                        chkMeniXatirla.Checked = true;
                        txtParol.Focus();
                    }
                }
            }
            catch
            {
                // Ayarlar oxuna bilmirsə səssiz keç
            }
        }

        private void YaddaSaxlananMelumatlariSil()
        {
            try
            {
                if (File.Exists(_settingsPath))
                    File.Delete(_settingsPath);
            }
            catch
            {
                // Səssiz keç
            }
        }

        public void XetaGoster(Control control, string message)
        {
            YuklemeGizle();
            errorProvider1.SetError(control, message);
            errorProvider1.SetIconAlignment(control, ErrorIconAlignment.MiddleRight);
            errorProvider1.SetIconPadding(control, 2);
        }

        public void XetaniTemizle(Control control)
        {
            errorProvider1.SetError(control, string.Empty);
        }

        public void ButunXetalariTemizle()
        {
            foreach (Control control in this.Controls)
            {
                ClearErrorsRecursive(control);
            }
        }

        private void ClearErrorsRecursive(Control control)
        {
            errorProvider1.SetError(control, string.Empty);
            foreach (Control child in control.Controls)
            {
                ClearErrorsRecursive(child);
            }
        }
    }
}
