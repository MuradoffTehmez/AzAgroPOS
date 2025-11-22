// Fayl: AzAgroPOS.Teqdimat/LoginFormu.cs
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
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
            // CAPS LOCK vəziyyətini yoxla
            CapsLockYoxla();

            // "Məni xatırla" seçimi saxlanılıbsa yüklə
            YaddaSaxlananMelumatlarıYukle();

            // Login card-ı mərkəzləşdir
            CenterLoginCard();
        }

        private void CenterLoginCard()
        {
            if (pnlLoginCard != null && pnlMain != null)
            {
                int x = (pnlMain.ClientSize.Width - pnlLoginCard.Width) / 2;
                int y = (pnlMain.ClientSize.Height - pnlLoginCard.Height) / 2 - 20;
                pnlLoginCard.Location = new Point(x, Math.Max(30, y));

                // Shadow paneli də hərəkət etdir
                if (pnlCardShadow != null)
                {
                    pnlCardShadow.Location = new Point(x + 5, y + 8);
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
            // Kartın kənarlarını yuvarlaqlaşdır
            var path = GetRoundedRectPath(new Rectangle(0, 0, pnlLoginCard.Width, pnlLoginCard.Height), 12);
            pnlLoginCard.Region = new Region(path);
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
            // Dairəvi logo konteyneri
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var brush = new SolidBrush(Color.FromArgb(25, 118, 210));
            e.Graphics.FillEllipse(brush, 0, 0, pnlLogoContainer.Width - 1, pnlLogoContainer.Height - 1);

            // Dairəvi region
            var path = new GraphicsPath();
            path.AddEllipse(0, 0, pnlLogoContainer.Width, pnlLogoContainer.Height);
            pnlLogoContainer.Region = new Region(path);
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
